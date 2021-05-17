using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace super_rpg_world
{
    class Program
    {
        static public SqlConnection connection = new SqlConnection("Data source=PC-CATALINA\\SQLEXPRESS; Initial Catalog=RPGWORLD; integrated security=true");


        
        static public Mob Mob;
        static public Player Player = new Player();
        static Random Random = new Random();
        static Travel Journey = new Travel();
        static Box Box = new Box(5, 3);
        static public PlayerStatus PlayerStatus;
        static MobStatus MobStatus;
        static public Races Races = new Races();

        //Inventory Items
        static public Inventory Inventory;

        //World
        static public World Gea;
        static bool gameover = false;





        //Turn vars
        static bool loot = false;
        static string lastAct = "born";


        static void Main(string[] args)
        {

            //while (1 < 2)
            //{
            //    Console.WriteLine(FantasyGen.Fantastic());
            //    Console.ReadKey();
            //}



            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

            //Preset
            string msg = null;

            //Game Bucle
            while (1 < 2)
            {
                //First of all - Loading savedgames list
                List<Game> Games = SavedGames.GetAll();
                //StartMenu - false load, true new Player
                if (StartMenu(Games))
                {

                    Inventory = new Inventory();
                    Gea = new World();

                    //Creating new player
                    Player.NewPlayer();

                }

                //Once the player is created or loaded, we refresh the statics
                Mob = new Mob(Gea.corruption);                
                PlayerStatus = new PlayerStatus(15, 3);
                gameover = false;

                //Gameplay
                while (!gameover)
                {
                    //Pre-turn
                    PlayerStatus.Refresh();

                    //Setting world corruption
                    if (!loot)
                    {
                        if (Random.Next(1, 4) == 4)
                        {
                            Gea.corruption++;
                        }
                    }
                    else
                    {
                        loot = false;
                        if (Random.Next(1, 4) <= 3)
                        {
                            Gea.corruption++;
                        }
                    }

                    //Setting starting turn msg
                    switch (lastAct)
                    {
                        case "born":
                            msg = "Amanece un hermoso día.";
                            break;
                        case "fight":
                            msg = "Menuda carnicería!";
                            break;
                        case "camp":
                            msg = "Amanece un hermoso día.";
                            break;
                        case "dialogue":
                            msg = "Menudo combate dialéctico!";
                            break;
                        case "runaway":
                            msg = "Por los pelos!";
                            break;
                    }


                    //Turn Itself
                    if (!Journey.Direction(msg))
                    {
                        gameover = true;
                    }
                    else
                    {
                        if (Encounter())
                        {
                            Combat();
                        }

                        Gea.months += Random.Next(1, 4);
                    }



                    //End of turn checkout


                    while (Gea.months >= 12)
                    {
                        Gea.months -= 12;
                        Gea.age++;
                        Player.Age++;
                    }



                }

                if (Player.Hp[0] <= 0)
                {
                    Console.Clear();
                    Graphics.Death(5);
                    SavedGames.DeleteCurrentGame();
                    Console.ReadKey();
                }

                Console.Clear();
            }
        }

        static bool Encounter()
        {
            Place Place = new Place();
            Menu RunMenu = new Menu(3, true);
            int rdn = Random.Next(1, 7);

            if (rdn == 1)
            {
                switch (RunMenu.Read(new string[] { "Montar el campamento", "Descansar es para débiles" }, $"{Arrival()} Todo está tranquilo ¿Qué haces?", 30))
                {
                    case 0:
                        RunMenu.Erase();
                        Firecamp.FireMenu();
                        break;
                    case 1:
                        RunMenu.Erase();
                        Boxy Keep = new Boxy(17, 0, true, "Sigues andando toda la noche");
                        Console.ReadKey();
                        Keep.Erase();
                        break;
                }
                lastAct = "camp";
                return false;
            }
            else
            {
                anotherMob();
                switch (RunMenu.Read(new string[] { "Luchar", "Parlamentar", "Huir" }, $"{Arrival()} {View()} {Mob.Name.Print(true, 1)}. ¿Qué haces?", 37))
                {
                    case 2:
                        if (Random.Next(1, 4) == 1)
                        {
                            RunMenu.Erase();
                            Boxy Message = new Boxy(22, 0, true, $"Huíste como {Common.Dt().GetWord(Player.Gender)} cobarde!");
                            lastAct = "runaway";
                            Console.ReadKey();
                            Message.Erase();
                            return false;
                        }
                        else
                        {
                            RunMenu.Erase();
                            Boxy MessageTwo = new Boxy(22, 0, true, "No puedes huir!");
                            Console.ReadKey();
                            MessageTwo.Erase();
                            return true;
                        }
                        break;
                    case 0:
                        RunMenu.Erase();
                        Boxy MessageThree = new Boxy(22, 0, true, "A luchar!");
                        Console.ReadKey();
                        MessageThree.Erase();
                        return true;
                        break;
                    case 1:
                        RunMenu.Erase();
                        if (Player.Discourse(Mob.St))
                        {
                            int xp = Random.Next(Mob.Attack() / 8, Mob.Attack() / 5) + 1;

                            Boxy MessageConvinced = new Boxy(22, 0, true, $"Charlas con el monstruo y lo vuelves pacifista. Ganas {xp} xp");
                            Console.ReadKey();
                            Player.GainXp(xp);
                            MessageConvinced.Erase();
                            loot = true;
                            lastAct = "dialogue";
                            return false;
                        }
                        else
                        {
                            if (Random.Next(1, 2) == 1)
                            {
                                Boxy MessageUnConvinced = new Boxy(22, 0, true, "Intentas hablar con el monstruo, pero solo quiere luchar!");
                                Console.ReadKey();
                                MessageUnConvinced.Erase();
                                return true;
                            }
                            else
                            {
                                Boxy MessageUnConvinced = new Boxy(22, 0, true, "Tu discurso vuelve al monstruo más agresivo!");
                                Mob.St += Random.Next(Mob.St / 10, Mob.St / 9);
                                Console.ReadKey();
                                MessageUnConvinced.Erase();
                                return true;
                            }
                        }

                        break;
                }
            }
            return false;
        }

        static void Combat()
        {
            Menu Combat = new Menu(3, true);
            bool runaway = false;
            while (1 < 2)
            {
                MobStatus.Refresh();
                MobStatus.Print();
                bool pass = true;
                switch (Combat.CombatMenu($"{Mob.Name.Print(false, 2)} se retuerce violentamente!", Player.cure, Player.meditate, Player.fury))
                {
                    case "a":
                        Combat.Erase();
                        //ataque
                        Attack(false);
                        break;
                    case "c":
                        Combat.Erase();
                        //conjuro
                        if (Player.Mana[0] < 1)
                        {
                            Boxy NoMana = new Boxy(22, 0, true, "No te queda mana!");
                            pass = false;
                            Console.ReadKey();
                            NoMana.Erase();
                        }
                        else { Attack(true); }
                        break;
                    case "d":
                        Combat.Erase();
                        //discurso
                        Mob.St -= Player.Discourse();
                        Boxy MD = new Boxy(22, 0, true, "Le echas una buena bronca. Se ha reducido su agresividad.");
                        Console.ReadKey();
                        MD.Erase();
                        break;
                    case "i":
                        Combat.Erase();
                        //inventario
                        pass = Inventory.Open();
                        break;
                    case "h":
                        Combat.Erase();
                        //huida
                        if (Random.Next(1, 3) == 1)
                        {
                            MobStatus.Erase();
                            Boxy MH = new Boxy(22, 0, true, "Huiste!");
                            Console.ReadKey();
                            MH.Erase();
                            runaway = true;
                        }
                        else
                        {
                            Boxy MH = new Boxy(22, 0, true, "Corres y corres, pero el monstruo te persigue!");
                            Console.ReadKey();
                            MH.Erase();
                        }
                        break;

                }

                if (runaway)
                {
                    loot = false;
                    lastAct = "runaway";
                    break;
                }
                else if (Player.Hp[0] <= 0)
                {
                    //Boxy MH = new Boxy(22, 0, true, "Has muerto :(");
                    //Console.ReadKey();
                    //MH.Erase();
                    break;
                }
                else if (Mob.Hp[0] <= 0)
                {
                    int xp = Mob.St + Random.Next(-Mob.St / 3, Mob.St / 3);
                    Boxy MH = new Boxy(25, 0, true, $"Has asesinado a {Mob.Name.Print(false, 1)}. Ganas {xp}xp");
                    lastAct = "fight";
                    loot = true;
                    MobStatus.Erase();
                    Console.ReadKey();
                    Player.GainXp(xp);
                    MH.Erase();
                    break;
                }

                if (pass) { Take(); }


                if (Player.Hp[0] <= 0)
                {
                    //Boxy MH = new Boxy(22, 0, true, "Has muerto :(");
                    //Console.ReadKey();
                    //MH.Erase();
                    gameover = true;
                    break;
                }
            }

        }

        static void Attack(bool magic)
        {
            int dmg = 0;

            if (magic)
            {
                dmg = Player.MagicDmg(critical());
            Boxy DamageM = new Boxy(22, 0, true, $"Le lanzas una bola de fuego! Le haces {Mob.TakeDmg(dmg, magic)} de daño! WOW!");
            MobStatus.Refresh();
            MobStatus.Animation(2, 35);
            Console.ReadKey();
            DamageM.Erase();
            }
            else
            {
                dmg = Player.PhisicDmg(critical());
            Boxy DamageM = new Boxy(22, 0, true, $"Le pegas una patada voladora! Le haces {Mob.TakeDmg(dmg, magic)} de daño! WOW!");
                MobStatus.Refresh();
                MobStatus.Animation(2, 35);
                Console.ReadKey();
                DamageM.Erase();
            }


        }

        static void Take()
        {
            int dmg = Mob.Attack();
            Boxy DamageM = new Boxy(22, 0, true, $"Te pega un legüetazo ácido! Te mete {Player.TakeDamage(false, dmg)} de daño! Uos!");
            PlayerStatus.Refresh();
            PlayerStatus.AnimationLeft(2, 35);
            Console.ReadKey();
            DamageM.Erase();
        }

        static bool critical()
        {
            if (Random.Next(1, 25) <= Player.Crit) { return true; }
            else { return false; }
        }

        //true if new game, false if loaded
        static bool StartMenu(List<Game> Games)
        {
            Graphics.Title(1);
            Menu StartMenu = new Menu(12, true);
            bool exit = false;
            bool output = true;

            while (!exit)
            {
                StartMenu.Erase();
                switch (StartMenu.Read(new string[] { "Nueva partida", "Cargar Partida", "Salón de la Fama", "Salir" }, "Hola!", 18))
                {
                    case 0:
                        exit = true;
                        output = true;
                        break;
                    case 1:
                        exit = SavedGames.LoadMenu(Games);
                        output = false;
                        break;
                    case 2:
                        Boxy noMsn = new Boxy(12, 0, true, "Esta función se encuentra en desarrollo");
                        Console.ReadKey();
                        noMsn.Erase();
                        break;
                    case 3:
                        Console.Clear();
                        Boxy thanks = new Boxy(12, 0, true, "Gracias por jugar :')");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                }
            }

            Console.Clear();
            return output;
        }

        static void anotherMob()
        {
            MobWord MobWord = new MobWord();
            Mob = new Mob(Gea.corruption);
            Mob.Name = MobWord.GetName();
            Mob.Name.MobName(Construct.Gen());
            MobStatus = new MobStatus(19, 3);
        }

        static string Arrival()
        {
            Places place = new Places();
            return Construct.Rand(new string[] { "Llegas hasta", "Sobre la línea del horizonte vislumbras", "De repente, ante ti aparece", "Te encuentras en", "Te topas con", "Te das cuenta de que estás en", "Has llegado hasta", "Has llegado a un sitio inexplorado, conocido por los lugareños como", "Te detienes a descansar en", "Paras a fumar un piti en", "Te detienes a mear en", "Sin saber muy bien cómo, llegas hasta", "Te pierdes y apareces en", "Encuentras", "Descubres" }) + " " + place.GetPlace() + ".";

        }

        static string View()
        {
            return Construct.Rand(new string[] { $"Detrás de {Construct.Rand(new string[] {"un pedrusco", "un árbol", "un cerro", "unos escombros", "una roca", "un tronco", "unas ruinas"})} descubres a",
                $"Aquí {Construct.Rand(new string[] { "ves a", "te encuetras con", "descubres a", "hay"})}",
                $"{Construct.Rand(new string[] {"Allá lejos", "En la lontananza", "En la lejanía"})} {Construct.Rand(new string[] { "vislumbras a", "se columbra a", "parece que hay", "se ve a" })}"}
                );
        }

    }



}
