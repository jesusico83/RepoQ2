using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using BrightIdeasSoftware;

namespace DocumentosVentas
{
    public partial class PedidovDetalle : Form
    {
        // Variables de paso de la ventana llamante:
        
        
        public string tipana_descripcion;        
        public string usuario;
        public List<PEDIDOSV_LI_SELResult> detalle;
        private PedidovDetalleCtx ctx = new PedidovDetalleCtx();

        public string Cliente { get; set; }
        public int ClienteId { get; set; }
        public string TipoAnalisis { get; set; }
        public string Matriz { get; set; }
        public string Descripcion { get; set; }
        public string Documento { get; set; }
        public string Numero { get; set; }
        public string PedidoIDorigen { get; set; }
        public int MaxLinea { get; set; }
        public int MediadorClieId { get; set; }
        public DataTable Detalle { get; set; }
        public int? _CompId { get; set; }
        public bool plantilla;

        public PedidovDetalle()
        {
            InitializeComponent();
        }
        #region Carga Inicial de la ventana

        // Carga todos los datos iniciales al abrir la ventana
        // Flecos: Verificar qué ocurre con un acta vacía

        private void PedidovDetalle_Load(object sender, EventArgs e)
        {
            // _compID, Matriz, ClienteId deben pasarse desde la ventana llamante          

            
            // Se da formato a los contenedores de datos olv, y se asigna al tlv de presupuestos las listas de datos.
            EstablecerDelegados();
            this._CompId = ctx.GetComportamientoIVACliente(ClienteId);

            // Se obtiene el detalle y se carga en el fdlv
            CargarDetalleActa();
            this.plantilla = false;
            // Obtiene el tipo de análisis (modelos y determinacioens) aplicables a la matriz
            ctx.GetTipanaFromMatriz(Matriz);
            // Actualizar etiquetas cliente y matriz de la cabecera de la ventana
            this.lblCliente.Text = "Cliente: " + Cliente;
            this.lblMatriz.Text = "Matriz: " + Matriz + " - " + Descripcion;

            // Se obtiene el tipo de Análisis en función de la matriz 
            TipoAnalisis = ctx.tipo_analisis.TIPANA_ID;
            tipana_descripcion = ctx.tipo_analisis.TIPANA_DESCRIPCION;
            this.lblTipoAnalisis.Text = "(" + tipana_descripcion + ")";

            this.folvModelos.SetObjects(ctx.GetArticulosModeloByTipoAnalisis(TipoAnalisis)); // Carga en el OLV modelos el listado de modelos aplicables a la matriz
            CargarDeterminacionesYCargos(); // Carga en el OLV determinaciones el listado de determinaciones aplicables a la matriz

            MostrarListadoPresupuestos(); // Cargar presupuestos anteriores del cliente en el TreeListView  
        }

        // Pinta de colores los cargos extra que se añaden al pedido que se listan en el olv determinaciones (traducción, muestreo, portes, etc.)
        private void folvDeterminaciones_FormatRow(object sender, FormatRowEventArgs e)
        {
            Almacen.odts.ArticuloDeterminacion d = e.Model as Almacen.odts.ArticuloDeterminacion;
            if (d.TipoArticulo == "CAR")
            {
                e.Item.BackColor = Color.LightGreen;
            }
        }

        // Se comprueba que la ventana llamante pasa todos los datos que esta ventana va a necesitar.
        //private bool ValidarCampos()
        //{
        //    string msgerror;
        //    if (Matriz == "")
        //    {
        //        msgerror = "Debe seleccionar la matriz antes de crear el detalle";
        //    }
        //    else if (ClienteId == 0)
        //    {
        //        msgerror = "Debe seleccionar un cliente antes de crear o editar el detalle";
        //    }
        //    else if (Numero == "")
        //    {
        //        msgerror = "Solo se puede crear un detalle sobre un pedido existente";
        //    }

        //    //// Validar mas campos si fuera necesario
        //    ////..........

        //    //    // Si todos los campos están
        //    else
        //    {
        //        return true;
        //    }
        //    MessageBox.Show(msgerror);
        //    this.Close();            
        //    return false;
        //}

        private void EstablecerDelegados()
        {
            // Cambiar la fuente de la fila cabecera de los OLV
            this.folvModelos.HeaderFormatStyle = new Utilidades.FitosoilHeaderFormatStyle();
            this.folvDeterminaciones.HeaderFormatStyle = new Utilidades.FitosoilHeaderFormatStyle();
            this.fdlvDetalle.HeaderFormatStyle = new Utilidades.FitosoilHeaderFormatStyle();
            this.tlvPresupuestos.HeaderFormatStyle = new Utilidades.FitosoilHeaderFormatStyle();

            // Ordenar las columnas del detalle
            this.fdlvDetalle.PrimarySortColumn = this.olvLinea;
            this.fdlvDetalle.SecondarySortColumn = this.olvSublinea;
            this.fdlvDetalle.PrimarySortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.fdlvDetalle.SecondarySortOrder = System.Windows.Forms.SortOrder.Ascending;

            // Asignar al tree list view los listados principales y los hijos.

            this.tlvPresupuestos.CanExpandGetter = delegate(object x)
            {
                return x is odts.PresupuestoVentaBloque || x is odts.DetalleModelo;
            };

            this.tlvPresupuestos.ChildrenGetter = delegate(object x)
            { 
                if (x is odts.PresupuestoVentaBloque)
                {
                    odts.PresupuestoVentaBloque b = (odts.PresupuestoVentaBloque)x;
                    b.Detalle = ctx.GetDetalleByBloque(b.DocuId, b.PresuvId, b.BloqueId);
                    return b.Detalle;
                }
                else if (x is odts.DetalleModelo)
                {
                    odts.DetalleModelo m = (odts.DetalleModelo)x;
                    return m.Determinaciones;
                }
                return null;
            };
        }
        private void CargarDetalleActa()
        {
            DataTable dt;
            if (!plantilla)
            {
                dt = ctx.GetDetalleByPedido2(this.Documento, this.Numero);
            }
            else
            {
                dt = ctx.GetDetalleByPedido2(this.Documento, this.PedidoIDorigen);
                plantilla = false;
            }

            this.fdlvDetalle.DataSource = dt;
            
        }
        
        private void CargarDeterminacionesYCargos()
        {
            this.folvDeterminaciones.SetObjects(ctx.GetArticulosDeterminacionByTipoAnalisis(TipoAnalisis));
            this.folvDeterminaciones.AddObjects(ctx.GetArticulosCargoByTipoAnalisis(TipoAnalisis));
            this.folvDeterminaciones.AddObjects(ctx.GetArticulosCargoServiciosEInformes());
        }
        private void MostrarListadoPresupuestos()
        {
            this.tlvPresupuestos.SetObjects(ctx.GetBloquesGrupoByCliente(ClienteId));
        }

        // Evento para asignar cadenas vacías a las columnas que no tienen datos en las listas padre.
        // Debe estar a true la propiedad cellformatevent
        private void tlvPresupuestos_FormatCell(object sender, BrightIdeasSoftware.FormatCellEventArgs e)
        {
            if (e.Model is odts.PresupuestoVentaBloque)
            {
                if (e.Column == this.cDetalleDescripcion)
                {
                    e.SubItem.Text = "";
                }
                else if (e.Column == this.cCantidad)
                {
                    e.SubItem.Text = "";
                }
                else if (e.Column == this.cUnidadId)
                {
                    e.SubItem.Text = "";
                }
                else if (e.Column == this.cPrecio)
                {
                    e.SubItem.Text = "";
                }
                else if (e.Column == this.cDescuentoDescripcion)
                {
                    e.SubItem.Text = "";
                }
                else if (e.Column == this.cArtiId1)
                {
                    e.SubItem.Text = "";
                }
                else if (e.Column == this.cBloqueTipoLinea)
                {
                    e.SubItem.Text = "";
                }
            }
            else if (e.Model is odts.PresupuestoVentaDetalle)
            {
                if (e.Column == this.cFamilDescripcion)
                {
                    e.SubItem.Text = "";
                }
                else if (e.Column == this.cTitulo)
                {
                    e.SubItem.Text = "";
                }
                else if (e.Column == this.cReferenciaCliente)
                {
                    e.SubItem.Text = "";
                }
                else if (e.Column == this.cFechaCreacion)
                {
                    e.SubItem.Text = "";
                }
                else if (e.Column == this.cDocuId)
                {
                    e.SubItem.Text = "";
                }
                else if (e.Column == this.cPresuvId)
                {
                    e.SubItem.Text = "";
                }
                else if (e.Column == this.cEstado)
                {
                    e.SubItem.Text = "";
                }
                else if (e.Column == this.cCliente)
                {
                    e.SubItem.Text = "";
                }
            }
        }

#endregion // Fin de region de código dedicada al formato inicial y dar formato a las ventanas       
        
#region filtros
        // Filtra los modelos utilizando el cuadro de texto de búsqueda
        private void txtModelo_TextChanged(object sender, EventArgs e)
        {
            BrightIdeasSoftware.IModelFilter filter = new BrightIdeasSoftware.ModelFilter(delegate(object x)
            {
                string artiDescripcion = Utilidades.UtilsBD.RemoveDiacriticos(((Almacen.odts.ArticuloModelo)x).Descripcion).ToUpper();
                string texto = Utilidades.UtilsBD.RemoveDiacriticos(txtModelo.Text).ToUpper();
                return artiDescripcion.Contains(texto);
            });
            this.folvModelos.ModelFilter = filter;
        }
        // Filtra las determinaciones utilizando el cuadro de texto de búsqueda
        private void txtDeterminacion_TextChanged(object sender, EventArgs e)
        {
            BrightIdeasSoftware.IModelFilter filter = new BrightIdeasSoftware.ModelFilter(delegate(object x)
            {
                string artiDescripcion = Utilidades.UtilsBD.RemoveDiacriticos(((Almacen.odts.ArticuloDeterminacion)x).Descripcion).ToUpper();
                string texto = Utilidades.UtilsBD.RemoveDiacriticos(txtDeterminacion.Text).ToUpper();
                return artiDescripcion.Contains(texto);
            });
            this.folvDeterminaciones.ModelFilter = filter;
        }
            
        // Filtra en el TreeListView de presupuestos los modelos y determinaciones marcados en check en los olv respectivos
        private void folvModelos_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            List<object> lista = new List<object>();
            foreach (Almacen.odts.ArticuloModelo am in this.folvModelos.CheckedObjects)
            {
                lista.Add(am);
            }
            foreach (Almacen.odts.ArticuloDeterminacion ad in this.folvDeterminaciones.CheckedObjects)
            {
                lista.Add(ad);
            }
            Filtrar(lista);
        }
        private void Filtrar(IList lista)
        {
            if (lista == null || lista.Count == 0)
            {
                this.tlvPresupuestos.ModelFilter = null;
                this.tlvPresupuestos.CollapseAll();
            }
            else
            {
                List<odts.PresupuestoVentaBloque> filtrados = new List<odts.PresupuestoVentaBloque>();
                foreach (object o in lista)
                {
                    if (o is Almacen.odts.ArticuloModelo)
                    {
                        filtrados.AddRange(GetBloquesQueContienen((o as Almacen.odts.ArticuloModelo).ArtiId1));
                    }
                    else if (o is Almacen.odts.ArticuloDeterminacion)
                    {
                        filtrados.AddRange(GetBloquesQueContienen((o as Almacen.odts.ArticuloDeterminacion).ArtiId1));
                    }
                }

                BrightIdeasSoftware.IModelFilter filter = new BrightIdeasSoftware.ModelFilter(delegate(object x)
                {
                    if (x is odts.PresupuestoVentaBloque)
                    {                       
                        if (filtrados.Contains((odts.PresupuestoVentaBloque)x))
                        {
                            return true;
                        }
                        else
                            return false;
                    }
                    else if (x is odts.PresupuestoVentaDetalle)
                    {
                        object padre = this.tlvPresupuestos.GetParent(x);
                        if (padre is odts.DetalleModelo)
                        {
                            object abuelo = this.tlvPresupuestos.GetParent(padre);
                            if (filtrados.Contains((odts.PresupuestoVentaBloque)abuelo))
                                return true;
                        }
                        else
                        {
                            if (filtrados.Contains((odts.PresupuestoVentaBloque)padre))
                                return true;
                        }
                        return false;
                    }
                   
                    return false;

                });
                this.tlvPresupuestos.ModelFilter = filter;
               
            }
        }
        private void InsertaBloqueEnActa(odts.PresupuestoVentaBloque bloque)
        {
            //foreach (odts.DetalleModelo d in bloque.Detalle)
            //{
            //    odts.DetalleModelo d1 = d.Copia(CalcularNuevaLinea());
            //    this.tlvActa.AddObject(d1);
            //}
        }
        //private void tlvActa_ModelCanDrop(object sender, BrightIdeasSoftware.ModelDropEventArgs e)
        //{
        //    DataRowView target = null;
        //    if (e.TargetModel != null)
        //    {
        //        target = (DataRowView)e.TargetModel;
        //    }
        //    foreach (var model in e.SourceModels)
        //    {
        //        if (model is odts.PresupuestoVentaBloque)
        //        {
        //            bool permitir = true;
        //            foreach (odts.PresupuestoVentaDetalle d in ((odts.PresupuestoVentaBloque)model).Detalle)
        //            {
        //                if (EsArticuloDuplicado(d.ArtiId1))
        //                {
        //                    permitir = false;
        //                    break;
        //                }
        //            }
        //            if (permitir)
        //            {
        //                e.Effect = DragDropEffects.Copy;
        //                e.InfoMessage = "Añadir un presupuesto completo";
        //            }
        //            else
        //            {
        //                e.Effect = DragDropEffects.None;
        //                e.InfoMessage = "Hay artículos repetidos";
        //            }
        //        }
        //        else if (model is Almacen.odts.ArticuloModelo && e.TargetModel == null)
        //        {
        //            if (!EsArticuloDuplicado(((Almacen.odts.ArticuloModelo)model).ArtiId1))
        //            {
        //                e.Effect = DragDropEffects.Copy;
        //                e.InfoMessage = "Añadir un modelo al acta";
        //            }
        //            else
        //            {
        //                e.Effect = DragDropEffects.None;
        //                e.InfoMessage = "Hay artículos repetidos";
        //            }
        //        }
        //        else if (model is Almacen.odts.ArticuloModelo && target != null && target.Row["LIDO_ID"].ToString() == "N" /*e.TargetModel is odts.DetalleModelo*/)
        //        {
        //            e.Effect = DragDropEffects.Copy;
        //            e.InfoMessage = "Añadir las determinaciones de un modelo a otro modelo";
        //        }
        //        else if (model is Almacen.odts.ArticuloDeterminacion && target != null && target.Row["LIDO_ID"].ToString() == "N" /*e.TargetModel is odts.DetalleModelo*/)
        //        {
        //            int depaId = (int)target.Row["DEPA_ID"];
        //            //if (((odts.DetalleModelo)e.TargetModel).Estado == "FC")
        //            //{
        //            //    e.Effect = DragDropEffects.None;
        //            //    e.InfoMessage = "La línea está facturada";
        //            //}
        //            //else 
        //            if (!EsArticuloDuplicado(((Almacen.odts.ArticuloDeterminacion)model).ArtiId1) && depaId == ((Almacen.odts.ArticuloDeterminacion)model).DepartamentoId)
        //            {
        //                e.Effect = DragDropEffects.Copy;
        //                e.InfoMessage = "Añadir una determinación a un modelo";
        //            }
        //            else if (depaId != ((Almacen.odts.ArticuloDeterminacion)model).DepartamentoId)
        //            {
        //                e.Effect = DragDropEffects.None;
        //                e.InfoMessage = "La determinación es de un departamento distinto al del modelo";
        //            }
        //            else
        //            {
        //                e.Effect = DragDropEffects.None;
        //                e.InfoMessage = "Hay artículos repetidos";
        //            }

        //        }
        //        else if (model is Almacen.odts.ArticuloDeterminacion && target != null && target.Row["LIDO_ID"].ToString() == "N+" /*e.TargetModel is odts.DetalleDeterminacion*/)
        //        {
        //            int depaId = (int)target.Row["DEPA_ID"];
        //            if (!EsArticuloDuplicado(((Almacen.odts.ArticuloDeterminacion)model).ArtiId1) && depaId == ((Almacen.odts.ArticuloDeterminacion)model).DepartamentoId)
        //            {
        //                e.Effect = DragDropEffects.Copy;
        //                e.InfoMessage = "Añadir una determinación en esta posición";
        //            }
        //            else if (depaId != ((Almacen.odts.ArticuloDeterminacion)model).DepartamentoId)
        //            {
        //                e.Effect = DragDropEffects.None;
        //                e.InfoMessage = "La determinación es de un departamento distinto al del modelo";
        //            }
        //            else
        //            {
        //                e.Effect = DragDropEffects.None;
        //                e.InfoMessage = "Hay artículos repetidos";
        //            }

        //        }
        //        else
        //        {
        //            e.Effect = DragDropEffects.None;
        //            e.InfoMessage = "Este movimiento no está permitido";
        //        }
        //    }

        //    //else if (e.TargetModel is odts.ArticuloModelo)
        //    //{ 
        //    //    if (person.MaritalStatus == MaritalStatus.Married) 
        //    //    { 
        //    //        e.Effect = DragDropEffects.None; 
        //    //        e.InfoMessage = "Can't drop on someone who is already married";
        //    //    } 
        //    //    else 
        //    //    { 
        //    //        e.Effect = DragDropEffects.Move;
        //    //    } 
        //    //}
        //}
        //private void tlvActa_ModelDropped(object sender, BrightIdeasSoftware.ModelDropEventArgs e)
        //{
        //    foreach (var m in e.SourceModels)
        //    {
        //        if (m is odts.PresupuestoVentaBloque)
        //        {
        //            InsertaBloqueEnActa(m as odts.PresupuestoVentaBloque);
        //        }
        //        else if (m is Almacen.odts.ArticuloModelo)
        //        {
        //            if (e.TargetModel is odts.DetalleModelo)
        //            {
        //                // Añadir las determinaciones de este modelo al modelo destino
        //            }
        //            else if (e.TargetModel == null)
        //            {
        //                // Añadir el modelo al presupuesto
        //                odts.DetalleModelo pvd = new odts.DetalleModelo();
        //                Almacen.odts.ArticuloModelo modelo = m as Almacen.odts.ArticuloModelo;
        //                int linea = CalcularNuevaLinea();
        //                pvd.Linea = linea;
        //                pvd.ArtiId1 = modelo.ArtiId1;
        //                pvd.Cantidad = (decimal)1;
        //                pvd.DetalleDescripcion = modelo.Descripcion;
        //                pvd.UnidadId = "UN";
        //                pvd.Sublinea = 0;
        //                pvd.ArtiDeterminaciones = modelo.ArtiDeterminaciones;
        //                pvd.ArtiPNTMetodologia = modelo.ArtiMetodologia;
        //                if (pvd.Precio == 0)
        //                {
        //                    if (this.MediadorClieId == 0)
        //                        ctx.GetPrecioArticuloByCliente(pvd, pvd.ArtiId1, this.ClienteId, this.Documento, usuario);
        //                    else
        //                        ctx.GetPrecioArticuloByCliente(pvd, pvd.ArtiId1, this.MediadorClieId, this.Documento, usuario);
        //                    pvd.ComportamientoIVA = this._CompId;
        //                }

        //                //                        this.tlvActa.AddObject(pvd);


        //                List<odts.DetalleDeterminacion> asociados = GetAsociados(new List<odts.DetalleDeterminacion>(), modelo.ArtiId1);

        //                foreach (odts.PresupuestoVentaDetalle a in asociados)
        //                {
        //                    if (!EsArticuloDuplicado(a.ArtiId1, pvd))
        //                    {
        //                        odts.DetalleDeterminacion dd = new odts.DetalleDeterminacion();
        //                        dd.Linea = linea;
        //                        dd.Sublinea = CalcularNuevaSublinea(linea);
        //                        dd.ArtiId1 = a.ArtiId1;
        //                        dd.Cantidad = (decimal)1;
        //                        dd.DetalleDescripcion = a.DetalleDescripcion;
        //                        dd.UnidadId = "UN";
        //                        dd.ArtiDeterminaciones = a.ArtiDeterminaciones;
        //                        dd.ArtiPNTMetodologia = a.ArtiPNTMetodologia;

        //                        if (dd.Precio == 0)
        //                        {
        //                            if (this.MediadorClieId == 0)
        //                                ctx.GetPrecioArticuloByCliente(dd, dd.ArtiId1, this.ClienteId, this.Documento, usuario);
        //                            else
        //                                ctx.GetPrecioArticuloByCliente(dd, dd.ArtiId1, this.MediadorClieId, this.Documento, usuario);

        //                            dd.ComportamientoIVA = this._CompId;
        //                        }

        //                        pvd.Determinaciones.AddRange(new List<odts.DetalleDeterminacion>() { dd });
        //                    }
        //                }

        //                //                        this.tlvActa.Expand(pvd);
        //            }
        //        }
        //        else if (m is Almacen.odts.ArticuloDeterminacion && e.TargetModel is odts.DetalleModelo)
        //        {
        //            // Añadir el determinación al presupuesto
        //            odts.DetalleDeterminacion pvd = new odts.DetalleDeterminacion();
        //            Almacen.odts.ArticuloDeterminacion d = m as Almacen.odts.ArticuloDeterminacion;
        //            odts.DetalleModelo modelo = e.TargetModel as odts.DetalleModelo;

        //            int linea = modelo.Linea;
        //            pvd.Linea = linea;
        //            pvd.Sublinea = CalcularNuevaSublinea(modelo.Linea);
        //            pvd.ArtiId1 = d.ArtiId1;
        //            pvd.Cantidad = (decimal)1;
        //            pvd.DetalleDescripcion = d.Descripcion;
        //            pvd.UnidadId = "UN";
        //            pvd.ArtiDeterminaciones = d.ArtiDeterminaciones;
        //            pvd.ArtiPNTMetodologia = d.ArtiMetodologia;
        //            if (pvd.Precio == 0)
        //            {
        //                if (this.MediadorClieId == 0)
        //                    ctx.GetPrecioArticuloByCliente(pvd, pvd.ArtiId1, this.ClienteId, this.Documento, usuario);
        //                else
        //                    ctx.GetPrecioArticuloByCliente(pvd, pvd.ArtiId1, this.MediadorClieId, this.Documento, usuario);

        //                pvd.ComportamientoIVA = this._CompId;
        //            }

        //            modelo.Determinaciones.AddRange(new List<odts.DetalleDeterminacion>() { pvd });

        //            List<odts.DetalleDeterminacion> asociados = GetAsociados(new List<odts.DetalleDeterminacion>(), d.ArtiId1);

        //            foreach (odts.PresupuestoVentaDetalle a in asociados)
        //            {
        //                if (!EsArticuloDuplicado(a.ArtiId1, modelo))
        //                {
        //                    odts.DetalleDeterminacion dd = new odts.DetalleDeterminacion();
        //                    dd.Linea = linea;
        //                    dd.Sublinea = CalcularNuevaSublinea(linea);
        //                    dd.ArtiId1 = a.ArtiId1;
        //                    dd.Cantidad = (decimal)1;
        //                    dd.DetalleDescripcion = a.DetalleDescripcion;
        //                    dd.UnidadId = "UN";
        //                    dd.ArtiDeterminaciones = a.ArtiDeterminaciones;
        //                    dd.ArtiPNTMetodologia = a.ArtiPNTMetodologia;

        //                    if (dd.Precio == 0)
        //                    {
        //                        if (this.MediadorClieId == 0)
        //                            ctx.GetPrecioArticuloByCliente(dd, dd.ArtiId1, this.ClienteId, this.Documento, usuario);
        //                        else
        //                            ctx.GetPrecioArticuloByCliente(dd, dd.ArtiId1, this.MediadorClieId, this.Documento, usuario);

        //                        dd.ComportamientoIVA = this._CompId;
        //                    }

        //                    modelo.Determinaciones.AddRange(new List<odts.DetalleDeterminacion>() { dd });
        //                }
        //            }

        //            //                    this.tlvActa.RefreshObject(modelo);
        //            //                    this.tlvActa.Expand(modelo);
        //        }

        //        else if (m is Almacen.odts.ArticuloDeterminacion && e.TargetModel is odts.DetalleDeterminacion)
        //        {
        //            odts.DetalleDeterminacion pvd = new odts.DetalleDeterminacion();
        //            Almacen.odts.ArticuloDeterminacion d = m as Almacen.odts.ArticuloDeterminacion;
        //            odts.DetalleDeterminacion t = e.TargetModel as odts.DetalleDeterminacion;
        //            odts.DetalleModelo modelo = null;
        //            int linea = t.Linea;
        //            int subLinea = t.Sublinea;

        //            //                    foreach (odts.PresupuestoVentaDetalle p in this.tlvActa.Objects)
        //            //                    {
        //            //                        if (p is odts.DetalleModelo)
        //            //                        {
        //            //                            if (((odts.DetalleModelo)p).Linea == linea)
        //            //                            {
        //            //                                modelo = p as odts.DetalleModelo;
        //            //                            }
        //            //                        }
        //            //                    }

        //            foreach (odts.DetalleDeterminacion dd in modelo.Determinaciones)
        //            {
        //                if (dd.Linea == linea && dd.Sublinea >= subLinea)
        //                {
        //                    dd.Sublinea++;
        //                }
        //            }

        //            pvd.Linea = linea;
        //            pvd.Sublinea = subLinea;
        //            pvd.ArtiId1 = d.ArtiId1;
        //            pvd.Cantidad = (decimal)1;
        //            pvd.DetalleDescripcion = d.Descripcion;
        //            pvd.UnidadId = "UN";
        //            pvd.ArtiDeterminaciones = d.ArtiDeterminaciones;
        //            pvd.ArtiPNTMetodologia = d.ArtiMetodologia;
        //            if (pvd.Precio == 0)
        //            {
        //                if (this.MediadorClieId == 0)
        //                    ctx.GetPrecioArticuloByCliente(pvd, pvd.ArtiId1, this.ClienteId, this.Documento, usuario);
        //                else
        //                    ctx.GetPrecioArticuloByCliente(pvd, pvd.ArtiId1, this.MediadorClieId, this.Documento, usuario);

        //                pvd.ComportamientoIVA = this._CompId;
        //            }

        //            modelo.Determinaciones.Insert(pvd.Sublinea - 1, pvd);

        //            List<odts.DetalleDeterminacion> asociados = GetAsociados(new List<odts.DetalleDeterminacion>(), d.ArtiId1);

        //            foreach (odts.PresupuestoVentaDetalle a in asociados)
        //            {
        //                if (!EsArticuloDuplicado(a.ArtiId1))
        //                {
        //                    odts.DetalleDeterminacion dd = new odts.DetalleDeterminacion();
        //                    dd.Linea = linea;
        //                    dd.Sublinea = CalcularNuevaSublinea(linea);
        //                    dd.ArtiId1 = a.ArtiId1;
        //                    dd.Cantidad = (decimal)1;
        //                    dd.DetalleDescripcion = a.DetalleDescripcion;
        //                    dd.UnidadId = "UN";
        //                    dd.ArtiDeterminaciones = a.ArtiDeterminaciones;
        //                    dd.ArtiPNTMetodologia = a.ArtiPNTMetodologia;
        //                    if (dd.Precio == 0)
        //                    {
        //                        if (this.MediadorClieId == 0)
        //                            ctx.GetPrecioArticuloByCliente(dd, dd.ArtiId1, this.ClienteId, this.Documento, usuario);
        //                        else
        //                            ctx.GetPrecioArticuloByCliente(dd, dd.ArtiId1, this.MediadorClieId, this.Documento, usuario);

        //                        dd.ComportamientoIVA = this._CompId;
        //                    }

        //                    modelo.Determinaciones.AddRange(new List<odts.DetalleDeterminacion>() { dd });
        //                }
        //            }
        //        }
        //    }
        //}

        private List<odts.PresupuestoVentaBloque> GetBloquesQueContienen(int artiId)
        {
            List<odts.PresupuestoVentaBloque> resultado = new List<odts.PresupuestoVentaBloque>();

            foreach (odts.PresupuestoVentaBloque pvb in this.tlvPresupuestos.Objects)
            {
                if (pvb.Detalle != null)
                {
                    foreach (odts.PresupuestoVentaDetalle pvd in pvb.Detalle)
                    {
                        if (pvd is odts.DetalleModelo)
                        {
                            if (pvd.ArtiId1 == artiId)
                            {
                                resultado.Add(pvb);
                                break;
                            }
                            if (((odts.DetalleModelo)pvd).Determinaciones != null)
                            {
                                foreach (odts.DetalleDeterminacion dd in ((odts.DetalleModelo)pvd).Determinaciones)
                                {
                                    if (dd.ArtiId1 == artiId)
                                    {
                                        resultado.Add(pvb);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return resultado;
        }
#endregion // Fin de la region filtros de búsqueda

#region Eventos
        // Comportamiento de la ventana tras pulsar el botón de salir sin guardar
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Flecos: Poner un cuadro de diálogo para asegurar que no se cierre por error
            if (MessageBox.Show("¿Desea realmente salir sin guardar el detalle?", "Confirme", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)            
            {
                this.DialogResult = DialogResult.Abort;
                this.Close();
                this.Dispose();
            }
            
        }
        // Comportamiento de la ventana tras pulsar el botón de salir sin guardar
        private void btnOK_Click(object sender, EventArgs e)
        {
            GuardarDetalle();

            this.DialogResult = DialogResult.OK;              
            
        }
        // Expande mediante un click la vista en árbol de los presupuestos
        private void tlvPresupuestos_Click(object sender, EventArgs e)
        {
            if (this.tlvPresupuestos.SelectedColumn != this.cDocuId && this.tlvPresupuestos.SelectedObject != null)
            {
                this.tlvPresupuestos.Expand(this.tlvPresupuestos.SelectedObject);
            }
        }
        private void tlvPresupuestos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tlvPresupuestos.SelectedColumn != this.cDocuId && this.tlvPresupuestos.SelectedObject != null)
            {
                this.tlvPresupuestos.Expand(this.tlvPresupuestos.SelectedObject);
            }
        }

        // Botón derecho para eliminar líneas del detalle
        // Flecos: sustituir este comportamiento por un botón para adaptarlo a tablet
        private void fdlvDetalle_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.fdlvDetalle.SelectedObject != null)
            {
                if (e.Button == MouseButtons.Right)
                {
                    ContextMenu m = new ContextMenu();

                    MenuItem mi1 = new MenuItem("Eliminar línea", EliminarLinea);
                    m.MenuItems.Add(mi1);

                    m.Show(this.fdlvDetalle, new Point(e.X, e.Y));
                }
            }
        }
        private void EliminarLinea(object sender, EventArgs e)
        {
            DataRow dr = ((DataRowView)this.fdlvDetalle.SelectedObject).Row;
            if (dr["ESTDOC_ID"].ToString() == "FC")
            {
                MessageBox.Show("No se puede eliminar una línea FACTURADA", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string tipoLinea = dr["LIDO_ID"].ToString();
                int linea = (int)dr["PEDIDL_LINEA"];

                dr.Delete();
                if (tipoLinea == "N")
                {
                    var rows = ((DataTable)this.fdlvDetalle.DataSource).Select("PEDIDL_LINEA = " + linea);
                    foreach (var row in rows)
                        row.Delete();
                }
            }

        }
        private void EliminarLinea()
        {
            if (fdlvDetalle.SelectedObject == null)
            {
                return;
            }
            DataRow dr = ((DataRowView)this.fdlvDetalle.SelectedObject).Row;
            if (dr["ESTDOC_ID"].ToString() == "FC")
            {
                MessageBox.Show("No se puede eliminar una línea FACTURADA", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string tipoLinea = dr["LIDO_ID"].ToString();
                int linea = (int)dr["PEDIDL_LINEA"];

                dr.Delete();
                if (tipoLinea == "N")
                {
                    var rows = ((DataTable)this.fdlvDetalle.DataSource).Select("PEDIDL_LINEA = " + linea);
                    foreach (var row in rows)
                        row.Delete();
                }
            }

        }


#endregion //Fin de la sección del código que gestiona eventos de interacción del usuario

        #region editar Detalle

        // Guarda, borra o actualiza los campos de la tabla Pedidov_li relativos al pedido actual
        private void GuardarDetalle()
        {
            DataTable dt = (DataTable)this.fdlvDetalle.DataSource;
            this.fdlvDetalle.BindingContext[dt].EndCurrentEdit();            
            if (!plantilla)
            {
                DataTable insert = dt.GetChanges(DataRowState.Added);
                DataTable delete = dt.GetChanges(DataRowState.Deleted);
                DataTable update = dt.GetChanges(DataRowState.Modified);

                if (delete != null && delete.Rows.Count > 0)
                {
                    delete.Columns.Remove("GRDE_DESCRIPCION");
                    delete.Columns.Remove("UNID_DESCRIPCION");
                    delete.Columns.Remove("DEPA_ID");
                    delete.RejectChanges();
                    ctx.EliminarDetalle(delete); //dal.PedidosvDAL.EliminarDetalle(delete);                    
                }
                if (insert != null && insert.Rows.Count > 0)
                {
                    insert.Columns.Remove("GRDE_DESCRIPCION");
                    insert.Columns.Remove("UNID_DESCRIPCION");
                    insert.Columns.Remove("DEPA_ID");
                    ctx.InsertarDetalle(insert); // dal.PedidosvDAL.InsertarDetalle(insert);                    
                }

                if (update != null && update.Rows.Count > 0)
                {
                    update.Columns.Remove("GRDE_DESCRIPCION");
                    update.Columns.Remove("UNID_DESCRIPCION");
                    update.Columns.Remove("DEPA_ID");
                    ctx.ActualizarDetalle(update); // IMPLEMENTAR ActualizarDetalle//dal.PedidosvDAL.ActualizarDetalle(update);
                }
                ///
                /// Si se modifica un ACTA hay que cambiar su estado a RE
                if (delete != null || insert != null || update != null)
                {
                    ctx.PedidoActualizaEstado(this.Documento, this.Numero, "RE"); //dal.PedidosvDAL.PedidoActualizaEstado(this.Documento, this.Numero, "RE");
                    ctx.GuardarEstado(this.Documento, this.Numero, "RE", this.usuario);//dal.PedidosvDAL.GuardarEstado(this.Documento, this.Numero, "RE",  this.usuario);
                }
                PedidoIDorigen = Numero;
            }
            else
            {
                ctx.InsertarPlantillaDetalle(PedidoIDorigen, Numero);
            }
        }

        // Eventos de arrastrar y soltar para añadir modelos, determinaciones o bloques
        // de presupuestos al detalle del pedido
        private void fdlvDetalle_CanDrop(object sender, BrightIdeasSoftware.OlvDropEventArgs e)
        {
            OLVDataObject o = e.DataObject as OLVDataObject;
            int depaId = 0;
            if (o != null)
            {
                OLVListItem target = e.DropTargetItem;
                bool targetModelo = false;
                if (target != null)
                {
                    DataRowView drv = (DataRowView)target.RowObject;
                    depaId = (int)drv.Row["DEPA_ID"];
                    if (drv.Row["LIDO_ID"].ToString() == "N")
                        targetModelo = true;
                }
                foreach (var model in o.ModelObjects)
                {
                    if (model is odts.PresupuestoVentaBloque)
                    {
                        bool permitir = true;
                        foreach (odts.PresupuestoVentaDetalle d in ((odts.PresupuestoVentaBloque)model).Detalle)
                        {
                            if (EsArticuloDuplicado(d.ArtiId1))
                            {
                                permitir = false;
                                break;
                            }
                        }
                        if (permitir)
                        {
                            e.Effect = DragDropEffects.Copy;
                            e.InfoMessage = "Añadir un presupuesto completo";
                        }
                        else
                        {
                            e.Effect = DragDropEffects.None;
                            e.InfoMessage = "Hay artículos repetidos";
                        }
                    }
                    else if (model is Almacen.odts.ArticuloModelo && target == null)
                    {
                        if (!EsArticuloDuplicado(((Almacen.odts.ArticuloModelo)model).ArtiId1))
                        {
                            e.Effect = DragDropEffects.Copy;
                            e.InfoMessage = "Añadir un modelo al acta";
                        }
                        else
                        {
                            e.Effect = DragDropEffects.None;
                            e.InfoMessage = "Hay artículos repetidos";
                        }
                    }
                    else if (model is Almacen.odts.ArticuloModelo && targetModelo)
                    {
                        e.Effect = DragDropEffects.Copy;
                        e.InfoMessage = "Añadir las determinaciones de un modelo a otro modelo";
                    }
                    else if (model is Almacen.odts.ArticuloDeterminacion && targetModelo)
                    {
                        int depaDeterminacion = ((Almacen.odts.ArticuloDeterminacion)model).DepartamentoId;
                        if (depaDeterminacion != 0 && depaDeterminacion != depaId)
                        {
                            e.Effect = DragDropEffects.None;
                            e.InfoMessage = "El departamento de la determinación no coincide con el del modelo";
                        }
                        else if (!EsArticuloDuplicado(((Almacen.odts.ArticuloDeterminacion)model).ArtiId1))
                        {
                            e.Effect = DragDropEffects.Copy;
                            e.InfoMessage = "Añadir una determinación a un modelo";
                        }
                        else
                        {
                            e.Effect = DragDropEffects.None;
                            e.InfoMessage = "Hay artículos repetidos";
                        }

                    }
                    else if (model is Almacen.odts.ArticuloDeterminacion && target != null && !targetModelo)
                    {
                        int depaDeterminacion = ((Almacen.odts.ArticuloDeterminacion)model).DepartamentoId;
                        if (depaDeterminacion != 0 && depaDeterminacion != depaId)
                        {
                            e.Effect = DragDropEffects.None;
                            e.InfoMessage = "El departamento de la determinación no coincide con el del modelo";
                        }
                        else if (!EsArticuloDuplicado(((Almacen.odts.ArticuloDeterminacion)model).ArtiId1))
                        {
                            e.Effect = DragDropEffects.Copy;
                            e.InfoMessage = "Añadir una determinación en esta posición";
                        }
                        else
                        {
                            e.Effect = DragDropEffects.None;
                            e.InfoMessage = "Hay artículos repetidos";
                        }

                    }
                    else if (model is DataRowView && target != null)
                    {
                        int depaModel = (int)((DataRowView)model).Row["DEPA_ID"];
                        if (depaModel == 0 || depaModel == depaId)
                        {

                            DataRow modelDataRow = ((DataRowView)model).Row;
                            DataRow targetDataRow = ((DataRowView)target.RowObject).Row;
                            if (modelDataRow["LIDO_ID"].ToString() == targetDataRow["LIDO_ID"].ToString())
                            {
                                e.Effect = DragDropEffects.Move;
                                e.InfoMessage = "Mover aquí";
                            }
                        }
                        else if (depaModel != depaId)
                        {
                            e.Effect = DragDropEffects.None;
                            e.InfoMessage = "Los dos artículos deben pertenecer al mismo departamento";
                        }
                        else
                        {
                            e.Effect = DragDropEffects.None;
                            e.InfoMessage = "Este movimiento no está permitido";
                        }
                    }
                    else
                    {
                        e.Effect = DragDropEffects.None;
                        e.InfoMessage = "Este movimiento no está permitido";
                    }
                }
            }
        }
        // Comprobar que no se repiten artículos
        private bool EsArticuloDuplicado(int artiId1)
        {
            foreach (DataRow dr in ((DataTable)this.fdlvDetalle.DataSource).Rows)
            {
                if ((int)dr["ARTI_ID1"] == artiId1)
                {
                    return true;
                }
            }
            return false;
        }
        private bool EsArticuloDuplicado(int artiId1, odts.DetalleModelo modelo)
        {
            foreach (odts.DetalleDeterminacion d in modelo.Determinaciones)
            {
                if (d.ArtiId1 == artiId1)
                {
                    return true;
                }
            }
            return false;
        }

        private void fdlvDetalle_Dropped(object sender, OlvDropEventArgs e)
        {
            e.Handled = true;
            OLVDataObject o = e.DataObject as OLVDataObject;
            if (o != null)
            {
                OLVListItem target = e.DropTargetItem;
                bool targetModelo = false;
                if (target != null)
                {
                    DataRowView drv = (DataRowView)target.RowObject;
                    if (drv.Row["LIDO_ID"].ToString() == "N")
                    {
                        targetModelo = true;
                    }
                }
                foreach (var model in o.ModelObjects)
                {
                    if (model is odts.PresupuestoVentaBloque)
                    {
                        bool permitir = true;
                        foreach (odts.PresupuestoVentaDetalle d in ((odts.PresupuestoVentaBloque)model).Detalle)
                        {
                            if (EsArticuloDuplicado(d.ArtiId1))
                            {
                                permitir = false;
                                break;
                            }
                        }
                        if (permitir)
                        {
                            // Copiar presupuesto
                            DataTable dt = (DataTable)this.fdlvDetalle.DataSource;
                            odts.PresupuestoVentaBloque bloque = (odts.PresupuestoVentaBloque)model;
                            foreach (odts.PresupuestoVentaDetalle d in ((odts.PresupuestoVentaBloque)model).Detalle)
                            {
                                DataRow dr = dt.NewRow();
                                dr["DOCU_ID"] = this.Documento;
                                dr["PEDID_ID"] = this.Numero;
                                dr["ESTDOC_ID"] = "N";
                                dr["LIDO_ID"] = d.TipoLinea;
                                dr["DOCU_ID_ORIGEN"] = bloque.DocuId;
                                dr["DOCU_NUMERO_ORIGEN"] = bloque.PresuvId;
                                dr["DOCU_LINEA_ORIGEN"] = d.Linea;
                                dr["DOCU_SUBLINEA_ORIGEN"] = d.Sublinea;
                                dr["PEDIDL_FLUJOC"] = "0";
                                dr["PEDIDL_FLUJOL"] = "0";
                                dr["PEDIDL_FECHAD_APLIC"] = string.Empty;
                                dr["PEDIDL_FECHAH_APLIC"] = string.Empty;
                                int linea = CalcularNuevaLinea();
                                dr["PEDIDL_LINEA"] = linea;
                                if (d.TipoLinea == "N")
                                    dr["PEDIDL_SUBLINEA"] = 0;
                                else
                                    dr["PEDIDL_SUBLINEA"] = d.Sublinea;
                                dr["PEDIDL_DESCRIPCION"] = d.DetalleDescripcion;
                                dr["PEDIDL_CANTIDAD"] = 1;
                                dr["UNID_ID"] = "UN";
                                dr["PEDIDL_PRECIO"] = d.Precio;
                                if (d.DescuentoId.HasValue)
                                    dr["GRDE_ID"] = d.DescuentoId;
                                else
                                    dr["GRDE_ID"] = DBNull.Value;
                                dr["COMP_ID"] = this._CompId;
                                dr["ARTI_ID1"] = d.ArtiId1;
                                dr["DEPA_ID"] = d.DepartamentoId;

                                dt.Rows.Add(dr);

                                if (d is odts.DetalleModelo)
                                {
                                    foreach (odts.DetalleDeterminacion dd in (d as odts.DetalleModelo).Determinaciones)
                                    {
                                        DataRow drd = dt.NewRow();
                                        drd["DOCU_ID"] = this.Documento;
                                        drd["PEDID_ID"] = this.Numero;
                                        drd["ESTDOC_ID"] = "N";
                                        drd["DOCU_ID_ORIGEN"] = bloque.DocuId;
                                        drd["DOCU_NUMERO_ORIGEN"] = bloque.PresuvId;
                                        drd["DOCU_LINEA_ORIGEN"] = d.Linea;
                                        drd["DOCU_SUBLINEA_ORIGEN"] = d.Sublinea;
                                        drd["PEDIDL_FLUJOC"] = "0";
                                        drd["PEDIDL_FLUJOL"] = "0";
                                        drd["PEDIDL_FECHAD_APLIC"] = string.Empty;
                                        drd["PEDIDL_FECHAH_APLIC"] = string.Empty;

                                        drd["LIDO_ID"] = dd.TipoLinea;
                                        drd["PEDIDL_LINEA"] = linea;
                                        drd["PEDIDL_SUBLINEA"] = dd.Sublinea;
                                        drd["PEDIDL_DESCRIPCION"] = dd.DetalleDescripcion;
                                        drd["PEDIDL_CANTIDAD"] = 1;
                                        drd["UNID_ID"] = "UN";
                                        drd["PEDIDL_PRECIO"] = dd.Precio;
                                        if (dd.DescuentoId.HasValue)
                                            drd["GRDE_ID"] = dd.DescuentoId;
                                        else
                                            drd["GRDE_ID"] = DBNull.Value;
                                        drd["COMP_ID"] = this._CompId;
                                        drd["ARTI_ID1"] = dd.ArtiId1;
                                        drd["DEPA_ID"] = dd.DepartamentoId;

                                        dt.Rows.Add(drd);
                                    }
                                }
                            }
                        }
                        else
                        {
                            e.Effect = DragDropEffects.None;
                            e.InfoMessage = "Hay artículos repetidos";
                        }
                    }
                    else if (model is Almacen.odts.ArticuloModelo && target == null)
                    {
                        if (!EsArticuloDuplicado(((Almacen.odts.ArticuloModelo)model).ArtiId1))
                        {
                            // Añadir modelo al acta
                            Almacen.odts.ArticuloModelo modelo = (Almacen.odts.ArticuloModelo)model;
                            DataTable dt = (DataTable)this.fdlvDetalle.DataSource;
                            DataRow dr = dt.NewRow();
                            dr["DOCU_ID"] = this.Documento;
                            dr["PEDID_ID"] = this.Numero;
                            dr["ESTDOC_ID"] = "N";
                            dr["DOCU_ID_ORIGEN"] = DBNull.Value;
                            dr["DOCU_NUMERO_ORIGEN"] = DBNull.Value;
                            dr["DOCU_LINEA_ORIGEN"] = DBNull.Value;
                            dr["PEDIDL_FLUJOC"] = "1";
                            dr["PEDIDL_FLUJOL"] = "1";
                            dr["PEDIDL_FECHAD_APLIC"] = string.Empty;
                            dr["PEDIDL_FECHAH_APLIC"] = string.Empty;

                            dr["LIDO_ID"] = "N";
                            int linea = CalcularNuevaLinea();
                            dr["PEDIDL_LINEA"] = linea;
                            dr["PEDIDL_SUBLINEA"] = 0;
                            dr["PEDIDL_DESCRIPCION"] = modelo.Descripcion;
                            dr["PEDIDL_CANTIDAD"] = 1;
                            dr["UNID_ID"] = "UN";
                            object[] precio = null;
                            if (this.MediadorClieId == 0)
                                precio = ctx.GetPrecioArticuloByCliente(modelo.ArtiId1, this.ClienteId, this.Documento, usuario);
                            else
                                precio = ctx.GetPrecioArticuloByCliente(modelo.ArtiId1, this.MediadorClieId, this.Documento, usuario);

                            dr["PEDIDL_PRECIO"] = precio[0] != null ? precio[0] : 0;
                            dr["GRDE_ID"] = precio[1] != null ? precio[1] : DBNull.Value;
                            dr["COMP_ID"] = this._CompId;
                            dr["ARTI_ID1"] = modelo.ArtiId1;
                            dr["DEPA_ID"] = modelo.DepartamentoId;

                            dt.Rows.Add(dr);

                            List<odts.DetalleDeterminacion> asociados = GetAsociados(new List<odts.DetalleDeterminacion>(), modelo.ArtiId1);

                            foreach (odts.PresupuestoVentaDetalle a in asociados)
                            {
                                if (!EsArticuloDuplicado(a.ArtiId1))
                                {
                                    DataRow drd = dt.NewRow();
                                    drd["DOCU_ID"] = this.Documento;
                                    drd["PEDID_ID"] = this.Numero;
                                    drd["ESTDOC_ID"] = "N";
                                    drd["DOCU_ID_ORIGEN"] = DBNull.Value;
                                    drd["DOCU_NUMERO_ORIGEN"] = DBNull.Value;
                                    drd["DOCU_LINEA_ORIGEN"] = DBNull.Value;
                                    drd["PEDIDL_FLUJOC"] = "1";
                                    drd["PEDIDL_FLUJOL"] = "1";
                                    drd["PEDIDL_FECHAD_APLIC"] = string.Empty;
                                    drd["PEDIDL_FECHAH_APLIC"] = string.Empty;

                                    drd["LIDO_ID"] = "N+";
                                    drd["PEDIDL_LINEA"] = linea;
                                    drd["PEDIDL_SUBLINEA"] = CalcularNuevaSublinea(linea);
                                    drd["PEDIDL_DESCRIPCION"] = a.DetalleDescripcion;
                                    drd["PEDIDL_CANTIDAD"] = 1;
                                    drd["UNID_ID"] = "UN";
                                    object[] precio1 = null;
                                    if (this.MediadorClieId == 0)
                                        precio1 = ctx.GetPrecioArticuloByCliente(a.ArtiId1, this.ClienteId, this.Documento, usuario);
                                    else
                                        precio1 = ctx.GetPrecioArticuloByCliente(a.ArtiId1, this.MediadorClieId, this.Documento, usuario);
                                    drd["PEDIDL_PRECIO"] = precio1[0] != null ? precio1[0] : 0;
                                    drd["GRDE_ID"] = precio1[1] != null ? precio1[1] : DBNull.Value;
                                    drd["COMP_ID"] = this._CompId;
                                    drd["ARTI_ID1"] = a.ArtiId1;
                                    drd["DEPA_ID"] = a.DepartamentoId;

                                    dt.Rows.Add(drd);
                                }
                            }
                        }
                        else
                        {
                            e.Effect = DragDropEffects.None;
                            e.InfoMessage = "Hay artículos repetidos";
                        }
                    }
                    else if (model is Almacen.odts.ArticuloModelo && targetModelo)
                    {
                        e.Effect = DragDropEffects.Copy;
                        e.InfoMessage = "Añadir las determinaciones de un modelo a otro modelo";
                    }
                    else if (model is Almacen.odts.ArticuloDeterminacion && targetModelo)
                    {
                        if (!EsArticuloDuplicado(((Almacen.odts.ArticuloDeterminacion)model).ArtiId1))
                        {
                            // Añadir determinacion al acta
                            Almacen.odts.ArticuloDeterminacion determinacion = (Almacen.odts.ArticuloDeterminacion)model;
                            DataRow drModelo = ((DataRowView)e.DropTargetItem.RowObject).Row;
                            int lineaModelo = (int)drModelo["PEDIDL_LINEA"];

                            DataTable dt = (DataTable)this.fdlvDetalle.DataSource;
                            DataRow dr = dt.NewRow();
                            dr["DOCU_ID"] = this.Documento;
                            dr["PEDID_ID"] = this.Numero;
                            dr["ESTDOC_ID"] = "N";
                            dr["DOCU_ID_ORIGEN"] = DBNull.Value;
                            dr["DOCU_NUMERO_ORIGEN"] = DBNull.Value;
                            dr["DOCU_LINEA_ORIGEN"] = DBNull.Value;
                            dr["PEDIDL_FLUJOC"] = "1";
                            dr["PEDIDL_FLUJOL"] = "1";
                            dr["PEDIDL_FECHAD_APLIC"] = string.Empty;
                            dr["PEDIDL_FECHAH_APLIC"] = string.Empty;

                            dr["LIDO_ID"] = "N+";
                            dr["PEDIDL_LINEA"] = lineaModelo;
                            dr["PEDIDL_SUBLINEA"] = CalcularNuevaSublinea(lineaModelo);
                            dr["PEDIDL_DESCRIPCION"] = determinacion.Descripcion;
                            dr["PEDIDL_CANTIDAD"] = 1;
                            dr["UNID_ID"] = "UN";
                            object[] precio = null;
                            if (this.MediadorClieId == 0)
                                precio = ctx.GetPrecioArticuloByCliente(determinacion.ArtiId1, this.ClienteId, this.Documento, usuario);
                            else
                                precio = ctx.GetPrecioArticuloByCliente(determinacion.ArtiId1, this.MediadorClieId, this.Documento, usuario);
                            dr["PEDIDL_PRECIO"] = precio[0] != null ? precio[0] : 0;
                            dr["GRDE_ID"] = precio[1] != null ? precio[1] : DBNull.Value;
                            dr["COMP_ID"] = this._CompId;
                            dr["ARTI_ID1"] = determinacion.ArtiId1;
                            dr["DEPA_ID"] = determinacion.DepartamentoId;

                            dt.Rows.Add(dr);

                            List<odts.DetalleDeterminacion> asociados = GetAsociados(new List<odts.DetalleDeterminacion>(), determinacion.ArtiId1);

                            foreach (odts.PresupuestoVentaDetalle a in asociados)
                            {
                                if (!EsArticuloDuplicado(a.ArtiId1))
                                {
                                    DataRow drd = dt.NewRow();
                                    drd["DOCU_ID"] = this.Documento;
                                    drd["PEDID_ID"] = this.Numero;
                                    drd["ESTDOC_ID"] = "N";
                                    drd["DOCU_ID_ORIGEN"] = DBNull.Value;
                                    drd["DOCU_NUMERO_ORIGEN"] = DBNull.Value;
                                    drd["DOCU_LINEA_ORIGEN"] = DBNull.Value;
                                    drd["PEDIDL_FLUJOC"] = "1";
                                    drd["PEDIDL_FLUJOL"] = "1";
                                    drd["PEDIDL_FECHAD_APLIC"] = string.Empty;
                                    drd["PEDIDL_FECHAH_APLIC"] = string.Empty;

                                    drd["LIDO_ID"] = "N+";
                                    drd["PEDIDL_LINEA"] = lineaModelo;
                                    drd["PEDIDL_SUBLINEA"] = CalcularNuevaSublinea(lineaModelo);
                                    drd["PEDIDL_DESCRIPCION"] = a.DetalleDescripcion;
                                    drd["PEDIDL_CANTIDAD"] = 1;
                                    drd["UNID_ID"] = "UN";
                                    object[] precio1 = null;
                                    if (this.MediadorClieId == 0)
                                        precio1 = ctx.GetPrecioArticuloByCliente(a.ArtiId1, this.ClienteId, this.Documento, usuario);
                                    else
                                        precio1 = ctx.GetPrecioArticuloByCliente(a.ArtiId1, this.MediadorClieId, this.Documento, usuario);
                                    drd["PEDIDL_PRECIO"] = precio1[0] != null ? precio1[0] : 0;
                                    drd["GRDE_ID"] = precio1[1] != null ? precio1[1] : DBNull.Value;
                                    drd["COMP_ID"] = this._CompId;
                                    drd["ARTI_ID1"] = a.ArtiId1;
                                    drd["DEPA_ID"] = a.DepartamentoId;

                                    dt.Rows.Add(drd);
                                }
                            }

                        }
                        else
                        {
                            e.Effect = DragDropEffects.None;
                            e.InfoMessage = "Hay artículos repetidos";
                        }

                    }
                    else if (model is Almacen.odts.ArticuloDeterminacion && target != null && !targetModelo)
                    {
                        if (!EsArticuloDuplicado(((Almacen.odts.ArticuloDeterminacion)model).ArtiId1))
                        {
                            // Añadir determinacion al acta
                            Almacen.odts.ArticuloDeterminacion determinacion = (Almacen.odts.ArticuloDeterminacion)model;
                            DataRow drModelo = ((DataRowView)e.DropTargetItem.RowObject).Row;
                            int lineaModelo = (int)drModelo["PEDIDL_LINEA"];

                            DataTable dt = (DataTable)this.fdlvDetalle.DataSource;
                            DataRow dr = dt.NewRow();
                            dr["DOCU_ID"] = this.Documento;
                            dr["PEDID_ID"] = this.Numero;
                            dr["ESTDOC_ID"] = "N";
                            dr["DOCU_ID_ORIGEN"] = DBNull.Value;
                            dr["DOCU_NUMERO_ORIGEN"] = DBNull.Value;
                            dr["DOCU_LINEA_ORIGEN"] = DBNull.Value;
                            dr["PEDIDL_FLUJOC"] = "1";
                            dr["PEDIDL_FLUJOL"] = "1";
                            dr["PEDIDL_FECHAD_APLIC"] = string.Empty;
                            dr["PEDIDL_FECHAH_APLIC"] = string.Empty;

                            dr["LIDO_ID"] = "N+";
                            dr["PEDIDL_LINEA"] = lineaModelo;
                            dr["PEDIDL_SUBLINEA"] = CalcularNuevaSublinea(lineaModelo);
                            dr["PEDIDL_DESCRIPCION"] = determinacion.Descripcion;
                            dr["PEDIDL_CANTIDAD"] = 1;
                            dr["UNID_ID"] = "UN";
                            object[] precio = null;
                            if (this.MediadorClieId == 0)
                                precio = ctx.GetPrecioArticuloByCliente(determinacion.ArtiId1, this.ClienteId, this.Documento, usuario);
                            else
                                precio = ctx.GetPrecioArticuloByCliente(determinacion.ArtiId1, this.MediadorClieId, this.Documento, usuario);
                            dr["PEDIDL_PRECIO"] = precio[0] != null ? precio[0] : 0;
                            dr["GRDE_ID"] = precio[1] != null ? precio[1] : DBNull.Value;
                            dr["COMP_ID"] = this._CompId;
                            dr["ARTI_ID1"] = determinacion.ArtiId1;
                            dr["DEPA_ID"] = determinacion.DepartamentoId;

                            dt.Rows.Add(dr);

                            List<odts.DetalleDeterminacion> asociados = GetAsociados(new List<odts.DetalleDeterminacion>(), determinacion.ArtiId1);

                            foreach (odts.PresupuestoVentaDetalle a in asociados)
                            {
                                if (!EsArticuloDuplicado(a.ArtiId1))
                                {
                                    DataRow drd = dt.NewRow();
                                    drd["DOCU_ID"] = this.Documento;
                                    drd["PEDID_ID"] = this.Numero;
                                    drd["ESTDOC_ID"] = "N";
                                    drd["DOCU_ID_ORIGEN"] = DBNull.Value;
                                    drd["DOCU_NUMERO_ORIGEN"] = DBNull.Value;
                                    drd["DOCU_LINEA_ORIGEN"] = DBNull.Value;
                                    drd["PEDIDL_FLUJOC"] = "1";
                                    drd["PEDIDL_FLUJOL"] = "1";
                                    drd["PEDIDL_FECHAD_APLIC"] = string.Empty;
                                    drd["PEDIDL_FECHAH_APLIC"] = string.Empty;

                                    drd["LIDO_ID"] = "N+";
                                    drd["PEDIDL_LINEA"] = lineaModelo;
                                    drd["PEDIDL_SUBLINEA"] = CalcularNuevaSublinea(lineaModelo);
                                    drd["PEDIDL_DESCRIPCION"] = a.DetalleDescripcion;
                                    drd["PEDIDL_CANTIDAD"] = 1;
                                    drd["UNID_ID"] = "UN";
                                    object[] precio1 = null;
                                    if (this.MediadorClieId == 0)
                                        precio1 = ctx.GetPrecioArticuloByCliente(a.ArtiId1, this.ClienteId, this.Documento, usuario);
                                    else
                                        precio1 = ctx.GetPrecioArticuloByCliente(a.ArtiId1, this.MediadorClieId, this.Documento, usuario);
                                    drd["PEDIDL_PRECIO"] = precio1[0] != null ? precio1[0] : 0;
                                    drd["GRDE_ID"] = precio1[1] != null ? precio1[1] : DBNull.Value;
                                    drd["COMP_ID"] = this._CompId;
                                    drd["ARTI_ID1"] = a.ArtiId1;
                                    drd["DEPA_ID"] = a.DepartamentoId;

                                    dt.Rows.Add(drd);
                                }
                            }
                        }
                        else
                        {

                            e.Handled = false;
                        }

                    }
                    // Intercambiar 2 determinaciones
                    else if (model is DataRowView && target != null && !targetModelo)
                    {
                        DataRow destino = ((DataRowView)target.RowObject).Row;
                        DataRow origen = ((DataRowView)model).Row;
                        IntercambiaFilas(origen, destino);

                    }
                    else
                    {
                        e.Effect = DragDropEffects.None;
                        e.InfoMessage = "Este movimiento no está permitido";
                    }
                }
            }
        }
        private int CalcularNuevaLinea()
        {
            DataTable dt = (DataTable)this.fdlvDetalle.DataSource;

            if (dt == null || dt.Rows.Count == 0)
                return 10;

            int max = (int)dt.Compute("MAX (PEDIDL_LINEA)", string.Empty);

            return max + 10;
        }
        private int CalcularNuevaSublinea(int linea)
        {
            DataTable dt = (DataTable)this.fdlvDetalle.DataSource;

            int max = (int)dt.Compute("MAX (PEDIDL_SUBLINEA)", "PEDIDL_LINEA = " + linea);

            return max + 1;

        }
        private List<odts.DetalleDeterminacion> GetAsociados(List<odts.DetalleDeterminacion> asociados, int artiId1)
        {
            if (asociados.FirstOrDefault(a => a.ArtiId1 == artiId1) == null)
            {
                // Flecos: Cambiar el dal por el contexto
                List<odts.DetalleDeterminacion> t1 = ctx.GetAsociados(artiId1);
                foreach (odts.DetalleDeterminacion d in t1)
                {
                    if (!asociados.Contains(d))
                    {
                        asociados.Add(d);
                    }
                }
                try
                {
                    if (asociados.Count != 0)
                    {
                        List<odts.DetalleDeterminacion> temporal = new List<odts.DetalleDeterminacion>();
                        foreach (odts.DetalleDeterminacion d in t1)
                        {
                            temporal.AddRange(GetAsociados(asociados, d.ArtiId1));                            
                        }
                        foreach (odts.DetalleDeterminacion d in temporal)
                        {
                            if (!asociados.Contains(d))
                            {
                                asociados.Add(d);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrior un error con los artículos asociados: " + ex.Message);
                }
            }
            return asociados;
        }
        private void IntercambiaFilas(DataRow origen, DataRow destino)
        {
            int lineaOrigen = (int)origen["PEDIDL_LINEA"];
            int subLineaOrigen = (int)origen["PEDIDL_SUBLINEA"];
            int lineaDestino = (int)destino["PEDIDL_LINEA"];
            int subLineaDestino = (int)destino["PEDIDL_SUBLINEA"];
            destino["PEDIDL_LINEA"] = lineaOrigen;
            destino["PEDIDL_SUBLINEA"] = subLineaOrigen;
            origen["PEDIDL_LINEA"] = lineaDestino;
            origen["PEDIDL_SUBLINEA"] = subLineaDestino;


            DataRow aux = ((DataTable)this.fdlvDetalle.DataSource).NewRow();
            aux.ItemArray = origen.ItemArray;
            origen.ItemArray = destino.ItemArray;
            destino.ItemArray = aux.ItemArray;

        }

        


        #endregion // Fin de la sección de código que gestiona la modificación del detalle

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarLinea();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarDetalle();

            this.DialogResult = DialogResult.OK;  
        }

        

    }
}
