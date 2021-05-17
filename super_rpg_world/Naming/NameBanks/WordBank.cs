using System;
using System.Collections.Generic;
using System.Text;

namespace super_rpg_world
{
    public class WordBank
    {
        public Word[] Sust;
        public Word[] Adj;
        public string[] Comp;
        public string[] Act;

        Random random = new Random();

        public Name GetName()
        {
            Name output = new Name();

            output.Sust = this.Sust[random.Next(0, this.Sust.Length)];

            output.Adj = this.Adj[random.Next(0, this.Adj.Length)];

            output.Comp = this.Comp[random.Next(0, this.Comp.Length)];

            output.Act = this.Act[random.Next(0, this.Act.Length)];

            return output;

        }

    }
}
