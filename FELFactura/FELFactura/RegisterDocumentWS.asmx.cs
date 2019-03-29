using System;
using System.Web.Services;
using System.Data;
using System.Xml;

using System.IO;
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
        ValidateDocument wsvalidate = new ValidateDocument();
        XMLFactura xml = new XMLFactura();
        DataSet strreponsexml = new DataSet();

        [WebMethod]
        public DataSet registerDocument(String token,
            String XMLCompany, String XMLInvoice, String XMLDetailInvoce, String path, String fac_num)
        {

            String xmlDoc = xml.getXML(XMLCompany, XMLInvoice, XMLDetailInvoce,path,fac_num);
            XmlDocument validate = wsvalidate.validar(token, xmlDoc);
            XmlNodeList resNodo = validate.GetElementsByTagName("tipo_respuesta");
              
            string error = resNodo[0].InnerXml;
            
            
            if ("1".Equals(error.ToString()))
            {
                
                String errorDescp = getError(validate);
                strreponsexml = GetResponseXML(errorDescp, error, this.strreponsexml);
                return strreponsexml;
            }

            XmlDocument register = ws.registerDte(token, xmlDoc);
            XmlNodeList resReg = register.GetElementsByTagName("tipo_respuesta");
            string errorRes = resNodo[0].InnerXml;

            
            if ("1".Equals(errorRes.ToString()))
            {
                
                String errorDescp = getError(register);
                strreponsexml = GetResponseXML(errorDescp, errorRes, this.strreponsexml);
                return strreponsexml;
            }

            XmlNodeList uuidNodo = register.GetElementsByTagName("uuid");

            string uuid = uuidNodo[0].InnerXml;

            strreponsexml = GetResponseXML("Transacción Exitosa", uuid, errorRes, this.strreponsexml);

            return strreponsexml;
        }
        private DataSet GetResponseXML(String valor,  string errores, DataSet strreponsexml)
        {
            try
            {
                //Vaciando Respuesta
                strreponsexml = new DataSet();
                //Evaluando token
                if (valor == null)
                { valor = " "; }

                //Evaluando Error Text
                //Creando XML
                //Documento XML
                XmlDocument xmlDoc = new XmlDocument();
                //Nombre de XML
                XmlNode rootNode = xmlDoc.CreateElement("NewDataset");
                xmlDoc.AppendChild(rootNode);
                //TABLE
                XmlNode xtable = xmlDoc.CreateElement("Table");
                rootNode.AppendChild(xtable);
                //token
                XmlNode xvalor = xmlDoc.CreateElement("respuesta");
                if (valor != null && valor.Length > 0)
                {
                    xvalor.InnerText = valor.ToString();
                }
                xtable.AppendChild(xvalor);

                //Error
                       XmlNode xerror = xmlDoc.CreateElement("blnerror");
                xerror.InnerText = errores.ToString();
                xtable.AppendChild(xerror);
                StringWriter stringWriter = new StringWriter();
                XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
                xmlDoc.WriteTo(xmlTextWriter);
                StringReader reader = new StringReader(stringWriter.ToString());
                strreponsexml.ReadXml(reader);

            }
            catch
            {

            }
            return strreponsexml;
        }
        private DataSet GetResponseXML(String valor,String uuid, string errores, DataSet strreponsexml)
        {
            try
            {
                //Vaciando Respuesta
                strreponsexml = new DataSet();
                //Evaluando token
                if (valor == null)
                { valor = " "; }
                if (uuid == null)
                { uuid = " "; }
                //Evaluando Error Text
                //Creando XML
                //Documento XML
                XmlDocument xmlDoc = new XmlDocument();
                //Nombre de XML
                XmlNode rootNode = xmlDoc.CreateElement("NewDataset");
                xmlDoc.AppendChild(rootNode);
                //TABLE
                XmlNode xtable = xmlDoc.CreateElement("Table");
                rootNode.AppendChild(xtable);
                //token
                XmlNode xvalor = xmlDoc.CreateElement("respuesta");
                if (valor != null && valor.Length > 0)
                {
                    xvalor.InnerText = valor.ToString();
                }
                xtable.AppendChild(xvalor);

                XmlNode xuuid = xmlDoc.CreateElement("uuid");
                if (uuid != null && uuid.Length > 0)
                {
                    xuuid.InnerText = uuid.ToString();
                }
                xtable.AppendChild(xuuid);

                //Error
                XmlNode xerror = xmlDoc.CreateElement("blnerror");
                xerror.InnerText = errores.ToString();
                xtable.AppendChild(xerror);
                StringWriter stringWriter = new StringWriter();
                XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
                xmlDoc.WriteTo(xmlTextWriter);
                StringReader reader = new StringReader(stringWriter.ToString());
                strreponsexml.ReadXml(reader);

            }
            catch
            {

            }
            return strreponsexml;
        }

        private String getError(XmlDocument doc)
        {

        
            XmlNode unEmpleado;
            String errores = "";
            XmlNodeList lst = doc.GetElementsByTagName("error");


            int count = lst.Count;
            for (int i = 0; i < count; i++)
            {

                unEmpleado = lst.Item(i);

                string id = unEmpleado.SelectSingleNode("cod_error").InnerText;
                string error = unEmpleado.SelectSingleNode("desc_error").InnerText;

                errores += " Código: " + id + ", Error: " + error + "\n";

            }
            return errores;
        }
    }
}
