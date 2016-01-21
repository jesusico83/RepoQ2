namespace DocumentosVentas
{
    partial class DocumentosConsulta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentosConsulta));
            this.fdlv1 = new BrightIdeasSoftware.FastDataListView();
            this.olvColumn1 = new BrightIdeasSoftware.OLVColumn();
            this.olvColumn2 = new BrightIdeasSoftware.OLVColumn();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnActaVolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fdlv1)).BeginInit();
            this.SuspendLayout();
            // 
            // fdlv1
            // 
            this.fdlv1.AllColumns.Add(this.olvColumn1);
            this.fdlv1.AllColumns.Add(this.olvColumn2);
            this.fdlv1.AllowDrop = true;
            this.fdlv1.AlternateRowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(219)))), ((int)(((byte)(249)))));
            this.fdlv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fdlv1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn2});
            this.fdlv1.DataSource = null;
            this.fdlv1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fdlv1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.fdlv1.FullRowSelect = true;
            this.fdlv1.Location = new System.Drawing.Point(0, 77);
            this.fdlv1.Name = "fdlv1";
            this.fdlv1.OwnerDraw = true;
            this.fdlv1.RowHeight = 24;
            this.fdlv1.ShowGroups = false;
            this.fdlv1.Size = new System.Drawing.Size(1024, 691);
            this.fdlv1.TabIndex = 3;
            this.fdlv1.UseAlternatingBackColors = true;
            this.fdlv1.UseCompatibleStateImageBehavior = false;
            this.fdlv1.UseFiltering = true;
            this.fdlv1.View = System.Windows.Forms.View.Details;
            this.fdlv1.VirtualMode = true;
            this.fdlv1.DoubleClick += new System.EventHandler(this.fdlv1_DoubleClick);
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "DOCU_ID";
            this.olvColumn1.Text = "Documento";
            this.olvColumn1.Width = 150;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "DOCU_DESCRIPCION";
            this.olvColumn2.Text = "Descripción";
            this.olvColumn2.Width = 360;
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
            this.btnOK.Location = new System.Drawing.Point(355, 9);
            this.btnOK.Margin = new System.Windows.Forms.Padding(0);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(79, 65);
            this.btnOK.TabIndex = 45;
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnActaVolver
            // 
            this.btnActaVolver.CausesValidation = false;
            this.btnActaVolver.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnActaVolver.FlatAppearance.BorderSize = 0;
            this.btnActaVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActaVolver.ForeColor = System.Drawing.Color.Transparent;
            this.btnActaVolver.Image = ((System.Drawing.Image)(resources.GetObject("btnActaVolver.Image")));
            this.btnActaVolver.Location = new System.Drawing.Point(463, 9);
            this.btnActaVolver.Margin = new System.Windows.Forms.Padding(0);
            this.btnActaVolver.Name = "btnActaVolver";
            this.btnActaVolver.Size = new System.Drawing.Size(65, 61);
            this.btnActaVolver.TabIndex = 44;
            this.btnActaVolver.UseVisualStyleBackColor = false;
            this.btnActaVolver.Click += new System.EventHandler(this.btnActaVolver_Click);
            // 
            // DocumentosConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnActaVolver);
            this.Controls.Add(this.fdlv1);
            this.ForeColor = System.Drawing.Color.MidnightBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(1, 1);
            this.Name = "DocumentosConsulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Consulta de documentos";
            this.Load += new System.EventHandler(this.PedidosvConsulta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fdlv1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.FastDataListView fdlv1;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnActaVolver;

    }
}