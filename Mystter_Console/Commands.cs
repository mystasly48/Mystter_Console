namespace Mystter_Console {
    public class Commands {
        public static readonly string Help = "help";
        public static readonly string Exit = "exit";
        public static readonly string Clear = "clear";
        public static readonly string Current = "current";
        public static readonly string List = "list";
        public static readonly string Add = "add ";
        public static readonly string Switch = "switch ";
        public static readonly string Tweet = "tweet ";
        public static readonly string Tweets = "tweets ";
        public static readonly string Delete = "delete ";
        public static readonly string Remove = "remove ";
        public static readonly string Image = "image ";

        public static readonly string HelpInfo = "help - ヘルプを表示";
        public static readonly string ExitInfo = "exit - プログラムを終了";
        public static readonly string ClearInfo = "clear - コンソールを初期化";
        public static readonly string CurrentInfo = "current - ログイン中のアカウントを表示";
        public static readonly string ListInfo = "list - 登録されているアカウントを表示";
        public static readonly string AddInfo = "add [名前] - アカウントを登録";
        public static readonly string SwitchInfo = "switch [名前] - アカウントを切り替え";
        public static readonly string TweetInfo = "tweet [文字列] - 文字列をツイート";
        public static readonly string TweetsInfo = "tweets [数値] - 過去ツイートを[数値]件表示（最大２００件）";
        public static readonly string DeleteInfo = "delete [数値] - [数値]前のツイートを削除（最大２００件前）";
        public static readonly string RemoveInfo = "remove [名前] - 登録されているアカウント[名前]を削除";
        public static readonly string ImageInfo = "image [文字列] [場所] - 画像[場所]を添付して[文字列]をツイート" + " *未実装*";
    }
}
