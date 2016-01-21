using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Collections.ObjectModel;
using System.Configuration;

namespace DocumentosVentas.dal
{
    public class PresupuestoVentaDAL
    {
        public static string _USU_ID;
        // Devuelve los bloques de un presupuesto
        public static List<odts.PresupuestoVentaBloque> GetBloquesByPresupuesto(string docuId, string presuvId)
        {
            List<odts.PresupuestoVentaBloque> lista = new List<odts.PresupuestoVentaBloque>();

            using (SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["conexionQ"]))
            {
                SqlCommand cmd = new SqlCommand(
                    @"SELECT A.DOCU_ID, A.PRESUV_ID, A.ESTDOC_ID, A.BLOQUE_ID, A.FAMIL_ID, B.FAMIL_DESCRIPCION, A.TITULO, A.REFERENCIA_CLIENTE, A.FECHA_CREACION
                        FROM PRESUPUESTOV_BLOQUE A 
                        LEFT OUTER JOIN FAMILIAS B ON B.FAMIL_ID = A.FAMIL_ID
                        WHERE A.DOCU_ID = @DOCU_ID AND A.PRESUV_ID = @PRESUV_ID ", cn);

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@DOCU_ID", docuId);
                cmd.Parameters.AddWithValue("@PRESUV_ID", presuvId);

                cn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        odts.PresupuestoVentaBloque p = new odts.PresupuestoVentaBloque();
                        p.DocuId = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader[0]);
                        p.PresuvId = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader[1]);
                        p.Estado = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader[2]);
                        p.BloqueId = Utilidades.UtilsBD.DBValueToRequiredValue<int>(reader[3]);
                        p.FamilId = Utilidades.UtilsBD.DBValueToOptionalString(reader[4]);
                        p.FamilDescripcion = Utilidades.UtilsBD.DBValueToOptionalString(reader[5]);
                        p.Titulo = Utilidades.UtilsBD.DBValueToOptionalString(reader[6]);
                        p.ReferenciaCliente = Utilidades.UtilsBD.DBValueToOptionalString(reader[7]);
                        p.FechaCreacion = Utilidades.UtilsBD.DBValueToRequiredFecha(reader[8]);

                        lista.Add(p);

                    }
                }
                cn.Close();

            }


            return lista;
        }

        // Devuelve los presupuestos de un cliente entre 2 fechas
        public static List<odts.PresupuestoVenta> GetPresupuestosPorClienteYFechas(int clieId, string fechaDesde, string fechaHasta)
        {
            List<odts.PresupuestoVenta> lista =  new List<odts.PresupuestoVenta>();

            using (SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["conexionQ"]))
            {
                SqlCommand cmd = new SqlCommand(
                    @"SELECT 
       A.DOCU_ID,
       A.PRESUV_ID,
       ED.ESTDOC_DESCRIPCION,
       A.CLIE_ID,
       A.ESTDOC_ID,
       A.PRESUV_FECHA,
       A.PRESUV_FECHAV,
       A.PRESUV_SUREFERENCIA,
       B.PERS_NOMBRE,
       P.PERS_NOMBRE GESTOR_NOMBRE,
       E.CLIE_DESCRIPCION,
       ISNULL(F.NUMERO_ADJUNTOS,0) NUMERO_ADJUNTOS,
       SUM((ISNULL(PL.PRESUVL_PRECIO,0)* ISNULL(PL.PRESUVL_CANTIDAD,0)) * ((100 - ISNULL(GDL.GRDEL_VALOR,0))/ 100)) BASE
       ,A.PRESUV_FECHAMAXIMA
       ,A.POTENCIAL
  FROM PRESUPUESTOSV A
    INNER JOIN ESTADO_DOCUMENTOS ED ON ED.ESTDOC_ID = A.ESTDOC_ID
  LEFT OUTER JOIN PRESUPUESTOSV_LI PL ON PL.DOCU_ID = A.DOCU_ID AND PL.PRESUV_ID = A.PRESUV_ID
  LEFT OUTER JOIN GRUPOS_DESC_LINEAS GDL ON GDL.GRDE_ID = PL.GRDE_ID
       LEFT OUTER JOIN PERSONAL B ON  B.PERS_ID = A.PERS_ID
       LEFT OUTER JOIN CLIENTES E ON E.CLIE_ID = A.CLIE_ID
       LEFT OUTER JOIN FICHEROS_ADJUNTOS F ON F.DOCU_ID = A.DOCU_ID AND F.DOCU_NUMERO = A.PRESUV_ID
       INNER JOIN PERSONAL P ON P.PERS_ID = A.GESTOR_ID
WHERE 
      (@CLIE_ID = 0 OR A.CLIE_ID = @CLIE_ID) AND
      (@FECHAD = '' OR @FECHAD <= A.PRESUV_FECHA) AND
      (@FECHAH = '' OR @FECHAH >= A.PRESUV_FECHA)
GROUP BY A.DOCU_ID,
       A.PRESUV_ID,
       ED.ESTDOC_DESCRIPCION,
       A.CLIE_ID,
       A.ESTDOC_ID,
       A.PRESUV_FECHA,
       A.PRESUV_FECHAV,
       A.PRESUV_SUREFERENCIA,
       B.PERS_NOMBRE,
       E.CLIE_DESCRIPCION,
       F.NUMERO_ADJUNTOS
       ,A.PRESUV_FECHAMAXIMA
       ,A.POTENCIAL
       ,P.PERS_NOMBRE
ORDER BY A.PRESUV_FECHA DESC,A.DOCU_ID,A.PRESUV_ID DESC       
 ", cn);

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@CLIE_ID", clieId);
                cmd.Parameters.AddWithValue("@FECHAD", fechaDesde);
                cmd.Parameters.AddWithValue("@FECHAH", fechaHasta);

                cn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        odts.PresupuestoVenta p = new odts.PresupuestoVenta();
                        p.Documento = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader["DOCU_ID"]);
                        p.Numero = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader["PRESUV_ID"]);
                        p.Estado = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader["ESTDOC_DESCRIPCION"]);
                        p.Fecha = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader["PRESUV_FECHA"]);
                        p.ClieId = Utilidades.UtilsBD.DBValueToRequiredValue<int>(reader["CLIE_ID"]);
                        p.Cliente = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader["CLIE_DESCRIPCION"]);
                        p.Referencia = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader["PRESUV_SUREFERENCIA"]);
                        p.Emisor = Utilidades.UtilsBD.DBValueToOptionalString(reader["PERS_NOMBRE"]);
                        p.Gestor = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader["GESTOR_NOMBRE"]);
                        p.Base = Utilidades.UtilsBD.DBValueToRequiredValue<decimal>(reader["BASE"]);
                        p.FechaValidez = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader["PRESUV_FECHAV"]);
                        p.NumeroAdjuntos = Utilidades.UtilsBD.DBValueToRequiredValue<int>(reader["NUMERO_ADJUNTOS"]);

                        p.FechaMaxima = Utilidades.UtilsBD.DBValueToOptionalString(reader["PRESUV_FECHAMAXIMA"]);
                        p.Potencial = Utilidades.UtilsBD.DBValueToOptionalValue<short>(reader["POTENCIAL"]);

                        lista.Add(p);
                    }
                }
                cn.Close();
            }
            return lista;
        }

        // Devuelve los presupuestos de un cliente y su grupo de clientes entre 2 fechas
        public static List<odts.PresupuestoVenta> GetPresupuestosPorGrupoYFechas(int clieId, string fechaDesde, string fechaHasta)
        {
            List<odts.PresupuestoVenta> lista = new List<odts.PresupuestoVenta>();

            using (SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["conexionQ"]))
            {
                SqlCommand cmd = new SqlCommand(
                    @"SELECT 
       A.DOCU_ID,
       A.PRESUV_ID,
       ED.ESTDOC_DESCRIPCION,
       A.CLIE_ID,
       A.ESTDOC_ID,
       A.PRESUV_FECHA,
       A.PRESUV_FECHAV,
       A.PRESUV_SUREFERENCIA,
       B.PERS_NOMBRE,
       P.PERS_NOMBRE GESTOR_NOMBRE,
       E.CLIE_DESCRIPCION,
       ISNULL(F.NUMERO_ADJUNTOS,0) NUMERO_ADJUNTOS,
       SUM((ISNULL(PL.PRESUVL_PRECIO,0)* ISNULL(PL.PRESUVL_CANTIDAD,0)) * ((100 - ISNULL(GDL.GRDEL_VALOR,0))/ 100)) BASE
,A.PRESUV_FECHAMAXIMA
       ,A.POTENCIAL
  FROM PRESUPUESTOSV A
    INNER JOIN ESTADO_DOCUMENTOS ED ON ED.ESTDOC_ID = A.ESTDOC_ID
  LEFT OUTER JOIN PRESUPUESTOSV_LI PL ON PL.DOCU_ID = A.DOCU_ID AND PL.PRESUV_ID = A.PRESUV_ID
  LEFT OUTER JOIN GRUPOS_DESC_LINEAS GDL ON GDL.GRDE_ID = PL.GRDE_ID
       LEFT OUTER JOIN PERSONAL B ON  B.PERS_ID = A.PERS_ID
       LEFT OUTER JOIN CLIENTES E ON E.CLIE_ID = A.CLIE_ID
       LEFT OUTER JOIN FICHEROS_ADJUNTOS F ON F.DOCU_ID = A.DOCU_ID AND F.DOCU_NUMERO = A.PRESUV_ID
       INNER JOIN PERSONAL P ON P.PERS_ID = A.GESTOR_ID
WHERE 
      (@FECHAD = '' OR @FECHAD <= A.PRESUV_FECHA) AND
      (@FECHAH = '' OR @FECHAH >= A.PRESUV_FECHA) AND
      (@CLIE_ID = 0 OR A.CLIE_ID IN 
                                                    (
									                    SELECT A.CLIE_ID
									                    FROM CLIENTES A
									                    INNER JOIN CLIENTES B ON A.CLIE_ID = B.CLIE_ID 
									                    WHERE A.CLIE_ID = @CLIE_ID OR
										                      B.CLIE_ID1 IN 
														                    (SELECT CLIE_ID1
														                     FROM CLIENTES 
														                     WHERE CLIE_ID = @CLIE_ID)
                                                    )
                                      )
GROUP BY A.DOCU_ID,
       A.PRESUV_ID,
       ED.ESTDOC_DESCRIPCION,
       A.CLIE_ID,
       A.ESTDOC_ID,
       A.PRESUV_FECHA,
       A.PRESUV_FECHAV,
       A.PRESUV_SUREFERENCIA,
       B.PERS_NOMBRE,
       E.CLIE_DESCRIPCION,
       F.NUMERO_ADJUNTOS
       ,A.PRESUV_FECHAMAXIMA
       ,A.POTENCIAL
       ,P.PERS_NOMBRE
ORDER BY A.PRESUV_FECHA DESC,A.DOCU_ID,A.PRESUV_ID DESC       
 ", cn);

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@CLIE_ID", clieId);
                cmd.Parameters.AddWithValue("@FECHAD", fechaDesde);
                cmd.Parameters.AddWithValue("@FECHAH", fechaHasta);

                cn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        odts.PresupuestoVenta p = new odts.PresupuestoVenta();
                        p.Documento = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader["DOCU_ID"]);
                        p.Numero = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader["PRESUV_ID"]);
                        p.Estado = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader["ESTDOC_DESCRIPCION"]);
                        p.Fecha = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader["PRESUV_FECHA"]);
                        p.ClieId = Utilidades.UtilsBD.DBValueToRequiredValue<int>(reader["CLIE_ID"]);
                        p.Cliente = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader["CLIE_DESCRIPCION"]);
                        p.Referencia = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader["PRESUV_SUREFERENCIA"]);
                        p.Emisor = Utilidades.UtilsBD.DBValueToOptionalString(reader["PERS_NOMBRE"]);
                        p.Gestor = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader["GESTOR_NOMBRE"]);
                        p.Base = Utilidades.UtilsBD.DBValueToRequiredValue<decimal>(reader["BASE"]);
                        p.FechaValidez = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader["PRESUV_FECHAV"]);
                        p.NumeroAdjuntos = Utilidades.UtilsBD.DBValueToRequiredValue<int>(reader["NUMERO_ADJUNTOS"]);

                        lista.Add(p);
                    }
                }
                cn.Close();
            }
            return lista;
        }


        // Devuelve los bloques de los presupuestos de un cliente y su grupo
        public static List<odts.PresupuestoVentaBloque> GetBloquesGrupoByCliente(int clieId)
        {
            List<odts.PresupuestoVentaBloque> lista = new List<odts.PresupuestoVentaBloque>();

            using (SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["conexionQ"]))
            {
                SqlCommand cmd = new SqlCommand(
                    @"SELECT DISTINCT A.DOCU_ID, A.PRESUV_ID, A.ESTDOC_ID, A.BLOQUE_ID, A.FAMIL_ID, B.FAMIL_DESCRIPCION, A.TITULO, A.REFERENCIA_CLIENTE, A.FECHA_CREACION, D.CLIE_DESCRIPCION
FROM PRESUPUESTOV_BLOQUE A 
LEFT OUTER JOIN FAMILIAS B ON B.FAMIL_ID = A.FAMIL_ID
INNER JOIN PRESUPUESTOSV C ON C.DOCU_ID = A.DOCU_ID AND C.PRESUV_ID = A.PRESUV_ID
INNER JOIN CLIENTES D ON D.CLIE_ID = C.CLIE_ID
WHERE D.CLIE_ID = @CLIE_ID OR D.CLIE_ID IN (SELECT B.CLIE_ID FROM CLIENTES A INNER JOIN CLIENTES B ON B.CLIE_ID1 = A.CLIE_ID1 WHERE A.CLIE_ID = @CLIE_ID) ", cn);

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@CLIE_ID", clieId);

                cn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        odts.PresupuestoVentaBloque p = new odts.PresupuestoVentaBloque();
                        p.DocuId = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader[0]);
                        p.PresuvId = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader[1]);
                        p.Estado = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader[2]);
                        p.BloqueId = Utilidades.UtilsBD.DBValueToRequiredValue<int>(reader[3]);
                        p.FamilId = Utilidades.UtilsBD.DBValueToOptionalString(reader[4]);
                        p.FamilDescripcion = Utilidades.UtilsBD.DBValueToOptionalString(reader[5]);
                        p.Titulo = Utilidades.UtilsBD.DBValueToOptionalString(reader[6]);
                        p.ReferenciaCliente = Utilidades.UtilsBD.DBValueToOptionalString(reader[7]);
                        p.FechaCreacion = Utilidades.UtilsBD.DBValueToRequiredFecha(reader[8]);
                        p.Cliente = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader[9]);

                        lista.Add(p);

                    }
                }
                cn.Close();

            }


            return lista;
        }



        // Devuelve las lineas (detalle) de un bloque
        public static List<odts.PresupuestoVentaDetalle> GetDetalleByBloque(string docuId, string presuvId, int bloqueId)
        {
            List<odts.PresupuestoVentaDetalle> lista = new List<odts.PresupuestoVentaDetalle>();

            using (SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["conexionQ"]))
            {
                SqlCommand cmd = new SqlCommand(
                    @"SELECT A.LIDO_ID, A.PRESUVL_LINEA, A.PRESUVL_SUBLINEA, A.ARTI_ID1, A.PRESUVL_DESCRIPCION, A.PRESUVL_CANTIDAD, A.UNID_ID, B.UNID_DESCRIPCION, A.PRESUVL_PRECIO, A.GRDE_ID, C.GRDE_DESCRIPCION, A.COMP_ID, A.ARTI_DETERMINACIONES, A.ARTI_PNT_METODOLOGIA
                    FROM PRESUPUESTOSV_LI A
                    INNER JOIN UNIDADES B ON B.UNID_ID = A.UNID_ID
                    LEFT OUTER JOIN GRUPOS_DESCUENTOS C ON C.GRDE_ID = A.GRDE_ID
                    WHERE A.DOCU_ID = @DOCU_ID AND A.PRESUV_ID = @PRESUV_ID AND A.BLOQUE_ID = @BLOQUE_ID AND A.LIDO_ID <> 'T' ", cn);

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@DOCU_ID", docuId);
                cmd.Parameters.AddWithValue("@PRESUV_ID", presuvId);
                cmd.Parameters.AddWithValue("@BLOQUE_ID", bloqueId);

                cn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    odts.DetalleModelo p = new odts.DetalleModelo();
                    while (reader.Read())
                    {
                        string tipoLinea = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader["LIDO_ID"]);

                        if (tipoLinea == "N")
                        {
                            p = new odts.DetalleModelo();
                            p.Linea = Utilidades.UtilsBD.DBValueToRequiredValue<int>(reader["PRESUVL_LINEA"]);
                            p.Sublinea = Utilidades.UtilsBD.DBValueToRequiredValue<int>(reader["PRESUVL_SUBLINEA"]);
                            p.ArtiId1 = Utilidades.UtilsBD.DBValueToRequiredValue<int>(reader["ARTI_ID1"]);
                            p.DetalleDescripcion = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader["PRESUVL_DESCRIPCION"]);
                            p.Cantidad = Utilidades.UtilsBD.DBValueToRequiredValue<decimal>(reader["PRESUVL_CANTIDAD"]);
                            p.UnidadId = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader["UNID_ID"]);
                            p.UnidadDescripcion = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader["UNID_DESCRIPCION"]);
                            p.Precio = Utilidades.UtilsBD.DBValueToRequiredValue<decimal>(reader["PRESUVL_PRECIO"]);
                            p.DescuentoId = Utilidades.UtilsBD.DBValueToOptionalValue<int>(reader["GRDE_ID"]);
                            p.DescuentoDescripcion = Utilidades.UtilsBD.DBValueToOptionalString(reader["GRDE_DESCRIPCION"]);
                            p.ComportamientoIVA = Utilidades.UtilsBD.DBValueToRequiredValue<int>(reader["COMP_ID"]);
                            p.ArtiDeterminaciones = Utilidades.UtilsBD.DBValueToOptionalString(reader["ARTI_DETERMINACIONES"]);
                            p.ArtiPNTMetodologia = Utilidades.UtilsBD.DBValueToOptionalString(reader["ARTI_PNT_METODOLOGIA"]);
                            lista.Add(p);
                        }
                        else if (tipoLinea == "N+")
                        {
                            odts.DetalleDeterminacion dd = new odts.DetalleDeterminacion();
                            dd.Linea = Utilidades.UtilsBD.DBValueToRequiredValue<int>(reader["PRESUVL_LINEA"]);
                            dd.Sublinea = Utilidades.UtilsBD.DBValueToRequiredValue<int>(reader["PRESUVL_SUBLINEA"]);
                            dd.ArtiId1 = Utilidades.UtilsBD.DBValueToRequiredValue<int>(reader["ARTI_ID1"]);
                            dd.DetalleDescripcion = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader["PRESUVL_DESCRIPCION"]);
                            dd.Cantidad = Utilidades.UtilsBD.DBValueToRequiredValue<decimal>(reader["PRESUVL_CANTIDAD"]);
                            dd.UnidadId = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader["UNID_ID"]);
                            dd.UnidadDescripcion = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader["UNID_DESCRIPCION"]);
                            dd.Precio = Utilidades.UtilsBD.DBValueToRequiredValue<decimal>(reader["PRESUVL_PRECIO"]);
                            dd.DescuentoId = Utilidades.UtilsBD.DBValueToOptionalValue<int>(reader["GRDE_ID"]);
                            dd.DescuentoDescripcion = Utilidades.UtilsBD.DBValueToOptionalString(reader["GRDE_DESCRIPCION"]);
                            dd.ComportamientoIVA = Utilidades.UtilsBD.DBValueToRequiredValue<int>(reader["COMP_ID"]);
                            dd.ArtiDeterminaciones = Utilidades.UtilsBD.DBValueToOptionalString(reader["ARTI_DETERMINACIONES"]);
                            dd.ArtiPNTMetodologia = Utilidades.UtilsBD.DBValueToOptionalString(reader["ARTI_PNT_METODOLOGIA"]);
                            //lista.Add(p);
                            p.Determinaciones.Add(dd);
                        }
                        else
                        {
                            MessageBox.Show("Tipo de línea no contemplado, coméntalo con el responsable del desarrollo");
                        }



                    }
                }
                cn.Close();

            }


            return lista;
        }

        /// <summary>
        /// Obtiene las líneas de detalle de un bloque de un presupuesto
        /// </summary>
        /// <param name="docuId">documento del presupuesto</param>
        /// <param name="presuvId">número del presupuesto</param>
        /// <param name="bloqueId">código de bloque</param>
        /// <returns></returns>
        public static DataTable GetDetalleByBloque2(string docuId, string presuvId, int bloqueId)
        {
            DataTable dt = new DataTable("PRESUPUESTO");

            using (SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["conexionQ"]))
            {
                SqlCommand cmd = new SqlCommand(
                    @"SELECT A.*, ISNULL(M.DEPA_ID, ISNULL(D.DEPA_ID,0)) DEPA_ID
                    FROM PRESUPUESTOSV_LI A
                    INNER JOIN UNIDADES B ON B.UNID_ID = A.UNID_ID
                    LEFT OUTER JOIN GRUPOS_DESCUENTOS C ON C.GRDE_ID = A.GRDE_ID
INNER JOIN ARTICULOS AR ON AR.ARTI_ID1 = A.ARTI_ID1
LEFT OUTER JOIN MODELOS M ON M.ARTI_ID = AR.ARTI_ID
LEFT OUTER JOIN DETERMINACION_TIAN DT ON DT.ARTI_ID = AR.ARTI_ID
LEFT OUTER JOIN DETERMINACIONES D ON D.DETE_ID = DT.DETE_ID
                    WHERE A.DOCU_ID = @DOCU_ID AND A.PRESUV_ID = @PRESUV_ID AND A.BLOQUE_ID = @BLOQUE_ID AND A.LIDO_ID <> 'T' ", cn);

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@DOCU_ID", docuId);
                cmd.Parameters.AddWithValue("@PRESUV_ID", presuvId);
                cmd.Parameters.AddWithValue("@BLOQUE_ID", bloqueId);

                cn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                cn.Close();
            }

            return dt;
        }


        // Devuelve los articulos asociados a las determinaciones incluidas en un modelo
        public static List<Almacen.odts.ArticuloDeterminacion> GetArticulosDeterminacionFromModeloTipoAnalisis(int artiId1, string tipoAnalisis)
        {
            List<Almacen.odts.ArticuloDeterminacion> lista = new List<Almacen.odts.ArticuloDeterminacion>();
            /*
             * SELECT F.ARTI_ID1, F.ARTI_DESCRIPCION, F.ARTI_ID
FROM MODELOS A
INNER JOIN ARTICULOS B ON B.ARTI_ID = A.ARTI_ID
INNER JOIN MODELOS_LI C ON C.MODE_ID = A.MODE_ID
INNER JOIN MODEL_DETER D ON D.MODE_ID = C.MODE_ID AND D.MODELI_ID = C.MODELI_ID
INNER JOIN DETERMINACION_TIAN E ON E.DETE_ID = D.DETE_ID AND E.TIPANA_ID = D.TIPANA_ID --AND E.TIPANALI_ID = D.TIPANALI_ID
INNER JOIN ARTICULOS F ON F.ARTI_ID = E.ARTI_ID
WHERE B.ARTI_ID1 = 8929 AND C.TIPANA_ID = 'AG' AND '2014-04-03' BETWEEN C.MODELI_FECHAD AND C.MODELI_FECHAH
            */
            return lista;
        }

        public static List<Almacen.odts.Familia> GetFamilias()
        {
            List<Almacen.odts.Familia> lista = new List<Almacen.odts.Familia>();
            lista.Add(new Almacen.odts.Familia());

            using (SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["conexionQ"]))
            {
                SqlCommand cmd = new SqlCommand(
                    @"SELECT FAMIL_ID, FAMIL_DESCRIPCION FROM FAMILIAS WHERE TIPANA_ID IS NOT NULL ", cn);

                cmd.CommandType = System.Data.CommandType.Text;

                cn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Almacen.odts.Familia f = new Almacen.odts.Familia();
                        f.FamilId = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader[0]);
                        f.FamilDescripcion = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader[1]);

                        lista.Add(f);
                    }
                }
                cn.Close();
            }

            return lista;
        }


        // Obtiene el precio y descuento de un articulo para un cliente
        public static void GetPrecioArticuloByCliente(odts.PresupuestoVentaDetalle detalle, int artiId1, int clieId, string docuId)
        {

            using (SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["conexionQ"]))
            {
                SqlCommand cmd = new SqlCommand(
                    @"CLIENTES_COND_PRECIO2", cn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TIPO", 0);
                cmd.Parameters.AddWithValue("@USUARIO", _USU_ID); 
                cmd.Parameters.AddWithValue("@INTER_ID", clieId);
                cmd.Parameters.AddWithValue("@FECHA", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@ARTI_ID1", artiId1);
                cmd.Parameters.AddWithValue("@DOCU_ID", docuId);

                cn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        detalle.Precio = Utilidades.UtilsBD.DBValueToRequiredValue<decimal>(reader[1]);
                        detalle.DescuentoId = Utilidades.UtilsBD.DBValueToOptionalValue<int>(reader[2]);
                    }
                }
                cn.Close();
            }
        }

        // Obtiene el precio y descuento de un articulo para un cliente
        public static object[] GetPrecioArticuloByCliente(int artiId1, int clieId, string docuId)
        {
            // precio[0] precio
            // precio[1] descuento
            object[] precio = new object[2];

            using (SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["conexionQ"]))
            {
                SqlCommand cmd = new SqlCommand(
                    @"CLIENTES_COND_PRECIO2", cn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TIPO", 0);
                cmd.Parameters.AddWithValue("@USUARIO", _USU_ID);
                cmd.Parameters.AddWithValue("@INTER_ID", clieId);
                cmd.Parameters.AddWithValue("@FECHA", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@ARTI_ID1", artiId1);
                cmd.Parameters.AddWithValue("@DOCU_ID", docuId);

                cn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        precio[0] = Utilidades.UtilsBD.DBValueToRequiredValue<decimal>(reader[1]);
                        precio[1] = Utilidades.UtilsBD.DBValueToOptionalValue<int>(reader[2]);
                    }
                }
                cn.Close();
            }

            return precio;
        }

        public static void GetDatosArticulo(odts.PresupuestoVentaDetalle detalle, int artiId1, int clieId)
        {
            //exec ARTICULOS_SEL_LINEAS1 @TIPO=0,@USUARIO='AL',@ARTI_ID='PLA000000000002',@CLIE_ID=3018
            using (SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["conexionQ"]))
            {
                SqlCommand cmd = new SqlCommand(
                    @"ARTICULOS_SEL_LINEAS3", cn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TIPO", 0);
                cmd.Parameters.AddWithValue("@USUARIO", _USU_ID);
                cmd.Parameters.AddWithValue("@ARTI_ID", artiId1);
                cmd.Parameters.AddWithValue("@CLIE_ID", clieId);

                cn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        detalle.UnidadId = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader["UNID_ID"]);
                        detalle.ArtiId1 = Utilidades.UtilsBD.DBValueToRequiredValue<int>(reader["ARTI_ID1"]);
                        detalle.ComportamientoIVA = Utilidades.UtilsBD.DBValueToRequiredValue<int>(reader["COMP_ID"]);
                    }
                }
                cn.Close();
            }
        }

        // Crea un bloque y devuelve su identificador
        public static int GuardarBloque(string docuId, string numero, int linea, string familia, string titulo, string referenciaCliente, string estado)
        {
            int bloqueId = 1;
            using (SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["conexionQ"]))
            {
                SqlCommand cmd = new SqlCommand(
                    @"PRESUPUESTOV_BLOQUE_INS", cn);
                cmd.Parameters.AddWithValue("@TIPO", 0);
                cmd.Parameters.AddWithValue("@USUARIO", _USU_ID);
                cmd.Parameters.AddWithValue("@DOCU_ID", docuId);
                cmd.Parameters.AddWithValue("@PRESUV_ID", numero);
                cmd.Parameters.AddWithValue("@BLOQUE_ID", linea);
                cmd.Parameters.AddWithValue("@FAMIL_ID", familia);
                cmd.Parameters.AddWithValue("@TITULO", titulo);
                cmd.Parameters.AddWithValue("@REFERENCIA_CLIENTE", referenciaCliente);
                cmd.Parameters.AddWithValue("@FECHA_CREACION", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@ESTDOC_ID", estado);

                //cmd.Parameters["@BLOQUE_ID"].Direction = ParameterDirection.InputOutput;

                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                cmd.ExecuteNonQuery();
                //if (cmd.ExecuteNonQuery() > 0)
                //{
                //bloqueId = (int)cmd.Parameters["@BLOQUE_ID"].Value;
                //}
                cn.Close();
            }

            return linea;
        }

        // Actualiza un bloque
        public static void ActualizarBloque(string docuId, string numero, int bloqueId, string familia, string titulo, string referenciaCliente, string estado)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["conexionQ"]))
            {
                SqlCommand cmd = new SqlCommand(
                    @"PRESUPUESTOV_BLOQUE_UPD", cn);
                cmd.Parameters.AddWithValue("@TIPO", 0);
                cmd.Parameters.AddWithValue("@USUARIO", _USU_ID);
                cmd.Parameters.AddWithValue("@DOCU_ID", docuId);
                cmd.Parameters.AddWithValue("@PRESUV_ID", numero);
                cmd.Parameters.AddWithValue("@BLOQUE_ID", bloqueId);
                cmd.Parameters.AddWithValue("@FAMIL_ID", familia);
                cmd.Parameters.AddWithValue("@TITULO", titulo);
                cmd.Parameters.AddWithValue("@REFERENCIA_CLIENTE", referenciaCliente);
                cmd.Parameters.AddWithValue("@FECHA_CREACION", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@ESTDOC_ID", estado);


                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }

        }

        // Guarda la linea de un bloque
        public static void GuardarLineaTextoBloque(bool actualizar, string docuId, string numero, int bloqueId, string texto, int linea, int artiId1)
        {

            using (SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["conexionQ"]))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                if (actualizar)
                {
                    cmd.CommandText = @"UPDATE PRESUPUESTOSV_LI
                    SET
PRESUVL_DESCRIPCION = @PRESUVL_DESCRIPCION,
ARTI_ID1 = @ARTI_ID1
WHERE DOCU_ID = @DOCU_ID AND PRESUV_ID = @PRESUV_ID AND PRESUVL_LINEA = @PRESUVL_LINEA AND  BLOQUE_ID = @BLOQUE_ID
";
                    cmd.Parameters.AddWithValue("@DOCU_ID", docuId);
                    cmd.Parameters.AddWithValue("@PRESUV_ID", numero);
                    cmd.Parameters.AddWithValue("@PRESUVL_LINEA", linea);
                    cmd.Parameters.AddWithValue("@PRESUVL_DESCRIPCION", texto);
                    cmd.Parameters.AddWithValue("@ARTI_ID1", artiId1);
                    cmd.Parameters.AddWithValue("@BLOQUE_ID", bloqueId);
                }
                else
                {
                    //SqlCommand cmd = new SqlCommand(
                    cmd.CommandText =
                        @"INSERT INTO PRESUPUESTOSV_LI	
	 	(DOCU_ID,PRESUV_ID,PRESUVL_LINEA,PRESUVL_SUBLINEA,LIDO_ID,PRESUVL_DESCRIPCION,PRESUVL_CANTIDAD,
		PRESUVL_PRECIO,GRDE_ID,UNID_ID,ESTDOC_ID,DOCU_ID_ORIGEN,DOCU_NUMERO_ORIGEN,DOCU_LINEA_ORIGEN,
		DOCU_SUBLINEA_ORIGEN,PRESUVL_FLUJOC,PRESUVL_FLUJOL,ARTI_ID1,COMP_ID,
		ARTI_DETERMINACIONES, ARTI_PNT_METODOLOGIA, BLOQUE_ID)
        VALUES(
@DOCU_ID,@PRESUV_ID,@PRESUVL_LINEA,@PRESUVL_SUBLINEA,@LIDO_ID,@PRESUVL_DESCRIPCION,@PRESUVL_CANTIDAD,
		@PRESUVL_PRECIO,@GRDE_ID,@UNID_ID,@ESTDOC_ID,@DOCU_ID_ORIGEN,@DOCU_NUMERO_ORIGEN,@DOCU_LINEA_ORIGEN,
		@DOCU_SUBLINEA_ORIGEN,@PRESUVL_FLUJOC,@PRESUVL_FLUJOL,@ARTI_ID1,@COMP_ID, @ARTI_DETERMINACIONES, @ARTI_PNT_METODOLOGIA, @BLOQUE_ID)
        ";

                    cmd.Parameters.AddWithValue("@DOCU_ID", docuId);
                    cmd.Parameters.AddWithValue("@PRESUV_ID", numero);
                    cmd.Parameters.AddWithValue("@PRESUVL_LINEA", linea);
                    cmd.Parameters.AddWithValue("@PRESUVL_SUBLINEA", 0);
                    cmd.Parameters.AddWithValue("@LIDO_ID", "T");
                    cmd.Parameters.AddWithValue("@PRESUVL_DESCRIPCION", texto);
                    cmd.Parameters.AddWithValue("@PRESUVL_CANTIDAD", 1);
                    cmd.Parameters.AddWithValue("@PRESUVL_PRECIO", 0);
                    cmd.Parameters.AddWithValue("@GRDE_ID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@UNID_ID", "UN");
                    cmd.Parameters.AddWithValue("@ESTDOC_ID", "T");
                    cmd.Parameters.AddWithValue("@DOCU_ID_ORIGEN", DBNull.Value);
                    cmd.Parameters.AddWithValue("@DOCU_NUMERO_ORIGEN", DBNull.Value);
                    cmd.Parameters.AddWithValue("@DOCU_LINEA_ORIGEN", DBNull.Value);
                    cmd.Parameters.AddWithValue("@DOCU_SUBLINEA_ORIGEN", DBNull.Value);
                    cmd.Parameters.AddWithValue("@PRESUVL_FLUJOC", "1");
                    cmd.Parameters.AddWithValue("@PRESUVL_FLUJOL", "1");
                    cmd.Parameters.AddWithValue("@ARTI_ID1", artiId1);
                    cmd.Parameters.AddWithValue("@COMP_ID", 2);
                    cmd.Parameters.AddWithValue("@ARTI_DETERMINACIONES", string.Empty);
                    cmd.Parameters.AddWithValue("@ARTI_PNT_METODOLOGIA", string.Empty);
                    cmd.Parameters.AddWithValue("@BLOQUE_ID", bloqueId);
                }
                cmd.CommandType = CommandType.Text;

                cn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {

                }
                cn.Close();
            }
        }

        public static void EliminarBloque(string docuId, string numero, int bloqueId)
        {
            EliminaLineasBloque(docuId, numero, bloqueId);


            using (SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["conexionQ"]))
            {
                SqlCommand cmd = new SqlCommand(
                    @"DELETE PRESUPUESTOV_BLOQUE
                      WHERE DOCU_ID = @DOCU_ID AND PRESUV_ID = @PRESUV_ID AND BLOQUE_ID = @BLOQUE_ID ", cn);
                cmd.Parameters.AddWithValue("@DOCU_ID", docuId);
                cmd.Parameters.AddWithValue("@PRESUV_ID", numero);
                cmd.Parameters.AddWithValue("@BLOQUE_ID", bloqueId);

                cmd.CommandType = CommandType.Text;

                cn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {

                }
                cn.Close();
            }

        }


        // Elimina todas las lineas de artículos
        public static void EliminaLineasBloque(string docuId, string numero, int bloqueId)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["conexionQ"]))
            {
                SqlCommand cmd = new SqlCommand(
                    @"DELETE PRESUPUESTOSV_LI
                      WHERE DOCU_ID = @DOCU_ID AND PRESUV_ID = @PRESUV_ID AND BLOQUE_ID = @BLOQUE_ID --AND LIDO_ID <> 'T' ", cn);
                cmd.Parameters.AddWithValue("@DOCU_ID", docuId);
                cmd.Parameters.AddWithValue("@PRESUV_ID", numero);
                cmd.Parameters.AddWithValue("@BLOQUE_ID", bloqueId);

                cmd.CommandType = CommandType.Text;

                cn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {

                }
                cn.Close();
            }
        }


        // Guarda la linea de un bloque
        public static void GuardarLineaBloque(string docuId, string numero, int bloqueId, odts.PresupuestoVentaDetalle linea, int numLinea)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["conexionQ"]))
            {
                SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO PRESUPUESTOSV_LI	
	 	(DOCU_ID,PRESUV_ID,PRESUVL_LINEA,PRESUVL_SUBLINEA,LIDO_ID,PRESUVL_DESCRIPCION,PRESUVL_CANTIDAD,
		PRESUVL_PRECIO,GRDE_ID,UNID_ID,ESTDOC_ID,DOCU_ID_ORIGEN,DOCU_NUMERO_ORIGEN,DOCU_LINEA_ORIGEN,
		DOCU_SUBLINEA_ORIGEN,PRESUVL_FLUJOC,PRESUVL_FLUJOL,ARTI_ID1,COMP_ID,
		ARTI_DETERMINACIONES, ARTI_PNT_METODOLOGIA, BLOQUE_ID)
        VALUES(
@DOCU_ID,@PRESUV_ID,@PRESUVL_LINEA,@PRESUVL_SUBLINEA,@LIDO_ID,@PRESUVL_DESCRIPCION,@PRESUVL_CANTIDAD,
		@PRESUVL_PRECIO,@GRDE_ID,@UNID_ID,@ESTDOC_ID,@DOCU_ID_ORIGEN,@DOCU_NUMERO_ORIGEN,@DOCU_LINEA_ORIGEN,
		@DOCU_SUBLINEA_ORIGEN,@PRESUVL_FLUJOC,@PRESUVL_FLUJOL,@ARTI_ID1,@COMP_ID, @ARTI_DETERMINACIONES, @ARTI_PNT_METODOLOGIA, @BLOQUE_ID)
        ", cn);
                cmd.Parameters.AddWithValue("@DOCU_ID", docuId);
                cmd.Parameters.AddWithValue("@PRESUV_ID", numero);
                cmd.Parameters.AddWithValue("@PRESUVL_LINEA", numLinea);
                cmd.Parameters.AddWithValue("@PRESUVL_SUBLINEA", linea.Sublinea);
                cmd.Parameters.AddWithValue("@LIDO_ID", linea.TipoLinea);
                cmd.Parameters.AddWithValue("@PRESUVL_DESCRIPCION", linea.DetalleDescripcion);
                cmd.Parameters.AddWithValue("@PRESUVL_CANTIDAD", linea.Cantidad);
                cmd.Parameters.AddWithValue("@PRESUVL_PRECIO", linea.Precio);
                if (linea.DescuentoId.HasValue)
                {
                    cmd.Parameters.AddWithValue("@GRDE_ID", linea.DescuentoId.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@GRDE_ID", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@UNID_ID", linea.UnidadId);
                cmd.Parameters.AddWithValue("@ESTDOC_ID", linea.Estado);
                cmd.Parameters.AddWithValue("@DOCU_ID_ORIGEN", DBNull.Value);
                cmd.Parameters.AddWithValue("@DOCU_NUMERO_ORIGEN", DBNull.Value);
                cmd.Parameters.AddWithValue("@DOCU_LINEA_ORIGEN", DBNull.Value);
                cmd.Parameters.AddWithValue("@DOCU_SUBLINEA_ORIGEN", DBNull.Value);
                cmd.Parameters.AddWithValue("@PRESUVL_FLUJOC", "1");
                cmd.Parameters.AddWithValue("@PRESUVL_FLUJOL", "1");
                cmd.Parameters.AddWithValue("@ARTI_ID1", linea.ArtiId1);
                cmd.Parameters.AddWithValue("@COMP_ID", 2);

                if (linea.ArtiDeterminaciones == null)
                    cmd.Parameters.AddWithValue("@ARTI_DETERMINACIONES", string.Empty);
                else
                    cmd.Parameters.AddWithValue("@ARTI_DETERMINACIONES", linea.ArtiDeterminaciones);

                if (linea.ArtiPNTMetodologia == null)
                    cmd.Parameters.AddWithValue("@ARTI_PNT_METODOLOGIA", string.Empty);
                else
                    cmd.Parameters.AddWithValue("@ARTI_PNT_METODOLOGIA", linea.ArtiPNTMetodologia);

                cmd.Parameters.AddWithValue("@BLOQUE_ID", bloqueId);

                cmd.CommandType = CommandType.Text;

                cn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {

                }
                cn.Close();
            }
        }

        // Obtiene el listado de texto textos internos
        public static List<odts.TextoInterno> GetTextosInternos()
        {
            List<odts.TextoInterno> lista = new List<odts.TextoInterno>();

            using (SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["conexionQ"]))
            {
                SqlCommand cmd = new SqlCommand(
                    @"SELECT A.ARTI_ID1, A.ARTI_DESCRIPCION
                        FROM ARTICULOS A 
                        WHERE TIPAR_ID = 'TI'
                        ORDER BY A.ARTI_DESCRIPCION ", cn);

                cmd.CommandType = System.Data.CommandType.Text;

                cn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        odts.TextoInterno t = new odts.TextoInterno();
                        t.ArtiId1 = Utilidades.UtilsBD.DBValueToRequiredValue<int>(reader["ARTI_ID1"]);
                        t.Texto = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader["ARTI_DESCRIPCION"]);

                        lista.Add(t);
                    }
                }
                cn.Close();
            }
            return lista;
        }


        public static string GetTipoAnalisisPorFamilia(string familId)
        {
            string tipanaId = string.Empty;
            using (SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["conexionQ"]))
            {
                SqlCommand cmd = new SqlCommand(
                    @"SELECT TOP 1 TIPANA_ID
                        FROM FAMILIAS
                        WHERE FAMIL_ID = @FAMIL_ID ", cn);

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@FAMIL_ID", familId);

                cn.Open();

                object o = cmd.ExecuteScalar();
                if (o != null)
                    tipanaId = o.ToString();

                cn.Close();
            }

            return tipanaId;
        }

        public static List<odts.DetalleDeterminacion> GetAsociados(int artiId1)
        {
            List<odts.DetalleDeterminacion> lista = new List<odts.DetalleDeterminacion>();


            using (SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["conexionQ"]))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(@"
                                        SELECT B.ARTI_ID, B.ARTI_ID1, B.ARTI_DESCRIPCION, B.ARTI_PNT_METODOLOGIA, B.ARTI_DETERMINACIONES, B.TIPAR_ID, ISNULL(M.DEPA_ID, ISNULL(D.DEPA_ID,0)) DEPA_ID
                                        FROM ARTICULO_ASOCIADO A
                                        INNER JOIN ARTICULOS B ON B.ARTI_ID1 = A.ASOCIADO_ID1
LEFT OUTER JOIN MODELOS M ON M.ARTI_ID = B.ARTI_ID
LEFT OUTER JOIN DETERMINACION_TIAN DT ON DT.ARTI_ID = B.ARTI_ID
LEFT OUTER JOIN DETERMINACIONES D ON D.DETE_ID = DT.DETE_ID
                                        WHERE A.ARTI_ID1 = @ARTI_ID1
                    ", cn);
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@ARTI_ID1", artiId1);

                    cn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            odts.DetalleDeterminacion a = new odts.DetalleDeterminacion();
                            a.DetalleDescripcion = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader["ARTI_DESCRIPCION"]);
                            a.ArtiId1 = Utilidades.UtilsBD.DBValueToRequiredValue<int>(reader["ARTI_ID1"]);
                            a.ArtiDeterminaciones = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader["ARTI_DETERMINACIONES"]);
                            a.ArtiPNTMetodologia = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader["ARTI_PNT_METODOLOGIA"]);
                            a.DepartamentoId = Utilidades.UtilsBD.DBValueToRequiredValue<int>(reader["DEPA_ID"]);

                            lista.Add(a);
                        }
                    }

                    cn.Close();
                }
                catch (System.StackOverflowException ex)
                {
                    MessageBox.Show("Existe un bucle entre los artículos asociados" + Environment.NewLine + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al buscar los artículos asociados" + Environment.NewLine + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

            return lista;
        }


        public static void EliminarDetalle(DataTable delete)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["conexionQ"]))
            {
                SqlCommand cmd = new SqlCommand(
                    @"DELETE PRESUPUESTOSV_LI
                    WHERE DOCU_ID = @DOCU_ID AND PRESUV_ID = @PRESUV_ID AND PRESUVL_LINEA = @PRESUVL_LINEA AND PRESUVL_SUBLINEA = @PRESUVL_SUBLINEA ", cn);

                cn.Open();
                foreach (DataRow dr in delete.Rows)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@DOCU_ID", dr["DOCU_ID"]);
                    cmd.Parameters.AddWithValue("@PRESUV_ID", dr["PRESUV_ID"]);
                    cmd.Parameters.AddWithValue("@PRESUVL_LINEA", dr["PRESUVL_LINEA"]);
                    cmd.Parameters.AddWithValue("@PRESUVL_SUBLINEA", dr["PRESUVL_SUBLINEA"]);

                    cmd.ExecuteNonQuery();
                }
                cn.Close();
            }
        }

        public static void InsertarDetalle(DataTable insert)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["conexionQ"]))
            {
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(ConfigurationSettings.AppSettings["conexionQ"]))
                {
                    bulkCopy.DestinationTableName = "PRESUPUESTOSV_LI";

                    try
                    {
                        // Write the array of rows to the destination.
                        bulkCopy.WriteToServer(insert);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        public static void ActualizarDetalle(DataTable update)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["conexionQ"]))
            {
                SqlCommand cmd = new SqlCommand(
                    @"UPDATE PRESUPUESTOSV_LI
                    SET
                        --DOCU_ID = @DOCU_ID,
	                    --PEDID_ID = @PRESUV_ID,
        	            --PRESUVL_LINEA = @PRESUVL_LINEA,
	                    --PRESUVL_SUBLINEA= @PRESUVL_SUBLINEA,
                        BLOQUE_ID = @BLOQUE_ID,
	                    LIDO_ID = @LIDO_ID,
	                    PRESUVL_DESCRIPCION = @PRESUVL_DESCRIPCION,
	                    PRESUVL_CANTIDAD = @PRESUVL_CANTIDAD,
	                    PRESUVL_PRECIO = @PRESUVL_PRECIO,
	                    GRDE_ID = @GRDE_ID,
	                    ESTDOC_ID = @ESTDOC_ID,
	                    UNID_ID = @UNID_ID,
	                    DOCU_ID_ORIGEN = @DOCU_ID_ORIGEN,
	                    DOCU_NUMERO_ORIGEN = @DOCU_NUMERO_ORIGEN,
	                    DOCU_LINEA_ORIGEN = @DOCU_LINEA_ORIGEN,
	                    DOCU_SUBLINEA_ORIGEN = @DOCU_SUBLINEA_ORIGEN,
	                    PRESUVL_FLUJOC = @PRESUVL_FLUJOC,
	                    PRESUVL_FLUJOL = @PRESUVL_FLUJOL,
	                    COMP_ID = @COMP_ID,
	                    ARTI_ID1 = @ARTI_ID1,
                        ARTI_DETERMINACIONES = @ARTI_DETERMINACIONES,
                        ARTI_PNT_METODOLOGIA = @ARTI_PNT_METODOLOGIA
                        WHERE DOCU_ID = @DOCU_ID AND PRESUV_ID = @PRESUV_ID AND PRESUVL_LINEA = @PRESUVL_LINEA AND PRESUVL_SUBLINEA = @PRESUVL_SUBLINEA", cn);

                cn.Open();
                foreach (DataRow dr in update.Rows)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@DOCU_ID", dr["DOCU_ID"]);
                    cmd.Parameters.AddWithValue("@PRESUV_ID", dr["PRESUV_ID"]);
                    cmd.Parameters.AddWithValue("@PRESUVL_LINEA", dr["PRESUVL_LINEA"]);
                    cmd.Parameters.AddWithValue("@PRESUVL_SUBLINEA", dr["PRESUVL_SUBLINEA"]);
                    cmd.Parameters.AddWithValue("@BLOQUE_ID", dr["BLOQUE_ID"]);
                    cmd.Parameters.AddWithValue("@LIDO_ID", dr["LIDO_ID"]);
                    cmd.Parameters.AddWithValue("@PRESUVL_DESCRIPCION", dr["PRESUVL_DESCRIPCION"]);
                    cmd.Parameters.AddWithValue("@PRESUVL_CANTIDAD", dr["PRESUVL_CANTIDAD"]);
                    cmd.Parameters.AddWithValue("@PRESUVL_PRECIO", dr["PRESUVL_PRECIO"]);
                    cmd.Parameters.AddWithValue("@GRDE_ID", dr["GRDE_ID"]);
                    cmd.Parameters.AddWithValue("@ESTDOC_ID", dr["ESTDOC_ID"]);
                    cmd.Parameters.AddWithValue("@UNID_ID", dr["UNID_ID"]);
                    cmd.Parameters.AddWithValue("@DOCU_ID_ORIGEN", dr["DOCU_ID_ORIGEN"]);
                    cmd.Parameters.AddWithValue("@DOCU_NUMERO_ORIGEN", dr["DOCU_NUMERO_ORIGEN"]);
                    cmd.Parameters.AddWithValue("@DOCU_LINEA_ORIGEN", dr["DOCU_LINEA_ORIGEN"]);
                    cmd.Parameters.AddWithValue("@DOCU_SUBLINEA_ORIGEN", dr["DOCU_SUBLINEA_ORIGEN"]);
                    cmd.Parameters.AddWithValue("@PRESUVL_FLUJOC", dr["PRESUVL_FLUJOC"]);
                    cmd.Parameters.AddWithValue("@PRESUVL_FLUJOL", dr["PRESUVL_FLUJOL"]);
                    cmd.Parameters.AddWithValue("@COMP_ID", dr["COMP_ID"]);
                    cmd.Parameters.AddWithValue("@ARTI_ID1", dr["ARTI_ID1"]);
                    cmd.Parameters.AddWithValue("@ARTI_DETERMINACIONES", dr["ARTI_DETERMINACIONES"]);
                    cmd.Parameters.AddWithValue("@ARTI_PNT_METODOLOGIA", dr["ARTI_PNT_METODOLOGIA"]);

                    cmd.ExecuteNonQuery();
                }
                cn.Close();
            }
        }

        /// <summary>
        /// Devuelve los pedidos sin facturar de un cliente
        /// </summary>
        /// <param name="clieId"></param>
        /// <returns></returns>
        public static DataTable GetPedidosSinFacturarPorCliente(int clieId)
        {
            DataTable dt = new DataTable("PEDIDOSV");

            using (SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["conexionQ"]))
            {
                SqlCommand cmd = new SqlCommand(
                    @"SELECT P.DOCU_ID, P.PEDID_ID, P.PEDID_SUREFERENCIA, P.PEDID_FECHA, A.ARTI_DESCRIPCION, A.FAMIL_ID
FROM PEDIDOSV P
INNER JOIN ARTICULOS A ON A.ARTI_ID = P.ARTI_ID
WHERE P.CLIE_ID = @CLIE_ID AND P.ESTDOC_ID NOT IN ('AN', 'FC')
ORDER BY P.PEDID_FECHA ", cn);

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@CLIE_ID", clieId);

                cn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                cn.Close();
            }

            return dt;
        }

        public static DataTable GetDetallePedido(string documento, string numero)
        {
            DataTable dt = new DataTable("PEDIDOSV_LI");

            using (SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["conexionQ"]))
            {
                SqlCommand cmd = new SqlCommand(
                    @"SELECT P.DOCU_ID, P.PEDID_ID, P.LIDO_ID, P.PEDIDL_DESCRIPCION, P.PEDIDL_PRECIO, P.PEDIDL_CANTIDAD, P.PEDIDL_LINEA, P.PEDIDL_SUBLINEA, GD.GRDE_DESCRIPCION
FROM PEDIDOSV_LI P
LEFT OUTER JOIN GRUPOS_DESCUENTOS GD ON GD.GRDE_ID = P.GRDE_ID
WHERE P.DOCU_ID = @DOCU_ID AND P.PEDID_ID = @PEDID_ID
ORDER BY P.PEDIDL_LINEA, P.PEDIDL_SUBLINEA ", cn);

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@DOCU_ID", documento);
                cmd.Parameters.AddWithValue("@PEDID_ID", numero);

                cn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                cn.Close();
            }

            return dt;
        }


        public static DataTable GetDatosActaParaCopiaBloque(string documentoActa, string numeroActa, string documentoPresupuesto, string numeroPresupuesto, int bloque, int maxLinea)
        {
            DataTable dt = new DataTable("PRESUPUESTOSV_LI");

            using (SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["conexionQ"]))
            {
                SqlCommand cmd = new SqlCommand(
                    @"SELECT @DOCU_PRESUV_ID DOCU_ID, @PRESUV_ID PRESUV_ID, P.PEDIDL_LINEA PRESUVL_LINEA, P.PEDIDL_SUBLINEA PRESUVL_SUBLINEA, P.LIDO_ID, 
P.PEDIDL_DESCRIPCION PRESUVL_DESCRIPCION, P.PEDIDL_CANTIDAD PRESUVL_CANTIDAD, P.PEDIDL_PRECIO PRESUVL_PRECIO, P.GRDE_ID, P.UNID_ID, 'N' ESTDOC_ID,
P.DOCU_ID DOCU_ID_ORIGEN, P.PEDID_ID DOCU_NUMERO_ORIGEN, P.PEDIDL_LINEA DOCU_LINEA_ORIGEN, P.PEDIDL_SUBLINEA DOCU_SUBLINEA_ORIGEN,
'0' PRESUVL_FLUJOC, '1' PRESUVL_FLUJOL, P.ARTI_ID1, P.COMP_ID, A.ARTI_DETERMINACIONES, A.ARTI_PNT_METODOLOGIA, @BLOQUE_ID BLOQUE_ID
FROM PEDIDOSV_LI P
INNER JOIN ARTICULOS A ON A.ARTI_ID1 = P.ARTI_ID1
WHERE P.DOCU_ID = @DOCU_ID AND P.PEDID_ID = @PEDID_ID
ORDER BY P.PEDIDL_LINEA, P.PEDIDL_SUBLINEA ", cn);

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@DOCU_ID", documentoActa);
                cmd.Parameters.AddWithValue("@PEDID_ID", numeroActa);
                cmd.Parameters.AddWithValue("@DOCU_PRESUV_ID", documentoPresupuesto);
                cmd.Parameters.AddWithValue("@PRESUV_ID", numeroPresupuesto);
                cmd.Parameters.AddWithValue("@BLOQUE_ID", bloque);

                cn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                cn.Close();
            }

            if (dt.Rows.Count > 0)
            {
                //dt.Columns.Add("PRESUVL_LINEA", typeof(int));

                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["LIDO_ID"].ToString() == "N")
                    {
                        maxLinea += 10;
                    }
                    dr["PRESUVL_LINEA"] = maxLinea;
                }
            }

            return dt;
        }

        public static DataTable GetPresupuestosPorArticulo(string artiId, string fechaD, string fechaH)
        {
            DataTable presupuestoVenta = new DataTable("PRESUPUESTOS_V_LISTADO");

            using (SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["conexionQ"]))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(@"
                SELECT
                    A.DOCU_ID,
                    A.PRESUV_ID,
                    A.ESTDOC_ID,
                    A.CLIE_ID,
                    A.PRESUV_FECHA,
                    A.PRESUV_FECHAV,
                    A.PERS_ID,
                    B.PRESUVL_CANTIDAD,
                    B.PRESUVL_PRECIO,
                    C.CLIE_DESCRIPCION,
                    D.PERS_NOMBRE
                FROM PRESUPUESTOSV A
                INNER JOIN PRESUPUESTOSV_LI B ON B.DOCU_ID = A.DOCU_ID AND B.PRESUV_ID = A.PRESUV_ID
                INNER JOIN CLIENTES C ON C.CLIE_ID = A.CLIE_ID
                INNER JOIN PERSONAL D ON D.PERS_ID = A.PERS_ID
                INNER JOIN ARTICULOS E ON E.ARTI_ID1 = B.ARTI_ID1
                WHERE                     
                    E.ARTI_ID = @ARTI_ID AND
                    (@FECHAD IS NULL OR @FECHAD <= A.PRESUV_FECHA) AND
                    (@FECHAH IS NULL OR @FECHAH >= A.PRESUV_FECHA)", cn);

                cmd.Parameters.AddWithValue("@ARTI_ID", artiId);
                cmd.Parameters.AddWithValue("@FECHAD", fechaD);
                cmd.Parameters.AddWithValue("@FECHAH", fechaH);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(presupuestoVenta);
            }
            return presupuestoVenta;
        }
    }
}
