package jACBrFramework.lcb;

import com.sun.jna.ptr.IntByReference;
import jACBrFramework.ACBrClass;
import jACBrFramework.ACBrEventListener;
import jACBrFramework.ACBrException;
import jACBrFramework.interop.ACBrLCBInterop;
import java.nio.ByteBuffer;
import java.nio.charset.Charset;

/**
 * Componente para Leitores de Codigo de Barra Seriais.
 * 
 * @author Jose Mauro
 * @version Criado em: 26/05/2014 15:47:07, revisao: $Id$
 */
public final class ACBrLCB extends ACBrClass {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    // </editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    /**
     * Construtor padrao.
     *
     * @throws ACBrException excecao acionada ao construir o objeto.
     */
    public ACBrLCB() throws ACBrException {
    }
    
    /**
     * Cria um novo objeto com base no charset recebido.
     * 
     * @param pCharset charset utilizado na conversao para geracao do sintegra.
     */
    public ACBrLCB(Charset pCharset) throws ACBrException {
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
        int ret = ACBrLCBInterop.INSTANCE.LCB_Create(handle);
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
            int ret = ACBrLCBInterop.INSTANCE.LCB_Destroy(getHandle());
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
    public void checkResult(int pResult) throws ACBrException {
        switch (pResult) {
            case -1: {
                String lMessage;
                final int LEN = 1024;
                ByteBuffer buffer = ByteBuffer.allocate(LEN);
                int ret = ACBrLCBInterop.INSTANCE.LCB_GetUltimoErro(getHandle(), buffer, LEN);

                lMessage = fromUTF8(buffer, ret);
                throw new ACBrException(lMessage);
            }
            case -2: {
                throw new ACBrException("ACBr LCB não inicializado.");
            }
        }
    }    
    // </editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Components Methods">
    /**
     * Verifica se o componente esta ativo.
     * 
     * @return status do componente.
     * @throws ACBrException 
     */
    public boolean isAtivo() throws ACBrException {
        return ACBrLCBInterop.INSTANCE.LCB_GetAtivo(getHandle()) != 0;
    }

    /**
     * Seta a porta de comunicacao com o leitor serial.
     * 
     * @param pPorta porta de comunicacao.
     * @throws ACBrException 
     */
    public void setPorta(String pPorta) throws ACBrException {
        int ret = ACBrLCBInterop.INSTANCE.LCB_SetPorta(getHandle(), toUTF8(pPorta));
        checkResult(ret);
    }
    
    /**
     * Recupera a porta de comunicacao com o leitor serial
     * 
     * @return
     * @throws ACBrException 
     */
    public String getPorta() throws ACBrException {
        ByteBuffer lPorta = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrLCBInterop.INSTANCE.LCB_GetPorta(getHandle(), lPorta, STR_BUFFER_LEN);
        checkResult(ret);
        return fromUTF8(lPorta, ret);
    }
    
    /**
     * Recupera o ultimo codigo lido.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getUltimoCodigo() throws ACBrException {
        ByteBuffer lArqLOG = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrLCBInterop.INSTANCE.LCB_GetUltimoCodigo(getHandle(), lArqLOG, STR_BUFFER_LEN);
        checkResult(ret);
        return fromUTF8(lArqLOG, ret);
    }

    /**
     * Recupera a ultima leitura.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getUltimaLeitura() throws ACBrException {
        ByteBuffer lArqLOG = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrLCBInterop.INSTANCE.LCB_GetUltimaLeitura(getHandle(), lArqLOG, STR_BUFFER_LEN);
        checkResult(ret);
        return fromUTF8(lArqLOG, ret);
    }
    
    /**
     * Realiza a ativacao do componente.
     * 
     * @throws ACBrException 
     */
    public void ativar() throws ACBrException {
        int ret = ACBrLCBInterop.INSTANCE.LCB_Ativar(getHandle());
        checkResult(ret);
    }
    
    /**
     * Realiza a ativacao do componente.
     * 
     * @throws ACBrException 
     */
    public void desativar() throws ACBrException {
        int ret = ACBrLCBInterop.INSTANCE.LCB_Desativar(getHandle());
        checkResult(ret);
    }

    /**
     * Ler a string associada ao componente.
     * 
     * @return
     * @throws ACBrException 
     */
    public String lerString() throws ACBrException {
        ByteBuffer lArqLOG = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrLCBInterop.INSTANCE.LCB_LerString(getHandle(), lArqLOG, STR_BUFFER_LEN);
        checkResult(ret);
        return fromUTF8(lArqLOG, ret);
    }
    // </editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onAntesGravarArquivo">
    /**
     * Adiciona o listener de leitura de codigo.
     * 
     * @param pListener 
     */
	public void addOnLeCodigo(ACBrEventListener<LeCodigoEventObject> pListener) {
		if (!hasListeners("onLeCodigo")) {
			ACBrLCBInterop.INSTANCE.LCB_SetOnLeCodigo(getHandle(), new ACBrLCBInterop.LeCodigoCallback() {
                @Override
                public void invoke() {
                    onLeCodigo();
                }
			});
		}
		addListener("onLeCodigo", pListener);
	}

    /**
     * Remove o listener associado.
     * 
     * @param pListener 
     */
	public void removeOnLeCodigo(ACBrEventListener<LeCodigoEventObject> pListener) {
		removeListener("onLeCodigo", pListener);
		if (!hasListeners("onLeCodigo")) {
			ACBrLCBInterop.INSTANCE.LCB_SetOnLeCodigo(getHandle(), null);
		}
	}

    /**
     * Leitura o codigo de barras.
     * 
     * @return 
     */
	private void onLeCodigo() {
		LeCodigoEventObject e = new LeCodigoEventObject(this);
		notifyListeners("onLeCodigo", e);
	}
	//</editor-fold>

}