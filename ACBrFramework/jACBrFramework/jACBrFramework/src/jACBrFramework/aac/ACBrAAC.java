package jACBrFramework.aac;

import com.sun.jna.ptr.DoubleByReference;
import com.sun.jna.ptr.IntByReference;
import jACBrFramework.ACBrClass;
import jACBrFramework.ACBrEventListener;
import jACBrFramework.ACBrException;
import jACBrFramework.OleDate;
import jACBrFramework.interop.ACBrAACInterop;
import java.nio.ByteBuffer;
import java.nio.charset.Charset;

/**
 * Classe para para as operacoes AAC.
 * 
 * @author Jose Mauro
 * @version Criado em: 11/12/2013 09:25:39, revisao: $Id$
 */
public class ACBrAAC extends ACBrClass {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Identificacao do PAF.
     */
    private IdenticacaoPaf identPaf = new IdenticacaoPaf(this);
    // </editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    /**
     * Construtor padrao.
     *
     * @throws ACBrException excecao acionada ao construir o objeto.
     */
    public ACBrAAC() throws ACBrException {
    }
    /**
     * Cria um novo objeto com base no charset recebido.
     * 
     * @param pCharset charset utilizado na conversao para geracao do sintegra.
     */
    public ACBrAAC(Charset pCharset) throws ACBrException {
        this();
        setCustomCharset(pCharset);
    }    
    // </editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Override Methods">
    /**
     * Realiza a inicializacao da comunicacao com a acbr.
     *
     * @throws ACBrException excecao acionada ao inicializar o componente.
     */
    @Override
    protected void onInitialize() throws ACBrException {
        IntByReference handle = new IntByReference();
        int ret = ACBrAACInterop.INSTANCE.AAC_Create(handle);
        checkResult(ret);
        setHandle(handle.getValue());
    }

    /**
     * Finaliza a comunicacao com a acbr.
     *
     * @throws ACBrException excecao acionada ao finalizar a comunicacao.
     */
    @Override
    protected void onFinalize() throws ACBrException {
        if (getHandle() != 0) {
            int ret = ACBrAACInterop.INSTANCE.AAC_Destroy(getHandle());
            checkResult(ret);
            setHandle(0);
        }
    }

    /**
     * Responsavel pela verificacao dos resultados a cada operacao.
     *
     * @param pResult resultado da operacao.
     * @throws ACBrException mensagem de erro caso nao tenha havido
     * processamento com sucesso.
     */
    @Override
    protected void checkResult(int pResult) throws ACBrException {
        switch (pResult) {
            case -1: {
                String lMessage;
                final int LEN = 1024;
                ByteBuffer buffer = ByteBuffer.allocate(LEN);
                int ret = ACBrAACInterop.INSTANCE.AAC_GetUltimoErro(getHandle(), buffer, LEN);

                lMessage = fromUTF8(buffer, ret);
                throw new ACBrException(lMessage);
            }
            case -2: {
                throw new ACBrException("ACBr AAC não inicializado.");
            }
        }
    }
    
    /**
     * {@inheritDoc}
     */
    @Override
    protected String toUTF8(String value) {
        return super.toUTF8(value); 
    }    

    /**
     * {@inheritDoc}
     */    
    @Override
    protected String fromUTF8(ByteBuffer buffer, int len) {
        return super.fromUTF8(buffer, len); 
    }
    
    /**
     * {@inheritDoc}
     */    
    @Override
    protected String fromUTF8(byte[] value) {
        return super.fromUTF8(value); 
    }    

    /**
     * {@inheritDoc}
     */    
    @Override
    protected byte[] toByte(String pValue, int pSize) {
        return super.toByte(pValue, pSize); 
    }    
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Components Methods">
    /**
     * Seta a chave para criptografia dos arquivos.
     * 
     * {@see ACBrAAC#addOnGetChave}
     * @param pKey chave.
     */
    public void setKey(final String pKey) {
        addOnGetChave(new ACBrEventListener<AACGetChaveEventObject>() {
            @Override
            public void notification(AACGetChaveEventObject e) {
                e.setKey(pKey);
            }
        });
    }    
        
    /**
     * Nome do arquivo auxiliar.
     * 
     * @param pNomeArquivoAuxiliar
     * @throws ACBrException 
     */
    public void setNomeArquivoAuxiliar(String pNomeArquivoAuxiliar) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_SetNomeArquivoAux(getHandle(), toUTF8(pNomeArquivoAuxiliar));
        checkResult(ret);
    }
    
    /**
     * Nome do arquivo auxiliar.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getNomeArquivoAuxiliar() throws ACBrException {
        ByteBuffer lNomeArquivoAuxiliar = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrAACInterop.INSTANCE.AAC_GetNomeArquivoAux(getHandle(), lNomeArquivoAuxiliar, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lNomeArquivoAuxiliar, ret);
    }
    
    /**
     * Arquivo de log.
     * 
     * @param pArqLOG
     * @throws ACBrException 
     */
    public void setArqLOG(String pArqLOG) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_SetArqLOG(getHandle(), toUTF8(pArqLOG));
        checkResult(ret);
    }
    
    /**
     * Arquivo de log.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getArqLOG() throws ACBrException {
        ByteBuffer lArqLOG = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrAACInterop.INSTANCE.AAC_GetArqLOG(getHandle(), lArqLOG, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lArqLOG, ret);
    }
    
    /**
     * Recupera a quantidade de parametros.
     * 
     * @return
     * @throws ACBrException 
     */
    public int getParamsCount() throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_GetParamsCount(getHandle());
        return ret;
    }
    
    /**
     * Seta os parametros.
     * 
     * @param pParams
     * @throws ACBrException 
     */
    public void setParams(String[] pParams) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_SetParams(getHandle(), toUTF8(pParams), pParams.length);
        checkResult(ret);
    }
    
    /**
     * Recupera a lista de parametros.
     * 
     * @return
     * @throws ACBrException 
     */
    public String[] getParams() throws ACBrException {
		int lCount = getParamsCount();
		checkResult(lCount);

		String[] lParams = new String[lCount];
		for (int i = 0; i < lParams.length; i++) {
			ByteBuffer lReturnBuffer = ByteBuffer.allocate(STR_BUFFER_LEN);
			int ret = ACBrAACInterop.INSTANCE.AAC_GetParams(getHandle(), lReturnBuffer, STR_BUFFER_LEN, i);
			checkResult(ret);

			lParams[i] = fromUTF8(lReturnBuffer, ret);
		}

		return lParams;        
    }    
    
    /**
     * Indica a criacao de arquivo de backup.
     * 
     * @param pCriarBAK indica a criacao de arquivo de backup.
     * @throws ACBrException 
     */
    public void setCriarBAK(boolean pCriarBAK) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_SetCriarBAK(getHandle(), pCriarBAK);
        checkResult(ret);
    }

    /**
     * Verifica a criacao de arquivo de backup.
     * 
     * @return indica a criacao de arquivo de backup.
     * @throws ACBrException 
     */
    public boolean isCriarBAK() throws ACBrException {
        return ACBrAACInterop.INSTANCE.AAC_GetCriarBAK(getHandle()) != 0;
    }     
    
    /**
     * Indica a realizacao de flush nos arquivos.
     * 
     * @param pEfetuarFlush indica a realizacao de flush nos arquivos.
     * @throws ACBrException 
     */
    public void setEfetuarFlush(boolean pEfetuarFlush) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_SetEfetuarFlush(getHandle(), pEfetuarFlush);
        checkResult(ret);
    }

    /**
     * Verifica a realizacao de flush nos arquivos.
     * 
     * @return indica a realizacao de flush nos arquivos.
     * @throws ACBrException 
     */
    public boolean isEfetuarFlush() throws ACBrException {
        return ACBrAACInterop.INSTANCE.AAC_GetEfetuarFlush(getHandle()) != 0;
    }     
    
    /**
     * Indica a gravacao da configuracao com aplicacao.
     * 
     * @param pGravarConfigApp indica a gravacao da configuracao com aplicacao.
     * @throws ACBrException 
     */
    public void setGravarConfigApp(boolean pGravarConfigApp) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_SetGravarConfigApp(getHandle(), pGravarConfigApp);
        checkResult(ret);
    }

    /**
     * Verifica a gravacao da configuracao com aplicacao.
     * 
     * @return indica a gravacao da configuracao com aplicacao.
     * @throws ACBrException 
     */
    public boolean isGravarConfigApp() throws ACBrException {
        return ACBrAACInterop.INSTANCE.AAC_GetGravarConfigApp(getHandle()) != 0;
    }     
        
    /**
     * Indica a gravacao dos dados do PAF.
     * 
     * @param pGravarDadosPAF indica a gravacao dos dados do PAF.
     * @throws ACBrException 
     */
    public void setGravarDadosPAF(boolean pGravarDadosPAF) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_SetGravarDadosPAF(getHandle(), pGravarDadosPAF);
        checkResult(ret);
    }

    /**
     * Verifica a gravacao dos dados do PAF.
     * 
     * @return indica a gravacao dos dados do PAF.
     * @throws ACBrException 
     */
    public boolean isGravarDadosPAF() throws ACBrException {
        return ACBrAACInterop.INSTANCE.AAC_GetGravarDadosPAF(getHandle()) != 0;
    }       
    
    /**
     * Indica a gravacao dos dados da SH.
     * 
     * @param pGravarDadosSH indica a gravacao dos dados da SH.
     * @throws ACBrException 
     */
    public void setGravarDadosSH(boolean pGravarDadosSH) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_SetGravarDadosSH(getHandle(), pGravarDadosSH);
        checkResult(ret);
    }

    /**
     * Verifica a gravacao dos dados da SH.
     * 
     * @return indica a gravacao dos dados da SH.
     * @throws ACBrException 
     */
    public boolean isGravarDadosSH() throws ACBrException {
        return ACBrAACInterop.INSTANCE.AAC_GetGravarDadosSH(getHandle()) != 0;
    }       

    /**
     * Indica a gravacao dos dados das ECFs.
     * 
     * @param pGravarTodosECFs indica a gravacao dos dados das ECFs.
     * @throws ACBrException 
     */
    public void setGravarTodosECFs(boolean pGravarTodosECFs) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_SetGravarTodosECFs(getHandle(), pGravarTodosECFs);
        checkResult(ret);
    }

    /**
     * Verifica a gravacao dos dados das ECFs.
     * 
     * @return indica a gravacao dos dados das ECFs.
     * @throws ACBrException 
     */
    public boolean isGravarTodosECFs() throws ACBrException {
        return ACBrAACInterop.INSTANCE.AAC_GetGravarTodosECFs(getHandle()) != 0;
    }       
    
    /**
     * Realiza a abertura do arquivo.
     * 
     * @throws ACBrException 
     */
    public void abrirArquivo() throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_AbrirArquivo(getHandle());
        checkResult(ret);
    }    
    
    /**
     * Realiza o salvamento do arquivo.
     * 
     * @throws ACBrException 
     */
    public void salvarArquivo() throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_SalvarArquivo(getHandle());
        checkResult(ret);
    }  
    
    /**
     * Realiza a verificacao para recarregamento de arquivo.
     * 
     * @throws ACBrException 
     */
    public void verificaReCarregarArquivo() throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_VerificaReCarregarArquivo(getHandle());
        checkResult(ret);
    }    
    
    /**
     * Verifica o total GT.
     * 
     * @param pNumSerie numero de serie do equipamento.
     * @return
     * @throws ACBrException 
     */
    public double verificarGTECF(String pNumSerie) throws ACBrException {        
        DoubleByReference lTotal = new DoubleByReference();
        int ret = ACBrAACInterop.INSTANCE.AAC_VerificarGTECF(getHandle(), toUTF8(pNumSerie), lTotal);
        checkResult(ret);
        return lTotal.getValue();
    }
   
    /**
     * Realiza a atualizacao do GT.
     * 
     * @param pNumSerie numero de serie do equipamento.
     * @param pGrandeTotal valor do GT.
     * @throws ACBrException 
     */
    public void atualizarValorGT(String pNumSerie, double pGrandeTotal) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_AtualizarValorGT(getHandle(), toUTF8(pNumSerie), pGrandeTotal);
        checkResult(ret);
    }  
    
    /**
     * Realiza a atualizacao do MD5.
     * 
     * @param pMd5 md5 a ser atualizado.
     * @throws ACBrException 
     */
    public void atualizarMD5(String pMd5) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_AtualizarMD5(getHandle(), toUTF8(pMd5));
        checkResult(ret);
    }    
    
    /**
     * Acha o indice da ECF.
     * 
     * @param pSerie serie da ecf.
     * @return
     * @throws ACBrException 
     */
    public int achaIndiceECF(String pSerie) throws ACBrException {
        IntByReference lIndice = new IntByReference();
        int ret = ACBrAACInterop.INSTANCE.AAC_AchaIndiceECF(getHandle(), toUTF8(pSerie), lIndice);
        checkResult(ret);
        return lIndice.getValue();
    }   
    
    /**
     * Obtem os dados da ECF com base na serie recebida.
     * 
     * @param pSerie serie a ser considerada.
     * @return
     * @throws ACBrException 
     */
    public AACECF achaECF(String pSerie) throws ACBrException{
        ACBrAACInterop.TECFAutorizado lEcfAutorizado = new ACBrAACInterop.TECFAutorizado();
        int ret = ACBrAACInterop.INSTANCE.AAC_AchaECF(getHandle(), toUTF8(pSerie), lEcfAutorizado);
        checkResult(ret);

        if (ret == 0) return null;

        AACECF lEcf = new AACECF();
        lEcf.setCni(lEcfAutorizado.CNI); 
        lEcf.setCro(lEcfAutorizado.CRO);
        lEcf.setValorGT(lEcfAutorizado.ValorGT);
        lEcf.setDtHrAtualizado(OleDate.fromOADate(lEcfAutorizado.DtHrAtualizado));
        lEcf.setNumeroSerie(fromUTF8(lEcfAutorizado.NumeroSerie));

        return lEcf;
    }
    // </editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onAntesGravarArquivo">
    /**
     * Adiciona o listener de gravacao do arquivo.
     * 
     * @param pListener 
     */
	public void addOnAntesGravarArquivo(ACBrEventListener<AACAntesArquivoEventObject> pListener) {
		if (!hasListeners("onAntesGravarArquivo")) {
			ACBrAACInterop.INSTANCE.AAC_SetAntesGravarArquivo(getHandle(), new ACBrAACInterop.AntesArquivoCallback() {
                @Override
                public boolean invoke() {
                    return onAntesGravarArquivo();
                }
			});
		}
		addListener("onAntesGravarArquivo", pListener);
	}

    /**
     * Remove o listener associado.
     * 
     * @param pListener 
     */
	public void removeOnAntesGravarArquivo(ACBrEventListener<AACAntesArquivoEventObject> pListener) {
		removeListener("onAntesGravarArquivo", pListener);
		if (!hasListeners("onAntesGravarArquivo")) {
			ACBrAACInterop.INSTANCE.AAC_SetAntesGravarArquivo(getHandle(), null);
		}
	}

    /**
     * Obtem o status de continuidade.
     * 
     * @return 
     */
	private boolean onAntesGravarArquivo() {
		AACAntesArquivoEventObject e = new AACAntesArquivoEventObject(this, false);
		notifyListeners("onAntesGravarArquivo", e);
		return e.isContinua();
	}
	//</editor-fold>    
	//<editor-fold defaultstate="collapsed" desc="onAntesAbrirArquivo">
    /**
     * Adiciona o listener de abertura de arquivo.
     * 
     * @param pListener 
     */
	public void addOnAntesAbrirArquivo(ACBrEventListener<AACAntesArquivoEventObject> pListener) {
		if (!hasListeners("onAntesAbrirArquivo")) {
			ACBrAACInterop.INSTANCE.AAC_SetOnAntesAbrirArquivo(getHandle(), new ACBrAACInterop.AntesArquivoCallback() {
                @Override
                public boolean invoke() {
                    return onAntesAbrirArquivo();
                }
			});
		}
		addListener("onAntesAbrirArquivo", pListener);
	}

    /**
     * Remove o listener associado.
     * 
     * @param pListener 
     */
	public void removeOnAntesAbrirArquivo(ACBrEventListener<AACAntesArquivoEventObject> pListener) {
		removeListener("onAntesAbrirArquivo", pListener);
		if (!hasListeners("onAntesAbrirArquivo")) {
			ACBrAACInterop.INSTANCE.AAC_SetOnAntesAbrirArquivo(getHandle(), null);
		}
	}

    /**
     * Obtem o status de continuidade.
     * 
     * @return 
     */
	private boolean onAntesAbrirArquivo() {
		AACAntesArquivoEventObject e = new AACAntesArquivoEventObject(this, false);
		notifyListeners("onAntesAbrirArquivo", e);
		return e.isContinua();
	}
	//</editor-fold>    
	//<editor-fold defaultstate="collapsed" desc="onCrypt">
    /**
     * Adiciona o listener de criptografia.
     * 
     * @param pListener 
     */
	public void addOnCrypt(ACBrEventListener<AACCryptEventObject> pListener) {
		if (!hasListeners("onCrypt")) {
			ACBrAACInterop.INSTANCE.AAC_SetOnCrypt(getHandle(), new ACBrAACInterop.CryptCallback() {
                @Override
                public String invoke(String value) {
                    return onCrypt(value);
                }
			});
		}
		addListener("onCrypt", pListener);
	}

    /**
     * Remove o listener associado.
     * 
     * @param pListener 
     */
	public void removeOnCrypt(ACBrEventListener<AACCryptEventObject> pListener) {
		removeListener("onCrypt", pListener);
		if (!hasListeners("onCrypt")) {
			ACBrAACInterop.INSTANCE.AAC_SetOnCrypt(getHandle(), null);
		}
	}

    /**
     * String criptografada.
     * 
     * @param pConteudo conteudo a ser criptografado.
     * @return 
     */
	private String onCrypt(String pConteudo) {
		AACCryptEventObject e = new AACCryptEventObject(this, pConteudo, "");
		notifyListeners("onCrypt", e);
		return e.getResposta();
	}
	//</editor-fold>    
	//<editor-fold defaultstate="collapsed" desc="onDeCrypt">
    /**
     * Adiciona o listener de descriptografia.
     * 
     * @param pListener 
     */
	public void addOnDeCrypt(ACBrEventListener<AACCryptEventObject> pListener) {
		if (!hasListeners("onDeCrypt")) {
			ACBrAACInterop.INSTANCE.AAC_SetOnDeCrypt(getHandle(), new ACBrAACInterop.CryptCallback() {
                @Override
                public String invoke(String value) {
                    return onDeCrypt(value);
                }
			});
		}
		addListener("onDeCrypt", pListener);
	}

    /**
     * Remove o listener associado.
     * 
     * @param pListener 
     */
	public void removeOnDeCrypt(ACBrEventListener<AACCryptEventObject> pListener) {
		removeListener("onDeCrypt", pListener);
		if (!hasListeners("onDeCrypt")) {
			ACBrAACInterop.INSTANCE.AAC_SetOnDeCrypt(getHandle(), null);
		}
	}

    /**
     * String descriptografada.
     * 
     * @param pConteudo conteudo a ser descriptografado.
     * @return 
     */
	private String onDeCrypt(String pConteudo) {
		AACCryptEventObject e = new AACCryptEventObject(this, pConteudo, "");
		notifyListeners("onDeCrypt", e);
		return e.getResposta();
	}
	//</editor-fold>        
 	//<editor-fold defaultstate="collapsed" desc="onDepoisAbrirArquivo">
    /**
     * Adiciona o listener depois da abertura do arquivo.
     * 
     * @param pListener 
     */
	public void addOnDepoisAbrirArquivo(ACBrEventListener<AACDepoisArquivoEventObject> pListener) {
		if (!hasListeners("onDepoisAbrirArquivo")) {
			ACBrAACInterop.INSTANCE.AAC_SetOnDepoisAbrirArquivo(getHandle(), new ACBrAACInterop.NoArgumentsCallback() {
                @Override
                public void invoke() {
                    onDepoisAbrirArquivo();
                }
            });
		}
		addListener("onDepoisAbrirArquivo", pListener);
	}

    /**
     * Remove o listener associado.
     * 
     * @param pListener 
     */
	public void removeOnDepoisAbrirArquivo(ACBrEventListener<AACDepoisArquivoEventObject> pListener) {
		removeListener("onDepoisAbrirArquivo", pListener);
		if (!hasListeners("onDepoisAbrirArquivo")) {
			ACBrAACInterop.INSTANCE.AAC_SetOnDepoisAbrirArquivo(getHandle(), null);
		}
	}

    /**
     * Obtem o status de continuidade.
     */
	private void onDepoisAbrirArquivo() {
		AACDepoisArquivoEventObject e = new AACDepoisArquivoEventObject(this);
		notifyListeners("onDepoisAbrirArquivo", e);
	}
	//</editor-fold>       
	//<editor-fold defaultstate="collapsed" desc="onDepoisGravarArquivo">
    /**
     * Adiciona o listener depois da abertura do arquivo.
     * 
     * @param pListener 
     */
	public void addOnDepoisGravarArquivo(ACBrEventListener<AACDepoisArquivoEventObject> pListener) {
		if (!hasListeners("onDepoisGravarArquivo")) {
			ACBrAACInterop.INSTANCE.AAC_SetOnDepoisGravarArquivo(getHandle(), new ACBrAACInterop.NoArgumentsCallback() {
                @Override
                public void invoke() {
                    onDepoisGravarArquivo();
                }
            });
		}
		addListener("onDepoisGravarArquivo", pListener);
	}

    /**
     * Remove o listener associado.
     * 
     * @param pListener 
     */
	public void removeOnDepoisGravarArquivo(ACBrEventListener<AACDepoisArquivoEventObject> pListener) {
		removeListener("onDepoisGravarArquivo", pListener);
		if (!hasListeners("onDepoisGravarArquivo")) {
			ACBrAACInterop.INSTANCE.AAC_SetOnDepoisGravarArquivo(getHandle(), null);
		}
	}

    /**
     * Obtem o status de continuidade.
     */
	private void onDepoisGravarArquivo() {
		AACDepoisArquivoEventObject e = new AACDepoisArquivoEventObject(this);
		notifyListeners("onDepoisGravarArquivo", e);
	}
	//</editor-fold>       
	//<editor-fold defaultstate="collapsed" desc="onGetChave">
    /**
     * Adiciona o listener para obtencao da chave de criptografia.
     * 
     * @param pListener 
     */
	public void addOnGetChave(ACBrEventListener<AACGetChaveEventObject> pListener) {
		if (!hasListeners("onGetChave")) {
			ACBrAACInterop.INSTANCE.AAC_SetOnGetChave(getHandle(), new ACBrAACInterop.OnGetChaveCallback() {
                @Override
                public String invoke() {
                    return onGetChave();
                }
			});
		}
		addListener("onGetChave", pListener);
	}

    /**
     * Remove o listener associado.
     * 
     * @param pListener 
     */
	public void removeOnGetChave(ACBrEventListener<AACGetChaveEventObject> pListener) {
		removeListener("onGetChave", pListener);
		if (!hasListeners("onGetChave")) {
			ACBrAACInterop.INSTANCE.AAC_SetOnGetChave(getHandle(), null);
		}
	}

    /**
     * Chave associada ao arquivo.
     * 
     * @return 
     */
	private String onGetChave() {
		AACGetChaveEventObject e = new AACGetChaveEventObject(this, "");
		notifyListeners("onGetChave", e);
		return e.getKey();
	}
	//</editor-fold>        
	//<editor-fold defaultstate="collapsed" desc="onVerificarRecomporNumSerie">
    /**
     * Adiciona o listener para verificacao do numero de serie.
     * 
     * @param pListener 
     */
	public void addOnVerificarRecomporNumSerie(ACBrEventListener<AACVerificarRecomporNumSerieEventObject> pListener) {
		if (!hasListeners("onVerificarRecomporNumSerie")) {
			ACBrAACInterop.INSTANCE.AAC_SetVerificarRecomporNumSerie(getHandle(), new ACBrAACInterop.VerificarRecomporNumSerieCallback() {
                @Override
                public void invoke(String NumSerie, double ValorGT, IntByReference CRO, IntByReference CNI) {
                    onVerificarRecomporNumSerie(NumSerie, ValorGT, CRO, CNI);
                }
			});
		}
		addListener("onVerificarRecomporNumSerie", pListener);
	}

    /**
     * Remove o listener associado.
     * 
     * @param pListener 
     */
	public void removeOnVerificarRecomporNumSerie(ACBrEventListener<AACVerificarRecomporNumSerieEventObject> pListener) {
		removeListener("onVerificarRecomporNumSerie", pListener);
		if (!hasListeners("onVerificarRecomporNumSerie")) {
			ACBrAACInterop.INSTANCE.AAC_SetVerificarRecomporNumSerie(getHandle(), null);
		}
	}
    
    /**
     * Dispara o evento de verificacao.
     * 
     * @param pNumSerie numero de serie da ECF.
     * @param pValorGT valor do GT.
     * @param pCro contador de inicio de operacao.
     * @param pCni contator nacional de identificacao.
     */
	private void onVerificarRecomporNumSerie(String pNumSerie, double pValorGT, IntByReference pCro, IntByReference pCni) {
		AACVerificarRecomporNumSerieEventObject e = new AACVerificarRecomporNumSerieEventObject(this, 
                pNumSerie, pValorGT, pCro.getValue(), pCni.getValue());
		notifyListeners("onVerificarRecomporNumSerie", e);
	}
	//</editor-fold>        
	//<editor-fold defaultstate="collapsed" desc="onVerificarRecomporValorGT">
    /**
     * Adiciona o listener para verificacao do valor GT.
     * 
     * @param pListener 
     */
	public void addOnVerificarRecomporValorGT(ACBrEventListener<AACVerificarRecomporValorGTEventObject> pListener) {
		if (!hasListeners("onVerificarRecomporValorGT")) {
			ACBrAACInterop.INSTANCE.AAC_SetVerificarRecomporValorGT(getHandle(), new ACBrAACInterop.VerificarRecomporValorGTCallback() {
                @Override
                public void invoke(String NumSerie, DoubleByReference ValorGT) {
                    onVerificarRecomporValorGT(NumSerie, ValorGT);
                }
			});
		}
		addListener("onVerificarRecomporValorGT", pListener);
	}

    /**
     * Remove o listener associado.
     * 
     * @param pListener 
     */
	public void removeOnVerificarRecomporValorGT(ACBrEventListener<AACVerificarRecomporValorGTEventObject> pListener) {
		removeListener("onVerificarRecomporValorGT", pListener);
		if (!hasListeners("onVerificarRecomporValorGT")) {
			ACBrAACInterop.INSTANCE.AAC_SetVerificarRecomporValorGT(getHandle(), null);
		}
	}
    
    /**
     * Dispara o evento de verificacao.
     * 
     * @param pNumSerie numero de serie da ECF.
     * @param pValorGT valor do GT.
     */
	private void onVerificarRecomporValorGT(String pNumSerie, DoubleByReference pValorGT) {
		AACVerificarRecomporValorGTEventObject e = new AACVerificarRecomporValorGTEventObject(this, 
                pNumSerie, pValorGT.getValue());
		notifyListeners("onVerificarRecomporValorGT", e);
	}
	//</editor-fold>        
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters"> 
    /**
     * Identificacao do PAF.
     * @return the identPaf
     */
    public IdenticacaoPaf getIdentPaf() {
        return identPaf;
    }
	//</editor-fold>        

}