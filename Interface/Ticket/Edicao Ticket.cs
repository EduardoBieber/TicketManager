using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Interface.GerenciarTickets;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Interface.Ticket
{
    public partial class FrmEdicao_Ticket : Form
    {
        private GerenciarTickets gerenciarTickets;
        public FrmEdicao_Ticket(GerenciarTickets gt)
        {
            InitializeComponent();
            gerenciarTickets = gt;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtBoxID.Text == "")
            {
                MessageBox.Show("Campo ID - Ticket Vazio", "ID", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBoxID.Focus();
                return;
            }

            if (txtBoxNome.Text == "")
            {
                MessageBox.Show("Campo Nome Funcionário Vazio", "NOME", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBoxNome.Focus();
                return;
            }
            if (txtBoxQnt.Text == "")
            {
                MessageBox.Show("Campo Quantidade entregue Vazio", "QUANTIDADE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBoxQnt.Focus();
                return;
            }
            if (txtBoxSituacao.Text == "")
            {
                MessageBox.Show("Campo Situacao Vazio", "SITUACAO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBoxSituacao.Focus();
                return;
            }
            if (txtBoxData.Text == "")
            {
                MessageBox.Show("Campo Data Entregue Vazio", "DATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBoxData.Focus();
                return;
            }
            else
            {
                GerenciarTickets.SalvarEdicaoTicket(txtBoxID.Text, txtBoxNome.Text, int.Parse(txtBoxQnt.Text), txtBoxSituacao.Text);
                MessageBox.Show("Dados Salvos!");
                Close();
            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmEdicao_Ticket_Load(object sender, EventArgs e)
        {
            Tickets ticket = gerenciarTickets.RecuperarID();

            txtBoxID.Text = ticket.Id;
            txtBoxID.TextAlign = HorizontalAlignment.Center;
            txtBoxNome.Text = ticket.Funcionario;
            txtBoxNome.TextAlign = HorizontalAlignment.Center;
            txtBoxQnt.Text = ticket.QntEntregue;
            txtBoxQnt.TextAlign = HorizontalAlignment.Center;
            txtBoxSituacao.Text = ticket.Situacao;
            txtBoxData.Text = ticket.Data;
            txtBoxData.TextAlign = HorizontalAlignment.Center;
        }
    }
}
