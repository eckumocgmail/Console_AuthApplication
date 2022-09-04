using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Mvc_ClientApp
{
    public class ClientAppTransient : IDisposable 
    {
        private readonly ClientAppScoped _scoped;
        private readonly ILogger<ClientAppTransient> _logger;
        public ClientAppTransient(ILogger<ClientAppTransient> logger, ClientAppScoped scoped)
        {
            this._scoped = scoped;
            this._logger = logger;
            this._scoped.Add(this);
            this._logger.LogInformation("CREATED");
        }
        public void Dispose() => _scoped.Remove(this);
    }


    public class OperationClientAppTransient : ClientAppTransient, IMiddleware
    {
        public OperationClientAppTransient(
            ILogger<ClientAppTransient> logger, 
            ClientAppScoped scoped) : base(logger, scoped)
        {
        }

       
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await Task.CompletedTask;
        }
    }



}

