using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentosVentas
{
    class MonedasConsultaCtx
    {
        private MonedasConsultaDBDataContext MonedasConsultaDataCtx = new MonedasConsultaDBDataContext();

        public List<MONEDAS_Q2_CONResult> monedas;
        public void MONEDAS_CON()
        {
            monedas = MonedasConsultaDataCtx.MONEDAS_Q2_CON().ToList();
        }
    }
}
