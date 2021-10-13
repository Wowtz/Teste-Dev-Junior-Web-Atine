using ApiCadastro.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCadastro.ViewModel
{
    public class ClienteViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string RazaoSocial { get; set; }

        [Required]
        public string CNPJ { get; set; }

        [Required]
        public List<TelefoneViewModel> Telefones { get; set; }

        [Required]
        public List<EmailViewModel> Emails { get; set; }

        [Required]
        public string Endereco { get; set; } 
    }
}
