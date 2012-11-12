namespace ACBrFramework.TEFDTeste
{
    partial class CNF_CNCForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CNF_CNCForm));
            this.cmbRede = new System.Windows.Forms.ComboBox();
            this.lblRede = new System.Windows.Forms.Label();
            this.txtNSU = new System.Windows.Forms.TextBox();
            this.txtFinalizacao = new System.Windows.Forms.TextBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbRede
            // 
            this.cmbRede.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRede.FormattingEnabled = true;
            this.cmbRede.Items.AddRange(new object[] {
            "REDECARD",
            "VISANET",
            "AMEX"});
            this.cmbRede.Location = new System.Drawing.Point(15, 28);
            this.cmbRede.Name = "cmbRede";
            this.cmbRede.Size = new System.Drawing.Size(113, 21);
            this.cmbRede.TabIndex = 18;
            // 
            // lblRede
            // 
            this.lblRede.AutoSize = true;
            this.lblRede.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRede.Location = new System.Drawing.Point(12, 12);
            this.lblRede.Name = "lblRede";
            this.lblRede.Size = new System.Drawing.Size(37, 13);
            this.lblRede.TabIndex = 19;
            this.lblRede.Text = "Rede";
            // 
            // txtNSU
            // 
            this.txtNSU.Location = new System.Drawing.Point(134, 28);
            this.txtNSU.Name = "txtNSU";
            this.txtNSU.Size = new System.Drawing.Size(180, 20);
            this.txtNSU.TabIndex = 20;
            // 
            // txtFinalizacao
            // 
            this.txtFinalizacao.Location = new System.Drawing.Point(15, 69);
            this.txtFinalizacao.Name = "txtFinalizacao";
            this.txtFinalizacao.Size = new System.Drawing.Size(203, 20);
            this.txtFinalizacao.TabIndex = 21;
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(224, 69);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(90, 20);
            this.txtValor.TabIndex = 22;
            this.txtValor.Text = "0,00";
            this.txtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(131, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "NSU";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Finalização";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(221, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Valor";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(239, 99);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 26;
            this.btnOK.Text = "CNC";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // CNF_CNCForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 134);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.txtFinalizacao);
            this.Controls.Add(this.txtNSU);
            this.Controls.Add(this.lblRede);
            this.Controls.Add(this.cmbRede);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CNF_CNCForm";
            this.Text = "CNF_CNCForm";
            this.Load += new System.EventHandler(this.CNF_CNCForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbRede;
        private System.Windows.Forms.Label lblRede;
        private System.Windows.Forms.TextBox txtNSU;
        private System.Windows.Forms.TextBox txtFinalizacao;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOK;
    }
}