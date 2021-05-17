using System;
using System.Collections.Generic;
using System.Text;

namespace super_rpg_world
{
    class PlayerStatus : Box
    {

        public PlayerStatus(int cx, int cy) : base( 12, 12)
        {
            Content = new string[] { $" {Program.Player.Name}", $"{Program.Player.Class} {Program.Player.Race} de nivel {Program.Player.Lvl}", $" edad {Program.Player.Age}", $" hp {Program.Player.Hp[0]}/{Program.Player.Hp[1]}", $" mana {Program.Player.Mana[0]}/{Program.Player.Mana[1]}", $" siguiente nivel {Program.Player.Xp[0]}/{Program.Player.Xp[1]}", $"GEA: {Program.Gea.corruption}" };
            y = Content.Length;
            int longest = Construct.Longest(Content);
            x = longest + 2;
            CursorX = cx;
            CursorY = cy;
        }

        public void Refresh()
        {
            this.Erase();
            Content = new string[] { $" {Program.Player.Name}", $"{Program.Player.Class} {Program.Player.Race} de nivel {Program.Player.Lvl}", $" edad {Program.Player.Age}", $" hp {Program.Player.Hp[0]}/{Program.Player.Hp[1]}", $" mana {Program.Player.Mana[0]}/{Program.Player.Mana[1]}", $" siguiente nivel {Program.Player.Xp[0]}/{Program.Player.Xp[1]}" };
            x = Construct.Longest(Content) + 2;
            this.Print();
        }
    }
}
