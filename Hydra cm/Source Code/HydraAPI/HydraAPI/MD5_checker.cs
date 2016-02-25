using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace HydraAPI
{
    class MD5_checker
    {
        public string check(string filename)
        {

            using (var md5 = MD5.Create())
            {

                using (var stream = File.OpenRead(filename))
                {
                    
                    return Convert.ToBase64String(md5.ComputeHash(stream));
                }
            
            }
        
        
        }

    }
}
