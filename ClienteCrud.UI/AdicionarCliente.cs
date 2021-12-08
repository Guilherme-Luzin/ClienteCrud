using ClienteCrud.Domain;
using ClienteCrud.Infra;
using Ninject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteCrud.UI
{
    public partial class AdicionarCliente : Form
    {
        //IClienteRepository _ClienteRepository = new ClienteRepository();
        Cliente cliente = new Cliente();
        public Regex validaremail = new Regex(@"^[a-z0-9](([_\.\-]?[a-z0-9]+)*)@([a-z0-9]+)(([\.\-]?[a-z0-9]
                                                +)*)\.([a-z]{2,})$");//validação de email

        private readonly IClienteRepository _clienteRepository;
        int id;
        [Inject()]
        public AdicionarCliente(IClienteRepository ClienteRepository, [Optional] int id = 0)
        {
            this._clienteRepository = ClienteRepository;
            InitializeComponent();
            this.id = id;

            if(this.id > 0)
            {
                var cliente = this._clienteRepository.GetCliente(this.id);
                //Passando valores selecionados para o textbox
                txtId.Text = cliente.Id.ToString();
                txtNome.Text = cliente.Nome.ToString();
                txtIdade.Text = cliente.Idade.ToString();
                txtEmail.Text = cliente.Email.ToString();
            }
        }
        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar1_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.ToString() == string.Empty)
            {
                MessageBox.Show("Adicione um nome para o cliente", "Erro", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else if (txtIdade.Text.ToString() == string.Empty)
            {
                MessageBox.Show("Adicione a idade do cliente", "Erro", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else if (!validaremail.IsMatch(txtEmail.Text))
            {
                MessageBox.Show("Adicione um email válido para o cliente", "Erro", MessageBoxButtons.OK,
MessageBoxIcon.Error);
            }
            else
            {
                if (this.id == 0)
                {
                    //adicionando valores na classe cliente
                    cliente.Nome = txtNome.Text.ToString();
                    cliente.Idade = Convert.ToInt32(txtIdade.Text.ToString());
                    cliente.Email = txtEmail.Text.ToString();

                    this._clienteRepository.Adicionar(cliente);


                    DialogResult = DialogResult.OK;
                    MessageBox.Show("Registro cadastrado com Sucesso", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else if (this.id > 0)
                {
                    cliente.Id = Convert.ToInt32(txtId.Text);
                    cliente.Nome = txtNome.Text;
                    cliente.Idade = Convert.ToInt32(txtIdade.Text.ToString());
                    cliente.Email = txtEmail.Text;

                    this._clienteRepository.Editar(cliente);

                    DialogResult = DialogResult.OK;
                    MessageBox.Show("Regsitro Editado com sucesso", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }
        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
