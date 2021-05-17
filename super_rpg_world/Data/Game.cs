using System;
using System.Collections.Generic;
using System.Text;

namespace super_rpg_world
{
    public class Game
    {
        public int GameID { get; set; }
        public Player SavedPlayer { get; set; }
        public World SavedWorld { get; set; }
        public Inventory SavedInv { get; set; }

        public Game(int id, Player player, Inventory Inv, World World)
        {
            GameID = id;
            SavedPlayer = player;
            SavedWorld = World;
            SavedInv = Inv;
        }

    }
}
