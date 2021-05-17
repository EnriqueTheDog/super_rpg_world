using System;
using System.Collections.Generic;
using System.Text;

namespace super_rpg_world
{
    public class Name
    {
        public Word Sust;
        public Word Adj;
        public string Comp;
        public string Act;
        public string Dt;
        public string Art;

        public string shortName;
        public string largeName;

        public string Print(bool size, int pre)
        {
            string output = shortName;
            if (size) { output += largeName; }
            if (pre == 2) { output = Art + " " + output;  }
            else if (pre == 1) { output = Dt + " " + output; }
            return output.Substring(0, output.Length - 1);
        }

        public void MobName(string g)
        {

            this.Dt = Common.Dt().GetWord(g);
            this.Art = Common.Art().GetWord(g);
            this.shortName = Sust.GetWord(g) + " " + Construct.Rand(Adj.GetWord(g), 80);
            string compi = Construct.Rand(Comp, 60);
            string acting = Construct.Rand(Act, 60);
            if ((shortName + compi).Length <= 20)
            {
                shortName += compi;
                largeName = acting;
            }
            else
            {
                largeName = compi + acting;
            }
        }

    }
}
