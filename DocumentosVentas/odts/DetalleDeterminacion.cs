using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentosVentas.odts
{
    public class DetalleDeterminacion : PresupuestoVentaDetalle
    {
        public override string TipoLinea
        {
            get
            {
                return "N+";
            }
            set
            {
            }
        }

        public DetalleDeterminacion Copia(int linea)
        {
            DetalleDeterminacion p = new DetalleDeterminacion();

            p.Linea = linea;
            p.Sublinea = this.Sublinea;
            p.ArtiId1 = this.ArtiId1;
            p.DetalleDescripcion = this.DetalleDescripcion;
            p.Cantidad = this.Cantidad;
            p.UnidadId = this.UnidadId;
            p.UnidadDescripcion = this.UnidadDescripcion;
            p.Precio = this.Precio;
            p.DescuentoId = this.DescuentoId;
            p.DescuentoDescripcion = this.DescuentoDescripcion;

            return p;
        }

        public override bool Equals(object obj)
        {
            DetalleDeterminacion d = (DetalleDeterminacion)obj;
            return this.ArtiId1 == d.ArtiId1;
        }
    }
}
