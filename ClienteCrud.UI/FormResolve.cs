using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteCrud.UI
{
    public class FormResolve
    {
        private static IKernel _ninjectKernel;
        public static void wire(INinjectModule module)
        {
            _ninjectKernel = new StandardKernel(module);
        }
        public static T Resolve<T>()
        {
            return _ninjectKernel.Get<T>();
        }
    }
}
