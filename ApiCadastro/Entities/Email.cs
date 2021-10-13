using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCadastro.Entities
{
    public class Email
    {
        public Guid Id { get; set; }
        public string EmailCliente { get; set; }
        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
