 

using System;
using System.Threading;
using System.Threading.Tasks;

public class ClientAppBackground 
{
    private readonly ClientAppSingleton _app;

    public ClientAppBackground(ClientAppSingleton app)
    {
        Console.WriteLine("CREATED");
        _app = app;
            
    }

    protected Task ExecuteAsync(CancellationToken stoppingToken)
    {
        return Task.Run(() => {
            while (true)
            {
                long seconds = DateTimeOffset.Now.ToUnixTimeSeconds();
                Console.WriteLine("OnTimeup: "+seconds);
                _app.OnTimeup(seconds);
                Thread.Sleep(1000);
            }


        });
    }
}

