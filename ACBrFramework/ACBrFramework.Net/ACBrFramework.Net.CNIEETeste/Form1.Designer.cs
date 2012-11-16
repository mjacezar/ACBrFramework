namespace ACBrFramework.Net.CNIEETeste
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
			this.grpgroupBox1 = new System.Windows.Forms.GroupBox();
			this.btnLocalizar = new System.Windows.Forms.Button();
			this.lbVersao = new System.Windows.Forms.Label();
			this.btnAbrir = new System.Windows.Forms.Button();
			this.txtArquivo = new System.Windows.Forms.TextBox();
			this.txtURL = new System.Windows.Forms.TextBox();
			this.btnDownload = new System.Windows.Forms.Button();
			this.lblNomeDo = new System.Windows.Forms.Label();
			this.lblURLPara = new System.Windows.Forms.Label();
			this.dgvECFs = new System.Windows.Forms.DataGridView();
			this.grpTipoDe = new System.Windows.Forms.GroupBox();
			this.radHTML = new System.Windows.Forms.RadioButton();
			this.radXML = new System.Windows.Forms.RadioButton();
			this.radDSV = new System.Windows.Forms.RadioButton();
			this.radCSV = new System.Windows.Forms.RadioButton();
			this.aCBrCNIEE1 = new ACBrFramework.CNIEE.ACBrCNIEE();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.messageToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.descriptionToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.btnSair = new System.Windows.Forms.Button();
			this.btnListar = new System.Windows.Forms.Button();
			this.btnExportar = new System.Windows.Forms.Button();
			this.btnProxy = new System.Windows.Forms.Button();
			this.grpgroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvECFs)).BeginInit();
			this.grpTipoDe.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpgroupBox1
			// 
			this.grpgroupBox1.Controls.Add(this.btnLocalizar);
			this.grpgroupBox1.Controls.Add(this.lbVersao);
			this.grpgroupBox1.Controls.Add(this.btnAbrir);
			this.grpgroupBox1.Controls.Add(this.txtArquivo);
			this.grpgroupBox1.Controls.Add(this.txtURL);
			this.grpgroupBox1.Controls.Add(this.btnDownload);
			this.grpgroupBox1.Controls.Add(this.lblNomeDo);
			this.grpgroupBox1.Controls.Add(this.lblURLPara);
			this.grpgroupBox1.Location = new System.Drawing.Point(12, 12);
			this.grpgroupBox1.Name = "grpgroupBox1";
			this.grpgroupBox1.Size = new System.Drawing.Size(533, 117);
			this.grpgroupBox1.TabIndex = 0;
			this.grpgroupBox1.TabStop = false;
			this.grpgroupBox1.Text = "Arquivo Tabela_CNIEE.bin";
			// 
			// btnLocalizar
			// 
			this.btnLocalizar.Image = global::ACBrFramework.Net.CNIEETeste.Properties.Resources.Procurar;
			this.btnLocalizar.Location = new System.Drawing.Point(407, 71);
			this.btnLocalizar.Name = "btnLocalizar";
			this.btnLocalizar.Size = new System.Drawing.Size(31, 25);
			this.btnLocalizar.TabIndex = 6;
			this.btnLocalizar.UseVisualStyleBackColor = true;
			this.btnLocalizar.Click += new System.EventHandler(this.button2_Click);
			// 
			// lbVersao
			// 
			this.lbVersao.AutoSize = true;
			this.lbVersao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbVersao.Location = new System.Drawing.Point(384, 97);
			this.lbVersao.Name = "lbVersao";
			this.lbVersao.Size = new System.Drawing.Size(54, 13);
			this.lbVersao.TabIndex = 5;
			this.lbVersao.Text = "Versão: ";
			// 
			// btnAbrir
			// 
			this.btnAbrir.Image = global::ACBrFramework.Net.CNIEETeste.Properties.Resources.Abrir;
			this.btnAbrir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAbrir.Location = new System.Drawing.Point(445, 71);
			this.btnAbrir.Name = "btnAbrir";
			this.btnAbrir.Size = new System.Drawing.Size(82, 23);
			this.btnAbrir.TabIndex = 4;
			this.btnAbrir.Text = "Abrir";
			this.btnAbrir.UseVisualStyleBackColor = true;
			this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
			// 
			// txtArquivo
			// 
			this.txtArquivo.Location = new System.Drawing.Point(9, 74);
			this.txtArquivo.Name = "txtArquivo";
			this.txtArquivo.Size = new System.Drawing.Size(392, 20);
			this.txtArquivo.TabIndex = 3;
			this.txtArquivo.Text = "Tabela_CNIEE.bin";
			// 
			// txtURL
			// 
			this.txtURL.Location = new System.Drawing.Point(9, 31);
			this.txtURL.Name = "txtURL";
			this.txtURL.Size = new System.Drawing.Size(429, 20);
			this.txtURL.TabIndex = 1;
			this.txtURL.Text = "http://www.fazenda.mg.gov.br/empresas/ecf/files/Tabela_CNIEE.bin";
			// 
			// btnDownload
			// 
			this.btnDownload.Image = global::ACBrFramework.Net.CNIEETeste.Properties.Resources.Download;
			this.btnDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnDownload.Location = new System.Drawing.Point(445, 29);
			this.btnDownload.Name = "btnDownload";
			this.btnDownload.Size = new System.Drawing.Size(82, 23);
			this.btnDownload.TabIndex = 2;
			this.btnDownload.Text = "Download";
			this.btnDownload.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnDownload.UseVisualStyleBackColor = true;
			this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
			// 
			// lblNomeDo
			// 
			this.lblNomeDo.AutoSize = true;
			this.lblNomeDo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblNomeDo.Location = new System.Drawing.Point(6, 58);
			this.lblNomeDo.Name = "lblNomeDo";
			this.lblNomeDo.Size = new System.Drawing.Size(158, 13);
			this.lblNomeDo.TabIndex = 1;
			this.lblNomeDo.Text = "Nome do Arquivo em disco";
			// 
			// lblURLPara
			// 
			this.lblURLPara.AutoSize = true;
			this.lblURLPara.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblURLPara.Location = new System.Drawing.Point(6, 16);
			this.lblURLPara.Name = "lblURLPara";
			this.lblURLPara.Size = new System.Drawing.Size(121, 13);
			this.lblURLPara.TabIndex = 0;
			this.lblURLPara.Text = "URL para Download";
			// 
			// dgvECFs
			// 
			this.dgvECFs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvECFs.Location = new System.Drawing.Point(12, 135);
			this.dgvECFs.Name = "dgvECFs";
			this.dgvECFs.Size = new System.Drawing.Size(533, 163);
			this.dgvECFs.TabIndex = 1;
			// 
			// grpTipoDe
			// 
			this.grpTipoDe.Controls.Add(this.radHTML);
			this.grpTipoDe.Controls.Add(this.radXML);
			this.grpTipoDe.Controls.Add(this.radDSV);
			this.grpTipoDe.Controls.Add(this.radCSV);
			this.grpTipoDe.Location = new System.Drawing.Point(12, 304);
			this.grpTipoDe.Name = "grpTipoDe";
			this.grpTipoDe.Size = new System.Drawing.Size(533, 55);
			this.grpTipoDe.TabIndex = 2;
			this.grpTipoDe.TabStop = false;
			this.grpTipoDe.Text = "Tipo de exportação";
			// 
			// radHTML
			// 
			this.radHTML.AutoSize = true;
			this.radHTML.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.radHTML.Location = new System.Drawing.Point(419, 21);
			this.radHTML.Name = "radHTML";
			this.radHTML.Size = new System.Drawing.Size(108, 17);
			this.radHTML.TabIndex = 3;
			this.radHTML.Text = "Formato HTML";
			this.radHTML.UseVisualStyleBackColor = true;
			// 
			// radXML
			// 
			this.radXML.AutoSize = true;
			this.radXML.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.radXML.Location = new System.Drawing.Point(289, 21);
			this.radXML.Name = "radXML";
			this.radXML.Size = new System.Drawing.Size(99, 17);
			this.radXML.TabIndex = 2;
			this.radXML.Text = "Formato XML";
			this.radXML.UseVisualStyleBackColor = true;
			// 
			// radDSV
			// 
			this.radDSV.AutoSize = true;
			this.radDSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.radDSV.Location = new System.Drawing.Point(146, 21);
			this.radDSV.Name = "radDSV";
			this.radDSV.Size = new System.Drawing.Size(99, 17);
			this.radDSV.TabIndex = 1;
			this.radDSV.Text = "Formato DSV";
			this.radDSV.UseVisualStyleBackColor = true;
			// 
			// radCSV
			// 
			this.radCSV.AutoSize = true;
			this.radCSV.Checked = true;
			this.radCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.radCSV.Location = new System.Drawing.Point(9, 21);
			this.radCSV.Name = "radCSV";
			this.radCSV.Size = new System.Drawing.Size(98, 17);
			this.radCSV.TabIndex = 0;
			this.radCSV.TabStop = true;
			this.radCSV.Text = "Formato CSV";
			this.radCSV.UseVisualStyleBackColor = true;
			// 
			// aCBrCNIEE1
			// 
			this.aCBrCNIEE1.ParseText = false;
			this.aCBrCNIEE1.ProxyPort = "8080";
			this.aCBrCNIEE1.URLDownload = "http://www.fazenda.mg.gov.br/empresas/ecf/files/Tabela_CNIEE.bin";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.messageToolStripStatusLabel,
            this.descriptionToolStripStatusLabel});
			this.statusStrip1.Location = new System.Drawing.Point(0, 398);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(557, 22);
			this.statusStrip1.TabIndex = 27;
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
			this.descriptionToolStripStatusLabel.Size = new System.Drawing.Size(392, 17);
			this.descriptionToolStripStatusLabel.Spring = true;
			this.descriptionToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnSair
			// 
			this.btnSair.Image = global::ACBrFramework.Net.CNIEETeste.Properties.Resources.Sair;
			this.btnSair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnSair.Location = new System.Drawing.Point(470, 365);
			this.btnSair.Name = "btnSair";
			this.btnSair.Size = new System.Drawing.Size(75, 23);
			this.btnSair.TabIndex = 8;
			this.btnSair.Text = "Sair";
			this.btnSair.UseVisualStyleBackColor = true;
			this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
			// 
			// btnListar
			// 
			this.btnListar.Image = global::ACBrFramework.Net.CNIEETeste.Properties.Resources.Listar;
			this.btnListar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnListar.Location = new System.Drawing.Point(367, 365);
			this.btnListar.Name = "btnListar";
			this.btnListar.Size = new System.Drawing.Size(75, 23);
			this.btnListar.TabIndex = 7;
			this.btnListar.Text = "Listar";
			this.btnListar.UseVisualStyleBackColor = true;
			// 
			// btnExportar
			// 
			this.btnExportar.Image = global::ACBrFramework.Net.CNIEETeste.Properties.Resources.Exportar;
			this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnExportar.Location = new System.Drawing.Point(286, 365);
			this.btnExportar.Name = "btnExportar";
			this.btnExportar.Size = new System.Drawing.Size(75, 23);
			this.btnExportar.TabIndex = 6;
			this.btnExportar.Text = "Exportar";
			this.btnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnExportar.UseVisualStyleBackColor = true;
			this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
			// 
			// btnProxy
			// 
			this.btnProxy.Image = global::ACBrFramework.Net.CNIEETeste.Properties.Resources.Proxy;
			this.btnProxy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnProxy.Location = new System.Drawing.Point(205, 365);
			this.btnProxy.Name = "btnProxy";
			this.btnProxy.Size = new System.Drawing.Size(75, 23);
			this.btnProxy.TabIndex = 5;
			this.btnProxy.Text = "Proxy";
			this.btnProxy.UseVisualStyleBackColor = true;
			this.btnProxy.Click += new System.EventHandler(this.btnProxy_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(557, 420);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.btnSair);
			this.Controls.Add(this.btnListar);
			this.Controls.Add(this.btnExportar);
			this.Controls.Add(this.btnProxy);
			this.Controls.Add(this.grpTipoDe);
			this.Controls.Add(this.dgvECFs);
			this.Controls.Add(this.grpgroupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ACBrFramework.Net CNIEE Demo";
			this.grpgroupBox1.ResumeLayout(false);
			this.grpgroupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvECFs)).EndInit();
			this.grpTipoDe.ResumeLayout(false);
			this.grpTipoDe.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private CNIEE.ACBrCNIEE aCBrCNIEE1;
		private System.Windows.Forms.GroupBox grpgroupBox1;
		private System.Windows.Forms.Button btnLocalizar;
		private System.Windows.Forms.Label lbVersao;
		private System.Windows.Forms.Button btnAbrir;
		private System.Windows.Forms.TextBox txtArquivo;
		private System.Windows.Forms.TextBox txtURL;
		private System.Windows.Forms.Button btnDownload;
		private System.Windows.Forms.Label lblNomeDo;
		private System.Windows.Forms.Label lblURLPara;
		private System.Windows.Forms.DataGridView dgvECFs;
		private System.Windows.Forms.GroupBox grpTipoDe;
		private System.Windows.Forms.Button btnProxy;
		private System.Windows.Forms.Button btnExportar;
		private System.Windows.Forms.Button btnListar;
		private System.Windows.Forms.Button btnSair;
		private System.Windows.Forms.RadioButton radHTML;
		private System.Windows.Forms.RadioButton radXML;
		private System.Windows.Forms.RadioButton radDSV;
		private System.Windows.Forms.RadioButton radCSV;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel messageToolStripStatusLabel;
		private System.Windows.Forms.ToolStripStatusLabel descriptionToolStripStatusLabel;
	}
}

