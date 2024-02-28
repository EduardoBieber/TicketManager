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

namespace Interface.Ticket
{
    
    public partial class FrmCadastro_Ticket : Form
    {
        Edicao edicao;
        private GerenciarTickets gerenciarTickets;
        public FrmCadastro_Ticket()
        {
            InitializeComponent();
            edicao = new Edicao(grid);
        }

        private void grid_Click(object sender, EventArgs e)
        {
            btnEditar.Enabled = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Ticket.FrmEdicao_Ticket form = new Ticket.FrmEdicao_Ticket(gerenciarTickets);
            btnEditar.Enabled = false;
            form.Show();
        }

        private void FrmCadastro_Ticket_Load(object sender, EventArgs e)
        {
            gerenciarTickets = new GerenciarTickets(grid);
            gerenciarTickets.ListarTickets();
        }

        private void txtBuscarNome_TextChanged(object sender, EventArgs e)
        {
            edicao.BuscarNome(txtBuscarNome.Text);
        }
    }
}
