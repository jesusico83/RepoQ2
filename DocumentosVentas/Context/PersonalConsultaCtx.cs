using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentosVentas
{
    class PersonalConsultaCtx
    {
        public PersonalConsultaDBDataContext PersonalConsultaDataCtx = new PersonalConsultaDBDataContext();
        public List<DocumentosVentas.PERSONAL_CON_Q2Result> personal_lista;

        public void CON(string pers_nombre)
        {
            this.personal_lista = this.PersonalConsultaDataCtx.PERSONAL_CON_Q2(pers_nombre).ToList();
        }
    }
}
