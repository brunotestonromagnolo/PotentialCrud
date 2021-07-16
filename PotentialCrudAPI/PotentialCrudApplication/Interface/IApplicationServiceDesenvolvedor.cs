using PotentialCrudApplication.Dto;
using System.Collections.Generic;

namespace PotentialCrudApplication.Interface
{
    public interface IApplicationServiceDesenvolvedor
    {
        IEnumerable<DesenvolvedorDto> GetAll();

        DesenvolvedorDto GetById(int id);

        IEnumerable<DesenvolvedorDto> GetListById(int id);

        IEnumerable<DesenvolvedorDto> GetByQueryString(string queryString, int? qtdRegistros = null, int? pagina = null);

        int Add(DesenvolvedorDto desenvolvedor);

        void Update(DesenvolvedorDto desenvolvedor);

        void Remove(DesenvolvedorDto desenvolvedor);

        void Remove(int id);

    }
}
