using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;

namespace XmlSerialization
{




    public class Ip
    {

        public void GetClientIP()
        {


            Console.WriteLine("Local IP Address: " + GetIPAddress(Dns.GetHostName()));
            Console.WriteLine("Google IP:" + GetIPAddress("google.com"));
            Console.ReadLine();

            var ServerIP = Dns.GetHostName();

            string hostname = Dns.GetHostName();// this will get your local computers hostname.
            IPHostEntry ipEntry = Dns.GetHostEntry(hostname);
            IPAddress[] addr = ipEntry.AddressList;
            foreach (var item in addr)
            {
                Console.WriteLine(item.ToString());
            }


            string ConvertedDecimalNumber = 10000.0.ToString("C2", new CultureInfo("es-CO"));
            IPAddress[] addresses = Dns.GetHostAddresses(Dns.GetHostName()).Where(a => a.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).ToArray();

            IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());


            IPHostEntry host;

            host = Dns.GetHostEntry(hostname);

            Console.WriteLine("GetHostEntry({0}) returns:", hostname);

            foreach (IPAddress ip in host.AddressList)
            {
                Console.WriteLine("    {0}", ip);
            }


        }

        public static IPAddress GetIPAddress(string hostName)
        {
            Ping ping = new Ping();
            var replay = ping.Send(hostName);

            if (replay.Status == IPStatus.Success)
            {
                return replay.Address;
            }
            return null;
        }
    }

}