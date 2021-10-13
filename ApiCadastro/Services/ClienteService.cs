using ApiCadastro.Entities;
using ApiCadastro.Repositories;
using ApiCadastro.ViewModel;
using ApiCadastro.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCadastro.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _ClienteRepository;

        public ClienteService(IClienteRepository IClienteRepository)
        {
            _ClienteRepository = IClienteRepository;
        }

        public async Task<ClienteViewModel> Adicionar(ClienteViewModel cliente)
        {
            cliente.Id = Guid.NewGuid();

            var emails = new List<Email>();

            foreach (EmailViewModel email in cliente.Emails)
            {
                var emailCount = new Email()
                {
                    Id = Guid.NewGuid(),
                    EmailCliente = email.EmailCliente,
                    ClienteId = cliente.Id
                };

                emails.Add(emailCount);
            }

            var telefones = new List<Telefone>();

            foreach (TelefoneViewModel telefone in cliente.Telefones)
            {
                var tel = new Telefone()
                {
                    Id = Guid.NewGuid(),
                    TelefoneCliente = telefone.TelefoneCliente,
                    ClienteId = cliente.Id
                };
                telefones.Add(tel);
            }

            var empresaAdicionar = new Cliente
            {
                Id = cliente.Id,
                CNPJ = cliente.CNPJ,
                Email = emails,
                Endereco = cliente.Endereco,
                RazaoSocial = cliente.RazaoSocial,
                Telefone = telefones
            };

            //add banco de dados
            await _ClienteRepository.Inserir(empresaAdicionar);

            return new ClienteViewModel
            {
                Id = empresaAdicionar.Id,
                CNPJ = cliente.CNPJ,
                Emails = cliente.Emails,
                Endereco = cliente.Endereco,
                RazaoSocial = cliente.RazaoSocial,
                Telefones = cliente.Telefones,
            };

        }

        public async Task Atualizar(ClienteViewModel clienteAtt)
        {
            var cliente = _ClienteRepository.ObterCliente(clienteAtt.Id);

            if (cliente == null)
            {
                throw new Exception("Não encontrado");
            }


            var clienteUpdate = new Cliente
            {
                Id = clienteAtt.Id,
                RazaoSocial = clienteAtt.RazaoSocial,
                CNPJ = clienteAtt.CNPJ,
                Endereco = clienteAtt.Endereco
            };

            await _ClienteRepository.Atualizar(clienteUpdate);
        }

        public async Task Deletar(Guid id)
        {
            var cliente = _ClienteRepository.ObterCliente(id);
            if(cliente == null)
            {
                throw new Exception("Não encontrado");
            }

            await _ClienteRepository.Remover(id);
        }

       

        public async Task<ClienteViewModel> ObterEmpresa(Guid id)
        {
            var empresa = await _ClienteRepository.ObterCliente(id);

            if(empresa == null)
            {
                return null;
            }

            var emails = new List<EmailViewModel>();

            foreach (Email email in empresa.Email)
            {
                var emailCount = new EmailViewModel()
                {
                    EmailCliente = email.EmailCliente,
                };

                emails.Add(emailCount);
            }

            var telefones = new List<TelefoneViewModel>();

            foreach (Telefone telefone in empresa.Telefone)
            {
                var tel = new TelefoneViewModel()
                {
                    TelefoneCliente = telefone.TelefoneCliente,
                };
                telefones.Add(tel);
            }

            return new ClienteViewModel
            {
                Id = empresa.Id,
                CNPJ = empresa.CNPJ,
                Emails = emails,
                Endereco = empresa.Endereco,
                RazaoSocial = empresa.RazaoSocial,
                Telefones = telefones
            };
        }

        public void Dispose()
        {
            _ClienteRepository?.Dispose();
        }

        public async Task<List<Cliente>> ListarClientes()
        {
                return await _ClienteRepository.ListarClientes();
        }
    }
}
