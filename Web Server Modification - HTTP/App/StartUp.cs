using SIS.HTTP;
using System;
using System.Threading.Tasks;

namespace App
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            var httpServer = new HttpServer(80);
            await httpServer.StartAsync();
        }
    }
}
