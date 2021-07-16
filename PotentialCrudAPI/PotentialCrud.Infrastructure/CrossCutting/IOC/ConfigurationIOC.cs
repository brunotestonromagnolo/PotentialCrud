using Autofac;
using PotentialCrud.Domain.Service;
using PotentialCrud.Infrastructure.Data.Repository;
using PotentialCrudApplication;
using PotentialCrudApplication.Interface;
using PotentialCrudApplication.Interface.Mapper;
using PotentialCrudApplication.Mapper;
using PotentialCrudDomain.Core.Interface.Repository;
using PotentialCrudDomain.Core.Interface.Service;

namespace PotentialCrud.Infrastructure.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationServiceDesenvolvedor>().As<IApplicationServiceDesenvolvedor>();
            builder.RegisterType<ServiceDesenvolvedor>().As<IServiceDesenvolvedor>();
            builder.RegisterType<RepositoryDesenvolvedor>().As<IRepositoryDesenvolvedor>();
            builder.RegisterType<MapperDesenvolvedor>().As<IMapperDesenvolvedor>();
        }
    }
}
