using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDotNetCore31
{
    public class Partsix
    {
        public static void Main(string[] args)
        {
            //will write it in console
            Console.WriteLine("Hello, world!"); // Print "Hello, world!" to the console
            Console.WriteLine("Hello, world!");
            Console.WriteLine("Hello, world!");
            Console.WriteLine("Hello, world!");
            Console.WriteLine("Hello, world!");
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            //app.MapGet("/", () => "Hello From Nawab Zadi");

            //app.Run();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();

                });
    }
}