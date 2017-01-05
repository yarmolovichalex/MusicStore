using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MusicStore.Logic.Model.Artist;

namespace MusicStore.Web.Infrastructure
{
    public class ServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyContaining(typeof(ArtistService))
                                .Where(Component.IsInSameNamespaceAs<ArtistService>())
                                .WithService.DefaultInterfaces()
                                .LifestylePerWebRequest());
        }
    }
}