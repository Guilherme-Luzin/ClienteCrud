using ClienteCrud.Domain;
using DataModels;
using LinqToDB;
using LinqToDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteCrud.Infra
{
    public class LinqToDbClientRepository : IClienteRepository
    {
        public void Adicionar(Cliente cliente)
        {
            using (var db = new CadastroClienteDB())
            {
                db.Clientes.Value(c => c.Nome, cliente.Nome)
                    .Value(c => c.Idade, Convert.ToInt32(cliente.Idade))
                    .Value(c => c.Email, cliente.Email)
                    .Insert();
            }
        }

        public void Deletar(int id)
        {
            using (var db = new CadastroClienteDB())
            {
                db.Clientes.Where(c => c.Id == id).Delete();
            }
        }

        public void Editar(Cliente cliente)
        {
            using(var db = new CadastroClienteDB())
            {
                db.Clientes.Where(c => c.Id == cliente.Id)
                    .Set(c => c.Nome, cliente.Nome)
                    .Set(c => c.Idade, Convert.ToInt32(cliente.Idade))
                    .Set(c => c.Email, cliente.Email)
                    .Update();
            }
        }
        public List<Cliente> GetAll()
        {
            using (var db = new CadastroClienteDB())
            {
                var dados = from c in db.Clientes select c;
                return dados.ToList();
            }
        }

        public Cliente GetCliente(int id)
        {
            Cliente cliente = null;
            using (var db = new CadastroClienteDB())
            {
                cliente = new Cliente();
                var query = db.Clientes.Where(c => c.Id == id).ToList();
                foreach (var item in query.ToList())
                {
                    cliente.Id = Convert.ToInt32(item.Id);
                    cliente.Nome = item.Nome;
                    cliente.Idade = Convert.ToInt32(item.Idade.ToString());
                    cliente.Email = item.Email;
                }

            }
            return cliente;
        }
    }
}
