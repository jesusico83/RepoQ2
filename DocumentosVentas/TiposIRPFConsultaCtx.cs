using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentosVentas
{
    public class TiposIRPFConsultaCtx
    {
        TiposIRPFConsultaDBDataContext TiposIRPFConsultaDataCtx = new TiposIRPFConsultaDBDataContext();
        public List<IRPF_CONResult> tipos_irpf;

        public void IRPF_CON(string usu_id)
        {
            this.tipos_irpf = TiposIRPFConsultaDataCtx.IRPF_CON(0, usu_id).ToList();
        }        
    }
}
