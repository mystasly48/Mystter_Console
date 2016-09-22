using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mystter_Console {
    public class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Mystter - Console");
            Console.WriteLine("help でコマンドを確認することができます。");
            Command.Read();
        }
    }
}
