using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CoreTweet;

namespace Mystter_Console {
    public class Twitter {
        private static Tokens twitter;

        public static void Init() {
            if (Program.settings.Selected != "null") {
                var _account = SearchUserFromName(Program.settings.Selected);
                twitter = CreateTokens(_account.Token, _account.Secret);
            }
            Command.ReadCommand();
        }

        public static void AddAccount(string name) {
            while (true) {
                try {
                    var s = OAuth.Authorize(SecretKeys.ConsumerKey, SecretKeys.ConsumerSecret);
                    Process.Start(s.AuthorizeUri.AbsoluteUri);
                    Console.WriteLine("PIN を入力してください。");
                    twitter = s.GetTokens(Command.ReadLine());
                    SetCurrentUser(name);
                    SaveAccount(twitter, name);
                    Console.WriteLine($"アカウント {name} を追加しました。");
                    break;
                } catch (TwitterException ex) {
                    // TODO: PIN が不正だった場合にはどうするか・・・。
                    if (ex.Message == "Error processing your OAuth request: Invalid oauth_verifier parameter") {
                        var reOauth = Command.TakeConfirm("不正なPINです。再認証しますか？");
                        if (reOauth) {
                            continue;
                        } else {
                            break;
                        }
                    }
                    Console.WriteLine("TwitterException が発生しました。");
                    throw;
                }
            }
        }

        public static void SwitchAccount(string name) {
            var _account = SearchUserFromName(name);
            if (_account != null) {
                twitter = CreateTokens(_account.Token, _account.Secret);
                SetCurrentUser(name);
                Console.WriteLine($"アカウント {name} に切り替えました。");
            } else {
                Console.WriteLine($"アカウント {name} は存在しません。");
            }
        }

        public static void DeleteAccount(string name) {
            if (IsExistName(name)) {
                var index = GetIndexFromName(name);
                Program.settings.Accounts.RemoveAt(index);
                if (name == GetCurrentUser()) {
                    twitter = null;
                    SetCurrentUser("null");
                }
                Console.WriteLine($"アカウント {name} を削除しました。");
            } else {
                Console.WriteLine($"アカウント {name} は存在しません。");
            }
        }

        public static void DeleteTweet(int index) {
            if (index <= 200 && index > 0) {
                var targetTweet = twitter.Statuses.UserTimeline(screen_name: GetCurrentUser(), count: index).Last();
                var confirm = Command.TakeConfirm($"{targetTweet.Text}\nを削除しますか？");
                if (confirm) {
                    twitter.Statuses.Destroy(targetTweet.Id);
                    Console.WriteLine("ツイートを削除しました。");
                } else {
                    Console.WriteLine("ツイートの削除をキャンセルしました。");
                }
            } else {
                Console.WriteLine("削除できるツイートは２００件前までです。");
            }
        }

        public static string GetTweets(int count) {
            if (count <= 200 && count > 0) {
                var tweets = twitter.Statuses.UserTimeline(screen_name: GetCurrentUser(), count: count);
                var tweetsList = new string[tweets.Count];
                for (int i = 0; i < tweets.Count; i++) {
                    var user = tweets[i].User.Name + " : " + tweets[i].User.ScreenName + " : " + tweets[i].CreatedAt.LocalDateTime.ToString("M月d日 H時m分s秒");
                    var text = tweets[i].Text;
                    tweetsList[i] = user + "\n" + text;
                }
                var tweetsStr = string.Join("\n----------\n", tweetsList);
                return tweetsStr;
            } else {
                return "取得できるツイートは２００件までです。";
            }
        }

        public static string GetCurrentUser() {
            return Program.settings.Selected;
        }

        public static Account SearchUserFromName(string name) {
            foreach (var _account in Program.settings.Accounts) {
                if (_account.Name == name) {
                    return _account;
                }
            }
            return null;
        }

        public static int GetAccountCount() {
            var accountCount = Program.settings.Accounts.Count;
            return accountCount;
        }

        public static string[] GetAccountNames() {
            var accountNames = Program.settings.Accounts.Select(a => a.Name).ToArray();
            return accountNames;
        }

        public static int GetIndexFromName(string name) {
            for (int i = 0; i < Program.settings.Accounts.Count; i++) {
                if (Program.settings.Accounts[i].Name == name) {
                    return i;
                }
            }
            return -1;
        }

        public static bool IsExistName(string name) {
            foreach (var _account in Program.settings.Accounts) {
                if (_account.Name == name)
                    return true;
            }
            return false;
        }

        public static bool IsExistScreen(string screen) {
            foreach (var _account in Program.settings.Accounts) {
                if (_account.Screen == screen)
                    return true;
            }
            return false;
        }

        public static void SendTweet(string msg) {
            try {
                if (twitter == null) {
                    Console.WriteLine("アカウントは設定されていません。");
                    return;
                }
                if (string.IsNullOrEmpty(msg)) {
                    Console.WriteLine("ツイートは入力されていません。");
                    return;
                }
                if (msg.Length > 140) {
                    Console.WriteLine("ツイートは１４０文字以内にしてください。");
                    return;
                }
                twitter.Statuses.Update(status: msg);
                Console.WriteLine("ツイートは投稿されました。");
            } catch (TwitterException) {
                Console.WriteLine("TwitterException が発生しました。");
                throw;
            }
        }

        private static void SaveAccount(Tokens _tokens, string name) {
            var _account = new Account();
            _account.Name = name;
            _account.Token = _tokens.AccessToken;
            _account.Secret = _tokens.AccessTokenSecret;
            _account.Screen = _tokens.ScreenName;
            Program.settings.Accounts.Add(_account);
            Program.settings.Save(Program.settings);
        }

        private static void SetCurrentUser(string name) {
            Program.settings.Selected = name;
        }

        private static Tokens CreateTokens(string AccessToken, string AccessSecret) {
            var _tokens = Tokens.Create(SecretKeys.ConsumerKey, SecretKeys.ConsumerSecret, AccessToken, AccessSecret);
            return _tokens;
        }
    }
}
