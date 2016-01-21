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
    public partial class PersonalConsulta : Form
    {
        public PersonalConsulta()
        {
            InitializeComponent();
        }
        public int pers_id;
        private int tipo;        
        public string pers_nombre;

        private PersonalConsultaCtx ctx = new PersonalConsultaCtx();    
        private void ValidarCampos()
        {
            pers_nombre = this.txtDESCRIPCION.Text;
        }
        private void MostrarListado()
        {
            this.fdlv1.ClearObjects();
            ValidarCampos();
            ctx.CON(pers_nombre);
            this.fdlv1.DataSource = ctx.personal_lista;
            if (ctx.personal_lista.Count() == 0)
            {
                MessageBox.Show("No hay registros con los filtros seleccionados");
            }
        }
        public void SeleccionarRegistro()
        {
            PERSONAL_CON_Q2Result persona = (PERSONAL_CON_Q2Result)this.fdlv1.SelectedObject;
            if (persona != null)
            {
                pers_id = persona.PERS_ID;
                pers_nombre = persona.PERS_NOMBRE;
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }

        private void ClientesConsult_Load(object sender, EventArgs e)
        {            
            this.fdlv1.ClearObjects();
        }

        private void btnClientesCon_Click(object sender, EventArgs e)
        {
            MostrarListado();
        }

        private void btnActaVolver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
            
        }

        private void fdlv1_DoubleClick(object sender, EventArgs e)
        {
            SeleccionarRegistro();
        }

        private void txtDESCRIPCION_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MostrarListado();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SeleccionarRegistro();
        }
    }
}
