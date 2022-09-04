using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_ClientApp.Modules
{

   
    public class ClientAppMiddleware
    {
        private List<Predicate<HttpContext>> Steps = new List<Predicate<HttpContext>>();

        public async Task Cofigure( HttpContext context )
        {
            List<bool> results = new List<bool>();
            try
            {        
                
                Steps.ForEach(step => results.Add(step(context)));
            }
            catch(Exception ex)
            {
                foreach( bool result in  results)
                    Console.WriteLine(result);
            }
            finally
            {
                await Task.CompletedTask;
            }
        }

       
    }
}
