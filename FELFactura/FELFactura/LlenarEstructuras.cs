using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data;
using Modelos;

namespace FELFactura
{
    public class LlenarEstructuras
    {

        public static void DatosGenerales(DataSet dstcompanyxml, DatosGenerales datosGenerales)
        {

            foreach (DataRow reader in dstcompanyxml.Tables[0].Rows)
            {
                var CodigoMoneda = reader["codigomoneda"];
                if (CodigoMoneda != null)
                {
                    datosGenerales.CodigoMoneda = CodigoMoneda.ToString();

                }

                var NumeroAcceso = reader["numeroaccesso"];
                if (NumeroAcceso != null)
                {
                    datosGenerales.NumeroAcceso = NumeroAcceso.ToString();

                }


                datosGenerales.Tipo = Constants.TIPO_FACTURA;




            }

        }



    }
}