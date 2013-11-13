package jACBrFramework.serial.ecf;

import com.sun.jna.ptr.DoubleByReference;
import com.sun.jna.ptr.IntByReference;
import jACBrFramework.ACBrClass;
import jACBrFramework.ACBrEventListener;
import jACBrFramework.ACBrException;
import jACBrFramework.ChaveEventObject;
import jACBrFramework.OleDate;
import jACBrFramework.interop.ACBrECFInterop;
import jACBrFramework.serial.ACBrDevice;
import java.nio.ByteBuffer;
import java.util.Date;
import java.util.EventObject;

public final class ACBrECF extends ACBrClass
{
	// <editor-fold defaultstate="collapsed" desc="Fields">

	private ACBrDevice device;
	private Aliquota[] aliquotas;
	private FormaPagamento[] formasPagamento;
	private ComprovanteNaoFiscal[] comprovantesNaoFiscais;

	// </editor-fold>
	
	//<editor-fold defaultstate="collapsed" desc="Constructor">
	public ACBrECF() throws ACBrException
	{
	}

	//</editor-fold>
	
	//<editor-fold defaultstate="collapsed" desc="Events">
	//<editor-fold defaultstate="collapsed" desc="onMsgPoucoPapel">
	public void addOnMsgPoucoPapel(ACBrEventListener<EventObject> listener)
	{
		if (!hasListeners("onMsgPoucoPapel")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnMsgPoucoPapel(getHandle(), new ACBrECFInterop.Callback()
			{
				@Override
				public void invoke()
				{
					onMsgPoucoPapel();
				}
			});
		}

		addListener("onMsgPoucoPapel", listener);
	}

	public void removeOnMsgPoucoPapel(ACBrEventListener<EventObject> listener)
	{
		removeListener("onMsgPoucoPapel", listener);

		if (!hasListeners("onMsgPoucoPapel")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnMsgPoucoPapel(getHandle(), null);
		}
	}

	private void onMsgPoucoPapel()
	{
		EventObject e = new EventObject(this);
		notifyListeners("onMsgPoucoPapel", e);
	}

//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onAguardandoRespostaChange">
	public void addOnAguardandoRespostaChange(ACBrEventListener<EventObject> listener)
	{
		if (!hasListeners("onAguardandoRespostaChange")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAguardandoRespostaChange(getHandle(), new ACBrECFInterop.Callback()
			{
				@Override
				public void invoke()
				{
					onAguardandoRespostaChange();
				}
			});
		}

		addListener("onAguardandoRespostaChange", listener);
	}

	public void removeOnAguardandoRespostaChange(ACBrEventListener<EventObject> listener)
	{
		removeListener("onAguardandoRespostaChange", listener);

		if (!hasListeners("onAguardandoRespostaChange")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAguardandoRespostaChange(getHandle(), null);
		}
	}

	private void onAguardandoRespostaChange()
	{
		EventObject e = new EventObject(this);
		notifyListeners("onAguardandoRespostaChange", e);
	}

//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onAntesAbreCupom">
	public void addOnAntesAbreCupom(ACBrEventListener<AbreCupomEventObject> listener)
	{
		if (!hasListeners("onAntesAbreCupom")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesAbreCupom(getHandle(), new ACBrECFInterop.AbreCupomCallback()
			{
				@Override
				public void invoke(String CPF_CNPJ, String Nome, String Endereco)
				{
					onAntesAbreCupom(toUTF8(CPF_CNPJ), toUTF8(Nome), toUTF8(Endereco));
				}
			});
		}

		addListener("onAntesAbreCupom", listener);
	}

	public void removeOnAntesAbreCupom(ACBrEventListener<AbreCupomEventObject> listener)
	{
		removeListener("onAntesAbreCupom", listener);

		if (!hasListeners("onAntesAbreCupom")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesAbreCupom(getHandle(), null);
		}
	}

	private void onAntesAbreCupom(String CPF_CNPJ, String Nome, String Endereco)
	{
		AbreCupomEventObject e = new AbreCupomEventObject(this, CPF_CNPJ, Nome, Endereco);
		notifyListeners("onAntesAbreCupom", e);
	}

	//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onAntesAbreCupomVinculado">
	public void addOnAntesAbreCupomVinculado(ACBrEventListener<EventObject> listener)
	{
		if (!hasListeners("onAntesAbreCupomVinculado")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesAbreCupomVinculado(getHandle(), new ACBrECFInterop.Callback()
			{
				@Override
				public void invoke()
				{
					onAntesAbreCupomVinculado();
				}
			});
		}

		addListener("onAntesAbreCupomVinculado", listener);
	}

	public void removeOnAntesAbreCupomVinculado(ACBrEventListener<EventObject> listener)
	{
		removeListener("onAntesAbreCupomVinculado", listener);

		if (!hasListeners("onAntesAbreCupomVinculado")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesAbreCupomVinculado(getHandle(), null);
		}
	}

	private void onAntesAbreCupomVinculado()
	{
		EventObject e = new EventObject(this);
		notifyListeners("onAntesAbreCupomVinculado", e);
	}

	//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onAntesAbreNaoFiscal">
	public void addOnAntesAbreNaoFiscal(ACBrEventListener<AbreCupomEventObject> listener)
	{
		if (!hasListeners("onAntesAbreNaoFiscal")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesAbreNaoFiscal(getHandle(), new ACBrECFInterop.AbreCupomCallback()
			{
				@Override
				public void invoke(String CPF_CNPJ, String Nome, String Endereco)
				{
					onAntesAbreNaoFiscal(toUTF8(CPF_CNPJ), toUTF8(Nome), toUTF8(Endereco));
				}
			});
		}

		addListener("onAntesAbreNaoFiscal", listener);
	}

	public void removeOnAntesAbreNaoFiscal(ACBrEventListener<AbreCupomEventObject> listener)
	{
		removeListener("onAntesAbreNaoFiscal", listener);

		if (!hasListeners("onAntesAbreNaoFiscal")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesAbreNaoFiscal(getHandle(), null);
		}
	}

	private void onAntesAbreNaoFiscal(String CPF_CNPJ, String Nome, String Endereco)
	{
		AbreCupomEventObject e = new AbreCupomEventObject(this, CPF_CNPJ, Nome, Endereco);
		notifyListeners("onAntesAbreNaoFiscal", e);
	}

	//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onAntesAbreRelatorioGerencial">
	public void addOnAntesAbreRelatorioGerencial(ACBrEventListener<RelatorioGerencialEventObject> listener)
	{
		if (!hasListeners("onAntesAbreRelatorioGerencial")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesAbreRelatorioGerencial(getHandle(), new ACBrECFInterop.RelatorioGerencialCallback()
			{
				@Override
				public void invoke(int value)
				{
					onAntesAbreRelatorioGerencial(value);
				}
			});
		}

		addListener("onAntesAbreRelatorioGerencial", listener);
	}

	public void removeOnAntesAbreRelatorioGerencial(ACBrEventListener<RelatorioGerencialEventObject> listener)
	{
		removeListener("onAntesAbreRelatorioGerencial", listener);

		if (!hasListeners("onAntesAbreRelatorioGerencial")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesAbreRelatorioGerencial(getHandle(), null);
		}
	}

	private void onAntesAbreRelatorioGerencial(int value)
	{
		RelatorioGerencialEventObject e = new RelatorioGerencialEventObject(this, value);
		notifyListeners("onAntesAbreRelatorioGerencial", e);
	}

	//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onAntesCancelaCupom">
	public void addOnAntesCancelaCupom(ACBrEventListener<EventObject> listener)
	{
		if (!hasListeners("onAntesCancelaCupom")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesCancelaCupom(getHandle(), new ACBrECFInterop.Callback()
			{
				@Override
				public void invoke()
				{
					onAntesCancelaCupom();
				}
			});
		}

		addListener("onAntesCancelaCupom", listener);
	}

	public void removeOnAntesCancelaCupom(ACBrEventListener<EventObject> listener)
	{
		removeListener("onAntesCancelaCupom", listener);

		if (!hasListeners("onAntesCancelaCupom")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesCancelaCupom(getHandle(), null);
		}
	}

	private void onAntesCancelaCupom()
	{
		EventObject e = new EventObject(this);
		notifyListeners("onAntesCancelaCupom", e);
	}

	//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onAntesCancelaItemNaoFiscal">
	public void addOnAntesCancelaItemNaoFiscal(ACBrEventListener<CancelaItemEventObject> listener)
	{
		if (!hasListeners("onAntesCancelaItemNaoFiscal")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesCancelaItemNaoFiscal(getHandle(), new ACBrECFInterop.CancelaItemCallback()
			{
				@Override
				public void invoke(int value)
				{
					onAntesCancelaItemNaoFiscal(value);
				}
			});
		}

		addListener("onAntesCancelaItemNaoFiscal", listener);
	}

	public void removeOnAntesCancelaItemNaoFiscal(ACBrEventListener<CancelaItemEventObject> listener)
	{
		removeListener("onAntesCancelaItemNaoFiscal", listener);

		if (!hasListeners("onAntesCancelaItemNaoFiscal")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesCancelaItemNaoFiscal(getHandle(), null);
		}
	}

	private void onAntesCancelaItemNaoFiscal(int value)
	{
		CancelaItemEventObject e = new CancelaItemEventObject(this, value);
		notifyListeners("onAntesCancelaItemNaoFiscal", e);
	}

	//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onAntesCancelaItemVendido">
	public void addOnAntesCancelaItemVendido(ACBrEventListener<CancelaItemEventObject> listener)
	{
		if (!hasListeners("onAntesCancelaItemVendido")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesCancelaItemVendido(getHandle(), new ACBrECFInterop.CancelaItemCallback()
			{
				@Override
				public void invoke(int value)
				{
					onAntesCancelaItemVendido(value);
				}
			});
		}

		addListener("onAntesCancelaItemVendido", listener);
	}

	public void removeOnAntesCancelaItemVendido(ACBrEventListener<CancelaItemEventObject> listener)
	{
		removeListener("onAntesCancelaItemVendido", listener);

		if (!hasListeners("onAntesCancelaItemVendido")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesCancelaItemVendido(getHandle(), null);
		}
	}

	private void onAntesCancelaItemVendido(int value)
	{
		CancelaItemEventObject e = new CancelaItemEventObject(this, value);
		notifyListeners("onAntesCancelaItemVendido", e);
	}

	//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onAntesCancelaNaoFiscal">
	public void addOnAntesCancelaNaoFiscal(ACBrEventListener<EventObject> listener)
	{
		if (!hasListeners("onAntesCancelaNaoFiscal")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesCancelaNaoFiscal(getHandle(), new ACBrECFInterop.Callback()
			{
				@Override
				public void invoke()
				{
					onAntesCancelaNaoFiscal();
				}
			});
		}

		addListener("onAntesCancelaNaoFiscal", listener);
	}

	public void removeOnAntesCancelaNaoFiscal(ACBrEventListener<EventObject> listener)
	{
		removeListener("onAntesCancelaNaoFiscal", listener);

		if (!hasListeners("onAntesCancelaNaoFiscal")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesCancelaNaoFiscal(getHandle(), null);
		}
	}

	private void onAntesCancelaNaoFiscal()
	{
		EventObject e = new EventObject(this);
		notifyListeners("onAntesCancelaNaoFiscal", e);
	}

	//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onAntesEfetuaPagamento">
	public void addOnAntesEfetuaPagamento(ACBrEventListener<EfetuaPagamentoEventObject> listener)
	{
		if (!hasListeners("onAntesEfetuaPagamento")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesEfetuaPagamento(getHandle(), new ACBrECFInterop.EfetuaPagamentoCallback()
			{
				@Override
				public void invoke(String CodFormaPagto, double Valor, String Observacao, boolean ImprimeVinculado)
				{
					onAntesEfetuaPagamento(toUTF8(CodFormaPagto), Valor, toUTF8(Observacao), ImprimeVinculado);
				}
			});
		}

		addListener("onAntesEfetuaPagamento", listener);
	}

	public void removeOnAntesEfetuaPagamento(ACBrEventListener<EfetuaPagamentoEventObject> listener)
	{
		removeListener("onAntesEfetuaPagamento", listener);

		if (!hasListeners("onAntesEfetuaPagamento")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesEfetuaPagamento(getHandle(), null);
		}
	}

	private void onAntesEfetuaPagamento(String CodFormaPagto, double Valor, String Observacao, boolean ImprimeVinculado)
	{
		EfetuaPagamentoEventObject e = new EfetuaPagamentoEventObject(this, CodFormaPagto, Valor, Observacao, ImprimeVinculado);
		notifyListeners("onAntesEfetuaPagamento", e);
	}

	//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onAntesEfetuaPagamentoNaoFiscal">
	public void addOnAntesEfetuaPagamentoNaoFiscal(ACBrEventListener<EfetuaPagamentoEventObject> listener)
	{
		if (!hasListeners("onAntesEfetuaPagamentoNaoFiscal")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesEfetuaPagamentoNaoFiscal(getHandle(), new ACBrECFInterop.EfetuaPagamentoCallback()
			{
				@Override
				public void invoke(String CodFormaPagto, double Valor, String Observacao, boolean ImprimeVinculado)
				{
					onAntesEfetuaPagamentoNaoFiscal(toUTF8(CodFormaPagto), Valor, toUTF8(Observacao), ImprimeVinculado);
				}
			});
		}

		addListener("onAntesEfetuaPagamentoNaoFiscal", listener);
	}

	public void removeOnAntesEfetuaPagamentoNaoFiscal(ACBrEventListener<EfetuaPagamentoEventObject> listener)
	{
		removeListener("onAntesEfetuaPagamentoNaoFiscal", listener);

		if (!hasListeners("onAntesEfetuaPagamentoNaoFiscal")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesEfetuaPagamentoNaoFiscal(getHandle(), null);
		}
	}

	private void onAntesEfetuaPagamentoNaoFiscal(String CodFormaPagto, double Valor, String Observacao, boolean ImprimeVinculado)
	{
		EfetuaPagamentoEventObject e = new EfetuaPagamentoEventObject(this, CodFormaPagto, Valor, Observacao, ImprimeVinculado);
		notifyListeners("onAntesEfetuaPagamentoNaoFiscal", e);
	}

	//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onAntesFechaCupom">
	public void addOnAntesFechaCupom(ACBrEventListener<FechaCupomEventObject> listener)
	{
		if (!hasListeners("onAntesFechaCupom")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesFechaCupom(getHandle(), new ACBrECFInterop.FechaCupomCallback()
			{
				@Override
				public void invoke(String Observacao, int IndiceBMP)
				{
					onAntesFechaCupom(toUTF8(Observacao), IndiceBMP);
				}
			});
		}

		addListener("onAntesFechaCupom", listener);
	}

	public void removeOnAntesFechaCupom(ACBrEventListener<FechaCupomEventObject> listener)
	{
		removeListener("onAntesFechaCupom", listener);

		if (!hasListeners("onAntesFechaCupom")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesFechaCupom(getHandle(), null);
		}
	}

	private void onAntesFechaCupom(String Observacao, int IndiceBMP)
	{
		FechaCupomEventObject e = new FechaCupomEventObject(this, Observacao, IndiceBMP);
		notifyListeners("onAntesFechaCupom", e);
	}

	//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onAntesFechaNaoFiscal">
	public void addOnAntesFechaNaoFiscal(ACBrEventListener<FechaCupomEventObject> listener)
	{
		if (!hasListeners("onAntesFechaNaoFiscal")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesFechaNaoFiscal(getHandle(), new ACBrECFInterop.FechaCupomCallback()
			{
				@Override
				public void invoke(String Observacao, int IndiceBMP)
				{
					onAntesFechaNaoFiscal(toUTF8(Observacao), IndiceBMP);
				}
			});
		}

		addListener("onAntesFechaNaoFiscal", listener);
	}

	public void removeOnAntesFechaNaoFiscal(ACBrEventListener<FechaCupomEventObject> listener)
	{
		removeListener("onAntesFechaNaoFiscal", listener);

		if (!hasListeners("onAntesFechaNaoFiscal")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesFechaNaoFiscal(getHandle(), null);
		}
	}

	private void onAntesFechaNaoFiscal(String Observacao, int IndiceBMP)
	{
		FechaCupomEventObject e = new FechaCupomEventObject(this, Observacao, IndiceBMP);
		notifyListeners("onAntesFechaNaoFiscal", e);
	}

	//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onAntesFechaRelatorio">
	public void addOnAntesFechaRelatorio(ACBrEventListener<EventObject> listener)
	{
		if (!hasListeners("onAntesFechaRelatorio")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesFechaRelatorio(getHandle(), new ACBrECFInterop.Callback()
			{
				@Override
				public void invoke()
				{
					onAntesFechaRelatorio();
				}
			});
		}

		addListener("onAntesFechaRelatorio", listener);
	}

	public void removeOnAntesFechaRelatorio(ACBrEventListener<EventObject> listener)
	{
		removeListener("onAntesFechaRelatorio", listener);

		if (!hasListeners("onAntesFechaRelatorio")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesFechaRelatorio(getHandle(), null);
		}
	}

	private void onAntesFechaRelatorio()
	{
		EventObject e = new EventObject(this);
		notifyListeners("onAntesFechaRelatorio", e);
	}

	//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onAntesLeituraX">
	public void addOnAntesLeituraX(ACBrEventListener<EventObject> listener)
	{
		if (!hasListeners("onAntesLeituraX")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesLeituraX(getHandle(), new ACBrECFInterop.Callback()
			{
				@Override
				public void invoke()
				{
					onAntesLeituraX();
				}
			});
		}

		addListener("onAntesLeituraX", listener);
	}

	public void removeOnAntesLeituraX(ACBrEventListener<EventObject> listener)
	{
		removeListener("onAntesLeituraX", listener);

		if (!hasListeners("onAntesLeituraX")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesLeituraX(getHandle(), null);
		}
	}

	private void onAntesLeituraX()
	{
		EventObject e = new EventObject(this);
		notifyListeners("onAntesLeituraX", e);
	}

	//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onAntesReducaoZ">
	public void addOnAntesReducaoZ(ACBrEventListener<EventObject> listener)
	{
		if (!hasListeners("onAntesReducaoZ")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesReducaoZ(getHandle(), new ACBrECFInterop.Callback()
			{
				@Override
				public void invoke()
				{
					onAntesReducaoZ();
				}
			});
		}

		addListener("onAntesReducaoZ", listener);
	}

	public void removeOnAntesReducaoZ(ACBrEventListener<EventObject> listener)
	{
		removeListener("onAntesReducaoZ", listener);

		if (!hasListeners("onAntesReducaoZ")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesReducaoZ(getHandle(), null);
		}
	}

	private void onAntesReducaoZ()
	{
		EventObject e = new EventObject(this);
		notifyListeners("onAntesReducaoZ", e);
	}

	//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onAntesSangria">
	public void addOnAntesSangria(ACBrEventListener<SangriaSuprimentoEventObject> listener)
	{
		if (!hasListeners("onAntesSangria")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesSangria(getHandle(), new ACBrECFInterop.SangriaSuprimentoCallback()
			{
				@Override
				public void invoke(double Valor, String Obs, String DescricaoCNF, String DescricaoFPG)
				{
					onAntesSangria(Valor, toUTF8(Obs), toUTF8(DescricaoCNF), toUTF8(DescricaoFPG));
				}
			});
		}

		addListener("onAntesSangria", listener);
	}

	public void removeOnAntesSangria(ACBrEventListener<SangriaSuprimentoEventObject> listener)
	{
		removeListener("onAntesSangria", listener);

		if (!hasListeners("onAntesSangria")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesSangria(getHandle(), null);
		}
	}

	private void onAntesSangria(double Valor, String Obs, String DescricaoCNF, String DescricaoFPG)
	{
		SangriaSuprimentoEventObject e = new SangriaSuprimentoEventObject(this, Valor, Obs, DescricaoCNF, DescricaoFPG);
		notifyListeners("onAntesSangria", e);
	}

	//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onAntesSubtotalizaCupom">
	public void addOnAntesSubtotalizaCupom(ACBrEventListener<SubtotalizaCupomEventObject> listener)
	{
		if (!hasListeners("onAntesSubtotalizaCupom")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesSubtotalizaCupom(getHandle(), new ACBrECFInterop.SubtotalizaCupomCallback()
			{
				@Override
				public void invoke(double DescontoAcrescimo, String MensagemRodape)
				{
					onAntesSubtotalizaCupom(DescontoAcrescimo, toUTF8(MensagemRodape));
				}
			});
		}

		addListener("onAntesSubtotalizaCupom", listener);
	}

	public void removeOnAntesSubtotalizaCupom(ACBrEventListener<SubtotalizaCupomEventObject> listener)
	{
		removeListener("onAntesSubtotalizaCupom", listener);

		if (!hasListeners("onAntesSubtotalizaCupom")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesSubtotalizaCupom(getHandle(), null);
		}
	}

	private void onAntesSubtotalizaCupom(double DescontoAcrescimo, String MensagemRodape)
	{
		SubtotalizaCupomEventObject e = new SubtotalizaCupomEventObject(this, DescontoAcrescimo, MensagemRodape);
		notifyListeners("onAntesSubtotalizaCupom", e);
	}

	//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onAntesSubtotalizaNaoFiscal">
	public void addOnAntesSubtotalizaNaoFiscal(ACBrEventListener<SubtotalizaCupomEventObject> listener)
	{
		if (!hasListeners("onAntesSubtotalizaNaoFiscal")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesSubtotalizaNaoFiscal(getHandle(), new ACBrECFInterop.SubtotalizaCupomCallback()
			{
				@Override
				public void invoke(double DescontoAcrescimo, String MensagemRodape)
				{
					onAntesSubtotalizaNaoFiscal(DescontoAcrescimo, toUTF8(MensagemRodape));
				}
			});
		}

		addListener("onAntesSubtotalizaNaoFiscal", listener);
	}

	public void removeOnAntesSubtotalizaNaoFiscal(ACBrEventListener<SubtotalizaCupomEventObject> listener)
	{
		removeListener("onAntesSubtotalizaNaoFiscal", listener);

		if (!hasListeners("onAntesSubtotalizaNaoFiscal")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesSubtotalizaNaoFiscal(getHandle(), null);
		}
	}

	private void onAntesSubtotalizaNaoFiscal(double DescontoAcrescimo, String MensagemRodape)
	{
		SubtotalizaCupomEventObject e = new SubtotalizaCupomEventObject(this, DescontoAcrescimo, MensagemRodape);
		notifyListeners("onAntesSubtotalizaNaoFiscal", e);
	}

	//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onAntesSuprimento">
	public void addOnAntesSuprimento(ACBrEventListener<SangriaSuprimentoEventObject> listener)
	{
		if (!hasListeners("onAntesSuprimento")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesSuprimento(getHandle(), new ACBrECFInterop.SangriaSuprimentoCallback()
			{
				@Override
				public void invoke(double Valor, String Obs, String DescricaoCNF, String DescricaoFPG)
				{
					onAntesSuprimento(Valor, toUTF8(Obs), toUTF8(DescricaoCNF), toUTF8(DescricaoFPG));
				}
			});
		}

		addListener("onAntesSuprimento", listener);
	}

	public void removeOnAntesSuprimento(ACBrEventListener<SangriaSuprimentoEventObject> listener)
	{
		removeListener("onAntesSuprimento", listener);

		if (!hasListeners("onAntesSuprimento")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesSuprimento(getHandle(), null);
		}
	}

	private void onAntesSuprimento(double Valor, String Obs, String DescricaoCNF, String DescricaoFPG)
	{
		SangriaSuprimentoEventObject e = new SangriaSuprimentoEventObject(this, Valor, Obs, DescricaoCNF, DescricaoFPG);
		notifyListeners("onAntesSuprimento", e);
	}

	//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onAntesVendeItem">
	public void addOnAntesVendeItem(ACBrEventListener<VendeItemEventObject> listener)
	{
		if (!hasListeners("onAntesVendeItem")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesVendeItem(getHandle(), new ACBrECFInterop.VendeItemCallback()
			{
				@Override
				public void invoke(String Codigo, String Descricao, String AliquotaICMS, double Qtd, double ValorUnitario, double ValorDescontoAcrescimo, String Unidade, String TipoDescontoAcrescimo, String DescontoAcrescimo)
				{
					onAntesVendeItem(toUTF8(Codigo), toUTF8(Descricao), toUTF8(AliquotaICMS), Qtd, ValorUnitario, ValorDescontoAcrescimo, toUTF8(Unidade), toUTF8(TipoDescontoAcrescimo), toUTF8(DescontoAcrescimo));
				}
			});
		}

		addListener("onAntesVendeItem", listener);
	}

	public void removeOnAntesVendeItem(ACBrEventListener<VendeItemEventObject> listener)
	{
		removeListener("onAntesVendeItem", listener);

		if (!hasListeners("onAntesVendeItem")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesVendeItem(getHandle(), null);
		}
	}

	private void onAntesVendeItem(String Codigo, String Descricao, String AliquotaICMS, double Qtd, double ValorUnitario, double ValorDescontoAcrescimo, String Unidade, String TipoDescontoAcrescimo, String DescontoAcrescimo)
	{
		VendeItemEventObject e = new VendeItemEventObject(this, Codigo, Descricao, AliquotaICMS, Qtd, ValorUnitario, ValorDescontoAcrescimo, Unidade, TipoDescontoAcrescimo, DescontoAcrescimo);
		notifyListeners("onAntesVendeItem", e);
	}

	//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onBobinaAdicionaLinhas">
	public void addOnBobinaAdicionaLinhas(ACBrEventListener<BobinaAdicionaLinhasEventObject> listener)
	{
		if (!hasListeners("onBobinaAdicionaLinhas")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnBobinaAdicionaLinhas(getHandle(), new ACBrECFInterop.BobinaAdicionaLinhasCallback()
			{
				@Override
				public void invoke(String linhas, String operacao)
				{
					onBobinaAdicionaLinhas(toUTF8(linhas), toUTF8(operacao));
				}
			});
		}

		addListener("onBobinaAdicionaLinhas", listener);
	}

	public void removeOnBobinaAdicionaLinhas(ACBrEventListener<BobinaAdicionaLinhasEventObject> listener)
	{
		removeListener("onBobinaAdicionaLinhas", listener);

		if (!hasListeners("onBobinaAdicionaLinhas")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnBobinaAdicionaLinhas(getHandle(), null);
		}
	}

	private void onBobinaAdicionaLinhas(String linhas, String operacao)
	{
		BobinaAdicionaLinhasEventObject e = new BobinaAdicionaLinhasEventObject(this, linhas, operacao);
		notifyListeners("onBobinaAdicionaLinhas", e);
	}

	//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onChangeEstado">
	public void addOnChangeEstado(ACBrEventListener<ChangeEstadoEventObject> listener)
	{
		if (!hasListeners("onChangeEstado")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnChangeEstado(getHandle(), new ACBrECFInterop.ChangeEstadoCallback()
			{
				@Override
				public void invoke(int EstadoAnterior, int EstadoAtual)
				{
					onChangeEstado(EstadoAnterior, EstadoAtual);
				}
			});
		}

		addListener("onChangeEstado", listener);
	}

	public void removeOnChangeEstado(ACBrEventListener<ChangeEstadoEventObject> listener)
	{
		removeListener("onChangeEstado", listener);

		if (!hasListeners("onChangeEstado")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnChangeEstado(getHandle(), null);
		}
	}

	private void onChangeEstado(int EstadoAnterior, int EstadoAtual)
	{
		ChangeEstadoEventObject e = new ChangeEstadoEventObject(this, EstadoAnterior, EstadoAtual);
		notifyListeners("onChangeEstado", e);
	}

	//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onChequeEstado">
	public void addOnChequeEstado(ACBrEventListener<ChequeEstadoEventObject> listener)
	{
		if (!hasListeners("onChequeEstado")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnChequeEstado(getHandle(), new ACBrECFInterop.ChequeEstadoCallback()
			{
				@Override
				public boolean invoke(int EstadoAtual)
				{
					return onChequeEstado(EstadoAtual);
				}
			});
		}

		addListener("onChequeEstado", listener);
	}

	public void removeOnChequeEstado(ACBrEventListener<ChequeEstadoEventObject> listener)
	{
		removeListener("onChequeEstado", listener);

		if (!hasListeners("onChequeEstado")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnChequeEstado(getHandle(), null);
		}
	}

	private boolean onChequeEstado(int EstadoAtual)
	{
		ChequeEstadoEventObject e = new ChequeEstadoEventObject(this, EstadoAtual, true);
		notifyListeners("onChequeEstado", e);

		return e.getContinuar();
	}

	//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onDepoisAbreCupom">
	public void addOnDepoisAbreCupom(ACBrEventListener<AbreCupomEventObject> listener)
	{
		if (!hasListeners("onDepoisAbreCupom")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnDepoisAbreCupom(getHandle(), new ACBrECFInterop.AbreCupomCallback()
			{
				@Override
				public void invoke(String CPF_CNPJ, String Nome, String Endereco)
				{
					onDepoisAbreCupom(toUTF8(CPF_CNPJ), toUTF8(Nome), toUTF8(Endereco));
				}
			});
		}

		addListener("onDepoisAbreCupom", listener);
	}

	public void removeOnDepoisAbreCupom(ACBrEventListener<AbreCupomEventObject> listener)
	{
		removeListener("onDepoisAbreCupom", listener);

		if (!hasListeners("onDepoisAbreCupom")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnDepoisAbreCupom(getHandle(), null);
		}
	}

	private void onDepoisAbreCupom(String CPF_CNPJ, String Nome, String Endereco)
	{
		AbreCupomEventObject e = new AbreCupomEventObject(this, CPF_CNPJ, Nome, Endereco);
		notifyListeners("onDepoisAbreCupom", e);
	}

	//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onDepoisAbreCupomVinculado">
	public void addOnDepoisAbreCupomVinculado(ACBrEventListener<EventObject> listener)
	{
		if (!hasListeners("onDepoisAbreCupomVinculado")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnDepoisAbreCupomVinculado(getHandle(), new ACBrECFInterop.Callback()
			{
				@Override
				public void invoke()
				{
					onDepoisAbreCupomVinculado();
				}
			});
		}

		addListener("onDepoisAbreCupomVinculado", listener);
	}

	public void removeOnDepoisAbreCupomVinculado(ACBrEventListener<EventObject> listener)
	{
		removeListener("onDepoisAbreCupomVinculado", listener);

		if (!hasListeners("onDepoisAbreCupomVinculado")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnDepoisAbreCupomVinculado(getHandle(), null);
		}
	}

	private void onDepoisAbreCupomVinculado()
	{
		EventObject e = new EventObject(this);
		notifyListeners("onDepoisAbreCupomVinculado", e);
	}

	//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onDepoisAbreNaoFiscal">
	public void addOnDepoisAbreNaoFiscal(ACBrEventListener<AbreCupomEventObject> listener)
	{
		if (!hasListeners("onDepoisAbreNaoFiscal")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnDepoisAbreNaoFiscal(getHandle(), new ACBrECFInterop.AbreCupomCallback()
			{
				@Override
				public void invoke(String CPF_CNPJ, String Nome, String Endereco)
				{
					onDepoisAbreNaoFiscal(toUTF8(CPF_CNPJ), toUTF8(Nome), toUTF8(Endereco));
				}
			});
		}

		addListener("onDepoisAbreNaoFiscal", listener);
	}

	public void removeOnDepoisAbreNaoFiscal(ACBrEventListener<AbreCupomEventObject> listener)
	{
		removeListener("onDepoisAbreNaoFiscal", listener);

		if (!hasListeners("onDepoisAbreNaoFiscal")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnDepoisAbreNaoFiscal(getHandle(), null);
		}
	}

	private void onDepoisAbreNaoFiscal(String CPF_CNPJ, String Nome, String Endereco)
	{
		AbreCupomEventObject e = new AbreCupomEventObject(this, CPF_CNPJ, Nome, Endereco);
		notifyListeners("onDepoisAbreNaoFiscal", e);
	}

	//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onDepoisAbreRelatorioGerencial">
	public void addOnDepoisAbreRelatorioGerencial(ACBrEventListener<RelatorioGerencialEventObject> listener)
	{
		if (!hasListeners("onDepoisAbreRelatorioGerencial")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnDepoisAbreRelatorioGerencial(getHandle(), new ACBrECFInterop.RelatorioGerencialCallback()
			{
				@Override
				public void invoke(int value)
				{
					onDepoisAbreRelatorioGerencial(value);
				}
			});
		}

		addListener("onDepoisAbreRelatorioGerencial", listener);
	}

	public void removeOnDepoisAbreRelatorioGerencial(ACBrEventListener<RelatorioGerencialEventObject> listener)
	{
		removeListener("onDepoisAbreRelatorioGerencial", listener);

		if (!hasListeners("onDepoisAbreRelatorioGerencial")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnDepoisAbreRelatorioGerencial(getHandle(), null);
		}
	}

	private void onDepoisAbreRelatorioGerencial(int value)
	{
		RelatorioGerencialEventObject e = new RelatorioGerencialEventObject(this, value);
		notifyListeners("onDepoisAbreRelatorioGerencial", e);
	}

	//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onDepoisCancelaCupom">
	public void addOnDepoisCancelaCupom(ACBrEventListener<EventObject> listener)
	{
		if (!hasListeners("onDepoisCancelaCupom")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnDepoisCancelaCupom(getHandle(), new ACBrECFInterop.Callback()
			{
				@Override
				public void invoke()
				{
					onDepoisCancelaCupom();
				}
			});
		}

		addListener("onDepoisCancelaCupom", listener);
	}

	public void removeOnDepoisCancelaCupom(ACBrEventListener<EventObject> listener)
	{
		removeListener("onDepoisCancelaCupom", listener);

		if (!hasListeners("onDepoisCancelaCupom")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnDepoisCancelaCupom(getHandle(), null);
		}
	}

	private void onDepoisCancelaCupom()
	{
		EventObject e = new EventObject(this);
		notifyListeners("onDepoisCancelaCupom", e);
	}

	//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onDepoisCancelaItemNaoFiscal">
	public void addOnDepoisCancelaItemNaoFiscal(ACBrEventListener<CancelaItemEventObject> listener)
	{
		if (!hasListeners("onDepoisCancelaItemNaoFiscal")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnDepoisCancelaItemNaoFiscal(getHandle(), new ACBrECFInterop.CancelaItemCallback()
			{
				@Override
				public void invoke(int value)
				{
					onDepoisCancelaItemNaoFiscal(value);
				}
			});
		}

		addListener("onDepoisCancelaItemNaoFiscal", listener);
	}

	public void removeOnDepoisCancelaItemNaoFiscal(ACBrEventListener<CancelaItemEventObject> listener)
	{
		removeListener("onDepoisCancelaItemNaoFiscal", listener);

		if (!hasListeners("onDepoisCancelaItemNaoFiscal")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnDepoisCancelaItemNaoFiscal(getHandle(), null);
		}
	}

	private void onDepoisCancelaItemNaoFiscal(int value)
	{
		CancelaItemEventObject e = new CancelaItemEventObject(this, value);
		notifyListeners("onDepoisCancelaItemNaoFiscal", e);
	}

	//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onDepoisCancelaItemVendido">
	public void addOnDepoisCancelaItemVendido(ACBrEventListener<CancelaItemEventObject> listener)
	{
		if (!hasListeners("onDepoisCancelaItemVendido")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnDepoisCancelaItemVendido(getHandle(), new ACBrECFInterop.CancelaItemCallback()
			{
				@Override
				public void invoke(int value)
				{
					onDepoisCancelaItemVendido(value);
				}
			});
		}

		addListener("onDepoisCancelaItemVendido", listener);
	}

	public void removeOnDepoisCancelaItemVendido(ACBrEventListener<CancelaItemEventObject> listener)
	{
		removeListener("onDepoisCancelaItemVendido", listener);

		if (!hasListeners("onDepoisCancelaItemVendido")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnDepoisCancelaItemVendido(getHandle(), null);
		}
	}

	private void onDepoisCancelaItemVendido(int value)
	{
		CancelaItemEventObject e = new CancelaItemEventObject(this, value);
		notifyListeners("onDepoisCancelaItemVendido", e);
	}

	//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onDepoisCancelaNaoFiscal">
	public void addOnDepoisCancelaNaoFiscal(ACBrEventListener<EventObject> listener)
	{
		if (!hasListeners("onDepoisCancelaNaoFiscal")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnDepoisCancelaNaoFiscal(getHandle(), new ACBrECFInterop.Callback()
			{
				@Override
				public void invoke()
				{
					onDepoisCancelaNaoFiscal();
				}
			});
		}

		addListener("onDepoisCancelaNaoFiscal", listener);
	}

	public void removeOnDepoisCancelaNaoFiscal(ACBrEventListener<EventObject> listener)
	{
		removeListener("onDepoisCancelaNaoFiscal", listener);

		if (!hasListeners("onDepoisCancelaNaoFiscal")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnDepoisCancelaNaoFiscal(getHandle(), null);
		}
	}

	private void onDepoisCancelaNaoFiscal()
	{
		EventObject e = new EventObject(this);
		notifyListeners("onDepoisCancelaNaoFiscal", e);
	}

	//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onDepoisEfetuaPagamento">
	public void addOnDepoisEfetuaPagamento(ACBrEventListener<EfetuaPagamentoEventObject> listener)
	{
		if (!hasListeners("onDepoisEfetuaPagamento")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnDepoisEfetuaPagamento(getHandle(), new ACBrECFInterop.EfetuaPagamentoCallback()
			{
				@Override
				public void invoke(String CodFormaPagto, double Valor, String Observacao, boolean ImprimeVinculado)
				{
					onDepoisEfetuaPagamento(toUTF8(CodFormaPagto), Valor, toUTF8(Observacao), ImprimeVinculado);
				}
			});
		}

		addListener("onDepoisEfetuaPagamento", listener);
	}

	public void removeOnDepoisEfetuaPagamento(ACBrEventListener<EfetuaPagamentoEventObject> listener)
	{
		removeListener("onDepoisEfetuaPagamento", listener);

		if (!hasListeners("onDepoisEfetuaPagamento")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnDepoisEfetuaPagamento(getHandle(), null);
		}
	}

	private void onDepoisEfetuaPagamento(String CodFormaPagto, double Valor, String Observacao, boolean ImprimeVinculado)
	{
		EfetuaPagamentoEventObject e = new EfetuaPagamentoEventObject(this, CodFormaPagto, Valor, Observacao, ImprimeVinculado);
		notifyListeners("onDepoisEfetuaPagamento", e);
	}

	//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onDepoisEfetuaPagamentoNaoFiscal">
	public void addOnDepoisEfetuaPagamentoNaoFiscal(ACBrEventListener<EfetuaPagamentoEventObject> listener)
	{
		if (!hasListeners("onDepoisEfetuaPagamentoNaoFiscal")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnDepoisEfetuaPagamentoNaoFiscal(getHandle(), new ACBrECFInterop.EfetuaPagamentoCallback()
			{
				@Override
				public void invoke(String CodFormaPagto, double Valor, String Observacao, boolean ImprimeVinculado)
				{
					onDepoisEfetuaPagamentoNaoFiscal(toUTF8(CodFormaPagto), Valor, toUTF8(Observacao), ImprimeVinculado);
				}
			});
		}

		addListener("onDepoisEfetuaPagamentoNaoFiscal", listener);
	}

	public void removeOnDepoisEfetuaPagamentoNaoFiscal(ACBrEventListener<EfetuaPagamentoEventObject> listener)
	{
		removeListener("onDepoisEfetuaPagamentoNaoFiscal", listener);

		if (!hasListeners("onDepoisEfetuaPagamentoNaoFiscal")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnDepoisEfetuaPagamentoNaoFiscal(getHandle(), null);
		}
	}

	private void onDepoisEfetuaPagamentoNaoFiscal(String CodFormaPagto, double Valor, String Observacao, boolean ImprimeVinculado)
	{
		EfetuaPagamentoEventObject e = new EfetuaPagamentoEventObject(this, CodFormaPagto, Valor, Observacao, ImprimeVinculado);
		notifyListeners("onDepoisEfetuaPagamentoNaoFiscal", e);
	}

	//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onDepoisFechaCupom">
	public void addOnDepoisFechaCupom(ACBrEventListener<FechaCupomEventObject> listener)
	{
		if (!hasListeners("onDepoisFechaCupom")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnDepoisFechaCupom(getHandle(), new ACBrECFInterop.FechaCupomCallback()
			{
				@Override
				public void invoke(String Observacao, int IndiceBMP)
				{
					onDepoisFechaCupom(toUTF8(Observacao), IndiceBMP);
				}
			});
		}

		addListener("onDepoisFechaCupom", listener);
	}

	public void removeOnDepoisFechaCupom(ACBrEventListener<FechaCupomEventObject> listener)
	{
		removeListener("onDepoisFechaCupom", listener);

		if (!hasListeners("onDepoisFechaCupom")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnDepoisFechaCupom(getHandle(), null);
		}
	}

	private void onDepoisFechaCupom(String Observacao, int IndiceBMP)
	{
		FechaCupomEventObject e = new FechaCupomEventObject(this, Observacao, IndiceBMP);
		notifyListeners("onDepoisFechaCupom", e);
	}

	//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onDepoisFechaNaoFiscal">
	public void addOnDepoisFechaNaoFiscal(ACBrEventListener<FechaCupomEventObject> listener)
	{
		if (!hasListeners("onDepoisFechaNaoFiscal")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnDepoisFechaNaoFiscal(getHandle(), new ACBrECFInterop.FechaCupomCallback()
			{
				@Override
				public void invoke(String Observacao, int IndiceBMP)
				{
					onDepoisFechaNaoFiscal(toUTF8(Observacao), IndiceBMP);
				}
			});
		}

		addListener("onDepoisFechaNaoFiscal", listener);
	}

	public void removeOnDepoisFechaNaoFiscal(ACBrEventListener<FechaCupomEventObject> listener)
	{
		removeListener("onDepoisFechaNaoFiscal", listener);

		if (!hasListeners("onDepoisFechaNaoFiscal")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnDepoisFechaNaoFiscal(getHandle(), null);
		}
	}

	private void onDepoisFechaNaoFiscal(String Observacao, int IndiceBMP)
	{
		FechaCupomEventObject e = new FechaCupomEventObject(this, Observacao, IndiceBMP);
		notifyListeners("onDepoisFechaNaoFiscal", e);
	}

//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onDepoisFechaRelatorio">
	public void addOnDepoisFechaRelatorio(ACBrEventListener<EventObject> listener)
	{
		if (!hasListeners("onDepoisFechaRelatorio")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnDepoisFechaRelatorio(getHandle(), new ACBrECFInterop.Callback()
			{
				@Override
				public void invoke()
				{
					onDepoisFechaRelatorio();
				}
			});
		}

		addListener("onDepoisFechaRelatorio", listener);
	}

	public void removeOnDepoisFechaRelatorio(ACBrEventListener<EventObject> listener)
	{
		removeListener("onDepoisFechaRelatorio", listener);

		if (!hasListeners("onDepoisFechaRelatorio")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnDepoisFechaRelatorio(getHandle(), null);
		}
	}

	private void onDepoisFechaRelatorio()
	{
		EventObject e = new EventObject(this);
		notifyListeners("onDepoisFechaRelatorio", e);
	}

//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onDepoisLeituraX">
	public void addOnDepoisLeituraX(ACBrEventListener<EventObject> listener)
	{
		if (!hasListeners("onDepoisLeituraX")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnDepoisLeituraX(getHandle(), new ACBrECFInterop.Callback()
			{
				@Override
				public void invoke()
				{
					onDepoisLeituraX();
				}
			});
		}

		addListener("onDepoisLeituraX", listener);
	}

	public void removeOnDepoisLeituraX(ACBrEventListener<EventObject> listener)
	{
		removeListener("onDepoisLeituraX", listener);

		if (!hasListeners("onDepoisLeituraX")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnDepoisLeituraX(getHandle(), null);
		}
	}

	private void onDepoisLeituraX()
	{
		EventObject e = new EventObject(this);
		notifyListeners("onDepoisLeituraX", e);
	}

//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onDepoisReducaoZ">
	public void addOnDepoisReducaoZ(ACBrEventListener<EventObject> listener)
	{
		if (!hasListeners("onDepoisReducaoZ")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnDepoisReducaoZ(getHandle(), new ACBrECFInterop.Callback()
			{
				@Override
				public void invoke()
				{
					onDepoisReducaoZ();
				}
			});
		}

		addListener("onDepoisReducaoZ", listener);
	}

	public void removeOnDepoisReducaoZ(ACBrEventListener<EventObject> listener)
	{
		removeListener("onDepoisReducaoZ", listener);

		if (!hasListeners("onDepoisReducaoZ")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnDepoisReducaoZ(getHandle(), null);
		}
	}

	private void onDepoisReducaoZ()
	{
		EventObject e = new EventObject(this);
		notifyListeners("onDepoisReducaoZ", e);
	}

//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onDepoisSangria">
	public void addOnDepoisSangria(ACBrEventListener<SangriaSuprimentoEventObject> listener)
	{
		if (!hasListeners("onDepoisSangria")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnDepoisSangria(getHandle(), new ACBrECFInterop.SangriaSuprimentoCallback()
			{
				@Override
				public void invoke(double Valor, String Obs, String DescricaoCNF, String DescricaoFPG)
				{
					onDepoisSangria(Valor, toUTF8(Obs), toUTF8(DescricaoCNF), toUTF8(DescricaoFPG));
				}
			});
		}

		addListener("onDepoisSangria", listener);
	}

	public void removeOnDepoisSangria(ACBrEventListener<SangriaSuprimentoEventObject> listener)
	{
		removeListener("onDepoisSangria", listener);

		if (!hasListeners("onDepoisSangria")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnDepoisSangria(getHandle(), null);
		}
	}

	private void onDepoisSangria(double Valor, String Obs, String DescricaoCNF, String DescricaoFPG)
	{
		SangriaSuprimentoEventObject e = new SangriaSuprimentoEventObject(this, Valor, Obs, DescricaoCNF, DescricaoFPG);
		notifyListeners("onDepoisSangria", e);
	}

//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onDepoisSubtotalizaCupom">
	public void addOnDepoisSubtotalizaCupom(ACBrEventListener<SubtotalizaCupomEventObject> listener)
	{
		if (!hasListeners("onDepoisSubtotalizaCupom")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnDepoisSubtotalizaCupom(getHandle(), new ACBrECFInterop.SubtotalizaCupomCallback()
			{
				@Override
				public void invoke(double DescontoAcrescimo, String MensagemRodape)
				{
					onDepoisSubtotalizaCupom(DescontoAcrescimo, toUTF8(MensagemRodape));
				}
			});
		}

		addListener("onDepoisSubtotalizaCupom", listener);
	}

	public void removeOnDepoisSubtotalizaCupom(ACBrEventListener<SubtotalizaCupomEventObject> listener)
	{
		removeListener("onDepoisSubtotalizaCupom", listener);

		if (!hasListeners("onDepoisSubtotalizaCupom")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnDepoisSubtotalizaCupom(getHandle(), null);
		}
	}

	private void onDepoisSubtotalizaCupom(double DescontoAcrescimo, String MensagemRodape)
	{
		SubtotalizaCupomEventObject e = new SubtotalizaCupomEventObject(this, DescontoAcrescimo, MensagemRodape);
		notifyListeners("onDepoisSubtotalizaCupom", e);
	}

//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onDepoisSubtotalizaNaoFiscal">
	public void addOnDepoisSubtotalizaNaoFiscal(ACBrEventListener<SubtotalizaCupomEventObject> listener)
	{
		if (!hasListeners("onDepoisSubtotalizaNaoFiscal")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnDepoisSubtotalizaNaoFiscal(getHandle(), new ACBrECFInterop.SubtotalizaCupomCallback()
			{
				@Override
				public void invoke(double DescontoAcrescimo, String MensagemRodape)
				{
					onDepoisSubtotalizaNaoFiscal(DescontoAcrescimo, toUTF8(MensagemRodape));
				}
			});
		}

		addListener("onDepoisSubtotalizaNaoFiscal", listener);
	}

	public void removeOnDepoisSubtotalizaNaoFiscal(ACBrEventListener<SubtotalizaCupomEventObject> listener)
	{
		removeListener("onDepoisSubtotalizaNaoFiscal", listener);

		if (!hasListeners("onDepoisSubtotalizaNaoFiscal")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnDepoisSubtotalizaNaoFiscal(getHandle(), null);
		}
	}

	private void onDepoisSubtotalizaNaoFiscal(double DescontoAcrescimo, String MensagemRodape)
	{
		SubtotalizaCupomEventObject e = new SubtotalizaCupomEventObject(this, DescontoAcrescimo, MensagemRodape);
		notifyListeners("onDepoisSubtotalizaNaoFiscal", e);
	}

//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onDepoisSuprimento">
	public void addOnDepoisSuprimento(ACBrEventListener<SangriaSuprimentoEventObject> listener)
	{
		if (!hasListeners("onDepoisSuprimento")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnDepoisSuprimento(getHandle(), new ACBrECFInterop.SangriaSuprimentoCallback()
			{
				@Override
				public void invoke(double Valor, String Obs, String DescricaoCNF, String DescricaoFPG)
				{
					onDepoisSuprimento(Valor, toUTF8(Obs), toUTF8(DescricaoCNF), toUTF8(DescricaoFPG));
				}
			});
		}

		addListener("onDepoisSuprimento", listener);
	}

	public void removeOnDepoisSuprimento(ACBrEventListener<SangriaSuprimentoEventObject> listener)
	{
		removeListener("onDepoisSuprimento", listener);

		if (!hasListeners("onDepoisSuprimento")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnDepoisSuprimento(getHandle(), null);
		}
	}

	private void onDepoisSuprimento(double Valor, String Obs, String DescricaoCNF, String DescricaoFPG)
	{
		SangriaSuprimentoEventObject e = new SangriaSuprimentoEventObject(this, Valor, Obs, DescricaoCNF, DescricaoFPG);
		notifyListeners("onDepoisSuprimento", e);
	}

//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onDepoisVendeItem">
	public void addOnDepoisVendeItem(ACBrEventListener<VendeItemEventObject> listener)
	{
		if (!hasListeners("onDepoisVendeItem")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnDepoisVendeItem(getHandle(), new ACBrECFInterop.VendeItemCallback()
			{
				@Override
				public void invoke(String Codigo, String Descricao, String AliquotaICMS, double Qtd, double ValorUnitario, double ValorDescontoAcrescimo, String Unidade, String TipoDescontoAcrescimo, String DescontoAcrescimo)
				{
					onDepoisVendeItem(toUTF8(Codigo), toUTF8(Descricao), toUTF8(AliquotaICMS), Qtd, ValorUnitario, ValorDescontoAcrescimo, toUTF8(Unidade), toUTF8(TipoDescontoAcrescimo), toUTF8(DescontoAcrescimo));
				}
			});
		}

		addListener("onDepoisVendeItem", listener);
	}

	public void removeOnDepoisVendeItem(ACBrEventListener<VendeItemEventObject> listener)
	{
		removeListener("onDepoisVendeItem", listener);

		if (!hasListeners("onDepoisVendeItem")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnDepoisVendeItem(getHandle(), null);
		}
	}

	private void onDepoisVendeItem(String Codigo, String Descricao, String AliquotaICMS, double Qtd, double ValorUnitario, double ValorDescontoAcrescimo, String Unidade, String TipoDescontoAcrescimo, String DescontoAcrescimo)
	{
		VendeItemEventObject e = new VendeItemEventObject(this, Codigo, Descricao, AliquotaICMS, Qtd, ValorUnitario, ValorDescontoAcrescimo, Unidade, TipoDescontoAcrescimo, DescontoAcrescimo);
		notifyListeners("onDepoisVendeItem", e);
	}

//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onErrorAbreCupom">
	public void addOnErrorAbreCupom(ACBrEventListener<ErrorEventObject> listener)
	{
		if (!hasListeners("onErrorAbreCupom")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnErrorAbreCupom(getHandle(), new ACBrECFInterop.ErrorCallback()
			{
				@Override
				public boolean invoke()
				{
					return onErrorAbreCupom();
				}
			});
		}

		addListener("onErrorAbreCupom", listener);
	}

	public void removeOnErrorAbreCupom(ACBrEventListener<ErrorEventObject> listener)
	{
		removeListener("onErrorAbreCupom", listener);

		if (!hasListeners("onErrorAbreCupom")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnErrorAbreCupom(getHandle(), null);
		}
	}

	private boolean onErrorAbreCupom()
	{
		ErrorEventObject e = new ErrorEventObject(this, false);
		notifyListeners("onErrorAbreCupom", e);

		return e.getTratado();
	}

//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onErrorAbreCupomVinculado">
	public void addOnErrorAbreCupomVinculado(ACBrEventListener<ErrorEventObject> listener)
	{
		if (!hasListeners("onErrorAbreCupomVinculado")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnErrorAbreCupomVinculado(getHandle(), new ACBrECFInterop.ErrorCallback()
			{
				@Override
				public boolean invoke()
				{
					return onErrorAbreCupomVinculado();
				}
			});
		}

		addListener("onErrorAbreCupomVinculado", listener);
	}

	public void removeOnErrorAbreCupomVinculado(ACBrEventListener<ErrorEventObject> listener)
	{
		removeListener("onErrorAbreCupomVinculado", listener);

		if (!hasListeners("onErrorAbreCupomVinculado")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnErrorAbreCupomVinculado(getHandle(), null);
		}
	}

	private boolean onErrorAbreCupomVinculado()
	{
		ErrorEventObject e = new ErrorEventObject(this, false);
		notifyListeners("onErrorAbreCupomVinculado", e);

		return e.getTratado();
	}

//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onErrorAbreNaoFiscal">
	public void addOnErrorAbreNaoFiscal(ACBrEventListener<ErrorEventObject> listener)
	{
		if (!hasListeners("onErrorAbreNaoFiscal")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnErrorAbreNaoFiscal(getHandle(), new ACBrECFInterop.ErrorCallback()
			{
				@Override
				public boolean invoke()
				{
					return onErrorAbreNaoFiscal();
				}
			});
		}

		addListener("onErrorAbreNaoFiscal", listener);
	}

	public void removeOnErrorAbreNaoFiscal(ACBrEventListener<ErrorEventObject> listener)
	{
		removeListener("onErrorAbreNaoFiscal", listener);

		if (!hasListeners("onErrorAbreNaoFiscal")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnErrorAbreNaoFiscal(getHandle(), null);
		}
	}

	private boolean onErrorAbreNaoFiscal()
	{
		ErrorEventObject e = new ErrorEventObject(this, false);
		notifyListeners("onErrorAbreNaoFiscal", e);

		return e.getTratado();
	}

	//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onErrorAbreRelatorioGerencial">
	public void addOnErrorAbreRelatorioGerencial(ACBrEventListener<ErrorRelatorioEventObject> listener)
	{
		if (!hasListeners("onErrorAbreRelatorioGerencial")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnErrorAbreRelatorioGerencial(getHandle(), new ACBrECFInterop.ErrorRelatorioCallback()
			{
				@Override
				public boolean invoke(int Indice)
				{
					return onErrorAbreRelatorioGerencial(Indice);
				}
			});
		}

		addListener("onErrorAbreRelatorioGerencial", listener);
	}

	public void removeOnErrorAbreRelatorioGerencial(ACBrEventListener<ErrorRelatorioEventObject> listener)
	{
		removeListener("onErrorAbreRelatorioGerencial", listener);

		if (!hasListeners("onErrorAbreRelatorioGerencial")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnErrorAbreRelatorioGerencial(getHandle(), null);
		}
	}

	private boolean onErrorAbreRelatorioGerencial(int Indice)
	{
		ErrorRelatorioEventObject e = new ErrorRelatorioEventObject(this, false, Indice);
		notifyListeners("onErrorAbreRelatorioGerencial", e);

		return e.getTratado();
	}

//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onErrorCancelaCupom">
	public void addOnErrorCancelaCupom(ACBrEventListener<ErrorEventObject> listener)
	{
		if (!hasListeners("onErrorCancelaCupom")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnErrorCancelaCupom(getHandle(), new ACBrECFInterop.ErrorCallback()
			{
				@Override
				public boolean invoke()
				{
					return onErrorCancelaCupom();
				}
			});
		}

		addListener("onErrorCancelaCupom", listener);
	}

	public void removeOnErrorCancelaCupom(ACBrEventListener<ErrorEventObject> listener)
	{
		removeListener("onErrorCancelaCupom", listener);

		if (!hasListeners("onErrorCancelaCupom")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnErrorCancelaCupom(getHandle(), null);
		}
	}

	private boolean onErrorCancelaCupom()
	{
		ErrorEventObject e = new ErrorEventObject(this, false);
		notifyListeners("onErrorCancelaCupom", e);

		return e.getTratado();
	}

	//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onErrorCancelaItemNaoFiscal">
	public void addOnErrorCancelaItemNaoFiscal(ACBrEventListener<ErrorEventObject> listener)
	{
		if (!hasListeners("onErrorCancelaItemNaoFiscal")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnErrorCancelaItemNaoFiscal(getHandle(), new ACBrECFInterop.ErrorCallback()
			{
				@Override
				public boolean invoke()
				{
					return onErrorCancelaItemNaoFiscal();
				}
			});
		}

		addListener("onErrorCancelaItemNaoFiscal", listener);
	}

	public void removeOnErrorCancelaItemNaoFiscal(ACBrEventListener<ErrorEventObject> listener)
	{
		removeListener("onErrorCancelaItemNaoFiscal", listener);

		if (!hasListeners("onErrorCancelaItemNaoFiscal")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnErrorCancelaItemNaoFiscal(getHandle(), null);
		}
	}

	private boolean onErrorCancelaItemNaoFiscal()
	{
		ErrorEventObject e = new ErrorEventObject(this, false);
		notifyListeners("onErrorCancelaItemNaoFiscal", e);

		return e.getTratado();
	}

	//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onErrorCancelaItemVendido">
	public void addOnErrorCancelaItemVendido(ACBrEventListener<ErrorEventObject> listener)
	{
		if (!hasListeners("onErrorCancelaItemVendido")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnErrorCancelaItemVendido(getHandle(), new ACBrECFInterop.ErrorCallback()
			{
				@Override
				public boolean invoke()
				{
					return onErrorCancelaItemVendido();
				}
			});
		}

		addListener("onErrorCancelaItemVendido", listener);
	}

	public void removeOnErrorCancelaItemVendido(ACBrEventListener<ErrorEventObject> listener)
	{
		removeListener("onErrorCancelaItemVendido", listener);

		if (!hasListeners("onErrorCancelaItemVendido")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnErrorCancelaItemVendido(getHandle(), null);
		}
	}

	private boolean onErrorCancelaItemVendido()
	{
		ErrorEventObject e = new ErrorEventObject(this, false);
		notifyListeners("onErrorCancelaItemVendido", e);

		return e.getTratado();
	}

//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onErrorCancelaNaoFiscal">
	public void addOnErrorCancelaNaoFiscal(ACBrEventListener<ErrorEventObject> listener)
	{
		if (!hasListeners("onErrorCancelaNaoFiscal")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnErrorCancelaNaoFiscal(getHandle(), new ACBrECFInterop.ErrorCallback()
			{
				@Override
				public boolean invoke()
				{
					return onErrorCancelaNaoFiscal();
				}
			});
		}

		addListener("onErrorCancelaNaoFiscal", listener);
	}

	public void removeOnErrorCancelaNaoFiscal(ACBrEventListener<ErrorEventObject> listener)
	{
		removeListener("onErrorCancelaNaoFiscal", listener);

		if (!hasListeners("onErrorCancelaNaoFiscal")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnErrorCancelaNaoFiscal(getHandle(), null);
		}
	}

	private boolean onErrorCancelaNaoFiscal()
	{
		ErrorEventObject e = new ErrorEventObject(this, false);
		notifyListeners("onErrorCancelaNaoFiscal", e);

		return e.getTratado();
	}

	//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onErrorEfetuaPagamento">
	public void addOnErrorEfetuaPagamento(ACBrEventListener<ErrorEventObject> listener)
	{
		if (!hasListeners("onErrorEfetuaPagamento")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnErrorEfetuaPagamento(getHandle(), new ACBrECFInterop.ErrorCallback()
			{
				@Override
				public boolean invoke()
				{
					return onErrorEfetuaPagamento();
				}
			});
		}

		addListener("onErrorEfetuaPagamento", listener);
	}

	public void removeOnErrorEfetuaPagamento(ACBrEventListener<ErrorEventObject> listener)
	{
		removeListener("onErrorEfetuaPagamento", listener);

		if (!hasListeners("onErrorEfetuaPagamento")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnErrorEfetuaPagamento(getHandle(), null);
		}
	}

	private boolean onErrorEfetuaPagamento()
	{
		ErrorEventObject e = new ErrorEventObject(this, false);
		notifyListeners("onErrorEfetuaPagamento", e);

		return e.getTratado();
	}

//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onErrorEfetuaPagamentoNaoFiscal">
	public void addOnErrorEfetuaPagamentoNaoFiscal(ACBrEventListener<ErrorEventObject> listener)
	{
		if (!hasListeners("onErrorEfetuaPagamentoNaoFiscal")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnErrorEfetuaPagamentoNaoFiscal(getHandle(), new ACBrECFInterop.ErrorCallback()
			{
				@Override
				public boolean invoke()
				{
					return onErrorEfetuaPagamentoNaoFiscal();
				}
			});
		}

		addListener("onErrorEfetuaPagamentoNaoFiscal", listener);
	}

	public void removeOnErrorEfetuaPagamentoNaoFiscal(ACBrEventListener<ErrorEventObject> listener)
	{
		removeListener("onErrorEfetuaPagamentoNaoFiscal", listener);

		if (!hasListeners("onErrorEfetuaPagamentoNaoFiscal")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnErrorEfetuaPagamentoNaoFiscal(getHandle(), null);
		}
	}

	private boolean onErrorEfetuaPagamentoNaoFiscal()
	{
		ErrorEventObject e = new ErrorEventObject(this, false);
		notifyListeners("onErrorEfetuaPagamentoNaoFiscal", e);

		return e.getTratado();
	}

//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onErrorFechaCupom">
	public void addOnErrorFechaCupom(ACBrEventListener<ErrorEventObject> listener)
	{
		if (!hasListeners("onErrorFechaCupom")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnErrorFechaCupom(getHandle(), new ACBrECFInterop.ErrorCallback()
			{
				@Override
				public boolean invoke()
				{
					return onErrorFechaCupom();
				}
			});
		}

		addListener("onErrorFechaCupom", listener);
	}

	public void removeOnErrorFechaCupom(ACBrEventListener<ErrorEventObject> listener)
	{
		removeListener("onErrorFechaCupom", listener);

		if (!hasListeners("onErrorFechaCupom")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnErrorFechaCupom(getHandle(), null);
		}
	}

	private boolean onErrorFechaCupom()
	{
		ErrorEventObject e = new ErrorEventObject(this, false);
		notifyListeners("onErrorFechaCupom", e);

		return e.getTratado();
	}

//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onErrorFechaNaoFiscal">
	public void addOnErrorFechaNaoFiscal(ACBrEventListener<ErrorEventObject> listener)
	{
		if (!hasListeners("onErrorFechaNaoFiscal")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnErrorFechaNaoFiscal(getHandle(), new ACBrECFInterop.ErrorCallback()
			{
				@Override
				public boolean invoke()
				{
					return onErrorFechaNaoFiscal();
				}
			});
		}

		addListener("onErrorFechaNaoFiscal", listener);
	}

	public void removeOnErrorFechaNaoFiscal(ACBrEventListener<ErrorEventObject> listener)
	{
		removeListener("onErrorFechaNaoFiscal", listener);

		if (!hasListeners("onErrorFechaNaoFiscal")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnErrorFechaNaoFiscal(getHandle(), null);
		}
	}

	private boolean onErrorFechaNaoFiscal()
	{
		ErrorEventObject e = new ErrorEventObject(this, false);
		notifyListeners("onErrorFechaNaoFiscal", e);

		return e.getTratado();
	}

//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onErrorFechaRelatorio">
	public void addOnErrorFechaRelatorio(ACBrEventListener<ErrorEventObject> listener)
	{
		if (!hasListeners("onErrorFechaRelatorio")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnErrorFechaRelatorio(getHandle(), new ACBrECFInterop.ErrorCallback()
			{
				@Override
				public boolean invoke()
				{
					return onErrorFechaRelatorio();
				}
			});
		}

		addListener("onErrorFechaRelatorio", listener);
	}

	public void removeOnErrorFechaRelatorio(ACBrEventListener<ErrorEventObject> listener)
	{
		removeListener("onErrorFechaRelatorio", listener);

		if (!hasListeners("onErrorFechaRelatorio")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnErrorFechaRelatorio(getHandle(), null);
		}
	}

	private boolean onErrorFechaRelatorio()
	{
		ErrorEventObject e = new ErrorEventObject(this, false);
		notifyListeners("onErrorFechaRelatorio", e);

		return e.getTratado();
	}

//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onErrorLeituraX">
	public void addOnErrorLeituraX(ACBrEventListener<ErrorEventObject> listener)
	{
		if (!hasListeners("onErrorLeituraX")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnErrorLeituraX(getHandle(), new ACBrECFInterop.ErrorCallback()
			{
				@Override
				public boolean invoke()
				{
					return onErrorLeituraX();
				}
			});
		}

		addListener("onErrorLeituraX", listener);
	}

	public void removeOnErrorLeituraX(ACBrEventListener<ErrorEventObject> listener)
	{
		removeListener("onErrorLeituraX", listener);

		if (!hasListeners("onErrorLeituraX")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnErrorLeituraX(getHandle(), null);
		}
	}

	private boolean onErrorLeituraX()
	{
		ErrorEventObject e = new ErrorEventObject(this, false);
		notifyListeners("onErrorLeituraX", e);

		return e.getTratado();
	}

//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onErrorReducaoZ">
	public void addOnErrorReducaoZ(ACBrEventListener<ErrorEventObject> listener)
	{
		if (!hasListeners("onErrorReducaoZ")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnErrorReducaoZ(getHandle(), new ACBrECFInterop.ErrorCallback()
			{
				@Override
				public boolean invoke()
				{
					return onErrorReducaoZ();
				}
			});
		}

		addListener("onErrorReducaoZ", listener);
	}

	public void removeOnErrorReducaoZ(ACBrEventListener<ErrorEventObject> listener)
	{
		removeListener("onErrorReducaoZ", listener);

		if (!hasListeners("onErrorReducaoZ")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnErrorReducaoZ(getHandle(), null);
		}
	}

	private boolean onErrorReducaoZ()
	{
		ErrorEventObject e = new ErrorEventObject(this, false);
		notifyListeners("onErrorReducaoZ", e);

		return e.getTratado();
	}

//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onErrorSangria">
	public void addOnErrorSangria(ACBrEventListener<ErrorEventObject> listener)
	{
		if (!hasListeners("onErrorSangria")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnErrorSangria(getHandle(), new ACBrECFInterop.ErrorCallback()
			{
				@Override
				public boolean invoke()
				{
					return onErrorSangria();
				}
			});
		}

		addListener("onErrorSangria", listener);
	}

	public void removeOnErrorSangria(ACBrEventListener<ErrorEventObject> listener)
	{
		removeListener("onErrorSangria", listener);

		if (!hasListeners("onErrorSangria")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnErrorSangria(getHandle(), null);
		}
	}

	private boolean onErrorSangria()
	{
		ErrorEventObject e = new ErrorEventObject(this, false);
		notifyListeners("onErrorSangria", e);

		return e.getTratado();
	}

//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onErrorSemPapel">
	public void addOnErrorSemPapel(ACBrEventListener<EventObject> listener)
	{
		if (!hasListeners("onErrorSemPapel")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnErrorSemPapel(getHandle(), new ACBrECFInterop.Callback()
			{
				@Override
				public void invoke()
				{
					onErrorSemPapel();
				}
			});
		}

		addListener("onErrorSemPapel", listener);
	}

	public void removeOnErrorSemPapel(ACBrEventListener<EventObject> listener)
	{
		removeListener("onErrorSemPapel", listener);

		if (!hasListeners("onErrorSemPapel")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnErrorSemPapel(getHandle(), null);
		}
	}

	private void onErrorSemPapel()
	{
		EventObject e = new EventObject(this);
		notifyListeners("onErrorSemPapel", e);
	}

//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onErrorSubtotalizaCupom">
	public void addOnErrorSubtotalizaCupom(ACBrEventListener<ErrorEventObject> listener)
	{
		if (!hasListeners("onErrorSubtotalizaCupom")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnErrorSubtotalizaCupom(getHandle(), new ACBrECFInterop.ErrorCallback()
			{
				@Override
				public boolean invoke()
				{
					return onErrorSubtotalizaCupom();
				}
			});
		}

		addListener("onErrorSubtotalizaCupom", listener);
	}

	public void removeOnErrorSubtotalizaCupom(ACBrEventListener<ErrorEventObject> listener)
	{
		removeListener("onErrorSubtotalizaCupom", listener);

		if (!hasListeners("onErrorSubtotalizaCupom")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnErrorSubtotalizaCupom(getHandle(), null);
		}
	}

	private boolean onErrorSubtotalizaCupom()
	{
		ErrorEventObject e = new ErrorEventObject(this, false);
		notifyListeners("onErrorSubtotalizaCupom", e);

		return e.getTratado();
	}

//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onErrorSubtotalizaNaoFiscal">
	public void addOnErrorSubtotalizaNaoFiscal(ACBrEventListener<ErrorEventObject> listener)
	{
		if (!hasListeners("onErrorSubtotalizaNaoFiscal")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnErrorSubtotalizaNaoFiscal(getHandle(), new ACBrECFInterop.ErrorCallback()
			{
				@Override
				public boolean invoke()
				{
					return onErrorSubtotalizaNaoFiscal();
				}
			});
		}

		addListener("onErrorSubtotalizaNaoFiscal", listener);
	}

	public void removeOnErrorSubtotalizaNaoFiscal(ACBrEventListener<ErrorEventObject> listener)
	{
		removeListener("onErrorSubtotalizaNaoFiscal", listener);

		if (!hasListeners("onErrorSubtotalizaNaoFiscal")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnErrorSubtotalizaNaoFiscal(getHandle(), null);
		}
	}

	private boolean onErrorSubtotalizaNaoFiscal()
	{
		ErrorEventObject e = new ErrorEventObject(this, false);
		notifyListeners("onErrorSubtotalizaNaoFiscal", e);

		return e.getTratado();
	}

//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onErrorSuprimento">
	public void addOnErrorSuprimento(ACBrEventListener<ErrorEventObject> listener)
	{
		if (!hasListeners("onErrorSuprimento")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnErrorSuprimento(getHandle(), new ACBrECFInterop.ErrorCallback()
			{
				@Override
				public boolean invoke()
				{
					return onErrorSuprimento();
				}
			});
		}

		addListener("onErrorSuprimento", listener);
	}

	public void removeOnErrorSuprimento(ACBrEventListener<ErrorEventObject> listener)
	{
		removeListener("onErrorSuprimento", listener);

		if (!hasListeners("onErrorSuprimento")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnErrorSuprimento(getHandle(), null);
		}
	}

	private boolean onErrorSuprimento()
	{
		ErrorEventObject e = new ErrorEventObject(this, false);
		notifyListeners("onErrorSuprimento", e);

		return e.getTratado();
	}

//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onErrorVendeItem">
	public void addOnErrorVendeItem(ACBrEventListener<ErrorEventObject> listener)
	{
		if (!hasListeners("onErrorVendeItem")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnErrorVendeItem(getHandle(), new ACBrECFInterop.ErrorCallback()
			{
				@Override
				public boolean invoke()
				{
					return onErrorVendeItem();
				}
			});
		}

		addListener("onErrorVendeItem", listener);
	}

	public void removeOnErrorVendeItem(ACBrEventListener<ErrorEventObject> listener)
	{
		removeListener("onErrorVendeItem", listener);

		if (!hasListeners("onErrorVendeItem")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnErrorVendeItem(getHandle(), null);
		}
	}

	private boolean onErrorVendeItem()
	{
		ErrorEventObject e = new ErrorEventObject(this, false);
		notifyListeners("onErrorVendeItem", e);

		return e.getTratado();
	}

//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onMsgAguarde">
	public void addOnMsgAguarde(ACBrEventListener<MsgEventObject> listener)
	{
		if (!hasListeners("onMsgAguarde")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnMsgAguarde(getHandle(), new ACBrECFInterop.MsgCallback()
			{
				@Override
				public void invoke(String Mensagem)
				{
					onMsgAguarde(toUTF8(Mensagem));
				}
			});
		}

		addListener("onMsgAguarde", listener);
	}

	public void removeOnMsgAguarde(ACBrEventListener<MsgEventObject> listener)
	{
		removeListener("onMsgAguarde", listener);

		if (!hasListeners("onMsgAguarde")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnMsgAguarde(getHandle(), null);
		}
	}

	private void onMsgAguarde(String Mensagem)
	{
		MsgEventObject e = new MsgEventObject(this, Mensagem);
		notifyListeners("onMsgAguarde", e);
	}

//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onMsgRetentar">
	public void addOnMsgRetentar(ACBrEventListener<MsgRetentarEventObject> listener)
	{
		if (!hasListeners("onMsgRetentar")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnMsgRetentar(getHandle(), new ACBrECFInterop.MsgRetentarCallback()
			{
				@Override
				public boolean invoke(String Mensagem, String Situacao)
				{
					return onMsgRetentar(toUTF8(Mensagem), toUTF8(Situacao));
				}
			});
		}

		addListener("onMsgRetentar", listener);
	}

	public void removeOnMsgRetentar(ACBrEventListener<MsgRetentarEventObject> listener)
	{
		removeListener("onMsgRetentar", listener);

		if (!hasListeners("onMsgRetentar")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnMsgRetentar(getHandle(), null);
		}
	}

	private boolean onMsgRetentar(String Mensagem, String Situacao)
	{
		MsgRetentarEventObject e = new MsgRetentarEventObject(this, Mensagem, Situacao, false);
		notifyListeners("onMsgRetentar", e);

		return e.getResult();
	}

//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onPAFCalcEAD">
	public void addOnPAFCalcEAD(ACBrEventListener<PAFCalcEADEventObject> listener)
	{
		if (!hasListeners("onPAFCalcEAD")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnPAFCalcEAD(getHandle(), new ACBrECFInterop.PAFCalcEADCallback()
			{
				@Override
				public void invoke(String value)
				{
					onPAFCalcEAD(toUTF8(value));
				}
			});
		}

		addListener("onPAFCalcEAD", listener);
	}

	public void removeOnPAFCalcEAD(ACBrEventListener<PAFCalcEADEventObject> listener)
	{
		removeListener("onPAFCalcEAD", listener);

		if (!hasListeners("onPAFCalcEAD")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnPAFCalcEAD(getHandle(), null);
		}
	}

	private void onPAFCalcEAD(String value)
	{
		PAFCalcEADEventObject e = new PAFCalcEADEventObject(this, value);
		notifyListeners("onPAFCalcEAD", e);
	}

//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onPAFGetKeyRSA">
	public void addOnPAFGetKeyRSA(ACBrEventListener<ChaveEventObject> listener)
	{
		if (!hasListeners("onPAFGetKeyRSA")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnPAFGetKeyRSA(getHandle(), new ACBrECFInterop.ChaveCallback()
			{
				@Override
				public String invoke()
				{
					return onPAFGetKeyRSA();
				}
			});
		}

		addListener("onPAFGetKeyRSA", listener);
	}

	public void removeOnPAFGetKeyRSA(ACBrEventListener<ChaveEventObject> listener)
	{
		removeListener("onPAFGetKeyRSA", listener);

		if (!hasListeners("onPAFGetKeyRSA")) {
			ACBrECFInterop.INSTANCE.ECF_SetOnPAFGetKeyRSA(getHandle(), null);
		}
	}

	private String onPAFGetKeyRSA()
	{
		ChaveEventObject e = new ChaveEventObject(this, "");
		notifyListeners("onPAFGetKeyRSA", e);

		return e.getChave();
	}

//</editor-fold>
	//</editor-fold>
	
	//<editor-fold defaultstate="collapsed" desc="Component Properties">
	
	public ACBrDevice getDevice()
	{
		return this.device;
	}

	public FormaPagamento[] getFormasPagamento() throws ACBrException
	{
		return formasPagamento;
	}

	public void carregaFormasPagamento() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_CarregaFormasPagamento(getHandle());
		checkResult(ret);

		carregaFormasPagamento(ret);

	}

	public void lerTotaisFormaPagamento() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_LerTotaisFormaPagamento(getHandle());
		checkResult(ret);

		carregaFormasPagamento(ret);

	}

	public void lerTotaisAliquota() throws ACBrException
	{
		int ret = ACBrECFInterop.INSTANCE.ECF_LerTotaisAliquota(getHandle());
		checkResult(ret);

		carregaAliquotas(ret);
	}

	public void carregaAliquotas() throws ACBrException
	{
		int ret = ACBrECFInterop.INSTANCE.ECF_CarregaAliquotas(getHandle());
		checkResult(ret);

		carregaAliquotas(ret);
	}

	private void carregaAliquotas(int count) throws ACBrException
	{

		Aliquota[] array = new Aliquota[count];
		for (int i = 0; i < count; i++) 
		{
			ACBrECFInterop.AliquotaRec record = new ACBrECFInterop.AliquotaRec();
			int ret = ACBrECFInterop.INSTANCE.ECF_GetAliquota(getHandle(), record, i);
			checkResult(ret);

			Aliquota item = new Aliquota(fromUTF8(record.Indice), record.Aliquota, record.Tipo, record.Total, record.Sequencia);
			array[i] = item;
		}

		this.aliquotas = array;

	}	
	
	public Aliquota[] getAliquotas() throws ACBrException
	{
		return aliquotas;
	}

	//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="Properties">
	public int getModelo() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_GetModelo(getHandle());
		checkResult(ret);

		return ret;
	}

	public void setModelo(int value) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_SetModelo(getHandle(), value);
		checkResult(ret);

	}

	public int getMaxLinhasBuffer() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_GetMaxLinhasBuffer(getHandle());
		checkResult(ret);

		return ret;
	}

	public void setMaxLinhasBuffer(int value) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_SetMaxLinhasBuffer(getHandle(), value);
		checkResult(ret);

	}

	public boolean getDescricaoGrande() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_GetDescricaoGrande(getHandle());
		checkResult(ret);

		return ret != 0;
	}

	public void setDescricaoGrande(boolean value) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_SetDescricaoGrande(getHandle(), value);
		checkResult(ret);

	}

	public boolean getGavetaSinalInvertido() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_GetGavetaSinalInvertido(getHandle());
		checkResult(ret);

		return ret != 0;
	}

	public void setGavetaSinalInvertido(boolean value) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_SetGavetaSinalInvertido(getHandle(), value);
		checkResult(ret);

	}

	public boolean getArredondaPorQtd() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_GetArredondaPorQtd(getHandle());
		checkResult(ret);

		return ret != 0;
	}

	public void setArredondaPorQtd(boolean value) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_SetArredondaPorQtd(getHandle(), value);
		checkResult(ret);

	}

	public boolean getArredondaItemMFD() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_GetArredondaItemMFD(getHandle());
		checkResult(ret);

		return ret != 0;
	}

	public void setArredondaItemMFD(boolean value) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_SetArredondaItemMFD(getHandle(), value);
		checkResult(ret);

	}

	public boolean getIgnorarTagsFormatacao() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_GetIgnorarTagsFormatacao(getHandle());
		checkResult(ret);

		return ret != 0;
	}

	public void setIgnorarTagsFormatacao(boolean value) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_SetIgnorarTagsFormatacao(getHandle(), value);
		checkResult(ret);

	}

	public int getPausaRelatorio() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_GetPausaRelatorio(getHandle());
		checkResult(ret);

		return ret;
	}

	public void setPausaRelatorio(int value) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_SetPausaRelatorio(getHandle(), value);
		checkResult(ret);

	}

	public int getPaginaDeCodigo() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_GetPaginaDeCodigo(getHandle());
		checkResult(ret);

		return ret;
	}

	public void setPaginaDeCodigo(int value) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_SetPaginaDeCodigo(getHandle(), value);
		checkResult(ret);

	}

	public String getAbout() throws ACBrException
	{

		ByteBuffer returnBuffer = ByteBuffer.allocate(STR_BUFFER_LEN);
		int ret = ACBrECFInterop.INSTANCE.ECF_GetAbout(getHandle(), returnBuffer, STR_BUFFER_LEN);
		checkResult(ret);

		return fromUTF8(returnBuffer, ret);
	}

	public String getArqLOG() throws ACBrException
	{

		ByteBuffer returnBuffer = ByteBuffer.allocate(STR_BUFFER_LEN);
		int ret = ACBrECFInterop.INSTANCE.ECF_GetArqLOG(getHandle(), returnBuffer, STR_BUFFER_LEN);
		checkResult(ret);

		return fromUTF8(returnBuffer, ret);
	}

	public void setArqLOG(String value) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_SetArqLOG(getHandle(), toUTF8(value));
		checkResult(ret);

	}

	public String getOperador() throws ACBrException
	{

		ByteBuffer returnBuffer = ByteBuffer.allocate(STR_BUFFER_LEN);
		int ret = ACBrECFInterop.INSTANCE.ECF_GetOperador(getHandle(), returnBuffer, STR_BUFFER_LEN);
		checkResult(ret);

		return fromUTF8(returnBuffer, ret);
	}

	public void setOperador(String value) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_SetOperador(getHandle(), toUTF8(value));
		checkResult(ret);

	}

	public String[] getMemoParams() throws ACBrException
	{

		int count = ACBrECFInterop.INSTANCE.ECF_GetMemoParamsCount(getHandle());
		checkResult(count);

		String[] array = new String[count];
		for (int i = 0; i < array.length; i++) {
			ByteBuffer returnBuffer = ByteBuffer.allocate(STR_BUFFER_LEN);
			int ret = ACBrECFInterop.INSTANCE.ECF_GetMemoParams(getHandle(), returnBuffer, STR_BUFFER_LEN, i);
			checkResult(ret);

			array[i] = fromUTF8(returnBuffer, ret);
		}

		return array;
	}

	public void setMemoParams(String[] value) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_SetMemoParams(getHandle(), toUTF8(value), value.length);
		checkResult(ret);

	}

	public int getLinhasEntreCupons() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_GetLinhasEntreCupons(getHandle());
		checkResult(ret);

		return ret;
	}

	public void setLinhasEntreCupons(int value) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_SetLinhasEntreCupons(getHandle(), value);
		checkResult(ret);

	}

	public int getDecimaisPreco() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_GetDecimaisPreco(getHandle());
		checkResult(ret);

		return ret;
	}

	public void setDecimaisPreco(int value) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_SetDecimaisPreco(getHandle(), value);
		checkResult(ret);

	}

	public int getDecimaisQtd() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_GetDecimaisQtd(getHandle());
		checkResult(ret);

		return ret;
	}

	public void setDecimaisQtd(int value) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_SetDecimaisQtd(getHandle(), value);
		checkResult(ret);

	}

	/*public Rodape getInfoRodapeCupom() throws ACBrException
	 * {
	 * //NotImplemented
	 * }
	 * 
	 * public ConfigBarras getConfigBarras() throws ACBrException
	 * {
	 * //NotImplemented
	 * }
	 * 
	 * public ACBrAAC getAAC() throws ACBrException
	 * {
	 * //NotImplemented
	 * }
	 * 
	 * public void setAAC(ACBrAAC value) throws ACBrException
	 * {
	 * 
	 * 
	 * int ret = ACBrECFInterop.INSTANCE.ECF_SetAAC(getHandle(), value);
	 * checkResult(ret);
	 * 
	 * }
	 * 
	 * public ACBrEAD getEAD() throws ACBrException
	 * {
	 * //NotImplemented
	 * }
	 * 
	 * public void setEAD(ACBrEAD value) throws ACBrException
	 * {
	 * 
	 * 
	 * int ret = ACBrECFInterop.INSTANCE.ECF_SetEAD(getHandle(), value);
	 * checkResult(ret);
	 * 
	 * }
	 * 
	 * public ACBrRFD getRFD() throws ACBrException
	 * {
	 * //NotImplemented
	 * }
	 * 
	 * public void setRFD(ACBrRFD value) throws ACBrException
	 * {
	 * 
	 * 
	 * int ret = ACBrECFInterop.INSTANCE.ECF_SetRFD(getHandle(), value);
	 * checkResult(ret);
	 * 
	 * }*/
	public boolean getAtivo() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_GetAtivo(getHandle());
		checkResult(ret);

		return ret != 0;
	}

	public int getColunas() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_GetColunas(getHandle());
		checkResult(ret);

		return ret;
	}

	public boolean getAguardandoResposta() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_GetAguardandoResposta(getHandle());
		checkResult(ret);

		return ret != 0;
	}

	public String getComandoLog() throws ACBrException
	{

		ByteBuffer returnBuffer = ByteBuffer.allocate(STR_BUFFER_LEN);
		int ret = ACBrECFInterop.INSTANCE.ECF_GetComandoLog(getHandle(), returnBuffer, STR_BUFFER_LEN);
		checkResult(ret);

		return fromUTF8(returnBuffer, ret);
	}

	public void setComandoLog(String value) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_SetComandoLog(getHandle(), toUTF8(value));
		checkResult(ret);

	}

	public boolean getAguardaImpressao() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_GetAguardaImpressao(getHandle());
		checkResult(ret);

		return ret != 0;
	}

	public void setAguardaImpressao(boolean value) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_SetAguardaImpressao(getHandle(), value);
		checkResult(ret);

	}

	public String getModeloStr() throws ACBrException
	{

		ByteBuffer returnBuffer = ByteBuffer.allocate(STR_BUFFER_LEN);
		int ret = ACBrECFInterop.INSTANCE.ECF_GetModeloStr(getHandle(), returnBuffer, STR_BUFFER_LEN);
		checkResult(ret);

		return fromUTF8(returnBuffer, ret);
	}

	public String getRFDID() throws ACBrException
	{

		ByteBuffer returnBuffer = ByteBuffer.allocate(STR_BUFFER_LEN);
		int ret = ACBrECFInterop.INSTANCE.ECF_GetRFDID(getHandle(), returnBuffer, STR_BUFFER_LEN);
		checkResult(ret);

		return fromUTF8(returnBuffer, ret);
	}

	public Date getDataHora() throws ACBrException
	{

		DoubleByReference returnValue = new DoubleByReference();
		int ret = ACBrECFInterop.INSTANCE.ECF_GetDataHora(getHandle(), returnValue);
		checkResult(ret);

		return OleDate.fromOADate(returnValue.getValue());
	}

	public String getNumCupom() throws ACBrException
	{

		ByteBuffer returnBuffer = ByteBuffer.allocate(STR_BUFFER_LEN);
		int ret = ACBrECFInterop.INSTANCE.ECF_GetNumCupom(getHandle(), returnBuffer, STR_BUFFER_LEN);
		checkResult(ret);

		return fromUTF8(returnBuffer, ret);
	}

	public String getNumCOO() throws ACBrException
	{

		ByteBuffer returnBuffer = ByteBuffer.allocate(STR_BUFFER_LEN);
		int ret = ACBrECFInterop.INSTANCE.ECF_GetNumCOO(getHandle(), returnBuffer, STR_BUFFER_LEN);
		checkResult(ret);

		return fromUTF8(returnBuffer, ret);
	}

	public String getNumLoja() throws ACBrException
	{

		ByteBuffer returnBuffer = ByteBuffer.allocate(STR_BUFFER_LEN);
		int ret = ACBrECFInterop.INSTANCE.ECF_GetNumLoja(getHandle(), returnBuffer, STR_BUFFER_LEN);
		checkResult(ret);

		return fromUTF8(returnBuffer, ret);
	}

	public String getNumECF() throws ACBrException
	{

		ByteBuffer returnBuffer = ByteBuffer.allocate(STR_BUFFER_LEN);
		int ret = ACBrECFInterop.INSTANCE.ECF_GetNumECF(getHandle(), returnBuffer, STR_BUFFER_LEN);
		checkResult(ret);

		return fromUTF8(returnBuffer, ret);
	}

	public String getNumSerie() throws ACBrException
	{

		ByteBuffer returnBuffer = ByteBuffer.allocate(STR_BUFFER_LEN);
		int ret = ACBrECFInterop.INSTANCE.ECF_GetNumSerie(getHandle(), returnBuffer, STR_BUFFER_LEN);
		checkResult(ret);

		return fromUTF8(returnBuffer, ret);
	}

	public String getNumSerieMFD() throws ACBrException
	{

		ByteBuffer returnBuffer = ByteBuffer.allocate(STR_BUFFER_LEN);
		int ret = ACBrECFInterop.INSTANCE.ECF_GetNumSerieMFD(getHandle(), returnBuffer, STR_BUFFER_LEN);
		checkResult(ret);

		return fromUTF8(returnBuffer, ret);
	}

	public String getNumVersao() throws ACBrException
	{

		ByteBuffer returnBuffer = ByteBuffer.allocate(STR_BUFFER_LEN);
		int ret = ACBrECFInterop.INSTANCE.ECF_GetNumVersao(getHandle(), returnBuffer, STR_BUFFER_LEN);
		checkResult(ret);

		return fromUTF8(returnBuffer, ret);
	}

	public Date getDataMovimento() throws ACBrException
	{

		DoubleByReference returnValue = new DoubleByReference();
		int ret = ACBrECFInterop.INSTANCE.ECF_GetDataMovimento(getHandle(), returnValue);
		checkResult(ret);

		return OleDate.fromOADate(returnValue.getValue());
	}

	public Date getDataHoraSB() throws ACBrException
	{

		DoubleByReference returnValue = new DoubleByReference();
		int ret = ACBrECFInterop.INSTANCE.ECF_GetDataHoraSB(getHandle(), returnValue);
		checkResult(ret);

		return OleDate.fromOADate(returnValue.getValue());
	}

	public String getCNPJ() throws ACBrException
	{

		ByteBuffer returnBuffer = ByteBuffer.allocate(STR_BUFFER_LEN);
		int ret = ACBrECFInterop.INSTANCE.ECF_GetCNPJ(getHandle(), returnBuffer, STR_BUFFER_LEN);
		checkResult(ret);

		return fromUTF8(returnBuffer, ret);
	}

	public String getIE() throws ACBrException
	{

		ByteBuffer returnBuffer = ByteBuffer.allocate(STR_BUFFER_LEN);
		int ret = ACBrECFInterop.INSTANCE.ECF_GetIE(getHandle(), returnBuffer, STR_BUFFER_LEN);
		checkResult(ret);

		return fromUTF8(returnBuffer, ret);
	}

	public String getIM() throws ACBrException
	{

		ByteBuffer returnBuffer = ByteBuffer.allocate(STR_BUFFER_LEN);
		int ret = ACBrECFInterop.INSTANCE.ECF_GetIM(getHandle(), returnBuffer, STR_BUFFER_LEN);
		checkResult(ret);

		return fromUTF8(returnBuffer, ret);
	}

	public String getCliche() throws ACBrException
	{

		ByteBuffer returnBuffer = ByteBuffer.allocate(STR_BUFFER_LEN);
		int ret = ACBrECFInterop.INSTANCE.ECF_GetCliche(getHandle(), returnBuffer, STR_BUFFER_LEN);
		checkResult(ret);

		return fromUTF8(returnBuffer, ret);
	}

	public String getUsuarioAtual() throws ACBrException
	{

		ByteBuffer returnBuffer = ByteBuffer.allocate(STR_BUFFER_LEN);
		int ret = ACBrECFInterop.INSTANCE.ECF_GetUsuarioAtual(getHandle(), returnBuffer, STR_BUFFER_LEN);
		checkResult(ret);

		return fromUTF8(returnBuffer, ret);
	}

	public String getSubModeloECF() throws ACBrException
	{

		ByteBuffer returnBuffer = ByteBuffer.allocate(STR_BUFFER_LEN);
		int ret = ACBrECFInterop.INSTANCE.ECF_GetSubModeloECF(getHandle(), returnBuffer, STR_BUFFER_LEN);
		checkResult(ret);

		return fromUTF8(returnBuffer, ret);
	}

	public String getPAF() throws ACBrException
	{

		ByteBuffer returnBuffer = ByteBuffer.allocate(STR_BUFFER_LEN);
		int ret = ACBrECFInterop.INSTANCE.ECF_GetPAF(getHandle(), returnBuffer, STR_BUFFER_LEN);
		checkResult(ret);

		return fromUTF8(returnBuffer, ret);
	}

	public String getNumCRZ() throws ACBrException
	{

		ByteBuffer returnBuffer = ByteBuffer.allocate(STR_BUFFER_LEN);
		int ret = ACBrECFInterop.INSTANCE.ECF_GetNumCRZ(getHandle(), returnBuffer, STR_BUFFER_LEN);
		checkResult(ret);

		return fromUTF8(returnBuffer, ret);
	}

	public String getNumCRO() throws ACBrException
	{

		ByteBuffer returnBuffer = ByteBuffer.allocate(STR_BUFFER_LEN);
		int ret = ACBrECFInterop.INSTANCE.ECF_GetNumCRO(getHandle(), returnBuffer, STR_BUFFER_LEN);
		checkResult(ret);

		return fromUTF8(returnBuffer, ret);
	}

	public String getNumCCF() throws ACBrException
	{

		ByteBuffer returnBuffer = ByteBuffer.allocate(STR_BUFFER_LEN);
		int ret = ACBrECFInterop.INSTANCE.ECF_GetNumCCF(getHandle(), returnBuffer, STR_BUFFER_LEN);
		checkResult(ret);

		return fromUTF8(returnBuffer, ret);
	}

	public String getNumGNF() throws ACBrException
	{

		ByteBuffer returnBuffer = ByteBuffer.allocate(STR_BUFFER_LEN);
		int ret = ACBrECFInterop.INSTANCE.ECF_GetNumGNF(getHandle(), returnBuffer, STR_BUFFER_LEN);
		checkResult(ret);

		return fromUTF8(returnBuffer, ret);
	}

	public String getNumGRG() throws ACBrException
	{

		ByteBuffer returnBuffer = ByteBuffer.allocate(STR_BUFFER_LEN);
		int ret = ACBrECFInterop.INSTANCE.ECF_GetNumGRG(getHandle(), returnBuffer, STR_BUFFER_LEN);
		checkResult(ret);

		return fromUTF8(returnBuffer, ret);
	}

	public String getNumCDC() throws ACBrException
	{

		ByteBuffer returnBuffer = ByteBuffer.allocate(STR_BUFFER_LEN);
		int ret = ACBrECFInterop.INSTANCE.ECF_GetNumCDC(getHandle(), returnBuffer, STR_BUFFER_LEN);
		checkResult(ret);

		return fromUTF8(returnBuffer, ret);
	}

	public String getNumCOOInicial() throws ACBrException
	{

		ByteBuffer returnBuffer = ByteBuffer.allocate(STR_BUFFER_LEN);
		int ret = ACBrECFInterop.INSTANCE.ECF_GetNumCOOInicial(getHandle(), returnBuffer, STR_BUFFER_LEN);
		checkResult(ret);

		return fromUTF8(returnBuffer, ret);
	}

	public String getComandoEnviado() throws ACBrException
	{

		ByteBuffer returnBuffer = ByteBuffer.allocate(STR_BUFFER_LEN);
		int ret = ACBrECFInterop.INSTANCE.ECF_GetComandoEnviado(getHandle(), returnBuffer, STR_BUFFER_LEN);
		checkResult(ret);

		return fromUTF8(returnBuffer, ret);
	}

	public String getRespostaComando() throws ACBrException
	{

		ByteBuffer returnBuffer = ByteBuffer.allocate(STR_BUFFER_LEN);
		int ret = ACBrECFInterop.INSTANCE.ECF_GetRespostaComando(getHandle(), returnBuffer, STR_BUFFER_LEN);
		checkResult(ret);

		return fromUTF8(returnBuffer, ret);
	}

	public double getVendaBruta() throws ACBrException
	{

		DoubleByReference returnValue = new DoubleByReference();
		int ret = ACBrECFInterop.INSTANCE.ECF_GetVendaBruta(getHandle(), returnValue);
		checkResult(ret);

		return returnValue.getValue();
	}

	public double getGrandeTotal() throws ACBrException
	{

		DoubleByReference returnValue = new DoubleByReference();
		int ret = ACBrECFInterop.INSTANCE.ECF_GetGrandeTotal(getHandle(), returnValue);
		checkResult(ret);

		return returnValue.getValue();
	}

	public double getTotalCancelamentos() throws ACBrException
	{

		DoubleByReference returnValue = new DoubleByReference();
		int ret = ACBrECFInterop.INSTANCE.ECF_GetTotalCancelamentos(getHandle(), returnValue);
		checkResult(ret);

		return returnValue.getValue();
	}

	public double getTotalDescontos() throws ACBrException
	{

		DoubleByReference returnValue = new DoubleByReference();
		int ret = ACBrECFInterop.INSTANCE.ECF_GetTotalDescontos(getHandle(), returnValue);
		checkResult(ret);

		return returnValue.getValue();
	}

	public double getTotalAcrescimos() throws ACBrException
	{

		DoubleByReference returnValue = new DoubleByReference();
		int ret = ACBrECFInterop.INSTANCE.ECF_GetTotalAcrescimos(getHandle(), returnValue);
		checkResult(ret);

		return returnValue.getValue();
	}

	public double getTotalTroco() throws ACBrException
	{

		DoubleByReference returnValue = new DoubleByReference();
		int ret = ACBrECFInterop.INSTANCE.ECF_GetTotalTroco(getHandle(), returnValue);
		checkResult(ret);

		return returnValue.getValue();
	}

	public double getTotalSubstituicaoTributaria() throws ACBrException
	{

		DoubleByReference returnValue = new DoubleByReference();
		int ret = ACBrECFInterop.INSTANCE.ECF_GetTotalSubstituicaoTributaria(getHandle(), returnValue);
		checkResult(ret);

		return returnValue.getValue();
	}

	public double getTotalNaoTributado() throws ACBrException
	{

		DoubleByReference returnValue = new DoubleByReference();
		int ret = ACBrECFInterop.INSTANCE.ECF_GetTotalNaoTributado(getHandle(), returnValue);
		checkResult(ret);

		return returnValue.getValue();
	}

	public double getTotalIsencao() throws ACBrException
	{

		DoubleByReference returnValue = new DoubleByReference();
		int ret = ACBrECFInterop.INSTANCE.ECF_GetTotalIsencao(getHandle(), returnValue);
		checkResult(ret);

		return returnValue.getValue();
	}

	public double getTotalCancelamentosISSQN() throws ACBrException
	{

		DoubleByReference returnValue = new DoubleByReference();
		int ret = ACBrECFInterop.INSTANCE.ECF_GetTotalCancelamentosISSQN(getHandle(), returnValue);
		checkResult(ret);

		return returnValue.getValue();
	}

	public double getTotalDescontosISSQN() throws ACBrException
	{

		DoubleByReference returnValue = new DoubleByReference();
		int ret = ACBrECFInterop.INSTANCE.ECF_GetTotalDescontosISSQN(getHandle(), returnValue);
		checkResult(ret);

		return returnValue.getValue();
	}

	public double getTotalAcrescimosISSQN() throws ACBrException
	{

		DoubleByReference returnValue = new DoubleByReference();
		int ret = ACBrECFInterop.INSTANCE.ECF_GetTotalAcrescimosISSQN(getHandle(), returnValue);
		checkResult(ret);

		return returnValue.getValue();
	}

	public double getTotalSubstituicaoTributariaISSQN() throws ACBrException
	{

		DoubleByReference returnValue = new DoubleByReference();
		int ret = ACBrECFInterop.INSTANCE.ECF_GetTotalSubstituicaoTributariaISSQN(getHandle(), returnValue);
		checkResult(ret);

		return returnValue.getValue();
	}

	public double getTotalNaoTributadoISSQN() throws ACBrException
	{

		DoubleByReference returnValue = new DoubleByReference();
		int ret = ACBrECFInterop.INSTANCE.ECF_GetTotalNaoTributadoISSQN(getHandle(), returnValue);
		checkResult(ret);

		return returnValue.getValue();
	}

	public double getTotalIsencaoISSQN() throws ACBrException
	{

		DoubleByReference returnValue = new DoubleByReference();
		int ret = ACBrECFInterop.INSTANCE.ECF_GetTotalIsencaoISSQN(getHandle(), returnValue);
		checkResult(ret);

		return returnValue.getValue();
	}

	public double getTotalNaoFiscal() throws ACBrException
	{

		DoubleByReference returnValue = new DoubleByReference();
		int ret = ACBrECFInterop.INSTANCE.ECF_GetTotalNaoFiscal(getHandle(), returnValue);
		checkResult(ret);

		return returnValue.getValue();
	}

	public int getNumUltItem() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_GetNumUltItem(getHandle());
		checkResult(ret);

		return ret;
	}

	public boolean getPoucoPapel() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_GetPoucoPapel(getHandle());
		checkResult(ret);

		return ret != 0;
	}

	public int getEstado() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_GetEstado(getHandle());
		checkResult(ret);

		return ret;
	}

	public boolean getHorarioVerao() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_GetHorarioVerao(getHandle());
		checkResult(ret);

		return ret != 0;
	}

	public boolean getArredonda() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_GetArredonda(getHandle());
		checkResult(ret);

		return ret != 0;
	}

	public boolean getTermica() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_GetTermica(getHandle());
		checkResult(ret);

		return ret != 0;
	}

	public boolean getMFD() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_GetMFD(getHandle());
		checkResult(ret);

		return ret != 0;
	}

	public String getMFAdicional() throws ACBrException
	{

		ByteBuffer returnBuffer = ByteBuffer.allocate(STR_BUFFER_LEN);
		int ret = ACBrECFInterop.INSTANCE.ECF_GetMFAdicional(getHandle(), returnBuffer, STR_BUFFER_LEN);
		checkResult(ret);

		return fromUTF8(returnBuffer, ret);
	}

	public boolean getIdentificaConsumidorRodape() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_GetIdentificaConsumidorRodape(getHandle());
		checkResult(ret);

		return ret != 0;
	}

	public boolean getParamDescontoISSQN() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_GetParamDescontoISSQN(getHandle());
		checkResult(ret);

		return ret != 0;
	}

	public double getSubTotal() throws ACBrException
	{

		DoubleByReference returnValue = new DoubleByReference();
		int ret = ACBrECFInterop.INSTANCE.ECF_GetSubTotal(getHandle(), returnValue);
		checkResult(ret);

		return returnValue.getValue();
	}

	public double getTotalPago() throws ACBrException
	{

		DoubleByReference returnValue = new DoubleByReference();
		int ret = ACBrECFInterop.INSTANCE.ECF_GetTotalPago(getHandle(), returnValue);
		checkResult(ret);

		return returnValue.getValue();
	}

	public boolean getGavetaAberta() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_GetGavetaAberta(getHandle());
		checkResult(ret);

		return ret != 0;
	}

	public boolean getChequePronto() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_GetChequePronto(getHandle());
		checkResult(ret);

		return ret != 0;
	}

	public int getIntervaloAposComando() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_GetIntervaloAposComando(getHandle());
		checkResult(ret);

		return ret;
	}

	public void setIntervaloAposComando(int value) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_SetIntervaloAposComando(getHandle(), value);
		checkResult(ret);

	}

	/*public Aliquota[] getAliquotas() throws ACBrException
	 * {
	 * //NotImplemented
	 * }
	 * 
	 * public FormaPagamento[] getFormasPagamento() throws ACBrException
	 * {
	 * //NotImplemented
	 * }
	 * 
	 * public RelatorioGerencial[] getRelatoriosGerenciais() throws ACBrException
	 * {
	 * //NotImplemented
	 * }
	 * 
	 * public ComprovanteNaoFiscal[] getComprovantesNaoFiscais() throws ACBrException
	 * {
	 * //NotImplemented
	 * }
	 * 
	 * public Consumidor getConsumidor() throws ACBrException
	 * {
	 * //NotImplemented
	 * }
	 * 
	 * public DadosReducaoZClass getDadosReducaoZClass() throws ACBrException
	 * {
	 * //NotImplemented
	 * }*/
	//</editor-fold>	
	//<editor-fold defaultstate="collapsed" desc="Methods">
	//<editor-fold defaultstate="collapsed" desc="Override Methods">
	@Override
	protected void onInitialize() throws ACBrException
	{
		IntByReference handle = new IntByReference();
		int ret = ACBrECFInterop.INSTANCE.ECF_Create(handle);
		checkResult(ret);

		setHandle(handle.getValue());

		this.device = new ACBrDevice(this);
	}

	@Override
	protected void onFinalize() throws ACBrException
	{
		int ret = ACBrECFInterop.INSTANCE.ECF_Destroy(getHandle());
		checkResult(ret);

		setHandle(0);
	}

	@Override
	protected void checkResult(int result) throws ACBrException
	{
		switch (result) {
			case -1:
				String message;

				int LEN = 1024;
				ByteBuffer buffer = ByteBuffer.allocate(LEN);
				int ret = ACBrECFInterop.INSTANCE.ECF_GetUltimoErro(getHandle(), buffer, LEN);

				message = fromUTF8(buffer, ret);
				throw new ACBrException(message);


			case -2:
				throw new ACBrException("ACBr ECF não inicializado.");
		}
	}

	//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="Component Methods">
	public String leituraMemoriaFiscalSerial(Date dataInicial, Date dataFinal, boolean simplificada) throws ACBrException
	{

		ByteBuffer returnBuffer = ByteBuffer.allocate(STR_BUFFER_LEN);
		int ret = ACBrECFInterop.INSTANCE.ECF_LeituraMemoriaFiscalSerialData(getHandle(), OleDate.toOADate(dataInicial), OleDate.toOADate(dataFinal), simplificada, returnBuffer, STR_BUFFER_LEN);
		checkResult(ret);

		return fromUTF8(returnBuffer, ret);
	}

	public void leituraMemoriaFiscalSerial(int reducaoInicial, int reducaoFinal, String nomeArquivo, boolean simplificada) throws ACBrException
	{

		int ret = ACBrECFInterop.INSTANCE.ECF_LeituraMemoriaFiscalArquivoReducao(getHandle(), reducaoInicial, reducaoFinal, toUTF8(nomeArquivo), simplificada);
		checkResult(ret);


	}

	public void leituraMemoriaFiscalSerial(Date dataInicial, Date dataFinal, String nomeArquivo, boolean simplificada) throws ACBrException
	{
		int ret = ACBrECFInterop.INSTANCE.ECF_LeituraMemoriaFiscalArquivoData(getHandle(), OleDate.toOADate(dataInicial), OleDate.toOADate(dataFinal), toUTF8(nomeArquivo), simplificada);
		checkResult(ret);
	}

	public void abreCupomVinculado(int coo, String codFormaPagto, double valor) throws ACBrException
	{
		abreCupomVinculado(String.valueOf(coo), codFormaPagto, valor);
	}

	public void abreCupomVinculado(String coo, String codFormaPagto, double valor) throws ACBrException
	{
		int ret = ACBrECFInterop.INSTANCE.ECF_AbreCupomVinculado(getHandle(), toUTF8(coo), toUTF8(codFormaPagto), valor);
		checkResult(ret);
	}

	public void abreCupomVinculado(String coo, String codFormaPagto, String codComprovanteNaoFiscal, double valor) throws ACBrException
	{
		int ret = ACBrECFInterop.INSTANCE.ECF_AbreCupomVinculadoCNF(getHandle(), toUTF8(coo), toUTF8(codFormaPagto), toUTF8(codComprovanteNaoFiscal), valor);
		checkResult(ret);

	}

	public void linhaCupomVinculado(String linhas[]) throws ACBrException
	{
		for (int i = 0; i < linhas.length; i++) {
			linhaCupomVinculado(linhas[i]);
		}
	}

	public void linhaCupomVinculado(String linha) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_LinhaCupomVinculado(getHandle(), toUTF8(linha));
		checkResult(ret);


	}

	public void reimpressaoVinculado() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_ReimpressaoVinculado(getHandle());
		checkResult(ret);


	}

	public void leituraX() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_LeituraX(getHandle());
		checkResult(ret);


	}

	public void reducaoZ(Date data) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_ReducaoZ(getHandle(), OleDate.toOADate(data));
		checkResult(ret);


	}

	public void reducaoZ() throws ACBrException
	{

		int ret = ACBrECFInterop.INSTANCE.ECF_ReducaoZ(getHandle(), 0);
		checkResult(ret);


	}

	public String dadosUltimaReducaoZ() throws ACBrException
	{

		ByteBuffer returnBuffer = ByteBuffer.allocate(STR_BUFFER_LEN);
		int ret = ACBrECFInterop.INSTANCE.ECF_GetDadosUltimaReducaoZ(getHandle(), returnBuffer, STR_BUFFER_LEN);
		checkResult(ret);

		return fromUTF8(returnBuffer, ret);
	}

	public String dadosReducaoZ() throws ACBrException
	{

		ByteBuffer returnBuffer = ByteBuffer.allocate(STR_BUFFER_LEN);
		int ret = ACBrECFInterop.INSTANCE.ECF_GetDadosReducaoZ(getHandle(), returnBuffer, STR_BUFFER_LEN);
		checkResult(ret);

		return fromUTF8(returnBuffer, ret);
	}

	public void abreRelatorioGerencial(int indice) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_AbreRelatorioGerencial(getHandle(), indice);
		checkResult(ret);


	}

	public void linhaRelatorioGerencial(String linhas[], int indiceBMP) throws ACBrException
	{
		for (int i = 0; i < linhas.length; i++) {
			linhaRelatorioGerencial(linhas[i], indiceBMP);
		}
	}

	public void linhaRelatorioGerencial(String linha, int indiceBMP) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_LinhaRelatorioGerencial(getHandle(), toUTF8(linha), indiceBMP);
		checkResult(ret);


	}

	public void programaRelatoriosGerenciais(String descricao, String posicao) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_ProgramaRelatoriosGerenciais(getHandle(), toUTF8(descricao), toUTF8(posicao));
		checkResult(ret);


	}

	public void carregaRelatoriosGerenciais() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_CarregaRelatoriosGerenciais(getHandle());
		checkResult(ret);


	}

	public void lerTotaisRelatoriosGerenciais() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_LerTotaisRelatoriosGerenciais(getHandle());
		checkResult(ret);


	}

	public void fechaRelatorio() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_FechaRelatorio(getHandle());
		checkResult(ret);


	}

	public void programaAliquota(double aliquota, String tipo, String posicao) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_ProgramaAliquota(getHandle(), aliquota, tipo.charAt(0), toUTF8(posicao));
		checkResult(ret);


	}

	private void carregaFormasPagamento(int count) throws ACBrException
	{

		FormaPagamento[] array = new FormaPagamento[count];
		for (int i = 0; i < count; i++) {
			ACBrECFInterop.FormaPagamentoRec record = new ACBrECFInterop.FormaPagamentoRec();
			int ret = ACBrECFInterop.INSTANCE.ECF_GetFormaPagamento(getHandle(), record, i);
			checkResult(ret);

			FormaPagamento item = new FormaPagamento(fromUTF8(record.Indice), fromUTF8(record.Descricao), record.PermiteVinculado, record.Total);
			array[i] = item;
		}

		this.formasPagamento = array;
	}

	public void programaFormaPagamento(String descricao, boolean permiteVinculado, String posicao) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_ProgramaFormaPagamento(getHandle(), toUTF8(descricao), permiteVinculado, toUTF8(posicao));
		checkResult(ret);


	}

    public void carregaComprovantesNaoFiscais() throws ACBrException {
        int ret = ACBrECFInterop.INSTANCE.ECF_CarregaComprovantesNaoFiscais(getHandle());
        checkResult(ret);
        carregaComprovantesNaoFiscais(ret);
    }

    private void carregaComprovantesNaoFiscais(int count) throws ACBrException {
        ComprovanteNaoFiscal[] array = new ComprovanteNaoFiscal[count];
        for (int i = 0; i < count; i++) {
            ACBrECFInterop.ComprovanteNaoFiscalRec record = new ACBrECFInterop.ComprovanteNaoFiscalRec();
            int ret = ACBrECFInterop.INSTANCE.ECF_GetComprovanteNaoFiscal(getHandle(), record, i);
            checkResult(ret);

            ComprovanteNaoFiscal item = new ComprovanteNaoFiscal(fromUTF8(record.Indice), fromUTF8(record.Descricao), fromUTF8(record.FormaPagamento), record.Contador, record.PermiteVinculado, record.Total);
            array[i] = item;
        }

        this.comprovantesNaoFiscais = array;
    }
    
    public ComprovanteNaoFiscal[] getComprovantesNaoFiscais() throws ACBrException {
        return comprovantesNaoFiscais;
    } 

	public void lerTotaisComprovanteNaoFiscal() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_LerTotaisComprovanteNaoFiscal(getHandle());
		checkResult(ret);


	}

	public void programaComprovanteNaoFiscal(String descricao, String tipo, String posicao) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_ProgramaComprovanteNaoFiscal(getHandle(), toUTF8(descricao), toUTF8(tipo), toUTF8(posicao));
		checkResult(ret);


	}

	public void abreNaoFiscal(String cpfCnpj, String nome, String endereco) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_AbreNaoFiscal(getHandle(), toUTF8(cpfCnpj), toUTF8(nome), toUTF8(endereco));
		checkResult(ret);


	}

	public void registraItemNaoFiscal(String codCNF, double value, String obs) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_RegistraItemNaoFiscal(getHandle(), toUTF8(codCNF), value, toUTF8(obs));
		checkResult(ret);


	}

	public void subtotalizaNaoFiscal(double descontoAcrescimo, String mensagemRodape) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_SubtotalizaNaoFiscal(getHandle(), descontoAcrescimo, toUTF8(mensagemRodape));
		checkResult(ret);


	}

	public void efetuaPagamentoNaoFiscal(String codFormaPagto, double valor, String observacao, boolean imprimeVinculado) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_EfetuaPagamentoNaoFiscal(getHandle(), toUTF8(codFormaPagto), valor, toUTF8(observacao), imprimeVinculado);
		checkResult(ret);


	}

	public void fechaNaoFiscal(String observacao, int IndiceBMP) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_FechaNaoFiscal(getHandle(), toUTF8(observacao), IndiceBMP);
		checkResult(ret);


	}

	public void cancelaNaoFiscal() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_CancelaNaoFiscal(getHandle());
		checkResult(ret);


	}

	public void suprimento(double valor, String obs, String DescricaoCNF, String DescricaoFPG, int indicebmp) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_Suprimento(getHandle(), valor, toUTF8(obs), toUTF8(DescricaoCNF), toUTF8(DescricaoFPG), indicebmp);
		checkResult(ret);


	}

	public void sangria(double valor, String obs, String DescricaoCNF, String DescricaoFPG, int indicebmp) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_Sangria(getHandle(), valor, toUTF8(obs), toUTF8(DescricaoCNF), toUTF8(DescricaoFPG), indicebmp);
		checkResult(ret);


	}

	public void abreGaveta() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_AbreGaveta(getHandle());
		checkResult(ret);


	}

	public void identificaPAF(String nomeVersao, String md5) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_IdentificaPAF(getHandle(), toUTF8(nomeVersao), toUTF8(md5));
		checkResult(ret);


	}

	public void ativar() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_Ativar(getHandle());
		checkResult(ret);


	}

	public void desativar() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_Desativar(getHandle());
		checkResult(ret);


	}

	public boolean acharECF(boolean Modelo, boolean Porta, int TimeOut) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_AcharECF(getHandle(), Modelo, Porta, TimeOut);
		checkResult(ret);

		return ret != 0;
	}

	public boolean acharPorta(int TimeOut) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_AcharPorta(getHandle(), TimeOut);
		checkResult(ret);

		return ret != 0;
	}

	public boolean emLinha(int timeOut) throws ACBrException
	{
		int ret = ACBrECFInterop.INSTANCE.ECF_GetEmLinha(getHandle(), timeOut);
		checkResult(ret);

		return ret != 0;
	}

	public void pulaLinhas(int numLinhas) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_PulaLinhas(getHandle(), numLinhas);
		checkResult(ret);


	}

	public void cortaPapel(boolean corteParcial) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_CortaPapel(getHandle(), corteParcial);
		checkResult(ret);


	}

	public void corrigeEstadoErro(boolean reducaoZ) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_CorrigeEstadoErro(getHandle(), reducaoZ);
		checkResult(ret);


	}

	public void mudaHorarioVerao() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_MudaHorarioVerao(getHandle());
		checkResult(ret);


	}

	public void mudaArredondamento(boolean arredonda) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_MudaArredondamento(getHandle(), arredonda);
		checkResult(ret);


	}

	public void preparaTEF() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_PreparaTEF(getHandle());
		checkResult(ret);


	}

	public void testaPodeAbrirCupom() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_TestaPodeAbrirCupom(getHandle());
		checkResult(ret);


	}

	public String enviaComando(String cmd, int timeout) throws ACBrException
	{

		ByteBuffer returnBuffer = ByteBuffer.allocate(STR_BUFFER_LEN);
		int ret = ACBrECFInterop.INSTANCE.ECF_EnviaComando(getHandle(), toUTF8(cmd), timeout, returnBuffer, STR_BUFFER_LEN);
		checkResult(ret);

		return fromUTF8(returnBuffer, ret);
	}

	public void imprimeCheque(String Banco, double Valor, String Favorecido, String Cidade, Date Data, String Observacao) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_ImprimeCheque(getHandle(), toUTF8(Banco), Valor, toUTF8(Favorecido), toUTF8(Cidade), OleDate.toOADate(Data), toUTF8(Observacao));
		checkResult(ret);


	}

	public void cancelaImpressaoCheque() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_CancelaImpressaoCheque(getHandle());
		checkResult(ret);


	}

	public String leituraCMC7() throws ACBrException
	{

		ByteBuffer returnBuffer = ByteBuffer.allocate(STR_BUFFER_LEN);
		int ret = ACBrECFInterop.INSTANCE.ECF_LeituraCMC7(getHandle(), returnBuffer, STR_BUFFER_LEN);
		checkResult(ret);

		return fromUTF8(returnBuffer, ret);
	}

	public void identificaConsumidor(String cpfCnpj, String nome, String endereco) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_IdentificaConsumidor(getHandle(), toUTF8(cpfCnpj), toUTF8(nome), toUTF8(endereco));
		checkResult(ret);


	}

	public void identificaOperador(String nome) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_IdentificaOperador(getHandle(), toUTF8(nome));
		checkResult(ret);


	}

	public void abreCupom() throws ACBrException
	{
		abreCupom("", "", "", false);
	}

	public void abreCupom(String cpfCnpj, String nome, String endereco, boolean ModoPreVenda) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_AbreCupom(getHandle(), toUTF8(cpfCnpj), toUTF8(nome), toUTF8(endereco), ModoPreVenda);
		checkResult(ret);


	}

	public void legendaInmetroProximoItem() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_LegendaInmetroProximoItem(getHandle());
		checkResult(ret);


	}

	public void vendeItem(String codigo, String descricao, String aliquotaICMS, double qtd, double valorUnitario, double descontoPorc, String unidade, String tipoDescontoAcrescimo, String descontoAcrescimo, int CodDepartamento) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_VendeItem(getHandle(), toUTF8(codigo), toUTF8(descricao), toUTF8(aliquotaICMS), qtd, valorUnitario, descontoPorc, toUTF8(unidade), toUTF8(tipoDescontoAcrescimo), toUTF8(descontoAcrescimo), CodDepartamento);
		checkResult(ret);


	}

	public void descontoAcrescimoItemAnterior(double valorDesconto, String descontoAcrescimo, String tipodescontoAcrescimo, int item) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_DescontoAcrescimoItemAnterior(getHandle(), valorDesconto, toUTF8(descontoAcrescimo), toUTF8(tipodescontoAcrescimo), item);
		checkResult(ret);


	}

	public void subtotalizaCupom(double descontoAcrescimo, String mensagemRodape) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_SubtotalizaCupom(getHandle(), descontoAcrescimo, toUTF8(mensagemRodape));
		checkResult(ret);


	}

	public void efetuaPagamento(String codFormaPagto, double valor, String observacao, boolean imprimeVinculado) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_EfetuaPagamento(getHandle(), toUTF8(codFormaPagto), valor, toUTF8(observacao), imprimeVinculado);
		checkResult(ret);


	}

	public void estornaPagamento(String codFormaPagtoEstornar, String codFormaPagtoEfetivar, double valor, String observacao) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_EstornaPagamento(getHandle(), toUTF8(codFormaPagtoEstornar), toUTF8(codFormaPagtoEfetivar), valor, toUTF8(observacao));
		checkResult(ret);


	}

	public void fechaCupom(String observacao) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_FechaCupom(getHandle(), toUTF8(observacao));
		checkResult(ret);


	}

	public void cancelaCupom() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_CancelaCupom(getHandle());
		checkResult(ret);


	}

	public void cancelaItemVendido(int numItem) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_CancelaItemVendido(getHandle(), numItem);
		checkResult(ret);


	}

	public void cancelaItemVendidoParcial(int numItem, double quantidade) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_CancelaItemVendidoParcial(getHandle(), numItem, quantidade);
		checkResult(ret);


	}

	public void cancelaDescontoAcrescimoItem(int numItem) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_CancelaDescontoAcrescimoItem(getHandle(), numItem);
		checkResult(ret);


	}

	public void cancelaDescontoAcrescimoSubTotal(String tipoAcrescimoDesconto) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_CancelaDescontoAcrescimoSubTotal(getHandle(), tipoAcrescimoDesconto.charAt(0));
		checkResult(ret);


	}

	public void dAV_Abrir(Date emissao, String decrdocumento, String numero, String situacao, String vendedor, String observacao, String cpfCnpj, String nome, String endereco, int indice) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_DAV_Abrir(getHandle(), OleDate.toOADate(emissao), toUTF8(decrdocumento), toUTF8(numero), toUTF8(situacao), toUTF8(vendedor), toUTF8(observacao), toUTF8(cpfCnpj), toUTF8(nome), toUTF8(endereco), indice);
		checkResult(ret);


	}

	public void dAV_RegistrarItem(String codigo, String descricao, String unidade, double quantidade, double vlrunitario, double desconto, double acrescimo, boolean cancelado) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_DAV_RegistrarItem(getHandle(), toUTF8(codigo), toUTF8(descricao), toUTF8(unidade), quantidade, vlrunitario, desconto, acrescimo, cancelado);
		checkResult(ret);


	}

	public void dAV_Fechar(String observacao) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_DAV_Fechar(getHandle(), toUTF8(observacao));
		checkResult(ret);


	}

	public void pafMF_GerarCAT52(Date DataInicial, Date DataFinal, String CaminhoArquivo) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_PafMF_GerarCAT52(getHandle(), OleDate.toOADate(DataInicial), OleDate.toOADate(DataFinal), toUTF8(CaminhoArquivo));
		checkResult(ret);


	}

	public void pafMF_LX_Impressao() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_PafMF_LX_Impressao(getHandle());
		checkResult(ret);


	}

	public void arquivoMFD_DLL(Date DataInicial, Date DataFinal, String CaminhoArquivo, int Finaliza, int Documentos[]) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_ArquivoMFD_DLL(getHandle(), OleDate.toOADate(DataInicial), OleDate.toOADate(DataFinal), toUTF8(CaminhoArquivo), Documentos, Documentos.length, Finaliza);
		checkResult(ret);


	}

	public void arquivoMFD_DLL(int COOInicial, int COOFinal, String CaminhoArquivo, int Finaliza, int TipoContador, int Documentos[]) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_ArquivoMFD_DLL_COO(getHandle(), COOInicial, COOFinal, toUTF8(CaminhoArquivo), Documentos, Documentos.length, Finaliza, TipoContador);
		checkResult(ret);


	}

	public void doAtualizarValorGT() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_DoAtualizarValorGT(getHandle());
		checkResult(ret);


	}

	public void doVerificaValorGT() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_DoVerificaValorGT(getHandle());
		checkResult(ret);


	}

	public void pafMF_LMFC_Cotepe1704(Date DataInicial, Date DataFinal, String CaminhoArquivo) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_PafMF_LMFC_Cotepe1704(getHandle(), OleDate.toOADate(DataInicial), OleDate.toOADate(DataFinal), toUTF8(CaminhoArquivo));
		checkResult(ret);


	}

	public void pafMF_LMFC_Cotepe1704(int CRZInicial, int CRZFinal, String CaminhoArquivo) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_PafMF_LMFC_Cotepe1704(getHandle(), CRZInicial, CRZFinal, toUTF8(CaminhoArquivo));
		checkResult(ret);


	}

	public void pafMF_LMFC_Espelho(Date DataInicial, Date DataFinal, String CaminhoArquivo) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_PafMF_LMFC_Espelho(getHandle(), OleDate.toOADate(DataInicial), OleDate.toOADate(DataFinal), toUTF8(CaminhoArquivo));
		checkResult(ret);


	}

	public void pafMF_LMFC_Espelho(int CRZInicial, int CRZFinal, String CaminhoArquivo) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_PafMF_LMFC_Espelho(getHandle(), CRZInicial, CRZFinal, toUTF8(CaminhoArquivo));
		checkResult(ret);


	}

	public void pafMF_LMFC_Impressao(Date DataInicial, Date DataFinal) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_PafMF_LMFC_Impressao(getHandle(), OleDate.toOADate(DataInicial), OleDate.toOADate(DataFinal));
		checkResult(ret);


	}

	public void pafMF_LMFC_Impressao(int CRZInicial, int CRZFinal) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_PafMF_LMFC_Impressao_CRZ(getHandle(), CRZInicial, CRZFinal);
		checkResult(ret);


	}

	public void pafMF_LMFS_Espelho(Date DataInicial, Date DataFinal, String CaminhoArquivo) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_PafMF_LMFS_Espelho(getHandle(), OleDate.toOADate(DataInicial), OleDate.toOADate(DataFinal), toUTF8(CaminhoArquivo));
		checkResult(ret);


	}

	public void pafMF_LMFS_Espelho(int CRZInicial, int CRZFinal, String CaminhoArquivo) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_PafMF_LMFS_Espelho(getHandle(), CRZInicial, CRZFinal, toUTF8(CaminhoArquivo));
		checkResult(ret);


	}

	public void pafMF_LMFS_Impressao(Date DataInicial, Date DataFinal) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_PafMF_LMFS_Impressao(getHandle(), OleDate.toOADate(DataInicial), OleDate.toOADate(DataFinal));
		checkResult(ret);


	}

	public void pafMF_LMFS_Impressao(int CRZInicial, int CRZFinal) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_PafMF_LMFS_Impressao(getHandle(), CRZInicial, CRZFinal);
		checkResult(ret);


	}

	public void pafMF_MFD_Cotepe1704(Date DataInicial, Date DataFinal, String CaminhoArquivo) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_PafMF_MFD_Cotepe1704(getHandle(), OleDate.toOADate(DataInicial), OleDate.toOADate(DataFinal), toUTF8(CaminhoArquivo));
		checkResult(ret);


	}

	public void pafMF_MFD_Cotepe1704(int COOInicial, int COOFinal, String CaminhoArquivo) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_PafMF_MFD_Cotepe1704(getHandle(), COOInicial, COOFinal, toUTF8(CaminhoArquivo));
		checkResult(ret);


	}

	public void pafMF_MFD_Espelho(Date DataInicial, Date DataFinal, String CaminhoArquivo) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_PafMF_MFD_Espelho(getHandle(), OleDate.toOADate(DataInicial), OleDate.toOADate(DataFinal), toUTF8(CaminhoArquivo));
		checkResult(ret);


	}

	public void pafMF_MFD_Espelho(int COOInicial, int COOFinal, String CaminhoArquivo) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_PafMF_MFD_Espelho(getHandle(), COOInicial, COOFinal, toUTF8(CaminhoArquivo));
		checkResult(ret);


	}

	public void leituraMemoriaFiscal(int reducaoInicial, int reducaoFinal, boolean simplificada) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_LeituraMemoriaFiscalReducao(getHandle(), reducaoInicial, reducaoFinal, simplificada);
		checkResult(ret);


	}

	public void leituraMemoriaFiscal(Date dataInicial, Date dataFinal, boolean simplificada) throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_LeituraMemoriaFiscalData(getHandle(), OleDate.toOADate(dataInicial), OleDate.toOADate(dataFinal), simplificada);
		checkResult(ret);


	}

	public String leituraMemoriaFiscalSerial(int reducaoInicial, int reducaoFinal, boolean simplificada) throws ACBrException
	{

		ByteBuffer returnBuffer = ByteBuffer.allocate(STR_BUFFER_LEN);
		int ret = ACBrECFInterop.INSTANCE.ECF_LeituraMemoriaFiscalSerialReducao(getHandle(), reducaoInicial, reducaoFinal, simplificada, returnBuffer, STR_BUFFER_LEN);
		checkResult(ret);

		return fromUTF8(returnBuffer, ret);
	}
	//</editor-fold>
	//</editor-fold>
}
