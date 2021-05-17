using System;
using System.Collections.Generic;
using System.Text;

namespace super_rpg_world
{
    public class Races : WordBank
    {
            public Random random = new Random();

        public Races()
        {

            this.Sust = new Word[] { new Word("elf"), new Word("human"), new Word("median"), new Word("enan"), new Word("elf"), new Word("human"), new Word("orco", true), new Word("human") };

            this.Adj = new Word[] { new Word("de las colinas", true), new Word("de los bosques", true), new Word("de las cuevas", true), new Word("de los pantanos", true) };

        }

        public string NewRace(string g)
        {
            Name output = new Name();

            output.Sust = this.Sust[random.Next(0, this.Sust.Length)];

            output.Adj = this.Adj[random.Next(0, this.Adj.Length)];

            string race = output.Sust.GetWord(g);
                
            string add = Construct.Rand(" " + output.Adj.GetWord(g), 60);

            if (add.Length > 1) { add = add.Substring(0, add.Length); }

            return race + add;

        }
    }
}
