﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Xml;
using System.Text;
using System.IO;
namespace FELFactura
{
    public class RegisterDocument
    {
        static GetRequestToken ws = Instancia.getInstancia();
        
        public XmlDocument registerDte(String token,String dataXml)
        {
            //ENVIANDO DOCUMENTO
            var request = (HttpWebRequest)WebRequest.Create(Constants.URL_REGISTRAR_DOCUMENTO);
            var postData = getPostData(dataXml);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(postData);
            var data = Encoding.ASCII.GetBytes(xmlDoc.InnerXml);
            request.Headers.Add("Authorization", "Bearer " + token.ToString().Trim());
            request.Method = "POST";
            request.ContentType = "application/xml";
            request.ContentLength = data.Length;
            var stream = request.GetRequestStream();
            stream.Write(data, 0, data.Length);
            
           var response = (HttpWebResponse)request.GetResponse();
           string responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            
            XmlDocument xmlDoc2 = new XmlDocument();
            xmlDoc2.LoadXml(responseString);
            return xmlDoc2;

        

        }
        private String getPostData(String data)
        {
    

            string uuid = Guid.NewGuid().ToString().ToUpper();

             String request = "<RegistraDocumentoXMLRequest id=\""+uuid+"\">" +
                            "<xml_dte>" +
                            " <![CDATA[" + data + "]]>" +
                            "</xml_dte>"+
                            "</RegistraDocumentoXMLRequest>";
            return request;
        }
    }
}