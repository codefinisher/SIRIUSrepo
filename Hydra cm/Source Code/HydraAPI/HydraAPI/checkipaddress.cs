using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;   
using System.Xml;

namespace HydraAPI
{
    class checkipaddress
    {
         string[] ipaddress = new string[2];
        public string[] getnamenode()
        {
            ////returns the namenode ipaddress.
            ////tested for single namenode
            
            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\hadoop-2.3.0\\etc\\hadoop\\hdfs-site.xml");
            XmlNode node = doc.DocumentElement;

            XmlNodeList namelist = doc.GetElementsByTagName("name");
            XmlNodeList valuelist = doc.GetElementsByTagName("value");

            for (int i = 0; i < namelist.Count; i++)//get single namenode ipadd
            {
                if (namelist[i].InnerXml == "dfs.http.address")
                {
                    ipaddress[0] = valuelist[i].InnerXml;
                }
            
            }

            for (int i = 0; i < namelist.Count; i++)//this gets both the namenode's ipaddresses inside an array
            {
                if(namelist[i].InnerXml == "dfs.namenode.http-address.mycluster.nn1")
                {
                    ipaddress[0] = valuelist[i].InnerXml;
                }
                if (namelist[i].InnerXml == "dfs.namenode.http-address.mycluster.nn2")
                {
                    ipaddress[1] = valuelist[i].InnerXml;                
                }
            
                
            }

                return ipaddress;
        }



        public string[] get_all_Ip()
        {

            string[] ipaddress = new string[100];
            string line;
            int count = 0;

            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\hadoop-2.3.0\etc\hadoop\slaves");

            while ((line = file.ReadLine()) != null)
            {
                ipaddress[count] = line;
                count++;
            
            }
            file.Close();
            return ipaddress; 
        }
    }

    }

