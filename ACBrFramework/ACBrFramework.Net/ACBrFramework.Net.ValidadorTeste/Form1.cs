using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ACBrFramework.Validador;

namespace ACBrFramework.Net.ValidadorTeste
{
	public partial class Form1 : Form
	{
		#region Fields
		#endregion Fields

		#region Constructor\Desconstructor

		public Form1()
		{
			InitializeComponent();
			popular();
		}

		#endregion Constructor\Desconstructor

		#region Methods

		private void popular()
		{
			foreach (var tipo in Enum.GetValues(typeof(ValTipoDocto))) cmbTipoDoc.Items.Add(tipo);
			cmbTipoDoc.SelectedIndex = 0;
		}
		
		private void Validar()
		{
			Formatar();

			aCBrValidador1.Documento = txtDocumento.Text;
			aCBrValidador1.Complemento = txtComplemento.Text;
			aCBrValidador1.IgnorarChar = txtIgnoreChars.Text;

			if(aCBrValidador1.Validar())
				WriteResp("Documento OK");
			else
				WriteResp(aCBrValidador1.MsgErro);
		}

		private void Formatar()
		{
			aCBrValidador1.Documento = txtDocumento.Text;

			txtDocumento.Text = aCBrValidador1.Formatar();
		}

		private void WriteResp(string resp)
		{
			if (string.IsNullOrEmpty(resp)) return;

			foreach (string line in resp.Split('\n'))
			{
				msgBox.Items.Add(line);
			}

			msgBox.SelectedIndex = msgBox.Items.Count - 1;
		}

		#endregion Methods
		
		#region EventHandlers

		private void btnValidar_Click(object sender, EventArgs e)
		{
			Validar();
		}

		private void btnFormatar_Click(object sender, EventArgs e)
		{
			Formatar();
		}

		private void cmbTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
		{
			aCBrValidador1.TipoDocto = (ValTipoDocto)cmbTipoDoc.SelectedItem;
		}

		private void chkVazio_CheckedChanged(object sender, EventArgs e)
		{
			aCBrValidador1.PermiteVazio = chkVazio.Checked;
		}

		private void chkTamanho_CheckedChanged(object sender, EventArgs e)
		{
			aCBrValidador1.AjustarTamanho = chkTamanho.Checked;
		}

		private void chkDigito_CheckedChanged(object sender, EventArgs e)
		{
			aCBrValidador1.ExibeDigitoCorreto = chkDigito.Checked;
		}

		private void chkExcecao_CheckedChanged(object sender, EventArgs e)
		{
			aCBrValidador1.RaiseExcept = chkExcecao.Checked;
		}

		#endregion EventHandlers
	}
}
