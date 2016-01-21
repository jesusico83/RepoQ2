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
    public partial class RegistroLaboratorioPedidoV : Form
    {
        // Datos de la ventana llamante

        public string _USUARIO;

        // Desde la ventana llamante (PEDIDOSV), se le pasa un objeto con todos los datos del pedido.
        public PEDIDOSV _Pedido;
        public string _Reglab_ID;
        
        public RegistroLaboratorioPedidoV()
        {
            InitializeComponent();
        }

        // Objeto que almacena todos los datos del formulario vinculados a la base de datos
        REGISTROLAB _REGISTROLAB_NUEVO;
        REGISTROLAB _REGLAB_EXISTENTE;

        private void RegistroLaboratorioPedidoV_Load(object sender, EventArgs e)
        {
            LimpiarRlab();

            // Comprobar si ya existe REGLAB asociado al acta.
            _REGLAB_EXISTENTE = ComprobarSiExisteRlab();

            if (_REGLAB_EXISTENTE != null)
            {
                // Carga todos los datos del registro de laboratorio asociado al pedido y los 
                // coloca en los lugares correspondientes del Formulario
                CargarRLAB();

                // Coloca sobre el formulario los campos que no pertenecen a la tabla REGISTROLAB 
                // que son descriptivos y además no se van a modificar durante la edición del registro.
                ValidarOtrosCamposNoEditables();
            }
            else
            {
                GenerarNuevoRLAB();
            }
                           

        }
        private REGISTROLAB ComprobarSiExisteRlab()
        {
            PedidosDBDataContext ctx = new PedidosDBDataContext();
            var rlab = from registro in ctx.REGISTROLAB
                       where registro.DOCU_ID_ORIGEN == _Pedido.DOCU_ID && registro.DOCU_NUMERO_ORIGEN == _Pedido.PEDID_ID
                       select registro;
            if (rlab.Count() > 0)
            {
                return rlab.First();
            }
            else
                return null;
        }
        private void CargarRLAB()
        {
            lblARTI_ID1.Text = _REGLAB_EXISTENTE.ARTI_ID1.ToString();
            lblCLIE_ID.Text = _REGLAB_EXISTENTE.CLIE_ID.ToString();
            lblDOCU_ID.Text = _REGLAB_EXISTENTE.DOCU_ID;
            lblDOCU_ID_ORIGEN.Text = _REGLAB_EXISTENTE.DOCU_ID_ORIGEN;
            lblDOCU_NUMERO_ORIGEN.Text = _REGLAB_EXISTENTE.DOCU_NUMERO_ORIGEN;
            txtMUESTRA_DESCRIPCION.Text = _REGLAB_EXISTENTE.MUESTRA_DESCRIPCION;
            txtMUESTRA_OBSERVACIONES.Text = _REGLAB_EXISTENTE.MUESTRA_OBSERVACIONES;
            txtMUESTRA_REF1.Text = _REGLAB_EXISTENTE.MUESTRA_REF1;
            txtMUESTRA_REF2.Text = _REGLAB_EXISTENTE.MUESTRA_REF2;
            txtMUESTRA_REF3.Text = _REGLAB_EXISTENTE.MUESTRA_REF3;
            txtMUESTREADOR_PERS_ID.Text = _REGLAB_EXISTENTE.MUESTREADOR_PERS_ID.ToString();
            txtNIVURG_ID.Text = _REGLAB_EXISTENTE.NIVURG_ID.ToString();
            txtRECOGEDOR_PERS_ID.Text = _REGLAB_EXISTENTE.RECOGEDOR_PERS_ID.ToString();
            txtREGLAB_ANOTACIONES.Text = _REGLAB_EXISTENTE.REGLAB_ANOTACIONES;
            txtREGLAB_EMPRESAMUESTREO.Text = _REGLAB_EXISTENTE.REGLAB_EMPRESAMUESTREO;
            txtREGLAB_EMPRESARECOGIDA.Text = _REGLAB_EXISTENTE.REGLAB_EMPRESARECOGIDA;
            try { dtpFechaEntradaMuestra.Value = Convert.ToDateTime(_REGLAB_EXISTENTE.REGLAB_FECHA); }
            catch (Exception) { dtpFechaEntradaMuestra.Checked = false; }
            try { dtpREGLAB_FECHAMAXIMA.Value = Convert.ToDateTime(_REGLAB_EXISTENTE.REGLAB_FECHAMAXIMA); }
            catch (Exception) { dtpREGLAB_FECHAMAXIMA.Checked = false; }
            try { dtpREGLAB_FECHAMUESTREO.Value = Convert.ToDateTime(_REGLAB_EXISTENTE.REGLAB_FECHAMUESTREO); }
            catch (Exception) { dtpREGLAB_FECHAMUESTREO.Checked = false; }
            try { dtpREGLAB_FECHARECOGIDA.Value = Convert.ToDateTime(_REGLAB_EXISTENTE.REGLAB_FECHARECOGIDA); }
            catch (Exception) { dtpREGLAB_FECHARECOGIDA.Checked = false; }
            try { dtpHoraEntradaMuestra.Value = Convert.ToDateTime(_REGLAB_EXISTENTE.REGLAB_HORA); }
            catch (Exception) { dtpHoraEntradaMuestra.Checked = false; }
            try { dtpREGLAB_HORAMAXIMA.Value = Convert.ToDateTime(_REGLAB_EXISTENTE.REGLAB_HORAMAXIMA); }
            catch (Exception) { dtpREGLAB_HORAMAXIMA.Checked = false; }
            try { dtpREGLAB_HORAMUESTREO.Value = Convert.ToDateTime(_REGLAB_EXISTENTE.REGLAB_HORAMUESTREO); }
            catch (Exception) { dtpREGLAB_HORAMUESTREO.Checked = false; }
            try { dtpREGLAB_HORARECOGIDA.Value = Convert.ToDateTime(_REGLAB_EXISTENTE.REGLAB_HORARECOGIDA); }
            catch (Exception) { dtpREGLAB_HORARECOGIDA.Checked = false; }
            lblREGLAB_ID.Text = _REGLAB_EXISTENTE.REGLAB_ID;
            txtREGLAB_MUESTREADOR.Text = _REGLAB_EXISTENTE.REGLAB_MUESTREADOR;
            txtREGLAB_PERSONAENTRADA.Text = _REGLAB_EXISTENTE.REGLAB_PERSONAENTRADA.ToString();
            txtREGLAB_RECOGEDOR.Text = _REGLAB_EXISTENTE.REGLAB_RECOGEDOR;
            txtSUREFERENCIA.Text = _REGLAB_EXISTENTE.SUREFERENCIA;
        }
        private void ValidarOtrosCamposNoEditables()
        {
            PedidosDBDataContext ctx = new PedidosDBDataContext();
            // Validar Cliente (Rellena el campo descripción)
            int c = Utilidades.UtilsTipos.toInt(lblCLIE_ID.Text);
            var cliente = from cli in ctx.CLIENTES
                          where cli.CLIE_ID == c
                          select cli.CLIE_DESCRIPCION;
            if (cliente.Count() > 0)
            {
                lblCLIE_DESCRIPCION.Text = cliente.First();
            }
            else
            {
                lblCLIE_DESCRIPCION.Text = string.Empty;
            }

            // Validar Matriz (Rellena ARTI_ID y ARTI_DESCRIPCIÓN, a partir de ARTI_ID1)
            int m = Utilidades.UtilsTipos.toInt(lblARTI_ID1.Text);
            var matriz = from mt in ctx.ARTICULOS
                         where mt.ARTI_ID1 == m
                         select new { mt.ARTI_ID, mt.ARTI_DESCRIPCION };
            if (matriz.Count() > 0)
            {
                lblARTI_ID.Text = matriz.First().ARTI_ID;
                lblARTI_DESCRIPCION.Text = matriz.First().ARTI_DESCRIPCION;
            }
            else
            {
                lblARTI_DESCRIPCION.Text = string.Empty;
            }

            // Validar Documento
            var documento = from doc in ctx.DOCUMENTOS
                            where doc.DOCU_ID == lblDOCU_ID_ORIGEN.Text
                            select doc.DOCU_DESCRIPCION;
            if (documento.Count() > 0)
            {
                lblDOCU_DESCRIPCION.Text = documento.First();
            }
            else lblDOCU_DESCRIPCION.Text = string.Empty;
            ctx.Dispose();            
        }
        
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // A ejecutar cuando no hay REGLAB asociado al pedido
        private void GenerarNuevoRLAB()
        {
            PedidosDBDataContext ctx = new PedidosDBDataContext();
            // Obtener el cliente
            this.lblCLIE_ID.Text = this._Pedido.CLIE_ID.ToString();

            // Obtener matriz
            string arti_id = _Pedido.ARTI_ID;
            var matriz = from articulo in ctx.ARTICULOS
                         where articulo.ARTI_ID == arti_id
                         select articulo.ARTI_ID1;
            if (matriz.Count() > 0)
            {
                lblARTI_ID1.Text = matriz.First().ToString();
            }

            lblDOCU_ID.Text = "RLAB"; // _REGISTROLAB.DOCU_ID
            lblDOCU_ID_ORIGEN.Text = this._Pedido.DOCU_ID;
            lblDOCU_NUMERO_ORIGEN.Text = this._Pedido.PEDID_ID;

            ValidarOtrosCamposNoEditables();

            dtpFechaEntradaMuestra.Value = DateTime.Now; // REGLAB_FECHA en formato toString("yyyy-MM-dd")
            dtpHoraEntradaMuestra.Value = DateTime.Now; // REGLAB_HORA en formato toString("HH:mm");  

            cbREGLAB_EMPRESAMUESTREO.SelectedIndex = 0;
            cbREGLAB_EMPRESARECOGIDA.SelectedIndex = 0;

            BuscarUsuario();             
           
        }
        private void BuscarUsuario()
        {
            // Llamar al proc. alm. que valida el usuario.
            PedidosDBDataContext ctx = new PedidosDBDataContext();

            // Consulta Linq para obtener el nombre de la persona que rellena el registro
            string pers_id, pers_nombre;
            var query = from usuario in ctx.USUARIOS
                        join persona in ctx.PERSONAL on usuario.USU_ID equals persona.USU_ID
                        where (usuario.USU_ID == _USUARIO)
                        select new { persona.PERS_ID, persona.PERS_NOMBRE };
            
            List<string> per_usu = new List<string>();
            if (query.Count() > 0)
            {
                pers_id = query.First().PERS_ID.ToString();
                pers_nombre = query.First().PERS_NOMBRE;
                this.txtREGLAB_PERSONAENTRADA.Text = pers_id; // REGLAB_PERSONAENTRADA
                this.lblPERS_NOMBRE.Text = pers_nombre; // Solo descriptivo. No va a bbdd
            }
            ctx.Dispose();
        }
        private void LimpiarRlab()
        {
            foreach (Control grbox in this.Controls)
            {
                if (grbox is GroupBox)
                {
                    foreach (Control c in grbox.Controls)
                    {
                        if (c is MaskedTextBox)
                        {
                            ((MaskedTextBox)c).Text = string.Empty;
                        }
                        if (c is Label && !(c is LinkLabel))
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
        }
        
        private void Autocompleta(TextBox tb)
        {
            PedidosDBDataContext ctx = new PedidosDBDataContext();
            AutoCompleteStringCollection a = new AutoCompleteStringCollection();
            if(txtREGLAB_EMPRESAMUESTREO.Text == "0")
            {
                tb.AutoCompleteMode = AutoCompleteMode.Append;
                var nombres = from n in ctx.PERSONAL
                          select n.PERS_NOMBRE;                
                List<string> lista = nombres.ToList(); 
                foreach (string s in lista)
                {
                    a.Add(s);
                }
                tb.AutoCompleteCustomSource = a;                     
            }
            else
            {
                tb.AutoCompleteMode = AutoCompleteMode.None;
                tb.AutoCompleteSource = AutoCompleteSource.None;
                return;
            }
        }
        private void CopiarRLABdeFormulario()
        {            
            _REGISTROLAB_NUEVO = new REGISTROLAB();
            _REGISTROLAB_NUEVO.ARTI_ID1 = Utilidades.UtilsTipos.toInt(lblARTI_ID1.Text);
            _REGISTROLAB_NUEVO.CLIE_ID = Utilidades.UtilsTipos.toIntN(lblCLIE_ID.Text);
            _REGISTROLAB_NUEVO.DOCU_ID = lblDOCU_ID.Text;
            _REGISTROLAB_NUEVO.DOCU_ID_ORIGEN = lblDOCU_ID_ORIGEN.Text;
            _REGISTROLAB_NUEVO.DOCU_NUMERO_ORIGEN = lblDOCU_NUMERO_ORIGEN.Text;
            if (xbEstado.Checked)
            {
                // Cambiar si se genera orden de trabajo desde fuera
                _REGISTROLAB_NUEVO.ESTDOC_ID = "PEN";
            }
            _REGISTROLAB_NUEVO.MUESTRA_DESCRIPCION = txtMUESTRA_DESCRIPCION.Text;
            _REGISTROLAB_NUEVO.MUESTRA_OBSERVACIONES = txtMUESTRA_OBSERVACIONES.Text;
            _REGISTROLAB_NUEVO.MUESTRA_REF1 = txtMUESTRA_REF1.Text;
            _REGISTROLAB_NUEVO.MUESTRA_REF2 = txtMUESTRA_REF2.Text;
            _REGISTROLAB_NUEVO.MUESTRA_REF3 = txtMUESTRA_REF3.Text;
            _REGISTROLAB_NUEVO.MUESTREADOR_PERS_ID = Utilidades.UtilsTipos.toIntN(txtMUESTREADOR_PERS_ID.Text);
            _REGISTROLAB_NUEVO.NIVURG_ID = Utilidades.UtilsTipos.toIntN(txtNIVURG_ID.Text);
            _REGISTROLAB_NUEVO.RECOGEDOR_PERS_ID = Utilidades.UtilsTipos.toIntN(txtRECOGEDOR_PERS_ID.Text);
            _REGISTROLAB_NUEVO.REGLAB_ANOTACIONES = txtREGLAB_ANOTACIONES.Text;
            _REGISTROLAB_NUEVO.REGLAB_EMPRESAMUESTREO = txtREGLAB_EMPRESAMUESTREO.Text;
            _REGISTROLAB_NUEVO.REGLAB_EMPRESARECOGIDA = txtREGLAB_EMPRESARECOGIDA.Text;
            if (dtpFechaEntradaMuestra.Checked)
                _REGISTROLAB_NUEVO.REGLAB_FECHA = dtpFechaEntradaMuestra.Value.ToString("yyyy-MM-dd");
            else _REGISTROLAB_NUEVO.REGLAB_FECHA = "";
            if (dtpREGLAB_FECHAMAXIMA.Checked)
                _REGISTROLAB_NUEVO.REGLAB_FECHAMAXIMA = dtpREGLAB_FECHAMAXIMA.Value.ToString("yyyy-MM-dd");
            else _REGISTROLAB_NUEVO.REGLAB_FECHAMAXIMA = "";
            if (dtpREGLAB_FECHAMUESTREO.Checked)
                _REGISTROLAB_NUEVO.REGLAB_FECHAMUESTREO = dtpREGLAB_FECHAMUESTREO.Value.ToString("yyyy-MM-dd");
            else _REGISTROLAB_NUEVO.REGLAB_FECHAMUESTREO = "";
            if (dtpREGLAB_FECHARECOGIDA.Checked)
                _REGISTROLAB_NUEVO.REGLAB_FECHARECOGIDA = dtpREGLAB_FECHARECOGIDA.Value.ToString("yyyy-MM-dd");
            else _REGISTROLAB_NUEVO.REGLAB_FECHARECOGIDA = "";
            if (dtpHoraEntradaMuestra.Checked)
                _REGISTROLAB_NUEVO.REGLAB_HORA = dtpHoraEntradaMuestra.Value.ToString("HH:mm");
            else _REGISTROLAB_NUEVO.REGLAB_HORAMAXIMA = "";
            if (dtpREGLAB_HORAMAXIMA.Checked)
                _REGISTROLAB_NUEVO.REGLAB_HORAMAXIMA = dtpREGLAB_HORAMAXIMA.Value.ToString("HH:mm");
            else _REGISTROLAB_NUEVO.REGLAB_HORAMAXIMA = "";
            if (dtpREGLAB_HORAMUESTREO.Checked)
                _REGISTROLAB_NUEVO.REGLAB_HORAMUESTREO = dtpREGLAB_HORAMUESTREO.Value.ToString("HH:mm");
            else _REGISTROLAB_NUEVO.REGLAB_HORAMUESTREO = "";
            if (dtpREGLAB_HORARECOGIDA.Checked)
                _REGISTROLAB_NUEVO.REGLAB_HORARECOGIDA = dtpREGLAB_HORARECOGIDA.Value.ToString("HH:mm");
            else _REGISTROLAB_NUEVO.REGLAB_HORARECOGIDA = "";
            _REGISTROLAB_NUEVO.REGLAB_ID = lblREGLAB_ID.Text;
            _REGISTROLAB_NUEVO.REGLAB_MUESTREADOR = txtREGLAB_MUESTREADOR.Text;
            _REGISTROLAB_NUEVO.REGLAB_PERSONAENTRADA = Utilidades.UtilsTipos.toInt(txtREGLAB_PERSONAENTRADA.Text);
            _REGISTROLAB_NUEVO.REGLAB_RECOGEDOR = txtREGLAB_RECOGEDOR.Text;
            _REGISTROLAB_NUEVO.REGLAB_XML = "";
            _REGISTROLAB_NUEVO.SUREFERENCIA = txtSUREFERENCIA.Text;            
        }
        

        private void UpdateRLAB()
        {
            RegistroLaboratorioPedidoVDBDataContext ctx = new RegistroLaboratorioPedidoVDBDataContext();
            PedidosDBDataContext pvctx = new PedidosDBDataContext();                   
            var rlab = from r in pvctx.REGISTROLAB
                       where r.DOCU_ID == _REGISTROLAB_NUEVO.DOCU_ID && r.REGLAB_ID == _REGISTROLAB_NUEVO.REGLAB_ID
                       select r;
            if (rlab.Count() > 0)
            {
                try
                {
                    ctx.REGISTROLAB_UPD1(0, _USUARIO, _REGISTROLAB_NUEVO.DOCU_ID, _REGISTROLAB_NUEVO.REGLAB_ID, _REGISTROLAB_NUEVO.REGLAB_FECHA,
                        _REGISTROLAB_NUEVO.ARTI_ID1, _REGISTROLAB_NUEVO.REGLAB_ANOTACIONES, _REGISTROLAB_NUEVO.REGLAB_XML, _REGISTROLAB_NUEVO.SUREFERENCIA,
                        _REGISTROLAB_NUEVO.CLIE_ID, _REGISTROLAB_NUEVO.NIVURG_ID, _REGISTROLAB_NUEVO.REGLAB_HORA, _REGISTROLAB_NUEVO.REGLAB_FECHAMUESTREO,
                        _REGISTROLAB_NUEVO.REGLAB_HORAMUESTREO, _REGISTROLAB_NUEVO.REGLAB_FECHAMAXIMA, _REGISTROLAB_NUEVO.REGLAB_HORAMAXIMA, _REGISTROLAB_NUEVO.REGLAB_EMPRESAMUESTREO, _REGISTROLAB_NUEVO.REGLAB_MUESTREADOR, _REGLAB_EXISTENTE.REGLAB_FECHARECOGIDA,
                        _REGISTROLAB_NUEVO.REGLAB_HORARECOGIDA, _REGISTROLAB_NUEVO.REGLAB_EMPRESARECOGIDA, _REGISTROLAB_NUEVO.REGLAB_RECOGEDOR,
                        _REGISTROLAB_NUEVO.REGLAB_PERSONAENTRADA, _REGISTROLAB_NUEVO.MUESTRA_DESCRIPCION, _REGISTROLAB_NUEVO.MUESTRA_REF1,
                        _REGISTROLAB_NUEVO.MUESTRA_REF2, _REGISTROLAB_NUEVO.MUESTRA_REF3, _REGISTROLAB_NUEVO.MUESTRA_OBSERVACIONES,
                        _REGISTROLAB_NUEVO.MUESTREADOR_PERS_ID, _REGISTROLAB_NUEVO.RECOGEDOR_PERS_ID);
                    _REGISTROLAB_NUEVO.REGLAB_ID = _Reglab_ID;
                    MessageBox.Show("Documento Actualizado Correctamente");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Casque en " + e);
                }


                // Alternativa al procedimiento almacenado
                /*foreach (REGISTROLAB r in rlab)
                {
                    r.ARTI_ID1 = _REGISTROLAB_NUEVO.ARTI_ID1;
                    r.CLIE_ID = _REGISTROLAB_NUEVO.CLIE_ID;
                    r.DOCU_ID = _REGISTROLAB_NUEVO.DOCU_ID;
                    r.REGLAB_FECHAMAXIMA = _REGISTROLAB_NUEVO.REGLAB_FECHAMAXIMA;
                    // poner los demás
                }
                try
                {
                    pvctx.SubmitChanges();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Casque en " + e);
                }*/
            }
            else
            {
                MessageBox.Show("No se puede actualizar si no existe RLAB válido");
            }

        }
        private bool validarPersonaFitosoil(int pers_id)
        {
            PedidosDBDataContext ctx = new PedidosDBDataContext();
            var persona = from p in ctx.PERSONAL
                          where p.PERS_ID == pers_id
                          select p;
            if (persona.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void InsertRLAB()
        {
            RegistroLaboratorioPedidoVDBDataContext ctx = new RegistroLaboratorioPedidoVDBDataContext();
           
            try
            {
                ctx.REGISTROLAB_INS2(0, _USUARIO, _REGISTROLAB_NUEVO.DOCU_ID, ref _Reglab_ID, _REGISTROLAB_NUEVO.ESTDOC_ID,
                    _REGISTROLAB_NUEVO.REGLAB_FECHA, _REGISTROLAB_NUEVO.DOCU_ID_ORIGEN, _REGISTROLAB_NUEVO.DOCU_NUMERO_ORIGEN,
                    _REGISTROLAB_NUEVO.ARTI_ID1, _REGISTROLAB_NUEVO.REGLAB_ANOTACIONES, _REGISTROLAB_NUEVO.REGLAB_XML,
                    _REGISTROLAB_NUEVO.SUREFERENCIA, _REGISTROLAB_NUEVO.CLIE_ID, _REGISTROLAB_NUEVO.NIVURG_ID,
                    _REGISTROLAB_NUEVO.REGLAB_HORA, _REGISTROLAB_NUEVO.REGLAB_FECHAMUESTREO, _REGISTROLAB_NUEVO.REGLAB_HORAMUESTREO,
                    _REGISTROLAB_NUEVO.REGLAB_FECHAMAXIMA, _REGISTROLAB_NUEVO.REGLAB_HORAMAXIMA, _REGISTROLAB_NUEVO.REGLAB_EMPRESAMUESTREO,
                    _REGISTROLAB_NUEVO.REGLAB_MUESTREADOR, _REGISTROLAB_NUEVO.REGLAB_FECHARECOGIDA, _REGISTROLAB_NUEVO.REGLAB_HORARECOGIDA,
                    _REGISTROLAB_NUEVO.REGLAB_EMPRESARECOGIDA, _REGISTROLAB_NUEVO.REGLAB_RECOGEDOR, _REGISTROLAB_NUEVO.REGLAB_PERSONAENTRADA,
                    _REGISTROLAB_NUEVO.MUESTRA_DESCRIPCION, _REGISTROLAB_NUEVO.MUESTRA_REF1, _REGISTROLAB_NUEVO.MUESTRA_REF2,
                    _REGISTROLAB_NUEVO.MUESTRA_REF3, _REGISTROLAB_NUEVO.MUESTRA_OBSERVACIONES, _REGISTROLAB_NUEVO.MUESTREADOR_PERS_ID,
                    _REGISTROLAB_NUEVO.RECOGEDOR_PERS_ID);
                _REGISTROLAB_NUEVO.REGLAB_ID = _Reglab_ID;
                MessageBox.Show("Documento guardado Correctamente");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al insertar " + e);
            }
            
        }


        private void txtREGLAB_EMPRESAMUESTREO_TextChanged(object sender, EventArgs e)
        {
            
            if (txtREGLAB_EMPRESAMUESTREO.Text == "1")
            {
                cbREGLAB_EMPRESAMUESTREO.SelectedIndex = 1;
            }
            else
                cbREGLAB_EMPRESAMUESTREO.SelectedIndex = 0;
        }
        private void REGLAB_EMPRESARECOGIDA_TextChanged(object sender, EventArgs e)
        {
            if (txtREGLAB_EMPRESARECOGIDA.Text == "1")
                cbREGLAB_EMPRESARECOGIDA.SelectedIndex = 1;
            else
                cbREGLAB_EMPRESARECOGIDA.SelectedIndex = 0;
        }

        private void cbREGLAB_EMPRESAMUESTREO_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbREGLAB_EMPRESAMUESTREO.SelectedIndex == 0)
                txtREGLAB_EMPRESAMUESTREO.Text = "0";
            else
            {
                txtREGLAB_EMPRESAMUESTREO.Text = "1";
                txtREGLAB_MUESTREADOR.Text = string.Empty;
                txtMUESTREADOR_PERS_ID.Text = string.Empty;
            }
        }
        private void cbREGLAB_EMPRESARECOGIDA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbREGLAB_EMPRESARECOGIDA.SelectedIndex == 0)
                txtREGLAB_EMPRESARECOGIDA.Text = "0";
            else
            {
                txtREGLAB_EMPRESARECOGIDA.Text = "1";
                txtREGLAB_RECOGEDOR.Text = string.Empty;
                txtMUESTREADOR_PERS_ID.Text = string.Empty;
            }
        }        

        private void lblResponsableMuestreo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PersonalConsulta c;            
            if (txtREGLAB_EMPRESAMUESTREO.Text == "0")
            {
                c = new PersonalConsulta();
                c.ShowDialog();
                if (c.DialogResult == DialogResult.OK)
                {
                    this.txtMUESTREADOR_PERS_ID.Text = c.pers_id.ToString();
                    this.txtREGLAB_MUESTREADOR.Text = c.pers_nombre;
                    c.Dispose();
                    if (txtREGLAB_EMPRESARECOGIDA.Text == "0")
                    {

                        txtRECOGEDOR_PERS_ID.Text = txtMUESTREADOR_PERS_ID.Text;
                        txtREGLAB_RECOGEDOR.Text = txtREGLAB_MUESTREADOR.Text;
                    }
                }
            }
            else
            {
                InterlocutoresConsulta2 i2 = new InterlocutoresConsulta2();
                i2.clie_id = Utilidades.UtilsTipos.toInt(lblCLIE_ID.Text);
                i2.ShowDialog();
                if (i2.DialogResult == DialogResult.OK)
                {
                    txtREGLAB_MUESTREADOR.Text = i2.nombre;
                    txtMUESTREADOR_PERS_ID.Text = "";
                }
            }
        }  
        private void lblResponsableRecogedor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PersonalConsulta c = new PersonalConsulta();
            if (txtREGLAB_EMPRESARECOGIDA.Text == "0")
            {
                c.ShowDialog();
                if (c.DialogResult == DialogResult.OK)
                {
                    this.txtRECOGEDOR_PERS_ID.Text = c.pers_id.ToString();
                    this.txtREGLAB_RECOGEDOR.Text = c.pers_nombre;

                }
            }
            else
            {
                InterlocutoresConsulta2 i2 = new InterlocutoresConsulta2();
                i2.clie_id = Utilidades.UtilsTipos.toInt(lblCLIE_ID.Text);
                i2.ShowDialog();
                if (i2.DialogResult == DialogResult.OK)
                {
                    txtREGLAB_RECOGEDOR.Text = i2.nombre;
                    txtRECOGEDOR_PERS_ID.Text = "";
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Comprobar los campos obligatorios y validar
            
            CopiarRLABdeFormulario();
            if (cbREGLAB_EMPRESAMUESTREO.SelectedIndex == 0)
            // Si muestrea fitosoil, es obligatorio seleccionar el muestreador, la fecha y la hora
            {
                if (!validarPersonaFitosoil(Utilidades.UtilsTipos.toInt(txtMUESTREADOR_PERS_ID.Text)))
                {
                    MessageBox.Show("Si el muestreo lo realiza Fitosoil, es obligatorio seleccionar el muestreador");
                    return;
                }
                if (!dtpREGLAB_FECHAMUESTREO.Checked || !dtpREGLAB_HORAMUESTREO.Checked)
                {
                    MessageBox.Show("Si el muestreo lo realiza Fitosoil, es obligatorio marcar la fecha y hora de muestreo");
                    return;
                }
            }

            if (cbREGLAB_EMPRESARECOGIDA.SelectedIndex == 0)
            // Si la recogida la realiza Fitosoil, es obligatorio indicar quién trae la muestra
            {
                if (!validarPersonaFitosoil(Utilidades.UtilsTipos.toInt(txtRECOGEDOR_PERS_ID.Text)))
                {
                    MessageBox.Show("Si la recogida la realiza Fitosoil, es obligatorio seleccionar la pesona que trae la muestra");
                    return;
                }
                if (!dtpREGLAB_FECHARECOGIDA.Checked || !dtpREGLAB_HORARECOGIDA.Checked)
                {
                    MessageBox.Show("Si la recogida la realiza Fitosoil, es obligatorio marcar la fecha y hora de recogida");
                    return;
                }
            } 
            // Verificar si es un rlab nuevo o existente
            _REGLAB_EXISTENTE = ComprobarSiExisteRlab();
            if (_REGLAB_EXISTENTE != null)
            {
                UpdateRLAB();
            }
            else
            {
                InsertRLAB();
            }
            
        }

        private void txtNIVURG_ID_TextChanged(object sender, EventArgs e)
        {
            PedidosDBDataContext ctx = new PedidosDBDataContext();
            var urgencias = from urg in ctx.NIVEL_URGENCIA
                            where urg.NIVURG_ID == Utilidades.UtilsTipos.toInt(txtNIVURG_ID.Text)
                            select urg.NIVURG_DESCRIPCION;
            if (urgencias.Count() > 0)
                lblNIVURG_DESCRIPCION.Text = urgencias.First();
            else
                lblNIVURG_DESCRIPCION.Text = string.Empty;
            ctx.Dispose();            
        }

        private void txtREGLAB_MUESTREADOR_TextChanged(object sender, EventArgs e)
        {
            PedidosDBDataContext ctx = new PedidosDBDataContext();
            var ids = from persona in ctx.PERSONAL
                      where persona.PERS_NOMBRE == txtREGLAB_MUESTREADOR.Text
                      select persona.PERS_ID.ToString();
            if (ids.Count() > 0)
                txtMUESTREADOR_PERS_ID.Text = ids.First();
            else
                txtMUESTREADOR_PERS_ID.Text = string.Empty;
        }

        private void txtREGLAB_RECOGEDOR_TextChanged(object sender, EventArgs e)
        {
            PedidosDBDataContext ctx = new PedidosDBDataContext();
            var ids = from persona in ctx.PERSONAL
                      where persona.PERS_NOMBRE == txtREGLAB_RECOGEDOR.Text
                      select persona.PERS_ID.ToString();
            if (ids.Count() > 0)
                txtRECOGEDOR_PERS_ID.Text = ids.First();
            else
                txtRECOGEDOR_PERS_ID.Text = string.Empty;
        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PersonalConsulta c = new PersonalConsulta();

            c.ShowDialog();
            if (c.DialogResult == DialogResult.OK)
            {
                this.txtREGLAB_PERSONAENTRADA.Text = c.pers_id.ToString();
                this.lblPERS_NOMBRE.Text = c.pers_nombre;
            }
        }

        private void txtREGLAB_PERSONAENTRADA_TextChanged(object sender, EventArgs e)
        {
            PedidosDBDataContext ctx = new PedidosDBDataContext();
            var nombre = from persona in ctx.PERSONAL
                         where persona.PERS_ID == Utilidades.UtilsTipos.toInt(txtREGLAB_PERSONAENTRADA.Text)
                         select persona.PERS_NOMBRE;
            if (nombre.Count() > 0)
                 lblPERS_NOMBRE.Text = nombre.First();
            else
                lblPERS_NOMBRE.Text = string.Empty;
        }
    }
}
