using System;
using System.Collections.Generic;
using System.Text;

namespace super_rpg_world
{
    public class Menu
    {

        int X { get; set; }
        int Y { get; set; }
        int posX { get; set; }
        int posY { get; set; }
        bool Center = false;

        public Menu(int x, int y)
        {
            this.posX = x;
            this.posY = y;
        }

        public Menu(int y, bool center)
        {
            this.posY = y;
            this.posX = 0;
            this.Center = true;
        }

        public int Read(string[] item, string title, int x)
        {
            //var originalpos = Console.CursorTop;
            int i = 0;
            ConsoleKeyInfo k;

            //Looking for the longest string in the menu
            int longest = Construct.Longest(item);


            if (longest > x) { x = longest; }
            int extraY = title.Length / x;
            if (title.Length % x != 0) { extraY++; }
            int height = item.Length + extraY;

            this.X = x;
            this.Y = height;
            this.posX = (Console.WindowWidth - this.X - 2) / 2;

            //Printing the boxy box
            Boxy Boxy = new Boxy(this.X, this.Y, this.posX, this.posY, this.Center);
            Boxy.BiPrint();
            Boxy.WriteLine(title);

            while (1 < 2)
            {
                Boxy.GoTop();
                Boxy.Jump(extraY);
                foreach (string element in item)
                {
                    Boxy.WriteLine(element);
                }

                Boxy.GoTop();
                Boxy.Jump(extraY + i);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Yellow;
                Boxy.WriteLine(item[i]);
                Console.ResetColor();

                Boxy.GoTo(this.posX + Boxy.X - 1, this.posY + extraY - 2);


                while (1 < 2)
                {
                    k = Console.ReadKey();

                    if (k.Key == ConsoleKey.UpArrow)
                    {
                        if (i == 0)
                        {
                            i = item.Length - 1;
                        }
                        else
                        {
                            i--;
                        }
                        break;
                    }
                    else if (k.Key == ConsoleKey.DownArrow)
                    {
                        if (i == item.Length - 1)
                        {
                            i = 0;
                        }
                        else
                        {
                            i++;
                        }
                        break;
                    }
                    else if (k.Key == ConsoleKey.Enter)
                    {
                        //Console.SetCursorPosition(Boxy.X - 1, Boxy.Y - 1);
                        return i;
                    }
                }
            }

            return 666;
        }

        //A menu printer wich accepts lists
        public int Read(List<string> item, string title, int x)
        {
            //var originalpos = Console.CursorTop;
            int i = 0;
            ConsoleKeyInfo k;

            //Looking for the longest string in the menu
            int longest = Construct.Longest(item);


            if (longest > x) { x = longest; }
            int extraY = title.Length / x;
            if (title.Length % x != 0) { extraY++; }
            int height = item.Count + extraY;

            this.X = x;
            this.Y = height;
            this.posX = (Console.WindowWidth - this.X - 2) / 2;

            //Printing the boxy box
            Boxy Boxy = new Boxy(this.X, this.Y, this.posX, this.posY, this.Center);
            Boxy.BiPrint();
            Boxy.WriteLine(title);

            while (1 < 2)
            {
                Boxy.GoTop();
                Boxy.Jump(extraY);
                foreach (string element in item)
                {
                    Boxy.WriteLine(element);
                }

                Boxy.GoTop();
                Boxy.Jump(extraY + i);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Yellow;
                Boxy.WriteLine(item[i]);
                Console.ResetColor();

                Boxy.GoTo(this.posX + Boxy.X - 1, this.posY + extraY - 2);


                while (1 < 2)
                {
                    k = Console.ReadKey();

                    if (k.Key == ConsoleKey.UpArrow)
                    {
                        if (i == 0)
                        {
                            i = item.Count - 1;
                        }
                        else
                        {
                            i--;
                        }
                        break;
                    }
                    else if (k.Key == ConsoleKey.DownArrow)
                    {
                        if (i == item.Count - 1)
                        {
                            i = 0;
                        }
                        else
                        {
                            i++;
                        }
                        break;
                    }
                    else if (k.Key == ConsoleKey.Enter)
                    {
                        //Console.SetCursorPosition(Boxy.X - 1, Boxy.Y - 1);
                        return i;
                    }
                }
            }

            return 666;
        }

        //Infinite list menu printer
        //public int ReadInfinite(List<string> item, string title, int x)
        //{

        //    if (item.Count <= 5)
        //    {
        //    return Read(item, title, x);
        //    }
        //    else
        //    {
        //        List<List<string>> SubLists = new List<List<string>>();
        //        int f = 0;
        //        List<string> strings = new List<string>();
        //        foreach (string elem in item)
        //        {
        //            if (strings.Count == 5)
        //            {
        //                SubLists.Add(strings);
        //                strings = new List<string>();
        //            }

        //            strings.Add(elem);

        //        }
        //        if (strings.Count > 0)
        //        {
        //            SubLists.Add(strings);
        //        }


        //        while (1 < 2)
        //        {
        //            for (int i = 0; i < SubLists.Count; i++)
        //            {
        //                List<string> el = SubLists[i];
        //                el.Add("Siguiente");

        //                switch(Read(el, title, x))
        //                {
        //                    case 1:

        //                        break;



        //                }


        //            }


        //        }



        //    }
        //}

        //This Menu is designed to be in a while
        public int ReadVarious(string[] item, string title, int x, int pos)
        {
            //var originalpos = Console.CursorTop;
            int i = pos;
            ConsoleKeyInfo k;

            //Looking for the longest string in the menu
            int longest = Construct.Longest(item);


            if (longest > x) { x = longest; }
            int extraY = title.Length / x;
            if (title.Length % x != 0) { extraY++; }
            int height = item.Length + extraY;

            this.X = x;
            this.Y = height;
            this.posX = (Console.WindowWidth - this.X - 2) / 2;

            //Printing the boxy box
            Boxy Boxy = new Boxy(this.X, this.Y, this.posX, this.posY, this.Center);
            Boxy.BiPrint();
            Boxy.WriteLine(title);

            while (1 < 2)
            {
                Boxy.GoTop();
                Boxy.Jump(extraY);
                foreach (string element in item)
                {
                    Boxy.WriteLine(element);
                }

                Boxy.GoTop();
                Boxy.Jump(extraY + i);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Yellow;
                Boxy.WriteLine(item[i]);
                Console.ResetColor();

                Boxy.GoTo(this.posX + Boxy.X - 1, this.posY + extraY - 2);


                while (1 < 2)
                {
                    k = Console.ReadKey();

                    if (k.Key == ConsoleKey.UpArrow)
                    {
                        if (i == 0)
                        {
                            i = item.Length - 1;
                        }
                        else
                        {
                            i--;
                        }
                        break;
                    }
                    else if (k.Key == ConsoleKey.DownArrow)
                    {
                        if (i == item.Length - 1)
                        {
                            i = 0;
                        }
                        else
                        {
                            i++;
                        }
                        break;
                    }
                    else if (k.Key == ConsoleKey.Enter)
                    {
                        //Console.SetCursorPosition(Boxy.X - 1, Boxy.Y - 1);
                        return i;
                    }
                }
            }

            return 666;
        }

        //Combat menu returns the first letter of the selected option
        public string CombatMenu(string title, bool cure, bool meditate, bool fury)
        {
            //var originalpos = Console.CursorTop;
            int i = 0;
            ConsoleKeyInfo k;

            //Options
            List<string> item = new List<string>();
            item.Add("Ataque");
            item.Add("Conjuro");
            item.Add("Discurso épico");
            if (cure) { item.Add("Sanaciión"); }
            if (meditate) { item.Add("Meditar"); }
            if (fury) { item.Add("Enfurecer"); }
            item.Add("Inventario");
            item.Add("Huir");

            //Looking for the longest string in the menu
            int longest = Construct.Longest(item);

            X = 17;

            if (longest > X) { X = longest; }

            Boxy counter = new Boxy(X, Y, 1, 1, Center);

            int extraY = counter.CountLines(title);
            Y = item.Count + extraY;

            this.posX = (Console.WindowWidth - this.X - 2) / 2;

            //Printing the boxy box
            Boxy Boxy = new Boxy(X, Y, posX, posY, Center);
            Boxy.BiPrint();
            Boxy.WriteLine(title);

            while (1 < 2)
            {
                Boxy.GoTop();
                Boxy.Jump(extraY);
                foreach (string element in item)
                {
                    Boxy.WriteLine(element);
                }

                Boxy.GoTop();
                Boxy.Jump(extraY + i);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Yellow;
                Boxy.WriteLine(item[i]);
                Console.ResetColor();

                Boxy.GoTo(this.posX + Boxy.X - 1, this.posY + extraY - 2);


                while (1 < 2)
                {
                    k = Console.ReadKey();

                    if (k.Key == ConsoleKey.UpArrow)
                    {
                        if (i == 0)
                        {
                            i = item.Count - 1;
                        }
                        else
                        {
                            i--;
                        }
                        break;
                    }
                    else if (k.Key == ConsoleKey.DownArrow)
                    {
                        if (i == item.Count - 1)
                        {
                            i = 0;
                        }
                        else
                        {
                            i++;
                        }
                        break;
                    }
                    else if (k.Key == ConsoleKey.Enter)
                    {
                        return item[i].Substring(0, 1).ToLower();
                    }
                }
            }     
        }

        //Inventory Menu, similarly to combat Menu, returns a letter
        public string InvMenu(List<string> item, string title, int x)
        {
            //var originalpos = Console.CursorTop;
            int i = 0;
            ConsoleKeyInfo k;

            //Looking for the longest string in the menu
            int longest = Construct.Longest(item);


            if (longest > x) { x = longest; }
            int extraY = title.Length / x;
            if (title.Length % x != 0) { extraY++; }
            int height = item.Count + extraY;

            this.X = x;
            this.Y = height;
            this.posX = (Console.WindowWidth - this.X - 2) / 2;

            //Printing the boxy box
            Boxy Boxy = new Boxy(this.X, this.Y, this.posX, this.posY, this.Center);
            Boxy.BiPrint();
            Boxy.WriteLine(title);

            while (1 < 2)
            {
                Boxy.GoTop();
                Boxy.Jump(extraY);
                foreach (string element in item)
                {
                    Boxy.WriteLine(element);
                }

                Boxy.GoTop();
                Boxy.Jump(extraY + i);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Yellow;
                Boxy.WriteLine(item[i]);
                Console.ResetColor();

                Boxy.GoTo(this.posX + Boxy.X - 1, this.posY + extraY - 2);


                while (1 < 2)
                {
                    k = Console.ReadKey();

                    if (k.Key == ConsoleKey.UpArrow)
                    {
                        if (i == 0)
                        {
                            i = item.Count - 1;
                        }
                        else
                        {
                            i--;
                        }
                        break;
                    }
                    else if (k.Key == ConsoleKey.DownArrow)
                    {
                        if (i == item.Count - 1)
                        {
                            i = 0;
                        }
                        else
                        {
                            i++;
                        }
                        break;
                    }
                    else if (k.Key == ConsoleKey.Enter)
                    {
                        return item[i].Substring(0, 1).ToLower();
                    }
                }
            }

            return "p";
        }


        public void Erase()
        {
            int position = this.posY;
                Console.SetCursorPosition(this.posX, position);
                for (int y = 0; y < this.Y + 2; y++)
                {
                    Console.Write(new String(' ', this.X + 2));
                position++;
                    Console.SetCursorPosition(this.posX, position);
            }
            
        }
    }
}
