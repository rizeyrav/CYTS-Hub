using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

new HostBuilder()
    // .ConfigureHostConfiguration({})      => Mengatur config host(paling awal : env variabel, args)
    // .ConfigureAppConfiguration(()=>{})   => Mengatur config aplikasi(appsettings.json, koneksi database, API Key)
    // .ConfigureServices(()=>{})           => Mengatur DI(Service, Repository, Controller)
    // .ConfigureLogging({}=>)              => Mengatur Console Log
    // .UseEnvironment("")                  => Mengatur Mode Aplikasi (Development, Production, dan Staging)
    // .UseContentRoot(Directory.GetCurrentDirectory())             => Menentukan Root folder aplikasi (Load file, config, dan static file)
    // .UseDefaultServiceProvider({})       => Mengatur behavior DI container
    // .ConfigureContainer<ContainerBuilder>({})          
    // .UseConsoleLifeTime()                => Mengatur siklus app di console
    .ConfigureLogging(logging =>
    {
        logging.AddConsole();
        logging.AddDebug();
    })
    // .ConfigureWebHost({}=>)           => Mengatur Server, Middleware, dan Routing
    .ConfigureWebHost(webBuilder =>
    {
        webBuilder.UseKestrel();
        webBuilder.Configure(app =>
        {
            // Request dikirim ke app.Run
            app.Run(async context =>
            {
                // Proses Request
                Console.WriteLine("Server Start Manual");

                // Response ke client
                await context.Response.WriteAsync("Manual Host");
            });
        });
    })
.Build()
.Run();