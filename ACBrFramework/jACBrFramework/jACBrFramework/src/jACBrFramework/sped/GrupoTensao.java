package jACBrFramework.sped;

/**
 * Codigo do grupo de tensao.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 08:49:02, revisao: $Id$
 */
public enum GrupoTensao {
    
    // <editor-fold defaultstate="collapsed" desc="Enums">    
    Nenhum(-1, "'' - Vazio. Para uso quando o documento for cancelado."),
    A1(1, "01 - A1 - Alta Tensão (230kV ou mais)"),
    A2(2, "02 - A2 - Alta Tensão (88 a 138kV)"),
    A3(3, "03 - A3 - Alta Tensão (69kV)"),
    A3a(4, "04 - A3a - Alta Tensão (30kV a 44kV)"),
    A4(5, "05 - A4 - Alta Tensão (2,3kV a 25kV)"),
    AS(6, "06 - AS - Alta Tensão Subterrâneo 06"),
    B107(7, "07 - B1 - Residencial 07"),
    B108(8, "08 - B1 - Residencial Baixa Renda 08"),
    B209(9, "09 - B2 - Rural 09"),
    B2Rural(10, "10 - B2 - Cooperativa de Eletrificação Rural"),
    B2Irrigacao(11, "11 - B2 - Serviço Público de Irrigação"),
    B3(12, "12 - B3 - Demais Classes"),
    B4a(13, "13 - B4a - Iluminação Pública - rede de distribuição"),
    B4b(14, "14 - B4b - Iluminação Pública - bulbo de lâmpada");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do grupo de tensao.
     */
    private String descricao;
    /**
     * Codigo do grupo de tensao.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    GrupoTensao(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do grupo de tensao.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do grupo de tensao.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold> 

}