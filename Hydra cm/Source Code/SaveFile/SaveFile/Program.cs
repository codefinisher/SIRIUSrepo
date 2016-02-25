using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace SaveFile
{
    class Program
    {
        static void Main(string[] args)
        {
            

            if (!Directory.EnumerateFiles(@"C:\COSMOS\EDITFILES").Any())
            {
                Console.WriteLine("Path Is Empty! File was Removed!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Save File?(Y)");
                // Console.ReadLine();
                string input = Console.ReadLine();

                if (input == "y" || input == "Y") 
                {
                    string[] files = Directory.GetFiles(@"C:\COSMOS\EDITFILES");
                    //files[0] = Path.GetFileName(files[0]);
                    Process.Start("cmd", @"/c cd C:\hadoop-2.3.0\bin && hdfs dfs -put -f " + files[0] + " /").WaitForExit();
                    //System.IO.File.Delete(files[0]);

                    Console.WriteLine("File Saved!");
                    Console.WriteLine("Press Any Key To Continue!");
                    Console.ReadLine();
                    System.IO.File.Delete(files[0]);
                }

                
            
            }
           
            
                
       }
            
        }


       
    }

