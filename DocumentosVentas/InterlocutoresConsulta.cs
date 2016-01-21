using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DocumentosVentas
{
    public partial class InterlocutoresConsulta : Form
    {
        public InterlocutoresConsulta()
        {
            InitializeComponent();
        }

        public int clie_id;
        public string clie_descripcion;
        public string usu_id;
        public List<PEDIDOSV_INTER_Q2_SELResult> interlocutores_seleccionados;
        public List<CLIENTES_INTER_Q2_SEL1Result> interlocutores_cliente;
        public short tipo = 0;

        private InterlocutoresConsultaCtx ctx = new InterlocutoresConsultaCtx();    

        private void MostrarListado()
        {
            this.fdlv1.ClearObjects();
            if (xbGrupos.Checked)
            {
                tipo = 1;
            }
            else
            {
                tipo = 0;
            }
            ctx.SEL(tipo, usu_id, clie_id);
            if (ctx.clientes_inter_Lista.Count() == 0)
            {
                this.DialogResult = DialogResult.No;
                
                this.Close();
                return;
            }
            interlocutores_cliente = ctx.clientes_inter_Lista;
            foreach (CLIENTES_INTER_Q2_SEL1Result interlocutor in interlocutores_cliente)
            {
                interlocutor.CLIEI_ECB = true;
                if (interlocutor.CLIEI_EC.Equals('1'))
                {
                    interlocutor.CLIEI_ECB = false;
                }
                interlocutor.CLIEI_EMB = true;
                if (interlocutor.CLIEI_EM.Equals('1'))
                {
                    interlocutor.CLIEI_EMB = false;
                }
                interlocutor.CLIEI_EFB = true;
                if (interlocutor.CLIEI_EF.Equals('1'))
                {
                    interlocutor.CLIEI_EFB = false;
                }
                interlocutor.CLIEI_ESB = true;
                if (interlocutor.CLIEI_ES.Equals('1'))
                {
                    interlocutor.CLIEI_ESB = false;
                }
                interlocutor.CLIEI_EWB = true;
                if (interlocutor.CLIEI_EW.Equals('1'))
                {
                    interlocutor.CLIEI_EWB = false;
                }
            }  
            
            // Mostrar el listado de todos los interlocutores del cliente en el OLV
            this.fdlv1.DataSource = interlocutores_cliente;          
        }
        
        public void AnyadirInterlocutores()
        {
            // Se convierte la lista de CLIENTES_INTER_Q2_SEL1Result a PEDIDOSV_INTER_Q2_SEL_RESULT,
            // para mandarla a la ventana llamante. Se comprueban los checked de las columnas booleanas y 
            // se asigna '0' o '1' a los campos correpondientes.
            
            // Lista Vacía de PedidosV_INTER_Q2_SELResult, para llenarla con los interlocutores
            // que se marquen de todo el listado de posibles interlocutores del cliente
            interlocutores_seleccionados = new List<PEDIDOSV_INTER_Q2_SELResult>();           
            foreach (DocumentosVentas.CLIENTES_INTER_Q2_SEL1Result cmsr in this.fdlv1.CheckedObjects)
            {
                // Por cada interlocutor con check activo, se crea un objeto PedidosV_INTER_SELResult y se añade a la lista
                interlocutores_seleccionados.Add(new PEDIDOSV_INTER_Q2_SELResult());
            }
            if (interlocutores_seleccionados.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un interlocutor Válido");
                return;
            }

            // Se rellena la lista de pedidosv_inter_sel_Result con los datos de los objetos seleccionados 
            // array de interlocutores marcados por el usuario, a pasar a la ventan llamante
            PEDIDOSV_INTER_Q2_SELResult[] pir = new PEDIDOSV_INTER_Q2_SELResult[this.fdlv1.CheckedObjects.Count];
            // array con los interlocutores marcados en el formato CLIENTES_INTER_Q2_SEL1Result, del que se extraerán los datos
            CLIENTES_INTER_Q2_SEL1Result[] olv = new CLIENTES_INTER_Q2_SEL1Result[this.fdlv1.CheckedObjects.Count];
            int contador = 0;
            foreach (CLIENTES_INTER_Q2_SEL1Result ci in this.fdlv1.CheckedObjects)
            {
                // Copia los interlocutores seleccionados del OLV en un array
                olv[contador] = ci;
                contador++;
            }
            for (int i = 0; i < this.fdlv1.CheckedObjects.Count; i++)
            {
                pir[i] = new PEDIDOSV_INTER_Q2_SELResult();
               // pir[i].NUMERO_ID = olv[i].CLIEI_ID; No PASARLE EL NÚMERO, AGREGARSELO EN LA VENTANA LLAMANTE
                pir[i].DEPAE_ID = olv[i].DEPAE_ID;
                pir[i].TINTE_ID = olv[i].TINTE_ID;
                pir[i].NOMBRE = olv[i].CLIEI_NOMBRE;
                pir[i].TELEFONO = olv[i].CLIEI_TELEFONO;
                pir[i].MOVIL = olv[i].CLIEI_MOVIL;
                pir[i].EMAIL = olv[i].CLIEI_EMAIL;
                pir[i].FAX = olv[i].CLIEI_FAX;
                pir[i].EC = olv[i].CLIEI_EC;
                pir[i].ECB = olv[i].CLIEI_ECB;
                pir[i].EF = olv[i].CLIEI_EF;
                pir[i].EFB = olv[i].CLIEI_EFB;
                pir[i].EM = olv[i].CLIEI_EM;
                pir[i].EMB = olv[i].CLIEI_EMB;
                pir[i].ES = olv[i].CLIEI_ES;
                pir[i].ESB = olv[i].CLIEI_ESB;
                pir[i].EW = olv[i].CLIEI_EW;
                pir[i].EWB = olv[i].CLIEI_EWB;
            }
            interlocutores_seleccionados = pir.ToList();            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }  

        private void btnActaVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AnyadirInterlocutores();
        }

        private void xbGrupos_CheckedChanged(object sender, EventArgs e)
        {
            MostrarListado();
        }

        private void InterlocutoresConsulta_Load(object sender, EventArgs e)
        {
            this.fdlv1.ClearObjects();
            this.txtCLIE_ID.Text = this.clie_id.ToString();
            this.lblCLIE_DESCRIPCION.Text = this.clie_descripcion;
            MostrarListado();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            AnyadirInterlocutores();
        }
    }
}
