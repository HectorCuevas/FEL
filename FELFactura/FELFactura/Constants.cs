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
        public static String URL_VAIDAR_DOCUMENTO = "https://dev.api.ifacere-fel.com/fel-dte-services/api/validarDocumento";
        public static String URL_ANULAR_DOCUMENTO = "https://dev.api.ifacere-fel.com/fel-dte-services/api/anularDocumentoXML";
        public static String URL_CERTIFICADO = "C:\\certificado\\3225607-61589fea042b4cfc.pfx";
        public static String URL_CERTIFICADO_CONTRASENIA = "MayaZac/49";
        public static String FRASE_2 = "1";
        public static String FRASE_1 = "1";
        public static String FRASE_CODIGO_2 = "2";
        public static String FRASE_CODIGO_1= "1";
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