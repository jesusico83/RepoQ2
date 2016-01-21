using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentosVentas.odts
{
    public class PresupuestoVenta
    {
        public string Documento { get; set; }
        public string Numero { get; set; }
        public string Estado { get; set; }
        public string Fecha { get; set; }
        public int ClieId { get; set; }
        public string Cliente { get; set; }
        public string Referencia { get; set; }
        public string Emisor { get; set; }
        public string Gestor { get; set; }
        public decimal Base { get; set; }
        public string FechaValidez { get; set; }
        public int NumeroAdjuntos { get; set; }
        public string FechaMaxima { get; set; }
        public short? Potencial { get; set; }
    }
}
