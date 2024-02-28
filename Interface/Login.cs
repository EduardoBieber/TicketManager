using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            panel_login.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel_login.Location = new Point((this.Width - panel_login.Width) / 2, (this.Height - panel_login.Height) / 2);
            panel_login.Visible = true;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            ChamarLogin();
        }

        private void buttonLogin_KeyDown(object sender, KeyEventArgs e) // verificar depois porque nao esta dando certo com ENTER
        {
            if (e.KeyCode == Keys.Enter)
            {
                ChamarLogin();
            }
        }

        private void ChamarLogin()
        {
            if (txtUsuario.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o Usuário", "Campo Vazio!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsuario.Text = "";
                txtUsuario.Focus();
                return;
            }

            if (txtSenha.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha a Senha", "Campo Vazio!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSenha.Text = "";
                txtSenha.Focus();
                return;
            }

            if(txtUsuario.Text == "admin" && txtSenha.Text == "admin123")
            {
                FrmMenu form = new FrmMenu();
                //this.Hide();
                Limpar();
                form.Show();
            }
            else
            {
                MessageBox.Show("Usuario ou Senha incorretos!", "Erro Login!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSenha.Text = "";
                txtUsuario.Focus();
                return;
            }

           
        }

        private void Limpar()
        {
            txtUsuario.Text = "";
            txtSenha.Text = "";
            txtUsuario.Focus();
        }

        private void FrmLogin_Resize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
