using PotentialCrudCommon.Exceptions;
using System;
using System.ComponentModel.DataAnnotations;

namespace PotentialCrudDomain.Entity
{
    public class Desenvolvedor : Base
    {
        private int _idade;

        [Required]
        public string Nome { get; set; }

        [Required]        
        public string Sexo { get; set; }

        [Required]
        public int Idade
        {
            get
            {
                return _idade;
            }
            set
            {
                if (value <= 0) throw new FieldInvalidException("Campo 'Idade' deve ser maior que zero!");
                _idade = value;
            }
        }

        public string Hobby { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }
    }
}
