using ClienteCrud.Domain;
using ClienteCrud.Infra;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteCrud.UI
{
    public class FormModule : NinjectModule
    {
        public override void Load()
        {
            //Bind<IClienteRepository>().To<ClienteRepository>();
            Bind<IClienteRepository>().To<LinqToDbClientRepository>();
        }

        public static FormModule create()
        {
            return new FormModule();
        }
    }
}
