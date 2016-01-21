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
    public partial class GruposCondicionesConsulta : Form
    {
        public GruposCondicionesConsulta()
        {
            InitializeComponent();
        }
        // Contexto
        private GruposCondicionesConsultaCtx ctx = new GruposCondicionesConsultaCtx();

        //Parámetros de la consulta
        public string usu_id;

        //Valores a devolver por la consulta tras seleccionar el registro
        public int codigo;
        public string descripcion;

        private void mostrarListado()
        {
            ctx.GRUPOS_DESCUENTOS_CON(usu_id);
            this.fdlv1.DataSource = ctx.grupos_lista;
        }

        private void GruposCondicionesConsulta_Load(object sender, EventArgs e)
        {
            mostrarListado();
        }

        private void SeleccionarRegistro()
        {
            GRUPOS_DESCUENTOS_CONResult descuento = (GRUPOS_DESCUENTOS_CONResult)fdlv1.SelectedObject;
            if (descuento != null)
            {
                this.codigo = descuento.GRDE_ID;
                this.descripcion = descuento.GRDE_DESCRIPCION;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
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
