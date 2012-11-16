using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ACBrFramework.Net.CNIEETeste
{
	public partial class ProxyForm : Form
	{
		#region Fields

		public string Host { get; set; }
		public string Port { get; set; }
		public bool Autenticar { get; set; }
		public string User { get; set; }
		public string Pass { get; set; }

		#endregion Fields

		#region Constructors

		public ProxyForm()
		{
			InitializeComponent();
		}

		#endregion Constructors

		#region Methods

		private void Confirmar()
		{
			if (string.IsNullOrEmpty(txtHost.Text))
			{
				MessageBox.Show("O host não pode ser vazio");
				return;
			}

			if (string.IsNullOrEmpty(txtPort.Text))
			{
				MessageBox.Show("A porta não pode ser vazia");
				return;
			}

			if(chkAutenticar.Checked && string.IsNullOrEmpty(txtUser.Text))
			{
				MessageBox.Show("O usuario não pode ser vazio");
				return;
			}

			if (chkAutenticar.Checked && string.IsNullOrEmpty(txtPass.Text))
			{
				MessageBox.Show("A Senha não pode ser vazia");
				return;
			}

			Host = txtHost.Text;
			Port = txtPort.Text;
			Autenticar = chkAutenticar.Checked;
			User = txtUser.Text;
			Pass = txtPass.Text;
			Close();
		}

		#endregion Methods

		#region EventHandlers

		private void chkcheckBox1_CheckedChanged(object sender, EventArgs e)
		{
			txtUser.Enabled = chkAutenticar.Checked;
			txtPass.Enabled = chkAutenticar.Checked;
		}
		
		private void btnOK_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			Close();
		}

		#endregion EventHandlers		
	}
}
