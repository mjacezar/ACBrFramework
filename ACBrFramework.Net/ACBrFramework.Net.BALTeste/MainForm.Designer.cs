namespace ACBrFramework.Net.BALTeste
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
			this.velocidadeComboBox = new System.Windows.Forms.ComboBox();
			this.velocidadeLabel = new System.Windows.Forms.Label();
			this.monitorarCheckBox = new System.Windows.Forms.CheckBox();
			this.portaComboBox = new System.Windows.Forms.ComboBox();
			this.modeloComboBox = new System.Windows.Forms.ComboBox();
			this.portaLabel = new System.Windows.Forms.Label();
			this.modeloLabel = new System.Windows.Forms.Label();
			this.acbrBAL = new ACBrFramework.ACBrBAL();
			this.pesoLabel = new System.Windows.Forms.Label();
			this.pesoValueLabel = new System.Windows.Forms.Label();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.messageToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.descriptionToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.ativarCheckButton = new System.Windows.Forms.CheckBox();
			this.readButton = new System.Windows.Forms.Button();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// velocidadeComboBox
			// 
			this.velocidadeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.velocidadeComboBox.FormattingEnabled = true;
			this.velocidadeComboBox.Location = new System.Drawing.Point(306, 28);
			this.velocidadeComboBox.Name = "velocidadeComboBox";
			this.velocidadeComboBox.Size = new System.Drawing.Size(109, 21);
			this.velocidadeComboBox.TabIndex = 23;
			// 
			// velocidadeLabel
			// 
			this.velocidadeLabel.AutoSize = true;
			this.velocidadeLabel.Location = new System.Drawing.Point(303, 12);
			this.velocidadeLabel.Name = "velocidadeLabel";
			this.velocidadeLabel.Size = new System.Drawing.Size(63, 13);
			this.velocidadeLabel.TabIndex = 22;
			this.velocidadeLabel.Text = "Velocidade:";
			// 
			// monitorarCheckBox
			// 
			this.monitorarCheckBox.AutoSize = true;
			this.monitorarCheckBox.Location = new System.Drawing.Point(12, 64);
			this.monitorarCheckBox.Name = "monitorarCheckBox";
			this.monitorarCheckBox.Size = new System.Drawing.Size(111, 17);
			this.monitorarCheckBox.TabIndex = 21;
			this.monitorarCheckBox.Text = "Monitorar balança";
			this.monitorarCheckBox.UseVisualStyleBackColor = true;
			this.monitorarCheckBox.CheckedChanged += new System.EventHandler(this.monitorarCheckBox_CheckedChanged);
			// 
			// portaComboBox
			// 
			this.portaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.portaComboBox.FormattingEnabled = true;
			this.portaComboBox.Location = new System.Drawing.Point(177, 28);
			this.portaComboBox.Name = "portaComboBox";
			this.portaComboBox.Size = new System.Drawing.Size(109, 21);
			this.portaComboBox.TabIndex = 16;
			// 
			// modeloComboBox
			// 
			this.modeloComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.modeloComboBox.FormattingEnabled = true;
			this.modeloComboBox.Location = new System.Drawing.Point(12, 28);
			this.modeloComboBox.Name = "modeloComboBox";
			this.modeloComboBox.Size = new System.Drawing.Size(148, 21);
			this.modeloComboBox.TabIndex = 14;
			// 
			// portaLabel
			// 
			this.portaLabel.AutoSize = true;
			this.portaLabel.Location = new System.Drawing.Point(174, 12);
			this.portaLabel.Name = "portaLabel";
			this.portaLabel.Size = new System.Drawing.Size(35, 13);
			this.portaLabel.TabIndex = 15;
			this.portaLabel.Text = "Porta:";
			// 
			// modeloLabel
			// 
			this.modeloLabel.AutoSize = true;
			this.modeloLabel.Location = new System.Drawing.Point(9, 12);
			this.modeloLabel.Name = "modeloLabel";
			this.modeloLabel.Size = new System.Drawing.Size(45, 13);
			this.modeloLabel.TabIndex = 13;
			this.modeloLabel.Text = "Modelo:";
			// 
			// acbrBAL
			// 
			this.acbrBAL.Modelo = ACBrFramework.ModeloBal.Nenhum;
			this.acbrBAL.MonitoraBalanca = false;
			this.acbrBAL.Porta = "COM1";
			this.acbrBAL.OnLePeso += new System.EventHandler<ACBrFramework.LePesoEventArgs>(this.acbrBAL_OnLePeso);
			// 
			// pesoLabel
			// 
			this.pesoLabel.AutoSize = true;
			this.pesoLabel.Location = new System.Drawing.Point(9, 102);
			this.pesoLabel.Name = "pesoLabel";
			this.pesoLabel.Size = new System.Drawing.Size(34, 13);
			this.pesoLabel.TabIndex = 24;
			this.pesoLabel.Text = "Peso:";
			// 
			// pesoValueLabel
			// 
			this.pesoValueLabel.AutoSize = true;
			this.pesoValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.pesoValueLabel.Location = new System.Drawing.Point(7, 115);
			this.pesoValueLabel.Name = "pesoValueLabel";
			this.pesoValueLabel.Size = new System.Drawing.Size(89, 29);
			this.pesoValueLabel.TabIndex = 25;
			this.pesoValueLabel.Text = "[Peso]";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.messageToolStripStatusLabel,
            this.descriptionToolStripStatusLabel});
			this.statusStrip1.Location = new System.Drawing.Point(0, 196);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(434, 22);
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
			this.descriptionToolStripStatusLabel.Size = new System.Drawing.Size(269, 17);
			this.descriptionToolStripStatusLabel.Spring = true;
			this.descriptionToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ativarCheckButton
			// 
			this.ativarCheckButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.ativarCheckButton.Appearance = System.Windows.Forms.Appearance.Button;
			this.ativarCheckButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.ativarCheckButton.Location = new System.Drawing.Point(318, 152);
			this.ativarCheckButton.Name = "ativarCheckButton";
			this.ativarCheckButton.Size = new System.Drawing.Size(104, 35);
			this.ativarCheckButton.TabIndex = 27;
			this.ativarCheckButton.Text = "Ativar";
			this.ativarCheckButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.ativarCheckButton.UseVisualStyleBackColor = true;
			this.ativarCheckButton.CheckedChanged += new System.EventHandler(this.ativarCheckButton_CheckedChanged);
			// 
			// readButton
			// 
			this.readButton.Location = new System.Drawing.Point(12, 147);
			this.readButton.Name = "readButton";
			this.readButton.Size = new System.Drawing.Size(87, 40);
			this.readButton.TabIndex = 28;
			this.readButton.Text = "Ler Peso";
			this.readButton.UseVisualStyleBackColor = true;
			this.readButton.Click += new System.EventHandler(this.readButton_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(434, 218);
			this.Controls.Add(this.readButton);
			this.Controls.Add(this.ativarCheckButton);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.pesoValueLabel);
			this.Controls.Add(this.pesoLabel);
			this.Controls.Add(this.velocidadeComboBox);
			this.Controls.Add(this.velocidadeLabel);
			this.Controls.Add(this.monitorarCheckBox);
			this.Controls.Add(this.portaComboBox);
			this.Controls.Add(this.modeloComboBox);
			this.Controls.Add(this.portaLabel);
			this.Controls.Add(this.modeloLabel);
			this.Name = "MainForm";
			this.Text = "ACBrFramework - Balança";
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox velocidadeComboBox;
		private System.Windows.Forms.Label velocidadeLabel;
		private System.Windows.Forms.CheckBox monitorarCheckBox;
		private System.Windows.Forms.ComboBox portaComboBox;
		private System.Windows.Forms.ComboBox modeloComboBox;
		private System.Windows.Forms.Label portaLabel;
		private System.Windows.Forms.Label modeloLabel;
		private ACBrBAL acbrBAL;
		private System.Windows.Forms.Label pesoLabel;
		private System.Windows.Forms.Label pesoValueLabel;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel messageToolStripStatusLabel;
		private System.Windows.Forms.ToolStripStatusLabel descriptionToolStripStatusLabel;
		private System.Windows.Forms.CheckBox ativarCheckButton;
		private System.Windows.Forms.Button readButton;
	}
}

