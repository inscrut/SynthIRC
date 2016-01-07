using System;

namespace SynthIRC
{
    public class IRCBot : Synth
    {
        public void Auth(string ip, int port, string pass, string nick, string email)
        {
            Connect(ip, port);
            Send("PASS " + pass + "\r\n");
            Send("NICK " + nick + "\r\n");
            Send("USER " + nick + " " + email + " " + "127.0.0.1" + " " + ":Synth" + "\r\n");

            for(int i=0; i<2; i++) Read();
        }
        public void Join(string chan)
        {
            Send("JOIN " + chan + "\r\n");
        }
        public void Message(string who, string msg)
        {
            Send("PRIVMSG " + who + " :" + msg + "\r\n");
        }
        public void Reading()
        {
            //
        }
        public void Quit()
        {
            Send("QUIT" + "\r\n");
            Close();
        }
        public void Command(string cmd)
        {
            Send(cmd + "\r\n");
        }
    }
}
