using ACBrFramework.AAC;
using ACBrFramework.EAD;
using ACBrFramework.RFD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ACBrFramework.ECF
{
	#region COM Interop

#if COM_INTEROP

	#region IDispatch Interface

	#region Documentation

	/// <summary>
	/// Interface contendo os eventos publicados pelo componente COM
	/// </summary>

	#endregion Documentation

	[ComVisible(true)]
	[Guid("EB11262D-1650-41D0-8235-4774384C6631")]
	[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IACBrECFEvents
	{
		[DispId(1)]
		void OnMsgPoucoPapel();

		[DispId(2)]
		void OnAguardandoRespostaChange();

		[DispId(3)]
		void OnAntesAbreCupom(AbreCupomArgs e);

		[DispId(4)]
		void OnAntesAbreCupomVinculado();

		[DispId(5)]
		void OnAntesAbreNaoFiscal(AbreCupomArgs e);

		[DispId(6)]
		void OnAntesAbreRelatorioGerencial(AntesAbreRelatorioGerencialArgs e);

		[DispId(7)]
		void OnAntesCancelaCupom();

		[DispId(8)]
		void OnAntesCancelaItemNaoFiscal(CancelaItemArgs e);

		[DispId(9)]
		void OnAntesCancelaItemVendido(CancelaItemArgs e);

		[DispId(10)]
		void OnBobinaAdicionaLinhas(BobinaEventArgs e);
	}

	#endregion IDispatch Interface

	#region Delegates

	#region Comments

	///os componentes COM não suportam Generics
	///Estas são implementações específicas de delegates que no .Net são representados como EventHandler<T>

	#endregion Comments

	public delegate void AntesAbreCupomEventHandler(AbreCupomArgs e);

	public delegate void AntesAbreNaoFiscalEventHandler(AbreCupomArgs e);

	public delegate void AntesAbreRelatorioGerencialEventHandler(AntesAbreRelatorioGerencialArgs e);

	public delegate void AntesCancelaItemNaoFiscalEventHandler(CancelaItemArgs e);

	public delegate void AntesCancelaItemVendidoEventHandler(CancelaItemArgs e);

	public delegate void BobinaAdicionaLinhasEventHandler(BobinaEventArgs e);

	#endregion Delegates

#endif

	#endregion COM Interop

	#region COM Interop Attributes

#if COM_INTEROP

	[ComVisible(true)]
	[Guid("7F5440D4-8D62-441B-9251-E911437D5F8F")]
	[ComSourceInterfaces(typeof(IACBrECFEvents))]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM Interop Attributes

	[ToolboxBitmap(typeof(ToolboxIcons), @"ACBrFramework.Serial.ECF.ico.bmp")]
	public class ACBrECF : ACBrComponent, IDisposable
	{
		#region Events

		public event EventHandler OnMsgPoucoPapel
		{
			add
			{
				onMsgPoucoPapel.Add(value);
			}
			remove
			{
				onMsgPoucoPapel.Remove(value);
			}
		}

		public event EventHandler OnAguardandoRespostaChange
		{
			add
			{
				onAguardandoRespostaChange.Add(value);
			}
			remove
			{
				onAguardandoRespostaChange.Remove(value);
			}
		}

#if COM_INTEROP

		public event AntesAbreCupomEventHandler OnAntesAbreCupom
#else
		public event EventHandler<AbreCupomArgs> OnAntesAbreCupom
#endif
		{
			add
			{
				onAntesAbreCupom.Add(value);
			}
			remove
			{
				onAntesAbreCupom.Remove(value);
			}
		}

		public event EventHandler OnAntesAbreCupomVinculado
		{
			add
			{
				onAntesAbreCupomVinculado.Add(value);
			}
			remove
			{
				onAntesAbreCupomVinculado.Remove(value);
			}
		}

#if COM_INTEROP

		public event AntesAbreNaoFiscalEventHandler OnAntesAbreNaoFiscal
#else
		public event EventHandler<AbreCupomArgs> OnAntesAbreNaoFiscal
#endif
		{
			add
			{
				onAntesAbreNaoFiscal.Add(value);
			}
			remove
			{
				onAntesAbreNaoFiscal.Remove(value);
			}
		}

#if COM_INTEROP

		public event AntesAbreRelatorioGerencialEventHandler OnAntesAbreRelatorioGerencial
#else
		public event EventHandler<AbreRelatorioGerencialArgs> OnAntesAbreRelatorioGerencial
#endif
		{
			add
			{
				onAntesAbreRelatorioGerencial.Add(value);
			}
			remove
			{
				onAntesAbreRelatorioGerencial.Remove(value);
			}
		}

		public event EventHandler OnAntesCancelaCupom
		{
			add
			{
				onAntesCancelaCupom.Add(value);
			}
			remove
			{
				onAntesCancelaCupom.Remove(value);
			}
		}

#if COM_INTEROP

		public event AntesCancelaItemNaoFiscalEventHandler OnAntesCancelaItemNaoFiscal
#else
		public event EventHandler<CancelaItemArgs> OnAntesCancelaItemNaoFiscal
#endif
		{
			add
			{
				onAntesCancelaItemNaoFiscal.Add(value);
			}
			remove
			{
				onAntesCancelaItemNaoFiscal.Remove(value);
			}
		}

#if COM_INTEROP

		public event AntesCancelaItemVendidoEventHandler OnAntesCancelaItemVendido
#else

		public event EventHandler<CancelaItemArgs> OnAntesCancelaItemVendido
#endif
		{
			add
			{
				onAntesCancelaItemVendido.Add(value);
			}
			remove
			{
				onAntesCancelaItemVendido.Remove(value);
			}
		}

		public event EventHandler OnAntesCancelaNaoFiscal
		{
			add
			{
				onAntesCancelaNaoFiscal.Add(value);
			}
			remove
			{
				onAntesCancelaNaoFiscal.Remove(value);
			}
		}

		public event EventHandler<EfetuaPagamentoArgs> OnAntesEfetuaPagamento
		{
			add
			{
				onAntesEfetuaPagamento.Add(value);
			}
			remove
			{
				onAntesEfetuaPagamento.Remove(value);
			}
		}

		public event EventHandler<EfetuaPagamentoArgs> OnAntesEfetuaPagamentoNaoFiscal
		{
			add
			{
				onAntesEfetuaPagamentoNaoFiscal.Add(value);
			}
			remove
			{
				onAntesEfetuaPagamentoNaoFiscal.Remove(value);
			}
		}

		public event EventHandler<FechaCupomArgs> OnAntesFechaCupom
		{
			add
			{
				onAntesFechaCupom.Add(value);
			}
			remove
			{
				onAntesFechaCupom.Remove(value);
			}
		}

		public event EventHandler<FechaCupomArgs> OnAntesFechaNaoFiscal
		{
			add
			{
				onAntesFechaNaoFiscal.Add(value);
			}
			remove
			{
				onAntesFechaNaoFiscal.Remove(value);
			}
		}

		public event EventHandler OnAntesFechaRelatorio
		{
			add
			{
				onAntesFechaRelatorio.Add(value);
			}
			remove
			{
				onAntesFechaRelatorio.Remove(value);
			}
		}

		public event EventHandler OnAntesLeituraX
		{
			add
			{
				onAntesLeituraX.Add(value);
			}
			remove
			{
				onAntesLeituraX.Remove(value);
			}
		}

		public event EventHandler OnAntesReducaoZ
		{
			add
			{
				onAntesReducaoZ.Add(value);
			}
			remove
			{
				onAntesReducaoZ.Remove(value);
			}
		}

		public event EventHandler<SangriaSuprimentoArgs> OnAntesSangria
		{
			add
			{
				onAntesSangria.Add(value);
			}
			remove
			{
				onAntesSangria.Remove(value);
			}
		}

		public event EventHandler<SubtotalizaCupomArgs> OnAntesSubtotalizaCupom
		{
			add
			{
				onAntesSubtotalizaCupom.Add(value);
			}
			remove
			{
				onAntesSubtotalizaCupom.Remove(value);
			}
		}

		public event EventHandler<SubtotalizaCupomArgs> OnAntesSubtotalizaNaoFiscal
		{
			add
			{
				onAntesSubtotalizaNaoFiscal.Add(value);
			}
			remove
			{
				onAntesSubtotalizaNaoFiscal.Remove(value);
			}
		}

		public event EventHandler<SangriaSuprimentoArgs> OnAntesSuprimento
		{
			add
			{
				onAntesSuprimento.Add(value);
			}
			remove
			{
				onAntesSuprimento.Remove(value);
			}
		}

		public event EventHandler<VendeItemArgs> OnAntesVendeItem
		{
			add
			{
				onAntesVendeItem.Add(value);
			}
			remove
			{
				onAntesVendeItem.Remove(value);
			}
		}

#if COM_INTEROP

		public event BobinaAdicionaLinhasEventHandler OnBobinaAdicionaLinhas
#else
		public event EventHandler<BobinaEventArgs> OnBobinaAdicionaLinhas
#endif
		{
			add
			{
				onBobinaAdicionaLinhas.Add(value);
			}
			remove
			{
				onBobinaAdicionaLinhas.Remove(value);
			}
		}
		
		public event EventHandler<ChangeEstadoArgs> OnChangeEstado
		{
			add
			{
				onChangeEstado.Add(value);
			}
			remove
			{
				onChangeEstado.Remove(value);
			}
		}

		public event EventHandler<ChequeEstadoArgs> OnChequeEstado
		{
			add
			{
				onChequeEstado.Add(value);
			}
			remove
			{
				onChequeEstado.Remove(value);
			}
		}

		public event EventHandler<AbreCupomArgs> OnDepoisAbreCupom
		{
			add
			{
				onDepoisAbreCupom.Add(value);
			}
			remove
			{
				onDepoisAbreCupom.Remove(value);
			}
		}

		public event EventHandler OnDepoisAbreCupomVinculado
		{
			add
			{
				onDepoisAbreCupomVinculado.Add(value);
			}
			remove
			{
				onDepoisAbreCupomVinculado.Remove(value);
			}
		}

		public event EventHandler<AbreCupomArgs> OnDepoisAbreNaoFiscal
		{
			add
			{
				onDepoisAbreNaoFiscal.Add(value);
			}
			remove
			{
				onDepoisAbreNaoFiscal.Remove(value);
			}
		}

		public event EventHandler<AbreRelatorioGerencialArgs> OnDepoisAbreRelatorioGerencial
		{
			add
			{
				onDepoisAbreRelatorioGerencial.Add(value);
			}
			remove
			{
				onDepoisAbreRelatorioGerencial.Remove(value);
			}
		}

		public event EventHandler OnDepoisCancelaCupom
		{
			add
			{
				onDepoisCancelaCupom.Add(value);
			}
			remove
			{
				onDepoisCancelaCupom.Remove(value);
			}
		}

		public event EventHandler<CancelaItemArgs> OnDepoisCancelaItemNaoFiscal
		{
			add
			{
				onDepoisCancelaItemNaoFiscal.Add(value);
			}
			remove
			{
				onDepoisCancelaItemNaoFiscal.Remove(value);
			}
		}

		public event EventHandler<CancelaItemArgs> OnDepoisCancelaItemVendido
		{
			add
			{
				onDepoisCancelaItemVendido.Add(value);
			}
			remove
			{
				onDepoisCancelaItemVendido.Remove(value);
			}
		}

		public event EventHandler OnDepoisCancelaNaoFiscal
		{
			add
			{
				onDepoisCancelaNaoFiscal.Add(value);
			}
			remove
			{
				onDepoisCancelaNaoFiscal.Remove(value);
			}
		}

		public event EventHandler<EfetuaPagamentoArgs> OnDepoisEfetuaPagamento
		{
			add
			{
				onDepoisEfetuaPagamento.Add(value);
			}
			remove
			{
				onDepoisEfetuaPagamento.Remove(value);
			}
		}

		public event EventHandler<EfetuaPagamentoArgs> OnDepoisEfetuaPagamentoNaoFiscal
		{
			add
			{
				onDepoisEfetuaPagamentoNaoFiscal.Add(value);
			}
			remove
			{
				onDepoisEfetuaPagamentoNaoFiscal.Remove(value);
			}
		}

		public event EventHandler<FechaCupomArgs> OnDepoisFechaCupom
		{
			add
			{
				onDepoisFechaCupom.Add(value);
			}
			remove
			{
				onDepoisFechaCupom.Remove(value);
			}
		}

		public event EventHandler<FechaCupomArgs> OnDepoisFechaNaoFiscal
		{
			add
			{
				onDepoisFechaNaoFiscal.Add(value);
			}
			remove
			{
				onDepoisFechaNaoFiscal.Remove(value);
			}
		}

		public event EventHandler OnDepoisFechaRelatorio
		{
			add
			{
				onDepoisFechaRelatorio.Add(value);
			}
			remove
			{
				onDepoisFechaRelatorio.Remove(value);
			}
		}

		public event EventHandler OnDepoisLeituraX
		{
			add
			{
				onDepoisLeituraX.Add(value);
			}
			remove
			{
				onDepoisLeituraX.Remove(value);
			}
		}

		public event EventHandler OnDepoisReducaoZ
		{
			add
			{
				onDepoisReducaoZ.Add(value);
			}
			remove
			{
				onDepoisReducaoZ.Remove(value);
			}
		}

		public event EventHandler<SangriaSuprimentoArgs> OnDepoisSangria
		{
			add
			{
				onDepoisSangria.Add(value);
			}
			remove
			{
				onDepoisSangria.Remove(value);
			}
		}

		public event EventHandler<SubtotalizaCupomArgs> OnDepoisSubtotalizaCupom
		{
			add
			{
				onDepoisSubtotalizaCupom.Add(value);
			}
			remove
			{
				onDepoisSubtotalizaCupom.Remove(value);
			}
		}

		public event EventHandler<SubtotalizaCupomArgs> OnDepoisSubtotalizaNaoFiscal
		{
			add
			{
				onDepoisSubtotalizaNaoFiscal.Add(value);
			}
			remove
			{
				onDepoisSubtotalizaNaoFiscal.Remove(value);
			}
		}

		public event EventHandler<SangriaSuprimentoArgs> OnDepoisSuprimento
		{
			add
			{
				onDepoisSuprimento.Add(value);
			}
			remove
			{
				onDepoisSuprimento.Remove(value);
			}
		}

		public event EventHandler<VendeItemArgs> OnDepoisVendeItem
		{
			add
			{
				onDepoisVendeItem.Add(value);
			}
			remove
			{
				onDepoisVendeItem.Remove(value);
			}
		}

		public event EventHandler<OnErrorArgs> OnErrorAbreCupom
		{
			add
			{
				onErrorAbreCupom.Add(value);
			}
			remove
			{
				onErrorAbreCupom.Remove(value);
			}
		}

		public event EventHandler<OnErrorArgs> OnErrorAbreCupomVinculado
		{
			add
			{
				onErrorAbreCupomVinculado.Add(value);
			}
			remove
			{
				onErrorAbreCupomVinculado.Remove(value);
			}
		}

		public event EventHandler<OnErrorArgs> OnErrorAbreNaoFiscal
		{
			add
			{
				onErrorAbreNaoFiscal.Add(value);
			}
			remove
			{
				onErrorAbreNaoFiscal.Remove(value);
			}
		}

		public event EventHandler<OnErrorRelatorioArgs> OnErrorAbreRelatorioGerencial
		{
			add
			{
				onErrorAbreRelatorioGerencial.Add(value);
			}
			remove
			{
				onErrorAbreRelatorioGerencial.Remove(value);
			}
		}

		public event EventHandler<OnErrorArgs> OnErrorCancelaCupom
		{
			add
			{
				onErrorCancelaCupom.Add(value);
			}
			remove
			{
				onErrorCancelaCupom.Remove(value);
			}
		}

		public event EventHandler<OnErrorArgs> OnErrorCancelaItemNaoFiscal
		{
			add
			{
				onErrorCancelaItemNaoFiscal.Add(value);
			}
			remove
			{
				onErrorCancelaItemNaoFiscal.Remove(value);
			}
		}

		public event EventHandler<OnErrorArgs> OnErrorCancelaItemVendido
		{
			add
			{
				onErrorCancelaItemVendido.Add(value);
			}
			remove
			{
				onErrorCancelaItemVendido.Remove(value);
			}
		}

		public event EventHandler<OnErrorArgs> OnErrorCancelaNaoFiscal
		{
			add
			{
				onErrorCancelaNaoFiscal.Add(value);
			}
			remove
			{
				onErrorCancelaNaoFiscal.Remove(value);
			}
		}

		public event EventHandler<OnErrorArgs> OnErrorEfetuaPagamento
		{
			add
			{
				onErrorEfetuaPagamento.Add(value);
			}
			remove
			{
				onErrorEfetuaPagamento.Remove(value);
			}
		}

		public event EventHandler<OnErrorArgs> OnErrorEfetuaPagamentoNaoFiscal
		{
			add
			{
				onErrorEfetuaPagamentoNaoFiscal.Add(value);
			}
			remove
			{
				onErrorEfetuaPagamentoNaoFiscal.Remove(value);
			}
		}

		public event EventHandler<OnErrorArgs> OnErrorFechaCupom
		{
			add
			{
				onErrorFechaCupom.Add(value);
			}
			remove
			{
				onErrorFechaCupom.Remove(value);
			}
		}

		public event EventHandler<OnErrorArgs> OnErrorFechaNaoFiscal
		{
			add
			{
				onErrorFechaNaoFiscal.Add(value);
			}
			remove
			{
				onErrorFechaNaoFiscal.Remove(value);
			}
		}

		public event EventHandler<OnErrorArgs> OnErrorFechaRelatorio
		{
			add
			{
				onErrorFechaRelatorio.Add(value);
			}
			remove
			{
				onErrorFechaRelatorio.Remove(value);
			}
		}

		public event EventHandler<OnErrorArgs> OnErrorLeituraX
		{
			add
			{
				onErrorLeituraX.Add(value);
			}
			remove
			{
				onErrorLeituraX.Remove(value);
			}
		}

		public event EventHandler<OnErrorArgs> OnErrorReducaoZ
		{
			add
			{
				onErrorReducaoZ.Add(value);
			}
			remove
			{
				onErrorReducaoZ.Remove(value);
			}
		}

		public event EventHandler<OnErrorArgs> OnErrorSangria
		{
			add
			{
				onErrorSangria.Add(value);
			}
			remove
			{
				onErrorSangria.Remove(value);
			}
		}

		public event EventHandler OnErrorSemPapel
		{
			add
			{
				onErrorSemPapel.Add(value);
			}
			remove
			{
				onErrorSemPapel.Remove(value);
			}
		}

		public event EventHandler<OnErrorArgs> OnErrorSubtotalizaCupom
		{
			add
			{
				onErrorSubtotalizaCupom.Add(value);
			}
			remove
			{
				onErrorSubtotalizaCupom.Remove(value);
			}
		}

		public event EventHandler<OnErrorArgs> OnErrorSubtotalizaNaoFiscal
		{
			add
			{
				onErrorSubtotalizaNaoFiscal.Add(value);
			}
			remove
			{
				onErrorSubtotalizaNaoFiscal.Remove(value);
			}
		}

		public event EventHandler<OnErrorArgs> OnErrorSuprimento
		{
			add
			{
				onErrorSuprimento.Add(value);
			}
			remove
			{
				onErrorSuprimento.Remove(value);
			}
		}

		public event EventHandler<OnErrorArgs> OnErrorVendeItem
		{
			add
			{
				onErrorVendeItem.Add(value);
			}
			remove
			{
				onErrorVendeItem.Remove(value);
			}
		}

		public event EventHandler<OnMsgArgs> OnMsgAguarde
		{
			add
			{
				onMsgAguarde.Add(value);
			}
			remove
			{
				onMsgAguarde.Remove(value);
			}
		}

		public event EventHandler<OnMsgRetentarArgs> OnMsgRetentar
		{
			add
			{
				onMsgRetentar.Add(value);
			}
			remove
			{
				onMsgRetentar.Remove(value);
			}
		}

		public event EventHandler<OnPAFCalcEADArgs> OnPAFCalcEAD
		{
			add
			{
				onPAFCalcEAD.Add(value);
			}
			remove
			{
				onPAFCalcEAD.Remove(value);
			}
		}

		public event EventHandler<ChaveEventArgs> OnPAFGetKeyRSA
		{
			add
			{
				onPAFGetKeyRSA.Add(value);
			}
			remove
			{
				onPAFGetKeyRSA.Remove(value);
			}
		}

		#endregion Events

		#region Fields

		private Aliquota[] aliquotas;
		private FormaPagamento[] formasPagamento;
		private ComprovanteNaoFiscal[] comprovantesNaoFiscais;
		private RelatorioGerencial[] relatoriosGerenciais;
		private ACBrAAC aac;
		private ACBrEAD ead;
		private ACBrRFD rfd;

		private readonly ACBrEventHandler<ACBrECFInterop.NoArgumentCallback> onMsgPoucoPapel;
		private readonly ACBrEventHandler<ACBrECFInterop.NoArgumentCallback> onAguardandoRespostaChange;
		private readonly ACBrEventHandler<AbreCupomArgs, ACBrECFInterop.AbreCupomCallback> onAntesAbreCupom;
		private readonly ACBrEventHandler<ACBrECFInterop.NoArgumentCallback> onAntesAbreCupomVinculado;
		private readonly ACBrEventHandler<AbreCupomArgs, ACBrECFInterop.AbreCupomCallback> onAntesAbreNaoFiscal;
		private readonly ACBrEventHandler<AbreRelatorioGerencialArgs, ACBrECFInterop.IntArgumentCallback> onAntesAbreRelatorioGerencial;
		private readonly ACBrEventHandler<ACBrECFInterop.NoArgumentCallback> onAntesCancelaCupom;
		private readonly ACBrEventHandler<CancelaItemArgs, ACBrECFInterop.IntArgumentCallback> onAntesCancelaItemNaoFiscal;
		private readonly ACBrEventHandler<CancelaItemArgs, ACBrECFInterop.IntArgumentCallback> onAntesCancelaItemVendido;
		private readonly ACBrEventHandler<ACBrECFInterop.NoArgumentCallback> onAntesCancelaNaoFiscal;
		private readonly ACBrEventHandler<EfetuaPagamentoArgs, ACBrECFInterop.EfetuaPagamentoCallback> onAntesEfetuaPagamento;
		private readonly ACBrEventHandler<EfetuaPagamentoArgs, ACBrECFInterop.EfetuaPagamentoCallback> onAntesEfetuaPagamentoNaoFiscal;
		private readonly ACBrEventHandler<FechaCupomArgs, ACBrECFInterop.FechaCupomCallback> onAntesFechaCupom;
		private readonly ACBrEventHandler<FechaCupomArgs, ACBrECFInterop.FechaCupomCallback> onAntesFechaNaoFiscal;
		private readonly ACBrEventHandler<ACBrECFInterop.NoArgumentCallback> onAntesFechaRelatorio;
		private readonly ACBrEventHandler<ACBrECFInterop.NoArgumentCallback> onAntesLeituraX;
		private readonly ACBrEventHandler<ACBrECFInterop.NoArgumentCallback> onAntesReducaoZ;
		private readonly ACBrEventHandler<SangriaSuprimentoArgs, ACBrECFInterop.SangriaSuprimentoCallback> onAntesSangria;
		private readonly ACBrEventHandler<SubtotalizaCupomArgs, ACBrECFInterop.SubtotalizaCupomCallback> onAntesSubtotalizaCupom;
		private readonly ACBrEventHandler<SubtotalizaCupomArgs, ACBrECFInterop.SubtotalizaCupomCallback> onAntesSubtotalizaNaoFiscal;
		private readonly ACBrEventHandler<SangriaSuprimentoArgs, ACBrECFInterop.SangriaSuprimentoCallback> onAntesSuprimento;
		private readonly ACBrEventHandler<VendeItemArgs, ACBrECFInterop.VendeItemCallback> onAntesVendeItem;
		private readonly ACBrEventHandler<BobinaEventArgs, ACBrECFInterop.BobinaAdicionaLinhasCallback> onBobinaAdicionaLinhas;
		private readonly ACBrEventHandler<ChangeEstadoArgs, ACBrECFInterop.ChangeEstadoCallback> onChangeEstado;
		private readonly ACBrEventHandler<ChequeEstadoArgs, ACBrECFInterop.ChequeEstadoCallback> onChequeEstado;
		private readonly ACBrEventHandler<AbreCupomArgs, ACBrECFInterop.AbreCupomCallback> onDepoisAbreCupom;
		private readonly ACBrEventHandler<ACBrECFInterop.NoArgumentCallback> onDepoisAbreCupomVinculado;
		private readonly ACBrEventHandler<AbreCupomArgs, ACBrECFInterop.AbreCupomCallback> onDepoisAbreNaoFiscal;
		private readonly ACBrEventHandler<AbreRelatorioGerencialArgs, ACBrECFInterop.IntArgumentCallback> onDepoisAbreRelatorioGerencial;
		private readonly ACBrEventHandler<ACBrECFInterop.NoArgumentCallback> onDepoisCancelaCupom;
		private readonly ACBrEventHandler<CancelaItemArgs, ACBrECFInterop.IntArgumentCallback> onDepoisCancelaItemNaoFiscal;
		private readonly ACBrEventHandler<CancelaItemArgs, ACBrECFInterop.IntArgumentCallback> onDepoisCancelaItemVendido;
		private readonly ACBrEventHandler<ACBrECFInterop.NoArgumentCallback> onDepoisCancelaNaoFiscal;
		private readonly ACBrEventHandler<EfetuaPagamentoArgs, ACBrECFInterop.EfetuaPagamentoCallback> onDepoisEfetuaPagamento;
		private readonly ACBrEventHandler<EfetuaPagamentoArgs, ACBrECFInterop.EfetuaPagamentoCallback> onDepoisEfetuaPagamentoNaoFiscal;
		private readonly ACBrEventHandler<FechaCupomArgs, ACBrECFInterop.FechaCupomCallback> onDepoisFechaCupom;
		private readonly ACBrEventHandler<FechaCupomArgs, ACBrECFInterop.FechaCupomCallback> onDepoisFechaNaoFiscal;
		private readonly ACBrEventHandler<ACBrECFInterop.NoArgumentCallback> onDepoisFechaRelatorio;
		private readonly ACBrEventHandler<ACBrECFInterop.NoArgumentCallback> onDepoisLeituraX;
		private readonly ACBrEventHandler<ACBrECFInterop.NoArgumentCallback> onDepoisReducaoZ;
		private readonly ACBrEventHandler<SangriaSuprimentoArgs, ACBrECFInterop.SangriaSuprimentoCallback> onDepoisSangria;
		private readonly ACBrEventHandler<SubtotalizaCupomArgs, ACBrECFInterop.SubtotalizaCupomCallback> onDepoisSubtotalizaCupom;
		private readonly ACBrEventHandler<SubtotalizaCupomArgs, ACBrECFInterop.SubtotalizaCupomCallback> onDepoisSubtotalizaNaoFiscal;
		private readonly ACBrEventHandler<SangriaSuprimentoArgs, ACBrECFInterop.SangriaSuprimentoCallback> onDepoisSuprimento;
		private readonly ACBrEventHandler<VendeItemArgs, ACBrECFInterop.VendeItemCallback> onDepoisVendeItem;
		private readonly ACBrEventHandler<OnErrorArgs, ACBrECFInterop.OnErrorCallback> onErrorAbreCupom;
		private readonly ACBrEventHandler<OnErrorArgs, ACBrECFInterop.OnErrorCallback> onErrorAbreCupomVinculado;
		private readonly ACBrEventHandler<OnErrorArgs, ACBrECFInterop.OnErrorCallback> onErrorAbreNaoFiscal;
		private readonly ACBrEventHandler<OnErrorRelatorioArgs, ACBrECFInterop.OnErrorRelatorioCallback> onErrorAbreRelatorioGerencial;
		private readonly ACBrEventHandler<OnErrorArgs, ACBrECFInterop.OnErrorCallback> onErrorCancelaCupom;
		private readonly ACBrEventHandler<OnErrorArgs, ACBrECFInterop.OnErrorCallback> onErrorCancelaItemNaoFiscal;
		private readonly ACBrEventHandler<OnErrorArgs, ACBrECFInterop.OnErrorCallback> onErrorCancelaItemVendido;
		private readonly ACBrEventHandler<OnErrorArgs, ACBrECFInterop.OnErrorCallback> onErrorCancelaNaoFiscal;
		private readonly ACBrEventHandler<OnErrorArgs, ACBrECFInterop.OnErrorCallback> onErrorEfetuaPagamento;
		private readonly ACBrEventHandler<OnErrorArgs, ACBrECFInterop.OnErrorCallback> onErrorEfetuaPagamentoNaoFiscal;
		private readonly ACBrEventHandler<OnErrorArgs, ACBrECFInterop.OnErrorCallback> onErrorFechaCupom;
		private readonly ACBrEventHandler<OnErrorArgs, ACBrECFInterop.OnErrorCallback> onErrorFechaNaoFiscal;
		private readonly ACBrEventHandler<OnErrorArgs, ACBrECFInterop.OnErrorCallback> onErrorFechaRelatorio;
		private readonly ACBrEventHandler<OnErrorArgs, ACBrECFInterop.OnErrorCallback> onErrorLeituraX;
		private readonly ACBrEventHandler<OnErrorArgs, ACBrECFInterop.OnErrorCallback> onErrorReducaoZ;
		private readonly ACBrEventHandler<OnErrorArgs, ACBrECFInterop.OnErrorCallback> onErrorSangria;
		private readonly ACBrEventHandler<ACBrECFInterop.NoArgumentCallback> onErrorSemPapel;
		private readonly ACBrEventHandler<OnErrorArgs, ACBrECFInterop.OnErrorCallback> onErrorSubtotalizaCupom;
		private readonly ACBrEventHandler<OnErrorArgs, ACBrECFInterop.OnErrorCallback> onErrorSubtotalizaNaoFiscal;
		private readonly ACBrEventHandler<OnErrorArgs, ACBrECFInterop.OnErrorCallback> onErrorSuprimento;
		private readonly ACBrEventHandler<OnErrorArgs, ACBrECFInterop.OnErrorCallback> onErrorVendeItem;

		private readonly ACBrEventHandler<OnMsgArgs, ACBrECFInterop.StringCallback> onMsgAguarde;
		private readonly ACBrEventHandler<OnMsgRetentarArgs, ACBrECFInterop.OnMsgRetentarCallback> onMsgRetentar;
		private readonly ACBrEventHandler<OnPAFCalcEADArgs, ACBrECFInterop.StringCallback> onPAFCalcEAD;
		private readonly ACBrEventHandler<ChaveEventArgs, ACBrECFInterop.GetKeyCallback> onPAFGetKeyRSA;

		#endregion Fields

		#region Constructor

		public ACBrECF()
		{
			onMsgPoucoPapel = new ACBrEventHandler<ACBrECFInterop.NoArgumentCallback>(this, OnMsgPoucoPapelCallback, ACBrECFInterop.ECF_SetOnPoucoPapel);
			onAguardandoRespostaChange = new ACBrEventHandler<ACBrECFInterop.NoArgumentCallback>(this, OnAguardandoRespostaChangeCallback, ACBrECFInterop.ECF_SetOnAguardandoRespostaChange);
			onAntesAbreCupom = new ACBrEventHandler<AbreCupomArgs, ACBrECFInterop.AbreCupomCallback>(this, OnAntesAbreCupomCallback, ACBrECFInterop.ECF_SetOnAntesAbreCupom);
			onAntesAbreCupomVinculado = new ACBrEventHandler<ACBrECFInterop.NoArgumentCallback>(this, OnAntesAbreCupomVinculadoCallback, ACBrECFInterop.ECF_SetOnAntesAbreCupomVinculado);
			onAntesAbreNaoFiscal = new ACBrEventHandler<AbreCupomArgs, ACBrECFInterop.AbreCupomCallback>(this, OnAntesAbreNaoFiscalCallback, ACBrECFInterop.ECF_SetOnAntesAbreNaoFiscal);
			onAntesAbreRelatorioGerencial = new ACBrEventHandler<AbreRelatorioGerencialArgs, ACBrECFInterop.IntArgumentCallback>(this, OnAntesAbreRelatorioGerencialCallback, ACBrECFInterop.ECF_SetOnAntesAbreRelatorioGerencial);
			onAntesCancelaCupom = new ACBrEventHandler<ACBrECFInterop.NoArgumentCallback>(this, OnAntesCancelaCupomCallback, ACBrECFInterop.ECF_SetOnAntesCancelaCupom);
			onAntesCancelaItemNaoFiscal = new ACBrEventHandler<CancelaItemArgs, ACBrECFInterop.IntArgumentCallback>(this, OnAntesCancelaItemNaoFiscalCallback, ACBrECFInterop.ECF_SetOnAntesCancelaItemNaoFiscal);
			onAntesCancelaItemVendido = new ACBrEventHandler<CancelaItemArgs, ACBrECFInterop.IntArgumentCallback>(this, OnAntesCancelaItemVendidoCallback, ACBrECFInterop.ECF_SetOnAntesCancelaItemVendido);
			onAntesCancelaNaoFiscal = new ACBrEventHandler<ACBrECFInterop.NoArgumentCallback>(this, OnAntesCancelaNaoFiscalCallback, ACBrECFInterop.ECF_SetOnAntesCancelaNaoFiscal);
			onAntesEfetuaPagamento = new ACBrEventHandler<EfetuaPagamentoArgs, ACBrECFInterop.EfetuaPagamentoCallback>(this, OnAntesEfetuaPagamentoCallback, ACBrECFInterop.ECF_SetOnAntesEfetuaPagamento);
			onAntesEfetuaPagamentoNaoFiscal = new ACBrEventHandler<EfetuaPagamentoArgs, ACBrECFInterop.EfetuaPagamentoCallback>(this, OnAntesEfetuaPagamentoNaoFiscalCallback, ACBrECFInterop.ECF_SetOnAntesEfetuaPagamentoNaoFiscal);
			onAntesFechaCupom = new ACBrEventHandler<FechaCupomArgs, ACBrECFInterop.FechaCupomCallback>(this, OnAntesFechaCupomCallback, ACBrECFInterop.ECF_SetOnAntesFechaCupom);
			onAntesFechaNaoFiscal = new ACBrEventHandler<FechaCupomArgs, ACBrECFInterop.FechaCupomCallback>(this, OnAntesFechaNaoFiscalCallback, ACBrECFInterop.ECF_SetOnAntesFechaNaoFiscal);
			onAntesFechaRelatorio = new ACBrEventHandler<ACBrECFInterop.NoArgumentCallback>(this, OnAntesFechaRelatorioCallback, ACBrECFInterop.ECF_SetOnAntesFechaRelatorio);
			onAntesLeituraX = new ACBrEventHandler<ACBrECFInterop.NoArgumentCallback>(this, OnAntesLeituraXCallback, ACBrECFInterop.ECF_SetOnAntesLeituraX);
			onAntesReducaoZ = new ACBrEventHandler<ACBrECFInterop.NoArgumentCallback>(this, OnAntesReducaoZCallback, ACBrECFInterop.ECF_SetOnAntesReducaoZ);
			onAntesSangria = new ACBrEventHandler<SangriaSuprimentoArgs, ACBrECFInterop.SangriaSuprimentoCallback>(this, OnAntesSangriaCallback, ACBrECFInterop.ECF_SetOnAntesSangria);
			onAntesSubtotalizaCupom = new ACBrEventHandler<SubtotalizaCupomArgs, ACBrECFInterop.SubtotalizaCupomCallback>(this, OnAntesSubtotalizaCupomCallback, ACBrECFInterop.ECF_SetOnAntesSubtotalizaCupom);
			onAntesSubtotalizaNaoFiscal = new ACBrEventHandler<SubtotalizaCupomArgs, ACBrECFInterop.SubtotalizaCupomCallback>(this, OnAntesSubtotalizaNaoFiscalCallback, ACBrECFInterop.ECF_SetOnAntesSubtotalizaCupom);
			onAntesSuprimento = new ACBrEventHandler<SangriaSuprimentoArgs, ACBrECFInterop.SangriaSuprimentoCallback>(this, OnAntesSuprimentoCallback, ACBrECFInterop.ECF_SetOnAntesSuprimento);
			onAntesVendeItem = new ACBrEventHandler<VendeItemArgs, ACBrECFInterop.VendeItemCallback>(this, OnAntesVendeItemCallback, ACBrECFInterop.ECF_SetOnAntesVendeItem);
			onBobinaAdicionaLinhas = new ACBrEventHandler<BobinaEventArgs, ACBrECFInterop.BobinaAdicionaLinhasCallback>(this, OnBobinaAdicionaLinhasCallback, ACBrECFInterop.ECF_SetOnBobinaAdicionaLinhas);
			onChangeEstado = new ACBrEventHandler<ChangeEstadoArgs, ACBrECFInterop.ChangeEstadoCallback>(this, OnChangeEstadoCallback, ACBrECFInterop.ECF_SetOnChangeEstado);
			onChequeEstado = new ACBrEventHandler<ChequeEstadoArgs, ACBrECFInterop.ChequeEstadoCallback>(this, OnChequeEstadoCallback, ACBrECFInterop.ECF_SetOnChequeEstado);
			onDepoisAbreCupom = new ACBrEventHandler<AbreCupomArgs, ACBrECFInterop.AbreCupomCallback>(this, OnDepoisAbreCupomCallback, ACBrECFInterop.ECF_SetOnDepoisAbreCupom);
			onDepoisAbreCupomVinculado = new ACBrEventHandler<ACBrECFInterop.NoArgumentCallback>(this, OnDepoisAbreCupomVinculadoCallback, ACBrECFInterop.ECF_SetOnDepoisAbreCupomVinculado);
			onDepoisAbreNaoFiscal = new ACBrEventHandler<AbreCupomArgs, ACBrECFInterop.AbreCupomCallback>(this, OnDepoisAbreNaoFiscalCallback, ACBrECFInterop.ECF_SetOnDepoisAbreNaoFiscal);
			onDepoisAbreRelatorioGerencial = new ACBrEventHandler<AbreRelatorioGerencialArgs, ACBrECFInterop.IntArgumentCallback>(this, OnDepoisAbreRelatorioGerencialCallback, ACBrECFInterop.ECF_SetOnDepoisAbreRelatorioGerencial);
			onDepoisCancelaCupom = new ACBrEventHandler<ACBrECFInterop.NoArgumentCallback>(this, OnDepoisCancelaCupomCallback, ACBrECFInterop.ECF_SetOnDepoisCancelaCupom);
			onDepoisCancelaItemNaoFiscal = new ACBrEventHandler<CancelaItemArgs, ACBrECFInterop.IntArgumentCallback>(this, OnDepoisCancelaItemNaoFiscalCallback, ACBrECFInterop.ECF_SetOnDepoisCancelaItemNaoFiscal);
			onDepoisCancelaItemVendido = new ACBrEventHandler<CancelaItemArgs, ACBrECFInterop.IntArgumentCallback>(this, OnDepoisCancelaItemVendidoCallback, ACBrECFInterop.ECF_SetOnDepoisCancelaItemVendido);
			onDepoisCancelaNaoFiscal = new ACBrEventHandler<ACBrECFInterop.NoArgumentCallback>(this, OnDepoisCancelaNaoFiscalCallback, ACBrECFInterop.ECF_SetOnDepoisCancelaNaoFiscal);
			onDepoisEfetuaPagamento = new ACBrEventHandler<EfetuaPagamentoArgs, ACBrECFInterop.EfetuaPagamentoCallback>(this, OnDepoisEfetuaPagamentoCallback, ACBrECFInterop.ECF_SetOnDepoisEfetuaPagamento);
			onDepoisEfetuaPagamentoNaoFiscal = new ACBrEventHandler<EfetuaPagamentoArgs, ACBrECFInterop.EfetuaPagamentoCallback>(this, OnDepoisEfetuaPagamentoNaoFiscalCallback, ACBrECFInterop.ECF_SetOnDepoisEfetuaPagamentoNaoFiscal);
			onDepoisFechaCupom = new ACBrEventHandler<FechaCupomArgs, ACBrECFInterop.FechaCupomCallback>(this, OnDepoisFechaCupomCallback, ACBrECFInterop.ECF_SetOnDepoisFechaCupom);
			onDepoisFechaNaoFiscal = new ACBrEventHandler<FechaCupomArgs, ACBrECFInterop.FechaCupomCallback>(this, OnDepoisFechaNaoFiscalCallback, ACBrECFInterop.ECF_SetOnDepoisFechaNaoFiscal);
			onDepoisFechaRelatorio = new ACBrEventHandler<ACBrECFInterop.NoArgumentCallback>(this, OnDepoisFechaRelatorioCallback, ACBrECFInterop.ECF_SetOnDepoisFechaRelatorio);
			onDepoisLeituraX = new ACBrEventHandler<ACBrECFInterop.NoArgumentCallback>(this, OnDepoisLeituraXCallback, ACBrECFInterop.ECF_SetOnDepoisLeituraX);
			onDepoisReducaoZ = new ACBrEventHandler<ACBrECFInterop.NoArgumentCallback>(this, OnDepoisReducaoZCallback, ACBrECFInterop.ECF_SetOnDepoisReducaoZ);
			onDepoisSangria = new ACBrEventHandler<SangriaSuprimentoArgs, ACBrECFInterop.SangriaSuprimentoCallback>(this, OnDepoisSangriaCallback, ACBrECFInterop.ECF_SetOnDepoisSangria);
			onDepoisSubtotalizaCupom = new ACBrEventHandler<SubtotalizaCupomArgs, ACBrECFInterop.SubtotalizaCupomCallback>(this, OnDepoisSubtotalizaCupomCallback, ACBrECFInterop.ECF_SetOnDepoisSubtotalizaCupom);
			onDepoisSubtotalizaNaoFiscal = new ACBrEventHandler<SubtotalizaCupomArgs, ACBrECFInterop.SubtotalizaCupomCallback>(this, OnDepoisSubtotalizaNaoFiscalCallback, ACBrECFInterop.ECF_SetOnDepoisSubtotalizaCupom);
			onDepoisSuprimento = new ACBrEventHandler<SangriaSuprimentoArgs, ACBrECFInterop.SangriaSuprimentoCallback>(this, OnDepoisSuprimentoCallback, ACBrECFInterop.ECF_SetOnDepoisSuprimento);
			onDepoisVendeItem = new ACBrEventHandler<VendeItemArgs, ACBrECFInterop.VendeItemCallback>(this, OnDepoisVendeItemCallback, ACBrECFInterop.ECF_SetOnDepoisVendeItem);
			onErrorAbreCupom = new ACBrEventHandler<OnErrorArgs, ACBrECFInterop.OnErrorCallback>(this, OnErrorAbreCupomCallback, ACBrECFInterop.ECF_SetOnErrorAbreCupom);
			onErrorAbreCupomVinculado = new ACBrEventHandler<OnErrorArgs, ACBrECFInterop.OnErrorCallback>(this, OnErrorAbreCupomVinculadoCallback, ACBrECFInterop.ECF_SetOnErrorAbreCupomVinculado);
			onErrorAbreNaoFiscal = new ACBrEventHandler<OnErrorArgs, ACBrECFInterop.OnErrorCallback>(this, OnErrorAbreNaoFiscalCallback, ACBrECFInterop.ECF_SetOnErrorAbreNaoFiscal);
			onErrorAbreRelatorioGerencial = new ACBrEventHandler<OnErrorRelatorioArgs, ACBrECFInterop.OnErrorRelatorioCallback>(this, OnErrorAbreRelatorioGerencialCallback, ACBrECFInterop.ECF_SetOnErrorAbreRelatorioGerencial);
			onErrorCancelaCupom = new ACBrEventHandler<OnErrorArgs, ACBrECFInterop.OnErrorCallback>(this, OnErrorCancelaCupomCallback, ACBrECFInterop.ECF_SetOnErrorCancelaCupom);
			onErrorCancelaItemNaoFiscal = new ACBrEventHandler<OnErrorArgs, ACBrECFInterop.OnErrorCallback>(this, OnErrorCancelaItemNaoFiscalCallback, ACBrECFInterop.ECF_SetOnErrorCancelaItemNaoFiscal);
			onErrorCancelaItemVendido = new ACBrEventHandler<OnErrorArgs, ACBrECFInterop.OnErrorCallback>(this, OnErrorCancelaItemVendidoCallback, ACBrECFInterop.ECF_SetOnErrorCancelaItemVendido);
			onErrorCancelaNaoFiscal = new ACBrEventHandler<OnErrorArgs, ACBrECFInterop.OnErrorCallback>(this, OnErrorCancelaNaoFiscalCallback, ACBrECFInterop.ECF_SetOnErrorCancelaNaoFiscal);
			onErrorEfetuaPagamento = new ACBrEventHandler<OnErrorArgs, ACBrECFInterop.OnErrorCallback>(this, OnErrorEfetuaPagamentoCallback, ACBrECFInterop.ECF_SetOnErrorEfetuaPagamento);
			onErrorEfetuaPagamentoNaoFiscal = new ACBrEventHandler<OnErrorArgs, ACBrECFInterop.OnErrorCallback>(this, OnErrorEfetuaPagamentoNaoFiscalCallback, ACBrECFInterop.ECF_SetOnErrorEfetuaPagamentoNaoFiscal);
			onErrorFechaCupom = new ACBrEventHandler<OnErrorArgs, ACBrECFInterop.OnErrorCallback>(this, OnErrorFechaCupomCallback, ACBrECFInterop.ECF_SetOnErrorFechaCupom);
			onErrorFechaNaoFiscal = new ACBrEventHandler<OnErrorArgs, ACBrECFInterop.OnErrorCallback>(this, OnErrorFechaNaoFiscalCallback, ACBrECFInterop.ECF_SetOnErrorFechaNaoFiscal);
			onErrorFechaRelatorio = new ACBrEventHandler<OnErrorArgs, ACBrECFInterop.OnErrorCallback>(this, OnErrorFechaRelatorioCallback, ACBrECFInterop.ECF_SetOnErrorFechaRelatorio);
			onErrorLeituraX = new ACBrEventHandler<OnErrorArgs, ACBrECFInterop.OnErrorCallback>(this, OnErrorLeituraXCallback, ACBrECFInterop.ECF_SetOnErrorLeituraX);
			onErrorReducaoZ = new ACBrEventHandler<OnErrorArgs, ACBrECFInterop.OnErrorCallback>(this, OnErrorReducaoZCallback, ACBrECFInterop.ECF_SetOnErrorReducaoZ);
			onErrorSangria = new ACBrEventHandler<OnErrorArgs, ACBrECFInterop.OnErrorCallback>(this, OnErrorSangriaCallback, ACBrECFInterop.ECF_SetOnErrorSangria);
			onErrorSemPapel = new ACBrEventHandler<ACBrECFInterop.NoArgumentCallback>(this, OnErrorSemPapelCallback, ACBrECFInterop.ECF_SetOnErrorSemPapel);
			onErrorSubtotalizaCupom = new ACBrEventHandler<OnErrorArgs, ACBrECFInterop.OnErrorCallback>(this, OnErrorSubtotalizaCupomCallback, ACBrECFInterop.ECF_SetOnErrorSubtotalizaCupom);
			onErrorSubtotalizaNaoFiscal = new ACBrEventHandler<OnErrorArgs, ACBrECFInterop.OnErrorCallback>(this, OnErrorSubtotalizaNaoFiscalCallback, ACBrECFInterop.ECF_SetOnErrorSubtotalizaCupom);
			onErrorSuprimento = new ACBrEventHandler<OnErrorArgs, ACBrECFInterop.OnErrorCallback>(this, OnErrorSuprimentoCallback, ACBrECFInterop.ECF_SetOnErrorSuprimento);
			onErrorVendeItem = new ACBrEventHandler<OnErrorArgs, ACBrECFInterop.OnErrorCallback>(this, OnErrorVendeItemCallback, ACBrECFInterop.ECF_SetOnErrorVendeItem);
			onMsgAguarde = new ACBrEventHandler<OnMsgArgs, ACBrECFInterop.StringCallback>(this, OnMsgAguardeCallback, ACBrECFInterop.ECF_SetOnMsgAguarde);
			onMsgRetentar = new ACBrEventHandler<OnMsgRetentarArgs, ACBrECFInterop.OnMsgRetentarCallback>(this, OnMsgRetentarCallback, ACBrECFInterop.ECF_SetOnMsgRetentar);
			onPAFCalcEAD = new ACBrEventHandler<OnPAFCalcEADArgs, ACBrECFInterop.StringCallback>(this, OnPAFCalcEADCallback, ACBrECFInterop.ECF_SetPAFCalcEAD);
			onPAFGetKeyRSA = new ACBrEventHandler<ChaveEventArgs, ACBrECFInterop.GetKeyCallback>(this, OnPAFGetKeyRSACallback, ACBrECFInterop.ECF_SetPAFGetKeyRSA);
		}

		#endregion Constructor

		#region Properties

		#region Visiveis

		[Category("Configutações ECF")]
		public ModeloECF Modelo
		{
			get
			{
				return (ModeloECF)GetInt32(ACBrECFInterop.ECF_GetModelo);
			}
			set
			{
				SetInt32(ACBrECFInterop.ECF_SetModelo, (int)value);
			}
		}

		[Category("Configutações ECF")]
		public ACBrDevice Device { get; private set; }

		[Category("Propriedades")]
		public int MaxLinhasBuffer
		{
			get
			{
				return GetInt32(ACBrECFInterop.ECF_GetMaxLinhasBuffer);
			}
			set
			{
				SetInt32(ACBrECFInterop.ECF_SetMaxLinhasBuffer, value);
			}
		}

		[Category("Propriedades")]
		public bool DescricaoGrande
		{
			get
			{
				return GetBool(ACBrECFInterop.ECF_GetDescricaoGrande);
			}
			set
			{
				SetBool(ACBrECFInterop.ECF_SetDescricaoGrande, value);
			}
		}

		[Category("Propriedades")]
		public bool GavetaSinalInvertido
		{
			get
			{
				return GetBool(ACBrECFInterop.ECF_GetGavetaSinalInvertido);
			}
			set
			{
				SetBool(ACBrECFInterop.ECF_SetGavetaSinalInvertido, value);
			}
		}

		[Category("Propriedades")]
		public bool ArredondaPorQtd
		{
			get
			{
				return GetBool(ACBrECFInterop.ECF_GetArredondaPorQtd);
			}
			set
			{
				SetBool(ACBrECFInterop.ECF_SetArredondaPorQtd, value);
			}
		}

		[Category("Propriedades")]
		public bool ArredondaItemMFD
		{
			get
			{
				return GetBool(ACBrECFInterop.ECF_GetArredondaItemMFD);
			}
			set
			{
				SetBool(ACBrECFInterop.ECF_SetArredondaItemMFD, value);
			}
		}

		[Category("Propriedades")]
		public bool IgnorarTagsFormatacao
		{
			get
			{
				return GetBool(ACBrECFInterop.ECF_GetIgnorarTagsFormatacao);
			}
			set
			{
				SetBool(ACBrECFInterop.ECF_SetIgnorarTagsFormatacao, value);
			}
		}

		[Category("Propriedades")]
		public int PausaRelatorio
		{
			get
			{
				return GetInt32(ACBrECFInterop.ECF_GetPausaRelatorio);
			}
			set
			{
				SetInt32(ACBrECFInterop.ECF_SetPausaRelatorio, value);
			}
		}

		[Category("Propriedades")]
		public int PaginaDeCodigo
		{
			get
			{
				return GetInt32(ACBrECFInterop.ECF_GetPaginaDeCodigo);
			}
			set
			{
				SetInt32(ACBrECFInterop.ECF_SetPaginaDeCodigo, value);
			}
		}

		[Category("Propriedades")]
		public string About
		{
			get
			{
				return GetAbout(ACBrECFInterop.ECF_GetAbout);
			}
		}

		[Category("Propriedades")]
		public string ArqLOG
		{
			get
			{
				return GetString(ACBrECFInterop.ECF_GetArqLOG);
			}
			set
			{
				SetString(ACBrECFInterop.ECF_SetArqLOG, value);
			}
		}

		[Category("Propriedades")]
		public string Operador
		{
			get
			{
				return GetString(ACBrECFInterop.ECF_GetOperador);
			}
			set
			{
				SetString(ACBrECFInterop.ECF_SetOperador, value);
			}
		}

		[Category("Propriedades")]
		public string[] MemoParams
		{
			get
			{
				return GetStringArray(ACBrECFInterop.ECF_GetMemoParams, ACBrECFInterop.ECF_GetMemoParamsLineCount);
			}
			set
			{
				SetStringArray(ACBrECFInterop.ECF_SetMemoParams, value);
			}
		}

		[Category("Propriedades")]
		public int LinhasEntreCupons
		{
			get
			{
				return GetInt32(ACBrECFInterop.ECF_GetLinhasEntreCupons);
			}
			set
			{
				SetInt32(ACBrECFInterop.ECF_SetLinhasEntreCupons, value);
			}
		}

		[Category("Propriedades")]
		public int DecimaisPreco
		{
			get
			{
				return GetInt32(ACBrECFInterop.ECF_GetDecimaisPreco);
			}
			set
			{
				SetInt32(ACBrECFInterop.ECF_SetDecimaisPreco, value);
			}
		}

		[Category("Propriedades")]
		public int DecimaisQtd
		{
			get
			{
				return GetInt32(ACBrECFInterop.ECF_GetDecimaisQtd);
			}
			set
			{
				SetInt32(ACBrECFInterop.ECF_SetDecimaisQtd, value);
			}
		}

		[Browsable(true)]
		[Category("Rodape")]
		public Rodape InfoRodapeCupom { get; private set; }

		[Browsable(true)]
		[Category("ConfigBarras")]
		public ConfigBarras ConfigBarras { get; private set; }

		#endregion Visiveis

		#region Componentes ACBr

		[Category("Componentes ACBr")]
		public ACBrAAC AAC
		{
			get
			{
				return this.aac;
			}
			set
			{
				if (value == null)
				{
					int ret = ACBrECFInterop.ECF_SetAAC(this.Handle, IntPtr.Zero);
					CheckResult(ret);

					this.aac = null;
				}
				else
				{
					int ret = ACBrECFInterop.ECF_SetAAC(this.Handle, value.Handle);
					CheckResult(ret);

					this.aac = value;
				}
			}
		}

		[Category("Componentes ACBr")]
		public ACBrEAD EAD
		{
			get
			{
				return this.ead;
			}
			set
			{
				if (value == null)
				{
					int ret = ACBrECFInterop.ECF_SetEAD(this.Handle, IntPtr.Zero);
					CheckResult(ret);

					this.ead = null;
				}
				else
				{
					int ret = ACBrECFInterop.ECF_SetEAD(this.Handle, value.Handle);
					CheckResult(ret);

					this.ead = value;
				}
			}
		}

		[Category("Componentes ACBr")]
		public ACBrRFD RFD
		{
			get
			{
				return this.rfd;
			}
			set
			{
				if (value == null)
				{
					if (rfd != null)
					{
						int ret = ACBrECFInterop.ECF_SetRFD(this.Handle, IntPtr.Zero);
						CheckResult(ret);

						var orfd = rfd;
						rfd = null;

						if (orfd.ECF != null)
							orfd.ECF = null;
					}
					else if (this.rfd != null)
					{
						int ret = ACBrECFInterop.ECF_SetRFD(this.Handle, IntPtr.Zero);
						CheckResult(ret);

						this.rfd = null;
					}
				}
				else
				{
					int ret = ACBrECFInterop.ECF_SetRFD(this.Handle, value.Handle);
					CheckResult(ret);

					this.rfd = value;

					if (rfd.ECF == null)
						this.rfd.ECF = this;
				}
			}
		}

		#endregion Componentes ACBr

		#region Propriedades Não-visiveis

		[Browsable(false)]
		public bool Ativo
		{
			get
			{
				return GetBool(ACBrECFInterop.ECF_GetAtivo);
			}
		}

		[Browsable(false)]
		public int Colunas
		{
			get
			{
				return GetInt32(ACBrECFInterop.ECF_GetColunas);
			}
		}

		[Browsable(false)]
		public bool AguardandoResposta
		{
			get
			{
				return GetBool(ACBrECFInterop.ECF_GetAguardandoResposta);
			}
		}

		[Browsable(false)]
		public string ComandoLog
		{
			get
			{
				return GetString(ACBrECFInterop.ECF_GetComandoLOG);
			}
			set
			{
				SetString(ACBrECFInterop.ECF_SetComandoLOG, value);
			}
		}

		[Browsable(false)]
		public bool AguardaImpressao
		{
			get
			{
				return GetBool(ACBrECFInterop.ECF_GetAguardaImpressao);
			}
			set
			{
				SetBool(ACBrECFInterop.ECF_SetAguardaImpressao, value);
			}
		}

		[Browsable(false)]
		public string ModeloStr
		{
			get
			{
				return GetString(ACBrECFInterop.ECF_GetModeloStr);
			}
		}

		[Browsable(false)]
		public string RFDID
		{
			get
			{
				return GetString(ACBrECFInterop.ECF_GetRFDID);
			}
		}

		[Browsable(false)]
		public DateTime DataHora
		{
			get
			{
				return GetDateTime(ACBrECFInterop.ECF_GetDataHora);
			}
		}

		[Browsable(false)]
		public string NumCupom
		{
			get
			{
				return GetString(ACBrECFInterop.ECF_GetNumCupom);
			}
		}

		[Browsable(false)]
		public string NumCOO
		{
			get
			{
				return GetString(ACBrECFInterop.ECF_GetNumCOO);
			}
		}

		[Browsable(false)]
		public string NumLoja
		{
			get
			{
				return GetString(ACBrECFInterop.ECF_GetNumLoja);
			}
		}

		[Browsable(false)]
		public string NumECF
		{
			get
			{
				return GetString(ACBrECFInterop.ECF_GetNumECF);
			}
		}

		[Browsable(false)]
		public string NumSerie
		{
			get
			{
				return GetString(ACBrECFInterop.ECF_GetNumSerie);
			}
		}

		[Browsable(false)]
		public string NumVersao
		{
			get
			{
				return GetString(ACBrECFInterop.ECF_GetNumVersao);
			}
		}

		[Browsable(false)]
		public DateTime DataMovimento
		{
			get
			{
				return GetDateTime(ACBrECFInterop.ECF_GetDataMovimento);
			}
		}

		[Browsable(false)]
		public DateTime DataHoraSB
		{
			get
			{
				return GetDateTime(ACBrECFInterop.ECF_GetDataHoraSB);
			}
		}

		[Browsable(false)]
		public string CNPJ
		{
			get
			{
				return GetString(ACBrECFInterop.ECF_GetCNPJ);
			}
		}

		[Browsable(false)]
		public string IE
		{
			get
			{
				return GetString(ACBrECFInterop.ECF_GetIE);
			}
		}

		[Browsable(false)]
		public string IM
		{
			get
			{
				return GetString(ACBrECFInterop.ECF_GetIM);
			}
		}

		[Browsable(false)]
		public string Cliche
		{
			get
			{
				return GetString(ACBrECFInterop.ECF_GetCliche);
			}
		}

		[Browsable(false)]
		public string UsuarioAtual
		{
			get
			{
				return GetString(ACBrECFInterop.ECF_GetUsuarioAtual);
			}
		}

		[Browsable(false)]
		public string SubModeloECF
		{
			get
			{
				return GetString(ACBrECFInterop.ECF_GetSubModeloECF);
			}
		}

		[Browsable(false)]
		public string PAF
		{
			get
			{
				return GetString(ACBrECFInterop.ECF_GetPAF);
			}
		}

		[Browsable(false)]
		public string NumCRZ
		{
			get
			{
				return GetString(ACBrECFInterop.ECF_GetNumCRZ);
			}
		}

		[Browsable(false)]
		public string NumCRO
		{
			get
			{
				return GetString(ACBrECFInterop.ECF_GetNumCRO);
			}
		}

		[Browsable(false)]
		public string NumCCF
		{
			get
			{
				return GetString(ACBrECFInterop.ECF_GetNumCCF);
			}
		}

		[Browsable(false)]
		public string NumGNF
		{
			get
			{
				return GetString(ACBrECFInterop.ECF_GetNumGNF);
			}
		}

		[Browsable(false)]
		public string NumGRG
		{
			get
			{
				return GetString(ACBrECFInterop.ECF_GetNumGRG);
			}
		}

		[Browsable(false)]
		public string NumCDC
		{
			get
			{
				return GetString(ACBrECFInterop.ECF_GetNumCDC);
			}
		}

		[Browsable(false)]
		public string NumCOOInicial
		{
			get
			{
				return GetString(ACBrECFInterop.ECF_GetNumCOOInicial);
			}
		}

		[Browsable(false)]
		public string ComandoEnviado
		{
			get
			{
				return GetString(ACBrECFInterop.ECF_GetComandoEnviado);
			}
		}

		[Browsable(false)]
		public string RespostaComando
		{
			get
			{
				return GetString(ACBrECFInterop.ECF_GetRespostaComando);
			}
		}

		[Browsable(false)]
		public decimal VendaBruta
		{
			get
			{
				return GetDecimal(ACBrECFInterop.ECF_GetVendaBruta);
			}
		}

		[Browsable(false)]
		public decimal GrandeTotal
		{
			get
			{
				return GetDecimal(ACBrECFInterop.ECF_GetGrandeTotal);
			}
		}

		[Browsable(false)]
		public decimal TotalCancelamentos
		{
			get
			{
				return GetDecimal(ACBrECFInterop.ECF_GetTotalCancelamentos);
			}
		}

		[Browsable(false)]
		public decimal TotalDescontos
		{
			get
			{
				return GetDecimal(ACBrECFInterop.ECF_GetTotalDescontos);
			}
		}

		[Browsable(false)]
		public decimal TotalAcrescimos
		{
			get
			{
				return GetDecimal(ACBrECFInterop.ECF_GetTotalAcrescimos);
			}
		}

		[Browsable(false)]
		public decimal TotalTroco
		{
			get
			{
				return GetDecimal(ACBrECFInterop.ECF_GetTotalTroco);
			}
		}

		[Browsable(false)]
		public decimal TotalSubstituicaoTributaria
		{
			get
			{
				return GetDecimal(ACBrECFInterop.ECF_GetTotalSubstituicaoTributaria);
			}
		}

		[Browsable(false)]
		public decimal TotalNaoTributado
		{
			get
			{
				return GetDecimal(ACBrECFInterop.ECF_GetTotalNaoTributado);
			}
		}

		[Browsable(false)]
		public decimal TotalIsencao
		{
			get
			{
				return GetDecimal(ACBrECFInterop.ECF_GetTotalIsencao);
			}
		}

		[Browsable(false)]
		public decimal TotalCancelamentosISSQN
		{
			get
			{
				return GetDecimal(ACBrECFInterop.ECF_GetTotalCancelamentosISSQN);
			}
		}

		[Browsable(false)]
		public decimal TotalDescontosISSQN
		{
			get
			{
				return GetDecimal(ACBrECFInterop.ECF_GetTotalDescontosISSQN);
			}
		}

		[Browsable(false)]
		public decimal TotalAcrescimosISSQN
		{
			get
			{
				return GetDecimal(ACBrECFInterop.ECF_GetTotalAcrescimosISSQN);
			}
		}

		[Browsable(false)]
		public decimal TotalSubstituicaoTributariaISSQN
		{
			get
			{
				return GetDecimal(ACBrECFInterop.ECF_GetTotalSubstituicaoTributariaISSQN);
			}
		}

		[Browsable(false)]
		public decimal TotalNaoTributadoISSQN
		{
			get
			{
				return GetDecimal(ACBrECFInterop.ECF_GetTotalNaoTributadoISSQN);
			}
		}

		[Browsable(false)]
		public decimal TotalIsencaoISSQN
		{
			get
			{
				return GetDecimal(ACBrECFInterop.ECF_GetTotalIsencaoISSQN);
			}
		}

		[Browsable(false)]
		public decimal TotalNaoFiscal
		{
			get
			{
				return GetDecimal(ACBrECFInterop.ECF_GetTotalNaoFiscal);
			}
		}

		[Browsable(false)]
		public int NumUltItem
		{
			get
			{
				return GetInt32(ACBrECFInterop.ECF_GetNumUltItem);
			}
		}

		[Browsable(false)]
		public bool EmLinha
		{
			get
			{
				const int DEFAULT_TIMEOUT = 1;
				int ret = ACBrECFInterop.ECF_GetEmLinha(this.Handle, DEFAULT_TIMEOUT);
				CheckResult(ret);

				return Convert.ToBoolean(ret);
			}
		}

		[Browsable(false)]
		public bool PoucoPapel
		{
			get
			{
				return GetBool(ACBrECFInterop.ECF_GetPoucoPapel);
			}
		}

		[Browsable(false)]
		public EstadoECF Estado
		{
			get
			{
				return (EstadoECF)GetInt32(ACBrECFInterop.ECF_GetEstado);
			}
		}

		[Browsable(false)]
		public bool HorarioVerao
		{
			get
			{
				return GetBool(ACBrECFInterop.ECF_GetHorarioVerao);
			}
		}

		[Browsable(false)]
		public bool Arredonda
		{
			get
			{
				return GetBool(ACBrECFInterop.ECF_GetArredonda);
			}
		}

		[Browsable(false)]
		public bool Termica
		{
			get
			{
				return GetBool(ACBrECFInterop.ECF_GetTermica);
			}
		}

		[Browsable(false)]
		public bool MFD
		{
			get
			{
				return GetBool(ACBrECFInterop.ECF_GetMFD);
			}
		}

		[Browsable(false)]
		public string MFAdicional
		{
			get
			{
				return GetString(ACBrECFInterop.ECF_GetMFAdicional);
			}
		}

		[Browsable(false)]
		public bool IdentificaConsumidorRodape
		{
			get
			{
				return GetBool(ACBrECFInterop.ECF_GetIdentificaConsumidorRodape);
			}
		}

		[Browsable(false)]
		public decimal SubTotal
		{
			get
			{
				return GetDecimal(ACBrECFInterop.ECF_GetSubTotal);
			}
		}

		[Browsable(false)]
		public decimal TotalPago
		{
			get
			{
				return GetDecimal(ACBrECFInterop.ECF_GetTotalPago);
			}
		}

		[Browsable(false)]
		public bool GavetaAberta
		{
			get
			{
				return GetBool(ACBrECFInterop.ECF_GetGavetaAberta);
			}
		}

		[Browsable(false)]
		public bool ChequePronto
		{
			get
			{
				return GetBool(ACBrECFInterop.ECF_GetChequePronto);
			}
		}

		[Browsable(false)]
		public int IntervaloAposComando
		{
			get
			{
				return GetInt32(ACBrECFInterop.ECF_GetIntervaloAposComando);
			}
			set
			{
				SetInt32(ACBrECFInterop.ECF_SetIntervaloAposComando, value);
			}
		}

		[Browsable(false)]
		public Aliquota[] Aliquotas
		{
			get
			{
				if (aliquotas == null) this.CarregaAliquotas();
				return (Aliquota[])aliquotas.Clone();
			}
		}

		[Browsable(false)]
		public FormaPagamento[] FormasPagamento
		{
			get
			{
				if (formasPagamento == null) CarregaFormasPagamento();
				return (FormaPagamento[])formasPagamento;
			}
		}

		[Browsable(false)]
		public RelatorioGerencial[] RelatoriosGerenciais
		{
			get
			{
				if (relatoriosGerenciais == null) CarregaRelatoriosGerenciais();
				return (RelatorioGerencial[])relatoriosGerenciais;
			}
		}

		[Browsable(false)]
		public ComprovanteNaoFiscal[] ComprovantesNaoFiscais
		{
			get
			{
				if (comprovantesNaoFiscais == null) CarregaComprovantesNaoFiscais();
				return (ComprovanteNaoFiscal[])comprovantesNaoFiscais;
			}
		}

		[Browsable(false)]
		public Consumidor Consumidor { get; private set; }

		[Browsable(false)]
		public DadosReducaoZClass DadosReducaoZClass { get; private set; }

		#endregion Propriedades Não-visiveis

		#endregion Properties

		#region Methods

		#region Métodos Ativar/Desativar

		public void Ativar()
		{
			int ret = ACBrECFInterop.ECF_Ativar(this.Handle);
			CheckResult(ret);
		}

		public void Desativar()
		{
			int ret = ACBrECFInterop.ECF_Desativar(this.Handle);
			CheckResult(ret);
		}

		#endregion Métodos Ativar/Desativar

		#region Métodos ECF

		public bool AcharECF()
		{
			return AcharECF(true, true, 3);
		}

		public bool AcharECF(bool Modelo)
		{
			return AcharECF(Modelo, true, 3);
		}

		public bool AcharECF(bool Modelo, bool Porta)
		{
			return AcharECF(Modelo, Porta, 3);
		}

		public bool AcharECF(bool Modelo, bool Porta, int TimeOut)
		{
			int ret = ACBrECFInterop.ECF_AcharECF(this.Handle, Modelo, Porta, TimeOut);
			CheckResult(ret);

			return Convert.ToBoolean(ret);
		}

		public bool AcharPorta()
		{
			return AcharPorta(3);
		}

		public bool AcharPorta(int TimeOut)
		{
			int ret = ACBrECFInterop.ECF_AcharPorta(this.Handle, TimeOut);
			CheckResult(ret);

			return Convert.ToBoolean(ret);
		}

		public void PulaLinhas(int numLinhas)
		{
			int ret = ACBrECFInterop.ECF_PulaLinhas(this.Handle, numLinhas);
			CheckResult(ret);
		}

		public void CortaPapel(bool corteParcial)
		{
			int ret = ACBrECFInterop.ECF_CortaPapel(this.Handle, corteParcial);
			CheckResult(ret);
		}

		public void CorrigeEstadoErro()
		{
			CorrigeEstadoErro(true);
		}

		public void CorrigeEstadoErro(bool reducaoZ)
		{
			int ret = ACBrECFInterop.ECF_CorrigeEstadoErro(this.Handle, reducaoZ);
			CheckResult(ret);
		}

		public void MudaHorarioVerao()
		{
			int ret = ACBrECFInterop.ECF_MudaHorarioVerao(this.Handle);
			CheckResult(ret);
		}

		public void PreparaTEF()
		{
			int ret = ACBrECFInterop.ECF_PreparaTEF(this.Handle);
			CheckResult(ret);

			CarregaAliquotas(GetInt32(ACBrECFInterop.ECF_GetALCount));
			CarregaFormasPagamento(GetInt32(ACBrECFInterop.ECF_GetFPGCount));
			CarregaComprovantesNaoFiscais(GetInt32(ACBrECFInterop.ECF_GetCNFCount));
		}

		public void TestaPodeAbrirCupom()
		{
			int ret = ACBrECFInterop.ECF_TestaPodeAbrirCupom(this.Handle);
			CheckResult(ret);
		}

		public string EnviaComando(string cmd)
		{
			return EnviaComando(cmd, -1);
		}

		public string EnviaComando(string cmd, int timeout)
		{
			int bufferlen = 512;
			StringBuilder buffer = new StringBuilder(bufferlen);

			int ret = ACBrECFInterop.ECF_EnviaComando(this.Handle, ToUTF8(cmd), timeout, buffer, bufferlen);
			CheckResult(ret);

			return FromUTF8(buffer.ToString());
		}

		#endregion Métodos ECF

		#region Métodos Cheque

		public void ImprimeCheque(string Banco, decimal Valor, string Favorecido, string Cidade, DateTime Data)
		{
			ImprimeCheque(Banco, Valor, Favorecido, Cidade, Data, string.Empty);
		}

		public void ImprimeCheque(string Banco, decimal Valor, string Favorecido, string Cidade, DateTime Data, string Observacao)
		{
			int ret = ACBrECFInterop.ECF_ImprimeCheque(this.Handle, ToUTF8(Banco), ToUTF8(Valor), ToUTF8(Favorecido), ToUTF8(Cidade), ToUTF8(Data), ToUTF8(Observacao));
			CheckResult(ret);
		}

		public void CancelaImpressaoCheque()
		{
			int ret = ACBrECFInterop.ECF_CancelaImpressaoCheque(this.Handle);
			CheckResult(ret);
		}

		public string LeituraCMC7()
		{
			int bufferlen = 256;
			StringBuilder buffer = new StringBuilder(bufferlen);

			int ret = ACBrECFInterop.ECF_LeituraCMC7(this.Handle, buffer, bufferlen);
			CheckResult(ret);

			return FromUTF8(buffer.ToString());
		}

		#endregion Métodos Cheque

		#region Métodos do Cupom Fiscal

		public void IdentificaConsumidor(string cpfCnpj, string nome, string endereco)
		{
			int ret = ACBrECFInterop.ECF_IdentificaConsumidor(this.Handle, ToUTF8(cpfCnpj), ToUTF8(nome), ToUTF8(endereco));
			CheckResult(ret);
		}

		public void AbreCupom()
		{
			AbreCupom(string.Empty, string.Empty, string.Empty);
		}

		public void AbreCupom(string cpfCnpj, string nome, string endereco)
		{
			int ret = ACBrECFInterop.ECF_AbreCupom(this.Handle, ToUTF8(cpfCnpj), ToUTF8(nome), ToUTF8(endereco));
			CheckResult(ret);
		}

		public void LegendaInmetroProximoItem()
		{
			int ret = ACBrECFInterop.ECF_LegendaInmetroProximoItem(this.Handle);
			CheckResult(ret);
		}

		public void VendeItem(string codigo, string descricao, string aliquotaICMS, decimal qtd, decimal valorUnitario)
		{
			VendeItem(codigo, descricao, aliquotaICMS, qtd, valorUnitario, 0, "UN", "%", "D", -1);
		}

		public void VendeItem(string codigo, string descricao, string aliquotaICMS, decimal qtd, decimal valorUnitario, decimal descontoPorc, string unidade, string tipoDescontoAcrescimo, string descontoAcrescimo)
		{
			VendeItem(codigo, descricao, aliquotaICMS, qtd, valorUnitario, descontoPorc, unidade, tipoDescontoAcrescimo, descontoAcrescimo, -1);
		}

		public void VendeItem(string codigo, string descricao, string aliquotaICMS, decimal qtd, decimal valorUnitario, decimal descontoPorc, string unidade, string tipoDescontoAcrescimo, string descontoAcrescimo, int CodDepartamento)
		{
			int ret = ACBrECFInterop.ECF_VendeItem(this.Handle, ToUTF8(codigo), ToUTF8(descricao), ToUTF8(aliquotaICMS), (double)qtd, (double)valorUnitario, (double)descontoPorc, ToUTF8(unidade), ToUTF8(tipoDescontoAcrescimo), ToUTF8(descontoAcrescimo), CodDepartamento);
			CheckResult(ret);
		}

		public void DescontoAcrescimoItemAnterior(decimal valorDesconto, string descontoAcrescimo)
		{
			DescontoAcrescimoItemAnterior(valorDesconto, descontoAcrescimo, "%", 0);
		}

		public void DescontoAcrescimoItemAnterior(decimal valorDesconto, string descontoAcrescimo, string tipodescontoAcrescimo, int item)
		{
			int ret = ACBrECFInterop.ECF_DescontoAcrescimoItemAnterior(this.Handle, (double)valorDesconto, ToUTF8(descontoAcrescimo), ToUTF8(tipodescontoAcrescimo), item);
			CheckResult(ret);
		}

		public void SubtotalizaCupom()
		{
			SubtotalizaCupom(0, "");
		}

		public void SubtotalizaCupom(decimal descontoAcrescimo, string mensagemRodape)
		{
			int ret = ACBrECFInterop.ECF_SubtotalizaCupom(this.Handle, (double)descontoAcrescimo, ToUTF8(mensagemRodape));
			CheckResult(ret);
		}

		public void EfetuaPagamento(string codFormaPagto, decimal valor)
		{
			EfetuaPagamento(codFormaPagto, valor, string.Empty, false);
		}

		public void EfetuaPagamento(string codFormaPagto, decimal valor, string observacao)
		{
			EfetuaPagamento(codFormaPagto, valor, observacao, false);
		}

		public void EfetuaPagamento(string codFormaPagto, decimal valor, string observacao, bool imprimeVinculado)
		{
			int ret = ACBrECFInterop.ECF_EfetuaPagamento(this.Handle, ToUTF8(codFormaPagto), (double)valor, ToUTF8(observacao), imprimeVinculado);
			CheckResult(ret);
		}

		public void EstornaPagamento(string codFormaPagtoEstornar, string codFormaPagtoEfetivar, double valor, string observacao)
		{
			int ret = ACBrECFInterop.ECF_EstornaPagamento(this.Handle, ToUTF8(codFormaPagtoEstornar), ToUTF8(codFormaPagtoEfetivar), valor, ToUTF8(observacao));
		}

		public void FechaCupom(string observacao)
		{
			int ret = ACBrECFInterop.ECF_FechaCupom(this.Handle, ToUTF8(observacao));
			CheckResult(ret);
		}

		public void CancelaCupom()
		{
			int ret = ACBrECFInterop.ECF_CancelaCupom(this.Handle);
			CheckResult(ret);
		}

		public void CancelaItemVendido(int numItem)
		{
			int ret = ACBrECFInterop.ECF_CancelaItemVendido(this.Handle, numItem);
			CheckResult(ret);
		}

		public void CancelaItemVendidoParcial(int numItem, decimal quantidade)
		{
			int ret = ACBrECFInterop.ECF_CancelaItemVendidoParcial(this.Handle, numItem, (double)quantidade);
			CheckResult(ret);
		}

		public void CancelaDescontoAcrescimoItem(int numItem)
		{
			int ret = ACBrECFInterop.ECF_CancelaDescontoAcrescimoItem(this.Handle, numItem);
		}

		public void CancelaDescontoAcrescimoSubTotal(string tipoAcrescimoDesconto)
		{
			int ret = ACBrECFInterop.ECF_CancelaDescontoAcrescimoSubTotal(this.Handle, tipoAcrescimoDesconto[0]);
			CheckResult(ret);
		}

		#endregion Métodos do Cupom Fiscal

		#region Métodos DAV

		public void DAV_Abrir(DateTime emissao, string decrdocumento, string numero, string situacao, string vendedor, string observacao, string cpfCnpj, string nome, string endereco)
		{
			int ret = ACBrECFInterop.ECF_DAV_Abrir(this.Handle, emissao.ToOADate(), ToUTF8(decrdocumento),
				ToUTF8(numero), ToUTF8(situacao), ToUTF8(vendedor), ToUTF8(observacao),
				ToUTF8(cpfCnpj), ToUTF8(nome), ToUTF8(endereco));
			CheckResult(ret);
		}

		public void DAV_RegistrarItem(string codigo, string descricao, string unidade, double quantidade, double vlrunitario, double desconto, double acrescimo, bool cancelado)
		{
			int ret = ACBrECFInterop.ECF_DAV_RegistrarItem(this.Handle, ToUTF8(codigo), ToUTF8(descricao), ToUTF8(unidade),
			quantidade, vlrunitario, desconto, acrescimo, cancelado);
			CheckResult(ret);
		}

		public void DAV_Fechar(string observacao)
		{
			int ret = ACBrECFInterop.ECF_DAV_Fechar(this.Handle, ToUTF8(observacao));
			CheckResult(ret);
		}

		public void PafMF_RelDAVEmitidos(DAVs[] DAVs, string TituloRelatorio, string IndiceRelatorio)
		{
			ACBrECFInterop.DAVsRec[] record = new ACBrECFInterop.DAVsRec[DAVs.Length];
			for (int i = 0; i < DAVs.Length; i++)
			{
				record[i].Numero = DAVs[i].Numero;
				record[i].COO_Cupom = DAVs[i].COO_Cupom;
				record[i].COO_Dav = DAVs[i].COO_Dav;
				record[i].Titulo = DAVs[i].Titulo;
				record[i].DtEmissao = DAVs[i].DtEmissao.ToOADate();
				record[i].Valor = Convert.ToDouble(DAVs[i].Valor);
			}

			int ret = ACBrECFInterop.ECF_PafMF_RelDAVEmitidos(this.Handle, record, DAVs.Length, ToUTF8(TituloRelatorio), ToUTF8(IndiceRelatorio));
			CheckResult(ret);
		}

		#endregion Métodos DAV

		#region PAF Relatorios

		public void PafMF_RelMeiosPagamento(FormaPagamento[] formasPagamento, string TituloRelatorio, int indiceRelatorio)
		{
			ACBrECFInterop.FormaPagamentoRec[] record = new ACBrECFInterop.FormaPagamentoRec[formasPagamento.Length];
			for (int i = 0; i < formasPagamento.Length; i++)
			{
				record[i].Indice = formasPagamento[i].Indice;
				record[i].Descricao = ToUTF8(formasPagamento[i].Descricao);
				record[i].PermiteVinculado = formasPagamento[i].PermiteVinculado;
				record[i].Total = Convert.ToDouble(formasPagamento[i].Total);
				record[i].Data = formasPagamento[i].Data.ToOADate();
				record[i].TipoDoc = ToUTF8(formasPagamento[i].TipoDoc);
			}

			int ret = ACBrECFInterop.ECF_PafMF_RelMeiosPagamento(this.Handle, record, record.Length, ToUTF8(TituloRelatorio), indiceRelatorio);
			CheckResult(ret);
		}

		public void PafMF_RelIdentificacaoPafECF()
		{
			PafMF_RelIdentificacaoPafECF(this.AAC.IdentPaf, 0);
		}

		public void PafMF_RelIdentificacaoPafECF(int indiceRelatorio)
		{
			PafMF_RelIdentificacaoPafECF(this.AAC.IdentPaf, indiceRelatorio);
		}

		public void PafMF_RelIdentificacaoPafECF(IdenticacaoPaf identificacaoPAF, int indiceRelatorio)
		{
			int ret = ACBrECFInterop.ECF_PafMF_RelIdentificacaoPafECF(this.Handle, identificacaoPAF.Handle, indiceRelatorio);
			CheckResult(ret);
		}

		public void PafMF_RelParametrosConfiguracao()
		{
			PafMF_RelParametrosConfiguracao(this.AAC.IdentPaf.Paf, 0);
		}

		public void PafMF_RelParametrosConfiguracao(int indiceRelatorio)
		{
			PafMF_RelParametrosConfiguracao(this.AAC.IdentPaf.Paf, indiceRelatorio);
		}

		public void PafMF_RelParametrosConfiguracao(InfoPaf infoPAF, int indiceRelatorio)
		{
			int ret = ACBrECFInterop.ECF_PafMF_RelParametrosConfiguracao(this.Handle, infoPAF.Handle, indiceRelatorio);
			CheckResult(ret);
		}

		#endregion PAF Relatorios

		#region PAF

		public void PafMF_GerarCAT52(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo)
		{
			int ret = ACBrECFInterop.ECF_PafMF_GerarCAT52(this.Handle, DataInicial.ToOADate(), DataFinal.ToOADate(), ToUTF8(CaminhoArquivo));
			CheckResult(ret);
		}

		public void PafMF_LX_Impressao()
		{
			int ret = ACBrECFInterop.ECF_PafMF_LX_Impressao(this.Handle);
			CheckResult(ret);
		}

		public void ArquivoMFD_DLL(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo)
		{
			int ret = ACBrECFInterop.ECF_ArquivoMFD_DLL(this.Handle, DataInicial.ToOADate(), DataFinal.ToOADate(), ToUTF8(CaminhoArquivo), null, 0, -1);
			CheckResult(ret);
		}

		public void ArquivoMFD_DLL(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo, FinalizaArqMFD Finaliza, params TipoDocumento[] Documentos)
		{
			int[] Docs = Array.ConvertAll(Documentos, value => (int)value);
			int ret = ACBrECFInterop.ECF_ArquivoMFD_DLL(this.Handle, DataInicial.ToOADate(), DataFinal.ToOADate(), ToUTF8(CaminhoArquivo), Docs, Docs.Length, (int)Finaliza);
			CheckResult(ret);
		}

		public void ArquivoMFD_DLL(int COOInicial, int COOFinal, string CaminhoArquivo)
		{
			int ret = ACBrECFInterop.ECF_ArquivoMFD_DLL_COO(this.Handle, COOInicial, COOFinal, ToUTF8(CaminhoArquivo), null, 0, -1, -1);
			CheckResult(ret);
		}

		public void ArquivoMFD_DLL(int COOInicial, int COOFinal, string CaminhoArquivo, FinalizaArqMFD Finaliza, TipoContador TipoContador, params TipoDocumento[] Documentos)
		{
			int[] Docs = Array.ConvertAll(Documentos, value => (int)value);
			int ret = ACBrECFInterop.ECF_ArquivoMFD_DLL_COO(this.Handle, COOInicial, COOFinal, ToUTF8(CaminhoArquivo), Docs, Docs.Length, (int)Finaliza, (int)TipoContador);
			CheckResult(ret);
		}

		public void DoAtualizarValorGT()
		{
			int ret = ACBrECFInterop.ECF_DoAtualizarValorGT(this.Handle);
			CheckResult(ret);
		}

		public void DoVerificaValorGT()
		{
			int ret = ACBrECFInterop.ECF_DoVerificaValorGT(this.Handle);
			CheckResult(ret);
		}

		#endregion PAF

		#region PAF LMFC

		public void PafMF_LMFC_Cotepe1704(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo)
		{
			int ret = ACBrECFInterop.ECF_PafMF_LMFC_Cotepe1704(this.Handle, DataInicial.ToOADate(), DataFinal.ToOADate(), ToUTF8(CaminhoArquivo));
			CheckResult(ret);
		}

		public void PafMF_LMFC_Cotepe1704(int CRZInicial, int CRZFinal, string CaminhoArquivo)
		{
			int ret = ACBrECFInterop.ECF_PafMF_LMFC_Cotepe1704_CRZ(this.Handle, CRZInicial, CRZFinal, ToUTF8(CaminhoArquivo));
			CheckResult(ret);
		}

		public void PafMF_LMFC_Espelho(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo)
		{
			int ret = ACBrECFInterop.ECF_PafMF_LMFC_Espelho(this.Handle, DataInicial.ToOADate(), DataFinal.ToOADate(), ToUTF8(CaminhoArquivo));
			CheckResult(ret);
		}

		public void PafMF_LMFC_Espelho(int CRZInicial, int CRZFinal, string CaminhoArquivo)
		{
			int ret = ACBrECFInterop.ECF_PafMF_LMFC_Espelho_CRZ(this.Handle, CRZInicial, CRZFinal, ToUTF8(CaminhoArquivo));
			CheckResult(ret);
		}

		public void PafMF_LMFC_Impressao(DateTime DataInicial, DateTime DataFinal)
		{
			int ret = ACBrECFInterop.ECF_PafMF_LMFC_Impressao(this.Handle, DataInicial.ToOADate(), DataFinal.ToOADate());
			CheckResult(ret);
		}

		public void PafMF_LMFC_Impressao(int CRZInicial, int CRZFinal)
		{
			int ret = ACBrECFInterop.ECF_PafMF_LMFC_Impressao_CRZ(this.Handle, CRZInicial, CRZFinal);
			CheckResult(ret);
		}

		#endregion PAF LMFC

		#region PAF LMFS

		public void PafMF_LMFS_Espelho(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo)
		{
			int ret = ACBrECFInterop.ECF_PafMF_LMFS_Espelho(this.Handle, DataInicial.ToOADate(), DataFinal.ToOADate(), ToUTF8(CaminhoArquivo));
			CheckResult(ret);
		}

		public void PafMF_LMFS_Espelho(int CRZInicial, int CRZFinal, string CaminhoArquivo)
		{
			int ret = ACBrECFInterop.ECF_PafMF_LMFS_Espelho_CRZ(this.Handle, CRZInicial, CRZFinal, ToUTF8(CaminhoArquivo));
			CheckResult(ret);
		}

		public void PafMF_LMFS_Impressao(DateTime DataInicial, DateTime DataFinal)
		{
			int ret = ACBrECFInterop.ECF_PafMF_LMFS_Impressao(this.Handle, DataInicial.ToOADate(), DataFinal.ToOADate());
			CheckResult(ret);
		}

		public void PafMF_LMFS_Impressao(int CRZInicial, int CRZFinal)
		{
			int ret = ACBrECFInterop.ECF_PafMF_LMFS_Impressao_CRZ(this.Handle, CRZInicial, CRZFinal);
			CheckResult(ret);
		}

		#endregion PAF LMFS

		#region PAF Espelho MFD

		public void PafMF_MFD_Cotepe1704(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo)
		{
			int ret = ACBrECFInterop.ECF_PafMF_MFD_Cotepe1704(this.Handle, DataInicial.ToOADate(), DataFinal.ToOADate(), ToUTF8(CaminhoArquivo));
			CheckResult(ret);
		}

		public void PafMF_MFD_Cotepe1704(int COOInicial, int COOFinal, string CaminhoArquivo)
		{
			int ret = ACBrECFInterop.ECF_PafMF_MFD_Cotepe1704_COO(this.Handle, COOInicial, COOFinal, ToUTF8(CaminhoArquivo));
			CheckResult(ret);
		}

		#endregion PAF Espelho MFD

		#region PAF Arq. MFD

		public void PafMF_MFD_Espelho(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo)
		{
			int ret = ACBrECFInterop.ECF_PafMF_MFD_Espelho(this.Handle, DataInicial.ToOADate(), DataFinal.ToOADate(), ToUTF8(CaminhoArquivo));
			CheckResult(ret);
		}

		public void PafMF_MFD_Espelho(int COOInicial, int COOFinal, string CaminhoArquivo)
		{
			int ret = ACBrECFInterop.ECF_PafMF_MFD_Espelho_COO(this.Handle, COOInicial, COOFinal, ToUTF8(CaminhoArquivo));
			CheckResult(ret);
		}

		#endregion PAF Arq. MFD

		#region Leitura Memoria Fiscal

		public void LeituraMemoriaFiscal(int reducaoInicial, int reducaoFinal)
		{
			LeituraMemoriaFiscal(reducaoInicial, reducaoFinal, false);
		}

		public void LeituraMemoriaFiscal(int reducaoInicial, int reducaoFinal, bool simplificada)
		{
			int ret = ACBrECFInterop.ECF_LeituraMemoriaFiscalReducao(this.Handle, reducaoInicial, reducaoFinal, simplificada);
			CheckResult(ret);
		}

		public void LeituraMemoriaFiscal(DateTime dataInicial, DateTime dataFinal)
		{
			LeituraMemoriaFiscal(dataInicial, dataFinal, false);
		}

		public void LeituraMemoriaFiscal(DateTime dataInicial, DateTime dataFinal, bool simplificada)
		{
			int ret = ACBrECFInterop.ECF_LeituraMemoriaFiscalData(this.Handle, dataInicial.ToOADate(), dataFinal.ToOADate(), simplificada);
			CheckResult(ret);
		}

		public string LeituraMemoriaFiscalSerial(int reducaoInicial, int reducaoFinal)
		{
			return LeituraMemoriaFiscalSerial(reducaoInicial, reducaoFinal, false);
		}

		public string LeituraMemoriaFiscalSerial(int reducaoInicial, int reducaoFinal, bool simplificada)
		{
			const int LEN = 10 * 1024;
			StringBuilder buffer = new StringBuilder(LEN);

			int ret = ACBrECFInterop.ECF_LeituraMemoriaFiscalSerialReducao(this.Handle, reducaoInicial, reducaoFinal, simplificada, buffer, LEN);
			CheckResult(ret);

			buffer.Length = ret;
			return FromUTF8(buffer);
		}

		public string LeituraMemoriaFiscalSerial(DateTime dataInicial, DateTime dataFinal)
		{
			return LeituraMemoriaFiscalSerial(dataInicial, dataFinal, false);
		}

		public string LeituraMemoriaFiscalSerial(DateTime dataInicial, DateTime dataFinal, bool simplificada)
		{
			const int LEN = 10 * 1024;
			StringBuilder buffer = new StringBuilder(LEN);

			int ret = ACBrECFInterop.ECF_LeituraMemoriaFiscalSerialData(this.Handle, dataInicial.ToOADate(), dataFinal.ToOADate(), simplificada, buffer, LEN);
			CheckResult(ret);

			buffer.Length = ret;
			return FromUTF8(buffer);
		}

		public void LeituraMemoriaFiscalSerial(int reducaoInicial, int reducaoFinal, string nomeArquivo)
		{
			LeituraMemoriaFiscalSerial(reducaoInicial, reducaoFinal, ToUTF8(nomeArquivo), false);
		}

		public void LeituraMemoriaFiscalSerial(int reducaoInicial, int reducaoFinal, string nomeArquivo, bool simplificada)
		{
			int ret = ACBrECFInterop.ECF_LeituraMemoriaFiscalArquivoReducao(this.Handle, reducaoInicial, reducaoFinal, ToUTF8(nomeArquivo), simplificada);
			CheckResult(ret);
		}

		public void LeituraMemoriaFiscalSerial(DateTime dataInicial, DateTime dataFinal, string nomeArquivo)
		{
			LeituraMemoriaFiscalSerial(dataInicial, dataFinal, ToUTF8(nomeArquivo), false);
		}

		public void LeituraMemoriaFiscalSerial(DateTime dataInicial, DateTime dataFinal, string nomeArquivo, bool simplificada)
		{
			int ret = ACBrECFInterop.ECF_LeituraMemoriaFiscalArquivoData(this.Handle, dataInicial.ToOADate(), dataFinal.ToOADate(), ToUTF8(nomeArquivo), simplificada);
			CheckResult(ret);
		}

		#endregion Leitura Memoria Fiscal

		#region Cupom Vinculado

		public void AbreCupomVinculado(int coo, string codFormaPagto, decimal valor)
		{
			var cooStr = string.Format("{0:000000}", coo);
			AbreCupomVinculado(cooStr, codFormaPagto, valor);
		}

		public void AbreCupomVinculado(string coo, string codFormaPagto, decimal valor)
		{
			int ret = ACBrECFInterop.ECF_AbreCupomVinculado(this.Handle, ToUTF8(coo), ToUTF8(codFormaPagto), (double)valor);
			CheckResult(ret);
		}

		public void AbreCupomVinculado(string coo, string codFormaPagto, string codComprovanteNaoFiscal, decimal valor)
		{
			int ret = ACBrECFInterop.ECF_AbreCupomVinculadoCNF(this.Handle, ToUTF8(coo), ToUTF8(codFormaPagto), ToUTF8(codComprovanteNaoFiscal), (double)valor);
			CheckResult(ret);
		}

		public void LinhaCupomVinculado(string[] linhas)
		{
			foreach (string linha in linhas)
				LinhaCupomVinculado(linha);
		}

		public void LinhaCupomVinculado(string linha)
		{
			int ret = ACBrECFInterop.ECF_LinhaCupomVinculado(this.Handle, ToUTF8(linha));
			CheckResult(ret);
		}

		#endregion Cupom Vinculado

		#region Leitura X / Redução Z

		public void LeituraX()
		{
			int ret = ACBrECFInterop.ECF_LeituraX(this.Handle);
			CheckResult(ret);
		}

		public void ReducaoZ()
		{
			ReducaoZ(0);
		}

		public void ReducaoZ(DateTime data)
		{
			ReducaoZ(data.ToOADate());
		}

		private void ReducaoZ(double data)
		{
			int ret = ACBrECFInterop.ECF_ReducaoZ(this.Handle, data);
			CheckResult(ret);
		}

		public string DadosUltimaReducaoZ()
		{
			const int BUFFER_LEN = 16384;
			string retorno = GetString(ACBrECFInterop.ECF_GetDadosUltimaReducaoZ, BUFFER_LEN);

			DadosReducaoZClass = new DadosReducaoZClass(this);

			return retorno;
		}

		public string DadosReducaoZ()
		{
			const int BUFFER_LEN = 16384;
			string retorno = GetString(ACBrECFInterop.ECF_GetDadosReducaoZ, BUFFER_LEN);

			DadosReducaoZClass = new DadosReducaoZClass(this);

			return retorno;
		}

		#endregion Leitura X / Redução Z

		#region Relatório Gerencial

		public void AbreRelatorioGerencial(int indice)
		{
			int ret = ACBrECFInterop.ECF_AbreRelatorioGerencial(this.Handle, indice);
			CheckResult(ret);
		}

		public void LinhaRelatorioGerencial(string[] linhas)
		{
			foreach (string linha in linhas)
			{
				LinhaRelatorioGerencial(linha, 0);
			}
		}

		public void LinhaRelatorioGerencial(string linha)
		{
			LinhaRelatorioGerencial(linha, 0);
		}

		public void LinhaRelatorioGerencial(string linha, int indiceBMP)
		{
			int ret = ACBrECFInterop.ECF_LinhaRelatorioGerencial(this.Handle, ToUTF8(linha), indiceBMP);
			CheckResult(ret);
		}

		public void ProgramaRelatoriosGerenciais(string descricao)
		{
			ProgramaRelatoriosGerenciais(descricao, String.Empty);
		}

		public void ProgramaRelatoriosGerenciais(string descricao, string posicao)
		{
			int ret = ACBrECFInterop.ECF_ProgramaRelatoriosGerenciais(this.Handle, ToUTF8(descricao), posicao);
			CheckResult(ret);
		}

		public void CarregaRelatoriosGerenciais()
		{
			int count = ACBrECFInterop.ECF_CarregaRelatoriosGerenciais(this.Handle);
			CheckResult(count);

			CarregaRelatoriosGerenciais(count);
		}

		public void LerTotaisRelatoriosGerenciais()
		{
			int count = ACBrECFInterop.ECF_LerTotaisRelatoriosGerenciais(this.Handle);
			CheckResult(count);

			CarregaRelatoriosGerenciais(count);
		}

		private void CarregaRelatoriosGerenciais(int count)
		{
			relatoriosGerenciais = new RelatorioGerencial[count];

			for (int i = 0; i < count; i++)
			{
				var record = new ACBrECFInterop.RelatorioGerencialRec();
				int ret = ACBrECFInterop.ECF_GetRelatoriosGerenciais(this.Handle, ref record, i);
				CheckResult(ret);

				RelatorioGerencial relatorio = new RelatorioGerencial()
				{
					Indice = FromUTF8(record.Indice),
					Descricao = FromUTF8(record.Descricao),
					Contador = record.Contador
				};

				relatoriosGerenciais[i] = relatorio;
			}
		}

		public void RelatorioGerencial(List<string> relatorio, int vias, int indice)
		{
			RelatorioGerencial(relatorio.ToArray(), vias, indice);
		}

		public void RelatorioGerencial(IEnumerable<string> relatorio, int vias, int indice)
		{
			RelatorioGerencial(relatorio.ToArray(), vias, indice);
		}

		public void RelatorioGerencial(string[] relatorio, int vias, int indice)
		{
			int ret = ACBrECFInterop.ECF_RelatorioGerencial(this.Handle, relatorio, relatorio.Length, vias, indice);
			CheckResult(ret);
		}

		public void FechaRelatorio()
		{
			int ret = ACBrECFInterop.ECF_FechaRelatorio(this.Handle);
			CheckResult(ret);
		}

		#endregion Relatório Gerencial

		#region Alíquotas

		public void CarregaAliquotas()
		{
			int count = ACBrECFInterop.ECF_CarregaAliquotas(this.Handle);
			CheckResult(count);

			CarregaAliquotas(count);
		}

		private void CarregaAliquotas(int count)
		{
			aliquotas = new Aliquota[count];

			for (int i = 0; i < count; i++)
			{
				var record = new ACBrECFInterop.AliquotaRec();
				int ret = ACBrECFInterop.ECF_GetAliquota(this.Handle, ref record, i);
				CheckResult(ret);

				Aliquota aliquota = new Aliquota();
				aliquota.Indice = FromUTF8(record.Indice);
				aliquota.ValorAliquota = Convert.ToDecimal(record.Aliquota);
				aliquota.Sequencia = record.Sequencia;
				aliquota.Tipo = record.Tipo.ToString();
				aliquota.Total = Convert.ToDecimal(record.Total);

				aliquotas[i] = aliquota;
			}
		}

		public void LerTotaisAliquota()
		{
			int count = ACBrECFInterop.ECF_LerTotaisAliquota(this.Handle);
			CheckResult(count);

			CarregaAliquotas(count);
		}

		public void ProgramaAliquota(decimal aliquota, string tipo)
		{
			ProgramaAliquota(aliquota, tipo, string.Empty);
		}

		public void ProgramaAliquota(decimal aliquota, string tipo, string posicao)
		{
			if (string.IsNullOrEmpty(tipo)) throw new ArgumentException();

			int ret = ACBrECFInterop.ECF_ProgramaAliquota(this.Handle, (double)aliquota, tipo[0], posicao);
			CheckResult(ret);
		}

		#endregion Alíquotas

		#region Formas de Pagto

		public FormaPagamento AchaFPGDescricao(string descricao)
		{
			return AchaFPGDescricao(descricao, true, true);
		}

		public FormaPagamento AchaFPGDescricao(string descricao, bool buscaExata)
		{
			return AchaFPGDescricao(descricao, buscaExata, true);
		}

		public FormaPagamento AchaFPGDescricao(string descricao, bool buscaExata, bool ignoreCase)
		{
			ACBrECFInterop.FormaPagamentoRec FormaRec = new ACBrECFInterop.FormaPagamentoRec();
			int ret = ACBrECFInterop.ECF_AchaFPGDescricao(this.Handle, ToUTF8(descricao), buscaExata, ignoreCase, ref FormaRec);
			CheckResult(ret);

			if (ret == 0)
				return null;
			else
			{
				FormaPagamento Forma = new FormaPagamento();
				Forma.Data = DateTime.FromOADate(FormaRec.Data);
				Forma.Descricao = FromUTF8(FormaRec.Descricao);
				Forma.Indice = FromUTF8(FormaRec.Indice);
				Forma.PermiteVinculado = FormaRec.PermiteVinculado;
				Forma.TipoDoc = FromUTF8(FormaRec.TipoDoc);
				Forma.Total = Convert.ToDecimal(FormaRec.Total);

				return Forma;
			}
		}

		public FormaPagamento AchaFPGIndice(string indice)
		{
			ACBrECFInterop.FormaPagamentoRec FormaRec = new ACBrECFInterop.FormaPagamentoRec();
			int ret = ACBrECFInterop.ECF_AchaFPGIndice(this.Handle, ToUTF8(indice), ref FormaRec);
			CheckResult(ret);

			if (ret == 0)
				return null;
			else
			{
				FormaPagamento Forma = new FormaPagamento();
				Forma.Data = DateTime.FromOADate(FormaRec.Data);
				Forma.Descricao = FromUTF8(FormaRec.Descricao);
				Forma.Indice = FromUTF8(FormaRec.Indice);
				Forma.PermiteVinculado = FormaRec.PermiteVinculado;
				Forma.TipoDoc = FromUTF8(FormaRec.TipoDoc);
				Forma.Total = Convert.ToDecimal(FormaRec.Total);

				return Forma;
			}
		}

		public void CarregaFormasPagamento()
		{
			int count = ACBrECFInterop.ECF_CarregaFormasPagamento(this.Handle);
			CheckResult(count);

			CarregaFormasPagamento(count);
		}

		private void CarregaFormasPagamento(int count)
		{
			formasPagamento = new FormaPagamento[count];
			for (int i = 0; i < count; i++)
			{
				var record = new ACBrECFInterop.FormaPagamentoRec();
				int ret = ACBrECFInterop.ECF_GetFormaPagamento(this.Handle, ref record, i);
				CheckResult(ret);

				FormaPagamento formaPagamento = new FormaPagamento();
				formaPagamento.Indice = FromUTF8(record.Indice);
				formaPagamento.Descricao = FromUTF8(record.Descricao);
				formaPagamento.PermiteVinculado = record.PermiteVinculado;
				formaPagamento.Total = Convert.ToDecimal(record.Total);
				formaPagamento.Data = DateTime.FromOADate(record.Data);
				formaPagamento.TipoDoc = FromUTF8(record.TipoDoc);

				formasPagamento[i] = formaPagamento;
			}
		}

		public void LerTotaisFormaPagamento()
		{
			int count = ACBrECFInterop.ECF_LerTotaisFormaPagamento(this.Handle);
			CheckResult(count);

			CarregaFormasPagamento(count);
		}

		public void ProgramaFormaPagamento(string descricao, bool permiteVinculado)
		{
			ProgramaFormaPagamento(descricao, permiteVinculado, string.Empty);
		}

		public void ProgramaFormaPagamento(string descricao, bool permiteVinculado, string posicao)
		{
			int ret = ACBrECFInterop.ECF_ProgramaFormaPagamento(this.Handle, ToUTF8(descricao), permiteVinculado, ToUTF8(posicao));
			CheckResult(ret);
		}

		#endregion Formas de Pagto

		#region Comprovantes Não Fiscal

		public ComprovanteNaoFiscal AchaCNFDescricao(string descricao)
		{
			return AchaCNFDescricao(descricao, true, true);
		}

		public ComprovanteNaoFiscal AchaCNFDescricao(string descricao, bool buscaExata)
		{
			return AchaCNFDescricao(descricao, buscaExata, true);
		}

		public ComprovanteNaoFiscal AchaCNFDescricao(string descricao, bool buscaExata, bool ignoreCase)
		{
			ACBrECFInterop.ComprovanteNaoFiscalRec record = new ACBrECFInterop.ComprovanteNaoFiscalRec();
			int ret = ACBrECFInterop.ECF_AchaCNFDescricao(this.Handle, ref record, ToUTF8(descricao), buscaExata, ignoreCase);
			CheckResult(ret);

			if (ret == 0)
				return null;
			else
			{
				ComprovanteNaoFiscal comprovanteNaoFiscal = new ComprovanteNaoFiscal();
				comprovanteNaoFiscal.Indice = FromUTF8(record.Indice);
				comprovanteNaoFiscal.Descricao = FromUTF8(record.Descricao);
				comprovanteNaoFiscal.PermiteVinculado = record.PermiteVinculado;
				comprovanteNaoFiscal.FormaPagamento = FromUTF8(record.FormaPagamento);
				comprovanteNaoFiscal.Total = FromUTF8(record.Total);
				comprovanteNaoFiscal.Contador = record.Contador;

				return comprovanteNaoFiscal;
			}
		}

		public void CarregaComprovantesNaoFiscais()
		{
			int count = ACBrECFInterop.ECF_CarregaComprovantesNaoFiscais(this.Handle);
			CheckResult(count);

			CarregaComprovantesNaoFiscais(count);
		}

		private void CarregaComprovantesNaoFiscais(int count)
		{
			comprovantesNaoFiscais = new ComprovanteNaoFiscal[count];
			for (int i = 0; i < count; i++)
			{
				var record = new ACBrECFInterop.ComprovanteNaoFiscalRec();
				int ret = ACBrECFInterop.ECF_GetComprovanteNaoFiscal(this.Handle, ref record, i);
				CheckResult(ret);

				ComprovanteNaoFiscal comprovanteNaoFiscal = new ComprovanteNaoFiscal();
				comprovanteNaoFiscal.Indice = FromUTF8(record.Indice);
				comprovanteNaoFiscal.Descricao = FromUTF8(record.Descricao);
				comprovanteNaoFiscal.PermiteVinculado = record.PermiteVinculado;
				comprovanteNaoFiscal.FormaPagamento = FromUTF8(record.FormaPagamento);
				comprovanteNaoFiscal.Total = FromUTF8(record.Total);
				comprovanteNaoFiscal.Contador = record.Contador;

				comprovantesNaoFiscais[i] = comprovanteNaoFiscal;
			}
		}

		public void LerTotaisComprovanteNaoFiscal()
		{
			int count = ACBrECFInterop.ECF_LerTotaisComprovanteNaoFiscal(this.Handle);
			CheckResult(count);

			CarregaComprovantesNaoFiscais(count);
		}

		public void ProgramaComprovanteNaoFiscal(string descricao, string tipo)
		{
			ProgramaComprovanteNaoFiscal(descricao, tipo, string.Empty);
		}

		public void ProgramaComprovanteNaoFiscal(string descricao, string tipo, string posicao)
		{
			if (string.IsNullOrEmpty(tipo)) throw new ArgumentException();

			int ret = ACBrECFInterop.ECF_ProgramaComprovanteNaoFiscal(this.Handle, ToUTF8(descricao), ToUTF8(tipo), ToUTF8(posicao));
			CheckResult(ret);
		}

		public void AbreNaoFiscal(string cpfCnpj)
		{
			int ret = ACBrECFInterop.ECF_AbreNaoFiscal(this.Handle, ToUTF8(cpfCnpj));
			CheckResult(ret);
		}

		public void RegistraItemNaoFiscal(string codCNF, decimal value, string obs)
		{
			int ret = ACBrECFInterop.ECF_RegistraItemNaoFiscal(this.Handle, ToUTF8(codCNF), Convert.ToDouble(value), ToUTF8(obs));
			CheckResult(ret);
		}

		public void SubtotalizaNaoFiscal(decimal descontoAcrescimo, string mensagemRodape)
		{
			int ret = ACBrECFInterop.ECF_SubtotalizaNaoFiscal(this.Handle, Convert.ToDouble(descontoAcrescimo), ToUTF8(mensagemRodape));
			CheckResult(ret);
		}

		public void EfetuaPagamentoNaoFiscal(string codFormaPagto, decimal valor)
		{
			EfetuaPagamentoNaoFiscal(codFormaPagto, valor, string.Empty, false);
		}

		public void EfetuaPagamentoNaoFiscal(string codFormaPagto, decimal valor, string observacao)
		{
			EfetuaPagamentoNaoFiscal(codFormaPagto, valor, observacao, false);
		}

		public void EfetuaPagamentoNaoFiscal(string codFormaPagto, decimal valor, string observacao, bool imprimeVinculado)
		{
			int ret = ACBrECFInterop.ECF_EfetuaPagamentoNaoFiscal(this.Handle, codFormaPagto, Convert.ToDouble(valor), observacao, imprimeVinculado);
			CheckResult(ret);
		}

		public void FechaNaoFiscal(string observacao)
		{
			int ret = ACBrECFInterop.ECF_FechaNaoFiscal(this.Handle, ToUTF8(observacao));
			CheckResult(ret);
		}

		public void CancelaNaoFiscal()
		{
			int ret = ACBrECFInterop.ECF_CancelaNaoFiscal(this.Handle);
			CheckResult(ret);
		}

		#endregion Comprovantes Não Fiscal

		#region Suprimento e Sangria

		public void Suprimento(decimal valor, string obs)
		{
			int ret = ACBrECFInterop.ECF_Suprimento(this.Handle, (double)valor, ToUTF8(obs));
			CheckResult(ret);
		}

		public void Sangria(decimal valor, string obs)
		{
			int ret = ACBrECFInterop.ECF_Sangria(this.Handle, (double)valor, ToUTF8(obs));
			CheckResult(ret);
		}

		#endregion Suprimento e Sangria

		#region Gaveta

		public void AbreGaveta()
		{
			int ret = ACBrECFInterop.ECF_AbreGaveta(this.Handle);
			CheckResult(ret);
		}

		#endregion Gaveta

		#region Programação

		public void IdentificaPAF(string nomeVersao, string md5)
		{
			int ret = ACBrECFInterop.ECF_IdentificaPAF(this.Handle, ToUTF8(nomeVersao), ToUTF8(md5));
			CheckResult(ret);
		}

		#endregion Programação

		#region Override Methods

		protected internal override void OnInitializeComponent()
		{
			CallCreate(ACBrECFInterop.ECF_Create);
			Device = new ACBrDevice(this);
			this.InfoRodapeCupom = new Rodape(this);
			this.ConfigBarras = new ConfigBarras(this);
			this.Consumidor = new Consumidor(this);
			this.DadosReducaoZClass = new DadosReducaoZClass(this);
		}

		protected internal override void CheckResult(int ret)
		{
			switch (ret)
			{
				case -1:

					string error = GetString(ACBrECFInterop.ECF_GetUltimoErro);
					throw new ACBrException(error);

				case -2:

					throw new ACBrException("ACBr ECF não inicializado.");
			}
		}

		protected override void OnDisposing()
		{
			if (this.Handle != IntPtr.Zero)
			{
				if (rfd != null)
				{
					if (this.Ativo)
					{
						rfd.Desativar();
						Desativar();
					}

					var orfd = rfd;
					rfd = null;
					if (orfd.ECF != null)
						orfd.ECF = null;
				}
				CallDestroy(ACBrECFInterop.ECF_Destroy);
			}
		}

		#endregion Override Methods

		#region Callback EventHandlers

		[AllowReversePInvokeCalls]
		private void OnMsgPoucoPapelCallback()
		{
			if (onMsgPoucoPapel.IsAssigned)
			{
				onMsgPoucoPapel.Raise();
			}
		}

		[AllowReversePInvokeCalls]
		private void OnAguardandoRespostaChangeCallback()
		{
			if (onAguardandoRespostaChange.IsAssigned)
			{
				onAguardandoRespostaChange.Raise();
			}
		}

		[AllowReversePInvokeCalls]
		private void OnAntesAbreCupomCallback(string CPF_CNPJ, string Nome, string Endereco)
		{
			if (onAntesAbreCupom.IsAssigned)
			{
				AbreCupomArgs e = new AbreCupomArgs(FromUTF8(CPF_CNPJ), FromUTF8(Nome), FromUTF8(Endereco));
				onAntesAbreCupom.Raise(e);
			}
		}

		[AllowReversePInvokeCalls]
		private void OnAntesAbreCupomVinculadoCallback()
		{
			if (onAntesAbreCupomVinculado.IsAssigned)
			{
				onAntesAbreCupomVinculado.Raise();
			}
		}

		[AllowReversePInvokeCalls]
		private void OnAntesAbreNaoFiscalCallback(string CPF_CNPJ, string Nome, string Endereco)
		{
			if (onAntesAbreNaoFiscal.IsAssigned)
			{
				AbreCupomArgs e = new AbreCupomArgs(FromUTF8(CPF_CNPJ), FromUTF8(Nome), FromUTF8(Endereco));
				onAntesAbreNaoFiscal.Raise(e);
			}
		}

		[AllowReversePInvokeCalls]
		private void OnAntesAbreRelatorioGerencialCallback(int Indice)
		{
			if (onAntesAbreRelatorioGerencial.IsAssigned)
			{
				AbreRelatorioGerencialArgs e = new AbreRelatorioGerencialArgs(Indice);
				onAntesAbreRelatorioGerencial.Raise(e);
			}
		}

		[AllowReversePInvokeCalls]
		private void OnAntesCancelaCupomCallback()
		{
			if (onAntesCancelaCupom.IsAssigned)
			{
				onAntesCancelaCupom.Raise();
			}
		}

		[AllowReversePInvokeCalls]
		private void OnAntesCancelaItemNaoFiscalCallback(int NumItem)
		{
			if (onAntesCancelaItemNaoFiscal.IsAssigned)
			{
				CancelaItemArgs e = new CancelaItemArgs(NumItem);
				onAntesCancelaItemNaoFiscal.Raise(e);
			}
		}

		[AllowReversePInvokeCalls]
		private void OnAntesCancelaItemVendidoCallback(int NumItem)
		{
			if (onAntesCancelaItemVendido.IsAssigned)
			{
				CancelaItemArgs e = new CancelaItemArgs(NumItem);
				onAntesCancelaItemVendido.Raise(e);
			}
		}

		[AllowReversePInvokeCalls]
		private void OnAntesCancelaNaoFiscalCallback()
		{
			if (onAntesCancelaNaoFiscal.IsAssigned)
			{
				onAntesCancelaNaoFiscal.Raise();
			}
		}

		[AllowReversePInvokeCalls]
		private void OnAntesEfetuaPagamentoCallback(string CodFormaPagto, double Valor, string Observacao, bool ImprimeVinculado)
		{
			if (onAntesEfetuaPagamento.IsAssigned)
			{
				EfetuaPagamentoArgs e = new EfetuaPagamentoArgs(FromUTF8(CodFormaPagto), Valor, FromUTF8(Observacao), ImprimeVinculado);
				onAntesEfetuaPagamento.Raise(e);
			}
		}

		[AllowReversePInvokeCalls]
		private void OnAntesEfetuaPagamentoNaoFiscalCallback(string CodFormaPagto, double Valor, string Observacao, bool ImprimeVinculado)
		{
			if (onAntesEfetuaPagamentoNaoFiscal.IsAssigned)
			{
				EfetuaPagamentoArgs e = new EfetuaPagamentoArgs(FromUTF8(CodFormaPagto), Valor, FromUTF8(Observacao), ImprimeVinculado);
				onAntesEfetuaPagamentoNaoFiscal.Raise(e);
			}
		}

		[AllowReversePInvokeCalls]
		private void OnAntesFechaCupomCallback(string Observacao, int IndiceBMP)
		{
			if (onAntesFechaCupom.IsAssigned)
			{
				FechaCupomArgs e = new FechaCupomArgs(FromUTF8(Observacao), IndiceBMP);
				onAntesFechaCupom.Raise(e);
			}
		}

		[AllowReversePInvokeCalls]
		private void OnAntesFechaNaoFiscalCallback(string Observacao, int IndiceBMP)
		{
			if (onAntesFechaNaoFiscal.IsAssigned)
			{
				FechaCupomArgs e = new FechaCupomArgs(FromUTF8(Observacao), IndiceBMP);
				onAntesFechaNaoFiscal.Raise(e);
			}
		}

		[AllowReversePInvokeCalls]
		private void OnAntesFechaRelatorioCallback()
		{
			if (onAntesFechaRelatorio.IsAssigned)
			{
				onAntesFechaRelatorio.Raise();
			}
		}

		[AllowReversePInvokeCalls]
		private void OnAntesLeituraXCallback()
		{
			if (onAntesLeituraX.IsAssigned)
			{
				onAntesLeituraX.Raise();
			}
		}

		[AllowReversePInvokeCalls]
		private void OnAntesReducaoZCallback()
		{
			if (onAntesReducaoZ.IsAssigned)
			{
				onAntesReducaoZ.Raise();
			}
		}

		[AllowReversePInvokeCalls]
		private void OnAntesSangriaCallback(double Valor, string Obs, string DescricaoCNF, string DescricaoFPG)
		{
			if (onAntesSangria.IsAssigned)
			{
				SangriaSuprimentoArgs e = new SangriaSuprimentoArgs(FromUTF8(Valor), FromUTF8(Obs), FromUTF8(DescricaoCNF), FromUTF8(DescricaoFPG));
				onAntesSangria.Raise(e);
			}
		}

		[AllowReversePInvokeCalls]
		private void OnAntesSubtotalizaCupomCallback(double DescontoAcrescimo, string MensagemRodape)
		{
			if (onAntesSubtotalizaCupom.IsAssigned)
			{
				SubtotalizaCupomArgs e = new SubtotalizaCupomArgs(FromUTF8(DescontoAcrescimo), FromUTF8(MensagemRodape));
				onAntesSubtotalizaCupom.Raise(e);
			}
		}

		[AllowReversePInvokeCalls]
		private void OnAntesSubtotalizaNaoFiscalCallback(double DescontoAcrescimo, string MensagemRodape)
		{
			if (onAntesSubtotalizaNaoFiscal.IsAssigned)
			{
				SubtotalizaCupomArgs e = new SubtotalizaCupomArgs(FromUTF8(DescontoAcrescimo), FromUTF8(MensagemRodape));
				onAntesSubtotalizaNaoFiscal.Raise(e);
			}
		}

		[AllowReversePInvokeCalls]
		private void OnAntesSuprimentoCallback(double Valor, string Obs, string DescricaoCNF, string DescricaoFPG)
		{
			if (onAntesSuprimento.IsAssigned)
			{
				SangriaSuprimentoArgs e = new SangriaSuprimentoArgs(FromUTF8(Valor), FromUTF8(Obs), FromUTF8(DescricaoCNF), FromUTF8(DescricaoFPG));
				onAntesSuprimento.Raise(e);
			}
		}
		
		[AllowReversePInvokeCalls]
		private void OnAntesVendeItemCallback(string Codigo, string Descricao, string AliquotaICMS, 
			double Qtd, double ValorUnitario, double ValorDescontoAcrescimo, string Unidade, 
			string TipoDescontoAcrescimo, string DescontoAcrescimo)
		{
			if (onAntesVendeItem.IsAssigned)
			{
				VendeItemArgs e = new VendeItemArgs(FromUTF8(Codigo), FromUTF8(Descricao), FromUTF8(AliquotaICMS),
					FromUTF8(Qtd), FromUTF8(ValorUnitario), FromUTF8(ValorDescontoAcrescimo), FromUTF8(Unidade), 
					FromUTF8(TipoDescontoAcrescimo), FromUTF8(DescontoAcrescimo));
				onAntesVendeItem.Raise(e);
			}
		}
		
		[AllowReversePInvokeCalls]
		private void OnBobinaAdicionaLinhasCallback(string Linhas, string Operacao)
		{
			if (onBobinaAdicionaLinhas.IsAssigned)
			{
				BobinaEventArgs e = new BobinaEventArgs();
				e.Linhas = FromUTF8(Linhas);
				e.Operacao = FromUTF8(Operacao);
				onBobinaAdicionaLinhas.Raise(e);
			}
		}

		[AllowReversePInvokeCalls]
		private void OnChangeEstadoCallback(int EstadoAnterior, int EstadoAtual)
		{
			if (onChangeEstado.IsAssigned)
			{
				ChangeEstadoArgs e = new ChangeEstadoArgs((EstadoECF)EstadoAnterior, (EstadoECF)EstadoAtual);
				onChangeEstado.Raise(e);
			}
		}

		[AllowReversePInvokeCalls]
		private bool OnChequeEstadoCallback(int EstadoAtual)
		{
			ChequeEstadoArgs e = new ChequeEstadoArgs((CHQEstado)EstadoAtual);

			if (onChequeEstado.IsAssigned)
				onChequeEstado.Raise(e);

			return e.Continuar;
		}

		[AllowReversePInvokeCalls]
		private void OnDepoisAbreCupomCallback(string CPF_CNPJ, string Nome, string Endereco)
		{
			if (onDepoisAbreCupom.IsAssigned)
			{
				AbreCupomArgs e = new AbreCupomArgs(FromUTF8(CPF_CNPJ), FromUTF8(Nome), FromUTF8(Endereco));
				onDepoisAbreCupom.Raise(e);
			}
		}

		[AllowReversePInvokeCalls]
		private void OnDepoisAbreCupomVinculadoCallback()
		{
			if (onDepoisAbreCupomVinculado.IsAssigned)
			{
				onDepoisAbreCupomVinculado.Raise();
			}
		}

		[AllowReversePInvokeCalls]
		private void OnDepoisAbreNaoFiscalCallback(string CPF_CNPJ, string Nome, string Endereco)
		{
			if (onDepoisAbreNaoFiscal.IsAssigned)
			{
				AbreCupomArgs e = new AbreCupomArgs(FromUTF8(CPF_CNPJ), FromUTF8(Nome), FromUTF8(Endereco));
				onDepoisAbreNaoFiscal.Raise(e);
			}
		}

		[AllowReversePInvokeCalls]
		private void OnDepoisAbreRelatorioGerencialCallback(int Indice)
		{
			if (onDepoisAbreRelatorioGerencial.IsAssigned)
			{
				AbreRelatorioGerencialArgs e = new AbreRelatorioGerencialArgs(Indice);
				onDepoisAbreRelatorioGerencial.Raise(e);
			}
		}

		[AllowReversePInvokeCalls]
		private void OnDepoisCancelaCupomCallback()
		{
			if (onDepoisCancelaCupom.IsAssigned)
			{
				onDepoisCancelaCupom.Raise();
			}
		}

		[AllowReversePInvokeCalls]
		private void OnDepoisCancelaItemNaoFiscalCallback(int NumItem)
		{
			if (onDepoisCancelaItemNaoFiscal.IsAssigned)
			{
				CancelaItemArgs e = new CancelaItemArgs(NumItem);
				onDepoisCancelaItemNaoFiscal.Raise(e);
			}
		}

		[AllowReversePInvokeCalls]
		private void OnDepoisCancelaItemVendidoCallback(int NumItem)
		{
			if (onDepoisCancelaItemVendido.IsAssigned)
			{
				CancelaItemArgs e = new CancelaItemArgs(NumItem);
				onDepoisCancelaItemVendido.Raise(e);
			}
		}

		[AllowReversePInvokeCalls]
		private void OnDepoisCancelaNaoFiscalCallback()
		{
			if (onDepoisCancelaNaoFiscal.IsAssigned)
			{
				onDepoisCancelaNaoFiscal.Raise();
			}
		}

		[AllowReversePInvokeCalls]
		private void OnDepoisEfetuaPagamentoCallback(string CodFormaPagto, double Valor, string Observacao, bool ImprimeVinculado)
		{
			if (onDepoisEfetuaPagamento.IsAssigned)
			{
				EfetuaPagamentoArgs e = new EfetuaPagamentoArgs(FromUTF8(CodFormaPagto), Valor, FromUTF8(Observacao), ImprimeVinculado);
				onDepoisEfetuaPagamento.Raise(e);
			}
		}

		[AllowReversePInvokeCalls]
		private void OnDepoisEfetuaPagamentoNaoFiscalCallback(string CodFormaPagto, double Valor, string Observacao, bool ImprimeVinculado)
		{
			if (onDepoisEfetuaPagamentoNaoFiscal.IsAssigned)
			{
				EfetuaPagamentoArgs e = new EfetuaPagamentoArgs(FromUTF8(CodFormaPagto), Valor, FromUTF8(Observacao), ImprimeVinculado);
				onDepoisEfetuaPagamentoNaoFiscal.Raise(e);
			}
		}

		[AllowReversePInvokeCalls]
		private void OnDepoisFechaCupomCallback(string Observacao, int IndiceBMP)
		{
			if (onDepoisFechaCupom.IsAssigned)
			{
				FechaCupomArgs e = new FechaCupomArgs(FromUTF8(Observacao), IndiceBMP);
				onDepoisFechaCupom.Raise(e);
			}
		}

		[AllowReversePInvokeCalls]
		private void OnDepoisFechaNaoFiscalCallback(string Observacao, int IndiceBMP)
		{
			if (onDepoisFechaNaoFiscal.IsAssigned)
			{
				FechaCupomArgs e = new FechaCupomArgs(FromUTF8(Observacao), IndiceBMP);
				onDepoisFechaNaoFiscal.Raise(e);
			}
		}

		[AllowReversePInvokeCalls]
		private void OnDepoisFechaRelatorioCallback()
		{
			if (onDepoisFechaRelatorio.IsAssigned)
			{
				onDepoisFechaRelatorio.Raise();
			}
		}

		[AllowReversePInvokeCalls]
		private void OnDepoisLeituraXCallback()
		{
			if (onDepoisLeituraX.IsAssigned)
			{
				onDepoisLeituraX.Raise();
			}
		}

		[AllowReversePInvokeCalls]
		private void OnDepoisReducaoZCallback()
		{
			if (onDepoisReducaoZ.IsAssigned)
			{
				onDepoisReducaoZ.Raise();
			}
		}

		[AllowReversePInvokeCalls]
		private void OnDepoisSangriaCallback(double Valor, string Obs, string DescricaoCNF, string DescricaoFPG)
		{
			if (onDepoisSangria.IsAssigned)
			{
				SangriaSuprimentoArgs e = new SangriaSuprimentoArgs(FromUTF8(Valor), FromUTF8(Obs), FromUTF8(DescricaoCNF), FromUTF8(DescricaoFPG));
				onDepoisSangria.Raise(e);
			}
		}

		[AllowReversePInvokeCalls]
		private void OnDepoisSubtotalizaCupomCallback(double DescontoAcrescimo, string MensagemRodape)
		{
			if (onDepoisSubtotalizaCupom.IsAssigned)
			{
				SubtotalizaCupomArgs e = new SubtotalizaCupomArgs(FromUTF8(DescontoAcrescimo), FromUTF8(MensagemRodape));
				onDepoisSubtotalizaCupom.Raise(e);
			}
		}

		[AllowReversePInvokeCalls]
		private void OnDepoisSubtotalizaNaoFiscalCallback(double DescontoAcrescimo, string MensagemRodape)
		{
			if (onDepoisSubtotalizaNaoFiscal.IsAssigned)
			{
				SubtotalizaCupomArgs e = new SubtotalizaCupomArgs(FromUTF8(DescontoAcrescimo), FromUTF8(MensagemRodape));
				onDepoisSubtotalizaNaoFiscal.Raise(e);
			}
		}

		[AllowReversePInvokeCalls]
		private void OnDepoisSuprimentoCallback(double Valor, string Obs, string DescricaoCNF, string DescricaoFPG)
		{
			if (onDepoisSuprimento.IsAssigned)
			{
				SangriaSuprimentoArgs e = new SangriaSuprimentoArgs(FromUTF8(Valor), FromUTF8(Obs), FromUTF8(DescricaoCNF), FromUTF8(DescricaoFPG));
				onDepoisSuprimento.Raise(e);
			}
		}

		[AllowReversePInvokeCalls]
		private void OnDepoisVendeItemCallback(string Codigo, string Descricao, string AliquotaICMS,
			double Qtd, double ValorUnitario, double ValorDescontoAcrescimo, string Unidade,
			string TipoDescontoAcrescimo, string DescontoAcrescimo)
		{
			if (onDepoisVendeItem.IsAssigned)
			{
				VendeItemArgs e = new VendeItemArgs(FromUTF8(Codigo), FromUTF8(Descricao), FromUTF8(AliquotaICMS),
					FromUTF8(Qtd), FromUTF8(ValorUnitario), FromUTF8(ValorDescontoAcrescimo), FromUTF8(Unidade),
					FromUTF8(TipoDescontoAcrescimo), FromUTF8(DescontoAcrescimo));
				onDepoisVendeItem.Raise(e);
			}
		}

		[AllowReversePInvokeCalls]
		private bool OnErrorAbreCupomCallback()
		{
			OnErrorArgs e = new OnErrorArgs();

			if (onErrorAbreCupom.IsAssigned)
				onErrorAbreCupom.Raise(e);

			return e.Tratado;
		}

		[AllowReversePInvokeCalls]
		private bool OnErrorAbreCupomVinculadoCallback()
		{
			OnErrorArgs e = new OnErrorArgs();

			if (onErrorAbreCupomVinculado.IsAssigned)
				onErrorAbreCupomVinculado.Raise(e);

			return e.Tratado;
		}

		[AllowReversePInvokeCalls]
		private bool OnErrorAbreNaoFiscalCallback()
		{
			OnErrorArgs e = new OnErrorArgs();

			if (onErrorAbreNaoFiscal.IsAssigned)
				onErrorAbreNaoFiscal.Raise(e);

			return e.Tratado;
		}

		[AllowReversePInvokeCalls]
		private bool OnErrorAbreRelatorioGerencialCallback(int Indice)
		{
			OnErrorRelatorioArgs e = new OnErrorRelatorioArgs(Indice);

			if (onErrorAbreRelatorioGerencial.IsAssigned)
				onErrorAbreRelatorioGerencial.Raise(e);

			return e.Tratado;
		}

		[AllowReversePInvokeCalls]
		private bool OnErrorCancelaCupomCallback()
		{
			OnErrorArgs e = new OnErrorArgs();

			if (onErrorCancelaCupom.IsAssigned)
				onErrorCancelaCupom.Raise(e);

			return e.Tratado;
		}

		[AllowReversePInvokeCalls]
		private bool OnErrorCancelaItemNaoFiscalCallback()
		{
			OnErrorArgs e = new OnErrorArgs();

			if (onErrorCancelaItemNaoFiscal.IsAssigned)
				onErrorCancelaItemNaoFiscal.Raise(e);

			return e.Tratado;
		}

		[AllowReversePInvokeCalls]
		private bool OnErrorCancelaItemVendidoCallback()
		{
			OnErrorArgs e = new OnErrorArgs();

			if (onErrorCancelaItemVendido.IsAssigned)
				onErrorCancelaItemVendido.Raise(e);

			return e.Tratado;
		}

		[AllowReversePInvokeCalls]
		private bool OnErrorCancelaNaoFiscalCallback()
		{
			OnErrorArgs e = new OnErrorArgs();

			if (onErrorCancelaNaoFiscal.IsAssigned)
				onErrorCancelaNaoFiscal.Raise(e);

			return e.Tratado;
		}

		[AllowReversePInvokeCalls]
		private bool OnErrorEfetuaPagamentoCallback()
		{
			OnErrorArgs e = new OnErrorArgs();

			if (onErrorEfetuaPagamento.IsAssigned)
				onErrorEfetuaPagamento.Raise(e);

			return e.Tratado;
		}

		[AllowReversePInvokeCalls]
		private bool OnErrorEfetuaPagamentoNaoFiscalCallback()
		{
			OnErrorArgs e = new OnErrorArgs();

			if (onErrorEfetuaPagamentoNaoFiscal.IsAssigned)
				onErrorEfetuaPagamentoNaoFiscal.Raise(e);

			return e.Tratado;
		}

		[AllowReversePInvokeCalls]
		private bool OnErrorFechaCupomCallback()
		{
			OnErrorArgs e = new OnErrorArgs();

			if (onErrorFechaCupom.IsAssigned)
				onErrorFechaCupom.Raise(e);

			return e.Tratado;
		}

		[AllowReversePInvokeCalls]
		private bool OnErrorFechaNaoFiscalCallback()
		{
			OnErrorArgs e = new OnErrorArgs();

			if (onErrorFechaNaoFiscal.IsAssigned)
				onErrorFechaNaoFiscal.Raise(e);

			return e.Tratado;
		}

		[AllowReversePInvokeCalls]
		private bool OnErrorFechaRelatorioCallback()
		{
			OnErrorArgs e = new OnErrorArgs();

			if (onErrorFechaRelatorio.IsAssigned)
				onErrorFechaRelatorio.Raise(e);

			return e.Tratado;
		}

		[AllowReversePInvokeCalls]
		private bool OnErrorLeituraXCallback()
		{
			OnErrorArgs e = new OnErrorArgs();

			if (onErrorLeituraX.IsAssigned)
				onErrorLeituraX.Raise(e);

			return e.Tratado;
		}

		[AllowReversePInvokeCalls]
		private bool OnErrorReducaoZCallback()
		{
			OnErrorArgs e = new OnErrorArgs();

			if (onErrorReducaoZ.IsAssigned)
				onErrorReducaoZ.Raise(e);

			return e.Tratado;
		}

		[AllowReversePInvokeCalls]
		private bool OnErrorSangriaCallback()
		{
			OnErrorArgs e = new OnErrorArgs();

			if (onErrorSangria.IsAssigned)
				onErrorSangria.Raise(e);

			return e.Tratado;
		}

		[AllowReversePInvokeCalls]
		private void OnErrorSemPapelCallback()
		{

			if (onErrorSemPapel.IsAssigned)
				onErrorSemPapel.Raise();
		}

		[AllowReversePInvokeCalls]
		private bool OnErrorSubtotalizaCupomCallback()
		{
			OnErrorArgs e = new OnErrorArgs();

			if (onErrorSubtotalizaCupom.IsAssigned)
				onErrorSubtotalizaCupom.Raise(e);

			return e.Tratado;
		}

		[AllowReversePInvokeCalls]
		private bool OnErrorSubtotalizaNaoFiscalCallback()
		{
			OnErrorArgs e = new OnErrorArgs();

			if (onErrorSubtotalizaNaoFiscal.IsAssigned)
				onErrorSubtotalizaNaoFiscal.Raise(e);

			return e.Tratado;
		}

		[AllowReversePInvokeCalls]
		private bool OnErrorSuprimentoCallback()
		{
			OnErrorArgs e = new OnErrorArgs();

			if (onErrorSuprimento.IsAssigned)
				onErrorSuprimento.Raise(e);

			return e.Tratado;
		}

		[AllowReversePInvokeCalls]
		private bool OnErrorVendeItemCallback()
		{
			OnErrorArgs e = new OnErrorArgs();

			if (onErrorVendeItem.IsAssigned)
				onErrorVendeItem.Raise(e);

			return e.Tratado;
		}

		[AllowReversePInvokeCalls]
		private void OnMsgAguardeCallback(string mensagem)
		{
			if (onMsgAguarde.IsAssigned)
			{
				OnMsgArgs e = new OnMsgArgs(FromUTF8(mensagem));
				onMsgAguarde.Raise(e);
			}
		}

		[AllowReversePInvokeCalls]
		private bool OnMsgRetentarCallback(string mensagem, string situacao)
		{
			OnMsgRetentarArgs e = new OnMsgRetentarArgs(FromUTF8(mensagem), FromUTF8(situacao));

			if (onMsgRetentar.IsAssigned)
				onMsgRetentar.Raise(e);

			return e.Result;
		}

		[AllowReversePInvokeCalls]
		private void OnPAFCalcEADCallback(string arquivo)
		{
			if (onPAFCalcEAD.IsAssigned)
			{
				OnPAFCalcEADArgs e = new OnPAFCalcEADArgs(FromUTF8(arquivo));
				onPAFCalcEAD.Raise(e);
			}
		}

		[AllowReversePInvokeCalls]
		private string OnPAFGetKeyRSACallback()
		{
			ChaveEventArgs e = new ChaveEventArgs();

			if (onPAFGetKeyRSA.IsAssigned)
				onPAFGetKeyRSA.Raise(e);

			return ToUTF8(e.Chave);
		}

		#endregion Callback EventHandlers

		#endregion Methods
	}
}