using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentosVentas
{
    class LineasDocumentoConsultaCtx
    {
        public LineasDocumentoConsultaDBDataContext LineasDocumentoConsultaDataCtx = new LineasDocumentoConsultaDBDataContext();
        public List<DOCUMENTOS_LINEAS_CONResult> lineas;

        public void DOCUMENTOS_LINEAS_CON(string usu_id, string docu_id)
        {
            lineas = LineasDocumentoConsultaDataCtx.DOCUMENTOS_LINEAS_CON(0, usu_id, docu_id).ToList();
        }
    }
}
