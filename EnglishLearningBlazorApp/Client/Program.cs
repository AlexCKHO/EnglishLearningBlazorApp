using EnglishLearningBlazorApp.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


namespace EnglishLearningBlazorApp.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddHttpClient("EnglishLearningBlazorApp.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("EnglishLearningBlazorApp.ServerAPI"));

            #region Using_the_Dictionary_Service

            builder.Services.AddSingleton<WordListService>();
            builder.Services.AddSingleton<DictionaryInitializationService>();


            builder.Services.AddApiAuthorization();

            var host = builder.Build();
            var dictionaryInitializationService = host.Services.GetRequiredService<DictionaryInitializationService>();

            // Initialize the dictionary
            await dictionaryInitializationService.InitializeDictionaryAsync();

            await host.RunAsync();

            #endregion

            await builder.Build().RunAsync();
        }
    }
}