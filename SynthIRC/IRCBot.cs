namespace SynthIRC
{
    public class IRCBot : Synth
    {
        public void Auth(string ip, int port, string nick)
        {
            Connect(ip, port);
            Send("CAP LS\r\n");
            Send("NICK " + nick + "\r\n");
            Send("USER " + nick.ToLower() + " 0 * :Synth\r\n");

            for(int i=0; i<2; i++) Read(); //Server is answer
        }
        public void Join(string chan)
        {
            Send("JOIN " + chan + "\r\n");
        }
        public void Message(string who, string msg)
        {
            Send("PRIVMSG " + who + " :" + msg + "\r\n");
        }
        public string[] Reading()
        {
            return Read().Split(' ');
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
