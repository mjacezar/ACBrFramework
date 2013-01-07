namespace ACBrFramework.Net.ValidadorTeste
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
			this.cmbTipoDoc = new System.Windows.Forms.ComboBox();
			this.aCBrValidador1 = new ACBrFramework.Validador.ACBrValidador();
			this.chkVazio = new System.Windows.Forms.CheckBox();
			this.btnValidar = new System.Windows.Forms.Button();
			this.lbllabel1 = new System.Windows.Forms.Label();
			this.txtComplemento = new System.Windows.Forms.TextBox();
			this.msgBox = new System.Windows.Forms.ListBox();
			this.txtDocumento = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtIgnoreChars = new System.Windows.Forms.TextBox();
			this.chkTamanho = new System.Windows.Forms.CheckBox();
			this.chkDigito = new System.Windows.Forms.CheckBox();
			this.chkExcecao = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btnFormatar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// cmbTipoDoc
			// 
			this.cmbTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTipoDoc.FormattingEnabled = true;
			this.cmbTipoDoc.Location = new System.Drawing.Point(270, 27);
			this.cmbTipoDoc.Name = "cmbTipoDoc";
			this.cmbTipoDoc.Size = new System.Drawing.Size(121, 21);
			this.cmbTipoDoc.TabIndex = 0;
			this.cmbTipoDoc.SelectedIndexChanged += new System.EventHandler(this.cmbTipoDoc_SelectedIndexChanged);
			// 
			// aCBrValidador1
			// 
			this.aCBrValidador1.AjustarTamanho = false;
			this.aCBrValidador1.Complemento = "";
			this.aCBrValidador1.Documento = "";
			this.aCBrValidador1.ExibeDigitoCorreto = false;
			this.aCBrValidador1.IgnorarChar = "./-";
			this.aCBrValidador1.PermiteVazio = false;
			this.aCBrValidador1.RaiseExcept = false;
			this.aCBrValidador1.TipoDocto = ACBrFramework.Validador.ValTipoDocto.CPF;
			// 
			// chkVazio
			// 
			this.chkVazio.AutoSize = true;
			this.chkVazio.Location = new System.Drawing.Point(145, 68);
			this.chkVazio.Name = "chkVazio";
			this.chkVazio.Size = new System.Drawing.Size(90, 17);
			this.chkVazio.TabIndex = 1;
			this.chkVazio.Text = "Permite Vazio";
			this.chkVazio.UseVisualStyleBackColor = true;
			this.chkVazio.CheckedChanged += new System.EventHandler(this.chkVazio_CheckedChanged);
			// 
			// btnValidar
			// 
			this.btnValidar.Location = new System.Drawing.Point(20, 243);
			this.btnValidar.Name = "btnValidar";
			this.btnValidar.Size = new System.Drawing.Size(75, 23);
			this.btnValidar.TabIndex = 2;
			this.btnValidar.Text = "Validar";
			this.btnValidar.UseVisualStyleBackColor = true;
			this.btnValidar.Click += new System.EventHandler(this.btnValidar_Click);
			// 
			// lbllabel1
			// 
			this.lbllabel1.AutoSize = true;
			this.lbllabel1.Location = new System.Drawing.Point(274, 11);
			this.lbllabel1.Name = "lbllabel1";
			this.lbllabel1.Size = new System.Drawing.Size(28, 13);
			this.lbllabel1.TabIndex = 3;
			this.lbllabel1.Text = "Tipo";
			// 
			// txtComplemento
			// 
			this.txtComplemento.Location = new System.Drawing.Point(164, 27);
			this.txtComplemento.Name = "txtComplemento";
			this.txtComplemento.Size = new System.Drawing.Size(100, 20);
			this.txtComplemento.TabIndex = 4;
			// 
			// msgBox
			// 
			this.msgBox.FormattingEnabled = true;
			this.msgBox.Location = new System.Drawing.Point(20, 142);
			this.msgBox.Name = "msgBox";
			this.msgBox.Size = new System.Drawing.Size(371, 95);
			this.msgBox.TabIndex = 5;
			// 
			// txtDocumento
			// 
			this.txtDocumento.Location = new System.Drawing.Point(12, 27);
			this.txtDocumento.Name = "txtDocumento";
			this.txtDocumento.Size = new System.Drawing.Size(146, 20);
			this.txtDocumento.TabIndex = 6;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(161, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(71, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Complemento";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 11);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(62, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "Documento";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 50);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(67, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "Ignore Chars";
			// 
			// txtIgnoreChars
			// 
			this.txtIgnoreChars.Location = new System.Drawing.Point(15, 66);
			this.txtIgnoreChars.Name = "txtIgnoreChars";
			this.txtIgnoreChars.Size = new System.Drawing.Size(101, 20);
			this.txtIgnoreChars.TabIndex = 10;
			// 
			// chkTamanho
			// 
			this.chkTamanho.AutoSize = true;
			this.chkTamanho.Location = new System.Drawing.Point(145, 91);
			this.chkTamanho.Name = "chkTamanho";
			this.chkTamanho.Size = new System.Drawing.Size(106, 17);
			this.chkTamanho.TabIndex = 11;
			this.chkTamanho.Text = "Ajustar Tamanho";
			this.chkTamanho.UseVisualStyleBackColor = true;
			this.chkTamanho.CheckedChanged += new System.EventHandler(this.chkTamanho_CheckedChanged);
			// 
			// chkDigito
			// 
			this.chkDigito.AutoSize = true;
			this.chkDigito.Location = new System.Drawing.Point(259, 68);
			this.chkDigito.Name = "chkDigito";
			this.chkDigito.Size = new System.Drawing.Size(132, 17);
			this.chkDigito.TabIndex = 12;
			this.chkDigito.Text = "Exibe Digito Calculado";
			this.chkDigito.UseVisualStyleBackColor = true;
			this.chkDigito.CheckedChanged += new System.EventHandler(this.chkDigito_CheckedChanged);
			// 
			// chkExcecao
			// 
			this.chkExcecao.AutoSize = true;
			this.chkExcecao.Location = new System.Drawing.Point(259, 91);
			this.chkExcecao.Name = "chkExcecao";
			this.chkExcecao.Size = new System.Drawing.Size(97, 17);
			this.chkExcecao.TabIndex = 13;
			this.chkExcecao.Text = "Gerar Exceção";
			this.chkExcecao.UseVisualStyleBackColor = true;
			this.chkExcecao.CheckedChanged += new System.EventHandler(this.chkExcecao_CheckedChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(17, 126);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(89, 13);
			this.label4.TabIndex = 14;
			this.label4.Text = "Mensagens Erros";
			// 
			// btnFormatar
			// 
			this.btnFormatar.Location = new System.Drawing.Point(316, 243);
			this.btnFormatar.Name = "btnFormatar";
			this.btnFormatar.Size = new System.Drawing.Size(75, 23);
			this.btnFormatar.TabIndex = 15;
			this.btnFormatar.Text = "Formatar";
			this.btnFormatar.UseVisualStyleBackColor = true;
			this.btnFormatar.Click += new System.EventHandler(this.btnFormatar_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(403, 278);
			this.Controls.Add(this.btnFormatar);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.chkExcecao);
			this.Controls.Add(this.chkDigito);
			this.Controls.Add(this.chkTamanho);
			this.Controls.Add(this.txtIgnoreChars);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtDocumento);
			this.Controls.Add(this.msgBox);
			this.Controls.Add(this.txtComplemento);
			this.Controls.Add(this.lbllabel1);
			this.Controls.Add(this.btnValidar);
			this.Controls.Add(this.chkVazio);
			this.Controls.Add(this.cmbTipoDoc);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Validador de Documentos";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cmbTipoDoc;
		private Validador.ACBrValidador aCBrValidador1;
		private System.Windows.Forms.CheckBox chkVazio;
		private System.Windows.Forms.Button btnValidar;
		private System.Windows.Forms.Label lbllabel1;
		private System.Windows.Forms.TextBox txtComplemento;
		private System.Windows.Forms.ListBox msgBox;
		private System.Windows.Forms.TextBox txtDocumento;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtIgnoreChars;
		private System.Windows.Forms.CheckBox chkTamanho;
		private System.Windows.Forms.CheckBox chkDigito;
		private System.Windows.Forms.CheckBox chkExcecao;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnFormatar;
	}
}

