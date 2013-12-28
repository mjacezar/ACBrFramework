package jACBrFramework.aac;

import jACBrFramework.ACBrException;
import jACBrFramework.interop.ACBrAACInterop;
import java.nio.ByteBuffer;

/**
 * Identificacao do PAF.
 * 
 * @author Jose Mauro
 * @version Criado em: 16/12/2013 14:20:11, revisao: $Id$
 */
public class IdenticacaoPaf extends ACBrAACWrapper {

    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Identificacao da empresa.
     */
    private Empresa empresa = null;
    /**
     * Informacoes do PAF.
     */
    private InfoPaf paf = null;
    /**
     * ECFs autorizados.
     */
    private ECFs ecfsAutorizados = null;
    /**
     * Outros arquivos criptografados.
     */
    private Arquivos outrosArquivos = null;
    /**
     * Lista de arquivo autenticados.
     */
    private ArquivoListaAutenticados arquivoListaAutenticados = null;
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    /**
     * Cria um novo objeto empresa.
     * 
     * @param pAac instancia para auxiliar a criptografia.
     */
    IdenticacaoPaf(ACBrAAC pAac) {
        super(pAac);
        empresa = new Empresa(aac);
        paf = new InfoPaf(aac);
        ecfsAutorizados = new ECFs(aac);
        outrosArquivos = new Arquivos(aac);
        arquivoListaAutenticados = new ArquivoListaAutenticados(aac);
    }    
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Components Methods">
    /**
     * Numero do laudo.
     * 
     * @param pNumeroLaudo
     * @throws ACBrException 
     */
    public void setNumeroLaudo(String pNumeroLaudo) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_SetNumeroLaudo(getHandle(), toUTF8(pNumeroLaudo));
        checkResult(ret);
    }
    
    /**
     * Numero do laudo.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getNumeroLaudo() throws ACBrException {
        ByteBuffer lNumeroLaudo = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_GetNumeroLaudo(getHandle(), lNumeroLaudo, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lNumeroLaudo, ret);
    } 

    /**
     * Versao.
     * 
     * @param pVersaoER
     * @throws ACBrException 
     */
    public void setVersaoER(String pVersaoER) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_SetVersaoER(getHandle(), toUTF8(pVersaoER));
        checkResult(ret);
    }
    
    /**
     * Versao.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getVersaoER() throws ACBrException {
        ByteBuffer lVersaoER = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_GetVersaoER(getHandle(), lVersaoER, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lVersaoER, ret);
    }
    // </editor-fold>    
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters"> 
    /**
     * Identificacao da empresa.
     * @return the empresa
     */
    public Empresa getEmpresa() {
        return empresa;
    }

    /**
     * Informacoes do PAF.
     * @return the paf
     */
    public InfoPaf getPaf() {
        return paf;
    }

    /**
     * ECFs autorizados.
     * @return the ecfsAutorizados
     */
    public ECFs getEcfsAutorizados() {
        return ecfsAutorizados;
    }

    /**
     * Outros arquivos criptografados.
     * @return the outrosArquivos
     */
    public Arquivos getOutrosArquivos() {
        return outrosArquivos;
    }

    /**
     * Lista de arquivo autenticados.
     * @return the arquivoListaAutenticados
     */
    public ArquivoListaAutenticados getArquivoListaAutenticados() {
        return arquivoListaAutenticados;
    }
    // </editor-fold>    
    
}