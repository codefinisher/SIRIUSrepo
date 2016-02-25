using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;


namespace Hydra
{
    public class MD5Checker
    {
        
        private static MD5 md5 = MD5.Create();
        public string MD5Check(string file)
        {

            using (FileStream stream = File.OpenRead(file))
            {
                byte[] checksum = md5.ComputeHash(stream);

                return (BitConverter.ToString(checksum).Replace("-", string.Empty));
                
            }
        
        }

      

    }
}
