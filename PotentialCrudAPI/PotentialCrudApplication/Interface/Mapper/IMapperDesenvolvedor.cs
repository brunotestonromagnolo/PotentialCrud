using PotentialCrudApplication.Dto;
using PotentialCrudDomain.Entity;
using System.Collections.Generic;

namespace PotentialCrudApplication.Interface.Mapper
{
    public interface IMapperDesenvolvedor
    {
        Desenvolvedor MapperDtoToEntity(DesenvolvedorDto desenvolvedorDto);

        IEnumerable<DesenvolvedorDto> MapperListEntityToListDesenvolvedorDto(IEnumerable<Desenvolvedor> desenvolvedores);

        DesenvolvedorDto MapperEntityToDesenvolvedorDto(Desenvolvedor desenvolvedor);
    }
}
