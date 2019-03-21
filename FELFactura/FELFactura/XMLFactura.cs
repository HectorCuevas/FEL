using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

using System.Xml.Linq;
using System.IO;
using System.Data;
using Modelos;
using Firma;
namespace FELFactura
{
    public class XMLFactura
    {
        private DataSet dstcompanyxml = new DataSet();
        private DataSet dstinvoicexml = new DataSet();
        private DataSet dstdetailinvoicexml = new DataSet();
        private DatosGenerales datosGenerales = new DatosGenerales();
        private Emisor emisor = new Emisor();
        private Receptor receptor = new Receptor();
        private List<Item> items = new List<Item>();
        private Totales totales = new Totales();
        string v_rootxml ="";
        string fac_num = "";
        public String getXML(string XMLCompany, string XMLInvoice, string XMLDetailInvoce, string path, string fac_num)
        {
            v_rootxml = path;
            this.fac_num = fac_num;
            //convertir a dataset los string para mayor manupulacion
            XmlToDataSet( XMLCompany, XMLInvoice,  XMLDetailInvoce);
            //llenar estructuras
            ReaderDataset();
            //armar xml
            getXML();
            //firmar xml por certificado
            v_rootxml = v_rootxml + @"\" + fac_num.Trim() + ".xml";

            XmlDocument myXML = FirmaDocumento.FirmarDocumento(Constants.URL_CERTIFICADO, Constants.URL_CERTIFICADO_CONTRASENIA, path, fac_num.Trim() + ".xml",  path);
            return myXML.ToString();

        }


        //Convertir XML a DataSet
        private bool XmlToDataSet(string XMLCompany, string XMLInvoice, string XMLDetailInvoce)
        {
            try
            {
                //Conviertiendo XML a DataSet Empresa y factura
                System.IO.StringReader rdpymesxml = new System.IO.StringReader(XMLCompany);
                dstcompanyxml.ReadXml(rdpymesxml);
                //Conviertiendo XML a DataSet Empresa
             
                //Convieriendo XMl a DataSet Factura
                System.IO.StringReader rdinvoice = new System.IO.StringReader(XMLInvoice);
                dstinvoicexml.ReadXml(rdinvoice);

                //Convieritiendo XML a DataSet Detalle Factura
                System.IO.StringReader rddetailinvoice = new System.IO.StringReader(XMLDetailInvoce);
                dstdetailinvoicexml.ReadXml(rddetailinvoice);
                return true;
            }
            catch (Exception ex)
            {
                //DecodingResponse("Se produjo un error en la conversion de XML a DataSet. Verifique que la estrucutra del " +
                //              "XMl este bien estructurado para su conversion.\n'" + ex.Message.ToString(), "", 1);
                return false;
            }
        }


        //Lectura de Documentos
        private bool ReaderDataset()
        {

            LlenarEstructuras.DatosGenerales(dstcompanyxml,datosGenerales);
            DatosEmisor();
            DatosReceptor();
            DatosItems();
           return false;
        }

        private void DatosGenerales()
        {
            foreach (DataRow reader in dstcompanyxml.Tables[0].Rows)
            {
                var CodigoMoneda = reader["codigomoneda"];
                if (CodigoMoneda != null)
                {
                    this.datosGenerales.CodigoMoneda = CodigoMoneda.ToString();

                }
       
                var NumeroAcceso = reader["numeroaccesso"];
                if (NumeroAcceso != null)
                {
                    this.datosGenerales.NumeroAcceso = NumeroAcceso.ToString();

                }

       
                this.datosGenerales.Tipo = Constants.TIPO_FACTURA;




            }

        }


        private void DatosEmisor()
        {
            foreach (DataRow reader in dstcompanyxml.Tables[0].Rows)
            {
                var AfiliacionIVA = reader["afiliacioniva"];
                if (AfiliacionIVA != null)
                {
                    this.emisor.AfiliacionIVA = AfiliacionIVA.ToString();

                }
                var CodigoEstablecimiento = reader["codigoestablecimiento"];
                if (CodigoEstablecimiento != null)
                {
                    this.emisor.CodigoEstablecimiento = CodigoEstablecimiento.ToString();

                }
                var CorreoEmisor = reader["correoemisor"];
                if (CorreoEmisor != null)
                {
                    this.emisor.CorreoEmisor = CorreoEmisor.ToString();

                }

                var NITEmisor = reader["nitemisor"];
                if (NITEmisor != null)
                {
                    this.emisor.NITEmisor = NITEmisor.ToString();

                }
                var NombreComercial = reader["nombrecomercial"];
                if (NombreComercial != null)
                {
                    this.emisor.NombreComercial = NombreComercial.ToString();

                }
                var NombreEmisor = reader["nombreemisor"];
                if (NombreEmisor != null)
                {
                    this.emisor.NombreEmisor = NombreEmisor.ToString();

                }
                var Direccion = reader["direccion"];
                if (Direccion != null)
                {
                    this.emisor.Direccion = Direccion.ToString();

                }
                var CodigoPostal = reader["codigopostal"];
                if (CodigoPostal != null)
                {
                    this.emisor.CodigoPostal = CodigoPostal.ToString();

                }
                var Municipio = reader["municipio"];
                if (Municipio != null)
                {
                    this.emisor.Municipio = Municipio.ToString();

                }
                var Departamento = reader["departamento"];
                if (Departamento != null)
                {
                    this.emisor.Departamento = Departamento.ToString();


                }
                var Pais = reader["pais"];
                if (Pais != null)
                {
                    this.emisor.Pais = Pais.ToString();


                }
            
        
        }

    }


        private void DatosReceptor()
        {
            foreach (DataRow reader in dstinvoicexml.Tables[0].Rows)
            {

                var FechaHoraEmision = reader["fec_emis"];
                if (FechaHoraEmision != null)
                {
                    this.datosGenerales.FechaHoraEmision = FechaHoraEmision.ToString();

                }

                var CorreoReceptor = reader["correoreceptor"];
                if (CorreoReceptor != null)
                {
                    this.receptor.CorreoReceptor = CorreoReceptor.ToString();

                }
                var IDReceptor = reader["idreceptor"];
                if (IDReceptor != null)
                {
                    this.receptor.IDReceptor = IDReceptor.ToString();

                }
                var NombreReceptor = reader["nombrereceptor"];
                if (NombreReceptor != null)
                {
                    this.receptor.NombreReceptor = NombreReceptor.ToString();

                }

                var Direccion = reader["direccion"];
                if (Direccion != null)
                {
                    this.emisor.Direccion = Direccion.ToString();

                }
                var CodigoPostal = reader["codigopostal"];
                if (CodigoPostal != null)
                {
                    this.emisor.CodigoPostal = CodigoPostal.ToString();

                }
                var Municipio = reader["municipio"];
                if (Municipio != null)
                {
                    this.emisor.Municipio = Municipio.ToString();

                }
                var Departamento = reader["departamento"];
                if (Departamento != null)
                {
                    this.emisor.Departamento = Departamento.ToString();

                }
                var Pais = reader["pais"];
                if (Pais != null)
                {
                    this.emisor.Pais = Pais.ToString();

                }
              
            }

        }
        private void DatosItems()
        {
            foreach (DataRow reader in dstdetailinvoicexml.Tables[0].Rows)
            {
                Item item = new Item();
                Impuesto impuesto = new Impuesto();
                //impuesto
                var impuestonombrecorto = reader["impuestonombrecorto"];
                if (impuestonombrecorto != null)
                {
                    impuesto.NombreCorto = impuestonombrecorto.ToString();

                }
                var codigounidadgravable = reader["codigounidadgravable"];
                if (codigounidadgravable != null)
                {
                    impuesto.CodigoUnidadGravable = codigounidadgravable.ToString();

                }
                var montoimpuesto = reader["montoimpuesto"];
                if (montoimpuesto != null)
                {
                    impuesto.MontoImpuesto = montoimpuesto.ToString();

                }
                var montogravable = reader["montogravable"];
                if (montogravable != null)
                {
                    impuesto.MontoGravable = montogravable.ToString();

                }
                //item en general
                var bienoservicio = reader["bienoservicio"];
                if (bienoservicio != null)
                {
                    item.BienOServicio= bienoservicio.ToString();

                }
                var descripcion = reader["descripcion"];
                if (descripcion != null)
                {
                    item.Descripcion = descripcion.ToString();

                }
                var numerolinea = reader["numerolinea"];
                if (numerolinea != null)
                {
                    item.NumeroLinea = numerolinea.ToString();

                }
                var cantidad = reader["cantidad"];
                if (cantidad != null)
                {
                    item.Cantidad = cantidad.ToString();

                }

                var precio = reader["precio"];
                if (precio != null)
                {
                    item.Precio = precio.ToString();

                }
                var preciounitario = reader["preciounitario"];
                if (preciounitario != null)
                {
                    item.PrecioUnitario = preciounitario.ToString();

                }

                var total = reader["total"];
                if (total != null)
                {
                    item.Total = total.ToString();

                }

                var descuento = reader["descuento"];
                if (descuento != null)
                {
                    item.Descuento = descuento.ToString();

                }

            }
        }

           private String getXML()
        {
            XNamespace dte = XNamespace.Get("http://www.sat.gob.gt/dte/fel/0.1.0");
            XNamespace xd = XNamespace.Get("http://www.w3.org/2000/09/xmldsig#");
            //Encabezado del Documento
            XDeclaration declaracion = new XDeclaration("1.0", "utf-8", "no");

            //GTDocumento
            XElement parameters = new XElement(dte + "GTDocumento",
                            new XAttribute(XNamespace.Xmlns + "dte", dte.NamespaceName),
                           new XAttribute(XNamespace.Xmlns + "xd", xd.NamespaceName),
                           new XAttribute("Version", "0.4"));
            //SAT
            XElement SAT = new XElement(dte + "SAT", new XAttribute("ClaseDocumento", "dte"));
            parameters.Add(SAT);

            // formando dte
            XElement DTE = new XElement(dte + "DTE", new XAttribute("ID", "DatosCertificados"));
            SAT.Add(DTE);

            //datos de emision
            XElement DatosEmision = new XElement(dte + "DatosEmision", new XAttribute("ID", "DatosEmision"));
            DTE.Add(DatosEmision);

            //datos generales
            XElement DatosGenerales = new XElement(dte + "DatosGenerales", new XAttribute("CodigoMoneda", this.datosGenerales.CodigoMoneda), 
                new XAttribute("FechaHoraEmision", this.datosGenerales.FechaHoraEmision), new XAttribute("NumeroAcceso", this.datosGenerales.NumeroAcceso), new XAttribute("Tipo", this.datosGenerales.Tipo));
            DatosEmision.Add(DatosGenerales);

            //datos emisor
            XElement Emisor = new XElement(dte + "Emisor", new XAttribute("AfiliacionIVA", this.emisor.AfiliacionIVA),
                new XAttribute("CodigoEstablecimiento", this.emisor.CodigoEstablecimiento), 
                new XAttribute("CorreoEmisor", this.emisor.CorreoEmisor), new XAttribute("NITEmisor", this.emisor.NITEmisor), 
                new XAttribute("NombreComercial", this.emisor.NombreComercial), new XAttribute("NombreEmisor", this.emisor.NombreEmisor));
            DatosEmision.Add(Emisor);
            //direccion del emisor
            XElement DireccionEmisor = new XElement(dte + "DireccionEmisor");
            Emisor.Add(DireccionEmisor);
            //elementos dentro de direccion de emisor, dirección, codigopostal, municipio, departamento, pais
            XElement Direccion = new XElement(dte + "Direccion", this.emisor.Direccion);
            XElement CodigoPostal = new XElement(dte + "CodigoPostal", this.emisor.CodigoPostal);
            XElement Municipio = new XElement(dte + "Municipio", this.emisor.Municipio);
            XElement Departamento = new XElement(dte + "Departamento", this.emisor.Departamento);
            XElement Pais = new XElement(dte + "Pais", this.emisor.Pais);
            DireccionEmisor.Add(Direccion);
            DireccionEmisor.Add(CodigoPostal);
            DireccionEmisor.Add(Municipio);
            DireccionEmisor.Add(Departamento);
            DireccionEmisor.Add(Pais);

            //datos Receptor
            XElement Receptor = new XElement(dte + "Receptor", new XAttribute("CorreoReceptor", this.receptor.CorreoReceptor), 
                new XAttribute("IDReceptor", this.receptor.IDReceptor),
                new XAttribute("NombreReceptor", this.receptor.NombreReceptor));
            DatosEmision.Add(Receptor);
            //direccion del receptor
            XElement DireccionReceptor = new XElement(dte + "DireccionReceptor");
            Receptor.Add(DireccionReceptor);
            //elementos dentro de direccion de emisor, dirección, codigopostal, municipio, departamento, pais
            XElement DireccionRecp = new XElement(dte + "Direccion", this.receptor.Direccion);
            XElement CodigoPostalReceptor = new XElement(dte + "CodigoPostal", this.receptor.CodigoPostal);
            XElement MunicipioReceptor = new XElement(dte + "Municipio", this.receptor.Municipio);
            XElement DepartamentoReceptor = new XElement(dte + "Departamento", this.receptor.Departamento);
            XElement PaisReceptor = new XElement(dte + "Pais", this.receptor.Pais);
            DireccionReceptor.Add(DireccionRecp);
            DireccionReceptor.Add(CodigoPostalReceptor);
            DireccionReceptor.Add(MunicipioReceptor);
            DireccionReceptor.Add(DepartamentoReceptor);
            DireccionReceptor.Add(PaisReceptor);

            //frases
            XElement Frases = new XElement(dte + "Frases");
            DatosEmision.Add(Frases);
            XElement Frase1 = new XElement(dte + "Frase", new XAttribute("CodigoEscenario", "1"), new XAttribute("TipoFrase", Constants.FRASE));
            Frases.Add(Frase1);


            // detalle de factura 

            XElement Items = new XElement(dte + "Items");
            DatosEmision.Add(Items);
            if (this.items!=null) {
                foreach (Item item in this.items) {
                    //Items


                    //item
                    XElement Item = new XElement(dte + "Item", new XAttribute("BienOServicio", item.BienOServicio), new XAttribute("NumeroLinea", item.NumeroLinea));
                    XElement Cantidad = new XElement(dte + "Cantidad", item.Cantidad);
                    XElement UnidadMedida = new XElement(dte + "UnidadMedida", item.UnidadMedida);
                    XElement Descripcion = new XElement(dte + "Descripcion", item.Descripcion);
                    XElement PrecioUnitario = new XElement(dte + "PrecioUnitario", item.PrecioUnitario);
                    XElement Precio = new XElement(dte + "Precio", item.Precio);
                    XElement Descuento = new XElement(dte + "Descuento", item.Descuento);
                    XElement TotalItem = new XElement(dte + "Total", item.Total);
                    //impuestos
                    XElement Impuestos = new XElement(dte + "Impuestos");

                    Item.Add(Cantidad);
                    Item.Add(UnidadMedida);
                    Item.Add(Descripcion);
                    Item.Add(PrecioUnitario);
                    Item.Add(Precio);
                    Item.Add(Descuento);
                    Item.Add(Impuestos);
                    Item.Add(TotalItem);
                    Items.Add(Item);



                    //impuesto por item
                 if (item.impuestos != null) {
                        foreach (Impuesto im in item.impuestos) {
                            XElement Impuesto = new XElement(dte + "Impuesto");
                            XElement NombreCorto = new XElement(dte + "NombreCorto", im.NombreCorto);
                            XElement CodigoUnidadGravable = new XElement(dte + "CodigoUnidadGravable", im.CodigoUnidadGravable);
                            XElement MontoGravable = new XElement(dte + "MontoGravable", im.MontoGravable);
                            XElement CantidadUnidadesGravables = new XElement(dte + "CantidadUnidadesGravables", im.CantidadUnidadesGravables);
                            XElement MontoImpuesto = new XElement(dte + "MontoImpuesto", im.MontoImpuesto);
                            Impuesto.Add(NombreCorto);
                            Impuesto.Add(CodigoUnidadGravable);
                            Impuesto.Add(MontoGravable);
                            Impuesto.Add(CantidadUnidadesGravables);
                            Impuesto.Add(MontoImpuesto);
                            Impuestos.Add(Impuesto);
                        }                    
                 }
               }
            }
            //Totales
            XElement Totales = new XElement(dte + "Totales");
            DatosEmision.Add(Totales);

            //total impuestos
            XElement TotalImpuestos = new XElement(dte + "TotalImpuestos");
            XElement TotalImpuesto = new XElement(dte + "TotalImpuesto", new XAttribute("NombreCorto", "IVA"), new XAttribute("TotalMontoImpuesto", "5.40"));
            TotalImpuestos.Add(TotalImpuesto);
            Totales.Add(TotalImpuestos);

            //total general
            XElement GranTotal = new XElement(dte + "GranTotal", "64.50");
            Totales.Add(GranTotal);

            //datos del certificador
            XElement Certificacion = new XElement(dte + "Certificacion");
            XElement NITCertificador = new XElement(dte + "NITCertificador", "50510231");
            Certificacion.Add(NITCertificador);

            XElement NombreCertificador = new XElement(dte + "NombreCertificador", "Megaprint, S.A.");
            Certificacion.Add(NombreCertificador);

            XElement NumeroAutorizacion = new XElement(dte + "NumeroAutorizacion", new XAttribute("Numero", "2684359144"), new XAttribute("Serie", "9DD87A39"), "9DD87A39-A000-11E8-98D0-529269FB1459");
            Certificacion.Add(NumeroAutorizacion);

            XElement FechaHoraCertificacion = new XElement(dte + "FechaHoraCertificacion", "2018-08-14T12:00:00-06:00");
            Certificacion.Add(FechaHoraCertificacion);

            DTE.Add(Certificacion);



            XDocument myXML = new XDocument(declaracion, parameters);
            String res = myXML.ToString();


            try
            {
                v_rootxml = string.Format(@"{0}\{1}.xml", v_rootxml, fac_num.Trim());
                if (!File.Exists(v_rootxml))
                {
                    
                    myXML.Save(v_rootxml);
                }
                else
                {
                    System.IO.File.Delete(v_rootxml);
                    myXML.Save(v_rootxml);
                }
            }
            catch (Exception ex)
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + "docelec.txt";
                System.IO.File.WriteAllText(path, ex.Message);
            }
            return res;
        }
        }
}