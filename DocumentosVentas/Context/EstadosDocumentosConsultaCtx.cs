using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentosVentas
{
    class EstadosDocumentosConsultaCtx
    {
        public EstadosDocumentoConsultaDBDataContext EstadosDocumentosConsultaDataCxt = new EstadosDocumentoConsultaDBDataContext();
        public List<DOCUMENTOS_ESTADOS_CONResult> estados;

        public void CON(string usu_id, string docu_id)
        {
            this.estados = EstadosDocumentosConsultaDataCxt.DOCUMENTOS_ESTADOS_CON(0, usu_id, docu_id).ToList();
        }
    }
}
