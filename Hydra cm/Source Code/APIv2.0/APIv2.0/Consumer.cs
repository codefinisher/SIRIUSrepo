using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Communication;
using Models;
using CoreV2;
using ActiveMQ;
using NMS;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace APIv2
{
    public class Consumer:Cosmos
    {

        private Device device;
        private SimpleTopicSubscriber topic;
        public Consumer(Device dev) 
        {
            this.device = dev;
        }
        public bool start() 
        {
            bool success = false;
            communication com = new communication();
            string uri = "tcp://"+device.Component.Address+":61616";
            string clientID = com.generateID(10);

            try
            {
                topic = new SimpleTopicSubscriber(device.DeviceQueue, uri, clientID, clientID);
            }
            catch (Exception e) 
            { 
                
            }
            return success;
        }
        public object subscribe() 
        {
            byte[] bytes = Convert.FromBase64String(topic.getData());
            MemoryStream ms = new MemoryStream(bytes, 0, bytes.Length);
            ms.Write(bytes, 0, bytes.Length);
            ms.Position = 0;
            return new BinaryFormatter().Deserialize(ms);

        }
    }
}
