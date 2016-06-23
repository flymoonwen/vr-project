using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Model;

namespace Test.db.Mapping
{
    class PlayerMap :ClassMap<Player>
    {
        public PlayerMap()
        {
            Table("player");
            Id(x => x.playerId).Column("playerId").GeneratedBy.Increment();
            Map(x => x.username);
         

        }

    }
}
