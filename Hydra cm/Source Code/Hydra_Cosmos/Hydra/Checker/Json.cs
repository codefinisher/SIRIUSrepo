using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace Hydra
{


    class Json
    {
        public string[] files_new = new string[100];
        bool response = false;
        private IRestResponse get(string url)
        {

            var client = new RestClient(url);
            var request = new RestRequest();

            request.Method = Method.GET;
            request.RequestFormat = DataFormat.Json;
            return client.Execute(request);


        }

        public Boolean checkfile(string directory)
        {
            get_namenode getnamenode = new get_namenode();
            int count = 0;
            Boolean result = true;

            string[] namenode = getnamenode.getnamenode();//get the namenode ip address

            while (namenode[count] != null) 
            {
                string filestatus = "http://" + namenode[count] + "/webhdfs/v1/" + directory + "?op=GETFILESTATUS";//json command

                string json_input = get(filestatus).Content;

                if (json_input.Contains("FileNotFoundException"))
                result = false;

                count++;
            }
            
            //dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject(json_input);


            //if (json.RemoteException.exception == null)
            //{
            //    return true;

            //}
            //else
            //    return false;
                //string json_response = json.RemoteException.exception;//need to fix



                //if (json_response == "FileNotFoundException")//returns false if the file is not found
                //    return false;
                //else
                //    return true;



            return result;
            
        }

        public string[] isCorrupt(string[] files) 
        {
            get_namenode getnamenode = new get_namenode();
            int count = 0;
            int count_file = 0;



            string[] namenode = getnamenode.getnamenode();//get the namenode ip address

            while (namenode[count] != null)
            {
                while(files[count_file] != null)
                {
                string filestatus = "http://" + namenode[count] + "/webhdfs/v1" + files[count_file] + "?op=GETFILESTATUS";//json command

                string json_input = get(filestatus).Content;

                if (json_input.Contains("FileNotFoundException"))
                    count_file++;
                else
                {
                    files_new[count_file] = files[count_file];
                    count_file++;
                }

                
                
                }
                count++;
            }




            return files_new;
            
        }

        public Boolean isfileCorrupt(string file) 
        {

            get_namenode getnamenode = new get_namenode();
            int count = 0;
            


            string[] namenode = getnamenode.getnamenode();//get the namenode ip address

            while (namenode[count] != null)
            {

                    string filestatus = "http://" + namenode[count] + "/webhdfs/v1/" + file + "?op=GET_BLOCK_LOCATIONS";//json command

                    string json_input = get(filestatus).Content;

                    if (json_input.Contains("\"isCorrupt\":true"))
                        response = true;
                    


                
                count++;
            }
            return response;
            
        }

        public Boolean file_incomplete(string directory)
        {
            Storage search = new Storage();
            string[] result = new string[100];            
            string path = Path.GetFileName(directory);
            result = search.SearchFile(path);
            


                if(result.Contains("/"+path+"._COPYING_"))
                   response = true;
                
                
            
          

            return response;
        }
    }
}
