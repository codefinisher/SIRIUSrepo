using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Hydra
{
    public class crc32checker
    {
        public string crc32_checker(string file)
        {
            Crc32 crc32 = new Crc32();

            string hash = string.Empty;

            using(FileStream fs = File.Open(file, FileMode.Open))
            {
                foreach(byte b in crc32.ComputeHash(fs))
                   {
                   
                    hash += b.ToString("x2").ToLower();
                   }
            }
                   

            return hash;
        }
        

    }
}
