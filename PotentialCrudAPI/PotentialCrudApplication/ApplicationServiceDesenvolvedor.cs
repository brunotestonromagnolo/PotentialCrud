using PotentialCrudApplication.Dto;
using PotentialCrudApplication.Interface;
using PotentialCrudApplication.Interface.Mapper;
using PotentialCrudCommon.Exceptions;
using PotentialCrudDomain.Core.Interface.Service;
using System.Collections.Generic;
using System.Linq;

namespace PotentialCrudApplication
{
    public class ApplicationServiceDesenvolvedor : IApplicationServiceDesenvolvedor
    {
        private readonly IServiceDesenvolvedor serviceDesenvolvedor;
        private readonly IMapperDesenvolvedor mapperDesenvolvedor;

        public ApplicationServiceDesenvolvedor(IServiceDesenvolvedor serviceDesenvolvedor, IMapperDesenvolvedor mapperDesenvolvedor )
        {
            this.serviceDesenvolvedor = serviceDesenvolvedor;
            this.mapperDesenvolvedor = mapperDesenvolvedor;
        }


        public int Add(DesenvolvedorDto desenvolvedor)
        {
            var devEntity = mapperDesenvolvedor.MapperDtoToEntity(desenvolvedor);            
            return serviceDesenvolvedor.Add(devEntity);
        }

        public IEnumerable<DesenvolvedorDto> GetAll()
        {
            var desenvolvedores = serviceDesenvolvedor.GetlAll();
            return mapperDesenvolvedor.MapperListEntityToListDesenvolvedorDto(desenvolvedores);
        }

        public DesenvolvedorDto GetById(int id)
        {
            var desenvolvedor = serviceDesenvolvedor.GetById(id);
            return mapperDesenvolvedor.MapperEntityToDesenvolvedorDto(desenvolvedor);
        }

        public IEnumerable<DesenvolvedorDto> GetListById(int id)
        {
            var desenvolvedor = serviceDesenvolvedor.GetListById(id);
            return mapperDesenvolvedor.MapperListEntityToListDesenvolvedorDto(desenvolvedor);
        }

        public IEnumerable<DesenvolvedorDto> GetByQueryString(string queryString, int? qtdRegistros = null, int? pagina = null)
        {
            var queryStringMaiuscula = queryString.ToUpper();

            var desenvolvedores = serviceDesenvolvedor.GetlAll().Where(q => 
            q.Nome.ToUpper().Contains(queryStringMaiuscula) || 
            q.Hobby.ToUpper().Contains(queryStringMaiuscula) || 
            q.Idade.ToString().Contains(queryString));

            if (qtdRegistros != null && pagina != null)
            {
                desenvolvedores =  desenvolvedores.Skip((qtdRegistros * (pagina - 1)).Value).Take(qtdRegistros.Value);
            }            
            
            return mapperDesenvolvedor.MapperListEntityToListDesenvolvedorDto(desenvolvedores);
        }

        public void Remove(DesenvolvedorDto desenvolvedor)
        {
            var devEntity = mapperDesenvolvedor.MapperDtoToEntity(desenvolvedor);
            serviceDesenvolvedor.Remove(devEntity);
        }

        public void Remove(int id)
        {
            var desenvolvedor = serviceDesenvolvedor.GetById(id);

            if (desenvolvedor == null)
                throw new RegistryNotFoundException("Registro nao encontrado");

            serviceDesenvolvedor.Remove(desenvolvedor);
        }

        public void Update(DesenvolvedorDto desenvolvedor)
        {
            var devEntity = mapperDesenvolvedor.MapperDtoToEntity(desenvolvedor);
            serviceDesenvolvedor.Update(devEntity);
        }
    }
}
