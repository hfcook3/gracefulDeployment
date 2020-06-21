using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

public class SleepyService : IHostedService, IDisposable
{
    private Timer _timer;
    private Task _sleepTask;

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(SleepAsync, null, 0, 15001);
        return Task.CompletedTask;
    }

    private async void SleepAsync(object state)
    {
        System.Console.WriteLine("Going to sleep...");
        _sleepTask = Task.Delay(15000);
        await _sleepTask;
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        Dispose();
    }

    public void Dispose()
    {
        _timer.Dispose();
    }
}