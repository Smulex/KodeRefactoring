using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Security;
using System.Text;
using System.Threading.Tasks;


namespace KodeRefactoring
{
    class Program
    {
        static void Main()
        {
            DHCP dhcp = new DHCP();
            DNS dns = new DNS();
            Networking networking = new Networking();


            while (true)
            {
                Console.WriteLine("Choose an option:\n");

                Console.WriteLine("\t1 - Get Hostname by IP");
                Console.WriteLine("\t2 - Get IP by Hostname");
                Console.WriteLine("\t3 - Get DHCP Server Addresses");
                Console.WriteLine("\t4 - Local ping");
                Console.WriteLine("\t5 - Traceroute\n");

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        Console.Write("Enter IP Address: ");
                        Console.WriteLine("\nAnswer: " + dns.GetHostnameFromIp(Console.ReadLine()));
                        break;
                    case ConsoleKey.D2:
                        Console.Write("Enter Hostname: ");
                        Console.WriteLine("\nAnswer: " + dns.GetIpFromHostname(Console.ReadLine()));
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine("DHCP Servers");
                        foreach (var item in dhcp.GetDhcpServerAddresses())
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine(networking.LocalPing());
                        break;
                    case ConsoleKey.D5:
                        Console.Write("Enter Hostname or IP Address: ");
                        Console.WriteLine("\n" + networking.Traceroute(Console.ReadLine()));
                        break;
                    default:
                        break;
                }
                Console.WriteLine("\nPress any key to resume..");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
