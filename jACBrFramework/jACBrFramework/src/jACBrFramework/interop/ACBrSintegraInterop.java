/**
* ACBrFramework DefExporter
* Este arquivo foi gerado automaticamente - não altere
* This file was generated automatically - don't change it.
* 
* - Para que nao haja erro no envio dos dados foi preciso implementar a
* - interface Structure.ByValue nos registros 10 e 11. Alem disso todos os 
* -- vetores de char[] foram modificados para vetor de bytes[].
**/


package jACBrFramework.interop;
import jACBrFramework.InteropLib;
import com.sun.jna.*;
import com.sun.jna.ptr.*;
import java.nio.ByteBuffer;
import java.util.Arrays;
import java.util.List;


public interface ACBrSintegraInterop extends InteropLib
{
	public static final ACBrSintegraInterop INSTANCE = (ACBrSintegraInterop)Native.loadLibrary(InteropLib.JNA_LIBRARY_NAME, ACBrSintegraInterop.class);

	// Tipos de dados

	public static class Registro10Rec extends Structure implements Structure.ByValue
	{
		public byte[] CNPJ = new byte[15];
		public byte[] Inscricao = new byte[15]; 
		public byte[] RazaoSocial = new byte[36];
		public byte[] Cidade = new byte[31];
		public byte[] Estado = new byte[3];
		public byte[] Telefone = new byte[13];
		public double DataInicial;
		public double DataFinal;
		public int CodigoConvenio;
		public int NaturezaInformacoes;
		public int FinalidadeArquivo;

		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("CNPJ" , "Inscricao" , "RazaoSocial" , "Cidade" , "Estado" , "Telefone" , "DataInicial" , "DataFinal" , "CodigoConvenio" , "NaturezaInformacoes" , "FinalidadeArquivo");
		}


		public static class ByReference extends Registro10Rec implements Structure.ByReference{ }
		public static class ByValue extends Registro10Rec implements Structure.ByValue{ }
	}

	public static class Registro11Rec extends Structure implements Structure.ByValue
	{
		public byte[] Responsavel = new byte[29];
		public byte[] Bairro = new byte[16];
		public byte[] Cep = new byte[9];
		public byte[] Numero = new byte[6];
		public byte[] Complemento = new byte[23];
		public byte[] Endereco = new byte[35];
		public byte[] Telefone = new byte[13];


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("Responsavel" , "Bairro" , "Cep" , "Numero" , "Complemento" , "Endereco" , "Telefone");
		}


		public static class ByReference extends Registro11Rec implements Structure.ByReference{ }
		public static class ByValue extends Registro11Rec implements Structure.ByValue{ }
	}

	public static class Registro50Rec extends Structure
	{
		public byte[] CPFCNPJ = new byte[15];
		public byte[] Inscricao = new byte[15];
		public byte[] UF = new byte[3];
		public byte[] Situacao = new byte[2];
		public double Aliquota;
		public double Isentas;
		public double Icms;
		public double ValorContabil;
		public double BasedeCalculo;
		public double Outras;
		public byte[] EmissorDocumento = new byte[2];
		public byte[] Cfop = new byte[5];
		public byte[] Serie = new byte[4];
		public byte[] Modelo = new byte[3];
		public byte[] Numero = new byte[7];
		public double DataDocumento;


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("CPFCNPJ" , "Inscricao" , "UF" , "Situacao" , "Aliquota" , "Isentas" , "Icms" , "ValorContabil" , "BasedeCalculo" , "Outras" , "EmissorDocumento" , "Cfop" , "Serie" , "Modelo" , "Numero" , "DataDocumento");
		}


		public static class ByReference extends Registro50Rec implements Structure.ByReference{ }
		public static class ByValue extends Registro50Rec implements Structure.ByValue{ }
	}

	public static class Registro51Rec extends Structure
	{
		public byte[] CPFCNPJ = new byte[15];
		public byte[] Inscricao = new byte[15];
		public byte[] Estado = new byte[3];
		public double ValorIpi;
		public double ValorContabil;
		public byte[] Serie = new byte[4];
		public double DataDocumento;
		public byte[] Cfop = new byte[5];
		public byte[] Numero = new byte[7];
		public byte[] Situacao = new byte[2];
		public double ValorIsentas;
		public double ValorOutras;


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("CPFCNPJ" , "Inscricao" , "Estado" , "ValorIpi" , "ValorContabil" , "Serie" , "DataDocumento" , "Cfop" , "Numero" , "Situacao" , "ValorIsentas" , "ValorOutras");
		}


		public static class ByReference extends Registro51Rec implements Structure.ByReference{ }
		public static class ByValue extends Registro51Rec implements Structure.ByValue{ }
	}

	public static class Registro53Rec extends Structure
	{
		public byte[] CPFCNPJ = new byte[15];
		public byte[] Inscricao = new byte[15];
		public byte[] Estado = new byte[3];
		public byte[] Serie = new byte[4];
		public double DataDocumento;
		public byte[] Cfop = new byte[5];
		public byte[] Numero = new byte[7];
		public byte[] Situacao = new byte[4];
		public byte[] CodigoAntecipacao = new byte[2];
		public double BaseST;
		public byte[] Modelo = new byte[3];
		public byte[] Emitente = new byte[2];
		public double Despesas;
		public double IcmsRetido;


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("CPFCNPJ" , "Inscricao" , "Estado" , "Serie" , "DataDocumento" , "Cfop" , "Numero" , "Situacao" , "CodigoAntecipacao" , "BaseST" , "Modelo" , "Emitente" , "Despesas" , "IcmsRetido");
		}


		public static class ByReference extends Registro53Rec implements Structure.ByReference{ }
		public static class ByValue extends Registro53Rec implements Structure.ByValue{ }
	}

	public static class Registro54Rec extends Structure
	{
		public double Aliquota;
		public double BaseST;
		public double BasedeCalculo;
		public double Quantidade;
		public double ValorDescontoDespesa;
		public double ValorIpi;
		public double Valor;
		public int NumeroItem;
		public byte[] CST = new byte[4];
		public byte[] Codigo = new byte[15];
		public byte[] CFOP = new byte[5];
		public byte[] Descricao = new byte[54];
		public byte[] CPFCNPJ = new byte[15];
		public byte[] Numero = new byte[7];
		public byte[] Modelo = new byte[3];
		public byte[] Serie = new byte[4];


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("Aliquota" , "BaseST" , "BasedeCalculo" , "Quantidade" , "ValorDescontoDespesa" , "ValorIpi" , "Valor" , "NumeroItem" , "CST" , "Codigo" , "CFOP" , "Descricao" , "CPFCNPJ" , "Numero" , "Modelo" , "Serie");
		}


		public static class ByReference extends Registro54Rec implements Structure.ByReference{ }
		public static class ByValue extends Registro54Rec implements Structure.ByValue{ }
	}

	public static class Registro55Rec extends Structure
	{
		public double Valor;
		public int Agencia;
		public int Banco;
		public byte[] NumeroConvenio = new byte[31];
		public byte[] Inscricao = new byte[15];
		public byte[] MesAno = new byte[7];
		public byte[] CNPJ = new byte[15];
		public byte[] UF = new byte[3];
		public byte[] Numero = new byte[15];
		public double DataPagamento;
		public double Vencimento;


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("Valor" , "Agencia" , "Banco" , "NumeroConvenio" , "Inscricao" , "MesAno" , "CNPJ" , "UF" , "Numero" , "DataPagamento" , "Vencimento");
		}


		public static class ByReference extends Registro55Rec implements Structure.ByReference{ }
		public static class ByValue extends Registro55Rec implements Structure.ByValue{ }
	}

	public static class Registro56Rec extends Structure
	{
		public byte[] Cnpj = new byte[15];
		public byte[] Modelo = new byte[3];
		public byte[] Serie = new byte[4];
		public byte[] Numero = new byte[7];
		public byte[] Cfop = new byte[5];
		public byte[] Cst = new byte[4];
		public int NumeroItem;
		public byte[] Codigo = new byte[15];
		public byte[] TipoOperacao = new byte[2];
		public byte[] CnpjConcessionaria = new byte[15];
		public double Ipi;
		public byte[] Chassi = new byte[18];


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("Cnpj" , "Modelo" , "Serie" , "Numero" , "Cfop" , "Cst" , "NumeroItem" , "Codigo" , "TipoOperacao" , "CnpjConcessionaria" , "Ipi" , "Chassi");
		}


		public static class ByReference extends Registro56Rec implements Structure.ByReference{ }
		public static class ByValue extends Registro56Rec implements Structure.ByValue{ }
	}

	public static class Registro60ARec extends Structure
	{
		public byte[] NumSerie = new byte[21];
		public byte[] Aliquota = new byte[5];
		public double Emissao;
		public double Valor;


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("NumSerie" , "Aliquota" , "Emissao" , "Valor");
		}


		public static class ByReference extends Registro60ARec implements Structure.ByReference{ }
		public static class ByValue extends Registro60ARec implements Structure.ByValue{ }
	}

	public static class Registro60DRec extends Structure
	{
		public byte[] NumSerie = new byte[21];
		public byte[] StAliquota = new byte[5];
		public double Emissao;
		public double Valor;
		public byte[] Codigo = new byte[15];
		public double ValorIcms;
		public double Quantidade;
		public double BaseDeCalculo;


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("NumSerie" , "StAliquota" , "Emissao" , "Valor" , "Codigo" , "ValorIcms" , "Quantidade" , "BaseDeCalculo");
		}


		public static class ByReference extends Registro60DRec implements Structure.ByReference{ }
		public static class ByValue extends Registro60DRec implements Structure.ByValue{ }
	}

	public static class Registro60IRec extends Structure
	{
		public byte[] NumSerie = new byte[21];
		public byte[] StAliquota = new byte[5];
		public double Emissao;
		public double Valor;
		public byte[] Codigo = new byte[15];
		public double ValorIcms;
		public double Quantidade;
		public double BaseDeCalculo;
		public int Item;
		public byte[] Cupom = new byte[7];
		public byte[] ModeloDoc = new byte[3];


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("NumSerie" , "StAliquota" , "Emissao" , "Valor" , "Codigo" , "ValorIcms" , "Quantidade" , "BaseDeCalculo" , "Item" , "Cupom" , "ModeloDoc");
		}


		public static class ByReference extends Registro60IRec implements Structure.ByReference{ }
		public static class ByValue extends Registro60IRec implements Structure.ByValue{ }
	}

	public static class Registro60MRec extends Structure
	{
		public int CRO;
		public int NumOrdem;
		public double VendaBruta;
		public byte[] ModeloDoc = new byte[3];
		public double ValorGT;
		public int CRZ;
		public int CooFinal;
		public int CooInicial;
		public byte[] NumSerie = new byte[21];
		public double Emissao;


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("CRO" , "NumOrdem" , "VendaBruta" , "ModeloDoc" , "ValorGT" , "CRZ" , "CooFinal" , "CooInicial" , "NumSerie" , "Emissao");
		}


		public static class ByReference extends Registro60MRec implements Structure.ByReference{ }
		public static class ByValue extends Registro60MRec implements Structure.ByValue{ }
	}

	public static class Registro60RRec extends Structure
	{
		public double BaseDeCalculo;
		public double Valor;
		public double Qtd;
		public byte[] MesAno = new byte[7];
		public byte[] Codigo = new byte[15];
		public byte[] Aliquota = new byte[5];


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("BaseDeCalculo" , "Valor" , "Qtd" , "MesAno" , "Codigo" , "Aliquota");
		}


		public static class ByReference extends Registro60RRec implements Structure.ByReference{ }
		public static class ByValue extends Registro60RRec implements Structure.ByValue{ }
	}

	public static class Registro61Rec extends Structure
	{
		public double Emissao;
		public double Valor;
		public double ValorIcms;
		public double Outras;
		public double BaseDeCalculo;
		public double Isentas;
		public int NumOrdemInicial;
		public int NumOrdemFinal;
		public byte[] Modelo = new byte[3];
		public byte[] SubSerie = new byte[3];
		public byte[] Serie = new byte[4];
		public double Aliquota;


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("Emissao" , "Valor" , "ValorIcms" , "Outras" , "BaseDeCalculo" , "Isentas" , "NumOrdemInicial" , "NumOrdemFinal" , "Modelo" , "SubSerie" , "Serie" , "Aliquota");
		}


		public static class ByReference extends Registro61Rec implements Structure.ByReference{ }
		public static class ByValue extends Registro61Rec implements Structure.ByValue{ }
	}

	public static class Registro61RRec extends Structure
	{
		public double Aliquota;
		public double Valor;
		public double Qtd;
		public byte[] MesAno = new byte[7];
		public byte[] Codigo = new byte[15];
		public double BaseDeCalculo;


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("Aliquota" , "Valor" , "Qtd" , "MesAno" , "Codigo" , "BaseDeCalculo");
		}


		public static class ByReference extends Registro61RRec implements Structure.ByReference{ }
		public static class ByValue extends Registro61RRec implements Structure.ByValue{ }
	}

	public static class Registro70Rec extends Structure
	{
		public double Icms;
		public double ValorContabil;
		public byte[] UF = new byte[3];
		public double Isentas;
		public byte[] SubSerie = new byte[3];
		public byte[] Serie = new byte[2];
		public double DataDocumento;
		public byte[] Modelo = new byte[3];
		public byte[] CPFCNPJ = new byte[15];
		public byte[] Cfop = new byte[5];
		public byte[] Numero = new byte[7];
		public byte[] Inscricao = new byte[15];
		public byte[] Situacao = new byte[15];
		public double Outras;
		public double BasedeCalculo;
		public byte[] CifFobOutros = new byte[2];


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("Icms" , "ValorContabil" , "UF" , "Isentas" , "SubSerie" , "Serie" , "DataDocumento" , "Modelo" , "CPFCNPJ" , "Cfop" , "Numero" , "Inscricao" , "Situacao" , "Outras" , "BasedeCalculo" , "CifFobOutros");
		}


		public static class ByReference extends Registro70Rec implements Structure.ByReference{ }
		public static class ByValue extends Registro70Rec implements Structure.ByValue{ }
	}

	public static class Registro71Rec extends Structure
	{
		public byte[] CPFCNPJ = new byte[15];
		public byte[] Inscricao = new byte[15];
		public double DataDocumento;
		public byte[] Modelo = new byte[3];
		public byte[] Serie = new byte[2];
		public byte[] SubSerie = new byte[3];
		public byte[] Numero = new byte[7];
		public byte[] UF = new byte[3];
		public byte[] UFNF = new byte[3];
		public byte[] CPFCNPJNF = new byte[15];
		public byte[] InscricaoNF = new byte[15];
		public double DataNF;
		public byte[] ModeloNF = new byte[3];
		public byte[] SerieNF = new byte[4];
		public byte[] NumeroNF = new byte[7];
		public double ValorNF;


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("CPFCNPJ" , "Inscricao" , "DataDocumento" , "Modelo" , "Serie" , "SubSerie" , "Numero" , "UF" , "UFNF" , "CPFCNPJNF" , "InscricaoNF" , "DataNF" , "ModeloNF" , "SerieNF" , "NumeroNF" , "ValorNF");
		}


		public static class ByReference extends Registro71Rec implements Structure.ByReference{ }
		public static class ByValue extends Registro71Rec implements Structure.ByValue{ }
	}

	public static class Registro74Rec extends Structure
	{
		public double ValorProduto;
		public byte[] CodigoPosse = new byte[2];
		public byte[] InscricaoPossuidor = new byte[15];
		public byte[] Codigo = new byte[15];
		public byte[] CNPJPossuidor = new byte[15];
		public byte[] UFPossuidor = new byte[3];
		public double Data;
		public double Quantidade;


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("ValorProduto" , "CodigoPosse" , "InscricaoPossuidor" , "Codigo" , "CNPJPossuidor" , "UFPossuidor" , "Data" , "Quantidade");
		}


		public static class ByReference extends Registro74Rec implements Structure.ByReference{ }
		public static class ByValue extends Registro74Rec implements Structure.ByValue{ }
	}

	public static class Registro75Rec extends Structure implements Structure.ByValue
	{
		public byte[] Codigo = new byte[15];
		public byte[] Descricao = new byte[54];
		public double Reducao;
		public double BaseST;
		public double AliquotaIpi;
		public byte[] NCM = new byte[9];
		public byte[] Unidade = new byte[7];
		public double AliquotaICMS;
		public double DataFinal;
		public double DataInicial;


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("Codigo" , "Descricao" , "Reducao" , "BaseST" , "AliquotaIpi" , "NCM" , "Unidade" , "AliquotaICMS" , "DataFinal" , "DataInicial");
		}


		public static class ByReference extends Registro75Rec implements Structure.ByReference{ }
		public static class ByValue extends Registro75Rec implements Structure.ByValue{ }
	}

	public static class Registro76Rec extends Structure
	{
		public double Isentas;
		public double ValorTotal;
		public double Icms;
		public double BasedeCalculo;
		public double Outras;
		public int Modelo;
		public int Numero;
		public byte[] Situacao = new byte[2];
		public byte[] Inscricao = new byte[15];
		public byte[] SubSerie = new byte[3];
		public byte[] Uf = new byte[3];
		public byte[] Serie = new byte[3];
		public byte[] Cfop = new byte[5];
		public byte[] CPFCNPJ = new byte[15];
		public double DataDocumento;
		public int TipoReceita;
		public int Aliquota;


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("Isentas" , "ValorTotal" , "Icms" , "BasedeCalculo" , "Outras" , "Modelo" , "Numero" , "Situacao" , "Inscricao" , "SubSerie" , "Uf" , "Serie" , "Cfop" , "CPFCNPJ" , "DataDocumento" , "TipoReceita" , "Aliquota");
		}


		public static class ByReference extends Registro76Rec implements Structure.ByReference{ }
		public static class ByValue extends Registro76Rec implements Structure.ByValue{ }
	}

	public static class Registro77Rec extends Structure
	{
		public double Quantidade;
		public double ValorServico;
		public double ValorDesconto;
		public double BaseDeCalculo;
		public int Modelo;
		public int Numero;
		public int NumeroTerminal;
		public int NumeroItem;
		public int Aliquota;
		public byte[] CNPJMF = new byte[15];
		public byte[] Cfop = new byte[5];
		public byte[] Codigo = new byte[12];
		public byte[] SubSerie = new byte[3];
		public byte[] CPFCNPJ = new byte[15];
		public byte[] Serie = new byte[3];
		public int TipoReceita;


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("Quantidade" , "ValorServico" , "ValorDesconto" , "BaseDeCalculo" , "Modelo" , "Numero" , "NumeroTerminal" , "NumeroItem" , "Aliquota" , "CNPJMF" , "Cfop" , "Codigo" , "SubSerie" , "CPFCNPJ" , "Serie" , "TipoReceita");
		}


		public static class ByReference extends Registro77Rec implements Structure.ByReference{ }
		public static class ByValue extends Registro77Rec implements Structure.ByValue{ }
	}

	public static class Registro85Rec extends Structure
	{
		public byte[] Declaracao = new byte[12];
		public double DataDeclaracao;
		public byte[] NaturezaExportacao = new byte[2];
		public byte[] RegistroExportacao = new byte[13];
		public double DataRegistro;
		public byte[] Conhecimento = new byte[17];
		public double DataConhecimento;
		public byte[] TipoConhecimento = new byte[3];
		public byte[] Pais = new byte[5];
		public double DataAverbacao;
		public byte[] NumeroNotaFiscal = new byte[7];
		public double DataNotaFiscal;
		public byte[] Modelo = new byte[3];
		public byte[] Serie = new byte[4];


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("Declaracao" , "DataDeclaracao" , "NaturezaExportacao" , "RegistroExportacao" , "DataRegistro" , "Conhecimento" , "DataConhecimento" , "TipoConhecimento" , "Pais" , "DataAverbacao" , "NumeroNotaFiscal" , "DataNotaFiscal" , "Modelo" , "Serie");
		}


		public static class ByReference extends Registro85Rec implements Structure.ByReference{ }
		public static class ByValue extends Registro85Rec implements Structure.ByValue{ }
	}

	public static class Registro86Rec extends Structure
	{
		public byte[] RegistroExportacao = new byte[13];
		public double DataRegistro;
		public byte[] CPFCNPJ = new byte[15];
		public byte[] Inscricao = new byte[15];
		public byte[] UF = new byte[3];
		public byte[] NumeroNotaFiscal = new byte[7];
		public double DataDocumento;
		public byte[] Modelo = new byte[3];
		public byte[] Serie = new byte[4];
		public byte[] Codigo = new byte[15];
		public double Quantidade;
		public double ValorUnitario;
		public double ValorTotalProduto;
		public byte[] Relacionamento = new byte[2];


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("RegistroExportacao" , "DataRegistro" , "CPFCNPJ" , "Inscricao" , "UF" , "NumeroNotaFiscal" , "DataDocumento" , "Modelo" , "Serie" , "Codigo" , "Quantidade" , "ValorUnitario" , "ValorTotalProduto" , "Relacionamento");
		}


		public static class ByReference extends Registro86Rec implements Structure.ByReference{ }
		public static class ByValue extends Registro86Rec implements Structure.ByValue{ }
	}


	// Funções

	int SIN_Create(IntByReference sinHandle);
	int SIN_Destroy(int sinHandle);
	int SIN_GeraArquivo(int sinHandle);
	int SIN_GetAtivo(int sinHandle);
	int SIN_GetFileName(int sinHandle, ByteBuffer buffer, int bufferLen);
	int SIN_GetInforma88C(int sinHandle);
	int SIN_GetInforma88EAN(int sinHandle);
	int SIN_GetInforma88SME(int sinHandle);
	int SIN_GetInforma88SMS(int sinHandle);
	int SIN_GetInformaSapiMG(int sinHandle);
	int SIN_GetUltimoErro(int sinHandle, ByteBuffer buffer, int bufferLen);
	int SIN_GetVersao(int sinHandle, ByteBuffer buffer, int bufferLen);
	int SIN_GetVersaoValidador(int sinHandle);
	int SIN_LimparRegistros(int sinHandle);
	int SIN_Registro10(int sinHandle, ACBrSintegraInterop.Registro10Rec registro10);
	int SIN_Registro11(int sinHandle, ACBrSintegraInterop.Registro11Rec registro11);
	int SIN_Registro50(int sinHandle, ACBrSintegraInterop.Registro50Rec registro50[], int count);
	int SIN_Registro51(int sinHandle, ACBrSintegraInterop.Registro51Rec registro51[], int count);
	int SIN_Registro53(int sinHandle, ACBrSintegraInterop.Registro53Rec registro53[], int count);
	int SIN_Registro54(int sinHandle, ACBrSintegraInterop.Registro54Rec registro54[], int count);
	int SIN_Registro55(int sinHandle, ACBrSintegraInterop.Registro55Rec registro55[], int count);
	int SIN_Registro56(int sinHandle, ACBrSintegraInterop.Registro56Rec registro56[], int count);
	int SIN_Registro60A(int sinHandle, ACBrSintegraInterop.Registro60ARec registro60A[], int count);
	int SIN_Registro60D(int sinHandle, ACBrSintegraInterop.Registro60DRec registro60D[], int count);
	int SIN_Registro60I(int sinHandle, ACBrSintegraInterop.Registro60IRec registro60I[], int count);
	int SIN_Registro60M(int sinHandle, ACBrSintegraInterop.Registro60MRec registro60M[], int count);
	int SIN_Registro60R(int sinHandle, ACBrSintegraInterop.Registro60RRec registro60R[], int count);
	int SIN_Registro61(int sinHandle, ACBrSintegraInterop.Registro61Rec registro61[], int count);
	int SIN_Registro61R(int sinHandle, ACBrSintegraInterop.Registro61RRec registro61R[], int count);
	int SIN_Registro70(int sinHandle, ACBrSintegraInterop.Registro70Rec registro70[], int count);
	int SIN_Registro71(int sinHandle, ACBrSintegraInterop.Registro71Rec registro71[], int count);
	int SIN_Registro74(int sinHandle, ACBrSintegraInterop.Registro74Rec registro74[], int count);
	int SIN_Registro75(int sinHandle, ACBrSintegraInterop.Registro75Rec registro75[], int count);
	int SIN_Registro76(int sinHandle, ACBrSintegraInterop.Registro76Rec registro76[], int count);
	int SIN_Registro77(int sinHandle, ACBrSintegraInterop.Registro77Rec registro77[], int count);
	int SIN_Registro85(int sinHandle, ACBrSintegraInterop.Registro85Rec registro85[], int count);
	int SIN_Registro86(int sinHandle, ACBrSintegraInterop.Registro86Rec registr86[], int count);
	int SIN_SetAtivo(int sinHandle, boolean value);
	int SIN_SetFileName(int sinHandle, String filename);
	int SIN_SetInforma88C(int sinHandle, boolean value);
	int SIN_SetInforma88EAN(int sinHandle, boolean value);
	int SIN_SetInforma88SME(int sinHandle, boolean value);
	int SIN_SetInforma88SMS(int sinHandle, boolean value);
	int SIN_SetInformaSapiMG(int sinHandle, boolean value);
	int SIN_SetVersaoValidador(int sinHandle, int Versao);
}
