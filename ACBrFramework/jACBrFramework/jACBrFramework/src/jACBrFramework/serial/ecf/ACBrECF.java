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
		if (onAntesAbrirCupomListeners.isEmpty())
		{
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesAbreCupom(getHandle(), new ACBrECFInterop.AbreCupomCallback() {

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
		
		if (onAntesAbrirCupomListeners.isEmpty())
		{
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesAbreCupom(getHandle(), null);
		}
	}
	
	private void onAntesAbrirCupom(String CPF_CNPJ, String Nome, String Endereco)
	{
		AbreCupomEventObject e = new AbreCupomEventObject(this, fromUTF8(CPF_CNPJ), fromUTF8(Nome), fromUTF8(Endereco));
		
		Iterator<ACBrEventListener<AbreCupomEventObject>> iterator = onAntesAbrirCupomListeners.iterator();
		while(iterator.hasNext())
		{
			iterator.next().notification(e);
		}
	}
	//</editor-fold>	
	
	//<editor-fold defaultstate="collapsed" desc="OnBobinaAdicionaLinhas">
	
	public void addOnBobinaAdicionaLinhas(ACBrEventListener<BobinaEventObject> listener)
	{
		if (onBobinaAdicionaLinhasListeners.isEmpty())
		{
			ACBrECFInterop.INSTANCE.ECF_SetOnBobinaAdicionaLinhas(getHandle(), new ACBrECFInterop.BobinaAdicionaLinhasCallback() {
				
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
		
		if (onBobinaAdicionaLinhasListeners.isEmpty())
		{
			ACBrECFInterop.INSTANCE.ECF_SetOnBobinaAdicionaLinhas(getHandle(), null);
		}
	}
	
	private void onBobinaAdicionaLinha(String linhas, String operacao)
	{
		BobinaEventObject e = new BobinaEventObject(this, fromUTF8(linhas), fromUTF8(operacao));
		
		Iterator<ACBrEventListener<BobinaEventObject>> iterator = onBobinaAdicionaLinhasListeners.iterator();
		while(iterator.hasNext())
		{
			iterator.next().notification(e);
		}
	}
	//</editor-fold>
	
	//<editor-fold defaultstate="collapsed" desc="OnAntesCancelaItemVendido">
	
	public void addOnAntesCancelaItemVendido(ACBrEventListener<CancelaItemEventObject> listener)
	{
		if (onAntesCancelaItemVendidoListeners.isEmpty())
		{
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesCancelaItemVendido(getHandle(), new ACBrECFInterop.IntArgumentCallback() {

				@Override
				public void invoke(int value)
				{
					onAntesCancelaItemVendido(value);
				}
			} );
		}
		
		onAntesCancelaItemVendidoListeners.add(listener);
	}
	
	public void removeOnAntesCancelaItemVendido(ACBrEventListener<CancelaItemEventObject> listener)
	{
		onAntesCancelaItemVendidoListeners.remove(listener);
		
		if (onAntesCancelaItemVendidoListeners.isEmpty())
		{
			ACBrECFInterop.INSTANCE.ECF_SetOnAntesCancelaItemVendido(getHandle(), null);
		}
	}
	
	private void onAntesCancelaItemVendido(int numItem)
	{
		CancelaItemEventObject e = new CancelaItemEventObject(this, numItem);
		
		Iterator<ACBrEventListener<CancelaItemEventObject>> iterator = onAntesCancelaItemVendidoListeners.iterator();
		while(iterator.hasNext())
		{
			iterator.next().notification(e);
		}
	}
	
	//</editor-fold>		
	
	//</editor-fold>
		
	//<editor-fold defaultstate="collapsed" desc="Properties">
	public ACBrDevice getDevice()
	{
		return this.device;
	}

	public int getModelo() throws ACBrException
	{

		return getInt(new GetIntEntryPoint()
		{
			@Override
			public int invoke(int handle)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetModelo(handle);
			}
		});

	}

	public void setModelo(int value) throws ACBrException
	{

		setInt(value, new SetIntEntryPoint()
		{
			@Override
			public int invoke(int handle, int value)
			{
				return ACBrECFInterop.INSTANCE.ECF_SetModelo(handle, value);
			}
		});

	}

	public int getMaxLinhasBuffer() throws ACBrException
	{

		return getInt(new GetIntEntryPoint()
		{
			@Override
			public int invoke(int handle)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetMaxLinhasBuffer(handle);
			}
		});

	}

	public void setMaxLinhasBuffer(int value) throws ACBrException
	{

		setInt(value, new SetIntEntryPoint()
		{
			@Override
			public int invoke(int handle, int value)
			{
				return ACBrECFInterop.INSTANCE.ECF_SetMaxLinhasBuffer(handle, value);
			}
		});

	}

	public boolean getDescricaoGrande() throws ACBrException
	{

		return getBoolean(new GetBooleanEntryPoint()
		{
			@Override
			public int invoke(int handle)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetDescricaoGrande(handle);
			}
		});

	}

	public void setDescricaoGrande(boolean value) throws ACBrException
	{

		setBoolean(value, new SetBooleanEntryPoint()
		{
			@Override
			public int invoke(int handle, boolean value)
			{
				return ACBrECFInterop.INSTANCE.ECF_SetDescricaoGrande(handle, value);
			}
		});

	}

	public boolean getGavetaSinalInvertido() throws ACBrException
	{

		return getBoolean(new GetBooleanEntryPoint()
		{
			@Override
			public int invoke(int handle)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetGavetaSinalInvertido(handle);
			}
		});

	}

	public void setGavetaSinalInvertido(boolean value) throws ACBrException
	{

		setBoolean(value, new SetBooleanEntryPoint()
		{
			@Override
			public int invoke(int handle, boolean value)
			{
				return ACBrECFInterop.INSTANCE.ECF_SetGavetaSinalInvertido(handle, value);
			}
		});

	}

	public boolean getArredondaPorQtd() throws ACBrException
	{

		return getBoolean(new GetBooleanEntryPoint()
		{
			@Override
			public int invoke(int handle)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetArredondaPorQtd(handle);
			}
		});

	}

	public void setArredondaPorQtd(boolean value) throws ACBrException
	{

		setBoolean(value, new SetBooleanEntryPoint()
		{
			@Override
			public int invoke(int handle, boolean value)
			{
				return ACBrECFInterop.INSTANCE.ECF_SetArredondaPorQtd(handle, value);
			}
		});

	}

	public boolean getArredondaItemMFD() throws ACBrException
	{

		return getBoolean(new GetBooleanEntryPoint()
		{
			@Override
			public int invoke(int handle)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetArredondaItemMFD(handle);
			}
		});

	}

	public void setArredondaItemMFD(boolean value) throws ACBrException
	{

		setBoolean(value, new SetBooleanEntryPoint()
		{
			@Override
			public int invoke(int handle, boolean value)
			{
				return ACBrECFInterop.INSTANCE.ECF_SetArredondaItemMFD(handle, value);
			}
		});

	}

	public boolean getIgnorarTagsFormatacao() throws ACBrException
	{

		return getBoolean(new GetBooleanEntryPoint()
		{
			@Override
			public int invoke(int handle)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetIgnorarTagsFormatacao(handle);
			}
		});

	}

	public void setIgnorarTagsFormatacao(boolean value) throws ACBrException
	{

		setBoolean(value, new SetBooleanEntryPoint()
		{
			@Override
			public int invoke(int handle, boolean value)
			{
				return ACBrECFInterop.INSTANCE.ECF_SetIgnorarTagsFormatacao(handle, value);
			}
		});

	}

	public int getPausaRelatorio() throws ACBrException
	{

		return getInt(new GetIntEntryPoint()
		{
			@Override
			public int invoke(int handle)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetPausaRelatorio(handle);
			}
		});

	}

	public void setPausaRelatorio(int value) throws ACBrException
	{

		setInt(value, new SetIntEntryPoint()
		{
			@Override
			public int invoke(int handle, int value)
			{
				return ACBrECFInterop.INSTANCE.ECF_SetPausaRelatorio(handle, value);
			}
		});

	}

	public int getPaginaDeCodigo() throws ACBrException
	{

		return getInt(new GetIntEntryPoint()
		{
			@Override
			public int invoke(int handle)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetPaginaDeCodigo(handle);
			}
		});

	}

	public void setPaginaDeCodigo(int value) throws ACBrException
	{

		setInt(value, new SetIntEntryPoint()
		{
			@Override
			public int invoke(int handle, int value)
			{
				return ACBrECFInterop.INSTANCE.ECF_SetPaginaDeCodigo(handle, value);
			}
		});

	}

	public String getAbout() throws ACBrException
	{

		return getString(new GetStringEntryPoint()
		{
			@Override
			public int invoke(int handle, ByteBuffer buffer, int bufferLen)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetAbout(handle, buffer, bufferLen);
			}
		});

	}

	public String getArqLOG() throws ACBrException
	{

		return getString(new GetStringEntryPoint()
		{
			@Override
			public int invoke(int handle, ByteBuffer buffer, int bufferLen)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetArqLOG(handle, buffer, bufferLen);
			}
		});

	}

	public void setArqLOG(String value) throws ACBrException
	{

		setString(value, new SetStringEntryPoint()
		{
			@Override
			public int invoke(int handle, String value)
			{
				return ACBrECFInterop.INSTANCE.ECF_SetArqLOG(handle, value);
			}
		});

	}

	public String getOperador() throws ACBrException
	{

		return getString(new GetStringEntryPoint()
		{
			@Override
			public int invoke(int handle, ByteBuffer buffer, int bufferLen)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetOperador(handle, buffer, bufferLen);
			}
		});

	}

	public void setOperador(String value) throws ACBrException
	{

		setString(value, new SetStringEntryPoint()
		{
			@Override
			public int invoke(int handle, String value)
			{
				return ACBrECFInterop.INSTANCE.ECF_SetOperador(handle, value);
			}
		});

	}

	public String[] getMemoParams() throws ACBrException
	{
		return getStringArray(
			new GetStringArrayEntryPoint()
			{
				@Override
				public int invoke(int handle, ByteBuffer buffer, int bufferLen, int index)
				{
					return ACBrECFInterop.INSTANCE.ECF_GetMemoParams(handle, buffer, bufferLen, index);
				}
			},
			new GetIntEntryPoint()
			{
				@Override
				public int invoke(int handle)
				{
					return ACBrECFInterop.INSTANCE.ECF_GetMemoParamsLineCount(handle);
				}
			});
	}

	public void setMemoParams(String[] value) throws ACBrException
	{
		//NÃO IMPLEMENTADO
	}

	public int getLinhasEntreCupons() throws ACBrException
	{

		return getInt(new GetIntEntryPoint()
		{
			@Override
			public int invoke(int handle)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetLinhasEntreCupons(handle);
			}
		});

	}

	public void setLinhasEntreCupons(int value) throws ACBrException
	{

		setInt(value, new SetIntEntryPoint()
		{
			@Override
			public int invoke(int handle, int value)
			{
				return ACBrECFInterop.INSTANCE.ECF_SetLinhasEntreCupons(handle, value);
			}
		});

	}

	public int getDecimaisPreco() throws ACBrException
	{

		return getInt(new GetIntEntryPoint()
		{
			@Override
			public int invoke(int handle)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetDecimaisPreco(handle);
			}
		});

	}

	public void setDecimaisPreco(int value) throws ACBrException
	{

		setInt(value, new SetIntEntryPoint()
		{
			@Override
			public int invoke(int handle, int value)
			{
				return ACBrECFInterop.INSTANCE.ECF_SetDecimaisPreco(handle, value);
			}
		});

	}

	public int getDecimaisQtd() throws ACBrException
	{

		return getInt(new GetIntEntryPoint()
		{
			@Override
			public int invoke(int handle)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetDecimaisQtd(handle);
			}
		});

	}

	public void setDecimaisQtd(int value) throws ACBrException
	{

		setInt(value, new SetIntEntryPoint()
		{
			@Override
			public int invoke(int handle, int value)
			{
				return ACBrECFInterop.INSTANCE.ECF_SetDecimaisQtd(handle, value);
			}
		});

	}

	/*public Rodape getInfoRodapeCupom() throws ACBrException
	 * {
	 * //Nao implementado
	 * }
	 * 
	 * public ConfigBarras getConfigBarras() throws ACBrException
	 * {
	 * //Nao implementado
	 * }
	 * 
	 * public ACBrAAC getAAC() throws ACBrException
	 * {
	 * //Nao implementado
	 * }
	 * 
	 * public void setAAC(ACBrAAC value) throws ACBrException
	 * {
	 * //Nao implementado
	 * }
	 * 
	 * public ACBrEAD getEAD() throws ACBrException
	 * {
	 * //Nao implementado
	 * }
	 * 
	 * public void setEAD(ACBrEAD value) throws ACBrException
	 * {
	 * //Nao implementado
	 * }
	 * 
	 * public ACBrRFD getRFD() throws ACBrException
	 * {
	 * //Nao implementado
	 * }
	 * 
	 * public void setRFD(ACBrRFD value) throws ACBrException
	 * {
	 * //Nao implementado
	 * }*/
	public boolean getAtivo() throws ACBrException
	{

		return getBoolean(new GetBooleanEntryPoint()
		{
			@Override
			public int invoke(int handle)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetAtivo(handle);
			}
		});

	}

	public int getColunas() throws ACBrException
	{

		return getInt(new GetIntEntryPoint()
		{
			@Override
			public int invoke(int handle)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetColunas(handle);
			}
		});

	}

	public boolean getAguardandoResposta() throws ACBrException
	{

		return getBoolean(new GetBooleanEntryPoint()
		{
			@Override
			public int invoke(int handle)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetAguardandoResposta(handle);
			}
		});

	}

	public String getComandoLog() throws ACBrException
	{

		return getString(new GetStringEntryPoint()
		{
			@Override
			public int invoke(int handle, ByteBuffer buffer, int bufferLen)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetComandoLOG(handle, buffer, bufferLen);
			}
		});

	}

	public void setComandoLog(String value) throws ACBrException
	{

		setString(value, new SetStringEntryPoint()
		{
			@Override
			public int invoke(int handle, String value)
			{
				return ACBrECFInterop.INSTANCE.ECF_SetComandoLOG(handle, value);
			}
		});

	}

	public boolean getAguardaImpressao() throws ACBrException
	{

		return getBoolean(new GetBooleanEntryPoint()
		{
			@Override
			public int invoke(int handle)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetAguardaImpressao(handle);
			}
		});

	}

	public void setAguardaImpressao(boolean value) throws ACBrException
	{

		setBoolean(value, new SetBooleanEntryPoint()
		{
			@Override
			public int invoke(int handle, boolean value)
			{
				return ACBrECFInterop.INSTANCE.ECF_SetAguardaImpressao(handle, value);
			}
		});

	}

	public String getModeloStr() throws ACBrException
	{

		return getString(new GetStringEntryPoint()
		{
			@Override
			public int invoke(int handle, ByteBuffer buffer, int bufferLen)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetModeloStr(handle, buffer, bufferLen);
			}
		});

	}

	public String getRFDID() throws ACBrException
	{

		return getString(new GetStringEntryPoint()
		{
			@Override
			public int invoke(int handle, ByteBuffer buffer, int bufferLen)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetRFDID(handle, buffer, bufferLen);
			}
		});

	}

	public Date getDataHora() throws ACBrException
	{

		return getDate(new GetDoubleEntryPoint()
		{
			@Override
			public int invoke(int handle, DoubleByReference value)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetDataHora(handle, value);
			}
		});

	}

	public String getNumCupom() throws ACBrException
	{

		return getString(new GetStringEntryPoint()
		{
			@Override
			public int invoke(int handle, ByteBuffer buffer, int bufferLen)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetNumCupom(handle, buffer, bufferLen);
			}
		});

	}

	public String getNumCOO() throws ACBrException
	{

		return getString(new GetStringEntryPoint()
		{
			@Override
			public int invoke(int handle, ByteBuffer buffer, int bufferLen)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetNumCOO(handle, buffer, bufferLen);
			}
		});

	}

	public String getNumLoja() throws ACBrException
	{

		return getString(new GetStringEntryPoint()
		{
			@Override
			public int invoke(int handle, ByteBuffer buffer, int bufferLen)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetNumLoja(handle, buffer, bufferLen);
			}
		});

	}

	public String getNumECF() throws ACBrException
	{

		return getString(new GetStringEntryPoint()
		{
			@Override
			public int invoke(int handle, ByteBuffer buffer, int bufferLen)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetNumECF(handle, buffer, bufferLen);
			}
		});

	}

	public String getNumSerie() throws ACBrException
	{

		return getString(new GetStringEntryPoint()
		{
			@Override
			public int invoke(int handle, ByteBuffer buffer, int bufferLen)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetNumSerie(handle, buffer, bufferLen);
			}
		});

	}

	public String getNumSerieMFD() throws ACBrException
	{

		return getString(new GetStringEntryPoint()
		{
			@Override
			public int invoke(int handle, ByteBuffer buffer, int bufferLen)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetNumSerieMFD(handle, buffer, bufferLen);
			}
		});

	}

	public String getNumVersao() throws ACBrException
	{

		return getString(new GetStringEntryPoint()
		{
			@Override
			public int invoke(int handle, ByteBuffer buffer, int bufferLen)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetNumVersao(handle, buffer, bufferLen);
			}
		});

	}

	public Date getDataMovimento() throws ACBrException
	{

		return getDate(new GetDoubleEntryPoint()
		{
			@Override
			public int invoke(int handle, DoubleByReference value)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetDataMovimento(handle, value);
			}
		});

	}

	public Date getDataHoraSB() throws ACBrException
	{

		return getDate(new GetDoubleEntryPoint()
		{
			@Override
			public int invoke(int handle, DoubleByReference value)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetDataHoraSB(handle, value);
			}
		});

	}

	public String getCNPJ() throws ACBrException
	{

		return getString(new GetStringEntryPoint()
		{
			@Override
			public int invoke(int handle, ByteBuffer buffer, int bufferLen)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetCNPJ(handle, buffer, bufferLen);
			}
		});

	}

	public String getIE() throws ACBrException
	{

		return getString(new GetStringEntryPoint()
		{
			@Override
			public int invoke(int handle, ByteBuffer buffer, int bufferLen)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetIE(handle, buffer, bufferLen);
			}
		});

	}

	public String getIM() throws ACBrException
	{

		return getString(new GetStringEntryPoint()
		{
			@Override
			public int invoke(int handle, ByteBuffer buffer, int bufferLen)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetIM(handle, buffer, bufferLen);
			}
		});

	}

	public String getCliche() throws ACBrException
	{

		return getString(new GetStringEntryPoint()
		{
			@Override
			public int invoke(int handle, ByteBuffer buffer, int bufferLen)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetCliche(handle, buffer, bufferLen);
			}
		});

	}

	public String getUsuarioAtual() throws ACBrException
	{

		return getString(new GetStringEntryPoint()
		{
			@Override
			public int invoke(int handle, ByteBuffer buffer, int bufferLen)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetUsuarioAtual(handle, buffer, bufferLen);
			}
		});

	}

	public String getSubModeloECF() throws ACBrException
	{

		return getString(new GetStringEntryPoint()
		{
			@Override
			public int invoke(int handle, ByteBuffer buffer, int bufferLen)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetSubModeloECF(handle, buffer, bufferLen);
			}
		});

	}

	public String getPAF() throws ACBrException
	{

		return getString(new GetStringEntryPoint()
		{
			@Override
			public int invoke(int handle, ByteBuffer buffer, int bufferLen)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetPAF(handle, buffer, bufferLen);
			}
		});

	}

	public String getNumCRZ() throws ACBrException
	{

		return getString(new GetStringEntryPoint()
		{
			@Override
			public int invoke(int handle, ByteBuffer buffer, int bufferLen)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetNumCRZ(handle, buffer, bufferLen);
			}
		});

	}

	public String getNumCRO() throws ACBrException
	{

		return getString(new GetStringEntryPoint()
		{
			@Override
			public int invoke(int handle, ByteBuffer buffer, int bufferLen)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetNumCRO(handle, buffer, bufferLen);
			}
		});

	}

	public String getNumCCF() throws ACBrException
	{

		return getString(new GetStringEntryPoint()
		{
			@Override
			public int invoke(int handle, ByteBuffer buffer, int bufferLen)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetNumCCF(handle, buffer, bufferLen);
			}
		});

	}

	public String getNumGNF() throws ACBrException
	{

		return getString(new GetStringEntryPoint()
		{
			@Override
			public int invoke(int handle, ByteBuffer buffer, int bufferLen)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetNumGNF(handle, buffer, bufferLen);
			}
		});

	}

	public String getNumGRG() throws ACBrException
	{

		return getString(new GetStringEntryPoint()
		{
			@Override
			public int invoke(int handle, ByteBuffer buffer, int bufferLen)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetNumGRG(handle, buffer, bufferLen);
			}
		});

	}

	public String getNumCDC() throws ACBrException
	{

		return getString(new GetStringEntryPoint()
		{
			@Override
			public int invoke(int handle, ByteBuffer buffer, int bufferLen)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetNumCDC(handle, buffer, bufferLen);
			}
		});

	}

	public String getNumCOOInicial() throws ACBrException
	{

		return getString(new GetStringEntryPoint()
		{
			@Override
			public int invoke(int handle, ByteBuffer buffer, int bufferLen)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetNumCOOInicial(handle, buffer, bufferLen);
			}
		});

	}

	public String getComandoEnviado() throws ACBrException
	{

		return getString(new GetStringEntryPoint()
		{
			@Override
			public int invoke(int handle, ByteBuffer buffer, int bufferLen)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetComandoEnviado(handle, buffer, bufferLen);
			}
		});

	}

	public String getRespostaComando() throws ACBrException
	{

		return getString(new GetStringEntryPoint()
		{
			@Override
			public int invoke(int handle, ByteBuffer buffer, int bufferLen)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetRespostaComando(handle, buffer, bufferLen);
			}
		});

	}

	public double getVendaBruta() throws ACBrException
	{

		return getDouble(new GetDoubleEntryPoint()
		{
			@Override
			public int invoke(int handle, DoubleByReference value)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetVendaBruta(handle, value);
			}
		});

	}

	public double getGrandeTotal() throws ACBrException
	{

		return getDouble(new GetDoubleEntryPoint()
		{
			@Override
			public int invoke(int handle, DoubleByReference value)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetGrandeTotal(handle, value);
			}
		});

	}

	public double getTotalCancelamentos() throws ACBrException
	{

		return getDouble(new GetDoubleEntryPoint()
		{
			@Override
			public int invoke(int handle, DoubleByReference value)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetTotalCancelamentos(handle, value);
			}
		});

	}

	public double getTotalDescontos() throws ACBrException
	{

		return getDouble(new GetDoubleEntryPoint()
		{
			@Override
			public int invoke(int handle, DoubleByReference value)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetTotalDescontos(handle, value);
			}
		});

	}

	public double getTotalAcrescimos() throws ACBrException
	{

		return getDouble(new GetDoubleEntryPoint()
		{
			@Override
			public int invoke(int handle, DoubleByReference value)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetTotalAcrescimos(handle, value);
			}
		});

	}

	public double getTotalTroco() throws ACBrException
	{

		return getDouble(new GetDoubleEntryPoint()
		{
			@Override
			public int invoke(int handle, DoubleByReference value)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetTotalTroco(handle, value);
			}
		});

	}

	public double getTotalSubstituicaoTributaria() throws ACBrException
	{

		return getDouble(new GetDoubleEntryPoint()
		{
			@Override
			public int invoke(int handle, DoubleByReference value)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetTotalSubstituicaoTributaria(handle, value);
			}
		});

	}

	public double getTotalNaoTributado() throws ACBrException
	{

		return getDouble(new GetDoubleEntryPoint()
		{
			@Override
			public int invoke(int handle, DoubleByReference value)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetTotalNaoTributado(handle, value);
			}
		});

	}

	public double getTotalIsencao() throws ACBrException
	{

		return getDouble(new GetDoubleEntryPoint()
		{
			@Override
			public int invoke(int handle, DoubleByReference value)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetTotalIsencao(handle, value);
			}
		});

	}

	public double getTotalCancelamentosISSQN() throws ACBrException
	{

		return getDouble(new GetDoubleEntryPoint()
		{
			@Override
			public int invoke(int handle, DoubleByReference value)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetTotalCancelamentosISSQN(handle, value);
			}
		});

	}

	public double getTotalDescontosISSQN() throws ACBrException
	{

		return getDouble(new GetDoubleEntryPoint()
		{
			@Override
			public int invoke(int handle, DoubleByReference value)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetTotalDescontosISSQN(handle, value);
			}
		});

	}

	public double getTotalAcrescimosISSQN() throws ACBrException
	{

		return getDouble(new GetDoubleEntryPoint()
		{
			@Override
			public int invoke(int handle, DoubleByReference value)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetTotalAcrescimosISSQN(handle, value);
			}
		});

	}

	public double getTotalSubstituicaoTributariaISSQN() throws ACBrException
	{

		return getDouble(new GetDoubleEntryPoint()
		{
			@Override
			public int invoke(int handle, DoubleByReference value)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetTotalSubstituicaoTributariaISSQN(handle, value);
			}
		});

	}

	public double getTotalNaoTributadoISSQN() throws ACBrException
	{

		return getDouble(new GetDoubleEntryPoint()
		{
			@Override
			public int invoke(int handle, DoubleByReference value)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetTotalNaoTributadoISSQN(handle, value);
			}
		});

	}

	public double getTotalIsencaoISSQN() throws ACBrException
	{

		return getDouble(new GetDoubleEntryPoint()
		{
			@Override
			public int invoke(int handle, DoubleByReference value)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetTotalIsencaoISSQN(handle, value);
			}
		});

	}

	public double getTotalNaoFiscal() throws ACBrException
	{

		return getDouble(new GetDoubleEntryPoint()
		{
			@Override
			public int invoke(int handle, DoubleByReference value)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetTotalNaoFiscal(handle, value);
			}
		});

	}

	public int getNumUltItem() throws ACBrException
	{

		return getInt(new GetIntEntryPoint()
		{
			@Override
			public int invoke(int handle)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetNumUltItem(handle);
			}
		});

	}

	public boolean getPoucoPapel() throws ACBrException
	{

		return getBoolean(new GetBooleanEntryPoint()
		{
			@Override
			public int invoke(int handle)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetPoucoPapel(handle);
			}
		});

	}

	public int getEstado() throws ACBrException
	{

		return getInt(new GetIntEntryPoint()
		{
			@Override
			public int invoke(int handle)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetEstado(handle);
			}
		});

	}

	public boolean getHorarioVerao() throws ACBrException
	{

		return getBoolean(new GetBooleanEntryPoint()
		{
			@Override
			public int invoke(int handle)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetHorarioVerao(handle);
			}
		});

	}

	public boolean getArredonda() throws ACBrException
	{

		return getBoolean(new GetBooleanEntryPoint()
		{
			@Override
			public int invoke(int handle)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetArredonda(handle);
			}
		});

	}

	public boolean getTermica() throws ACBrException
	{

		return getBoolean(new GetBooleanEntryPoint()
		{
			@Override
			public int invoke(int handle)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetTermica(handle);
			}
		});

	}

	public boolean getMFD() throws ACBrException
	{

		return getBoolean(new GetBooleanEntryPoint()
		{
			@Override
			public int invoke(int handle)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetMFD(handle);
			}
		});

	}

	public String getMFAdicional() throws ACBrException
	{

		return getString(new GetStringEntryPoint()
		{
			@Override
			public int invoke(int handle, ByteBuffer buffer, int bufferLen)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetMFAdicional(handle, buffer, bufferLen);
			}
		});

	}

	public boolean getIdentificaConsumidorRodape() throws ACBrException
	{

		return getBoolean(new GetBooleanEntryPoint()
		{
			@Override
			public int invoke(int handle)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetIdentificaConsumidorRodape(handle);
			}
		});

	}

	public boolean getParamDescontoISSQN() throws ACBrException
	{

		return getBoolean(new GetBooleanEntryPoint()
		{
			@Override
			public int invoke(int handle)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetParamDescontoISSQN(handle);
			}
		});

	}

	public double getSubTotal() throws ACBrException
	{

		return getDouble(new GetDoubleEntryPoint()
		{
			@Override
			public int invoke(int handle, DoubleByReference value)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetSubTotal(handle, value);
			}
		});

	}

	public double getTotalPago() throws ACBrException
	{

		return getDouble(new GetDoubleEntryPoint()
		{
			@Override
			public int invoke(int handle, DoubleByReference value)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetTotalPago(handle, value);
			}
		});

	}

	public boolean getGavetaAberta() throws ACBrException
	{

		return getBoolean(new GetBooleanEntryPoint()
		{
			@Override
			public int invoke(int handle)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetGavetaAberta(handle);
			}
		});

	}

	public boolean getChequePronto() throws ACBrException
	{

		return getBoolean(new GetBooleanEntryPoint()
		{
			@Override
			public int invoke(int handle)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetChequePronto(handle);
			}
		});

	}

	public int getIntervaloAposComando() throws ACBrException
	{

		return getInt(new GetIntEntryPoint()
		{
			@Override
			public int invoke(int handle)
			{
				return ACBrECFInterop.INSTANCE.ECF_GetIntervaloAposComando(handle);
			}
		});

	}

	public void setIntervaloAposComando(int value) throws ACBrException
	{

		setInt(value, new SetIntEntryPoint()
		{
			@Override
			public int invoke(int handle, int value)
			{
				return ACBrECFInterop.INSTANCE.ECF_SetIntervaloAposComando(handle, value);
			}
		});

	}

	public FormaPagamento[] getFormasPagamento() throws ACBrException
	{
		return formasPagamento;
	}
	
	/*public Aliquota[] getAliquotas() throws ACBrException
	 * {
	 * //Nao implementado
	 * }
	 * 

	 * 
	 * public RelatorioGerencial[] getRelatoriosGerenciais() throws ACBrException
	 * {
	 * //Nao implementado
	 * }
	 * 
	 * public ComprovanteNaoFiscal[] getComprovantesNaoFiscais() throws ACBrException
	 * {
	 * //Nao implementado
	 * }
	 * 
	 * public Consumidor getConsumidor() throws ACBrException
	 * {
	 * //Nao implementado
	 * }
	 * 
	 * public DadosReducaoZClass getDadosReducaoZClass() throws ACBrException
	 * {
	 * //Nao implementado
	 * }
	 * 
	 * public IntPtr getHandle() throws ACBrException
	 * {
	 * //Nao implementado
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
		for(int i=0; i<linhas.length; i++ )
		{
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
		for(int i=0; i<linhas.length; i++ )
		{
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


		int ret = ACBrECFInterop.INSTANCE.ECF_ProgramaAliquota(getHandle(), aliquota, tipo.charAt(0) , toUTF8(posicao));
		checkResult(ret);


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

	private void carregaFormasPagamento(int count) throws ACBrException
	{

		FormaPagamento[] array = new FormaPagamento[count];
		for (int i=0; i<count; i++)
		{
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


		int ret = ACBrECFInterop.INSTANCE.ECF_CancelaDescontoAcrescimoSubTotal(getHandle(), tipoAcrescimoDesconto.charAt(0) );
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
