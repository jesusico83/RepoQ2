namespace DocumentosVentas
{
    partial class PedidosvConsulta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PedidosvConsulta));
            this.lblHASTA = new System.Windows.Forms.Label();
            this.dtpHASTA = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDESDE = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnActaVolver = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnBusqueda = new System.Windows.Forms.Button();
            this.fdlv1 = new BrightIdeasSoftware.FastDataListView();
            this.cFECHA = new BrightIdeasSoftware.OLVColumn();
            this.cPEDID_ID = new BrightIdeasSoftware.OLVColumn();
            this.cCLIE_DESCRIPCION = new BrightIdeasSoftware.OLVColumn();
            this.cESTADO = new BrightIdeasSoftware.OLVColumn();
            this.cPERS_NOMBRE = new BrightIdeasSoftware.OLVColumn();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fdlv1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHASTA
            // 
            this.lblHASTA.AutoSize = true;
            this.lblHASTA.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHASTA.Location = new System.Drawing.Point(18, 66);
            this.lblHASTA.Name = "lblHASTA";
            this.lblHASTA.Size = new System.Drawing.Size(87, 24);
            this.lblHASTA.TabIndex = 17;
            this.lblHASTA.Text = "F. Hasta";
            // 
            // dtpHASTA
            // 
            this.dtpHASTA.CalendarForeColor = System.Drawing.Color.MidnightBlue;
            this.dtpHASTA.CalendarTitleForeColor = System.Drawing.Color.MidnightBlue;
            this.dtpHASTA.Checked = false;
            this.dtpHASTA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHASTA.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHASTA.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtpHASTA.Location = new System.Drawing.Point(127, 64);
            this.dtpHASTA.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpHASTA.MinDate = new System.DateTime(1990, 1, 1, 0, 0, 0, 0);
            this.dtpHASTA.Name = "dtpHASTA";
            this.dtpHASTA.ShowUpDown = true;
            this.dtpHASTA.Size = new System.Drawing.Size(130, 26);
            this.dtpHASTA.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 24);
            this.label2.TabIndex = 15;
            this.label2.Text = "F. Desde";
            // 
            // dtpDESDE
            // 
            this.dtpDESDE.CalendarForeColor = System.Drawing.Color.MidnightBlue;
            this.dtpDESDE.CalendarTitleForeColor = System.Drawing.Color.MidnightBlue;
            this.dtpDESDE.Checked = false;
            this.dtpDESDE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDESDE.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDESDE.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtpDESDE.Location = new System.Drawing.Point(124, 27);
            this.dtpDESDE.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpDESDE.MinDate = new System.DateTime(1990, 1, 1, 0, 0, 0, 0);
            this.dtpDESDE.Name = "dtpDESDE";
            this.dtpDESDE.ShowUpDown = true;
            this.dtpDESDE.Size = new System.Drawing.Size(130, 26);
            this.dtpDESDE.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnActaVolver);
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Controls.Add(this.btnBusqueda);
            this.panel2.Controls.Add(this.lblHASTA);
            this.panel2.Controls.Add(this.dtpHASTA);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dtpDESDE);
            this.panel2.Location = new System.Drawing.Point(1, -15);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1007, 95);
            this.panel2.TabIndex = 28;
            // 
            // btnActaVolver
            // 
            this.btnActaVolver.CausesValidation = false;
            this.btnActaVolver.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnActaVolver.FlatAppearance.BorderSize = 0;
            this.btnActaVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActaVolver.ForeColor = System.Drawing.Color.Transparent;
            this.btnActaVolver.Image = ((System.Drawing.Image)(resources.GetObject("btnActaVolver.Image")));
            this.btnActaVolver.Location = new System.Drawing.Point(470, 24);
            this.btnActaVolver.Margin = new System.Windows.Forms.Padding(0);
            this.btnActaVolver.Name = "btnActaVolver";
            this.btnActaVolver.Size = new System.Drawing.Size(65, 61);
            this.btnActaVolver.TabIndex = 57;
            this.btnActaVolver.UseVisualStyleBackColor = false;
            this.btnActaVolver.Click += new System.EventHandler(this.btnActaVolver_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.CausesValidation = false;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.ForeColor = System.Drawing.Color.Transparent;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(372, 22);
            this.btnOK.Margin = new System.Windows.Forms.Padding(0);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(79, 65);
            this.btnOK.TabIndex = 56;
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.BackColor = System.Drawing.Color.Transparent;
            this.btnBusqueda.CausesValidation = false;
            this.btnBusqueda.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnBusqueda.FlatAppearance.BorderSize = 0;
            this.btnBusqueda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBusqueda.ForeColor = System.Drawing.Color.Transparent;
            this.btnBusqueda.Image = ((System.Drawing.Image)(resources.GetObject("btnBusqueda.Image")));
            this.btnBusqueda.Location = new System.Drawing.Point(276, 27);
            this.btnBusqueda.Margin = new System.Windows.Forms.Padding(0);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(54, 58);
            this.btnBusqueda.TabIndex = 38;
            this.btnBusqueda.UseVisualStyleBackColor = false;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // fdlv1
            // 
            this.fdlv1.AllColumns.Add(this.cFECHA);
            this.fdlv1.AllColumns.Add(this.cPEDID_ID);
            this.fdlv1.AllColumns.Add(this.cCLIE_DESCRIPCION);
            this.fdlv1.AllColumns.Add(this.cESTADO);
            this.fdlv1.AllColumns.Add(this.cPERS_NOMBRE);
            this.fdlv1.AlternateRowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(219)))), ((int)(((byte)(249)))));
            this.fdlv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fdlv1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cFECHA,
            this.cPEDID_ID,
            this.cCLIE_DESCRIPCION,
            this.cESTADO,
            this.cPERS_NOMBRE});
            this.fdlv1.DataSource = null;
            this.fdlv1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fdlv1.FullRowSelect = true;
            this.fdlv1.Location = new System.Drawing.Point(1, 122);
            this.fdlv1.Name = "fdlv1";
            this.fdlv1.RowHeight = 24;
            this.fdlv1.ShowGroups = false;
            this.fdlv1.Size = new System.Drawing.Size(1024, 634);
            this.fdlv1.TabIndex = 3;
            this.fdlv1.TintSortColumn = true;
            this.fdlv1.UseAlternatingBackColors = true;
            this.fdlv1.UseCellFormatEvents = true;
            this.fdlv1.UseCompatibleStateImageBehavior = false;
            this.fdlv1.UseFiltering = true;
            this.fdlv1.View = System.Windows.Forms.View.Details;
            this.fdlv1.VirtualMode = true;
            this.fdlv1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.fdlv1_ColumnClick);
            this.fdlv1.DoubleClick += new System.EventHandler(this.fdlv1_DoubleClick);
            // 
            // cFECHA
            // 
            this.cFECHA.AspectName = "PEDID_FECHA";
            this.cFECHA.Text = "Fecha";
            this.cFECHA.Width = 112;
            // 
            // cPEDID_ID
            // 
            this.cPEDID_ID.AspectName = "PEDID_ID";
            this.cPEDID_ID.Text = "Núm. Acta";
            this.cPEDID_ID.Width = 96;
            // 
            // cCLIE_DESCRIPCION
            // 
            this.cCLIE_DESCRIPCION.AspectName = "CLIE_DESCRIPCION";
            this.cCLIE_DESCRIPCION.Text = "Cliente";
            this.cCLIE_DESCRIPCION.Width = 387;
            // 
            // cESTADO
            // 
            this.cESTADO.AspectName = "ESTDOC_DESCRIPCION";
            this.cESTADO.Text = "Estado";
            this.cESTADO.Width = 166;
            // 
            // cPERS_NOMBRE
            // 
            this.cPERS_NOMBRE.AspectName = "PERS_NOMBRE";
            this.cPERS_NOMBRE.Text = "Recoge muestra";
            this.cPERS_NOMBRE.Width = 240;
            // 
            // txtFiltro
            // 
            this.txtFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltro.Location = new System.Drawing.Point(116, 88);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(215, 29);
            this.txtFiltro.TabIndex = 29;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.Color.Transparent;
            this.btnFiltrar.CausesValidation = false;
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnFiltrar.FlatAppearance.BorderSize = 0;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.ForeColor = System.Drawing.Color.Transparent;
            this.btnFiltrar.Image = ((System.Drawing.Image)(resources.GetObject("btnFiltrar.Image")));
            this.btnFiltrar.Location = new System.Drawing.Point(338, 81);
            this.btnFiltrar.Margin = new System.Windows.Forms.Padding(0);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(35, 35);
            this.btnFiltrar.TabIndex = 57;
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 24);
            this.label1.TabIndex = 58;
            this.label1.Text = "Filtro";
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Location = new System.Drawing.Point(391, 99);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(0, 13);
            this.lblFiltro.TabIndex = 59;
            // 
            // PedidosvConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.fdlv1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(1, 1);
            this.Name = "PedidosvConsulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "PedidosvConsulta";
            this.Load += new System.EventHandler(this.PedidosvConsulta_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PedidosvConsulta_FormClosing);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fdlv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BrightIdeasSoftware.FastDataListView fdlv1;
        private BrightIdeasSoftware.OLVColumn cPEDID_ID;
        private BrightIdeasSoftware.OLVColumn cFECHA;
        private BrightIdeasSoftware.OLVColumn cCLIE_DESCRIPCION;
        private System.Windows.Forms.Label lblHASTA;
        private System.Windows.Forms.DateTimePicker dtpHASTA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDESDE;
        private BrightIdeasSoftware.OLVColumn cESTADO;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnBusqueda;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnActaVolver;
        private BrightIdeasSoftware.OLVColumn cPERS_NOMBRE;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFiltro;

    }
}