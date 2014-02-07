package jACBrFramework.sped.blocoC;

import jACBrFramework.sintegra.TipoOperacao;
import jACBrFramework.sped.Emitente;
import jACBrFramework.sped.SituacaoDocto;
import jACBrFramework.sped.TipoFrete;
import jACBrFramework.sped.TipoPagamento;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Date;

/**
 * Nota fiscal (codigo 01), nota fiscal avulsa (codigo 1B), nota fiscal de produto
 * (codigo 04), NF-e (codigo 55) e NFC-e (codigo 65).
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 10:32:19, revisao: $Id$
 */
public class RegistroC100 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Operacoes com ICMS ST recolhido para UF diversa do destinatario do documento fiscal (Codigo 55).
     */
    private Collection<RegistroC105> registroC105 = new ArrayList<RegistroC105>();     
    /**
     * Informacao complementar da nota fiscal (codigo 01, 1B, 04 e 55).
     */
    private Collection<RegistroC110> registroC110 = new ArrayList<RegistroC110>();     
    /**
     * Complemento de documento - operacoes de importacao (codigo 01 e 55)
     */
    private Collection<RegistroC120> registroC120 = new ArrayList<RegistroC120>();     
    /**
     * ISSQN, IRRF e Previdencia Social.
     */
    private Collection<RegistroC130> registroC130 = new ArrayList<RegistroC130>();     
    /**
     * Fatura (codigo 01)
     */
    private Collection<RegistroC140> registroC140 = new ArrayList<RegistroC140>();     
    /**
     * Volumes transportados (codigo 01 e 04) - exceto combustiveis.
     */
    private Collection<RegistroC160> registroC160 = new ArrayList<RegistroC160>();     
    /**
     * Operacoes com combustiveis (codigo 01; 55).
     */
    private Collection<RegistroC165> registroC165 = new ArrayList<RegistroC165>();     
    /**
     * Itens do documento (codigo 01, 1B, 04 e 55).
     */
    private Collection<RegistroC170> registroC170 = new ArrayList<RegistroC170>();     
    /**
     * Registro analitico do documento (codigo 01, 1B, 04, 55 e 65).
     */
    private Collection<RegistroC190> registroC190 = new ArrayList<RegistroC190>();     
    /**
     * Observacoes do lancamento fiscal (codigo 01, 1B, 04 e 55).
     */
    private Collection<RegistroC195> registroC195 = new ArrayList<RegistroC195>();     
    /**
     * Indicador do tipo de operacao.
     */
    private TipoOperacao IND_OPER;
    /**
     * Emitente do documento fiscal.
     */
    private Emitente IND_EMIT;
    /**
     * Codigo do participante (campo 02 do Registro 0150):
     *  - do Emitente do documento ou do remetente das mercadorias, no caso de entradas; 
     *  - do adquirente, no caso de saidas
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
     * Numero do documento fiscal.
     */
    private String NUM_DOC;
    /**
     * Chave da Nota Fiscal Eletronica.
     */
    private String CHV_NFE;
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
     * Indicador do tipo de pagamento.
     */
    private TipoPagamento IND_PGTO;
    /**
     * Valor total do desconto.
     */
    private double VL_DESC;
    /**
     * Abatimento nao tributado e nao comercial Ex. desconto ICMS nas remessas para ZFM.
     */
    private double VL_ABAT_NT;
    /**
     * Valor total das mercadorias e servico.
     */
    private double VL_MERC;
    /**
     * Indicador do tipo do frete.
     */
    private TipoFrete IND_FRT;
    /**
     * Valor do frete indicado no documento fiscal.
     */
    private double VL_FRT;
    /**
     * Valor do seguro indicado no documento fiscal.
     */
    private double VL_SEG;
    /**
     * Valor de outras despesas acessorias.
     */
    private double VL_OUT_DA;
    /**
     * Valor da base de calculo do ICMS.
     */
    private double VL_BC_ICMS;
    /**
     * Valor do ICMS.
     */
    private double VL_ICMS;
    /**
     * Valor da base de calculo do ICMS substituicao tributaria.
     */
    private double VL_BC_ICMS_ST;
    /**
     * Valor do ICMS retido por substituicao tributaria.
     */
    private double VL_ICMS_ST;
    /**
     * Valor total do IPI.
     */
    private double VL_IPI;
    /**
     * Valor total do PIS.
     */
    private double VL_PIS;
    /**
     * Valor total da COFINS.
     */
    private double VL_COFINS;
    /**
     * Valor total do PIS retido por substituicao tributaria.
     */
    private double VL_PIS_ST;
    /**
     * Valor total da COFINS retido por substituicao tributaria.
     */
    private double VL_COFINS_ST;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Operacoes com ICMS ST recolhido para UF diversa do destinatario do documento fiscal (Codigo 55).
     * @return the registroC105
     */
    public Collection<RegistroC105> getRegistroC105() {
        return registroC105;
    }

    /**
     * Informacao complementar da nota fiscal (codigo 01, 1B, 04 e 55).
     * @return the registroC110
     */
    public Collection<RegistroC110> getRegistroC110() {
        return registroC110;
    }

    /**
     * Complemento de documento - operacoes de importacao (codigo 01 e 55)
     * @return the registroC120
     */
    public Collection<RegistroC120> getRegistroC120() {
        return registroC120;
    }

    /**
     * ISSQN, IRRF e Previdencia Social.
     * @return the registroC130
     */
    public Collection<RegistroC130> getRegistroC130() {
        return registroC130;
    }

    /**
     * Fatura (codigo 01)
     * @return the registroC140
     */
    public Collection<RegistroC140> getRegistroC140() {
        return registroC140;
    }

    /**
     * Volumes transportados (codigo 01 e 04) - exceto combustiveis.
     * @return the registroC160
     */
    public Collection<RegistroC160> getRegistroC160() {
        return registroC160;
    }

    /**
     * Operacoes com combustiveis (codigo 01; 55).
     * @return the registroC165
     */
    public Collection<RegistroC165> getRegistroC165() {
        return registroC165;
    }

    /**
     * Itens do documento (codigo 01, 1B, 04 e 55).
     * @return the registroC170
     */
    public Collection<RegistroC170> getRegistroC170() {
        return registroC170;
    }

    /**
     * Registro analitico do documento (codigo 01, 1B, 04, 55 e 65).
     * @return the registroC190
     */
    public Collection<RegistroC190> getRegistroC190() {
        return registroC190;
    }

    /**
     * Observacoes do lancamento fiscal (codigo 01, 1B, 04 e 55).
     * @return the registroC195
     */
    public Collection<RegistroC195> getRegistroC195() {
        return registroC195;
    }

    /**
     * Indicador do tipo de operacao.
     * @return the IND_OPER
     */
    public TipoOperacao getIND_OPER() {
        return IND_OPER;
    }

    /**
     * Indicador do tipo de operacao.
     * @param IND_OPER the IND_OPER to set
     */
    public void setIND_OPER(TipoOperacao IND_OPER) {
        this.IND_OPER = IND_OPER;
    }

    /**
     * Emitente do documento fiscal.
     * @return the IND_EMIT
     */
    public Emitente getIND_EMIT() {
        return IND_EMIT;
    }

    /**
     * Emitente do documento fiscal.
     * @param IND_EMIT the IND_EMIT to set
     */
    public void setIND_EMIT(Emitente IND_EMIT) {
        this.IND_EMIT = IND_EMIT;
    }

    /**
     * Codigo do participante (campo 02 do Registro 0150):
     * - do Emitente do documento ou do remetente das mercadorias, no caso de entradas;
     * - do adquirente, no caso de saidas
     * @return the COD_PART
     */
    public String getCOD_PART() {
        return COD_PART;
    }

    /**
     * Codigo do participante (campo 02 do Registro 0150):
     * - do Emitente do documento ou do remetente das mercadorias, no caso de entradas;
     * - do adquirente, no caso de saidas
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
     * Chave da Nota Fiscal Eletronica.
     * @return the CHV_NFE
     */
    public String getCHV_NFE() {
        return CHV_NFE;
    }

    /**
     * Chave da Nota Fiscal Eletronica.
     * @param CHV_NFE the CHV_NFE to set
     */
    public void setCHV_NFE(String CHV_NFE) {
        this.CHV_NFE = CHV_NFE;
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
     * Indicador do tipo de pagamento.
     * @return the IND_PGTO
     */
    public TipoPagamento getIND_PGTO() {
        return IND_PGTO;
    }

    /**
     * Indicador do tipo de pagamento.
     * @param IND_PGTO the IND_PGTO to set
     */
    public void setIND_PGTO(TipoPagamento IND_PGTO) {
        this.IND_PGTO = IND_PGTO;
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
     * Abatimento nao tributado e nao comercial Ex. desconto ICMS nas remessas para ZFM.
     * @return the VL_ABAT_NT
     */
    public double getVL_ABAT_NT() {
        return VL_ABAT_NT;
    }

    /**
     * Abatimento nao tributado e nao comercial Ex. desconto ICMS nas remessas para ZFM.
     * @param VL_ABAT_NT the VL_ABAT_NT to set
     */
    public void setVL_ABAT_NT(double VL_ABAT_NT) {
        this.VL_ABAT_NT = VL_ABAT_NT;
    }

    /**
     * Valor total das mercadorias e servico.
     * @return the VL_MERC
     */
    public double getVL_MERC() {
        return VL_MERC;
    }

    /**
     * Valor total das mercadorias e servico.
     * @param VL_MERC the VL_MERC to set
     */
    public void setVL_MERC(double VL_MERC) {
        this.VL_MERC = VL_MERC;
    }

    /**
     * Indicador do tipo do frete.
     * @return the IND_FRT
     */
    public TipoFrete getIND_FRT() {
        return IND_FRT;
    }

    /**
     * Indicador do tipo do frete.
     * @param IND_FRT the IND_FRT to set
     */
    public void setIND_FRT(TipoFrete IND_FRT) {
        this.IND_FRT = IND_FRT;
    }

    /**
     * Valor do frete indicado no documento fiscal.
     * @return the VL_FRT
     */
    public double getVL_FRT() {
        return VL_FRT;
    }

    /**
     * Valor do frete indicado no documento fiscal.
     * @param VL_FRT the VL_FRT to set
     */
    public void setVL_FRT(double VL_FRT) {
        this.VL_FRT = VL_FRT;
    }

    /**
     * Valor do seguro indicado no documento fiscal.
     * @return the VL_SEG
     */
    public double getVL_SEG() {
        return VL_SEG;
    }

    /**
     * Valor do seguro indicado no documento fiscal.
     * @param VL_SEG the VL_SEG to set
     */
    public void setVL_SEG(double VL_SEG) {
        this.VL_SEG = VL_SEG;
    }

    /**
     * Valor de outras despesas acessorias.
     * @return the VL_OUT_DA
     */
    public double getVL_OUT_DA() {
        return VL_OUT_DA;
    }

    /**
     * Valor de outras despesas acessorias.
     * @param VL_OUT_DA the VL_OUT_DA to set
     */
    public void setVL_OUT_DA(double VL_OUT_DA) {
        this.VL_OUT_DA = VL_OUT_DA;
    }

    /**
     * Valor da base de calculo do ICMS.
     * @return the VL_BC_ICMS
     */
    public double getVL_BC_ICMS() {
        return VL_BC_ICMS;
    }

    /**
     * Valor da base de calculo do ICMS.
     * @param VL_BC_ICMS the VL_BC_ICMS to set
     */
    public void setVL_BC_ICMS(double VL_BC_ICMS) {
        this.VL_BC_ICMS = VL_BC_ICMS;
    }

    /**
     * Valor do ICMS.
     * @return the VL_ICMS
     */
    public double getVL_ICMS() {
        return VL_ICMS;
    }

    /**
     * Valor do ICMS.
     * @param VL_ICMS the VL_ICMS to set
     */
    public void setVL_ICMS(double VL_ICMS) {
        this.VL_ICMS = VL_ICMS;
    }

    /**
     * Valor da base de calculo do ICMS substituicao tributaria.
     * @return the VL_BC_ICMS_ST
     */
    public double getVL_BC_ICMS_ST() {
        return VL_BC_ICMS_ST;
    }

    /**
     * Valor da base de calculo do ICMS substituicao tributaria.
     * @param VL_BC_ICMS_ST the VL_BC_ICMS_ST to set
     */
    public void setVL_BC_ICMS_ST(double VL_BC_ICMS_ST) {
        this.VL_BC_ICMS_ST = VL_BC_ICMS_ST;
    }

    /**
     * Valor do ICMS retido por substituicao tributaria.
     * @return the VL_ICMS_ST
     */
    public double getVL_ICMS_ST() {
        return VL_ICMS_ST;
    }

    /**
     * Valor do ICMS retido por substituicao tributaria.
     * @param VL_ICMS_ST the VL_ICMS_ST to set
     */
    public void setVL_ICMS_ST(double VL_ICMS_ST) {
        this.VL_ICMS_ST = VL_ICMS_ST;
    }

    /**
     * Valor total do IPI.
     * @return the VL_IPI
     */
    public double getVL_IPI() {
        return VL_IPI;
    }

    /**
     * Valor total do IPI.
     * @param VL_IPI the VL_IPI to set
     */
    public void setVL_IPI(double VL_IPI) {
        this.VL_IPI = VL_IPI;
    }

    /**
     * Valor total do PIS.
     * @return the VL_PIS
     */
    public double getVL_PIS() {
        return VL_PIS;
    }

    /**
     * Valor total do PIS.
     * @param VL_PIS the VL_PIS to set
     */
    public void setVL_PIS(double VL_PIS) {
        this.VL_PIS = VL_PIS;
    }

    /**
     * Valor total da COFINS.
     * @return the VL_COFINS
     */
    public double getVL_COFINS() {
        return VL_COFINS;
    }

    /**
     * Valor total da COFINS.
     * @param VL_COFINS the VL_COFINS to set
     */
    public void setVL_COFINS(double VL_COFINS) {
        this.VL_COFINS = VL_COFINS;
    }

    /**
     * Valor total do PIS retido por substituicao tributaria.
     * @return the VL_PIS_ST
     */
    public double getVL_PIS_ST() {
        return VL_PIS_ST;
    }

    /**
     * Valor total do PIS retido por substituicao tributaria.
     * @param VL_PIS_ST the VL_PIS_ST to set
     */
    public void setVL_PIS_ST(double VL_PIS_ST) {
        this.VL_PIS_ST = VL_PIS_ST;
    }

    /**
     * Valor total da COFINS retido por substituicao tributaria.
     * @return the VL_COFINS_ST
     */
    public double getVL_COFINS_ST() {
        return VL_COFINS_ST;
    }

    /**
     * Valor total da COFINS retido por substituicao tributaria.
     * @param VL_COFINS_ST the VL_COFINS_ST to set
     */
    public void setVL_COFINS_ST(double VL_COFINS_ST) {
        this.VL_COFINS_ST = VL_COFINS_ST;
    }
    // </editor-fold>
    
}