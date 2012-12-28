using System;
using System.Text;

namespace ACBrFramework.TEFD
{
	public class Resp : ACBrComposedComponent
	{
		#region Constructor

		internal Resp(ACBrTEFD parent, IntPtr composedHandle)
			: base(parent, composedHandle)
		{
		}

		#endregion Constructor

		#region Properties

		public new ACBrTEFD Parent
		{
			get
			{
				return (ACBrTEFD)base.Parent;
			}
		}

		public string Header
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_Resp_GetHeader);
			}
		}

		public string DocumentoVinculado
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_Resp_GetDocumentoVinculado);
			}
		}

		public string CMC7
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_Resp_GetCMC7);
			}
		}

		public string TipoPessoa
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_Resp_GetTipoPessoa);
			}
		}

		public string DocumentoPessoa
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_Resp_GetDocumentoPessoa);
			}
		}

		public string Rede
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_Resp_GetRede);
			}
		}

		public string NSU
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_Resp_GetNSU);
			}
		}

		public string Finalizacao
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_Resp_GetFinalizacao);
			}
		}

		public string StatusTransacao
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_Resp_GetStatusTransacao);
			}
		}

		public string NSUTransacaoCancelada
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_Resp_GetNSUTransacaoCancelada);
			}
		}

		public string TextoEspecialOperador
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_Resp_GetTextoEspecialOperador);
			}
		}

		public string TextoEspecialCliente
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_Resp_GetTextoEspecialCliente);
			}
		}

		public string Autenticacao
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_Resp_GetAutenticacao);
			}
		}

		public string Banco
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_Resp_GetBanco);
			}
		}

		public string Agencia
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_Resp_GetAgencia);
			}
		}

		public string AgenciaDC
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_Resp_GetAgenciaDC);
			}
		}

		public string Conta
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_Resp_GetConta);
			}
		}

		public string ContaDC
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_Resp_GetContaDC);
			}
		}

		public string Cheque
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_Resp_GetCheque);
			}
		}

		public string ChequeDC
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_Resp_GetChequeDC);
			}
		}

		public string NomeAdministradora
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_Resp_GetNomeAdministradora);
			}
		}

		public string Trailer
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_Resp_GetTrailer);
			}
		}

		public string ArqBackup
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_Resp_GetArqBackup);
			}
		}

		public string ArqRespPendente
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_Resp_GetArqRespPendente);
			}
		}

		public string IndiceFPG_ECF
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_Resp_GetIndiceFPG_ECF);
			}
		}

		public string Instituicao
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_Resp_GetInstituicao);
			}
		}

		public string ModalidadePagto
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_Resp_GetModalidadePagto);
			}
		}

		public string ModalidadePagtoDescrita
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_Resp_GetModalidadePagtoDescrita);
			}
		}

		public string ModalidadeExtenso
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_Resp_GetModalidadeExtenso);
			}
		}

		public string CodigoRedeAutorizada
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_Resp_GetCodigoRedeAutorizada);
			}
		}

		public int ID
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_Resp_GetID);
			}
		}

		public int Moeda
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_Resp_GetMoeda);
			}
		}

		public int TipoTransacao
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_Resp_GetTipoTransacao);
			}
		}

		public int CodigoAutorizacaoTransacao
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_Resp_GetCodigoAutorizacaoTransacao);
			}
		}

		public int NumeroLoteTransacao
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_Resp_GetNumeroLoteTransacao);
			}
		}

		public int TipoParcelamento
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_Resp_GetTipoParcelamento);
			}
		}

		public int QtdParcelas
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_Resp_GetQtdParcelas);
			}
		}

		public int QtdLinhasComprovante
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_Resp_GetQtdLinhasComprovante);
			}
		}

		public int OrdemPagamento
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_Resp_GetOrdemPagamento);
			}
		}

		public TefTipo TipoGP
		{
			get
			{
				return (TefTipo)GetInt32(ACBrTEFInterop.TEF_Resp_GetTipoGP);
			}
		}

		public int ParceladoPor
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_Resp_GetParceladoPor);
			}
		}

		public int TipoOperacao
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_Resp_GetTipoOperacao);
			}
		}

		public bool CNFEnviado
		{
			get
			{
				return GetBool(ACBrTEFInterop.TEF_Resp_GetCNFEnviado);
			}
		}

		public bool TransacaoAprovada
		{
			get
			{
				return GetBool(ACBrTEFInterop.TEF_Resp_GetTransacaoAprovada);
			}
		}

		public bool Debito
		{
			get
			{
				return GetBool(ACBrTEFInterop.TEF_Resp_GetDebito);
			}
		}

		public bool Credito
		{
			get
			{
				return GetBool(ACBrTEFInterop.TEF_Resp_GetCredito);
			}
		}

		public decimal ValorTotal
		{
			get
			{
				return GetDecimal(ACBrTEFInterop.TEF_Resp_GetValorTotal);
			}
		}

		public decimal ValorOriginal
		{
			get
			{
				return GetDecimal(ACBrTEFInterop.TEF_Resp_GetValorOriginal);
			}
		}

		public decimal Saque
		{
			get
			{
				return GetDecimal(ACBrTEFInterop.TEF_Resp_GetSaque);
			}
		}

		public decimal Desconto
		{
			get
			{
				return GetDecimal(ACBrTEFInterop.TEF_Resp_GetDesconto);
			}
		}

		public decimal ValorEntradaCDC
		{
			get
			{
				return GetDecimal(ACBrTEFInterop.TEF_Resp_GetValorEntradaCDC);
			}
		}

		public DateTime DataCheque
		{
			get
			{
				return GetDateTime(ACBrTEFInterop.TEF_Resp_GetDataCheque);
			}
		}

		public DateTime DataHoraTransacaoHost
		{
			get
			{
				return GetDateTime(ACBrTEFInterop.TEF_Resp_GetDataHoraTransacaoHost);
			}
		}

		public DateTime DataHoraTransacaoLocal
		{
			get
			{
				return GetDateTime(ACBrTEFInterop.TEF_Resp_GetDataHoraTransacaoLocal);
			}
		}

		public DateTime DataPreDatado
		{
			get
			{
				return GetDateTime(ACBrTEFInterop.TEF_Resp_GetDataPreDatado);
			}
		}

		public DateTime DataHoraTransacaoCancelada
		{
			get
			{
				return GetDateTime(ACBrTEFInterop.TEF_Resp_GetDataHoraTransacaoCancelada);
			}
		}

		public DateTime DataHoraTransacaoComprovante
		{
			get
			{
				return GetDateTime(ACBrTEFInterop.TEF_Resp_GetDataHoraTransacaoComprovante);
			}
		}

		public DateTime DataVencimento
		{
			get
			{
				return GetDateTime(ACBrTEFInterop.TEF_Resp_GetDataVencimento);
			}
		}

		public DateTime DataEntradaCDC
		{
			get
			{
				return GetDateTime(ACBrTEFInterop.TEF_Resp_GetDataEntradaCDC);
			}
		}

		#endregion Properties

		#region Methods

		public string[] GetImagemComprovante1aVia()
		{
			return GetStringArray(ACBrTEFInterop.TEF_Resp_GetImagemComprovante1aViaLinha, ACBrTEFInterop.TEF_Resp_GetImagemComprovante1aViaCount);
		}

		public string[] GetImagemComprovante2aVia()
		{
			return GetStringArray(ACBrTEFInterop.TEF_Resp_GetImagemComprovante2aViaLinha, ACBrTEFInterop.TEF_Resp_GetImagemComprovante2aViaCount);
		}

		public string LeInformacao(int Identificacao)
		{
			return LeInformacao(Identificacao, 0);
		}

		public string LeInformacao(int Identificacao, int Sequencia)
		{
			const int bufferLen = 256;
			StringBuilder buffer = new StringBuilder(bufferLen);
			int ret = ACBrTEFInterop.TEF_Resp_LeInformacao(this.Handle, this.ComposedHandle, buffer, bufferLen, Identificacao, Sequencia);
			CheckResult(ret);

			return buffer.ToString();
		}

		#endregion Methods
	}
}