namespace ACBrFramework.Net.CNIEETeste
{
	partial class ProxyForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProxyForm));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.txtHost = new System.Windows.Forms.TextBox();
			this.chkAutenticar = new System.Windows.Forms.CheckBox();
			this.txtPort = new System.Windows.Forms.TextBox();
			this.lbllabel1 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtPass = new System.Windows.Forms.TextBox();
			this.txtUser = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::ACBrFramework.Net.CNIEETeste.Properties.Resources.ProxyImage;
			this.pictureBox1.Location = new System.Drawing.Point(12, 31);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(123, 124);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(265, 213);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancelar.Location = new System.Drawing.Point(155, 213);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(75, 23);
			this.btnCancelar.TabIndex = 2;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.UseVisualStyleBackColor = true;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// txtHost
			// 
			this.txtHost.Location = new System.Drawing.Point(154, 28);
			this.txtHost.Name = "txtHost";
			this.txtHost.Size = new System.Drawing.Size(186, 20);
			this.txtHost.TabIndex = 4;
			// 
			// chkAutenticar
			// 
			this.chkAutenticar.AutoSize = true;
			this.chkAutenticar.Location = new System.Drawing.Point(155, 95);
			this.chkAutenticar.Name = "chkAutenticar";
			this.chkAutenticar.Size = new System.Drawing.Size(173, 17);
			this.chkAutenticar.TabIndex = 5;
			this.chkAutenticar.Text = "Meu proxy requer autenticação";
			this.chkAutenticar.UseVisualStyleBackColor = true;
			this.chkAutenticar.CheckedChanged += new System.EventHandler(this.chkcheckBox1_CheckedChanged);
			// 
			// txtPort
			// 
			this.txtPort.Location = new System.Drawing.Point(154, 67);
			this.txtPort.Name = "txtPort";
			this.txtPort.Size = new System.Drawing.Size(186, 20);
			this.txtPort.TabIndex = 6;
			// 
			// lbllabel1
			// 
			this.lbllabel1.AutoSize = true;
			this.lbllabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbllabel1.Location = new System.Drawing.Point(151, 12);
			this.lbllabel1.Name = "lbllabel1";
			this.lbllabel1.Size = new System.Drawing.Size(33, 13);
			this.lbllabel1.TabIndex = 3;
			this.lbllabel1.Text = "Host";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(151, 51);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(37, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Porta";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(151, 158);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(43, 13);
			this.label2.TabIndex = 11;
			this.label2.Text = "Senha";
			// 
			// txtPass
			// 
			this.txtPass.Enabled = false;
			this.txtPass.Location = new System.Drawing.Point(154, 174);
			this.txtPass.Name = "txtPass";
			this.txtPass.PasswordChar = '*';
			this.txtPass.Size = new System.Drawing.Size(186, 20);
			this.txtPass.TabIndex = 10;
			this.txtPass.UseSystemPasswordChar = true;
			// 
			// txtUser
			// 
			this.txtUser.Enabled = false;
			this.txtUser.Location = new System.Drawing.Point(154, 135);
			this.txtUser.Name = "txtUser";
			this.txtUser.Size = new System.Drawing.Size(186, 20);
			this.txtUser.TabIndex = 9;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(151, 119);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(50, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Usuario";
			// 
			// ProxyForm
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancelar;
			this.ClientSize = new System.Drawing.Size(354, 251);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtPass);
			this.Controls.Add(this.txtUser);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtPort);
			this.Controls.Add(this.chkAutenticar);
			this.Controls.Add(this.txtHost);
			this.Controls.Add(this.lbllabel1);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ProxyForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Configurar o Proxy";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.TextBox txtHost;
		private System.Windows.Forms.CheckBox chkAutenticar;
		private System.Windows.Forms.TextBox txtPort;
		private System.Windows.Forms.Label lbllabel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtPass;
		private System.Windows.Forms.TextBox txtUser;
		private System.Windows.Forms.Label label3;
	}
}