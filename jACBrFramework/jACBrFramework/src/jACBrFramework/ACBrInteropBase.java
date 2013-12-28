package jACBrFramework;

import com.sun.jna.Structure;
import java.nio.ByteBuffer;
import java.nio.charset.Charset;
import java.util.logging.Level;
import java.util.logging.Logger;


public abstract class ACBrInteropBase
{
	//<editor-fold defaultstate="collapsed" desc="Fields">
    /**
     * Charset customizado pelo usuario. A principio so e utilizado pelo ACBrSintegra.
     */
    private Charset customCharset = UTF8;    
	protected final int STR_BUFFER_LEN = 256;
	protected final static Charset UTF8;
	//</editor-fold>
	
	//<editor-fold defaultstate="collapsed" desc="Constructors">
	static {
		UTF8 = Charset.forName("UTF-8");
	}

	protected ACBrInteropBase()
	{
	}

	//</editor-fold>
	
	//<editor-fold defaultstate="collapsed" desc="Methods">
	
	//<editor-fold defaultstate="collapsed" desc="Abstract Methods">
	public abstract int getHandle();

	protected abstract void checkResult(int result) throws ACBrException;

	//</editor-fold>
	
	//<editor-fold defaultstate="collapsed" desc="InteropHelper Methods">
    /**
     * Converte uma string para sua representacao em byte no charset recebido.
     * 
     * @param pValue string a ser convertida.
     * @param pSize tamanho do vetor de retorno.
     * @param pCharset charset associada a conversao.
     * @return string na representacao em bytes.
     */
    protected byte[] toByte(String pValue, int pSize, Charset pCharset) { 
        byte[] lArray = new byte[pSize];
        //Arrays.fill(lArray, (byte)'\0');
        if (pValue != null) {
            byte[] lStrBytes = pValue.getBytes(pCharset);
            System.arraycopy(lStrBytes, 0, lArray, 0, lStrBytes.length > pSize ? pSize : lStrBytes.length);            
        }
        return lArray;   
    }
    
    /**
     * Converte uma string para sua representacao em byte com base no charset 
     * customizado.
     * 
     * @param pValue string a ser convertida.
     * @param pSize tamanho do vetor de retorno.
     * @return string no formato byte com o charset customizado.
     */
    protected byte[] toByte(String pValue, int pSize) {
        return toByte(pValue, pSize, getCustomCharset());
    }
    
    /**
     * Cria a estrutura de vetor que deve ser enviada via JNA.
     * 
     * @param <T> tipo associado ao retorno.
     * @param pClass classe que responsavel pela criacao do vetor.
     * @param pSize tamanho do vetor.
     * @return instancia de retorno.
     * @throws ACBrException erro ao criar o vetor.
     */
    @SuppressWarnings("UseSpecificCatch")
    protected <T extends Structure> T[] criaVetorJNA(Class<? extends Structure> pClass, int pSize) throws ACBrException {        
        try {
            if (pSize == 0) return null;
            else return (T[]) pClass.newInstance().toArray(pSize);
        } catch (Exception e) {
            Logger.getLogger(ACBrInteropBase.class.getName()).log(Level.SEVERE, null, e);
            throw new ACBrException(e.getMessage());
        }
    }
    
	protected String toUTF8(String value)
	{
		return new String(value.getBytes(UTF8));
	}
	
	protected String[] toUTF8(String[] value)
	{
		String[] array = new String[value.length];
		for(int i=0; i<array.length; i++)
		{
			array[i] = new String(value[i].getBytes(UTF8));
		}
		
		return array;
	}
	
	protected String fromUTF8(String value)
	{
		return new String(value.getBytes(), UTF8);
	}

	protected String fromUTF8(ByteBuffer buffer, int len)
	{
		return new String(buffer.array(), 0, len, UTF8);
	}

	protected String fromUTF8(byte[] value)
	{
		return new String(value, UTF8).trim();
	}
	//</editor-fold>
	
	//</editor-fold>
    
    //<editor-fold defaultstate="collapsed" desc="Getters - Setters">
    /**
     * Charset customizado pelo usuario. A principio so e utilizado pelo ACBrSintegra.
     * @return the customCharset
     */
    public Charset getCustomCharset() {
        return customCharset;
    }

    /**
     * Charset customizado pelo usuario. A principio so e utilizado pelo ACBrSintegra.
     * @param customCharset the customCharset to set
     */
    public void setCustomCharset(Charset customCharset) {
        this.customCharset = customCharset;
    }    
	//</editor-fold>
    
}
