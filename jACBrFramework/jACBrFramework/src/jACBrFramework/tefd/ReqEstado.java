package jACBrFramework.tefd;

/**
 * Estado das requisicoes.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/02/2014 17:17:09, revisao: $Id$
 */
public enum ReqEstado {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    Nenhum(0, "0 - Nennhuma Requisição em andamento"),
    Iniciando(1, "1 - Iniciando uma nova Requisicao"),
    CriandoArquivo(2, "2 - Arquivo Temporário de requisição está sendo criado"),
    AguardandoResposta(3, "3 - Requisição Escrita, Aguardando Resposta"),
    ConferindoResposta(4, "4 - Verifica se o STS é válido"),
    Finalizada(5, "5 - Finalizada");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao dos estados das requisicoes.
     */
    private String descricao;
    /**
     * Codigo dos estados das requisicoes.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    ReqEstado(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao dos estados das requisicoes.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo dos estados das requisicoes.
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
    public static ReqEstado valueOf(int pCodigo) {
        for (ReqEstado lReqEstado : values()) {
            if (lReqEstado.getCodigo() == pCodigo) return lReqEstado;
        }
        return null;
    }    
    // </editor-fold>       

}