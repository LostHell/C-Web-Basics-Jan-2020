using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RequesterHTTP
{
    class Program
    {
        // async Task
        static void Main(string[] args)
        {
            const string NewLine = "\r\n";

            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 80);
            tcpListener.Start();

            while (true)
            {
                TcpClient tcpClient = tcpListener.AcceptTcpClient();
                using (NetworkStream networkStream = tcpClient.GetStream())
                {
                    byte[] requestBytes = new byte[100000];           //TODO: USE BUFFER
                    int bytesRead = networkStream.Read(requestBytes, 0, requestBytes.Length);
                    string request = Encoding.UTF8.GetString(requestBytes, 0, requestBytes.Length);

                    string responseText = @"<form action='/Account/Login' method='post'>
                                            <input type=text name='username' />
                                            <input type=password name='password' />
                                            <input type=date name='date' />
                                            <input type=submit value='submit' />
                                            </form>";
                    string response = "HTTP/1.1 200 Created" + NewLine +
                                      "Server: MyServer/1.0" + NewLine +
                                      "Content-Type: text/html" + NewLine +
                                      "Content-Lenght: " + responseText.Length + NewLine + NewLine +
                                      responseText;
                    byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                    networkStream.Write(responseBytes, 0, responseBytes.Length);

                    Console.WriteLine(request);
                    Console.WriteLine(new string('=', 50));
                }
            }
        }

        public static async Task HttpRequest()
        {
            //          ---GET---           //

            //  HttpClient client = new HttpClient();
            //
            //  //First option
            //  //await client.GetAsync("https://softuni.bg");
            //  //Second option
            //  //client.GetAsync("https://softuni.bg").GetAwaiter().GetResult();

            //  HttpResponseMessage response = await client.GetAsync("https://softuni.bg");
            //  string result = await response.Content.ReadAsStringAsync();
            //  File.WriteAllText("index.html", result);





            //   HttpClient client = new HttpClient();
            //   client.DefaultRequestHeaders.Add("User-Agent", "MyConsoleBrowser/1.0");
            //   HttpResponseMessage response = await client.GetAsync("https://softuni.bg");
            //   string result = await response.Content.ReadAsStringAsync();
            //   File.WriteAllText("index.html", result);
        }
    }
}
