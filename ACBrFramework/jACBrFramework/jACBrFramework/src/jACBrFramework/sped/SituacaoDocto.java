package jACBrFramework.sped;

/**
 * Situacao do documento.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 08:38:06, revisao: $Id$
 */
public enum SituacaoDocto {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    Regular(0, "00 - Documento regular"),
    ExtempRegular(1, "01 - Escrituração extemporânea de documento regular"),
    Cancelado(2, "02 - Documento cancelado"),
    CanceladoExtemp(3, "03 - Escrituração extemporânea de documento cancelado"),
    DoctoDenegado(4, "04 - NF-e ou CT-e - denegado"),
    DoctoNumInutilizada(5, "05 - NF-e ou CT-e - Numeração inutilizada"),
    FiscalCompl(6, "06 - Documento Fiscal Complementar"),
    ExtempCompl(7, "07 - Escrituração extemporânea de documento complementar"),
    RegimeEspecNEsp(8, "08 - Documento Fiscal emitido com base em Regime Especial ou Norma Específica");
    // </editor-fold>    
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao da situacao do documento.
     */
    private String descricao;
    /**
     * Codigo da situacao do documento.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    SituacaoDocto(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao da situacao do documento.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo da situacao do documento.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold>   
    
}