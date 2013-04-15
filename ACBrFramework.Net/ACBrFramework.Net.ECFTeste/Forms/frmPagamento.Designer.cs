namespace ACBrFramework.ECFTeste
{
	partial class frmPagamento
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
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPagamento));
			this.lbllabel1 = new System.Windows.Forms.Label();
			this.lbllabel2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lstFPG = new System.Windows.Forms.ListBox();
			this.btnImprimir = new System.Windows.Forms.Button();
			this.txtIndice = new System.Windows.Forms.TextBox();
			this.chkVinculado = new System.Windows.Forms.CheckBox();
			this.txtValor = new System.Windows.Forms.TextBox();
			this.txtObservacao = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.lblTotalCupom = new System.Windows.Forms.Label();
			this.lblTotalPago = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.btnProcurar = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lbllabel1
			// 
			this.lbllabel1.AutoSize = true;
			this.lbllabel1.Location = new System.Drawing.Point(12, 9);
			this.lbllabel1.Name = "lbllabel1";
			this.lbllabel1.Size = new System.Drawing.Size(321, 13);
			this.lbllabel1.TabIndex = 0;
			this.lbllabel1.Text = "- Entre com um ou vários pagamentos até atingir o Total do Cupom";
			// 
			// lbllabel2
			// 
			this.lbllabel2.AutoSize = true;
			this.lbllabel2.Location = new System.Drawing.Point(12, 32);
			this.lbllabel2.Name = "lbllabel2";
			this.lbllabel2.Size = new System.Drawing.Size(367, 13);
			this.lbllabel2.TabIndex = 1;
			this.lbllabel2.Text = "- Se o valor pago for superior ao Total do Cupom será calculado o    TROCO";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(196, 61);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(113, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Formas de Pagamento";
			// 
			// lstFPG
			// 
			this.lstFPG.FormattingEnabled = true;
			this.lstFPG.Location = new System.Drawing.Point(199, 77);
			this.lstFPG.Name = "lstFPG";
			this.lstFPG.Size = new System.Drawing.Size(215, 147);
			this.lstFPG.TabIndex = 3;
			// 
			// btnImprimir
			// 
			this.btnImprimir.Location = new System.Drawing.Point(70, 242);
			this.btnImprimir.Name = "btnImprimir";
			this.btnImprimir.Size = new System.Drawing.Size(75, 23);
			this.btnImprimir.TabIndex = 4;
			this.btnImprimir.Text = "Imprimir";
			this.btnImprimir.UseVisualStyleBackColor = true;
			this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
			// 
			// txtIndice
			// 
			this.txtIndice.Location = new System.Drawing.Point(49, 95);
			this.txtIndice.MaxLength = 2;
			this.txtIndice.Name = "txtIndice";
			this.txtIndice.Size = new System.Drawing.Size(41, 20);
			this.txtIndice.TabIndex = 5;
			// 
			// chkVinculado
			// 
			this.chkVinculado.AutoSize = true;
			this.chkVinculado.Location = new System.Drawing.Point(49, 173);
			this.chkVinculado.Name = "chkVinculado";
			this.chkVinculado.Size = new System.Drawing.Size(109, 17);
			this.chkVinculado.TabIndex = 6;
			this.chkVinculado.Text = "Cupom &Vinculado";
			this.chkVinculado.UseVisualStyleBackColor = true;
			// 
			// txtValor
			// 
			this.txtValor.Location = new System.Drawing.Point(49, 121);
			this.txtValor.Name = "txtValor";
			this.txtValor.Size = new System.Drawing.Size(144, 20);
			this.txtValor.TabIndex = 7;
			this.txtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtObservacao
			// 
			this.txtObservacao.Location = new System.Drawing.Point(49, 147);
			this.txtObservacao.Name = "txtObservacao";
			this.txtObservacao.Size = new System.Drawing.Size(144, 20);
			this.txtObservacao.TabIndex = 8;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(196, 234);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(106, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "TOTAL DO CUPOM:";
			// 
			// lblTotalCupom
			// 
			this.lblTotalCupom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTotalCupom.Location = new System.Drawing.Point(308, 234);
			this.lblTotalCupom.Name = "lblTotalCupom";
			this.lblTotalCupom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.lblTotalCupom.Size = new System.Drawing.Size(106, 13);
			this.lblTotalCupom.TabIndex = 10;
			this.lblTotalCupom.Text = "1000.00";
			// 
			// lblTotalPago
			// 
			this.lblTotalPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTotalPago.Location = new System.Drawing.Point(308, 252);
			this.lblTotalPago.Name = "lblTotalPago";
			this.lblTotalPago.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.lblTotalPago.Size = new System.Drawing.Size(106, 13);
			this.lblTotalPago.TabIndex = 12;
			this.lblTotalPago.Text = "1000.00";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(224, 252);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(78, 13);
			this.label5.TabIndex = 11;
			this.label5.Text = "TOTAL PAGO:";
			// 
			// btnProcurar
			// 
			this.btnProcurar.Image = global::ACBrFramework.ECFTeste.Properties.Resources.Procurar16;
			this.btnProcurar.Location = new System.Drawing.Point(96, 93);
			this.btnProcurar.Name = "btnProcurar";
			this.btnProcurar.Size = new System.Drawing.Size(28, 23);
			this.btnProcurar.TabIndex = 13;
			this.btnProcurar.UseVisualStyleBackColor = true;
			this.btnProcurar.Click += new System.EventHandler(this.btnProcurar_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 98);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(29, 13);
			this.label6.TabIndex = 14;
			this.label6.Text = "&Cod.";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(12, 124);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(31, 13);
			this.label7.TabIndex = 15;
			this.label7.Text = "&Valor";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(12, 150);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(29, 13);
			this.label8.TabIndex = 16;
			this.label8.Text = "&Obs:";
			// 
			// frmPagamento
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(428, 277);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.btnProcurar);
			this.Controls.Add(this.lblTotalPago);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.lblTotalCupom);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtObservacao);
			this.Controls.Add(this.txtValor);
			this.Controls.Add(this.chkVinculado);
			this.Controls.Add(this.txtIndice);
			this.Controls.Add(this.btnImprimir);
			this.Controls.Add(this.lstFPG);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lbllabel2);
			this.Controls.Add(this.lbllabel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmPagamento";
			this.Text = "Efetuar Pagamento";
			this.Load += new System.EventHandler(this.frmPagamento_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lbllabel1;
		private System.Windows.Forms.Label lbllabel2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox lstFPG;
		private System.Windows.Forms.Button btnImprimir;
		private System.Windows.Forms.TextBox txtIndice;
		private System.Windows.Forms.CheckBox chkVinculado;
		private System.Windows.Forms.TextBox txtValor;
		private System.Windows.Forms.TextBox txtObservacao;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblTotalCupom;
		private System.Windows.Forms.Label lblTotalPago;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnProcurar;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
	}
}