using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentosVentas
{
    class ClientesConsultaCtx
    {
        public ClientesConsultaDBDataContext ClientesConsultaDataCtx = new ClientesConsultaDBDataContext();
        public List<DocumentosVentas.CLIENTES_CON1_Q2Result> clientes_conLista;

        public void CON(int? tipo, string usu_id, string clie_descripcion)
        {
            this.clientes_conLista = this.ClientesConsultaDataCtx.CLIENTES_CON1_Q2(tipo, usu_id, clie_descripcion).ToList();
        }
    }
}
