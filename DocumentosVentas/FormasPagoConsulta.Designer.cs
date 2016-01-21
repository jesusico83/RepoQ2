namespace DocumentosVentas
{
    partial class FormasPagoConsulta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormasPagoConsulta));
            this.fdlv1 = new BrightIdeasSoftware.FastDataListView();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnActaVolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fdlv1)).BeginInit();
            this.SuspendLayout();
            // 
            // fdlv1
            // 
            this.fdlv1.AllowDrop = true;
            this.fdlv1.AlternateRowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(219)))), ((int)(((byte)(249)))));
            this.fdlv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fdlv1.DataSource = null;
            this.fdlv1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fdlv1.FullRowSelect = true;
            this.fdlv1.Location = new System.Drawing.Point(0, 83);
            this.fdlv1.Name = "fdlv1";
            this.fdlv1.OwnerDraw = true;
            this.fdlv1.RowHeight = 20;
            this.fdlv1.ShowGroups = false;
            this.fdlv1.Size = new System.Drawing.Size(1024, 685);
            this.fdlv1.TabIndex = 7;
            this.fdlv1.UseAlternatingBackColors = true;
            this.fdlv1.UseCompatibleStateImageBehavior = false;
            this.fdlv1.UseFiltering = true;
            this.fdlv1.View = System.Windows.Forms.View.Details;
            this.fdlv1.VirtualMode = true;
            this.fdlv1.DoubleClick += new System.EventHandler(this.fdlv1_DoubleClick);
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
            this.btnOK.Location = new System.Drawing.Point(376, 9);
            this.btnOK.Margin = new System.Windows.Forms.Padding(0);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(79, 65);
            this.btnOK.TabIndex = 49;
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
            this.btnActaVolver.Location = new System.Drawing.Point(484, 9);
            this.btnActaVolver.Margin = new System.Windows.Forms.Padding(0);
            this.btnActaVolver.Name = "btnActaVolver";
            this.btnActaVolver.Size = new System.Drawing.Size(65, 61);
            this.btnActaVolver.TabIndex = 48;
            this.btnActaVolver.UseVisualStyleBackColor = false;
            this.btnActaVolver.Click += new System.EventHandler(this.btnActaVolver_Click);
            // 
            // FormasPagoConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnActaVolver);
            this.Controls.Add(this.fdlv1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(1, 1);
            this.Name = "FormasPagoConsulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FormasPago";
            this.Load += new System.EventHandler(this.FormasPagoConsulta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fdlv1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.FastDataListView fdlv1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnActaVolver;
    }
}