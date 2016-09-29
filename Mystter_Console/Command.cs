using System;

namespace Mystter_Console {
    public class Command {
        public static string ReadLine() {
            Console.Write(">> ");
            return Console.ReadLine();
        }

        public static void ReadCommand() {
            SwitchCommands(ReadLine());
        }

        public static bool TakeConfirm(string question) {
            while (true) {
                Console.WriteLine(question + "(y/n)");
                var input = ReadLine();
                if (input == "y") {
                    return true;
                }
                if (input == "n") {
                    return false;
                }
            }
        }

        public static bool CanConvertToInt(string str) {
            int i;
            var canConvert = int.TryParse(str, out i);
            return canConvert;
        }

        private static void SwitchCommands(string str) {
            if (str.Contains(Commands.Help)) {
                Console.WriteLine(Commands.HelpInfo);
                Console.WriteLine(Commands.ExitInfo);
                Console.WriteLine(Commands.ClearInfo);
                Console.WriteLine(Commands.CurrentInfo);
                Console.WriteLine(Commands.ListInfo);
                Console.WriteLine(Commands.AddInfo);
                Console.WriteLine(Commands.SwitchInfo);
                Console.WriteLine(Commands.TweetInfo);
                Console.WriteLine(Commands.TweetsInfo);
                Console.WriteLine(Commands.DeleteInfo);
                Console.WriteLine(Commands.RemoveInfo);
                Console.WriteLine(Commands.ImageInfo);
            } else if (str.Contains(Commands.Exit)) {
                return;
            } else if (str.Contains(Commands.Clear)) {
                Console.Clear();
            } else if (str.Contains(Commands.Current)) {
                var current = Twitter.GetCurrentUser();
                if (current == "null") {
                    Console.WriteLine("アカウントは設定されていません。");
                } else {
                    Console.WriteLine(current);
                }
            } else if (str.Contains(Commands.List)) {
                if (Twitter.GetAccountCount() != 0) {
                    foreach (var s in Twitter.GetAccountNames())
                        Console.WriteLine(s);
                } else {
                    Console.WriteLine("アカウントは追加されていません。");
                }
            } else if (str.Contains(Commands.Add)) {
                var param = ExtractParam(str, Commands.Add);
                Twitter.AddAccount(param);
            } else if (str.Contains(Commands.Switch)) {
                var param = ExtractParam(str, Commands.Switch);
                Twitter.SwitchAccount(param);
            } else if (str.Contains(Commands.Tweet)) {
                var param = ExtractParam(str, Commands.Tweet);
                Twitter.SendTweet(param);
            } else if (str.Contains(Commands.Tweets)) {
                var param = ExtractParam(str, Commands.Tweets);
                if (CanConvertToInt(param)) {
                    Console.WriteLine(Twitter.GetTweets(int.Parse(param)));
                } else {
                    Console.WriteLine("引数は数値で入力してください。");
                }
            } else if (str.Contains(Commands.Delete)) {
                var param = ExtractParam(str, Commands.Delete);
                if (CanConvertToInt(param)) {
                    Twitter.DeleteTweet(int.Parse(param));
                } else {
                    Console.WriteLine("引数は数値で入力してください。");
                }
            } else if (str.Contains(Commands.Remove)) {
                var param = ExtractParam(str, Commands.Remove);
                Twitter.DeleteAccount(param);
            } else if (str.Contains(Commands.Image)) {
                var param = ExtractParam(str, Commands.Image);
                Console.WriteLine("申し訳ありませんが、このコマンドは現在実装中です。");
            } else {
                Console.WriteLine("不明なコマンドです。 help でコマンドを確認することができます。");
            }
            ReadCommand();
        }

        private static string ExtractParam(string text, string cmd) {
            var param = text.Substring(cmd.Length); 
            return param;
        }
    }
}
