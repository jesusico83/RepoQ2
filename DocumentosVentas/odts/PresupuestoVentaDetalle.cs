using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentosVentas.odts
{
    public abstract class PresupuestoVentaDetalle
    {
        public abstract string TipoLinea { get; set; }
        public int Linea { get; set; }
        public int Sublinea { get; set; }
        public int ArtiId1 { get; set; }
        public string DetalleDescripcion { get; set; }
        public decimal Cantidad { get; set; }
        public string UnidadId { get; set; }
        public string UnidadDescripcion { get; set; }
        public decimal Precio { get; set; }
        public int? DescuentoId { get; set; }
        public string DescuentoDescripcion { get; set; }
        public string Estado
        {
            get
            {
                return "N";
            }
            set
            {
            }
        }
        public int ComportamientoIVA { get; set; }
        public string ArtiDeterminaciones { get; set; }
        public string ArtiPNTMetodologia { get; set; }
        public int DepartamentoId { get; set; }        
    }
}
