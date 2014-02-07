package jACBrFramework.sped;

/**
 * Tipo de movimentacao de bens ou componentes ativo.
 * 
 * @author Jose Mauro
 * @version Criado em: 30/01/2014 15:07:26, revisao: $Id$
 */
public enum MovimentoBens {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    SI(0, "SI = Saldo inicial de bens imobilizados"),
    IM(1, "IM = Imobilização de bem individual"),
    IA(2, "IA = Imobilização em Andamento - Componente"),
    CI(3, "CI = Conclusão de Imobilização em Andamento – Bem Resultante"),
    MC(4, "MC = Imobilização oriunda do Ativo Circulante"),
    BA(5, "BA = Baixa do Saldo de ICMS - Fim do período de apropriação"),
    AT(6, "AT = Alienação ou Transferência"),
    PE(7, "PE = Perecimento, Extravio ou Deterioração"),
    OT(8, "OT = Outras Saídas do Imobilizado");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do tipo de movimento.
     */
    private String descricao;
    /**
     * Codigo do tipo de movimento.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    MovimentoBens(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do tipo de movimento.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do tipo de movimento.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold>       
}