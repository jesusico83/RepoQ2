namespace DocumentosVentas
{
    partial class PedidovDetalle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PedidovDetalle));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.folvModelos = new BrightIdeasSoftware.FastObjectListView();
            this.cModeloDescripcion = new BrightIdeasSoftware.OLVColumn();
            this.cModeloArtiId1 = new BrightIdeasSoftware.OLVColumn();
            this.cEsHibrido = new BrightIdeasSoftware.OLVColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTipoAnalisis = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.folvDeterminaciones = new BrightIdeasSoftware.FastObjectListView();
            this.cDeterminacionDescripcion = new BrightIdeasSoftware.OLVColumn();
            this.cDeterminacionArtiId1 = new BrightIdeasSoftware.OLVColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.txtDeterminacion = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.LinkLabel();
            this.lblMatriz = new System.Windows.Forms.LinkLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.fdlvDetalle = new BrightIdeasSoftware.FastDataListView();
            this.olvTipoLinea = new BrightIdeasSoftware.OLVColumn();
            this.olvLinea = new BrightIdeasSoftware.OLVColumn();
            this.olvSublinea = new BrightIdeasSoftware.OLVColumn();
            this.olvDescripcion = new BrightIdeasSoftware.OLVColumn();
            this.olvCantidad = new BrightIdeasSoftware.OLVColumn();
            this.olvUnidId = new BrightIdeasSoftware.OLVColumn();
            this.olvPrecio = new BrightIdeasSoftware.OLVColumn();
            this.olvDescuento = new BrightIdeasSoftware.OLVColumn();
            this.olvDescuentoDescripcion = new BrightIdeasSoftware.OLVColumn();
            this.olvArtiId1 = new BrightIdeasSoftware.OLVColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tlvPresupuestos = new BrightIdeasSoftware.TreeListView();
            this.cDocuId = new BrightIdeasSoftware.OLVColumn();
            this.cPresuvId = new BrightIdeasSoftware.OLVColumn();
            this.cFamilDescripcion = new BrightIdeasSoftware.OLVColumn();
            this.cTitulo = new BrightIdeasSoftware.OLVColumn();
            this.cEstado = new BrightIdeasSoftware.OLVColumn();
            this.cDetalleDescripcion = new BrightIdeasSoftware.OLVColumn();
            this.cCantidad = new BrightIdeasSoftware.OLVColumn();
            this.cUnidadId = new BrightIdeasSoftware.OLVColumn();
            this.cPrecio = new BrightIdeasSoftware.OLVColumn();
            this.cDescuentoDescripcion = new BrightIdeasSoftware.OLVColumn();
            this.cReferenciaCliente = new BrightIdeasSoftware.OLVColumn();
            this.cFechaCreacion = new BrightIdeasSoftware.OLVColumn();
            this.cCliente = new BrightIdeasSoftware.OLVColumn();
            this.cArtiId1 = new BrightIdeasSoftware.OLVColumn();
            this.cBloqueTipoLinea = new BrightIdeasSoftware.OLVColumn();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.folvModelos)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.folvDeterminaciones)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fdlvDetalle)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlvPresupuestos)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(4, 70);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.folvModelos);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.folvDeterminaciones);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(1015, 249);
            this.splitContainer1.SplitterDistance = 483;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 0;
            // 
            // folvModelos
            // 
            this.folvModelos.AllColumns.Add(this.cModeloDescripcion);
            this.folvModelos.AllColumns.Add(this.cModeloArtiId1);
            this.folvModelos.AllColumns.Add(this.cEsHibrido);
            this.folvModelos.AlternateRowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(219)))), ((int)(((byte)(249)))));
            this.folvModelos.CheckBoxes = true;
            this.folvModelos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cModeloDescripcion});
            this.folvModelos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.folvModelos.FullRowSelect = true;
            this.folvModelos.IsSimpleDragSource = true;
            this.folvModelos.Location = new System.Drawing.Point(0, 35);
            this.folvModelos.MultiSelect = false;
            this.folvModelos.Name = "folvModelos";
            this.folvModelos.RowHeight = 20;
            this.folvModelos.ShowGroups = false;
            this.folvModelos.ShowImagesOnSubItems = true;
            this.folvModelos.Size = new System.Drawing.Size(479, 210);
            this.folvModelos.SortGroupItemsByPrimaryColumn = false;
            this.folvModelos.TabIndex = 1;
            this.folvModelos.UseAlternatingBackColors = true;
            this.folvModelos.UseCompatibleStateImageBehavior = false;
            this.folvModelos.UseFiltering = true;
            this.folvModelos.View = System.Windows.Forms.View.Details;
            this.folvModelos.VirtualMode = true;
            this.folvModelos.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.folvModelos_ItemChecked);
            // 
            // cModeloDescripcion
            // 
            this.cModeloDescripcion.AspectName = "Descripcion";
            this.cModeloDescripcion.Text = "Artículo";
            this.cModeloDescripcion.Width = 464;
            // 
            // cModeloArtiId1
            // 
            this.cModeloArtiId1.AspectName = "ArtiId1";
            this.cModeloArtiId1.IsVisible = false;
            // 
            // cEsHibrido
            // 
            this.cEsHibrido.AspectName = "EsHibrido";
            this.cEsHibrido.IsVisible = false;
            this.cEsHibrido.Text = "EsHibrido";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTipoAnalisis);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.txtModelo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(479, 35);
            this.panel1.TabIndex = 0;
            // 
            // lblTipoAnalisis
            // 
            this.lblTipoAnalisis.AutoSize = true;
            this.lblTipoAnalisis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoAnalisis.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTipoAnalisis.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
            this.lblTipoAnalisis.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lblTipoAnalisis.Location = new System.Drawing.Point(254, 7);
            this.lblTipoAnalisis.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTipoAnalisis.Name = "lblTipoAnalisis";
            this.lblTipoAnalisis.Size = new System.Drawing.Size(97, 20);
            this.lblTipoAnalisis.TabIndex = 2;
            this.lblTipoAnalisis.Text = "Tipo Analisis";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.linkLabel1.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
            this.linkLabel1.LinkColor = System.Drawing.Color.MidnightBlue;
            this.linkLabel1.Location = new System.Drawing.Point(4, 5);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(115, 20);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.Text = "Buscar Modelo";
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(127, 4);
            this.txtModelo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(119, 26);
            this.txtModelo.TabIndex = 0;
            this.txtModelo.TextChanged += new System.EventHandler(this.txtModelo_TextChanged);
            // 
            // folvDeterminaciones
            // 
            this.folvDeterminaciones.AllColumns.Add(this.cDeterminacionDescripcion);
            this.folvDeterminaciones.AllColumns.Add(this.cDeterminacionArtiId1);
            this.folvDeterminaciones.AlternateRowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(219)))), ((int)(((byte)(249)))));
            this.folvDeterminaciones.CheckBoxes = true;
            this.folvDeterminaciones.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cDeterminacionDescripcion});
            this.folvDeterminaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.folvDeterminaciones.FullRowSelect = true;
            this.folvDeterminaciones.IsSimpleDragSource = true;
            this.folvDeterminaciones.Location = new System.Drawing.Point(0, 35);
            this.folvDeterminaciones.MultiSelect = false;
            this.folvDeterminaciones.Name = "folvDeterminaciones";
            this.folvDeterminaciones.RowHeight = 20;
            this.folvDeterminaciones.ShowGroups = false;
            this.folvDeterminaciones.ShowImagesOnSubItems = true;
            this.folvDeterminaciones.Size = new System.Drawing.Size(522, 210);
            this.folvDeterminaciones.SortGroupItemsByPrimaryColumn = false;
            this.folvDeterminaciones.TabIndex = 2;
            this.folvDeterminaciones.UseAlternatingBackColors = true;
            this.folvDeterminaciones.UseCompatibleStateImageBehavior = false;
            this.folvDeterminaciones.UseFiltering = true;
            this.folvDeterminaciones.View = System.Windows.Forms.View.Details;
            this.folvDeterminaciones.VirtualMode = true;
            this.folvDeterminaciones.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.folvDeterminaciones_FormatRow);
            // 
            // cDeterminacionDescripcion
            // 
            this.cDeterminacionDescripcion.AspectName = "Descripcion";
            this.cDeterminacionDescripcion.Text = "Artículo";
            this.cDeterminacionDescripcion.Width = 476;
            // 
            // cDeterminacionArtiId1
            // 
            this.cDeterminacionArtiId1.AspectName = "ArtiId1";
            this.cDeterminacionArtiId1.IsVisible = false;
            this.cDeterminacionArtiId1.Text = "ArtiId1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.linkLabel2);
            this.panel2.Controls.Add(this.txtDeterminacion);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(522, 35);
            this.panel2.TabIndex = 1;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.linkLabel2.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
            this.linkLabel2.LinkColor = System.Drawing.Color.MidnightBlue;
            this.linkLabel2.Location = new System.Drawing.Point(4, 5);
            this.linkLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(166, 20);
            this.linkLabel2.TabIndex = 3;
            this.linkLabel2.Text = "Buscar Determinación";
            // 
            // txtDeterminacion
            // 
            this.txtDeterminacion.Location = new System.Drawing.Point(172, 5);
            this.txtDeterminacion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDeterminacion.Name = "txtDeterminacion";
            this.txtDeterminacion.Size = new System.Drawing.Size(141, 26);
            this.txtDeterminacion.TabIndex = 2;
            this.txtDeterminacion.TextChanged += new System.EventHandler(this.txtDeterminacion_TextChanged);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblCliente.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
            this.lblCliente.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lblCliente.Location = new System.Drawing.Point(55, 9);
            this.lblCliente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(76, 20);
            this.lblCliente.TabIndex = 15;
            this.lblCliente.Text = "CLIENTE";
            // 
            // lblMatriz
            // 
            this.lblMatriz.AutoSize = true;
            this.lblMatriz.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatriz.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblMatriz.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
            this.lblMatriz.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lblMatriz.Location = new System.Drawing.Point(622, 9);
            this.lblMatriz.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMatriz.Name = "lblMatriz";
            this.lblMatriz.Size = new System.Drawing.Size(60, 20);
            this.lblMatriz.TabIndex = 16;
            this.lblMatriz.Text = "Matriz: ";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.fdlvDetalle);
            this.panel3.Location = new System.Drawing.Point(33, 323);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(986, 214);
            this.panel3.TabIndex = 17;
            // 
            // fdlvDetalle
            // 
            this.fdlvDetalle.AllColumns.Add(this.olvTipoLinea);
            this.fdlvDetalle.AllColumns.Add(this.olvLinea);
            this.fdlvDetalle.AllColumns.Add(this.olvSublinea);
            this.fdlvDetalle.AllColumns.Add(this.olvDescripcion);
            this.fdlvDetalle.AllColumns.Add(this.olvCantidad);
            this.fdlvDetalle.AllColumns.Add(this.olvUnidId);
            this.fdlvDetalle.AllColumns.Add(this.olvPrecio);
            this.fdlvDetalle.AllColumns.Add(this.olvDescuento);
            this.fdlvDetalle.AllColumns.Add(this.olvDescuentoDescripcion);
            this.fdlvDetalle.AllColumns.Add(this.olvArtiId1);
            this.fdlvDetalle.AlternateRowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(219)))), ((int)(((byte)(249)))));
            this.fdlvDetalle.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvTipoLinea,
            this.olvLinea,
            this.olvSublinea,
            this.olvDescripcion,
            this.olvCantidad,
            this.olvUnidId,
            this.olvPrecio,
            this.olvDescuento,
            this.olvDescuentoDescripcion});
            this.fdlvDetalle.DataSource = null;
            this.fdlvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fdlvDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fdlvDetalle.FullRowSelect = true;
            this.fdlvDetalle.IsSimpleDragSource = true;
            this.fdlvDetalle.IsSimpleDropSink = true;
            this.fdlvDetalle.Location = new System.Drawing.Point(0, 0);
            this.fdlvDetalle.Name = "fdlvDetalle";
            this.fdlvDetalle.RowHeight = 20;
            this.fdlvDetalle.ShowGroups = false;
            this.fdlvDetalle.Size = new System.Drawing.Size(982, 210);
            this.fdlvDetalle.TabIndex = 46;
            this.fdlvDetalle.UseAlternatingBackColors = true;
            this.fdlvDetalle.UseCompatibleStateImageBehavior = false;
            this.fdlvDetalle.View = System.Windows.Forms.View.Details;
            this.fdlvDetalle.VirtualMode = true;
            this.fdlvDetalle.MouseClick += new System.Windows.Forms.MouseEventHandler(this.fdlvDetalle_MouseClick);
            this.fdlvDetalle.CanDrop += new System.EventHandler<BrightIdeasSoftware.OlvDropEventArgs>(this.fdlvDetalle_CanDrop);
            this.fdlvDetalle.Dropped += new System.EventHandler<BrightIdeasSoftware.OlvDropEventArgs>(this.fdlvDetalle_Dropped);
            // 
            // olvTipoLinea
            // 
            this.olvTipoLinea.AspectName = "LIDO_ID";
            this.olvTipoLinea.Text = "Tipo Línea";
            this.olvTipoLinea.Width = 88;
            // 
            // olvLinea
            // 
            this.olvLinea.AspectName = "PEDIDL_LINEA";
            this.olvLinea.Text = "Línea";
            this.olvLinea.Width = 55;
            // 
            // olvSublinea
            // 
            this.olvSublinea.AspectName = "PEDIDL_SUBLINEA";
            this.olvSublinea.Text = "Sublínea";
            this.olvSublinea.Width = 76;
            // 
            // olvDescripcion
            // 
            this.olvDescripcion.AspectName = "PEDIDL_DESCRIPCION";
            this.olvDescripcion.Text = "Descripción";
            this.olvDescripcion.Width = 269;
            // 
            // olvCantidad
            // 
            this.olvCantidad.AspectName = "PEDIDL_CANTIDAD";
            this.olvCantidad.Text = "Cantidad";
            // 
            // olvUnidId
            // 
            this.olvUnidId.AspectName = "UNID_ID";
            this.olvUnidId.Text = "Unidad";
            this.olvUnidId.Width = 48;
            // 
            // olvPrecio
            // 
            this.olvPrecio.AspectName = "PEDIDL_PRECIO";
            this.olvPrecio.Text = "Precio";
            this.olvPrecio.Width = 64;
            // 
            // olvDescuento
            // 
            this.olvDescuento.AspectName = "GRDE_ID";
            this.olvDescuento.Text = "DescuentoId";
            this.olvDescuento.Width = 72;
            // 
            // olvDescuentoDescripcion
            // 
            this.olvDescuentoDescripcion.AspectName = "GRDE_DESCRIPCION";
            this.olvDescuentoDescripcion.Text = "Descuento";
            this.olvDescuentoDescripcion.Width = 139;
            // 
            // olvArtiId1
            // 
            this.olvArtiId1.AspectName = "ARTI_ID1";
            this.olvArtiId1.IsVisible = false;
            this.olvArtiId1.Text = "ArtiId1";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.tlvPresupuestos);
            this.panel4.Location = new System.Drawing.Point(4, 541);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1021, 230);
            this.panel4.TabIndex = 18;
            // 
            // tlvPresupuestos
            // 
            this.tlvPresupuestos.AllColumns.Add(this.cDocuId);
            this.tlvPresupuestos.AllColumns.Add(this.cPresuvId);
            this.tlvPresupuestos.AllColumns.Add(this.cFamilDescripcion);
            this.tlvPresupuestos.AllColumns.Add(this.cTitulo);
            this.tlvPresupuestos.AllColumns.Add(this.cEstado);
            this.tlvPresupuestos.AllColumns.Add(this.cDetalleDescripcion);
            this.tlvPresupuestos.AllColumns.Add(this.cCantidad);
            this.tlvPresupuestos.AllColumns.Add(this.cUnidadId);
            this.tlvPresupuestos.AllColumns.Add(this.cPrecio);
            this.tlvPresupuestos.AllColumns.Add(this.cDescuentoDescripcion);
            this.tlvPresupuestos.AllColumns.Add(this.cReferenciaCliente);
            this.tlvPresupuestos.AllColumns.Add(this.cFechaCreacion);
            this.tlvPresupuestos.AllColumns.Add(this.cCliente);
            this.tlvPresupuestos.AllColumns.Add(this.cArtiId1);
            this.tlvPresupuestos.AllColumns.Add(this.cBloqueTipoLinea);
            this.tlvPresupuestos.AlternateRowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(219)))), ((int)(((byte)(249)))));
            this.tlvPresupuestos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cDocuId,
            this.cPresuvId,
            this.cFamilDescripcion,
            this.cTitulo,
            this.cEstado,
            this.cDetalleDescripcion,
            this.cCantidad,
            this.cUnidadId,
            this.cPrecio,
            this.cDescuentoDescripcion,
            this.cReferenciaCliente,
            this.cFechaCreacion,
            this.cCliente,
            this.cBloqueTipoLinea});
            this.tlvPresupuestos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlvPresupuestos.FullRowSelect = true;
            this.tlvPresupuestos.IsSimpleDragSource = true;
            this.tlvPresupuestos.Location = new System.Drawing.Point(0, 0);
            this.tlvPresupuestos.Name = "tlvPresupuestos";
            this.tlvPresupuestos.OwnerDraw = true;
            this.tlvPresupuestos.RowHeight = 20;
            this.tlvPresupuestos.ShowGroups = false;
            this.tlvPresupuestos.Size = new System.Drawing.Size(1017, 226);
            this.tlvPresupuestos.TabIndex = 8;
            this.tlvPresupuestos.UseAlternatingBackColors = true;
            this.tlvPresupuestos.UseCellFormatEvents = true;
            this.tlvPresupuestos.UseCompatibleStateImageBehavior = false;
            this.tlvPresupuestos.UseFiltering = true;
            this.tlvPresupuestos.View = System.Windows.Forms.View.Details;
            this.tlvPresupuestos.VirtualMode = true;
            this.tlvPresupuestos.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.tlvPresupuestos_FormatCell);
            this.tlvPresupuestos.SelectedIndexChanged += new System.EventHandler(this.tlvPresupuestos_SelectedIndexChanged);
            this.tlvPresupuestos.Click += new System.EventHandler(this.tlvPresupuestos_Click);
            // 
            // cDocuId
            // 
            this.cDocuId.AspectName = "DocuId";
            this.cDocuId.Text = "Documento";
            this.cDocuId.Width = 71;
            // 
            // cPresuvId
            // 
            this.cPresuvId.AspectName = "PresuvId";
            this.cPresuvId.Text = "Número";
            this.cPresuvId.Width = 79;
            // 
            // cFamilDescripcion
            // 
            this.cFamilDescripcion.AspectName = "FamilDescripcion";
            this.cFamilDescripcion.Text = "Familia";
            this.cFamilDescripcion.Width = 80;
            // 
            // cTitulo
            // 
            this.cTitulo.AspectName = "Titulo";
            this.cTitulo.Text = "Nombre";
            this.cTitulo.Width = 75;
            // 
            // cEstado
            // 
            this.cEstado.AspectName = "Estado";
            this.cEstado.Text = "Estado";
            this.cEstado.Width = 71;
            // 
            // cDetalleDescripcion
            // 
            this.cDetalleDescripcion.AspectName = "DetalleDescripcion";
            this.cDetalleDescripcion.Text = "Descripción";
            this.cDetalleDescripcion.Width = 103;
            // 
            // cCantidad
            // 
            this.cCantidad.AspectName = "Cantidad";
            this.cCantidad.Text = "Cantidad";
            this.cCantidad.Width = 62;
            // 
            // cUnidadId
            // 
            this.cUnidadId.AspectName = "UnidadId";
            this.cUnidadId.Text = "UnidadId";
            // 
            // cPrecio
            // 
            this.cPrecio.AspectName = "Precio";
            this.cPrecio.Text = "Precio";
            // 
            // cDescuentoDescripcion
            // 
            this.cDescuentoDescripcion.AspectName = "DescuentoDescripcion";
            this.cDescuentoDescripcion.Text = "Descuento";
            // 
            // cReferenciaCliente
            // 
            this.cReferenciaCliente.AspectName = "ReferenciaCliente";
            this.cReferenciaCliente.Text = "Referencia Cliente";
            this.cReferenciaCliente.Width = 67;
            // 
            // cFechaCreacion
            // 
            this.cFechaCreacion.AspectName = "FechaCreacion";
            this.cFechaCreacion.Text = "Fecha";
            this.cFechaCreacion.Width = 83;
            // 
            // cCliente
            // 
            this.cCliente.AspectName = "Cliente";
            this.cCliente.Text = "Cliente";
            this.cCliente.Width = 90;
            // 
            // cArtiId1
            // 
            this.cArtiId1.AspectName = "ArtiId1";
            this.cArtiId1.IsVisible = false;
            this.cArtiId1.Text = "ArtiId1";
            // 
            // cBloqueTipoLinea
            // 
            this.cBloqueTipoLinea.AspectName = "TipoLinea";
            this.cBloqueTipoLinea.Text = "TipoLinea";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(446, 25);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(35, 35);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.Transparent;
            this.btnGuardar.CausesValidation = false;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.Color.Transparent;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(500, 25);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(0);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(35, 35);
            this.btnGuardar.TabIndex = 60;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Transparent;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.Location = new System.Drawing.Point(-3, 437);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(36, 32);
            this.btnEliminar.TabIndex = 61;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // PedidovDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lblMatriz);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.MidnightBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(1, 1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PedidovDetalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Herramienta de Creación de Detalle del Pedido";
            this.Load += new System.EventHandler(this.PedidovDetalle_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.folvModelos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.folvDeterminaciones)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fdlvDetalle)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlvPresupuestos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.TextBox txtDeterminacion;
        private BrightIdeasSoftware.FastObjectListView folvModelos;
        private BrightIdeasSoftware.FastObjectListView folvDeterminaciones;
        private BrightIdeasSoftware.TreeListView tlvPresupuestos;
        private System.Windows.Forms.LinkLabel lblCliente;
        private System.Windows.Forms.LinkLabel lblMatriz;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.LinkLabel lblTipoAnalisis;
        private BrightIdeasSoftware.FastDataListView fdlvDetalle;
        private System.Windows.Forms.Button btnCancel;
        private BrightIdeasSoftware.OLVColumn olvTipoLinea;
        private BrightIdeasSoftware.OLVColumn olvLinea;
        private BrightIdeasSoftware.OLVColumn olvSublinea;
        private BrightIdeasSoftware.OLVColumn olvDescripcion;
        private BrightIdeasSoftware.OLVColumn olvCantidad;
        private BrightIdeasSoftware.OLVColumn olvUnidId;
        private BrightIdeasSoftware.OLVColumn olvPrecio;
        private BrightIdeasSoftware.OLVColumn olvDescuento;
        private BrightIdeasSoftware.OLVColumn olvDescuentoDescripcion;
        private BrightIdeasSoftware.OLVColumn olvArtiId1;
        private BrightIdeasSoftware.OLVColumn cModeloDescripcion;
        private BrightIdeasSoftware.OLVColumn cModeloArtiId1;
        private BrightIdeasSoftware.OLVColumn cEsHibrido;
        private BrightIdeasSoftware.OLVColumn cDeterminacionDescripcion;
        private BrightIdeasSoftware.OLVColumn cDeterminacionArtiId1;
        private BrightIdeasSoftware.OLVColumn cDocuId;
        private BrightIdeasSoftware.OLVColumn cPresuvId;
        private BrightIdeasSoftware.OLVColumn cFamilDescripcion;
        private BrightIdeasSoftware.OLVColumn cTitulo;
        private BrightIdeasSoftware.OLVColumn cEstado;
        private BrightIdeasSoftware.OLVColumn cDetalleDescripcion;
        private BrightIdeasSoftware.OLVColumn cCantidad;
        private BrightIdeasSoftware.OLVColumn cUnidadId;
        private BrightIdeasSoftware.OLVColumn cPrecio;
        private BrightIdeasSoftware.OLVColumn cDescuentoDescripcion;
        private BrightIdeasSoftware.OLVColumn cReferenciaCliente;
        private BrightIdeasSoftware.OLVColumn cFechaCreacion;
        private BrightIdeasSoftware.OLVColumn cCliente;
        private BrightIdeasSoftware.OLVColumn cArtiId1;
        private BrightIdeasSoftware.OLVColumn cBloqueTipoLinea;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;

    }
}