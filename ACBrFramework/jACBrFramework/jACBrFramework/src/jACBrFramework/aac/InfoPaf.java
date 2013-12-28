package jACBrFramework.aac;

import jACBrFramework.ACBrException;
import jACBrFramework.interop.ACBrAACInterop;
import jACBrFramework.paf.TipoDesenvolvimento;
import jACBrFramework.paf.TipoFuncionamento;
import jACBrFramework.paf.TipoIntegracao;
import java.nio.ByteBuffer;

/**
 * Informacoes PAF.
 * 
 * @author Jose Mauro
 * @version Criado em: 16/12/2013 11:02:38, revisao: $Id$
 */
public class InfoPaf extends ACBrAACWrapper {

    //<editor-fold defaultstate="collapsed" desc="Constructor">
    /**
     * Cria um novo objeto empresa.
     * 
     * @param pAac instancia para auxiliar a criptografia.
     */
    InfoPaf(ACBrAAC pAac) {
        super(pAac);
    }    
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Dados do Aplicativo">    
    /**
     * Nome do Aplicativo.
     * 
     * @param pNomeAplicativo
     * @throws ACBrException 
     */
    public void setNomeAplicativo(String pNomeAplicativo) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_SetNome(getHandle(), toUTF8(pNomeAplicativo));
        checkResult(ret);
    }
    
    /**
     * Recupera o nome do aplicativo.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getNomeAplicativo() throws ACBrException {
        ByteBuffer lNomeAplicativo = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_GetNome(getHandle(), lNomeAplicativo, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lNomeAplicativo, ret);
    }     
    
    /**
     * Linguagem do Aplicativo.
     * 
     * @param pLinguagemAplicativo
     * @throws ACBrException 
     */
    public void setLinguagemAplicativo(String pLinguagemAplicativo) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_SetLinguagem(getHandle(), toUTF8(pLinguagemAplicativo));
        checkResult(ret);
    }
    
    /**
     * Recupera a linguagem do aplicativo.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getLinguagemAplicativo() throws ACBrException {
        ByteBuffer lLinguagemAplicativo = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_GetLinguagem(getHandle(), lLinguagemAplicativo, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lLinguagemAplicativo, ret);
    }     
    
    /**
     * Banco de dados do Aplicativo.
     * 
     * @param pBancoDeDadosAplicativo
     * @throws ACBrException 
     */
    public void setBancoDeDadosAplicativo(String pBancoDeDadosAplicativo) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_SetBancoDados(getHandle(), toUTF8(pBancoDeDadosAplicativo));
        checkResult(ret);
    }
    
    /**
     * Recupera o Banco de dados do Aplicativo.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getBancoDeDadosAplicativo() throws ACBrException {
        ByteBuffer lBancoDeDadosAplicativo = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_GetBancoDados(getHandle(), lBancoDeDadosAplicativo, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lBancoDeDadosAplicativo, ret);
    }      
    
    /**
     * Sistema operacional do aplicativo.
     * 
     * @param pSistemaOperacionalAplicativo
     * @throws ACBrException 
     */
    public void setSistemaOperacionalAplicativo(String pSistemaOperacionalAplicativo) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_SetSistemaOperacional(getHandle(), toUTF8(pSistemaOperacionalAplicativo));
        checkResult(ret);
    }
    
    /**
     * Recupera o Sistema operacional do aplicativo.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getSistemaOperacionalAplicativo() throws ACBrException {
        ByteBuffer lSistemaOperacionalAplicativo = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_GetSistemaOperacional(getHandle(), lSistemaOperacionalAplicativo, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lSistemaOperacionalAplicativo, ret);
    }      
    
    /**
     * Versao do aplicativo.
     * 
     * @param pVersaoAplicativo
     * @throws ACBrException 
     */
    public void setVersaoAplicativo(String pVersaoAplicativo) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_SetVersao(getHandle(), toUTF8(pVersaoAplicativo));
        checkResult(ret);
    }
    
    /**
     * Recupera a Versao do aplicativo.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getVersaoAplicativo() throws ACBrException {
        ByteBuffer lVersaoAplicativo = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_GetVersao(getHandle(), lVersaoAplicativo, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lVersaoAplicativo, ret);
    }      
    
    /**
     * Principal executaval do aplicativo.
     * 
     * @param pPrincipalExeAplicativo
     * @throws ACBrException 
     */
    public void setPrincipalExeAplicativo(String pPrincipalExeAplicativo) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_PrincipalExe_SetNome(getHandle(), toUTF8(pPrincipalExeAplicativo));
        checkResult(ret);
    }
    
    /**
     * Recupera o Principal executaval do aplicativo.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getPrincipalExeAplicativo() throws ACBrException {
        ByteBuffer lPrincipalExeAplicativo = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_PrincipalExe_GetNome(getHandle(), lPrincipalExeAplicativo, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lPrincipalExeAplicativo, ret);
    }     
    
    /**
     * MD5 do aplicativo.
     * 
     * @param pMD5Aplicativo
     * @throws ACBrException 
     */
    public void setMD5Aplicativo(String pMD5Aplicativo) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_PrincipalExe_SetMD5(getHandle(), toUTF8(pMD5Aplicativo));
        checkResult(ret);
    }
    
    /**
     * Recupera o MD5 do aplicativo.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getMD5Aplicativo() throws ACBrException {
        ByteBuffer lMD5Aplicativo = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_PrincipalExe_GetMD5(getHandle(), lMD5Aplicativo, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lMD5Aplicativo, ret);
    }     
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Dados de Funcionalidades">    
    /**
     * Tipo do Funcionamento.
     * 
     * @param pTipoFuncionamento
     * @throws ACBrException 
     */
    public void setTipoFuncionamento(TipoFuncionamento pTipoFuncionamento) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_SetTipoFuncionamento(getHandle(), pTipoFuncionamento.getCodigo());
        checkResult(ret);
    }
    
    /**
     * Recupera o tipo de funcionamento.
     * 
     * @return
     * @throws ACBrException 
     */
    public TipoFuncionamento getTipoFuncionamento() throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_GetTipoFuncionamento(getHandle());
        return TipoFuncionamento.values()[ret];
    }     
    
    /**
     * Tipo da Integracao.
     * 
     * @param pTipoIntegracao
     * @throws ACBrException 
     */
    public void setTipoFuncionamento(TipoIntegracao pTipoIntegracao) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_SetIntegracaoPafECF(getHandle(), pTipoIntegracao.getCodigo());
        checkResult(ret);
    }
    
    /**
     * Recupera o tipo de integracao.
     * 
     * @return
     * @throws ACBrException 
     */
    public TipoIntegracao getTipoIntegracao() throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_GetIntegracaoPafECF(getHandle());
        return TipoIntegracao.values()[ret];
    }  
    
    /**
     * Tipo de desenvolvimento.
     * 
     * @param pTipoDesenvolvimento
     * @throws ACBrException 
     */
    public void setTipoDesenvolvimento(TipoDesenvolvimento pTipoDesenvolvimento) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_SetTipoDesenvolvimento(getHandle(), pTipoDesenvolvimento.getCodigo());
        checkResult(ret);
    }
    
    /**
     * Recupera o tipo de desenvolvimento.
     * 
     * @return
     * @throws ACBrException 
     */
    public TipoDesenvolvimento getTipoDesenvolvimento() throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_GetTipoDesenvolvimento(getHandle());
        return TipoDesenvolvimento.values()[ret];
    }      
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Dados de Nao Concomitancia">
    /**
     * Indica que realiza prevenda.
     * 
     * @param pRealizaPreVenda indica que realiza prevenda.
     * @throws ACBrException 
     */
    public void setRealizaPreVenda(boolean pRealizaPreVenda) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_SetRealizaPreVenda(getHandle(), pRealizaPreVenda);
        checkResult(ret);
    }

    /**
     * Verifica se realiza prevenda.
     * 
     * @return indica se ha prevenda.
     * @throws ACBrException 
     */
    public boolean isRealizaPreVenda() throws ACBrException {
        return ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_GetRealizaPreVenda(getHandle()) != 0;
    }      

    /**
     * Indica que realiza DAV Ecf.
     * 
     * @param pRealizaDAVECF indica que realiza dav ecf.
     * @throws ACBrException 
     */
    public void setRealizaDAVECF(boolean pRealizaDAVECF) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_SetRealizaDAVECF(getHandle(), pRealizaDAVECF);
        checkResult(ret);
    }

    /**
     * Verifica se realiza DAV Ecf.
     * 
     * @return indica que realiza dav ecf.
     * @throws ACBrException 
     */
    public boolean isRealizaDAVECF() throws ACBrException {
        return ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_GetRealizaDAVECF(getHandle()) != 0;
    }  
    
    /**
     * Indica que realiza DAV Nao Fiscal.
     * 
     * @param pRealizaDAVNaoFiscal indica que realiza dav Nao Fiscal.
     * @throws ACBrException 
     */
    public void setRealizaDAVNaoFiscal(boolean pRealizaDAVNaoFiscal) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_SetRealizaDAVNaoFiscal(getHandle(), pRealizaDAVNaoFiscal);
        checkResult(ret);
    }

    /**
     * Verifica se realiza DAV Nao Fiscal.
     * 
     * @return indica que realiza dav Nao Fiscal.
     * @throws ACBrException 
     */
    public boolean isRealizaDAVNaoFiscal() throws ACBrException {
        return ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_GetRealizaDAVNaoFiscal(getHandle()) != 0;
    }        
    
    /**
     * Indica que realiza DAV OS.
     * 
     * @param pRealizaDAVOS indica que realiza dav os.
     * @throws ACBrException 
     */
    public void setRealizaDAVOS(boolean pRealizaDAVOS) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_SetRealizaDAVOS(getHandle(), pRealizaDAVOS);
        checkResult(ret);
    }

    /**
     * Verifica se realiza DAV os.
     * 
     * @return indica que realiza dav os.
     * @throws ACBrException 
     */
    public boolean isRealizaDAVOS() throws ACBrException {
        return ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_GetRealizaDAVOS(getHandle()) != 0;
    }     
    
    /**
     * Indica que realiza lancamento de mesa.
     * 
     * @param pRealizaLancamentoMesa indica que realiza lancamento de mesa.
     * @throws ACBrException 
     */
    public void setRealizaLancamentoMesa(boolean pRealizaLancamentoMesa) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_SetRealizaLancamentoMesa(getHandle(), pRealizaLancamentoMesa);
        checkResult(ret);
    }

    /**
     * Verifica se realiza lancamento de mesa.
     * 
     * @return indica que realiza lancamento de mesa.
     * @throws ACBrException 
     */
    public boolean isRealizaLancamentoMesa() throws ACBrException {
        return ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_GetRealizaLancamentoMesa(getHandle()) != 0;
    }     
    
    /**
     * Indica que realiza DAV conforme anexo II.
     * 
     * @param pRealizaDAVConfAnexoII indica que realiza DAV conforme anexo II.
     * @throws ACBrException 
     */
    public void setRealizaDAVConfAnexoII(boolean pRealizaDAVConfAnexoII) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_SetDAVConfAnexoII(getHandle(), pRealizaDAVConfAnexoII);
        checkResult(ret);
    }

    /**
     * Verifica se realiza DAV conforme anexo II.
     * 
     * @return indica que realiza DAV conforme anexo II.
     * @throws ACBrException 
     */
    public boolean isRealizaDAVConfAnexoII() throws ACBrException {
        return ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_GetDAVConfAnexoII(getHandle()) != 0;
    }      
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Dados de Aplicacoes Especiais">
    /**
     * Indica indice tecnico de producao.
     * 
     * @param pIndiceTecnicoProducao indica indice tecnico de producao.
     * @throws ACBrException 
     */
    public void setIndiceTecnicoProducao(boolean pIndiceTecnicoProducao) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_SetIndiceTecnicoProd(getHandle(), pIndiceTecnicoProducao);
        checkResult(ret);
    }

    /**
     * Verifica o indice tecnico de producao.
     * 
     * @return indica o indice tecnico de producao.
     * @throws ACBrException 
     */
    public boolean isIndiceTecnicoProducao() throws ACBrException {
        return ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_GetIndiceTecnicoProd(getHandle()) != 0;
    }  
    
    /**
     * Indica uso da Ecf similar a restaurantes.
     * 
     * @param pBarSimilarECFRestaurante indica uso da Ecf similar a restaurantes.
     * @throws ACBrException 
     */
    public void setBarSimilarECFRestaurante(boolean pBarSimilarECFRestaurante) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_SetBarSimilarECFRestaurante(getHandle(), pBarSimilarECFRestaurante);
        checkResult(ret);
    }

    /**
     * Verifica o uso da Ecf similar a restaurantes.
     * 
     * @return indica o uso da Ecf similar a restaurantes.
     * @throws ACBrException 
     */
    public boolean isBarSimilarECFRestaurante() throws ACBrException {
        return ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_GetBarSimilarECFRestaurante(getHandle()) != 0;
    }  
    
    /**
     * Indica uso da Ecf similar comum.
     * 
     * @param pBarSimiliarECFComum indica uso da Ecf similar comum.
     * @throws ACBrException 
     */
    public void setBarSimiliarECFComum(boolean pBarSimiliarECFComum) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_SetBarSimilarECFComum(getHandle(), pBarSimiliarECFComum);
        checkResult(ret);
    }

    /**
     * Verifica uso da Ecf similar comum.
     * 
     * @return indica uso da Ecf similar comum.
     * @throws ACBrException 
     */
    public boolean isBarSimiliarECFComum() throws ACBrException {
        return ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_GetBarSimilarECFComum(getHandle()) != 0;
    }      

    /**
     * Indica uso da Ecf similar a balanca.
     * 
     * @param pBarSimiliarBalanca indica uso da Ecf similar a balanca.
     * @throws ACBrException 
     */
    public void setBarSimiliarBalanca(boolean pBarSimiliarBalanca) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_SetBarSimilarBalanca(getHandle(), pBarSimiliarBalanca);
        checkResult(ret);
    }

    /**
     * Verifica uso da Ecf similar a balanca.
     * 
     * @return indica uso da Ecf similar a balanca.
     * @throws ACBrException 
     */
    public boolean isBarSimiliarBalanca() throws ACBrException {
        return ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_GetBarSimilarBalanca(getHandle()) != 0;
    }      
    
    /**
     * Indica uso de impressora nao fiscal.
     * 
     * @param pUsaImpressoraNaoFiscal indica uso de impressora nao fiscal.
     * @throws ACBrException 
     */
    public void setUsaImpressoraNaoFiscal(boolean pUsaImpressoraNaoFiscal) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_SetUsaImpressoraNaoFiscal(getHandle(), pUsaImpressoraNaoFiscal);
        checkResult(ret);
    }

    /**
     * Verifica uso de impressora nao fiscal.
     * 
     * @return indica uso de impressora nao fiscal.
     * @throws ACBrException 
     */
    public boolean isUsaImpressoraNaoFiscal() throws ACBrException {
        return ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_GetUsaImpressoraNaoFiscal(getHandle()) != 0;
    }   
    
    /**
     * Indica discriminacao formula DAV.
     * 
     * @param pDAVDiscrFormula indica discriminacao formula DAV.
     * @throws ACBrException 
     */
    public void setDAVDiscrFormula(boolean pDAVDiscrFormula) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_SetDAVDiscrFormula(getHandle(), pDAVDiscrFormula);
        checkResult(ret);
    }

    /**
     * Verifica discriminacao formula DAV.
     * 
     * @return indica discriminacao formula DAV.
     * @throws ACBrException 
     */
    public boolean isDAVDiscrFormula() throws ACBrException {
        return ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_GetDAVDiscrFormula(getHandle()) != 0;
    }     
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Dados Criterios UF">
    /**
     * Indica totalizacao valores lista.
     * 
     * @param pTotalizaValoresLista indica totalizacao valores lista.
     * @throws ACBrException 
     */
    public void setTotalizaValoresLista(boolean pTotalizaValoresLista) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_SetTotalizaValoresLista(getHandle(), pTotalizaValoresLista);
        checkResult(ret);
    }

    /**
     * Verifica a totalizacao valores lista.
     * 
     * @return indica a totalizacao valores lista.
     * @throws ACBrException 
     */
    public boolean isTotalizaValoresLista() throws ACBrException {
        return ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_GetTotalizaValoresLista(getHandle()) != 0;
    }  

    /**
     * Indica transferencia de prevenda.
     * 
     * @param pTransPreVenda indica transferencia de prevenda.
     * @throws ACBrException 
     */
    public void setTransPreVenda(boolean pTransPreVenda) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_SetTransfPreVenda(getHandle(), pTransPreVenda);
        checkResult(ret);
    }

    /**
     * Verifica a transferencia de prevenda.
     * 
     * @return indica a transferencia de prevenda.
     * @throws ACBrException 
     */
    public boolean isTransPreVenda() throws ACBrException {
        return ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_GetTransfPreVenda(getHandle()) != 0;
    }  

    /**
     * Indica transferencia de dav.
     * 
     * @param pTransDAV indica transferencia de dav.
     * @throws ACBrException 
     */
    public void setTransDAV(boolean pTransDAV) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_SetTransfDAV(getHandle(), pTransDAV);
        checkResult(ret);
    }

    /**
     * Verifica a transferencia de dav.
     * 
     * @return indica a transferencia de dav.
     * @throws ACBrException 
     */
    public boolean isTransDAV() throws ACBrException {
        return ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_GetTransfDAV(getHandle()) != 0;
    }  
    
    /**
     * Indica recomposicao GT.
     * 
     * @param pRecompoeGT indica recomposicao GT.
     * @throws ACBrException 
     */
    public void setRecompoeGT(boolean pRecompoeGT) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_SetRecompoeGT(getHandle(), pRecompoeGT);
        checkResult(ret);
    }

    /**
     * Verifica a recomposicao GT.
     * 
     * @return indica a recomposicao GT.
     * @throws ACBrException 
     */
    public boolean isRecompoeGT() throws ACBrException {
        return ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_GetRecompoeGT(getHandle()) != 0;
    }  

    /**
     * Indica recomposicao do numero de serie.
     * 
     * @param pRecompoeNumSerie indica recomposicao do numero de serie.
     * @throws ACBrException 
     */
    public void setRecompoeNumSerie(boolean pRecompoeNumSerie) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_SetRecompoeNumSerie(getHandle(), pRecompoeNumSerie);
        checkResult(ret);
    }

    /**
     * Verifica a recomposicao do numero de serie.
     * 
     * @return indica a recomposicao do numero de serie.
     * @throws ACBrException 
     */
    public boolean isRecompoeNumSerie() throws ACBrException {
        return ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_GetRecompoeNumSerie(getHandle()) != 0;
    }  

    /**
     * Indica emissao de PED.
     * 
     * @param pEmitePED indica emissao de PED.
     * @throws ACBrException 
     */
    public void setEmitePED(boolean pEmitePED) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_SetEmitePED(getHandle(), pEmitePED);
        checkResult(ret);
    }

    /**
     * Verifica emissao de PED.
     * 
     * @return indica emissao de PED.
     * @throws ACBrException 
     */
    public boolean isEmitePED() throws ACBrException {
        return ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_GetEmitePED(getHandle()) != 0;
    }  
   
    /**
     * Indica emissao de cupom mania.
     * 
     * @param pCupomMania indica emissao de cupom mania.
     * @throws ACBrException 
     */
    public void setCupomMania(boolean pCupomMania) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_SetCupomMania(getHandle(), pCupomMania);
        checkResult(ret);
    }

    /**
     * Verifica emissao de cupom mania.
     * 
     * @return indica emissao de cupom mania.
     * @throws ACBrException 
     */
    public boolean isCupomMania() throws ACBrException {
        return ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_GetCupomMania(getHandle()) != 0;
    }      

    /**
     * Indica mensagem minas legal.
     * 
     * @param pMinasLegal indica mensagem minas legal.
     * @throws ACBrException 
     */
    public void setMinasLegal(boolean pMinasLegal) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_SetMinasLegal(getHandle(), pMinasLegal);
        checkResult(ret);
    }

    /**
     * Verifica mensagem minas legal.
     * 
     * @return indica mensagem minas legal.
     * @throws ACBrException 
     */
    public boolean isMinasLegal() throws ACBrException {
        return ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_GetMinasLegal(getHandle()) != 0;
    }      

    /**
     * Indica mensagem paraiba legal.
     * 
     * @param pParaibaLegal indica mensagem paraiba legal.
     * @throws ACBrException 
     */
    public void setParaibaLegal(boolean pParaibaLegal) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_SetParaibaLegal(getHandle(), pParaibaLegal);
        checkResult(ret);
    }

    /**
     * Verifica mensagem paraiba legal.
     * 
     * @return indica mensagem paraiba legal.
     * @throws ACBrException 
     */
    public boolean isParaibaLegal() throws ACBrException {
        return ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_GetParaibaLegal(getHandle()) != 0;
    }      

    /**
     * Indica nota legal DF.
     * 
     * @param pNotaLegalDF indica nota legal DF.
     * @throws ACBrException 
     */
    public void setNotaLegalDF(boolean pNotaLegalDF) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_SetNotaLegalDF(getHandle(), pNotaLegalDF);
        checkResult(ret);
    }

    /**
     * Verifica nota legal DF.
     * 
     * @return indica nota legal DF.
     * @throws ACBrException 
     */
    public boolean isNotaLegalDF() throws ACBrException {
        return ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_GetNotaLegalDF(getHandle()) != 0;
    }      

    /**
     * Indica troco em cartao.
     * 
     * @param pTrocoEmCartao indica troco em cartao.
     * @throws ACBrException 
     */
    public void setTrocoEmCartao(boolean pTrocoEmCartao) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_SetTrocoEmCartao(getHandle(), pTrocoEmCartao);
        checkResult(ret);
    }

    /**
     * Verifica troco em cartao.
     * 
     * @return indica troco em cartao.
     * @throws ACBrException 
     */
    public boolean isTrocoEmCartao() throws ACBrException {
        return ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_GetTrocoEmCartao(getHandle()) != 0;
    } 
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Postos de Combustivel">
    /**
     * Indica acumulo volume diario.
     * 
     * @param pAcumulaVolumeDiario indica acumulo volume diario.
     * @throws ACBrException 
     */
    public void setAcumulaVolumeDiario(boolean pAcumulaVolumeDiario) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_SetAcumulaVolumeDiario(getHandle(), pAcumulaVolumeDiario);
        checkResult(ret);
    }

    /**
     * Verifica acumulo volume diario.
     * 
     * @return indica acumulo volume diario.
     * @throws ACBrException 
     */
    public boolean isAcumulaVolumeDiario() throws ACBrException {
        return ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_GetAcumulaVolumeDiario(getHandle()) != 0;
    }  

    /**
     * Armazena encerrante inicial e final.
     * 
     * @param pArmazenaEncerranteIniFinal armazena encerrante inicial e final.
     * @throws ACBrException 
     */
    public void setArmazenaEncerranteIniFinal(boolean pArmazenaEncerranteIniFinal) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_SetArmazenaEncerranteIniFinal(getHandle(), pArmazenaEncerranteIniFinal);
        checkResult(ret);
    }

    /**
     * Verifica o armazenamento encerrante inicial e final.
     * 
     * @return indica o armazenamento encerrante inicial e final.
     * @throws ACBrException 
     */
    public boolean isArmazenaEncerranteIniFinal() throws ACBrException {
        return ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_GetArmazenaEncerranteIniFinal(getHandle()) != 0;
    }  

    /**
     * Indica cadastro de placa na bomba.
     * 
     * @param pCadastroPlacaBomba indica cadastro de placa na bomba.
     * @throws ACBrException 
     */
    public void setCadastroPlacaBomba(boolean pCadastroPlacaBomba) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_SetCadastroPlacaBomba(getHandle(), pCadastroPlacaBomba);
        checkResult(ret);
    }

    /**
     * Verifica o cadastro de placa na bomba.
     * 
     * @return indica o cadastro de placa na bomba.
     * @throws ACBrException 
     */
    public boolean isCadastroPlacaBomba() throws ACBrException {
        return ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_GetCadastroPlacaBomba(getHandle()) != 0;
    }  

    /**
     * Emite encerrante apos reducao Z e leitura X.
     * 
     * @param pEmiteContrEncerrAposREDZLEIX indica a emissao do encerrante apos reducao Z e leitura X.
     * @throws ACBrException 
     */
    public void setEmiteContrEncerrAposREDZLEIX(boolean pEmiteContrEncerrAposREDZLEIX) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_SetEmiteContrEncerrAposREDZLEIX(getHandle(), pEmiteContrEncerrAposREDZLEIX);
        checkResult(ret);
    }

    /**
     * Verifica a emissao do encerrante apos reducao Z e leitura X.
     * 
     * @return indica a emissao do encerrante apos reducao Z e leitura X.
     * @throws ACBrException 
     */
    public boolean isEmiteContrEncerrAposREDZLEIX() throws ACBrException {
        return ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_GetEmiteContrEncerrAposREDZLEIX(getHandle()) != 0;
    }  
    
    /**
     * Impede vendas com valores zerados.
     * 
     * @param pImpedeVendaVlrZero indica impedimento de vendas com valores zerados.
     * @throws ACBrException 
     */
    public void setImpedeVendaVlrZero(boolean pImpedeVendaVlrZero) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_SetImpedeVendaVlrZero(getHandle(), pImpedeVendaVlrZero);
        checkResult(ret);
    }

    /**
     * Verifica se pode realizar vendas com valores zerados.
     * 
     * @return indica impedimento de vendas com valores zerados.
     * @throws ACBrException 
     */
    public boolean isImpedeVendaVlrZero() throws ACBrException {
        return ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_GetImpedeVendaVlrZero(getHandle()) != 0;
    }  

    /**
     * Indica integracao com bombas.
     * 
     * @param pIntegradoComBombas indica integracao com bombas.
     * @throws ACBrException 
     */
    public void setIntegradoComBombas(boolean pIntegradoComBombas) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_SetIntegradoComBombas(getHandle(), pIntegradoComBombas);
        checkResult(ret);
    }

    /**
     * Verifica se ha integracao com bombas.
     * 
     * @return indica integracao com bombas.
     * @throws ACBrException 
     */
    public boolean isIntegradoComBombas() throws ACBrException {
        return ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_GetIntegradoComBombas(getHandle()) != 0;
    }  

    /**
     * Indica criacao abastecimento divergente encerrante.
     * 
     * @param pCriaAbastDivergEncerrante indica criacao abastecimento divergente encerrante.
     * @throws ACBrException 
     */
    public void setCriaAbastDivergEncerrante(boolean pCriaAbastDivergEncerrante) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_SetCriaAbastDivergEncerrante(getHandle(), pCriaAbastDivergEncerrante);
        checkResult(ret);
    }

    /**
     * Verifica se ha criacao abastecimento divergente encerrante.
     * 
     * @return indica criacao abastecimento divergente encerrante.
     * @throws ACBrException 
     */
    public boolean isCriaAbastDivergEncerrante() throws ACBrException {
        return ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_GetCriaAbastDivergEncerrante(getHandle()) != 0;
    } 
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Transporte de Passageiros">
    /**
     * Indica transporte de passageiros.
     * 
     * @param pTransportePassageiro indica transporte de passageiros.
     * @throws ACBrException 
     */
    public void setTransportePassageiro(boolean pTransportePassageiro) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_SetTransportePassageiro(getHandle(), pTransportePassageiro);
        checkResult(ret);
    }

    /**
     * Verifica indicativo de transporte de passageiros.
     * 
     * @return indica transporte de passageiros.
     * @throws ACBrException 
     */
    public boolean isTransportePassageiro() throws ACBrException {
        return ACBrAACInterop.INSTANCE.AAC_IdentPaf_Paf_GetTransportePassageiro(getHandle()) != 0;
    } 
    // </editor-fold>    
    
}