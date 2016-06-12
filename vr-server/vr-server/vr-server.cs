/* 
    ======================================================================== 
        File name：        vr_server
        Module:                
        Author：           lw
        Create Time：    2016/6/7 10:22:58
        Modify By:        
        Modify Date:    
    ======================================================================== 
*/

using ExitGames.Logging;
using ExitGames.Logging.Log4Net;

using log4net;
using log4net.Config;
using Photon.SocketServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using logMananger = ExitGames.Logging.LogManager;

namespace vr_server 
{
    class vr_server : ApplicationBase
    {

        protected static readonly ILogger Log = logMananger.GetCurrentClassLogger();
        /*************************************************
        // Description: 客户端连接时调用
        // Returns: override PeerBase
        // Parameter: initRequest
        *************************************************/
        protected override PeerBase CreatePeer(InitRequest initRequest)
        {
            Log.Info("CreatePeer " + initRequest.RemoteIP);
            return new MyPeer(initRequest);
        }



        /*************************************************
        // Description: 服务器启动时调用
        // Returns: override void
        *************************************************/
        protected override void Setup()
        {
            logMananger.SetLoggerFactory(Log4NetLoggerFactory.Instance);
            GlobalContext.Properties["LogFileName"] = "vr-server";
            XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(System.IO.Path.Combine(BinaryPath, "log4net.config")));
            Log.Info("Setup");
        }
        


        /*************************************************
        // Description: 服务器关闭调用
        // Returns: override void
        *************************************************/
        protected override void TearDown()
        {
            Log.Info("TearDown");
        }




    }
}
