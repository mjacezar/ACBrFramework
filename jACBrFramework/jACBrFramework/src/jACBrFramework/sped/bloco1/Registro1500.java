package jACBrFramework.sped.bloco1;

import jACBrFramework.sped.ClasseConsumo;
import jACBrFramework.sped.GrupoTensao;
import jACBrFramework.sped.SituacaoDocto;
import jACBrFramework.sped.TipoLigacao;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Date;

/**
 * Nota fsical/conta de energia eletrica (codigo 06) - operacoes interestaduais.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 08:37:09, revisao: $Id$
 */
public class Registro1500 {
    
    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Itens do documento nota fiscal/conta energia eletrica (Codigo 06)
     */
    private Collection<Registro1510> registro1510 = new ArrayList<Registro1510>(); 
    /**
     * Indicador do tipo de operacao: 1- Saida.
     */
    private String IND_OPER;
    /**
     * Indicador do emitente do documento fiscal: 0- Emissao propria.
     */
    private String IND_EMIT;
    /**
     * Codigo do participante (campo 02 do Registro 0150): - do adquirente, no caso das saidas.
     */
    private String COD_PART;
    /**
     * Codigo do modelo do documento fiscal, conforme a Tabela 4.1.1.
     */
    private String COD_MOD;
    /**
     * Codigo da situacao do documento fiscal, conforme a Tabela 4.1.2.
     */
    private SituacaoDocto COD_SIT;
    /**
     * Serie do documento fiscal.
     */
    private String SER;
    /**
     * Subserie do documento fiscal.
     */
    private String SUB;
    /**
     * Codigo de classe de consumo de energia eletrica ou gas.
     */
    private ClasseConsumo COD_CONS;
    /**
     * Numero do documento fiscal.
     */
    private String NUM_DOC;
    /**
     * Data da emissao do documento fiscal.
     */
    private Date DT_DOC;
    /**
     * Data da entrada ou da saida.
     */
    private Date DT_E_S;
    /**
     * Valor total do documento fiscal.
     */
    private double VL_DOC;
    /**
     * Valor total do desconto.
     */
    private double VL_DESC;
    /**
     * Valor total fornecido/consumido.
     */
    private double VL_FORN;
    /**
     * Valor total dos servicos nao-tributados pelo ICMS.
     */
    private double VL_SERV_NT;
    /**
     * Valor total cobrado em nome de terceiros.
     */
    private double VL_TERC;
    /**
     * Valor total de despesas acessorias indicadas no documento fiscal.
     */
    private double VL_DA;
    /**
     * Valor acumulado da base de calculo do ICMS.
     */
    private double VL_BC_ICMS;
    /**
     * Valor acumulado do ICMS.
     */
    private double VL_ICMS;
    /**
     * Valor acumulado da base de calculo do ICMS substituicao tributaria.
     */
    private double VL_BC_ICMS_ST;
    /**
     * Valor acumulado do ICMS retido por substituicao tributaria.
     */
    private double VL_ICMS_ST;
    /**
     * Codigo da informacao complementar do documento fiscal (campo 02 do Registro 0450).
     */
    private String COD_INF;
    /**
     * Valor do PIS.
     */
    private double VL_PIS;
    /**
     * Valor da COFINS.
     */
    private double VL_COFINS;
    /**
     * Codigo de tipo de Ligacao.
     */
    private TipoLigacao TP_LIGACAO;
    /**
     * Codigo de grupo de tensao.
     */
    private GrupoTensao COD_GRUPO_TENSAO;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">     
    /**
     * Itens do documento nota fiscal/conta energia eletrica (Codigo 06)
     * @return the registro1510
     */
    public Collection<Registro1510> getRegistro1510() {
        return registro1510;
    }

    /**
     * Indicador do tipo de operacao: 1- Saida.
     * @return the IND_OPER
     */
    public String getIND_OPER() {
        return IND_OPER;
    }

    /**
     * Indicador do tipo de operacao: 1- Saida.
     * @param IND_OPER the IND_OPER to set
     */
    public void setIND_OPER(String IND_OPER) {
        this.IND_OPER = IND_OPER;
    }

    /**
     * Indicador do emitente do documento fiscal: 0- Emissao propria.
     * @return the IND_EMIT
     */
    public String getIND_EMIT() {
        return IND_EMIT;
    }

    /**
     * Indicador do emitente do documento fiscal: 0- Emissao propria.
     * @param IND_EMIT the IND_EMIT to set
     */
    public void setIND_EMIT(String IND_EMIT) {
        this.IND_EMIT = IND_EMIT;
    }

    /**
     * Codigo do participante (campo 02 do Registro 0150): - do adquirente, no caso das saidas.
     * @return the COD_PART
     */
    public String getCOD_PART() {
        return COD_PART;
    }

    /**
     * Codigo do participante (campo 02 do Registro 0150): - do adquirente, no caso das saidas.
     * @param COD_PART the COD_PART to set
     */
    public void setCOD_PART(String COD_PART) {
        this.COD_PART = COD_PART;
    }

    /**
     * Codigo do modelo do documento fiscal, conforme a Tabela 4.1.1.
     * @return the COD_MOD
     */
    public String getCOD_MOD() {
        return COD_MOD;
    }

    /**
     * Codigo do modelo do documento fiscal, conforme a Tabela 4.1.1.
     * @param COD_MOD the COD_MOD to set
     */
    public void setCOD_MOD(String COD_MOD) {
        this.COD_MOD = COD_MOD;
    }

    /**
     * Codigo da situacao do documento fiscal, conforme a Tabela 4.1.2.
     * @return the COD_SIT
     */
    public SituacaoDocto getCOD_SIT() {
        return COD_SIT;
    }

    /**
     * Codigo da situacao do documento fiscal, conforme a Tabela 4.1.2.
     * @param COD_SIT the COD_SIT to set
     */
    public void setCOD_SIT(SituacaoDocto COD_SIT) {
        this.COD_SIT = COD_SIT;
    }

    /**
     * Serie do documento fiscal.
     * @return the SER
     */
    public String getSER() {
        return SER;
    }

    /**
     * Serie do documento fiscal.
     * @param SER the SER to set
     */
    public void setSER(String SER) {
        this.SER = SER;
    }

    /**
     * Subserie do documento fiscal.
     * @return the SUB
     */
    public String getSUB() {
        return SUB;
    }

    /**
     * Subserie do documento fiscal.
     * @param SUB the SUB to set
     */
    public void setSUB(String SUB) {
        this.SUB = SUB;
    }

    /**
     * Codigo de classe de consumo de energia eletrica ou gas.
     * @return the COD_CONS
     */
    public ClasseConsumo getCOD_CONS() {
        return COD_CONS;
    }

    /**
     * Codigo de classe de consumo de energia eletrica ou gas.
     * @param COD_CONS the COD_CONS to set
     */
    public void setCOD_CONS(ClasseConsumo COD_CONS) {
        this.COD_CONS = COD_CONS;
    }

    /**
     * Numero do documento fiscal.
     * @return the NUM_DOC
     */
    public String getNUM_DOC() {
        return NUM_DOC;
    }

    /**
     * Numero do documento fiscal.
     * @param NUM_DOC the NUM_DOC to set
     */
    public void setNUM_DOC(String NUM_DOC) {
        this.NUM_DOC = NUM_DOC;
    }

    /**
     * Data da emissao do documento fiscal.
     * @return the DT_DOC
     */
    public Date getDT_DOC() {
        return DT_DOC;
    }

    /**
     * Data da emissao do documento fiscal.
     * @param DT_DOC the DT_DOC to set
     */
    public void setDT_DOC(Date DT_DOC) {
        this.DT_DOC = DT_DOC;
    }

    /**
     * Data da entrada ou da saida.
     * @return the DT_E_S
     */
    public Date getDT_E_S() {
        return DT_E_S;
    }

    /**
     * Data da entrada ou da saida.
     * @param DT_E_S the DT_E_S to set
     */
    public void setDT_E_S(Date DT_E_S) {
        this.DT_E_S = DT_E_S;
    }

    /**
     * Valor total do documento fiscal.
     * @return the VL_DOC
     */
    public double getVL_DOC() {
        return VL_DOC;
    }

    /**
     * Valor total do documento fiscal.
     * @param VL_DOC the VL_DOC to set
     */
    public void setVL_DOC(double VL_DOC) {
        this.VL_DOC = VL_DOC;
    }

    /**
     * Valor total do desconto.
     * @return the VL_DESC
     */
    public double getVL_DESC() {
        return VL_DESC;
    }

    /**
     * Valor total do desconto.
     * @param VL_DESC the VL_DESC to set
     */
    public void setVL_DESC(double VL_DESC) {
        this.VL_DESC = VL_DESC;
    }

    /**
     * Valor total fornecido/consumido.
     * @return the VL_FORN
     */
    public double getVL_FORN() {
        return VL_FORN;
    }

    /**
     * Valor total fornecido/consumido.
     * @param VL_FORN the VL_FORN to set
     */
    public void setVL_FORN(double VL_FORN) {
        this.VL_FORN = VL_FORN;
    }

    /**
     * Valor total dos servicos nao-tributados pelo ICMS.
     * @return the VL_SERV_NT
     */
    public double getVL_SERV_NT() {
        return VL_SERV_NT;
    }

    /**
     * Valor total dos servicos nao-tributados pelo ICMS.
     * @param VL_SERV_NT the VL_SERV_NT to set
     */
    public void setVL_SERV_NT(double VL_SERV_NT) {
        this.VL_SERV_NT = VL_SERV_NT;
    }

    /**
     * Valor total cobrado em nome de terceiros.
     * @return the VL_TERC
     */
    public double getVL_TERC() {
        return VL_TERC;
    }

    /**
     * Valor total cobrado em nome de terceiros.
     * @param VL_TERC the VL_TERC to set
     */
    public void setVL_TERC(double VL_TERC) {
        this.VL_TERC = VL_TERC;
    }

    /**
     * Valor total de despesas acessorias indicadas no documento fiscal.
     * @return the VL_DA
     */
    public double getVL_DA() {
        return VL_DA;
    }

    /**
     * Valor total de despesas acessorias indicadas no documento fiscal.
     * @param VL_DA the VL_DA to set
     */
    public void setVL_DA(double VL_DA) {
        this.VL_DA = VL_DA;
    }

    /**
     * Valor acumulado da base de calculo do ICMS.
     * @return the VL_BC_ICMS
     */
    public double getVL_BC_ICMS() {
        return VL_BC_ICMS;
    }

    /**
     * Valor acumulado da base de calculo do ICMS.
     * @param VL_BC_ICMS the VL_BC_ICMS to set
     */
    public void setVL_BC_ICMS(double VL_BC_ICMS) {
        this.VL_BC_ICMS = VL_BC_ICMS;
    }

    /**
     * Valor acumulado do ICMS.
     * @return the VL_ICMS
     */
    public double getVL_ICMS() {
        return VL_ICMS;
    }

    /**
     * Valor acumulado do ICMS.
     * @param VL_ICMS the VL_ICMS to set
     */
    public void setVL_ICMS(double VL_ICMS) {
        this.VL_ICMS = VL_ICMS;
    }

    /**
     * Valor acumulado da base de calculo do ICMS substituicao tributaria.
     * @return the VL_BC_ICMS_ST
     */
    public double getVL_BC_ICMS_ST() {
        return VL_BC_ICMS_ST;
    }

    /**
     * Valor acumulado da base de calculo do ICMS substituicao tributaria.
     * @param VL_BC_ICMS_ST the VL_BC_ICMS_ST to set
     */
    public void setVL_BC_ICMS_ST(double VL_BC_ICMS_ST) {
        this.VL_BC_ICMS_ST = VL_BC_ICMS_ST;
    }

    /**
     * Valor acumulado do ICMS retido por substituicao tributaria.
     * @return the VL_ICMS_ST
     */
    public double getVL_ICMS_ST() {
        return VL_ICMS_ST;
    }

    /**
     * Valor acumulado do ICMS retido por substituicao tributaria.
     * @param VL_ICMS_ST the VL_ICMS_ST to set
     */
    public void setVL_ICMS_ST(double VL_ICMS_ST) {
        this.VL_ICMS_ST = VL_ICMS_ST;
    }

    /**
     * Codigo da informacao complementar do documento fiscal (campo 02 do Registro 0450).
     * @return the COD_INF
     */
    public String getCOD_INF() {
        return COD_INF;
    }

    /**
     * Codigo da informacao complementar do documento fiscal (campo 02 do Registro 0450).
     * @param COD_INF the COD_INF to set
     */
    public void setCOD_INF(String COD_INF) {
        this.COD_INF = COD_INF;
    }

    /**
     * Valor do PIS.
     * @return the VL_PIS
     */
    public double getVL_PIS() {
        return VL_PIS;
    }

    /**
     * Valor do PIS.
     * @param VL_PIS the VL_PIS to set
     */
    public void setVL_PIS(double VL_PIS) {
        this.VL_PIS = VL_PIS;
    }

    /**
     * Valor da COFINS.
     * @return the VL_COFINS
     */
    public double getVL_COFINS() {
        return VL_COFINS;
    }

    /**
     * Valor da COFINS.
     * @param VL_COFINS the VL_COFINS to set
     */
    public void setVL_COFINS(double VL_COFINS) {
        this.VL_COFINS = VL_COFINS;
    }

    /**
     * Codigo de tipo de Ligacao.
     * @return the TP_LIGACAO
     */
    public TipoLigacao getTP_LIGACAO() {
        return TP_LIGACAO;
    }

    /**
     * Codigo de tipo de Ligacao.
     * @param TipoLigacao the TP_LIGACAO to set
     */
    public void setTP_LIGACAO(TipoLigacao TP_LIGACAO) {
        this.TP_LIGACAO = TP_LIGACAO;
    }

    /**
     * Codigo de grupo de tensao.
     * @return the COD_GRUPO_TENSAO
     */
    public GrupoTensao getCOD_GRUPO_TENSAO() {
        return COD_GRUPO_TENSAO;
    }

    /**
     * Codigo de grupo de tensao.
     * @param COD_GRUPO_TENSAO the COD_GRUPO_TENSAO to set
     */
    public void setCOD_GRUPO_TENSAO(GrupoTensao COD_GRUPO_TENSAO) {
        this.COD_GRUPO_TENSAO = COD_GRUPO_TENSAO;
    }
    // </editor-fold>
    
}