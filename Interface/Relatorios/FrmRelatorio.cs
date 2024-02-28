using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface.Relatórios
{

    
    public partial class FrmRelatorio : Form
    {
        Edicao edicao;
        public FrmRelatorio()
        {
            InitializeComponent();
            edicao = new Edicao(grid);
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;
        }

        private void FrmRelatorio_Load(object sender, EventArgs e)
        {
            edicao.Listar();
        }

        private void btnGerarRelatorio_Click(object sender, EventArgs e)
        {
            DateTime dataInicial = dateTimePicker1.Value;
            DateTime dataFinal = dateTimePicker2.Value;

        }
    }
}
