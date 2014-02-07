package jACBrFramework.sped;

/**
 * Codigo da natureza da conta/grupo de contas.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/01/2014 10:48:27, revisao: $Id$
 */
public enum NaturezaConta {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    ContasAtivo(1, "Contas de ativo"),
    ContasPassivo(2, "Contas de passivo"),
    PatrimonioLiquido(3, "Patrimônio líquido"),
    ContasResultado(4, "Contas de resultado"),
    ContasCompesacao(5, "Contas de compensação"),
    Outras(6, "Outras");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao da natureza.
     */
    private String descricao;
    /**
     * Codigo da natureza.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    NaturezaConta(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao da natureza.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo da natureza.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold>  
    
}