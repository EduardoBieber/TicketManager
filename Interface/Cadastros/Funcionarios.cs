using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Interface.Edicao;



namespace Interface.Cadastros
{
    public partial class FrmFuncionarios : Form
    {

        private Edicao edicao;
        public FrmFuncionarios()
        {
            InitializeComponent();
            edicao = new Edicao(grid);
        }

        public TextBox TxtBoxNome { get; set; }
        public TextBox TxtBoxCPF { get; set; }
        public TextBox TxtBoxSituacao { get; set; }
        public object ConsultarCpf { get; private set; }

        private void habilitarCampos()
        {
            txtBoxNome.Enabled = true;
            txtBoxCPF .Enabled = true;
            //txtBoxID .Enabled = true;
            txtBoxSituacao .Enabled = true;
        }

        private void desaabilitarCampos()
        {
            txtBoxNome.Enabled = false;
            txtBoxCPF.Enabled = false;
            txtBoxID.Enabled = false;
            txtBoxSituacao.Enabled = false;
        }

        private void limparCampos()
        {
            txtBoxNome.Text = "";
            txtBoxCPF.Text = "";
            txtBoxID.Text = "";
            txtBoxSituacao.Text = "";
        }

        private void FrmFuncionarios_Load(object sender, EventArgs e)
        {
            edicao.Listar();
        }






        private void btnEditar_Click(object sender, EventArgs e)
        {
            habilitarCampos();
            btnSalvar.Enabled = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtBoxNome.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o campo nome!", "Campo Vazio!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBoxNome.Text = "";
                txtBoxNome.Focus();
                return;
            }

            if (txtBoxCPF.Text == "   .   .   -")
            {
                MessageBox.Show("Preencha o campo CPF!", "Campo Vazio!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBoxCPF.Text = "";
                txtBoxCPF.Focus();
                return;
            }

            string cpf = txtBoxCPF.Text;
            string id = txtBoxID.Text;
            string nome = txtBoxNome.Text;
            string situacao = txtBoxSituacao.Text;

            string cpfOriginal = ConsultaCpf.CpfOriginal(id);

            if (cpf != cpfOriginal)
            {
                if (Validacoes.VerificarExistencia(cpf))
                {
                    MessageBox.Show("Já existe um funcionário com esse CPF!", "Erro ao Cadastrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            Edicao.SalvarEdicao(nome, cpf, id, situacao);

            MessageBox.Show("Cadastro Editado com Sucesso!");
            txtBoxNome.Text = "";
            txtBoxCPF.Text = "   .   .   -";
            txtBoxNome.Focus();
            limparCampos();
            desaabilitarCampos();
            btnEditar.Enabled = false;
            btnSalvar.Enabled = false;
            edicao.Listar();

        }

  

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditar.Enabled = true;

            var funcionario = edicao.RecuperarID();
            string situacao = edicao.RecuperarSituacao();
            txtBoxNome.Text = funcionario.Nome;
            txtBoxCPF.Text = funcionario.CPF;
            txtBoxID.Text = funcionario.Id;
            txtBoxSituacao.Text = funcionario.Situacao;

        }

        private void txtBuscarNome_TextChanged(object sender, EventArgs e)
        {
            edicao.BuscarNome(txtBuscarNome.Text);
        }
    }
}

