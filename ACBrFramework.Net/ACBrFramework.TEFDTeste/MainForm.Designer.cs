namespace ACBrFramework.TEFDTeste
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.checkBox5 = new System.Windows.Forms.CheckBox();
			this.checkBox4 = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.button9 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.cmbGP = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnFPG = new System.Windows.Forms.Button();
			this.btnAtivar = new System.Windows.Forms.Button();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.btnSerial = new System.Windows.Forms.Button();
			this.cmbModelo = new System.Windows.Forms.ComboBox();
			this.modeloLabel = new System.Windows.Forms.Label();
			this.cmbPorta = new System.Windows.Forms.ComboBox();
			this.portaLabel = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.acBrECF1 = new ACBrFramework.ECF.ACBrECF();
			this.acBrTEFD1 = new ACBrFramework.TEFD.ACBrTEFD();
			this.label1 = new System.Windows.Forms.Label();
			this.respListBox = new System.Windows.Forms.ListBox();
			this.label2 = new System.Windows.Forms.Label();
			this.pgtoList = new System.Windows.Forms.ListBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.messageToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.descriptionToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.pctModelo = new System.Windows.Forms.PictureBox();
			this.button4 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.lblModelo = new System.Windows.Forms.Label();
			this.pctDial = new System.Windows.Forms.PictureBox();
			this.label8 = new System.Windows.Forms.Label();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pctModelo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pctDial)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(736, 219);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.groupBox2);
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(728, 193);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Configurações";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.checkBox5);
			this.groupBox2.Controls.Add(this.checkBox4);
			this.groupBox2.Controls.Add(this.checkBox3);
			this.groupBox2.Controls.Add(this.checkBox2);
			this.groupBox2.Controls.Add(this.checkBox1);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.textBox4);
			this.groupBox2.Controls.Add(this.textBox5);
			this.groupBox2.Controls.Add(this.button9);
			this.groupBox2.Controls.Add(this.button8);
			this.groupBox2.Controls.Add(this.cmbGP);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Location = new System.Drawing.Point(336, 6);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(384, 181);
			this.groupBox2.TabIndex = 11;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "TEF";
			// 
			// checkBox5
			// 
			this.checkBox5.AutoSize = true;
			this.checkBox5.Checked = true;
			this.checkBox5.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox5.Location = new System.Drawing.Point(141, 90);
			this.checkBox5.Name = "checkBox5";
			this.checkBox5.Size = new System.Drawing.Size(119, 17);
			this.checkBox5.TabIndex = 28;
			this.checkBox5.Text = "AutoFinalizarCupom";
			this.checkBox5.UseVisualStyleBackColor = true;
			// 
			// checkBox4
			// 
			this.checkBox4.AutoSize = true;
			this.checkBox4.Location = new System.Drawing.Point(141, 113);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new System.Drawing.Size(114, 17);
			this.checkBox4.TabIndex = 27;
			this.checkBox4.Text = "CHQ em Gerencial";
			this.checkBox4.UseVisualStyleBackColor = true;
			// 
			// checkBox3
			// 
			this.checkBox3.AutoSize = true;
			this.checkBox3.Checked = true;
			this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox3.Location = new System.Drawing.Point(141, 67);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(136, 17);
			this.checkBox3.TabIndex = 26;
			this.checkBox3.Text = "AutoEfetuarPagamento";
			this.checkBox3.UseVisualStyleBackColor = true;
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(141, 44);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(106, 17);
			this.checkBox2.TabIndex = 25;
			this.checkBox2.Text = "Multiplos Cartões";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Location = new System.Drawing.Point(141, 21);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(102, 17);
			this.checkBox1.TabIndex = 24;
			this.checkBox1.Text = "Auto Ativar G.P.";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(286, 67);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(70, 13);
			this.label6.TabIndex = 22;
			this.label6.Text = "EsperaSTS";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(286, 16);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(78, 13);
			this.label7.TabIndex = 23;
			this.label7.Text = "EsperaSleep";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(283, 83);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(81, 20);
			this.textBox4.TabIndex = 21;
			this.textBox4.Text = "7";
			this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(283, 32);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(81, 20);
			this.textBox5.TabIndex = 20;
			this.textBox5.Text = "250";
			this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(26, 88);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(75, 23);
			this.button9.TabIndex = 18;
			this.button9.Text = "Ativar GP";
			this.button9.UseVisualStyleBackColor = true;
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(26, 59);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(75, 23);
			this.button8.TabIndex = 17;
			this.button8.Text = "Inicializar";
			this.button8.UseVisualStyleBackColor = true;
			// 
			// cmbGP
			// 
			this.cmbGP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbGP.FormattingEnabled = true;
			this.cmbGP.Location = new System.Drawing.Point(12, 32);
			this.cmbGP.Name = "cmbGP";
			this.cmbGP.Size = new System.Drawing.Size(113, 21);
			this.cmbGP.TabIndex = 16;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(9, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(78, 13);
			this.label5.TabIndex = 15;
			this.label5.Text = "Selecionar GP:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.btnFPG);
			this.groupBox1.Controls.Add(this.btnAtivar);
			this.groupBox1.Controls.Add(this.textBox3);
			this.groupBox1.Controls.Add(this.textBox2);
			this.groupBox1.Controls.Add(this.btnSerial);
			this.groupBox1.Controls.Add(this.cmbModelo);
			this.groupBox1.Controls.Add(this.modeloLabel);
			this.groupBox1.Controls.Add(this.cmbPorta);
			this.groupBox1.Controls.Add(this.portaLabel);
			this.groupBox1.Location = new System.Drawing.Point(8, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(322, 181);
			this.groupBox1.TabIndex = 10;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "ECF";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(189, 67);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(109, 13);
			this.label4.TabIndex = 19;
			this.label4.Text = "Indice \"CHEQUE\"";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(189, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(108, 13);
			this.label3.TabIndex = 19;
			this.label3.Text = "Indice \"CARTAO\"";
			// 
			// btnFPG
			// 
			this.btnFPG.Location = new System.Drawing.Point(165, 135);
			this.btnFPG.Name = "btnFPG";
			this.btnFPG.Size = new System.Drawing.Size(75, 23);
			this.btnFPG.TabIndex = 11;
			this.btnFPG.Text = "FPG";
			this.btnFPG.UseVisualStyleBackColor = true;
			this.btnFPG.Click += new System.EventHandler(this.btnFPG_Click);
			// 
			// btnAtivar
			// 
			this.btnAtivar.Location = new System.Drawing.Point(50, 135);
			this.btnAtivar.Name = "btnAtivar";
			this.btnAtivar.Size = new System.Drawing.Size(75, 23);
			this.btnAtivar.TabIndex = 12;
			this.btnAtivar.Text = "Ativar";
			this.btnAtivar.UseVisualStyleBackColor = true;
			this.btnAtivar.Click += new System.EventHandler(this.btnAtivar_Click);
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(204, 83);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(81, 20);
			this.textBox3.TabIndex = 18;
			this.textBox3.Text = "3";
			this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(204, 32);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(81, 20);
			this.textBox2.TabIndex = 17;
			this.textBox2.Text = "2";
			this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// btnSerial
			// 
			this.btnSerial.Image = global::ACBrFramework.TEFDTeste.Properties.Resources.serial;
			this.btnSerial.Location = new System.Drawing.Point(132, 75);
			this.btnSerial.Name = "btnSerial";
			this.btnSerial.Size = new System.Drawing.Size(26, 26);
			this.btnSerial.TabIndex = 7;
			this.btnSerial.UseVisualStyleBackColor = true;
			this.btnSerial.Click += new System.EventHandler(this.btnSerial_Click);
			// 
			// cmbModelo
			// 
			this.cmbModelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbModelo.FormattingEnabled = true;
			this.cmbModelo.Location = new System.Drawing.Point(16, 38);
			this.cmbModelo.Name = "cmbModelo";
			this.cmbModelo.Size = new System.Drawing.Size(148, 21);
			this.cmbModelo.TabIndex = 14;
			// 
			// modeloLabel
			// 
			this.modeloLabel.AutoSize = true;
			this.modeloLabel.Location = new System.Drawing.Point(13, 22);
			this.modeloLabel.Name = "modeloLabel";
			this.modeloLabel.Size = new System.Drawing.Size(45, 13);
			this.modeloLabel.TabIndex = 13;
			this.modeloLabel.Text = "Modelo:";
			// 
			// cmbPorta
			// 
			this.cmbPorta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPorta.FormattingEnabled = true;
			this.cmbPorta.Location = new System.Drawing.Point(16, 77);
			this.cmbPorta.Name = "cmbPorta";
			this.cmbPorta.Size = new System.Drawing.Size(109, 21);
			this.cmbPorta.TabIndex = 16;
			// 
			// portaLabel
			// 
			this.portaLabel.AutoSize = true;
			this.portaLabel.Location = new System.Drawing.Point(13, 61);
			this.portaLabel.Name = "portaLabel";
			this.portaLabel.Size = new System.Drawing.Size(35, 13);
			this.portaLabel.TabIndex = 15;
			this.portaLabel.Text = "Porta:";
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(728, 193);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Operação";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// acBrECF1
			// 
			this.acBrECF1.AAC = null;
			this.acBrECF1.AguardaImpressao = false;
			this.acBrECF1.ComandoLog = "ChequePronto";
			this.acBrECF1.DecimaisPreco = 3;
			this.acBrECF1.DecimaisQtd = 3;
			this.acBrECF1.DescricaoGrande = false;
			this.acBrECF1.EAD = null;
			this.acBrECF1.GavetaSinalInvertido = false;
			this.acBrECF1.IntervaloAposComando = 100;
			this.acBrECF1.LinhasEntreCupons = 7;
			this.acBrECF1.Modelo = ACBrFramework.ECF.ModeloECF.Nenhum;
			this.acBrECF1.Operador = "";
			this.acBrECF1.Porta = "COM1";
			this.acBrECF1.TimeOut = 3;
			// 
			// acBrTEFD1
			// 
			this.acBrTEFD1.AutoAtivar = true;
			this.acBrTEFD1.AutoEfetuarPagamento = true;
			this.acBrTEFD1.AutoFinalizarCupom = true;
			this.acBrTEFD1.CHQEmGerencial = false;
			this.acBrTEFD1.GPAtual = ACBrFramework.TEFD.ACBrTEFDTipo.TefDial;
			this.acBrTEFD1.MultiplosCartoes = false;
			this.acBrTEFD1.OnAguardaResp += new System.EventHandler<ACBrFramework.TEFD.AguardaRespEventArgs>(this.tef_OnAguardaResp);
			this.acBrTEFD1.OnExibeMensagem += new System.EventHandler<ACBrFramework.TEFD.ExibeMensagemEventArgs>(this.tef_OnExibeMensagem);
			this.acBrTEFD1.OnBloqueiaMouseTeclado += new System.EventHandler<ACBrFramework.TEFD.BloqueiaMouseTecladoEventArgs>(this.tef_OnBloqueiaMouseTeclado);
			this.acBrTEFD1.OnRestauraFocoAplicacao += new System.EventHandler<ACBrFramework.TEFD.ExecutaAcaoEventArgs>(this.tef_OnRestauraFocoAplicacao);
			this.acBrTEFD1.OnLimpaTeclado += new System.EventHandler<ACBrFramework.TEFD.ExecutaAcaoEventArgs>(this.tef_OnLimpaTeclado);
			this.acBrTEFD1.OnComandaECF += new System.EventHandler<ACBrFramework.TEFD.ComandaECFEventArgs>(this.tef_OnComandaECF);
			this.acBrTEFD1.OnComandaECFSubtotaliza += new System.EventHandler<ACBrFramework.TEFD.ComandaECFSubtotalizaEventArgs>(this.tef_OnComandaECFSubtotaliza);
			this.acBrTEFD1.OnComandaECFPagamento += new System.EventHandler<ACBrFramework.TEFD.ComandaECFPagamentoEventArgs>(this.tef_OnComandaECFPagamento);
			this.acBrTEFD1.OnComandaECFAbreVinculado += new System.EventHandler<ACBrFramework.TEFD.ComandaECFAbreVinculadoEventArgs>(this.tef_OnComandaECFAbreVinculado);
			this.acBrTEFD1.OnComandaECFImprimeVia += new System.EventHandler<ACBrFramework.TEFD.ComandaECFImprimeViaEventArgs>(this.tef_OnComandaECFImprimeVia);
			this.acBrTEFD1.OnInfoECF += new System.EventHandler<ACBrFramework.TEFD.InfoECFEventArgs>(this.tef_OnInfoECF);
			this.acBrTEFD1.OnAntesFinalizarRequisicao += new System.EventHandler<ACBrFramework.TEFD.AntesFinalizarRequisicaoEventArgs>(this.tef_OnAntesFinalizarRequisicao);
			this.acBrTEFD1.OnDepoisConfirmarTransacoes += new System.EventHandler<ACBrFramework.TEFD.DepoisConfirmarTransacoesEventArgs>(this.tef_OnDepoisConfirmarTransacoes);
			this.acBrTEFD1.OnAntesCancelarTransacao += new System.EventHandler<ACBrFramework.TEFD.AntesCancelarTransacaoEventArgs>(this.tef_OnAntesCancelarTransacao);
			this.acBrTEFD1.OnDepoisCancelarTransacoes += new System.EventHandler<ACBrFramework.TEFD.DepoisCancelarTransacoesEventArgs>(this.tef_OnDepoisCancelarTransacoes);
			this.acBrTEFD1.OnMudaEstadoReq += new System.EventHandler<ACBrFramework.TEFD.MudaEstadoReqEventArgs>(this.tef_OnMudaEstadoReq);
			this.acBrTEFD1.OnMudaEstadoResp += new System.EventHandler<ACBrFramework.TEFD.MudaEstadoRespEventArgs>(this.tef_OnMudaEstadoResp);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(586, 222);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(122, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Pagamentos a Fazer";
			// 
			// respListBox
			// 
			this.respListBox.FormattingEnabled = true;
			this.respListBox.Location = new System.Drawing.Point(4, 228);
			this.respListBox.Name = "respListBox";
			this.respListBox.Size = new System.Drawing.Size(552, 173);
			this.respListBox.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(562, 383);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "Acrec/Desc";
			// 
			// pgtoList
			// 
			this.pgtoList.FormattingEnabled = true;
			this.pgtoList.Location = new System.Drawing.Point(565, 244);
			this.pgtoList.Name = "pgtoList";
			this.pgtoList.Size = new System.Drawing.Size(159, 95);
			this.pgtoList.TabIndex = 9;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(643, 380);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(81, 20);
			this.textBox1.TabIndex = 10;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.messageToolStripStatusLabel,
            this.descriptionToolStripStatusLabel});
			this.statusStrip1.Location = new System.Drawing.Point(0, 428);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(736, 22);
			this.statusStrip1.SizingGrip = false;
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
			this.descriptionToolStripStatusLabel.Size = new System.Drawing.Size(571, 17);
			this.descriptionToolStripStatusLabel.Spring = true;
			this.descriptionToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pctModelo
			// 
			this.pctModelo.Image = global::ACBrFramework.TEFDTeste.Properties.Resources._093;
			this.pctModelo.Location = new System.Drawing.Point(4, 407);
			this.pctModelo.Name = "pctModelo";
			this.pctModelo.Size = new System.Drawing.Size(17, 17);
			this.pctModelo.TabIndex = 12;
			this.pctModelo.TabStop = false;
			// 
			// button4
			// 
			this.button4.Image = global::ACBrFramework.TEFDTeste.Properties.Resources._105;
			this.button4.Location = new System.Drawing.Point(666, 348);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(26, 26);
			this.button4.TabIndex = 6;
			this.button4.UseVisualStyleBackColor = true;
			// 
			// button3
			// 
			this.button3.Image = global::ACBrFramework.TEFDTeste.Properties.Resources._024;
			this.button3.Location = new System.Drawing.Point(698, 348);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(26, 26);
			this.button3.TabIndex = 5;
			this.button3.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Image = global::ACBrFramework.TEFDTeste.Properties.Resources._007;
			this.button2.Location = new System.Drawing.Point(597, 348);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(26, 26);
			this.button2.TabIndex = 4;
			this.button2.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Image = global::ACBrFramework.TEFDTeste.Properties.Resources._001;
			this.button1.Location = new System.Drawing.Point(565, 348);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(26, 26);
			this.button1.TabIndex = 3;
			this.button1.UseVisualStyleBackColor = true;
			// 
			// lblModelo
			// 
			this.lblModelo.AutoSize = true;
			this.lblModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblModelo.Location = new System.Drawing.Point(25, 409);
			this.lblModelo.Name = "lblModelo";
			this.lblModelo.Size = new System.Drawing.Size(98, 13);
			this.lblModelo.TabIndex = 13;
			this.lblModelo.Text = "ECF Desativada";
			// 
			// pctDial
			// 
			this.pctDial.Image = global::ACBrFramework.TEFDTeste.Properties.Resources._093;
			this.pctDial.Location = new System.Drawing.Point(129, 407);
			this.pctDial.Name = "pctDial";
			this.pctDial.Size = new System.Drawing.Size(17, 17);
			this.pctDial.TabIndex = 14;
			this.pctDial.TabStop = false;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(152, 409);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(52, 13);
			this.label8.TabIndex = 15;
			this.label8.Text = "Tef Dial";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(736, 450);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.pctDial);
			this.Controls.Add(this.lblModelo);
			this.Controls.Add(this.pctModelo);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.pgtoList);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.respListBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tabControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "Teste TEF - ACBrFramework.NET";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pctModelo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pctDial)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cmbModelo;
        private System.Windows.Forms.Label modeloLabel;
        private System.Windows.Forms.ComboBox cmbPorta;
        private System.Windows.Forms.Label portaLabel;
        private ECF.ACBrECF acBrECF1;
        private TEFD.ACBrTEFD acBrTEFD1;
        private System.Windows.Forms.Button btnSerial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox respListBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox pgtoList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFPG;
        private System.Windows.Forms.Button btnAtivar;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.ComboBox cmbGP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel messageToolStripStatusLabel;
		private System.Windows.Forms.ToolStripStatusLabel descriptionToolStripStatusLabel;
		private System.Windows.Forms.PictureBox pctModelo;
		private System.Windows.Forms.Label lblModelo;
		private System.Windows.Forms.PictureBox pctDial;
		private System.Windows.Forms.Label label8;

    }
}

