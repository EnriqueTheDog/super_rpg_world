using System;
using System.Collections.Generic;
using System.Text;

namespace super_rpg_world
{
    public class Inventory
    {
        public Potion Potion = new Potion(3);
        public int Id;

        //Returns false if no item has been used
        public bool Open()
        {
            List<string> Objects = new List<string>();

            if (this.Potion.quantity > 0)
            {
                Objects.Add($"{Potion.PotName} ({Potion.quantity})");
            }

            if (Objects.Count <= 0)
            {
                Boxy Noth = new Boxy(17, 0, true, "El inventario está vacío.");
                Console.ReadKey();
                Noth.Erase();
                return false;
            }
            else
            {
                Objects.Add("Salir");
                Menu InvMenu = new Menu(3, true);
                switch(InvMenu.InvMenu(Objects, $"¿Qué objeto quieres usar?", 20))
                {
                    case "p":
                        InvMenu.Erase();
                        int heal = Potion.Drink();
                        Program.PlayerStatus.Refresh();
                        Program.PlayerStatus.Print();
                        Boxy Poti = new Boxy(17, 0, true, $"Bebes una poti y te curas {heal} hp");
                        Console.ReadKey();
                        Poti.Erase();
                        return true;
                        break;
                    case "s":
                        InvMenu.Erase();
                        return false;
                        break;
                }
            }

            return false;
        }

    }
}
