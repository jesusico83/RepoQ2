using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentosVentas
{
    class ArticulosConsultaCtx
    {
        public ArticulosConsultaDBDataContext ArticulosConsultaDataCtx = new ArticulosConsultaDBDataContext();
        public List<ARTICULOS_CON_Q2Result> articulos_lista;

        public void CON(string arti_descripcion, string tipar_id)
        {
            this.articulos_lista = ArticulosConsultaDataCtx.ARTICULOS_CON_Q2(arti_descripcion, tipar_id).ToList();
        }
    }
}
