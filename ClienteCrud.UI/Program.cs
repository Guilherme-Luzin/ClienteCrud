using ClienteCrud.Domain;
using ClienteCrud.Infra;
using LinqToDB.Data;
using Ninject;
using Ninject.Modules;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace ClienteCrud.UI
{
    internal static class Program
    {
        private static object assemblies;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DataConnection.DefaultSettings = new MySettings();

            /*//criação
             Ninject.IKernel inject = new StandardKernel();
             inject.Load(Assembly.GetExecutingAssembly());
             //inject.Bind<IClienteRepository>().To<ClienteRepository>();
             inject.Bind<IClienteRepository>().To<LinqToDbClientRepository>();
             //implementação
             var injecao = inject.Get<MenuView>();*/
            FormResolve.wire(FormModule.create());
            FormResolve.Resolve<MenuView>();


            //ApplicationConfiguration.Initialize();
            Application.Run(FormResolve.Resolve<MenuView>());
        }
    }
}