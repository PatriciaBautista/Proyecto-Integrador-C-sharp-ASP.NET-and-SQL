using capaEntidad;
using Grupo05_ProyectoWendy.Datos;
using Grupo05_ProyectoWendy.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using System.IO;
using Image = iText.Layout.Element.Image;
using Table = iText.Layout.Element.Table;
using Style = iText.Layout.Style;

namespace Grupo05_ProyectoWendy.Controllers
{
    public class DatosCompletosController : Controller
    {
        private DatosCompletosRepository repository;

        public DatosCompletosController()
        {
            repository = new DatosCompletosRepository();
        }

        //método de la vista mostrarDatos de las tablas relacionadas
        public ActionResult MostrarDatosCompletos(string identificador)
        {
            // Obtiene los datos completos de las tres tablas
            DatosCompletos datosCompletos = repository.ObtenerDatosCompletos();
            if (!string.IsNullOrEmpty(identificador))
            {
                //me filtra los datos de la lista datos completos
                datosCompletos.Empleados = datosCompletos.Empleados.Where(e => e.identificadorPersonal.Contains(identificador)).ToList();
            }
            // Pasa los datos a la vista
            return View(datosCompletos);
        }

        //inicia la vista y método de detalles del empleado relación de tablas
        public ActionResult Detalles(string id, int parametro1, int parametro2)
        {
            // Obtiene los datos completos de las tres tablas
            DatosCompletos datosCompletos = repository.ObtenerDatosCompletos();

            if (datosCompletos == null)
            {
                // Si no se obtienen los datos completos, redirecciona a la vista "MostrarDatosCompletos" o muestra un mensaje de error
                return RedirectToAction("MostrarDatosCompletos");
            }

            // Busca el empleado con el identificador proporcionado
            EmpleadoWendy empleado = datosCompletos?.Empleados.FirstOrDefault(e => e.identificadorPersonal == id);

            if (empleado == null)
            {
                // Si no se encuentra el empleado, redirecciona a la vista "MostrarDatosCompletos" o muestra un mensaje de error
                return RedirectToAction("MostrarDatosCompletos");
            }

            // Busca la dirección del empleado mediante la relación en la tabla empleadoWendy

            // Busca la dirección del empleado mediante la relación en la tabla empleadoWendy
            DireccionEmpleado direccion = datosCompletos?.Direccion.FirstOrDefault(d => d.idDireccion == parametro1);


            // Busca el detalle laboral del empleado mediante la relación en la tabla empleadoWendy
            DetallesLaborales detalle = datosCompletos?.DetalleLaboral.FirstOrDefault(d => d.idDetalleLaboral == parametro2);

            // Crea un objeto de la clase DatosCompletosEmpleado y asigna los valores correspondientes
            DatosCompletosEmpleado datosCompletosEmpleado = new DatosCompletosEmpleado
            {
                identificadorPersonal = empleado != null ? empleado.identificadorPersonal : string.Empty,
                nombreEmpleado = empleado != null ? empleado.nombreEmpleado : string.Empty,
                cargoEmpleado = empleado != null ? empleado.cargoEmpleado : string.Empty,
                monto = empleado != null ? empleado.monto : 0,
                edadEmpleado = empleado != null ? empleado.edadEmpleado : 0,
                paisEmpleado = direccion != null ? direccion.paisEmpleado : string.Empty,
                sucursalEmpleado = direccion != null ? direccion.sucursalEmpleado : string.Empty,
                estado = direccion != null ? direccion.estado : string.Empty,
                fechaIngreso = detalle != null ? detalle.fechaIngreso : string.Empty,
                fechaRenuncia = detalle != null ? detalle.fechaRenuncia : string.Empty,
                tipoContrato = detalle != null ? detalle.tipoContrato : string.Empty,
                fechaEmision = detalle.fechaEmision
            };

            // Pasa el objeto DatosCompletosEmpleado a la vista "Detalles"
            return View(datosCompletosEmpleado);
        }

        //Metodo que genera el documento de anticipo de indemnizacion en formato PDF
        [HttpPost]
        public ActionResult PDF(string Identificador, string nombre, string cargo, string monto, string edad, string pais, string sucursal, string estado, string fechaIngreso,
       string fechaRenuncia, string tipoContrato, string fechaEmision)
        {
            //Creacion del documento PDF
            MemoryStream ms = new MemoryStream();
            PdfWriter pw = new PdfWriter(ms);
            PdfDocument pdfDocument = new PdfDocument(pw);
            Document doc = new Document(pdfDocument, PageSize.LETTER);


            //Colocar imagen
            string logo = Server.MapPath("/Imagenes/Logo2.png");
            ImageData data = ImageDataFactory.Create(logo);
            Image log = new Image(data);
            log.ScaleAbsolute(75, 75);

            PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

            //Creacion de una tabla de 2 columnas y una fila para el logo y descripcion
            Table tabla = new Table(2).UseAllAvailableWidth();
            Cell cell = new Cell(2, 1).Add(log).SetBorder(Border.NO_BORDER);
            tabla.AddCell(cell);
            cell = new Cell(2, 1).Add(new Paragraph("Documento de Anticipo de Indemnizacion").SetMargins(20, 0, 0, 50)).Add(new Paragraph(" ")).Add(new Paragraph("      Tipo de contrato: " + tipoContrato).SetMargins(20, 0, 0, 50)).SetBorder(Border.NO_BORDER).SetFont(font);
            tabla.AddCell(cell);

            //Agregamos la tabla al documento
            doc.Add(tabla);

            Style styleText = new Style().SetMarginLeft(100);

            Paragraph parrafo = new Paragraph("\n" + nombre + ", de ").Add(edad).Add(" años de edad, Empresario, del domicilio ").Add(estado + ", " + pais).Add(" , con Documento Único de Identidad número ").Add(Identificador).Add(", hago constar:\n" +
                "\n I.Que he venido trabajando en forma continua e ininterrumpida para la Empresa de comidas rápidas Wendy, desde la fecha ").Add(fechaIngreso).Add(" , hasta el ").Add(fechaRenuncia).Add(" , desempeñando el cargo de ").Add(cargo).Add("\n" +
                "\nII.Que no obstante existir contrataciones periódicas en la empresa, como he manifestado y se me ha liquidado año con año, hago constar que en esta oportunidad recibo como en años anteriores mi correspondiente liquidación anual por mera liberalidad de la empresa, y demás prestaciones laborales correspondientes a la fecha, la cual acepto voluntariamente y a mi entera satisfacción, por la suma de $").Add(monto).Add(", como consta en el recibo de pago correspondiente, del periodo ").Add(fechaIngreso + " al " + fechaRenuncia).Add("\n" +
                "\nIII.Por tanto, declaro que el pago correspondiente a mi antigüedad laboral a cargo de La Empresa Wendy, por el periodo antes mencionado queda debidamente cancelado POR MERA LIBERALIDAD DE LA SOCIEDAD, de conformidad a la legislación vigente laboral, no teniendo nada que reclamar de mi parte a la misma en dicho concepto, por haber recibido dicho pago a mi entera satisfacción, de conformidad con la Ley.Por consiguiente, declaro a la Empresa de comidas rápidas Wendy, así como a cualquier persona natural o jurídica que pudiera haberse visto involucrada en mi prestación de servicios con la referida Sociedad libre y solvente de cualquier reclamo de índole laboral en relación al pago de mi antigüedad a esta fecha, por los servicios prestados durante el período señalado y por las contrataciones anteriores, otorgo, por tanto, el más amplio y completo finiquito a favor de la Empresa Wendy.\n" +
                "\nIV.Autorizo expresamente y en forma voluntaria a la Empresa Wendy, para que, en caso que mi contrato de trabajo se diere por terminado por causa imputable a la Sociedad, o por cualquier causa que implique un pago a mi persona como en caso de apegarme a la Ley de la Prestación Económica por Retiro Voluntario o muerte, descuente irrevocablemente del pago que me corresponda a la fecha del suceso, de conformidad con la legislación vigente, la suma, que he recibido a mi entera satisfacción hasta esta fecha en concepto de liquidaciones anuales desde mi fecha original de ingreso a la empresa.\n\n\n" +
                "\n\n\n\nV.Por lo anterior hago constar que quedarán únicamente pendiente de pago, las cantidades de dinero correspondientes a la antigüedad que no han sido canceladas y que se han acreditado posteriormente al período señalado que me ha sido cancelado desde la fecha de mi ingreso ").Add(fechaIngreso).Add(", hasta la fecha de finalizacion ").Add(fechaRenuncia).Add("\n" +
                "\nVI.Que he recibido en concepto de liquidación anual y por mera liberalidad de La Sociedad, las sumas de dinero consignadas en el presente documento en concepto de indemnización anual y demás prestaciones laborales correspondientes a la fecha. En fe de lo mencionado con anterioridad, firmo en el pais ").Add(pais + ", en la " + sucursal).Add(", a los ____ dias del mes de ___________ del año __________.\n" +



                "\n\n\n__________________________________________\n");

            Paragraph inter = new Paragraph("Trabajador(a)\n ").AddStyle(styleText);

            doc.Add(parrafo);
            doc.Add(inter);
            doc.Add(new AreaBreak()); // Salto de linea 
            doc.Add(new Paragraph(
            "\n\nEn el ").Add(pais + " de la " + sucursal).Add(", a las ___________________horas y ______________________ minutos, del día ______________________del mes de ____________________ del año ______.Ante mí, _____________________________, Notario, del domicilio de __________________________________, comparece,").Add(nombre).Add(", de ______ años de edad, Empleado, del domicilio").Add(estado + "," + pais).Add(", persona a quien conozco e identifico por medio de su Documento Único de Identidad número ").Add(Identificador).Add(", Y ME DICE: Que reconoce como suya la firma que calza en el anterior documento, por haberla puesto de su puño y letra, así como las declaraciones contenidas en el mismo, el cual está redactado de conformidad con su voluntad y el cual literalmente dice:\n" +
"\n“I.Que he venido trabajando en forma continua e ininterrumpida para la Empresa de comidas rápidas_________.en adelante La Sociedad, desde la fecha ").Add(fechaIngreso + " hasta el " + fechaRenuncia).Add(", desempeñando el cargo de ____________________________________. \n" +
"\nII.Que no obstante existir contrataciones periódicas en la empresa, como he manifestado y se me ha liquidado año con año, hago constar que en esta oportunidad recibo como en años anteriores mi correspondiente liquidación anual por mera liberalidad de la empresa, y demás prestaciones laborales correspondientes a la fecha, la cual acepto voluntariamente y a mi entera satisfacción, por la suma de ______________, como consta en el recibo de pago correspondiente, del período del").Add(fechaIngreso + " hasta el " + fechaRenuncia).Add("\n" +
"\nIII.Por tanto declaro que el pago correspondiente a mi antigüedad laboral a cargo de La Empresa Wendy________________________________________, por el periodo antes mencionado queda debidamente cancelado POR MERA LIBERALIDAD DE LA SOCIEDAD, de conformidad a la legislación vigente laboral, no teniendo nada que reclamar de mi parte a la misma en dicho concepto, por haber recibido dicho pago a mi entera satisfacción, de conformidad con la Ley. Por consiguiente, declaro a la Sociedad __________________así como a cualquier persona natural o jurídica que pudiera haberse visto involucrada en mi prestación de servicios con la referida Sociedad libre y solvente de cualquier reclamo de índole laboral en relación al pago de mi antigüedad a esta fecha, por los servicios prestados durante el período señalado y por las contrataciones anteriores, otorgo por tanto, el más amplio y completo finiquito a favor de la Sociedad ____________________________________________________.\n\n\n" +
"\n\n\n\n\nIV.Autorizo expresamente y en forma voluntaria a la Sociedad____________________, para que, en caso que mi contrato de trabajo se diere por terminado por causa imputable a la Sociedad, o por cualquier causa que implique un pago a mi persona como en caso de apegarme a la Ley de la Prestación Económica por Retiro Voluntario o muerte, descuente irrevocablemente del pago que me corresponda a la fecha del suceso, de conformidad con la legislación vigente, la suma, que he recibido a mi entera satisfacción hasta esta fecha en concepto de liquidaciones anuales desde mi fecha original de ingreso a la empresa.\n" +
"\nV.Por lo anterior hago constar que quedarán únicamente pendiente de pago, las cantidades de dinero correspondientes a la antigüedad que no han sido canceladas y que se han acreditado posteriormente al período señalado que me ha sido cancelado desde la fecha de mi ingreso hasta el ").Add(fechaRenuncia).Add("\n" +
"\nVI.Que he recibido en concepto de liquidación anual y por mera liberalidad de La Sociedad, las sumas de dinero consignadas en el presente documento en concepto de indemnización anual y demás prestaciones laborales correspondientes a la fecha. En fe de lo cual firmo en la Ciudad de ").Add(estado + " del pais " + pais).Add(", a los _______________días del mes de ___________ de dos mil _____________________________________.”.\n" +
"\nY Yo el / la suscrito / a Notario, DOY FE, que la referida firma es Autentica, por haber sido puesta a mi presencia por el compareciente, quien además la reconoció en los términos expresados.Así se expresó el compareciente, a quien expliqué los efectos legales de esta acta notarial que consta de dos hojas útiles, y leído que se la hube íntegramente en un solo acto sin interrupción, ratifica su contenido por estar redactado conforme a su voluntad y firmamos.DOY FE.\n" +


"\n\n_____________________________          ___________________________\n"));

            //Interlineado a los campos para firmas
            Paragraph inter2 = new Paragraph("Trabajador/a                                                   Notario").SetMarginLeft(40);
            doc.Add(inter2);
            // doc.SetMargins(75, 35, 70, 35);
            doc.Add(new Paragraph(


)
                .SetFontColor(ColorConstants.BLACK)
                /*.SetFont(font).SetFontSize(12)*/);

            doc.Close();

            byte[] bytesStream = ms.ToArray();
            ms = new MemoryStream();
            ms.Write(bytesStream, 0, bytesStream.Length);
            ms.Position = 0;

            return new FileStreamResult(ms, "application/pdf");
        }
    }
}