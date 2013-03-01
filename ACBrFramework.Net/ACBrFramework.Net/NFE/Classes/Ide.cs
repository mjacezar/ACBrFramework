using System;
using System.Collections.Generic;

namespace ACBrFramework.NFE
{
	public sealed class Ide : ACBrComposedComponent
	{
		#region Constructor

		internal Ide(ACBrNFE parent, IntPtr composedHandle)
			: base(parent, composedHandle)
		{
			this.NFrefCollection = new NFref(parent, composedHandle);
		}

		#endregion Constructor

		#region Properties

		private new ACBrNFE Parent
		{
			get
			{
				return (ACBrNFE)base.Parent;
			}
		}

		public int CUF 
		{
			get
			{
				return GetInt32(ACBrNFEInterop.NFE_NFe_Ide_GetcUF);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_NFe_Ide_SetcUF, value);
			}
		}

		public int CNF
		{
			get
			{
				return GetInt32(ACBrNFEInterop.NFE_NFe_Ide_GetcNF);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_NFe_Ide_SetcNF, value);
			}
		}

		public string NatOp
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Ide_GetnatOp);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Ide_SetnatOp, value);
			}
		}

		public IndicadorPagamento IndPag
		{
			get
			{
				return (IndicadorPagamento)GetInt32(ACBrNFEInterop.NFE_NFe_Ide_GetindPag);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_NFe_Ide_SetindPag, (int)value);
			}
		}

		public int Modelo
		{
			get
			{
				return GetInt32(ACBrNFEInterop.NFE_NFe_Ide_Getmodelo);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_NFe_Ide_Setmodelo, value);
			}
		}
		
		public int Serie
		{
			get
			{
				return GetInt32(ACBrNFEInterop.NFE_NFe_Ide_Getserie);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_NFe_Ide_Setserie, value);
			}
		}

		public int NNF
		{
			get
			{
				return GetInt32(ACBrNFEInterop.NFE_NFe_Ide_GetnNF);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_NFe_Ide_SetnNF, value);
			}
		}

		public DateTime DEmi
		{
			get
			{
				return GetDateTime(ACBrNFEInterop.NFE_NFe_Ide_GetdEmi);
			}
			set
			{
				SetDateTime(ACBrNFEInterop.NFE_NFe_Ide_SetdEmi, value);
			}
		}

		public DateTime DSaiEnt
		{
			get
			{
				return GetDateTime(ACBrNFEInterop.NFE_NFe_Ide_GetdSaiEnt);
			}
			set
			{
				SetDateTime(ACBrNFEInterop.NFE_NFe_Ide_SetdSaiEnt, value);
			}
		}

		public DateTime HSaiEnt
		{
			get
			{
				return GetDateTime(ACBrNFEInterop.NFE_NFe_Ide_GethSaiEnt);
			}
			set
			{
				SetDateTime(ACBrNFEInterop.NFE_NFe_Ide_SethSaiEnt, value);
			}
		}

		public TipoNFe TpNF
		{
			get
			{
				return (TipoNFe)GetInt32(ACBrNFEInterop.NFE_NFe_Ide_GettpNF);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_NFe_Ide_SettpNF, (int)value);
			}
		}

		public int CMunFG
		{
			get
			{
				return GetInt32(ACBrNFEInterop.NFE_NFe_Ide_GetcMunFG);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_NFe_Ide_SetcMunFG, value);
			}
		}

		public NFref NFrefCollection { get; private set; }
		public RefNFP RefNFP { get; private set; }

		public TipoImpressao TpImp
		{
			get
			{
				return (TipoImpressao)GetInt32(ACBrNFEInterop.NFE_NFe_Ide_GettpImp);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_NFe_Ide_SettpImp, (int)value);
			}
		}

		public TipoEmissao TpEmis
		{
			get
			{
				return (TipoEmissao)GetInt32(ACBrNFEInterop.NFE_NFe_Ide_GettpEmis);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_NFe_Ide_SettpEmis, (int)value);
			}
		}

		public int CDV
		{
			get
			{
				return GetInt32(ACBrNFEInterop.NFE_NFe_Ide_GetcDV);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_NFe_Ide_SetcDV, value);
			}
		}

		public TipoAmbiente TpAmb
		{
			get
			{
				return (TipoAmbiente)GetInt32(ACBrNFEInterop.NFE_NFe_Ide_GettpAmb);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_NFe_Ide_SettpAmb, (int)value);
			}
		}

		public FinalidadeNFe FinNFe
		{
			get
			{
				return (FinalidadeNFe)GetInt32(ACBrNFEInterop.NFE_NFe_Ide_GetfinNFe);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_NFe_Ide_SetfinNFe, (int)value);
			}
		}

		public ProcessoEmissao ProcEmi
		{
			get
			{
				return (ProcessoEmissao)GetInt32(ACBrNFEInterop.NFE_NFe_Ide_GetprocEmi);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_NFe_Ide_SetprocEmi, (int)value);
			}
		}

		public string VerProc
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Ide_GetverProc);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Ide_SetverProc, value);
			}
		}

		public DateTime DhCont
		{
			get
			{
				return GetDateTime(ACBrNFEInterop.NFE_NFe_Ide_GetdhCont);
			}
			set
			{
				SetDateTime(ACBrNFEInterop.NFE_NFe_Ide_SetdhCont, value);
			}
		}

		public string XJust
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Ide_GetxJust);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Ide_SetxJust, value);
			}
		}

		#endregion Properties
	}
}