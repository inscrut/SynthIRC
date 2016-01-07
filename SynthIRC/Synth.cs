using System.Text;
using System.Net.Sockets;

namespace SynthIRC
{
    public class Synth
    {
        private NetworkStream stream;
        private TcpClient client;

        public void Connect(string ip, int port)
        {
            try
            {
                client = new TcpClient(ip, port);
                stream = client.GetStream();
            }
            catch { /*ERROR*/ }
        }
        
        public void Send(string msg)
        {
            if (stream != null && client != null)
            {
                byte[] data = Encoding.ASCII.GetBytes(msg);
                stream.Write(data, 0, data.Length);
            }
            else { /*ERROR*/ }
        }

        public string Read()
        {
            if (stream != null && client != null)
            {
                byte[] buff = new byte[1024];
                return Encoding.ASCII.GetString(buff, 0, stream.Read(buff, 0, buff.Length));
            }
            else return null; /*ERROR*/
        }

        public void Close()
        {
            if (stream != null) stream.Close();
            if (client != null) client.Close();
        }
    }
}
