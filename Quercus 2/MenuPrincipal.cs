using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Quercus2
{
    public partial class MenuPrincipal : Form
    {  
        // Variables de Aplicación
        public string _USU_ID;
        public int _USU_ID1;
        public string _PESE_ID;
        public string _USU_DESCRIPCION;
        public DocumentosVentas.Pedidosv acta;

        public string _TIDOC_ID;

        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        { 
            AbrirLoginControl();             
        }
        private void AbrirLoginControl()
        {  
            LoginControl lc = new LoginControl();
            // No es necesario pasarle ningún valor a la ventana de login
            lc.ShowDialog();
            if (lc.DialogResult == DialogResult.OK)
            {
                // Se guardan los datos procedentes de la ventana a la que se llamó (LoginControl)
                _USU_ID = lc._USU_ID;
                _USU_ID1 = lc._USU_ID1;
                _PESE_ID = lc._PESE_ID;
                _USU_DESCRIPCION = lc._USU_DESCRIPCION;
                this.Text = "Quercus 2 : " + _USU_ID; 
                lc.Dispose(); // Liberar la memoria del Objeto LoginControl                
                // Flecos: Si hay etiquetas o textbox que requieran datos del usuario, ponerlos aquí
            }
        }
        
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnActas_Click(object sender, EventArgs e)
        {
            AbrirActa();
        }
        private void AbrirActa()
        {
            if (acta == null)
            {
                acta = new DocumentosVentas.Pedidosv();
                // Se pasan los valores a la ventana del acta
                acta._USU_ID = this._USU_ID;
                acta._TIDOC_ID = "PEDV";

                acta.ShowDialog();
            }
            else acta.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DocumentosVentas.RegistroLaboratorioPedidoV reglab = new DocumentosVentas.RegistroLaboratorioPedidoV();
            reglab.ShowDialog();
        }
    }
}
