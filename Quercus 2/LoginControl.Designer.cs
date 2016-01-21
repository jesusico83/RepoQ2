namespace Quercus2
{
    partial class LoginControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginControl));
            this.pnAcceso = new System.Windows.Forms.Panel();
            this.lblSalir = new System.Windows.Forms.Label();
            this.lblValidar = new System.Windows.Forms.Label();
            this.lblInicio = new System.Windows.Forms.Label();
            this.lblPasswd = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblUsuImg = new System.Windows.Forms.Label();
            this.lblLoginTitulo = new System.Windows.Forms.Label();
            this.txtUSU_PWD = new System.Windows.Forms.TextBox();
            this.txtUSU_ID = new System.Windows.Forms.TextBox();
            this.pnAcceso.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnAcceso
            // 
            this.pnAcceso.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pnAcceso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnAcceso.Controls.Add(this.lblSalir);
            this.pnAcceso.Controls.Add(this.lblValidar);
            this.pnAcceso.Controls.Add(this.lblInicio);
            this.pnAcceso.Controls.Add(this.lblPasswd);
            this.pnAcceso.Controls.Add(this.lblUsuario);
            this.pnAcceso.Controls.Add(this.lblUsuImg);
            this.pnAcceso.Controls.Add(this.lblLoginTitulo);
            this.pnAcceso.Controls.Add(this.txtUSU_PWD);
            this.pnAcceso.Controls.Add(this.txtUSU_ID);
            this.pnAcceso.Location = new System.Drawing.Point(208, 71);
            this.pnAcceso.Name = "pnAcceso";
            this.pnAcceso.Padding = new System.Windows.Forms.Padding(3);
            this.pnAcceso.Size = new System.Drawing.Size(596, 327);
            this.pnAcceso.TabIndex = 1;
            // 
            // lblSalir
            // 
            this.lblSalir.AutoSize = true;
            this.lblSalir.Image = ((System.Drawing.Image)(resources.GetObject("lblSalir.Image")));
            this.lblSalir.Location = new System.Drawing.Point(528, 238);
            this.lblSalir.Name = "lblSalir";
            this.lblSalir.Padding = new System.Windows.Forms.Padding(30);
            this.lblSalir.Size = new System.Drawing.Size(60, 73);
            this.lblSalir.TabIndex = 10;
            this.lblSalir.Click += new System.EventHandler(this.lblSalir_Click);
            // 
            // lblValidar
            // 
            this.lblValidar.AutoSize = true;
            this.lblValidar.Image = ((System.Drawing.Image)(resources.GetObject("lblValidar.Image")));
            this.lblValidar.Location = new System.Drawing.Point(279, 238);
            this.lblValidar.Name = "lblValidar";
            this.lblValidar.Padding = new System.Windows.Forms.Padding(30);
            this.lblValidar.Size = new System.Drawing.Size(60, 73);
            this.lblValidar.TabIndex = 8;
            this.lblValidar.Click += new System.EventHandler(this.lblValidar_Click);
            // 
            // lblInicio
            // 
            this.lblInicio.AutoSize = true;
            this.lblInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInicio.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblInicio.Location = new System.Drawing.Point(280, 186);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Size = new System.Drawing.Size(242, 24);
            this.lblInicio.TabIndex = 7;
            this.lblInicio.Text = "Iniciar  Sesión  en  Quercus";
            // 
            // lblPasswd
            // 
            this.lblPasswd.AutoSize = true;
            this.lblPasswd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswd.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblPasswd.Location = new System.Drawing.Point(153, 135);
            this.lblPasswd.Name = "lblPasswd";
            this.lblPasswd.Size = new System.Drawing.Size(123, 25);
            this.lblPasswd.TabIndex = 6;
            this.lblPasswd.Text = "Contraseña";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblUsuario.Location = new System.Drawing.Point(190, 55);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(86, 25);
            this.lblUsuario.TabIndex = 5;
            this.lblUsuario.Text = "Usuario";
            // 
            // lblUsuImg
            // 
            this.lblUsuImg.Image = ((System.Drawing.Image)(resources.GetObject("lblUsuImg.Image")));
            this.lblUsuImg.Location = new System.Drawing.Point(10, 44);
            this.lblUsuImg.Name = "lblUsuImg";
            this.lblUsuImg.Padding = new System.Windows.Forms.Padding(50);
            this.lblUsuImg.Size = new System.Drawing.Size(144, 142);
            this.lblUsuImg.TabIndex = 4;
            // 
            // lblLoginTitulo
            // 
            this.lblLoginTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(219)))), ((int)(((byte)(249)))));
            this.lblLoginTitulo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLoginTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLoginTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginTitulo.Location = new System.Drawing.Point(3, 3);
            this.lblLoginTitulo.Name = "lblLoginTitulo";
            this.lblLoginTitulo.Size = new System.Drawing.Size(588, 22);
            this.lblLoginTitulo.TabIndex = 3;
            this.lblLoginTitulo.Text = "QUERCUS 2 - ACCESO USUARIO";
            this.lblLoginTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtUSU_PWD
            // 
            this.txtUSU_PWD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUSU_PWD.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUSU_PWD.Location = new System.Drawing.Point(282, 124);
            this.txtUSU_PWD.MaxLength = 15;
            this.txtUSU_PWD.Name = "txtUSU_PWD";
            this.txtUSU_PWD.Size = new System.Drawing.Size(307, 44);
            this.txtUSU_PWD.TabIndex = 2;
            this.txtUSU_PWD.Text = "MATEO";
            this.txtUSU_PWD.UseSystemPasswordChar = true;
            this.txtUSU_PWD.Leave += new System.EventHandler(this.txtPasswd_Leave);
            // 
            // txtUSU_ID
            // 
            this.txtUSU_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUSU_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUSU_ID.Location = new System.Drawing.Point(282, 44);
            this.txtUSU_ID.MaxLength = 15;
            this.txtUSU_ID.Name = "txtUSU_ID";
            this.txtUSU_ID.Size = new System.Drawing.Size(307, 44);
            this.txtUSU_ID.TabIndex = 1;
            this.txtUSU_ID.Text = "MATEO";
            // 
            // LoginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.ControlBox = false;
            this.Controls.Add(this.pnAcceso);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(1, 1);
            this.MaximizeBox = false;
            this.Name = "LoginControl";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Quercus 2 Login";
            this.pnAcceso.ResumeLayout(false);
            this.pnAcceso.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnAcceso;
        private System.Windows.Forms.Label lblSalir;
        private System.Windows.Forms.Label lblValidar;
        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.Label lblPasswd;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblUsuImg;
        private System.Windows.Forms.Label lblLoginTitulo;
        private System.Windows.Forms.TextBox txtUSU_PWD;
        private System.Windows.Forms.TextBox txtUSU_ID;
    }
}