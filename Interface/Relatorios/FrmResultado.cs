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

namespace Interface.Relatorios
{
    
    public partial class FrmResultado : Form
    {
        private DateTime dataInicial;
        private DateTime dataFinal;
        private string nomeFuncionario;
        private GerenciarTickets gerenciarTickets;
        public FrmResultado(DateTime dataInicial, DateTime dataFinal, DataGridView grid)
        {

            InitializeComponent();
            this.dataInicial = dataInicial;
            this.dataFinal = dataFinal;
            gerenciarTickets = new GerenciarTickets(grid);

        }

        private void FrmResultado_Load(object sender, EventArgs e)
        {
            GerenciarTickets gerenciarTickets = new GerenciarTickets(grid); 
            gerenciarTickets.FiltrarRelatorio(nomeFuncionario, dataInicial, dataFinal);

        }
        }
    }

