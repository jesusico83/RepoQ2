using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.SqlClient;
using System.Text;
using System.Data;

namespace DocumentosVentas
{
   public class PedidosvCtx
    {
        public PedidosDBDataContext pedidosDataCtx = new PedidosDBDataContext();        
                
        public List<DocumentosVentas.PEDIDOSV_SELResult> pedidos_selLista;
        public PEDIDOSV_SELResult pedido;        
        public List<DocumentosVentas.Q2_PEDIDOSV_CONResult> pedidos_conLista;
        public List<DocumentosVentas.CLIENTES_SEL_Q2Result> clientes_selLista;
        public List<DocumentosVentas.PEDIDOSV_LI_SELResult> lineas_detalle;
        public CLIENTES_SEL_Q2Result cliente;

        public List<DocumentosVentas.PEDIDOSV_INTER_Q2_SELResult> pedidos_interLista;

        public string pedid_id;
        public string tidoc_id;       

        public DataTable PEDIDOSV_LI_SEL(string usu_id, string docu_id, string pedid_id)
        {
            lineas_detalle = pedidosDataCtx.PEDIDOSV_LI_SEL(0, usu_id, docu_id, pedid_id).ToList();
            return Utilidades.UtilsLinq.LINQResultToDataTable(lineas_detalle, "PEDIDOSV_LI");
        }
        public void PEDIDOSV_INTER_DEL(string numero)
        {
            pedidosDataCtx.PEDIDOSV_INTER_Q2_DEL(numero);
        }
        public void PEDIDOSV_INTER_SEL(string docu_id, string pedid_id)
        {
            this.pedidos_interLista = this.pedidosDataCtx.PEDIDOSV_INTER_Q2_SEL(docu_id, pedid_id).ToList();
        }

        public void PEDIDOSV_INTER_INS(string docu_id, string numero, int numero_id, string depae_id,
            string tinte_id, string nombre, string telefono, string movil, string fax, string email,
            string ec, string em, string ef, string es, string ew)
        {            
            this.pedidosDataCtx.PEDIDOSV_INTER_Q2_INS(docu_id, numero, numero_id, depae_id, tinte_id,
                nombre, telefono, movil, fax, email, ec, em, ef, es, ew);            
        }


        public void CLIENTES_SEL(int clie_id, string docu_id)
        {
            this.clientes_selLista = this.pedidosDataCtx.CLIENTES_SEL_Q2(clie_id, docu_id).ToList();
            if (clientes_selLista.Count > 0)
                cliente = clientes_selLista.First();
        }
                
        public void SEL(string usu_id, string docu_id, string pedid_id)
        {
            this.pedidos_selLista = this.pedidosDataCtx.PEDIDOSV_SEL(1, usu_id, docu_id, pedid_id).ToList();
            if (this.pedidos_selLista.Count() > 0)
            {
                this.pedido = pedidos_selLista.First(); 
            }            
        }
        public void CON(string fechaD, string fechaH)
        {
            this.pedidos_conLista = this.pedidosDataCtx.Q2_PEDIDOSV_CON(fechaD, fechaH).ToList();
        }

        public string INS(short? TIPO, string USUARIO, string DOCU_ID, ref string PEDID_ID,
                        string PEDID_SUREFERENCIA, int CLIE_ID, int CLIE_ID1, int CLIE_ID2,
                        int CLIE_ID3, string PEDID_FECHA, string PEDID_FECHAP, string PEDID_FECHAM,
                        string PEDID_FECHAPG, string ALMA_ID, int? PERS_ID, int? PERS_ID1,
                        string ESTDOC_ID, int? GRDE_ID, int? IRPF_ID, int? PEDID_RECFIN, string MONEDA_ID,
                        int FPAGO_ID, string PEDID_ENTIDAD, string PEDID_DIRPAGO, short PEDID_BANCO,
                        short PEDID_SUCURSAL, short PEDID_DC, string PEDID_CC, string TIPORT_ID,
                        short PEDID_ENTREGA, string PEDID_ANOTACIONES, string DOCUD_NOMBRE,
                        string DOCUD_RAZONSOCIAL, string DOCUD_NIF, string DOCUD_DIRECCION, string DOCUD_CP,
                        string DOCUD_POBLACION, string DOCUD_PROVINCIA, string PAIS_ID, string DOCUD_TELEFONO,
                        string DOCUD_TELEFONO1, string DOCUD_MOVIL, string DOCUD_EMAIL, string DOCUD_WEB,
                        string DOCUD_EAN, string CLIEGF_ID, string HORA_AVISO, string PEDID_B, string ARTI_ID,
                        int? AGENTE_EXTERNO, int? AGENTE_INTERNO, int? REPRE_ID, string APLICA_PRECIO_MEDIADOR, string XML)
        {
            this.pedid_id = PEDID_ID;
            this.pedidosDataCtx.PEDIDOSV_INS(TIPO, USUARIO, DOCU_ID, ref pedid_id, PEDID_SUREFERENCIA, CLIE_ID, CLIE_ID1,
                           CLIE_ID2, CLIE_ID3, PEDID_FECHA, PEDID_FECHAP, PEDID_FECHAM, PEDID_FECHAPG, ALMA_ID, PERS_ID,
                           PERS_ID1, ESTDOC_ID, GRDE_ID, IRPF_ID, PEDID_RECFIN, MONEDA_ID, FPAGO_ID, PEDID_ENTIDAD,
                           PEDID_DIRPAGO, PEDID_BANCO, PEDID_SUCURSAL, PEDID_DC, PEDID_CC, TIPORT_ID, PEDID_ENTREGA,
                           PEDID_ANOTACIONES, DOCUD_NOMBRE, DOCUD_RAZONSOCIAL, DOCUD_NIF, DOCUD_DIRECCION, DOCUD_CP,
                           DOCUD_POBLACION, DOCUD_PROVINCIA, PAIS_ID, DOCUD_TELEFONO, DOCUD_TELEFONO1, DOCUD_MOVIL,
                           DOCUD_EMAIL, DOCUD_WEB, DOCUD_EAN, CLIEGF_ID, HORA_AVISO, PEDID_B, ARTI_ID, AGENTE_EXTERNO,
                           AGENTE_INTERNO, REPRE_ID, APLICA_PRECIO_MEDIADOR, XML);
            return pedid_id;
        }

        public void UPDT(short? TIPO, string USUARIO, string DOCU_ID, ref string PEDID_ID,
                        string PEDID_SUREFERENCIA, int CLIE_ID, int CLIE_ID1, int CLIE_ID2,
                        int CLIE_ID3, string PEDID_FECHA, string PEDID_FECHAP, string PEDID_FECHAM,
                        string PEDID_FECHAPG, string ALMA_ID, int? PERS_ID, int? PERS_ID1,
                        string ESTDOC_ID, int? GRDE_ID, int? IRPF_ID, int? PEDID_RECFIN, string MONEDA_ID,
                        int FPAGO_ID, string PEDID_ENTIDAD, string PEDID_DIRPAGO, short PEDID_BANCO,
                        short PEDID_SUCURSAL, short PEDID_DC, string PEDID_CC, string TIPORT_ID,
                        short PEDID_ENTREGA, string PEDID_ANOTACIONES, string DOCUD_NOMBRE,
                        string DOCUD_RAZONSOCIAL, string DOCUD_NIF, string DOCUD_DIRECCION, string DOCUD_CP,
                        string DOCUD_POBLACION, string DOCUD_PROVINCIA, string PAIS_ID, string DOCUD_TELEFONO,
                        string DOCUD_TELEFONO1, string DOCUD_MOVIL, string DOCUD_EMAIL, string DOCUD_WEB,
                        string DOCUD_EAN, string CLIEGF_ID, string HORA_AVISO, string PEDID_B, string ARTI_ID,
                        int? AGENTE_EXTERNO, int? AGENTE_INTERNO, int? REPRE_ID, string APLICA_PRECIO_MEDIADOR, string XML)
        {
            this.pedid_id = PEDID_ID;
            this.pedidosDataCtx.PEDIDOSV_UPD(TIPO, USUARIO, DOCU_ID, ref pedid_id, PEDID_SUREFERENCIA, CLIE_ID, CLIE_ID1,
                           CLIE_ID2, CLIE_ID3, PEDID_FECHA, PEDID_FECHAP, PEDID_FECHAM, PEDID_FECHAPG, ALMA_ID, PERS_ID,
                           PERS_ID1, ESTDOC_ID, GRDE_ID, IRPF_ID, PEDID_RECFIN, MONEDA_ID, FPAGO_ID, PEDID_ENTIDAD,
                           PEDID_DIRPAGO, PEDID_BANCO, PEDID_SUCURSAL, PEDID_DC, PEDID_CC, TIPORT_ID, PEDID_ENTREGA,
                           PEDID_ANOTACIONES, DOCUD_NOMBRE, DOCUD_RAZONSOCIAL, DOCUD_NIF, DOCUD_DIRECCION, DOCUD_CP,
                           DOCUD_POBLACION, DOCUD_PROVINCIA, PAIS_ID, DOCUD_TELEFONO, DOCUD_TELEFONO1, DOCUD_MOVIL,
                           DOCUD_EMAIL, DOCUD_WEB, DOCUD_EAN, CLIEGF_ID, HORA_AVISO, PEDID_B, ARTI_ID, AGENTE_EXTERNO,
                           AGENTE_INTERNO, REPRE_ID, APLICA_PRECIO_MEDIADOR, XML);

        }
    }
}
