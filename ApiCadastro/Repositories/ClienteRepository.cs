using ApiCadastro.Configuration;
using ApiCadastro.Entities;
using ApiCadastro.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ApiCadastro.Repositories
{
    public class ClienteRepository : IClienteRepository, IDisposable
    {
        private readonly DbContextOptions<ClienteContext> _optionsBuilder;

        public ClienteRepository()
        {
            _optionsBuilder = new DbContextOptions<ClienteContext>();

        }

        public async Task Atualizar(Cliente empresa)
        {
            using (var data = new ClienteContext(_optionsBuilder))
            {
                data.Set<Cliente>().Update(empresa);
                await data.SaveChangesAsync();
            }
        }

        public async Task Inserir(Cliente empresa)
        {
            using (var data = new ClienteContext(_optionsBuilder))
            {
                await data.AddAsync(empresa);
                await data.SaveChangesAsync();
            }
        }
        

        public async Task<Cliente> ObterCliente(Guid id)
        {
            using (var data = new ClienteContext(_optionsBuilder))
            {
                var res = await data.Set<Cliente>().Include(x => x.Email).Include(x => x.Telefone).FirstOrDefaultAsync(x => x.Id == id);
                return res;
            }
        }

        public async Task<Cliente> ObterCliente(string cnpj)
        {
            using (var data = new ClienteContext(_optionsBuilder))
            {
                var res = await data.Set<Cliente>().Include(x => x.Email).Include(x => x.Telefone).FirstOrDefaultAsync(x => x.CNPJ == cnpj);
                return res;
            }
        }

        public async Task Remover(Guid id)
        {
            using (var data = new ClienteContext(_optionsBuilder))
            {
                var res = await data.Set<Cliente>().FirstOrDefaultAsync(x => x.Id == id);
                data.Set<Cliente>().Remove(res);
                await data.SaveChangesAsync();
            }
        }
        public async  Task<List<Cliente>> ListarClientes()
        {
            using (var data = new ClienteContext(_optionsBuilder))
            {
                return await data.Set<Cliente>().Include(x => x.Email).Include(x => x.Telefone).ToListAsync();
            }
        }

        #region Disposed https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public ClienteRepository(DbContextOptions<ClienteContext> optionsBuilder)
        {
            _optionsBuilder = optionsBuilder;
        }


        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }

        #endregion
    }
}
