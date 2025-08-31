using Microsoft.Extensions.DependencyInjection;

namespace AdapterPattern
{
    internal class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<Features.Interfaces.ISquarePeg, Features.SquarePeg>();
            services.AddTransient<Features.Interfaces.IRoundPeg, Features.RoundPeg>();
            services.AddTransient<Features.Interfaces.IRoundHole, Features.RoundHole>();
            services.AddTransient<Features.Adapter.ISquarePegAdapter, Features.Adapter.SquarePegAdapter>();
        }
    }
}
