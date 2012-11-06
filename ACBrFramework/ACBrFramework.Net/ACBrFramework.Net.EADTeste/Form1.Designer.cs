namespace ACBrFramework.Net.EADTeste
{
	partial class Form1
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.grpArquivoDe = new System.Windows.Forms.GroupBox();
			this.lblArquivo = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.btnProcurarArqu = new System.Windows.Forms.Button();
			this.btnVerifArqAssinado = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.btnVersao = new System.Windows.Forms.Button();
			this.txtArqEntrada = new System.Windows.Forms.TextBox();
			this.cmbHash = new System.Windows.Forms.ComboBox();
			this.grpChavePrivada = new System.Windows.Forms.GroupBox();
			this.btnCalcCP = new System.Windows.Forms.Button();
			this.btnGXeECFc = new System.Windows.Forms.Button();
			this.btnME = new System.Windows.Forms.Button();
			this.btnNPChaves = new System.Windows.Forms.Button();
			this.btnGravarCPI = new System.Windows.Forms.Button();
			this.btnLerCPI = new System.Windows.Forms.Button();
			this.txtArqPrivKey = new System.Windows.Forms.TextBox();
			this.txtChavePri = new System.Windows.Forms.TextBox();
			this.grpChavePublica = new System.Windows.Forms.GroupBox();
			this.button7 = new System.Windows.Forms.Button();
			this.btnGravarCPU = new System.Windows.Forms.Button();
			this.btnLerCPU = new System.Windows.Forms.Button();
			this.txtArqPubKey = new System.Windows.Forms.TextBox();
			this.txtChavePub = new System.Windows.Forms.TextBox();
			this.respListBox = new System.Windows.Forms.ListBox();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.messageToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.descriptionToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.acbrEAD = new ACBrFramework.EAD.ACBrEAD();
			this.grpArquivoDe.SuspendLayout();
			this.grpChavePrivada.SuspendLayout();
			this.grpChavePublica.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpArquivoDe
			// 
			this.grpArquivoDe.Controls.Add(this.lblArquivo);
			this.grpArquivoDe.Controls.Add(this.button3);
			this.grpArquivoDe.Controls.Add(this.btnProcurarArqu);
			this.grpArquivoDe.Controls.Add(this.btnVerifArqAssinado);
			this.grpArquivoDe.Controls.Add(this.button2);
			this.grpArquivoDe.Controls.Add(this.button1);
			this.grpArquivoDe.Controls.Add(this.btnVersao);
			this.grpArquivoDe.Controls.Add(this.txtArqEntrada);
			this.grpArquivoDe.Controls.Add(this.cmbHash);
			this.grpArquivoDe.Location = new System.Drawing.Point(12, 286);
			this.grpArquivoDe.Name = "grpArquivoDe";
			this.grpArquivoDe.Size = new System.Drawing.Size(695, 72);
			this.grpArquivoDe.TabIndex = 9;
			this.grpArquivoDe.TabStop = false;
			this.grpArquivoDe.Text = "Arquivo de Entrada";
			// 
			// lblArquivo
			// 
			this.lblArquivo.AutoSize = true;
			this.lblArquivo.Location = new System.Drawing.Point(12, 22);
			this.lblArquivo.Name = "lblArquivo";
			this.lblArquivo.Size = new System.Drawing.Size(46, 13);
			this.lblArquivo.TabIndex = 8;
			this.lblArquivo.Text = "Arquivo:";
			// 
			// button3
			// 
			this.button3.Image = global::ACBrFramework.Net.EADTeste.Properties.Resources.hash;
			this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button3.Location = new System.Drawing.Point(156, 45);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(68, 23);
			this.button3.TabIndex = 7;
			this.button3.Text = "HASH";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// btnProcurarArqu
			// 
			this.btnProcurarArqu.Image = global::ACBrFramework.Net.EADTeste.Properties.Resources.Procurar;
			this.btnProcurarArqu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnProcurarArqu.Location = new System.Drawing.Point(589, 17);
			this.btnProcurarArqu.Name = "btnProcurarArqu";
			this.btnProcurarArqu.Size = new System.Drawing.Size(99, 23);
			this.btnProcurarArqu.TabIndex = 6;
			this.btnProcurarArqu.Text = "Procurar";
			this.btnProcurarArqu.UseVisualStyleBackColor = true;
			this.btnProcurarArqu.Click += new System.EventHandler(this.btnProcurarArqu_Click);
			// 
			// btnVerifArqAssinado
			// 
			this.btnVerifArqAssinado.Image = global::ACBrFramework.Net.EADTeste.Properties.Resources.Verificar;
			this.btnVerifArqAssinado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnVerifArqAssinado.Location = new System.Drawing.Point(519, 45);
			this.btnVerifArqAssinado.Name = "btnVerifArqAssinado";
			this.btnVerifArqAssinado.Size = new System.Drawing.Size(169, 23);
			this.btnVerifArqAssinado.TabIndex = 5;
			this.btnVerifArqAssinado.Text = "Verificar Arquivo Assinado";
			this.btnVerifArqAssinado.UseVisualStyleBackColor = true;
			this.btnVerifArqAssinado.Click += new System.EventHandler(this.btnVerifArqAssinado_Click);
			// 
			// button2
			// 
			this.button2.Image = global::ACBrFramework.Net.EADTeste.Properties.Resources.Assinar;
			this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button2.Location = new System.Drawing.Point(340, 45);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(173, 23);
			this.button2.TabIndex = 4;
			this.button2.Text = "Assinar Arquivo com EAD";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Image = global::ACBrFramework.Net.EADTeste.Properties.Resources.CalcEAD;
			this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button1.Location = new System.Drawing.Point(230, 45);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(104, 23);
			this.button1.TabIndex = 3;
			this.button1.Text = "Calcular EAD";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// btnVersao
			// 
			this.btnVersao.Location = new System.Drawing.Point(5, 45);
			this.btnVersao.Name = "btnVersao";
			this.btnVersao.Size = new System.Drawing.Size(63, 23);
			this.btnVersao.TabIndex = 2;
			this.btnVersao.Text = "Versão";
			this.btnVersao.UseVisualStyleBackColor = true;
			// 
			// txtArqEntrada
			// 
			this.txtArqEntrada.Location = new System.Drawing.Point(64, 19);
			this.txtArqEntrada.Name = "txtArqEntrada";
			this.txtArqEntrada.Size = new System.Drawing.Size(519, 20);
			this.txtArqEntrada.TabIndex = 1;
			// 
			// cmbHash
			// 
			this.cmbHash.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbHash.FormattingEnabled = true;
			this.cmbHash.Location = new System.Drawing.Point(74, 46);
			this.cmbHash.Name = "cmbHash";
			this.cmbHash.Size = new System.Drawing.Size(77, 21);
			this.cmbHash.TabIndex = 0;
			// 
			// grpChavePrivada
			// 
			this.grpChavePrivada.Controls.Add(this.btnCalcCP);
			this.grpChavePrivada.Controls.Add(this.btnGXeECFc);
			this.grpChavePrivada.Controls.Add(this.btnME);
			this.grpChavePrivada.Controls.Add(this.btnNPChaves);
			this.grpChavePrivada.Controls.Add(this.btnGravarCPI);
			this.grpChavePrivada.Controls.Add(this.btnLerCPI);
			this.grpChavePrivada.Controls.Add(this.txtArqPrivKey);
			this.grpChavePrivada.Controls.Add(this.txtChavePri);
			this.grpChavePrivada.Location = new System.Drawing.Point(12, 12);
			this.grpChavePrivada.Name = "grpChavePrivada";
			this.grpChavePrivada.Size = new System.Drawing.Size(695, 134);
			this.grpChavePrivada.TabIndex = 8;
			this.grpChavePrivada.TabStop = false;
			this.grpChavePrivada.Text = "Chave Privada";
			// 
			// btnCalcCP
			// 
			this.btnCalcCP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCalcCP.Image = global::ACBrFramework.Net.EADTeste.Properties.Resources.ChavePub;
			this.btnCalcCP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCalcCP.Location = new System.Drawing.Point(534, 99);
			this.btnCalcCP.Name = "btnCalcCP";
			this.btnCalcCP.Size = new System.Drawing.Size(154, 23);
			this.btnCalcCP.TabIndex = 11;
			this.btnCalcCP.Text = "Calcular Chav.Publica";
			this.btnCalcCP.UseVisualStyleBackColor = true;
			this.btnCalcCP.Click += new System.EventHandler(this.btnCalcCP_Click);
			// 
			// btnGXeECFc
			// 
			this.btnGXeECFc.Image = global::ACBrFramework.Net.EADTeste.Properties.Resources.eECFc;
			this.btnGXeECFc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnGXeECFc.Location = new System.Drawing.Point(534, 70);
			this.btnGXeECFc.Name = "btnGXeECFc";
			this.btnGXeECFc.Size = new System.Drawing.Size(154, 23);
			this.btnGXeECFc.TabIndex = 10;
			this.btnGXeECFc.Text = "Gerar XML eECFc";
			this.btnGXeECFc.UseVisualStyleBackColor = true;
			this.btnGXeECFc.Click += new System.EventHandler(this.btnGXeECFc_Click);
			// 
			// btnME
			// 
			this.btnME.Image = global::ACBrFramework.Net.EADTeste.Properties.Resources.Modulo;
			this.btnME.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnME.Location = new System.Drawing.Point(534, 41);
			this.btnME.Name = "btnME";
			this.btnME.Size = new System.Drawing.Size(154, 23);
			this.btnME.TabIndex = 9;
			this.btnME.Text = "Módulo / Expoente";
			this.btnME.UseVisualStyleBackColor = true;
			this.btnME.Click += new System.EventHandler(this.btnME_Click);
			// 
			// btnNPChaves
			// 
			this.btnNPChaves.Image = global::ACBrFramework.Net.EADTeste.Properties.Resources.Chave;
			this.btnNPChaves.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnNPChaves.Location = new System.Drawing.Point(534, 12);
			this.btnNPChaves.Name = "btnNPChaves";
			this.btnNPChaves.Size = new System.Drawing.Size(154, 23);
			this.btnNPChaves.TabIndex = 8;
			this.btnNPChaves.Text = "Novo Par de Chaves";
			this.btnNPChaves.UseVisualStyleBackColor = true;
			this.btnNPChaves.Click += new System.EventHandler(this.btnNPChaves_Click);
			// 
			// btnGravarCPI
			// 
			this.btnGravarCPI.Image = ((System.Drawing.Image)(resources.GetObject("btnGravarCPI.Image")));
			this.btnGravarCPI.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnGravarCPI.Location = new System.Drawing.Point(409, 12);
			this.btnGravarCPI.Name = "btnGravarCPI";
			this.btnGravarCPI.Size = new System.Drawing.Size(78, 23);
			this.btnGravarCPI.TabIndex = 7;
			this.btnGravarCPI.Text = "Gravar";
			this.btnGravarCPI.UseVisualStyleBackColor = true;
			this.btnGravarCPI.Click += new System.EventHandler(this.btnGravarCPI_Click);
			// 
			// btnLerCPI
			// 
			this.btnLerCPI.Image = ((System.Drawing.Image)(resources.GetObject("btnLerCPI.Image")));
			this.btnLerCPI.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnLerCPI.Location = new System.Drawing.Point(325, 12);
			this.btnLerCPI.Name = "btnLerCPI";
			this.btnLerCPI.Size = new System.Drawing.Size(78, 23);
			this.btnLerCPI.TabIndex = 6;
			this.btnLerCPI.Text = "Ler";
			this.btnLerCPI.UseVisualStyleBackColor = true;
			this.btnLerCPI.Click += new System.EventHandler(this.btnLerCPI_Click);
			// 
			// txtArqPrivKey
			// 
			this.txtArqPrivKey.Location = new System.Drawing.Point(6, 15);
			this.txtArqPrivKey.Name = "txtArqPrivKey";
			this.txtArqPrivKey.Size = new System.Drawing.Size(313, 20);
			this.txtArqPrivKey.TabIndex = 5;
			this.txtArqPrivKey.Text = "priv_key.pem";
			// 
			// txtChavePri
			// 
			this.txtChavePri.Location = new System.Drawing.Point(6, 41);
			this.txtChavePri.Multiline = true;
			this.txtChavePri.Name = "txtChavePri";
			this.txtChavePri.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtChavePri.Size = new System.Drawing.Size(522, 81);
			this.txtChavePri.TabIndex = 4;
			// 
			// grpChavePublica
			// 
			this.grpChavePublica.Controls.Add(this.button7);
			this.grpChavePublica.Controls.Add(this.btnGravarCPU);
			this.grpChavePublica.Controls.Add(this.btnLerCPU);
			this.grpChavePublica.Controls.Add(this.txtArqPubKey);
			this.grpChavePublica.Controls.Add(this.txtChavePub);
			this.grpChavePublica.Location = new System.Drawing.Point(12, 152);
			this.grpChavePublica.Name = "grpChavePublica";
			this.grpChavePublica.Size = new System.Drawing.Size(695, 128);
			this.grpChavePublica.TabIndex = 7;
			this.grpChavePublica.TabStop = false;
			this.grpChavePublica.Text = "Chave Publica";
			// 
			// button7
			// 
			this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button7.Image = global::ACBrFramework.Net.EADTeste.Properties.Resources.eECFc;
			this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button7.Location = new System.Drawing.Point(493, 12);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(195, 23);
			this.button7.TabIndex = 12;
			this.button7.Text = "Calcular Chave de XML eECFc";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// btnGravarCPU
			// 
			this.btnGravarCPU.Image = ((System.Drawing.Image)(resources.GetObject("btnGravarCPU.Image")));
			this.btnGravarCPU.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnGravarCPU.Location = new System.Drawing.Point(409, 13);
			this.btnGravarCPU.Name = "btnGravarCPU";
			this.btnGravarCPU.Size = new System.Drawing.Size(78, 23);
			this.btnGravarCPU.TabIndex = 12;
			this.btnGravarCPU.Text = "Gravar";
			this.btnGravarCPU.UseVisualStyleBackColor = true;
			this.btnGravarCPU.Click += new System.EventHandler(this.btnGravarCPU_Click);
			// 
			// btnLerCPU
			// 
			this.btnLerCPU.Image = ((System.Drawing.Image)(resources.GetObject("btnLerCPU.Image")));
			this.btnLerCPU.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnLerCPU.Location = new System.Drawing.Point(325, 13);
			this.btnLerCPU.Name = "btnLerCPU";
			this.btnLerCPU.Size = new System.Drawing.Size(78, 23);
			this.btnLerCPU.TabIndex = 7;
			this.btnLerCPU.Text = "Ler";
			this.btnLerCPU.UseVisualStyleBackColor = true;
			this.btnLerCPU.Click += new System.EventHandler(this.btnLerCPU_Click);
			// 
			// txtArqPubKey
			// 
			this.txtArqPubKey.Location = new System.Drawing.Point(6, 15);
			this.txtArqPubKey.Name = "txtArqPubKey";
			this.txtArqPubKey.Size = new System.Drawing.Size(313, 20);
			this.txtArqPubKey.TabIndex = 4;
			this.txtArqPubKey.Text = "pub_key.pem";
			// 
			// txtChavePub
			// 
			this.txtChavePub.Location = new System.Drawing.Point(6, 41);
			this.txtChavePub.Multiline = true;
			this.txtChavePub.Name = "txtChavePub";
			this.txtChavePub.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtChavePub.Size = new System.Drawing.Size(682, 75);
			this.txtChavePub.TabIndex = 3;
			// 
			// respListBox
			// 
			this.respListBox.FormattingEnabled = true;
			this.respListBox.Location = new System.Drawing.Point(12, 364);
			this.respListBox.Name = "respListBox";
			this.respListBox.Size = new System.Drawing.Size(695, 108);
			this.respListBox.TabIndex = 10;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.messageToolStripStatusLabel,
            this.descriptionToolStripStatusLabel});
			this.statusStrip1.Location = new System.Drawing.Point(0, 487);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(719, 22);
			this.statusStrip1.TabIndex = 11;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// messageToolStripStatusLabel
			// 
			this.messageToolStripStatusLabel.AutoSize = false;
			this.messageToolStripStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
			this.messageToolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
			this.messageToolStripStatusLabel.Name = "messageToolStripStatusLabel";
			this.messageToolStripStatusLabel.Size = new System.Drawing.Size(150, 17);
			this.messageToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// descriptionToolStripStatusLabel
			// 
			this.descriptionToolStripStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
			this.descriptionToolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
			this.descriptionToolStripStatusLabel.Name = "descriptionToolStripStatusLabel";
			this.descriptionToolStripStatusLabel.Size = new System.Drawing.Size(554, 17);
			this.descriptionToolStripStatusLabel.Spring = true;
			this.descriptionToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// acbrEAD
			// 
			this.acbrEAD.OnGetChavePublica += new System.EventHandler<ACBrFramework.ChaveEventArgs>(this.acbrEAD_OnGetChavePublica);
			this.acbrEAD.OnGetChavePrivada += new System.EventHandler<ACBrFramework.ChaveEventArgs>(this.acbrEAD_OnGetChavePrivada);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(719, 509);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.respListBox);
			this.Controls.Add(this.grpArquivoDe);
			this.Controls.Add(this.grpChavePrivada);
			this.Controls.Add(this.grpChavePublica);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ACBrFramework.Net EAD Demo";
			this.grpArquivoDe.ResumeLayout(false);
			this.grpArquivoDe.PerformLayout();
			this.grpChavePrivada.ResumeLayout(false);
			this.grpChavePrivada.PerformLayout();
			this.grpChavePublica.ResumeLayout(false);
			this.grpChavePublica.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox grpArquivoDe;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button btnProcurarArqu;
		private System.Windows.Forms.Button btnVerifArqAssinado;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button btnVersao;
		private System.Windows.Forms.TextBox txtArqEntrada;
		private System.Windows.Forms.ComboBox cmbHash;
		private System.Windows.Forms.GroupBox grpChavePrivada;
		private System.Windows.Forms.Button btnCalcCP;
		private System.Windows.Forms.Button btnGXeECFc;
		private System.Windows.Forms.Button btnME;
		private System.Windows.Forms.Button btnNPChaves;
		private System.Windows.Forms.Button btnGravarCPI;
		private System.Windows.Forms.Button btnLerCPI;
		private System.Windows.Forms.TextBox txtArqPrivKey;
		private System.Windows.Forms.TextBox txtChavePri;
		private System.Windows.Forms.GroupBox grpChavePublica;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button btnGravarCPU;
		private System.Windows.Forms.Button btnLerCPU;
		private System.Windows.Forms.TextBox txtArqPubKey;
		private System.Windows.Forms.TextBox txtChavePub;
		private System.Windows.Forms.ListBox respListBox;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel messageToolStripStatusLabel;
		private System.Windows.Forms.ToolStripStatusLabel descriptionToolStripStatusLabel;
		private ACBrFramework.EAD.ACBrEAD acbrEAD;
		private System.Windows.Forms.Label lblArquivo;
	}
}

