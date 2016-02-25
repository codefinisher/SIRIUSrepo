using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Communication;
using Models;
using System.Threading;
using System.IO;
using Hydra;
using CosmosStorage;

namespace APIv2
{
    public class Cosmos
    {
        
        
        /// <summary>
        /// Retrieves component entry.
        /// </summary>
        /// <param name="componentID">string</param>
        /// <returns>Component object.</returns>
        public Component GetComponent(string componentID)
        {
            communication com = new communication();
            Request req = new Request();
            object obj = null;
            Component comp;
            CosmosObject co = new CosmosObject();
            string qName = com.generateID(8);

            req.componentID = componentID;
            req.isLocal = false;
            req.nType = 3;
            
            co.SourceIPAddress = com.knowLocalIp().ToString();
            co.DestinationIPAdress = com.knowLocalIp().ToString();
            co.SourceQueue = qName;
            co.DestinationQueue = "cosmos";
            co.CommandType = 2;
            co.Payload = (object)req;
 
            com.send(co);
            do
            {
                obj = com.startListen(qName);
            }
            while(obj == null);
            co = (CosmosObject)obj;
            comp = (Component)co.Payload;

            //add delete queue
            return comp;
        }

        /// <summary>
        /// Retrieves component entry.
        /// </summary>
        /// <param name="componentID">string</param>
        /// <returns>Component object.</returns>
        public Component GetComponent() 
        {
            communication com = new communication();
            Request req = new Request();
            object obj;
            Component comp = new Component();
            CosmosObject co = new CosmosObject();
            string qName = com.generateID(8);

            req.isLocal = true;
            req.nType = 3;
            
            co.SourceIPAddress = com.knowLocalIp().ToString();
            co.DestinationIPAdress = com.knowLocalIp().ToString();
            co.SourceQueue = qName;
            co.DestinationQueue = "cosmos";
            co.CommandType = 2;
            co.Payload = (object)req;
 
            com.send(co);
            do
            {
                obj = com.startListen(qName);
            }
            while(obj == null);
            
            co = (CosmosObject)obj;
            comp = (Component)co.Payload;
            //com.purge(qName, com.Session1);
            return comp;
        }


        /// <summary>
        /// Retrieves device entry.
        /// </summary>
        /// <param name="deviceID"></param>
        /// <returns></returns>
        public Device GetDevice (int deviceID)        
        {
            communication com = new communication();
            Request req = new Request();
            object obj = null;
            Device entry = null;
            CosmosObject co = new CosmosObject();
            string qName = com.generateID(8);

            req.entryID = deviceID.ToString();
            req.isLocal = true;
            req.nType = 0;
            
            co.SourceIPAddress = com.knowLocalIp().ToString();
            co.DestinationIPAdress = com.knowLocalIp().ToString();
            co.SourceQueue = qName;
            co.DestinationQueue = "cosmos";
            co.CommandType = 2;
            co.Payload = (object)req;
 
            com.send(co);
            do
            {
                obj = com.startListen(qName);
            }
            while(obj == null);
            co = (CosmosObject)obj;
            entry = (Device)co.Payload;
            
            return entry;
        }
        /// <summary>
        /// Retrieves device entry.
        /// </summary>
        /// <param name="deviceID"></param>
        /// <param name="componentID"></param>
        /// <returns></returns>
        public Device GetDevice (int deviceID , string componentID)        
        {
            communication com = new communication();
            Request req = new Request();
            object obj = null;
            Device entry = null;
            CosmosObject co = new CosmosObject();
            string qName = com.generateID(8);

            req.entryID = deviceID.ToString();
            req.componentID = componentID;
            req.isLocal = false;
            req.nType = 0;
            
            co.SourceIPAddress = com.knowLocalIp().ToString();
            co.DestinationIPAdress = com.knowLocalIp().ToString();
            co.SourceQueue = qName;
            co.DestinationQueue = "cosmos";
            co.CommandType = 2;
            co.Payload = (object)req;
 
            com.send(co);
            do
            {
                obj = com.startListen(qName);
            }
            while(obj == null);
            co = (CosmosObject)obj;
            entry = (Device)co.Payload;
            return entry;
        }

        public string GetFile(string directory) 
        {
            IStorage storage = new Hydra.Storage();

            string msg = storage.GetFile(directory);
            return msg;
        }

        public string EditFile(string directory)
        {
            IStorage storage = new Hydra.Storage();

            string msg = storage.EditFile(directory);
            return msg;        
        
        }

        public string SaveFile()
        {
            IStorage storage = new Hydra.Storage();

            string msg = storage.SaveFile();
            return msg;
        }

        public void testinglang()
        {
            Console.WriteLine("ni hao");
        }

        public string RegisterFile(string directory) 
        {
            IStorage storage = new Hydra.Storage();


            string msg = storage.RegisterFile(directory); 
            return msg;
        }

        public string[] SearchFile(string keyword) 
        {
            IStorage storage = new Hydra.Storage();

            string[] msg = storage.SearchFile(keyword);

            return msg;
        }


        public string DeleteFile(string keyword)
        {

            IStorage storage = new Hydra.Storage();

            string msg = storage.DeleteFile(keyword);

            return msg;
        
        }

        public string GetACL(string location)
        {
            IStorage sirius = new Hydra.Storage();
            string msg = sirius.GetACL(location);
            return "hi";
        }

        public string SetGroupACL(string location, string permission, string grpname, bool folderdefault)
        {
            IStorage sirius = new Hydra.Storage();
            string msg = sirius.SetGroupACL(location, permission, grpname, folderdefault);
            return "successfully changed group acl!";
        }

        public string SetUserACL(string location, string permission, string username, bool folderdefault)
        {
            IStorage sirius = new Hydra.Storage();
            string msg = sirius.SetUserACL(location, permission, username, folderdefault);
            return "successfully changed user acl!";
        }

        public string SetOthersACL(string location, string permission, bool folderdefault)
        {
            IStorage sirius = new Hydra.Storage();
            string msg = sirius.SetOthersACL(location, permission, folderdefault);
            return "successfully changed others acl!";
        }

        /// <summary>
        /// Retrieves file info entry.
        /// </summary>
        /// <param name="fileID"></param>
        /// <returns></returns>
        //public Models.File GetFile (int fileID)        
        //{
        //    communication com = new communication();
        //    Request req = new Request();
        //    object obj = null;
        //    Models.File entry = null;
        //    CosmosObject co = new CosmosObject();
        //    string qName = com.generateID(8);

        //    req.entryID = fileID.ToString();
        //    req.isLocal = true;
        //    req.nType = 1;
            
        //    co.SourceIPAddress = com.knowLocalIp().ToString();
        //    co.DestinationIPAdress = com.knowLocalIp().ToString();
        //    co.SourceQueue = qName;
        //    co.DestinationQueue = "cosmos";
        //    co.CommandType = 2;
        //    co.Payload = (object)req;
 
        //    com.send(co);
        //    do
        //    {
        //        obj = com.startListen(qName);
        //    }
        //    while(obj == null);

        //    co = (CosmosObject)obj;
        //    entry = (Models.File)co.Payload;

        //    return entry;
        //}

        ///// <summary>
        ///// Retrieves file info entry.
        ///// </summary>
        ///// <param name="fileID"></param>
        ///// <param name="componentID"></param>
        ///// <returns></returns>
        //public Models.File GetFile (int fileID,string componentID)        
        //{
        //    communication com = new communication();
        //    Request req = new Request();
        //    object obj = null;
        //    Models.File entry = null;
        //    CosmosObject co = new CosmosObject();
        //    string qName = com.generateID(8);

        //    req.entryID = fileID.ToString();
        //    req.componentID = componentID;
        //    req.isLocal = false;
        //    req.nType = 1;
            
        //    co.SourceIPAddress = com.knowLocalIp().ToString();
        //    co.DestinationIPAdress = com.knowLocalIp().ToString();
        //    co.SourceQueue = qName;
        //    co.DestinationQueue = "cosmos";
        //    co.CommandType = 2;
        //    co.Payload = (object)req;
 
        //    com.send(co);
        //    do
        //    {
        //        obj = com.startListen(qName);
        //    }
        //    while(obj == null);

        //    co = (CosmosObject)obj;
        //    entry = (Models.File)co.Payload;

        //    return entry;
        //}

        ///// <summary>
        ///// Retrieves device controller entry.
        ///// </summary>
        ///// <param name="devCtrlrID"></param>
        ///// <returns></returns>
        public DeviceController GetDeviceCtrlr(int devCtrlrID)
        {
            communication com = new communication();
            Request req = new Request();
            object obj = null;
            DeviceController entry = null;
            CosmosObject co = new CosmosObject();
            string qName = com.generateID(8);

            req.entryID = devCtrlrID.ToString();
            req.isLocal = true;
            req.nType = 2;

            co.SourceIPAddress = com.knowLocalIp().ToString();
            co.DestinationIPAdress = com.knowLocalIp().ToString();
            co.SourceQueue = qName;
            co.DestinationQueue = "cosmos";
            co.CommandType = 2;
            co.Payload = (object)req;

            com.send(co);
            do
            {
                obj = com.startListen(qName);
            }
            while (obj == null);

            co = (CosmosObject)obj;
            entry = (DeviceController)co.Payload;

            return entry;
        }

        /// <summary>
        /// Retrieves device controller entry.
        /// </summary>
        /// <param name="devCtrlrID"></param>
        /// <param name="componentID"></param>
        /// <returns></returns>
        public DeviceController GetDeviceCtrlr(int devCtrlrID, string componentID) 
        {
            communication com = new communication();
            Request req = new Request();
            object obj = null;
            DeviceController entry = null;
            CosmosObject co = new CosmosObject();
            string qName = com.generateID(8);

            req.entryID = devCtrlrID.ToString();
            req.componentID = componentID;
            req.isLocal = false;
            req.nType = 2;

            co.SourceIPAddress = com.knowLocalIp().ToString();
            co.DestinationIPAdress = com.knowLocalIp().ToString();
            co.SourceQueue = qName;
            co.DestinationQueue = "cosmos";
            co.CommandType = 2;
            co.Payload = (object)req;

            com.send(co);
            do
            {
                obj = com.startListen(qName);
            }
            while (obj == null);

            co = (CosmosObject)obj;
            entry = (DeviceController)co.Payload;

            return entry;

        }

        /// <summary>
        /// Registers entry in the network.
        /// </summary>
        /// <param name="entry"></param>
        /// <param name="nType"></param>
        /// <returns></returns>
        public bool Register(object entry, int nType)
        {
            communication com = new communication();
            Request req = new Request();
            object obj = null;
            CosmosObject co = new CosmosObject();
            string qName = com.generateID(8);

            req.isLocal = true;
            req.nType = nType;
            req.data = entry;

            co.SourceIPAddress = com.knowLocalIp().ToString();
            co.DestinationIPAdress = com.knowLocalIp().ToString();
            co.SourceQueue = qName;
            co.DestinationQueue = "cosmos";
            co.CommandType = 4;
            co.Payload = (object)req;

            com.send(co);
            do
            {
                obj = com.startListen(qName);
            }
            while (obj == null);

            co = (CosmosObject)obj;
            if (co.Payload is bool)
            {
                bool value = (bool)co.Payload;
                return value;
            }
            return false;
        }

        public object GetEntryList(int nType)
        {
            communication com = new communication();
            CosmosObject co = new CosmosObject();
            Request req = new Request();
            string qName = com.generateID(8);
            object obj;

            req.isLocal = true;
            req.nType = nType;

            co.SourceIPAddress = com.knowLocalIp().ToString();
            co.DestinationIPAdress = com.knowLocalIp().ToString();
            co.SourceQueue = qName;
            co.DestinationQueue = "cosmos";
            co.CommandType = 3;
            co.Payload = (object)req;

            com.send(co);
            do
            {
                obj = com.startListen(qName);
            }
            while (obj == null);

            co = (CosmosObject)obj;
            obj = co.Payload;
            return obj;

        }

        public List<Component> getComponentList()
        {
            communication com = new communication();
            CosmosObject co = new CosmosObject();
            Request req = new Request();
            List<Component> lComp;
            string qName = com.generateID(8);
            object obj;

            req.isLocal = false;
            req.nType = 3;

            co.SourceIPAddress = com.knowLocalIp().ToString();
            co.DestinationIPAdress = com.knowLocalIp().ToString();
            co.SourceQueue = qName;
            co.DestinationQueue = "cosmos";
            co.CommandType = 3;
            co.Payload = (object)req;

            com.send(co);
            do
            {
                obj = com.startListen(qName);
            }
            while (obj == null);

            co = (CosmosObject)obj;
            lComp = (List<Component>)co.Payload;
            return lComp;

        }
       
        public object GetEntryList (int nType,Component comp)        
        {
            communication com = new communication();
            CosmosObject co = new CosmosObject();
            Request req = new Request();
            string qName = com.generateID(8);
            object obj;

            req.isLocal = true;
            req.nType = nType;

            co.SourceIPAddress = com.knowLocalIp().ToString();
            co.DestinationIPAdress = comp.Address;
            co.SourceQueue = qName;
            co.DestinationQueue = "cosmos";
            co.CommandType = 3;
            co.Payload = (object)req;

            com.send(co);
            do
            {
                obj = com.startListen(qName);
            }
            while (obj == null);

            co = (CosmosObject)obj;
            obj = co.Payload;
            return obj;

        }

        public void SendFile(Models.File file,Component comp)
        {
            communication com = new communication();
            CosmosObject cos = new CosmosObject();

            cos.CommandType = 9;
            cos.DestinationIPAdress = comp.Address;
            cos.DestinationQueue = "cosmos";
            cos.SourceQueue = com.generateID(8);
            cos.SourceIPAddress = com.knowLocalIp().ToString();
            cos.Payload = (object)file;
            com.send(cos);
        }

        public Models.File GetFileInfo(string filePath)
        {
            FileInfo f = new FileInfo(filePath);
            Models.File file = new Models.File();

            file.FileName = f.Name;
            file.FileLocation = f.FullName;
            file.FileSize = f.Length.ToString();
            file.FileType = Path.GetExtension(filePath);

            return file;
        }

        //public void GetFile(Models.File file, string filePath)
        //{
        //    communication com = new communication();
        //    Request req = new Request();
        //    CosmosObject co = new CosmosObject();
        //    string qName = com.generateID(8);
        //    object obj = null;
        //    byte[] buffer;

        //    co.SourceIPAddress = com.knowLocalIp().ToString();
        //    co.DestinationIPAdress = file.Component.Address;
        //    co.SourceQueue = qName;
        //    co.DestinationQueue = "cosmos";         
        //    co.CommandType = 7;
        //    co.Payload = (object)file;

        //    com.send(co);

        //    FileStream fs = System.IO.File.Create( filePath + "\\" + file.FileName, 524288);
            
        //    do
        //    {
        //        obj = com.startListen(qName);
        //        co = (CosmosObject)obj;
        //        buffer = co.Payload as byte[];
        //        if (co.CommandType == 99)
        //        {
        //            fs.Write(buffer, 0, co.Buffer);
        //        }
        //    }
        //    while (co.CommandType == 99);
        //    fs.Close();
        }
    }

