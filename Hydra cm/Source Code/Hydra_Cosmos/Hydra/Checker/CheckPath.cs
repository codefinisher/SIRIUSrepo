using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Hydra
{
    class CheckPath
    {
        public Boolean returnvalue = false;
        public Boolean isdirectory(string path) 
        {
            if (Directory.Exists(path))
            {
                FileAttributes attr = File.GetAttributes(path);

                if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                    returnvalue = true;
                else
                    returnvalue = false;

            }
            //else
            //    throw new ArgumentException("ANo daw?");
            return returnvalue;
            
        }

        public Boolean directoryexists(string path)
        {
            if (Directory.Exists(path))
                return true;
            else
                return false;
        
            
        }

        public Boolean fileexists(string path)
        {
            if (File.Exists(path) == true)
                return true;
            else
                return false;

        }

        public Boolean local_file_incomplete(string directory, string path) 
        { 
            directory = Path.GetFileName(directory);
            if (System.IO.File.Exists(path + @"\" + directory + "._COPYING_"))
                return true;
            else
                return false;
        
        
        }
       
    }
}
