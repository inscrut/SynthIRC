using System;

namespace SynthIRC
{
    class Program
    {
        static void Main(string[] args)
        {
            IRCBot bot = new IRCBot();
            
            Console.Write("Type IP/DNS address: "); string ip = Console.ReadLine();
            Console.Write("Type port: "); int port = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Type nick: "); string nick = Console.ReadLine();

            Console.Write("Authorization . . . ");
            bot.Auth(ip, port, nick);
            Console.WriteLine("Done.");

            Console.Write("Type channel: "); string ch = Console.ReadLine();
            bot.Join(ch);

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
