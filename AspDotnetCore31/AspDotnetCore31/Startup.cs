﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
namespace AspDotNetCore31
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
            {
                 _config = config;
            }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    //await context.Response.WriteAsync("Hello World");
                    //gets the current process name

                    await context.Response.WriteAsync(System.Diagnostics.Process.GetCurrentProcess().ProcessName);

                    await context.Response.WriteAsync("   ");

                    //part009
                    await context.Response.WriteAsync(_config["MyKey"]);
                });
            });
            //Console.WriteLine("Hello, world!"); // Print "Hello, world!" to the console

        }
    }
}