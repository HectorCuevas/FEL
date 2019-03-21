using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FELFactura
{
    public class Constants
    {
        public  static  String URL_SOLICITAR_TOKEN= "https://dev.api.ifacere-fel.com/fel-dte-services/api/solicitarToken";
        public  static  String URL_REGISTRAR_DOCUMENTO = "https://dev.api.ifacere-fel.com/fel-dte-services/api/registrarDocumentoXML";
        public static String USUARIO = "3225607";
        public static String CLAVE = "hwI5RFEFm9wOnz727R6jLGu";
        public static String URL_CERTIFICADO = "C:\\certificado\\3225607-61589fea042b4cfc.pfx";
        //public static String URL_CERTIFICADO = "C:\\Users\\leyla\\Dropbox\\universidad\\prosisco\\proyectos\\FELFactura\\3225607-61589fea042b4cfc.pfx";
        public static String URL_CERTIFICADO_CONTRASENIA = "MayaZac/49";
        public static String UBICACION_XML_FACTURA = "C:\\Users\\leyla\\Dropbox\\universidad\\prosisco\\";
        public static String FRASE = "";
        public static String TIPO_FACTURA = "FACT";
        public static String TIPO_FACTURA_CAMBIARIA = "FCAM";
        public static String TIPO_FACTURA_PEQUENIO_CONTRIBUYENTE = "FPEQ";
        public static String TIPO_FACTURA_ESPECIAL = "FESP";
        public static String TIPO_NOTA_ABONO = "NABN";
        public static String TIPO_RECIBO_DONACION = "RDON";
        public static String TIPO_RECIBO = "RECI";
        public static String TIPO_NOTA_DEBITO = "NDEB";
        public static String TIPO_NOTA_CREDITO = "NCRE";
    }
}