using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mystter_Console {
    public class Command {
        public static void Read() {
            Console.Write(">> ");
            SwitchCommands(GetCommand(Console.ReadLine()));
        }

        private static Commands GetCommand(string str) {
            if (str.Contains("help")) return Commands.Help;
            if (str.Contains("exit")) return Commands.Exit;
            if (str.Contains("clear")) return Commands.Clear;
            if (str.Contains("current ")) return Commands.Current;
            if (str.Contains("list ")) return Commands.List;
            if (str.Contains("add ")) return Commands.Add;
            if (str.Contains("switch ")) return Commands.Switch;
            if (str.Contains("tweet ")) return Commands.Tweet;
            if (str.Contains("tweets ")) return Commands.Tweets;
            if (str.Contains("delete ")) return Commands.Delete;
            if (str.Contains("remove ")) return Commands.Remove;
            if (str.Contains("media ")) return Commands.Media;
            return Commands.Unknown;
        }

        private static void SwitchCommands(Commands cmd) {
            switch (cmd) {
                case Commands.Help:
                    ShowHelp();
                    break;

                case Commands.Exit:
                    return;

                case Commands.Clear:
                    Console.Clear();
                    break;

                case Commands.Current:

                    break;

                case Commands.List:

                    break;

                case Commands.Add:

                    break;

                case Commands.Switch:

                    break;

                case Commands.Tweet:

                    break;

                case Commands.Tweets:

                    break;

                case Commands.Delete:

                    break;

                case Commands.Remove:

                    break;

                case Commands.Media:

                    break;

                case Commands.Unknown:
                    Console.WriteLine("不明なコマンドです。 help でコマンドを確認することができます。");
                    break;
            }
            Read();
        }

        private enum Commands {
            Unknown,
            Help,
            Exit,
            Clear,
            Current,
            List,
            Add,
            Switch,
            Tweet,
            Tweets,
            Delete,
            Remove,
            Media
        }

        private static void ShowHelp() {
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
            Console.WriteLine("media [文字列] [場所] - メディア[場所]を添付して[文字列]をツイート *未実装*");
        }
    }
}
