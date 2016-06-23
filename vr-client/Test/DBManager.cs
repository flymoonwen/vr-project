using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate;


using NHibernate;
using Test.Model;

namespace Test.db
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


        public IList<Player> GetUserByUsername(string name)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var playerList = session.QueryOver<Player>().Where(user =>user.username == name);
                    return playerList.List();
                }
            }
        }
        public static void savePlayer()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var player = new Player {username = "d" };
                    session.Save(player);


                    player.username = "username";
                    session.Update(player);
                    
                    transaction.Commit();
                    Console.WriteLine("Player Saved");
                    Console.ReadKey();

                }
            }
        }
        static void Main(string[] args)
        {
            DBManager mgr = new DBManager();
            IList<Player> resList = mgr.GetAllUser();

            IList<Player> namedList = mgr.GetUserByUsername("username");
            try
            {
                foreach (Player player in resList)
                {
                    Console.WriteLine("playerId: " + player.playerId + " username: " +  player.username);
                }


                foreach (Player player in namedList)
                {
                    Console.WriteLine("named player  playerId: " + player.playerId + " username: " + player.username);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);            	
            }
            finally
            {

            }



            savePlayer();


        }
        
    }
}
