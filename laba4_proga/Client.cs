using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace laba4_proga
{
    internal class Client
    {
        public TcpClient topClient;
        public NetworkStream stream;

        public Client(string adress, int port)
        {
            topClient = new TcpClient(adress, port);
            stream = topClient.GetStream();
        }

        public string Request(string question)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(question);

            stream.Write(bytes, 0, bytes.Length);

            byte[] bytes1 = new byte[256];

            stream.Read(bytes1, 0, bytes1.Length);

            string answer = Encoding.UTF8.GetString(bytes1);

            return answer;
        }
    }
}
