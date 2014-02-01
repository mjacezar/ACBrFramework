using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ACBrFramework.TEFD;

namespace ACBrFramework.TEFDTeste
{
    public partial class InputVeSPagueForm : Form
    {
        private TEFVeSPagueObtemCampoEventArgs obtenCampoEventArgs;

        public InputVeSPagueForm()
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

		public void Initialize(TEFVeSPagueObtemCampoEventArgs obtenCampoEventArgs)
        {
            this.obtenCampoEventArgs = obtenCampoEventArgs;

            this.messageLabel.Text = obtenCampoEventArgs.Titulo;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
