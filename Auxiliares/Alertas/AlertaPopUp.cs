using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Auxiliares.Alertas
{
    public partial class AlertaPopUp : Form
    {
        public int clie_id;        
        public string docu_id;
        public int mensajes;
        short posicion = 0;

        public AlertaPopUp()
        {
            InitializeComponent();
        }

        private void AlertaPopUp_Load(object sender, EventArgs e)
        {
            AlertaCliente alerta = new AlertaCliente();
            List<AlertaCliente> lista = alerta.GetAlertasCliente(clie_id, docu_id);
            mensajes = lista.Count;
            foreach (AlertaCliente a in lista)
            {
                this.richTextBox1.Text += "\n" + a.Ampliacion+"\n";
            }
            this.label1.Text = "Clie. "+this.clie_id.ToString();
        }
        private void CambiarPosicion()
        {
            System.Drawing.Size size = new Size(574, 490); 
            System.Drawing.Point point = new Point(1, 1); 
            if (posicion == 0)
            {
                size = new Size(574, 490);
                point = new Point(1, 1);                
            }
            else if (posicion == 1)
            {
                size = new Size(100, 240);
                point = new Point(924, 1);
            }
            else if (posicion == 2)
            {
                size = new Size(100, 240);
                point = new Point(924, 527);
            }
            else
            {
                posicion = 0;
            }
            posicion++;
            this.Size = size;
            this.Location = point;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Drawing.Size size = new Size(100, 240);
            System.Drawing.Point point = new Point(924, 1);
            this.Location = point;
            this.Size = size;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CambiarPosicion();
        }
    }
}
