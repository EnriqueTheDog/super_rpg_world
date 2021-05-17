using System;
using System.Collections.Generic;
using System.Text;

namespace super_rpg_world
{
    class Travel
    {
        Random Random = new Random();


        //TRue if game keeps going, false if returning to main menu
        public bool Direction(string txt)
        {
            Menu DirectionMenu = new Menu(3, true);

            switch (DirectionMenu.Read(new string[] { "Norte", "Sur", "Este", "Oeste", "(Guardar y salir)" }, $"{txt}¿Hacia dónde quieres ir?", 20))
            {
                case 0:
                    DirectionMenu.Erase();
                    Boxy Northy = new Boxy("Te diriges hacia el Norte...", 1, 0, 5, true);
                    Console.ReadKey();
                    Northy.Erase();
                    return true;
                    break;
                case 1:
                    DirectionMenu.Erase();
                    Boxy Southy = new Boxy("Te diriges hacia el Sur...", 1, 0, 5, true);
                    Console.ReadKey();
                    Southy.Erase();
                    return true;
                    break;
                case 2:
                    DirectionMenu.Erase();
                    Boxy Easty = new Boxy("Te diriges hacia el Este...", 1, 0, 5, true);
                    Console.ReadKey();
                    Easty.Erase();
                    return true;
                    break;
                case 3:
                    DirectionMenu.Erase();
                    Boxy Westy = new Boxy("Te diriges hacia el Oeste...", 1, 0, 5, true);
                    Console.ReadKey();
                    Westy.Erase();
                    return true;
                    break;
                case 4:
                    //Save and Go
                    if (!Program.Player.existent)
                    {
                        SavedGames.SaveNew();
                        Boxy Save = new Boxy("Se ha guardado una nueva partida", 1, 0, 5, true);
                        Console.ReadKey();
                        Console.Clear();
                        return false;
                    }
                    else
                    {
                        SavedGames.Rewrite();
                        Boxy Rewrite = new Boxy("Se han sobreescrito los datos guardados", 1, 0, 5, true);
                        Console.ReadKey();
                        Console.Clear();
                        return false;
                    }
                    break;
            }

            return false;

        }
    }
}
