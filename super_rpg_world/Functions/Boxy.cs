using System;
using System.Collections.Generic;
using System.Text;

namespace super_rpg_world
{
    public class Boxy
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int CursorX { get; set; }
        public int CursorY { get; set; }
        public int CursorPosX { get; set; }
        public int CursorPosY { get; set; }

        public Boxy(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.CursorX = Console.CursorLeft;
            this.CursorY = Console.CursorTop;
        }

        public Boxy(int x, int y, int c, int i)
        {
            this.X = x;
            this.Y = y;
            this.CursorX = c;
            this.CursorY = i;
        }

        public Boxy(int x, int y, int i, bool center)
        {
            this.X = x;
            this.Y = y;
            this.CursorY = i;
            this.CursorX = (Console.WindowWidth - x - 2) / 2;
        }

        public Boxy(int x, int y, int c, int i, bool center)
        {
            this.X = x;
            this.Y = y;
            this.CursorY = i;
            if (center) { this.CursorX = (Console.WindowWidth - x - 2) / 2; }
            else { this.CursorX = c; }
        }

        public Boxy(string txt, int y, int c, int i, bool center)
        {
            this.X = txt.Length;
            this.Y = y;
            this.CursorY = i;
            if (center) { this.CursorX = (Console.WindowWidth - this.X - 2) / 2; }
            else { this.CursorX = c; }
            if (txt.Length > this.X)
            {
                this.Y = txt.Length / this.X;
                if (txt.Length % this.X != 0) { this.Y++; }
            }
            this.BiPrint();
            this.WriteLine(txt);
        }
        public Boxy(int x, int c, int i, bool center, string txt)
        {
            this.X = x;
            this.CursorY = i;
            if (center) { this.CursorX = (Console.WindowWidth - this.X - 2) / 2; }
            else { this.CursorX = c; }
            this.Y = CountLines(txt);
            this.BiPrint();
            this.WriteLine(txt);
        }
        
        public Boxy(int x, int c, bool center, string txt)
        {
            this.X = x;
            this.CursorY = 3;
            if (center) { this.CursorX = (Console.WindowWidth - this.X - 2) / 2; }
            else { this.CursorX = c; }
            this.Y = CountLines(txt);
            this.BiPrint();
            this.WriteLine(txt);
        }

        public Boxy(int x, string[] elements)
        {
            this.Y = elements.Length;
            int longest = Construct.Longest(elements);
            this.X = longest + 2;
            this.CursorX = x;
            this.CursorY = 3;
            this.Print();
            foreach (string element in elements)
            {
                this.WriteLine(element);
            }
        }

        public void Print()
        {
            int posX = this.CursorX;
            int posY = this.CursorY;
            Console.SetCursorPosition(posX, posY);
            for (int i = 0; i < this.Y + 2; i++)
            {
                if (i == 0)
                {
                    Console.Write("┌");
                    for (int c = 0; c < this.X; c++)
                    {
                        Console.Write("─");
                    }
                    Console.Write("┐");
                }
                else if (i == this.Y + 1)
                {
                    Console.Write("└");
                    for (int c = 0; c < this.X; c++)
                    {
                        Console.Write("─");
                    }
                    Console.Write("┘");
                }
                else
                {
                    for (int c = 0; c < this.X + 2; c++)
                    {
                        if (c == 0 || c == this.X + 1) { Console.Write("│"); }
                        else { Console.Write(" "); }
                    }
                }
                posY++;
                Console.SetCursorPosition(posX, posY);

            }
            this.CursorX++;
            this.CursorY++;
            this.CursorPosX = this.CursorX;
            this.CursorPosY = this.CursorY;
            Locate();

        }

        public void BiPrint()
        {
            var posY = this.CursorY;
            var posX = this.CursorX;

            Console.SetCursorPosition(posX, posY);

            for (int i = 0; i < this.Y + 2; i++)
            {
                if (i == 0)
                {
                    Console.Write("╔");
                    for (int c = 0; c < this.X; c++)
                    {
                        Console.Write("═");
                    }
                    Console.Write("╗");
                }
                else if (i == this.Y + 1)
                {
                    Console.Write("╚");
                    for (int c = 0; c < this.X; c++)
                    {
                        Console.Write("═");
                    }
                    Console.Write("╝");
                }
                else
                {
                    for (int c = 0; c < this.X + 2; c++)
                    {
                        if (c == 0 || c == this.X + 1) { Console.Write("║"); }
                        else { Console.Write(" "); }
                    }
                }
                posY++;
                Console.SetCursorPosition(posX, posY);

            }
            this.CursorX++;
            this.CursorY++;
            this.CursorPosX = this.CursorX;
            this.CursorPosY = this.CursorY;
            Locate();
        }

        public void GoTop()
        {
            this.CursorPosX = this.CursorX;
            this.CursorPosY = this.CursorY;
            Locate();

        }
        public void GoTopTop()
        {
            this.CursorPosX = this.CursorX - 1;
            this.CursorPosY = this.CursorY - 1;
            Locate();

        }
        public void GoTo(int y)
        {
            this.CursorPosX = this.CursorX;
            this.CursorPosY = this.CursorY + y - 1;
            Locate();
        }
        public void GoTo(int x, int y)
        {
            this.CursorPosX = this.CursorX + x;
            this.CursorPosY = this.CursorY + y - 1;
            Locate();

        }

        public void Locate()
        {
            Console.SetCursorPosition(this.CursorPosX, this.CursorPosY);
        }

        public void Jump()
        {
            this.CursorPosX = this.CursorX;
            this.CursorPosY++;
            Locate();
        }

        public void Jump(int i)
        {
            this.CursorPosX = this.CursorX;
            this.CursorPosY += i;
            Locate();
        }

        public void WriteLine(string wat)
        {
            List<string> Lines = Align(wat);
            foreach (string element in Lines)
            {
                Console.Write(element);
                Jump();
            }
        }

        public int CountLines(string wat)
        {
            List<string> Lines = Align(wat);
            return Lines.Count;
        }

        //Obsolete
        //public void WriteLine(string wat)
        //{
        //    List<string> txt = new List<string>();
        //    int i = 0;
        //    if (wat.Length <= this.X)
        //    {
        //        Console.Write(wat);
        //        Jump();
        //    }
        //    else
        //    {
        //        while (wat.Substring(i).Length >= this.X)
        //        {
        //            txt.Add(wat.Substring(i, this.X - 1));
        //            i += this.X - 1;
        //        }
        //        if (wat.Substring(i).Length > 0) { txt.Add(wat.Substring(i)); }
        //        foreach (string element in txt)
        //        {
        //            Console.Write(element);
        //            Jump();
        //        }
        //    }
        //}

        public string ReadLine()
        {
            Locate();
            ConsoleKeyInfo read;
            string output = "";
            while (1 < 2)
            {
                read = Console.ReadKey();
                if (read.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (output.Length < 20 && Char.IsLetter(Convert.ToChar(read.Key))) { output += Convert.ToString(read.Key); }
                else if (output.Length < 20 && read.Key == ConsoleKey.Spacebar)
                {
                    output += Convert.ToChar(read.Key);
                }
                else if (output.Length > 0 && read.Key == ConsoleKey.Backspace)
                {
                    //Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    Console.Write(" ");
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    output = output.Substring(0, output.Length - 1);

                }
                else
                {
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    Console.Write(" ");
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                }
            }


            Jump();
            return output;
        }

    public void Clear()
    {
        GoTop();
        for (int y = 0; y < this.Y; y++)
        {
            Console.Write(new String(' ', this.X));
            this.CursorPosY++;
            Locate();
        }
        GoTop();
    }

        public void Erase()
        {
            GoTopTop();
            for (int y = 0; y < this.Y + 2; y++)
            {
                Console.Write(new String(' ', this.X + 2));
                this.CursorPosY++;
                Locate();
            }
            GoTop();
        }

        public void Erase(int c, int i)
        {
            GoTopTop();
            for (int y = 0; y < i + 2; y++)
            {
                Console.Write(new String(' ', c + 2));
                this.CursorPosY++;
                Locate();
            }
            GoTop();
        }

        public List<string> Align(string txt)
    {
        List<string> Lines = new List<string>();

        if (txt.Length <= this.X)
        {
            Lines.Add(txt);
        }
        else
        {
            List<string> words = Separate(txt);

            string Line = "";
            for (int i = 0; i < words.Count; i++)
            {
                Line += words[i];
                if (i < words.Count - 1)
                {

                    if (Line.Length + words[i + 1].Length + 1 <= this.X)
                    {
                        Line += " ";
                    }
                    else
                    {
                        Lines.Add(Line);
                        Line = "";
                    }

                }
                else
                {
                    Lines.Add(Line);
                }

            }



        }
        return Lines;

    }

    public List<string> Separate(string txt)
    {
        List<string> Words = new List<string>();
        string wordN = "";
        for (int i = 0; i < txt.Length; i++)
        {
            if (Convert.ToString(txt[i]) != " ")
            {
                wordN += txt[i];
            }
            else
            {
                Words.Add(wordN);
                wordN = "";
            }
        }
        if (wordN.Length > 0)
        {
            Words.Add(wordN);
            wordN = "";
        }

        return Words;
    }
}
}
