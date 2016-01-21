using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentosVentas.odts
{
    public class TextoInterno
    {
        public string Texto { get; set; }
        public int ArtiId1 { get; set; }


        public override string ToString()
        {
            return Texto;
        }
    }
}
