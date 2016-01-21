using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace DocumentosVentas
{
    public partial class PedidosvConsulta : Form
    {
        //Contexto
        private PedidosvCtx ctx = new PedidosvCtx();

        //Parámetros de la consulta
        private int clie_id; 
        private int pers_id1;
        public string docu_id;
        public string estdoc_id;
        public string estdoc_descripcion;
        public string usu_id;
        public string fechaD, fechaH;
        public string pedid_id; // Es también parámetro de salida
        public PedidosvConsulta()
        {
            InitializeComponent();
        }
        //private void ValidarCampos()
        //{
        //    estdoc_id = this.txtESTDOC_ID.Text;
        //    try
        //    {
        //        pers_id1 = Convert.ToInt32(this.txtPERS_ID1.Text);
        //    }
        //    catch (FormatException fe)
        //    {
        //        pers_id1 = 0;
        //    }
        //    try
        //    {
        //        clie_id = Convert.ToInt32(this.txtCLIE_ID.Text);
        //    }
        //    catch (FormatException fe)
        //    {
        //        clie_id = 0;
        //    }
        //}        
        private void MostrarListado()
        {
            this.fdlv1.ClearObjects();
            //ValidarCampos();
            ctx.CON(dtpDESDE.Value.ToString("yyyy-MM-dd"), dtpHASTA.Value.ToString("yyy-MM-dd"));
            this.fdlv1.DataSource = ctx.pedidos_conLista;
            if (ctx.pedidos_conLista.Count() == 0)
            {
                MessageBox.Show("No hay registros con los filtros seleccionados");
            }            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MostrarListado();
        }

        private void PedidosvConsulta_Load(object sender, EventArgs e)
        {
            this.fdlv1.ClearObjects();
        }

        private void PedidosvConsulta_FormClosing(object sender, FormClosingEventArgs e)
        {            
            
        }
        public void SeleccionarRegistro()
        {
            Q2_PEDIDOSV_CONResult pedido = (Q2_PEDIDOSV_CONResult)this.fdlv1.SelectedObject;
            if (pedido != null)
            {
                this.pedid_id = pedido.PEDID_ID;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un registro para validar el pedido");
            }
            
        }
        //private void AbrirClientesConsulta()
        //{
        //    ClientesConsulta c = new ClientesConsulta();            
        //    c.ShowDialog();
        //    if (c.DialogResult == DialogResult.OK)
        //    {
        //        this.txtCLIE_ID.Text = c.clie_id.ToString();
        //        this.clie_id = c.clie_id;
        //        this.lblCLIE_DESCRIPCION.Text = c.clie_descripcion;
        //        c.Dispose();
        //    }
        //}
        //private void AbrirPersonalConsulta()
        //{
        //    PersonalConsulta c = new PersonalConsulta();
        //    c.ShowDialog();
        //    if (c.DialogResult == DialogResult.OK)
        //    {
        //        this.txtPERS_ID1.Text = c.pers_id.ToString();                
        //        this.lblPERS_NOMBRE.Text = c.pers_nombre;
        //        c.Dispose();
        //    }
        //}
        //private void AbrirEstadosDocumentoConsulta()
        //{
        //    DocumentosVentas.EstadosDocumentosConsulta c = new DocumentosVentas.EstadosDocumentosConsulta();
        //    c.docu_id = docu_id;
        //    c.usu_id = usu_id;
        //    c.ShowDialog();
        //    if (c.DialogResult == DialogResult.OK)
        //    {
        //        this.txtESTDOC_ID.Text = c.estdoc_id;
        //        this.lblESTDOC_DESCRIPCION.Text = c.estdoc_id;
        //        c.Dispose();
        //    }
        //}

        private void fdlv1_DoubleClick(object sender, EventArgs e)
        {
            SeleccionarRegistro();
        }        

        //private void lblCLIE_ID_Click(object sender, EventArgs e)
        //{
        //    AbrirClientesConsulta();
        //}

        //private void lblRecogido_Click(object sender, EventArgs e)
        //{
        //    AbrirPersonalConsulta();
        //}

        //private void lblEstado_Click(object sender, EventArgs e)
        //{
        //    AbrirEstadosDocumentoConsulta();
        //}

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            MostrarListado();
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

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            bool filtrado = false;
            int indice = 1;
            if (fdlv1.SelectedColumn != null)
                indice = this.fdlv1.SelectedColumn.DisplayIndex;
            if (this.fdlv1.SelectedColumn != null)
            {
                {
                    BrightIdeasSoftware.IModelFilter filtro = new BrightIdeasSoftware.ModelFilter(delegate(object x)
                    {
                        PropertyInfo pinfo = x.GetType().GetProperty(this.fdlv1.SelectedColumn.AspectName);
                        object valor = pinfo.GetValue(x, null);
                        if (valor == null)
                            valor = string.Empty;
                        string valorColumna = Utilidades.UtilsBD.RemoveDiacriticos((valor.ToString()).ToUpper());
                        string texto = Utilidades.UtilsBD.RemoveDiacriticos(this.txtFiltro.Text).ToUpper();
                        string[] textos = texto.Split(' ');
                        foreach (string txt in textos)
                        {
                            if (valorColumna.Contains(txt))
                                filtrado = true;
                            else
                            {
                                filtrado = false;
                                return filtrado;
                            }
                        }
                        return filtrado;
                    });
                    this.fdlv1.ModelFilter = filtro;
                }
            }
            else
            {
                MessageBox.Show("Para utlilizar el filtro debes seleccionar una columna", "A V I S O", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void fdlv1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            lblFiltro.Visible = true;
            lblFiltro.Text = "Filtro (" + this.fdlv1.SelectedColumn.Text + ")";
        }  


    }
   
}
