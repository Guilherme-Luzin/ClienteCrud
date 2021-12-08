using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteCrud.Infra.Migration
{
    [Migration(20211207133100)]
    public class _20211207133100_criando_tabela_de_clientes : MigrationBase
    {
        public override void Up()
        {
            Create.Table("Cliente")
                .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("Nome").AsString().NotNullable()
                .WithColumn("Idade").AsInt32().NotNullable()
                .WithColumn("Email").AsString().NotNullable();

            //Insert.IntoTable("Cliente").Row(new { Nome = "Guilherme", Idade = 20, Email = "guilhermeluzin@hotmail.com" });
            //Insert.IntoTable("Cliente").Row(new { Nome = "Eduardo", Idade = 20, Email = "eduardoluzin@hotmail.com" });
            //Insert.IntoTable("Cliente").Row(new { Nome = "Jordana", Idade = 55, Email = "jordaninha123@gmail.com" });
            //Insert.IntoTable("Cliente").Row(new { Nome = "Joao", Idade = 25, Email = "joaoeopedejeijao@outlook.com" });
            //Insert.IntoTable("Cliente").Row(new { Nome = "Maria", Idade = 17, Email = "mariaseeker@yahoo.com.br" });
        }

        public override void Down()
        {
            throw new NotImplementedException();
            //Delete.Table("Cliente");
        }
    }
}
