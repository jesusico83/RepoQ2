using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentosVentas
{
    class InterlocutoresConsultaCtx
    {
        public InterlocutoresConsultaDBDataContext InterlocutoresConsultaDataCtx = new InterlocutoresConsultaDBDataContext();
        public List<CLIENTES_INTER_Q2_SEL1Result> clientes_inter_Lista;
        public void SEL(short tipo, string usu_id, int clie_id)
        {
            clientes_inter_Lista = InterlocutoresConsultaDataCtx.CLIENTES_INTER_Q2_SEL1(tipo, usu_id, clie_id).ToList();
        }

    }
}
