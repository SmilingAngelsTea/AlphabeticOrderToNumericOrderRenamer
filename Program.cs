using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphabeticOrderToNumericOrderRenamer {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("AlphabeticOrderToNumericOrderRenamer\n");
            string path = "";
            if (args.Length < 1) {
                Console.WriteLine("No location specified. Using the current working directory.");
                path = Directory.GetCurrentDirectory();
            } else {
                path = args[0];
            }
            Console.WriteLine("Path: " + path);
            string[] files = Directory.GetFiles(path).OrderBy(f => f).ToArray();
            for(int i = 0; i < files.Length; i++) {
                string number = "";
                if(i < 10) {
                    number = "0" + i.ToString();
                } else {
                    number = i.ToString();
                }
                string outer = Path.GetFileName(files[i]) + " to " + number + Path.GetExtension(files[i]);
                try {
                    File.Move(files[i], path + "\\" + number + Path.GetExtension(files[i]));
                } catch {
                    outer = outer + " failed.";
                    Console.WriteLine(outer);
                }
                outer = outer + " succeeded.";
                Console.WriteLine(outer);
            }
        }
    }
}
