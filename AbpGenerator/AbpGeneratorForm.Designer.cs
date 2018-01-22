namespace AbpGenerator
{
    partial class AbpBackEndGeneratorForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.NomeEntidade = new System.Windows.Forms.TextBox();
            this.Manager = new System.Windows.Forms.TabControl();
            this.Entidade = new System.Windows.Forms.TabPage();
            this.TabelaNomes = new System.Windows.Forms.DataGridView();
            this.NomeDoCampo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoDoCampo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SemTenant = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TenantFacultativa = new System.Windows.Forms.CheckBox();
            this.TenantObrigatoria = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.InterfacesComplementares = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TipoChavePrimaria = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SiglaAplicacao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NomeClassePlural = new System.Windows.Forms.TextBox();
            this.NomeSolucao = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.NomeProjeto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.LeituraEscritaCheck = new System.Windows.Forms.CheckBox();
            this.ApenasLeituraCheck = new System.Windows.Forms.CheckBox();
            this.Manager.SuspendLayout();
            this.Entidade.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TabelaNomes)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Nome da classe no singular";
            // 
            // NomeEntidade
            // 
            this.NomeEntidade.Location = new System.Drawing.Point(11, 75);
            this.NomeEntidade.Name = "NomeEntidade";
            this.NomeEntidade.Size = new System.Drawing.Size(153, 20);
            this.NomeEntidade.TabIndex = 4;
            this.NomeEntidade.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // Manager
            // 
            this.Manager.Controls.Add(this.Entidade);
            this.Manager.Location = new System.Drawing.Point(0, -2);
            this.Manager.Name = "Manager";
            this.Manager.SelectedIndex = 0;
            this.Manager.Size = new System.Drawing.Size(667, 511);
            this.Manager.TabIndex = 8;
            // 
            // Entidade
            // 
            this.Entidade.Controls.Add(this.TabelaNomes);
            this.Entidade.Controls.Add(this.panel2);
            this.Entidade.Controls.Add(this.label7);
            this.Entidade.Controls.Add(this.InterfacesComplementares);
            this.Entidade.Controls.Add(this.label6);
            this.Entidade.Controls.Add(this.TipoChavePrimaria);
            this.Entidade.Controls.Add(this.label2);
            this.Entidade.Controls.Add(this.SiglaAplicacao);
            this.Entidade.Controls.Add(this.label1);
            this.Entidade.Controls.Add(this.NomeClassePlural);
            this.Entidade.Controls.Add(this.NomeSolucao);
            this.Entidade.Controls.Add(this.label5);
            this.Entidade.Controls.Add(this.NomeProjeto);
            this.Entidade.Controls.Add(this.label4);
            this.Entidade.Controls.Add(this.button1);
            this.Entidade.Controls.Add(this.label3);
            this.Entidade.Controls.Add(this.NomeEntidade);
            this.Entidade.Controls.Add(this.panel1);
            this.Entidade.Location = new System.Drawing.Point(4, 22);
            this.Entidade.Name = "Entidade";
            this.Entidade.Padding = new System.Windows.Forms.Padding(3);
            this.Entidade.Size = new System.Drawing.Size(659, 485);
            this.Entidade.TabIndex = 0;
            this.Entidade.Text = "Configuração";
            this.Entidade.UseVisualStyleBackColor = true;
            // 
            // TabelaNomes
            // 
            this.TabelaNomes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TabelaNomes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NomeDoCampo,
            this.TipoDoCampo});
            this.TabelaNomes.Location = new System.Drawing.Point(214, 155);
            this.TabelaNomes.MinimumSize = new System.Drawing.Size(398, 0);
            this.TabelaNomes.Name = "TabelaNomes";
            this.TabelaNomes.Size = new System.Drawing.Size(398, 273);
            this.TabelaNomes.TabIndex = 14;
            this.TabelaNomes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // NomeDoCampo
            // 
            this.NomeDoCampo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NomeDoCampo.FillWeight = 143.1472F;
            this.NomeDoCampo.HeaderText = "Nome do campo";
            this.NomeDoCampo.MinimumWidth = 150;
            this.NomeDoCampo.Name = "NomeDoCampo";
            // 
            // TipoDoCampo
            // 
            this.TipoDoCampo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TipoDoCampo.FillWeight = 456.8528F;
            this.TipoDoCampo.HeaderText = "Tipo do Campo";
            this.TipoDoCampo.MinimumWidth = 150;
            this.TipoDoCampo.Name = "TipoDoCampo";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.SemTenant);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.TenantFacultativa);
            this.panel2.Controls.Add(this.TenantObrigatoria);
            this.panel2.Location = new System.Drawing.Point(437, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(175, 90);
            this.panel2.TabIndex = 24;
            // 
            // SemTenant
            // 
            this.SemTenant.AutoSize = true;
            this.SemTenant.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SemTenant.Location = new System.Drawing.Point(13, 56);
            this.SemTenant.Name = "SemTenant";
            this.SemTenant.Size = new System.Drawing.Size(73, 17);
            this.SemTenant.TabIndex = 13;
            this.SemTenant.Text = "Sem FIltro";
            this.SemTenant.UseVisualStyleBackColor = true;
            this.SemTenant.CheckedChanged += new System.EventHandler(this.SemTenant_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Filtro de Tenant";
            // 
            // TenantFacultativa
            // 
            this.TenantFacultativa.AutoSize = true;
            this.TenantFacultativa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TenantFacultativa.Location = new System.Drawing.Point(90, 33);
            this.TenantFacultativa.Name = "TenantFacultativa";
            this.TenantFacultativa.Size = new System.Drawing.Size(78, 17);
            this.TenantFacultativa.TabIndex = 12;
            this.TenantFacultativa.Text = "Facultativo";
            this.TenantFacultativa.UseVisualStyleBackColor = true;
            this.TenantFacultativa.CheckedChanged += new System.EventHandler(this.TenantFacultativa_CheckedChanged);
            // 
            // TenantObrigatoria
            // 
            this.TenantObrigatoria.AutoSize = true;
            this.TenantObrigatoria.Checked = true;
            this.TenantObrigatoria.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TenantObrigatoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TenantObrigatoria.Location = new System.Drawing.Point(13, 33);
            this.TenantObrigatoria.Name = "TenantObrigatoria";
            this.TenantObrigatoria.Size = new System.Drawing.Size(77, 17);
            this.TenantObrigatoria.TabIndex = 11;
            this.TenantObrigatoria.Text = "Obrigatório";
            this.TenantObrigatoria.UseVisualStyleBackColor = true;
            this.TenantObrigatoria.CheckedChanged += new System.EventHandler(this.TenantObrigatoria_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(434, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Interfaces complementares";
            // 
            // InterfacesComplementares
            // 
            this.InterfacesComplementares.Location = new System.Drawing.Point(437, 128);
            this.InterfacesComplementares.Name = "InterfacesComplementares";
            this.InterfacesComplementares.Size = new System.Drawing.Size(175, 20);
            this.InterfacesComplementares.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(211, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Tipo da chave primaria (Ex: int)";
            // 
            // TipoChavePrimaria
            // 
            this.TipoChavePrimaria.Location = new System.Drawing.Point(214, 128);
            this.TipoChavePrimaria.Name = "TipoChavePrimaria";
            this.TipoChavePrimaria.Size = new System.Drawing.Size(175, 20);
            this.TipoChavePrimaria.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Sigla aplicação (Ex: Mt para metra)";
            // 
            // SiglaAplicacao
            // 
            this.SiglaAplicacao.Location = new System.Drawing.Point(11, 128);
            this.SiglaAplicacao.Name = "SiglaAplicacao";
            this.SiglaAplicacao.Size = new System.Drawing.Size(153, 20);
            this.SiglaAplicacao.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(211, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Nome da classe no plural";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // NomeClassePlural
            // 
            this.NomeClassePlural.Location = new System.Drawing.Point(214, 75);
            this.NomeClassePlural.Name = "NomeClassePlural";
            this.NomeClassePlural.Size = new System.Drawing.Size(175, 20);
            this.NomeClassePlural.TabIndex = 5;
            this.NomeClassePlural.TextChanged += new System.EventHandler(this.NomeClassePlural_TextChanged);
            // 
            // NomeSolucao
            // 
            this.NomeSolucao.Location = new System.Drawing.Point(214, 27);
            this.NomeSolucao.Name = "NomeSolucao";
            this.NomeSolucao.Size = new System.Drawing.Size(175, 20);
            this.NomeSolucao.TabIndex = 3;
            this.NomeSolucao.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(211, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Nome da Aplicação (Ex: MedTiss)";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // NomeProjeto
            // 
            this.NomeProjeto.Location = new System.Drawing.Point(11, 27);
            this.NomeProjeto.Name = "NomeProjeto";
            this.NomeProjeto.Size = new System.Drawing.Size(153, 20);
            this.NomeProjeto.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Nome .sln (Ex: Soitic.Solution)";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(255, 443);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 36);
            this.button1.TabIndex = 15;
            this.button1.Text = "Gerar Arquivos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.LeituraEscritaCheck);
            this.panel1.Controls.Add(this.ApenasLeituraCheck);
            this.panel1.Location = new System.Drawing.Point(11, 155);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(153, 273);
            this.panel1.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Gravação no Banco";
            // 
            // LeituraEscritaCheck
            // 
            this.LeituraEscritaCheck.AutoSize = true;
            this.LeituraEscritaCheck.Checked = true;
            this.LeituraEscritaCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LeituraEscritaCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LeituraEscritaCheck.Location = new System.Drawing.Point(12, 55);
            this.LeituraEscritaCheck.Name = "LeituraEscritaCheck";
            this.LeituraEscritaCheck.Size = new System.Drawing.Size(102, 17);
            this.LeituraEscritaCheck.TabIndex = 10;
            this.LeituraEscritaCheck.Text = "Leitura e Escrita";
            this.LeituraEscritaCheck.UseVisualStyleBackColor = true;
            this.LeituraEscritaCheck.CheckedChanged += new System.EventHandler(this.LeituraEscritaCheck_CheckedChanged);
            // 
            // ApenasLeituraCheck
            // 
            this.ApenasLeituraCheck.AutoSize = true;
            this.ApenasLeituraCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ApenasLeituraCheck.Location = new System.Drawing.Point(12, 31);
            this.ApenasLeituraCheck.Name = "ApenasLeituraCheck";
            this.ApenasLeituraCheck.Size = new System.Drawing.Size(97, 17);
            this.ApenasLeituraCheck.TabIndex = 9;
            this.ApenasLeituraCheck.Text = "Apenas Leitura";
            this.ApenasLeituraCheck.UseVisualStyleBackColor = true;
            this.ApenasLeituraCheck.CheckedChanged += new System.EventHandler(this.ApenasLeituraCheck_CheckedChanged);
            // 
            // AbpBackEndGeneratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 511);
            this.Controls.Add(this.Manager);
            this.Name = "AbpBackEndGeneratorForm";
            this.Text = "AbpGenerator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Manager.ResumeLayout(false);
            this.Entidade.ResumeLayout(false);
            this.Entidade.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TabelaNomes)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NomeEntidade;
        private System.Windows.Forms.TabControl Manager;
        private System.Windows.Forms.TabPage Entidade;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox NomeProjeto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox NomeSolucao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NomeClassePlural;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SiglaAplicacao;
        private System.Windows.Forms.CheckBox ApenasLeituraCheck;
        private System.Windows.Forms.CheckBox LeituraEscritaCheck;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TipoChavePrimaria;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox InterfacesComplementares;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox SemTenant;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox TenantFacultativa;
        private System.Windows.Forms.CheckBox TenantObrigatoria;
        private System.Windows.Forms.DataGridView TabelaNomes;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeDoCampo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoDoCampo;
    }
}

