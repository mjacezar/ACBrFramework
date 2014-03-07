package jACBrFramework.tefd;

/**
 * Operacoes de mensagem.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/02/2014 16:14:13, revisao: $Id$
 */
public enum OperacaoMensagem {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    OK(0, "0 - OK"),
    YesNo(1, "1 - YesNo"),
    ExibirMsgOperador(2, "2 - ExibirMsgOperador"),
    RemoverMsgOperador(3, "3 - RemoverMsgOperador"),
    ExibirMsgCliente(4, "4 - ExibirMsgCliente"),
    RemoverMsgCliente(5, "5 - RemoverMsgCliente"),
    DestaqueVia(6, "6 - DestaqueVia");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao das mensagens de operacao.
     */
    private String descricao;
    /**
     * Codigo das mensagens de operacao.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    OperacaoMensagem(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao das mensagens de operacao.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo das mensagens de operacao.
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
    public static OperacaoMensagem valueOf(int pCodigo) {
        for (OperacaoMensagem lOperacaoMensagem : values()) {
            if (lOperacaoMensagem.getCodigo() == pCodigo) return lOperacaoMensagem;
        }
        return null;
    }       
    // </editor-fold>        

}