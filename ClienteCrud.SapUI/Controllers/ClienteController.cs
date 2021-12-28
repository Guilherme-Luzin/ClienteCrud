using ClienteCrud.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;

namespace CrudCliente.SapUI.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clientRepository;
        public ClienteController(IClienteRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            var cliente = _clientRepository.GetAll();
            return Ok(cliente);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(Cliente cliente)
        {
            //JsonConvert.SerializeObject(cliente);
            if (cliente.Id == 0)
            {
                _clientRepository.Adicionar(cliente);
                return Json(new { status = "ok" });
            }
            else
            {
                _clientRepository.Editar(cliente);
                return Json(new { status = "ok" });
            }
        }

        [HttpGet]
        [Route("GetClient")]
        public IActionResult GetClient(int id)
        {
            Cliente cliente = new Cliente();
            var GetCliente = _clientRepository.GetCliente(id);
            cliente.Id = GetCliente.Id;
            cliente.Nome = GetCliente.Nome;
            cliente.Idade = GetCliente.Idade;
            cliente.Email = GetCliente.Email;
            return Ok(cliente);
        }

        // POST: ClientController/Delete/5
        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            _clientRepository.Deletar(id);
            return Json(new { status = "ok" });
        }
    }
}
