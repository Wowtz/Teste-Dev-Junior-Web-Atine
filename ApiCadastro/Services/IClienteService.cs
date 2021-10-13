using ApiCadastro.Entities;
using ApiCadastro.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCadastro.Services
{
    public interface IClienteService : IDisposable
    {
        Task<List<Cliente>> ListarClientes();
        Task<ClienteViewModel> ObterEmpresa(Guid id);
        Task<ClienteViewModel> Adicionar(ClienteViewModel empresa);
        Task Atualizar(ClienteViewModel empresa);
        Task Deletar(Guid id);
    }
}
