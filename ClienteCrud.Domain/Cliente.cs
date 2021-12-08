using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteCrud.Domain
{
    //[Table(Schema = "dbo", Name = "Cliente")]
    public class Cliente
    {
        /*[Column("id"), PrimaryKey, Identity]*/ public int Id { get; set; }
        
        [Required(ErrorMessage = "Informe o nome do cliente")]
        [StringLength(255, MinimumLength = 3, 
            ErrorMessage = "O nome deve conter no minimo 3 caracteres não numericos")]
        /*[Column("nome"), NotNull           ]*/public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a idade do cliente")]
        /*[Column("idade"), NotNull          ]*/ public int Idade { get; set; }

        [Required(ErrorMessage = "Informe o e-mail do cliente")]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido")]
        /*[Column("email"), NotNull          ]*/ public string Email { get; set; }
    }
}
