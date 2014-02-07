package jACBrFramework.sped;

/**
 * Tipo de titulo.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 14:19:26, revisao: $Id$
 */
public enum TipoTitulo {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    Duplicata(0, "00- Duplicata"),
    Cheque(1, "01- Cheque"),
    Promissoria(2, "02- Promissória"),
    Recibo(3, "03- Recibo"),
    Outros(99, "99- Outros (descrever)");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do tipo de titulo.
     */
    private String descricao;
    /**
     * Codigo do tipo de titulo.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    TipoTitulo(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do tipo de titulo.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do tipo de titulo.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold>      
}