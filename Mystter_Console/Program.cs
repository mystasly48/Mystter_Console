using System;

namespace Mystter_Console {
    public class Program {
        public static Settings settings = new Settings();
        public static void Main(string[] args) {
            settings = settings.Load();
            Console.WriteLine("Mystter - Console");
            Console.WriteLine("help でコマンドを確認することができます。");
            Twitter.Init();
            settings.Save(settings);
        }
    }
}
