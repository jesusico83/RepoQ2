using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quercus_2
{
    public class LoginControlCtx 
    {
        public LoginControlDBDataContext LoginControlDataCtx = new LoginControlDBDataContext();
        public List<USUARIOS_Q2_SEL_PWDResult> lista = new List<USUARIOS_Q2_SEL_PWDResult>();
        public USUARIOS_Q2_SEL_PWDResult usuario;
        public void SEL(string usu_id, string usu_pwd)
        {
            try
            {
                lista = LoginControlDataCtx.USUARIOS_Q2_SEL_PWD(usu_id, usu_pwd).ToList();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Fallo en la Ventana LoginControl. Detalle del error:\n" + e);                
            }
            if (lista.Count > 0)
                usuario = lista.First();
        }
    }
}
