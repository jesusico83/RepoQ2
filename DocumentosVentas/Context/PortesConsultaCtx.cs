using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentosVentas
{
    class PortesConsultaCtx
    {
        private PortesConsultaDBDataContext PortesConsultaDataCtx = new PortesConsultaDBDataContext();

        public List<TIPOS_PORTE_CONResult> tipos_porte;
        public void TIPOS_PORTE_CON(string usu_id)
        {
            tipos_porte = PortesConsultaDataCtx.TIPOS_PORTE_CON(0, usu_id).ToList();
        }
    }
}
