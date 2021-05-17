using System;
using System.Collections.Generic;
using System.Text;

namespace super_rpg_world
{
   
    static public class Firecamp
    {


        public static void FireMenu()
        {
            Random ran = new Random();

            List<string> Options = new List<string>();

            Options.Add("Dormir");
            Options.Add("Meditar");
            Options.Add("Hacer Sudokus");
            Options.Add("Comer un marshmallow");

            Menu Menu = new Menu(3, true);
            Boxy message;
            switch (Menu.Read(Options, $"Enciendes una hoguera y montas el campamento. ¿Qué vas a hacer esta noche?", 20))
            {
                case 0:
                    Menu.Erase();
                    message = new Boxy(22,  0, true, "A mimir!");
                    Program.Player.Hp[0] = Program.Player.Hp[1];
                    Console.ReadKey();
                    message.Erase();
                    break;
                case 1:
                    Menu.Erase();
                    message = new Boxy(22,  0, true, $"Meditas durante toda la noche."); ;
                    Program.Player.Heal(ran.Next(Program.Player.Hp[1] / 4, Program.Player.Hp[1] / 2));
                    Program.Player.Restore(ran.Next(Program.Player.Hp[1] / 5, Program.Player.Hp[1] / 3));
                    Console.ReadKey();
                    message.Erase();
                    break;
                case 2:
                    Menu.Erase();
                    message = new Boxy(22,  0, true, $"Te pasas la noche haciendo sudokus.");
                    Program.Player.Restore(ran.Next(Program.Player.Hp[1] / 4, Program.Player.Hp[1] / 2));
                    Console.ReadKey();
                    message.Erase();
                    break;
                case 3:
                    Menu.Erase();
                    //burn
                    if (ran.Next(0, 2) == 0)
                    {
                        message = new Boxy(22,  0, true, $"El marshmallow se te ha quemado :_(");
                        Console.ReadKey();
                        message.Erase();
                        break;
                    }
                    else
                    {
                        message = new Boxy(22,  0, true, $"El marshmallow estaba buenísimo.");
                        switch (ran.Next(0, 2))
                        {
                            case 0:
                                Program.Player.Heal(ran.Next(1, 5));
                                break;
                            case 1:
                                Program.Player.Restore(ran.Next(1, 2));
                                break;
                            case 2:
                                Program.Player.GainXp(ran.Next(1, 2));
                                break;
                        }
                        Console.ReadKey();
                        message.Erase();
                        break;
                    }
            }
            Program.PlayerStatus.Refresh();
        }

    }
}
