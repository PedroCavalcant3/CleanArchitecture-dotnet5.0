using CleanArch.Infra.Data.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;


namespace CleanArch.MVC {
    public class Program {

        //Cria um escopo de servi�o, obt�m o contexto do banco de dados, executa as migra��es pendentes e, em caso de erros, registra as exce��es.
        //Em seguida, inicia a execu��o do aplicativo. Garantia que o banco de dados esteja devidamente configurado antes de iniciar a aplica��o.

        public static void Main(string[] args) {


            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope()) {

                var services = scope.ServiceProvider;

                try {
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    context.Database.Migrate();
                }
                catch (Exception e) {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(e, "Ocorreu um erro na Migra��o ou alimenta��o dos dados.");
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
