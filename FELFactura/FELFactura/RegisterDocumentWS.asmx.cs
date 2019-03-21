using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
namespace FELFactura
{
    /// <summary>
    /// Descripción breve de RegisterDocumentWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class RegisterDocumentWS : System.Web.Services.WebService
    {
        static RegisterDocument ws = Instancia.getInstancia(1);
        XMLFactura xml = new XMLFactura();
        [WebMethod]
        public XmlDocument registerDocument(String token, string XMLCompany, string XMLInvoice, string XMLDetailInvoce,string path,string fac_num)
        {
            token = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJzY29wZSI6WyJvcGVuaWQiXSwiZXhwIjoxNTg0NTY3NTMxLCJhdXRob3JpdGllcyI6WyJST0xFX0VNSVNPUiJdLCJqdGkiOiJhYjc0MDdlOS0wNzdmLTRjZDItOWYwYS03YmQ2M2Y4ZjdjMzAiLCJjbGllbnRfaWQiOiIzMjI1NjA3In0.avnuVwiKA46K-7gfz8IEc6Om9--tMxwi4P4NLntz-KIc1Ukmf9Ybk_brsD4qW6gDbm5A3DlCisSyHEAaVNPPWW8vTuJjHWZxvxSNbDKr8eG6_AHX20xVNipOZQipWyGNQ3u3xetT23Jmfm0elwNVhlOuO9Re8Rh1Lvatcceb-A1O80reqdQBvm0QEXkDYxTOVmacVWxr75YYzz_LbCM7s14EY9CPoYbsbqmuQMEiuLPn_MmI2md1wkuDnXEQUMGLsiXM7t4vAYvxbAM03iXeD-Uojjdp0dL9PAzq5RdepsNO5J5qyvK820q9sXs0hZHrH1sTxSgdppzXHeQKZFCz0Q";
            XMLCompany = "<?xml version = \"1.0\" encoding=\"Windows - 1252\" standalone=\"yes\"?> <VFPData> <temp_fact_company> <codigomoneda>GTQ</codigomoneda> <numeroaccesso>1</numeroaccesso> <tipodocumento>FACT</tipodocumento> <afiliacioniva>GEN</afiliacioniva> <codigoestablecimiento>01</codigoestablecimiento> <correoemisor>jfinanciero@mayaquimicos.com.gt</correoemisor> <nitemisor>3225607</nitemisor> <nombrecomercial>Mayaquimicos</nombrecomercial> <nombreemisor>Mayaquimicos</nombreemisor> <direccion>Guatemala </direccion> <codigopostal>123</codigopostal> <departamento>Guatemala</departamento> <municipio>Guatemala</municipio> <pais>GT</pais> <apikey>hwI5RFEFm9wOnz727R6jLGu</apikey> </temp_fact_company> </VFPData>";
            XMLInvoice = "<?xml version = \"1.0\" encoding=\"Windows - 1252\" standalone=\"yes\"?> <VFPData> <temp_fact_header> <fact_num>20002466</fact_num> <fec_emis>2019-03-14T00:00:00</fec_emis> <correoreceptor/> <idreceptor>0000</idreceptor> <nombrereceptor>Acoustic Geophysical Services, Belize Limited</nombrereceptor> <direccion/> <codigopostal/> <pais>Guatemala</pais> <departamento>Guatemala</departamento> <municipio/> </temp_fact_header> </VFPData>";
            XMLDetailInvoce = "<?xml version = \"1.0\" encoding=\"Windows - 1252\" standalone=\"yes\"?> <VFPData> <temp_fact_detail> <bienoservicio>S</bienoservicio> <numerolinea>1</numerolinea> <cantidad>1.00000</cantidad> <unidadmedida>1</unidadmedida> <descripcion>Pago de Servicio de Seguridad</descripcion> <co_art>9901007</co_art> <fact_num>20002466</fact_num> <preciounitario>100.0000000000000000</preciounitario> <precio>100.000000</precio> <total>100.0000000000000000</total> <descuento>10.0000000000000000</descuento> <impuestonombrecorto>IVA</impuestonombrecorto> <codigounidadgravable>1</codigounidadgravable> <montoimpuesto>10</montoimpuesto> <montogravable>10</montogravable> </temp_fact_detail> </VFPData>";
            String xmlDoc = xml.getXML(XMLCompany, XMLInvoice, XMLDetailInvoce,path,fac_num);
            return ws.registerDte( token, xmlDoc);
        }
    }
}
