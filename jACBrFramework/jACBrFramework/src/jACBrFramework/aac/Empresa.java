package jACBrFramework.aac;

import jACBrFramework.ACBrException;
import jACBrFramework.interop.ACBrAACInterop;
import java.nio.ByteBuffer;

/**
 * Dados associados a empresa.
 * 
 * @author Jose Mauro
 * @version Criado em: 16/12/2013 10:12:20, revisao: $Id$
 */
public class Empresa extends ACBrAACWrapper {
    
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    /**
     * Cria um novo objeto empresa.
     * 
     * @param pAac instancia para auxiliar a criptografia.
     */
    Empresa(ACBrAAC pAac) {
        super(pAac);
    }    
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Components Methods">    
    /**
     * CNPJ.
     * 
     * @param pCnpj
     * @throws ACBrException 
     */
    public void setCnpj(String pCnpj) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Empresa_SetCNPJ(getHandle(), toUTF8(pCnpj));
        checkResult(ret);
    }
    
    /**
     * Recupera o CNPJ associado.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getCnpj() throws ACBrException {
        ByteBuffer lCnpj = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Empresa_GetCNPJ(getHandle(), lCnpj, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lCnpj, ret);
    }     

    /**
     * Razao Social.
     * 
     * @param pRazaoSocial
     * @throws ACBrException 
     */
    public void setRazaoSocial(String pRazaoSocial) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Empresa_SetRazaoSocial(getHandle(), toUTF8(pRazaoSocial));
        checkResult(ret);
    }
    
    /**
     * Razao Social associada.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getRazaoSocial() throws ACBrException {
        ByteBuffer lRazaoSocial = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Empresa_GetRazaoSocial(getHandle(), lRazaoSocial, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lRazaoSocial, ret);
    }     
    
    /**
     * Endereco.
     * 
     * @param pEndereco
     * @throws ACBrException 
     */
    public void setEndereco(String pEndereco) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Empresa_SetEndereco(getHandle(), toUTF8(pEndereco));
        checkResult(ret);
    }
    
    /**
     * Endereco associado.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getEndereco() throws ACBrException {
        ByteBuffer lEndereco = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Empresa_GetEndereco(getHandle(), lEndereco, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lEndereco, ret);
    }   
    
    /**
     * Cep.
     * 
     * @param pCep
     * @throws ACBrException 
     */
    public void setCep(String pCep) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Empresa_SetCep(getHandle(), toUTF8(pCep));
        checkResult(ret);
    }
    
    /**
     * Cep associado.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getCep() throws ACBrException {
        ByteBuffer lCep = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Empresa_GetCep(getHandle(), lCep, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lCep, ret);
    }    
    
    /**
     * Cidade.
     * 
     * @param pCidade
     * @throws ACBrException 
     */
    public void setCidade(String pCidade) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Empresa_SetCidade(getHandle(), toUTF8(pCidade));
        checkResult(ret);
    }
    
    /**
     * Cidade associada.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getCidade() throws ACBrException {
        ByteBuffer lCidade = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Empresa_GetCidade(getHandle(), lCidade, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lCidade, ret);
    }     
    
    /**
     * Uf.
     * 
     * @param pUf
     * @throws ACBrException 
     */
    public void setUf(String pUf) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Empresa_SetUf(getHandle(), toUTF8(pUf));
        checkResult(ret);
    }
    
    /**
     * Uf associada.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getUf() throws ACBrException {
        ByteBuffer lUf = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Empresa_GetUf(getHandle(), lUf, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lUf, ret);
    }   
    
    /**
     * Telefone.
     * 
     * @param pTelefone
     * @throws ACBrException 
     */
    public void setTelefone(String pTelefone) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Empresa_SetTelefone(getHandle(), toUTF8(pTelefone));
        checkResult(ret);
    }
    
    /**
     * Telefone associado.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getTelefone() throws ACBrException {
        ByteBuffer lTelefone = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Empresa_GetTelefone(getHandle(), lTelefone, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lTelefone, ret);
    } 
    
    /**
     * Contato.
     * 
     * @param pContato
     * @throws ACBrException 
     */
    public void setContato(String pContato) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Empresa_SetContato(getHandle(), toUTF8(pContato));
        checkResult(ret);
    }
    
    /**
     * Contato associado.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getContato() throws ACBrException {
        ByteBuffer lContato = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Empresa_GetContato(getHandle(), lContato, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lContato, ret);
    }   
    
    /**
     * Email.
     * 
     * @param pEmail
     * @throws ACBrException 
     */
    public void setEmail(String pEmail) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Empresa_SetEmail(getHandle(), toUTF8(pEmail));
        checkResult(ret);
    }
    
    /**
     * Email associado.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getEmail() throws ACBrException {
        ByteBuffer lEmail = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Empresa_GetEmail(getHandle(), lEmail, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lEmail, ret);
    }   
    
    /**
     * Inscricao Estadual.
     * 
     * @param pInscEstadual
     * @throws ACBrException 
     */
    public void setInscEstadual(String pInscEstadual) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Empresa_SetIE(getHandle(), toUTF8(pInscEstadual));
        checkResult(ret);
    }
    
    /**
     * Inscricao Estadual associada.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getInscEstadual() throws ACBrException {
        ByteBuffer lInscEstadual = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Empresa_GetIE(getHandle(), lInscEstadual, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lInscEstadual, ret);
    }   
    
    /**
     * Inscricao Municipal.
     * 
     * @param pInscMunicipal
     * @throws ACBrException 
     */
    public void setInscMunicipal(String pInscMunicipal) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Empresa_SetIM(getHandle(), toUTF8(pInscMunicipal));
        checkResult(ret);
    }
    
    /**
     * Inscricao Municipal associada.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getInscMunicipal() throws ACBrException {
        ByteBuffer lInscMunicipal = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_Empresa_GetIM(getHandle(), lInscMunicipal, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lInscMunicipal, ret);
    }     
    // </editor-fold>
    
}