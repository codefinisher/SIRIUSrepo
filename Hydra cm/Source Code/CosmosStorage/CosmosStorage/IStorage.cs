using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmosStorage
{
    public interface IStorage
    { 
        string RegisterFile(string directory);
        string GetFile(string directory);
        string EditFile(string directory);
        string SaveFile();
        string[] SearchFile(string keyword);
        string DeleteFile(string directory);

        //n3w cod3s for sirius acl
        string SetUserACL(string location, string permission, string name, bool folderdefault); //location can be a directory or file. default is for folder, perm to be inheritted by child or not
        string SetGroupACL(string location, string permission, string name, bool folderdefault); //name can be either groupname or filename
        string SetOthersACL(string location, string permission, bool folderdefault); //permission: r, w, or x

        string GetACL(string location);
      
    }
}
