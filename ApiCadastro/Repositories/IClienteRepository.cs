using ApiCadastro.Entities;
using ApiCadastro.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCadastro.Repositories
{
    public interface IClienteRepository : IDisposable
    {
        Task<List<Cliente>> ListarClientes();
        Task<Cliente> ObterCliente(Guid id);
        Task<Cliente> ObterCliente(string cnpj);
        Task Inserir(Cliente cliente);
        Task Atualizar(Cliente cliente);
        Task Remover(Guid id);
        void Dispose();
    }
}
