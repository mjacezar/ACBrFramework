namespace ACBrFramework.Net.SpedFiscalTeste
{
  partial class FrmSPEDFiscal
    {
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.Label Label3;
        public System.Windows.Forms.Label Label7;
        public System.Windows.Forms.Label Label8;
        public System.Windows.Forms.TextBox memoError;
        public System.Windows.Forms.TextBox memoTXT;
        public System.Windows.Forms.Button btnError;
        public System.Windows.Forms.Button btnTXT;
        public System.Windows.Forms.Panel Panel1;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.Label Label5;
        public System.Windows.Forms.Label Label6;
        public System.Windows.Forms.TextBox edtFile;
        public System.Windows.Forms.CheckBox cbConcomitante;
        public System.Windows.Forms.TextBox edNotas;
        public System.Windows.Forms.Panel Panel2;
        public System.Windows.Forms.Label Label4;
        public System.Windows.Forms.Button btnB_0;
        public System.Windows.Forms.Button btnB_1;
        public System.Windows.Forms.Button btnB_C;
        public System.Windows.Forms.Button btnB_D;
        public System.Windows.Forms.Button btnB_E;
        public System.Windows.Forms.Button btnB_H;
        public System.Windows.Forms.Button btnB_G;
        public System.Windows.Forms.Button btnB_Completo;
        public System.Windows.Forms.Button btnB_9;
        public System.Windows.Forms.TextBox edBufLinhas;
        public System.Windows.Forms.TextBox edBufNotas;
        public System.Windows.Forms.ProgressBar ProgressBar1;
		public ACBrFramework.Sped.ACBrSpedFiscal ACBrSPEDFiscal1;
        private System.Windows.Forms.ToolTip toolTip1 = null;

        // Clean up any resources being used.
        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                if(components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

#region Windows Form Designer generated code
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.cbConcomitante = new System.Windows.Forms.CheckBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label7 = new System.Windows.Forms.Label();
			this.Label8 = new System.Windows.Forms.Label();
			this.memoError = new System.Windows.Forms.TextBox();
			this.memoTXT = new System.Windows.Forms.TextBox();
			this.btnError = new System.Windows.Forms.Button();
			this.btnTXT = new System.Windows.Forms.Button();
			this.Panel1 = new System.Windows.Forms.Panel();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label5 = new System.Windows.Forms.Label();
			this.Label6 = new System.Windows.Forms.Label();
			this.edtFile = new System.Windows.Forms.TextBox();
			this.edNotas = new System.Windows.Forms.TextBox();
			this.Panel2 = new System.Windows.Forms.Panel();
			this.Label4 = new System.Windows.Forms.Label();
			this.btnB_0 = new System.Windows.Forms.Button();
			this.btnB_1 = new System.Windows.Forms.Button();
			this.btnB_C = new System.Windows.Forms.Button();
			this.btnB_D = new System.Windows.Forms.Button();
			this.btnB_E = new System.Windows.Forms.Button();
			this.btnB_H = new System.Windows.Forms.Button();
			this.btnB_G = new System.Windows.Forms.Button();
			this.btnB_Completo = new System.Windows.Forms.Button();
			this.btnB_9 = new System.Windows.Forms.Button();
			this.edBufLinhas = new System.Windows.Forms.TextBox();
			this.edBufNotas = new System.Windows.Forms.TextBox();
			this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
			this.ACBrSPEDFiscal1 = new ACBrFramework.Sped.ACBrSpedFiscal();
			this.Panel1.SuspendLayout();
			this.Panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// cbConcomitante
			// 
			this.cbConcomitante.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cbConcomitante.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.cbConcomitante.Location = new System.Drawing.Point(355, 30);
			this.cbConcomitante.Name = "cbConcomitante";
			this.cbConcomitante.Size = new System.Drawing.Size(134, 19);
			this.cbConcomitante.TabIndex = 1;
			this.cbConcomitante.Text = "Gerar Concomitante";
			this.toolTip1.SetToolTip(this.cbConcomitante, "Grava os Registros a medida que são alimentados\r\nEconomizando memória. \r\nÚtil par" +
        "a evitar erros em arquivos Enormes");
			this.cbConcomitante.Click += new System.EventHandler(this.cbConcomitante_Click);
			// 
			// Label2
			// 
			this.Label2.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Label2.Location = new System.Drawing.Point(8, 161);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(65, 13);
			this.Label2.TabIndex = 0;
			this.Label2.Text = "Lista de erros";
			// 
			// Label3
			// 
			this.Label3.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Label3.Location = new System.Drawing.Point(8, 265);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(75, 13);
			this.Label3.TabIndex = 1;
			this.Label3.Text = "Arquivo Gerado";
			// 
			// Label7
			// 
			this.Label7.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Label7.Location = new System.Drawing.Point(25, 499);
			this.Label7.Name = "Label7";
			this.Label7.Size = new System.Drawing.Size(63, 13);
			this.Label7.TabIndex = 2;
			this.Label7.Text = "Buffer Linhas";
			// 
			// Label8
			// 
			this.Label8.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Label8.Location = new System.Drawing.Point(130, 499);
			this.Label8.Name = "Label8";
			this.Label8.Size = new System.Drawing.Size(61, 13);
			this.Label8.TabIndex = 3;
			this.Label8.Text = "Buffer Notas";
			// 
			// memoError
			// 
			this.memoError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.memoError.Location = new System.Drawing.Point(8, 178);
			this.memoError.Multiline = true;
			this.memoError.Name = "memoError";
			this.memoError.ReadOnly = true;
			this.memoError.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.memoError.Size = new System.Drawing.Size(737, 83);
			this.memoError.TabIndex = 2;
			this.memoError.TabStop = false;
			// 
			// memoTXT
			// 
			this.memoTXT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.memoTXT.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.memoTXT.Location = new System.Drawing.Point(8, 283);
			this.memoTXT.Multiline = true;
			this.memoTXT.Name = "memoTXT";
			this.memoTXT.ReadOnly = true;
			this.memoTXT.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.memoTXT.Size = new System.Drawing.Size(737, 211);
			this.memoTXT.TabIndex = 3;
			this.memoTXT.TabStop = false;
			this.memoTXT.WordWrap = false;
			// 
			// btnError
			// 
			this.btnError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnError.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.btnError.Location = new System.Drawing.Point(541, 507);
			this.btnError.Name = "btnError";
			this.btnError.Size = new System.Drawing.Size(100, 25);
			this.btnError.TabIndex = 7;
			this.btnError.Text = "Gerar TXT Error";
			this.btnError.UseVisualStyleBackColor = false;
			this.btnError.Click += new System.EventHandler(this.btnError_Click);
			// 
			// btnTXT
			// 
			this.btnTXT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnTXT.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.btnTXT.Location = new System.Drawing.Point(647, 507);
			this.btnTXT.Name = "btnTXT";
			this.btnTXT.Size = new System.Drawing.Size(100, 25);
			this.btnTXT.TabIndex = 8;
			this.btnTXT.Text = "Gerar TXT";
			this.btnTXT.UseVisualStyleBackColor = false;
			this.btnTXT.Click += new System.EventHandler(this.btnTXT_Click);
			// 
			// Panel1
			// 
			this.Panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Panel1.Controls.Add(this.Label1);
			this.Panel1.Controls.Add(this.Label5);
			this.Panel1.Controls.Add(this.Label6);
			this.Panel1.Controls.Add(this.edtFile);
			this.Panel1.Controls.Add(this.cbConcomitante);
			this.Panel1.Controls.Add(this.edNotas);
			this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.Panel1.Location = new System.Drawing.Point(0, 87);
			this.Panel1.Name = "Panel1";
			this.Panel1.Size = new System.Drawing.Size(753, 58);
			this.Panel1.TabIndex = 0;
			// 
			// Label1
			// 
			this.Label1.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Label1.Location = new System.Drawing.Point(22, 14);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(82, 13);
			this.Label1.TabIndex = 0;
			this.Label1.Text = "Nome do Arquivo";
			// 
			// Label5
			// 
			this.Label5.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Label5.Dock = System.Windows.Forms.DockStyle.Top;
			this.Label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.Label5.Location = new System.Drawing.Point(0, 0);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(751, 16);
			this.Label5.TabIndex = 1;
			this.Label5.Text = "1 - Informe o Nome do Arquivo e método de Geração";
			this.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// Label6
			// 
			this.Label6.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Label6.Location = new System.Drawing.Point(526, 14);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(71, 13);
			this.Label6.TabIndex = 2;
			this.Label6.Text = "Num.Notas (C)";
			// 
			// edtFile
			// 
			this.edtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.edtFile.Location = new System.Drawing.Point(22, 28);
			this.edtFile.Name = "edtFile";
			this.edtFile.Size = new System.Drawing.Size(309, 20);
			this.edtFile.TabIndex = 0;
			this.edtFile.Text = "ACBrSpedFiscal.txt";
			this.edtFile.ModifiedChanged += new System.EventHandler(this.edtFile_Changed);
			this.edtFile.Leave += new System.EventHandler(this.edtFile_Changed);
			// 
			// edNotas
			// 
			this.edNotas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.edNotas.Location = new System.Drawing.Point(526, 29);
			this.edNotas.Name = "edNotas";
			this.edNotas.Size = new System.Drawing.Size(72, 20);
			this.edNotas.TabIndex = 2;
			this.edNotas.Text = "2";
			// 
			// Panel2
			// 
			this.Panel2.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Panel2.Controls.Add(this.Label4);
			this.Panel2.Controls.Add(this.btnB_0);
			this.Panel2.Controls.Add(this.btnB_1);
			this.Panel2.Controls.Add(this.btnB_C);
			this.Panel2.Controls.Add(this.btnB_D);
			this.Panel2.Controls.Add(this.btnB_E);
			this.Panel2.Controls.Add(this.btnB_H);
			this.Panel2.Controls.Add(this.btnB_G);
			this.Panel2.Controls.Add(this.btnB_Completo);
			this.Panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.Panel2.Location = new System.Drawing.Point(0, 0);
			this.Panel2.Name = "Panel2";
			this.Panel2.Size = new System.Drawing.Size(753, 87);
			this.Panel2.TabIndex = 1;
			// 
			// Label4
			// 
			this.Label4.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Label4.Dock = System.Windows.Forms.DockStyle.Top;
			this.Label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.Label4.Location = new System.Drawing.Point(0, 0);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(751, 16);
			this.Label4.TabIndex = 0;
			this.Label4.Text = "2 - Clique em cada botão dos Blocos e em seguida no botão Gerar TXT";
			this.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnB_0
			// 
			this.btnB_0.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.btnB_0.Location = new System.Drawing.Point(16, 51);
			this.btnB_0.Name = "btnB_0";
			this.btnB_0.Size = new System.Drawing.Size(100, 25);
			this.btnB_0.TabIndex = 1;
			this.btnB_0.Text = "Registros Bloco 0";
			this.btnB_0.UseVisualStyleBackColor = false;
			this.btnB_0.Click += new System.EventHandler(this.btnB_0_Click);
			// 
			// btnB_1
			// 
			this.btnB_1.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.btnB_1.Enabled = false;
			this.btnB_1.Location = new System.Drawing.Point(635, 51);
			this.btnB_1.Name = "btnB_1";
			this.btnB_1.Size = new System.Drawing.Size(100, 25);
			this.btnB_1.TabIndex = 7;
			this.btnB_1.Text = "Registros Bloco 1";
			this.btnB_1.UseVisualStyleBackColor = false;
			this.btnB_1.Click += new System.EventHandler(this.btnB_1_Click);
			// 
			// btnB_C
			// 
			this.btnB_C.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.btnB_C.Enabled = false;
			this.btnB_C.Location = new System.Drawing.Point(118, 51);
			this.btnB_C.Name = "btnB_C";
			this.btnB_C.Size = new System.Drawing.Size(100, 25);
			this.btnB_C.TabIndex = 2;
			this.btnB_C.Text = "Registros Bloco C";
			this.btnB_C.UseVisualStyleBackColor = false;
			this.btnB_C.Click += new System.EventHandler(this.btnB_C_Click);
			// 
			// btnB_D
			// 
			this.btnB_D.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.btnB_D.Enabled = false;
			this.btnB_D.Location = new System.Drawing.Point(220, 51);
			this.btnB_D.Name = "btnB_D";
			this.btnB_D.Size = new System.Drawing.Size(100, 25);
			this.btnB_D.TabIndex = 3;
			this.btnB_D.Text = "Registros Bloco D";
			this.btnB_D.UseVisualStyleBackColor = false;
			this.btnB_D.Click += new System.EventHandler(this.btnB_D_Click);
			// 
			// btnB_E
			// 
			this.btnB_E.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.btnB_E.Enabled = false;
			this.btnB_E.Location = new System.Drawing.Point(323, 51);
			this.btnB_E.Name = "btnB_E";
			this.btnB_E.Size = new System.Drawing.Size(100, 25);
			this.btnB_E.TabIndex = 4;
			this.btnB_E.Text = "Registros Bloco E";
			this.btnB_E.UseVisualStyleBackColor = false;
			this.btnB_E.Click += new System.EventHandler(this.btnB_E_Click);
			// 
			// btnB_H
			// 
			this.btnB_H.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.btnB_H.Enabled = false;
			this.btnB_H.Location = new System.Drawing.Point(531, 51);
			this.btnB_H.Name = "btnB_H";
			this.btnB_H.Size = new System.Drawing.Size(100, 25);
			this.btnB_H.TabIndex = 6;
			this.btnB_H.Text = "Registros Bloco H";
			this.btnB_H.UseVisualStyleBackColor = false;
			this.btnB_H.Click += new System.EventHandler(this.btnB_H_Click);
			// 
			// btnB_G
			// 
			this.btnB_G.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.btnB_G.Enabled = false;
			this.btnB_G.Location = new System.Drawing.Point(427, 51);
			this.btnB_G.Name = "btnB_G";
			this.btnB_G.Size = new System.Drawing.Size(100, 25);
			this.btnB_G.TabIndex = 5;
			this.btnB_G.Text = "Registros Bloco G";
			this.btnB_G.UseVisualStyleBackColor = false;
			this.btnB_G.Click += new System.EventHandler(this.btnB_G_Click);
			// 
			// btnB_Completo
			// 
			this.btnB_Completo.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.btnB_Completo.Location = new System.Drawing.Point(16, 23);
			this.btnB_Completo.Name = "btnB_Completo";
			this.btnB_Completo.Size = new System.Drawing.Size(719, 25);
			this.btnB_Completo.TabIndex = 0;
			this.btnB_Completo.Text = "Gerar o arquivo do SPED Fiscal completo";
			this.btnB_Completo.UseVisualStyleBackColor = false;
			this.btnB_Completo.Click += new System.EventHandler(this.btnB_Completo_Click);
			// 
			// btnB_9
			// 
			this.btnB_9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnB_9.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.btnB_9.Enabled = false;
			this.btnB_9.Location = new System.Drawing.Point(435, 507);
			this.btnB_9.Name = "btnB_9";
			this.btnB_9.Size = new System.Drawing.Size(100, 25);
			this.btnB_9.TabIndex = 6;
			this.btnB_9.Text = "Gravar Bloco 9";
			this.btnB_9.UseVisualStyleBackColor = false;
			this.btnB_9.Click += new System.EventHandler(this.btnB_9_Click);
			// 
			// edBufLinhas
			// 
			this.edBufLinhas.Location = new System.Drawing.Point(17, 514);
			this.edBufLinhas.Name = "edBufLinhas";
			this.edBufLinhas.Size = new System.Drawing.Size(80, 20);
			this.edBufLinhas.TabIndex = 4;
			this.edBufLinhas.Text = "1000";
			// 
			// edBufNotas
			// 
			this.edBufNotas.Enabled = false;
			this.edBufNotas.Location = new System.Drawing.Point(122, 514);
			this.edBufNotas.Name = "edBufNotas";
			this.edBufNotas.Size = new System.Drawing.Size(80, 20);
			this.edBufNotas.TabIndex = 5;
			this.edBufNotas.Text = "1000";
			// 
			// ProgressBar1
			// 
			this.ProgressBar1.Location = new System.Drawing.Point(198, 155);
			this.ProgressBar1.Name = "ProgressBar1";
			this.ProgressBar1.Size = new System.Drawing.Size(348, 20);
			this.ProgressBar1.TabIndex = 9;
			this.ProgressBar1.Visible = false;
			// 
			// ACBrSPEDFiscal1
			// 
			this.ACBrSPEDFiscal1.Arquivo = "";
			this.ACBrSPEDFiscal1.CurMascara = "#0.00";
			this.ACBrSPEDFiscal1.Delimitador = "|";
			this.ACBrSPEDFiscal1.DT_FIN = new System.DateTime(1899, 12, 30, 0, 0, 0, 0);
			this.ACBrSPEDFiscal1.DT_INI = new System.DateTime(1899, 12, 30, 0, 0, 0, 0);
			this.ACBrSPEDFiscal1.LinhasBuffer = 1000;
			this.ACBrSPEDFiscal1.Path = "C:\\Program Files (x86)\\Microsoft Visual Studio 11.0\\Common7\\IDE\\";
			this.ACBrSPEDFiscal1.TrimString = true;
			this.ACBrSPEDFiscal1.OnError += new System.EventHandler<ACBrFramework.Sped.ErrorEventArgs>(this.ACBrSPEDFiscal1_OnError);
			// 
			// FrmSPEDFiscal
			// 
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.ClientSize = new System.Drawing.Size(753, 540);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.Label7);
			this.Controls.Add(this.Label8);
			this.Controls.Add(this.memoError);
			this.Controls.Add(this.memoTXT);
			this.Controls.Add(this.btnError);
			this.Controls.Add(this.btnTXT);
			this.Controls.Add(this.Panel1);
			this.Controls.Add(this.Panel2);
			this.Controls.Add(this.btnB_9);
			this.Controls.Add(this.edBufLinhas);
			this.Controls.Add(this.edBufNotas);
			this.Controls.Add(this.ProgressBar1);
			this.Font = new System.Drawing.Font("Tahoma", 8F);
			this.Location = new System.Drawing.Point(356, 153);
			this.Name = "FrmSPEDFiscal";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ACBrSpedFiscal - Demo";
			this.Panel1.ResumeLayout(false);
			this.Panel1.PerformLayout();
			this.Panel2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }
#endregion

		private System.ComponentModel.IContainer components;

    }
}
