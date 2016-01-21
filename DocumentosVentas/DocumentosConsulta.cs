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
    public partial class DocumentosConsulta : Form
    {
        //Contexto
        private DocumentosConsultaCtx ctx = new DocumentosConsultaCtx();

        //Parámetros de la consulta        
        public string tidoc_id; 
        public string usu_id;
        public string docu_id;
        public string docu_descripcion;
        
        public DocumentosConsulta()
        {
            InitializeComponent();
        }
        private void ValidarCampos()
        {
            // Se asignan desde la ventana llamante, antes de mostrar la ventana
        }        
        private void MostrarListado()
        {
            this.fdlv1.ClearObjects();
            ValidarCampos();
            ctx.CON(usu_id, tidoc_id);
            this.fdlv1.DataSource = ctx.tipos;
            if (ctx.tipos.Count() == 0)
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
            DOCUMENTOS_CON_TIPOSResult documento = (DOCUMENTOS_CON_TIPOSResult)this.fdlv1.SelectedObject;
            if (documento != null)
            {
                this.docu_id = documento.DOCU_ID;
                this.docu_descripcion = documento.DOCU_DESCRIPCION;
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
