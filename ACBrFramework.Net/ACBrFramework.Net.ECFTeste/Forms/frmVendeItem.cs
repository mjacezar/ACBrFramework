using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ACBrFramework.ECFTeste
{
	public partial class frmVendeItem : Form
	{
		#region Field

		public Item Retorno { get; private set; }
		#endregion Field

		#region Constructor\Destructor

		public frmVendeItem()
		{
			InitializeComponent();
			Retorno = new Item();
		}

		#endregion Constructor\Destructor

		#region Methods

		private void Imprimir()
		{
			decimal valor = 0;

			Retorno.codigo = txtCodigo.Text;
			Retorno.descricao = txtDescricao.Text;
			
			decimal.TryParse(txtQuantidade.Text, out valor);
			Retorno.quantidade = valor;
			valor = 0;

			decimal.TryParse(txtPreco.Text, out valor);
			Retorno.ValorUnitario = valor;
			valor = 0;
			
			Retorno.Unidade = txtUnidade.Text;
			Retorno.tipoDescAcres = radPercentagem.Checked ? "%" : "$";
			Retorno.DescAcres = radAcrescimo.Checked ? "A" : "D";

			decimal.TryParse(txtDescAcres.Text, out valor);
			Retorno.ValorDescAcres = valor;

			Retorno.icms = txtICMS.Text;

			Close();
		}

		private void Cancelar()
		{
			Close();
		}

		#endregion Methods		

		#region EventHandlers

		private void btnImprimir_Click(object sender, EventArgs e)
		{
			Imprimir();
		}

		private void btnFechar_Click(object sender, EventArgs e)
		{
			Cancelar();
		}

		#endregion EventHandlers		
	}
}
