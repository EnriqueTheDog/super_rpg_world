using System;
using System.Collections.Generic;
using System.Text;

namespace super_rpg_world
{
    public class World
    {
        static Random Random = new Random();

        public string Name  = "Gaia";
        public int corruption = 1;
        public int Id;
        public int months;
        public int age = Random.Next(1, 7777);

        public void CheckCorruption()
        {

        }

    }
}
