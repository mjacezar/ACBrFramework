using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ACBrFramework.ECF;

namespace ACBrFramework.ECFTeste
{
	public partial class frmPagamento : Form
	{
		#region Field

		public MainForm Main { get; set; }
		public string Tipo { get; set; }

		#endregion Field

		#region Constructor

		public frmPagamento()
		{
			InitializeComponent();			
		}

		private void frmPagamento_Load(object sender, EventArgs e)
		{
			carregarFPG();
			atualizaValor();
		}

		#endregion Constructor

		#region Methods

		private void carregarFPG()
		{
			lstFPG.Items.Clear();

			if (Main.acbrECF.Modelo == ModeloECF.Bematech || Main.acbrECF.Modelo == ModeloECF.NaoFiscal)
				Main.acbrECF.CarregaFormasPagamento();
			else
				Main.acbrECF.AchaFPGIndice(string.Empty);

			foreach (FormaPagamento pag in Main.acbrECF.FormasPagamento)
			{
				string forma = string.Format("{0} -> {1} - {2}", pag.Indice, pag.Descricao, pag.PermiteVinculado);
				lstFPG.Items.Add(forma);
			}
		}

		private void atualizaValor()
		{
			lblTotalCupom.Text = string.Format("{0:C}", Main.acbrECF.SubTotal);
			lblTotalPago.Text = string.Format("{0:C}", Main.acbrECF.TotalPago);
		}

		private void procurarFPG()
		{
			try
			{
				string desc = string.Empty;

				if (InputBox.Show("Pesquisa Descrição Forma Pagamento",
					"Entre com a Descrição a Localizar ou Cadastrar(Bematech)", ref desc).Equals(DialogResult.Cancel))
					return;

				var FPG = Main.acbrECF.AchaFPGDescricao(desc);

				if (FPG == null)
				{
					string msg = string.Format("Forma de Pagamento: {0} não encontrada", desc);
					MessageBox.Show(msg);
					return;
				}

				txtIndice.Text = FPG.Indice;

				if (Main.acbrECF.ModeloStr.Equals("Bematech"))
					carregarFPG();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private void efetuarPagamento()
		{
			string msg = string.Format("Efetua Pagamento: {0} Valor: {1:c} Obs: {2} Vinc: {3}", txtIndice.Text, txtValor.Text, txtObservacao.Text, chkVinculado.Checked);

			switch (Tipo)
			{
				case "F":
					Main.acbrECF.EfetuaPagamento(txtIndice.Text, Convert.ToDecimal(txtValor.Text), txtObservacao.Text, chkVinculado.Checked);					
					Main.WriteResp(msg);
					atualizaValor();
					break;

				case "N":
					Main.acbrECF.EfetuaPagamentoNaoFiscal(txtIndice.Text, Convert.ToDecimal(txtValor.Text), txtObservacao.Text, chkVinculado.Checked);					
					Main.WriteResp(msg);
					atualizaValor();
					break;

				default:
					break;
			}
		}

		#endregion Methods

		#region EventHandlers

		private void btnProcurar_Click(object sender, EventArgs e)
		{
			procurarFPG();
		}
		
		private void btnImprimir_Click(object sender, EventArgs e)
		{
			efetuarPagamento();
		}

		#endregion EventHandlers		
	}
}
