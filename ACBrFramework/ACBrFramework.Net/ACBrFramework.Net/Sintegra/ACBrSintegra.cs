using System;
using System.ComponentModel;
using System.Drawing;

namespace ACBrFramework.Sintegra
{
	[ToolboxBitmap(typeof(ToolboxIcons), @"ACBrFramework.Sintegra.ico.bmp")]
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

		public string Versao
		{
			get
			{
				return GetString(ACBrSintegraInterop.SIN_GetVersao);
			}
		}

		public VersaoValidador VersaoValidador
		{
			get
			{
				return (VersaoValidador)GetInt32(ACBrSintegraInterop.SIN_GetVersaoValidador);
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
			set
			{
				SetBool(ACBrSintegraInterop.SIN_SetAtivo, value);
			}
		}

		public bool Informa88C
		{
			get
			{
				return GetBool(ACBrSintegraInterop.SIN_GetInforma88C);
			}
			set
			{
				SetBool(ACBrSintegraInterop.SIN_SetInforma88C, value);
			}
		}

		public bool Informa88EAN
		{
			get
			{
				return GetBool(ACBrSintegraInterop.SIN_GetInforma88EAN);
			}
			set
			{
				SetBool(ACBrSintegraInterop.SIN_SetInforma88EAN, value);
			}
		}

		public bool Informa88SME
		{
			get
			{
				return GetBool(ACBrSintegraInterop.SIN_GetInforma88SME);
			}
			set
			{
				SetBool(ACBrSintegraInterop.SIN_SetInforma88SME, value);
			}
		}

		public bool Informa88SMS
		{
			get
			{
				return GetBool(ACBrSintegraInterop.SIN_GetInforma88SMS);
			}
			set
			{
				SetBool(ACBrSintegraInterop.SIN_SetInforma88SMS, value);
			}
		}

		public bool InformaSapiMG
		{
			get
			{
				return GetBool(ACBrSintegraInterop.SIN_GetInformaSapiMG);
			}
			set
			{
				SetBool(ACBrSintegraInterop.SIN_SetInformaSapiMG, value);
			}
		}

		[Browsable(false)]
		public SintegraRegistro10 Registro10 { get; private set; }

		[Browsable(false)]
		public SintegraRegistro11 Registro11 { get; private set; }

		[Browsable(false)]
		public SintegraRegistros50 Registro50 { get; private set; }

		[Browsable(false)]
		public SintegraRegistros51 Registro51 { get; private set; }

		[Browsable(false)]
		public SintegraRegistros53 Registro53 { get; private set; }

		[Browsable(false)]
		public SintegraRegistros54 Registro54 { get; private set; }

		[Browsable(false)]
		public SintegraRegistros55 Registro55 { get; private set; }

		[Browsable(false)]
		public SintegraRegistros56 Registro56 { get; private set; }

		[Browsable(false)]
		public SintegraRegistros60A Registro60A { get; private set; }

		[Browsable(false)]
		public SintegraRegistros60D Registro60D { get; private set; }

		[Browsable(false)]
		public SintegraRegistros60I Registro60I { get; private set; }

		[Browsable(false)]
		public SintegraRegistros60M Registro60M { get; private set; }

		[Browsable(false)]
		public SintegraRegistros60R Registro60R { get; private set; }

		[Browsable(false)]
		public SintegraRegistros61 Registro61 { get; private set; }

		[Browsable(false)]
		public SintegraRegistros61R Registro61R { get; private set; }

		[Browsable(false)]
		public SintegraRegistros70 Registro70 { get; private set; }

		[Browsable(false)]
		public SintegraRegistros71 Registro71 { get; private set; }

		[Browsable(false)]
		public SintegraRegistros74 Registro74 { get; private set; }

		[Browsable(false)]
		public SintegraRegistros75 Registro75 { get; private set; }

		[Browsable(false)]
		public SintegraRegistros76 Registro76 { get; private set; }

		[Browsable(false)]
		public SintegraRegistros77 Registro77 { get; private set; }

		[Browsable(false)]
		public SintegraRegistros85 Registro85 { get; private set; }

		[Browsable(false)]
		public SintegraRegistros86 Registro86 { get; private set; }

		#endregion Properties

		#region Methods

		#region Metodos Sintegra

		public void LimparRegistros()
		{
			LimparRegistros(true);
		}

		private void LimparRegistros(bool componente)
		{
			if (componente)
			{
				int ret = ACBrSintegraInterop.SIN_LimparRegistros(this.Handle);
				CheckResult(ret);
			}

			Registro10 = null;
			Registro10 = new SintegraRegistro10();
			Registro11 = null;
			Registro11 = new SintegraRegistro11();
			Registro50.Clear();
			Registro51.Clear();
			Registro53.Clear();
			Registro54.Clear();
			Registro55.Clear();
			Registro56.Clear();
			Registro60A.Clear();
			Registro60D.Clear();
			Registro60I.Clear();
			Registro60M.Clear();
			Registro60R.Clear();
			Registro61.Clear();
			Registro61R.Clear();
			Registro70.Clear();
			Registro71.Clear();
			Registro74.Clear();
			Registro75.Clear();
			Registro76.Clear();
			Registro77.Clear();
			Registro85.Clear();
			Registro86.Clear();
		}

		public void GeraArquivo()
		{
			GerarRegistro10();
			GerarRegistro11();
			GerarRegistro50();
			GerarRegistro51();
			GerarRegistro53();
			GerarRegistro54();
			GerarRegistro55();
			GerarRegistro56();
			GerarRegistro60M();
			GerarRegistro60A();
			GerarRegistro60D();
			GerarRegistro60I();			
			GerarRegistro60R();
			GerarRegistro61();
			GerarRegistro61R();
			GerarRegistro70();
			GerarRegistro71();
			GerarRegistro74();
			GerarRegistro75();
			GerarRegistro76();
			GerarRegistro77();
			GerarRegistro85();
			GerarRegistro86();

			int ret = ACBrSintegraInterop.SIN_GeraArquivo(this.Handle);
			CheckResult(ret);

			LimparRegistros(false);
		}

		#endregion Metodos Sintegra

		#region Registros

		private void GerarRegistro10()
		{
			var record = new ACBrSintegraInterop.Registro10Rec();
			record.RazaoSocial = ToUTF8(Registro10.RazaoSocial);
			record.CNPJ = ToUTF8(Registro10.CNPJ);
			record.Inscricao = ToUTF8(Registro10.Inscricao);
			record.Cidade = ToUTF8(Registro10.Cidade);
			record.Estado = ToUTF8(Registro10.Estado);
			record.Telefone = ToUTF8(Registro10.Telefone);
			record.DataInicial = Registro10.DataInicial.ToOADate();
			record.DataFinal = Registro10.DataFinal.ToOADate();
			record.NaturezaInformacoes = Registro10.NaturezaInformacoes;
			record.FinalidadeArquivo = Registro10.FinalidadeArquivo;
			record.CodigoConvenio = Registro10.CodigoConvenio;

			int ret = ACBrSintegraInterop.SIN_Registro10(this.Handle, record);
			CheckResult(ret);
		}

		private void GerarRegistro11()
		{
			var record = new ACBrSintegraInterop.Registro11Rec();
			record.Responsavel = ToUTF8(Registro11.Responsavel);
			record.Bairro = ToUTF8(Registro11.Bairro);
			record.Cep = ToUTF8(Registro11.Cep);
			record.Numero = ToUTF8(Registro11.Numero);
			record.Complemento = ToUTF8(Registro11.Complemento);
			record.Endereco = ToUTF8(Registro11.Endereco);
			record.Telefone = ToUTF8(Registro11.Telefone);

			int ret = ACBrSintegraInterop.SIN_Registro11(this.Handle, record);
			CheckResult(ret);
		}

		private void GerarRegistro50()
		{
			ACBrSintegraInterop.Registro50Rec[] record = new ACBrSintegraInterop.Registro50Rec[Registro50.Count];
			for (int i = 0; i < Registro50.Count; i++)
			{
				record[i].CPFCNPJ = ToUTF8(Registro50[i].CPFCNPJ);
				record[i].Inscricao = ToUTF8(Registro50[i].Inscricao);
				record[i].UF = ToUTF8(Registro50[i].UF);
				record[i].Situacao = ToUTF8(Registro50[i].Situacao);
				record[i].Aliquota = Convert.ToDouble(Registro50[i].Aliquota);
				record[i].Isentas = Convert.ToDouble(Registro50[i].Isentas);
				record[i].Icms = Convert.ToDouble(Registro50[i].Icms);
				record[i].ValorContabil = Convert.ToDouble(Registro50[i].ValorContabil);
				record[i].BasedeCalculo = Convert.ToDouble(Registro50[i].BasedeCalculo);
				record[i].Outras = Convert.ToDouble(Registro50[i].Outras);
				record[i].EmissorDocumento = ToUTF8(Registro50[i].EmissorDocumento);
				record[i].Cfop = ToUTF8(Registro50[i].Cfop);
				record[i].Serie = ToUTF8(Registro50[i].Serie);
				record[i].Modelo = ToUTF8(Registro50[i].Modelo);
				record[i].Numero = ToUTF8(Registro50[i].Numero);
				record[i].DataDocumento = Registro50[i].DataDocumento.ToOADate();
			}

			int ret = ACBrSintegraInterop.SIN_Registro50(this.Handle, record, Registro50.Count);
			CheckResult(ret);
		}

		private void GerarRegistro51()
		{
			ACBrSintegraInterop.Registro51Rec[] record = new ACBrSintegraInterop.Registro51Rec[Registro51.Count];
			for (int i = 0; i < Registro51.Count; i++)
			{
				record[i].CPFCNPJ = ToUTF8(Registro51[i].CPFCNPJ);
				record[i].Inscricao = ToUTF8(Registro51[i].Inscricao);
				record[i].Estado = ToUTF8(Registro51[i].Estado);
				record[i].ValorContabil = Convert.ToDouble(Registro51[i].ValorContabil);
				record[i].Cfop = ToUTF8(Registro51[i].Cfop);
				record[i].Serie = ToUTF8(Registro51[i].Serie);
				record[i].Numero = ToUTF8(Registro51[i].Numero);
				record[i].DataDocumento = Registro51[i].DataDocumento.ToOADate();
				record[i].ValorIpi = Convert.ToDouble(Registro51[i].ValorIpi);
				record[i].Situacao = ToUTF8(Registro51[i].Situacao);
				record[i].ValorIsentas = Convert.ToDouble(Registro51[i].ValorIsentas);
				record[i].ValorOutras = Convert.ToDouble(Registro51[i].ValorOutras);
			}

			int ret = ACBrSintegraInterop.SIN_Registro51(this.Handle, record, Registro51.Count);
			CheckResult(ret);
		}

		private void GerarRegistro53()
		{
			ACBrSintegraInterop.Registro53Rec[] record = new ACBrSintegraInterop.Registro53Rec[Registro53.Count];
			for (int i = 0; i < Registro53.Count; i++)
			{
				record[i].CPFCNPJ = Registro53[i].CPFCNPJ;
				record[i].Inscricao = Registro53[i].Inscricao;
				record[i].Estado = Registro53[i].Estado;
				record[i].Serie = Registro53[i].Serie;
				record[i].DataDocumento = Registro53[i].DataDocumento.ToOADate();
				record[i].Cfop = Registro53[i].Cfop;
				record[i].Numero = Registro53[i].Numero;
				record[i].Situacao = Registro53[i].Situacao;
				record[i].CodigoAntecipacao = Registro53[i].CodigoAntecipacao;
				record[i].BaseST = Convert.ToDouble(Registro53[i].BaseST);
				record[i].Modelo = Registro53[i].Modelo;
				record[i].Emitente = Registro53[i].Emitente;
				record[i].Despesas = Convert.ToDouble(Registro53[i].Despesas);
				record[i].IcmsRetido = Convert.ToDouble(Registro53[i].IcmsRetido);
			}

			int ret = ACBrSintegraInterop.SIN_Registro53(this.Handle, record, Registro53.Count);
			CheckResult(ret);
		}

		private void GerarRegistro54()
		{
			ACBrSintegraInterop.Registro54Rec[] record = new ACBrSintegraInterop.Registro54Rec[Registro54.Count];
			for (int i = 0; i < Registro54.Count; i++)
			{
				record[i].CPFCNPJ = Registro54[i].CPFCNPJ;
				record[i].Aliquota = Convert.ToDouble(Registro54[i].Aliquota);
				record[i].BaseST = Convert.ToDouble(Registro54[i].BaseST);
				record[i].BasedeCalculo = Convert.ToDouble(Registro54[i].BasedeCalculo);
				record[i].Quantidade = Convert.ToDouble(Registro54[i].Quantidade);
				record[i].ValorDescontoDespesa = Convert.ToDouble(Registro54[i].ValorDescontoDespesa);
				record[i].ValorIpi = Convert.ToDouble(Registro54[i].ValorIpi);
				record[i].Valor = Convert.ToDouble(Registro54[i].Valor);
				record[i].NumeroItem = Registro54[i].NumeroItem;
				record[i].CST = Registro54[i].CST;
				record[i].Codigo = Registro54[i].Codigo;
				record[i].CFOP = Registro54[i].CFOP;
				record[i].Descricao = Registro54[i].Descricao;
				record[i].Numero = Registro54[i].Numero;
				record[i].Modelo = Registro54[i].Modelo;
				record[i].Serie = Registro54[i].Serie;
			}

			int ret = ACBrSintegraInterop.SIN_Registro54(this.Handle, record, Registro54.Count);
			CheckResult(ret);
		}

		private void GerarRegistro55()
		{
			ACBrSintegraInterop.Registro55Rec[] record = new ACBrSintegraInterop.Registro55Rec[Registro55.Count];
			for (int i = 0; i < Registro55.Count; i++)
			{
				record[i].Valor = Convert.ToDouble(Registro55[i].Valor);
				record[i].Agencia = Registro55[i].Agencia;
				record[i].Banco = Registro55[i].Banco;
				record[i].NumeroConvenio = Registro55[i].NumeroConvenio;
				record[i].Inscricao = Registro55[i].Inscricao;
				record[i].MesAno = Registro55[i].MesAno;
				record[i].CNPJ = Registro55[i].CNPJ;
				record[i].UF = Registro55[i].UF;
				record[i].Numero = Registro55[i].Numero;
				record[i].DataPagamento = Registro55[i].DataPagamento.ToOADate();
				record[i].Vencimento = Registro55[i].Vencimento.ToOADate();
			}

			int ret = ACBrSintegraInterop.SIN_Registro55(this.Handle, record, Registro55.Count);
			CheckResult(ret);
		}

		private void GerarRegistro56()
		{
			ACBrSintegraInterop.Registro56Rec[] record = new ACBrSintegraInterop.Registro56Rec[Registro56.Count];
			for (int i = 0; i < Registro56.Count; i++)
			{
				record[i].Cnpj = Registro56[i].Cnpj;
				record[i].Modelo = Registro56[i].Modelo;
				record[i].Serie = Registro56[i].Serie;
				record[i].Numero = Registro56[i].Numero;
				record[i].Cfop = Registro56[i].Cfop;
				record[i].Cst = Registro56[i].Cst;
				record[i].NumeroItem = Registro56[i].NumeroItem;
				record[i].Codigo = Registro56[i].Codigo;
				record[i].TipoOperacao = Registro56[i].TipoOperacao;
				record[i].CnpjConcessionaria = Registro56[i].CnpjConcessionaria;
				record[i].Ipi = Convert.ToDouble(Registro56[i].Ipi);
				record[i].Chassi = Registro56[i].Chassi;
			}

			int ret = ACBrSintegraInterop.SIN_Registro56(this.Handle, record, Registro56.Count);
			CheckResult(ret);
		}

		private void GerarRegistro60A()
		{
			ACBrSintegraInterop.Registro60ARec[] record = new ACBrSintegraInterop.Registro60ARec[Registro60A.Count];
			for (int i = 0; i < Registro60A.Count; i++)
			{
				record[i].NumSerie = Registro60A[i].NumSerie;
				record[i].Aliquota = Registro60A[i].Aliquota;
				record[i].Emissao = Registro60A[i].Emissao.ToOADate();
				record[i].Valor = Convert.ToDouble(Registro60A[i].Valor);
			}

			int ret = ACBrSintegraInterop.SIN_Registro60A(this.Handle, record, Registro60A.Count);
			CheckResult(ret);
		}

		private void GerarRegistro60D()
		{
			ACBrSintegraInterop.Registro60DRec[] record = new ACBrSintegraInterop.Registro60DRec[Registro60D.Count];
			for (int i = 0; i < Registro60D.Count; i++)
			{
				record[i].NumSerie = Registro60D[i].NumSerie;
				record[i].StAliquota = Registro60D[i].StAliquota;
				record[i].Emissao = Registro60D[i].Emissao.ToOADate();
				record[i].Valor = Convert.ToDouble(Registro60D[i].Valor);
				record[i].Codigo = Registro60D[i].Codigo;
				record[i].ValorIcms = Convert.ToDouble(Registro60D[i].ValorIcms);
				record[i].Quantidade = Convert.ToDouble(Registro60D[i].Quantidade);
				record[i].BaseDeCalculo = Convert.ToDouble(Registro60D[i].BaseDeCalculo);
			}

			int ret = ACBrSintegraInterop.SIN_Registro60D(this.Handle, record, Registro60D.Count);
			CheckResult(ret);
		}

		private void GerarRegistro60I()
		{
			ACBrSintegraInterop.Registro60IRec[] record = new ACBrSintegraInterop.Registro60IRec[Registro60I.Count];
			for (int i = 0; i < Registro60I.Count; i++)
			{
				record[i].NumSerie = Registro60I[i].NumSerie;
				record[i].StAliquota = Registro60I[i].StAliquota;
				record[i].Emissao = Registro60I[i].Emissao.ToOADate();
				record[i].Valor = Convert.ToDouble(Registro60I[i].Valor);
				record[i].Codigo = Registro60I[i].Codigo;
				record[i].ValorIcms = Convert.ToDouble(Registro60I[i].ValorIcms);
				record[i].Quantidade = Convert.ToDouble(Registro60I[i].Quantidade);
				record[i].BaseDeCalculo = Convert.ToDouble(Registro60I[i].BaseDeCalculo);
				record[i].Item = Registro60I[i].Item;
				record[i].Cupom = Registro60I[i].Cupom;
				record[i].ModeloDoc = Registro60I[i].ModeloDoc;
			}

			int ret = ACBrSintegraInterop.SIN_Registro60I(this.Handle, record, Registro60I.Count);
			CheckResult(ret);
		}

		private void GerarRegistro60M()
		{
			ACBrSintegraInterop.Registro60MRec[] record = new ACBrSintegraInterop.Registro60MRec[Registro60M.Count];
			for (int i = 0; i < Registro60M.Count; i++)
			{
				record[i].CRO = Registro60M[i].CRO;
				record[i].NumOrdem = Registro60M[i].NumOrdem;
				record[i].VendaBruta = Convert.ToDouble(Registro60M[i].VendaBruta);
				record[i].ModeloDoc = Registro60M[i].ModeloDoc;
				record[i].ValorGT = Convert.ToDouble(Registro60M[i].ValorGT);
				record[i].CRZ = Registro60M[i].CRZ;
				record[i].CooFinal = Registro60M[i].CooFinal;
				record[i].CooInicial = Registro60M[i].CooInicial;
				record[i].NumSerie = Registro60M[i].NumSerie;
				record[i].Emissao = Registro60M[i].Emissao.ToOADate();
			}

			int ret = ACBrSintegraInterop.SIN_Registro60M(this.Handle, record, Registro60M.Count);
			CheckResult(ret);
		}

		private void GerarRegistro60R()
		{
			ACBrSintegraInterop.Registro60RRec[] record = new ACBrSintegraInterop.Registro60RRec[Registro60R.Count];
			for (int i = 0; i < Registro60R.Count; i++)
			{
				record[i].BaseDeCalculo = Convert.ToDouble(Registro60R[i].BaseDeCalculo);
				record[i].Valor = Convert.ToDouble(Registro60R[i].Valor);
				record[i].Qtd = Convert.ToDouble(Registro60R[i].Qtd);
				record[i].MesAno = Registro60R[i].MesAno;
				record[i].Codigo = Registro60R[i].Codigo;
				record[i].Aliquota = Registro60R[i].Aliquota;
			}

			int ret = ACBrSintegraInterop.SIN_Registro60R(this.Handle, record, Registro60R.Count);
			CheckResult(ret);
		}

		private void GerarRegistro61()
		{
			ACBrSintegraInterop.Registro61Rec[] record = new ACBrSintegraInterop.Registro61Rec[Registro61.Count];
			for (int i = 0; i < Registro61.Count; i++)
			{
				record[i].Emissao = Registro61[i].Emissao.ToOADate();
				record[i].Valor = Convert.ToDouble(Registro61[i].Valor);
				record[i].ValorIcms = Convert.ToDouble(Registro61[i].ValorIcms);
				record[i].Outras = Convert.ToDouble(Registro61[i].Outras);
				record[i].BaseDeCalculo = Convert.ToDouble(Registro61[i].BaseDeCalculo);
				record[i].Isentas = Convert.ToDouble(Registro61[i].Isentas);
				record[i].NumOrdemInicial = Registro61[i].NumOrdemInicial;
				record[i].NumOrdemFinal = Registro61[i].NumOrdemFinal;
				record[i].Modelo = Registro61[i].Modelo;
				record[i].SubSerie = Registro61[i].SubSerie;
				record[i].Serie = Registro61[i].Serie;
				record[i].Aliquota = Convert.ToDouble(Registro61[i].Aliquota);
			}

			int ret = ACBrSintegraInterop.SIN_Registro61(this.Handle, record, Registro61.Count);
			CheckResult(ret);
		}

		private void GerarRegistro61R()
		{
			ACBrSintegraInterop.Registro61RRec[] record = new ACBrSintegraInterop.Registro61RRec[Registro61R.Count];
			for (int i = 0; i < Registro61R.Count; i++)
			{
				record[i].Aliquota = Convert.ToDouble(Registro61R[i].Aliquota);
				record[i].Valor = Convert.ToDouble(Registro61R[i].Valor);
				record[i].Qtd = Convert.ToDouble(Registro61R[i].Qtd);
				record[i].MesAno = Registro61R[i].MesAno;
				record[i].Codigo = Registro61R[i].Codigo;
				record[i].BaseDeCalculo = Convert.ToDouble(Registro61R[i].BaseDeCalculo);
			}

			int ret = ACBrSintegraInterop.SIN_Registro61R(this.Handle, record, Registro61R.Count);
			CheckResult(ret);
		}

		private void GerarRegistro70()
		{
			ACBrSintegraInterop.Registro70Rec[] record = new ACBrSintegraInterop.Registro70Rec[Registro70.Count];
			for (int i = 0; i < Registro70.Count; i++)
			{
				record[i].Icms = Convert.ToDouble(Registro70[i].Icms);
				record[i].ValorContabil = Convert.ToDouble(Registro70[i].ValorContabil);
				record[i].UF = Registro70[i].UF;
				record[i].Isentas = Convert.ToDouble(Registro70[i].Isentas);
				record[i].SubSerie = Registro70[i].SubSerie;
				record[i].Serie = Registro70[i].Serie;
				record[i].DataDocumento = Registro70[i].DataDocumento.ToOADate();
				record[i].Modelo = Registro70[i].Modelo;
				record[i].CPFCNPJ = Registro70[i].CPFCNPJ;
				record[i].Cfop = Registro70[i].Cfop;
				record[i].Numero = Registro70[i].Numero;
				record[i].Inscricao = Registro70[i].Inscricao;
				record[i].Situacao = Registro70[i].Situacao;
				record[i].Outras = Convert.ToDouble(Registro70[i].Outras);
				record[i].BasedeCalculo = Convert.ToDouble(Registro70[i].BasedeCalculo);
				record[i].CifFobOutros = Registro70[i].CifFobOutros;
			}

			int ret = ACBrSintegraInterop.SIN_Registro70(this.Handle, record, Registro70.Count);
			CheckResult(ret);
		}

		private void GerarRegistro71()
		{
			ACBrSintegraInterop.Registro71Rec[] record = new ACBrSintegraInterop.Registro71Rec[Registro71.Count];
			for (int i = 0; i < Registro71.Count; i++)
			{
				record[i].CPFCNPJ = Registro71[i].CPFCNPJ;
				record[i].Inscricao = Registro71[i].Inscricao;
				record[i].DataDocumento = Registro71[i].DataDocumento.ToOADate();
				record[i].Modelo = Registro71[i].Modelo;
				record[i].Serie = Registro71[i].Serie;
				record[i].SubSerie = Registro71[i].SubSerie;
				record[i].Numero = Registro71[i].Numero;
				record[i].UF = Registro71[i].UF;
				record[i].UFNF = Registro71[i].UFNF;
				record[i].CPFCNPJNF = Registro71[i].CPFCNPJNF;
				record[i].InscricaoNF = Registro71[i].InscricaoNF;
				record[i].DataNF = Registro71[i].DataNF.ToOADate();
				record[i].ModeloNF = Registro71[i].ModeloNF;
				record[i].SerieNF = Registro71[i].SerieNF;
				record[i].NumeroNF = Registro71[i].NumeroNF;
				record[i].ValorNF = Convert.ToDouble(Registro71[i].ValorNF);
			}

			int ret = ACBrSintegraInterop.SIN_Registro71(this.Handle, record, Registro71.Count);
			CheckResult(ret);
		}

		private void GerarRegistro74()
		{
			ACBrSintegraInterop.Registro74Rec[] record = new ACBrSintegraInterop.Registro74Rec[Registro74.Count];
			for (int i = 0; i < Registro74.Count; i++)
			{
				record[i].ValorProduto = Convert.ToDouble(Registro74[i].ValorProduto);
				record[i].CodigoPosse = Registro74[i].CodigoPosse;
				record[i].InscricaoPossuidor = Registro74[i].InscricaoPossuidor;
				record[i].Codigo = Registro74[i].Codigo;
				record[i].CNPJPossuidor = Registro74[i].CNPJPossuidor;
				record[i].UFPossuidor = Registro74[i].UFPossuidor;
				record[i].Data = Registro74[i].Data.ToOADate();
				record[i].Quantidade = Convert.ToDouble(Registro74[i].Quantidade);
			}

			int ret = ACBrSintegraInterop.SIN_Registro74(this.Handle, record, Registro74.Count);
			CheckResult(ret);
		}

		private void GerarRegistro75()
		{
			ACBrSintegraInterop.Registro75Rec[] record = new ACBrSintegraInterop.Registro75Rec[Registro75.Count];
			for (int i = 0; i < Registro75.Count; i++)
			{
				record[i].Codigo = Registro75[i].Codigo;
				record[i].Descricao = Registro75[i].Descricao;
				record[i].Reducao = Convert.ToDouble(Registro75[i].Reducao);
				record[i].BaseST = Convert.ToDouble(Registro75[i].BaseST);
				record[i].AliquotaIpi = Convert.ToDouble(Registro75[i].AliquotaIpi);
				record[i].NCM = Registro75[i].NCM;
				record[i].Unidade = Registro75[i].Unidade;
				record[i].AliquotaICMS = Convert.ToDouble(Registro75[i].AliquotaICMS);
				record[i].DataFinal = Registro75[i].DataFinal.ToOADate();
				record[i].DataInicial = Registro75[i].DataInicial.ToOADate();
			}

			int ret = ACBrSintegraInterop.SIN_Registro75(this.Handle, record, Registro75.Count);
			CheckResult(ret);
		}

		private void GerarRegistro76()
		{
			ACBrSintegraInterop.Registro76Rec[] record = new ACBrSintegraInterop.Registro76Rec[Registro76.Count];
			for (int i = 0; i < Registro76.Count; i++)
			{
				record[i].Isentas = Convert.ToDouble(Registro76[i].Isentas);
				record[i].ValorTotal = Convert.ToDouble(Registro76[i].ValorTotal);
				record[i].Icms = Convert.ToDouble(Registro76[i].Icms);
				record[i].BasedeCalculo = Convert.ToDouble(Registro76[i].BasedeCalculo);
				record[i].Outras = Convert.ToDouble(Registro76[i].Outras);
				record[i].Modelo = Registro76[i].Modelo;
				record[i].Numero = Registro76[i].Numero;
				record[i].Situacao = Registro76[i].Situacao;
				record[i].Inscricao = Registro76[i].Inscricao;
				record[i].SubSerie = Registro76[i].SubSerie;
				record[i].Uf = Registro76[i].Uf;
				record[i].Serie = Registro76[i].Serie;
				record[i].Cfop = Registro76[i].Cfop;
				record[i].CPFCNPJ = Registro76[i].CPFCNPJ;
				record[i].DataDocumento = Registro76[i].DataDocumento.ToOADate();
				record[i].TipoReceita = (int)Registro76[i].TipoReceita;
				record[i].Aliquota = Registro76[i].Aliquota;
			}

			int ret = ACBrSintegraInterop.SIN_Registro76(this.Handle, record, Registro76.Count);
			CheckResult(ret);
		}

		private void GerarRegistro77()
		{
			ACBrSintegraInterop.Registro77Rec[] record = new ACBrSintegraInterop.Registro77Rec[Registro77.Count];
			for (int i = 0; i < Registro77.Count; i++)
			{
				record[i].Quantidade = Convert.ToDouble(Registro77[i].Quantidade);
				record[i].ValorServico = Convert.ToDouble(Registro77[i].ValorServico);
				record[i].ValorDesconto = Convert.ToDouble(Registro77[i].ValorDesconto);
				record[i].BaseDeCalculo = Convert.ToDouble(Registro77[i].BaseDeCalculo);
				record[i].Modelo = Registro77[i].Modelo;
				record[i].Numero = Registro77[i].Numero;
				record[i].NumeroTerminal = Registro77[i].NumeroTerminal;
				record[i].NumeroItem = Registro77[i].NumeroItem;
				record[i].Aliquota = Registro77[i].Aliquota;
				record[i].CNPJMF = Registro77[i].CNPJMF;
				record[i].Cfop = Registro77[i].Cfop;
				record[i].Codigo = Registro77[i].Codigo;
				record[i].SubSerie = Registro77[i].SubSerie;
				record[i].CPFCNPJ = Registro77[i].CPFCNPJ;
				record[i].Serie = Registro77[i].Serie;
				record[i].TipoReceita = (int)Registro77[i].TipoReceita;
			}

			int ret = ACBrSintegraInterop.SIN_Registro77(this.Handle, record, Registro77.Count);
			CheckResult(ret);
		}

		private void GerarRegistro85()
		{
			ACBrSintegraInterop.Registro85Rec[] record = new ACBrSintegraInterop.Registro85Rec[Registro85.Count];
			for (int i = 0; i < Registro85.Count; i++)
			{
				record[i].Declaracao = Registro85[i].Declaracao;
				record[i].DataDeclaracao = Registro85[i].DataDeclaracao.ToOADate();
				record[i].NaturezaExportacao = Registro85[i].NaturezaExportacao;
				record[i].RegistroExportacao = Registro85[i].RegistroExportacao;
				record[i].DataRegistro = Registro85[i].DataRegistro.ToOADate();
				record[i].Conhecimento = Registro85[i].Conhecimento;
				record[i].DataConhecimento = Registro85[i].DataConhecimento.ToOADate();
				record[i].TipoConhecimento = Registro85[i].TipoConhecimento;
				record[i].Pais = Registro85[i].Pais;
				record[i].DataAverbacao = Registro85[i].DataAverbacao.ToOADate();
				record[i].NumeroNotaFiscal = Registro85[i].NumeroNotaFiscal;
				record[i].DataNotaFiscal = Registro85[i].DataNotaFiscal.ToOADate();
				record[i].Modelo = Registro85[i].Modelo;
				record[i].Serie = Registro85[i].Serie;
			}

			int ret = ACBrSintegraInterop.SIN_Registro85(this.Handle, record, Registro85.Count);
			CheckResult(ret);
		}

		private void GerarRegistro86()
		{
			ACBrSintegraInterop.Registro86Rec[] record = new ACBrSintegraInterop.Registro86Rec[Registro86.Count];
			for (int i = 0; i < Registro86.Count; i++)
			{
				record[i].RegistroExportacao = Registro86[i].RegistroExportacao;
				record[i].DataRegistro = Registro86[i].DataRegistro.ToOADate();
				record[i].CPFCNPJ = Registro86[i].CPFCNPJ;
				record[i].Inscricao = Registro86[i].Inscricao;
				record[i].UF = Registro86[i].UF;
				record[i].NumeroNotaFiscal = Registro86[i].NumeroNotaFiscal;
				record[i].DataDocumento = Registro86[i].DataDocumento.ToOADate();
				record[i].Modelo = Registro86[i].Modelo;
				record[i].Serie = Registro86[i].Serie;
				record[i].Codigo = Registro86[i].Codigo;
				record[i].Quantidade = Convert.ToDouble(Registro86[i].Quantidade);
				record[i].ValorUnitario = Convert.ToDouble(Registro86[i].ValorUnitario);
				record[i].ValorTotalProduto = Convert.ToDouble(Registro86[i].ValorTotalProduto);
				record[i].Relacionamento = Registro86[i].Relacionamento;
			}

			int ret = ACBrSintegraInterop.SIN_Registro86(this.Handle, record, Registro86.Count);
			CheckResult(ret);
		}

		#endregion Registros

		#region Override Methods

		protected internal override void OnInitialize()
		{
			CallCreate(ACBrSintegraInterop.SIN_Create);
			Registro10 = new SintegraRegistro10();
			Registro11 = new SintegraRegistro11();
			Registro50 = new SintegraRegistros50();
			Registro51 = new SintegraRegistros51();
			Registro53 = new SintegraRegistros53();
			Registro54 = new SintegraRegistros54();
			Registro55 = new SintegraRegistros55();
			Registro56 = new SintegraRegistros56();
			Registro60A = new SintegraRegistros60A();
			Registro60D = new SintegraRegistros60D();
			Registro60I = new SintegraRegistros60I();
			Registro60M = new SintegraRegistros60M();
			Registro60R = new SintegraRegistros60R();
			Registro61 = new SintegraRegistros61();
			Registro61R = new SintegraRegistros61R();
			Registro70 = new SintegraRegistros70();
			Registro71 = new SintegraRegistros71();
			Registro74 = new SintegraRegistros74();
			Registro75 = new SintegraRegistros75();
			Registro76 = new SintegraRegistros76();
			Registro77 = new SintegraRegistros77();
			Registro85 = new SintegraRegistros85();
			Registro86 = new SintegraRegistros86();
		}

		protected internal override void CheckResult(int ret)
		{
			switch (ret)
			{
				case -1:

					string error = GetString(ACBrSintegraInterop.SIN_GetUltimoErro);
					throw new ACBrException(error);

				case -2:

					throw new ACBrException("ACBr Sintegra não inicializado.");
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