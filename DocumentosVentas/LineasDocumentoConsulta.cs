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
    public partial class LineasDocumentoConsulta : Form
    {
        public LineasDocumentoConsulta()
        {
            InitializeComponent();
        }
        public string docu_id;
        public string usu_id;
        public string lido_id;
        public string lido_descripcion;

        private LineasDocumentoConsultaCtx ctx = new LineasDocumentoConsultaCtx();

        private void mostrarListado()
        {
            ctx.DOCUMENTOS_LINEAS_CON(usu_id, docu_id);
            this.fdlv1.DataSource = ctx.lineas;
        }

        private void LineasDocumentoConsulta_Load(object sender, EventArgs e)
        {
            mostrarListado();
        }

        private void SeleccionarRegistro()
        {
            DOCUMENTOS_LINEAS_CONResult linea = (DOCUMENTOS_LINEAS_CONResult)this.fdlv1.SelectedObject;
            if(linea != null)
            {
                lido_id = linea.LIDO_ID;
                lido_descripcion = linea.LIDO_DESCRIPCION;
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }

        private void fdlv1_DoubleClick(object sender, EventArgs e)
        {
            SeleccionarRegistro();
        }
    }
}
