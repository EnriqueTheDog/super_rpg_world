using System;
using System.Collections.Generic;
using System.Text;

namespace super_rpg_world
{
    class Weapons
    {
        Random random = new Random();

        Mono[] sust = { new Mono("espada", "f", false), new Mono("espadón", "m", false), new Mono("maza", "f", true), new Mono("martillo", "m", false), new Mono("daga", "f", false), new Mono("garrote", "m", false), new Mono("puño americano", "m", false), new Mono("bate", "m", false), new Mono("nunchakus", "m", true), new Mono("mandoble", "m", false), new Mono("katana", "f", false), new Mono("cuchillo", "m", false), new Mono("látigo", "m", false), new Mono("guanteletes", "m", true), new Mono("sable", "m", false), new Mono("trabuco", "m", false), new Mono("alabarda", "f", false), new Mono("lucero del alba", "m", false), new Mono("cimitarra", "f", false), new Mono("hoja", "f", false), new Mono("filo", "m", false), new Mono("navaja", "f", false), new Mono("húmero", "m", false), new Mono("mangual", "m", false), new Mono("shuriken", "m", false), new Mono("kopesh", "m", false), new Mono("gancho", "m", false), new Mono("palanca", "f", false), new Mono("motosierra", "f", false) };

        Word[] adj = { new Word("rompeculos", true), new Word("élfic"), new Word("enan"), new Word("descomunal", true), new Word("mastodóntic", true), new Word("diminut"), new Word("invisible", true), new Word("engrasad"), new Word("oxidad"), new Word("milenari"), new Word("sagrad"), new Word("místic"), new Word("destripador", "", "a"), new Word("verdug"), new Word("emasculador", "", "a"), new Word("sanguinari"), new Word("microscópic"), new Word("interminable", true), new Word("maldit"), new Word("embrujad"), new Word("gigantesc", true), new Word("salvaje", true), new Word("idílic"), new Word("remot"), new Word("reluciente", true), new Word("invisible", true), new Word("mágic"), new Word("roj"), new Word("gris", true, "grises"), new Word("negr"), new Word("alucinógen"), new Word("fúngic"), new Word("faéric"), new Word("apocalíptic"), new Word("dorad"), new Word("explosiv"), new Word("caníbal", true, "caníbales") };

        string comp = "de" + " " + FantasyGen.Fantastic();

        //{Construct.Rand(new string[] {"" })}

        string[] act = { $"de los {Construct.Rand(new string[] { "elfos", "enanos", "orcos", "reyes", "gigantes", "magos" })} {Construct.Rand(new string[] { "oscuros", "borrachos", "nocturnos", "caídos", "antiguos", "milenarios", "perdidos" })}",
            $"de los {Construct.Rand(new string[] { "ladrones", "gusanos", "muñones", "perdidos", "macarras", "mil caminos", "pedos", "sustos. BUH!!!" })}",
            $"de {Construct.Rand(new string[] { "moco", "caramelo", "azúcar", "plástico", "granito", "azufre", "cristal", "magnesio", "plomo", "sangre", "caca", "fuego", "hielo", "cartulina", "mentira"})}", 
            $"de las {Construct.Rand(new string[] { "calaveras", "luciérnagas", "lamentaciones", "amazonas", "brujas", "hadas" })}", 
            $"de la {Construct.Rand(new string[] { "Locura", "desesperación", "perdición", "amargura", "sabiduría" })}", 
            $"del {Construct.Rand(new string[] { "gamberreo", "desuello", "despiporre", "despelote", "eco", "rocanrol", "dragón" })}" };

        public string GetPlace()
        {
            Mono s = sust[random.Next(0, sust.Length)];

            bool pl = false;

            if (s.plural && random.Next(1, 3) == 2) {  s.sust += "s"; pl = true; }

            string ct;

            if (random.Next(1, 3) == 1)
            {
                ct = Construct.Rand(act);
            }
            else
            {
                ct = comp;
            }

            int dice = random.Next(1, 8);

            if (dice <= 3)
            {
                return Common.Art(pl).GetWord(s.gender) + " " + s.sust + " " + adj[random.Next(0, adj.Length)].GetWord(s.gender, pl);
            }
            else if (dice <= 6)
            {
                return Common.Art(pl).GetWord(s.gender) + " " + s.sust + " " + ct;
            }
            else
            {
                return Common.Art(pl).GetWord(s.gender) + " " + s.sust + " " + adj[random.Next(0, adj.Length)].GetWord(s.gender, pl) + ct;
            }


        }


    }
}
