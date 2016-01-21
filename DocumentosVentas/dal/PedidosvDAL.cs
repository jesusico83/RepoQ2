using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Configuration;

namespace DocumentosVentas.dal
{
    public class PedidosvDAL
    {

        public static int GetComportamientoIVACliente(int clieId)
        {
            int compId = 0;
            
            // LINQ to SQL directo con SPR

            return compId;
        }

        // Devuelve las lineas (detalle) de un bloque
        public static DataTable GetDetalleByPedido2(string docuId, string numero)
        {
            DataTable datos = new DataTable("PEDIDOSV_LI");

            using (SqlConnection cn = new SqlConnection(@"Data Source=INFORMATICA02\SQLSRV2008;Initial Catalog=local;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand(
                    @"SELECT A.*, B.UNID_DESCRIPCION,  C.GRDE_DESCRIPCION, ISNULL(M.DEPA_ID, ISNULL(D.DEPA_ID,0)) DEPA_ID
                    FROM PEDIDOSV_LI A
                    INNER JOIN ARTICULOS AR ON AR.ARTI_ID1 = A.ARTI_ID1
LEFT OUTER JOIN MODELOS M ON M.ARTI_ID = AR.ARTI_ID
LEFT OUTER JOIN DETERMINACION_TIAN DT ON DT.ARTI_ID = AR.ARTI_ID
LEFT OUTER JOIN DETERMINACIONES D ON D.DETE_ID = DT.DETE_ID
                    INNER JOIN UNIDADES B ON B.UNID_ID = A.UNID_ID
                    LEFT OUTER JOIN GRUPOS_DESCUENTOS C ON C.GRDE_ID = A.GRDE_ID
WHERE A.DOCU_ID = @DOCU_ID AND A.PEDID_ID = @PEDID_ID  ", cn);

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@DOCU_ID", docuId);
                cmd.Parameters.AddWithValue("@PEDID_ID", numero);

                cn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(datos);

                
                cn.Close();

            }


            return datos;
        }
    }
}
