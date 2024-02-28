using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace Interface.Cadastros
{
    public partial class FrmNovoCadastro : Form
    {


        public FrmNovoCadastro()
        {
            InitializeComponent();
        }

        private void FrmNovoCadastro_Load(object sender, EventArgs e)
        {
            txtBoxNome.Focus();
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

            if (txtBoxCPF.Text== "   .   .   -")
            {
                MessageBox.Show("Preencha o campo CPF!", "Campo Vazio!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBoxCPF.Text = "";
                txtBoxCPF.Focus();
                return;
            }

            if (Validacoes.VerificarExistencia(txtBoxCPF.Text))
            {
                MessageBox.Show("CPF já cadastrado!", "Erro ao Cadastrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            Cadastro.Cadastrar(txtBoxNome.Text, txtBoxCPF.Text);


            MessageBox.Show("Cadastro Salvo com Sucesso!");
            txtBoxNome.Text = "";
            txtBoxCPF.Text = "   .   .   -";
            txtBoxNome.Focus();

        }
    }
}
