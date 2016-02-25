using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace Hydra
{
    class Check_Size
    {

        public Boolean checksize(string file_to_check)
        {
            string[] content = new string[2];
            int counter = 0;
            string line = null ;
            
           // Process process = new Process();


           // process.Start();

           // StreamWriter write = process.StandardInput;
            //write.WriteLine(cmd_hadoop_bin_path);
            //write.WriteLine(@"hadoop fs -df -h > C:\hadoop\checksize.txt");

            Process.Start("cmd", @"/c cd C:\hadoop-2.7.2\bin && hadoop fs -df -h > C:\hadoop\checksize.txt").WaitForExit();

            
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\hadoop\checksize.txt");

            while((line  = file.ReadLine())!=null)
            {
                content[counter] = line;
                counter++;
            
            }

            char[] chartotrim = {' '};

            content[1] = content[1].Substring(content[1].LastIndexOf('%') - 16, 7);

            
            ///////////////////////////////////////////////////////////////////
            string disk = content[1];


            Int64 disk_Space = Convert.ToInt64(disk);
            Int64 file_Size;
            Int64 total_space;
           

            FileInfo file_open = new FileInfo(file_to_check);

            file_Size = Convert.ToInt64(file_open.Length);
            file_Size = Convert.ToInt64(file_Size * 0.000001);
            disk_Space = Convert.ToInt64(disk_Space * 1000);
            total_space = disk_Space - file_Size;

           
            if (total_space < 1)
                return true;
            else
                return false;

            
        }


    }
}
