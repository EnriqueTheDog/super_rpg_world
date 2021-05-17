using System;
using System.Collections.Generic;
using System.Text;

namespace super_rpg_world
{
    class Box
    {
        public int x { get; set; }
        public int y { get; set; }
        public int CursorX { get; set; }
        public int CursorY { get; set; }
        public string[] Content { get; set; }

        public Box(int CursorX, int CursorY)
        {
            this.CursorX = CursorX;
            this.CursorY = CursorY;
        }

        public void Erase()
        {
            int position = this.CursorY;
            Console.SetCursorPosition(this.CursorX, position);
            for (int y = 0; y < this.y + 2; y++)
            {
                Console.Write(new String(' ', x + 2));
                position++;
                Console.SetCursorPosition(this.CursorX, position);
            }
        }

        public void Print()
        {
            Boxy States = new Boxy(CursorX, Content);
        }

        public void Move(int movX, int movY)
        {
            this.Erase();
            this.CursorX += movX;
            this.CursorY += movY;
            Boxy States = new Boxy(CursorX, Content);
        }

        public void MoveLeft(int movX, int movY)
        {
            this.Erase();
            CursorX -= movX;
            CursorY -= movY;
            Boxy States = new Boxy(CursorX, Content);
        }

        public void Animation(int mx, int speed)
        {
            for (int i = 1; i <= mx; i++)
            {
                this.Move(i, 0);
                System.Threading.Thread.Sleep(speed);
            }
            for (int i = 1; i <= mx; i++)
            {
                this.Move(-i, 0);
                System.Threading.Thread.Sleep(speed);
            }
            this.Print();
        }

        public void AnimationLeft(int mx, int speed)
        {
            for (int i = 1; i <= mx; i++)
            {
                this.MoveLeft(i, 0);
                System.Threading.Thread.Sleep(speed);
            }
            for (int i = 1; i <= mx; i++)
            {
                this.MoveLeft(-i, 0);
                System.Threading.Thread.Sleep(speed);
            }
        }

    }
}
