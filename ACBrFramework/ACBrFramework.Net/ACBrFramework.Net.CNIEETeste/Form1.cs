using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ACBrFramework.CNIEE;

namespace ACBrFramework.Net.CNIEETeste
{
	public partial class Form1 : Form
	{
		#region Fields

		private List<Registro> Tabela;

		#endregion Fields

		#region Constructors

		public Form1()
		{
			InitializeComponent();
			Inicializar();
		}

		#endregion Constructors		

		#region Methods

		private void Inicializar()
		{
			try
			{
				string arquivo = string.Format(@"{0}\Tabela_CNIEE.bin", Path.GetDirectoryName(Application.ExecutablePath));
				txtArquivo.Text = arquivo;
				aCBrCNIEE1.Arquivo = arquivo;
				aCBrCNIEE1.LerConfiguracoesProxy();

				if (File.Exists(arquivo))
					AbrirArquivo();
			}
			catch (Exception exception)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = exception.Message;
			}
		}

		private void AbrirArquivo()
		{
			try
			{
				aCBrCNIEE1.Arquivo = txtArquivo.Text;
				if (aCBrCNIEE1.AbrirTabela())
				{
					Tabela = new List<Registro>();
					Tabela.AddRange(aCBrCNIEE1.Registros);
					dgvECFs.DataSource = Tabela;
					dgvECFs.Refresh();
				}
			}
			catch (Exception exception)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = exception.Message;
			}
		}

		private void Download()
		{
			try
			{
				aCBrCNIEE1.URLDownload = txtURL.Text;
				if (aCBrCNIEE1.DownloadTabela())
				{
					MessageBox.Show("Download Efetuado com Sucesso");
					if (MessageBox.Show("Gostaria de abrir e mostrar os dados?", this.Text, MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
						AbrirArquivo();
				}
				else
					MessageBox.Show("Erro ao fazer download de tabela");
			}
			catch (Exception exception)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = exception.Message;
			}
		}

		private void Exportar()
		{
			try
			{
				Exporta tipo = Exporta.TXT;

				SaveFileDialog dlg = new SaveFileDialog();

				if (radCSV.Checked)
				{
					dlg.Title = "Exportar arquivo CSV";
					dlg.FileName = "TabelaCNIEE.csv";
					dlg.DefaultExt = ".csv";
					dlg.Filter = "Arquivos CSV|*.csv";
					tipo = Exporta.CSV;
				}
				else if (radDSV.Checked)
				{
					dlg.Title = "Exportar arquivo DSV";
					dlg.FileName = "TabelaCNIEE.dsv";
					dlg.DefaultExt = ".dsv";
					dlg.Filter = "Arquivos DSV|*.dsv";
					tipo = Exporta.DSV;
				}
				else if (radXML.Checked)
				{
					dlg.Title = "Exportar arquivo XML";
					dlg.FileName = "TabelaCNIEE.xml";
					dlg.DefaultExt = ".xml";
					dlg.Filter = "Arquivos XML|*.xml";
					tipo = Exporta.XML;
				}
				else if (radHTML.Checked)
				{
					dlg.Title = "Exportar arquivo HTML";
					dlg.FileName = "TabelaCNIEE.html";
					dlg.DefaultExt = ".html";
					dlg.Filter = "Arquivos HTML|*.";
					tipo = Exporta.HTML;
				}

				if (dlg.ShowDialog().Equals(DialogResult.OK))
				{
					aCBrCNIEE1.Exportar(dlg.FileName, tipo);
				}
			}
			catch (Exception exception)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = exception.Message;
			}

		}

		private void LocalizarArquivo()
		{
			try
			{
				OpenFileDialog dlg = new OpenFileDialog();
				dlg.Multiselect = false;
				dlg.CheckFileExists = true;
				dlg.CheckPathExists = true;
				dlg.FileName = "Tabela_CNIEE.bin";
				dlg.Filter = "Tabela Nacional de ECFs|Tabela_CNIEE.bin";

				if (dlg.ShowDialog().Equals(DialogResult.OK))
				{
					txtArquivo.Text = dlg.FileName;
				}
			}
			catch (Exception exception)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = exception.Message;
			}
		}

		private void ConfigurarProxy()
		{
			try
			{
				using (ProxyForm cfgProxy = new ProxyForm())
				{
					if (cfgProxy.ShowDialog().Equals(DialogResult.OK))
					{
						aCBrCNIEE1.ProxyHost = cfgProxy.Host;
						aCBrCNIEE1.ProxyPort = cfgProxy.Port;

						if (cfgProxy.Autenticar)
						{
							aCBrCNIEE1.ProxyUser = cfgProxy.User;
							aCBrCNIEE1.ProxyPass = cfgProxy.Pass;
						}
					}
				}
			}
			catch (Exception exception)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = exception.Message;
			}
		}

		#endregion Methods

		#region EventHandlers

		private void btnDownload_Click(object sender, EventArgs e)
		{
			Download();
		}

		private void btnAbrir_Click(object sender, EventArgs e)
		{
			AbrirArquivo();
		}

		private void btnExportar_Click(object sender, EventArgs e)
		{
			Exportar();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			LocalizarArquivo();
		}

		private void btnProxy_Click(object sender, EventArgs e)
		{
			ConfigurarProxy();
		}

		private void btnSair_Click(object sender, EventArgs e)
		{
			Close();
		}		

		#endregion EventHandlers
	}
}
