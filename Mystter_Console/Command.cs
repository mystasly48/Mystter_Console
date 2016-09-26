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

        private static void SwitchCommands(string str) {
            if (str.Contains(Commands.Help)) {
                Console.WriteLine("help - ヘルプを表示");
                Console.WriteLine("exit - プログラムを終了");
                Console.WriteLine("clear - コンソールを初期化");
                Console.WriteLine("current - ログイン中のアカウントを表示");
                Console.WriteLine("list - 登録されているアカウントを表示 *未実装*");
                Console.WriteLine("add [名前] - アカウントを登録");
                Console.WriteLine("switch [名前] - アカウントを切り替え");
                Console.WriteLine("tweet [文字列] - 文字列をツイート");
                Console.WriteLine("tweets [数値] - 過去ツイートを[数値]件表示（最大５０件） *未実装*");
                Console.WriteLine("delete [数値] - [数値]前のツイートを削除（最大２００件前） *未実装*");
                Console.WriteLine("remove [名前] - 登録されているアカウント[名前]を削除 *未実装*");
                Console.WriteLine("image [文字列] [場所] - 画像[場所]を添付して[文字列]をツイート *未実装*");
            } else if (str.Contains(Commands.Exit)) {
                return;
            } else if (str.Contains(Commands.Clear)) {
                Console.Clear();
            } else if (str.Contains(Commands.Current)) {
                Console.WriteLine(Twitter.GetCurrentUser());
            } else if (str.Contains(Commands.List)) {
                foreach (var s in Twitter.GetAccountNames()) Console.WriteLine(s);
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
                Console.WriteLine("申し訳ありませんが、このコマンドは現在実装中です。");
            } else if (str.Contains(Commands.Delete)) {
                var param = ExtractParam(str, Commands.Delete);
                Console.WriteLine("申し訳ありませんが、このコマンドは現在実装中です。");
            } else if (str.Contains(Commands.Remove)) {
                var param = ExtractParam(str, Commands.Remove);
                Console.WriteLine("申し訳ありませんが、このコマンドは現在実装中です。");
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
