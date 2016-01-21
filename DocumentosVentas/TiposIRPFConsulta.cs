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
    public partial class TiposIRPFConsulta : Form
    {
        public TiposIRPFConsulta()
        {
            InitializeComponent();
        }
        // Contexto
        TiposIRPFConsultaCtx ctx = new TiposIRPFConsultaCtx();

        // parámetros
        public string usu_id;

        // Valores devueltos
        public int codigo;
        public string descripcion;

        private void MostrarListado()
        {
            ctx.IRPF_CON(usu_id);
            this.fdlv1.DataSource = ctx.tipos_irpf;
        }

        private void SeleccionarRegistro()
        {
            IRPF_CONResult irpf = (IRPF_CONResult)fdlv1.SelectedObject;
            if (irpf != null)
            {
                this.codigo = irpf.IRPF_ID;
                this.descripcion = irpf.IRPF_DESCRIPCION;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void TiposIRPFConsulta_Load(object sender, EventArgs e)
        {
            MostrarListado();
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
