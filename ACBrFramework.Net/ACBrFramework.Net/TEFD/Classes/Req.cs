using System;

namespace ACBrFramework.TEFD
{
	public class Req : ACBrComposedComponent
	{
		#region Constructor

		internal Req(ACBrTEFD parent, IntPtr composedHandle)
			: base(parent, composedHandle)
		{
		}

		#endregion Constructor

		#region Properties

		public string Header
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_Req_GetHeader);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_Req_SetHeader, value);
			}
		}

		public string DocumentoVinculado
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_Req_GetDocumentoVinculado);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_Req_SetDocumentoVinculado, value);
			}
		}

		public string CMC7
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_Req_GetCMC7);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_Req_SetCMC7, value);
			}
		}

		public string DocumentoPessoa
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_Req_GetDocumentoPessoa);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_Req_SetDocumentoPessoa, value);
			}
		}

		public string Rede
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_Req_GetRede);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_Req_SetRede, value);
			}
		}

		public string NSU
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_Req_GetNSU);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_Req_SetNSU, value);
			}
		}

		public string Finalizacao
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_Req_GetFinalizacao);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_Req_SetFinalizacao, value);
			}
		}

		public int ID
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_Req_GetID);
			}
			set
			{
				SetInt32(ACBrTEFInterop.TEF_Req_SetID, value);
			}
		}

		public int Moeda
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_Req_GetMoeda);
			}
			set
			{
				SetInt32(ACBrTEFInterop.TEF_Req_SetMoeda, value);
			}
		}

		public char TipoPessoa
		{
			get
			{
				return GetChar(ACBrTEFInterop.TEF_Req_GetTipoPessoa);
			}
			set
			{
				SetChar(ACBrTEFInterop.TEF_Req_SetTipoPessoa, value);
			}
		}

		public decimal ValorTotal
		{
			get
			{
				return GetDecimal(ACBrTEFInterop.TEF_Req_GetValorTotal);
			}
			set
			{
				SetDecimal(ACBrTEFInterop.TEF_Req_SetValorTotal, value);
			}
		}

		public DateTime DataCheque
		{
			get
			{
				return GetDateTime(ACBrTEFInterop.TEF_Req_GetDataCheque);
			}
			set
			{
				SetDateTime(ACBrTEFInterop.TEF_Req_SetDataCheque, value);
			}
		}

		public DateTime DataHoraTransacaoComprovante
		{
			get
			{
				return GetDateTime(ACBrTEFInterop.TEF_Req_GetDataHoraTransacaoComprovante);
			}
			set
			{
				SetDateTime(ACBrTEFInterop.TEF_Req_SetDataHoraTransacaoComprovante, value);
			}
		}

		#endregion Properties
	}
}