﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Canguros.Model;

using Canguros.Model.Factories;
using Canguros.Model.interfaces;
using AppCanguros.Model.interfaces;
using Microsoft.Extensions.Logging;
using AppCanguros;
using Canguros.Model._Constants;

static IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
        .ConfigureServices(
            (_, services) => 
                        services.AddSingleton<ILine<int>>(
                                                line => { return new LineaNumerica(Constants.INITIAL_NUMBER_NUMERIC_LINE, Constants.FINAL_NUMBER_NUMERIC_LINE);
                                            })                                        
                                .AddSingleton<Evaluator>()
                                .AddScoped<IJumper, Canguro>()
                                .AddSingleton<Application, Application>());
}
var host = CreateHostBuilder(args).Build();
Application app = host.Services.GetRequiredService<Application>();
Console.WriteLine("Evaluando si existe punto de coincidencia...!");

var evaluator = app.Evaluator;

/*Instanciamos el primer canguro*/
var canguro1 = new CanguroFactory()
                        .Create(3, 3);
/*Instanciamos el segundo canguro*/
var canguro2 = new CanguroFactory()
                        .Create(5, 2);
evaluator.WithCanguro(canguro1)
         .AndAnotherCanguro(canguro2);
bool existsPoint = evaluator.ExistsCoincidentPoint(canguro1, canguro2);

/*Imprime el resultado final*/
if (existsPoint)
    Console.WriteLine("SI");
else
    Console.WriteLine("NO");


