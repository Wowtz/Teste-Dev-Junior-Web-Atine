using ApiCadastro.Entities;
using ApiCadastro.Repositories;
using ApiCadastro.Services;
using ApiCadastro.ViewModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCadastro.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _IClienteService;
        private readonly IClienteRepository _ClienteRepository;

        public ClienteController(IClienteService IClienteService, IClienteRepository IClienteRepository)
        {
            _IClienteService = IClienteService;
            _ClienteRepository = IClienteRepository;
        }

        [HttpGet("listar")]
        public async Task<IEnumerable<Cliente>> ListarClientes()
        {
            var result = await _IClienteService.ListarClientes();    

            return result;
        }

        [HttpGet("buscar/{idCliente:guid}")]
        public async Task<ActionResult<ClienteViewModel>> ObterEmpresa(Guid idCliente)
        {
            try
            {
                var result = await _IClienteService.ObterEmpresa(idCliente);

                return Ok(result);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost("criar")]
        public async Task<ActionResult<ClienteViewModel>> AdicionarEmpresa(ClienteViewModel cliente)
        {
            try
            {
                var checkEmpresa = await _ClienteRepository.ObterCliente(cliente.CNPJ);

                if (checkEmpresa != null)
                {
                    return Ok(false);
                }

                var result = await _IClienteService.Adicionar(cliente);
                return Ok(result);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPut("atualizar")]
        public async Task<ActionResult> AtualizarEmpresa(ClienteViewModel cliente)
        {
            try
            {
                await _IClienteService.Atualizar(cliente);



                return Ok();
            }
            catch(Exception e)
            {
                return NotFound(e);
            }
        }

        [HttpDelete("deletar/{idCliente:guid}")]
        public async Task<ActionResult> ApagarEmpresa(Guid idCliente)
        {
            try
            {
                await _IClienteService.Deletar(idCliente);

                return Ok();
            }
            catch(Exception e)
            {
                return NotFound(e);
            }
        }
    }
}
