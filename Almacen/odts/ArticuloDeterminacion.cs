using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Almacen.odts
{
    public class ArticuloDeterminacion : Articulo
    {
        public string ArtiDeterminaciones { get; set; }
        public string ArtiMetodologia { get; set; }
        public string TipoArticulo { get; set; }


        public override bool Equals(object obj)
        {
            ArticuloDeterminacion a = (ArticuloDeterminacion)obj;
            return a.ArtiId1 == this.ArtiId1;
        }
    }
}
