using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MusicStore.Logic.Artists;

namespace MusicStore.Web.Infrastructure
{
    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyContaining(typeof(ArtistRepository))
                                .Where(Component.IsInSameNamespaceAs<ArtistRepository>())
                                .WithService.DefaultInterfaces()
                                .LifestylePerWebRequest());
        }
    }
}