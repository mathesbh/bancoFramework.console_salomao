using bancoFramework;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    private static IMenuServices _menuServices;
    private static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();
        var serviceProvider = AddApplicationServicesExtensions.AddApplicatonServices(serviceCollection).BuildServiceProvider();
        _menuServices = serviceProvider.GetRequiredService<IMenuServices>();

        _menuServices.BoasVindas().Wait();
    }
}