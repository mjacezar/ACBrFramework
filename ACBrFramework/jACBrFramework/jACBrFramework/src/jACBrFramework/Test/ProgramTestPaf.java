package jACBrFramework.Test;

import jACBrFramework.ACBrEventListener;
import jACBrFramework.ACBrException;
import jACBrFramework.paf.*;
import java.nio.charset.Charset;
import java.util.Calendar;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 * Teste dos arquivo PAF.
 * 
 * @author Jose Mauro
 * @version Criado em: 11/12/2013 21:29:04, revisao: $Id$
 */
public class ProgramTestPaf {

    public static void main(String[] args) {
        try {
            ACBrPAF lAcbrPaf = new ACBrPAF(Charset.forName("cp1252")); 
            System.out.println("\nNome Arquivo: " + lAcbrPaf.getNomeArquivo());
            System.out.print("setNomeArquivo -> ");
            lAcbrPaf.setNomeArquivo("teste_paf_");
            System.out.println(lAcbrPaf.getNomeArquivo());   
            
            System.out.println("Delimitador: " + lAcbrPaf.getDelimitador());
            System.out.print("setDelimitador -> ");
            lAcbrPaf.setDelimitador("|");
            System.out.println(lAcbrPaf.getDelimitador());               

//            System.out.println("Mascara: " + lAcbrPaf.getCurMascara());
//            System.out.print("setCurMascara -> ");
//            lAcbrPaf.setCurMascara("#0.00");
//            System.out.println(lAcbrPaf.getCurMascara());               
            
            System.out.println("Trim String: " + lAcbrPaf.isTrimString());
            System.out.print("setTrimString -> ");
            lAcbrPaf.setTrimString(false);
            System.out.println(lAcbrPaf.isTrimString());            

//            System.out.println("Assinar Arquivo: " + lAcbrPaf.isAssinarArquivo());
//            System.out.print("setAssinarArquivo -> ");
//            lAcbrPaf.setAssinarArquivo(false);
//            System.out.println(lAcbrPaf.isAssinarArquivo());      

			System.out.println("Exemplo do evento GetKey.");
            lAcbrPaf.addOnPAFGetKeyRSA(new ACBrEventListener<PAFGetKeyRSAEventObject>() {
                @Override
                public void notification(PAFGetKeyRSAEventObject e) {
                    System.out.println(">> Evento OnPAFGetKeyRSA <<" + e.getKey());
                }
            });
            
            System.out.println("Salvando registros B");
            populaPafB(lAcbrPaf.getPaf_B(), 2);
            lAcbrPaf.saveFileTXT_B("arquivoB.txt");
            
            System.out.println("Salvando registros C");
            populaPafC(lAcbrPaf.getPaf_C(), 3);
            lAcbrPaf.saveFileTXT_C("arquivoC.txt");

            System.out.println("Salvando registros D");
            populaPafD(lAcbrPaf.getPaf_D(), 2, 4, 3);
            lAcbrPaf.saveFileTXT_D("arquivoD.txt");
            
            System.out.println("Salvando registros E");
            populaPafE(lAcbrPaf.getPaf_E(), 5);
            lAcbrPaf.saveFileTXT_E("arquivoE.txt");   
            
            System.out.println("Salvando registros H");
            populaPafH(lAcbrPaf.getPaf_H(), 2);
            lAcbrPaf.saveFileTXT_H("arquivoH.txt");        
            
            System.out.println("Salvando registros N");
            populaPafN(lAcbrPaf.getPaf_N(), 2);
            lAcbrPaf.saveFileTXT_N("arquivoN.txt");  

            System.out.println("Salvando registros P");
            populaPafP(lAcbrPaf.getPaf_P(), 4);
            lAcbrPaf.saveFileTXT_P("arquivoP.txt");  

            System.out.println("Salvando registros R");
            populaPafR(lAcbrPaf.getPaf_R(), 2, 2, 3, 4, 5, 6, 7);
            lAcbrPaf.saveFileTXT_R("arquivoR.txt");  

            System.out.println("Salvando registros T");
            populaPafT(lAcbrPaf.getPaf_T(), 5);
            lAcbrPaf.saveFileTXT_T("arquivoT.txt");              
            
            System.out.println("Salvando registros TITP");
            populaPafTITP(lAcbrPaf.getPaf_TITP(), 5, 5);
            lAcbrPaf.saveFileTXT_TITP("arquivoTITP.txt");     
            
            System.out.println("Salvando registros de ECF.");
            populaPafA(lAcbrPaf.getPaf_A(), 2);
            populaPafD(lAcbrPaf.getPaf_D(), 2, 4, 3);
            populaPafE(lAcbrPaf.getPaf_E(), 5);
            populaPafP(lAcbrPaf.getPaf_P(), 4);
            populaPafR(lAcbrPaf.getPaf_R(), 2, 2, 3, 4, 5, 6, 7);
            populaPafU(lAcbrPaf.getPaf_U());
            lAcbrPaf.saveFileTXT_RegistrosECF("registros_ecf.txt");
            
            //System.out.println("Assinar Arquivo com EAD: " + lAcbrPaf.assinarArquivoComEAD("arquivoB.txt"));
        } catch (ACBrException ex) {
            Logger.getLogger(ProgramTestPaf.class.getName()).log(Level.SEVERE, null, ex);
        }
    }     
    
    private static void populaPafA(ACBrPAF_A pRegistroA, int pQtdeA2) {
        pRegistroA.getRegistroA1().setCnpj("77058992102725");
        pRegistroA.getRegistroA1().setInscEstadual("0659121090814");
        pRegistroA.getRegistroA1().setInscMunicipal("");
        pRegistroA.getRegistroA1().setRazaoSocial("Teste PAF jACBrFramework");
        pRegistroA.getRegistroA1().setUf("MG");
        
        for (int i = 0; i < pQtdeA2; i++) {
            ACBrPAFRegistroA2 a2 = new ACBrPAFRegistroA2();
            a2.setCodigoTipoDocumento(CodigoTipoDocumento.CUPOM_FISCAL);
            a2.setData(Calendar.getInstance().getTime());
            a2.setMeioPagamento("Dinheiro");
            a2.setRegistroValido(true);
            a2.setValor(10);            
            pRegistroA.getRegistrosA2().add(a2);
        }
    }    
    
    private static void populaPafB(ACBrPAF_B pRegistroB, int pQtdeB2) {
        pRegistroB.getRegistroB1().setCnpj("77058992102725");
        pRegistroB.getRegistroB1().setInscEstadual("0659121090814");
        pRegistroB.getRegistroB1().setInscMunicipal("");
        pRegistroB.getRegistroB1().setRazaoSocial("Teste PAF jACBrFramework");
        pRegistroB.getRegistroB1().setUf("MG");
        
//        for (int i = 0; i < pQtdeB2; i++) {
//            ACBrPAFRegistroB2 b2 = new ACBrPAFRegistroB2();
//            b2.setBico("1");
//            b2.setBomba("Bomba");
//            b2.setCnpjEmpresa("77058992102725");
//            b2.setCpfTecnico("12312312387");
//            b2.setData(Calendar.getInstance().getTime());
//            b2.setEncerranteAntes(10);
//            b2.setEncerranteApos(20);
//            b2.setHora(Calendar.getInstance().getTime());
//            b2.setMotivo("Teste Registro B");
//            b2.setNumLacreAntes("3");
//            b2.setNumLacreApos("90");
//            b2.setRegistroValido(true);
//            
//            pRegistroB.getRegistrosB2().add(b2);
//        }
    }
    
    private static void populaPafC(ACBrPAF_C pRegistroC, int pQtdeC2) {
        pRegistroC.getRegistroC1().setCnpj("77058992102725");
        pRegistroC.getRegistroC1().setInscEstadual("0659121090814");
        pRegistroC.getRegistroC1().setInscMunicipal("");
        pRegistroC.getRegistroC1().setRazaoSocial("Teste PAF jACBrFramework");
        pRegistroC.getRegistroC1().setUf("MG");
        for (int i = 0; i < pQtdeC2; i++) {
            ACBrPAFRegistroC2 c2 = new ACBrPAFRegistroC2();
            c2.setBico("1");
            c2.setBomba("Bomba");
            c2.setCombustivel("800");
            c2.setCoo(9);
            c2.setData(Calendar.getInstance().getTime());
            c2.setDataAbastecimento(Calendar.getInstance().getTime());
            c2.setEncerrantaFinal(999);
            c2.setEncerranteInicial(333);
            c2.setHora(Calendar.getInstance().getTime());
            c2.setHoraAbastecimento(Calendar.getInstance().getTime());
            c2.setIdAbastecimento("ID");
            c2.setNumNotaFiscal(1212);
            c2.setNumSerieEcf("0001");
            c2.setRegistroValido(true);
            c2.setStatusAbastecimento("A");
            c2.setTanque("Tanque");
            c2.setVolume(9898);
            pRegistroC.getRegistrosC2().add(c2);
        }
    }
    
    private static void populaPafD(ACBrPAF_D pRegistroD, int pQtdeD2, int pQtdeD3, int pQtdeD4) {
        pRegistroD.getRegistroD1().setCnpj("77058992102725");
        pRegistroD.getRegistroD1().setInscEstadual("0659121090814");
        pRegistroD.getRegistroD1().setInscMunicipal("");
        pRegistroD.getRegistroD1().setRazaoSocial("Teste PAF jACBrFramework");
        pRegistroD.getRegistroD1().setUf("MG");
        for (int i = 0; i < pQtdeD2; i++) {
            ACBrPAFRegistroD2 d2 = new ACBrPAFRegistroD2();
            d2.setCoo("4");
            d2.setCooDocFiscalVenda("5");
            d2.setCpfCnpj("12312312387");
            d2.setDataDav(Calendar.getInstance().getTime());
            d2.setMarcaEcf("Marca");
            d2.setMfAdicional("S");
            d2.setModeloEcf("Modelo");
            d2.setNomeCliente("ACBr");
            d2.setNumDav("8");
            d2.setNumFabricacao("Num. Fab.");
            d2.setNumeroEcf("0001");
            d2.setRegistroValido(true);
            d2.setTipoEcf("Tipo");
            d2.setTituloDav("Titulo");
            d2.setValorTotalDav(9.90);
            
            for (int j = 0; j < pQtdeD3; j++) { 
                ACBrPAFRegistroD3 d3 = new ACBrPAFRegistroD3();
                d3.setAliquota(7.0);
                d3.setCasasDecimaisQtd(2);
                d3.setCasasDecimaisVlrUn(3);
                d3.setCodItem(String.valueOf(j));
                d3.setDataInclucao(Calendar.getInstance().getTime());
                d3.setDescrItem("Descricao Item " + j);
                d3.setIndCancelamento("N");
                d3.setNumItem(1);
                d3.setQtdeItem(8);
                d3.setRegistroValido(true);
                d3.setSituacaoTributaria("000");
                d3.setUnidItem("UN");
                d3.setValorAcrescimo(4);
                d3.setValorDesconto(3.5);
                d3.setValorItem(1.5);
                d3.setValorTotal(12);
                d2.getRegistrosD3().add(d3);
            }
            
            for (int j = 0; j < pQtdeD4; j++) { 
                ACBrPAFRegistroD4 d4 = new ACBrPAFRegistroD4();
                d4.setAcrescimoSobreItem(1);
                d4.setAliquota(7.00);
                d4.setCasasDecimaisQtd(2);
                d4.setCasasDecimaisVlrUn(3);
                d4.setCodigoProdutoServico("0001");
                d4.setDataAlteracao(Calendar.getInstance().getTime());
                d4.setDescontoSobreItem(0.5);
                d4.setDescricao("Descricao Item " + j);
                d4.setHoraAlteracao(Calendar.getInstance().getTime());
                d4.setIndicadorCancelamento("N");
                d4.setNumeroDAV("8");
                d4.setQuantidade(1);
                d4.setSituacaoTributaria("000");
                d4.setTipoAlteracao("");
                d4.setUnidade("UN");
                d4.setValorTotalLiquido(8.5);
                d4.setValorUnitario(1.5);
                d2.getRegistrosD4().add(d4);
            }
            
            pRegistroD.getRegistrosD2().add(d2);
        }
    }
    
    private static void populaPafE(ACBrPAF_E pRegistroE, int pQtdeE2) {
        pRegistroE.getRegistroE1().setCnpj("77058992102725");
        pRegistroE.getRegistroE1().setDataEstoque(Calendar.getInstance().getTime());
        pRegistroE.getRegistroE1().setInclusaoExclusao(false);
        pRegistroE.getRegistroE1().setInscEstadual("0659121090814");
        pRegistroE.getRegistroE1().setInscMunicipal("");
        pRegistroE.getRegistroE1().setMarcaEcf("Bema");
        pRegistroE.getRegistroE1().setMfAdicional("AD");
        pRegistroE.getRegistroE1().setModeloEcf("4000");
        pRegistroE.getRegistroE1().setNumFabricacao("FAB");
        pRegistroE.getRegistroE1().setRazaoSocial("Teste PAF jACBrFramework");
        pRegistroE.getRegistroE1().setRegistroValido(true);
        pRegistroE.getRegistroE1().setTipoEcf("TH");
        pRegistroE.getRegistroE1().setUf("MG");
        
        pRegistroE.getRegistroE3().setDataEstoque(Calendar.getInstance().getTime());
        pRegistroE.getRegistroE3().setHoraEstoque(Calendar.getInstance().getTime());
        pRegistroE.getRegistroE3().setMarcaEcf("Bema");
        pRegistroE.getRegistroE3().setMfAdicional("AD");
        pRegistroE.getRegistroE3().setModeloEcf("4000");
        pRegistroE.getRegistroE3().setNumFabricacao("FAB");
        pRegistroE.getRegistroE3().setTipoEcf("TH");
        
        for (int i = 0; i < pQtdeE2; i++) {
            ACBrPAFRegistroE2 e2 = new ACBrPAFRegistroE2();
            e2.setCodMercadoria("0001");
            e2.setDescMercadoria("Descrição Item " + i);
            e2.setQtdeEstoque(8);
            e2.setRegistroValido(true);
            e2.setUnidadeMedida("UN");
            pRegistroE.getRegistrosE2().add(e2);
        }
    } 
    
    private static void populaPafH(ACBrPAF_H pRegistroH, int pQtdeH2) {
        pRegistroH.getRegistroH1().setCnpj("77058992102725");
        pRegistroH.getRegistroH1().setDataEstoque(Calendar.getInstance().getTime());
        pRegistroH.getRegistroH1().setInclusaoExclusao(false);
        pRegistroH.getRegistroH1().setInscEstadual("0659121090814");
        pRegistroH.getRegistroH1().setInscMunicipal("");
        pRegistroH.getRegistroH1().setMarcaEcf("Bema");
        pRegistroH.getRegistroH1().setMfAdicional("AD");
        pRegistroH.getRegistroH1().setModeloEcf("4000");
        pRegistroH.getRegistroH1().setNumFabricacao("FAB");
        pRegistroH.getRegistroH1().setRazaoSocial("Teste PAF jACBrFramework");
        pRegistroH.getRegistroH1().setRegistroValido(true);
        pRegistroH.getRegistroH1().setTipoEcf("TH");
        pRegistroH.getRegistroH1().setUf("MG");
        
        for (int i = 0; i < pQtdeH2; i++) {
            ACBrPAFRegistroH2 h2 = new ACBrPAFRegistroH2();
            h2.setCcf(i + 1);
            h2.setCnpjCredenciadoraCartao("34527888000137");
            h2.setCoo(i + 2);
            h2.setCpfAdquirente("12312312387");
            h2.setDataTroco(Calendar.getInstance().getTime());
            h2.setNumTitulo("012345");
            h2.setRegistroValido(true);
            h2.setVlrTroco(10);
            pRegistroH.getRegistrosH2().add(h2);
        }
    }
     
    private static void populaPafN(ACBrPAF_N pRegistroN, int pQtdeN3) {
        pRegistroN.getRegistroN1().setCnpj("77058992102725");
        pRegistroN.getRegistroN1().setInscEstadual("0659121090814");
        pRegistroN.getRegistroN1().setInscMunicipal("");
        pRegistroN.getRegistroN1().setRazaoSocial("Teste PAF jACBrFramework");
        pRegistroN.getRegistroN1().setUf("MG");
        
        pRegistroN.getRegistroN2().setLaudo("LAUDO");
        pRegistroN.getRegistroN2().setNome("Nome");
        pRegistroN.getRegistroN2().setVersao("Versao");
        
        for (int i = 0; i < pQtdeN3; i++) {
            ACBrPAFRegistroN3 n3 = new ACBrPAFRegistroN3();
            n3.setMd5("12121-MD5");
            n3.setNomeArquivo("ARQUIVO");
            pRegistroN.getRegistrosN3().add(n3);
        }
    }     
    
    private static void populaPafP(ACBrPAF_P pRegistroP, int pQtdeP2) {
        pRegistroP.getRegistroP1().setCnpj("77058992102725");
        pRegistroP.getRegistroP1().setInscEstadual("0659121090814");
        pRegistroP.getRegistroP1().setInscMunicipal("");
        pRegistroP.getRegistroP1().setRazaoSocial("Teste PAF jACBrFramework");
        pRegistroP.getRegistroP1().setUf("MG");
        
        for (int i = 0; i < pQtdeP2; i++) {
            ACBrPAFRegistroP2 p2 = new ACBrPAFRegistroP2();
            p2.setAliquota(7);
            p2.setCodMercadoriaServico("001");
            p2.setDescMercadoriaServico("Descrição Item " + i);
            p2.setIat("A");
            p2.setIppt("T");
            p2.setRegistroValido(true);
            p2.setSt("000");
            p2.setUnidadeMedida("UN");
            p2.setValorUnitario(10);
            pRegistroP.getRegistrosP2().add(p2);
        }
    }       

    private static void populaPafR(ACBrPAF_R pRegistroR, int pQtdeR1, int pQtdeR2,
            int pQtdeR3, int pQtdeR4, int pQtdeR5, int pQtdeR6, int pQtdeR7) {
        for (int i = 0; i < pQtdeR1; i++) {
            ACBrPAFRegistroR1 r1 = new ACBrPAFRegistroR1();
            r1.setCnpj("77058992102725");
            r1.setCnpjSh("34527888000137");
            r1.setCodigoMd5("MD5");
            r1.setDataFim(Calendar.getInstance().getTime());
            r1.setDataInicial(Calendar.getInstance().getTime());
            r1.setDtInstalacaoSb(Calendar.getInstance().getTime());
            r1.setHoraInstalacaoSb(Calendar.getInstance().getTime());
            r1.setInclusaoExclusao(true);
            r1.setInscEstadual("0659121090814");
            r1.setInscEstadualSh("0659121090814");
            r1.setInscMunicipalSh("");
            r1.setMarcaEcf("Bema");
            r1.setMfAdicional("D");
            r1.setModeloEcf("MP 4000");
            r1.setNomePaf("Nome PAF");
            r1.setNomeSh("ACBr");
            r1.setNumFabricacao("Num Fab.");
            r1.setNumSeqEcf(1);
            r1.setRegistroValido(true);
            r1.setTipoEcf("TH");
            r1.setVersaoPaf("1.0");
            r1.setVersaoRequisitosPaf("2.0");
            r1.setVersaoSb("4.0");
            
            for (int j = 0; j < pQtdeR2; j++) {
                ACBrPAFRegistroR2 r2 = new ACBrPAFRegistroR2();
                r2.setCoo(i);
                r2.setCro(j);
                r2.setCrz(i + j);
                r2.setDataEmissao(Calendar.getInstance().getTime());
                r2.setDataMovimento(Calendar.getInstance().getTime());
                r2.setHoraEmissao(Calendar.getInstance().getTime());
                r2.setNumeroUsuario(1);
                r2.setParametroEcf("P");
                r2.setRegistroValido(true);
                r2.setVendaBrutaDiaria(100);
                
                for (int k = 0; k < pQtdeR3; k++) {
                    ACBrPAFRegistroR3 r3 = new ACBrPAFRegistroR3();    
                    r3.setCodTotalzadorParcial("DIN");
                    r3.setRegistroValido(true);
                    r3.setValorAcumulado(100);                    
                    r2.getRegistrosR3().add(r3);
                }
                
                r1.getRegistrosR2().add(r2);
            }
            
            for (int j = 0; j < pQtdeR4; j++) {
                ACBrPAFRegistroR4 r4 = new ACBrPAFRegistroR4();
                r4.setAcrescimoSobreSubtotal(0);
                r4.setCnpjCpf("77058992102725");
                r4.setCoo(j);
                r4.setDataInicioEmissao(Calendar.getInstance().getTime());
                r4.setDescontoSobreSubtotal(1);
                r4.setIndCancelamento("N");
                r4.setNomeCliente("Cliente " + j);
                r4.setNumContador(j);
                r4.setNumeroUsuario(i);
                r4.setOrdemAplicacaoDescAcres("D");
                r4.setRegistroValido(true);
                r4.setSubTotalDocumento(8);
                r4.setTipoAcrescimo("P");
                r4.setTipoDesconto("P");
                r4.setValorCancelamento(10);
                r4.setValorTotalLiquido(80);
                
                for (int k = 0; k < pQtdeR5; k++) {
                    ACBrPAFRegistroR5 r5 = new ACBrPAFRegistroR5();    
                    r5.setAcrescimoItem(i);
                    r5.setCodItem(String.valueOf(k));
                    r5.setCodTotalizadorParcial("DIN");
                    r5.setDescontoItem(j);
                    r5.setDescricaoItem("Item " + k);
                    r5.setIat("T");
                    r5.setIndCancelamento("N");
                    r5.setIppt("P");
                    r5.setNumCasasDecimaisEmQtde(2);
                    r5.setNumCasasDecimaisEmValor(3);
                    r5.setNumContador(i + j + k);
                    r5.setNumItem(k);
                    r5.setQtdeCancelada(0);
                    r5.setQtdeItem(8);
                    r5.setRegistroValido(true);
                    r5.setUnidadeMedida("UN");
                    r5.setValorCancelamento(4);
                    r5.setValorCancelamentoAcresc(50);
                    r5.setValorTotalLiquidoItem(46);
                    r5.setValorUnitario(10);
                    r4.getRegistrosR5().add(r5);
                }
                
                for (int k = 0; k < pQtdeR7; k++) {
                    ACBrPAFRegistroR7 r7 = new ACBrPAFRegistroR7();    
                    r7.setCcf(k);
                    r7.setGnf(j);
                    r7.setIndEstorno("N");
                    r7.setMeioPagamento("Dinheiro");
                    r7.setRegistroValido(true);
                    r7.setValorEstorno(0);
                    r7.setValorPago(10);
                    r4.getRegistrosR7().add(r7);
                }
                r1.getRegistrosR4().add(r4);
            }            
            
            for (int j = 0; j < pQtdeR6; j++) {
                ACBrPAFRegistroR6 r6 = new ACBrPAFRegistroR6();
                r6.setCdc(j);
                r6.setCoo(i);
                r6.setDataFinalEmissao(Calendar.getInstance().getTime());
                r6.setDenominacao("Teste");
                r6.setGnf(i + j);
                r6.setGrg(j * i);
                r6.setHoraFinalEmissao(Calendar.getInstance().getTime());
                r6.setNumeroUsuario(i);
                r6.setRegistroValido(true);
                
               for (int k = 0; k < pQtdeR7; k++) {
                    ACBrPAFRegistroR7 r7 = new ACBrPAFRegistroR7();    
                    r7.setCcf(k);
                    r7.setGnf(j);
                    r7.setIndEstorno("N");
                    r7.setMeioPagamento("Dinheiro");
                    r7.setRegistroValido(true);
                    r7.setValorEstorno(0);
                    r7.setValorPago(10);
                    r6.getRegistrosR7().add(r7);
                }                
                r1.getRegistrosR6().add(r6);
            }
            pRegistroR.getRegistrosR1().add(r1);
        }
    }       

    private static void populaPafT(ACBrPAF_T pRegistroT, int pQtdeT2) {
        pRegistroT.getRegistroT1().setCnpj("77058992102725");
        pRegistroT.getRegistroT1().setInscEstadual("0659121090814");
        pRegistroT.getRegistroT1().setInscMunicipal("");
        pRegistroT.getRegistroT1().setRazaoSocial("Teste PAF jACBrFramework");
        pRegistroT.getRegistroT1().setUf("MG");
        
        for (int i = 0; i < pQtdeT2; i++) {
            ACBrPAFRegistroT2 t2 = new ACBrPAFRegistroT2();
            t2.setAliquota(7);
            t2.setCfop("2102");
            t2.setCrz(i);
            t2.setDataMovimento(Calendar.getInstance().getTime());
            t2.setNumEcf("0001");
            t2.setNumeroBilheteFinal(10);
            t2.setNumeroBilheteInicial(1);
            t2.setRegistroValido(true);
            t2.setSerie("001");
            t2.setTipoDocumento("Dinheiro");
            t2.setValorBaseCalculo(100);
            t2.setValorContabil(80);
            t2.setValorImposto(70);
            t2.setValorIsentas(5);
            t2.setValorOutras(4);
            pRegistroT.getRegistrosT2().add(t2);
        }
    } 
    
    private static void populaPafTITP(ACBrPAF_TITP pRegistro, int pQtdeMerc, int pQtdeIns) {
        pRegistro.setData(Calendar.getInstance().getTime());
        pRegistro.setTitulo("Titulo");

        for (int i = 0; i < pQtdeMerc; i++) {
            ACBrPAFRegistroMercadoria m = new ACBrPAFRegistroMercadoria();
            m.setAliquota(7);
            m.setCodigo(String.valueOf(i));
            m.setDescricao("Mercadoria " + i);
            m.setEan("69001000");
            m.setQuantidade(8);
            m.setUnidade("UN");
            m.setVlrUnitario(1);
            
            for (int j = 0; j < pQtdeIns; j++) {
                ACBrPAFRegistroInsumo s = new ACBrPAFRegistroInsumo();
                s.setAliquota(7);
                s.setCodigo(String.valueOf(i));
                s.setDescricao("Insumo " + i);
                s.setEan("69001000");
                s.setQuantidade(8);
                s.setUnidade("UN");
                s.setVlrUnitario(1);
                m.getInsumos().add(s);
            }
            pRegistro.getMercadorias().add(m);
        }
    }
    
    private static void populaPafU(ACBrPAF_U pRegistroU) {
        pRegistroU.getRegistroU1().setCnpj("77058992102725");
        pRegistroU.getRegistroU1().setInscEstadual("0659121090814");
        pRegistroU.getRegistroU1().setInscMunicipal("");
        pRegistroU.getRegistroU1().setRazaoSocial("Teste PAF jACBrFramework");
        pRegistroU.getRegistroU1().setUf("MG");
    }  
   
}