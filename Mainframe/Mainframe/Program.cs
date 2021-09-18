using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Mainframe
{
    class Program
    {
        static void Main(string[] args)
        {
            //Wiadomość początkowa
            Console.WriteLine("copyright: J.Pufund,D.Trzciński");
            Console.WriteLine("Server versja:"+Define.versja);

            //Skaner UDP
            string input=UDPListener.StartListner();

            //wypisanie odebranych danych
            Console.WriteLine(input);
        }
    }

    public class UDPListener    //Funkcja skanera UDP
    {
        
        public static string od_adres;  //Adrres nadawcy

        public static string StartListner()
        {
            UdpClient lisnter = new UdpClient(Define.port);
            IPEndPoint grupeEP = new IPEndPoint(IPAddress.Any, Define.port);

            //bufor
            byte[] bytes = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            //nasłuch
            try
            {
                while (bytes[0] == 0)   //do momętu odebrania 
                {
                    bytes = lisnter.Receive(ref grupeEP); // odebrane dane
                    od_adres = grupeEP.Address.ToString(); //pobierane ip
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
            //Console.WriteLine(a);
            return a;
        }
    }
    public class Define //Stałe programowe
    {
        public const string versja="0.0";
        public const int port = 10000;//port komunikacyjny
    }
}
