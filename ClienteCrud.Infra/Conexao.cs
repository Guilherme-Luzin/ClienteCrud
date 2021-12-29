using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using LinqToDB;

namespace ClienteCrud.Infra
{
    public class Conexao
    {
        SqlConnection con = new SqlConnection();
        
        //cria a conexão com o banco
        public Conexao() {
            con.ConnectionString = @"Data Source=INVENT069\B1;Initial Catalog=CadastroCliente;Integrated Security=True";
        }

        //Abre a conexão com o banco
        public SqlConnection Conectar()
        {
            if(con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        //Fecha a conexão com o banco
        public void Desconectar()
        {
            if(con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
