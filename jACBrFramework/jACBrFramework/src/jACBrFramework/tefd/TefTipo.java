package jACBrFramework.tefd;

/**
 * Tipo do TEF.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/02/2014 08:26:12, revisao: $Id$
 */
public enum TefTipo {
 
    // <editor-fold defaultstate="collapsed" desc="Enums">    
    Nenhum(0, "0 - Nenhum"),
    TefDial(1, "1 - TefDial"),
    TefDisc(2, "2 - TefDisc"),
    HiperTef(3, "3 - HiperTef"),
    CliSiTef(4, "4 - CliSiTef"),
    TefGpu(5, "5 - TefGpu"),
    VeSPague(6, "6 - VeSPague"),
    Banese(7, "7 - Banese"),
    TefAuttar(8, "8 - TefAuttar"),
    GoodCard(9, "9 - GoodCard"),
    FoxWin(10, "10 - FoxWin"),
    CliDTEF(11, "11 - CliDTEF"),
    Petrocard(12, "12 - Petrocard"),
    CrediShop(13, "13 - CrediShop"),
    TicketCar(14, "14 - TicketCar"),
    ConvCard(15, "15 - ConvCard");		    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do tipo de TEF.
     */
    private String descricao;
    /**
     * Codigo do tipo de TEF.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    TefTipo(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do tipo de TEF.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do tipo de TEF.
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
    public static TefTipo valueOf(int pCodigo) {
        for (TefTipo lTefTipo : values()) {
            if (lTefTipo.getCodigo() == pCodigo) return lTefTipo;
        }
        return null;
    }
    // </editor-fold>          

}