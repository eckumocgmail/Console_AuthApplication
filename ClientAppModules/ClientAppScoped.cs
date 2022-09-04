using Microsoft.Extensions.Logging;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Mvc_ClientApp
{
    public class ClientAppScoped : IDisposable  
    {
        private readonly ClientAppSingleton _singleton;
        private readonly ILogger<ClientAppScoped> _logger;
        private readonly IDictionary<int, object> _scopes;


        public ClientAppScoped(ILogger<ClientAppScoped> logger, ClientAppSingleton singleton)
        {
            this._singleton = singleton;
            this._logger = logger;
            this._singleton.Add(this);
            this._scopes = new ConcurrentDictionary<int, object>();
            this._logger.LogInformation("CREATED");
        }
        public void Add(object transient) => this._scopes[transient.GetHashCode()] = transient;
        public void Remove(object transient) => this._scopes.Remove(transient.GetHashCode());
        public void Dispose()
        {
            this._singleton.Remove(this);
        }
    }
}


