namespace ACBrFramework.ECFTeste
{
	partial class frmVendeItem
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVendeItem));
			this.btnImprimir = new System.Windows.Forms.Button();
			this.txtCodigo = new System.Windows.Forms.TextBox();
			this.lbllabel1 = new System.Windows.Forms.Label();
			this.txtDescricao = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnFechar = new System.Windows.Forms.Button();
			this.txtQuantidade = new System.Windows.Forms.TextBox();
			this.txtPreco = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.grpgroupBox1 = new System.Windows.Forms.GroupBox();
			this.txtDescAcres = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.radValor = new System.Windows.Forms.RadioButton();
			this.radPercentagem = new System.Windows.Forms.RadioButton();
			this.radAcrescimo = new System.Windows.Forms.RadioButton();
			this.radDesconto = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtICMS = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtUnidade = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.grpgroupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnImprimir
			// 
			this.btnImprimir.Location = new System.Drawing.Point(15, 232);
			this.btnImprimir.Name = "btnImprimir";
			this.btnImprimir.Size = new System.Drawing.Size(75, 23);
			this.btnImprimir.TabIndex = 0;
			this.btnImprimir.Text = "Imprimir";
			this.btnImprimir.UseVisualStyleBackColor = true;
			this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
			// 
			// txtCodigo
			// 
			this.txtCodigo.Location = new System.Drawing.Point(90, 20);
			this.txtCodigo.Name = "txtCodigo";
			this.txtCodigo.Size = new System.Drawing.Size(121, 20);
			this.txtCodigo.TabIndex = 2;
			this.txtCodigo.Text = "111222333";
			// 
			// lbllabel1
			// 
			this.lbllabel1.AutoSize = true;
			this.lbllabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbllabel1.Location = new System.Drawing.Point(12, 23);
			this.lbllabel1.Name = "lbllabel1";
			this.lbllabel1.Size = new System.Drawing.Size(46, 13);
			this.lbllabel1.TabIndex = 3;
			this.lbllabel1.Text = "Codigo";
			// 
			// txtDescricao
			// 
			this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtDescricao.Location = new System.Drawing.Point(90, 46);
			this.txtDescricao.Name = "txtDescricao";
			this.txtDescricao.Size = new System.Drawing.Size(359, 20);
			this.txtDescricao.TabIndex = 4;
			this.txtDescricao.Text = "TESTE DE PRODUTO";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 49);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Descrição";
			// 
			// btnFechar
			// 
			this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnFechar.Location = new System.Drawing.Point(154, 232);
			this.btnFechar.Name = "btnFechar";
			this.btnFechar.Size = new System.Drawing.Size(75, 23);
			this.btnFechar.TabIndex = 6;
			this.btnFechar.Text = "Fechar";
			this.btnFechar.UseVisualStyleBackColor = true;
			this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// txtQuantidade
			// 
			this.txtQuantidade.Location = new System.Drawing.Point(90, 72);
			this.txtQuantidade.Name = "txtQuantidade";
			this.txtQuantidade.Size = new System.Drawing.Size(110, 20);
			this.txtQuantidade.TabIndex = 7;
			this.txtQuantidade.Text = "1";
			// 
			// txtPreco
			// 
			this.txtPreco.Location = new System.Drawing.Point(342, 72);
			this.txtPreco.Name = "txtPreco";
			this.txtPreco.Size = new System.Drawing.Size(107, 20);
			this.txtPreco.TabIndex = 8;
			this.txtPreco.Text = "1";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(12, 75);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Quantidade";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(248, 75);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 13);
			this.label3.TabIndex = 10;
			this.label3.Text = "Preço Unitario";
			// 
			// grpgroupBox1
			// 
			this.grpgroupBox1.Controls.Add(this.txtDescAcres);
			this.grpgroupBox1.Controls.Add(this.groupBox2);
			this.grpgroupBox1.Controls.Add(this.radAcrescimo);
			this.grpgroupBox1.Controls.Add(this.radDesconto);
			this.grpgroupBox1.Location = new System.Drawing.Point(15, 124);
			this.grpgroupBox1.Name = "grpgroupBox1";
			this.grpgroupBox1.Size = new System.Drawing.Size(200, 102);
			this.grpgroupBox1.TabIndex = 11;
			this.grpgroupBox1.TabStop = false;
			// 
			// txtDescAcres
			// 
			this.txtDescAcres.Location = new System.Drawing.Point(113, 26);
			this.txtDescAcres.Name = "txtDescAcres";
			this.txtDescAcres.Size = new System.Drawing.Size(81, 20);
			this.txtDescAcres.TabIndex = 15;
			this.txtDescAcres.Text = "0";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.radValor);
			this.groupBox2.Controls.Add(this.radPercentagem);
			this.groupBox2.Location = new System.Drawing.Point(6, 65);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(188, 31);
			this.groupBox2.TabIndex = 13;
			this.groupBox2.TabStop = false;
			// 
			// radValor
			// 
			this.radValor.AutoSize = true;
			this.radValor.Location = new System.Drawing.Point(118, 8);
			this.radValor.Name = "radValor";
			this.radValor.Size = new System.Drawing.Size(49, 17);
			this.radValor.TabIndex = 15;
			this.radValor.TabStop = true;
			this.radValor.Text = "Valor";
			this.radValor.UseVisualStyleBackColor = true;
			// 
			// radPercentagem
			// 
			this.radPercentagem.AutoSize = true;
			this.radPercentagem.Location = new System.Drawing.Point(6, 8);
			this.radPercentagem.Name = "radPercentagem";
			this.radPercentagem.Size = new System.Drawing.Size(88, 17);
			this.radPercentagem.TabIndex = 14;
			this.radPercentagem.TabStop = true;
			this.radPercentagem.Text = "Percentagem";
			this.radPercentagem.UseVisualStyleBackColor = true;
			// 
			// radAcrescimo
			// 
			this.radAcrescimo.AutoSize = true;
			this.radAcrescimo.Location = new System.Drawing.Point(6, 42);
			this.radAcrescimo.Name = "radAcrescimo";
			this.radAcrescimo.Size = new System.Drawing.Size(74, 17);
			this.radAcrescimo.TabIndex = 2;
			this.radAcrescimo.TabStop = true;
			this.radAcrescimo.Text = "Acrescimo";
			this.radAcrescimo.UseVisualStyleBackColor = true;
			// 
			// radDesconto
			// 
			this.radDesconto.AutoSize = true;
			this.radDesconto.Location = new System.Drawing.Point(6, 19);
			this.radDesconto.Name = "radDesconto";
			this.radDesconto.Size = new System.Drawing.Size(71, 17);
			this.radDesconto.TabIndex = 2;
			this.radDesconto.TabStop = true;
			this.radDesconto.Text = "Desconto";
			this.radDesconto.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtICMS);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Location = new System.Drawing.Point(235, 98);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(214, 157);
			this.groupBox1.TabIndex = 12;
			this.groupBox1.TabStop = false;
			// 
			// txtICMS
			// 
			this.txtICMS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtICMS.Location = new System.Drawing.Point(107, 23);
			this.txtICMS.Name = "txtICMS";
			this.txtICMS.Size = new System.Drawing.Size(101, 20);
			this.txtICMS.TabIndex = 15;
			this.txtICMS.Text = "NN";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(6, 26);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(99, 13);
			this.label6.TabIndex = 15;
			this.label6.Text = "&Valor Aliq. ICMS";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(6, 68);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(169, 78);
			this.label5.TabIndex = 10;
			this.label5.Text = "II = Isento\r\nNN = Não Incidencia\r\nFF = Substituição Tributária\r\nSI = Isento ISSQN" +
    "\r\nSN = Não Incidencia ISSQN\r\nSF = Subst.Tributária ISSQN";
			// 
			// txtUnidade
			// 
			this.txtUnidade.Location = new System.Drawing.Point(90, 98);
			this.txtUnidade.Name = "txtUnidade";
			this.txtUnidade.Size = new System.Drawing.Size(110, 20);
			this.txtUnidade.TabIndex = 13;
			this.txtUnidade.Text = "UN";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(12, 101);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(54, 13);
			this.label4.TabIndex = 14;
			this.label4.Text = "Unidade";
			// 
			// frmVendeItem
			// 
			this.AcceptButton = this.btnImprimir;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnFechar;
			this.ClientSize = new System.Drawing.Size(462, 267);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtUnidade);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.grpgroupBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtPreco);
			this.Controls.Add(this.txtQuantidade);
			this.Controls.Add(this.btnFechar);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtDescricao);
			this.Controls.Add(this.lbllabel1);
			this.Controls.Add(this.txtCodigo);
			this.Controls.Add(this.btnImprimir);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmVendeItem";
			this.Text = "Vende Item";
			this.grpgroupBox1.ResumeLayout(false);
			this.grpgroupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnImprimir;
		private System.Windows.Forms.TextBox txtCodigo;
		private System.Windows.Forms.Label lbllabel1;
		private System.Windows.Forms.TextBox txtDescricao;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnFechar;
		private System.Windows.Forms.TextBox txtQuantidade;
		private System.Windows.Forms.TextBox txtPreco;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox grpgroupBox1;
		private System.Windows.Forms.TextBox txtDescAcres;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton radValor;
		private System.Windows.Forms.RadioButton radPercentagem;
		private System.Windows.Forms.RadioButton radAcrescimo;
		private System.Windows.Forms.RadioButton radDesconto;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtICMS;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtUnidade;
		private System.Windows.Forms.Label label4;
	}
}