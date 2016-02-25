using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Xml;
using CosmosStorage;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
 

namespace Hydra
{
    public class Storage : IStorage
    {

        public string SaveFile_Delete;
        public string response;
        string[] content = new string[100];

        private IRestResponse get(string url)
        {

            var client = new RestClient(url);
            var request = new RestRequest();

            request.Method = Method.GET;
            request.RequestFormat = DataFormat.Json;
            return client.Execute(request);


        }

        public static ProcessStartInfo initializeCmd()
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = "cmd";
            processStartInfo.Verb = "runas"; // run as administrator
            processStartInfo.LoadUserProfile = true;
            processStartInfo.RedirectStandardInput = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardError = true; //added by sirius to enable error handling
            processStartInfo.UseShellExecute = false;
            return processStartInfo;


        }

///<summary>
        
/// </summary>
/// <param name="directory"></param>
/// <returns></returns>

        
        public string RegisterFile(string directory)
        {
          
            Check_Size check_size = new Check_Size();
            CheckPath check_path = new CheckPath();
            Json is_incomplete = new Json();
            //MD5Checker check = new MD5Checker();
            ////string md5 = check.MD5Check(directory);
            
            //crc32checker crc32check = new crc32checker();

                if (directory.Contains(" "))
                {
                    response = "File Directory Contains Space!";

                }
                else if (Directory.Exists(directory) || directory == "/" || directory == @"\")
                {
                    response = "Path is A directory! Please Specify a filename!";
                }
                else if (File.Exists(directory))
                {

                    Process.Start("cmd", @"/c cd C:\hadoop-2.7.2\bin && hdfs dfs -put -f " + directory + " /").WaitForExit();
                    if (is_incomplete.file_incomplete(directory) == true)
                    {
                        response = "File Upload was cancelled upon upload!";
                    }
                    else
                    {
                        response = "File Uploaded";
                    }
                }
                else 
                {
                    response = "Input Invalid~";
                }
                

                
                //return crc32;
                return response;
           
        }

        public string GetFile(string directory)
        {
            Json checkfile = new Json();
            CheckPath check_path = new CheckPath();
            
            DirectoryInfo dir = new DirectoryInfo(@"C:\COSMOS");


            ////If the File being downloaded exsits.. Delete the file//////
           if(System.IO.File.Exists(@"C:\COSMOS\" +directory))
           {
               System.IO.File.Delete(@"C:\COSMOS\" + directory);
           }


           
            if (directory.Contains(" "))
            {
                response = "File Directory Contains Space!";

            }
            else if(check_path.directoryexists(@"C:\COSMOS")==false || directory == "/" || directory == @"\" )//check if destination exist
            {
                response = "The Directory Doesn't Exist!";
            }
            else if(checkfile.checkfile(directory)==false || directory == "." || directory == @"\" || directory == "/")//check if file exists
            {
                response = "File Not found";      
            
            }
            else if(checkfile.isfileCorrupt(directory))
            {
                response = "File is Corrupted!";
            
            }
            else
            {
                Process.Start("cmd", @"/c cd C:\hadoop-2.7.2\bin && hdfs dfs -copyToLocal /" + directory + @" C:\COSMOS").WaitForExit();


                if (check_path.local_file_incomplete(directory, @"C:\COSMOS"))
                {
                    response = "File Download was cancelled upon download!";
                }
                else
                {
                    response = "File downloaded";
                }
            }



           

                return response;
        }        

        public string EditFile(string directory)
        {
            Json checkfile = new Json();
            CheckPath check_path = new CheckPath();
            Boolean file_downloaded_check = false;
            

            /////////////Delete All Files inside EDITFILES folder///////////////

           DirectoryInfo dir = new DirectoryInfo(@"C:\COSMOS\EDITFILES");

           foreach (FileInfo fi in dir.GetFiles())
           {
               fi.Delete();           
           }
           
            ////////////Create Folder For Files to be Edited////////
            Boolean folderExists = Directory.Exists(@"C:\COSMOS\EDITFILES");
            if (folderExists == false)
                Directory.CreateDirectory(@"C:\COSMOS\EDITFILES");


            ///////////DOWNLOADS FILE FIRST//////////////
            if (directory.Contains(" "))
            {
                response = "File Directory Contains Space!";

            }
            else if (checkfile.checkfile(directory) == false || directory == "." || directory == @"\" || directory == "/")//check if file exists
            {
                response = "File Not found";

            }
            else if (checkfile.isfileCorrupt(directory))
            {
                response = "File is Corrupted!";

            }
            else
            {   //////////////Download from HDFS/////////////////
                
                Process.Start("cmd", @"/c cd C:\hadoop-2.7.2\bin && hdfs dfs -copyToLocal /" + directory + @" C:\COSMOS\EDITFILES").WaitForExit();


                if (check_path.local_file_incomplete(directory, @"C:\COSMOS\EDITFILES"))
                {
                    response = "File Download was cancelled upon Loading!";
                }
                else
                {
                    //////////////Delete from HDFS once finished Downloading/////////
                    //response = "File downloaded";
                    //Process.Start("cmd", @"/c cd C:\hadoop-2.3.0\bin && hdfs dfs -rm /" + directory ).WaitForExit();
                    SaveFile_Delete = directory;
                    file_downloaded_check = true;
                }
            }

            if (file_downloaded_check == true)
            {

                Process.Start(@"C:\COSMOS\EDITFILES");
                               
            }

            return null;
        }

        public string SaveFile()
        {

            string[] files = Directory.GetFiles(@"C:\COSMOS\EDITFILES");
            if (files.Length > 1)
            {
                response = "Folder Has More Than One File Inside!";
            }
            else
            {
                Process.Start("cmd", @"/c cd C:\hadoop-2.7.2\bin && hdfs dfs -rm /" + SaveFile_Delete).WaitForExit();
                Process.Start("cmd", @"/c cd C:\hadoop-2.7.2\bin && hdfs dfs -put -f " + files[0] + " /").WaitForExit();
                System.IO.File.Delete(files[0]);
                response = "File Saved";
            }



            return response;
        }
        public string[] SearchFile(string keyword)
        {//for testing pa
             //should run as admin
            ////////////readxml////////////////
            
            Trimmer trim = new Trimmer();
            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\hadoop-2.7.2\\etc\\hadoop\\hdfs-site.xml");
            XmlNode node = doc.DocumentElement;
            
            string namenode =string.Empty;
            Json checkblock = new Json();


            
          

            /////////////////////////////////
            if (keyword == "/")
                content[0] = "No such Directory!";
            else
            {
                Process.Start("cmd", @"/c cd C:\hadoop-2.7.2\sbin && hdfs dfs -ls -R / | Findstr " + keyword + @" > C:\hadoop\search_Result.txt").WaitForExit();

                string line;
                int counter = 0;

                ///////////////////////////////////
                //reads the list of files that the search command outputted in the search_result.txt file
                if (new FileInfo(@"C:\hadoop\search_Result.txt").Length != 0)
                {
                    
                    System.IO.StreamReader file = new System.IO.StreamReader(@"C:\hadoop\search_Result.txt");

                    while ((line = file.ReadLine()) != null)
                    {
                        content[counter] = line;
                        counter++;

                    }
                    file.Close();

                }

                content = trim.trimmer(content);
                //content = checkblock.isCorrupt(content);




                //////returns the files inside the network
                

            }

            return content;
        }

        public string DeleteFile(string directory) 
        {
            Json checkfile = new Json();
            CheckPath check_path = new CheckPath();
            

            if (directory.Contains(" "))
            {
                response = "File Cannot Contain Spaces!";

            }
            else if (check_path.directoryexists(@"C:\COSMOS") == false || directory == "/" || directory == @"\")//check if destination exist
            {
                response = "Input Cannot be a Directory!";
            }
            else if (checkfile.checkfile(directory) == false || directory == "." || directory == @"\" || directory == "/")//check if file exists
            {
                response = "File Not found";

            }
            else
            {
                Process.Start("cmd", @"/c cd C:\hadoop-2.7.2\bin && hdfs dfs -rm /" + directory).WaitForExit();

                response = "File Deleted!";
                

            }





            return response;
        
        


        }
        //<////////////////////////////////////// inserted by SIRIUS ////////////////////////////////////////>//
        
        public string SetGroupACL(string location, string permission, string grpname, bool folderdefault){
            Process myprocess = new Process();
            myprocess.StartInfo = initializeCmd();
            myprocess.EnableRaisingEvents = true; //added by sirius to enable error handling
            myprocess.Start();
            StreamWriter cmdwriter = myprocess.StandardInput;

            if (folderdefault)
            {
                cmdwriter.WriteLine("cd C:\\hadoop-2.7.2\\bin && hdfs dfs -setfacl -m default:group:"+grpname+":" + permission + " " + location + " >> C:\\COSMOS\\siriuslogs.txt");
                cmdwriter.Flush();
                cmdwriter.Close();
                listenForError(myprocess);

                return "changes applied!";
            }
            // this part onwards execute to place permission regularly
            Console.WriteLine("skipping set folder default");
            myprocess.Start();
            cmdwriter.WriteLine("cd C:\\hadoop-2.7.2\\bin && hdfs dfs -setfacl -m group:" + grpname + ":" + permission + " " + location + " >> C:\\COSMOS\\siriuslogs.txt");
            cmdwriter.Flush();
            cmdwriter.Close();
            listenForError(myprocess);

            return "file acl changed!";
        }

        public string SetUserACL(string location, string permission, string username, bool folderdefault)
        {
            Process myprocess = new Process();
            myprocess.StartInfo = initializeCmd();
            myprocess.EnableRaisingEvents = true; //added by sirius to enable error handling
            myprocess.Start();
            StreamWriter cmdwriter = myprocess.StandardInput;
            //StreamReader cmdreader = myprocess.StandardOutput; 

            if (folderdefault)
            {
                
                 //Process.Start("cmd", @"/c cd C:\hadoop-2.7.2\bin && hdfs dfs -setfacl -m default:user:" + username + ":" + permission + " " + location).WaitForExit();
                cmdwriter.WriteLine("cd C:\\hadoop-2.7.2\\bin && hdfs dfs -setfacl -m default:user:"+username+":"+permission+" "+location+" >> C:\\COSMOS\\siriuslogs.txt");
                cmdwriter.Flush();
                cmdwriter.Close();
                listenForError(myprocess);
               // myprocess.WaitForExit();
               // string output = cmdreader.ReadToEnd();
                
                //try
                //{
                //  //  int x = output.Length;
                //    //Console.WriteLine(output);
                //    using (StreamReader s = myprocess.StandardError)
                //    {
                //        string errorlog = s.ReadToEnd();
                //        myprocess.WaitForExit();
                //        Console.WriteLine(errorlog);
                //        Console.WriteLine(raiseSiriusError(errorlog));
                //        myprocess.Close(); //terminating console window
                //        int x = errorlog.Length; //to test if there is any error
                //    }
                //}
                //catch(NullReferenceException e){
                //    Console.WriteLine("no error"); //no error string returned.
                //}

                return "changes applied!";
            }
            // this part onwards execute to place permission regularly
            Console.WriteLine("problematic"); 
            //Process myprocess2 = new Process();
            //myprocess2.StartInfo = initializeCmd();
            //myprocess2.EnableRaisingEvents = true; //added by sirius to enable error handling
            //myprocess2.Start();


            //StreamWriter cmdwriter2 = myprocess2.StandardInput;
            //cmdwriter2.WriteLine("cd C:\\hadoop-2.7.2\\bin && hdfs dfs -setfacl -m user:" + username + ":" + permission + " " + location + " >> C:\\COSMOS\\siriuslogs.txt");
            //cmdwriter2.Flush();
            //cmdwriter2.Close();
            myprocess.Start();
            cmdwriter.WriteLine("cd C:\\hadoop-2.7.2\\bin && hdfs dfs -setfacl -m user:" + username + ":" + permission + " " + location + " >> C:\\COSMOS\\siriuslogs.txt");
            cmdwriter.Flush();
            cmdwriter.Close();
            listenForError(myprocess);
                
            
            return "file acl changed!";
        }

        public string SetOthersACL(string location, string permission, bool folderdefault)
        {
            Process myprocess = new Process();
            myprocess.StartInfo = initializeCmd();
            myprocess.EnableRaisingEvents = true; //added by sirius to enable error handling
            myprocess.Start();
            StreamWriter cmdwriter = myprocess.StandardInput;

            if (folderdefault)
            {
                cmdwriter.WriteLine("cd C:\\hadoop-2.7.2\\bin && hdfs dfs -setfacl -m default:other::" + permission + " " + location + " >> C:\\COSMOS\\siriuslogs.txt");
                cmdwriter.Flush();
                cmdwriter.Close();
                listenForError(myprocess);

                return "changes applied!";
            }
            // this part onwards execute to place permission regularly
            Console.WriteLine("cannot apply permission default to non directory or don't want to set folder to default");
            myprocess.Start();
            cmdwriter.WriteLine("cd C:\\hadoop-2.7.2\\bin && hdfs dfs -setfacl -m other::" + permission + " " + location + " >> C:\\COSMOS\\siriuslogs.txt");
            cmdwriter.Flush();
            cmdwriter.Close();
            listenForError(myprocess);

            return "file acl changed!";
        }

        public string GetACL(string location)
        {
            Process.Start("cmd", @"/c cd C:\hadoop-2.7.2\bin && hdfs dfs -getfacl /" + location + "> C:\\COSMOS\\SIRIUS_FILE_PERMISSION.txt").WaitForExit();
            
            //for checking purposes only, comment out on final version
            Process.Start("C:\\COSMOS\\SIRIUS_FILE_PERMISSION.txt"); //open SIRIUS_FILE_PERMISSION.txt after writing to the file
            //checking purposes END

            return "acl retrieved!";
        }
        private string raiseSiriusError(string errormsgs)
        {
            string siriuserror = errormsgs.Replace("\r\n","+");
            string[] siriuserrors = siriuserror.Split('+');
            if (siriuserrors.Length == 2)
               // Console.WriteLine(siriuserrors.Length + " " + "setfacl: Invalid ACL: only directories may have a default ACL.".Length);
                Console.WriteLine(siriuserrors[0]);
            switch(siriuserrors[0]){ //errormsgs contains extra space at back
                case "setfacl: Invalid ACL: only directories may have a default ACL.\\n": 
                    return "sorry";

                default: return "no sirius errors";
            }
        }
        private string listenForError(Process processname)
        {
            string errorlog;
            try
            {
                using (StreamReader s = processname.StandardError)
                {
                    //processname.BeginErrorReadLine();
                    errorlog = s.ReadToEnd();
                    processname.WaitForExit();
                    Console.WriteLine(errorlog);
                    //Console.WriteLine(raiseSiriusError(errorlog));
                    processname.Close(); //terminating console window
                    int x = errorlog.Length; //to test if there is any error
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("no error");
                return "command executed.";
            }
            raiseSiriusError(errorlog);
            Console.WriteLine("problematic");
            return "problematic";
        }
        //<//////////////////////////////////////  SIRIUS ////////////////////////////////////////>//
    }

}