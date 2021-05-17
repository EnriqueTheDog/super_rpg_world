using System;
using System.Collections.Generic;
using System.Text;

namespace super_rpg_world
{
    public static class FantasyGen
    {
        public static string Fantastic()
        {
            Random random = new Random();

            string[] vow = { "û", "ô", "ì", "ë", "ä", "u", "o", "i", "e", "a", "a", "e", "i", "o", "u", "â", "e", "i", "ù", "oo" };
            string[] syllaVow = { "r", "t", "p", "s", "d", "ph", "k", "x", "v", "br", "m", "t", "d", "m", "k", "n", "h"};
            string[] cons = { "r", "t", "l", "d", "z", "m", "n", "ll", "r", "r", "s", "k" };

            string word = null;
            int count = 1;

            do
            {
                int rdm = random.Next(1, 4);

                if (rdm == 3)
                {
                    word += Construct.Rand(syllaVow) + Construct.Rand(vow) + Construct.Rand(new string[] {" ", "'", "-", $" {FanSyll()} " }, count*10);
                }
                else if (rdm == 2)
                {
                    word += Construct.Rand(syllaVow) + Construct.Rand(vow) + Construct.Rand(cons) + Construct.Rand(new string[] { " ", "'", "-", $" {FanSyll()} " }, count * 10);
                }
                else
                {
                    word += Construct.Rand(vow) + Construct.Rand(cons) + Construct.Rand(new string[] { " ", "'", "-", $" {FanSyll()} " }, count * 10);
                }

                count++;

            } while (random.Next(1, 4) != 3 && count < 5);

            if (word[word.Length - 1].ToString() == "-" | word[word.Length - 1].ToString() == " " | word[word.Length - 1].ToString() == "'")
            {
                word = word.Substring(0, word.Length - 2);
            }

            for (int i = 0; i < word.Length - 2; i++)
            {
                if (Convert.ToString(word[i]) == " " || Convert.ToString(word[i]) == "-" )
                {
                    word = word.Substring(0, i + 1) + word.Substring(i + 1, 1).ToUpper() + word.Substring(i + 2);
                }
            }


            return Char.ToUpper(word[0]) + word.Substring(1);

        }

        public static string FanSyll()
        {
            Random random = new Random();

            string[] vow = { "ô", "û", "ò", "ë", "ui", "ae", "u", "e", "a", "i", "o", "ea", "iu", "ëa", "ii", "'" };
            string[] syllaVow = { "r", "t", "p", "s", "dr", "ph", "th", "k", "x", "v", "vr", "br", "nr", "m", "tr", "dh", "mh", "nh", "tk", "md" };
            string[] cons = { "r", "t", "q", "l", "d", "z", "m", "n", "ll", "r", "r", "s", "k" };

            string word = null;

                int rdm = random.Next(1, 4);

                if (rdm == 3)
                {
                    word += Construct.Rand(syllaVow) + Construct.Rand(vow) + Construct.Rand(" ", 10);
                }
                else if (rdm == 2)
                {
                    word += Construct.Rand(syllaVow) + Construct.Rand(vow) + Construct.Rand(cons) + Construct.Rand(" ", 10);
                }
                else
                {
                    word += Construct.Rand(vow) + Construct.Rand(cons) + Construct.Rand(" ", 10);
                }

            return word;
            }
    }
}
