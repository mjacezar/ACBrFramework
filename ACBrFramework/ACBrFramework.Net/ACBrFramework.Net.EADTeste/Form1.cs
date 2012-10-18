using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;

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

		public void InicializarEAD()
		{
			try
			{
				acbrEAD.ChavePrivada = "-----BEGIN RSA PRIVATE KEY-----" + Environment.NewLine +
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

				foreach (var hash in Enum.GetValues(typeof(EADDigest))) cmbHash.Items.Add(hash);
			}
			catch (Exception exception)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = exception.Message;
			}
		}

		public void GerarChaves()
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

		public void SalvarPriKey()
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

		public void SalvarPubKey()
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

		private void LerChavePrivada()
		{
			try
			{
				OpenFileDialog dlg = new OpenFileDialog()
				{
					Multiselect = false,
					Title = "Selecione a chave privada",
					FilterIndex = 1,
					Filter = "RSA Key (*.pem)|*.pem|txt files (*.txt)|*.txt|All files (*.*)|*.*"
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

				acbrEAD.ChavePrivada = txtChavePri.Text;
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
				Filter = "RSA Key (*.pem)|*.pem|txt files (*.txt)|*.txt|All files (*.*)|*.*"
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

				acbrEAD.ChavePublica = txtChavePub.Text;
				WriteResp("Chave Publica Lida com Sucesso");
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

		#endregion Event Handlers		
	}
}
