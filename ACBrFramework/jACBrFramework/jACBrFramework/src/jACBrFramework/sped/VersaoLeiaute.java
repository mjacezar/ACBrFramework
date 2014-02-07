package jACBrFramework.sped;

/**
 * Versao do layout da Escrituracao Fiscal de Documentos - EFD
 * 
 * @author Jose Mauro
 * @version Criado em: 27/01/2014 08:23:45, revisao: $Id$
 */
public enum VersaoLeiaute {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    Versao100("100", 1, "Código 001 - Versão 100 Ato COTEPE 01/01/2008"),
    Versao101("101", 2, "Código 002 - Versão 101 Ato COTEPE 01/01/2009"),
    Versao102("102", 3, "Código 003 - Versão 102 Ato COTEPE 01/01/2010"),
    Versao103("103", 4, "Código 004 - Versão 103 Ato COTEPE 01/01/2011"),
    Versao104("104", 5, "Código 005 - Versão 104 Ato COTEPE 01/01/2012"),
    Versao105("105", 6, "Código 006 - Versão 105 Ato COTEPE 01/07/2012"),
    Versao106("106", 7, "Código 007 - Versão 106 Ato COTEPE 01/01/2013");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao da versao.
     */
    private String descricao;
    /**
     * Codigo da versao
     */
    private int codigo;
    /**
     * Versao do layout.
     */
    private String versao;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    VersaoLeiaute(String pVersao, int pCodigo, String pDescricao) {
        versao = pVersao;
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao da versao.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo da versao
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }

    /**
     * Versao do layout.
     * @return the versao
     */
    public String getVersao() {
        return versao;
    }
    // </editor-fold>        

}