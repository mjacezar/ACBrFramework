package jACBrFramework.sped;

/**
 * Tipo de referencia da base de calculo do ICMS (ST) do produto farmaceutico.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 15:22:26, revisao: $Id$
 */
public enum TipoBaseMedicamento {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    CalcTabeladoSugerido(0, "0 - Base de cálculo referente ao preço tabelado ou preço máximo sugerido"),
    CalMargemAgregado(1, "1 - Base cálculo – Margem de valor agregado"),
    CalListNegativa(2, "2 - Base de cálculo referente à Lista Negativa"),
    CalListaPositiva(3, "3 - Base de cálculo referente à Lista Positiva"),
    CalListNeutra(4, "4 - Base de cálculo referente à Lista Neutra");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do tipo base de medicamento.
     */
    private String descricao;
    /**
     * Codigo do tipo base de medicamento.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    TipoBaseMedicamento(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do tipo base de medicamento.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do tipo base de medicamento.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold>     
}