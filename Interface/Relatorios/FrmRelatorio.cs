using Interface.Relatorios;
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
        DateTime dataInicial;
        DateTime dataFinal;
        public FrmRelatorio()
        {
            InitializeComponent();
            edicao = new Edicao(grid);
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                DataGridViewRow row = grid.Rows[e.RowIndex];
                string nomeFuncionario = row.Cells[1].Value.ToString();
            }
        }

        private void FrmRelatorio_Load(object sender, EventArgs e)
        {
            edicao.Listar();
        }

        private void btnGerarRelatorio_Click(object sender, EventArgs e)
        {
            FrmResultado form = new FrmResultado(dateTimePicker1.Value, dateTimePicker2.Value, grid);
            form.Show();
        }

        private void txtBuscarNome_TextChanged(object sender, EventArgs e)
        {
            edicao.BuscarNome(txtBuscarNome.Text);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dataInicial = dateTimePicker1.Value;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dataFinal = dateTimePicker2.Value;
        }
    }
}
