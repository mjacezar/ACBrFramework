package jACBrFramework.serial.ecf;

import com.sun.jna.ptr.DoubleByReference;
import com.sun.jna.ptr.IntByReference;
import jACBrFramework.ACBrClass;
import jACBrFramework.ACBrEventListener;
import jACBrFramework.ACBrException;
import jACBrFramework.OleDate;
import jACBrFramework.interop.ACBrECFInterop;
import jACBrFramework.serial.ACBrDevice;
import java.nio.ByteBuffer;
import java.util.ArrayList;
import java.util.Date;
import java.util.Iterator;

public final class ACBrECF extends ACBrClass
{
	// <editor-fold defaultstate="collapsed" desc="Fields">

	private ACBrDevice device;
	private Aliquota[] aliquotas;
	private FormaPagamento[] formasPagamento;
	private ComprovanteNaoFiscal[] comprovantesNaoFiscais;
	private ArrayList<ACBrEventListener<AbreCupomEventObject>> onAntesAbrirCupomListeners = new ArrayList<ACBrEventListener<AbreCupomEventObject>>();
	private ArrayList<ACBrEventListener<BobinaEventObject>> onBobinaAdicionaLinhasListeners = new ArrayList<ACBrEventListener<BobinaEventObject>>();
	private ArrayList<ACBrEventListener<CancelaItemEventObject>> onAntesCancelaItemVendidoListeners = new ArrayList<ACBrEventListener<CancelaItemEventObject>>();

	// </editor-fold>
	
	//<editor-fold defaultstate="collapsed" desc="Constructor">
	public ACBrECF() throws ACBrException
	{
	}

	//</editor-fold>
	
	//<editor-fold defaultstate="collapsed" desc="Events">
	//<editor-fold defaultstate="collapsed" desc="OnAntesAbrirCupom">
	public void addOnAntesAbrirCupom(ACBrEventListener<AbreCupomEventObject> listener)
	{
		if (onAntesAbrirCupomListeners.isEmpty()) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesAbreCupom(getHandle(), new ACBrECFInterop.AbreCupomCallback()
			{
				@Override
				public void invoke(String CPF_CNPJ, String Nome, String Endereco)
				{
					onAntesAbrirCupom(CPF_CNPJ, Nome, Endereco);
				}
			});
		}

		onAntesAbrirCupomListeners.add(listener);
	}

	public void removeOnAntesAbrirCupom(ACBrEventListener<AbreCupomEventObject> listener)
	{
		onAntesAbrirCupomListeners.remove(listener);

		if (onAntesAbrirCupomListeners.isEmpty()) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesAbreCupom(getHandle(), null);
		}
	}

	private void onAntesAbrirCupom(String CPF_CNPJ, String Nome, String Endereco)
	{
		AbreCupomEventObject e = new AbreCupomEventObject(this, fromUTF8(CPF_CNPJ), fromUTF8(Nome), fromUTF8(Endereco));

		Iterator<ACBrEventListener<AbreCupomEventObject>> iterator = onAntesAbrirCupomListeners.iterator();
		while (iterator.hasNext()) {
			iterator.next().notification(e);
		}
	}
	//</editor-fold>	

	//<editor-fold defaultstate="collapsed" desc="OnBobinaAdicionaLinhas">
	public void addOnBobinaAdicionaLinhas(ACBrEventListener<BobinaEventObject> listener)
	{
		if (onBobinaAdicionaLinhasListeners.isEmpty()) {
			ACBrECFInterop.INSTANCE.ECF_SetOnBobinaAdicionaLinhas(getHandle(), new ACBrECFInterop.BobinaAdicionaLinhasCallback()
			{
				@Override
				public void invoke(String linhas, String operacao)
				{
					onBobinaAdicionaLinha(linhas, operacao);
				}
			});
		}

		onBobinaAdicionaLinhasListeners.add(listener);
	}

	public void removeOnBobinaAdicionaLinhas(ACBrEventListener<BobinaEventObject> listener)
	{
		onBobinaAdicionaLinhasListeners.remove(listener);

		if (onBobinaAdicionaLinhasListeners.isEmpty()) {
			ACBrECFInterop.INSTANCE.ECF_SetOnBobinaAdicionaLinhas(getHandle(), null);
		}
	}

	private void onBobinaAdicionaLinha(String linhas, String operacao)
	{
		BobinaEventObject e = new BobinaEventObject(this, fromUTF8(linhas), fromUTF8(operacao));

		Iterator<ACBrEventListener<BobinaEventObject>> iterator = onBobinaAdicionaLinhasListeners.iterator();
		while (iterator.hasNext()) {
			iterator.next().notification(e);
		}
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc="OnAntesCancelaItemVendido">
	public void addOnAntesCancelaItemVendido(ACBrEventListener<CancelaItemEventObject> listener)
	{
		if (onAntesCancelaItemVendidoListeners.isEmpty()) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesCancelaItemVendido(getHandle(), new ACBrECFInterop.IntArgumentCallback()
			{
				@Override
				public void invoke(int value)
				{
					onAntesCancelaItemVendido(value);
				}
			});
		}

		onAntesCancelaItemVendidoListeners.add(listener);
	}

	public void removeOnAntesCancelaItemVendido(ACBrEventListener<CancelaItemEventObject> listener)
	{
		onAntesCancelaItemVendidoListeners.remove(listener);

		if (onAntesCancelaItemVendidoListeners.isEmpty()) {
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesCancelaItemVendido(getHandle(), null);
		}
	}

	private void onAntesCancelaItemVendido(int numItem)
	{
		CancelaItemEventObject e = new CancelaItemEventObject(this, numItem);

		Iterator<ACBrEventListener<CancelaItemEventObject>> iterator = onAntesCancelaItemVendidoListeners.iterator();
		while (iterator.hasNext()) {
			iterator.next().notification(e);
		}
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

	public void carregaAliquotas() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_CarregaAliquotas(getHandle());
		checkResult(ret);


	}

	public void lerTotaisAliquota() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_LerTotaisAliquota(getHandle());
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

	public void carregaComprovantesNaoFiscais() throws ACBrException
	{


		int ret = ACBrECFInterop.INSTANCE.ECF_CarregaComprovantesNaoFiscais(getHandle());
		checkResult(ret);


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


		int ret = ACBrECFInterop.INSTANCE.ECF_PafMF_LMFC_Impressao(getHandle(), CRZInicial, CRZFinal);
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
