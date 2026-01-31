using System;
using Jellyfin.Plugin.OpenLibrary.Providers;
using MediaBrowser.Controller;
using MediaBrowser.Controller.Entities;
using MediaBrowser.Controller.Plugins;
using MediaBrowser.Controller.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace Jellyfin.Plugin.OpenLibrary
{
    /// <summary>
    /// Register OpenLibrary services.
    /// </summary>
    public class PluginServiceRegistrator : IPluginServiceRegistrator
    {
        /// <summary>
        /// The name of the HTTP client used for OpenLibrary API requests.
        /// </summary>
        public const string OpenLibraryHttpClientName = "OpenLibrary";

        /// <inheritdoc />
        public void RegisterServices(IServiceCollection serviceCollection, IServerApplicationHost applicationHost)
        {
            // Register the rate-limited HTTP handler
            serviceCollection.AddTransient<ClientSideRateLimitedHandler>();

            // Register a named HTTP client with rate limiting for OpenLibrary API
            serviceCollection.AddHttpClient(OpenLibraryHttpClientName)
                .ConfigurePrimaryHttpMessageHandler<ClientSideRateLimitedHandler>()
                .SetHandlerLifetime(TimeSpan.FromMinutes(5));

            // Register the metadata providers
            serviceCollection.AddSingleton<OpenLibraryProvider>();
            serviceCollection.AddSingleton<IRemoteMetadataProvider<Person, PersonLookupInfo>, OpenLibraryPersonProvider>();
        }
    }
}
