using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthIRC
{
    class Program
    {
        static void Main(string[] args)
        {
            IRCBot bot = new IRCBot();

            Console.Write("Type IP address: "); string ip = Console.ReadLine();
            Console.Write("Type port: "); int port = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Type nick: "); string nick = Console.ReadLine();
            Console.Write("Type password: "); string pass = Console.ReadLine();
            Console.Write("Type e-mail: "); string em = Console.ReadLine();

            Console.Write("Authorization . . . ");
            bot.Auth(ip, port, pass, nick, em);
            Console.WriteLine("Done.");

            Console.Write("Type channel: "); string ch = Console.ReadLine();

            Console.Write("Join to the channel . . . ");
            bot.Join(ch);
            Console.WriteLine("Done.");

            while (true)
            {
                Console.Write("Type message: "); string msg = Console.ReadLine();
                if (msg == "QUIT") break; //For exit programm type QUIT
                Console.Write("Sending message . . . ");
                bot.Message(ch, msg);
                Console.WriteLine("Done.");
            }

            Console.Write("Press any key to exit . . .");
            Console.Read();
            bot.Quit();
        }
    }
}
