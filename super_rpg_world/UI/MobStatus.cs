using System;
using System.Collections.Generic;
using System.Text;

namespace super_rpg_world
{
    class MobStatus : Box
    {
        public MobStatus(int cx, int cy) : base(12, 12)
        {
            Content = new string[] { $" {Program.Mob.Name.Print(false, 0)}", " ", $" hp {Program.Mob.Hp[0]}/{Program.Mob.Hp[1]}"};
            y = Content.Length;
            int longest = Construct.Longest(Content);
            x = longest + 2;
            CursorX = Console.BufferWidth - Construct.Longest(Content) - cx - 2;
            CursorY = cy;
        }

        public void Refresh()
        {
            Content = new string[] { $" {Program.Mob.Name.Print(false, 0)}", " ", $" hp {Program.Mob.Hp[0]}/{Program.Mob.Hp[1]}" };
            x = Construct.Longest(Content) + 2;
        }
    }
}
