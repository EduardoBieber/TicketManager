using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xamarin.Forms;
using static Interface.Edicao;

namespace Interface.Ticket
{
    public partial class FrmQtd : Form
    {
        Edicao edicao;
        public FrmQtd(Edicao edicao)
        {
            InitializeComponent();
            this.edicao = edicao;
        }

        private void btnConfirma_Click(object sender, EventArgs e)
        {
            if(txtBoxQtn.Text == "")
            {
                MessageBox.Show("Informe a Quantidade!", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information );
                txtBoxQtn.Focus();
                return;

            }
            else
            {
                string nomeFuncionario = txtBoxNome.Text;
                int quantidade = int.Parse(txtBoxQtn.Text);

                GerenciarTickets.LancarTickets(nomeFuncionario, quantidade);
                MessageBox.Show("Tickets Emitidos com Sucesso!", "Tickets Emitidos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Close();
        }

        private void FrmQtd_Load(object sender, EventArgs e)
        {
            var funcionario = edicao.RecuperarID();
            txtBoxNome.Text = funcionario.Nome;
            txtBoxID.Text = funcionario.Id;
        }
    }
}
