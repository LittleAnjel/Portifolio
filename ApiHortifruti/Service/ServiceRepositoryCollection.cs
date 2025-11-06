using System.Reflection;
using ApiHortifruti.Data.Repository;
using ApiHortifruti.Data.Repository.Interfaces;

// Adiciona no escopo do as interfaces e os servi�os/repositories que as implementam (baseando nos nomes encontrados no assembly)
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        // Registra repositories. Procura "arquivos" que são do tipo interface e o nome termina com "Repository" e adiciona em uma lista
        var repositories = assembly.GetTypes()
            .Where(t => t.Name.EndsWith("Repository") && !t.IsInterface)
            .ToList();

        // Passa a lista por um laço de repetição (para cada registro dentro dela) e faz o AddScoped(interfaceType = I+Nome, repo = Nome)       
        foreach (var repo in repositories)
        {
            var interfaceType = repo.GetInterface($"I{repo.Name}");
            if (interfaceType != null)
                services.AddScoped(interfaceType, repo);
        }

        // Registra services Procura "arquivos" que são do tipo interface e o nome termina com "Service" e adiciona em uma lista
        var serviceTypes = assembly.GetTypes()
            .Where(t => t.Name.EndsWith("Service") && !t.IsInterface)
            .ToList();

        // Passa a lista por um laço de repetição (para cada registro dentro dela) e faz o AddScoped(interfaceType = I+Nome, repo = Nome)    
        foreach (var service in serviceTypes)
        {
            var interfaceType = service.GetInterface($"I{service.Name}");
            if (interfaceType != null)
                services.AddScoped(interfaceType, service);
        }

        services.AddScoped<IUnityOfWork, UnityOfWork>(); // Adiciona o UnityOfWork no escopo
        return services;
    }
}