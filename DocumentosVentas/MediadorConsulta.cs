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
    public partial class MediadorConsulta : Form
    {
        public MediadorConsulta()
        {
            InitializeComponent();
        }

        public string usu_id; 
        public int clie_id;
        public int repre_id;
        public string repre_descripcion;
        public bool media_siempre, aplica_precio, comunica;        

        private MediadorConsultaCtx ctx = new MediadorConsultaCtx();

        private void MostrarListado()
        {
            this.fdlv1.ClearObjects();
            ctx.SEL(usu_id, clie_id);
            this.fdlv1.DataSource = ctx.clientes_mediadorLista;
            if (ctx.clientes_mediadorLista.Count() == 0)
            {
                MessageBox.Show("No hay registros con los filtros seleccionados");
            }
        }
        public void SeleccionarRegistro()
        {
            CLIENTES_MEDIADOR_SELResult mediador = (CLIENTES_MEDIADOR_SELResult)this.fdlv1.SelectedObject;
            if (mediador != null)
            {
                repre_id = mediador.REPRE_ID;
                repre_descripcion = mediador.REPRE_DESCRIPCION;
                if (mediador.MEDIA_SIEMPRE == "0")
                {
                    media_siempre = true;
                }
                else media_siempre = false;
                if (mediador.APLICA_PRECIO_MEDIADOR == "0")
                {
                    aplica_precio = true;
                }
                else aplica_precio = false;
                if (mediador.COMUNICA == "0")
                {
                    comunica = true;
                }
                else comunica = false;

                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }

        private void ClientesConsult_Load(object sender, EventArgs e)
        {            
            this.fdlv1.ClearObjects();
            txtDESCRIPCION.Text = this.clie_id.ToString();
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            SeleccionarRegistro();
        }

    }
}
