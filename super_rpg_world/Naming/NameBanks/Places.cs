using System;
using System.Collections.Generic;
using System.Text;

namespace super_rpg_world
{
    class Places
    {
        Random random = new Random();

        Mono[] sust = { new Mono("monte", "m", true), new Mono("estación de servicio", "f", false), new Mono("bosque", "m", true), new Mono("montaña", "f", true), new Mono("pantano", "m", true), new Mono("valle", "m", false), new Mono("llanura", "f", true), new Mono("desierto", "m", true), new Mono("oficina", "f", true), new Mono("ciudad", "f", false), new Mono("polígono", "m", false), new Mono("selva", "f", false), new Mono("descampado", "m", false), new Mono("colina", "f", true), new Mono("autopista", "f", false), new Mono("peñasco", "m", false), new Mono("risco", "m", true), new Mono("marisma", "f", true), new Mono("laberinto", "m", false), new Mono("baldío", "m", true), new Mono("caverna", "f", true), new Mono("mar", "m", false), new Mono("tierra", "f", true), new Mono("pedregal", "m", false), new Mono("océano", "m", false), new Mono("cementerio", "m", false), new Mono("mina", "f", true), new Mono("pinar", "m", true), new Mono("sima", "f", false) };

        Word[] adj = { new Word("inhóspit"), new Word("encantad"), new Word("sagrad"), new Word("tenebros"), new Word("pestilente", true), new Word("recóndit"), new Word("umbrí"), new Word("virgen", true, "vírgenes"), new Word("florid"), new Word("azul", true, "azules"), new Word("asesin"), new Word("parlante", true), new Word("milenari"), new Word("suci"), new Word("polvorient"), new Word("nevad"), new Word("infinit"), new Word("microscópic"), new Word("interminable", true), new Word("maldit"), new Word("embrujad"), new Word("gigantesc", true), new Word("salvaje", true), new Word("idílic"), new Word("remot"), new Word("reluciente", true), new Word("invisible", true), new Word("mágic"), new Word("roj"), new Word("gris", true, "grises"), new Word("negr"), new Word("alucinógen"), new Word("fúngic"), new Word("faéric"), new Word("apocalíptic"), new Word("dorad"), new Word("explosiv"), new Word("caníbal", true, "caníbales") };

        string comp = "de" + " " + FantasyGen.Fantastic();

        //{Construct.Rand(new string[] {"" })}

        string[] act = { $"de los {Construct.Rand(new string[] { "elfos", "enanos", "orcos", "reyes", "gigantes", "magos" })} {Construct.Rand(new string[] { "oscuros", "borrachos", "nocturnos", "caídos", "antiguos", "milenarios", "perdidos" })}",
            $"de los {Construct.Rand(new string[] { "ladrones", "gusanos", "muñones", "perdidos", "macarras", "mil caminos", "pedos", "sustos. BUH!!!" })}",
            $"de {Construct.Rand(new string[] { "moco", "caramelo", "azúcar", "plástico", "granito", "azufre", "cristal", "magnesio", "plomo", "sangre", "caca", "fuego", "hielo", "cartulina", "mentira"})}", 
            $"de las {Construct.Rand(new string[] { "calaveras", "luciérnagas", "lamentaciones", "amazonas", "brujas", "hadas" })}", 
            $"de la {Construct.Rand(new string[] { "Locura", "desesperación", "perdición", "amargura", "sabiduría" })}", 
            $"del {Construct.Rand(new string[] { "botellón", "fin del mundo", "despiporre", "despelote", "eco", "rocanrol", "dragón" })}" };

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
