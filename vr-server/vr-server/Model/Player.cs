using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vr_server.Model
{
    class Player
    {
        //玩家id
        public virtual int playerId { get; set; }

        //昵称
        public virtual String username { get; set; }

    }
}
