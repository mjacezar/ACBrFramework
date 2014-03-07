package jACBrFramework.Test;

import jACBrFramework.sped.ACBrSpedFiscal;
import jACBrFramework.sped.IndicadorMovimento;
import jACBrFramework.sped.MotivoInventario;
import jACBrFramework.sped.PosseItem;
import jACBrFramework.sped.blocoH.RegistroH005;
import jACBrFramework.sped.blocoH.RegistroH010;
import jACBrFramework.sped.blocoH.RegistroH020;
import java.nio.charset.Charset;
import java.util.Date;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Jose Mauro
 * @version Criado em: 31/01/2014 12:53:45, revisao: $Id$
 */
public class ProgramTestSpedFiscal {

    public static void main(String[] args) {
        try {
            ACBrSpedFiscal sped = new ACBrSpedFiscal(Charset.forName("cp1252"));
            sped.setDelimitador("|");
            sped.setPath("\\");
            sped.setArquivo("sped_teste.txt");
            sped.getBloco0().setDataInicial(new Date());
            sped.getBloco0().setDataFinal(new Date());
            sped.getBloco0().getRegistro0000().setCNPJ("58565051000140");
            sped.getBloco0().getRegistro0000().setNOME("Empresa Teste");
            sped.getBlocoH().setDataInicial(new Date());
            sped.getBlocoH().setDataFinal(new Date());
            sped.getBlocoH().getRegistroH001().setIND_MOV(IndicadorMovimento.ComDados);
            RegistroH005 regH005 = new RegistroH005();
            regH005.setDT_INV(new Date());
            regH005.setMOT_INV(MotivoInventario.FinalPeriodo);
            regH005.setVL_INV(10);           
            sped.getBlocoH().getRegistroH001().getRegistroH005().add(regH005);
            
            RegistroH010 regH010 = new RegistroH010();
            regH010.setCOD_CTA("1.1");
            regH010.setCOD_ITEM("1");
            regH010.setCOD_PART("P");
            regH010.setIND_PROP(PosseItem.Informante);
            regH010.setQTD(8);
            regH010.setTXT_COMPL("Texto Complementar");
            regH010.setUNID("UN");
            regH010.setVL_ITEM(3);
            regH010.setVL_UNIT(5.5);
            regH005.getRegistroH010().add(regH010);
            
            RegistroH020 regH020 = new RegistroH020();
            regH020.setBC_ICMS(100);
            regH020.setCST_ICMS("00");
            regH020.setVL_ICMS(7);
            regH010.getRegistroH020().add(regH020);

            sped.saveFileTXT();
        } catch (Exception ex) {
            Logger.getLogger(ProgramTestAac.class.getName()).log(Level.SEVERE, null, ex);
        }        
    }
}