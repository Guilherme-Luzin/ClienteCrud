using ClienteCrud.Domain;
using ClienteCrud.Infra;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ClienteCrud.Web.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clientRepository;
        public ClienteController(IClienteRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var cliente = _clientRepository.GetAll();
            return View(cliente.ToList());
        }

        // GET: ClientController/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            Cliente cliente = new Cliente();
            var GetCliente = _clientRepository.GetCliente(id);
            cliente.Id = GetCliente.Id;
            cliente.Nome = GetCliente.Nome;
            cliente.Idade = GetCliente.Idade;
            cliente.Email = GetCliente.Email;
            return View(cliente);
        }

        [HttpGet]
        public ActionResult Create(int id = 0)
        {
            if(id == 0)
            {
                return View(new Cliente());
            }
            else
            {
                Cliente cliente = new Cliente();
                var Getcliente = _clientRepository.GetCliente(id);
                cliente.Nome = Getcliente.Nome;
                cliente.Idade = Getcliente.Idade;
                cliente.Email = Getcliente.Email;
                return View(cliente);
            }
        }

        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente, int id)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _clientRepository.Adicionar(cliente);
                    return RedirectToAction("Index");
                }
                else
                {
                    _clientRepository.Editar(cliente);
                    return RedirectToAction("Index");
                }
            }
            return View(cliente);
            
        }

        // GET: ClientController/Edit/5
        //[HttpGet]
        /*public ActionResult Edit(int id)
        {
            Cliente cliente = new Cliente();
            var Getcliente = _clientRepository.GetCliente(id);
            cliente.Nome = Getcliente.Nome;
            cliente.Idade = Getcliente.Idade;
            cliente.Email = Getcliente.Email;
            return View(cliente);
        }*/

        // POST: ClientController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        /*public ActionResult Edit(Cliente cliente)
        {
            _clientRepository.Editar(cliente);
            return RedirectToAction("Index");
        }*/

        // GET: ClientController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Cliente cliente = new Cliente();
            var GetCliente = _clientRepository.GetCliente(id);
            cliente.Id = GetCliente.Id;
            cliente.Nome = GetCliente.Nome;
            cliente.Idade = GetCliente.Idade;
            cliente.Email = GetCliente.Email;
            return View(cliente);
        }

        // POST: ClientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _clientRepository.Deletar(id);
            return RedirectToAction("Index");
        }
    }
}
