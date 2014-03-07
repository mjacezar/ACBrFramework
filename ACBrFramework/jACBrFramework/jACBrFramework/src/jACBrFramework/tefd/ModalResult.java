package jACBrFramework.tefd;

/**
 * Resultado modal.
 * 
 * @author Jose Mauro
 * @version Criado em: 06/03/2014 14:42:48, revisao: $Id$
 */
public enum ModalResult {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    None(0, "0 - None"),
    OK(1, "1 - OK"),
    Cancel(2, "2 - Cancel"),
    Abort(3, "3 - Abort"),
    Retry(4, "4 - Retry"),
    Ignore(5, "5 - Ignore"),
    Yes(6, "6 - Yes"),
    No(7, "7 - No"),
    All(8, "8 - All"),
    NoToAll(9, "9 - NoToAll"),
    YesToAll(10, "10 - YesToAll");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do resultado modal.
     */
    private String descricao;
    /**
     * Codigo do resultado modal.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    ModalResult(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do resultado modal.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do resultado modal.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    
    /**
     * Recupera o enum pelo codigo correspondente.
     * 
     * @param pCodigo codigo a ser recuperado.
     * @return 
     */
    public static ModalResult valueOf(int pCodigo) {
        for (ModalResult lModalResult : values()) {
            if (lModalResult.getCodigo() == pCodigo) return lModalResult;
        }
        return null;
    }     
    // </editor-fold>          

}