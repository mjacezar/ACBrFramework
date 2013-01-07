using System;
using System.Text;
using System.Threading;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Drawing;
using ACBrFramework.ECF;

namespace ACBrFramework.RFD
{
	[ToolboxBitmap(typeof(ToolboxIcons), @"ACBrFramework.RFD.ico.bmp")]
	public class ACBrRFD : ACBrComponent, IDisposable
	{
		#region Events

		[Category("Geral")]
		public event EventHandler<OnCalcEADArgs> OnCalcEAD
		{
			add
			{
				onCalcEAD.Add(value);
			}
			remove
			{
				onCalcEAD.Remove(value);
			}
		}

		[Category("Geral")]
		public event EventHandler<OnCalcHashLogArgs> OnCalcHashLog
		{
			add
			{
				onCalcHashLog.Add(value);
			}
			remove
			{
				onCalcHashLog.Remove(value);
			}
		}

		[Category("Geral")]
		public event EventHandler<ChaveEventArgs> OnGetKeyHashLog
		{
			add
			{
				onGetKeyHashLog.Add(value);
			}
			remove
			{
				onGetKeyHashLog.Remove(value);
			}
		}

		[Category("Geral")]
		public event EventHandler<ChaveEventArgs> OnGetKeyRSA
		{
			add
			{
				onGetKeyRSA.Add(value);
			}
			remove
			{
				onGetKeyRSA.Remove(value);
			}
		}

		#endregion Events

		#region Fields

		private readonly ACBrEventHandler<OnCalcEADArgs, ACBrRFDInterop.OnCalcEADCallback> onCalcEAD;
		private readonly ACBrEventHandler<OnCalcHashLogArgs, ACBrRFDInterop.OnCalcHashLogCallback> onCalcHashLog;
		private readonly ACBrEventHandler<ChaveEventArgs, ACBrRFDInterop.OnGetKeyCallback> onGetKeyHashLog;
		private readonly ACBrEventHandler<ChaveEventArgs, ACBrRFDInterop.OnGetKeyCallback> onGetKeyRSA;
		private ACBrECF ecf;

		#endregion Fields

		#region Constructor

		public ACBrRFD()
		{
			onCalcEAD = new ACBrEventHandler<OnCalcEADArgs, ACBrRFDInterop.OnCalcEADCallback>(this, OnCalcEADCallback, ACBrRFDInterop.RFD_SetOnCalcEAD);
			onCalcHashLog = new ACBrEventHandler<OnCalcHashLogArgs, ACBrRFDInterop.OnCalcHashLogCallback>(this, OnCalcHashLogCallback, ACBrRFDInterop.RFD_SetOnCalcHashLog);
			onGetKeyHashLog = new ACBrEventHandler<ChaveEventArgs, ACBrRFDInterop.OnGetKeyCallback>(this, OnGetKeyHashLogCallback, ACBrRFDInterop.RFD_SetOnGetKeyHashLog);
			onGetKeyRSA = new ACBrEventHandler<ChaveEventArgs, ACBrRFDInterop.OnGetKeyCallback>(this, OnGetKeyRSACallback, ACBrRFDInterop.RFD_SetOnGetKeyRSA);
		}

		#endregion Constructor

		#region Properties

		#region Visiveis

		[Category("RFD")]
		public string DirRFD
		{
			get
			{
				return GetString(ACBrRFDInterop.RFD_GetDirRFD);
			}
			set
			{
				SetString(ACBrRFDInterop.RFD_SetDirRFD, value);
			}
		}

		[Category("RFD")]
		public bool IgnoraEcfMfd
		{
			get
			{
				return GetBool(ACBrRFDInterop.RFD_GetIgnoraEcfMfd);
			}
			set
			{
				SetBool(ACBrRFDInterop.RFD_SetIgnoraEcfMfd, value);
			}
		}

		[Category("Componentes ACBr")]
		public ACBrECF ECF
		{
			get
			{
				return this.ecf;
			}
			set
			{
				if (value == null)
				{
					if (ecf != null)
					{
						int ret = ACBrRFDInterop.RFD_SetECF(this.Handle, IntPtr.Zero);
						CheckResult(ret);

						var oecf = ecf;
						ecf = null;

						if (oecf.RFD != null)
							oecf.RFD = null;
					}
					else if (this.ecf != null)
					{						
						int ret = ACBrRFDInterop.RFD_SetECF(this.Handle, IntPtr.Zero);
						CheckResult(ret);

						this.ecf = null;
					}
				}
				else
				{
					int ret = ACBrRFDInterop.RFD_SetECF(this.Handle, value.Handle);
					CheckResult(ret);

					ecf = value;
					
					if(ecf.RFD == null)
						this.ecf.RFD = this;				
				}
			}
		}

		[Category("Software House")]
		public string SH_CNPJ
		{
			get
			{
				return GetString(ACBrRFDInterop.RFD_GetSH_CNPJ);
			}
			set
			{
				SetString(ACBrRFDInterop.RFD_SetSH_CNPJ, value);
			}
		}

		[Category("Software House")]
		public string SH_COO
		{
			get
			{
				return GetString(ACBrRFDInterop.RFD_GetSH_COO);
			}
			set
			{
				SetString(ACBrRFDInterop.RFD_SetSH_COO, value);
			}
		}

		[Category("Software House")]
		public string SH_IE
		{
			get
			{
				return GetString(ACBrRFDInterop.RFD_GetSH_IE);
			}
			set
			{
				SetString(ACBrRFDInterop.RFD_SetSH_IE, value);
			}
		}

		[Category("Software House")]
		public string SH_IM
		{
			get
			{
				return GetString(ACBrRFDInterop.RFD_GetSH_IM);
			}
			set
			{
				SetString(ACBrRFDInterop.RFD_SetSH_IM, value);
			}
		}

		[Category("Software House")]
		public string SH_Linha1
		{
			get
			{
				return GetString(ACBrRFDInterop.RFD_GetSH_Linha1);
			}
			set
			{
				SetString(ACBrRFDInterop.RFD_SetSH_Linha1, value);
			}
		}

		[Category("Software House")]
		public string SH_Linha2
		{
			get
			{
				return GetString(ACBrRFDInterop.RFD_GetSH_Linha2);
			}
			set
			{
				SetString(ACBrRFDInterop.RFD_SetSH_Linha2, value);
			}
		}

		[Category("Software House")]
		public string SH_NomeAplicativo
		{
			get
			{
				return GetString(ACBrRFDInterop.RFD_GetSH_NomeAplicativo);
			}
			set
			{
				SetString(ACBrRFDInterop.RFD_SetSH_NomeAplicativo, value);
			}
		}

		[Category("Software House")]
		public string SH_VersaoAplicativo
		{
			get
			{
				return GetString(ACBrRFDInterop.RFD_GetSH_VersaoAplicativo);
			}
			set
			{
				SetString(ACBrRFDInterop.RFD_SetSH_VersaoAplicativo, value);
			}
		}

		[Category("Software House")]
		public string SH_NumeroAplicativo
		{
			get
			{
				return GetString(ACBrRFDInterop.RFD_GetSH_NumeroAplicativo);
			}
			set
			{
				SetString(ACBrRFDInterop.RFD_SetSH_NumeroAplicativo, value);
			}
		}

		#endregion Visiveis

		#region Não Visiveis

		[Browsable(false)]
		public bool Ativo
		{
			get
			{
				return GetBool(ACBrRFDInterop.RFD_GetAtivo);
			}
			set
			{
				SetBool(ACBrRFDInterop.RFD_SetAtivo, value);
			}
		}

		[Browsable(false)]
		public DateTime DiaMov
		{
			get
			{
				return GetDateTime(ACBrRFDInterop.RFD_GetDiaMov);
			}
		}

		[Browsable(false)]
		public string DirECF
		{
			get
			{
				return GetString(ACBrRFDInterop.RFD_GetDirECF);
			}
		}

		[Browsable(false)]
		public string DirECFLog
		{
			get
			{
				return GetString(ACBrRFDInterop.RFD_GetDirECFLog);
			}
		}

		[Browsable(false)]
		public string DirECFMes
		{
			get
			{
				return GetString(ACBrRFDInterop.RFD_GetDirECFMes);
			}
		}

		[Browsable(false)]
		public string ArqRFDID
		{
			get
			{
				return GetString(ACBrRFDInterop.RFD_GetArqRFDID);
			}
		}

		[Browsable(false)]
		public string ArqRFD
		{
			get
			{
				return GetString(ACBrRFDInterop.RFD_GetArqRFD);
			}
		}

		[Browsable(false)]
		public string ArqReducaoZ
		{
			get
			{
				return GetString(ACBrRFDInterop.RFD_GetArqReducaoZ);
			}
		}

		[Browsable(false)]
		public string ArqINI
		{
			get
			{
				return GetString(ACBrRFDInterop.RFD_GetArqINI);
			}
		}

		[Browsable(false)]
		public int ECF_CROAtual
		{
			get
			{
				return GetInt32(ACBrRFDInterop.RFD_GetECF_CROAtual);
			}
			set
			{
				SetInt32(ACBrRFDInterop.RFD_SetECF_CROAtual, value);
			}
		}

		[Browsable(false)]
		public string ECF_RFDID
		{
			get
			{
				return GetString(ACBrRFDInterop.RFD_GetECF_RFDID);
			}
			set
			{
				SetString(ACBrRFDInterop.RFD_SetECF_RFDID, value);
			}
		}

		[Browsable(false)]
		public DateTime DataHoraSwBasico
		{
			get
			{
				return GetDateTime(ACBrRFDInterop.RFD_GetECF_DataHoraSwBasico);
			}
			set
			{
				SetDateTime(ACBrRFDInterop.RFD_SetECF_DataHoraSwBasico, value);
			}
		}

		[Browsable(false)]
		public string AtoCotepe
		{
			get
			{
				return GetString(ACBrRFDInterop.RFD_GetAtoCotepe);
			}
			set
			{
				SetString(ACBrRFDInterop.RFD_SetAtoCotepe, value);
			}
		}

		[Browsable(false)]
		public string CONT_CNPJ
		{
			get
			{
				return GetString(ACBrRFDInterop.RFD_GetCONT_CNPJ);
			}
			set
			{
				SetString(ACBrRFDInterop.RFD_SetCONT_CNPJ, value);
			}
		}

		[Browsable(false)]
		public string CONT_IE
		{
			get
			{
				return GetString(ACBrRFDInterop.RFD_GetCONT_IE);
			}
			set
			{
				SetString(ACBrRFDInterop.RFD_SetCONT_IE, value);
			}
		}

		[Browsable(false)]
		public int CONT_NumUsuario
		{
			get
			{
				return GetInt32(ACBrRFDInterop.RFD_GetCONT_NumUsuario);
			}
			set
			{
				SetInt32(ACBrRFDInterop.RFD_SetCONT_NumUsuario, value);
			}
		}

		[Browsable(false)]
		public string CONT_RazaoSocial
		{
			get
			{
				return GetString(ACBrRFDInterop.RFD_GetCONT_RazaoSocial);
			}
			set
			{
				SetString(ACBrRFDInterop.RFD_SetCONT_RazaoSocial, value);
			}
		}

		[Browsable(false)]
		public string CONT_Endereco
		{
			get
			{
				return GetString(ACBrRFDInterop.RFD_GetCONT_Endereco);
			}
			set
			{
				SetString(ACBrRFDInterop.RFD_SetCONT_Endereco, value);
			}
		}

		[Browsable(false)]
		public DateTime CONT_DataHoraCadastro
		{
			get
			{
				return GetDateTime(ACBrRFDInterop.RFD_GetCONT_DataHoraCadastro);
			}
			set
			{
				SetDateTime(ACBrRFDInterop.RFD_SetCONT_DataHoraCadastro, value);
			}
		}

		[Browsable(false)]
		public int CONT_CROCadastro
		{
			get
			{
				return GetInt32(ACBrRFDInterop.RFD_GetCONT_CROCadastro);
			}
			set
			{
				SetInt32(ACBrRFDInterop.RFD_SetCONT_CROCadastro, value);
			}
		}

		[Browsable(false)]
		public decimal CONT_GTCadastro
		{
			get
			{
				return GetDecimal(ACBrRFDInterop.RFD_GetCONT_GTCadastro);
			}
			set
			{
				SetDecimal(ACBrRFDInterop.RFD_SetCONT_GTCadastro, value);
			}
		}
		

		#endregion Não Visiveis

		#endregion Properties

		#region Methods

		#region Funções

		public void Ativar()
		{
			int ret = ACBrRFDInterop.RFD_Ativar(this.Handle);
			CheckResult(ret);
		}

		public void Desativar()
		{
			int ret = ACBrRFDInterop.RFD_Desativar(this.Handle);
			CheckResult(ret);
		}

		public void VerificaParametros()
		{
			int ret = ACBrRFDInterop.RFD_VerificaParametros(this.Handle);
			CheckResult(ret);
		}

		public string AchaRFDID(string RFDID)
		{
			const int bufferlen = 256;
			StringBuilder buffer = new StringBuilder(bufferlen);

			int ret = ACBrRFDInterop.RFD_AchaRFDID(this.Handle, ToUTF8(RFDID), buffer, bufferlen);
			CheckResult(ret);

			return FromUTF8(buffer.ToString());
		}

		public void LerINI()
		{
			int ret = ACBrRFDInterop.RFD_LerINI(this.Handle);
			CheckResult(ret);
		}

		public void GravarINI()
		{
			int ret = ACBrRFDInterop.RFD_LerINI(this.Handle);
			CheckResult(ret);
		}

		public void CriarArqRFDID(string arquivo)
		{
			int ret = ACBrRFDInterop.RFD_CriarArqRFDID(this.Handle, ToUTF8(arquivo));
			CheckResult(ret);
		}

		public string NomeArqRFD(DateTime DtMov)
		{
			const int bufferlen = 256;
			StringBuilder buffer = new StringBuilder(bufferlen);

			int ret = ACBrRFDInterop.RFD_NomeArqRFD(this.Handle, DtMov.ToOADate(), buffer, bufferlen);
			CheckResult(ret);

			return FromUTF8(buffer.ToString());
		}

		public void AbreCupom()
		{
			int ret = ACBrRFDInterop.RFD_AbreCupom(this.Handle);
			CheckResult(ret);
		}

		public void VendeItem(string codigo, string descricao, decimal Qtd, decimal ValorUnitario, string Unidade, decimal ValorDescAcres, string Aliquota)
		{
			int ret = ACBrRFDInterop.RFD_VendeItem(this.Handle, ToUTF8(codigo), ToUTF8(descricao), ToUTF8(Qtd), ToUTF8(ValorUnitario), ToUTF8(Unidade),ToUTF8(ValorDescAcres), ToUTF8(Aliquota));
			CheckResult(ret);
		}

		public void SubTotalizaCupom(decimal DescontoAcrescimo)
		{
			int ret = ACBrRFDInterop.RFD_SubTotalizaCupom(this.Handle, ToUTF8(DescontoAcrescimo));
			CheckResult(ret);
		}

		public void FechaCupom()
		{
			int ret = ACBrRFDInterop.RFD_FechaCupom(this.Handle);
			CheckResult(ret);
		}

		public void CancelaCupom(int COO)
		{
			int ret = ACBrRFDInterop.RFD_CancelaCupom(this.Handle, COO);
			CheckResult(ret);
		}

		public void CancelaItemVendido(int NumItem)
		{
			int ret = ACBrRFDInterop.RFD_CancelaItemVendido(this.Handle, NumItem);
			CheckResult(ret);
		}

		public void ReducaoZ(string ReducaoZ)
		{
			int ret = ACBrRFDInterop.RFD_ReducaoZ(this.Handle, ToUTF8(ReducaoZ));
			CheckResult(ret);
		}

		public void Documento(string Denominacao)
		{
			int ret = ACBrRFDInterop.RFD_Documento(this.Handle, ToUTF8(Denominacao));
			CheckResult(ret);
		}

		public void EfetuaPagamento(string DescricaoFormaPagto, decimal Valor)
		{
			int ret = ACBrRFDInterop.RFD_EfetuaPagamento(this.Handle, ToUTF8(DescricaoFormaPagto), ToUTF8(Valor));
			CheckResult(ret);
		}

		#endregion Funções

		#region EventHandlers

		#endregion EventHandlers

		#region Override Methods

		protected internal override void OnInitializeComponent()
		{
			CallCreate(ACBrRFDInterop.RFD_Create);
		}

		protected internal override void CheckResult(int ret)
		{
			switch (ret)
			{
				case -1:

					string error = GetString(ACBrRFDInterop.RFD_GetUltimoErro);
					throw new ACBrException(error);

				case -2:

					throw new ACBrException("ACBrRFD não inicializado.");
			}
		}

		protected override void OnDisposing()
		{
			if (Handle != IntPtr.Zero)
			{
				if (ecf != null)
				{
					if (this.Ativo)
						Desativar();

					var oecf = ecf;
					ecf = null;
					if (oecf.RFD != null)
						oecf.RFD = null;
				}

				CallDestroy(ACBrRFDInterop.RFD_Destroy);
			}
		}

		#endregion Override Methods

		#region Interop EventCallbacks

		[AllowReversePInvokeCalls]
		private void OnCalcEADCallback(string arquivo)
		{
			if (onCalcEAD.IsAssigned)
			{
				OnCalcEADArgs e = new OnCalcEADArgs(arquivo);
				onCalcEAD.Raise(e);
			}
		}

		[AllowReversePInvokeCalls]
		private string OnCalcHashLogCallback(string linha)
		{
			OnCalcHashLogArgs e = new OnCalcHashLogArgs(linha);
	
			if (onCalcHashLog.IsAssigned)				
				onCalcHashLog.Raise(e);

				return ToUTF8(e.Hash);
		}

		[AllowReversePInvokeCalls]
		private string OnGetKeyHashLogCallback()
		{
			ChaveEventArgs e = new ChaveEventArgs();

			if (onGetKeyHashLog.IsAssigned)
				onGetKeyHashLog.Raise(e);

			return ToUTF8(e.Chave);
		}

		[AllowReversePInvokeCalls]
		private string OnGetKeyRSACallback()
		{
			ChaveEventArgs e = new ChaveEventArgs();

			if (onGetKeyRSA.IsAssigned)
				onGetKeyRSA.Raise(e);

			return ToUTF8(e.Chave);
		}

		#endregion Interop EventCallbacks

		#endregion Methods
	}
}