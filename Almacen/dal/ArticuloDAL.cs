using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Almacen.dal
{
    public class ArticuloDAL
    {
//        public static List<odts.ArticuloModelo> GetArticulosModeloByTipoAnalisis(string tipoAnalisis)
//        {
//            List<odts.ArticuloModelo> lista = new List<odts.ArticuloModelo>();

//            using (SqlConnection cn = new SqlConnection(Tipos.Configuracion.Conexion))
//            {
//                SqlCommand cmd = new SqlCommand(
//                    @"SELECT A.ARTI_ID, C.ARTI_DESCRIPCION, C.ARTI_ID1, CONVERT(BIT,0) ES_HIBRIDO, C.ARTI_DETERMINACIONES, C.ARTI_PNT_METODOLOGIA, A.DEPA_ID
//FROM MODELOS A
//INNER JOIN MODELOS_LI B ON B.MODE_ID = A.MODE_ID
//INNER JOIN ARTICULOS C ON C.ARTI_ID = A.ARTI_ID
//INNER JOIN FAMILIAS D ON D.TIPANA_ID = B.TIPANA_ID
//WHERE C.TIPAR_ID = 'AN' AND (@TIPANA_ID = '' OR D.TIPANA_ID = @TIPANA_ID) AND (C.ARTI_FECHABAJA = '' OR C.ARTI_FECHABAJA > @HOY)
//UNION ALL
//SELECT A.ARTI_ID, B.ARTI_DESCRIPCION, B.ARTI_ID1, CONVERT(BIT,1), B.ARTI_DETERMINACIONES, B.ARTI_PNT_METODOLOGIA, 0 DEPA_ID
//FROM MODELO_HIBRIDO A
//INNER JOIN ARTICULOS B ON B.ARTI_ID = A.ARTI_ID
//INNER JOIN FAMILIAS C ON C.TIPANA_ID = A.TIPANA_ID
//WHERE B.TIPAR_ID = 'AN' AND (@TIPANA_ID = '' OR C.TIPANA_ID = @TIPANA_ID) AND (B.ARTI_FECHABAJA = '' OR B.ARTI_FECHABAJA > @HOY)
//ORDER BY ARTI_DESCRIPCION ", cn);

//                cmd.CommandType = System.Data.CommandType.Text;
//                cmd.Parameters.AddWithValue("@TIPANA_ID", tipoAnalisis);
//                cmd.Parameters.AddWithValue("@HOY", DateTime.Now.ToString("yyyy-MM-dd"));

//                cn.Open();

//                SqlDataReader reader = cmd.ExecuteReader();

//                if (reader.HasRows)
//                {
//                    while (reader.Read())
//                    {
//                        odts.ArticuloModelo m = new odts.ArticuloModelo();
//                        m.ArtiId = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader["ARTI_ID"]);
//                        m.Descripcion = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader["ARTI_DESCRIPCION"]);
//                        m.ArtiId1 = Utilidades.UtilsBD.DBValueToRequiredValue<int>(reader["ARTI_ID1"]);
//                        m.EsHibrido = Utilidades.UtilsBD.DBValueToRequiredValue<bool>(reader["ES_HIBRIDO"]);
//                        m.ArtiDeterminaciones = Utilidades.UtilsBD.DBValueToOptionalString(reader["ARTI_DETERMINACIONES"]);
//                        m.ArtiMetodologia = Utilidades.UtilsBD.DBValueToOptionalString(reader["ARTI_PNT_METODOLOGIA"]);
//                        m.DepartamentoId = Utilidades.UtilsBD.DBValueToRequiredValue<int>(reader["DEPA_ID"]);

//                        if (!lista.Contains(m))
//                            lista.Add(m);
//                    }
//                }
//                cn.Close();
//            }

//            return lista;
//        }
    }
}
