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
        public int reduct = 0;

        //Mob construction only requires a base level (based on the world's current corruption)
        public Mob(int lvl)
        {
            //this.Name = MobName.Name(Construct.Gen());
            int lev = lvl * (lvl / 2 + lvl % 2) - lvl / 2;

            this.St = lev + random.Next((lev - lev/3), (lev + lev/5));
            this.Hp[0] = lev + random.Next((lev + lev / 3), (lev*2));
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
            int dmg = St - reduct;
            return random.Next(dmg - dmg / 5, dmg + dmg / 5);
        }

        //Returns false when no more reduction is allowed
        public bool TakeDiscourse(int dmg)
        {
            if (reduct >= St * 0.3) { return false; }
            reduct = dmg;
            if (reduct >= St * 0.3) { reduct = Convert.ToInt32(St * 0.3); }
            return true;
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
