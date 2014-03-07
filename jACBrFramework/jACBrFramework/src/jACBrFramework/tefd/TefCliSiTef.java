package jACBrFramework.tefd;

import com.sun.jna.ptr.IntByReference;
import jACBrFramework.ACBrComposedClass;
import jACBrFramework.ACBrEventListener;
import jACBrFramework.ACBrException;
import jACBrFramework.OleDate;
import jACBrFramework.interop.ACBrTEFInterop;
import jACBrFramework.tefd.eventos.TEFCliSiTefExibeMenuEventObject;
import jACBrFramework.tefd.eventos.TEFCliSiTefObtemCampoEventObject;
import java.nio.ByteBuffer;
import java.util.Date;

/**
 * TEF do Sitef.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/02/2014 10:28:25, revisao: $Id$
 */
public class TefCliSiTef extends ACBrComposedClass {

    //<editor-fold defaultstate="collapsed" desc="Constructor">
    TefCliSiTef(ACBrTEFD pParent) throws ACBrException {
        super(pParent);
    }
    // </editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Components Methods">
    /**
     * Seta o IP da comunicacao.
     * 
     * @param pEnderecoIP endereco IP da comunicacao.
     * @throws ACBrException 
     */
    public void setEnderecoIP(String pEnderecoIP) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFCliSiTef_SetEnderecoIP(getHandle(), toUTF8(pEnderecoIP));
        checkResult(ret);
    }
    
    /**
     * Recupera o endereco IP da comunicacao.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getEnderecoIP() throws ACBrException {
        ByteBuffer lEnderecoIP = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFCliSiTef_GetEnderecoIP(getHandle(), lEnderecoIP, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lEnderecoIP, ret);
    }

    /**
     * Seta o codigo do estabelecimento.
     * 
     * @param pCodigoLoja codigo do estabelecimento.
     * @throws ACBrException 
     */
    public void setCodigoLoja(String pCodigoLoja) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFCliSiTef_SetCodigoLoja(getHandle(), toUTF8(pCodigoLoja));
        checkResult(ret);
    }
    
    /**
     * Recupera o codigo do estabelecimento.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getCodigoLoja() throws ACBrException {
        ByteBuffer lCodigoLoja = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFCliSiTef_GetCodigoLoja(getHandle(), lCodigoLoja, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lCodigoLoja, ret);
    }
    
    /**
     * Seta o numero do terminal de transacao.
     * 
     * @param pNumeroTerminal numero do terminal de transacao.
     * @throws ACBrException 
     */
    public void setNumeroTerminal(String pNumeroTerminal) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFCliSiTef_SetNumeroTerminal(getHandle(), toUTF8(pNumeroTerminal));
        checkResult(ret);
    }
    
    /**
     * Recupera o numero do terminal de transacao.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getNumeroTerminal() throws ACBrException {
        ByteBuffer lNumeroTerminal = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFCliSiTef_GetNumeroTerminal(getHandle(), lNumeroTerminal, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lNumeroTerminal, ret);
    }
    
    /**
     * Seta o operador do terminal.
     * 
     * @param pOperador operador do terminal.
     * @throws ACBrException 
     */
    public void setOperador(String pOperador) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFCliSiTef_SetOperador(getHandle(), toUTF8(pOperador));
        checkResult(ret);
    }
    
    /**
     * Recupera o operador do terminal.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getOperador() throws ACBrException {
        ByteBuffer lOperador = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFCliSiTef_GetOperador(getHandle(), lOperador, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lOperador, ret);
    }    
    
    /**
     * Seta as restricoes.
     * 
     * @param pRestricoes restricoes.
     * @throws ACBrException 
     */
    public void setRestricoes(String pRestricoes) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFCliSiTef_SetRestricoes(getHandle(), toUTF8(pRestricoes));
        checkResult(ret);
    }
    
    /**
     * Recupera as restricoes.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getRestricoes() throws ACBrException {
        ByteBuffer lRestricoes = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFCliSiTef_GetRestricoes(getHandle(), lRestricoes, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lRestricoes, ret);
    }    
    
    /**
     * Seta os parametros adicionais.
     * 
     * @param pParametros parametros adicionais.
     * @throws ACBrException 
     */
    public void setParametrosAdicionais(String[] pParametros) throws ACBrException {
        if (pParametros != null) {
            int ret = ACBrTEFInterop.INSTANCE.TEF_TEFCliSiTef_SetParametrosAdicionais(getHandle(), toUTF8(pParametros), pParametros.length);
            checkResult(ret);   
        }
    }
    
    /**
     * Obtem os parametros adicionais.
     * 
     * @return linhas do comprovante.
     * @throws ACBrException 
     */
    public String[] getParametrosAdicionais() throws ACBrException {
        int count = ACBrTEFInterop.INSTANCE.TEF_TEFCliSiTef_GetParametrosAdicionaisCount(getHandle());
        checkResult(count);
        String[] lParametros = new String[count];
        for (int i = 0; i < count; i++) {
            ByteBuffer lParametro = ByteBuffer.allocate(STR_BUFFER_LEN);
            int ret = ACBrTEFInterop.INSTANCE.TEF_TEFCliSiTef_GetParametrosAdicionais(getHandle(), lParametro, STR_BUFFER_LEN, i);
            checkResult(ret);   
            lParametros[i] = fromUTF8(lParametro, ret);
        }
        return lParametros;
    }    
    
    /**
     * Seta o nome do TEF.
     * 
     * @param pName nome do TEF.
     * @throws ACBrException 
     */
    public void setName(String pName) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFCliSiTef_SetName(getHandle(), toUTF8(pName));
        checkResult(ret);
    }
    
    /**
     * Recupera o nome do TEF.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getName() throws ACBrException {
        ByteBuffer lName = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFCliSiTef_GetName(getHandle(), lName, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lName, ret);
    }    
    
    /**
     * Indica se o TEF esta habilitado.
     * 
     * @param pHabilitado indica se o TEF esta habilitado.
     * @throws ACBrException 
     */
    public void setHabilitado(boolean pHabilitado) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFCliSiTef_SetHabilitado(getHandle(), pHabilitado);
        checkResult(ret);
    }
    
    /**
     * Verifica se o TEF esta habilitado.
     * 
     * @return indica se o TEF esta habilitado.
     * @throws ACBrException 
     */
    public boolean isHabilitado() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFCliSiTef_GetHabilitado(getHandle());
        checkResult(ret);
        return ret == 1;
    }
    
    /**
     * Informa operacao ATV.
     * 
     * @param pOperacaoATV informa operacao ATV.
     * @throws ACBrException 
     */
    public void setOperacaoATV(int pOperacaoATV) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFCliSiTef_SetOperacaoATV(getHandle(), pOperacaoATV);
        checkResult(ret);
    }
    
    /**
     * Verifica operacao ATV.
     * 
     * @return operacao ATV.
     * @throws ACBrException 
     */
    public int getOperacaoATV() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFCliSiTef_GetOperacaoATV(getHandle());
        checkResult(ret);
        return ret;
    }  
    
    /**
     * Informa operacao ADM.
     * 
     * @param pOperacaoADM informa operacao ADM.
     * @throws ACBrException 
     */
    public void setOperacaoADM(int pOperacaoADM) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFCliSiTef_SetOperacaoADM(getHandle(), pOperacaoADM);
        checkResult(ret);
    }
    
    /**
     * Verifica operacao ADM.
     * 
     * @return operacao ADM.
     * @throws ACBrException 
     */
    public int getOperacaoADM() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFCliSiTef_GetOperacaoADM(getHandle());
        checkResult(ret);
        return ret;
    }         
    
    /**
     * Informa operacao CRT.
     * 
     * @param pOperacaoCRT informa operacao CRT.
     * @throws ACBrException 
     */
    public void setOperacaoCRT(int pOperacaoCRT) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFCliSiTef_SetOperacaoCRT(getHandle(), pOperacaoCRT);
        checkResult(ret);
    }
    
    /**
     * Verifica operacao CRT.
     * 
     * @return operacao CRT.
     * @throws ACBrException 
     */
    public int getOperacaoCRT() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFCliSiTef_GetOperacaoCRT(getHandle());
        checkResult(ret);
        return ret;
    }         
    
    /**
     * Informa operacao CHQ.
     * 
     * @param pOperacaoCHQ informa operacao CHQ.
     * @throws ACBrException 
     */
    public void setOperacaoCHQ(int pOperacaoCHQ) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFCliSiTef_SetOperacaoCHQ(getHandle(), pOperacaoCHQ);
        checkResult(ret);
    }
    
    /**
     * Verifica operacao CHQ.
     * 
     * @return operacao CHQ.
     * @throws ACBrException 
     */
    public int getOperacaoCHQ() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFCliSiTef_GetOperacaoCHQ(getHandle());
        checkResult(ret);
        return ret;
    }         
    
    /**
     * Informa operacao CNC.
     * 
     * @param pOperacaoCNC informa operacao CNC.
     * @throws ACBrException 
     */
    public void setOperacaoCNC(int pOperacaoCNC) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFCliSiTef_SetOperacaoCNC(getHandle(), pOperacaoCNC);
        checkResult(ret);
    }
    
    /**
     * Verifica operacao CNC.
     * 
     * @return operacao CNC.
     * @throws ACBrException 
     */
    public int getOperacaoCNC() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFCliSiTef_GetOperacaoCNC(getHandle());
        checkResult(ret);
        return ret;
    }         
    
    /**
     * Informa operacao de reimpressao.
     * 
     * @param pOperacaoReImpressao informa operacao de reimpressao.
     * @throws ACBrException 
     */
    public void setOperacaoReImpressao(int pOperacaoReImpressao) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFCliSiTef_SetOperacaoReImpressao(getHandle(), pOperacaoReImpressao);
        checkResult(ret);
    }
    
    /**
     * Verifica operacao de reimpressao.
     * 
     * @return operacao de reimpressao.
     * @throws ACBrException 
     */
    public int getOperacaoReImpressao() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFCliSiTef_GetOperacaoReImpressao(getHandle());
        checkResult(ret);
        return ret;
    }      
    
    /**
     * Define a mensagem permanente PINPAD
     * @param pMensagem mensagem a ser utilizada.
     * @return
     * @throws ACBrException 
     */
    public int defineMensagemPermanentePinPad(String pMensagem) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFCliSiTef_DefineMensagemPermanentePinPad(getHandle(), toUTF8(pMensagem));
        checkResult(ret);
        return ret;
    }   
    
    /**
     * Obtem a quantidade de transacoes pendentes.
     * 
     * @param pData data para verificacao.
     * @param pCupomFiscal cupom fiscal para verificacao.
     * @return
     * @throws ACBrException 
     */
    public int obtemQuantidadeTransacoesPendentes(Date pData, String pCupomFiscal) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFCliSiTef_ObtemQuantidadeTransacoesPendentes(getHandle(), OleDate.toOADate(pData), toUTF8(pCupomFiscal));
        checkResult(ret);
        return ret;
    }    
    // </editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onExibeMenu">
	public void addOnExibeMenu(ACBrEventListener<TEFCliSiTefExibeMenuEventObject> pListener) {
		if (!hasListeners("onExibeMenu")) {
            ACBrTEFInterop.INSTANCE.TEF_TEFCliSiTef_SetOnExibeMenu(getHandle(), new ACBrTEFInterop.TEFCliSiTefExibeMenuCallback() {

                @Override
                public void invoke(String pTitulo, int pOpcoes, int pOpcoesCount, IntByReference pItemSelecionado, IntByReference pVoltarMenu) {
                    onExibeMenu(pTitulo, pOpcoes, pOpcoesCount, pItemSelecionado, pVoltarMenu);
                }
			});
		}
		addListener("onExibeMenu", pListener);
	}
    
	public void removeOnExibeMenu(ACBrEventListener<TEFCliSiTefExibeMenuEventObject> pListener) {
		removeListener("onExibeMenu", pListener);

		if (!hasListeners("onExibeMenu")) {
			ACBrTEFInterop.INSTANCE.TEF_TEFCliSiTef_SetOnExibeMenu(getHandle(), null);
		}
	}

	private void onExibeMenu(String pTitulo, int pOpcoes, int pOpcoesCount, IntByReference pItemSelecionado, IntByReference pVoltarMenu) {
		TEFCliSiTefExibeMenuEventObject e = new TEFCliSiTefExibeMenuEventObject(this, pTitulo, pOpcoes, pOpcoesCount);
        //TODO Verificar processo de leitura de opcoes.
        pItemSelecionado = e.getItemSelecionado();
        pVoltarMenu = e.getItemSelecionado();
		notifyListeners("onExibeMenu", e);
	}
	//</editor-fold>  
	//<editor-fold defaultstate="collapsed" desc="onObtemCampo">
	public void addOnObtemCampo(ACBrEventListener<TEFCliSiTefObtemCampoEventObject> pListener) {
		if (!hasListeners("onObtemCampo")) {
            ACBrTEFInterop.INSTANCE.TEF_TEFCliSiTef_SetOnObtemCampo(getHandle(), new ACBrTEFInterop.TEFCliSiTefObtemCampoCalback() {

                @Override
                public void invoke(String pTitulo, int pTamanhoMinimo, int pTamanhoMaximo, int pTipoCampo, 
                int pOperacao, ByteBuffer pResposta, int pRespLen, IntByReference pDigitado, IntByReference pVoltarMenu) {
                    onObtemCampo(pTitulo, pTamanhoMinimo, pTamanhoMaximo, pTipoCampo, pOperacao, pResposta, pRespLen, pDigitado, pVoltarMenu);
                }
			});
		}
		addListener("onObtemCampo", pListener);
	}
    
	public void removeOnObtemCampo(ACBrEventListener<TEFCliSiTefObtemCampoEventObject> pListener) {
		removeListener("onObtemCampo", pListener);

		if (!hasListeners("onObtemCampo")) {
			ACBrTEFInterop.INSTANCE.TEF_TEFCliSiTef_SetOnObtemCampo(getHandle(), null);
		}
	}
    
	private void onObtemCampo(String pTitulo, int pTamanhoMinimo, int pTamanhoMaximo, int pTipoCampo, 
            int pOperacao, ByteBuffer pResposta, int pRespLen, IntByReference pDigitado, IntByReference pVoltarMenu) {
		TEFCliSiTefObtemCampoEventObject e = new TEFCliSiTefObtemCampoEventObject(this, pTitulo, pTamanhoMinimo, 
                pTamanhoMaximo, pTipoCampo, TefCliSiTefOperacaoCampo.valueOf(pOperacao));
        //TODO Verificar processo de leitura de opcoes.
        pResposta = e.getResposta();
        pRespLen = 0;
        pDigitado = e.getDigitado();
        pVoltarMenu = e.getVoltarMenu();
		notifyListeners("onObtemCampo", e);
	}
	//</editor-fold>  
    
}