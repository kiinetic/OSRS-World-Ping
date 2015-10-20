using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRS_Ping {
    public class World {

        public int worldID, players, ping;
        public bool isMembers;
        public string location, canonicalName;

        public World(int worldID, int players, bool isMembers, string location, string canonicalName, int ping) {
            this.worldID = worldID;
            this.players = players;
            this.isMembers = isMembers;
            this.location = location;
            this.canonicalName = canonicalName;
            this.ping = ping;
        }
    }
}
