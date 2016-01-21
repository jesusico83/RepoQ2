using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentosVentas
{
    class GruposCondicionesConsultaCtx
    {
        public GruposCondicionesConsultaDBDataContext GruposCondicionesConsultaDataCtx = new GruposCondicionesConsultaDBDataContext();

        public List<GRUPOS_DESCUENTOS_CONResult> grupos_lista;
        public void GRUPOS_DESCUENTOS_CON(string usu_id)
        {
            grupos_lista = GruposCondicionesConsultaDataCtx.GRUPOS_DESCUENTOS_CON(0, usu_id).ToList();
        }
    }
}
