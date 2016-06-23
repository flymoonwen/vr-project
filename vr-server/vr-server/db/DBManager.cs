using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vr_server.Model;

namespace vr_server.db
{
    class DBManager
    {
        public IList<Player> GetAllUser()
        {
            using( var session = NHibernateHelper.OpenSession())
            {
                using(var transaction = session.BeginTransaction())
                {
                    var playerList = session.QueryOver<Player>();
                    return playerList.List();
                }
            }
        }

        static void Main(string[] args)
        {
            DBManager mgr = new DBManager();
            IList<Player> resList = mgr.GetAllUser();
            foreach(Player player in resList)
            {
                Console.WriteLine(player.username);
            }
        }
        
    }
}
