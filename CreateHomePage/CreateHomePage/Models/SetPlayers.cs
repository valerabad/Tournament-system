using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreateHomePage.Models
{
    public class SetPlayers
    {
        public SetPlayers()
        {
            int countPl = 8;
            for (int i=0; i< countPl; i++)
            Players.Add(new Player("testName"+Convert.ToString(i+1),i,12,"информация о спортсмене",Convert.ToString(i)));
        }
        public List<Player> Players = new List<Player>();
    }
}