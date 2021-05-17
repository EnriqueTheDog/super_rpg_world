using System;
using System.Collections.Generic;
using System.Text;

namespace super_rpg_world
{
    public class Mob
    {
        Random random = new Random();

        public Name Name;
        public int Xp;
        public int St;
        public int[] Hp = new int[2];
        public bool PhRes = false;
        public bool MgRes = false;

        public static void Baptize()
        {
            
        }

        //Mob construction only requires a base level (based on the world's current corruption)
        public Mob(int lvl)
        {
            //this.Name = MobName.Name(Construct.Gen());
            int lev = lvl * (lvl / 2 + lvl % 2) - lvl / 2;

            this.St = lev + random.Next((lev - lev/3), (lev + lev/5));
            this.Hp[0] = lev + random.Next((lev - lev / 3), (lev + lev / 2));
            this.Hp[1] = this.Hp[0];
            this.Xp = lev + (lvl / 2 + lvl % 2);

            if (random.Next(1, 10) <= 2)
            {
                if (random.Next(1, 2) == 1)
                {
                    this.PhRes = true;
                }
                else
                {
                    this.MgRes = true;
                }
            }

        }

        public int Attack()
        {
            return random.Next(this.St - this.St / 5, this.St + this.St / 5);
        }

        public int TakeDmg(int q, bool magic)
        {
            if (magic && MgRes == true)
            {
                q -= random.Next(q / 5, q / 2);
            }
            else if (!magic && PhRes == true)
            {
                q -= random.Next(q / 5, q / 2);
            }

            this.Hp[0] -= q;
            if (Hp[0] < 0) { Hp[0] = 0; }
            return q;
        }

    }
}
