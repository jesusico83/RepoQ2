using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Auxiliares.Alertas
{
    class AlertasClienteCtx
    {
        public AlertasClienteDBDataContext AlertasClienteDataCtx = new AlertasClienteDBDataContext();
        public List<Q2_ALERTAS_CLIENTEResult> GET_ALERTAS(string fecha, int? clie_id, string docu_id)
        {
            return AlertasClienteDataCtx.Q2_ALERTAS_CLIENTE(fecha, clie_id, docu_id).ToList();            
        }
    }
}
