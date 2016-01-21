using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Almacen.odts
{
    public class ArticuloModelo : Articulo
    {
        public bool EsHibrido { get; set; }
        public string ArtiDeterminaciones { get; set; }
        public string ArtiMetodologia { get; set; }


        public override bool Equals(object obj)
        {
            ArticuloModelo a = (ArticuloModelo)obj;            
            return a.ArtiId1 == this.ArtiId1;
        }
    }
}
