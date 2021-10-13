using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCadastro.Entities
{
    public class Telefone
    {
        public Guid Id { get; set; }
        public string TelefoneCliente { get; set; }
        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
