using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BlazorClient
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddOidcAuthentication(options =>
            {
                // Configure your authentication provider options here.
                // For more information, see https://aka.ms/blazor-standalone-auth
                builder.Configuration.Bind("oidc", options.ProviderOptions);

                

                // options.ProviderOptions.Authority = "https://localhost:5001";

                // options.ProviderOptions.ClientId = "blazor";
                // // options.ProviderOptions.ClientSecret = "secret";
                // options.ProviderOptions.ResponseType = "code";

//                options.ProviderOptions.DefaultScopes.Add("{SCOPE URI}");
            });

            await builder.Build().RunAsync();
        }
    }
}
