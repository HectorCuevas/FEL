using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FELFactura
{
    public class Instancia
    {
        static GetRequestToken wsRT = getInstancia();
        public static GetRequestToken getInstancia()
        {
            if (null == wsRT)
            {
                return new GetRequestToken();
            }

            return wsRT;

        }
        static RegisterDocument wsRD = getInstancia(1);
        public static RegisterDocument getInstancia(int num)
        {
            if (null == wsRD)
            {
                return new RegisterDocument();
            }

            return wsRD;

        }


    }
}