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
			this.okButton = new System.Windows.Forms.Button();
			this.messageLabel = new System.Windows.Forms.Label();
			this.statusRespLabel = new System.Windows.Forms.Label();
			this.statusReqLabel = new System.Windows.Forms.Label();
			this.alertLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// okButton
			// 
			this.okButton.Location = new System.Drawing.Point(21, 12);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 0;
			this.okButton.Text = "Inicia";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// messageLabel
			// 
			this.messageLabel.AutoSize = true;
			this.messageLabel.Location = new System.Drawing.Point(21, 42);
			this.messageLabel.Name = "messageLabel";
			this.messageLabel.Size = new System.Drawing.Size(56, 13);
			this.messageLabel.TabIndex = 1;
			this.messageLabel.Text = "[Message]";
			// 
			// statusRespLabel
			// 
			this.statusRespLabel.AutoSize = true;
			this.statusRespLabel.Location = new System.Drawing.Point(21, 73);
			this.statusRespLabel.Name = "statusRespLabel";
			this.statusRespLabel.Size = new System.Drawing.Size(43, 13);
			this.statusRespLabel.TabIndex = 2;
			this.statusRespLabel.Text = "[Status]";
			// 
			// statusReqLabel
			// 
			this.statusReqLabel.AutoSize = true;
			this.statusReqLabel.Location = new System.Drawing.Point(21, 96);
			this.statusReqLabel.Name = "statusReqLabel";
			this.statusReqLabel.Size = new System.Drawing.Size(43, 13);
			this.statusReqLabel.TabIndex = 3;
			this.statusReqLabel.Text = "[Status]";
			// 
			// alertLabel
			// 
			this.alertLabel.Location = new System.Drawing.Point(113, 12);
			this.alertLabel.Name = "alertLabel";
			this.alertLabel.Size = new System.Drawing.Size(316, 150);
			this.alertLabel.TabIndex = 4;
			this.alertLabel.Text = "ATENÇÃO: O componente ACBrTEFD está em fase de desenvolvimento e não deverá ser u" +
    "tilizado em produção!!! ESTE DEMO É PARA FINS DE DESENVOLVIMENTO ... AGUARDE O L" +
    "ANÇAMENTO DO ACBrTEFD";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(462, 193);
			this.Controls.Add(this.alertLabel);
			this.Controls.Add(this.statusReqLabel);
			this.Controls.Add(this.statusRespLabel);
			this.Controls.Add(this.messageLabel);
			this.Controls.Add(this.okButton);
			this.Name = "MainForm";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Label messageLabel;
		private System.Windows.Forms.Label statusRespLabel;
		private System.Windows.Forms.Label statusReqLabel;
		private System.Windows.Forms.Label alertLabel;
	}
}

