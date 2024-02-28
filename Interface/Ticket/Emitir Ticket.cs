using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface.Ticket
{
    public partial class FrmEmitir_Ticket : Form
    {
        private Edicao edicao;
        public FrmEmitir_Ticket()
        {
            InitializeComponent();
            edicao = new Edicao(grid);
        }

        private void grid_Click(object sender, EventArgs e)
        {
            btnEmitir.Enabled = true;
        }

        private void btnEmitir_Click(object sender, EventArgs e)
        {

            if (txtBoxSituacao.Text == "I")
            {
                MessageBox.Show("Funcionário inativo. Não é possível emitir ticket.", "Funcionário Inativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Ticket.FrmQtd form = new Ticket.FrmQtd(edicao);
            form.Show();
            btnEmitir.Enabled = false;
        }

        private void FrmEmitir_Ticket_Load(object sender, EventArgs e)
        {
            edicao.Listar();
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEmitir.Enabled = true;

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
