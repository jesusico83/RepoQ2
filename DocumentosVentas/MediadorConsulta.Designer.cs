namespace DocumentosVentas
{
    partial class MediadorConsulta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MediadorConsulta));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnActaVolver = new System.Windows.Forms.Button();
            this.txtDESCRIPCION = new System.Windows.Forms.TextBox();
            this.btnClientesCon = new System.Windows.Forms.Button();
            this.lblCliente = new System.Windows.Forms.Label();
            this.fdlv1 = new BrightIdeasSoftware.FastDataListView();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fdlv1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Controls.Add(this.btnActaVolver);
            this.panel2.Controls.Add(this.txtDESCRIPCION);
            this.panel2.Controls.Add(this.btnClientesCon);
            this.panel2.Controls.Add(this.lblCliente);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1024, 77);
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
            this.btnOK.Location = new System.Drawing.Point(465, 6);
            this.btnOK.Margin = new System.Windows.Forms.Padding(0);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(79, 65);
            this.btnOK.TabIndex = 53;
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
            this.btnActaVolver.Location = new System.Drawing.Point(561, 12);
            this.btnActaVolver.Margin = new System.Windows.Forms.Padding(0);
            this.btnActaVolver.Name = "btnActaVolver";
            this.btnActaVolver.Size = new System.Drawing.Size(44, 52);
            this.btnActaVolver.TabIndex = 38;
            this.btnActaVolver.UseVisualStyleBackColor = false;
            this.btnActaVolver.Click += new System.EventHandler(this.btnActaVolver_Click);
            // 
            // txtDESCRIPCION
            // 
            this.txtDESCRIPCION.Location = new System.Drawing.Point(81, 29);
            this.txtDESCRIPCION.Name = "txtDESCRIPCION";
            this.txtDESCRIPCION.Size = new System.Drawing.Size(100, 20);
            this.txtDESCRIPCION.TabIndex = 6;
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
            this.btnClientesCon.Location = new System.Drawing.Point(211, 9);
            this.btnClientesCon.Margin = new System.Windows.Forms.Padding(0);
            this.btnClientesCon.Name = "btnClientesCon";
            this.btnClientesCon.Size = new System.Drawing.Size(54, 58);
            this.btnClientesCon.TabIndex = 37;
            this.btnClientesCon.UseVisualStyleBackColor = false;
            this.btnClientesCon.Click += new System.EventHandler(this.btnClientesCon_Click);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(10, 32);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(39, 13);
            this.lblCliente.TabIndex = 7;
            this.lblCliente.Text = "Cliente";
            // 
            // fdlv1
            // 
            this.fdlv1.AlternateRowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(219)))), ((int)(((byte)(249)))));
            this.fdlv1.DataSource = null;
            this.fdlv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fdlv1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fdlv1.FullRowSelect = true;
            this.fdlv1.Location = new System.Drawing.Point(0, 77);
            this.fdlv1.Name = "fdlv1";
            this.fdlv1.RowHeight = 24;
            this.fdlv1.ShowGroups = false;
            this.fdlv1.Size = new System.Drawing.Size(1024, 691);
            this.fdlv1.TabIndex = 43;
            this.fdlv1.UseAlternatingBackColors = true;
            this.fdlv1.UseCompatibleStateImageBehavior = false;
            this.fdlv1.UseFiltering = true;
            this.fdlv1.View = System.Windows.Forms.View.Details;
            this.fdlv1.VirtualMode = true;
            this.fdlv1.DoubleClick += new System.EventHandler(this.fdlv1_DoubleClick);
            // 
            // MediadorConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.fdlv1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(1, 1);
            this.Name = "MediadorConsulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Consulta de Mediador";
            this.Load += new System.EventHandler(this.ClientesConsult_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fdlv1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnActaVolver;
        private System.Windows.Forms.TextBox txtDESCRIPCION;
        private System.Windows.Forms.Button btnClientesCon;
        private System.Windows.Forms.Label lblCliente;
        private BrightIdeasSoftware.FastDataListView fdlv1;
        private System.Windows.Forms.Button btnOK;
    }
}