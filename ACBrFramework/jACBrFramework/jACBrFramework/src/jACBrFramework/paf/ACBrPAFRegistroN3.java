package jACBrFramework.paf;

/**
 * Relacao dos arquivos executaveis e seus codigos de autenticacao (MD5).
 * 
 * @author Jose Mauro
 * @version Criado em: 10/12/2013 17:45:33, revisao: $Id$
 */
public final class ACBrPAFRegistroN3 {

    // <editor-fold defaultstate="collapsed" desc="Attributes">  
    /**
     * Nome do arquivo executavel.
     */
    private String nomeArquivo;
    /**
     * Codigo de autenticacao (MD-5).
     */
    private String md5;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Nome do arquivo executavel.
     * @return the nomeArquivo
     */
    public String getNomeArquivo() {
        return nomeArquivo;
    }

    /**
     * Nome do arquivo executavel.
     * @param nomeArquivo the nomeArquivo to set
     */
    public void setNomeArquivo(String nomeArquivo) {
        this.nomeArquivo = nomeArquivo;
    }

    /**
     * Codigo de autenticacao (MD-5).
     * @return the md5
     */
    public String getMd5() {
        return md5;
    }

    /**
     * Codigo de autenticacao (MD-5).
     * @param md5 the md5 to set
     */
    public void setMd5(String md5) {
        this.md5 = md5;
    }
    // </editor-fold>
    
}