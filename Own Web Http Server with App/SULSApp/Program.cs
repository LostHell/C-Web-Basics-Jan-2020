using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SIS.HTTP;
using SIS.MvcFramework;
using SULSApp.Controllers;

namespace SULSApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await WebHost.StartAsync(new Startup());
        }
    }
}
