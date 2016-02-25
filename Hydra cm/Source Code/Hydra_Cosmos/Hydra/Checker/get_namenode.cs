using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace Hydra
{
    class get_namenode
    {
        string[] ipaddress = new string[3];
        public string[] getnamenode()
        {
            ////returns the namenode ipaddress.
            ////tested for single namenode
            
            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\hadoop-2.7.2\\etc\\hadoop\\hdfs-site.xml");
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


    }
}
