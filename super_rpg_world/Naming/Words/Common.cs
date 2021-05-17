using System;
using System.Collections.Generic;
using System.Text;

namespace super_rpg_world
{
    public static class Common
    {

        public static Word Dt()
        {
            return new Word("un", "", "a", "e");
        } 
            
        public static Word Art()
        {
            return new Word("", "el", "la", "le");
        }

        public static Word Art(bool pl)
        {
            if (pl)
            {
                return new Word("", "los", "las", "les");
            }
            else
            {
            return new Word("", "el", "la", "le");
            }

        }

    }
}
