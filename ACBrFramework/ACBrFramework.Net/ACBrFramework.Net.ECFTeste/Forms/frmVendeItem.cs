using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ACBrFramework.ECF;

namespace ACBrFramework.ECFTeste
{
	public partial class frmVendeItem : Form
	{
		#region Field

		private Item item { get; set; }
		private MainForm Main;

		#endregion Field

		#region Constructor\Destructor

		public frmVendeItem()
		{
			InitializeComponent();
			Main = MainForm.Instance;
			item = new Item();
		}

		#endregion Constructor\Destructor

		#region Methods

		private void Imprimir()
		{
			decimal valor = 0;

			item.codigo = txtCodigo.Text;
			item.descricao = txtDescricao.Text;

			if (decimal.TryParse(txtQuantidade.Text, out valor))
				item.quantidade = valor;
			else
				item.quantidade = 1;

			if(decimal.TryParse(txtPreco.Text, out valor))
				item.ValorUnitario = valor;
			else
				item.ValorUnitario = 1;
			
			item.Unidade = txtUnidade.Text;
			item.tipoDescAcres = radPercentagem.Checked ? "%" : "$";
			item.DescAcres = radAcrescimo.Checked ? "A" : "D";

			if (decimal.TryParse(txtDescAcres.Text, out valor))
				item.ValorDescAcres = valor;
			else
				item.ValorDescAcres = 0;

			item.icms = txtICMS.Text;

			string msg = string.Format("Vende Item: Cod:{0}\n Desc:{1}\n Aliq:{2}\n Qtd:{3}\n " +
							"Preço:{4}\n Desc:{5}\n Un:{6}\n Tipo:{7}\n Desc:{8}", item.codigo, item.descricao, item.icms, item.quantidade, item.ValorUnitario, item.ValorDescAcres, item.Unidade, item.tipoDescAcres, item.DescAcres);

			Main.acbrECF.VendeItem(item.codigo, item.descricao, item.icms, item.quantidade, item.ValorUnitario, item.ValorDescAcres, item.Unidade, item.tipoDescAcres, item.DescAcres);
			Main.WriteResp(msg);
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
