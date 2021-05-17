using System;
using System.Collections.Generic;
using System.Text;

namespace super_rpg_world
{
    public class Player
    {
        static Random Random = new Random();
        public bool existent { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        //--Lifetime--
        //1 if young,
        //2 if middle-aged,
        //3 if old,
        //4 if very old,
        //5 if terribly old
        //6 if dead
        public int LifeTime { get; set; }
        //This one enlarges the player's life expectancies
        public int LongLife { get; set; }
        //f-m-n
        public string Gender { get; set; }

        public string Race { get; set; }
        public string Class { get; set; }
        //Skills
        public int St { get; set; }
        public int In { get; set; }
        public int Cr { get; set; }
        public int Rs { get; set; }
        public int Crit { get; set; }
        //Special abilities
        public bool cure { get; set; }
        public bool fury { get; set; }
        public bool meditate { get; set; }
        public bool vampire { get; set; }
        //Storage
        public int[] Hp = new int[2];
        public int[] Mana = new int[2];
        public int[] Xp = new int[2];

        public int Lvl { get; set; }

        public void NewPlayer()
        {
            existent = false;

            Name = "STATIC";
            Age = Random.Next(16, 24);
            LifeTime = 1;
            LongLife = 0;
            Race = "humano";
            Class = "";
            St = 1;
            In = 1;
            Cr = 1;
            Rs = 2;

            Crit = 1;

            cure = false;
            fury = false;
            meditate = false;
            vampire = false;
            Hp = new int[] { 24, 24 };
            Mana = new int[] { 7, 7 };
            Xp = new int[] { 0, 4 };

            Lvl = 1;

            bool invalidName;
            string newName;
            Menu CreatePlayerMenu = new Menu(5, true);
            do
            {
                Console.Clear();
                Boxy NameBoxy = new Boxy("Introduce el nombre de tu personaje", 2, 0, 5, true);
                newName = NameBoxy.ReadLine();
                NameBoxy.Erase();
                if (newName.Length <= 0)
                {
                    NameBoxy = new Boxy("Tienes que introducir un nombre ._.", 1, 0, 5, true);
                    Console.ReadKey();
                    invalidName = true;

                }
                else if (SavedGames.CheckPlayerName(newName))
                {
                    NameBoxy = new Boxy("Ya existe una partida guardada con este nombre", 1, 0, 5, true);
                    Console.ReadKey();
                    invalidName = true;
                }
                else
                {
                    invalidName = false;
                }
            } while (invalidName);

            this.Name = newName;
            switch (CreatePlayerMenu.Read(new string[] { "ella", "él", "elle" }, "Con qué pronombre prefieres que se refieran a ti?", 20))
            {
                case 0:
                    this.Gender = "f";
                    break;
                case 1:
                    this.Gender = "m";
                    break;
                case 2:
                    this.Gender = "n";
                    break;
            }
            Console.Clear();

            this.Race = Program.Races.NewRace(this.Gender);

            Boxy Message = new Boxy(22, 0, true, BackStory());
            Console.ReadKey();
            Console.Clear();
        }

        public void GainXp(int n)
        {
            this.Xp[0] += n;
            while (this.Xp[0] >= this.Xp[1])
            {
                this.Lvl++;
                this.LevelUp();
                this.Xp[0] -= this.Xp[1];
                //This controls the next level xp range needed
                this.Xp[1] += this.Xp[1] / 3 + (this.Lvl / 2 + this.Lvl % 2) * 2;
            }
            Program.PlayerStatus.Refresh();
        }

        public void LevelUp()
        {
            int pt = (Lvl / 2 + Lvl % 2) + Lvl/4;
            Menu StatMenu = new Menu(5, true);
            Hp[1] += (Hp[1] / 2 + Hp[1] % 2) + pt;
            Hp[0] = Hp[1];
            int i = 0;
            while (pt > 0)
            {
                switch (StatMenu.ReadVarious(new string[] { $"Fuerza({St})", $"Inteligencia({In})", $"Carisma({Cr})", $"Resistencia({Rs})" }, $"{Name} ha subido al nivel {Lvl}! Tienes {pt} puntos para gastar", 20, i))
                {
                    case 0:
                        St++;
                        pt--;
                        i = 0;
                        break;
                    case 1:
                        In++;
                        pt--;
                        i = 1;
                        break;
                    case 2:
                        Cr++;
                        pt--;
                        i = 2;
                        break;
                    case 3:
                        Rs++;
                        pt--;
                        i = 3;
                        break;
                }


                StatMenu.Erase();
            }
            Program.PlayerStatus.Refresh();
        }

        public bool IsAlive()
        {
            if (this.Hp[0] <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int TakeDamage(bool magicDmg, int dmg)
        {
            Random random = new Random();
            int rdm = random.Next(10, 30);

            if (magicDmg)
            {
                dmg = dmg - this.In / (rdm * 5 + 13) - this.Rs / (rdm * 10 - 7);
            }
            else
            {
                dmg = dmg - this.Rs / (rdm * 4 - 7);
            }
            this.Hp[0] -= dmg;
            if (Hp[0] < 0) { Hp[0] = 0; }
            return dmg;
        }

        public int PhisicDmg(bool critical)
        {
            int dmg = Random.Next(this.St - this.St / 5, this.St + this.St / 5);
            if (critical) { dmg += dmg; }
            return dmg;
        }

        public int MagicDmg(bool critical)
        {
            Mana[0]--;
            int dmg = Random.Next(this.In - this.In / 6, this.In + this.In / 3) * 2;
            if (critical) { dmg += dmg; }
            return dmg;
        }

        public int Discourse()
        {
            int dmg = Random.Next(this.Cr + this.Cr, this.Cr + this.Cr * 3);
            return dmg;
        }

        //Give a Mob.St int for convincing a mob to leave battle
        public bool Discourse(int res)
        {
            int dmg = Random.Next(this.Cr, this.Cr * 3);
            int resistance = Random.Next(res / 6, res / 2);
            if (dmg >= resistance) { return true; }
            else { return false; }
        }

        public int Heal(int n)
        {
            this.Hp[0] += n;
            if (this.Hp[0] > this.Hp[1]) { this.Hp[0] = this.Hp[1]; }
            return this.Hp[0];
        }

        public int Restore(int n)
        {
            this.Mana[0] += n;
            if (this.Mana[0] > this.Mana[1]) { this.Mana[0] = this.Mana[1]; }
            return this.Mana[0];
        }

        public void HappyBirthday()
        {
            this.Age++;
        }

        //Changes the lifestatus of the player
        public void GetOld()
        {
            Random random = new Random();
            int elong = 7;
            int meter = this.Age - LongLife + random.Next(-elong, elong);
            int deadly = random.Next(0, 100);
            switch (this.LifeTime)
            {
                case 1:
                    if (meter > 30) { this.LifeTime++; }
                    break;
                case 2:
                    if (meter > 50) { this.LifeTime++; }
                    break;
                case 3:
                    if (meter > 80)
                    {
                        if (deadly <= 80) { this.LifeTime++; }
                        else if (deadly > 80) { this.LifeTime = 6; }
                    }
                    break;
                case 4:
                    if (meter > 110)
                    {
                        if (deadly <= 50) { this.LifeTime++; }
                        else if (deadly > 50) { this.LifeTime = 6; }
                    }
                    break;
                case 5:
                    if (deadly > 20) { this.LifeTime++; }
                    break;
            }
        }

        public string BackStory()
        {
            Word[] proffesion = { new Word("programador", "", "a", "e"), new Word("granjer"), new Word("herrer"), new Word("community manager", true), new Word("camarer"), new Word("", "vendedor de seguros", "vendedora de seguros", "vendedore de seguros"), new Word("", "parado de larga duración", "parada de larga duración", "parade de larga duración"), new Word("charcuter") };

            String story = $"{new Word("cansad").GetWord(Gender)} de su {Construct.Rand(new string[] { "aburrida", "absurda", "insatisfactoria", "monótona", "gris", "mediocre" })} y {Construct.Rand(new string[] { "despreciable", "vacía", "nada emocionante", "miserable" })} {Construct.Rand(new string[] { "vida", "existencia" })} de {proffesion[Random.Next(0, proffesion.Length)].GetWord(Gender)}, decide embarcarse en una {Construct.Rand(new string[] { "nueva", "larga", "loca", "sangrienta", "legendaria", "épica" })} y {Construct.Rand(new string[] { "emocionante", "trepidante", "macabra", "peligrosa", "tortuosa" })}  {Construct.Rand(new string[] { "aventura", "cruzada", "aventura", "empresa", "aventura", "expedición" })} {Construct.Rand(new string[] { $"en busca {Construct.Rand(new string[] {"del amor verdadero", "de sus auténticos padres", "del vellocino de oro", "de la felicidad", "de un nuevo puesto de trabajo", "de su verdad interior"})}", $"para {Construct.Rand(new string[] {"salvar el mundo", "destruir el mal sobre la Tierra", "acabar con el capitalismo", "dominar el mundo"})}"})}";

            return $"{Name} es {Common.Dt().GetWord(Gender)} joven {Race} que, {story}.";

        }
    }
}
