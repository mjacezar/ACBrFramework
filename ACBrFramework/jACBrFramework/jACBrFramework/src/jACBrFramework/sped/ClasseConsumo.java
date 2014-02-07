package jACBrFramework.sped;

/**
 * Codigo de classe de consumo de energia eletrica ou gas.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 08:41:58, revisao: $Id$
 */
public enum ClasseConsumo {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    Comercial(1, "01 - Comercial"),
    ConsumoProprio(2, "02 - Consumo Próprio"),
    IluminacaoPublica(3, "03 - Iluminação Pública"),
    Industrial(4, "04 - Industrial"),
    PoderPublico(5, "05 - Poder Público"),
    Residencial(6, "06 - Residencial"),
    Rural(7, "07 - Rural"),
    ServicoPublico(8, "08 -Serviço Público");
    // </editor-fold>    
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao da classe de consumo.
     */
    private String descricao;
    /**
     * Codigo da classe de consumo.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    ClasseConsumo(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao da classe de consumo.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo da classe de consumo.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold>       
}