using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;

namespace ACBrFramework
{
	[ToolboxBitmap(typeof(ACBrSintegra), @"Sintegra.ico.bmp")]
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

		#region Metodos Sintegra
	
		public void LimparRegistros()
		{
			int ret = ACBrSintegraInterop.SIN_LimparRegistros(this.Handle);
			CheckResult(ret);
		}

		public void GeraArquivo()
		{
			int ret = ACBrSintegraInterop.SIN_GeraArquivo(this.Handle);
			CheckResult(ret);
		}
		
		#endregion Metodos Sintegra
		
		#region Registros
	
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

		public void Registro55(List<SintegraRegistro55> registro55)
		{
			Registro55(registro55.ToArray());
		}

		public void Registro55(IEnumerable<SintegraRegistro55> registro55)
		{
			Registro55(registro55.ToArray());
		}

		public void Registro55(SintegraRegistro55[] registro55)
		{
			ACBrSintegraInterop.Registro55Rec[] record = new ACBrSintegraInterop.Registro55Rec[registro55.Length];
			for (int i = 0; i < registro55.Length; i++)
			{
				record[i].Valor = registro55[i].Valor;
				record[i].Agencia = registro55[i].Agencia;
				record[i].Banco = registro55[i].Banco;
				record[i].NumeroConvenio = registro55[i].NumeroConvenio;
				record[i].Inscricao = registro55[i].Inscricao;
				record[i].MesAno = registro55[i].MesAno;
				record[i].CNPJ = registro55[i].CNPJ;
				record[i].UF = registro55[i].UF;
				record[i].Numero = registro55[i].Numero;
				record[i].DataPagamento = registro55[i].DataPagamento.ToOADate();
				record[i].Vencimento = registro55[i].Vencimento.ToOADate();
			}

			int ret = ACBrSintegraInterop.SIN_Registro55(this.Handle, record, registro55.Length);
			CheckResult(ret);
		}

		public void Registro56(List<SintegraRegistro56> registro56)
		{
			Registro56(registro56.ToArray());
		}

		public void Registro56(IEnumerable<SintegraRegistro56> registro56)
		{
			Registro56(registro56.ToArray());
		}

		public void Registro56(SintegraRegistro56[] registro56)
		{
			ACBrSintegraInterop.Registro56Rec[] record = new ACBrSintegraInterop.Registro56Rec[registro56.Length];
			for (int i = 0; i < registro56.Length; i++)
			{
				record[i].Cnpj = registro56[i].Cnpj;
				record[i].Modelo = registro56[i].Modelo;
				record[i].Serie = registro56[i].Serie;
				record[i].Numero = registro56[i].Numero;
				record[i].Cfop = registro56[i].Cfop;
				record[i].Cst = registro56[i].Cst;
				record[i].NumeroItem = registro56[i].NumeroItem;
				record[i].Codigo = registro56[i].Codigo;
				record[i].TipoOperacao = registro56[i].TipoOperacao;
				record[i].CnpjConcessionaria = registro56[i].CnpjConcessionaria;
				record[i].Ipi = registro56[i].Ipi;
				record[i].Chassi = registro56[i].Chassi;
			}

			int ret = ACBrSintegraInterop.SIN_Registro56(this.Handle, record, registro56.Length);
			CheckResult(ret);
		}

		public void Registro60A(List<SintegraRegistro60A> registro60A)
		{
			Registro60A(registro60A.ToArray());
		}

		public void Registro60A(IEnumerable<SintegraRegistro60A> registro60A)
		{
			Registro60A(registro60A.ToArray());
		}

		public void Registro60A(SintegraRegistro60A[] registro60A)
		{
			ACBrSintegraInterop.Registro60ARec[] record = new ACBrSintegraInterop.Registro60ARec[registro60A.Length];
			for (int i = 0; i < registro60A.Length; i++)
			{
				record[i].NumSerie = registro60A[i].NumSerie;
				record[i].Aliquota = registro60A[i].Aliquota;
				record[i].Emissao = registro60A[i].Emissao.ToOADate();
				record[i].Valor = registro60A[i].Valor;
			}

			int ret = ACBrSintegraInterop.SIN_Registro60A(this.Handle, record, registro60A.Length);
			CheckResult(ret);
		}

		public void Registro60D(List<SintegraRegistro60D> registro60D)
		{
			Registro60D(registro60D.ToArray());
		}

		public void Registro60D(IEnumerable<SintegraRegistro60D> registro60D)
		{
			Registro60D(registro60D.ToArray());
		}

		public void Registro60D(SintegraRegistro60D[] registro60D)
		{
			ACBrSintegraInterop.Registro60DRec[] record = new ACBrSintegraInterop.Registro60DRec[registro60D.Length];
			for (int i = 0; i < registro60D.Length; i++)
			{
				record[i].NumSerie = registro60D[i].NumSerie;
				record[i].StAliquota = registro60D[i].StAliquota;
				record[i].Emissao = registro60D[i].Emissao.ToOADate();
				record[i].Valor = registro60D[i].Valor;
				record[i].Codigo = registro60D[i].Codigo;
				record[i].ValorIcms = registro60D[i].ValorIcms;
				record[i].Quantidade = registro60D[i].Quantidade;
				record[i].BaseDeCalculo = registro60D[i].BaseDeCalculo;
			}

			int ret = ACBrSintegraInterop.SIN_Registro60D(this.Handle, record, registro60D.Length);
			CheckResult(ret);
		}

		public void Registro60I(List<SintegraRegistro60I> registro60I)
		{
			Registro60I(registro60I.ToArray());
		}

		public void Registro60I(IEnumerable<SintegraRegistro60I> registro60I)
		{
			Registro60I(registro60I.ToArray());
		}

		public void Registro60I(SintegraRegistro60I[] registro60I)
		{
			ACBrSintegraInterop.Registro60IRec[] record = new ACBrSintegraInterop.Registro60IRec[registro60I.Length];
			for (int i = 0; i < registro60I.Length; i++)
			{
				record[i].NumSerie = registro60I[i].NumSerie;
				record[i].StAliquota = registro60I[i].StAliquota;
				record[i].Emissao = registro60I[i].Emissao.ToOADate();
				record[i].Valor = registro60I[i].Valor;
				record[i].Codigo = registro60I[i].Codigo;
				record[i].ValorIcms = registro60I[i].ValorIcms;
				record[i].Quantidade = registro60I[i].Quantidade;
				record[i].BaseDeCalculo = registro60I[i].BaseDeCalculo;
				record[i].Item = registro60I[i].Item;
				record[i].Cupom = registro60I[i].Cupom;
				record[i].ModeloDoc = registro60I[i].ModeloDoc;
			}

			int ret = ACBrSintegraInterop.SIN_Registro60I(this.Handle, record, registro60I.Length);
			CheckResult(ret);
		}

		public void Registro60M(List<SintegraRegistro60M> registro60M)
		{
			Registro60M(registro60M.ToArray());
		}

		public void Registro60M(IEnumerable<SintegraRegistro60M> registro60M)
		{
			Registro60M(registro60M.ToArray());
		}

		public void Registro60M(SintegraRegistro60M[] registro60M)
		{
			ACBrSintegraInterop.Registro60MRec[] record = new ACBrSintegraInterop.Registro60MRec[registro60M.Length];
			for (int i = 0; i < registro60M.Length; i++)
			{
				record[i].CRO = registro60M[i].CRO;
				record[i].NumOrdem = registro60M[i].NumOrdem;
				record[i].VendaBruta = registro60M[i].VendaBruta;
				record[i].ModeloDoc = registro60M[i].ModeloDoc;
				record[i].ValorGT = registro60M[i].ValorGT;
				record[i].CRZ = registro60M[i].CRZ;
				record[i].CooFinal = registro60M[i].CooFinal;
				record[i].CooInicial = registro60M[i].CooInicial;
				record[i].NumSerie = registro60M[i].NumSerie;
				record[i].Emissao = registro60M[i].Emissao.ToOADate();
			}

			int ret = ACBrSintegraInterop.SIN_Registro60M(this.Handle, record, registro60M.Length);
			CheckResult(ret);
		}

		public void Registro60R(List<SintegraRegistro60R> registro60R)
		{
			Registro60R(registro60R.ToArray());
		}

		public void Registro60R(IEnumerable<SintegraRegistro60R> registro60R)
		{
			Registro60R(registro60R.ToArray());
		}

		public void Registro60R(SintegraRegistro60R[] registro60R)
		{
			ACBrSintegraInterop.Registro60RRec[] record = new ACBrSintegraInterop.Registro60RRec[registro60R.Length];
			for (int i = 0; i < registro60R.Length; i++)
			{
				record[i].BaseDeCalculo = registro60R[i].BaseDeCalculo;
				record[i].Valor = registro60R[i].Valor;
				record[i].Qtd = registro60R[i].Qtd;
				record[i].MesAno = registro60R[i].MesAno;
				record[i].Codigo = registro60R[i].Codigo;
				record[i].Aliquota = registro60R[i].Aliquota;
			}

			int ret = ACBrSintegraInterop.SIN_Registro60R(this.Handle, record, registro60R.Length);
			CheckResult(ret);
		}

		public void Registro61(List<SintegraRegistro61> registro61)
		{
			Registro61(registro61.ToArray());
		}

		public void Registro61(IEnumerable<SintegraRegistro61> registro61)
		{
			Registro61(registro61.ToArray());
		}

		public void Registro61(SintegraRegistro61[] registro61)
		{
			ACBrSintegraInterop.Registro61Rec[] record = new ACBrSintegraInterop.Registro61Rec[registro61.Length];
			for (int i = 0; i < registro61.Length; i++)
			{
				record[i].Emissao = registro61[i].Emissao.ToOADate();
				record[i].Valor = registro61[i].Valor;
				record[i].ValorIcms = registro61[i].ValorIcms;
				record[i].Outras = registro61[i].Outras;
				record[i].BaseDeCalculo = registro61[i].BaseDeCalculo;
				record[i].Isentas = registro61[i].Isentas;
				record[i].NumOrdemInicial = registro61[i].NumOrdemInicial;
				record[i].NumOrdemFinal = registro61[i].NumOrdemFinal;
				record[i].Modelo = registro61[i].Modelo;
				record[i].SubSerie = registro61[i].SubSerie;
				record[i].Serie = registro61[i].Serie;
				record[i].Aliquota = registro61[i].Aliquota;
			}

			int ret = ACBrSintegraInterop.SIN_Registro61(this.Handle, record, registro61.Length);
			CheckResult(ret);
		}

		public void Registro61R(List<SintegraRegistro61R> registro61R)
		{
			Registro61R(registro61R.ToArray());
		}

		public void Registro61R(IEnumerable<SintegraRegistro61R> registro61R)
		{
			Registro61R(registro61R.ToArray());
		}

		public void Registro61R(SintegraRegistro61R[] registro61R)
		{
			ACBrSintegraInterop.Registro61RRec[] record = new ACBrSintegraInterop.Registro61RRec[registro61R.Length];
			for (int i = 0; i < registro61R.Length; i++)
			{
				record[i].Aliquota = registro61R[i].Aliquota;
				record[i].Valor = registro61R[i].Valor;
				record[i].Qtd = registro61R[i].Qtd;
				record[i].MesAno = registro61R[i].MesAno;
				record[i].Codigo = registro61R[i].Codigo;
				record[i].BaseDeCalculo = registro61R[i].BaseDeCalculo;
			}

			int ret = ACBrSintegraInterop.SIN_Registro61R(this.Handle, record, registro61R.Length);
			CheckResult(ret);
		}

		public void Registro70(List<SintegraRegistro70> registro70)
		{
			Registro70(registro70.ToArray());
		}

		public void Registro70(IEnumerable<SintegraRegistro70> registro70)
		{
			Registro70(registro70.ToArray());
		}

		public void Registro70(SintegraRegistro70[] registro70)
		{
			ACBrSintegraInterop.Registro70Rec[] record = new ACBrSintegraInterop.Registro70Rec[registro70.Length];
			for (int i = 0; i < registro70.Length; i++)
			{
				record[i].Icms = registro70[i].Icms;
				record[i].ValorContabil = registro70[i].ValorContabil;
				record[i].UF = registro70[i].UF;
				record[i].Isentas = registro70[i].Isentas;
				record[i].SubSerie = registro70[i].SubSerie;
				record[i].Serie = registro70[i].Serie;
				record[i].DataDocumento = registro70[i].DataDocumento.ToOADate();
				record[i].Modelo = registro70[i].Modelo;
				record[i].CPFCNPJ = registro70[i].CPFCNPJ;
				record[i].Cfop = registro70[i].Cfop;
				record[i].Numero = registro70[i].Numero;
				record[i].Inscricao = registro70[i].Inscricao;
				record[i].Situacao = registro70[i].Situacao;
				record[i].Outras = registro70[i].Outras;
				record[i].BasedeCalculo = registro70[i].BasedeCalculo;
				record[i].CifFobOutros = registro70[i].CifFobOutros;
			}

			int ret = ACBrSintegraInterop.SIN_Registro70(this.Handle, record, registro70.Length);
			CheckResult(ret);
		}

		public void Registro71(List<SintegraRegistro71> registro71)
		{
			Registro71(registro71.ToArray());
		}

		public void Registro71(IEnumerable<SintegraRegistro71> registro71)
		{
			Registro71(registro71.ToArray());
		}

		public void Registro71(SintegraRegistro71[] registro71)
		{
			ACBrSintegraInterop.Registro71Rec[] record = new ACBrSintegraInterop.Registro71Rec[registro71.Length];
			for (int i = 0; i < registro71.Length; i++)
			{
				record[i].CPFCNPJ = registro71[i].CPFCNPJ;
				record[i].Inscricao = registro71[i].Inscricao;
				record[i].DataDocumento = registro71[i].DataDocumento.ToOADate();
				record[i].Modelo = registro71[i].Modelo;
				record[i].Serie = registro71[i].Serie;
				record[i].SubSerie = registro71[i].SubSerie;
				record[i].Numero = registro71[i].Numero;
				record[i].UF = registro71[i].UF;
				record[i].UFNF = registro71[i].UFNF;
				record[i].CPFCNPJNF = registro71[i].CPFCNPJNF;
				record[i].InscricaoNF = registro71[i].InscricaoNF;
				record[i].DataNF = registro71[i].DataNF.ToOADate();
				record[i].ModeloNF = registro71[i].ModeloNF;
				record[i].SerieNF = registro71[i].SerieNF;
				record[i].NumeroNF = registro71[i].NumeroNF;
				record[i].ValorNF = registro71[i].ValorNF;
			}

			int ret = ACBrSintegraInterop.SIN_Registro71(this.Handle, record, registro71.Length);
			CheckResult(ret);
		}

		public void Registro74(List<SintegraRegistro74> registro74)
		{
			Registro74(registro74.ToArray());
		}

		public void Registro74(IEnumerable<SintegraRegistro74> registro74)
		{
			Registro74(registro74.ToArray());
		}

		public void Registro74(SintegraRegistro74[] registro74)
		{
			ACBrSintegraInterop.Registro74Rec[] record = new ACBrSintegraInterop.Registro74Rec[registro74.Length];
			for (int i = 0; i < registro74.Length; i++)
			{
				record[i].ValorProduto = registro74[i].ValorProduto;
				record[i].CodigoPosse = registro74[i].CodigoPosse;
				record[i].InscricaoPossuidor = registro74[i].InscricaoPossuidor;
				record[i].Codigo = registro74[i].Codigo;
				record[i].CNPJPossuidor = registro74[i].CNPJPossuidor;
				record[i].UFPossuidor = registro74[i].UFPossuidor;
				record[i].Data = registro74[i].Data.ToOADate();
				record[i].Quantidade = registro74[i].Quantidade;
			}

			int ret = ACBrSintegraInterop.SIN_Registro74(this.Handle, record, registro74.Length);
			CheckResult(ret);
		}

		public void Registro75(List<SintegraRegistro75> registro75)
		{
			Registro75(registro75.ToArray());
		}

		public void Registro75(IEnumerable<SintegraRegistro75> registro75)
		{
			Registro75(registro75.ToArray());
		}

		public void Registro75(SintegraRegistro75[] registro75)
		{
			ACBrSintegraInterop.Registro75Rec[] record = new ACBrSintegraInterop.Registro75Rec[registro75.Length];
			for (int i = 0; i < registro75.Length; i++)
			{
				record[i].Codigo = registro75[i].Codigo;
				record[i].Descricao = registro75[i].Descricao;
				record[i].Reducao = registro75[i].Reducao;
				record[i].BaseST = registro75[i].BaseST;
				record[i].AliquotaIpi = registro75[i].AliquotaIpi;
				record[i].NCM = registro75[i].NCM;
				record[i].Unidade = registro75[i].Unidade;
				record[i].AliquotaICMS = registro75[i].AliquotaICMS;
				record[i].DataFinal = registro75[i].DataFinal.ToOADate();
				record[i].DataInicial = registro75[i].DataInicial.ToOADate();
			}

			int ret = ACBrSintegraInterop.SIN_Registro75(this.Handle, record, registro75.Length);
			CheckResult(ret);
		}

		public void Registro76(List<SintegraRegistro76> registro76)
		{
			Registro76(registro76.ToArray());
		}

		public void Registro76(IEnumerable<SintegraRegistro76> registro76)
		{
			Registro76(registro76.ToArray());
		}

		public void Registro76(SintegraRegistro76[] registro76)
		{
			ACBrSintegraInterop.Registro76Rec[] record = new ACBrSintegraInterop.Registro76Rec[registro76.Length];
			for (int i = 0; i < registro76.Length; i++)
			{
				record[i].Isentas = registro76[i].Isentas;
				record[i].ValorTotal = registro76[i].ValorTotal;
				record[i].Icms = registro76[i].Icms;
				record[i].BasedeCalculo = registro76[i].BasedeCalculo;
				record[i].Outras = registro76[i].Outras;
				record[i].Modelo = registro76[i].Modelo;
				record[i].Numero = registro76[i].Numero;
				record[i].Situacao = registro76[i].Situacao;
				record[i].Inscricao = registro76[i].Inscricao;
				record[i].SubSerie = registro76[i].SubSerie;
				record[i].Uf = registro76[i].Uf;
				record[i].Serie = registro76[i].Serie;
				record[i].Cfop = registro76[i].Cfop;
				record[i].CPFCNPJ = registro76[i].CPFCNPJ;
				record[i].DataDocumento = registro76[i].DataDocumento.ToOADate();
				record[i].TipoReceita = (int)registro76[i].TipoReceita;
				record[i].Aliquota = registro76[i].Aliquota;
			}

			int ret = ACBrSintegraInterop.SIN_Registro76(this.Handle, record, registro76.Length);
			CheckResult(ret);
		}

		public void Registro77(List<SintegraRegistro77> registro77)
		{
			Registro77(registro77.ToArray());
		}

		public void Registro77(IEnumerable<SintegraRegistro77> registro77)
		{
			Registro77(registro77.ToArray());
		}

		public void Registro77(SintegraRegistro77[] registro77)
		{
			ACBrSintegraInterop.Registro77Rec[] record = new ACBrSintegraInterop.Registro77Rec[registro77.Length];
			for (int i = 0; i < registro77.Length; i++)
			{
				record[i].Quantidade = registro77[i].Quantidade;
				record[i].ValorServico = registro77[i].ValorServico;
				record[i].ValorDesconto = registro77[i].ValorDesconto;
				record[i].BaseDeCalculo = registro77[i].BaseDeCalculo;
				record[i].Modelo = registro77[i].Modelo;
				record[i].Numero = registro77[i].Numero;
				record[i].NumeroTerminal = registro77[i].NumeroTerminal;
				record[i].NumeroItem = registro77[i].NumeroItem;
				record[i].Aliquota = registro77[i].Aliquota;
				record[i].CNPJMF = registro77[i].CNPJMF;
				record[i].Cfop = registro77[i].Cfop;
				record[i].Codigo = registro77[i].Codigo;
				record[i].SubSerie = registro77[i].SubSerie;
				record[i].CPFCNPJ = registro77[i].CPFCNPJ;
				record[i].Serie = registro77[i].Serie;
				record[i].TipoReceita = (int)registro77[i].TipoReceita;
			}

			int ret = ACBrSintegraInterop.SIN_Registro77(this.Handle, record, registro77.Length);
			CheckResult(ret);
		}

		public void Registro85(List<SintegraRegistro85> registro85)
		{
			Registro85(registro85.ToArray());
		}

		public void Registro85(IEnumerable<SintegraRegistro85> registro85)
		{
			Registro85(registro85.ToArray());
		}

		public void Registro85(SintegraRegistro85[] registro85)
		{
			ACBrSintegraInterop.Registro85Rec[] record = new ACBrSintegraInterop.Registro85Rec[registro85.Length];
			for (int i = 0; i < registro85.Length; i++)
			{
				record[i].Declaracao = registro85[i].Declaracao;
				record[i].DataDeclaracao = registro85[i].DataDeclaracao.ToOADate();
				record[i].NaturezaExportacao = registro85[i].NaturezaExportacao;
				record[i].RegistroExportacao = registro85[i].RegistroExportacao;
				record[i].DataRegistro = registro85[i].DataRegistro.ToOADate();
				record[i].Conhecimento = registro85[i].Conhecimento;
				record[i].DataConhecimento = registro85[i].DataConhecimento.ToOADate();
				record[i].TipoConhecimento = registro85[i].TipoConhecimento;
				record[i].Pais = registro85[i].Pais;
				record[i].DataAverbacao = registro85[i].DataAverbacao.ToOADate();
				record[i].NumeroNotaFiscal = registro85[i].NumeroNotaFiscal;
				record[i].DataNotaFiscal = registro85[i].DataNotaFiscal.ToOADate();
				record[i].Modelo = registro85[i].Modelo;
				record[i].Serie = registro85[i].Serie;
			}

			int ret = ACBrSintegraInterop.SIN_Registro85(this.Handle, record, registro85.Length);
			CheckResult(ret);
		}

		public void Registro86(List<SintegraRegistro86> registro86)
		{
			Registro86(registro86.ToArray());
		}

		public void Registro86(IEnumerable<SintegraRegistro86> registro86)
		{
			Registro86(registro86.ToArray());
		}

		public void Registro86(SintegraRegistro86[] registro86)
		{
			ACBrSintegraInterop.Registro86Rec[] record = new ACBrSintegraInterop.Registro86Rec[registro86.Length];
			for (int i = 0; i < registro86.Length; i++)
			{
				record[i].RegistroExportacao = registro86[i].RegistroExportacao;
				record[i].DataRegistro = registro86[i].DataRegistro.ToOADate();
				record[i].CPFCNPJ = registro86[i].CPFCNPJ;
				record[i].Inscricao = registro86[i].Inscricao;
				record[i].UF = registro86[i].UF;
				record[i].NumeroNotaFiscal = registro86[i].NumeroNotaFiscal;
				record[i].DataDocumento = registro86[i].DataDocumento.ToOADate();
				record[i].Modelo = registro86[i].Modelo;
				record[i].Serie = registro86[i].Serie;
				record[i].Codigo = registro86[i].Codigo;
				record[i].Quantidade = registro86[i].Quantidade;
				record[i].ValorUnitario = registro86[i].ValorUnitario;
				record[i].ValorTotalProduto = registro86[i].ValorTotalProduto;
				record[i].Relacionamento = registro86[i].Relacionamento;
			}

			int ret = ACBrSintegraInterop.SIN_Registro86(this.Handle, record, registro86.Length);
			CheckResult(ret);
		}

		#endregion Registros

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