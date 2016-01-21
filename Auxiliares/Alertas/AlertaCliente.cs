using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Auxiliares
{
    class AlertaCliente
    {
        public int Prioridad { get; set; }
        public string FechaDesde { get; set; }
        public string FechaHasta { get; set; }
        public int MensajeId { get; set; }
        public string Ampliacion { get; set; }
        public string Documento { get; set; }
        public string Texto { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public bool Sonoro { get; set; }

        

        public List<AlertaCliente> GetAlertasCliente(int cliente, string documento)
        {
            List<AlertaCliente> lista = new List<AlertaCliente>();
            Alertas.AlertasClienteCtx ctx = new Alertas.AlertasClienteCtx();

            List<Alertas.Q2_ALERTAS_CLIENTEResult> listaAlertas = ctx.GET_ALERTAS(DateTime.Now.ToString("yyyy-MM-dd"), (int)cliente, documento);

            if (listaAlertas.Count == 0)
            {
                return lista;
            }
            foreach (Alertas.Q2_ALERTAS_CLIENTEResult alerta in listaAlertas)
            {
                AlertaCliente a = new AlertaCliente();
                a.Prioridad = alerta.PRMS_ID;
                a.FechaDesde = alerta.PRMS_FECHAD;
                a.FechaHasta = alerta.PRMS_FECHAH;
                a.MensajeId = alerta.MENS_ID;
                a.Ampliacion = alerta.PRMS_AMPLIACION;
                a.Documento = alerta.DOCU_ID;
                a.Texto = alerta.MENS_MENSAJE;
                a.Descripcion = alerta.MENS_DESCRIPCION;
                a.Tipo = alerta.MENS_TIPO;
                a.Sonoro = alerta.MENS_SONORO == "0" ? true : false;
                lista.Add(a);
            }
            return lista.GroupBy(a => a.Ampliacion).Select(grp => grp.FirstOrDefault()).ToList();
        }
        public override string ToString()
        {
            return this.Descripcion;
        }
    }
}
