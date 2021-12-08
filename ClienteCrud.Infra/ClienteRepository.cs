using ClienteCrud.Domain;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteCrud.Infra
{
    public class ClienteRepository : IClienteRepository
    {
        public void Adicionar(Cliente cliente)
        {
            Conexao conexao = new Conexao();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO Cliente (nome, idade, email) VALUES(@nome, @idade, @email)";

            cmd.Parameters.AddWithValue("@nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@idade", cliente.Idade);
            cmd.Parameters.AddWithValue("@email", cliente.Email);
            try
            {
                cmd.Connection = conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch(SqlException ex) {
                throw ex;
            }
        }

        public void Deletar(int Id)
        {
            Conexao conexao = new Conexao();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "DELETE FROM Cliente WHERE id=@id";
            cmd.Parameters.AddWithValue("@id", Id);
            try 
            {
                cmd.Connection = conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            } catch(SqlException ex) 
            {
                throw ex;
            }
        }

        public void Editar(Cliente cliente)
        {
            Conexao conexao = new Conexao();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "UPDATE Cliente SET nome=@nome, idade=@idade, email=@email " +
                "WHERE id=@id";

            cmd.Parameters.AddWithValue("@id", cliente.Id);
            cmd.Parameters.AddWithValue("@nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@idade", cliente.Idade);
            cmd.Parameters.AddWithValue("@email", cliente.Email);

            try
            {
                cmd.Connection = conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }catch(SqlException ex)
            {
                var x = ex.Message;
            }
        }
        public Cliente GetCliente(int Id)
        {
            Conexao conexao = new Conexao();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT * FROM Cliente WHERE id=@id";
            cmd.Parameters.AddWithValue("@id", Id);

            try
            {
                Cliente cliente = null;
                cmd.Connection = conexao.Conectar();
                using(var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        if (dr.Read())
                        {
                            cliente = new Cliente();
                            cliente.Id = Convert.ToInt32(dr["Id"].ToString());
                            cliente.Nome = dr["Nome"].ToString();
                            cliente.Idade = Convert.ToInt32(dr["Idade"].ToString());
                            cliente.Email = dr["Email"].ToString();
                        }
                    }
                }
                conexao.Desconectar();
                return cliente;
            }catch(SqlException ex)
            {
                throw ex;
            }
        }

        public List<Cliente> GetAll()
        {
            Conexao conexao = new Conexao();
             var con = conexao.Conectar();

             using IDbConnection db = new SqlConnection(con.ConnectionString);

             return db.Query<Cliente>("SELECT * FROM Cliente", commandType: CommandType.Text).ToList();
        }
    }
}
