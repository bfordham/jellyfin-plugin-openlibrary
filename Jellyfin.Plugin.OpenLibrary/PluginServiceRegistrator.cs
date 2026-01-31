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
        /// <inheritdoc />
        public void RegisterServices(IServiceCollection serviceCollection, IServerApplicationHost applicationHost)
        {
            serviceCollection.AddSingleton<OpenLibraryProvider>();
            serviceCollection.AddSingleton<IRemoteMetadataProvider<Person, PersonLookupInfo>, OpenLibraryPersonProvider>();
        }
    }
}
