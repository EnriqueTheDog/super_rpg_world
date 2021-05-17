using System;
using System.Collections.Generic;
using System.Text;

namespace super_rpg_world
{
    static public class Graphics
    {

        public static void Title(int y)
        {
            List<string> lines = new List<string>();

            lines.Add(new string("   ▄████████ ███    █▄     ▄███████▄    ▄████████    ▄████████     ▄████████    ▄███████▄    ▄██████▄    ▄█     █▄   ▄██████▄     ▄████████  ▄█       ████████▄"));
            lines.Add(new string("   ███    ███ ███    ███   ███    ███   ███    ███   ███    ███    ███    ███   ███    ███   ███    ███  ███     ███ ███    ███   ███    ███ ███       ███   ▀███"));
            lines.Add(new string("  ███    █▀  ███    ███   ███    ███   ███    █▀    ███    ███    ███    ███   ███    ███   ███    █▀   ███     ███ ███    ███   ███    ███ ███       ███    ███ "));
            lines.Add(new string("  ███        ███    ███   ███    ███  ▄███▄▄▄      ▄███▄▄▄▄██▀   ▄███▄▄▄▄██▀   ███    ███  ▄███         ███     ███ ███    ███  ▄███▄▄▄▄██▀ ███       ███    ███"));
            lines.Add(new string("▀███████████ ███    ███ ▀█████████▀  ▀▀███▀▀▀     ▀▀███▀▀▀▀▀    ▀▀███▀▀▀▀▀   ▀█████████▀  ▀▀███ ████▄   ███     ███ ███    ███ ▀▀███▀▀▀▀▀   ███       ███    ███"));
            lines.Add(new string("         ███ ███    ███   ███          ███    █▄  ▀███████████  ▀███████████   ███          ███    ███  ███     ███ ███    ███ ▀███████████ ███       ███    ███"));
            lines.Add(new string("   ▄█    ███ ███    ███   ███          ███    ███   ███    ███    ███    ███   ███          ███    ███  ███ ▄█▄ ███ ███    ███   ███    ███ ███▌    ▄ ███   ▄███"));
            lines.Add(new string(" ▄████████▀  ████████▀   ▄████▀        ██████████   ███    ███    ███    ███  ▄████▀        ████████▀    ▀███▀███▀   ▀██████▀    ███    ███ █████▄▄██ ████████▀"));
            lines.Add(new string("                                                   ███    ███    ███    ███                                                     ███    ███ ▀                    "));

            int x = Construct.Longest(lines);

            foreach (string line in lines)
            {
                Console.SetCursorPosition((Console.BufferWidth - x) / 2, y);             
                Console.WriteLine(line);
                y++;
            }
        }

        public static void Death(int y)
        {
            

            List<string> lines = new List<string>();

            lines.Add(new string(" ██░ ██  ▄▄▄        ██████     ███▄ ▄███▓ █    ██ ▓█████  ██▀███  ▄▄▄█████▓ ▒█████"));
            lines.Add(new string("░██░ ██▒▒████▄    ▒██    ▒    ▓██▒▀█▀ ██▒ ██  ▓██▒▓█   ▀ ▓██ ▒ ██▒▓  ██▒ ▓▒▒██▒  ██▒"));
            lines.Add(new string("▒██▀▀██░▒██  ▀█▄  ░ ▓██▄      ▓██    ▓██░▓██  ▒██░▒███   ▓██ ░▄█ ▒▒ ▓██░ ▒░▒██░  ██▒"));
            lines.Add(new string("░▓█ ░██ ░██▄▄▄▄██   ▒   ██▒   ▒██    ▒██ ▓▓█  ░██░▒▓█  ▄ ▒██▀▀█▄  ░ ▓██▓ ░ ▒██   ██░"));
            lines.Add(new string("░▓█▒░██▓ ▓█   ▓██▒▒██████▒▒   ▒██▒   ░██▒▒▒█████▓ ░▒████▒░██▓ ▒██▒  ▒██▒ ░ ░ ████▓▒░"));
            lines.Add(new string(" ▒ ░░▒░▒ ▒▒   ▓▒█░▒ ▒▓▒ ▒ ░   ░ ▒░   ░  ░░▒▓▒ ▒ ▒ ░░ ▒░ ░░ ▒▓ ░▒▓░  ▒ ░░   ░ ▒░▒░▒░ "));
            lines.Add(new string(" ▒ ░▒░ ░  ▒   ▒▒ ░░ ░▒  ░ ░   ░  ░      ░░░▒░ ░ ░  ░ ░  ░  ░▒ ░ ▒░    ░      ░ ▒ ▒░ "));
            lines.Add(new string(" ░  ░░ ░  ░   ▒   ░  ░  ░     ░      ░    ░░░ ░ ░    ░     ░░   ░   ░      ░ ░ ░ ▒  "));
            lines.Add(new string(" ░  ░  ░      ░  ░      ░            ░      ░        ░  ░   ░                  ░ ░  "));

            int x = Construct.Longest(lines);

            foreach (string line in lines)
            {
                Console.SetCursorPosition((Console.BufferWidth - x) / 2, y);
                Console.WriteLine(line);
                y++;
            }

        }
    }
}
