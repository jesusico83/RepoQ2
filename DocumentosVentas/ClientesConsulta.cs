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
    public partial class ClientesConsulta : Form
    {
        public ClientesConsulta()
        {
            InitializeComponent();
        }
        public int clie_id;
        private int tipo;
        public string usu_id = "SALVA"; // Flecos: Resolver esto
        public string clie_descripcion;

        private ClientesConsultaCtx ctx = new ClientesConsultaCtx();    
        private void ValidarCampos()
        {
            clie_descripcion = txtCLIE_DESCRIPCION.Text;
            if (xbComercial.Checked)
                tipo = 1;
            else
                tipo = 0; 
        }
        private void MostrarListado()
        {
            this.fdlv1.ClearObjects();
            ValidarCampos();
            ctx.CON(tipo, usu_id, clie_descripcion);
            this.fdlv1.DataSource = ctx.clientes_conLista;
            if (ctx.clientes_conLista.Count() == 0)
            {
                MessageBox.Show("No hay registros con los filtros seleccionados");
            }
        }
        public void SeleccionarRegistro()
        {
            CLIENTES_CON1_Q2Result cliente = (CLIENTES_CON1_Q2Result)this.fdlv1.SelectedObject;
            if (cliente != null)
            {
                clie_id = cliente.CLIE_ID;
            }
            this.Close();
        }

        private void ClientesConsult_Load(object sender, EventArgs e)
        {
            this.lblUSU_ID.Text = usu_id;
            this.fdlv1.ClearObjects();
            EstablecerDelegados();
        }
        private void EstablecerDelegados()
        {
            // Cambiar la fuente de la fila cabecera de los OLV
            this.fdlv1.HeaderFormatStyle = new Utilidades.FitosoilHeaderFormatStyle();

            // Ordenar las columnas por Nombre de Cliente
            this.fdlv1.PrimarySortColumn = this.cCLIE_DESCRIPCION;
        }

        private void ClientesConsult_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnClientesCon_Click(object sender, EventArgs e)
        {
            MostrarListado();
        }

        private void btnActaVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void fdlv1_DoubleClick(object sender, EventArgs e)
        {
            SeleccionarRegistro();
        }

        private void xbComercial_CheckedChanged(object sender, EventArgs e)
        {
            MostrarListado();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SeleccionarRegistro();
        }

        private void txtCLIE_DESCRIPCION_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MostrarListado();
            }
        }
    }
}
