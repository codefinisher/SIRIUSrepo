using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIv2;
using Models;
using System.Threading;

namespace were_sirius
{
    class Program
    {
        static void Main(string[] args)
        {
            //test_h_functions();
            naAPI();
        }

        public static void test_h_functions()
        {
            //register file
            Cosmos hydra_storage = new Cosmos();
            //hydra_storage.RegisterFile("C:\\Users\\sirius\\Desktop\\nyeh");//PASSED 12:26 PM
            //hydra_storage.RegisterFile("C:\\thign.txt"); //PASSED 12:26 PM
            hydra_storage.GetFile("hi3.txt"); //PASSED 13:55 ; need to be specific filename
            //hydra_storage.EditFile("xxx.txt"); //gets file from hdfs then you edit at editfiles folder
            //Console.WriteLine("ni hao");
            //    string[] searchfiles = hydra_storage.SearchFile("thign");
            //    int counter = 0;
            //    while ((searchfiles[counter]) != null){
            //        Console.WriteLine(searchfiles[counter]);
            //        counter++;
            //    }
            //int milliseconds = 2000;
            //Thread.Sleep(milliseconds);
            //hydra_storage.DeleteFile("thign"); //NEED TO BE SPECIFIC (IE FILE EXTENSION) IF TWO FILES HAVE SAME NAME :O)
            //hydra_storage.SaveFile();
        }

        public static void naAPI(){
            Cosmos sirius_security = new Cosmos(); //still an cosmos object
            sirius_security.GetACL("weak"); //location input is hdfs style not windows based >> ex. C:\\ result is located at C:\COSMOS\SIRIUS_PERMISSION.txt
            //sirius_security.SetUserACL("/weak", "---", "clock", false);
            sirius_security.SetUserACL("/sans", "r--", "dayana", true);
            //sirius_security.SetOthersACL("/weak/hi.txt", "---", false);
            //sirius_security.SetGroupACL("/weak/hi.txt", "---", "",false);
        }
    }
}
