using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SIS.HTTP
{
    public class HttpServer : IHttpServer
    {
        private readonly TcpListener tcpListener;
        public HttpServer(int port)
        {
            tcpListener = new TcpListener(IPAddress.Loopback, port);
        }
        public async Task ResetAsync()
        {
            StopAsync();
            StartAsync();
        }

        public async Task StartAsync()
        {
            this.tcpListener.Start();

            while (true)
            {
                TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync();

                Task.Run(() => ProcessClientAsync(tcpClient));
            }
        }

        private async Task ProcessClientAsync(TcpClient tcpClient)
        {
            using (NetworkStream networkStream = tcpClient.GetStream())
            {
                byte[] requestBytes = new byte[100000];
                int bytesRead = await networkStream.ReadAsync(requestBytes, 0, requestBytes.Length);
                string requestAsString = Encoding.UTF8.GetString(requestBytes, 0, bytesRead);
                var request = new HttpRequest(requestAsString);
                string content = "<h1>Random page</h1>";

                if (request.Path == "/")
                {
                    content = "<h1>Home page</h1>";
                }
                else if (request.Path == "/users/login")
                {
                    content = "<h1>Login page</h1>";
                }

                byte[] stringContent = Encoding.UTF8.GetBytes(content);
                var response = new HttpResponse(HttpResponseCode.OK, stringContent);

                response.Headers.Add(new Header("Server", "MyPrivateServer/1.3"));
                response.Headers.Add(new Header("Content-Type","text/html"));

                byte[] responseBytes = Encoding.UTF8.GetBytes(response.ToString());

                await networkStream.WriteAsync(responseBytes, 0, responseBytes.Length);
                await networkStream.WriteAsync(response.Body, 0, response.Body.Length);

                Console.WriteLine(request);
                Console.WriteLine(new string('=', 60));
            }
        }

        public void StopAsync()
        {
            this.tcpListener.Stop();
        }
    }
}