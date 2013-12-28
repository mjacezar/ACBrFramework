package jACBrFramework.aac;

/**
 * Arquivo PAF.
 * 
 * @author Jose Mauro
 * @version Criado em: 16/12/2013 15:03:41, revisao: $Id$
 */
public class Arquivo {

    // <editor-fold defaultstate="collapsed" desc="Attributes">        
    /**
     * MD5 do arquivo.
     */
    private String md5;
    /**
     * Nome do arquivo.
     */
    private String Nome;
    // </editor-fold>    
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * MD5 do arquivo.
     * @return the md5
     */
    public String getMd5() {
        return md5;
    }

    /**
     * MD5 do arquivo.
     * @param md5 the md5 to set
     */
    public void setMd5(String md5) {
        this.md5 = md5;
    }

    /**
     * Nome do arquivo.
     * @return the Nome
     */
    public String getNome() {
        return Nome;
    }

    /**
     * Nome do arquivo.
     * @param Nome the Nome to set
     */
    public void setNome(String Nome) {
        this.Nome = Nome;
    }
    // </editor-fold>        
    
}