using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCadastro.Entities
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public ICollection<Telefone> Telefone { get; set; }
        public ICollection<Email> Email { get; set; }
        public string Endereco { get; set; }
    }
}
