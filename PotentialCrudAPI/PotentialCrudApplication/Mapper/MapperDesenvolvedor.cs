using PotentialCrudApplication.Dto;
using PotentialCrudApplication.Interface.Mapper;
using PotentialCrudDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PotentialCrudApplication.Mapper
{
    public class MapperDesenvolvedor : IMapperDesenvolvedor
    {
        public Desenvolvedor MapperDtoToEntity(DesenvolvedorDto desenvolvedorDto)
        {
            if (desenvolvedorDto == null) return null;            

            return new Desenvolvedor()
            {
                Id = desenvolvedorDto.Id,
                Nome = desenvolvedorDto.Nome,
                Sexo = desenvolvedorDto.Sexo.ToString(),
                Idade = desenvolvedorDto.Idade,
                Hobby = desenvolvedorDto.Hobby,
                DataNascimento = Convert.ToDateTime(desenvolvedorDto.DataNascimento)
            };
        }

        public DesenvolvedorDto MapperEntityToDesenvolvedorDto(Desenvolvedor desenvolvedor)
        {
            if (desenvolvedor == null) return null;

            return new DesenvolvedorDto()
            {
                Id = desenvolvedor.Id,
                Nome = desenvolvedor.Nome,
                Sexo = desenvolvedor.Sexo.ToString().ToUpper(),
                Idade = desenvolvedor.Idade,
                Hobby = desenvolvedor.Hobby,
                DataNascimento = desenvolvedor.DataNascimento.ToString("yyyy-MM-dd")
        };
        }

        public IEnumerable<DesenvolvedorDto> MapperListEntityToListDesenvolvedorDto(IEnumerable<Desenvolvedor> desenvolvedores)
        {
            if (desenvolvedores.Count() == 0) return null;

            return desenvolvedores.Select(d => new DesenvolvedorDto
            {
                Id = d.Id,
                Nome = d.Nome,
                Sexo = d.Sexo.ToString().ToUpper(),
                Idade = d.Idade,
                Hobby = d.Hobby,
                DataNascimento = d.DataNascimento.ToString("yyyy-MM-dd")
            });
        }        
    }
}
