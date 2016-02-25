using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace JSerial
{
    class Program
    {
        static void Main(string[] args)
        {
            string x = "x";
            JSerialize(x, x, x);
        }

        public static string JSerialize(string name, string permission, string type)
        {
            bool file_exist = File.Exists("C:\\jsons\\user.json");
            if (file_exist == true)
            {
                Console.WriteLine("file exists");


                //int milliseconds = 3000;
                //Thread.Sleep(milliseconds);
            }
            else
            {
                Console.WriteLine("first run, creating file...");
                File.Create("C:\\jsons\\user.json").Dispose();
                JSerialize(name, permission, type);
            }
            return "yes";
        }

        public static string JDeserialize()
        {
            return "no";
        }
    }

    class
}
