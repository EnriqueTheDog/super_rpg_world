using System;
using System.Collections.Generic;
using System.Text;

namespace super_rpg_world
{
    public class Mono
    {
        public string sust { get; set; }
        public string gender { get; set; }
        public bool plural { get; set; }

        public Mono(string w, string g, bool plur)
        {
            sust = w;
            gender = g;
            plural = plur;
        }

    }
}
