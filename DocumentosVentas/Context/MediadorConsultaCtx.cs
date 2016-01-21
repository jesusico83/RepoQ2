using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentosVentas
{
    class MediadorConsultaCtx
    {
        public MediadoresConsultaDBDataContext MediadoresConsultaDataCtx = new MediadoresConsultaDBDataContext();
        public List<CLIENTES_MEDIADOR_SELResult> clientes_mediadorLista;
        public void SEL(string usu_id, int clie_id)
        {
            this.clientes_mediadorLista = this.MediadoresConsultaDataCtx.CLIENTES_MEDIADOR_SEL(0, usu_id, clie_id).ToList();
        }
    }
}
