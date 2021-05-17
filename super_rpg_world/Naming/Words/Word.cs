using System;
using System.Collections.Generic;
using System.Text;

namespace super_rpg_world
{
    public class Word
    {
        private string Root;
        private string Sufn;
        private string Suff;
        private string Sufm;
        private string ipl;

        public Word(string root)
        {
            this.Root = root;
            this.Sufn = "e";
            this.Suff = "a";
            this.Sufm = "o";
        }
        public Word(string root, bool fix)
        {
            this.Root = root;
            this.Sufn = "";
            this.Suff = "";
            this.Sufm = "";
        }

        public Word(string root, bool fix, string plural)
        {
            this.Root = root;
            this.Sufn = "";
            this.Suff = "";
            this.Sufm = "";
            this.ipl = plural;
        }

        public Word(string root, string sufn)
        {
            this.Root = root;
            this.Sufn = sufn;
            this.Suff = "a";
            this.Sufm = "o";
        }
        public Word(string root, string sufm, string suff)
        {
            this.Root = root;
            this.Sufn = "e";
            this.Suff = suff;
            this.Sufm = sufm;
        }

        public Word(string root, string sufm, string suff, string sufn)
        {
            this.Root = root;
            this.Sufn = sufn;
            this.Suff = suff;
            this.Sufm = sufm;
        }

        //If given a bool in first place, takes different words for the f and m;
        //When not specified, n is equal to m
        public Word(bool only, string f, string m)
        {
            this.Root = "";
            this.Suff = f;
            this.Sufm = m;
            this.Sufn = m;
        }
        
        public Word(bool only, string f, string m, string n)
        {
            this.Root = "";
            this.Suff = f;
            this.Sufm = m;
            this.Sufn = n;
        }

        public string GetWord(string g)
        {
            switch (g)
            {
                case "f":
                    return this.Root + this.Suff;
                    break;
                case "m":
                    return this.Root + this.Sufm;
                    break;
                case "n":
                    return this.Root + this.Sufn;
                    break;
                default:
                    return this.Root + "x";
                    break;
            }
        }

        public string GetWord(string g, bool plural)
        {

            string word;

            switch (g)
            {
                case "f":
                    word = this.Root + this.Suff;
                    break;
                case "m":
                    word = this.Root + this.Sufm;
                    break;
                case "n":
                    word = this.Root + this.Sufn;
                    break;
                default:
                    word = this.Root + "x";
                    break;
            }

            if (plural)
            {
                if (ipl != null)
                {
                    return ipl;
                }
                else
                {
                return word + "s";
                }
            }
            else
            {
                return word;
            }
        }

    }
}
