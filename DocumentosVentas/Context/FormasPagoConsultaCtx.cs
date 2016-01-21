using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentosVentas
{
    class FormasPagoConsultaCtx
    {
        private FormasPagoConsultaDBDataContext FormasPagoConsultaDataCtx = new FormasPagoConsultaDBDataContext();

        public List<FORMAS_PAGO_Q2_CONResult> formas_pago;
        public void FORMAS_PAGO_CON()
        {
            formas_pago = FormasPagoConsultaDataCtx.FORMAS_PAGO_Q2_CON().ToList();
        }
    }
}
