using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ACBrFramework.TEFD;

namespace ACBrFramework.TEFDTeste
{
    public partial class InputForm : Form
    {
        private TEFCliSiTefObtemCampoEventArgs obtenCampoEventArgs;

        public InputForm()
        {
            InitializeComponent();
        }

        public string InputText
        {
            get
            {
                return this.textBox.Text;
            }
        }

		public void Initialize(TEFCliSiTefObtemCampoEventArgs obtenCampoEventArgs)
        {
            this.obtenCampoEventArgs = obtenCampoEventArgs;

            this.messageLabel.Text = obtenCampoEventArgs.Titulo;
			this.textBox.MaxLength = obtenCampoEventArgs.TamanhoMaximo;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            string text = this.textBox.Text;

			if (text.Length < obtenCampoEventArgs.TamanhoMinimo || text.Length > obtenCampoEventArgs.TamanhoMaximo)
            {
                MessageBox.Show(this, "Valor incorreto!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.None;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
