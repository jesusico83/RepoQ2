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
    public partial class ArticulosConsulta : Form
    {
        public ArticulosConsulta()
        {
            InitializeComponent();
        }

        // Variables de intercambio de datos entre ventanas
        public string arti_id;
        public string arti_descripcion;

        private ArticulosConsultaCtx ctx = new ArticulosConsultaCtx();
        private void MostrarListado()
        {
            this.fdlv1.ClearObjects();
            ctx.CON(txtARTI_DESCRIPCION.Text, txtTIPAR_ID.Text);
            this.fdlv1.DataSource = ctx.articulos_lista;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MostrarListado();
        }
        private void SeleccionarRegistro()
        {
            ARTICULOS_CON_Q2Result articulo = (ARTICULOS_CON_Q2Result)this.fdlv1.SelectedObject;            
            if (articulo != null)
            {
                arti_id = articulo.ARTI_ID;
                arti_descripcion = articulo.ARTI_DESCRIPCION;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void fdlv1_DoubleClick(object sender, EventArgs e)
        {
            SeleccionarRegistro();
        }

        private void ArticulosConsulta_Load(object sender, EventArgs e)
        {
            EstablecerDelegados();
        }
        private void EstablecerDelegados()
        {
            // Cambiar la fuente de la fila cabecera de los OLV
            this.fdlv1.HeaderFormatStyle = new Utilidades.FitosoilHeaderFormatStyle();

            // Ordenar las columnas por Nombre de Cliente
            this.fdlv1.PrimarySortColumn = this.cArtiID;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SeleccionarRegistro();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void txtARTI_DESCRIPCION_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MostrarListado();
            }

        }
    }
}
