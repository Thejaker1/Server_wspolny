using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mainframe
{
    class Program
    {
        static void Main(string[] args)
        {
            //thdtgd
        }
    }

    public class UDPListener
    {
        private const int port = 10000;//port komunikacyjny
        public static string od_adres;
        public static int od_port;
        public static void StartListner()
        {
            UdpClient lisnter = new UdpClient(port);
            IPEndPoint grupeEP = new IPEndPoint(IPAddress.Any, port);

            //bufor
            byte[] bytes = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            //nasłuch
            try
            {
                while (bytes[0] == 0)
                {
                    bytes = lisnter.Receive(ref grupeEP); // odebrane dane
                    od_adres = grupeEP.Address.ToString(); //pobierane ip
                    od_port = grupeEP.Port; //pobieranie portu
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                lisnter.Close();
            }
            //zapis do pliku buforującego
            string a = System.Text.Encoding.UTF8.GetString(bytes);
            Console.WriteLine(a);
        }
    }
}
