using ClienteCrud.Domain;
using ClienteCrud.Infra;
using Ninject;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ClienteCrud.UI
{
    public partial class MenuView : Form
    {
        //IClienteRepository _clienteRepository = new ClienteRepository();
        private readonly IClienteRepository _clienteRepository;
        [Inject()]
        public MenuView(IClienteRepository clienteRepository)
        {
            this._clienteRepository = clienteRepository;
            InitializeComponent();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AdicionarCliente telaAdicionar = FormResolve.Resolve<AdicionarCliente>();
            //AdicionarCliente telaAdicionar = new AdicionarCliente(_clienteRepository);
            if (telaAdicionar.ShowDialog() == DialogResult.OK)
            {
                //atualizar DataGridView
                mostrar.DataSource = null;
                mostrar.DataSource = _clienteRepository.GetAll();
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Deseja realmente fechar o programa?", "confirmação",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                Application.Exit();
            }
        }

        private void btnExc_Click(object sender, EventArgs e)
        {
            if(mostrar.CurrentCell != null)
            {
                var index = mostrar.CurrentRow.Cells[0].Value.ToString();
                if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja apagar o registro?", "Confirmação",
    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    _clienteRepository.Deletar(Convert.ToInt32(index));
                    MessageBox.Show("Registro Deletado com sucesso", "Sucesso", MessageBoxButtons.OK,
    MessageBoxIcon.Information);

                    mostrar.DataSource = null;
                    mostrar.DataSource = _clienteRepository.GetAll();
                }
            }
            else
            {
                MessageBox.Show("Não existe registro para deletar", "erro", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (mostrar.CurrentCell != null)
            {
                var id = mostrar.Rows[mostrar.CurrentCell.RowIndex].Cells["id"].Value.ToString();
                //AdicionarCliente telaEditar = FormResolve.Resolve<AdicionarCliente>();
                AdicionarCliente telaEditar = new AdicionarCliente(_clienteRepository, Convert.ToInt32(id));
                if (telaEditar.ShowDialog() == DialogResult.OK)
                {
                    mostrar.DataSource = null;
                    mostrar.DataSource = _clienteRepository.GetAll();
                }
            }
            else
            {
                MessageBox.Show("Não existe dados para editar", "erro", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void MenuView_Load(object sender, EventArgs e)
        {
            mostrar.DataSource = null;
            mostrar.DataSource = _clienteRepository.GetAll();
        }
    }
}