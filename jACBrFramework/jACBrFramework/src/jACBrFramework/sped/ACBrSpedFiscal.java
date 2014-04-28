package jACBrFramework.sped;

import com.sun.jna.Structure;
import com.sun.jna.ptr.DoubleByReference;
import com.sun.jna.ptr.IntByReference;
import jACBrFramework.ACBrClass;
import jACBrFramework.ACBrEventListener;
import jACBrFramework.ACBrException;
import jACBrFramework.OleDate;
import jACBrFramework.interop.ACBrSpedFiscalInterop;
import jACBrFramework.sped.bloco0.*;
import jACBrFramework.sped.bloco1.*;
import jACBrFramework.sped.bloco9.*;
import jACBrFramework.sped.blocoC.*;
import jACBrFramework.sped.blocoD.*;
import jACBrFramework.sped.blocoE.*;
import jACBrFramework.sped.blocoG.*;
import jACBrFramework.sped.blocoH.*;
import java.lang.reflect.Array;
import java.lang.reflect.Field;
import java.nio.ByteBuffer;
import java.nio.charset.Charset;
import java.text.MessageFormat;
import java.util.Date;

/**
 * Classe responsavel pela manipulacao e geracao do Sped Fiscal.
 * 
 * @author Jose Mauro
 * @version Criado em: 24/01/2014 16:41:56, revisao: $Id$
 */
public final class ACBrSpedFiscal extends ACBrClass {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * @see Bloco0
     */
    private Bloco0 bloco0;
    /**
     * @see Bloco1
     */
    private Bloco1 bloco1;
    /**
     * @see Bloco9
     */
    private Bloco9 bloco9;
    /**
     * @see BlocoC
     */
    private BlocoC blocoC;
    /**
     * @see BlocoD
     */
    private BlocoD blocoD;
    /**
     * @see BlocoE
     */
    private BlocoE blocoE;
    /**
     * @see BlocoG
     */
    private BlocoG blocoG;
    /**
     * @see BlocoH
     */
    private BlocoH blocoH;
    // </editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    /**
     * Construtor padrao.
     *
     * @throws ACBrException excecao acionada ao construir o objeto.
     */
    public ACBrSpedFiscal() throws ACBrException {
    }
    
    /**
     * Cria um novo objeto com base no charset recebido.
     * 
     * @param pCharset charset utilizado na conversao para geracao do sintegra.
     */
    public ACBrSpedFiscal(Charset pCharset) throws ACBrException {
        this();
        setCustomCharset(pCharset);
    }    
    // </editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Override Methods">
    /**
     * Realiza a inicializacao da comunicacao com a acbr.
     *
     * @throws ACBrException excecao acionada ao inicializar o componente.
     */
    @Override
    protected void onInitialize() throws ACBrException {
        IntByReference handle = new IntByReference();
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_Create(handle);
        checkResult(ret);
        setHandle(handle.getValue());
        createBlocos();
    }

    /**
     * Finaliza a comunicacao com a acbr.
     *
     * @throws ACBrException excecao acionada ao finalizar a comunicacao.
     */
    @Override
    protected void onFinalize() throws ACBrException {
        if (getHandle() != 0) {
            int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_Destroy(getHandle());
            checkResult(ret);
            setHandle(0);
        }
    }

    /**
     * Responsavel pela verificacao dos resultados a cada operacao.
     *
     * @param pResult resultado da operacao.
     * @throws ACBrException mensagem de erro caso nao tenha havido
     * processamento com sucesso.
     */
    @Override
    public void checkResult(int pResult) throws ACBrException {
        switch (pResult) {
            case -1: {
                String lMessage;
                final int LEN = 1024;
                ByteBuffer buffer = ByteBuffer.allocate(LEN);
                int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_GetUltimoErro(getHandle(), buffer, LEN);

                lMessage = fromUTF8(buffer, ret);
                throw new ACBrException(lMessage);
            }
            case -2: {
                throw new ACBrException("ACBr Sped Fiscal não inicializado.");
            }
        }
    }    
    // </editor-fold>       
    //<editor-fold defaultstate="collapsed" desc="Components Methods">    
    /**
     * Recupera as informacoes do modulo.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getAbout() throws ACBrException {
        ByteBuffer lAbout = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_GetAbout(getHandle(), lAbout, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lAbout, ret);
    }
    
    /**
     * Seta o arquivo para exportacao.
     * 
     * @param pArquivo arquivo para geracao.
     * @throws ACBrException 
     */
    public void setArquivo(String pArquivo) throws ACBrException {
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_SetArquivo(getHandle(), toUTF8(pArquivo));
        checkResult(ret);
    }
    
    /**
     * Recupera o nome do arquivo associado a geracao.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getArquivo() throws ACBrException {
        ByteBuffer lArquivo = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_GetArquivo(getHandle(), lArquivo, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lArquivo, ret);
    }
        
    /**
     * Seta a mascara para geracao do arquivo.
     * 
     * @param pCurMascara mascara associada ao arquivo.
     * @throws ACBrException 
     */
    public void setCurMascara(String pCurMascara) throws ACBrException {
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_SetCurMascara(getHandle(), toUTF8(pCurMascara));
        checkResult(ret);
    }

    /**
     * Recupera a mascara associada a geracao do arquivo.
     * 
     * @return mascara associada ao arquivo.
     * @throws ACBrException 
     */
    public String getCurMascara() throws ACBrException {
        ByteBuffer lMascara = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_GetCurMascara(getHandle(), lMascara, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lMascara, ret);
    }
    
    /**
     * Seta o caminho do arquivo para exportacao.
     * 
     * @param pPath caminho do arquivo para geracao.
     * @throws ACBrException 
     */
    public void setPath(String pPath) throws ACBrException {
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_SetPath(getHandle(), toUTF8(pPath));
        checkResult(ret);
    }
    
    /**
     * Recupera o caminho do arquivo para exportacao.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getPath() throws ACBrException {
        ByteBuffer lPath = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_GetPath(getHandle(), lPath, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lPath, ret);
    } 
    
    /**
     * Seta o delimitador do arquivo.
     * 
     * @param pDelimitador delimitador associado ao arquivo.
     * @throws ACBrException 
     */
    public void setDelimitador(String pDelimitador) throws ACBrException {
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_SetDelimitador(getHandle(), toUTF8(pDelimitador));
        checkResult(ret);
    }

    /**
     * Recupera o delimitador de arquivo.
     * 
     * @return delimitador de arquivo.
     * @throws ACBrException 
     */
    public String getDelimitador() throws ACBrException {
        ByteBuffer lDelimitador = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_GetDelimitador(getHandle(), lDelimitador, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lDelimitador, ret);
    }    
    
    /**
     * Seta o numero de linhas do buffer.
     * 
     * @param pLinhasBuffer numero de linhas do buffer.
     * @throws ACBrException 
     */
    public void setLinhasBuffer(int pLinhasBuffer) throws ACBrException {
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_SetLinhasBuffer(getHandle(), pLinhasBuffer);
        checkResult(ret);
    }
    
    /**
     * Recupera o numero de linhas do buffer.
     * 
     * @return numero de linha do buffer.
     * @throws ACBrException 
     */
    public int getLinhasBuffer() throws ACBrException {
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_GetLinhasBuffer(getHandle());
        checkResult(ret);   
        return ret;
    }  
    
    /**
     * Indica que as string sofrerao trim.
     * 
     * @param pTrimString indica que o trim deve ser aplicado nas strings.
     * @throws ACBrException 
     */
    public void setTrimString(boolean pTrimString) throws ACBrException {
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_SetTrimString(getHandle(), pTrimString);
        checkResult(ret);
    }

    /**
     * Verifica se as strings do arquivos sofrerao trim.
     * 
     * @return indica se as string sofrerao trim.
     * @throws ACBrException 
     */
    public boolean isTrimString() throws ACBrException {
        return ACBrSpedFiscalInterop.INSTANCE.SPDF_GetTrimString(getHandle()) != 0;
    }    
    
    /**
     * Seta a data inicial da geracao do arquivo.
     * 
     * @param pDataInicial data inicial do periodo de apuracao.
     * @throws ACBrException 
     */
    public void setDataInicial(Date pDataInicial) throws ACBrException {     
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_SetDT_INI(getHandle(), OleDate.toOADate(pDataInicial));
        checkResult(ret);
    }  
    
    /**
     * Recupera a data inicial de apuracao.
     * 
     * @return data inicial de apuracao.
     * @throws ACBrException 
     */
    public Date getDataInicial() throws ACBrException {
        DoubleByReference lData = new DoubleByReference();
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_GetDT_INI(getHandle(), lData);
        checkResult(ret);   
        return OleDate.fromOADate(lData.getValue());
    }   
    
    /**
     * Seta a data final da geracao do arquivo.
     * 
     * @param pDataFinal data final do periodo de apuracao.
     * @throws ACBrException 
     */
    public void setDataFinal(Date pDataFinal) throws ACBrException {     
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_SetDT_FIN(getHandle(), OleDate.toOADate(pDataFinal));
        checkResult(ret);
    }  
    
    /**
     * Recupera a data final de apuracao.
     * 
     * @return data final de apuracao.
     * @throws ACBrException 
     */
    public Date getDataFinal() throws ACBrException {
        DoubleByReference lData = new DoubleByReference();
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_GetDT_FIN(getHandle(), lData);
        checkResult(ret);   
        return OleDate.fromOADate(lData.getValue());
    }   
    
    /**
     * Realiza o salvamento do arquivo do Sped Fiscal.
     * 
     * @throws ACBrException 
     */
    public void saveFileTXT() throws ACBrException {
        sendBlocos();

        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_SaveFileTXT(getHandle());
        checkResult(ret);

        createBlocos();
    }  
    
    /**
     * Cria os blocos de envio ao ACBr.
     */
    private void createBlocos() {
        bloco0 = new Bloco0(this);
        bloco1 = new Bloco1(this);
        bloco9 = new Bloco9(this);
        blocoC = new BlocoC(this);
        blocoD = new BlocoD(this);
        blocoE = new BlocoE(this);
        blocoG = new BlocoG(this);
        blocoH = new BlocoH(this);
    }    
    
    /**
     * Realiza o envio dos blocos para o ACBr.
     * 
     * @throws ACBrException
     */
    private void sendBlocos() throws ACBrException {
        sendBloco0();
        sendBloco1();
        sendBloco9();
        sendBlocoC();
        sendBlocoD();
        sendBlocoE();
        sendBlocoG();
        sendBlocoH();        
    }
    
    //<editor-fold defaultstate="collapsed" desc="Bloco 0"> 
    private void sendBloco0() throws ACBrException {
        sendRegistro0000();
        sendRegistro0001();
    }
    
    private void sendRegistro0000() throws ACBrException {
        sendRecord(bloco0.getRegistro0000(), new ACBrSpedFiscalInterop.Bloco0Registro0000(), "SPDF_Bloco_0_Registro0000New");
    }

    private void sendRegistro0001() throws ACBrException {
        sendRecord(bloco0.getRegistro0001(), new ACBrSpedFiscalInterop.Bloco0Registro0001(), "SPDF_Bloco_0_Registro0001New");
        
        sendRegistro0005();
        
        for (Registro0015 reg0015 : bloco0.getRegistro0001().getRegistro0015()) {
            sendRegistro0015(reg0015);
        }               

        sendRegistro0100();

        for (Registro0150 reg0150 : bloco0.getRegistro0001().getRegistro0150()) {
            sendRegistro0150(reg0150);
        }           
        
        for (Registro0190 reg0190 : bloco0.getRegistro0001().getRegistro0190()) {
            sendRegistro0190(reg0190);
        }             

        for (Registro0200 reg0200 : bloco0.getRegistro0001().getRegistro0200()) {
            sendRegistro0200(reg0200);
        }    

        for (Registro0300 reg0300 : bloco0.getRegistro0001().getRegistro0300()) {
            sendRegistro0300(reg0300);
        } 
        
        for (Registro0400 reg0400 : bloco0.getRegistro0001().getRegistro0400()) {
            sendRegistro0400(reg0400);
        } 

        for (Registro0450 reg0450 : bloco0.getRegistro0001().getRegistro0450()) {
            sendRegistro0450(reg0450);
        } 
        
        for (Registro0460 reg0460 : bloco0.getRegistro0001().getRegistro0460()) {
            sendRegistro0460(reg0460);
        } 

        for (Registro0500 reg0500 : bloco0.getRegistro0001().getRegistro0500()) {
            sendRegistro0500(reg0500);
        } 

        for (Registro0600 reg0600 : bloco0.getRegistro0001().getRegistro0600()) {
            sendRegistro0600(reg0600);
        } 
    }    
    
    private void sendRegistro0005() throws ACBrException {
        sendRecord(bloco0.getRegistro0001().getRegistro0005(), new ACBrSpedFiscalInterop.Bloco0Registro0005(), "SPDF_Bloco_0_Registro0005New");
    }    
    
    private void sendRegistro0015(Registro0015 pReg0015) throws ACBrException {
        sendRecord(pReg0015, new ACBrSpedFiscalInterop.Bloco0Registro0015(), "SPDF_Bloco_0_Registro0015New");
    }
     
    private void sendRegistro0100() throws ACBrException {
        sendRecord(bloco0.getRegistro0001().getRegistro0100(), new ACBrSpedFiscalInterop.Bloco0Registro0100(), "SPDF_Bloco_0_Registro0100New");
    }    
    
    private void sendRegistro0150(Registro0150 pReg0150) throws ACBrException {
        sendRecord(pReg0150, new ACBrSpedFiscalInterop.Bloco0Registro0150(), "SPDF_Bloco_0_Registro0150New");

        for (Registro0175 reg0175 : pReg0150.getRegistro0175()) {
            sendRegistro0175(reg0175);
        }
    }    
    
    private void sendRegistro0175(Registro0175 pReg0175) throws ACBrException {
        sendRecord(pReg0175, new ACBrSpedFiscalInterop.Bloco0Registro0175(), "SPDF_Bloco_0_Registro0175New");
    }    
    
    private void sendRegistro0190(Registro0190 pReg0190) throws ACBrException {
        sendRecord(pReg0190, new ACBrSpedFiscalInterop.Bloco0Registro0190(), "SPDF_Bloco_0_Registro0190New");
    }    
    
    private void sendRegistro0200(Registro0200 pReg0200) throws ACBrException {
        sendRecord(pReg0200, new ACBrSpedFiscalInterop.Bloco0Registro0200(), "SPDF_Bloco_0_Registro0200New");

        for (Registro0205 reg0205 : pReg0200.getRegistro0205()) {
            sendRegistro0205(reg0205);
        }

        for (Registro0206 reg0206 : pReg0200.getRegistro0206()) {
            sendRegistro0206(reg0206);
        }        

        for (Registro0220 reg0220 : pReg0200.getRegistro0220()) {
            sendRegistro0220(reg0220);
        }    
    }
        
    private void sendRegistro0205(Registro0205 pReg0205) throws ACBrException {
        sendRecord(pReg0205, new ACBrSpedFiscalInterop.Bloco0Registro0205(), "SPDF_Bloco_0_Registro0205New");
    }    
    
    private void sendRegistro0206(Registro0206 pReg0206) throws ACBrException {
        sendRecord(pReg0206, new ACBrSpedFiscalInterop.Bloco0Registro0206(), "SPDF_Bloco_0_Registro0206New");
    }    
    
    private void sendRegistro0220(Registro0220 pReg0220) throws ACBrException {
        sendRecord(pReg0220, new ACBrSpedFiscalInterop.Bloco0Registro0220(), "SPDF_Bloco_0_Registro0220New");
    }    
    
    private void sendRegistro0300(Registro0300 pReg0300) throws ACBrException {
        sendRecord(pReg0300, new ACBrSpedFiscalInterop.Bloco0Registro0300(), "SPDF_Bloco_0_Registro0300New");

        for (Registro0305 reg0305 : pReg0300.getRegistro0305()) {
            sendRegistro0305(reg0305);
        }
    }
    
    private void sendRegistro0305(Registro0305 pReg0305) throws ACBrException {
        sendRecord(pReg0305, new ACBrSpedFiscalInterop.Bloco0Registro0305(), "SPDF_Bloco_0_Registro0305New");
    }

    private void sendRegistro0400(Registro0400 pReg0400) throws ACBrException {
        sendRecord(pReg0400, new ACBrSpedFiscalInterop.Bloco0Registro0400(), "SPDF_Bloco_0_Registro0400New");
    }
    
    private void sendRegistro0450(Registro0450 pReg0450) throws ACBrException {
        sendRecord(pReg0450, new ACBrSpedFiscalInterop.Bloco0Registro0450(), "SPDF_Bloco_0_Registro0450New");
    }    
    
    private void sendRegistro0460(Registro0460 pReg0460) throws ACBrException {
        sendRecord(pReg0460, new ACBrSpedFiscalInterop.Bloco0Registro0460(), "SPDF_Bloco_0_Registro0460New");
    }    
    
    private void sendRegistro0500(Registro0500 pReg0500) throws ACBrException {
        sendRecord(pReg0500, new ACBrSpedFiscalInterop.Bloco0Registro0500(), "SPDF_Bloco_0_Registro0500New");
    }
        
    private void sendRegistro0600(Registro0600 pReg0600) throws ACBrException {
        sendRecord(pReg0600, new ACBrSpedFiscalInterop.Bloco0Registro0600(), "SPDF_Bloco_0_Registro0600New");
    } 
    // </editor-fold>  
    //<editor-fold defaultstate="collapsed" desc="Bloco 1"> 
    private void sendBloco1() throws ACBrException {
        sendRegistro1001();
    }    
    
    private void sendRegistro1001() throws ACBrException {
        sendRecord(bloco1.getRegistro1001(), new ACBrSpedFiscalInterop.Bloco1Registro1001(), "SPDF_Bloco_1_Registro1001New");

        for (Registro1010 reg1010 : bloco1.getRegistro1001().getRegistro1010()) {
            sendRegistro1010(reg1010);
        }     
        
        for (Registro1100 reg1100 : bloco1.getRegistro1001().getRegistro1100()) {
            sendRegistro1100(reg1100);
        }  

        for (Registro1200 reg1200 : bloco1.getRegistro1001().getRegistro1200()) {
            sendRegistro1200(reg1200);
        }  
        
        for (Registro1300 reg1300 : bloco1.getRegistro1001().getRegistro1300()) {
            sendRegistro1300(reg1300);
        }  

        for (Registro1350 reg1350 : bloco1.getRegistro1001().getRegistro1350()) {
            sendRegistro1350(reg1350);
        }  
        
        for (Registro1390 reg1390 : bloco1.getRegistro1001().getRegistro1390()) {
            sendRegistro1390(reg1390);
        }  

        for (Registro1400 reg1400 : bloco1.getRegistro1001().getRegistro1400()) {
            sendRegistro1400(reg1400);
        }  

        for (Registro1500 reg1500 : bloco1.getRegistro1001().getRegistro1500()) {
            sendRegistro1500(reg1500);
        }  

        for (Registro1600 reg1600 : bloco1.getRegistro1001().getRegistro1600()) {
            sendRegistro1600(reg1600);
        }  

        for (Registro1700 reg1700 : bloco1.getRegistro1001().getRegistro1700()) {
            sendRegistro1700(reg1700);
        }  

        for (Registro1800 reg1800 : bloco1.getRegistro1001().getRegistro1800()) {
            sendRegistro1800(reg1800);
        }  
    }
    
    private void sendRegistro1010(Registro1010 pReg1010) throws ACBrException {
        sendRecord(pReg1010, new ACBrSpedFiscalInterop.Bloco1Registro1010(), "SPDF_Bloco_1_Registro1010New");
    }    
    
    private void sendRegistro1100(Registro1100 pReg1100) throws ACBrException {
        sendRecord(pReg1100, new ACBrSpedFiscalInterop.Bloco1Registro1100(), "SPDF_Bloco_1_Registro1100New");

        for (Registro1105 reg1105 : pReg1100.getRegistro1105()) {
            sendRegistro1105(reg1105);
        }
    }
    
    private void sendRegistro1105(Registro1105 pReg1105) throws ACBrException {
        sendRecord(pReg1105, new ACBrSpedFiscalInterop.Bloco1Registro1105(), "SPDF_Bloco_1_Registro1105New");        

        for (Registro1110 reg1110 : pReg1105.getRegistro1110()) {
            sendRegistro1110(reg1110);
        }        
    }    
    
    private void sendRegistro1110(Registro1110 pReg1110) throws ACBrException {
        sendRecord(pReg1110, new ACBrSpedFiscalInterop.Bloco1Registro1110(), "SPDF_Bloco_1_Registro1110New");     
    }
    
    private void sendRegistro1200(Registro1200 pReg1200) throws ACBrException {
        sendRecord(pReg1200, new ACBrSpedFiscalInterop.Bloco1Registro1200(), "SPDF_Bloco_1_Registro1200New");

        for (Registro1210 reg1210 : pReg1200.getRegistro1210()) {
            sendRegistro1210(reg1210);
        }        
    }
    
    private void sendRegistro1210(Registro1210 pReg1210) throws ACBrException {
        sendRecord(pReg1210, new ACBrSpedFiscalInterop.Bloco1Registro1210(), "SPDF_Bloco_1_Registro1210New");
    }
    
    private void sendRegistro1300(Registro1300 pReg1300) throws ACBrException {
        sendRecord(pReg1300, new ACBrSpedFiscalInterop.Bloco1Registro1300(), "SPDF_Bloco_1_Registro1300New");

        for (Registro1310 reg1310 : pReg1300.getRegistro1310()) {
            sendRegistro1310(reg1310);
        } 
    }   
    
    private void sendRegistro1310(Registro1310 pReg1310) throws ACBrException {
        sendRecord(pReg1310, new ACBrSpedFiscalInterop.Bloco1Registro1310(), "SPDF_Bloco_1_Registro1310New");

        for (Registro1320 reg1320 : pReg1310.getRegistro1320()) {
            sendRegistro1320(reg1320);
        }        
    }    
    
    private void sendRegistro1320(Registro1320 pReg1320) throws ACBrException {
        sendRecord(pReg1320, new ACBrSpedFiscalInterop.Bloco1Registro1320(), "SPDF_Bloco_1_Registro1320New");
    }    
    
    private void sendRegistro1350(Registro1350 pReg1350) throws ACBrException {
        sendRecord(pReg1350, new ACBrSpedFiscalInterop.Bloco1Registro1350(), "SPDF_Bloco_1_Registro1350New");
        
        for (Registro1360 reg1360 : pReg1350.getRegistro1360()) {
            sendRegistro1360(reg1360);
        }         

        for (Registro1370 reg1370 : pReg1350.getRegistro1370()) {
            sendRegistro1370(reg1370);
        }         
    }
    
    private void sendRegistro1360(Registro1360 pReg1360) throws ACBrException {
        sendRecord(pReg1360, new ACBrSpedFiscalInterop.Bloco1Registro1360(), "SPDF_Bloco_1_Registro1360New");
    }  
    
    private void sendRegistro1370(Registro1370 pReg1370) throws ACBrException {
        sendRecord(pReg1370, new ACBrSpedFiscalInterop.Bloco1Registro1370(), "SPDF_Bloco_1_Registro1370New");
    }
    
    private void sendRegistro1390(Registro1390 pReg1390) throws ACBrException {
        sendRecord(pReg1390, new ACBrSpedFiscalInterop.Bloco1Registro1390(), "SPDF_Bloco_1_Registro1390New");
    }
    
    private void sendRegistro1400(Registro1400 pReg1400) throws ACBrException {
        sendRecord(pReg1400, new ACBrSpedFiscalInterop.Bloco1Registro1400(), "SPDF_Bloco_1_Registro1400New");
    }
    
    private void sendRegistro1500(Registro1500 pReg1500) throws ACBrException {
        sendRecord(pReg1500, new ACBrSpedFiscalInterop.Bloco1Registro1500(), "SPDF_Bloco_1_Registro1500New");

        for (Registro1510 reg1510 : pReg1500.getRegistro1510()) {
            sendRegistro1510(reg1510);
        }
    }
    
    private void sendRegistro1510(Registro1510 pReg1510) throws ACBrException {
        sendRecord(pReg1510, new ACBrSpedFiscalInterop.Bloco1Registro1510(), "SPDF_Bloco_1_Registro1510New");
    }
    
    private void sendRegistro1600(Registro1600 pReg1600) throws ACBrException {
        sendRecord(pReg1600, new ACBrSpedFiscalInterop.Bloco1Registro1600(), "SPDF_Bloco_1_Registro1600New");
    }    

    private void sendRegistro1700(Registro1700 pReg1700) throws ACBrException {
        sendRecord(pReg1700, new ACBrSpedFiscalInterop.Bloco1Registro1700(), "SPDF_Bloco_1_Registro1700New");

        for (Registro1710 reg1710 : pReg1700.getRegistro1710()) {
            sendRegistro1710(reg1710);
        }        
    }    
    
    private void sendRegistro1710(Registro1710 pReg1710) throws ACBrException {
        sendRecord(pReg1710, new ACBrSpedFiscalInterop.Bloco1Registro1710(), "SPDF_Bloco_1_Registro1710New");
    }

    private void sendRegistro1800(Registro1800 pReg1800) throws ACBrException {
        sendRecord(pReg1800, new ACBrSpedFiscalInterop.Bloco1Registro1800(), "SPDF_Bloco_1_Registro1800New");
    }    
    // </editor-fold>  
    //<editor-fold defaultstate="collapsed" desc="Bloco 9"> 
    private void sendBloco9() throws ACBrException {
        sendRegistro9001();

        for (Registro9900 reg9900 : bloco9.getRegistro9900()) {
            sendRegistro9900(reg9900);
        }
    }
    
    private void sendRegistro9001() throws ACBrException {
        sendRecord(bloco9.getRegistro9001(), new ACBrSpedFiscalInterop.Bloco9Registro9001(), "SPDF_Bloco_9_Registro9001New");
    }   
    
    private void sendRegistro9900(Registro9900 pReg9900) throws ACBrException {
        sendRecord(pReg9900, new ACBrSpedFiscalInterop.Bloco9Registro9900(), "SPDF_Bloco_9_Registro9900New");
    } 
    // </editor-fold>  
    //<editor-fold defaultstate="collapsed" desc="Bloco C"> 
    private void sendBlocoC() throws ACBrException {
        sendRegistroC001();
    } 
    
    private void sendRegistroC001() throws ACBrException {
        sendRecord(blocoC.getRegistroC001(), new ACBrSpedFiscalInterop.BlocoCRegistroC001(), "SPDF_Bloco_C_RegistroC001New");

        for (RegistroC100 regC100 : blocoC.getRegistroC001().getRegistroC100()) {
            sendRegistroC100(regC100);
        }

        for (RegistroC300 regC300 : blocoC.getRegistroC001().getRegistroC300()) {
            sendRegistroC300(regC300);
        }

        for (RegistroC350 regC350 : blocoC.getRegistroC001().getRegistroC350()) {
            sendRegistroC350(regC350);
        }

        for (RegistroC400 regC400 : blocoC.getRegistroC001().getRegistroC400()) {
            sendRegistroC400(regC400);
        }

        for (RegistroC495 regC495 : blocoC.getRegistroC001().getRegistroC495()) {
            sendRegistroC495(regC495);
        }

        for (RegistroC500 regC500 : blocoC.getRegistroC001().getRegistroC500()) {
            sendRegistroC500(regC500);
        }

        for (RegistroC600 regC600 : blocoC.getRegistroC001().getRegistroC600()) {
            sendRegistroC600(regC600);
        }

        for (RegistroC700 regC700 : blocoC.getRegistroC001().getRegistroC700()) {
            sendRegistroC700(regC700);
        }

        for (RegistroC800 regC800 : blocoC.getRegistroC001().getRegistroC800()) {
            sendRegistroC800(regC800);
        }

        for (RegistroC860 regC860 : blocoC.getRegistroC001().getRegistroC860()) {
            sendRegistroC860(regC860);
        }
    }

    private void sendRegistroC100(RegistroC100 pRegC100) throws ACBrException {
        sendRecord(pRegC100, new ACBrSpedFiscalInterop.BlocoCRegistroC100(), "SPDF_Bloco_C_RegistroC100New");
        
        for (RegistroC105 regC105 : pRegC100.getRegistroC105()) {
            sendRegistroC105(regC105);
        }

        for (RegistroC110 regC110 : pRegC100.getRegistroC110()) {
            sendRegistroC110(regC110);
        }
        
        for (RegistroC120 regC120 : pRegC100.getRegistroC120()) {
            sendRegistroC120(regC120);
        }
        
        for (RegistroC130 regC130 : pRegC100.getRegistroC130()) {
            sendRegistroC130(regC130);
        }
        
        for (RegistroC140 regC140 : pRegC100.getRegistroC140()) {
            sendRegistroC140(regC140);
        }

        for (RegistroC160 regC160 : pRegC100.getRegistroC160()) {
            sendRegistroC160(regC160);
        }
        
        for (RegistroC165 regC165 : pRegC100.getRegistroC165()) {
            sendRegistroC165(regC165);
        }

        for (RegistroC170 regC170 : pRegC100.getRegistroC170()) {
            sendRegistroC170(regC170);
        }

        for (RegistroC190 regC190 : pRegC100.getRegistroC190()) {
            sendRegistroC190(regC190);
        }

        for (RegistroC195 regC195 : pRegC100.getRegistroC195()) {
            sendRegistroC195(regC195);
        }
    }
    
    private void sendRegistroC105(RegistroC105 pRegC105) throws ACBrException {
        sendRecord(pRegC105, new ACBrSpedFiscalInterop.BlocoCRegistroC105(), "SPDF_Bloco_C_RegistroC105New");
    }
    
    private void sendRegistroC110(RegistroC110 pRegC110) throws ACBrException {
        sendRecord(pRegC110, new ACBrSpedFiscalInterop.BlocoCRegistroC110(), "SPDF_Bloco_C_RegistroC110New");
        
        for (RegistroC111 regC111 : pRegC110.getRegistroC111()) {
            sendRegistroC111(regC111);
        }

        for (RegistroC112 regC112 : pRegC110.getRegistroC112()) {
            sendRegistroC112(regC112);
        }

        for (RegistroC113 regC113 : pRegC110.getRegistroC113()) {
            sendRegistroC113(regC113);
        }        

        for (RegistroC114 regC114 : pRegC110.getRegistroC114()) {
            sendRegistroC114(regC114);
        }        
        
        for (RegistroC115 regC115 : pRegC110.getRegistroC115()) {
            sendRegistroC115(regC115);
        }        
        
        for (RegistroC116 regC116 : pRegC110.getRegistroC116()) {
            sendRegistroC116(regC116);
        }        
    }

    private void sendRegistroC111(RegistroC111 pRegC111) throws ACBrException {
        sendRecord(pRegC111, new ACBrSpedFiscalInterop.BlocoCRegistroC111(), "SPDF_Bloco_C_RegistroC111New");
    }    
    
    private void sendRegistroC112(RegistroC112 pRegC112) throws ACBrException {
        sendRecord(pRegC112, new ACBrSpedFiscalInterop.BlocoCRegistroC112(), "SPDF_Bloco_C_RegistroC112New");
    }
    
    private void sendRegistroC113(RegistroC113 pRegC113) throws ACBrException {
        sendRecord(pRegC113, new ACBrSpedFiscalInterop.BlocoCRegistroC113(), "SPDF_Bloco_C_RegistroC113New");
    }
    
    private void sendRegistroC114(RegistroC114 pRegC114) throws ACBrException {
        sendRecord(pRegC114, new ACBrSpedFiscalInterop.BlocoCRegistroC114(), "SPDF_Bloco_C_RegistroC114New");
    }
    
    private void sendRegistroC115(RegistroC115 pRegC115) throws ACBrException {
        sendRecord(pRegC115, new ACBrSpedFiscalInterop.BlocoCRegistroC115(), "SPDF_Bloco_C_RegistroC115New");
    }
    
    private void sendRegistroC116(RegistroC116 pRegC116) throws ACBrException {
        sendRecord(pRegC116, new ACBrSpedFiscalInterop.BlocoCRegistroC116(), "SPDF_Bloco_C_RegistroC116New");
    }
    
    private void sendRegistroC120(RegistroC120 pRegC120) throws ACBrException {
        sendRecord(pRegC120, new ACBrSpedFiscalInterop.BlocoCRegistroC120(), "SPDF_Bloco_C_RegistroC120New");
    }
    
    private void sendRegistroC130(RegistroC130 pRegC130) throws ACBrException {
        sendRecord(pRegC130, new ACBrSpedFiscalInterop.BlocoCRegistroC130(), "SPDF_Bloco_C_RegistroC130New");
    }
    
    private void sendRegistroC140(RegistroC140 pRegC140) throws ACBrException {
        sendRecord(pRegC140, new ACBrSpedFiscalInterop.BlocoCRegistroC140(), "SPDF_Bloco_C_RegistroC140New");
        
        for (RegistroC141 regC141 : pRegC140.getRegistroC141()) {
            sendRegistroC141(regC141);
        }
    }    
    
    private void sendRegistroC141(RegistroC141 pRegC141) throws ACBrException {
        sendRecord(pRegC141, new ACBrSpedFiscalInterop.BlocoCRegistroC141(), "SPDF_Bloco_C_RegistroC141New");
    }
    
    private void sendRegistroC160(RegistroC160 pRegC160) throws ACBrException {
        sendRecord(pRegC160, new ACBrSpedFiscalInterop.BlocoCRegistroC160(), "SPDF_Bloco_C_RegistroC160New");
    }    
    
    private void sendRegistroC165(RegistroC165 pRegC165) throws ACBrException {
        sendRecord(pRegC165, new ACBrSpedFiscalInterop.BlocoCRegistroC165(), "SPDF_Bloco_C_RegistroC165New");
    }
    
    private void sendRegistroC170(RegistroC170 pRegC170) throws ACBrException {
        sendRecord(pRegC170, new ACBrSpedFiscalInterop.BlocoCRegistroC170(), "SPDF_Bloco_C_RegistroC170New");
        
        for (RegistroC171 regC171 : pRegC170.getRegistroC171()) {
            sendRegistroC171(regC171);
        }

        for (RegistroC172 regC172 : pRegC170.getRegistroC172()) {
            sendRegistroC172(regC172);
        }

        for (RegistroC173 regC173 : pRegC170.getRegistroC173()) {
            sendRegistroC173(regC173);
        }

        for (RegistroC174 regC174 : pRegC170.getRegistroC174()) {
            sendRegistroC174(regC174);
        }

        for (RegistroC175 regC175 : pRegC170.getRegistroC175()) {
            sendRegistroC175(regC175);
        }

        for (RegistroC176 regC176 : pRegC170.getRegistroC176()) {
            sendRegistroC176(regC176);
        }

        for (RegistroC177 regC177 : pRegC170.getRegistroC177()) {
            sendRegistroC177(regC177);
        }

        for (RegistroC178 regC178 : pRegC170.getRegistroC178()) {
            sendRegistroC178(regC178);
        }

        for (RegistroC179 regC179 : pRegC170.getRegistroC179()) {
            sendRegistroC179(regC179);
        }
    }
    
    private void sendRegistroC171(RegistroC171 pRegC171) throws ACBrException {
        sendRecord(pRegC171, new ACBrSpedFiscalInterop.BlocoCRegistroC171(), "SPDF_Bloco_C_RegistroC171New");
    }
    
    private void sendRegistroC172(RegistroC172 pRegC172) throws ACBrException {
        sendRecord(pRegC172, new ACBrSpedFiscalInterop.BlocoCRegistroC172(), "SPDF_Bloco_C_RegistroC172New");
    }
    
    private void sendRegistroC173(RegistroC173 pRegC173) throws ACBrException {
        sendRecord(pRegC173, new ACBrSpedFiscalInterop.BlocoCRegistroC173(), "SPDF_Bloco_C_RegistroC173New");
    }
    
    private void sendRegistroC174(RegistroC174 pRegC174) throws ACBrException {
        sendRecord(pRegC174, new ACBrSpedFiscalInterop.BlocoCRegistroC174(), "SPDF_Bloco_C_RegistroC174New");
    }
    
    private void sendRegistroC175(RegistroC175 pRegC175) throws ACBrException {
        sendRecord(pRegC175, new ACBrSpedFiscalInterop.BlocoCRegistroC175(), "SPDF_Bloco_C_RegistroC175New");
    }

    private void sendRegistroC176(RegistroC176 pRegC176) throws ACBrException {
        sendRecord(pRegC176, new ACBrSpedFiscalInterop.BlocoCRegistroC176(), "SPDF_Bloco_C_RegistroC176New");
    }

    private void sendRegistroC177(RegistroC177 pRegC177) throws ACBrException {
        sendRecord(pRegC177, new ACBrSpedFiscalInterop.BlocoCRegistroC177(), "SPDF_Bloco_C_RegistroC177New");
    }

    private void sendRegistroC178(RegistroC178 pRegC178) throws ACBrException {
        sendRecord(pRegC178, new ACBrSpedFiscalInterop.BlocoCRegistroC178(), "SPDF_Bloco_C_RegistroC178New");
    }

    private void sendRegistroC179(RegistroC179 pRegC179) throws ACBrException {
        sendRecord(pRegC179, new ACBrSpedFiscalInterop.BlocoCRegistroC179(), "SPDF_Bloco_C_RegistroC179New");
    }    
      
    private void sendRegistroC190(RegistroC190 pRegC190) throws ACBrException {
        sendRecord(pRegC190, new ACBrSpedFiscalInterop.BlocoCRegistroC190(), "SPDF_Bloco_C_RegistroC190New");
    }

    private void sendRegistroC195(RegistroC195 pRegC195) throws ACBrException {
        sendRecord(pRegC195, new ACBrSpedFiscalInterop.BlocoCRegistroC195(), "SPDF_Bloco_C_RegistroC195New");

        for (RegistroC197 regC197 : pRegC195.getRegistroC197()) {
            sendRegistroC197(regC197);
        }
    }

    private void sendRegistroC197(RegistroC197 pRegC197) throws ACBrException {
        sendRecord(pRegC197, new ACBrSpedFiscalInterop.BlocoCRegistroC197(), "SPDF_Bloco_C_RegistroC197New");
    }

    private void sendRegistroC300(RegistroC300 pRegC300) throws ACBrException {
        sendRecord(pRegC300, new ACBrSpedFiscalInterop.BlocoCRegistroC300(), "SPDF_Bloco_C_RegistroC300New");

        for (RegistroC310 regC310 : pRegC300.getRegistroC310()) {
            sendRegistroC310(regC310);
        }

        for (RegistroC320 regC320 : pRegC300.getRegistroC320()) {
            sendRegistroC320(regC320);
        }
    }

    private void sendRegistroC310(RegistroC310 pRegC310) throws ACBrException {
        sendRecord(pRegC310, new ACBrSpedFiscalInterop.BlocoCRegistroC310(), "SPDF_Bloco_C_RegistroC310New");
    }

    private void sendRegistroC320(RegistroC320 pRegC320) throws ACBrException {
        sendRecord(pRegC320, new ACBrSpedFiscalInterop.BlocoCRegistroC320(), "SPDF_Bloco_C_RegistroC320New");

        for (RegistroC321 regC321 : pRegC320.getRegistroC321()) {
            sendRegistroC321(regC321);
        }
    }

    private void sendRegistroC321(RegistroC321 pRegC321) throws ACBrException {
        sendRecord(pRegC321, new ACBrSpedFiscalInterop.BlocoCRegistroC321(), "SPDF_Bloco_C_RegistroC321New");
    }

    private void sendRegistroC350(RegistroC350 pRegC350) throws ACBrException {
        sendRecord(pRegC350, new ACBrSpedFiscalInterop.BlocoCRegistroC350(), "SPDF_Bloco_C_RegistroC350New");

        for (RegistroC370 regC370 : pRegC350.getRegistroC370()) {
            sendRegistroC370(regC370);
        }

        for (RegistroC390 regC390 : pRegC350.getRegistroC390()) {
            sendRegistroC390(regC390);
        }
    }

    private void sendRegistroC370(RegistroC370 pRegC370) throws ACBrException {
        sendRecord(pRegC370, new ACBrSpedFiscalInterop.BlocoCRegistroC370(), "SPDF_Bloco_C_RegistroC370New");
    }

    private void sendRegistroC390(RegistroC390 pRegC390) throws ACBrException {
        sendRecord(pRegC390, new ACBrSpedFiscalInterop.BlocoCRegistroC390(), "SPDF_Bloco_C_RegistroC390New");
    }
    
    private void sendRegistroC400(RegistroC400 pRegC400) throws ACBrException {
        sendRecord(pRegC400, new ACBrSpedFiscalInterop.BlocoCRegistroC400(), "SPDF_Bloco_C_RegistroC400New");

        for (RegistroC405 regC405 : pRegC400.getRegistroC405()) {
            sendRegistroC405(regC405);
        }
    }

    private void sendRegistroC405(RegistroC405 pRegC405) throws ACBrException {
        sendRecord(pRegC405, new ACBrSpedFiscalInterop.BlocoCRegistroC405(), "SPDF_Bloco_C_RegistroC405New");

        for (RegistroC410 regC410 : pRegC405.getRegistroC410()) {
            sendRegistroC410(regC410);
        }

        for (RegistroC420 regC420 : pRegC405.getRegistroC420()) {
            sendRegistroC420(regC420);
        }

        for (RegistroC460 regC460 : pRegC405.getRegistroC460()) {
            sendRegistroC460(regC460);
        }

        for (RegistroC490 regC490 : pRegC405.getRegistroC490()) {
            sendRegistroC490(regC490);
        }
    }

    private void sendRegistroC410(RegistroC410 pRegC410) throws ACBrException {
        sendRecord(pRegC410, new ACBrSpedFiscalInterop.BlocoCRegistroC410(), "SPDF_Bloco_C_RegistroC410New");
    }

    private void sendRegistroC420(RegistroC420 pRegC420) throws ACBrException {
        sendRecord(pRegC420, new ACBrSpedFiscalInterop.BlocoCRegistroC420(), "SPDF_Bloco_C_RegistroC420New");

        for (RegistroC425 regC425 : pRegC420.getRegistroC425()) {
            sendRegistroC425(regC425);
        }
    }

    private void sendRegistroC425(RegistroC425 pRegC425) throws ACBrException {
        sendRecord(pRegC425, new ACBrSpedFiscalInterop.BlocoCRegistroC425(), "SPDF_Bloco_C_RegistroC425New");
    }

    private void sendRegistroC460(RegistroC460 pRegC460) throws ACBrException {
        sendRecord(pRegC460, new ACBrSpedFiscalInterop.BlocoCRegistroC460(), "SPDF_Bloco_C_RegistroC460New");

        for (RegistroC470 regC470 : pRegC460.getRegistroC470()) {
            sendRegistroC470(regC470);
        }
    }

    private void sendRegistroC470(RegistroC470 pRegC470) throws ACBrException {
        sendRecord(pRegC470, new ACBrSpedFiscalInterop.BlocoCRegistroC470(), "SPDF_Bloco_C_RegistroC470New");
    }

    private void sendRegistroC490(RegistroC490 pRegC490) throws ACBrException {
        sendRecord(pRegC490, new ACBrSpedFiscalInterop.BlocoCRegistroC490(), "SPDF_Bloco_C_RegistroC490New");
    }

    private void sendRegistroC495(RegistroC495 pRegC495) throws ACBrException {
        sendRecord(pRegC495, new ACBrSpedFiscalInterop.BlocoCRegistroC495(), "SPDF_Bloco_C_RegistroC495New");
    }
    
    private void sendRegistroC500(RegistroC500 pRegC500) throws ACBrException {
        sendRecord(pRegC500, new ACBrSpedFiscalInterop.BlocoCRegistroC500(), "SPDF_Bloco_C_RegistroC500New");

        for (RegistroC510 regC510 : pRegC500.getRegistroC510()) {
            sendRegistroC510(regC510);
        }

        for (RegistroC590 regC590 : pRegC500.getRegistroC590()) {
            sendRegistroC590(regC590);
        }
    }

    private void sendRegistroC510(RegistroC510 pRegC510) throws ACBrException {
        sendRecord(pRegC510, new ACBrSpedFiscalInterop.BlocoCRegistroC510(), "SPDF_Bloco_C_RegistroC510New");
    }

    private void sendRegistroC590(RegistroC590 pRegC590) throws ACBrException {
        sendRecord(pRegC590, new ACBrSpedFiscalInterop.BlocoCRegistroC590(), "SPDF_Bloco_C_RegistroC590New");
    }
    
    private void sendRegistroC600(RegistroC600 pRegC600) throws ACBrException {
        sendRecord(pRegC600, new ACBrSpedFiscalInterop.BlocoCRegistroC600(), "SPDF_Bloco_C_RegistroC600New");

        for (RegistroC601 regC601 : pRegC600.getRegistroC601()) {
            sendRegistroC601(regC601);
        }

        for (RegistroC610 regC610 : pRegC600.getRegistroC610()) {
            sendRegistroC610(regC610);
        }

        for (RegistroC690 regC690 : pRegC600.getRegistroC690()) {
            sendRegistroC690(regC690);
        }
    }

    private void sendRegistroC601(RegistroC601 pRegC601) throws ACBrException {
        sendRecord(pRegC601, new ACBrSpedFiscalInterop.BlocoCRegistroC601(), "SPDF_Bloco_C_RegistroC601New");
    }

    private void sendRegistroC610(RegistroC610 pRegC610) throws ACBrException {
        sendRecord(pRegC610, new ACBrSpedFiscalInterop.BlocoCRegistroC610(), "SPDF_Bloco_C_RegistroC610New");
    }

    private void sendRegistroC690(RegistroC690 pRegC690) throws ACBrException {
        sendRecord(pRegC690, new ACBrSpedFiscalInterop.BlocoCRegistroC690(), "SPDF_Bloco_C_RegistroC690New");
    }
    
    private void sendRegistroC700(RegistroC700 pRegC700) throws ACBrException {
        sendRecord(pRegC700, new ACBrSpedFiscalInterop.BlocoCRegistroC700(), "SPDF_Bloco_C_RegistroC700New");

        for (RegistroC790 regC790 : pRegC700.getRegistroC790()) {
            sendRegistroC790(regC790);
        }
    }

    private void sendRegistroC790(RegistroC790 pRegC790) throws ACBrException {
        sendRecord(pRegC790, new ACBrSpedFiscalInterop.BlocoCRegistroC790(), "SPDF_Bloco_C_RegistroC790New");

        for (RegistroC791 regC791 : pRegC790.getRegistroC791()) {
            sendRegistroC791(regC791);
        }
    }

    private void sendRegistroC791(RegistroC791 pRegC791) throws ACBrException {
        sendRecord(pRegC791, new ACBrSpedFiscalInterop.BlocoCRegistroC791(), "SPDF_Bloco_C_RegistroC791New");
    }
    
    private void sendRegistroC800(RegistroC800 pRegC800) throws ACBrException {
        sendRecord(pRegC800, new ACBrSpedFiscalInterop.BlocoCRegistroC800(), "SPDF_Bloco_C_RegistroC800New");

        for (RegistroC850 regC850 : pRegC800.getRegistroC850()) {
            sendRegistroC850(regC850);
        }
    }

    private void sendRegistroC850(RegistroC850 pRegC850) throws ACBrException {
        sendRecord(pRegC850, new ACBrSpedFiscalInterop.BlocoCRegistroC850(), "SPDF_Bloco_C_RegistroC850New");
    }

    private void sendRegistroC860(RegistroC860 pRegC860) throws ACBrException {
        sendRecord(pRegC860, new ACBrSpedFiscalInterop.BlocoCRegistroC860(), "SPDF_Bloco_C_RegistroC860New");

        for (RegistroC890 regC890 : pRegC860.getRegistroC890()) {
            sendRegistroC890(regC890);
        }
    }

    private void sendRegistroC890(RegistroC890 pRegC890) throws ACBrException {
        sendRecord(pRegC890, new ACBrSpedFiscalInterop.BlocoCRegistroC890(), "SPDF_Bloco_C_RegistroC890New");
    } 
    // </editor-fold>      
    //<editor-fold defaultstate="collapsed" desc="Bloco D"> 
    private void sendBlocoD() throws ACBrException {
        sendRegistroD001();
    }

    private void sendRegistroD001() throws ACBrException {
        sendRecord(blocoD.getRegistroD001(), new ACBrSpedFiscalInterop.BlocoDRegistroD001(), "SPDF_Bloco_D_RegistroD001New");        

        for (RegistroD100 regD100 : blocoD.getRegistroD001().getRegistroD100()) {
            sendRegistroD100(regD100);
        }

        for (RegistroD300 regD300 : blocoD.getRegistroD001().getRegistroD300()) {
            sendRegistroD300(regD300);
        }

        for (RegistroD350 regD350 : blocoD.getRegistroD001().getRegistroD350()) {
            sendRegistroD350(regD350);
        }

        for (RegistroD400 regD400 : blocoD.getRegistroD001().getRegistroD400()) {
            sendRegistroD400(regD400);
        }

        for (RegistroD500 regD500 : blocoD.getRegistroD001().getRegistroD500()) {
            sendRegistroD500(regD500);
        }

        for (RegistroD600 regD600 : blocoD.getRegistroD001().getRegistroD600()) {
            sendRegistroD600(regD600);
        }

        for (RegistroD695 regD695 : blocoD.getRegistroD001().getRegistroD695()) {
            sendRegistroD695(regD695);
        }
    }

    private void sendRegistroD100(RegistroD100 pRegD100) throws ACBrException {
        sendRecord(pRegD100, new ACBrSpedFiscalInterop.BlocoDRegistroD100(), "SPDF_Bloco_D_RegistroD100New");        
        
        for (RegistroD110 regD110 : pRegD100.getRegistroD110()) {
            sendRegistroD110(regD110);
        }

        for (RegistroD130 regD130 : pRegD100.getRegistroD130()) {
            sendRegistroD130(regD130);
        }

        for (RegistroD140 regD140 : pRegD100.getRegistroD140()) {
            sendRegistroD140(regD140);
        }

        for (RegistroD150 regD150 : pRegD100.getRegistroD150()) {
            sendRegistroD150(regD150);
        }

        for (RegistroD160 regD160 : pRegD100.getRegistroD160()) {
            sendRegistroD160(regD160);
        }

        for (RegistroD170 regD170 : pRegD100.getRegistroD170()) {
            sendRegistroD170(regD170);
        }

        for (RegistroD180 regD180 : pRegD100.getRegistroD180()) {
            sendRegistroD180(regD180);
        }

        for (RegistroD190 regD190 : pRegD100.getRegistroD190()) {
            sendRegistroD190(regD190);
        }

        for (RegistroD195 regD195 : pRegD100.getRegistroD195()) {
            sendRegistroD195(regD195);
        }
    }

    private void sendRegistroD110(RegistroD110 pRegD110) throws ACBrException {
        sendRecord(pRegD110, new ACBrSpedFiscalInterop.BlocoDRegistroD110(), "SPDF_Bloco_D_RegistroD110New");        

        for (RegistroD120 regD120 : pRegD110.getRegistroD120()) {
            sendRegistroD120(regD120);
        }
    }

    private void sendRegistroD120(RegistroD120 pRegD120) throws ACBrException {
        sendRecord(pRegD120, new ACBrSpedFiscalInterop.BlocoDRegistroD120(), "SPDF_Bloco_D_RegistroD120New");        
    }

    private void sendRegistroD130(RegistroD130 pRegD130) throws ACBrException {
        sendRecord(pRegD130, new ACBrSpedFiscalInterop.BlocoDRegistroD130(), "SPDF_Bloco_D_RegistroD130New");        
    }

    private void sendRegistroD140(RegistroD140 pRegD140) throws ACBrException {
        sendRecord(pRegD140, new ACBrSpedFiscalInterop.BlocoDRegistroD140(), "SPDF_Bloco_D_RegistroD140New");
    }

    private void sendRegistroD150(RegistroD150 pRegD150) throws ACBrException {
        sendRecord(pRegD150, new ACBrSpedFiscalInterop.BlocoDRegistroD150(), "SPDF_Bloco_D_RegistroD150New");
    }

    private void sendRegistroD160(RegistroD160 pRegD160) throws ACBrException {
        sendRecord(pRegD160, new ACBrSpedFiscalInterop.BlocoDRegistroD160(), "SPDF_Bloco_D_RegistroD160New");

        for (RegistroD161 regD161 : pRegD160.getRegistroD161()) {
            sendRegistroD161(regD161);
        }

        for (RegistroD162 regD162 : pRegD160.getRegistroD162()) {
            sendRegistroD162(regD162);
        }
    }

    private void sendRegistroD161(RegistroD161 pRegD161) throws ACBrException {
        sendRecord(pRegD161, new ACBrSpedFiscalInterop.BlocoDRegistroD161(), "SPDF_Bloco_D_RegistroD161New");
    }

    private void sendRegistroD162(RegistroD162 pRegD162) throws ACBrException {
        sendRecord(pRegD162, new ACBrSpedFiscalInterop.BlocoDRegistroD162(), "SPDF_Bloco_D_RegistroD162New");
    }

    private void sendRegistroD170(RegistroD170 pRegD170) throws ACBrException {
        sendRecord(pRegD170, new ACBrSpedFiscalInterop.BlocoDRegistroD170(), "SPDF_Bloco_D_RegistroD170New");
    }

    private void sendRegistroD180(RegistroD180 pRegD180) throws ACBrException {
        sendRecord(pRegD180, new ACBrSpedFiscalInterop.BlocoDRegistroD180(), "SPDF_Bloco_D_RegistroD180New");
    }

    private void sendRegistroD190(RegistroD190 pRegD190) throws ACBrException {
        sendRecord(pRegD190, new ACBrSpedFiscalInterop.BlocoDRegistroD190(), "SPDF_Bloco_D_RegistroD190New");
    }

    private void sendRegistroD195(RegistroD195 pRegD195) throws ACBrException {
        sendRecord(pRegD195, new ACBrSpedFiscalInterop.BlocoDRegistroD195(), "SPDF_Bloco_D_RegistroD195New");        

        for (RegistroD197 regD197 : pRegD195.getRegistroD197()) {
            sendRegistroD197(regD197);
        }
    }

    private void sendRegistroD197(RegistroD197 pRegD197) throws ACBrException {
        sendRecord(pRegD197, new ACBrSpedFiscalInterop.BlocoDRegistroD197(), "SPDF_Bloco_D_RegistroD197New");
    }

    private void sendRegistroD300(RegistroD300 pRegD300) throws ACBrException {
        sendRecord(pRegD300, new ACBrSpedFiscalInterop.BlocoDRegistroD300(), "SPDF_Bloco_D_RegistroD300New");

        for (RegistroD301 regD301 : pRegD300.getRegistroD301()) {
            sendRegistroD301(regD301);
        }

        for (RegistroD310 regD310 : pRegD300.getRegistroD310()) {
            sendRegistroD310(regD310);
        }
    }

    private void sendRegistroD301(RegistroD301 pRegD301) throws ACBrException {
        sendRecord(pRegD301, new ACBrSpedFiscalInterop.BlocoDRegistroD301(), "SPDF_Bloco_D_RegistroD301New");
    }

    private void sendRegistroD310(RegistroD310 pRegD310) throws ACBrException {
        sendRecord(pRegD310, new ACBrSpedFiscalInterop.BlocoDRegistroD310(), "SPDF_Bloco_D_RegistroD310New");
    }

    private void sendRegistroD350(RegistroD350 pRegD350) throws ACBrException {
        sendRecord(pRegD350, new ACBrSpedFiscalInterop.BlocoDRegistroD350(), "SPDF_Bloco_D_RegistroD350New");

        for (RegistroD355 regD355 : pRegD350.getRegistroD355()) {
            sendRegistroD355(regD355);
        }
    }

    private void sendRegistroD355(RegistroD355 pRegD355) throws ACBrException {
        sendRecord(pRegD355, new ACBrSpedFiscalInterop.BlocoDRegistroD355(), "SPDF_Bloco_D_RegistroD355New");

        for (RegistroD360 regD360 : pRegD355.getRegistroD360()) {
            sendRegistroD360(regD360);
        }

        for (RegistroD365 regD365 : pRegD355.getRegistroD365()) {
            sendRegistroD365(regD365);
        }

        for (RegistroD390 regD390 : pRegD355.getRegistroD390()) {
            sendRegistroD390(regD390);
        }
    }

    private void sendRegistroD360(RegistroD360 pRegD360) throws ACBrException {
        sendRecord(pRegD360, new ACBrSpedFiscalInterop.BlocoDRegistroD360(), "SPDF_Bloco_D_RegistroD360New");
    }

    private void sendRegistroD365(RegistroD365 pRegD365) throws ACBrException {
        sendRecord(pRegD365, new ACBrSpedFiscalInterop.BlocoDRegistroD365(), "SPDF_Bloco_D_RegistroD365New");

        for (RegistroD370 regD370 : pRegD365.getRegistroD370()) {
            sendRegistroD370(regD370);
        }
    }

    private void sendRegistroD370(RegistroD370 pRegD370) throws ACBrException {
        sendRecord(pRegD370, new ACBrSpedFiscalInterop.BlocoDRegistroD370(), "SPDF_Bloco_D_RegistroD370New");
    }

    private void sendRegistroD390(RegistroD390 pRegD390) throws ACBrException {
        sendRecord(pRegD390, new ACBrSpedFiscalInterop.BlocoDRegistroD390(), "SPDF_Bloco_D_RegistroD390New");
    }

    private void sendRegistroD400(RegistroD400 pRegD400) throws ACBrException {
        sendRecord(pRegD400, new ACBrSpedFiscalInterop.BlocoDRegistroD400(), "SPDF_Bloco_D_RegistroD400New");

        for (RegistroD410 regD410 : pRegD400.getRegistroD410()) {
            sendRegistroD410(regD410);
        }

        for (RegistroD420 regD420 : pRegD400.getRegistroD420()) {
            sendRegistroD420(regD420);
        }
    }

    private void sendRegistroD410(RegistroD410 pRegD410) throws ACBrException {
        sendRecord(pRegD410, new ACBrSpedFiscalInterop.BlocoDRegistroD410(), "SPDF_Bloco_D_RegistroD410New");

        for (RegistroD411 regD411 : pRegD410.getRegistroD411()) {
            sendRegistroD411(regD411);
        }
    }

    private void sendRegistroD411(RegistroD411 pRegD411) throws ACBrException {
        sendRecord(pRegD411, new ACBrSpedFiscalInterop.BlocoDRegistroD411(), "SPDF_Bloco_D_RegistroD411New");
    }

    private void sendRegistroD420(RegistroD420 pRegD420) throws ACBrException {
        sendRecord(pRegD420, new ACBrSpedFiscalInterop.BlocoDRegistroD420(), "SPDF_Bloco_D_RegistroD420New");
    }

    private void sendRegistroD500(RegistroD500 pRegD500) throws ACBrException {
        sendRecord(pRegD500, new ACBrSpedFiscalInterop.BlocoDRegistroD500(), "SPDF_Bloco_D_RegistroD500New");

        for (RegistroD510 regD510 : pRegD500.getRegistroD510()) {
            sendRegistroD510(regD510);
        }

        for (RegistroD530 regD530 : pRegD500.getRegistroD530()) {
            sendRegistroD530(regD530);
        }

        for (RegistroD590 regD590 : pRegD500.getRegistroD590()) {
            sendRegistroD590(regD590);
        }
    }

    private void sendRegistroD510(RegistroD510 pRegD510) throws ACBrException {
        sendRecord(pRegD510, new ACBrSpedFiscalInterop.BlocoDRegistroD510(), "SPDF_Bloco_D_RegistroD510New");
    }

    private void sendRegistroD530(RegistroD530 pRegD530) throws ACBrException {
        sendRecord(pRegD530, new ACBrSpedFiscalInterop.BlocoDRegistroD530(), "SPDF_Bloco_D_RegistroD530New");
    }

    private void sendRegistroD590(RegistroD590 pRegD590) throws ACBrException {
        sendRecord(pRegD590, new ACBrSpedFiscalInterop.BlocoDRegistroD590(), "SPDF_Bloco_D_RegistroD590New");
    }

    private void sendRegistroD600(RegistroD600 pRegD600) throws ACBrException {
        sendRecord(pRegD600, new ACBrSpedFiscalInterop.BlocoDRegistroD600(), "SPDF_Bloco_D_RegistroD600New");

        for (RegistroD610 regD610 : pRegD600.getRegistroD610()) {
            sendRegistroD610(regD610);
        }

        for (RegistroD690 regD690 : pRegD600.getRegistroD690()) {
            sendRegistroD690(regD690);
        }
    }

    private void sendRegistroD610(RegistroD610 pRegD610) throws ACBrException {
        sendRecord(pRegD610, new ACBrSpedFiscalInterop.BlocoDRegistroD610(), "SPDF_Bloco_D_RegistroD610New");
    }

    private void sendRegistroD690(RegistroD690 pRegD690) throws ACBrException {
        sendRecord(pRegD690, new ACBrSpedFiscalInterop.BlocoDRegistroD690(), "SPDF_Bloco_D_RegistroD690New");
    }

    private void sendRegistroD695(RegistroD695 pRegD695) throws ACBrException {
        sendRecord(pRegD695, new ACBrSpedFiscalInterop.BlocoDRegistroD695(), "SPDF_Bloco_D_RegistroD695New");

        for (RegistroD696 regD696 : pRegD695.getRegistroD696()) {
            sendRegistroD696(regD696);
        }
    }

    private void sendRegistroD696(RegistroD696 pRegD696) throws ACBrException {
        sendRecord(pRegD696, new ACBrSpedFiscalInterop.BlocoDRegistroD696(), "SPDF_Bloco_D_RegistroD696New");

        for (RegistroD697 regD697 : pRegD696.getRegistroD697()) {
            sendRegistroD697(regD697);
        }
    }

    private void sendRegistroD697(RegistroD697 pRegD697) throws ACBrException {
        sendRecord(pRegD697, new ACBrSpedFiscalInterop.BlocoDRegistroD697(), "SPDF_Bloco_D_RegistroD697New");
    }
    // </editor-fold>  
    //<editor-fold defaultstate="collapsed" desc="Bloco E"> 
    private void sendBlocoE() throws ACBrException {
        sendRegistroE001();
    }

    private void sendRegistroE001() throws ACBrException {
        sendRecord(blocoE.getRegistroE001(), new ACBrSpedFiscalInterop.BlocoERegistroE001(), "SPDF_Bloco_E_RegistroE001New");

        for (RegistroE100 regE100 : blocoE.getRegistroE001().getRegistroE100()) {
            sendRegistroE100(regE100);
        }

        for (RegistroE200 regE200 : blocoE.getRegistroE001().getRegistroE200()) {
            sendRegistroE200(regE200);
        }

        for (RegistroE500 regE500 : blocoE.getRegistroE001().getRegistroE500()) {
            sendRegistroE500(regE500);
        }
    }

    private void sendRegistroE100(RegistroE100 pRegE100) throws ACBrException {
        sendRecord(pRegE100, new ACBrSpedFiscalInterop.BlocoERegistroE100(), "SPDF_Bloco_E_RegistroE100New");

        sendRegistroE110(pRegE100.getRegistroE110());
    }

    private void sendRegistroE110(RegistroE110 pRegE110) throws ACBrException {
        sendRecord(pRegE110, new ACBrSpedFiscalInterop.BlocoERegistroE110(), "SPDF_Bloco_E_RegistroE110New");

        for (RegistroE111 regE111 : pRegE110.getRegistroE111()) {
            sendRegistroE111(regE111);
        }

        for (RegistroE115 regE115 : pRegE110.getRegistroE115()) {
            sendRegistroE115(regE115);
        }

        for (RegistroE116 regE116 : pRegE110.getRegistroE116()) {
            sendRegistroE116(regE116);
        }
    }

    private void sendRegistroE111(RegistroE111 pRegE111) throws ACBrException {
        sendRecord(pRegE111, new ACBrSpedFiscalInterop.BlocoERegistroE111(), "SPDF_Bloco_E_RegistroE111New");

        for (RegistroE112 regE112 : pRegE111.getRegistroE112()) {
            sendRegistroE112(regE112);
        }

        for (RegistroE113 regE113 : pRegE111.getRegistroE113()) {
            sendRegistroE113(regE113);
        }
    }

    private void sendRegistroE112(RegistroE112 pRegE112) throws ACBrException {
        sendRecord(pRegE112, new ACBrSpedFiscalInterop.BlocoERegistroE112(), "SPDF_Bloco_E_RegistroE112New");
    }

    private void sendRegistroE113(RegistroE113 pRegE113) throws ACBrException {
        sendRecord(pRegE113, new ACBrSpedFiscalInterop.BlocoERegistroE113(), "SPDF_Bloco_E_RegistroE113New");
    }

    private void sendRegistroE115(RegistroE115 pRegE115) throws ACBrException {
        sendRecord(pRegE115, new ACBrSpedFiscalInterop.BlocoERegistroE115(), "SPDF_Bloco_E_RegistroE115New");
    }

    private void sendRegistroE116(RegistroE116 pRegE116) throws ACBrException {
        sendRecord(pRegE116, new ACBrSpedFiscalInterop.BlocoERegistroE116(), "SPDF_Bloco_E_RegistroE116New");
    }

    private void sendRegistroE200(RegistroE200 pRegE200) throws ACBrException {
        sendRecord(pRegE200, new ACBrSpedFiscalInterop.BlocoERegistroE200(), "SPDF_Bloco_E_RegistroE200New");

        for (RegistroE210 regE210 : pRegE200.getRegistroE210()) {
            sendRegistroE210(regE210);
        }
    }

    private void sendRegistroE210(RegistroE210 pRegE210) throws ACBrException {
        sendRecord(pRegE210, new ACBrSpedFiscalInterop.BlocoERegistroE210(), "SPDF_Bloco_E_RegistroE210New");

        for (RegistroE220 regE220 : pRegE210.getRegistroE220()) {
            sendRegistroE220(regE220);
        }

        for (RegistroE250 regE250 : pRegE210.getRegistroE250()) {
            sendRegistroE250(regE250);
        }
    }

    private void sendRegistroE220(RegistroE220 pRegE220) throws ACBrException {
        sendRecord(pRegE220, new ACBrSpedFiscalInterop.BlocoERegistroE220(), "SPDF_Bloco_E_RegistroE220New");

        for (RegistroE230 regE230 : pRegE220.getRegistroE230()) {
            sendRegistroE230(regE230);
        }

        for (RegistroE240 regE240 : pRegE220.getRegistroE240()) {
            sendRegistroE240(regE240);
        }
    }

    private void sendRegistroE230(RegistroE230 pRegE230) throws ACBrException {
        sendRecord(pRegE230, new ACBrSpedFiscalInterop.BlocoERegistroE230(), "SPDF_Bloco_E_RegistroE230New");
    }

    private void sendRegistroE240(RegistroE240 pRegE240) throws ACBrException {
        sendRecord(pRegE240, new ACBrSpedFiscalInterop.BlocoERegistroE240(), "SPDF_Bloco_E_RegistroE240New");
    }

    private void sendRegistroE250(RegistroE250 pRegE250) throws ACBrException {
        sendRecord(pRegE250, new ACBrSpedFiscalInterop.BlocoERegistroE250(), "SPDF_Bloco_E_RegistroE250New");
    }

    private void sendRegistroE500(RegistroE500 pRegE500) throws ACBrException {
        sendRecord(pRegE500, new ACBrSpedFiscalInterop.BlocoERegistroE500(), "SPDF_Bloco_E_RegistroE500New");

        for (RegistroE510 regE510 : pRegE500.getRegistroE510()) {
            sendRegistroE510(regE510);
        }

        for (RegistroE520 regE520 : pRegE500.getRegistroE520()) {
            sendRegistroE520(regE520);
        }
    }

    private void sendRegistroE510(RegistroE510 pRegE510) throws ACBrException {
        sendRecord(pRegE510, new ACBrSpedFiscalInterop.BlocoERegistroE510(), "SPDF_Bloco_E_RegistroE510New");
    }

    private void sendRegistroE520(RegistroE520 pRegE520) throws ACBrException {
        sendRecord(pRegE520, new ACBrSpedFiscalInterop.BlocoERegistroE520(), "SPDF_Bloco_E_RegistroE520New");

        for (RegistroE530 regE530 : pRegE520.getRegistroE530()) {
            sendRegistroE530(regE530);
        }
    }

    private void sendRegistroE530(RegistroE530 pRegE530) throws ACBrException {
        sendRecord(pRegE530, new ACBrSpedFiscalInterop.BlocoERegistroE530(), "SPDF_Bloco_E_RegistroE530New");
    }
    // </editor-fold>  
    //<editor-fold defaultstate="collapsed" desc="Bloco G"> 
    private void sendBlocoG() throws ACBrException {
        sendRegistroG001();
    }

    private void sendRegistroG001() throws ACBrException {
        sendRecord(blocoG.getRegistroG001(), new ACBrSpedFiscalInterop.BlocoGRegistroG001(), "SPDF_Bloco_G_RegistroG001New");

        for (RegistroG110 regG110 : blocoG.getRegistroG001().getRegistroG110()) {
            sendRegistroG110(regG110);
        }
    }

    private void sendRegistroG110(RegistroG110 pRegG110) throws ACBrException {
        sendRecord(pRegG110, new ACBrSpedFiscalInterop.BlocoGRegistroG110(), "SPDF_Bloco_G_RegistroG110New");

        for (RegistroG125 regG125 : pRegG110.getRegistroG125()) {
            sendRegistroG125(regG125);
        }
    }

    private void sendRegistroG125(RegistroG125 pRegG125) throws ACBrException {
        sendRecord(pRegG125, new ACBrSpedFiscalInterop.BlocoGRegistroG125(), "SPDF_Bloco_G_RegistroG125New");

        for (RegistroG126 regG126 : pRegG125.getRegistroG126()) {
            sendRegistroG126(regG126);
        }

        for (RegistroG130 regG130 : pRegG125.getRegistroG130()) {
            sendRegistroG130(regG130);
        }
    }

    private void sendRegistroG126(RegistroG126 pRegG126) throws ACBrException {
        sendRecord(pRegG126, new ACBrSpedFiscalInterop.BlocoGRegistroG126(), "SPDF_Bloco_G_RegistroG126New");
    }

    private void sendRegistroG130(RegistroG130 pRegG130) throws ACBrException {
        sendRecord(pRegG130, new ACBrSpedFiscalInterop.BlocoGRegistroG130(), "SPDF_Bloco_G_RegistroG130New");
        
        for (RegistroG140 regG140 : pRegG130.getRegistroG140()) {
            sendRegistroG140(regG140);
        }
    }

    private void sendRegistroG140(RegistroG140 pRegG140) throws ACBrException {
        sendRecord(pRegG140, new ACBrSpedFiscalInterop.BlocoGRegistroG140(), "SPDF_Bloco_G_RegistroG140New");
    }    
    // </editor-fold>  
    //<editor-fold defaultstate="collapsed" desc="Bloco H"> 
    private void sendBlocoH() throws ACBrException {
        sendRegistroH001();
    }

    private void sendRegistroH001() throws ACBrException {
        sendRecord(blocoH.getRegistroH001(), new ACBrSpedFiscalInterop.BlocoHRegistroH001(), "SPDF_Bloco_H_RegistroH001New");

        for (RegistroH005 regH005 : blocoH.getRegistroH001().getRegistroH005()) {
            sendRegistroH005(regH005);
        }
    }

    private void sendRegistroH005(RegistroH005 pRegH005) throws ACBrException {
        sendRecord(pRegH005, new ACBrSpedFiscalInterop.BlocoHRegistroH005(), "SPDF_Bloco_H_RegistroH005New");

        for (RegistroH010 regH010 : pRegH005.getRegistroH010()) {
            sendRegistroH010(regH010);
        }
    }

    private void sendRegistroH010(RegistroH010 pRegH010) throws ACBrException {
        sendRecord(pRegH010, new ACBrSpedFiscalInterop.BlocoHRegistroH010(), "SPDF_Bloco_H_RegistroH010New");

        for (RegistroH020 regH020 : pRegH010.getRegistroH020()) {
            sendRegistroH020(regH020);
        }
    }

    private void sendRegistroH020(RegistroH020 pRegH020) throws ACBrException {
        sendRecord(pRegH020, new ACBrSpedFiscalInterop.BlocoHRegistroH020(), "SPDF_Bloco_H_RegistroH020New");
    }    
    // </editor-fold>  
    // </editor-fold>  
 	//<editor-fold defaultstate="collapsed" desc="onError">
    /**
     * Adiciona o listener de erro do Sped Fiscal.
     * 
     * @param pListener 
     */
	public void addOnError(ACBrEventListener<OnErrorEventObject> pListener) {
		if (!hasListeners("onError")) {
			ACBrSpedFiscalInterop.INSTANCE.SPDF_SetOnError(getHandle(), new ACBrSpedFiscalInterop.StringCallback() {

                @Override
                public void invoke(String Mensagem) {
                    onError(Mensagem);
                }
            });
		}
		addListener("onError", pListener);
	}

    /**
     * Remove o listener associado.
     * 
     * @param pListener 
     */
	public void removeOnError(ACBrEventListener<OnErrorEventObject> pListener) {
		removeListener("onError", pListener);
		if (!hasListeners("onError")) {
			ACBrSpedFiscalInterop.INSTANCE.SPDF_SetOnError(getHandle(), null);
		}
	}

    /**
     * Seta a mensagem de erro.
     * 
     * @param pMensagem mensagem de erro.
     */
	private void onError(String pMensagem) {
		OnErrorEventObject e = new OnErrorEventObject(this, pMensagem);
		notifyListeners("onError", e);
	}
	//</editor-fold>  
    //<editor-fold defaultstate="collapsed" desc="Methods">
    /**
     * Realiza o envio do registro para gravacao.
     * 
     * @param pSource arquivo negocial.
     * @param pJna arquivo jna para envio.
     * @param pMethod metodo a ser acionado.
     * @throws ACBrException 
     */
    private void sendRecord(Object pSource, Structure pJna, String pMethod) throws ACBrException {
        objToJna(pSource, pJna);
        int ret = -1;
        try {
            ret = (int) ACBrSpedFiscalInterop.INSTANCE.getClass().getMethod(pMethod,
                    new Class[]{int.class, pJna.getClass()}).invoke(ACBrSpedFiscalInterop.INSTANCE, getHandle(), pJna);
        } catch (Exception e) {
            throw new ACBrException(e.getMessage());
        }
        checkResult(ret);
    }

    /**
     * Realiza a conversao de um objeto negocial para um objeto JNA para envio
     * a lib do ACBr.
     * 
     * @param pSourceObj objeto negocial de origem.
     * @param pTargetJna objeto jna de destino.
     * @throws ACBrException 
     */
    protected void objToJna(Object pSourceObj, Structure pTargetJna) throws ACBrException {
        try {
            // Obtem os campos que serao iterados para realizacao dos sets.
            Field[] lFields = pTargetJna.getClass().getDeclaredFields();
            Object lSourceValue; // Valor DE
            Field lSourceField; // Propriedade PARA

            // Percorre os campos obtidos tornando-os acessiveis para que o valores do JNA sejam setados.
            for (Field lTargetField : lFields) {
                lTargetField.setAccessible(true);
                
                // Torna a propriedade visivel para acesso ao dados do objeto.
                lSourceField = pSourceObj.getClass().getDeclaredField(lTargetField.getName());
                lSourceField.setAccessible(true);
                lSourceValue = lSourceField.get(pSourceObj);

                // Caso o campo seja string o mesmo sera convertido para um array
                // de bytes que sera submetido ao JNA.
                if (lSourceField.getType().isAssignableFrom(String.class)) {
                    lTargetField.set(pTargetJna, 
                            toByte(lSourceValue == null ? "" : lSourceValue.toString(), Array.getLength(lTargetField.get(pTargetJna))));

                // Caso o campo seja um date ele e convertido para double para o
                // envio via JNA. Somente sao setados valores nao nulos.
                } else if (lSourceField.getType().isAssignableFrom(Date.class)) {
                    if (lSourceValue != null) {
                        lTargetField.set(pTargetJna, OleDate.toOADate((Date)lSourceValue));
                    }

                // Em casos de enum e acionado o metodo getCodigo() para verificar
                // o codigo que sera submetido ao JNA. No momento apenas int e
                // String sera tratados.    
                } else if (lSourceField.getType().isEnum()) {
                    if (lSourceValue != null) {
                        Object lEnumValue = lSourceValue.getClass()
                                .getMethod("getCodigo", new Class[0])
                                .invoke(lSourceValue, new Object[0]);

                        // Verifica se o enum e um inteiro.
                        if (lEnumValue.getClass().isAssignableFrom(Integer.class) && ((int)lEnumValue) > -1) { 
                            lTargetField.set(pTargetJna, lEnumValue);    

                        // Verifica se o enum e uma String.
                        } else if (lEnumValue.getClass().isAssignableFrom(String.class)) {
                            lTargetField.set(pTargetJna, 
                                    toByte(lEnumValue.toString(), Array.getLength(lTargetField.get(pTargetJna))));                        
                        }
                    } else {
                        // Seta o valor -1 informando que o enum nao deve aparecer no arquivo.
                        lTargetField.set(pTargetJna, -1); 
                    }                        
                // Os demais tipos serao setados diretamente ao JNA. Por enquanto, 
                // espera-se apenas tipos primitivos.
                } else {
                    lTargetField.set(pTargetJna, lSourceValue);
                }
            }
        } catch (NoSuchFieldException e) {
            throw new ACBrException(MessageFormat.format("O tipo {0} nao possui a propriedade {1}.", 
                    pTargetJna.getClass().getName(), e.getMessage()));
        } catch (Exception e) {
            throw new ACBrException(e.getMessage());
        }            
    }
	//</editor-fold>  
    //<editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * @see Bloco0
     * @return the bloco0
     */
    public Bloco0 getBloco0() {
        return bloco0;
    }

    /**
     * @see Bloco1
     * @return the bloco1
     */
    public Bloco1 getBloco1() {
        return bloco1;
    }

    /**
     * @see Bloco9
     * @return the bloco9
     */
    public Bloco9 getBloco9() {
        return bloco9;
    }

    /**
     * @see BlocoC
     * @return the blocoC
     */
    public BlocoC getBlocoC() {
        return blocoC;
    }

    /**
     * @see BlocoD
     * @return the blocoD
     */
    public BlocoD getBlocoD() {
        return blocoD;
    }

    /**
     * @see BlocoE
     * @return the blocoE
     */
    public BlocoE getBlocoE() {
        return blocoE;
    }

    /**
     * @see BlocoG
     * @return the blocoG
     */
    public BlocoG getBlocoG() {
        return blocoG;
    }

    /**
     * @see BlocoH
     * @return the blocoH
     */
    public BlocoH getBlocoH() {
        return blocoH;
    }
    // </editor-fold>  
    
}