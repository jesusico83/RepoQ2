using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;

namespace DocumentosVentas
{
    public class DocumentosConsultaCtx
    {
        public DocumentosConsultaDBDataContext DocumentosConsultaDataCtx = new DocumentosConsultaDBDataContext();
        public List<DOCUMENTOS_CON_TIPOSResult> tipos;

        public void CON(string usu_id, string tidoc_id)
        {
            this.tipos = DocumentosConsultaDataCtx.DOCUMENTOS_CON_TIPOS(0, usu_id, tidoc_id).ToList();            
        }
    }
}
