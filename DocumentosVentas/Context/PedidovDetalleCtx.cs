using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DocumentosVentas
{
    class PedidovDetalleCtx
    {
        string connectionString = @"Data Source=INFORMATICA02\SQLSRV2008;Initial Catalog=local;Integrated Security=True";
        string connection = System.Configuration.ConfigurationSettings.AppSettings["ConectionString"];
        PedidovDetalleDBDataContext PedidovDetalleDataCtx = new PedidovDetalleDBDataContext();

        public List<Q2_GET_MODELOS_BY_TIPO_ANALISISResult> modelos;
        public List<Q2_GET_DETERMINACIONES_BY_TIPO_ANALISISResult> determinaciones;
        public List<Q2_GET_ARTICULOS_CARGO_BY_TIPO_ANALISISResult> articulos_cargo;
        public List<Q2_GET_ARTICULOS_CARGO_SERVICIOS_E_INFORMESResult> servicios_informes;
        public List<Q2_GET_BLOQUES_GRUPO_BY_CLIENTEResult> bloques;
        public List<Q2_GET_DETALLE_BY_BLOQUEResult> detalles_bloque;
        public List<Q2_GET_ASOCIADOSResult> asociados;
        public TIPANA_MATRIZ_CON_Q2Result tipo_analisis;
        public List<Q2_GET_MODELOS_BY_TIPO_ANALISISResult> GET_MODELOS(string tipana_id)
        {             
            modelos = PedidovDetalleDataCtx.Q2_GET_MODELOS_BY_TIPO_ANALISIS(tipana_id).ToList();
            return modelos;
        }
        public List<Q2_GET_DETERMINACIONES_BY_TIPO_ANALISISResult> GET_DETERMINACIONES(string tipana_id)
        {
            determinaciones = PedidovDetalleDataCtx.Q2_GET_DETERMINACIONES_BY_TIPO_ANALISIS(tipana_id).ToList();
            return determinaciones;
        }
        public void GetTipanaFromMatriz(string arti_id)
        {            
            tipo_analisis = PedidovDetalleDataCtx.TIPANA_MATRIZ_CON_Q2(arti_id).First();
        }
        public int? GetComportamientoIVACliente(int clieId)
        {
            // LINQ to SQL directo con SPR
            try
            {
                if (PedidovDetalleDataCtx.Q2_GET_COMP_IVA_CLIENTE(clieId).Count() > 0)
                    return PedidovDetalleDataCtx.Q2_GET_COMP_IVA_CLIENTE(clieId).First().COMP_ID;

                else return 0;
            }
            catch (Exception e)
            { return 0; }
        }
        //public DataTable GetDetalleByPedido2(string docu_id, string pedid_id)
        //{
        //    List<Q2_GET_DETALLE_BY_PEDIDO2Result> detalles = PedidovDetalleDataCtx.Q2_GET_DETALLE_BY_PEDIDO2(docu_id, pedid_id).ToList();
        //    DataTable datos = Utilidades.UtilsLinq.LINQResultToDataTable(detalles, "PEDIDOSV_LI");
        //    return datos;
        //}
        public DataTable GetDetalleByPedido2(string docuId, string numero)
        {
            DataTable datos = new DataTable("PEDIDOSV_LI");

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                /*SqlCommand cmd = new SqlCommand(
                    @"SELECT A.*, B.UNID_DESCRIPCION,  C.GRDE_DESCRIPCION--A.LIDO_ID, A.PEDIDL_LINEA, A.PEDIDL_SUBLINEA, A.ARTI_ID1, A.PEDIDL_DESCRIPCION, A.PEDIDL_CANTIDAD, A.UNID_ID, B.UNID_DESCRIPCION, A.PEDIDL_PRECIO, A.GRDE_ID, C.GRDE_DESCRIPCION, A.COMP_ID
                    FROM PEDIDOSV_LI A
                    INNER JOIN UNIDADES B ON B.UNID_ID = A.UNID_ID
                    LEFT OUTER JOIN GRUPOS_DESCUENTOS C ON C.GRDE_ID = A.GRDE_ID
                    WHERE A.DOCU_ID = @DOCU_ID AND A.PEDID_ID = @PEDID_ID  ", cn);*/
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

                //SqlDataReader reader = cmd.ExecuteReader();

                //if (reader.HasRows)
                //{
                //    odts.DetalleModelo p = new Ventas.odts.DetalleModelo();
                //    while (reader.Read())
                //    {
                //        string tipoLinea = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader["LIDO_ID"]);

                //        if (tipoLinea == "N")
                //        {
                //            p = new Ventas.odts.DetalleModelo();
                //            p.Linea = Utilidades.UtilsBD.DBValueToRequiredValue<int>(reader["PEDIDL_LINEA"]);
                //            p.Sublinea = Utilidades.UtilsBD.DBValueToRequiredValue<int>(reader["PEDIDL_SUBLINEA"]);
                //            p.ArtiId1 = Utilidades.UtilsBD.DBValueToRequiredValue<int>(reader["ARTI_ID1"]);
                //            p.DetalleDescripcion = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader["PEDIDL_DESCRIPCION"]);
                //            p.Cantidad = Utilidades.UtilsBD.DBValueToRequiredValue<decimal>(reader["PEDIDL_CANTIDAD"]);
                //            p.UnidadId = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader["UNID_ID"]);
                //            p.UnidadDescripcion = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader["UNID_DESCRIPCION"]);
                //            p.Precio = Utilidades.UtilsBD.DBValueToRequiredValue<decimal>(reader["PEDIDL_PRECIO"]);
                //            p.DescuentoId = Utilidades.UtilsBD.DBValueToOptionalValue<int>(reader["GRDE_ID"]);
                //            p.DescuentoDescripcion = Utilidades.UtilsBD.DBValueToOptionalString(reader["GRDE_DESCRIPCION"]);
                //            p.ComportamientoIVA = Utilidades.UtilsBD.DBValueToRequiredValue<int>(reader["COMP_ID"]);
                //            //p.ArtiDeterminaciones = Utilidades.UtilsBD.DBValueToOptionalString(reader["ARTI_DETERMINACIONES"]);
                //            //p.ArtiPNTMetodologia = Utilidades.UtilsBD.DBValueToOptionalString(reader["ARTI_PNT_METODOLOGIA"]);
                //            lista.Add(p);
                //        }
                //        else if (tipoLinea == "N+")
                //        {
                //            odts.DetalleDeterminacion dd = new Ventas.odts.DetalleDeterminacion();
                //            dd.Linea = Utilidades.UtilsBD.DBValueToRequiredValue<int>(reader["PEDIDL_LINEA"]);
                //            dd.Sublinea = Utilidades.UtilsBD.DBValueToRequiredValue<int>(reader["PEDIDL_SUBLINEA"]);
                //            dd.ArtiId1 = Utilidades.UtilsBD.DBValueToRequiredValue<int>(reader["ARTI_ID1"]);
                //            dd.DetalleDescripcion = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader["PEDIDL_DESCRIPCION"]);
                //            dd.Cantidad = Utilidades.UtilsBD.DBValueToRequiredValue<decimal>(reader["PEDIDL_CANTIDAD"]);
                //            dd.UnidadId = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader["UNID_ID"]);
                //            dd.UnidadDescripcion = Utilidades.UtilsBD.DBValueToRequiredValue<string>(reader["UNID_DESCRIPCION"]);
                //            dd.Precio = Utilidades.UtilsBD.DBValueToRequiredValue<decimal>(reader["PEDIDL_PRECIO"]);
                //            dd.DescuentoId = Utilidades.UtilsBD.DBValueToOptionalValue<int>(reader["GRDE_ID"]);
                //            dd.DescuentoDescripcion = Utilidades.UtilsBD.DBValueToOptionalString(reader["GRDE_DESCRIPCION"]);
                //            dd.ComportamientoIVA = Utilidades.UtilsBD.DBValueToRequiredValue<int>(reader["COMP_ID"]);
                //            //dd.ArtiDeterminaciones = Utilidades.UtilsBD.DBValueToOptionalString(reader["ARTI_DETERMINACIONES"]);
                //            //dd.ArtiPNTMetodologia = Utilidades.UtilsBD.DBValueToOptionalString(reader["ARTI_PNT_METODOLOGIA"]);
                //            //lista.Add(p);
                //            p.Determinaciones.Add(dd);
                //        }
                //        else
                //        {
                //            MessageBox.Show("Tipo de línea no contemplado, coméntalo con el responsable del desarrollo");
                //        }
                //    }
                //}
                cn.Close();

            }


            return datos;
        }

        public List<Almacen.odts.ArticuloModelo> GetArticulosModeloByTipoAnalisis(string tipoAnalisis)
        {
            List<Almacen.odts.ArticuloModelo> lista = new List<Almacen.odts.ArticuloModelo>();
            modelos = PedidovDetalleDataCtx.Q2_GET_MODELOS_BY_TIPO_ANALISIS(tipoAnalisis).ToList();
            foreach (Q2_GET_MODELOS_BY_TIPO_ANALISISResult modelo in modelos)
            {
                Almacen.odts.ArticuloModelo m = new Almacen.odts.ArticuloModelo();
                m.ArtiId = modelo.ARTI_ID;
                m.Descripcion = modelo.ARTI_DESCRIPCION;
                m.ArtiId1 = modelo.ARTI_ID1;
                m.EsHibrido = (bool)modelo.ES_HIBRIDO;
                m.ArtiDeterminaciones = modelo.ARTI_DETERMINACIONES;
                m.ArtiMetodologia = modelo.ARTI_PNT_METODOLOGIA;
                m.DepartamentoId = (int)modelo.DEPA_ID;
                if (!lista.Contains(m))
                    lista.Add(m);
            }
            return lista;
        }
        public List<Almacen.odts.ArticuloDeterminacion> GetArticulosDeterminacionByTipoAnalisis(string tipoAnalisis)
        {
            List<Almacen.odts.ArticuloDeterminacion> lista = new List<Almacen.odts.ArticuloDeterminacion>();
            determinaciones = PedidovDetalleDataCtx.Q2_GET_DETERMINACIONES_BY_TIPO_ANALISIS(tipoAnalisis).ToList();
            foreach (Q2_GET_DETERMINACIONES_BY_TIPO_ANALISISResult determinacion in determinaciones)
            {
                Almacen.odts.ArticuloDeterminacion d = new Almacen.odts.ArticuloDeterminacion();
                d.ArtiId = determinacion.ARTI_ID;
                d.Descripcion = determinacion.ARTI_DESCRIPCION;
                d.ArtiId1 = determinacion.ARTI_ID1;
                d.ArtiDeterminaciones = determinacion.ARTI_DETERMINACIONES;
                d.ArtiMetodologia = determinacion.ARTI_PNT_METODOLOGIA;
                d.DepartamentoId = determinacion.DEPA_ID;

                if (!lista.Contains(d))
                    lista.Add(d);
            }
            return lista;
        }
        public List<Almacen.odts.ArticuloDeterminacion> GetArticulosCargoByTipoAnalisis(string tipoAnalisis)
        {
            List<Almacen.odts.ArticuloDeterminacion> lista = new List<Almacen.odts.ArticuloDeterminacion>();
            articulos_cargo = PedidovDetalleDataCtx.Q2_GET_ARTICULOS_CARGO_BY_TIPO_ANALISIS(tipoAnalisis).ToList();
            foreach (Q2_GET_ARTICULOS_CARGO_BY_TIPO_ANALISISResult articulo_cargo in articulos_cargo)
            {
                Almacen.odts.ArticuloDeterminacion d = new Almacen.odts.ArticuloDeterminacion();
                d.ArtiId = articulo_cargo.ARTI_ID;
                d.Descripcion = articulo_cargo.ARTI_DESCRIPCION;
                d.ArtiId1 = articulo_cargo.ARTI_ID1;
                d.ArtiDeterminaciones = string.Empty;
                d.ArtiMetodologia = string.Empty;
                d.TipoArticulo = articulo_cargo.TIPAR_ID;
                d.DepartamentoId = 0;
                if (!lista.Contains(d))
                    lista.Add(d);
            }
            return lista;
        }
        public List<Almacen.odts.ArticuloDeterminacion> GetArticulosCargoServiciosEInformes()
        {
            List<Almacen.odts.ArticuloDeterminacion> lista = new List<Almacen.odts.ArticuloDeterminacion>();
            servicios_informes = PedidovDetalleDataCtx.Q2_GET_ARTICULOS_CARGO_SERVICIOS_E_INFORMES().ToList();
            foreach (Q2_GET_ARTICULOS_CARGO_SERVICIOS_E_INFORMESResult servicio_informe in servicios_informes)
            {
                Almacen.odts.ArticuloDeterminacion d = new Almacen.odts.ArticuloDeterminacion();
                d.ArtiId = servicio_informe.ARTI_ID;
                d.Descripcion = servicio_informe.ARTI_DESCRIPCION;
                d.ArtiId1 = servicio_informe.ARTI_ID1;
                d.ArtiDeterminaciones = string.Empty;
                d.ArtiMetodologia = string.Empty;
                d.TipoArticulo = servicio_informe.TIPAR_ID;
                d.DepartamentoId = 0;
                if (!lista.Contains(d))
                    lista.Add(d);
            }
            return lista;
        }
        public List<odts.PresupuestoVentaBloque> GetBloquesGrupoByCliente(int clieId)
        {
            List<odts.PresupuestoVentaBloque> lista = new List<DocumentosVentas.odts.PresupuestoVentaBloque>();
            bloques = PedidovDetalleDataCtx.Q2_GET_BLOQUES_GRUPO_BY_CLIENTE(clieId).ToList();
            foreach (Q2_GET_BLOQUES_GRUPO_BY_CLIENTEResult bloque in bloques)
            {
                odts.PresupuestoVentaBloque p = new odts.PresupuestoVentaBloque();
                p.DocuId = bloque.DOCU_ID;
                p.PresuvId = bloque.PRESUV_ID;
                p.Estado = bloque.ESTDOC_ID;
                p.BloqueId = bloque.BLOQUE_ID;
                p.FamilId = bloque.FAMIL_ID;
                p.FamilDescripcion = bloque.FAMIL_DESCRIPCION;
                p.Titulo = bloque.TITULO;
                p.FechaCreacion = bloque.FECHA_CREACION;
                p.Cliente = bloque.CLIE_DESCRIPCION;

                lista.Add(p);
            }
            return lista;
        }
        public List<odts.PresupuestoVentaDetalle> GetDetalleByBloque(string docuId, string presuvId, int bloqueId)
        {
            List<odts.PresupuestoVentaDetalle> lista = new List<odts.PresupuestoVentaDetalle>();
            detalles_bloque = PedidovDetalleDataCtx.Q2_GET_DETALLE_BY_BLOQUE(docuId, presuvId, bloqueId).ToList();
            odts.DetalleModelo p = new odts.DetalleModelo();
            foreach (Q2_GET_DETALLE_BY_BLOQUEResult detalle in detalles_bloque)
            {
                string tipoLinea = detalle.LIDO_ID;
                if (tipoLinea == "N")
                {
                    p = new odts.DetalleModelo();
                    p.Linea = detalle.PRESUVL_LINEA;
                    p.Sublinea = detalle.PRESUVL_SUBLINEA;
                    p.ArtiId1 = (int)detalle.ARTI_ID1;
                    p.DetalleDescripcion = detalle.PRESUVL_DESCRIPCION;
                    p.Cantidad = detalle.PRESUVL_CANTIDAD;
                    p.UnidadId = detalle.UNID_ID;
                    p.UnidadDescripcion = detalle.UNID_DESCRIPCION;
                    p.Precio = detalle.PRESUVL_PRECIO;
                    p.DescuentoId = detalle.GRDE_ID;
                    p.DescuentoDescripcion = detalle.GRDE_DESCRIPCION;
                    p.ComportamientoIVA = (int)detalle.COMP_ID;
                    p.ArtiDeterminaciones = detalle.ARTI_DETERMINACIONES;
                    p.ArtiPNTMetodologia = detalle.ARTI_PNT_METODOLOGIA;
                    lista.Add(p);
                }
                else if (tipoLinea == "N+")
                {
                    odts.DetalleDeterminacion dd = new odts.DetalleDeterminacion();
                    dd.Linea = detalle.PRESUVL_LINEA;
                    dd.Sublinea = detalle.PRESUVL_SUBLINEA;
                    dd.ArtiId1 = (int)detalle.ARTI_ID1;
                    dd.DetalleDescripcion = detalle.PRESUVL_DESCRIPCION;
                    dd.Cantidad = detalle.PRESUVL_CANTIDAD;
                    dd.UnidadId = detalle.UNID_ID;
                    dd.UnidadDescripcion = detalle.UNID_DESCRIPCION;
                    dd.Precio = detalle.PRESUVL_PRECIO;
                    dd.DescuentoId = detalle.GRDE_ID;
                    dd.DescuentoDescripcion = detalle.GRDE_DESCRIPCION;
                    dd.ComportamientoIVA = (int)detalle.COMP_ID;
                    dd.ArtiDeterminaciones = detalle.ARTI_DETERMINACIONES;
                    dd.ArtiPNTMetodologia = detalle.ARTI_PNT_METODOLOGIA;
                    p.Determinaciones.Add(dd);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Tipo de línea no contemplado, coméntalo con el responsable del desarrollo");
                }
            }
            return lista;
        }
        public List<odts.DetalleDeterminacion> GetAsociados(int artiId1)
        {
            List<odts.DetalleDeterminacion> lista = new List<DocumentosVentas.odts.DetalleDeterminacion>();
            try
            {

                asociados = PedidovDetalleDataCtx.Q2_GET_ASOCIADOS(artiId1).ToList();
                foreach (Q2_GET_ASOCIADOSResult asociado in asociados)
                {
                    odts.DetalleDeterminacion a = new odts.DetalleDeterminacion();
                    a.DetalleDescripcion = asociado.ARTI_DESCRIPCION;
                    a.ArtiId1 = asociado.ARTI_ID1;
                    a.ArtiDeterminaciones = asociado.ARTI_DETERMINACIONES;
                    a.ArtiPNTMetodologia = asociado.ARTI_PNT_METODOLOGIA;
                    a.DepartamentoId = asociado.DEPA_ID;
                    lista.Add(a);
                }
            }
            catch (System.StackOverflowException ex)
            {
                
            }
            catch (Exception ex)
            {
                
            }

            return lista;
        }
        public void InsertarDetalle(string documento, string numero, odts.PresupuestoVentaDetalle pvd)
        {
            this.PedidovDetalleDataCtx.Q2_PEDIDOSV_LI_INS(documento, numero, pvd.Linea, pvd.Sublinea, pvd.TipoLinea,
                pvd.DetalleDescripcion, pvd.Cantidad, pvd.Precio, pvd.DescuentoId, pvd.Estado, pvd.UnidadId,
                string.Empty, string.Empty, null, null, string.Empty, string.Empty, pvd.ComportamientoIVA,
                pvd.ArtiId1, string.Empty, string.Empty);
        }
        public void InsertarDetalle(DataTable insert)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connectionString))
                {
                    bulkCopy.DestinationTableName = "PEDIDOSV_LI";

                    try
                    {
                        // Write the array of rows to the destination.
                        bulkCopy.WriteToServer(insert);
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message);
                    }
                }
            }        
        }
        public void ActualizarDetalle(DataTable update)
        {
            foreach (DataRow dr in update.Rows)
            {
                string DOCU_ID = dr["DOCU_ID"].ToString();
                string PEDID_ID = dr["PEDID_ID"].ToString();
                int PEDIDL_LINEA = (int)dr["PEDIDL_LINEA"];
                int PEDIDL_SUBLINEA = (int)dr["PEDIDL_SUBLINEA"];
                string LIDO_ID = dr["LIDO_ID"].ToString();
                string PEDIDL_DESCRIPCION = dr["PEDIDL_DESCRIPCION"].ToString();
                decimal PEDIDL_CANTIDAD = (decimal)dr["PEDIDL_CANTIDAD"];
                decimal PEDIDL_PRECIO = (decimal)dr["PEDIDL_PRECIO"];
                int GRDE_ID = (int)dr["GRDE_ID"];
                string ESTDOC_ID = dr["ESTDOC_ID"].ToString();
                string UNID_ID = dr["UNID_ID"].ToString();
                string DOCU_ID_ORIGEN = dr["DOCU_ID_ORIGEN"].ToString();
                string DOCU_NUMERO_ORIGEN = dr["DOCU_NUMERO_ORIGEN"].ToString();
                int DOCU_LINEA_ORIGEN = (int)dr["DOCU_LINEA_ORIGEN"];
                int DOCU_SUBLINEA_ORIGEN = (int)dr["DOCU_SUBLINEA_ORIGEN"];
                string PEDIDL_FLUJOC = dr["PEDIDL_FLUJOC"].ToString();
                string PEDIDL_FLUJOL = dr["PEDIDL_FLUJOL"].ToString();
                int COMP_ID = (int)dr["COMP_ID"];
                int ARTI_ID1 = (int)dr["ARTI_ID1"];
                string PEDIDL_FECHAD_APLIC = dr["PEDIDL_FECHAD_APLIC"].ToString();
                string PEDIDL_FECHAH_APLIC = dr["PEDIDL_FECHAH_APLIC"].ToString();
                PedidovDetalleDataCtx.Q2_PEDIDOSV_LI_UPD(DOCU_ID, PEDID_ID, PEDIDL_LINEA, PEDIDL_SUBLINEA, LIDO_ID, PEDIDL_DESCRIPCION, PEDIDL_CANTIDAD,
                    PEDIDL_PRECIO, GRDE_ID, ESTDOC_ID, UNID_ID, DOCU_ID_ORIGEN, DOCU_NUMERO_ORIGEN, DOCU_LINEA_ORIGEN, DOCU_SUBLINEA_ORIGEN,
                    PEDIDL_FLUJOC, PEDIDL_FLUJOL, COMP_ID, ARTI_ID1, PEDIDL_FECHAD_APLIC, PEDIDL_FECHAH_APLIC);

            }
        }
        public void EliminarDetalle(DataTable delete)
        {
            foreach (DataRow dr in delete.Rows)
            {
                string DOCU_ID = dr["DOCU_ID"].ToString();
                string PEDID_ID = dr["PEDID_ID"].ToString();
                int PEDIDL_LINEA = (int)dr["PEDIDL_LINEA"];
                int PEDIDL_SUBLINEA = (int)dr["PEDIDL_SUBLINEA"];

                PedidovDetalleDataCtx.Q2_ELIMINAR_DETALLE(DOCU_ID, PEDID_ID, PEDIDL_LINEA, PEDIDL_SUBLINEA);
            }

        }
        public void EliminarDetalleFondo(DataTable delete)
        {
            foreach (DataRow dr in delete.Rows)
            {
                string DOCU_ACTA_ID = dr["DOCU_ACTA_ID"].ToString();
                string PEDID_ID = dr["PEDID_ID"].ToString();
                int PEDIDL_LINEA = (int)dr["PEDIDL_LINEA"];
                int PEDIDL_SUBLINEA = (int)dr["PEDIDL_SUBLINEA"];

                PedidovDetalleDataCtx.Q2_ELIMINAR_DETALLE_FONDO(DOCU_ACTA_ID, PEDID_ID, PEDIDL_LINEA, PEDIDL_SUBLINEA);
            }
        }
        public void PedidoActualizaEstado(string documento, string numero, string estado)
        {
            PedidovDetalleDataCtx.Q2_PEDIDO_ACTUALIZAR_ESTADO(estado, documento, numero);
        }
        public void GuardarEstado(string documento, string numero, string estado, string usuario)
        {
            PedidovDetalleDataCtx.DOCUMENTO_ESTADO_INS(usuario, documento, numero, estado, "", "U");
        }
        public void InsertarPlantillaDetalle(string pedid_origen, string pedid_destino)
        {
            List<Q2_PEDIDOSV_LI_SELResult> lista = PedidovDetalleDataCtx.Q2_PEDIDOSV_LI_SEL(pedid_origen).ToList();
            foreach (Q2_PEDIDOSV_LI_SELResult linea in lista)
            {
                PedidovDetalleDataCtx.Q2_PEDIDOSV_LI_INS(linea.DOCU_ID, pedid_destino, linea.PEDIDL_LINEA, linea.PEDIDL_SUBLINEA, linea.LIDO_ID,
                    linea.PEDIDL_DESCRIPCION, linea.PEDIDL_CANTIDAD, linea.PEDIDL_PRECIO, linea.GRDE_ID, linea.ESTDOC_ID, linea.UNID_ID, null,
                    null, null, null, linea.PEDIDL_FLUJOC, linea.PEDIDL_FLUJOL, linea.COMP_ID, linea.ARTI_ID1, linea.PEDIDL_FECHAD_APLIC,
                    linea.PEDIDL_FECHAH_APLIC);
            }
        }

        public object[] GetPrecioArticuloByCliente(int artiId1, int clieId, string docuId, string usu_id)
        {
            object[] precio = new object[2];

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    @"CLIENTES_COND_PRECIO2", cn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TIPO", 0);
                cmd.Parameters.AddWithValue("@USUARIO", usu_id);
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
        public void GetPrecioArticuloByCliente(odts.PresupuestoVentaDetalle detalle, int artiId1, int clieId, string docuId, string usu_id)
        {

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    @"CLIENTES_COND_PRECIO2", cn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TIPO", 0);
                cmd.Parameters.AddWithValue("@USUARIO", usu_id);
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
    }
}
