using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Canguros.Model;

using Canguros.Model.Factories;
using Canguros.Model.interfaces;
using AppCanguros.Model.interfaces;
using Microsoft.Extensions.Logging;
using AppCanguros;
using Canguros.Model._Constants;
using Microsoft.Extensions.Configuration;
using Serilog;

static IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
        .ConfigureServices(
            (_, services) =>
                        services.AddSingleton<ILine<int>>(
                                                            line => new LineaNumerica(Constants.INITIAL_NUMBER_NUMERIC_LINE, Constants.FINAL_NUMBER_NUMERIC_LINE) )
                                .AddSingleton<Evaluator>()
                                .AddScoped<IJumper, Canguro>()
                                .AddSingleton<Application>()
                                );

}

var host = CreateHostBuilder(args)
           .UseSerilog((ctx, lc) => lc.WriteTo.Console()
                                      .WriteTo.RollingFile("log-{Date}.txt",
                                        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}")
      )

           .Build();
 

 
Application app = host.Services.GetRequiredService<Application>();
Console.WriteLine("Evaluando si existe punto de coincidencia...!");

var evaluator = app.Evaluator;

/*Instanciamos el primer canguro*/
var canguro1 = new CanguroFactory()
                        .Create(3, 3);
/*Instanciamos el segundo canguro*/
var canguro2 = new CanguroFactory()
                        .Create(3177, 2);
evaluator.WithCanguro(canguro1)
         .AndAnotherCanguro(canguro2);

var response = evaluator.ExistsCoincidentPoint_NonRecursiveAlternative(canguro1.CurrentPoint,canguro1.MetersPerJump, canguro2.CurrentPoint, canguro2.MetersPerJump);

/*Imprime el resultado final*/
 Console.WriteLine($"{response}");
 



