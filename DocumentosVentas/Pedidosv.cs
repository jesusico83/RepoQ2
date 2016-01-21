using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace DocumentosVentas
{
    public partial class Pedidosv : Form
    {
        // Variables de ventana

        // Flecos: Implementar la inserción de estos campos
        public string _USU_ID;
        public string _DOCU_ID = "ACTA";
        public string _TIDOC_ID = "PEDV";
        public string _PEDID_ID, _PEDID_ID_ORIGEN;
        public int _CLIE_ID;        
        private PedidosvCtx ctx = new PedidosvCtx();
        private List<PEDIDOSV_INTER_Q2_SELResult> interlocutores;
        public List<PEDIDOSV_LI_SELResult> detalle;
        public DataTable detalle_lineas;
        public bool plantilla = false;
        public bool bloqueo = false;
       
        private int numero_id; // Máximo número id de los interlocutores, para asignar a los nuevos que se añadan un número mayor


        bool insert = true; // Flecos: Ver cómo lo resuelvo

        public Pedidosv()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Asignar Valores por defecto a los campos más utilizados
        /// </summary>
        private void InicializarCampos()
        {
            txtDOCU_ID.Text = "ACTA";
            lblDOCU_DESCRIPCION.Text = "ACTA DE RECEPCION";
            txtESTDOC_ID.Text = "PRE";
            lblESTDOC_DESCRIPCION.Text = "Pendiente de recoger";
            txtPAIS_ID.Text = "ES";
            lblPAIS_DESCRIPCION.Text = "España";
        }
        /// <summary>
        /// Borra todos los datos editables del acta
        /// </summary>
        private void LimpiarActa()
        {
            this.xBoxAplicaPrecios.Checked = false;
            this.dtpHORA_AVISO.Checked = false;
            this.dtpPEDID_FECHA.Checked = false;
            this.dtpPEDID_FECHAM.Checked = false;
            this.dtpPEDID_FECHAP.Checked = false;
            foreach (Control componente in this.tabControlActas.Controls)
            {
                if(componente is TabPage)
                {
                    foreach (Control c in componente.Controls)
                    {
                        if(c is MaskedTextBox)
                        {
                            ((MaskedTextBox)c).Text = string.Empty;                            
                        }
                        if(c is Label && !(c is LinkLabel ))
                        {
                            ((Label)c).Text = string.Empty;
                        }
                        if (c is TextBox)
                        {
                            ((TextBox)c).Text = string.Empty;
                        }
                    }
                }
            }
            this.fdlv1.DataSource = null;
            this.fdlv1.ClearObjects();
            this.fdlv2.DataSource = null;
            this.fdlv2.ClearObjects();
        }

        private void mtxtPEDID_ID_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MostrarPedido();
            }
        }
        private void MostrarPedido()
        {

            this.ctx.SEL(_USU_ID, _DOCU_ID, txtPEDID_ID.Text);
            if (ctx.pedido == null)
            {
                MessageBox.Show("El pedido no existe");
            }
            else
            {
                // Cargar todos los datos simples del formulario
                this.pEDIDOSV_SELResultBindingSource.DataSource = ctx.pedido;
                this.pEDIDOSV_SELResultBindingSource.ResumeBinding();
                
                this.insert = false;

                // Mostrar la parte de interlocutores
                this.ctx.PEDIDOSV_INTER_SEL(_DOCU_ID, this.txtPEDID_ID.Text);
                //this.fdlv1.ClearObjects();                
                CopiarInterlocutoresDePedido();
                
                //this.fdlv1.DataSource = interlocutores;
                this.fdlv1.SetObjects(interlocutores);
                //detalle_lineas = this.ctx.PEDIDOSV_LI_SEL(_USU_ID, _DOCU_ID, this.txtPEDID_ID.Text);
                //convertir a datatable                
                this.fdlv2.DataSource = this.ctx.PEDIDOSV_LI_SEL(_USU_ID, _DOCU_ID, this.txtPEDID_ID.Text);
            }                
        }
        // Se copian los interlocutores que vienen del pedido y se guardan en otra lista de interlocutores que 
        // servirá para añadir, quitar y guardar.
        
        // Se guarda la lista de interlocutores nueva y se agrega el varchar 0 si está marcado. Paso previo al insert
        private void CopiarInterlocutoresAlPedido()
        {
            if (fdlv1.GetItem(0) != null)
            {
                
                //Flecos: Comprobar que al menos uno de ellos tiene seleccionado el correo.
            }
            ctx.PEDIDOSV_INTER_DEL(this.txtPEDID_ID.Text);
            foreach (PEDIDOSV_INTER_Q2_SELResult interlocutor in this.fdlv1.Objects)
            {
                if ((bool)interlocutor.ECB)
                {
                    interlocutor.EC = '0';
                }
                else
                {
                    interlocutor.EC = '1';
                }
                if ((bool)interlocutor.EMB)
                {
                    interlocutor.EM = '0';
                }
                else
                {
                    interlocutor.EM = '1';
                }
                if ((bool)interlocutor.EFB)
                {
                    interlocutor.EF = '0';
                }
                else
                {
                    interlocutor.EF = '1';
                }
                if ((bool)interlocutor.ESB)
                {
                    interlocutor.ES = '0';
                }
                else
                {
                    interlocutor.ES = '1';
                }
                if ((bool)interlocutor.EWB)
                {
                    interlocutor.EW = '0';
                }
                else
                {
                    interlocutor.EW = '1';
                }
                ctx.PEDIDOSV_INTER_INS(_DOCU_ID, this.txtPEDID_ID.Text, interlocutor.NUMERO_ID, interlocutor.DEPAE_ID, interlocutor.TINTE_ID,
                    interlocutor.NOMBRE, interlocutor.TELEFONO, interlocutor.MOVIL, interlocutor.FAX, interlocutor.EMAIL, interlocutor.EC.ToString(),
                    interlocutor.EM.ToString(), interlocutor.EF.ToString(), interlocutor.ES.ToString(), interlocutor.EW.ToString());
            }

        }

        private void CopiarInterlocutoresDePedido()
        {
            // Se guarda la lista de interlocutores que devuelve el procedimiento almacenado y se transforman los 
            // varchar en int, pasándolos a los campos bit del objeto
            interlocutores = ctx.pedidos_interLista;
            foreach (PEDIDOSV_INTER_Q2_SELResult interlocutor in interlocutores)
            {
                interlocutor.ECB = true;
                if(interlocutor.EC.Equals('1'))
                {
                    interlocutor.ECB = false;
                }
                interlocutor.EMB = true;
                if (interlocutor.EM.Equals('1'))
                {
                    interlocutor.EMB = false;
                }
                interlocutor.EFB = true;
                if (interlocutor.EF.Equals('1'))
                {
                    interlocutor.EFB = false;
                }
                interlocutor.ESB = true;
                if (interlocutor.ES.Equals('1'))
                {
                    interlocutor.ESB = false;
                }
                interlocutor.EWB = true;
                if (interlocutor.EW.Equals('1'))
                {
                    interlocutor.EWB = false;
                }                
            }
            // Se calcula el máximo numero_id
            foreach (PEDIDOSV_INTER_Q2_SELResult inter in interlocutores)
            {
                if (numero_id < inter.NUMERO_ID)
                    numero_id = inter.NUMERO_ID;
            }
        }
        private void EliminarInterlocutoresDePedido()
        {
            foreach (PEDIDOSV_INTER_Q2_SELResult interlocutor in  fdlv1.CheckedObjects)
            {
                interlocutores.Remove(interlocutor);
            }
            this.fdlv1.DataSource = interlocutores;
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {            
            EliminarInterlocutoresDePedido();
        }
        private void AnyadirInterlocutoresAlPedido()
        {
            AbrirInterlocutoresConsulta();
        }
        private int CalcularNumero_Id()
        {
            List<int> numeros_id = new List<int>();
            foreach (PEDIDOSV_INTER_Q2_SELResult pir in this.fdlv1.Objects)
            {
                numeros_id.Add(pir.NUMERO_ID);
            }
            if (numeros_id.Count == 0) return 0;
            return numeros_id.Max();
        }
        private void AbrirInterlocutoresConsulta()
        { 
            DocumentosVentas.InterlocutoresConsulta c = new DocumentosVentas.InterlocutoresConsulta();
            c.clie_id = Utilidades.UtilsTipos.toInt(this.txtCLIE_ID.Text);
            c.clie_descripcion = txtDOCUD_NOMBRE.Text;
            c.ShowDialog();
            if (c.DialogResult != DialogResult.OK)
            {
                MessageBox.Show("El cliente seleccionado no existe o no tiene una lista de interlocutores predefinidos");
            }
            else 
            {
                // Se añaden los interlocutores seleccionados en la ventana de interlocutores_consulta
                // a la lista actual                
                
                List<PEDIDOSV_INTER_Q2_SELResult> lista = new List<PEDIDOSV_INTER_Q2_SELResult>();
                foreach(PEDIDOSV_INTER_Q2_SELResult pir in c.interlocutores_seleccionados)
                {                    
                    lista.Add(pir);
                }
                // Se evita meter datos duplicados comprueba si ya existen. Revisar este bucle
                foreach (PEDIDOSV_INTER_Q2_SELResult pirs in c.interlocutores_seleccionados)
                {
                    foreach (PEDIDOSV_INTER_Q2_SELResult pir in fdlv1.Objects)
                    {
                        if (pirs.NOMBRE == pir.NOMBRE)
                        {
                            lista.Remove(pirs);
                        }                        
                    }                    
                }

                // Se asignan los numeros_id
                int max = CalcularNumero_Id();
                int contador = 1;
                foreach (PEDIDOSV_INTER_Q2_SELResult pir in lista)
                {
                    pir.NUMERO_ID = max + contador * 10;
                    contador++;
                }

                // Se unen las 2 listas
                if (interlocutores != null)
                    interlocutores = interlocutores.Union(lista).ToList();
                else interlocutores = lista;
                this.fdlv1.DataSource = interlocutores;                
            }
        }           

        private void MostrarDatosCliente()
        {           
            _DOCU_ID = txtDOCU_ID.Text;            
            ctx.CLIENTES_SEL(_CLIE_ID, _DOCU_ID);
            if (ctx.cliente == null)
            {
                return;
            }
            else
            {
                pEDIDOSV_SELResultBindingSource.SuspendBinding();
                txtCLIE_ID.Text = ctx.cliente.CLIE_ID.ToString();
                txtDOCUD_NOMBRE.Text = ctx.cliente.CLIE_DESCRIPCION;
                txtCLIE_ID1.Text = ctx.cliente.CLIE_ID1.ToString();
                txtCLIE_ID2.Text = ctx.cliente.CLIE_ID2.ToString();
                txtCLIE_ID3.Text = ctx.cliente.CLIE_ID3.ToString();
                // Falta validar los otros 3 campos
                txtDOCUD_RAZONSOCIAL.Text = ctx.cliente.CLIE_RAZONSOCIAL;
                txtDOCUD_NIF.Text = ctx.cliente.CLIE_NIF;
                txtDOCUD_DIRECCION.Text = ctx.cliente.CLIE_DIRECCION;
                txtDOCUD_POBLACION.Text = ctx.cliente.CLIE_POBLACION;
                txtDOCUD_PROVINCIA.Text = ctx.cliente.CLIE_PROVINCIA;
                txtDOCU_CP.Text = ctx.cliente.CLIE_CP;
                txtPAIS_ID.Text = ctx.cliente.PAIS_ID;
                txtDOCUD_TELEFONO.Text = ctx.cliente.CLIE_TELEFONO;
                txtDOCU_MOVIL.Text = ctx.cliente.CLIE_MOVIL;
                txtDOCU_TELEFONO1.Text = ctx.cliente.CLIE_TELEFONO1;
                txtDOCUD_EMAIL.Text = ctx.cliente.CLIE_EMAIL;
                txtDOCUD_WEB.Text = ctx.cliente.CLIE_WEB;
                txtDOCUD_EAN.Text = ctx.cliente.CLIE_EAN;
                txtAGENTE.Text = ctx.cliente.AGENTE.ToString();
                txtAGENTE_INTERNO.Text = ctx.cliente.AGENTE_INTERNO.ToString();
                lblAGENTE.Text = ctx.cliente.PERS_NOMBRE;
                lblAGENTE_INTERNO.Text = ctx.cliente.AGENTE_INTERNO_NOMBRE;
                txtGRDE_ID.Text = ctx.cliente.GRDE_ID.ToString();
                lblGRDE_DESCRIPCION.Text = ctx.cliente.GRDE_DESCRIPCION;
                txtIRPF_ID.Text = ctx.cliente.IRPF_ID.ToString();
                lblIRPF_DESCRIPCION.Text = ctx.cliente.IRPF_DESCRIPCION;
                txtPEDID_RECFIN.Text = ctx.cliente.CLIE_RECFIN.ToString();
                lblGRDE_DESCRIPCION1.Text = ctx.cliente.GRDE_DESCRIPCION1;
                txtMONEDA_ID.Text = ctx.cliente.MONEDA_ID;
                lblMONEDA_DESCRIPCION.Text = ctx.cliente.MONEDA_DESCRIPCION;
                txtFPAGO_ID.Text = ctx.cliente.FPAGO_ID.ToString();
                lblFPAGO_DESCRIPCION.Text = ctx.cliente.FPAGO_DESCRIPCION;
                txtPEDID_ENTIDAD.Text = ctx.cliente.CLIE_ENTIDAD;
                txtPEDID_DIRPAGO.Text = ctx.cliente.CLIE_DIRPAGO;
                txtPEDID_BANCO.Text = ctx.cliente.CLIE_BANCO.ToString();
                txtPEDID_SUCURSAL.Text = ctx.cliente.CLIE_SUCURSAL.ToString();
                txtPEDID_DC.Text = ctx.cliente.CLIE_DC.ToString();
                txtPEDID_CC.Text = ctx.cliente.CLIE_CC;
                txtTIPORT_ID.Text = ctx.cliente.TIPORT_ID;
                txtPEDID_ENTREGA.Text = ctx.cliente.CLIE_ENTREGA.ToString(); 
                
            }

        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            AbrirPedidosConsulta();
            plantilla = false;
            // Bloquear Todos los campos editables
        }
        private void AbrirPedidosConsulta()
        {
            DocumentosVentas.PedidosvConsulta c = new DocumentosVentas.PedidosvConsulta();
            c.usu_id = _USU_ID;
            c.docu_id = _DOCU_ID;
            c.ShowDialog();
            if (c.DialogResult == DialogResult.OK)
            {
                this.txtPEDID_ID.Text = c.pedid_id;
                _PEDID_ID = c.pedid_id;
                _PEDID_ID_ORIGEN = c.pedid_id;
                MostrarPedido();
                insert = false;
            }
            
        }
        /// <summary>
        /// Para el campo principal de cliente
        /// </summary>
        private void AbrirClientesConsulta()
        {
            ClientesConsulta c = new ClientesConsulta();
            c.usu_id = _USU_ID;
            c.ShowDialog();
            if (c.DialogResult == DialogResult.OK)
            {  
                this._CLIE_ID = c.clie_id;                
                MostrarDatosCliente();
                c.Dispose();
            }
        }
        /// <summary>
        /// Para los campos secundarios clie_id1, clie_id2, clie_id3
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="l"></param>
        private void AbrirClientesConsulta(MaskedTextBox tb, Label l)
        {
            ClientesConsulta c = new ClientesConsulta();
            c.usu_id = _USU_ID;
            c.ShowDialog();
            if (c.DialogResult == DialogResult.OK)
            {
                tb.Text = c.clie_id.ToString();                
                l.Text = c.clie_descripcion;                  
                c.Dispose();
            }
            //InicializarCampos();
        }
        

        private void ValidarDatosUPD()
        {
            PedidosDBDataContext dc = new PedidosDBDataContext();
            short? TIPO = 0;
            string USUARIO = _USU_ID;
            string DOCU_ID = _DOCU_ID;
            string PEDID_ID = this.txtPEDID_ID.Text;
            string PEDID_SUREFERENCIA = this.txtPEDID_SUREFERENCIA.Text;
            int CLIE_ID = Utilidades.UtilsTipos.toInt(this.txtCLIE_ID.Text); // No nulo, necesita validar
            var clie = from c in dc.CLIENTES
                       where c.CLIE_ID == CLIE_ID
                       select c;
            if (clie.Count() == 0)
            {
                MessageBox.Show("Error: Campo solicitante no válido");                
                return;
            }

            int CLIE_ID1 = Utilidades.UtilsTipos.toInt(this.txtCLIE_ID1.Text); // No nulo, necesita validar
            var clie1 = from c in dc.CLIENTES
                        where c.CLIE_ID == CLIE_ID
                        select c;
            if (clie1.Count() == 0)
            {
                MessageBox.Show("Error: Campo envío (cliente) no válido");
                return;
            }
            int CLIE_ID2 = Utilidades.UtilsTipos.toInt(this.txtCLIE_ID2.Text); // No nulo, necesita validar
            var clie2 = from c in dc.CLIENTES
                        where c.CLIE_ID == CLIE_ID
                        select c;
            if (clie2.Count() == 0)
            {
                MessageBox.Show("Error: Campo Facturación (cliente) no válido");
                return;
            }
            int CLIE_ID3 = Utilidades.UtilsTipos.toInt(this.txtCLIE_ID3.Text); // No nulo, necesita validar
            var clie3 = from c in dc.CLIENTES
                        where c.CLIE_ID == CLIE_ID
                        select c;
            if (clie3.Count() == 0)
            {
                MessageBox.Show("Error: Campo Pago (cliente) no válido");
                return;
            }
            if (!this.dtpPEDID_FECHA.Checked)
            {
                MessageBox.Show("Error: No ha confirmado la fecha del documento");
                return;
            }
            string PEDID_FECHA = this.dtpPEDID_FECHA.Value.ToString("yyyy-MM-dd"); // No nulo, necesita validar
            if (!this.dtpPEDID_FECHAP.Checked)
            {
                MessageBox.Show("Error: No ha confirmado la fecha prevista");
                return;
            }
            string PEDID_FECHAP = this.dtpPEDID_FECHAP.Value.ToString("yyyy-MM-dd"); // No nulo, necesita validar
            string PEDID_FECHAM = null;
            if (this.dtpPEDID_FECHAM.Checked) PEDID_FECHAM = this.dtpPEDID_FECHAM.Value.ToString("yyyy-MM-dd"); // Necesita validar
            string PEDID_FECHAPG = null; // No se lo que es; // Necesita validar
            string ALMA_ID = null; // No se usa
            int? PERS_ID = Utilidades.UtilsTipos.toIntN(this.txtPERS_ID.Text); // Necesita validar
            var pers_id = from c in dc.PERSONAL
                          where c.PERS_ID == PERS_ID
                          select c;
            if (PERS_ID != null && pers_id.Count() == 0)
            {
                MessageBox.Show("Error: Receptor no válido");
                return;
            }
            int? PERS_ID1 = Utilidades.UtilsTipos.toIntN(this.txtPERS_ID1.Text); // Necesita validar
            var pers_id1 = from c in dc.PERSONAL
                           where c.PERS_ID == PERS_ID1
                           select c;
            if (PERS_ID1 != null && pers_id1.Count() == 0)
            {
                MessageBox.Show("Error: campo recoge muestra no válido");
                return;
            }

            string ESTDOC_ID = this.txtESTDOC_ID.Text; // No nulo, necesita validar
            int? GRDE_ID = Utilidades.UtilsTipos.toIntN(txtGRDE_ID.Text); // Necesita validar
            int? IRPF_ID = Utilidades.UtilsTipos.toIntN(txtIRPF_ID.Text); // Necesita validar
            int? PEDID_RECFIN = Utilidades.UtilsTipos.toIntN(txtPEDID_RECFIN.Text); // Necesita validar
            string MONEDA_ID = this.txtMONEDA_ID.Text; // No nulo, necesita validar 
            var moneda = from c in dc.MONEDAS
                         where c.MONEDA_ID == MONEDA_ID
                         select c;
            if (moneda.Count() == 0)
            {
                MessageBox.Show("Error: moneda no válida");
                return;
            }
            int FPAGO_ID = Utilidades.UtilsTipos.toInt(txtFPAGO_ID.Text);   // No nulo, necesita validar  
            var fpago = from c in dc.FORMAS_PAGO
                        where c.FPAGO_ID == FPAGO_ID
                        select c;
            if (fpago.Count() == 0)
            {
                MessageBox.Show("Error: Forma de pago no válida");
                return;
            }
            string PEDID_ENTIDAD = txtPEDID_ENTIDAD.Text; // No nulo
            string PEDID_DIRPAGO = txtPEDID_DIRPAGO.Text; // No nulo
            short PEDID_BANCO = (short)Utilidades.UtilsTipos.toInt(txtPEDID_BANCO.Text);
            short PEDID_SUCURSAL = (short)Utilidades.UtilsTipos.toInt(txtPEDID_SUCURSAL.Text);
            short PEDID_DC = (short)Utilidades.UtilsTipos.toInt(txtPEDID_DC.Text);
            string PEDID_CC = txtPEDID_CC.Text;
            string TIPORT_ID = txtTIPORT_ID.Text;
            var tiport_id = from c in dc.TIPOS_PORTE
                            where c.TIPORT_ID == TIPORT_ID
                            select c;
            if (tiport_id.Count() == 0)
            {
                MessageBox.Show("Error: Tipo de porte no válido");
                return;
            }

            short PEDID_ENTREGA = (short)Utilidades.UtilsTipos.toInt(txtPEDID_ENTREGA.Text);
            string PEDID_ANOTACIONES = txtPEDID_ANOTACIONES.Text;
            string DOCUD_NOMBRE = txtDOCUD_NOMBRE.Text;
            string DOCUD_RAZONSOCIAL = txtDOCUD_RAZONSOCIAL.Text;
            string DOCUD_NIF = txtDOCUD_NIF.Text;
            string DOCUD_DIRECCION = txtDOCUD_DIRECCION.Text;
            string DOCUD_CP = txtDOCU_CP.Text;
            string DOCUD_POBLACION = txtDOCUD_POBLACION.Text;
            string DOCUD_PROVINCIA = txtDOCUD_PROVINCIA.Text;
            string PAIS_ID = txtPAIS_ID.Text;
            var pais_id = from c in dc.PAISES
                          where c.PAIS_ID == PAIS_ID
                          select c;
            if (pais_id.Count() == 0)
            {
                MessageBox.Show("Error: Campo país no válido");
                return;
            }
            string DOCUD_TELEFONO = txtDOCUD_TELEFONO.Text;
            string DOCUD_TELEFONO1 = txtDOCU_TELEFONO1.Text;
            string DOCUD_MOVIL = txtDOCU_MOVIL.Text;
            string DOCUD_EMAIL = txtDOCUD_EMAIL.Text;
            string DOCUD_WEB = txtDOCUD_WEB.Text;
            string DOCUD_EAN = txtDOCUD_EAN.Text;
            string CLIEGF_ID = null; // No se mete al crear el acta            
            string HORA_AVISO = "";
            if (this.dtpHORA_AVISO.Checked)
                HORA_AVISO = dtpHORA_AVISO.Value.ToString(); // No nulo, necesita validar
            string PEDID_B = ""; // No nulo, necesita validar
            string ARTI_ID = this.txtARTI_ID.Text; //necesita validar
            var arti_id = from c in dc.ARTICULOS
                          where c.ARTI_ID == ARTI_ID
                          select c;
            if (arti_id.Count() == 0)
            {
                ARTI_ID = null;
            }
            int? AGENTE_EXTERNO = Utilidades.UtilsTipos.toIntN(txtAGENTE.Text);
            int? AGENTE_INTERNO = Utilidades.UtilsTipos.toIntN(txtAGENTE.Text);
            int? REPRE_ID = Utilidades.UtilsTipos.toIntN(txtREPRE_ID.Text);
            string APLICA_PRECIO_MEDIADOR = "1";
            if (xBoxAplicaPrecios.Checked)
            {
                APLICA_PRECIO_MEDIADOR = "0";
            }
            string XML = "<?xml version=\"1.0\" encoding=\"windows-1252\"?><ROOT />";

            ctx.UPDT(TIPO, USUARIO, DOCU_ID, ref PEDID_ID, PEDID_SUREFERENCIA,
            CLIE_ID, CLIE_ID1, CLIE_ID2, CLIE_ID3, PEDID_FECHA, PEDID_FECHAP, PEDID_FECHAM,
            PEDID_FECHAPG, ALMA_ID, PERS_ID, PERS_ID1, ESTDOC_ID, GRDE_ID, IRPF_ID, PEDID_RECFIN,
            MONEDA_ID, FPAGO_ID, PEDID_ENTIDAD, PEDID_DIRPAGO, PEDID_BANCO, PEDID_SUCURSAL, PEDID_DC,
            PEDID_CC, TIPORT_ID, PEDID_ENTREGA, PEDID_ANOTACIONES, DOCUD_NOMBRE, DOCUD_RAZONSOCIAL,
            DOCUD_NIF, DOCUD_DIRECCION, DOCUD_CP, DOCUD_POBLACION, DOCUD_PROVINCIA, PAIS_ID, DOCUD_TELEFONO,
            DOCUD_TELEFONO1, DOCUD_MOVIL, DOCUD_EMAIL, DOCUD_WEB, DOCUD_EAN, CLIEGF_ID, HORA_AVISO, PEDID_B,
            ARTI_ID, AGENTE_EXTERNO, AGENTE_INTERNO, REPRE_ID, APLICA_PRECIO_MEDIADOR, XML);
        }


        private bool ValidarDatosINS()
        {

            PedidosDBDataContext dc = new PedidosDBDataContext();
            short? TIPO = 0; 
            string USUARIO = _USU_ID;
            string DOCU_ID = _DOCU_ID;
            string PEDID_ID = this.txtPEDID_ID.Text;
            string PEDID_SUREFERENCIA = this.txtPEDID_SUREFERENCIA.Text;
            int CLIE_ID = Utilidades.UtilsTipos.toInt(this.txtCLIE_ID.Text); // No nulo, necesita validar
            var clie = from c in dc.CLIENTES
                       where c.CLIE_ID == CLIE_ID
                       select c;
            if (clie.Count() == 0 )
            {
                MessageBox.Show("Error: Campo solicitante no válido");
                this.txtCLIE_ID.Select();
                return false;
            }

            int CLIE_ID1 = Utilidades.UtilsTipos.toInt(this.txtCLIE_ID1.Text); // No nulo, necesita validar
            var clie1 = from c in dc.CLIENTES
                        where c.CLIE_ID == CLIE_ID
                        select c;
            if (clie1.Count() == 0)
            {
                MessageBox.Show("Error: Campo envío (cliente) no válido");
                return false;
            }
            int CLIE_ID2 = Utilidades.UtilsTipos.toInt(this.txtCLIE_ID2.Text); // No nulo, necesita validar
            var clie2 = from c in dc.CLIENTES
                       where c.CLIE_ID == CLIE_ID
                       select c;
            if (clie2.Count() == 0)
            {
                MessageBox.Show("Error: Campo Facturación (cliente) no válido");
                return false;
            }
            int CLIE_ID3 = Utilidades.UtilsTipos.toInt(this.txtCLIE_ID3.Text); // No nulo, necesita validar
            var clie3 = from c in dc.CLIENTES
                       where c.CLIE_ID == CLIE_ID
                       select c;
            if (clie3.Count() == 0)
            {
                MessageBox.Show("Error: Campo Pago (cliente) no válido");
                return false;
            }
            if (!this.dtpPEDID_FECHA.Checked)
            {
                MessageBox.Show("Error: No ha confirmado la fecha del documento");
                this.dtpPEDID_FECHA.Select();
                return false;
            }
            string PEDID_FECHA = this.dtpPEDID_FECHA.Value.ToString("yyyy-MM-dd"); // No nulo, necesita validar
            if (!this.dtpPEDID_FECHAP.Checked)
            {
                MessageBox.Show("Error: No ha confirmado la fecha prevista");
                this.dtpPEDID_FECHAP.Select();
                return false;
            }
            string PEDID_FECHAP = this.dtpPEDID_FECHAP.Value.ToString("yyyy-MM-dd"); // No nulo, necesita validar
            string PEDID_FECHAM = null;
            if(this.dtpPEDID_FECHAM.Checked) PEDID_FECHAM = this.dtpPEDID_FECHAM.Value.ToString("yyyy-MM-dd"); // Necesita validar
            string PEDID_FECHAPG = null; // No se lo que es; // Necesita validar
            string ALMA_ID = null; // No se usa
            int? PERS_ID = Utilidades.UtilsTipos.toIntN(this.txtPERS_ID.Text); // Necesita validar
            var pers_id = from c in dc.PERSONAL
                          where c.PERS_ID == PERS_ID
                          select c;
            if (PERS_ID != null && pers_id.Count() == 0)
            {
                MessageBox.Show("Error: Receptor no válido");
                return false;
            }
            int? PERS_ID1 = Utilidades.UtilsTipos.toIntN(this.txtPERS_ID1.Text); // Necesita validar
            var pers_id1 = from c in dc.PERSONAL
                          where c.PERS_ID == PERS_ID1
                          select c;
            if (PERS_ID1 != null && pers_id1.Count() == 0)
            {
                MessageBox.Show("Error: campo recoge muestra no válido");
                return false;
            }

            string ESTDOC_ID = this.txtESTDOC_ID.Text; // No nulo, necesita validar
            var estdoc_id = from e in dc.DOCUMENTOS_ESTADOS
                            where e.ESTDOC_ID == ESTDOC_ID
                            select e;
            if (estdoc_id.Count() == 0)
            {
                MessageBox.Show("Error: revise el estado del documento");
                return false;
            }
            int? GRDE_ID = Utilidades.UtilsTipos.toIntN(txtGRDE_ID.Text); // Necesita validar
            int? IRPF_ID = Utilidades.UtilsTipos.toIntN(txtIRPF_ID.Text); // Necesita validar
            int? PEDID_RECFIN = Utilidades.UtilsTipos.toIntN(txtPEDID_RECFIN.Text); // Necesita validar
            string MONEDA_ID = this.txtMONEDA_ID.Text; // No nulo, necesita validar 
            var moneda = from c in dc.MONEDAS
                         where c.MONEDA_ID == MONEDA_ID
                         select c;
            if(moneda.Count() == 0)
            {
                MessageBox.Show("Error: moneda no válida");
                return false;
            }
            int FPAGO_ID = Utilidades.UtilsTipos.toInt(txtFPAGO_ID.Text);   // No nulo, necesita validar  
            var fpago = from c in dc.FORMAS_PAGO
                        where c.FPAGO_ID == FPAGO_ID
                        select c;
            if(fpago.Count() == 0)
            {
                MessageBox.Show("Error: Forma de pago no válida");
                return false;
            }
            string PEDID_ENTIDAD = txtPEDID_ENTIDAD.Text; // No nulo
            string PEDID_DIRPAGO = txtPEDID_DIRPAGO.Text; // No nulo
            short PEDID_BANCO = (short)Utilidades.UtilsTipos.toInt(txtPEDID_BANCO.Text);
            short PEDID_SUCURSAL = (short)Utilidades.UtilsTipos.toInt(txtPEDID_SUCURSAL.Text);
            short PEDID_DC = (short)Utilidades.UtilsTipos.toInt(txtPEDID_DC.Text); 
            string PEDID_CC = txtPEDID_CC.Text; 
            string TIPORT_ID = txtTIPORT_ID.Text;
            var tiport_id = from c in dc.TIPOS_PORTE
                            where c.TIPORT_ID == TIPORT_ID
                            select c;
            if (tiport_id.Count() == 0)
            {
                MessageBox.Show("Error: Tipo de porte no válido");
                this.txtTIPORT_ID.Select();
                return false;
            }

            short PEDID_ENTREGA = (short)Utilidades.UtilsTipos.toInt(txtPEDID_ENTREGA.Text); 
            string PEDID_ANOTACIONES = txtPEDID_ANOTACIONES.Text; 
            string DOCUD_NOMBRE = txtDOCUD_NOMBRE.Text;
            string DOCUD_RAZONSOCIAL = txtDOCUD_RAZONSOCIAL.Text;
            string DOCUD_NIF = txtDOCUD_NIF.Text;
            string DOCUD_DIRECCION = txtDOCUD_DIRECCION.Text;
            string DOCUD_CP = txtDOCU_CP.Text;
            string DOCUD_POBLACION = txtDOCUD_POBLACION.Text;
            string DOCUD_PROVINCIA = txtDOCUD_PROVINCIA.Text;
            string PAIS_ID = txtPAIS_ID.Text;
            var pais_id = from c in dc.PAISES
                          where c.PAIS_ID == PAIS_ID
                          select c;
            if (pais_id.Count() == 0)
            {
                MessageBox.Show("Error: Campo país no válido");
                return false;
            }
            string DOCUD_TELEFONO = txtDOCUD_TELEFONO.Text;
            string DOCUD_TELEFONO1 = txtDOCU_TELEFONO1.Text;
            string DOCUD_MOVIL = txtDOCU_MOVIL.Text;
            string DOCUD_EMAIL = txtDOCUD_EMAIL.Text;
            string DOCUD_WEB = txtDOCUD_WEB.Text;
            string DOCUD_EAN = txtDOCUD_EAN.Text;
            string CLIEGF_ID = null; // No se mete al crear el acta            
            string HORA_AVISO = "";
            if (this.dtpHORA_AVISO.Checked)
            HORA_AVISO = dtpHORA_AVISO.Value.ToString(); // No nulo, necesita validar
            string PEDID_B = ""; // No nulo, necesita validar
            string ARTI_ID = this.txtARTI_ID.Text; //necesita validar
            var arti_id = from c in dc.ARTICULOS
                          where c.ARTI_ID == ARTI_ID
                          select c;
            if (arti_id.Count() == 0)
            {
                ARTI_ID = null;
            }
            int? AGENTE_EXTERNO = Utilidades.UtilsTipos.toIntN(txtAGENTE.Text);
            int? AGENTE_INTERNO = Utilidades.UtilsTipos.toIntN(txtAGENTE.Text);
            int? REPRE_ID = Utilidades.UtilsTipos.toIntN(txtREPRE_ID.Text);            
            string APLICA_PRECIO_MEDIADOR = "1";
            if (xBoxAplicaPrecios.Checked)
            {
                APLICA_PRECIO_MEDIADOR = "0";
            }
            string XML = "<?xml version=\"1.0\" encoding=\"windows-1252\"?><ROOT />";

            this.txtPEDID_ID.Text = ctx.INS(TIPO, USUARIO, DOCU_ID, ref PEDID_ID, PEDID_SUREFERENCIA,
            CLIE_ID, CLIE_ID1, CLIE_ID2, CLIE_ID3, PEDID_FECHA, PEDID_FECHAP, PEDID_FECHAM,
            PEDID_FECHAPG, ALMA_ID, PERS_ID, PERS_ID1, ESTDOC_ID, GRDE_ID, IRPF_ID, PEDID_RECFIN,
            MONEDA_ID, FPAGO_ID, PEDID_ENTIDAD, PEDID_DIRPAGO, PEDID_BANCO, PEDID_SUCURSAL, PEDID_DC,
            PEDID_CC, TIPORT_ID, PEDID_ENTREGA, PEDID_ANOTACIONES, DOCUD_NOMBRE, DOCUD_RAZONSOCIAL,
            DOCUD_NIF, DOCUD_DIRECCION, DOCUD_CP, DOCUD_POBLACION, DOCUD_PROVINCIA, PAIS_ID, DOCUD_TELEFONO,
            DOCUD_TELEFONO1, DOCUD_MOVIL, DOCUD_EMAIL, DOCUD_WEB, DOCUD_EAN, CLIEGF_ID, HORA_AVISO, PEDID_B,
            ARTI_ID, AGENTE_EXTERNO, AGENTE_INTERNO, REPRE_ID, APLICA_PRECIO_MEDIADOR, XML);
            _PEDID_ID = this.txtPEDID_ID.Text;
            MessageBox.Show("Acta creada Correctamente");
            insert = false;
            dc.Dispose();
            return true; 
         
        }


           


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (bloqueo)
            {
                MessageBox.Show("No se pudo guardar el acta. El cliente seleccionado tiene las actas bloqueadas. Por favor, avise al responsable para gestionar el problema debidamente.");                
                return;
            }

            int s = this.tabControlActas.SelectedIndex;
            for (int i = 0; i < this.tabControlActas.TabPages.Count; i++)
            {
                this.tabControlActas.SelectedIndex = i;
            }
            this.tabControlActas.SelectedIndex = s;
            if (!insert)
            {
                CopiarInterlocutoresAlPedido();

                try
                {
                    ValidarDatosUPD();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de programa al ejecutar el método ValidarDatosUPD. Detalle:\n" + ex);
                    return;
                }
                MessageBox.Show("Datos Actualizados Correctamente");

            }
            else
            {
                // Si el pedido es nuevo, copiar los interlocutores
                if (!ValidarDatosINS())
                {
                    return;
                }
                CopiarInterlocutoresAlPedido();
                ValidarDatosUPD();
                
            }
            _PEDID_ID = this.txtPEDID_ID.Text;

            if (plantilla)
            {
                PedidovDetalleCtx ctx = new PedidovDetalleCtx();
                ctx.InsertarPlantillaDetalle(_PEDID_ID_ORIGEN, _PEDID_ID);
                plantilla = false;
            }
        }


        private void AbrirDocumentosConsulta()
        {
            DocumentosVentas.DocumentosConsulta c = new DocumentosVentas.DocumentosConsulta();
            c.tidoc_id = _TIDOC_ID;
            c.usu_id = _USU_ID;
            
            c.ShowDialog();
            if (c.DialogResult == DialogResult.OK)
            {
                this.txtDOCU_ID.Text = c.docu_id;
                _DOCU_ID = c.docu_id;
                this.lblDOCU_DESCRIPCION.Text = c.docu_descripcion; // Validar descripción
            }
            
        }

        private void AbrirPaisesConsulta()
        {
            PaisesConsulta c = new PaisesConsulta();
            c.ShowDialog();
            if (c.DialogResult == DialogResult.OK)
            {
                this.txtPAIS_ID.Text = c.codigo;
                this.lblPAIS_DESCRIPCION.Text = c.descripcion;
            }
        }

        private void AbrirMonedasConsulta()
        {
            MonedasConsulta c = new MonedasConsulta();
            c.ShowDialog();
            if (c.DialogResult == DialogResult.OK)
            {
                this.txtMONEDA_ID.Text = c.codigo;
                this.lblMONEDA_DESCRIPCION.Text = c.descripcion;
            }
        }
        private void AbrirPortesConsulta()
        {
            PortesConsulta c = new PortesConsulta();
            c.ShowDialog();
            if (c.DialogResult == DialogResult.OK)
            {
                this.txtTIPORT_ID.Text = c.codigo;
                this.lblTIPORT_DESCRIPCION.Text = c.descripcion;
            }
        }

        private void AbrirFormasPagoConsulta()
        {
            FormasPagoConsulta c = new FormasPagoConsulta();
            c.ShowDialog();
            if (c.DialogResult == DialogResult.OK)
            {
                this.txtFPAGO_ID.Text = c.codigo.ToString();
                this.lblFPAGO_DESCRIPCION.Text = c.descripcion;
            }
        }

        private void AbrirMediadorConsulta()
        {
            DocumentosVentas.MediadorConsulta c = new DocumentosVentas.MediadorConsulta();
            c.usu_id = _USU_ID;
            if (_CLIE_ID <= 0) // Mejorar esta validación
            {
                MessageBox.Show("Seleccione un cliente Válido");
                return;
            }
            c.clie_id = _CLIE_ID;
            
            c.ShowDialog();
            if(c.DialogResult == DialogResult.OK)
            {
                this.txtREPRE_ID.Text = c.repre_id.ToString();
                this.lblREPRE_DESCRIPCION.Text = c.repre_descripcion;
                this.xBoxAplicaPrecios.Checked = c.aplica_precio;                
            }
        }
        private void AbrirTiposIRPFConsulta()
        {
            TiposIRPFConsulta c = new TiposIRPFConsulta();
            c.usu_id = _USU_ID;
            c.ShowDialog();
            if (c.DialogResult == DialogResult.OK)
            {
                this.txtIRPF_ID.Text = c.codigo.ToString();
                this.lblIRPF_DESCRIPCION.Text = c.descripcion;
            }
        }

        private void AbrirEstadosDocumentoConsulta()
        {
            DocumentosVentas.EstadosDocumentosConsulta c = new DocumentosVentas.EstadosDocumentosConsulta();
            c.docu_id = _DOCU_ID;
            c.usu_id = _USU_ID;
            c.ShowDialog();
            if (c.DialogResult == DialogResult.OK)
            {
                this.txtESTDOC_ID.Text = c.estdoc_id;
                this.lblESTDOC_DESCRIPCION.Text = c.estdoc_descripcion;
            }
        }
        private void AbrirGruposCondicionesConsulta()
        {
            GruposCondicionesConsulta c = new GruposCondicionesConsulta();
            c.usu_id = _USU_ID;
            c.ShowDialog();
            if (c.DialogResult == DialogResult.OK)
            {
                this.txtGRDE_ID.Text = c.codigo.ToString();
                this.lblGRDE_DESCRIPCION.Text = c.descripcion;
            }
        }
        private void AbrirGruposCondicionesConsulta2()
        {
            GruposCondicionesConsulta c = new GruposCondicionesConsulta();
            c.usu_id = _USU_ID;
            c.ShowDialog();
            if (c.DialogResult == DialogResult.OK)
            {
                this.txtPEDID_RECFIN.Text = c.codigo.ToString();
                this.lblGRDE_DESCRIPCION1.Text = c.descripcion;
            }
        }
        private void AbrirPersonalConsulta()
        {
            PersonalConsulta c = new PersonalConsulta();
            c.ShowDialog();
            if (c.DialogResult == DialogResult.OK)
            {
                this.txtPERS_ID.Text = c.pers_id.ToString();
                this.lblPERS_NOMBRE.Text = c.pers_nombre;
                c.Dispose();
            }
        }
        private void AbrirPersonalConsulta2()
        {
            PersonalConsulta c = new PersonalConsulta();
            c.ShowDialog();
            if (c.DialogResult == DialogResult.OK)
            {
                this.txtPERS_ID1.Text = c.pers_id.ToString();
                this.lblPERS_NOMBRE1.Text = c.pers_nombre;
                c.Dispose();
            }
        }
        private void AbrirArticulosConsulta()
        {
            ArticulosConsulta c = new ArticulosConsulta();
            c.ShowDialog();
            if (c.DialogResult == DialogResult.OK)
            {
                this.txtARTI_ID.Text = c.arti_id;
                this.lblARTI_DESCRIPCION.Text = c.arti_descripcion;
            }
        }

        private void AbrirCrearDetalle()
        {  
            PedidovDetalle pd = new PedidovDetalle();

            // Variables a pasar a la ventana llamada
            pd.Documento = _DOCU_ID;
            pd.Numero = _PEDID_ID;
            pd.PedidoIDorigen = _PEDID_ID_ORIGEN;
            pd.ClienteId = Utilidades.UtilsTipos.toInt(this.txtCLIE_ID.Text);
            pd.Cliente = this.txtDOCUD_NOMBRE.Text;
            // Flecos: El tipo de analisis se calcula en la ventana de detalle por ahora
            pd.Matriz = this.txtARTI_ID.Text;
            pd.Descripcion = this.lblARTI_DESCRIPCION.Text;
            bool aplicaPrecioMediador = false; //flecos: Revisar el funcionamiento del mediador.
            if (aplicaPrecioMediador)
            {
                pd.MediadorClieId = Utilidades.UtilsTipos.toInt(txtREPRE_ID.Text);
            }            
            int maxLinea = 0;
            DataTable lineas = Utilidades.UtilsLinq.LINQResultToDataTable(detalle);
            if (lineas != null && lineas.Rows.Count > 0)
            {
                maxLinea = Convert.ToInt32(lineas.Compute("MAX(PEDIDL_LINEA)", string.Empty));
            }
            pd.MaxLinea = maxLinea; 
            pd.usuario = _USU_ID;
            pd.plantilla = this.plantilla;
            
            pd.ShowDialog();
            if (pd.DialogResult == DialogResult.OK)
            {
                this.fdlv2.DataSource = this.ctx.PEDIDOSV_LI_SEL(_USU_ID, _DOCU_ID, _PEDID_ID);
                ValidarDatosUPD();
                this.plantilla = pd.plantilla;
                MessageBox.Show("Detalle guardado correctamente");
            }
        }

        private void Pedidosv_Load(object sender, EventArgs e)
        {            
            LimpiarActa(); // Borrar todos los campos editables
            InicializarCampos(); // Poner valores por defecto
            InicializarControlesActa();           
        }

        private void InicializarControlesActa()
        {            
            this.txtPEDID_ID.Enabled = false;
            this.txtREGLAB_ID.Enabled = false;
        }

        private void lblDocumento_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AbrirDocumentosConsulta();
        }

        private void lblEstado_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AbrirEstadosDocumentoConsulta();
        }

        private void lblSolicitante_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AbrirClientesConsulta();
        }

        private void lblNumActa_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AbrirPedidosConsulta();
        }

        private void lblEnvio_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AbrirClientesConsulta(txtCLIE_ID1, lblCLIE_DESCRIPCION1);
        }

        private void lblFacturacion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AbrirClientesConsulta(txtCLIE_ID2, lblCLIE_DESCRIPCION2);
        }

        private void lblPago_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AbrirClientesConsulta(txtCLIE_ID3, lblCLIE_DESCRIPCION3);
        }

        private void lblMediador_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AbrirMediadorConsulta();
        }

        private void btnAbrirInterloc_Click(object sender, EventArgs e)
        {
            
            AbrirInterlocutoresConsulta();
        }

        private void lblMatriz_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AbrirArticulosConsulta();
        }
        
        private void lblCondiciones_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AbrirGruposCondicionesConsulta();
        }

        private void lblIRPF_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AbrirTiposIRPFConsulta();
        }

        private void lblRecFinanciero_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AbrirGruposCondicionesConsulta2();
        }

        private void lblMoneda_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AbrirMonedasConsulta();
        }

        private void lblFormaPago_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AbrirFormasPagoConsulta();
        }


        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblPortes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AbrirPortesConsulta();
        }

        private void lblPais_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AbrirPaisesConsulta();
        }

        private void lblReceptor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AbrirPersonalConsulta();
        }

        private void lblRecogida_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AbrirPersonalConsulta2();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblCrearDetalle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            PedidosDBDataContext dc = new PedidosDBDataContext();
            string PEDID_ID = txtPEDID_ID.Text;
            var pedid_id = from p in dc.PEDIDOSV
                           where p.PEDID_ID == PEDID_ID
                           select p;

            if (pedid_id.Count() == 0)
            {
                MessageBox.Show("Debe guardar el pedido antes de crear el detalle");
                insert = true;
                return;
            }
            string ARTI_ID = txtARTI_ID.Text;
            var arti_id = from a in dc.ARTICULOS
                          where a.ARTI_ID == ARTI_ID
                          select a;
            if (arti_id.Count() == 0)
            {
                MessageBox.Show("Indique la matriz antes de crear el detalle");
                return;
            }

            AbrirCrearDetalle();
            

        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            LimpiarActa();
            InicializarCampos();
            InicializarControlesActa();
            insert = true;
            this.tabControlActas.SelectedIndex = 0;
            plantilla = false;
        }

        private void tabControlActas_TabIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void tabControlActas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.txtCLIE_ID.Text == string.Empty && tabControlActas.SelectedIndex != 0)
            {
                MessageBox.Show("Debe indicar el cliente antes de seguir rellenando los datos del pedido");
                this.tabControlActas.SelectedIndex = 0;
            }
        }

        private void pEDIDOSV_SELResultBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }


        private void linkLabel41_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void lblkAnotaciones_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.tabControlActas.SelectTab(6);
        }

        private void lblkActa_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.tabControlActas.SelectedIndex = 0;
        }

        private void btnAbrirPlantilla_Click(object sender, EventArgs e)
        {
            AbrirPedidosConsulta();
            this._PEDID_ID_ORIGEN = this.txtPEDID_ID.Text;
            this.txtPEDID_ID.Text = "";
            this._PEDID_ID = txtPEDID_ID.Text;
            this.txtREGLAB_ID.Text = string.Empty;
            insert = true;
            plantilla = true;
        }

        private void txtCLIE_ID_TextChanged(object sender, EventArgs e)
        {
            // Cierra alertas previas
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == typeof(Auxiliares.Alertas.AlertaPopUp))
                {
                    frm.Close();
                    frm.Dispose();
                    break;
                }
            }

            PedidosDBDataContext dc = new PedidosDBDataContext();
            
            var cliente = from c in dc.CLIENTES
                          where c.CLIE_ID == Utilidades.UtilsTipos.toInt(txtCLIE_ID.Text)
                          select c;
            if (cliente.Count() != 0)
            {
                // Comprobación de bloqueos
                var cliente_bloqueo = from cb in dc.CLIENTE_BLOQUEO
                                      where cb.CLIE_ID == cliente.First().CLIE_ID && cb.ACTA == true
                                      select cb.CLIE_ID;
                if (cliente_bloqueo.Count() > 0)
                {
                    MessageBox.Show("El cliente seleccionado tiene las actas bloqueadas. Por favor, avise al responsable para gestionar el problema debidamente.");
                    bloqueo = true;
                    return;
                }
                else
                {
                    bloqueo = false;
                }
                // Comprobación de alertas
                Auxiliares.Alertas.AlertaPopUp popup = new Auxiliares.Alertas.AlertaPopUp();
                popup.docu_id = _DOCU_ID;
                popup.clie_id = cliente.First().CLIE_ID;
                popup.Text = cliente.First().CLIE_DESCRIPCION;
                popup.Visible = false;
                popup.Show();
                if (popup.mensajes == 0)
                {
                    popup.Close();
                    popup.Dispose();
                }
                else
                {
                    popup.Visible = true;
                    popup.TopMost = true;
                }
                
            }
            dc.Dispose();
         
            
        }

        private void lblAplica_TextChanged(object sender, EventArgs e)
        {
            if (this.lblAplica.Text == "0")
            {
                this.xBoxAplicaPrecios.Checked = true;
            }
            else
            {
                this.xBoxAplicaPrecios.Checked = false;
            }
        }

        private void lblRegLab_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistroLaboratorioPedidoV reglab = new RegistroLaboratorioPedidoV();
            reglab.ShowDialog();

            // Variables a pasar a la ventana llamada
            //pd.Documento = _DOCU_ID;
            //pd.Numero = _PEDID_ID;
            //pd.PedidoIDorigen = _PEDID_ID_ORIGEN;
            //pd.ClienteId = toInt(this.txtCLIE_ID.Text);
            //pd.Cliente = this.txtDOCUD_NOMBRE.Text;
            //// Flecos: El tipo de analisis se calcula en la ventana de detalle por ahora
            //pd.Matriz = this.txtARTI_ID.Text;
            //pd.Descripcion = this.lblARTI_DESCRIPCION.Text;
            //bool aplicaPrecioMediador = false; //flecos: Revisar el funcionamiento del mediador.
            //if (aplicaPrecioMediador)
            //{
            //    pd.MediadorClieId = toInt(txtREPRE_ID.Text);
            //}
            //int maxLinea = 0;
            //DataTable lineas = Utilidades.UtilsLinq.LINQResultToDataTable(detalle);
            //if (lineas != null && lineas.Rows.Count > 0)
            //{
            //    maxLinea = Convert.ToInt32(lineas.Compute("MAX(PEDIDL_LINEA)", string.Empty));
            //}
            //pd.MaxLinea = maxLinea;
            //pd.usuario = _USU_ID;
            //pd.plantilla = this.plantilla;

            //pd.ShowDialog();
            //if (pd.DialogResult == DialogResult.OK)
            //{
            //    this.fdlv2.DataSource = this.ctx.PEDIDOSV_LI_SEL(_USU_ID, _DOCU_ID, _PEDID_ID);
            //    ValidarDatosUPD();
            //    this.plantilla = pd.plantilla;
            //    MessageBox.Show("Detalle guardado correctamente");
            //}
        }

        private void AbrirRLAB()
        {
            // Se monta el objeto pedido para enviarlo al RLAB
            PedidosDBDataContext ctx = new PedidosDBDataContext();
            PEDIDOSV pv;
            var pedido = from este in ctx.PEDIDOSV
                         where este.DOCU_ID == txtDOCU_ID.Text && este.PEDID_ID == txtPEDID_ID.Text
                         select este;
            if (pedido.Count() > 0)
                pv = pedido.First();

            else
            {
                MessageBox.Show("Error al intentar abrir la ventana de RLAB. El pedido aun no se ha guardado");
                return;
            }
            // Validar matriz
            var articulo = from matriz in ctx.ARTICULOS
                           where matriz.ARTI_ID == pv.ARTI_ID
                           select matriz;
            if (articulo.Count() == 0)
            {
                MessageBox.Show("No se puede crear RLAB si no hay una matriz válida");
                return;
            }
            RegistroLaboratorioPedidoV rlab = new RegistroLaboratorioPedidoV();
            rlab._USUARIO = this._USU_ID;
            rlab._Pedido = pv;
            rlab.ShowDialog();
            if (rlab.DialogResult == DialogResult.OK)
            {
                this.txtREGLAB_ID.Text = rlab._Reglab_ID;
            }
        }

        private void btnRegLab_Click(object sender, EventArgs e)
        {
            AbrirRLAB(); 
        }

        private void btnRLAB_Click(object sender, EventArgs e)
        {
            AbrirRLAB();
        }

        private void btnRLABlateral_Click(object sender, EventArgs e)
        {
            AbrirRLAB();
        }

    }
}
