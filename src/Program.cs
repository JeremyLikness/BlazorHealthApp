using System.Threading.Tasks;
using BlazorHealthApp.Shared;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorHealthApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault();
            builder.RootComponents.Add<App>("app");
            builder.Services.AddSingleton<IModel, MainModel>();
            await builder.Build().RunAsync();
        }
    }
}
