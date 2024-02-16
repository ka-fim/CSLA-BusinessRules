// See https://aka.ms/new-console-template for more information

using Csla;
using Csla.Configuration;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddCsla();
var provider = services.BuildServiceProvider();
var dp = provider.GetRequiredService<IDataPortal<BusinessClass>>();

var bo = dp.Create();

Console.WriteLine("Setting primary property");
bo.Primary = "test";
Console.WriteLine("Setting additional input property");
bo.AdditionalInput = "test2";