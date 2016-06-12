
/* 
    ======================================================================== 
        File name：        ClientPeer
        Module:                
        Author：           lw
        Create Time：    2016/6/7 10:41:20
        Modify By:        
        Modify Date:    
    ======================================================================== 
*/


using Photon.SocketServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotonHostRuntimeInterfaces;

namespace vr_server
{
    public class MyPeer : ClientPeer
    {
        public MyPeer(InitRequest initRequest):base(initRequest)
          {

          }
        /*************************************************
        // Description:
        // Returns: override void
        // Parameter: reasonCode
        // Parameter: reasonDetail
        *************************************************/
        protected override void OnDisconnect(DisconnectReason reasonCode, string reasonDetail)
        {
        

        }

        /*************************************************
        // Description: 响应客户端请求
        // Returns: override void
        // Parameter: operationRequest
        // Parameter: sendParameters
        *************************************************/
        protected override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters)
        {
            //构造返回信息
            Dictionary<byte, object> dict = new Dictionary<byte, object>();
            dict.Add(1, "response");
            OperationResponse resp = new OperationResponse(1, dict);

            //发送返回
            SendOperationResponse(resp, sendParameters);
            



        }
    }
}
