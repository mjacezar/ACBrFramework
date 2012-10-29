using System;
using System.Linq;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections.Generic;
using System.IO;

namespace ACBrFramework
{
	[ToolboxBitmap(typeof(ACBrSintegra), @"ACBrSintegra.ico.bmp")]
	public class ACBrSintegra : ACBrComponent, IDisposable
	{
		#region Fields

		#endregion Fields

		#region Constructor

		public ACBrSintegra()
		{
		}

		#endregion Constructor

		#region Properties

		public string FileName
		{
			get
			{
				return GetString(ACBrSintegraInterop.SIN_GetFileName);
			}
			set
			{
				SetString(ACBrSintegraInterop.SIN_SetFileName, value);
			}
		}

		public ACBrSintegraVersaoValidador VersaoValidador
		{
			get
			{
                return (ACBrSintegraVersaoValidador)GetInt32(ACBrSintegraInterop.SIN_GetVersaoValidador);
			}
			set
			{
				SetInt32(ACBrSintegraInterop.SIN_SetVersaoValidador, (int)value);
			}
		}

		public bool Ativo
		{
			get
			{
				return GetBool(ACBrSintegraInterop.SIN_GetAtivo);
			}
		}

		#endregion Properties

		#region Methods

		public void LimparRegistros()
		{
			int ret = ACBrSintegraInterop.SIN_LimparRegistros(this.Handle);
			CheckResult(ret);
		}

		public void Registro10(SintegraRegistro10 registro10)
		{
			var record = new ACBrSintegraInterop.Registro10Rec();
			record.RazaoSocial = ToUTF8(registro10.RazaoSocial);
			record.CNPJ = ToUTF8(registro10.CNPJ.ToString());
			record.Inscricao = ToUTF8(registro10.Inscricao.ToString());
			record.Cidade = ToUTF8(registro10.Cidade);
			record.Estado = ToUTF8(registro10.Estado);
			record.Telefone = ToUTF8(registro10.Telefone.ToString());
			record.DataInicial = registro10.DataInicial.ToOADate();
			record.DataFinal = registro10.DataFinal.ToOADate();
			record.NaturezaInformacoes = registro10.NaturezaInformacoes;
			record.FinalidadeArquivo = registro10.FinalidadeArquivo;
			record.CodigoConvenio = registro10.CodigoConvenio;

			int ret = ACBrSintegraInterop.SIN_Registro10(this.Handle, record);
			CheckResult(ret);
		}

		public void Registro11(SintegraRegistro11 registro11)
		{
			var record = new ACBrSintegraInterop.Registro11Rec();
			record.Responsavel = ToUTF8(registro11.Responsavel);
			record.Bairro = ToUTF8(registro11.Bairro);
			record.Cep = ToUTF8(registro11.Cep.ToString());
			record.Numero = ToUTF8(registro11.Numero.ToString());
			record.Complemento = ToUTF8(registro11.Complemento);
			record.Endereco = ToUTF8(registro11.Endereco);
			record.Telefone = ToUTF8(registro11.Telefone.ToString());

			int ret = ACBrSintegraInterop.SIN_Registro11(this.Handle, record);
			CheckResult(ret);
		}

        public void Registro50(List<SintegraRegistro50> registro50)
        {
            Registro50(registro50.ToArray());
        }

        public void Registro50(IEnumerable<SintegraRegistro50> registro50)
        {
            Registro50(registro50.ToArray());
        }

 		public void Registro50(SintegraRegistro50[] registro50)
		{
			ACBrSintegraInterop.Registro50Rec[] record = new ACBrSintegraInterop.Registro50Rec[registro50.Length];
			for (int i = 0; i < registro50.Length; i++)
			{
				record[i].CPFCNPJ = ToUTF8(registro50[i].CPFCNPJ.ToString());
				record[i].Inscricao = ToUTF8(registro50[i].Inscricao.ToString());
				record[i].UF = ToUTF8(registro50[i].UF);
				record[i].Situacao = ToUTF8(registro50[i].Situacao);
				record[i].Aliquota = registro50[i].Aliquota;
				record[i].Isentas = registro50[i].Isentas;
				record[i].Icms = registro50[i].Icms;
				record[i].ValorContabil = registro50[i].ValorContabil;
				record[i].BasedeCalculo = registro50[i].BasedeCalculo;
				record[i].Outras = registro50[i].Outras;
				record[i].EmissorDocumento = ToUTF8(registro50[i].EmissorDocumento);
				record[i].Cfop = ToUTF8(registro50[i].Cfop);
				record[i].Serie = ToUTF8(registro50[i].Serie);
				record[i].Modelo = ToUTF8(registro50[i].Modelo);
				record[i].Numero = ToUTF8(registro50[i].Numero.ToString());
				record[i].DataDocumento = registro50[i].DataDocumento.ToOADate();
			}

			int ret = ACBrSintegraInterop.SIN_Registro50(this.Handle, record, registro50.Length);
			CheckResult(ret);
		}

        public void Registro51(List<SintegraRegistro51> registro51)
        {
            Registro51(registro51.ToArray());
        }

        public void Registro51(IEnumerable<SintegraRegistro51> registro51)
        {
            Registro51(registro51.ToArray());
        }

		public void Registro51(SintegraRegistro51[] registro51)
		{
			ACBrSintegraInterop.Registro51Rec[] record = new ACBrSintegraInterop.Registro51Rec[registro51.Length];
			for (int i = 0; i < registro51.Length; i++)
			{
				record[i].CPFCNPJ = ToUTF8(registro51[i].CPFCNPJ.ToString());
				record[i].Inscricao = ToUTF8(registro51[i].Inscricao.ToString());
				record[i].Estado = ToUTF8(registro51[i].Estado);
				record[i].ValorContabil = registro51[i].ValorContabil;
				record[i].Cfop = ToUTF8(registro51[i].Cfop);
				record[i].Serie = ToUTF8(registro51[i].Serie);
				record[i].Numero = ToUTF8(registro51[i].Numero.ToString());
				record[i].DataDocumento = registro51[i].DataDocumento.ToOADate();
				record[i].ValorIpi = registro51[i].ValorIpi;
				record[i].Situacao = ToUTF8(registro51[i].Situacao);
				record[i].ValorIsentas = registro51[i].ValorIsentas;
				record[i].ValorOutras = registro51[i].ValorOutras;
			}

			int ret = ACBrSintegraInterop.SIN_Registro51(this.Handle, record, registro51.Length);
			CheckResult(ret);
		}

        public void Registro53(List<SintegraRegistro53> registro53)
        {
            Registro53(registro53.ToArray());
        }

        public void Registro53(IEnumerable<SintegraRegistro53> registro53)
        {
            Registro53(registro53.ToArray());
        }

        public void Registro53(SintegraRegistro53[] registro53)
        {
            ACBrSintegraInterop.Registro53Rec[] record = new ACBrSintegraInterop.Registro53Rec[registro53.Length];
            for (int i = 0; i < registro53.Length; i++)
            {
                record[i].CPFCNPJ = registro53[i].CPFCNPJ;
                record[i].Inscricao = registro53[i].Inscricao;
                record[i].Estado = registro53[i].Estado;
                record[i].Serie = registro53[i].Serie;
                record[i].DataDocumento = registro53[i].DataDocumento.ToOADate();
                record[i].Cfop = registro53[i].Cfop;
                record[i].Numero = registro53[i].Numero;
                record[i].Situacao = registro53[i].Situacao;
                record[i].CodigoAntecipacao = registro53[i].CodigoAntecipacao;
                record[i].BaseST = registro53[i].BaseST;
                record[i].Modelo = registro53[i].Modelo;
                record[i].Emitente = registro53[i].Emitente;
                record[i].Despesas = registro53[i].Despesas;
                record[i].IcmsRetido = registro53[i].IcmsRetido; 
            }

            int ret = ACBrSintegraInterop.SIN_Registro53(this.Handle, record, registro53.Length);
            CheckResult(ret);
        }

        public void Registro54(List<SintegraRegistro54> registro54)
        {
            Registro54(registro54.ToArray());
        }

        public void Registro54(IEnumerable<SintegraRegistro54> registro54)
        {
            Registro54(registro54.ToArray());
        }

        public void Registro54(SintegraRegistro54[] registro54)
        {
            ACBrSintegraInterop.Registro54Rec[] record = new ACBrSintegraInterop.Registro54Rec[registro54.Length];
            for (int i = 0; i < registro54.Length; i++)
            {
                record[i].CPFCNPJ = registro54[i].CPFCNPJ;
                record[i].Aliquota = registro54[i].Aliquota;
                record[i].BaseST = registro54[i].BaseST;
                record[i].BasedeCalculo = registro54[i].BasedeCalculo;
                record[i].Quantidade = registro54[i].Quantidade;
                record[i].ValorDescontoDespesa = registro54[i].ValorDescontoDespesa;
                record[i].ValorIpi = registro54[i].ValorIpi;
                record[i].Valor = registro54[i].Valor;
                record[i].NumeroItem = registro54[i].NumeroItem;
                record[i].CST = registro54[i].CST;
                record[i].Codigo = registro54[i].Codigo;
                record[i].CFOP = registro54[i].CFOP;
                record[i].Descricao = registro54[i].Descricao;
                record[i].Numero = registro54[i].Numero;
                record[i].Modelo = registro54[i].Modelo;
                record[i].Serie = registro54[i].Serie;
            }

            int ret = ACBrSintegraInterop.SIN_Registro54(this.Handle, record, registro54.Length);
            CheckResult(ret);
        }

		#region Override Methods

		protected internal override void OnInitializeComponent()
		{
			CallCreate(ACBrSintegraInterop.SIN_Create);
		}

		protected internal override void CheckResult(int ret)
		{
			switch (ret)
			{
				case -1:

					string error = GetString(ACBrSintegraInterop.SIN_GetUltimoErro);
					throw new ACBrECFException(error);

				case -2:

					throw new ACBrECFException("ACBr Sintegra não inicializado.");
			}
		}

		protected override void OnDisposing()
		{
			if (this.Handle != IntPtr.Zero)
			{
				CallDestroy(ACBrSintegraInterop.SIN_Destroy);
			}
		}

		#endregion Override Methods

		#endregion Methods
	}
}