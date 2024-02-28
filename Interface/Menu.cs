using Interface.Relatórios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void FrmMenu_Resize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            panelRight.BackColor = Color.FromArgb(170, 170, 170);
            timer1.Interval = 1000;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("HH:mm:ss");
            label3.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void editarCadastroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadastros.FrmFuncionarios form = new Cadastros.FrmFuncionarios();
            form.Show();
        }
        private void funcionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadastros.FrmNovoCadastro form = new Cadastros.FrmNovoCadastro();
            form.Show();
        }

        private void emitirTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ticket.FrmEmitir_Ticket form = new Ticket.FrmEmitir_Ticket();
            form.Show();
        }

        private void consultarEEditarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ticket.FrmCadastro_Ticket form = new Ticket.FrmCadastro_Ticket();
            form.Show();
        }

        private void ticketEntreguesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Relatórios.FrmRelatorio form = new Relatórios.FrmRelatorio();
            form.Show();
        }
    }
}
