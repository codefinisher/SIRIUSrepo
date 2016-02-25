using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using SHDocVw;
using System.Net;
using System.Xml;
using System.Net.Sockets;
using System.Threading;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using Hydra;

namespace HydraAPI
{
    public class Initialize
    {
        bool hadoop_initialize = false;
        private string hadoop_path;
        private string hadoop_bin_path;
        private string hadoop_sbin_path;
        private string zookeeper_path;


        private string cmd_hadoop_sbin_path;
        private string cmd_hadoop_bin_path;
        public string response;

        checkipaddress checkip = new checkipaddress();
        
        public  Initialize(string hadoop_path, string zookeeper_path)
        {
            this.hadoop_path = hadoop_path;
            this.zookeeper_path = zookeeper_path.Replace(@"\", @"/");
            hadoop_bin_path = hadoop_path + "\\bin";
            hadoop_sbin_path = hadoop_path + "\\sbin";

            cmd_hadoop_bin_path = "cd " + hadoop_bin_path;
            cmd_hadoop_sbin_path = "cd " + hadoop_sbin_path;


        }

        public string start_hadoop()
        {
              //ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd", @"/c cd " +path+"&& start-dfs.cmd");

            string cmd_hadoop_sbin_path = "cd " + hadoop_sbin_path;
            string cmd_hadoop_bin_path = "cd " + hadoop_bin_path;
            string cmd_start_dfs = "start-dfs";
            


            
            //  processStartInfo.CreateNoWindow = false;  // remove the command line where you type start-dfs initially
            check_namenode_ip();
         
            Process process = new Process();
            process.StartInfo = initializeCmd();
            process.Start();
           

            StreamWriter write = process.StandardInput;

            if (hadoop_sbin_path.EndsWith("sbin"))
            {
                Console.WriteLine("sbin path" + cmd_hadoop_sbin_path);
                write.WriteLine(cmd_hadoop_sbin_path);
                write.WriteLine(cmd_start_dfs);
                //System.Threading.Thread.Sleep(6000);
                
                //Process testprocess = new Process();
                //testprocess.StartInfo = initializeCmd();
                //testprocess.Start();
                //StreamWriter tpwrite = testprocess.StandardInput;

                //tpwrite.WriteLine("cd desktop");
                //tpwrite.WriteLine("mkdir hello");
                //Console.WriteLine("hello folder creation line done");
                
                hadoop_initialize = true;
                
                response = "Hadoop Started!";
                // Internet Explorer Launch code 
                /*    try
                    {


                        InternetExplorer IE = new InternetExplorer();
                        object Empty = 0;
                        object URL = "http://10.100.219.94:50070";
                        IE.Visible = true;
                        IE.Navigate2(ref URL, ref Empty, ref Empty, ref Empty, ref Empty);
                        write.WriteLine(cmd_hadoop_bin_path);
                        write.WriteLine(cmd_mkdir);
                        hadoop_initialize = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        Console.ReadKey();
                    }
             
                 */


            }
            else
            {
                response = "Hadoop Failed to start!";
            }


            return response;
          

        }

        public static ProcessStartInfo initializeCmd()
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = "cmd";
            processStartInfo.Verb = "runas"; // run as administrator
            processStartInfo.LoadUserProfile = true;
            processStartInfo.RedirectStandardInput = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.UseShellExecute = false;
            return processStartInfo;


        }

        public void rebalanceCluster(string threshold_percentage)
        {
            string rebalance = "hadoop balancer -threshold " + threshold_percentage;

            while (true)
            {
                Process process = new Process();

                process.StartInfo = initializeCmd();
                process.Start();

                StreamWriter write = process.StandardInput;
                write.WriteLine(cmd_hadoop_bin_path);
                write.WriteLine(rebalance);
                //process.Kill();
                Thread.Sleep(30000);


            }
        }

        public void formatNameNode()
        {

            string hadoopNamespaceDir = @"C:\hadoop";
            bool directoryExists = Directory.Exists(hadoopNamespaceDir);

            try
            {
                if (directoryExists)
                {
                    Directory.Delete(hadoopNamespaceDir, true);
                }
            }
            catch (Exception e)
            {
               
            }

            string namenodeFormat = "hdfs namenode -format";


            Process process = new Process();

            process.StartInfo = initializeCmd();
            process.Start();

            StreamWriter write = process.StandardInput;
            write.WriteLine(cmd_hadoop_bin_path);
            write.WriteLine(namenodeFormat);
            write.WriteLine("y");

            //process.WaitForExit();
            process.Close();

            //Console.ReadKey()

            System.Threading.Thread.Sleep(5000);

            //Process.Start("cmd", @"/c cd C:\hadoop-2.3.0\bin && hadoop namenode -format ").WaitForExit();
           






        }

        public void setReplication(String numOfReplicas, String path)//checking
        {
            string numOfRep = numOfReplicas;
            string setRep = "hdfs dfs -setrep -w " + numOfRep + " " + path;

                Process process = new Process();

                process.StartInfo = initializeCmd();
                process.Start();

                StreamWriter write = process.StandardInput;
                write.WriteLine(cmd_hadoop_bin_path);
                write.WriteLine(setRep);

                process.Close();

          

        }

        public string[] list_all_files()
        {
            Process.Start("cmd", @"/c cd C:\hadoop-2.7.2\sbin && hdfs dfs -ls -R / > C:\hadoop\list_all.txt").WaitForExit();
            string[] content = new string[100];
            string line;
            int counter = 0;

            ///////////////////////////////////
            //reads the list of files that the search command outputted in the search_result.txt file
            if (new FileInfo(@"C:\hadoop\search_Result.txt").Length != 0)
            {
                System.IO.StreamReader file = new System.IO.StreamReader(@"C:\hadoop\list_all.txt");

                while ((line = file.ReadLine()) != null)
                {
                    content[counter] = line;
                    counter++;

                }
                file.Close();

            }

  
            //////returns the files inside the network
            return content;
     
        }       
             
        public void check_namenode_ip()
        {
            using (XmlReader reader = XmlReader.Create(hadoop_path + "\\etc\\hadoop\\core-site.xml"))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name)
                        {
                            case "configuration":
                                Console.WriteLine("Start <configuration> element.");
                                break;
                            case "property":
                                Console.WriteLine("Start <property> element.");
                                break;
                            case "name":
                                Console.WriteLine("Start <name> element.");
                                break;
                            case "value":
                                Console.WriteLine("Start <value> element.");

                                if (reader.Read())
                                {
                                    try
                                    {
                                        if (reader.Value.Trim() == "")
                                        {
                                            throw new ArgumentException("\nYou need to specify an IP at the <value> element of core-site.xml.");



                                        }
                                        /*    else
                                            {
                                                Console.WriteLine("  Text node: " + reader.Value.Trim());
                                            
                                            }

                                            */

                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.ToString());
                                        Console.Read();
                                        System.Environment.Exit(0);
                                    }
                                }

                                break;
                        }

                    }
                }

            }

        }

       // public void populate_slaves_file(string[] list_ip)
        public void populate_slaves_file_local()
        {

            string[] ip_list = null;
            int index=0;
                XmlDocument doc = new XmlDocument();
                doc.Load("C:\\COSMOS\\REGISTRY\\LocalRegistry.xml");               
                
                XmlNode node = doc.DocumentElement;           

         
                foreach (XmlElement element in node.SelectNodes("//address"))
                {

                        using (StreamWriter writer = new StreamWriter(hadoop_path + "\\etc\\hadoop\\slaves", true))
                        {
                            
                            writer.WriteLine(doc.GetElementsByTagName("address")[index].ChildNodes[0].InnerText);
                            writer.Close();
                            index++;
                        }
                   
                       
                    

                }




        }

        public void populate_slaves_file_network()
        {

            string[] ip_list = null;
            int index = 0;

            XmlDocument doc2 = new XmlDocument();
            doc2.Load("C:\\COSMOS\\REGISTRY\\NetworkRegistry.xml");
            XmlNode node2 = doc2.DocumentElement;


            foreach (XmlElement element in node2.SelectNodes("//address"))
            {

                using (StreamWriter writer2 = new StreamWriter(hadoop_path + "\\etc\\hadoop\\slaves", true))
                {
                    writer2.WriteLine(doc2.GetElementsByTagName("address")[index].ChildNodes[0].InnerText);
                    writer2.Close();
                    index++;
                }


            }





        }

        public void clear_slaves_file()
        {
            StreamWriter strm = File.CreateText(@hadoop_path + "\\etc\\hadoop\\slaves");
            strm.Flush();
            strm.Close();
        }

        public string setup_hadoop_configs(String NameNodeIPAddress, String replication_factor)
        {

            string[] ipaddress = new string[2];
            ipaddress = checkip.get_all_Ip();
            int n;
            int repfactor  = Convert.ToInt32(replication_factor);

          
            if (!ipaddress.Contains(NameNodeIPAddress) || !int.TryParse(replication_factor, out n))
            {
                response = "Ip Address Not Found! / Replication Factor is not a Numberical Value";
            }
            else if (repfactor > 10 || repfactor < 1)
            {
                response = "Replication Factor Out of Bounds!";
            
            }
            else
            {
                string six_indents = "            ";
                string five_indents = "     ";
                XmlWriterSettings settings = new XmlWriterSettings
                {
                    Indent = true,
                    IndentChars = "   ",
                    NewLineChars = "\r\n",
                    NewLineHandling = NewLineHandling.Replace
                };

                using (XmlWriter writer = XmlWriter.Create(hadoop_path + "\\etc\\hadoop\\core-site.xml", settings))
                {

                    writer.WriteStartDocument();
                    writer.WriteStartElement("configuration");
                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "fs.defaultFS");
                    writer.WriteElementString("value", NameNodeIPAddress.Insert(0, "hdfs://"));
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
                using (XmlWriter writer = XmlWriter.Create(hadoop_path + "\\etc\\hadoop\\hdfs-site.xml", settings))
                {

                    writer.WriteStartDocument();
                    writer.WriteStartElement("configuration");
                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "dfs.replication");
                    writer.WriteElementString("value", replication_factor);
                    writer.WriteEndElement();

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "dfs.namenode.name.dir");
                    writer.WriteElementString("value", "file:/hadoop/data/dfs/namenode");
                    writer.WriteEndElement();

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "dfs.datanode.data.dir");
                    writer.WriteElementString("value", "file:/hadoop/data/dfs/datanode");
                    writer.WriteEndElement();

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "dfs.permissions");
                    writer.WriteElementString("value", "false");
                    writer.WriteEndElement();

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "dfs.http.address");
                    writer.WriteElementString("value", NameNodeIPAddress + ":50070");
                    writer.WriteEndElement();

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "dfs.namenode.heartbeat.recheck-interval");
                    writer.WriteElementString("value", "150000");
                    writer.WriteEndElement();

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "dfs.heartbeat.interval");
                    writer.WriteElementString("value", "3");
                    writer.WriteEndElement();

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "dfs.webhdfs.enbled");
                    writer.WriteElementString("value", "true");
                    writer.WriteElementString("description", "to enable webhdfs");
                    writer.WriteElementString("final", "true");
                    writer.WriteEndElement();



                    writer.WriteEndElement();

                    writer.WriteEndDocument();
                }
                using (XmlWriter writer = XmlWriter.Create(hadoop_path + "\\etc\\hadoop\\yarn-site.xml", settings))
                {

                    writer.WriteStartDocument();
                    writer.WriteStartElement("configuration");

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "yarn.nodemanager.aux-services");
                    writer.WriteElementString("value", "mapreduce_shuffle");
                    writer.WriteEndElement();

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "yarn.nodemanager.aux-services.mapreduce.shuffle.class");
                    writer.WriteElementString("value", "org.apache.hadoop.mapred.ShuffleHandler");
                    writer.WriteEndElement();

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "yarn.resourcemanager.hostname");
                    writer.WriteElementString("value", NameNodeIPAddress);
                    writer.WriteEndElement();

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "yarn.application.classpath");
                    writer.WriteElementString("value", Environment.NewLine + six_indents + "%HADOOP_HOME%\\etc\\hadoop," +
                                                       Environment.NewLine + six_indents + "%HADOOP_HOME%\\share\\hadoop\\common\\*," +
                                                       Environment.NewLine + six_indents + "%HADOOP_HOME%\\share\\hadoop\\common\\lib\\*," +
                                                       Environment.NewLine + six_indents + "%HADOOP_HOME%\\share\\hadoop\\hdfs\\*," +
                                                       Environment.NewLine + six_indents + "%HADOOP_HOME%\\share\\hadoop\\hdfs\\lib\\*," +
                                                       Environment.NewLine + six_indents + "%HADOOP_HOME%\\share\\hadoop\\mapreduce\\*," +
                                                       Environment.NewLine + six_indents + "%HADOOP_HOME%\\share\\hadoop\\mapreduce\\lib\\*," +
                                                       Environment.NewLine + six_indents + "%HADOOP_HOME%\\share\\hadoop\\yarn\\*," +
                                                       Environment.NewLine + six_indents + "%HADOOP_HOME%\\share\\hadoop\\yarn\\lib\\*" +
                                                       Environment.NewLine + five_indents
                                                       );


                    writer.WriteEndElement();

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }

                response = "Setup Finished!";


            }
            //Console.WriteLine("Hello");
            return response;
           
        }

        //#1 High Availability with Manual Failover
        public string HA_setup_hadoop_configs_with(String[] NameNodeIPAddress, String[] JournalNodeIPAddress, String replication_factor)
        {
            string[] ipaddress = new string[100];
            ipaddress = checkip.get_all_Ip();

            if (ipaddress.Contains(NameNodeIPAddress[0]) == false || ipaddress.Contains(NameNodeIPAddress[1]) == false || ipaddress.Contains(JournalNodeIPAddress[0]) == false || ipaddress.Contains(JournalNodeIPAddress[1]) == false || ipaddress.Contains(JournalNodeIPAddress[2]) == false)
            {
                response = "Ip Address Invalid!";

            }
            else if (Convert.ToInt32(replication_factor) > 10 || Convert.ToInt32(replication_factor) < 1)
            {
                response = "Replication Factor Out of Bounds!";

            }
            else 
            {
                //high availability
                string six_indents = "            ";
                string five_indents = "     ";

                string NN1 = NameNodeIPAddress[0];
                string NN2 = NameNodeIPAddress[1];

                string JN1 = JournalNodeIPAddress[0];
                string JN2 = JournalNodeIPAddress[1];
                string JN3 = JournalNodeIPAddress[2];

                string JNEditsDirectory = @"C:\journal_Folder";

                XmlWriterSettings settings = new XmlWriterSettings
                {
                    Indent = true,
                    IndentChars = "   ",
                    NewLineChars = "\r\n",
                    NewLineHandling = NewLineHandling.Replace
                };

                using (XmlWriter writer = XmlWriter.Create(hadoop_path + "\\etc\\hadoop\\core-site.xml", settings))
                {

                    writer.WriteStartDocument();
                    writer.WriteStartElement("configuration");
                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "fs.defaultFS");
                    writer.WriteElementString("value", "hdfs://mycluster");
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
                using (XmlWriter writer = XmlWriter.Create(hadoop_path + "\\etc\\hadoop\\hdfs-site.xml", settings))
                {

                    writer.WriteStartDocument();
                    writer.WriteStartElement("configuration");
                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "dfs.replication");
                    writer.WriteElementString("value", replication_factor);
                    writer.WriteEndElement();

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "dfs.namenode.name.dir");
                    writer.WriteElementString("value", "file:/hadoop/data/dfs/namenode");
                    writer.WriteEndElement();

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "dfs.datanode.data.dir");
                    writer.WriteElementString("value", "file:/hadoop/data/dfs/datanode");
                    writer.WriteEndElement();

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "dfs.permissions");
                    writer.WriteElementString("value", "false");
                    writer.WriteEndElement();


                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "dfs.webhdfs.enbled");
                    writer.WriteElementString("value", "true");
                    writer.WriteElementString("description", "to enable webhdfs");
                    writer.WriteElementString("final", "true");
                    writer.WriteEndElement();

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "dfs.nameservices");
                    writer.WriteElementString("value", "mycluster");
                    writer.WriteEndElement();

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "dfs.ha.namenodes.mycluster");
                    writer.WriteElementString("value", "nn1,nn2");
                    writer.WriteEndElement();

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "dfs.namenode.rpc-address.mycluster.nn1");
                    writer.WriteElementString("value", NN1 + ":8020");
                    writer.WriteEndElement();

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "dfs.namenode.rpc-address.mycluster.nn2");
                    writer.WriteElementString("value", NN2 + ":8020");
                    writer.WriteEndElement();

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "dfs.namenode.http-address.mycluster.nn1");
                    writer.WriteElementString("value", NN1 + ":50070");
                    writer.WriteEndElement();

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "dfs.namenode.http-address.mycluster.nn2");
                    writer.WriteElementString("value", NN2 + ":50070");
                    writer.WriteEndElement();

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "dfs.namenode.shared.edits.dir");
                    writer.WriteElementString("value", "qjournal://" + JN1 + ":8485;" + JN2 + ":8485;" + JN3 + ":8485/mycluster");
                    writer.WriteEndElement();

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "dfs.client.failover.proxy.provider.mycluster");
                    writer.WriteElementString("value", "org.apache.hadoop.hdfs.server.namenode.ha.ConfiguredFailoverProxyProvider");
                    writer.WriteEndElement();

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "dfs.ha.fencing.methods");
                    writer.WriteElementString("value", @"shell(bin\true)");
                    writer.WriteEndElement();

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "dfs.journalnode.edits.dir");
                    writer.WriteElementString("value", JNEditsDirectory);
                    writer.WriteEndElement();

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "dfs.namenode.heartbeat.recheck-interval");
                    writer.WriteElementString("value", "150000");
                    writer.WriteEndElement();

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "dfs.heartbeat.interval");
                    writer.WriteElementString("value", "3");
                    writer.WriteEndElement();


                    writer.WriteEndElement();

                    writer.WriteEndDocument();
                }
                using (XmlWriter writer = XmlWriter.Create(hadoop_path + "\\etc\\hadoop\\yarn-site.xml", settings))
                {

                    writer.WriteStartDocument();
                    writer.WriteStartElement("configuration");

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "yarn.nodemanager.aux-services");
                    writer.WriteElementString("value", "mapreduce_shuffle");
                    writer.WriteEndElement();

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "yarn.nodemanager.aux-services.mapreduce.shuffle.class");
                    writer.WriteElementString("value", "org.apache.hadoop.mapred.ShuffleHandler");
                    writer.WriteEndElement();

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "yarn.resourcemanager.hostname");
                    writer.WriteElementString("value", NameNodeIPAddress[0]);
                    writer.WriteEndElement();


                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "yarn.application.classpath");
                    writer.WriteElementString("value", Environment.NewLine + six_indents + "%HADOOP_HOME%\\etc\\hadoop," +
                                                       Environment.NewLine + six_indents + "%HADOOP_HOME%\\share\\hadoop\\common\\*," +
                                                       Environment.NewLine + six_indents + "%HADOOP_HOME%\\share\\hadoop\\common\\lib\\*," +
                                                       Environment.NewLine + six_indents + "%HADOOP_HOME%\\share\\hadoop\\hdfs\\*," +
                                                       Environment.NewLine + six_indents + "%HADOOP_HOME%\\share\\hadoop\\hdfs\\lib\\*," +
                                                       Environment.NewLine + six_indents + "%HADOOP_HOME%\\share\\hadoop\\mapreduce\\*," +
                                                       Environment.NewLine + six_indents + "%HADOOP_HOME%\\share\\hadoop\\mapreduce\\lib\\*," +
                                                       Environment.NewLine + six_indents + "%HADOOP_HOME%\\share\\hadoop\\yarn\\*," +
                                                       Environment.NewLine + six_indents + "%HADOOP_HOME%\\share\\hadoop\\yarn\\lib\\*" +
                                                       Environment.NewLine + five_indents
                                                       );


                    writer.WriteEndElement();

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }

                response = "SetUp Finished!";
            }

            return response;
            
        }

        //#2 High Availability with Manual Failover
        //#4 ZooKeeper High Availability aka Automatic Failover
        public void HA_formatJournalNodes()
        {
            string journalNodeFormat = "hdfs namenode -initializeSharedEdits -force";



            Process process = new Process();

            process.StartInfo = initializeCmd();
            process.Start();

            StreamWriter write = process.StandardInput;
            write.WriteLine(cmd_hadoop_bin_path);
            write.WriteLine(journalNodeFormat);

            Console.WriteLine("Journalnode format success!");

            Console.Read();

        }
        //#4 High Availability with Manual Failover
        //#5 (Execute in another NameNode) ZooKeeper High Availability aka Automatic Failover
        public void HA_getLatestCheckpoint()
        {
            string journalNodeFormat = "hdfs namenode -bootstrapStandby -force";



            Process process = new Process();

            process.StartInfo = initializeCmd();
            process.Start();

            StreamWriter write = process.StandardInput;
            write.WriteLine(cmd_hadoop_bin_path);
            write.WriteLine(journalNodeFormat);

            Console.WriteLine("Successfully copied latest checkpoint success!");

            Console.Read();



        }

        //#3 High Availability with Manual Failover

        //#3 ZooKeeper High Availability aka Automatic Failover
        public void HA_startJournalNode()
        {
            string startJournalNode = "hdfs journalnode";


            Process process = new Process();

            process.StartInfo = initializeCmd();
            process.Start();

            StreamWriter write = process.StandardInput;
            write.WriteLine(cmd_hadoop_bin_path);
            write.WriteLine(startJournalNode);

            Console.WriteLine("Successfully started journalnode success!");

            Console.Read();




        }

        public string HA_setNNToActive(String NameNodeServiceID)
        {
            if (NameNodeServiceID == "nn1" || NameNodeServiceID == "nn2")
            {
                // string hadoop_bin_path = "cd " + hadoop_path + "\\bin";
                string transitionToActive = "hdfs haadmin -transitionToActive " + NameNodeServiceID;


                Process process = new Process();
                process.StartInfo = initializeCmd();
                process.Start();

                StreamWriter write = process.StandardInput;
                write.WriteLine(cmd_hadoop_bin_path);
                write.WriteLine(transitionToActive);



                response = "Namenode Set to Active";

            }
            else 
            {
                response = "Wrong Service ID";
            }

            return response;
            
        }//ok

        public string HA_setNNToStandby(String NameNodeServiceID)
        {
            if (NameNodeServiceID == "nn1" || NameNodeServiceID == "nn2")
            {

                // string hadoop_bin_path = "cd " + hadoop_path + "\\bin";
                string transitionToActive = "hdfs haadmin -transitionToStandby" + NameNodeServiceID;




                Process process = new Process();
                process.StartInfo = initializeCmd();
                process.Start();

                StreamWriter write = process.StandardInput;
                write.WriteLine(cmd_hadoop_bin_path);
                write.WriteLine(transitionToActive);

                response = "Namenode Set to Standby";

            }
            else
            {

                response = "Wrong Service ID!";
                
            }

            return response;
        }//ok

        public string HA_setGracefulFailover(String NameNodeServiceID1, String NameNodeServiceID2)
        {

            if (NameNodeServiceID1 != "nn1" || NameNodeServiceID1 != "nn2" || NameNodeServiceID2 != "nn1" || NameNodeServiceID2 != "nn2")
            {
                response = "Invalid Input!";
            
            }
            else if ((NameNodeServiceID1 == "nn1" && NameNodeServiceID2 == "nn1") || (NameNodeServiceID1 == "nn2" && NameNodeServiceID2 == "nn2"))
            {
                response = "Both Service Id's Cannot be the same!";

            }
            else 
            {
                string NameNodeServiceID_1 = NameNodeServiceID1;
                string NameNodeServiceID_2 = NameNodeServiceID2;

                // string hadoop_bin_path = "cd " + hadoop_path + "\\bin";
                string failover = "hdfs haadmin -failover --forcefence --forceactive " + NameNodeServiceID_1 + " " + NameNodeServiceID_2;





                Process process = new Process();
                process.StartInfo = initializeCmd();
                process.Start();

                StreamWriter write = process.StandardInput;
                write.WriteLine(cmd_hadoop_bin_path);
                write.WriteLine(failover);

                response = "Setup Finished!";
            
            }

            return response;


        }

        public string HA_checkNNState(String NameNodeServiceID)
        {
            if (NameNodeServiceID == "nn1" || NameNodeServiceID == "nn2")
            {
                string NameNodeServiceID_1 = NameNodeServiceID;

                // string hadoop_bin_path = "cd " + hadoop_path + "\\bin";
                string checkState = "hdfs haadmin -getServiceState " + NameNodeServiceID_1 + @"> C:\hadoop\NNstate.txt";



                Process process = new Process();
                process.StartInfo = initializeCmd();
                process.Start();

                StreamWriter write = process.StandardInput;
                write.WriteLine(cmd_hadoop_bin_path);
                write.WriteLine(checkState);

               
                string line;
                int count = 0;

                System.IO.StreamReader file = new System.IO.StreamReader(@"C:\hadoop-2.7.2\etc\hadoop\slaves");

                while ((line = file.ReadLine()) != null)
                {
                    response = line;
                    count++;

                }
                file.Close();
               



            }
            else
            {
                response = "Wrong Service ID";
            }

            return response;

        }

        //#2 ZooKeeper High Availability aka Automatic Failover
        public string ZK_setup_zookeeper(String[] serverIPAddress, String serverID, String maxClientConnections)
        {
            string[] ipaddress = new string[100];
            ipaddress = checkip.get_all_Ip();

            if (ipaddress.Contains(serverIPAddress[0]) == false || ipaddress.Contains(serverIPAddress[1]) == false)
            {
                response = "Ip Address Invalid!";

            }
            else {
                string[] serverIPs = serverIPAddress;
                string id_server = serverID;
                int index = 1;

                if (!System.IO.Directory.Exists(zookeeper_path + "/data"))
                {
                    System.IO.Directory.CreateDirectory(zookeeper_path + "/data");
                    if (!System.IO.File.Exists(zookeeper_path + "/data/myid"))
                    {
                        System.IO.File.Create(zookeeper_path + "/data/myid").Close();

                    }

                }

                using (StreamWriter writer2 = new StreamWriter(zookeeper_path + "/data/myid"))
                {
                    writer2.WriteLine(id_server);
                }

                if (!System.IO.File.Exists(zookeeper_path + "/conf/zoo.cfg"))
                {
                    System.IO.File.Create(zookeeper_path + "/conf/zoo.cfg").Close();

                }

                using (StreamWriter writer = new StreamWriter(zookeeper_path + "/conf/zoo.cfg"))
                {


                    writer.WriteLine("tickTime=2000");
                    writer.WriteLine("initLimit=10");
                    writer.WriteLine("syncLimit=5");

                    writer.WriteLine("dataDir=" + zookeeper_path + "/data");
                    writer.WriteLine("clientPort=2181");
                    writer.WriteLine("maxClientCnxns=" + maxClientConnections);
                    foreach (string value in serverIPs)
                    {
                        writer.WriteLine("server." + index + "=" + value + ":2888:3888");
                        index++;
                    }

                    response = "Setup Complete!";           
            }

            

            }

            return response;

        }
        //#1 ZooKeeper High Availability aka Automatic Failover
        public string ZK_setup_hadoop_configs_with_ha(String[] NameNodeIPAddress, String[] JournalNodeIPAddress, String[] ZookeeperIPAddress, String replication_factor, String JNEditsDir)
        {

            string[] ipaddress = new string[100];
            ipaddress = checkip.get_all_Ip();

            if (ipaddress.Contains(NameNodeIPAddress[0]) == false || ipaddress.Contains(NameNodeIPAddress[1]) == false || ipaddress.Contains(JournalNodeIPAddress[0]) == false || ipaddress.Contains(JournalNodeIPAddress[1]) == false || ipaddress.Contains(JournalNodeIPAddress[2]) == false || ipaddress.Contains(ZookeeperIPAddress[0]) == false || ipaddress.Contains(ZookeeperIPAddress[1]) == false)
            {
                response = "Ip Address Invalid!";

            }
            else if (Convert.ToInt32(replication_factor) > 10 || Convert.ToInt32(replication_factor) < 1)
            {
                response = "Replication Factor Out of Bounds!";

            }
            else 
            {
                string six_indents = "            ";
                string five_indents = "     ";

                string NN1 = NameNodeIPAddress[0];
                string NN2 = NameNodeIPAddress[1];

                string[] JNs = JournalNodeIPAddress;

                string[] ZKs = ZookeeperIPAddress;


                string JNEditsDirectory = JNEditsDir;

                XmlWriterSettings settings = new XmlWriterSettings
                {
                    Indent = true,
                    IndentChars = "   ",
                    NewLineChars = "\r\n",
                    NewLineHandling = NewLineHandling.Replace
                };

                using (XmlWriter writer = XmlWriter.Create(hadoop_path + "\\etc\\hadoop\\core-site.xml", settings))
                {

                    writer.WriteStartDocument();
                    writer.WriteStartElement("configuration");
                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "fs.defaultFS");
                    writer.WriteElementString("value", "hdfs://mycluster");
                    writer.WriteEndElement();

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "ha.zookeeper.quorum");
                    string zookeeperQuroum = string.Empty;
                    foreach (string value in ZKs)
                    {

                        zookeeperQuroum = zookeeperQuroum + value + ":2181,";


                    }

                    zookeeperQuroum = zookeeperQuroum.Remove(zookeeperQuroum.Length - 1);
                    writer.WriteElementString("value", zookeeperQuroum);
                    writer.WriteEndElement();
                    writer.WriteEndElement();


                    writer.WriteEndDocument();
                }
                using (XmlWriter writer = XmlWriter.Create(hadoop_path + "\\etc\\hadoop\\hdfs-site.xml", settings))
                {

                    writer.WriteStartDocument();
                    writer.WriteStartElement("configuration");
                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "dfs.replication");
                    writer.WriteElementString("value", replication_factor);
                    writer.WriteEndElement();

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "dfs.namenode.name.dir");
                    writer.WriteElementString("value", "file:/hadoop/data/dfs/namenode");
                    writer.WriteEndElement();

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "dfs.datanode.data.dir");
                    writer.WriteElementString("value", "file:/hadoop/data/dfs/datanode");
                    writer.WriteEndElement();

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "dfs.permissions");
                    writer.WriteElementString("value", "false");
                    writer.WriteEndElement();


                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "dfs.webhdfs.enbled");
                    writer.WriteElementString("value", "true");
                    writer.WriteElementString("description", "to enable webhdfs");
                    writer.WriteElementString("final", "true");
                    writer.WriteEndElement();

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "dfs.nameservices");
                    writer.WriteElementString("value", "mycluster");
                    writer.WriteEndElement();

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "dfs.ha.namenodes.mycluster");
                    writer.WriteElementString("value", "nn1,nn2");
                    writer.WriteEndElement();

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "dfs.namenode.rpc-address.mycluster.nn1");
                    writer.WriteElementString("value", NN1 + ":8020");
                    writer.WriteEndElement();

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "dfs.namenode.rpc-address.mycluster.nn2");
                    writer.WriteElementString("value", NN2 + ":8020");
                    writer.WriteEndElement();

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "dfs.namenode.http-address.mycluster.nn1");
                    writer.WriteElementString("value", NN1 + ":50070");
                    writer.WriteEndElement();

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "dfs.namenode.http-address.mycluster.nn2");
                    writer.WriteElementString("value", NN2 + ":50070");
                    writer.WriteEndElement();



                    int JNindex = JNs.Length - 1;
                    int JNctr = 0;

                    string sharedEditsDir = string.Empty;

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "dfs.namenode.shared.edits.dir");
                    // writer.WriteElementString("value", "qjournal://" + JN1 + ":8485;" + JN2 + ":8485;" + JN3 + ":8485/mycluster");

                    foreach (string value in JNs)
                    {
                        if (JNctr == JNindex)
                        {
                            sharedEditsDir = sharedEditsDir + value + ":8485/mycluster";

                        }
                        else
                        {
                            sharedEditsDir = sharedEditsDir + value + ":8485;";

                        }
                        JNctr++;
                    }
                    writer.WriteElementString("value", "qjournal://" + sharedEditsDir);


                    writer.WriteEndElement();

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "dfs.client.failover.proxy.provider.mycluster");
                    writer.WriteElementString("value", "org.apache.hadoop.hdfs.server.namenode.ha.ConfiguredFailoverProxyProvider");
                    writer.WriteEndElement();

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "dfs.ha.fencing.methods");
                    writer.WriteElementString("value", "shell(" + hadoop_sbin_path + @"\\automatic-failover-fencer.cmd\)");
                    writer.WriteEndElement();

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "dfs.journalnode.edits.dir");
                    writer.WriteElementString("value", JNEditsDirectory);
                    writer.WriteEndElement();

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "dfs.ha.automatic-failover.enabled");
                    writer.WriteElementString("value", "true");
                    writer.WriteEndElement();

                    writer.WriteEndElement();

                    writer.WriteEndDocument();
                }
                using (XmlWriter writer = XmlWriter.Create(hadoop_path + "\\etc\\hadoop\\yarn-site.xml", settings))
                {

                    writer.WriteStartDocument();
                    writer.WriteStartElement("configuration");

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "yarn.nodemanager.aux-services");
                    writer.WriteElementString("value", "mapreduce_shuffle");
                    writer.WriteEndElement();

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "yarn.nodemanager.aux-services.mapreduce.shuffle.class");
                    writer.WriteElementString("value", "org.apache.hadoop.mapred.ShuffleHandler");
                    writer.WriteEndElement();

                    writer.WriteStartElement("property");
                    writer.WriteElementString("name", "yarn.application.classpath");
                    writer.WriteElementString("value", Environment.NewLine + six_indents + "%HADOOP_HOME%\\etc\\hadoop," +
                                                       Environment.NewLine + six_indents + "%HADOOP_HOME%\\share\\hadoop\\common\\*," +
                                                       Environment.NewLine + six_indents + "%HADOOP_HOME%\\share\\hadoop\\common\\lib\\*," +
                                                       Environment.NewLine + six_indents + "%HADOOP_HOME%\\share\\hadoop\\hdfs\\*," +
                                                       Environment.NewLine + six_indents + "%HADOOP_HOME%\\share\\hadoop\\hdfs\\lib\\*," +
                                                       Environment.NewLine + six_indents + "%HADOOP_HOME%\\share\\hadoop\\mapreduce\\*," +
                                                       Environment.NewLine + six_indents + "%HADOOP_HOME%\\share\\hadoop\\mapreduce\\lib\\*," +
                                                       Environment.NewLine + six_indents + "%HADOOP_HOME%\\share\\hadoop\\yarn\\*," +
                                                       Environment.NewLine + six_indents + "%HADOOP_HOME%\\share\\hadoop\\yarn\\lib\\*" +
                                                       Environment.NewLine + five_indents
                                                       );

                    writer.WriteEndElement();

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }

                response = "Setup Completed!";
            }



            return response;
            
        }

        //#6 ZooKeeper High Availability aka Automatic Failover
        public void ZK_setup_znode()
        {

            string transitionToActive = "hdfs zkfc -formatZK";


            Process process = new Process();
            process.StartInfo = initializeCmd();
            process.Start();

            StreamWriter write = process.StandardInput;
            write.WriteLine(cmd_hadoop_bin_path);
            write.WriteLine(transitionToActive);
            write.WriteLine("y");


        }
        //#7 ZooKeeper High Availability aka Automatic Failover
        public void ZK_start_zkfc()
        {

            string transitionToActive = "hdfs zkfc";


            Process process = new Process();
            process.StartInfo = initializeCmd();
            process.Start();

            StreamWriter write = process.StandardInput;
            write.WriteLine(cmd_hadoop_bin_path);
            write.WriteLine(transitionToActive);
            


        }

        public void ZK_Server()
        {
            Process.Start("cmd", @"/c cd C:\zookeeper\bin && zkServer.cmd").WaitForExit();
        }

    }

}
