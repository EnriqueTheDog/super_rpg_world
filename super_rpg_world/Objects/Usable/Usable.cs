using System;
using System.Collections.Generic;
using System.Text;

namespace super_rpg_world
{
    public class Usable
    {
        public int quantity = 0;

        public Usable(int q)
        {
            quantity = q;
        }
        public void Use()
        {
            quantity--;
        }

    }

    

}
