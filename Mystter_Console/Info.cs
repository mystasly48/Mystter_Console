namespace Mystter_Console {
    public class Info {
        public static readonly string Name = "Mystter - Console";

        public static string GetCurrentDirectory() {
            return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }
    }
}
