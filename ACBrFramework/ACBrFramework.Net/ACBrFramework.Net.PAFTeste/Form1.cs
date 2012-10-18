﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ACBrFramework.Net.PAFTeste
{
	public partial class Form1 : Form
	{
		#region Fields

		private const string NUM_FAB = "NUMFAB78901234567890";
		private const string MF_ADICIONAL = "";
		private const string TIPO_ECF = "ECF-IF";
		private const string MARCA_ECF = "ACBr";
		private const string MODELO_ECF = "PAF";

		#endregion Fields

		#region Constructor
		public Form1()
		{
			InitializeComponent();
			InicializarPaf();
		}
		#endregion Constructor

		#region Methods
		private void InicializarPaf()
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
			acbrPAF.EAD = acbrEAD;
		}

		private void GerarArquivoC()
		{
			try
			{
				ACBrPAFRegistroC1 RegistroC1 = new ACBrPAFRegistroC1();
				List<ACBrPAFRegistroC2> RegistroC2 = new List<ACBrPAFRegistroC2>();

				RegistroC1.RazaoSocial = txtRazaoSocial.Text;
				RegistroC1.UF = txtUF.Text;
				RegistroC1.CNPJ = txtCNPJ.Text;
				RegistroC1.IE = txtIE.Text;
				RegistroC1.IM = txtIM.Text;

				for (int i = 0; i < 10; i++)
				{
					ACBrPAFRegistroC2 ItemC2 = new ACBrPAFRegistroC2();
					ItemC2.ID_ABASTECIMENTO = "";
					ItemC2.TANQUE = "001";
					ItemC2.BOMBA = "001";
					ItemC2.BICO = "001";
					ItemC2.COMBUSTIVEL = (string)GerarDados('S', 14);
					ItemC2.DATA_ABASTECIMENTO = DateTime.Now;
					ItemC2.HORA_ABASTECIMENTO = DateTime.Now;
					ItemC2.ENCERRANTE_INICIAL = (int)GerarDados('I', 5);
					ItemC2.ENCERRANTE_FINAL = (int)GerarDados('I', 5);
					ItemC2.STATUS_ABASTECIMENTO = "EMITIDO CF";
					ItemC2.NRO_SERIE_ECF = (string)GerarDados('S', 14);
					ItemC2.DATA = DateTime.Now;
					ItemC2.HORA = DateTime.Now;
					ItemC2.COO = (int)GerarDados('I', 3);
					ItemC2.NRO_NOTA_FISCAL = (int)GerarDados('I', 4);
					ItemC2.VOLUME = (int)GerarDados('I', 2);
					ItemC2.RegistroValido = true;
					RegistroC2.Add(ItemC2);
					ItemC2 = null;
				}

				acbrPAF.Path = Path.GetDirectoryName(Application.ExecutablePath);
				acbrPAF.SaveFileTXT_C(RegistroC1, RegistroC2.ToArray(), @"\PAF_C.txt");
				WriteResp("Arquivo PAF_C Gerado com sucesso");
			}
			catch (Exception exception)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = exception.Message;
			}
		}

		private void GerarArquivoD()
		{
			try
			{
				ACBrPAFRegistroD1 RegistroD1 = new ACBrPAFRegistroD1();
				List<ACBrPAFRegistroD2> RegistroD2 = new List<ACBrPAFRegistroD2>();

				RegistroD1.RazaoSocial = txtRazaoSocial.Text;
				RegistroD1.UF = txtUF.Text;
				RegistroD1.CNPJ = txtCNPJ.Text;
				RegistroD1.IE = txtIE.Text;
				RegistroD1.IM = txtIM.Text;

				for (int i = 0; i < 10; i++)
				{
					ACBrPAFRegistroD2 ItemD2 = new ACBrPAFRegistroD2();
					ItemD2.NUM_FAB = NUM_FAB;
					ItemD2.MF_ADICIONAL = MF_ADICIONAL;
					ItemD2.TIPO_ECF = TIPO_ECF;
					ItemD2.MARCA_ECF = MARCA_ECF;
					ItemD2.MODELO_ECF = MODELO_ECF;
					ItemD2.COO = GerarDados('I', 6).ToString();
					ItemD2.NUM_DAV = GerarDados('I', 13).ToString();
					ItemD2.DT_DAV = DateTime.Now;
					ItemD2.TIT_DAV = "Pedido";
					ItemD2.VLT_DAV = (double)GerarDados('D', 8);
					ItemD2.COO_DFV = "0";
					ItemD2.NUMERO_ECF = "1";
					ItemD2.NOME_CLIENTE = "Rafael Dias";
					ItemD2.CPF_CNPJ = GerarDados('I', 14).ToString();
					ItemD2.RegistroD3 = new List<ACBrPAFRegistroD3>();
					for (int d = 0; d < 5; d++)
					{
						ACBrPAFRegistroD3 ItemD3 = new ACBrPAFRegistroD3();
						ItemD3.DT_INCLUSAO = DateTime.Now;
						ItemD3.NUM_ITEM = d;
						ItemD3.COD_ITEM = GerarDados('I', 8).ToString();
						ItemD3.DESC_ITEM = "descricao do item";
						ItemD3.QTDE_ITEM = (double)GerarDados('D', 8);
						ItemD3.UNI_ITEM = "UN";
						ItemD3.VL_UNIT = (double)GerarDados('D', 8);
						ItemD3.VL_DESCTO = (double)GerarDados('D', 8);
						ItemD3.VL_ACRES = (double)GerarDados('D', 8);
						ItemD3.VL_TOTAL = (double)GerarDados('D', 8);
						ItemD3.DEC_VL_UNIT = 2;
						ItemD3.DEC_QTDE_ITEM = 2;
						ItemD3.SIT_TRIB = "T";
						ItemD3.ALIQ = (double)GerarDados('D', 8); ;
						ItemD3.IND_CANC = "M";
						ItemD3.RegistroValido = true;
						ItemD2.RegistroD3.Add(ItemD3);
						ItemD3 = null;
					}

					ItemD2.RegistroValido = true;
					RegistroD2.Add(ItemD2);
					ItemD2 = null;
				}

				acbrPAF.Path = Path.GetDirectoryName(Application.ExecutablePath);
				acbrPAF.SaveFileTXT_D(RegistroD1, RegistroD2.ToArray(), @"\PAF_D.txt");
				WriteResp("Arquivo PAF_D Gerado com sucesso");
			}
			catch (Exception exception)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = exception.Message;
			}
		}

		private void GerarArquivoP()
		{
			try
			{
				ACBrPAFRegistroP1 RegistroP1 = new ACBrPAFRegistroP1();
				List<ACBrPAFRegistroP2> RegistroP2 = new List<ACBrPAFRegistroP2>();

				RegistroP1.RazaoSocial = txtRazaoSocial.Text;
				RegistroP1.UF = txtUF.Text;
				RegistroP1.CNPJ = txtCNPJ.Text;
				RegistroP1.IE = txtIE.Text;
				RegistroP1.IM = txtIM.Text;

				for (int i = 0; i < 10; i++)
				{
					ACBrPAFRegistroP2 ItemP2 = new ACBrPAFRegistroP2();
					ItemP2.COD_MERC_SERV = (string)GerarDados('S', 6);
					ItemP2.DESC_MERC_SERV = (string)GerarDados('S', 6);
					ItemP2.UN_MED = (string)GerarDados('S', 2);
					ItemP2.IAT = (string)GerarDados('S', 6);
					ItemP2.IPPT = (string)GerarDados('S', 6);
					ItemP2.ST = (string)GerarDados('S', 6);
					ItemP2.ALIQ = (double)GerarDados('D', 6);
					ItemP2.VL_UNIT = (double)GerarDados('D', 6);
					ItemP2.RegistroValido = true;
					RegistroP2.Add(ItemP2);
					ItemP2 = null;
				}

				acbrPAF.Path = Path.GetDirectoryName(Application.ExecutablePath);
				acbrPAF.SaveFileTXT_P(RegistroP1, RegistroP2.ToArray(), @"\PAF_P.txt");
				WriteResp("Arquivo PAF_P Gerado com sucesso");
			}
			catch (Exception exception)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = exception.Message;
			}
		}

		private object GerarDados(char tipo, int size)
		{
			Random random = new Random();
			StringBuilder str = new StringBuilder(size);
			char ch;
			int nb;
			for (int ind = 0; ind < size; ind++)
			{
				switch (tipo)
				{
					case 'S':
						ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
						str.Append(ch);
						break;

					case 'I':
						nb = Convert.ToInt32(decimal.Round(Convert.ToDecimal(Math.Floor(26 * random.NextDouble() + 65)), 1));
						str.Append(nb.ToString());
						break;

					case 'D':
						nb = Convert.ToInt32(decimal.Round(Convert.ToDecimal(Math.Floor(26 * random.NextDouble() + 65)), 1));
						str.Append(nb.ToString());
						break;
				}
			}
			if (tipo == 'I')
				return Convert.ToInt32(str.ToString().ToUpper().Remove(size - 1));
			if (tipo == 'D')
				return Convert.ToDouble(str.ToString().ToUpper().Remove(size - 1));
			else
				return str.ToString().ToUpper();
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
		private void btnTipoC_Click(object sender, EventArgs e)
		{
			GerarArquivoC();
		}

		private void btnTipoD_Click(object sender, EventArgs e)
		{
			GerarArquivoD();
		}

		private void btnTipoP_Click(object sender, EventArgs e)
		{
			GerarArquivoP();
		}
		#endregion Event Handlers
	}
}
