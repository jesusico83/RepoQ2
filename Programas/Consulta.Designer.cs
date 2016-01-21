namespace Programas
{
    partial class Consulta
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Consulta));
            this.fdlvConsulta = new BrightIdeasSoftware.FastDataListView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnActaVolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fdlvConsulta)).BeginInit();
            this.SuspendLayout();
            // 
            // fdlvConsulta
            // 
            this.fdlvConsulta.AlternateRowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(219)))), ((int)(((byte)(249)))));
            this.fdlvConsulta.DataSource = null;
            this.fdlvConsulta.Location = new System.Drawing.Point(12, 187);
            this.fdlvConsulta.Name = "fdlvConsulta";
            this.fdlvConsulta.RowHeight = 25;
            this.fdlvConsulta.ShowGroups = false;
            this.fdlvConsulta.Size = new System.Drawing.Size(984, 253);
            this.fdlvConsulta.TabIndex = 0;
            this.fdlvConsulta.UseCompatibleStateImageBehavior = false;
            this.fdlvConsulta.View = System.Windows.Forms.View.Details;
            this.fdlvConsulta.VirtualMode = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscar.CausesValidation = false;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.ForeColor = System.Drawing.Color.Transparent;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(379, 34);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(0);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(54, 58);
            this.btnBuscar.TabIndex = 38;
            this.btnBuscar.UseVisualStyleBackColor = false;
            // 
            // btnActaVolver
            // 
            this.btnActaVolver.CausesValidation = false;
            this.btnActaVolver.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnActaVolver.FlatAppearance.BorderSize = 0;
            this.btnActaVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActaVolver.ForeColor = System.Drawing.Color.Transparent;
            this.btnActaVolver.Image = ((System.Drawing.Image)(resources.GetObject("btnActaVolver.Image")));
            this.btnActaVolver.Location = new System.Drawing.Point(537, 40);
            this.btnActaVolver.Margin = new System.Windows.Forms.Padding(0);
            this.btnActaVolver.Name = "btnActaVolver";
            this.btnActaVolver.Size = new System.Drawing.Size(44, 52);
            this.btnActaVolver.TabIndex = 39;
            this.btnActaVolver.UseVisualStyleBackColor = false;
            // 
            // Consulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.btnActaVolver);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.fdlvConsulta);
            this.ForeColor = System.Drawing.Color.MidnightBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(1, 1);
            this.Name = "Consulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.Consulta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fdlvConsulta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.FastDataListView fdlvConsulta;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnActaVolver;

    }
}
