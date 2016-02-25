using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using Communication;

namespace APIv2
{
    public class Producer
    {
        private Device device;
        private communication com;
        private CosmosObject cObj;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        public Producer(Device device) 
        {
            this.device = device;
        }

        /// <summary>
        /// Create and starts a topic for the device.
        /// </summary>
        public bool start()
        {
            com = new communication();
            cObj = new CosmosObject();
            string qName = com.generateID(8);
            object obj = null;

            cObj.DestinationIPAdress = device.Component.Address;
            cObj.DestinationQueue = "cosmos";
            cObj.SourceIPAddress = com.knowLocalIp().ToString();
            cObj.SourceQueue = qName;
            cObj.CommandType = 10;
            cObj.Payload = this.device;

            com.send(cObj);

            do
            {
                obj = com.startListen(qName);
            }while(obj == null);

            if (obj == null)
            {
                Console.WriteLine("exception to");
                return false;
            }
            else
                return true;
        }

        ///// <summary>
        ///// 
        ///// </summary>
        //public void stop() 
        //{ 
        
        //}
    }
}
