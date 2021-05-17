using System;
using System.Collections.Generic;
using System.Text;

namespace super_rpg_world
{
    static class Construct
    {
        //Returns a given string with a given probability over 100
        //If given false, omits the space after the string
        public static string Rand(string r, int prob)
        {
            Random random = new Random();
            if (random.Next(0, 100) <= prob)
            {
                return r + " ";
            }
            else { return ""; }
        }

        public static string Rand(string r, int prob, bool spc)
        {
            Random random = new Random();
            if (spc) { r = r + " "; }
            if (random.Next(0, 100) <= prob)
            {
                return r;
            }
            else { return ""; }
        }

        //When given an array, returns a random string from it
        public static string Rand(string[] r)
        {
            Random Random = new Random();
            return r[Random.Next(0, r.Length)];
        }

        public static string DiceRand(string[] r, int dice)
        {
            Random Random = new Random();
            int num = Random.Next(0, dice + 1) + Random.Next(0, dice + 1);
            if (num >= r.Length) { num = r.Length; }
            return r[num];
        }

        //Also, when given an array AND a number, has a posibility over 100 of returning an empty string
        public static string Rand(string[] r, int n)
        {
            Random Random = new Random();
            if (n >= Random.Next(0, 100))
            {
            return r[Random.Next(0, r.Length)];
            }
            else
            {
                return null;
            }
        }

        //Gives a random genre (n-m-f). If given ints:
        //the first represents the n probability (over 100)
        //the second the f probability and the rest is the m probability
        //Beware of errors here. In case of conflict neutre (n) wins.
        public static string Gen()
        {
            Random Random = new Random();
            int dice = Random.Next(0, 100);

            if (dice <= 5)
            {
                return "n";
            }
            else if (dice <= 45)
            {
                return "f";
            }
            else
            {
                return "m";
            }
        }

        public static string Gen(int a, int b)
        {
            Random Random = new Random();
            int dice = Random.Next(0, 100);

            if (dice <= a)
            {
                return "n";
            }
            else if (dice <= a + b)
            {
                return "f";
            }
            else
            {
                return "m";
            }
        }

        public static int Longest(List<string> list)
        {
            int longest = 0;
            foreach (string element in list)
            {
                if (element.Length > longest) { longest = element.Length; }
            }
            return longest;
        }
        public static int Longest(string[] list)
        {
            int longest = 0;
            foreach (string element in list)
            {
                if (element.Length > longest) { longest = element.Length; }
            }
            return longest;
        }

    }
}

