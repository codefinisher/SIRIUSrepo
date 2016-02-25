using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hydra
{
    class Trimmer
    {
        public string[] trimmer(string[] content)
        {

            int count = 0;

            while (content[count] != null) 
            {
                content[count] = content[count].Remove(0, 66);
                count++;
            
            }


            return content;
        }


    }
}
