using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FELFactura
{
    public class Utils
    {

        public static string replace(string valor )
        {


            valor = valor.ToUpper().Replace("Ñ", "N");

            return valor;
        }


    }
}