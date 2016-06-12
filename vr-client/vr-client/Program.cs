using ExitGames.Client.Photon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vr_client
{

    class ChatServerListener : IPhotonPeerListener
    {
        public Boolean isConnected = false;

        public void DebugReturn(DebugLevel level, string message)
        {

        }

        public void OnEvent(EventData eventData)
        {

        }

        public void OnMessage(object messages)
        {

        }

        /*************************************************
        // Description: 处理服务器返回
        // Returns: void
        // Parameter: operationResponse
        *************************************************/
        public void OnOperationResponse(OperationResponse operationResponse)
        {
            Console.WriteLine("OnOperationResponse");
            Dictionary<byte, object> dict = operationResponse.Parameters;
            object va = null;

            //获取有效数据
            dict.TryGetValue(1, out va);
            if (null != va)
            {
                Console.WriteLine("Get value from server: " + va.ToString());
            }
            else
            {
                Console.WriteLine("Error : Get value from server");
            }

        }

        public void OnStatusChanged(StatusCode statusCode)
        {
            switch (statusCode)
            {
                case StatusCode.Connect: //连接到服务器
                    this.isConnected = true;
                    Console.WriteLine("Connect...");
                    break;
}
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ChatServerListener listener = new ChatServerListener();

            PhotonPeer peer = new PhotonPeer(listener, ConnectionProtocol.Tcp);
            peer.Connect("127.0.0.1:4532", "vr-server"); //连接服务器
            while (listener.isConnected == false)
            {
                peer.Service();
            }

            Dictionary<byte, object> dict = new Dictionary<byte, object>();
            dict.Add(1, "username");
            dict.Add(2, "password");
            peer.OpCustom(1, dict, true);



            while (true)
            {
                peer.Service();
            }
            
            
            


            Console.ReadLine();


        }
    }
}
