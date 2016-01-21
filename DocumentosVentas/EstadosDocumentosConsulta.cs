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
    public partial class EstadosDocumentosConsulta : Form
    {
        //Contexto
        private EstadosDocumentosConsultaCtx ctx = new EstadosDocumentosConsultaCtx();

        //Parámetros de la consulta  
        public string usu_id;        
        public string docu_id;
        public string estdoc_id;
        public string estdoc_descripcion;
        
        public EstadosDocumentosConsulta()
        {
            InitializeComponent();
        }
        private void ValidarCampos()
        {
            // Se asignan valores en la ventana desde la que se llame
            // Comprobar si son valores válidos
        }        
        private void MostrarListado()
        {
            this.fdlv1.ClearObjects();
            ValidarCampos();
            ctx.CON(usu_id, docu_id);
            this.fdlv1.DataSource = ctx.estados;
            if (ctx.estados.Count() == 0)
            {
                MessageBox.Show("No hay registros con los filtros seleccionados");
            }            
        }

        private void PedidosvConsulta_Load(object sender, EventArgs e)
        {
            this.fdlv1.ClearObjects();
            ValidarCampos();
            MostrarListado();
        }
        public void SeleccionarRegistro()
        {
            DOCUMENTOS_ESTADOS_CONResult estado = (DOCUMENTOS_ESTADOS_CONResult)this.fdlv1.SelectedObject;
            if (estado != null)
            {
                this.estdoc_id = estado.ESTDOC_ID;
                this.estdoc_descripcion = estado.ESTDOC_DESCRIPCION;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }        

        private void fdlv1_DoubleClick(object sender, EventArgs e)
        {
            SeleccionarRegistro();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SeleccionarRegistro();
        }

        private void btnActaVolver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }    
}
