package jACBrFramework.Test;

import jACBrFramework.ACBrEventListener;
import jACBrFramework.lcb.ACBrLCB;
import jACBrFramework.lcb.LeCodigoEventObject;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 * Testes basicos para leitura serial.
 * 
 * @author Jose Mauro
 * @version Criado em: 26/05/2014 16:37:35, revisao: $Id$
 */
public class ProgramTestLCB {

    public static void main(String[] args) {
        try {
            final ACBrLCB lcb = new ACBrLCB();
            System.out.println("Configurando a PORTA");
            lcb.setPorta("COM2");
            
            System.out.println("Ativando o componente.");
            lcb.ativar();
            lcb.addOnLeCodigo(new ACBrEventListener<LeCodigoEventObject>() {
                @Override
                public void notification(LeCodigoEventObject e) {
                    try {
                        System.out.print("Recuperando o último código: ");
                        System.out.println(lcb.getUltimoCodigo());
                    } catch (Exception ex) {
                        Logger.getLogger(ProgramTestAac.class.getName()).log(Level.SEVERE, null, ex);
                    }        
                }
            });
            
            System.out.print("Pressione alguma tecla para finalizar a leitura.");
            System.in.read();
            
            System.out.println("Desativando o componente.");
            lcb.desativar();            
        } catch (Exception ex) {
            Logger.getLogger(ProgramTestAac.class.getName()).log(Level.SEVERE, null, ex);
        }        
    }
    
}