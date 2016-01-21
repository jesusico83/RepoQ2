using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Quercus2
{
    public partial class LoginControl : Form
    {
        public LoginControl()
        {
            InitializeComponent();
        }
        // Contexto para consultas en BBDD
        private Quercus_2.LoginControlCtx ctx = new Quercus_2.LoginControlCtx();

        // Variables públicas de aplicación que se pasarán a la ventana llamante
        public string _USU_ID;
        public int _USU_ID1;
        public string _PESE_ID;
        public string _USU_DESCRIPCION;              

        // Variables privadas a usar por los métodos de validación/rechazo de usuario
        private int fallos = 0;
        private bool ok = false;
        private string Usuario, Contraseña;
        private int Usuario_Id;
        private string Usuario_Descripcion;
        private string Pese_Id;

        private string CalcularPwd(string Pwd)
        {
            if (Pwd.Length > 0)
            {
                System.Text.UnicodeEncoding End = new UnicodeEncoding();
                byte[] by = End.GetBytes(Pwd);
                SHA1CryptoServiceProvider prv = new SHA1CryptoServiceProvider();
                byte[] c = prv.ComputeHash(by);
                return (Convert.ToBase64String(c));
            }
            return "";
        }

        private void ValidarUsuario()
        {
            if (fallos <= 3)
            {
                this.lblInicio.Text = "Iniciar  sesión  en  Quercus";
                this.lblInicio.ForeColor = Color.Black;
                this.lblInicio.BackColor = Color.LightSteelBlue;
                if (this.txtUSU_ID.Text == string.Empty || this.txtUSU_PWD.Text == string.Empty)
                {
                    this.lblInicio.ForeColor = Color.White;
                    this.lblInicio.Text = "Escriba usuario y contraseña";
                    this.lblInicio.BackColor = Color.Red;
                }
                else
                {
                    Usuario = this.txtUSU_ID.Text;
                    Contraseña = this.txtUSU_PWD.Text;
                    ctx.SEL(Usuario, CalcularPwd(Contraseña));
                    if (ctx.lista.Count > 0)
                    {
                        Usuario = ctx.usuario.USU_ID;
                        Usuario_Id = ctx.usuario.USU_ID1;
                        Usuario_Descripcion = ctx.usuario.USU_DESCRIPCION;
                        Pese_Id = ctx.usuario.PESE_ID;
                        ok = true;
                    }
                    if (ok)
                    {
                        _USU_ID = Usuario;
                        _USU_ID1 = Usuario_Id;
                        _USU_DESCRIPCION = Usuario_Descripcion;
                        _PESE_ID = Pese_Id;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        this.fallos++;
                        this.lblInicio.ForeColor = Color.White;
                        this.lblInicio.Text = "Login Incorrecto";
                        this.lblInicio.BackColor = Color.Red;
                    }
                    if (fallos == 3)
                    {
                        ok = false;
                        MessageBox.Show("LOGIN INCORRECTO");
                        salir();
                    }
                }
            }
        }
          


        // Eventos y acciones del usuario
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }
        public static void salir()
        {
            Application.Exit();
        }

        private void lblSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void lblValidar_Click(object sender, EventArgs e)
        {
            ValidarUsuario();
        }

        private void txtPasswd_Leave(object sender, EventArgs e)
        {
            ValidarUsuario();
        }
    }
}
