using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ACBrFramework.EAD;

namespace ACBrFramework.Net.EADTeste
{
	public partial class Form1 : Form
	{
		#region Constructor

		public Form1()
		{
			InitializeComponent();
			InicializarEAD();
		}

		#endregion Constructor

		#region Methods

		private void InicializarEAD()
		{
			try
			{
				foreach (var hash in Enum.GetValues(typeof(EADDigest))) cmbHash.Items.Add(hash);
				cmbHash.SelectedIndex = 2;
			}
			catch (Exception exception)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = exception.Message;
			}
		}

		private void GerarChaves()
		{
			try
			{
				string ChavePUB = string.Empty;
				string ChavePRI = string.Empty;
				acbrEAD.GerarChaves(out ChavePUB, out ChavePRI);
				txtChavePri.Text = ChavePRI;
				txtChavePub.Text = ChavePUB;

				if (MessageBox.Show("Gostaria de salvar as chaves", "ACBrFramework.Net", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
				{
					SalvarPriKey();
					SalvarPubKey();
				}

				WriteResp("Chaves geradas com sucesso");
			}
			catch (Exception exception)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = exception.Message;
			}
		}

		private void GerarXML()
		{
			try
			{
				string SH = "Sua SoftwareHouse";
				if (!InputBox("Sua SoftwareHouse", "Entre com o nome da Sw.House", ref SH).Equals(DialogResult.OK))
					return;

				if (string.IsNullOrEmpty(SH))
					return;

				FolderBrowserDialog dlg = new FolderBrowserDialog();

				if (dlg.ShowDialog().Equals(DialogResult.OK))
				{
					string XML = String.Format(@"{0}\{1}.xml", dlg.SelectedPath, SH);
					if (File.Exists(XML))
					{
						if (MessageBox.Show("Arquivo já existe, sobrescrever ?", "ACBrEAD", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
							acbrEAD.GerarXMLeECFc(SH, XML);
					}
					else
					{
						acbrEAD.GerarXMLeECFc(SH, dlg.SelectedPath);
					}

					WriteResp(string.Format("Arquivo {0}.xml gerado em {1}", SH, dlg.SelectedPath));
				}
			}
			catch (Exception exception)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = exception.Message;
			}
		}

		private void ConverterXML()
		{
			try
			{
				OpenFileDialog dlg = new OpenFileDialog()
				{
					Multiselect = false,
					Title = "Selecione o arquivo",
					FilterIndex = 1,
					Filter = "Arquivo XML(*.xml)|*.xml"
				};

				if (dlg.ShowDialog() == DialogResult.OK)
				{
					txtChavePub.Clear();
					txtChavePub.Text = acbrEAD.ConverteXMLeECFcParaOpenSSL(dlg.FileName);
					WriteResp("Arquivo convertido com sucesso");
				}
			}
			catch (Exception exception)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = exception.Message;
			}
		}

		private void SalvarPriKey()
		{
			try
			{
				StreamWriter sw = new StreamWriter(txtArqPrivKey.Text);
				sw.Write(txtChavePri.Text);
				sw.Close();
				WriteResp("Chave privada salva com sucesso !!");
			}
			catch (Exception exception)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = exception.Message;
			}
		}

		private void SalvarPubKey()
		{
			try
			{
				StreamWriter sw = new StreamWriter(txtArqPubKey.Text);
				sw.Write(txtChavePub.Text);
				sw.Close();
				WriteResp("Chave privada salva com sucesso !!");
			}
			catch (Exception exception)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = exception.Message;
			}
		}

		private void CalcularCHPUB()
		{
			try
			{
				txtChavePub.Text = acbrEAD.CalcularChavePublica();
				WriteResp("Chave Publica calculada com sucesso");
			}
			catch (Exception exception)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = exception.Message;
			}
		}

		private void CalcularModuloExpoente()
		{
			try
			{
				string modulo, expoente;
				modulo = string.Empty;
				expoente = string.Empty;

				acbrEAD.CalcularModuloeExpoente(out modulo, out expoente);

				WriteResp(string.Format("Modulo: {0}", modulo));
				WriteResp(string.Format("Expoente: {0}", expoente));
			}
			catch (Exception exception)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = exception.Message;
			}
		}

		private void CalcularHash()
		{
			try
			{
				if (!File.Exists(txtArqEntrada.Text))
					return;

				string Hash = acbrEAD.CalcularHashArquivo(txtArqEntrada.Text, (EADDigest)cmbHash.SelectedItem);
				WriteResp("Hash calculado com sucesso");
				WriteResp(string.Format("Hash : {0}", Hash));
			}
			catch (Exception exception)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = exception.Message;
			}
		}

		private void CalcularEAD()
		{
			try
			{
				if (!File.Exists(txtArqEntrada.Text))
					return;

				string EAD = acbrEAD.CalcularEADArquivo(txtArqEntrada.Text);
				WriteResp("EAD calculado com sucesso");
				WriteResp(string.Format("EAD : {0}", EAD));
			}
			catch (Exception exception)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = exception.Message;
			}
		}

		private void AssinarComEAD()
		{
			try
			{
				if (!File.Exists(txtArqEntrada.Text))
					return;

				string EAD = acbrEAD.AssinarArquivoComEAD(txtArqEntrada.Text, true);
				WriteResp("Arquivo assinado com sucesso");
				WriteResp(string.Format("EAD : {0}", EAD));
			}
			catch (Exception exception)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = exception.Message;
			}
		}

		private void VerificarEAD()
		{
			try
			{
				if (!File.Exists(txtArqEntrada.Text))
					return;

				if (acbrEAD.VerificarEADArquivo(txtArqEntrada.Text))
					WriteResp("EAD valido");
				else
					WriteResp("EAD invalido");
			}
			catch (Exception exception)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = exception.Message;
			}
		}

		private void LerChavePrivada()
		{
			try
			{
				OpenFileDialog dlg = new OpenFileDialog()
				{
					Multiselect = false,
					Title = "Selecione a chave privada",
					FilterIndex = 1,
					Filter = "Chave RSA (*.pem)|*.pem|Arquivo de Texto (*.txt)|*.txt|Todos os Arquivos (*.*)|*.*"
				};

				if (dlg.ShowDialog() == DialogResult.OK)
				{
					txtArqPrivKey.Text = dlg.FileName;
					StreamReader sr = new StreamReader(dlg.FileName);
					string linha;

					txtChavePri.Clear();
					while ((linha = sr.ReadLine()) != null)
						txtChavePri.Text += String.Format("{0}{1}", linha, Environment.NewLine);
				}

				WriteResp("Chave Privada Lida com Sucesso");
			}
			catch (Exception exception)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = exception.Message;
			}
		}

		private void LerChavePublica()
		{
			try
			{
				OpenFileDialog dlg = new OpenFileDialog()
				{
					Multiselect = false,
					Title = "Selecione a chave publica",
					FilterIndex = 1,
					Filter = "Chave RSA (*.pem)|*.pem|Arquivo de Texto (*.txt)|*.txt|Todos os Arquivos (*.*)|*.*"
				};

				if (dlg.ShowDialog() == DialogResult.OK)
				{
					txtArqPubKey.Text = dlg.FileName;
					StreamReader sr = new StreamReader(dlg.FileName);
					string linha;

					txtChavePub.Clear();
					while ((linha = sr.ReadLine()) != null)
						txtChavePub.Text += String.Format("{0}{1}", linha, Environment.NewLine);
				}

				WriteResp("Chave Publica Lida com Sucesso");
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
				OpenFileDialog dlg = new OpenFileDialog()
				{
					Multiselect = false,
					Title = "Selecione um arquivo",
					FilterIndex = 1,
					Filter = "Todos os Arquivos (*.*)|*.*"
				};

				if (dlg.ShowDialog() == DialogResult.OK)
					txtArqEntrada.Text = dlg.FileName;
			}
			catch (Exception exception)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = exception.Message;
			}
		}

		private void WriteResp(string resp)
		{
			if (string.IsNullOrEmpty(resp)) return;

			foreach (string line in resp.Split('\n'))
			{
				respListBox.Items.Add(line);
			}
			respListBox.Items.Add("+-+-+-+-+-+-+-+-+-+-+-+-+-+-");
			respListBox.Items.Add("");
			respListBox.SelectedIndex = respListBox.Items.Count - 1;
		}

		private static DialogResult InputBox(string title, string promptText, ref string value)
		{
			Form form = new Form();
			Label label = new Label();
			TextBox textBox = new TextBox();
			Button buttonOk = new Button();
			Button buttonCancel = new Button();

			form.Text = title;
			label.Text = promptText;
			textBox.Text = value;

			buttonOk.Text = "OK";
			buttonCancel.Text = "Cancelar";
			buttonOk.DialogResult = DialogResult.OK;
			buttonCancel.DialogResult = DialogResult.Cancel;

			label.SetBounds(9, 20, 372, 13);
			textBox.SetBounds(12, 36, 372, 20);
			buttonOk.SetBounds(228, 72, 75, 23);
			buttonCancel.SetBounds(309, 72, 75, 23);

			label.AutoSize = true;
			textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
			buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

			form.ClientSize = new Size(396, 107);
			form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
			form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
			form.FormBorderStyle = FormBorderStyle.FixedDialog;
			form.StartPosition = FormStartPosition.CenterScreen;
			form.MinimizeBox = false;
			form.MaximizeBox = false;
			form.AcceptButton = buttonOk;
			form.CancelButton = buttonCancel;

			DialogResult dialogResult = form.ShowDialog();
			value = textBox.Text;
			return dialogResult;
		}

		#endregion Methods

		#region Event Handlers

		private void btnNPChaves_Click(object sender, EventArgs e)
		{
			GerarChaves();
		}

		private void btnGravarCPI_Click(object sender, EventArgs e)
		{
			SalvarPriKey();
		}

		private void btnGravarCPU_Click(object sender, EventArgs e)
		{
			SalvarPubKey();
		}

		private void btnCalcCP_Click(object sender, EventArgs e)
		{
			CalcularCHPUB();
		}

		private void btnLerCPI_Click(object sender, EventArgs e)
		{
			LerChavePrivada();
		}

		private void btnLerCPU_Click(object sender, EventArgs e)
		{
			LerChavePublica();
		}

		private void btnProcurarArqu_Click(object sender, EventArgs e)
		{
			AbrirArquivo();
		}

		private void btnME_Click(object sender, EventArgs e)
		{
			CalcularModuloExpoente();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			AssinarComEAD();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			CalcularEAD();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			CalcularHash();
		}

		private void btnVerifArqAssinado_Click(object sender, EventArgs e)
		{
			VerificarEAD();
		}

		private void btnGXeECFc_Click(object sender, EventArgs e)
		{
			GerarXML();
		}

		private void button7_Click(object sender, EventArgs e)
		{
			ConverterXML();
		}

		private void acbrEAD_OnGetChavePrivada(object sender, ChaveEventArgs e)
		{
			e.Chave = "-----BEGIN RSA PRIVATE KEY-----" + Environment.NewLine +
					   "MIICXwIBAAKBgQC+TZjfcw/a/SovoqQPOW5bbKn4CQw4DeZJA3Y9vJrYHKN4aCQv" + Environment.NewLine +
					   "z0i3AG9kGdsTSZdZ/clh4xv6tUwPsBdZJHrm21gH7wN/zKLTvXbs+i3x7U00ElCB" + Environment.NewLine +
					   "YyZ8BOXJWVMuye0UvSz7p4JwSopugzbjaImIGy+5LvgcjUCn3OZzWpwYWQIDAQAB" + Environment.NewLine +
					   "AoGBAKAycEtB8An37ghVkGfkf7rkmZxb+XZCdSXnjSThXTQpv46/lB7PDrZG3n5U" + Environment.NewLine +
					   "qa/t1kQCOQF3DnmZHqNiJ/V5mR7ApbciQj4WYVLkMCgltru3MmzIUQ9IiLtAgaCv" + Environment.NewLine +
					   "uHc0MAzt/OWgQ93uFnLf4ubp4+2PTHiiIChv2m78s605wX2lAkEA+3pPsPdXcaOe" + Environment.NewLine +
					   "7T7C4hn1qg93ksN96UutB1APF3YAjWVWuPwzZv4hExiMPc0uKvVK2H3tP4P5CkM5" + Environment.NewLine +
					   "YMIEGEkF2wJBAMG5qmoYksz+MFZ2cd7gt68mf3Oq9F59qkHHcoV+1ttXx5pfzwat" + Environment.NewLine +
					   "kelhKkN+LV1XsgS0bGAKu2NitOMBUAcnItsCQQCEJxqJ3PFO/rUd58VyHEJFRCuK" + Environment.NewLine +
					   "LMGWP/aFyUSlB5XyuDaCr8YzcYjgCB5qu9BvMshKTKLIpgnRotIcTtjoCjfRAkEA" + Environment.NewLine +
					   "tsqHn+Bb9A0McykDvPdwmlXLAMsYFWihk7urtYa/GOw0rNcmMvjnqrxB8rlF+MNc" + Environment.NewLine +
					   "d8/+SokV02s5ntCIQJeO7QJBAKp2BCOIck+uhMPDiw/1788yQLD6mVb/pBzClzBn" + Environment.NewLine +
					   "pTMAFPGJG2fO4YJn/pUHdtDtSenX8TibWve+gY6oFCFw/Ts=" + Environment.NewLine +
					   "-----END RSA PRIVATE KEY-----";
		}

		private void acbrEAD_OnGetChavePublica(object sender, ChaveEventArgs e)
		{
			e.Chave = txtChavePub.Text;
		}

		#endregion Event Handlers
	}
}