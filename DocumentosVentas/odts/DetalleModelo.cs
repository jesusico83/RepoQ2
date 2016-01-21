using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentosVentas.odts
{
    public class DetalleModelo : PresupuestoVentaDetalle
    {
        public override string TipoLinea
        {
            get
            {
                return "N";
            }
            set
            {
            }
        }
        private List<DetalleDeterminacion> _Determinaciones = new List<DetalleDeterminacion>();
        public List<DetalleDeterminacion> Determinaciones
        {
            get
            {
                return _Determinaciones;
            }
            set
            {
                this._Determinaciones = value;
            }
        }

        public DetalleModelo Copia(int linea)
        {
            DetalleModelo p = new DetalleModelo();

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
            foreach (odts.DetalleDeterminacion d in this.Determinaciones)
            {
                p.Determinaciones.Add(d.Copia(linea));
            }

            return p;
        }

    }
}
