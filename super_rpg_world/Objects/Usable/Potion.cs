using System;
using System.Collections.Generic;
using System.Text;

namespace super_rpg_world
{
    public class Potion : Usable
    {
        Random Random = new Random();

        public string PotName = "Poción";

        public Potion(int q) : base(q)
        {
            quantity = q;
        }

        public int Drink()
        {
            int healing = Random.Next(Program.Player.Hp[1] / 2, Program.Player.Hp[1] - Program.Player.Lvl * (Program.Player.Lvl / 3));
            Program.Player.Hp[0] = healing; 
            this.Use();
            return healing;
        }

    }
}
