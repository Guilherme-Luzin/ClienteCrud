using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteCrud.Domain
{
    public class Cliente
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Informe o nome do cliente")]
        [StringLength(255, MinimumLength = 3, 
            ErrorMessage = "O nome deve conter no minimo 3 caracteres não numericos")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a idade do cliente")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "Informe o e-mail do cliente")]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido")]
        public string Email { get; set; }
    }
}
