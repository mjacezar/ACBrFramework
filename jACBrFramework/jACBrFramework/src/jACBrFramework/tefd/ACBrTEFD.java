package jACBrFramework.tefd;

import com.sun.jna.ptr.DoubleByReference;
import com.sun.jna.ptr.IntByReference;
import jACBrFramework.ACBrClass;
import jACBrFramework.ACBrEventListener;
import jACBrFramework.ACBrException;
import jACBrFramework.OleDate;
import jACBrFramework.interop.ACBrTEFInterop;
import jACBrFramework.tefd.eventos.AguardaRespEventObject;
import jACBrFramework.tefd.eventos.AntesCancelarTransacaoEventObject;
import jACBrFramework.tefd.eventos.AntesFinalizarRequisicaoEventObject;
import jACBrFramework.tefd.eventos.BloqueiaMouseTecladoEventObject;
import jACBrFramework.tefd.eventos.ComandaECFAbreVinculadoEventObject;
import jACBrFramework.tefd.eventos.ComandaECFEventObject;
import jACBrFramework.tefd.eventos.ComandaECFImprimeViaEventObject;
import jACBrFramework.tefd.eventos.ComandaECFPagamentoEventObject;
import jACBrFramework.tefd.eventos.ComandaECFSubtotalizaEventObject;
import jACBrFramework.tefd.eventos.DepoisCancelarTransacoesEventObject;
import jACBrFramework.tefd.eventos.DepoisConfirmarTransacoesEventObject;
import jACBrFramework.tefd.eventos.ExecutaAcaoEventObject;
import jACBrFramework.tefd.eventos.ExibeMsgEventObject;
import jACBrFramework.tefd.eventos.InfoECFEventObject;
import jACBrFramework.tefd.eventos.MudaEstadoReqEventObject;
import jACBrFramework.tefd.eventos.MudaEstadoRespEventObject;
import java.nio.ByteBuffer;
import java.nio.charset.Charset;
import java.util.Date;

/**
 * Classe responsavel pelo acesso as funcionalidades do TEF.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/02/2014 14:57:31, revisao: $Id$
 */
public class ACBrTEFD extends ACBrClass {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * @see Identificacao
     */
    private Identificacao identificacao;
    /**
     * 
     * @see TefCliSiTef
     */
    private TefCliSiTef tefCliSiTef;
    /**
     * @see TEFVeSPague
     */
    private TEFVeSPague tefVeSPague;
    /**
     * @see TefDial
     */
    private TefDial tefDial;
    /**
     * @see TefDisc
     */
    private TefDisc tefDisc;
    /**
     * @see TefHiper
     */
    private TefHiper tefHiper;
    /**
     * @see TefGPU
     */
    private TefGPU tefGPU;
    /**
     * @see TefAuttar
     */
    private TefAuttar tefAuttar;
    /**
     * @see TefGood
     */
    private TefGood tefGood;
    /**
     * @see TefFoxWin
     */
    private TefFoxWin tefFoxWin;
    /**
     * @see TefPetrocard
     */
    private TefPetrocard tefPetrocard;
    /**
     * @see TefCrediShop
     */
    private TefCrediShop tefCrediShop;
    // </editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    /**
     * Construtor padrao.
     *
     * @throws ACBrException excecao acionada ao construir o objeto.
     */
    public ACBrTEFD() throws ACBrException {
        this.identificacao = new Identificacao(this);
        this.tefCliSiTef = new TefCliSiTef(this);
        this.tefVeSPague = new TEFVeSPague(this);
        this.tefDial = new TefDial(this);
        this.tefDisc = new TefDisc(this);
        this.tefHiper = new TefHiper(this);
        this.tefGPU = new TefGPU(this);
        this.tefAuttar = new TefAuttar(this);
        this.tefGood = new TefGood(this);
        this.tefFoxWin = new TefFoxWin(this);
        this.tefPetrocard = new TefPetrocard(this);
        this.tefCrediShop = new TefCrediShop(this);        
    }
    
    /**
     * Cria um novo objeto com base no charset recebido.
     * 
     * @param pCharset charset utilizado na conversao para geracao do sintegra.
     */
    public ACBrTEFD(Charset pCharset) throws ACBrException {
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
        int ret = ACBrTEFInterop.INSTANCE.TEF_Create(handle);
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
            int ret = ACBrTEFInterop.INSTANCE.TEF_Destroy(getHandle());
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
                int ret = ACBrTEFInterop.INSTANCE.TEF_GetUltimoErro(getHandle(), buffer, LEN);

                lMessage = fromUTF8(buffer, ret);
                throw new ACBrException(lMessage);
            }
            case -2: {
                throw new ACBrException("ACBr TEF não inicializado.");
            }
        }
    }    
    // </editor-fold>  
    //<editor-fold defaultstate="collapsed" desc="Components Methods">    
    /**
     * Recupera as informacoes do modulo.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getAbout() throws ACBrException {
        ByteBuffer lAbout = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_GetAbout(getHandle(), lAbout, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lAbout, ret);
    }    
    
    /**
     * Seta o caminho do backup.
     * 
     * @param pPathBackup caminho do backup.
     * @throws ACBrException 
     */
    public void setPathBackup(String pPathBackup) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_SetPathBackup(getHandle(), toUTF8(pPathBackup));
        checkResult(ret);
    }
    
    /**
     * Recupera o caminho do backup.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getPathBackup() throws ACBrException {
        ByteBuffer lPathBackup = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_GetPathBackup(getHandle(), lPathBackup, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lPathBackup, ret);
    }
    
    
    /**
     * Seta o arquivo de log.
     * 
     * @param pArqLOG ArqLOG para geracao.
     * @throws ACBrException 
     */
    public void setArqLOG(String pArqLOG) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_SetArqLOG(getHandle(), toUTF8(pArqLOG));
        checkResult(ret);
    }
    
    /**
     * Recupera o arquivo de log.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getArqLOG() throws ACBrException {
        ByteBuffer lArqLOG = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_GetArqLOG(getHandle(), lArqLOG, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lArqLOG, ret);
    }
    
    /**
     * Informa se sera auto ativado.
     * 
     * @param pIndAutoAtivar indica auto ativacao.
     * @throws ACBrException 
     */
    public void setAutoAtivar(boolean pIndAutoAtivar) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_SetAutoAtivar(getHandle(), pIndAutoAtivar);
        checkResult(ret);
    }
    
    /**
     * Verifica se indica auto ativacao.
     * 
     * @return indica auto ativacao.
     * @throws ACBrException 
     */
    public boolean isAutoAtivar() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_GetAutoAtivar(getHandle());
        checkResult(ret);
        return ret == 1;
    }      
    
    /**
     * Informa se sera utilizado multiplos cartoes.
     * 
     * @param pIndMultiplosCartoes indica utilizacao de multiplos cartoes.
     * @throws ACBrException 
     */
    public void setMultiplosCartoes(boolean pMultiplosCartoes) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_SetMultiplosCartoes(getHandle(), pMultiplosCartoes);
        checkResult(ret);
    }
    
    /**
     * Verifica se utiliza multiplos cartoes.
     * 
     * @return indica utilizacao de multiplos cartoes.
     * @throws ACBrException 
     */
    public boolean isMultiplosCartoes() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_GetMultiplosCartoes(getHandle());
        checkResult(ret);
        return ret == 1;
    }      

    /**
     * Informa se os pagamentos serao automaticos.
     * 
     * @param pAutoEfetuarPagamento indica pagamento automatico.
     * @throws ACBrException 
     */
    public void setAutoEfetuarPagamento(boolean pAutoEfetuarPagamento) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_SetAutoEfetuarPagamento(getHandle(), pAutoEfetuarPagamento);
        checkResult(ret);
    }
    
    /**
     * Verifica pagamento automatico.
     * 
     * @return indica pagamento automatico.
     * @throws ACBrException 
     */
    public boolean isAutoEfetuarPagamento() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_GetAutoEfetuarPagamento(getHandle());
        checkResult(ret);
        return ret == 1;
    }      

    /**
     * Informa se o cupom sera finalizado automaticamente.
     * 
     * @param pAutoFinalizarCupom indica finalizacao automatica cupom.
     * @throws ACBrException 
     */
    public void setAutoFinalizarCupom(boolean pAutoFinalizarCupom) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_SetAutoFinalizarCupom(getHandle(), pAutoFinalizarCupom);
        checkResult(ret);
    }
    
    /**
     * Verifica finalizacao automatica cupom.
     * 
     * @return indica finalizacao automatica cupom.
     * @throws ACBrException 
     */
    public boolean isAutoFinalizarCupom() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_GetAutoFinalizarCupom(getHandle());
        checkResult(ret);
        return ret == 1;
    }      

    /**
     * Informa utilizacao cheque em relatorio gerencial.
     * 
     * @param pCHQEmGerencial indica cheque em gerencial.
     * @throws ACBrException 
     */
    public void setCHQEmGerencial(boolean pCHQEmGerencial) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_SetCHQEmGerencial(getHandle(), pCHQEmGerencial);
        checkResult(ret);
    }
    
    /**
     * Verifica utilizacao cheque em gerencial.
     * 
     * @return indica cheque em gerencial.
     * @throws ACBrException 
     */
    public boolean isCHQEmGerencial() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_GetCHQEmGerencial(getHandle());
        checkResult(ret);
        return ret == 1;
    }      

    /**
     * Informa exibicao de mensagem para autenticacao.
     * 
     * @param pExibirMsgAutenticacao indica exibicao mensagem de autenticacao.
     * @throws ACBrException 
     */
    public void setExibirMsgAutenticacao(boolean pExibirMsgAutenticacao) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_SetExibirMsgAutenticacao(getHandle(), pExibirMsgAutenticacao);
        checkResult(ret);
    }
    
    /**
     * Verifica a exibicao de mensagem para autenticacao.
     * 
     * @return indica exibicao mensagem de autenticacao.
     * @throws ACBrException 
     */
    public boolean isExibirMsgAutenticacao() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_GetExibirMsgAutenticacao(getHandle());
        checkResult(ret);
        return ret == 1;
    }      
    
    /**
     * Seta o troco maximo.
     * 
     * @param pTrocoMaximo troco maximo.
     * @throws ACBrException 
     */
    public void setTrocoMaximo(double pTrocoMaximo) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_SetTrocoMaximo(getHandle(), pTrocoMaximo);
        checkResult(ret);
    }
    
    /**
     * Recupera o troco maximo.
     * 
     * @return troco maximo.
     * @throws ACBrException 
     */
    public double getTrocoMaximo() throws ACBrException {
        DoubleByReference lTrocoMaximo = new DoubleByReference();
        int ret = ACBrTEFInterop.INSTANCE.TEF_GetTrocoMaximo(getHandle(), lTrocoMaximo);
        checkResult(ret);   
        return lTrocoMaximo.getValue();
    }  
    
    /**
     * Seta o tempo de espera.
     * 
     * @param pEsperaSleep tempo de espera.
     * @throws ACBrException 
     */
    public void setEsperaSleep(int pEsperaSleep) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_SetEsperaSleep(getHandle(), pEsperaSleep);
        checkResult(ret);
    }
    
    /**
     * Recupera o tempo de espera.
     * 
     * @return tempo de espera.
     * @throws ACBrException 
     */
    public int getEsperaSleep() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_GetEsperaSleep(getHandle());
        checkResult(ret);   
        return ret;
    }      
    
    /**
     * Seta o tempo de espera STS.
     * 
     * @param pEsperaSTS tempo de espera STS.
     * @throws ACBrException 
     */
    public void setEsperaSTS(int pEsperaSTS) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_SetEsperaSTS(getHandle(), pEsperaSTS);
        checkResult(ret);
    }
    
    /**
     * Recupera o tempo de espera STS.
     * 
     * @return tempo de espera STS.
     * @throws ACBrException 
     */
    public int getEsperaSTS() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_GetEsperaSTS(getHandle());
        checkResult(ret);   
        return ret;
    }      
    
    /**
     * Seta o numero de vias para impressao.
     * 
     * @param pNumVias numero de vias.
     * @throws ACBrException 
     */
    public void setNumVias(int pNumVias) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_SetNumVias(getHandle(), pNumVias);
        checkResult(ret);
    }
    
    /**
     * Recupera o numero de vias para impressao.
     * 
     * @return numero de vias.
     * @throws ACBrException 
     */
    public int getNumVias() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_GetNumVias(getHandle());
        checkResult(ret);   
        return ret;
    }      
    
    /**
     * Seta o numero maximo de cartoes utilizados na venda.
     * 
     * @param pNumeroMaximoCartoes numero maximo de cartoes.
     * @throws ACBrException 
     */
    public void setNumeroMaximoCartoes(int pNumeroMaximoCartoes) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_SetNumeroMaximoCartoes(getHandle(), pNumeroMaximoCartoes);
        checkResult(ret);
    }
    
    /**
     * Recupera o numero maximo de cartoes.
     * 
     * @return numero maximo de cartoes.
     * @throws ACBrException 
     */
    public int getNumeroMaximoCartoes() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_GetNumeroMaximoCartoes(getHandle());
        checkResult(ret);   
        return ret;
    }      
    
    /**
     * Informa a possibilidade de saque.
     * 
     * @param pSuportaSaque indica suporte a saque.
     * @throws ACBrException 
     */
    public void setSuportaSaque(boolean pSuportaSaque) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_SetSuportaSaque(getHandle(), pSuportaSaque);
        checkResult(ret);
    }
    
    /**
     * Verifica a possibilidade de saque.
     * 
     * @return indica suporte a saque.
     * @throws ACBrException 
     */
    public boolean isSuportaSaque() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_GetSuportaSaque(getHandle());
        checkResult(ret);
        return ret == 1;
    }      

    /**
     * Informa a possibilidade de desconto.
     * 
     * @param pSuportaDesconto indica suporte a desconto.
     * @throws ACBrException 
     */
    public void setSuportaDesconto(boolean pSuportaDesconto) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_SetSuportaDesconto(getHandle(), pSuportaDesconto);
        checkResult(ret);
    }
    
    /**
     * Verifica a possibilidade de desconto.
     * 
     * @return indica suporte a desconto.
     * @throws ACBrException 
     */
    public boolean isSuportaDesconto() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_GetSuportaDesconto(getHandle());
        checkResult(ret);
        return ret == 1;
    }      
    
    /**
     * Cria uma nova requisicao.
     * 
     * @return nova requisicao criada.
     * @throws ACBrException 
     */
    public Req getReq() throws ACBrException {
        IntByReference lComposedComponent = new IntByReference();
        int ret = ACBrTEFInterop.INSTANCE.TEF_GetReq(getHandle(), lComposedComponent);
        checkResult(ret);
        return new Req(this, lComposedComponent.getValue());
    }

    /**
     * Cria uma nova resposta.
     * 
     * @return nova resposta criada.
     * @throws ACBrException 
     */
    public Resp getResp() throws ACBrException {
        IntByReference lComposedComponent = new IntByReference();
        int ret = ACBrTEFInterop.INSTANCE.TEF_GetResp(getHandle(), lComposedComponent);
        checkResult(ret);
        return new Resp(this, lComposedComponent.getValue());
    }

    /**
     * Cria um registro de respostas pendentes.
     * 
     * @return respostas pendentes.
     * @throws ACBrException 
     */
    public RespostasPendentes getRespostasPendentes() throws ACBrException {
        IntByReference lComposedComponent = new IntByReference();
        int ret = ACBrTEFInterop.INSTANCE.TEF_GetRespostasPendentes(getHandle(), lComposedComponent);
        checkResult(ret);
        return new RespostasPendentes(this, lComposedComponent.getValue());
    }
    
    /**
     * Seta o tipo do TEF.
     * 
     * @param pGPAtual tipo do TEF.
     * @throws ACBrException 
     */
    public void setGPAtual(TefTipo pGPAtual) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_SetGPAtual(getHandle(), pGPAtual.getCodigo());
        checkResult(ret);
    }
    
    /**
     * Recupera o tipo do TEF.
     * 
     * @return tipo do TEF.
     * @throws ACBrException 
     */
    public TefTipo getGPAtual() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_GetGPAtual(getHandle());
        checkResult(ret);   
        return TefTipo.valueOf(ret);
    }      
    
    /**
     * Inicializa o TEF.
     * 
     * @param pTipoTef tipo do TEF.
     * @throws ACBrException 
     */
    public void inicializar(TefTipo pTipoTef) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_Inicializar(getHandle(), pTipoTef.getCodigo());
        checkResult(ret);
    }

    /**
     * Desinicializa o TEF.
     * 
     * @param pTipoTef tipo do TEF.
     * @throws ACBrException 
     */
    public void desInicializar(TefTipo pTipoTef) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_DesInicializar(getHandle(), pTipoTef.getCodigo());
        checkResult(ret);
    }

    /**
     * Ativa o TEF.
     * 
     * @param pTipoTef tipo do TEF.
     * @throws ACBrException 
     */
    public void ativarGP(TefTipo pTipoTef) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_AtivarGP(getHandle(), pTipoTef.getCodigo());
        checkResult(ret);
    }        

    /**
     * Seta as informacoes de valores e forma de pagamento da ECF.
     * 
     * @param pValor valor do movimento.
     * @param pIndiceFPG_ECF indice da forma de pagamento.
     * @return validade da operacao.
     * @throws ACBrException 
     */
    public boolean crt(double pValor, String pIndiceFPG_ECF) throws ACBrException {
        return crt(pValor, pIndiceFPG_ECF, "", 0);
    }
    
    /**
     * Seta as informacoes vinculadas ao pagamento.
     * @param pValor valor do movimento.
     * @param pIndiceFPG_ECF indice da forma de pagamento.
     * @param pDocumentoVinculado documento vinculado.
     * @param pMoeda moeda utilizada.
     * @return validade da operacao.
     * @throws ACBrException 
     */
    public boolean crt(double pValor, String pIndiceFPG_ECF, String pDocumentoVinculado, int pMoeda) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_CRT(getHandle(), pValor, toUTF8(pIndiceFPG_ECF), toUTF8(pDocumentoVinculado), pMoeda);
        checkResult(ret);
        return ret == 1;
    }
    
    /**
     * Seta as informacoes do cheque.
     * 
     * @param pValor valor da transacao.
     * @param pIndiceFPG_ECF indice da forma de pagamento.
     * @return status da transacao.
     * @throws ACBrException 
     */
    public boolean chq(double pValor, String pIndiceFPG_ECF) throws ACBrException {
        return chq(pValor, pIndiceFPG_ECF, "", "", 'F', "", null, "", "", "", "", "", "", "", "");
    }
    
    /**
     * Seta as informacoes do cheque.
     * 
     * @param pValor valor da transacao.
     * @param pIndiceFPG_ECF indice da forma de pagamento.
     * @param pDocumentoVinculado documento vinculado a transacao.
     * @param pCMC7 codigo de barras do cheque.
     * @param pTipoPessoa tipo da pessoa.
     * @param pDocumentoPessoa documento da pessoa.
     * @param pDataCheque data do cheque;
     * @param pBanco banco.
     * @param pAgencia agencia.
     * @param pAgenciaDC agencia dc.
     * @param pConta numero da conta.
     * @param pContaDC numero da conta DC.
     * @param pCheque numero do cheque.
     * @param pChequeDC numero do cheque DC.
     * @param pCompensacao compensacao.
     * @return status da transacao.
     * @throws ACBrException 
     */
    public boolean chq(double pValor, String pIndiceFPG_ECF, String pDocumentoVinculado, String pCMC7,
        char pTipoPessoa, String pDocumentoPessoa, Date pDataCheque, String pBanco,
        String pAgencia, String pAgenciaDC, String pConta, String pContaDC, String pCheque, 
        String pChequeDC, String pCompensacao) throws ACBrException {
        if(pDataCheque == null) pDataCheque = new Date();

        int ret = ACBrTEFInterop.INSTANCE.TEF_CHQ(getHandle(), pValor, toUTF8(pIndiceFPG_ECF), 
                toUTF8(pDocumentoVinculado), toUTF8(pCMC7), pTipoPessoa, toUTF8(pDocumentoPessoa), 
                OleDate.toOADate(pDataCheque), toUTF8(pBanco), toUTF8(pAgencia),
                toUTF8(pAgenciaDC), toUTF8(pConta), toUTF8(pContaDC), toUTF8(pCheque), 
                toUTF8(pChequeDC), toUTF8(pCompensacao));
        checkResult(ret);
        return ret == 1;
    }

    /**
     * Aciona o ATV.
     * 
     * @throws ACBrException 
     */
    public void atv() throws ACBrException {
        atv(TefTipo.Nenhum);
    }

    /**
     * Aciona o ATV.
     * 
     * @param pTipoTef tipo do TEF.
     * @throws ACBrException 
     */
    public void atv(TefTipo pTipoTef) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_ATV(getHandle(), pTipoTef.getCodigo());
        checkResult(ret);
    }  
    
    /**
     * Aciona a ADM.
     * 
     * @throws ACBrException 
     */
    public void adm() throws ACBrException {
        adm(TefTipo.Nenhum);
    }

    /**
     * Aciona a ADM.
     * 
     * @param pTipoTef tipo do TEF.
     * @throws ACBrException 
     */
    public void adm(TefTipo pTipoTef) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_ADM(getHandle(), pTipoTef.getCodigo());
        checkResult(ret);
    }     
    
    /**
     * Seta os dados CNC.
     * 
     * @param pRede dados da rede.
     * @param pNsu nsu da transacao.
     * @param pDataHoraTransacao data e hora da transacao.
     * @param pValor valor da transacao.
     * @return status da transacao.
     * @throws ACBrException 
     */
    public boolean cnc(String pRede, String pNsu, Date pDataHoraTransacao, double pValor) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_CNC(getHandle(), toUTF8(pRede), toUTF8(pNsu), 
                OleDate.toOADate(pDataHoraTransacao), pValor);
        checkResult(ret);
        return ret == 1;
    } 
    
    /**
     * Seta os dados CNF.
     * 
     * @param pRede dados da rede.
     * @param pNsu nsu da transacao.
     * @param pFinalizacao finalizacao.
     * @throws ACBrException 
     */
    public void cnf(String pRede, String pNsu, String pFinalizacao) throws ACBrException {
        cnf(pRede, pNsu, pFinalizacao, "");
    }
    
    /**
     * Seta os dados CNF.
     * 
     * @param pRede dados da rede.
     * @param pNsu nsu da transacao.
     * @param pFinalizacao finalizacao.
     * @param pDocumentoVinculado documento vinculado.
     * @throws ACBrException 
     */
    public void cnf(String pRede, String pNsu, String pFinalizacao, String pDocumentoVinculado) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_CNF(getHandle(), toUTF8(pRede), toUTF8(pNsu), 
                toUTF8(pFinalizacao), toUTF8(pDocumentoVinculado));
        checkResult(ret);
    }  

    /**
     * Seta os dados NCN.
     * 
     * @param pRede dados da rede.
     * @param pNsu nsu da transacao.
     * @param pFinalizacao finalizacao.
     * @throws ACBrException 
     */
    public void ncn(String pRede, String pNsu, String pFinalizacao) throws ACBrException {
        ncn(pRede, pNsu, pFinalizacao, 0d, "");
    }
    
    /**
     * Seta os dados NCN.
     * 
     * @param pRede dados da rede.
     * @param pNsu nsu da transacao.
     * @param pFinalizacao finalizacao.
     * @param pValor valor da transacao
     * @param pDocumentoVinculado documento vinculado.
     * @throws ACBrException 
     */
    public void ncn(String pRede, String pNsu, String pFinalizacao, double pValor, String pDocumentoVinculado) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_NCN(getHandle(), toUTF8(pRede), toUTF8(pNsu), 
                toUTF8(pFinalizacao), pValor, toUTF8(pDocumentoVinculado));
        checkResult(ret);
    }   
    
    /**
     * Cancela as transacoes pendentes.
     * 
     * @throws ACBrException 
     */
    public void cancelarTransacoesPendentes() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_CancelarTransacoesPendentes(getHandle());
        checkResult(ret);
    }

    /**
     * Confirma as transacoes pendentes.
     * 
     * @throws ACBrException 
     */
    public void confirmarTransacoesPendentes() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_ConfirmarTransacoesPendentes(getHandle());
        checkResult(ret);
    }

    /**
     * Imprime as transacoes pendentes.
     * 
     * @throws ACBrException 
     */
    public void imprimirTransacoesPendentes() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_ImprimirTransacoesPendentes(getHandle());
        checkResult(ret);
    }

    /**
     * Finaliza o cupom e bloqueia o TEF.
     * 
     * @throws ACBrException 
     */
    public void finalizarCupom() throws ACBrException {
        finalizarCupom(true);
    }
    
    /**
     * Finaliza o cupom.
     * 
     * @param pIndBloqueio indica se o TEF sera bloqueado.
     * @throws ACBrException 
     */
    public void finalizarCupom(boolean pIndBloqueio) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_FinalizarCupom(getHandle(), pIndBloqueio);
        checkResult(ret);
    }    
    // </editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onAguardaResp">
	public void addOnAguardaResp(ACBrEventListener<AguardaRespEventObject> pListener) {
		if (!hasListeners("onAguardaResp")) {
            ACBrTEFInterop.INSTANCE.TEF_SetOnAguardaResp(getHandle(), new ACBrTEFInterop.AguardaRespCallback() {
                @Override
                public void invoke(String pArquivo, int pSegundosTimeOut, IntByReference pInterromper) {
                    onAguardaResp(pArquivo, pSegundosTimeOut, pInterromper);
                }
            });
		}
		addListener("onAguardaResp", pListener);
	}
    
	public void removeOnAguardaResp(ACBrEventListener<AguardaRespEventObject> pListener) {
		removeListener("onAguardaResp", pListener);
		if (!hasListeners("onAguardaResp")) {
			ACBrTEFInterop.INSTANCE.TEF_SetOnAguardaResp(getHandle(), null);
		}
	}

	private void onAguardaResp(String pArquivo, int pSegundosTimeOut, IntByReference pInterromper) {
		AguardaRespEventObject e = new AguardaRespEventObject(this, pArquivo, pSegundosTimeOut);
        pInterromper = e.getInterromper();
		notifyListeners("onAguardaResp", e);
	}
	//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onExibeMensagem">
	public void addOnExibeMensagem(ACBrEventListener<ExibeMsgEventObject> pListener) {
		if (!hasListeners("onExibeMensagem")) {
            ACBrTEFInterop.INSTANCE.TEF_SetOnExibeMsg(getHandle(), new ACBrTEFInterop.ExibeMsgCallback() {
                @Override
                public void invoke(int pOperacao, String pMensagem, IntByReference pAModalResult) {
                    onExibeMensagem(pOperacao, pMensagem, pAModalResult);
                }
            });
		}
		addListener("onExibeMensagem", pListener);
	}
    
	public void removeOnExibeMensagem(ACBrEventListener<ExibeMsgEventObject> pListener) {
		removeListener("onExibeMensagem", pListener);
		if (!hasListeners("onExibeMensagem")) {
			ACBrTEFInterop.INSTANCE.TEF_SetOnExibeMsg(getHandle(), null);
		}
	}

	private void onExibeMensagem(int pOperacao, String pMensagem, IntByReference pAModalResult) {
		ExibeMsgEventObject e = new ExibeMsgEventObject(this, OperacaoMensagem.valueOf(pOperacao), toUTF8(pMensagem));
        pAModalResult = e.getaModalResult();
		notifyListeners("onExibeMensagem", e);
	}
	//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onBloqueiaMouseTeclado">
	public void addOnBloqueiaMouseTeclado(ACBrEventListener<BloqueiaMouseTecladoEventObject> pListener) {
		if (!hasListeners("onBloqueiaMouseTeclado")) {
            ACBrTEFInterop.INSTANCE.TEF_SetOnBloqueiaMouseTeclado(getHandle(), new ACBrTEFInterop.BloqueiaMouseTecladoCallback() {
                @Override
                public void invoke(boolean pBloqueia, IntByReference pTratado) {
                    onBloqueiaMouseTeclado(pBloqueia, pTratado);
                }
			});
		}
		addListener("onBloqueiaMouseTeclado", pListener);
	}
    
	public void removeOnBloqueiaMouseTeclado(ACBrEventListener<BloqueiaMouseTecladoEventObject> pListener) {
		removeListener("onBloqueiaMouseTeclado", pListener);
		if (!hasListeners("onBloqueiaMouseTeclado")) {
			ACBrTEFInterop.INSTANCE.TEF_SetOnBloqueiaMouseTeclado(getHandle(), null);
		}
	}

	private void onBloqueiaMouseTeclado(boolean pBloqueia, IntByReference pTratado) {
		BloqueiaMouseTecladoEventObject e = new BloqueiaMouseTecladoEventObject(this, pBloqueia ? 1 : 0);
        pTratado = e.getTratado();
		notifyListeners("onBloqueiaMouseTeclado", e);
	}
	//</editor-fold> 
	//<editor-fold defaultstate="collapsed" desc="onRestauraFocoAplicacao">
	public void addOnRestauraFocoAplicacao(ACBrEventListener<ExecutaAcaoEventObject> pListener) {
		if (!hasListeners("onRestauraFocoAplicacao")) {
            ACBrTEFInterop.INSTANCE.TEF_SetOnRestauraFocoAplicacao(getHandle(), new ACBrTEFInterop.ExecutaAcaoCallback() {
                @Override
                public void invoke(IntByReference pTratado) {
                    onRestauraFocoAplicacao(pTratado);
                }
            });
		}
		addListener("onRestauraFocoAplicacao", pListener);
	}
    
	public void removeOnRestauraFocoAplicacao(ACBrEventListener<ExecutaAcaoEventObject> pListener) {
		removeListener("onRestauraFocoAplicacao", pListener);
		if (!hasListeners("onRestauraFocoAplicacao")) {
			ACBrTEFInterop.INSTANCE.TEF_SetOnRestauraFocoAplicacao(getHandle(), null);
		}
	}

	private void onRestauraFocoAplicacao(IntByReference pTratado) {
		ExecutaAcaoEventObject e = new ExecutaAcaoEventObject(this, pTratado.getValue());
		notifyListeners("onRestauraFocoAplicacao", e);
	}
	//</editor-fold>  
	//<editor-fold defaultstate="collapsed" desc="onLimpaTeclado">
	public void addOnLimpaTeclado(ACBrEventListener<ExecutaAcaoEventObject> pListener) {
		if (!hasListeners("onLimpaTeclado")) {
            ACBrTEFInterop.INSTANCE.TEF_SetOnLimpaTeclado(getHandle(), new ACBrTEFInterop.ExecutaAcaoCallback() {
                @Override
                public void invoke(IntByReference pTratado) {
                    onLimpaTeclado(pTratado);
                }
            });
		}
		addListener("onLimpaTeclado", pListener);
	}
    
	public void removeOnLimpaTeclado(ACBrEventListener<ExecutaAcaoEventObject> pListener) {
		removeListener("onLimpaTeclado", pListener);
		if (!hasListeners("onLimpaTeclado")) {
			ACBrTEFInterop.INSTANCE.TEF_SetOnLimpaTeclado(getHandle(), null);
		}
	}

	private void onLimpaTeclado(IntByReference pTratado) {
		ExecutaAcaoEventObject e = new ExecutaAcaoEventObject(this, pTratado.getValue());
		notifyListeners("onLimpaTeclado", e);
	}
	//</editor-fold>  
	//<editor-fold defaultstate="collapsed" desc="onComandaECF">
	public void addOnComandaECF(ACBrEventListener<ComandaECFEventObject> pListener) {
		if (!hasListeners("onComandaECF")) {
            ACBrTEFInterop.INSTANCE.TEF_SetOnComandaECF(getHandle(), new ACBrTEFInterop.ComandaECFCallback() {
                @Override
                public void invoke(int pOperacao, int pResp, IntByReference pRetornoECF) {
                    onComandaECF(pOperacao, pResp, pRetornoECF);
                }
			});
		}
		addListener("onComandaECF", pListener);
	}
    
	public void removeOnComandaECF(ACBrEventListener<ComandaECFEventObject> pListener) {
		removeListener("onComandaECF", pListener);
		if (!hasListeners("onComandaECF")) {
			ACBrTEFInterop.INSTANCE.TEF_SetOnComandaECF(getHandle(), null);
		}
	}

	private void onComandaECF(int pOperacao, int pResp, IntByReference pRetornoECF) {
        try {
            Resp lResp = pResp == 0 ? null : new Resp(this, pResp);
            ComandaECFEventObject e = new ComandaECFEventObject(this, OperacaoECF.valueOf(pOperacao), lResp);
            pRetornoECF.setValue(e.getRetornoEcf().getValue());
            notifyListeners("onComandaECF", e);
        } catch (ACBrException e) {
            e.printStackTrace();
        }
	}
	//</editor-fold>  
	//<editor-fold defaultstate="collapsed" desc="onComandaECFSubtotaliza">
	public void addOnComandaECFSubtotaliza(ACBrEventListener<ComandaECFSubtotalizaEventObject> pListener) {
		if (!hasListeners("onComandaECFSubtotaliza")) {
            ACBrTEFInterop.INSTANCE.TEF_SetOnComandaECFSubtotaliza(getHandle(), new ACBrTEFInterop.ComandaECFSubtotalizaCallback() {
                @Override
                public void invoke(double pDescAcre, IntByReference pRetornoECF) {
                    onComandaECFSubtotaliza(pDescAcre, pRetornoECF);
                }
            });
		}
		addListener("onComandaECFSubtotaliza", pListener);
	}
    
	public void removeOnComandaECFSubtotaliza(ACBrEventListener<ComandaECFSubtotalizaEventObject> pListener) {
		removeListener("onComandaECFSubtotaliza", pListener);
		if (!hasListeners("onComandaECFSubtotaliza")) {
			ACBrTEFInterop.INSTANCE.TEF_SetOnComandaECFSubtotaliza(getHandle(), null);
		}
	}

	private void onComandaECFSubtotaliza(double pDescAcre, IntByReference pRetornoECF) {
		ComandaECFSubtotalizaEventObject e = new ComandaECFSubtotalizaEventObject(this, pDescAcre);
        pRetornoECF.setValue(e.getRetornoEcf().getValue());
		notifyListeners("onComandaECFSubtotaliza", e);
	}
	//</editor-fold>  
	//<editor-fold defaultstate="collapsed" desc="onComandaECFPagamento">
	public void addOnComandaECFPagamento(ACBrEventListener<ComandaECFPagamentoEventObject> pListener) {
		if (!hasListeners("onComandaECFPagamento")) {
            ACBrTEFInterop.INSTANCE.TEF_SetOnComandaECFPagamento(getHandle(), new ACBrTEFInterop.ComandaECFPagamentoCallback() {
                @Override
                public void invoke(String pIndiceECF, double pValor, IntByReference pRetornoECF) {
                    onComandaECFPagamento(pIndiceECF, pValor, pRetornoECF);
                }
            });
		}
		addListener("onComandaECFPagamento", pListener);
	}
    
	public void removeOnComandaECFPagamento(ACBrEventListener<ComandaECFPagamentoEventObject> pListener) {
		removeListener("onComandaECFPagamento", pListener);
		if (!hasListeners("onComandaECFPagamento")) {
			ACBrTEFInterop.INSTANCE.TEF_SetOnComandaECFPagamento(getHandle(), null);
		}
	}

	private void onComandaECFPagamento(String pIndiceECF, double pValor, IntByReference pRetornoECF) {
		ComandaECFPagamentoEventObject e = new ComandaECFPagamentoEventObject(this, toUTF8(pIndiceECF), pValor);
        pRetornoECF.setValue(e.getRetornoEcf().getValue());
		notifyListeners("onComandaECFPagamento", e);
	}
	//</editor-fold>  
	//<editor-fold defaultstate="collapsed" desc="onComandaECFAbreVinculado">
	public void addOnComandaECFAbreVinculado(ACBrEventListener<ComandaECFAbreVinculadoEventObject> pListener) {
		if (!hasListeners("onComandaECFAbreVinculado")) {
            ACBrTEFInterop.INSTANCE.TEF_SetOnComandaECFAbreVinculado(getHandle(), new ACBrTEFInterop.ComandaECFAbreVinculadoCallback() {
                @Override
                public void invoke(String pCOO, String pIndiceECF, double pValor, IntByReference pRetornoECF) {
                    onComandaECFAbreVinculado(pCOO, pIndiceECF, pValor, pRetornoECF);
                }
            });
		}
		addListener("onComandaECFAbreVinculado", pListener);
	}
    
	public void removeOnComandaECFAbreVinculado(ACBrEventListener<ComandaECFAbreVinculadoEventObject> pListener) {
		removeListener("onComandaECFAbreVinculado", pListener);
		if (!hasListeners("onComandaECFAbreVinculado")) {
			ACBrTEFInterop.INSTANCE.TEF_SetOnComandaECFAbreVinculado(getHandle(), null);
		}
	}

	private void onComandaECFAbreVinculado(String pCOO, String pIndiceECF, double pValor, IntByReference pRetornoECF) {
		ComandaECFAbreVinculadoEventObject e = new ComandaECFAbreVinculadoEventObject(this, toUTF8(pCOO), toUTF8(pIndiceECF), pValor);
        pRetornoECF.setValue(e.getRetornoEcf().getValue());
		notifyListeners("onComandaECFAbreVinculado", e);
	}
	//</editor-fold>  
	//<editor-fold defaultstate="collapsed" desc="onComandaECFImprimeVia">
	public void addOnComandaECFImprimeVia(ACBrEventListener<ComandaECFImprimeViaEventObject> pListener) {
		if (!hasListeners("onComandaECFImprimeVia")) {
            ACBrTEFInterop.INSTANCE.TEF_SetOnComandaECFImprimeVia(getHandle(), new ACBrTEFInterop.ComandaECFImprimeViaCallback() {
                @Override
                public void invoke(int pTipoRelatorio, int pVia, int pImagemComprovante, int pImagemComprovanteCount, IntByReference pRetornoECF) {
                    onComandaECFImprimeVia(pTipoRelatorio, pVia, pImagemComprovante, pImagemComprovanteCount, pRetornoECF);
                }
            });
		}
		addListener("onComandaECFImprimeVia", pListener);
	}
    
	public void removeOnComandaECFImprimeVia(ACBrEventListener<ComandaECFImprimeViaEventObject> pListener) {
		removeListener("onComandaECFImprimeVia", pListener);
		if (!hasListeners("onComandaECFImprimeVia")) {
			ACBrTEFInterop.INSTANCE.TEF_SetOnComandaECFImprimeVia(getHandle(), null);
		}
	}

	private void onComandaECFImprimeVia(int pTipoRelatorio, int pVia, int pImagemComprovante, int pImagemComprovanteCount, IntByReference pRetornoECF) {
        //TODO Ver processo de obtencao para imagem.
		ComandaECFImprimeViaEventObject e = new ComandaECFImprimeViaEventObject(this, TipoRelatorio.valueOf(pTipoRelatorio), pVia, null, pImagemComprovanteCount);
        pRetornoECF.setValue(e.getRetornoEcf().getValue());
        notifyListeners("onComandaECFImprimeVia", e);
	}
	//</editor-fold>      
	//<editor-fold defaultstate="collapsed" desc="onInfoECF">
	public void addOnInfoECF(ACBrEventListener<InfoECFEventObject> pListener) {
		if (!hasListeners("onInfoECF")) {
            ACBrTEFInterop.INSTANCE.TEF_SetOnInfoECF(getHandle(), new ACBrTEFInterop.InfoECFCallback() {
                @Override
                public void invoke(int pOperacao, ByteBuffer pRetornoECF, int pRetornoECFLen) {
                    onInfoECF(pOperacao, pRetornoECF, pRetornoECFLen);
                }
            });
		}
		addListener("onInfoECF", pListener);
	}
    
	public void removeOnInfoECF(ACBrEventListener<InfoECFEventObject> pListener) {
		removeListener("onInfoECF", pListener);
		if (!hasListeners("onInfoECF")) {
			ACBrTEFInterop.INSTANCE.TEF_SetOnInfoECF(getHandle(), null);
		}
	}

	private void onInfoECF(int pOperacao, ByteBuffer pRetornoECF, int pRetornoECFLen) {
        //TODO Ajustar processo 
		InfoECFEventObject e = new InfoECFEventObject(this, InfoECF.valueOf(pOperacao));        
        pRetornoECFLen = 0;
        pRetornoECF = e.getRetornoEcf();
		notifyListeners("onInfoECF", e);
	}
	//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onAntesFinalizarRequisicao">
	public void addOnAntesFinalizarRequisicao(ACBrEventListener<AntesFinalizarRequisicaoEventObject> pListener) {
		if (!hasListeners("onAntesFinalizarRequisicao")) {
            ACBrTEFInterop.INSTANCE.TEF_SetOnAntesFinalizarRequisicao(getHandle(), new ACBrTEFInterop.AntesFinalizarRequisicaoCallback() {
                @Override
                public void invoke(int pReq) {
                    onAntesFinalizarRequisicao(pReq);
                }
            });
		}
		addListener("onAntesFinalizarRequisicao", pListener);
	}
    
	public void removeOnAntesFinalizarRequisicao(ACBrEventListener<AntesFinalizarRequisicaoEventObject> pListener) {
		removeListener("onAntesFinalizarRequisicao", pListener);
		if (!hasListeners("onAntesFinalizarRequisicao")) {
			ACBrTEFInterop.INSTANCE.TEF_SetOnAntesFinalizarRequisicao(getHandle(), null);
		}
	}

	private void onAntesFinalizarRequisicao(int pReq) {
        try {
            Req lReq = pReq == 0 ? null : new Req(this, pReq);
            AntesFinalizarRequisicaoEventObject e = new AntesFinalizarRequisicaoEventObject(this, lReq);
            notifyListeners("onAntesFinalizarRequisicao", e);
        } catch (ACBrException e) {
            e.printStackTrace();
        }		
	}
	//</editor-fold>      
	//<editor-fold defaultstate="collapsed" desc="onDepoisConfirmarTransacoes">
	public void addOnDepoisConfirmarTransacoes(ACBrEventListener<DepoisConfirmarTransacoesEventObject> pListener) {
		if (!hasListeners("onDepoisConfirmarTransacoes")) {
            ACBrTEFInterop.INSTANCE.TEF_SetOnDepoisConfirmarTransacoes(getHandle(), new ACBrTEFInterop.DepoisConfirmarTransacoesCallback() {
                @Override
                public void invoke(int pRespostasPendentes) {
                    onDepoisConfirmarTransacoes(pRespostasPendentes);
                }
            });
		}
		addListener("onDepoisConfirmarTransacoes", pListener);
	}
    
	public void removeOnDepoisConfirmarTransacoes(ACBrEventListener<DepoisConfirmarTransacoesEventObject> pListener) {
		removeListener("onDepoisConfirmarTransacoes", pListener);
		if (!hasListeners("onDepoisConfirmarTransacoes")) {
			ACBrTEFInterop.INSTANCE.TEF_SetOnDepoisConfirmarTransacoes(getHandle(), null);
		}
	}

	private void onDepoisConfirmarTransacoes(int pRespostasPendentes) {		
        try {
            RespostasPendentes lRespostasPendentes = pRespostasPendentes == 0 ? null : new RespostasPendentes(this, pRespostasPendentes);
            DepoisConfirmarTransacoesEventObject e = new DepoisConfirmarTransacoesEventObject(this, lRespostasPendentes);
            notifyListeners("onDepoisConfirmarTransacoes", e);
        } catch (ACBrException e) {
            e.printStackTrace();
        }	        
	}
	//</editor-fold>      
	//<editor-fold defaultstate="collapsed" desc="onAntesCancelarTransacao">
	public void addOnAntesCancelarTransacao(ACBrEventListener<AntesCancelarTransacaoEventObject> pListener) {
		if (!hasListeners("onAntesCancelarTransacao")) {
            ACBrTEFInterop.INSTANCE.TEF_SetOnAntesCancelarTransacao(getHandle(), new ACBrTEFInterop.AntesCancelarTransacaoCallback() {
                @Override
                public void invoke(int pRespostaPendente) {
                    onAntesCancelarTransacao(pRespostaPendente);
                }
            });
		}
		addListener("onAntesCancelarTransacao", pListener);
	}
    
	public void removeOnAntesCancelarTransacao(ACBrEventListener<AntesCancelarTransacaoEventObject> pListener) {
		removeListener("onAntesCancelarTransacao", pListener);
		if (!hasListeners("onAntesCancelarTransacao")) {
			ACBrTEFInterop.INSTANCE.TEF_SetOnAntesCancelarTransacao(getHandle(), null);
		}
	}

	private void onAntesCancelarTransacao(int pRespostaPendente) {
        try {
            RespostasPendentes lRespostasPendentes = pRespostaPendente == 0 ? null : new RespostasPendentes(this, pRespostaPendente);
            AntesCancelarTransacaoEventObject e = new AntesCancelarTransacaoEventObject(this, lRespostasPendentes);
            notifyListeners("onAntesCancelarTransacao", e);
        } catch (ACBrException e) {
            e.printStackTrace();
        }        
	}
	//</editor-fold>  
	//<editor-fold defaultstate="collapsed" desc="onDepoisCancelarTransacoes">
	public void addOnDepoisCancelarTransacoes(ACBrEventListener<DepoisCancelarTransacoesEventObject> pListener) {
		if (!hasListeners("onDepoisCancelarTransacoes")) {
            ACBrTEFInterop.INSTANCE.TEF_SetOnDepoisCancelarTransacoes(getHandle(), new ACBrTEFInterop.DepoisCancelarTransacoesCallback() {
                @Override
                public void invoke(int pRespostasPendentes) {
                    onDepoisCancelarTransacoes(pRespostasPendentes);
                }
            });
		}
		addListener("onDepoisCancelarTransacoes", pListener);
	}
    
	public void removeOnDepoisCancelarTransacoes(ACBrEventListener<DepoisCancelarTransacoesEventObject> pListener) {
		removeListener("onDepoisCancelarTransacoes", pListener);
		if (!hasListeners("onDepoisCancelarTransacoes")) {
			ACBrTEFInterop.INSTANCE.TEF_SetOnDepoisCancelarTransacoes(getHandle(), null);
		}
	}

	private void onDepoisCancelarTransacoes(int pRespostasPendentes) {
        try {
            RespostasPendentes lRespostasPendentes = pRespostasPendentes == 0 ? null : new RespostasPendentes(this, pRespostasPendentes);
            DepoisCancelarTransacoesEventObject e = new DepoisCancelarTransacoesEventObject(this, lRespostasPendentes);
            notifyListeners("onDepoisCancelarTransacoes", e);
        } catch (ACBrException e) {
            e.printStackTrace();
        }          
	}
	//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onMudaEstadoReq">
	public void addOnMudaEstadoReq(ACBrEventListener<MudaEstadoReqEventObject> pListener) {
		if (!hasListeners("onMudaEstadoReq")) {
            ACBrTEFInterop.INSTANCE.TEF_SetOnMudaEstadoReq(getHandle(), new ACBrTEFInterop.MudaEstadoReqCallback() {
                @Override
                public void invoke(int pEstadoReq) {
                    onMudaEstadoReq(pEstadoReq);
                }
            });
		}
		addListener("onMudaEstadoReq", pListener);
	}
    
	public void removeOnMudaEstadoReq(ACBrEventListener<MudaEstadoReqEventObject> pListener) {
		removeListener("onMudaEstadoReq", pListener);
		if (!hasListeners("onMudaEstadoReq")) {
			ACBrTEFInterop.INSTANCE.TEF_SetOnMudaEstadoReq(getHandle(), null);
		}
	}

	private void onMudaEstadoReq(int pEstadoReq) {
		MudaEstadoReqEventObject e = new MudaEstadoReqEventObject(this, ReqEstado.valueOf(pEstadoReq));
		notifyListeners("onMudaEstadoReq", e);
	}
	//</editor-fold>      
	//<editor-fold defaultstate="collapsed" desc="onMudaEstadoResp">
	public void addOnMudaEstadoResp(ACBrEventListener<MudaEstadoRespEventObject> pListener) {
		if (!hasListeners("onMudaEstadoResp")) {
            ACBrTEFInterop.INSTANCE.TEF_SetOnMudaEstadoResp(getHandle(), new ACBrTEFInterop.MudaEstadoRespCallback() {
                @Override
                public void invoke(int pEstadoResp) {
                    onMudaEstadoResp(pEstadoResp);
                }
            });
		}
		addListener("onMudaEstadoResp", pListener);
	}
    
	public void removeOnMudaEstadoResp(ACBrEventListener<MudaEstadoRespEventObject> pListener) {
		removeListener("onMudaEstadoResp", pListener);
		if (!hasListeners("onMudaEstadoResp")) {
			ACBrTEFInterop.INSTANCE.TEF_SetOnMudaEstadoResp(getHandle(), null);
		}
	}

	private void onMudaEstadoResp(int pEstadoResp) {
		MudaEstadoRespEventObject e = new MudaEstadoRespEventObject(this, RespEstado.valueOf(pEstadoResp));
		notifyListeners("onMudaEstadoResp", e);
	}
	//</editor-fold> 
    //<editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * @see Identificacao
     * @return the identificacao
     */
    public Identificacao getIdentificacao() {
        return identificacao;
    }
    
    /**
     * @see TefCliSiTef
     * @return the tefCliSiTef
     */
    public TefCliSiTef getTefCliSiTef() {
        return tefCliSiTef;
    }

    /**
     * @see TEFVeSPague
     * @return the tefVeSPague
     */
    public TEFVeSPague getTefVeSPague() {
        return tefVeSPague;
    }

    /**
     * @see TefDial
     * @return the tefDial
     */
    public TefDial getTefDial() {
        return tefDial;
    }

    /**
     * @see TefDisc
     * @return the tefDisc
     */
    public TefDisc getTefDisc() {
        return tefDisc;
    }

    /**
     * @see TefHiper
     * @return the tefHiper
     */
    public TefHiper getTefHiper() {
        return tefHiper;
    }

    /**
     * @see TefGPU
     * @return the tefGPU
     */
    public TefGPU getTefGPU() {
        return tefGPU;
    }

    /**
     * @see TefAuttar
     * @return the tefAuttar
     */
    public TefAuttar getTefAuttar() {
        return tefAuttar;
    }

    /**
     * @see TefGood
     * @return the tefGood
     */
    public TefGood getTefGood() {
        return tefGood;
    }

    /**
     * @see TefFoxWin
     * @return the tefFoxWin
     */
    public TefFoxWin getTefFoxWin() {
        return tefFoxWin;
    }

    /**
     * @see TefPetrocard
     * @return the tefPetrocard
     */
    public TefPetrocard getTefPetrocard() {
        return tefPetrocard;
    }

    /**
     * @see TefCrediShop
     * @return the tefCrediShop
     */
    public TefCrediShop getTefCrediShop() {
        return tefCrediShop;
    }
    // </editor-fold>  
    
}