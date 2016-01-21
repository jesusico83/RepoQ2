using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentosVentas.odts
{
    public class PresupuestoVentaBloque
    {
        public int BloqueId { get; set; }
        public string FamilId { get; set; }
        public string FamilDescripcion { get; set; }
        public string Titulo { get; set; }
        public string ReferenciaCliente { get; set; }
        public string FechaCreacion { get; set; }

        public string DocuId { get; set; }
        public string PresuvId { get; set; }
        public string Cliente { get; set; }
        public string Estado { get; set; }

        public List<PresupuestoVentaDetalle> Detalle { get; set; }
    }
}
