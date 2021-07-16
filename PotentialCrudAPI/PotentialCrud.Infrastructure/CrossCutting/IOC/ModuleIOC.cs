using Autofac;

namespace PotentialCrud.Infrastructure.CrossCutting.IOC
{
    public class ModuleIOC : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            ConfigurationIOC.Load(builder);
            base.Load(builder); 
        }
    }
}
