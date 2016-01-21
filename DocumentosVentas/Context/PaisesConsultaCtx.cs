using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentosVentas
{
    class PaisesConsultaCtx
    {
        private PaisesConsultaDBDataContext PaisesConsultaDataCtx = new PaisesConsultaDBDataContext();
        public List<PAISES_Q2_CONResult> paises;
        public void PAISES_CON()
        {
            paises = PaisesConsultaDataCtx.PAISES_Q2_CON().ToList();
        }
    }
}
