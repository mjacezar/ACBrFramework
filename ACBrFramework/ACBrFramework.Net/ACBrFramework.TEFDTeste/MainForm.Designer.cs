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
			this.button1 = new System.Windows.Forms.Button();
			this.messageLabel = new System.Windows.Forms.Label();
			this.statusRespLabel = new System.Windows.Forms.Label();
			this.statusReqLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(21, 12);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
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
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(243, 193);
			this.Controls.Add(this.statusReqLabel);
			this.Controls.Add(this.statusRespLabel);
			this.Controls.Add(this.messageLabel);
			this.Controls.Add(this.button1);
			this.Name = "MainForm";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label messageLabel;
		private System.Windows.Forms.Label statusRespLabel;
		private System.Windows.Forms.Label statusReqLabel;
	}
}

