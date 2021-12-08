using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteCrud.Domain
{
    public interface IClienteRepository
    {
        void Adicionar(Cliente cliente);
        void Editar(Cliente cliente);
        void Deletar(int id);
        Cliente GetCliente(int id);

        List<Cliente> GetAll();
    }
}
