using System;
using System.Text;

namespace ACBrFramework.TEFD
{
	public class ACBrTEFDRespostaPendente : ACBrInteropListItemBase
	{
		#region Constructor

		internal ACBrTEFDRespostaPendente(ACBrTEFDRespostasPendentes parent, int index) : base(parent.Parent, index) { }

		#endregion Constructor

		#region Properties

		public string Header
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_RespostasPendentes_GetHeader);
			}
		}

		public string DocumentoVinculado
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_RespostasPendentes_GetDocumentoVinculado);
			}
		}

		public string CMC7
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_RespostasPendentes_GetCMC7);
			}
		}

		public string TipoPessoa
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_RespostasPendentes_GetTipoPessoa);
			}
		}

		public string DocumentoPessoa
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_RespostasPendentes_GetDocumentoPessoa);
			}
		}

		public string Rede
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_RespostasPendentes_GetRede);
			}
		}

		public string NSU
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_RespostasPendentes_GetNSU);
			}
		}

		public string Finalizacao
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_RespostasPendentes_GetFinalizacao);
			}
		}

		public string StatusTransacao
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_RespostasPendentes_GetStatusTransacao);
			}
		}

		public string NSUTransacaoCancelada
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_RespostasPendentes_GetNSUTransacaoCancelada);
			}
		}

		public string TextoEspecialOperador
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_RespostasPendentes_GetTextoEspecialOperador);
			}
		}

		public string TextoEspecialCliente
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_RespostasPendentes_GetTextoEspecialCliente);
			}
		}

		public string Autenticacao
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_RespostasPendentes_GetAutenticacao);
			}
		}

		public string Banco
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_RespostasPendentes_GetBanco);
			}
		}

		public string Agencia
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_RespostasPendentes_GetAgencia);
			}
		}

		public string AgenciaDC
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_RespostasPendentes_GetAgenciaDC);
			}
		}

		public string Conta
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_RespostasPendentes_GetConta);
			}
		}

		public string ContaDC
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_RespostasPendentes_GetContaDC);
			}
		}

		public string Cheque
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_RespostasPendentes_GetCheque);
			}
		}

		public string ChequeDC
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_RespostasPendentes_GetChequeDC);
			}
		}

		public string NomeAdministradora
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_RespostasPendentes_GetNomeAdministradora);
			}
		}

		public string Trailer
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_RespostasPendentes_GetTrailer);
			}
		}

		public string ArqBackup
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_RespostasPendentes_GetArqBackup);
			}
		}

		public string ArqRespPendente
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_RespostasPendentes_GetArqRespPendente);
			}
		}

		public string IndiceFPG_ECF
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_RespostasPendentes_GetIndiceFPG_ECF);
			}
		}

		public string Instituicao
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_RespostasPendentes_GetInstituicao);
			}
		}

		public string ModalidadePagto
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_RespostasPendentes_GetModalidadePagto);
			}
		}

		public string ModalidadePagtoDescrita
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_RespostasPendentes_GetModalidadePagtoDescrita);
			}
		}

		public string ModalidadeExtenso
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_RespostasPendentes_GetModalidadeExtenso);
			}
		}

		public string CodigoRedeAutorizada
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_RespostasPendentes_GetCodigoRedeAutorizada);
			}
		}

		public int ID
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_RespostasPendentes_GetID);
			}
		}

		public int Moeda
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_RespostasPendentes_GetMoeda);
			}
		}

		public int TipoTransacao
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_RespostasPendentes_GetTipoTransacao);
			}
		}

		public int CodigoAutorizacaoTransacao
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_RespostasPendentes_GetCodigoAutorizacaoTransacao);
			}
		}

		public int NumeroLoteTransacao
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_RespostasPendentes_GetNumeroLoteTransacao);
			}
		}

		public int TipoParcelamento
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_RespostasPendentes_GetTipoParcelamento);
			}
		}

		public int QtdParcelas
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_RespostasPendentes_GetQtdParcelas);
			}
		}

		public int QtdLinhasComprovante
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_RespostasPendentes_GetQtdLinhasComprovante);
			}
		}

		public int OrdemPagamento
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_RespostasPendentes_GetOrdemPagamento);
			}
		}

		public ACBrTEFDTipo TipoGP
		{
			get
			{
				return (ACBrTEFDTipo)GetInt32(ACBrTEFInterop.TEF_RespostasPendentes_GetTipoGP);
			}
		}

		public int ParceladoPor
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_RespostasPendentes_GetParceladoPor);
			}
		}

		public int TipoOperacao
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_RespostasPendentes_GetTipoOperacao);
			}
		}

		public bool CNFEnviado
		{
			get
			{
				return GetBool(ACBrTEFInterop.TEF_RespostasPendentes_GetCNFEnviado);
			}
		}

		public bool TransacaoAprovada
		{
			get
			{
				return GetBool(ACBrTEFInterop.TEF_RespostasPendentes_GetTransacaoAprovada);
			}
		}

		public bool Debito
		{
			get
			{
				return GetBool(ACBrTEFInterop.TEF_RespostasPendentes_GetDebito);
			}
		}

		public bool Credito
		{
			get
			{
				return GetBool(ACBrTEFInterop.TEF_RespostasPendentes_GetCredito);
			}
		}

		public decimal ValorTotal
		{
			get
			{
				return GetDecimal(ACBrTEFInterop.TEF_RespostasPendentes_GetValorTotal);
			}
		}

		public decimal ValorOriginal
		{
			get
			{
				return GetDecimal(ACBrTEFInterop.TEF_RespostasPendentes_GetValorOriginal);
			}
		}

		public decimal Saque
		{
			get
			{
				return GetDecimal(ACBrTEFInterop.TEF_RespostasPendentes_GetSaque);
			}
		}

		public decimal Desconto
		{
			get
			{
				return GetDecimal(ACBrTEFInterop.TEF_RespostasPendentes_GetDesconto);
			}
		}

		public decimal ValorEntradaCDC
		{
			get
			{
				return GetDecimal(ACBrTEFInterop.TEF_RespostasPendentes_GetValorEntradaCDC);
			}
		}

		public DateTime DataCheque
		{
			get
			{
				return GetDateTime(ACBrTEFInterop.TEF_RespostasPendentes_GetDataCheque);
			}
		}

		public DateTime DataHoraTransacaoHost
		{
			get
			{
				return GetDateTime(ACBrTEFInterop.TEF_RespostasPendentes_GetDataHoraTransacaoHost);
			}
		}

		public DateTime DataHoraTransacaoLocal
		{
			get
			{
				return GetDateTime(ACBrTEFInterop.TEF_RespostasPendentes_GetDataHoraTransacaoLocal);
			}
		}

		public DateTime DataPreDatado
		{
			get
			{
				return GetDateTime(ACBrTEFInterop.TEF_RespostasPendentes_GetDataPreDatado);
			}
		}

		public DateTime DataHoraTransacaoCancelada
		{
			get
			{
				return GetDateTime(ACBrTEFInterop.TEF_RespostasPendentes_GetDataHoraTransacaoCancelada);
			}
		}

		public DateTime DataHoraTransacaoComprovante
		{
			get
			{
				return GetDateTime(ACBrTEFInterop.TEF_RespostasPendentes_GetDataHoraTransacaoComprovante);
			}
		}

		public DateTime DataVencimento
		{
			get
			{
				return GetDateTime(ACBrTEFInterop.TEF_RespostasPendentes_GetDataVencimento);
			}
		}

		public DateTime DataEntradaCDC
		{
			get
			{
				return GetDateTime(ACBrTEFInterop.TEF_RespostasPendentes_GetDataEntradaCDC);
			}
		}

		#endregion Properties
	}
}