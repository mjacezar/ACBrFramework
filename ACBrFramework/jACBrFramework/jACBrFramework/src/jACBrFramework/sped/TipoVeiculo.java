package jACBrFramework.sped;

/**
 * Tipo de veiculo transportador.
 * 
 * @author Jose Mauro
 * @version Criado em: 29/01/2014 14:14:00, revisao: $Id$
 */
public enum TipoVeiculo {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    Embarcacao(0, "0 – Embarcação"),
    EmpuradorRebocador(1, "1 – Empurrador/rebocador");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do tipo de veiculo.
     */
    private String descricao;
    /**
     * Codigo do tipo de veiculo.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    TipoVeiculo(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do tipo de veiculo.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do tipo de veiculo.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold>       
}