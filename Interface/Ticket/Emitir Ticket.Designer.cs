namespace Interface.Ticket
{
    partial class FrmEmitir_Ticket
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEmitir_Ticket));
            this.txtBuscarNome = new System.Windows.Forms.TextBox();
            this.txtBuscar = new System.Windows.Forms.Label();
            this.txtBoxSituacao = new System.Windows.Forms.ComboBox();
            this.txtSituacao = new System.Windows.Forms.Label();
            this.txtBoxID = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.Label();
            this.txtBoxCPF = new System.Windows.Forms.MaskedTextBox();
            this.txtCPF = new System.Windows.Forms.Label();
            this.txtBoxNome = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.Label();
            this.grid = new System.Windows.Forms.DataGridView();
            this.btnEmitir = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEmitir)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBuscarNome
            // 
            this.txtBuscarNome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscarNome.Location = new System.Drawing.Point(461, 15);
            this.txtBuscarNome.Name = "txtBuscarNome";
            this.txtBuscarNome.Size = new System.Drawing.Size(317, 20);
            this.txtBuscarNome.TabIndex = 63;
            this.txtBuscarNome.TextChanged += new System.EventHandler(this.txtBuscarNome_TextChanged);
            // 
            // txtBuscar
            // 
            this.txtBuscar.AutoSize = true;
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(323, 15);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(109, 17);
            this.txtBuscar.TabIndex = 62;
            this.txtBuscar.Text = "Buscar Nome:";
            // 
            // txtBoxSituacao
            // 
            this.txtBoxSituacao.Enabled = false;
            this.txtBoxSituacao.FormattingEnabled = true;
            this.txtBoxSituacao.Items.AddRange(new object[] {
            "ATIVO",
            "INATIVO"});
            this.txtBoxSituacao.Location = new System.Drawing.Point(98, 228);
            this.txtBoxSituacao.Name = "txtBoxSituacao";
            this.txtBoxSituacao.Size = new System.Drawing.Size(165, 21);
            this.txtBoxSituacao.TabIndex = 72;
            // 
            // txtSituacao
            // 
            this.txtSituacao.AutoSize = true;
            this.txtSituacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSituacao.Location = new System.Drawing.Point(10, 228);
            this.txtSituacao.Name = "txtSituacao";
            this.txtSituacao.Size = new System.Drawing.Size(71, 17);
            this.txtSituacao.TabIndex = 76;
            this.txtSituacao.Text = "Situação";
            // 
            // txtBoxID
            // 
            this.txtBoxID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxID.Enabled = false;
            this.txtBoxID.Location = new System.Drawing.Point(98, 186);
            this.txtBoxID.Name = "txtBoxID";
            this.txtBoxID.Size = new System.Drawing.Size(165, 20);
            this.txtBoxID.TabIndex = 71;
            // 
            // txtID
            // 
            this.txtID.AutoSize = true;
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(10, 186);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(28, 17);
            this.txtID.TabIndex = 75;
            this.txtID.Text = "ID:";
            // 
            // txtBoxCPF
            // 
            this.txtBoxCPF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxCPF.Enabled = false;
            this.txtBoxCPF.Location = new System.Drawing.Point(98, 142);
            this.txtBoxCPF.Mask = "000,000,000-00";
            this.txtBoxCPF.Name = "txtBoxCPF";
            this.txtBoxCPF.Size = new System.Drawing.Size(165, 20);
            this.txtBoxCPF.TabIndex = 70;
            // 
            // txtCPF
            // 
            this.txtCPF.AutoSize = true;
            this.txtCPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCPF.Location = new System.Drawing.Point(10, 145);
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(42, 17);
            this.txtCPF.TabIndex = 74;
            this.txtCPF.Text = "CPF:";
            // 
            // txtBoxNome
            // 
            this.txtBoxNome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxNome.Enabled = false;
            this.txtBoxNome.Location = new System.Drawing.Point(98, 97);
            this.txtBoxNome.Name = "txtBoxNome";
            this.txtBoxNome.Size = new System.Drawing.Size(165, 20);
            this.txtBoxNome.TabIndex = 69;
            // 
            // txtNome
            // 
            this.txtNome.AutoSize = true;
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(10, 97);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(54, 17);
            this.txtNome.TabIndex = 73;
            this.txtNome.Text = "Nome:";
            // 
            // grid
            // 
            this.grid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Location = new System.Drawing.Point(285, 97);
            this.grid.Name = "grid";
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(493, 261);
            this.grid.TabIndex = 77;
            this.grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellClick);
            this.grid.Click += new System.EventHandler(this.grid_Click);
            // 
            // btnEmitir
            // 
            this.btnEmitir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEmitir.BackgroundImage")));
            this.btnEmitir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEmitir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEmitir.Enabled = false;
            this.btnEmitir.Location = new System.Drawing.Point(326, 366);
            this.btnEmitir.Name = "btnEmitir";
            this.btnEmitir.Size = new System.Drawing.Size(51, 46);
            this.btnEmitir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnEmitir.TabIndex = 78;
            this.btnEmitir.TabStop = false;
            this.btnEmitir.Click += new System.EventHandler(this.btnEmitir_Click);
            // 
            // FrmEmitir_Ticket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 450);
            this.Controls.Add(this.btnEmitir);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.txtBoxSituacao);
            this.Controls.Add(this.txtSituacao);
            this.Controls.Add(this.txtBoxID);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtBoxCPF);
            this.Controls.Add(this.txtCPF);
            this.Controls.Add(this.txtBoxNome);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtBuscarNome);
            this.Controls.Add(this.txtBuscar);
            this.MaximizeBox = false;
            this.Name = "FrmEmitir_Ticket";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Emissão de Ticket para Funcionário";
            this.Load += new System.EventHandler(this.FrmEmitir_Ticket_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEmitir)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtBuscarNome;
        private System.Windows.Forms.Label txtBuscar;
        private System.Windows.Forms.ComboBox txtBoxSituacao;
        private System.Windows.Forms.Label txtSituacao;
        private System.Windows.Forms.TextBox txtBoxID;
        private System.Windows.Forms.Label txtID;
        private System.Windows.Forms.MaskedTextBox txtBoxCPF;
        private System.Windows.Forms.Label txtCPF;
        private System.Windows.Forms.TextBox txtBoxNome;
        private System.Windows.Forms.Label txtNome;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.PictureBox btnEmitir;
    }
}