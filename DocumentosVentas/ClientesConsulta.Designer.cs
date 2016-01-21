namespace DocumentosVentas
{
    partial class ClientesConsulta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientesConsulta));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.xbComercial = new System.Windows.Forms.CheckBox();
            this.lblUSU_ID = new System.Windows.Forms.Label();
            this.btnActaVolver = new System.Windows.Forms.Button();
            this.txtCLIE_DESCRIPCION = new System.Windows.Forms.TextBox();
            this.btnClientesCon = new System.Windows.Forms.Button();
            this.lblCliente = new System.Windows.Forms.Label();
            this.fdlv1 = new BrightIdeasSoftware.FastDataListView();
            this.cCLIE_ID = new BrightIdeasSoftware.OLVColumn();
            this.cCLIE_DESCRIPCION = new BrightIdeasSoftware.OLVColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fdlv1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Controls.Add(this.xbComercial);
            this.panel2.Controls.Add(this.lblUSU_ID);
            this.panel2.Controls.Add(this.btnActaVolver);
            this.panel2.Controls.Add(this.txtCLIE_DESCRIPCION);
            this.panel2.Controls.Add(this.btnClientesCon);
            this.panel2.Controls.Add(this.lblCliente);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1024, 142);
            this.panel2.TabIndex = 42;
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
            this.btnOK.Location = new System.Drawing.Point(395, 56);
            this.btnOK.Margin = new System.Windows.Forms.Padding(0);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(79, 65);
            this.btnOK.TabIndex = 43;
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // xbComercial
            // 
            this.xbComercial.AutoSize = true;
            this.xbComercial.Location = new System.Drawing.Point(368, 15);
            this.xbComercial.Margin = new System.Windows.Forms.Padding(6);
            this.xbComercial.Name = "xbComercial";
            this.xbComercial.Size = new System.Drawing.Size(247, 28);
            this.xbComercial.TabIndex = 42;
            this.xbComercial.Text = "Sólo clientes asignados a ";
            this.xbComercial.UseVisualStyleBackColor = true;
            this.xbComercial.CheckedChanged += new System.EventHandler(this.xbComercial_CheckedChanged);
            // 
            // lblUSU_ID
            // 
            this.lblUSU_ID.AutoSize = true;
            this.lblUSU_ID.Location = new System.Drawing.Point(627, 19);
            this.lblUSU_ID.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblUSU_ID.Name = "lblUSU_ID";
            this.lblUSU_ID.Size = new System.Drawing.Size(94, 24);
            this.lblUSU_ID.TabIndex = 41;
            this.lblUSU_ID.Text = "lblUSU_ID";
            // 
            // btnActaVolver
            // 
            this.btnActaVolver.CausesValidation = false;
            this.btnActaVolver.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnActaVolver.FlatAppearance.BorderSize = 0;
            this.btnActaVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActaVolver.ForeColor = System.Drawing.Color.Transparent;
            this.btnActaVolver.Image = ((System.Drawing.Image)(resources.GetObject("btnActaVolver.Image")));
            this.btnActaVolver.Location = new System.Drawing.Point(711, 40);
            this.btnActaVolver.Margin = new System.Windows.Forms.Padding(0);
            this.btnActaVolver.Name = "btnActaVolver";
            this.btnActaVolver.Size = new System.Drawing.Size(81, 96);
            this.btnActaVolver.TabIndex = 38;
            this.btnActaVolver.UseVisualStyleBackColor = false;
            this.btnActaVolver.Click += new System.EventHandler(this.btnActaVolver_Click);
            // 
            // txtCLIE_DESCRIPCION
            // 
            this.txtCLIE_DESCRIPCION.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCLIE_DESCRIPCION.Location = new System.Drawing.Point(149, 13);
            this.txtCLIE_DESCRIPCION.Margin = new System.Windows.Forms.Padding(6);
            this.txtCLIE_DESCRIPCION.Name = "txtCLIE_DESCRIPCION";
            this.txtCLIE_DESCRIPCION.Size = new System.Drawing.Size(180, 29);
            this.txtCLIE_DESCRIPCION.TabIndex = 6;
            this.txtCLIE_DESCRIPCION.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCLIE_DESCRIPCION_KeyDown);
            // 
            // btnClientesCon
            // 
            this.btnClientesCon.BackColor = System.Drawing.Color.Transparent;
            this.btnClientesCon.CausesValidation = false;
            this.btnClientesCon.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnClientesCon.FlatAppearance.BorderSize = 0;
            this.btnClientesCon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientesCon.ForeColor = System.Drawing.Color.Transparent;
            this.btnClientesCon.Image = ((System.Drawing.Image)(resources.GetObject("btnClientesCon.Image")));
            this.btnClientesCon.Location = new System.Drawing.Point(264, 56);
            this.btnClientesCon.Margin = new System.Windows.Forms.Padding(0);
            this.btnClientesCon.Name = "btnClientesCon";
            this.btnClientesCon.Size = new System.Drawing.Size(74, 64);
            this.btnClientesCon.TabIndex = 37;
            this.btnClientesCon.UseVisualStyleBackColor = false;
            this.btnClientesCon.Click += new System.EventHandler(this.btnClientesCon_Click);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(18, 18);
            this.lblCliente.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(110, 24);
            this.lblCliente.TabIndex = 7;
            this.lblCliente.Text = "Descripción";
            // 
            // fdlv1
            // 
            this.fdlv1.AllColumns.Add(this.cCLIE_ID);
            this.fdlv1.AllColumns.Add(this.cCLIE_DESCRIPCION);
            this.fdlv1.AlternateRowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(219)))), ((int)(((byte)(249)))));
            this.fdlv1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cCLIE_ID,
            this.cCLIE_DESCRIPCION});
            this.fdlv1.DataSource = null;
            this.fdlv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fdlv1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fdlv1.FullRowSelect = true;
            this.fdlv1.Location = new System.Drawing.Point(0, 142);
            this.fdlv1.Margin = new System.Windows.Forms.Padding(6);
            this.fdlv1.MultiSelect = false;
            this.fdlv1.Name = "fdlv1";
            this.fdlv1.RowHeight = 24;
            this.fdlv1.ShowGroups = false;
            this.fdlv1.Size = new System.Drawing.Size(1024, 626);
            this.fdlv1.TabIndex = 43;
            this.fdlv1.UseAlternatingBackColors = true;
            this.fdlv1.UseCompatibleStateImageBehavior = false;
            this.fdlv1.UseFiltering = true;
            this.fdlv1.View = System.Windows.Forms.View.Details;
            this.fdlv1.VirtualMode = true;
            this.fdlv1.DoubleClick += new System.EventHandler(this.fdlv1_DoubleClick);
            // 
            // cCLIE_ID
            // 
            this.cCLIE_ID.AspectName = "CLIE_ID";
            this.cCLIE_ID.Text = "Código";
            this.cCLIE_ID.Width = 159;
            // 
            // cCLIE_DESCRIPCION
            // 
            this.cCLIE_DESCRIPCION.AspectName = "CLIE_DESCRIPCION";
            this.cCLIE_DESCRIPCION.Text = "Cliente";
            this.cCLIE_DESCRIPCION.Width = 839;
            // 
            // ClientesConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.fdlv1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.MidnightBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(1, 1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ClientesConsulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Clientes Consulta";
            this.Load += new System.EventHandler(this.ClientesConsult_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientesConsult_FormClosing);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fdlv1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox xbComercial;
        private System.Windows.Forms.Label lblUSU_ID;
        private System.Windows.Forms.Button btnActaVolver;
        private System.Windows.Forms.TextBox txtCLIE_DESCRIPCION;
        private System.Windows.Forms.Button btnClientesCon;
        private System.Windows.Forms.Label lblCliente;
        private BrightIdeasSoftware.FastDataListView fdlv1;
        private BrightIdeasSoftware.OLVColumn cCLIE_ID;
        private BrightIdeasSoftware.OLVColumn cCLIE_DESCRIPCION;
        private System.Windows.Forms.Button btnOK;
    }
}