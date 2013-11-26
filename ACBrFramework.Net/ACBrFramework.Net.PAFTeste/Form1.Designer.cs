namespace ACBrFramework.Net.PAFTeste
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
            this.acbrPAF = new ACBrFramework.PAF.ACBrPAF();
            this.btnTipoP = new System.Windows.Forms.Button();
            this.btnTipoD = new System.Windows.Forms.Button();
            this.btnTipoC = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblUF = new System.Windows.Forms.Label();
            this.txtIE = new System.Windows.Forms.TextBox();
            this.txtCNPJ = new System.Windows.Forms.TextBox();
            this.txtRazaoSocial = new System.Windows.Forms.TextBox();
            this.txtIM = new System.Windows.Forms.TextBox();
            this.txtUF = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.messageToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.descriptionToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.respListBox = new System.Windows.Forms.ListBox();
            this.btnTipoN = new System.Windows.Forms.Button();
            this.btnRegistroECF = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // acbrPAF
            // 
            this.acbrPAF.AAC = null;
            this.acbrPAF.AssinarArquivo = true;
            this.acbrPAF.CurMascara = "";
            this.acbrPAF.Delimitador = "";
            this.acbrPAF.EAD = null;
            this.acbrPAF.Path = "C:\\Program Files (x86)\\Microsoft Visual Studio 10.0\\Common7\\IDE\\";
            this.acbrPAF.TrimString = true;
            this.acbrPAF.OnPAFGetKeyRSA += new System.EventHandler<ACBrFramework.ChaveEventArgs>(this.acbrPAF_OnPAFGetKeyRSA);
            // 
            // btnTipoP
            // 
            this.btnTipoP.Location = new System.Drawing.Point(254, 162);
            this.btnTipoP.Name = "btnTipoP";
            this.btnTipoP.Size = new System.Drawing.Size(75, 23);
            this.btnTipoP.TabIndex = 25;
            this.btnTipoP.Text = "Tipo P";
            this.btnTipoP.UseVisualStyleBackColor = true;
            this.btnTipoP.Click += new System.EventHandler(this.btnTipoP_Click);
            // 
            // btnTipoD
            // 
            this.btnTipoD.Location = new System.Drawing.Point(92, 162);
            this.btnTipoD.Name = "btnTipoD";
            this.btnTipoD.Size = new System.Drawing.Size(75, 23);
            this.btnTipoD.TabIndex = 24;
            this.btnTipoD.Text = "Tipo D";
            this.btnTipoD.UseVisualStyleBackColor = true;
            this.btnTipoD.Click += new System.EventHandler(this.btnTipoD_Click);
            // 
            // btnTipoC
            // 
            this.btnTipoC.Location = new System.Drawing.Point(11, 162);
            this.btnTipoC.Name = "btnTipoC";
            this.btnTipoC.Size = new System.Drawing.Size(75, 23);
            this.btnTipoC.TabIndex = 23;
            this.btnTipoC.Text = "Tipo C";
            this.btnTipoC.UseVisualStyleBackColor = true;
            this.btnTipoC.Click += new System.EventHandler(this.btnTipoC_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(8, 71);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(82, 13);
            this.label21.TabIndex = 22;
            this.label21.Text = "Razão Social";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(326, 11);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(117, 13);
            this.label20.TabIndex = 21;
            this.label20.Text = "Inscrição Municipal";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(193, 11);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(112, 13);
            this.label19.TabIndex = 20;
            this.label19.Text = "Inscrição Estadual";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(64, 11);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(38, 13);
            this.label18.TabIndex = 19;
            this.label18.Text = "CNPJ";
            // 
            // lblUF
            // 
            this.lblUF.AutoSize = true;
            this.lblUF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUF.Location = new System.Drawing.Point(8, 11);
            this.lblUF.Name = "lblUF";
            this.lblUF.Size = new System.Drawing.Size(23, 13);
            this.lblUF.TabIndex = 18;
            this.lblUF.Text = "UF";
            // 
            // txtIE
            // 
            this.txtIE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIE.Location = new System.Drawing.Point(196, 27);
            this.txtIE.MaxLength = 14;
            this.txtIE.Name = "txtIE";
            this.txtIE.Size = new System.Drawing.Size(127, 20);
            this.txtIE.TabIndex = 17;
            this.txtIE.Text = "75792415000144";
            this.txtIE.WordWrap = false;
            // 
            // txtCNPJ
            // 
            this.txtCNPJ.Location = new System.Drawing.Point(67, 27);
            this.txtCNPJ.MaxLength = 14;
            this.txtCNPJ.Name = "txtCNPJ";
            this.txtCNPJ.Size = new System.Drawing.Size(123, 20);
            this.txtCNPJ.TabIndex = 16;
            this.txtCNPJ.Text = "46038555000123";
            this.txtCNPJ.WordWrap = false;
            // 
            // txtRazaoSocial
            // 
            this.txtRazaoSocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRazaoSocial.Location = new System.Drawing.Point(11, 87);
            this.txtRazaoSocial.MaxLength = 50;
            this.txtRazaoSocial.Name = "txtRazaoSocial";
            this.txtRazaoSocial.Size = new System.Drawing.Size(427, 20);
            this.txtRazaoSocial.TabIndex = 15;
            this.txtRazaoSocial.Text = "DEMO ACBRFRAMEWORK.NET PAF";
            this.txtRazaoSocial.WordWrap = false;
            // 
            // txtIM
            // 
            this.txtIM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIM.Location = new System.Drawing.Point(329, 27);
            this.txtIM.MaxLength = 14;
            this.txtIM.Name = "txtIM";
            this.txtIM.Size = new System.Drawing.Size(109, 20);
            this.txtIM.TabIndex = 14;
            this.txtIM.Text = "16784268000100";
            this.txtIM.WordWrap = false;
            // 
            // txtUF
            // 
            this.txtUF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUF.Location = new System.Drawing.Point(11, 27);
            this.txtUF.MaxLength = 2;
            this.txtUF.Name = "txtUF";
            this.txtUF.Size = new System.Drawing.Size(50, 20);
            this.txtUF.TabIndex = 13;
            this.txtUF.Text = "MS";
            this.txtUF.WordWrap = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.messageToolStripStatusLabel,
            this.descriptionToolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 331);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(449, 22);
            this.statusStrip1.TabIndex = 26;
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
            this.descriptionToolStripStatusLabel.Size = new System.Drawing.Size(284, 17);
            this.descriptionToolStripStatusLabel.Spring = true;
            this.descriptionToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // respListBox
            // 
            this.respListBox.FormattingEnabled = true;
            this.respListBox.Location = new System.Drawing.Point(12, 205);
            this.respListBox.Name = "respListBox";
            this.respListBox.Size = new System.Drawing.Size(425, 108);
            this.respListBox.TabIndex = 27;
            // 
            // btnTipoN
            // 
            this.btnTipoN.Location = new System.Drawing.Point(173, 162);
            this.btnTipoN.Name = "btnTipoN";
            this.btnTipoN.Size = new System.Drawing.Size(75, 23);
            this.btnTipoN.TabIndex = 28;
            this.btnTipoN.Text = "Tipo N";
            this.btnTipoN.UseVisualStyleBackColor = true;
            this.btnTipoN.Click += new System.EventHandler(this.btnTipoN_Click);
            // 
            // btnRegistroECF
            // 
            this.btnRegistroECF.Location = new System.Drawing.Point(335, 162);
            this.btnRegistroECF.Name = "btnRegistroECF";
            this.btnRegistroECF.Size = new System.Drawing.Size(102, 23);
            this.btnRegistroECF.TabIndex = 29;
            this.btnRegistroECF.Text = "Registros ECF";
            this.btnRegistroECF.UseVisualStyleBackColor = true;
            this.btnRegistroECF.Click += new System.EventHandler(this.btnRegistroECF_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 353);
            this.Controls.Add(this.btnRegistroECF);
            this.Controls.Add(this.btnTipoN);
            this.Controls.Add(this.respListBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnTipoP);
            this.Controls.Add(this.btnTipoD);
            this.Controls.Add(this.btnTipoC);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.lblUF);
            this.Controls.Add(this.txtIE);
            this.Controls.Add(this.txtCNPJ);
            this.Controls.Add(this.txtRazaoSocial);
            this.Controls.Add(this.txtIM);
            this.Controls.Add(this.txtUF);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ACBrFramework.Net PAF Demo";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private ACBrFramework.PAF.ACBrPAF acbrPAF;
		private System.Windows.Forms.Button btnTipoP;
		private System.Windows.Forms.Button btnTipoD;
		private System.Windows.Forms.Button btnTipoC;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label lblUF;
		private System.Windows.Forms.TextBox txtIE;
		private System.Windows.Forms.TextBox txtCNPJ;
		private System.Windows.Forms.TextBox txtRazaoSocial;
		private System.Windows.Forms.TextBox txtIM;
		private System.Windows.Forms.TextBox txtUF;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel messageToolStripStatusLabel;
		private System.Windows.Forms.ToolStripStatusLabel descriptionToolStripStatusLabel;
		private System.Windows.Forms.ListBox respListBox;
        private System.Windows.Forms.Button btnTipoN;
        private System.Windows.Forms.Button btnRegistroECF;
	}
}

