
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

 
public class ClientAppSingleton: IServiceProvider
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IList<ServiceDescriptor> _serviceCollection;
    private readonly IDictionary<int, object> _serviceTrancients;

    public ClientAppSingleton( IList<ServiceDescriptor> serviceCollection, IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _serviceCollection = serviceCollection;
        _serviceTrancients = new ConcurrentDictionary<int, object>();  
    }
   
    public void OnTimeup(long seconds)
    {
        Console.WriteLine($"OnTimeup({seconds})");
    }

    public static Func<IServiceProvider, ClientAppSingleton> Get(IServiceCollection services)
    {
        var servicesList = services.ToList();
        return (sp) => new ClientAppSingleton(servicesList, sp);
    }
    public object GetService(Type serviceType) => _serviceCollection.FirstOrDefault(desc => desc.ServiceType == serviceType).ImplementationFactory.Invoke(_serviceProvider);
    public void Add(object service) => _serviceTrancients[service.GetHashCode()] = service;
    public void Remove(object service) => _serviceTrancients.Remove(service.GetHashCode());
    
} 