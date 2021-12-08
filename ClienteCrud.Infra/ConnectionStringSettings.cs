using LinqToDB;
using LinqToDB.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteCrud.Infra
{
    public class ConnectionStringSettings : IConnectionStringSettings
    {
        public string ConnectionString { get; set; }

        public string Name { get; set; }

        public string? ProviderName { get; set; }

        public bool IsGlobal => false;
    }
    public class MySettings : ILinqToDBSettings
    {
        public IEnumerable<IDataProviderSettings> DataProviders => Enumerable.Empty<IDataProviderSettings>();

        public string? DefaultConfiguration => "SqlServer";

        public string? DefaultDataProvider => "SqlServer";

        public IEnumerable<IConnectionStringSettings> ConnectionStrings
        {
            get
            {
                yield return
                    new ConnectionStringSettings
                    {
                        Name = "CadastroCliente",
                        ProviderName = "System.Data.SqlCliente",
                        ConnectionString =
                @"Data Source=INVENT017;Initial Catalog=CadastroCliente;Integrated Security=True"
                    };
            }
        }
    }
}
