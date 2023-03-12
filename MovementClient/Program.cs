using System;
using System.Net.Sockets;
using System.Runtime.CompilerServices;

namespace MovementClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter IP address in correct format: ");
            string IP = Console.ReadLine();
            if (IP.Split('.').Length != 4)
            {
                Environment.Exit(0);
            }
            Console.WriteLine("Enter correct port: ");
            try
            {
                int port = Convert.ToInt32(Console.ReadLine());
                TcpClient tcpClient = new TcpClient(IP, port);
                NetworkStream stream = tcpClient.GetStream();
                while (true)
                {
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo cki = Console.ReadKey();
                        switch (cki.Key)
                        {
                            case ConsoleKey.W:
                                stream.Write(System.Text.Encoding.ASCII.GetBytes("Up"), 0, 2);
                                break;
                            case ConsoleKey.A:
                                stream.Write(System.Text.Encoding.ASCII.GetBytes("Left"), 0, 4);
                                break;
                            case ConsoleKey.S:
                                stream.Write(System.Text.Encoding.ASCII.GetBytes("Down"), 0, 4);
                                break;
                            case ConsoleKey.D:
                                stream.Write(System.Text.Encoding.ASCII.GetBytes("Right"), 0, 5);
                                break;
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("Incorrect port format.");
            }
            Console.ReadKey();
        }
    }
}
