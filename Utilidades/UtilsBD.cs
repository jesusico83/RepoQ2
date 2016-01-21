using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Reflection;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Configuration;

namespace Utilidades
{
    public class UtilsBD
    {
        public static string[] DiasSemana = { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo" };

        //La versión que se usa cuando el campo es requerido:
        public static T DBValueToRequiredValue<T>(object value)
        {
            if (value == DBNull.Value)
            {
                //Esta función exige que haya un valor.
                throw new ArgumentNullException();
            }
            return (T)value;
        }
        //La versión que se usa cuando el campo es opcional:
        public static Nullable<T> DBValueToOptionalValue<T>(object value)
            where T : struct
        {
            if (value == DBNull.Value)
            {
                //Esta vez no importa.
                return null;
            }
            return (T)value;
        }

        public static string DBValueToOptionalString(object value)
        {
            if (value == DBNull.Value)
            {
                return null;
            }
            return value.ToString();
        }


        public static string DBValueToOptionalFecha(object value)
        {
            if (value == DBNull.Value || value == null)
            {
                return null;
            }
            return FechaDBToFecha(value.ToString());
        }

        public static string DBValueToRequiredFecha(object value)
        {
            if (value == DBNull.Value)
            {
                //Esta función exige que haya un valor.
                throw new ArgumentNullException();
            }
            return FechaDBToFecha(value.ToString());
        }

        private static string FechaDBToFecha(string fecha)
        {
            if (fecha != null && fecha != "" && fecha.Length == 10)
            {
                string anyo = fecha.Substring(0, 4);
                string mes = fecha.Substring(5, 2);
                string dia = fecha.Substring(8, 2);

                return dia + "/" + mes + "/" + anyo;
            }
            return "";
        }

        public static string DecimalToMonedaString(decimal cantidad)
        {
            return cantidad.ToString("N");
        }


        public static string DecimalToMonedaString(decimal cantidad, int decimales)
        {
            string formato = "N" + decimales.ToString();
            return cantidad.ToString(formato);
        }


        // Devuelve una tabla de Ordenes sin flujo a sus RLAB de origen
        public static DataTable BuscarOrdenesHuerfanas(string conexion)
        {
            DataTable Ordenes = new DataTable();
            Ordenes.Columns.Add("DOCU_ID", typeof(string));
            Ordenes.Columns.Add("ORDEN_ID", typeof(string));

            using (SqlConnection cn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand(
                    @"SELECT A.DOCU_ID, A.ORDEN_ID
                      FROM ORDENTRABAJO A
                      LEFT OUTER JOIN FLUJODOCUMENTOSC B ON B.DOCU_ID = A.DOCU_ID AND B.NUMERO = A.ORDEN_ID
                      WHERE B.DOCU_ID IS NULL AND A.DOCU_ID_ORIGEN <> '' ", cn);
                cmd.CommandType = System.Data.CommandType.Text;

                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Ordenes.Rows.Add(new object[] { reader[0].ToString(), reader[1].ToString() });
                    }
                }
                cn.Close();

            }

            return Ordenes;
        }
        
        // Inserta el enlace entre las ordenes huerfanas y sus registros de origen
        public static void EnlazaOrdenesYRegistros(string conexion)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO FLUJODOCUMENTOSC
                    SELECT A.DOCU_ID, A.ORDEN_ID, A.DOCU_ID_ORIGEN, A.DOCU_NUMERO_ORIGEN, '1'
                    FROM ORDENTRABAJO A
                    LEFT OUTER JOIN FLUJODOCUMENTOSC B ON B.DOCU_ID = A.DOCU_ID AND B.NUMERO = A.ORDEN_ID
                    WHERE B.DOCU_ID IS NULL AND A.DOCU_ID_ORIGEN <> '' ", cn);
                cmd.CommandType = System.Data.CommandType.Text;


                cn.Open();
                if (cmd.ExecuteNonQuery() <= 0)
                {
                    MessageBox.Show("Error al enlazar las ordenes con sus registros de origen");
                }
                cn.Close();
            }
        }

        // Inserta el enlace entre las ordenes huerfanas y sus registros de origen
        public static void EnlazaOrdenesYRegistros(string docuId, string ordenId)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["conexionQ"]))
            {
                SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO FLUJODOCUMENTOSC
                    SELECT A.DOCU_ID, A.ORDEN_ID, A.DOCU_ID_ORIGEN, A.DOCU_NUMERO_ORIGEN, '1'
                    FROM ORDENTRABAJO A
                    LEFT OUTER JOIN FLUJODOCUMENTOSC B ON B.DOCU_ID = A.DOCU_ID AND B.NUMERO = A.ORDEN_ID
                    WHERE A.DOCU_ID = @DOCU_ID AND A.ORDEN_ID = @ORDEN_ID ", cn);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@DOCU_ID", docuId);
                cmd.Parameters.AddWithValue("@ORDEN_ID", ordenId);


                cn.Open();
                if (cmd.ExecuteNonQuery() <= 0)
                {
                    MessageBox.Show(string.Format("Error al enlazar la orden {0} con sus registros de origen", ordenId));
                }
                cn.Close();
            }
        }

        // Devuelve una lista de RLAB en estado N que no tienen Ordenes creadas
        public static DataTable RLabNSinOrdenes(string conexion)
        {
            DataTable Registros = new DataTable();
            Registros.Columns.Add("DOCU_ID", typeof(string));
            Registros.Columns.Add("REGLAB_ID", typeof(string));

            using (SqlConnection cn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand(
                    @"SELECT A.DOCU_ID, A.REGLAB_ID
                    FROM REGISTROLAB A
                    LEFT OUTER JOIN ORDENTRABAJO B on B.DOCU_ID_ORIGEN = A.DOCU_ID AND B.DOCU_NUMERO_ORIGEN = A.REGLAB_ID
                    WHERE A.ESTDOC_ID = 'N' AND B.DOCU_ID IS NULL ", cn);
                cmd.CommandType = System.Data.CommandType.Text;

                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Registros.Rows.Add(new object[] { reader[0].ToString(), reader[1].ToString() });
                    }
                }
                cn.Close();
            }

            return Registros;
        }

        public static void RepararPropiedades1(string conexion, string docuId, string ordenId, int clieId, string artiId, string fecha, int depaId)
        {

            try
            {


                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    SqlCommand cmd = new SqlCommand(
                        @"ORDENTRABAJO_LIP_ACTUALIZAR ", cn);
                    // @DOCU_ID,@ORDEN_ID,@CLIE_ID,@ARTI_ID,@ORDEN_FECHA,@DEPA_ID
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DOCU_ID", docuId);
                    cmd.Parameters.AddWithValue("@ORDEN_ID", ordenId);
                    cmd.Parameters.AddWithValue("@CLIE_ID", clieId);
                    cmd.Parameters.AddWithValue("@ARTI_ID", artiId);
                    cmd.Parameters.AddWithValue("@FECHA", fecha);
                    cmd.Parameters.AddWithValue("@DEPA_ID", depaId);

                    cn.Open();

                    cmd.ExecuteNonQuery();

                    cn.Close();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void RepararPropiedades2(string conexion, string docuId, string ordenId, int clieId, string artiId, string fecha, int depaId)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    SqlCommand cmd = new SqlCommand(
                            @"ORDENTRABAJO_LIP_ACTUALIZAR4 ", cn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DOCU_ID", docuId);
                    cmd.Parameters.AddWithValue("@ORDEN_ID", ordenId);
                    cmd.Parameters.AddWithValue("@CLIE_ID", clieId);
                    cmd.Parameters.AddWithValue("@ARTI_ID", artiId);
                    cmd.Parameters.AddWithValue("@FECHA", fecha);
                    cmd.Parameters.AddWithValue("@DEPA_ID", depaId);

                    cn.Open();

                    cmd.ExecuteNonQuery();

                    cn.Close();
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void RepararProcesos(string conexion, string docuId, string ordenId)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    SqlCommand cmd1 = new SqlCommand(
                                @"ORDENTRABAJO_LI_LIPROC_INS ", cn);
                    cmd1.CommandType = CommandType.StoredProcedure;

                    cmd1.Parameters.AddWithValue("@DOCU_ID", docuId);
                    cmd1.Parameters.AddWithValue("@ORDEN_ID", ordenId);

                    cn.Open();

                    cmd1.ExecuteNonQuery();

                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Elimina las propiedades generadas para una orden de trabajo (tabla ORDENTRABAJO_LIP)
        public static void ResetPropiedades(string conexion, string docuId, string ordenId)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    SqlCommand cmd1 = new SqlCommand(
                                @"DELETE ORDENTRABAJO_LIP
                                  WHERE DOCU_ID = @DOCU_ID AND ORDEN_ID = @ORDEN_ID", cn);
                    cmd1.CommandType = CommandType.Text;

                    cmd1.Parameters.AddWithValue("@DOCU_ID", docuId);
                    cmd1.Parameters.AddWithValue("@ORDEN_ID", ordenId);

                    cn.Open();

                    cmd1.ExecuteNonQuery();

                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void GenerateExcel(DataTable dt/*, string excelSheetName*/)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
            // Add column headings...
            int iCol = 0;
            foreach (DataColumn c in dt.Columns)
            {
                iCol++;
                excel.Cells[1, iCol] = c.ColumnName;
            }
            // for each row of data...
            int iRow = 0;
            foreach (DataRow r in dt.Rows)
            {
                iRow++;
                // add each row's cell data...
                iCol = 0;
                foreach (DataColumn c in dt.Columns)
                {
                    iCol++;
                    excel.Cells[iRow + 1, iCol] = r[c.ColumnName];
                }
            }
           
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.Filter = "Fichero Excel (*.xlsx, *.xls)|*.xlsx;*.xls";
            saveFileDialog1.Title = "Exportar fichero a Excel";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName != string.Empty)
            {
                // Global missing reference for objects we are not defining...
                object missing = System.Reflection.Missing.Value;
                // If wanting to Save the workbook...
                //workbook.SaveAs(excelSheetName,
                workbook.SaveAs(saveFileDialog1.FileName,
                Microsoft.Office.Interop.Excel.XlFileFormat.xlXMLSpreadsheet, missing, missing,
                false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                missing, missing, missing, missing, missing);
                // If wanting to make Excel visible and activate the worksheet...
                excel.Visible = true;
                Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)excel.ActiveSheet;
                ((Microsoft.Office.Interop.Excel._Worksheet)worksheet).Activate();
                // If wanting excel to shutdown...

                //((Microsoft.Office.Interop.Excel._Application)excel).Quit();
                //MessageBox.Show("Archivo exportado a " + saveFileDialog1.FileName , "Exportado");
            }

        }


        public static void GenerateExcel(DataTable dt, string excelSheetName)
        {
            excelSheetName = Regex.Replace(excelSheetName, @"[^\w\s@-]", "");

            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
            // Add column headings...
            int iCol = 0;
            foreach (DataColumn c in dt.Columns)
            {
                iCol++;
                excel.Cells[1, iCol] = c.ColumnName;
            }
            // for each row of data...
            int iRow = 0;
            foreach (DataRow r in dt.Rows)
            {
                iRow++;
                // add each row's cell data...
                iCol = 0;
                foreach (DataColumn c in dt.Columns)
                {
                    iCol++;
                    excel.Cells[iRow + 1, iCol] = r[c.ColumnName];
                }
            }
            
            
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = excelSheetName;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.Filter = "Fichero Excel (*.xlsx, *.xls)|*.xlsx;*.xls";
            saveFileDialog1.Title = "Exportar fichero a Excel";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName != string.Empty)
            {
                // Global missing reference for objects we are not defining...
                object missing = System.Reflection.Missing.Value;
                // If wanting to Save the workbook...
                //workbook.SaveAs(excelSheetName,
                workbook.SaveAs(saveFileDialog1.FileName,
                Microsoft.Office.Interop.Excel.XlFileFormat.xlXMLSpreadsheet, missing, missing,
                false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                missing, missing, missing, missing, missing);
                // If wanting to make Excel visible and activate the worksheet...
                excel.Visible = true;
                Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)excel.ActiveSheet;
                ((Microsoft.Office.Interop.Excel._Worksheet)worksheet).Activate();
                // If wanting excel to shutdown...

                //((Microsoft.Office.Interop.Excel._Application)excel).Quit();
                //MessageBox.Show("Archivo exportado a " + saveFileDialog1.FileName + " !!", "Exportado");
            }

        }

        public static void GenerateExcel(List<object> lista, string excelSheetName)
        {

            excelSheetName = Regex.Replace(excelSheetName, @"[^\w\s@-]", "");
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
            // Add column headings...
            int iCol = 0;

            if (lista.Count > 0)
            {
                object o = lista[0];
                PropertyInfo[] pinfo = o.GetType().GetProperties();
                foreach (PropertyInfo p in pinfo)
                {
                    iCol++;
                    excel.Cells[1, iCol] = p.Name;
                }
            }
           
            int iRow = 0;
            foreach (object r in lista)
            {
                iRow++;
                // add each row's cell data...
                iCol = 0;
                PropertyInfo[] pinfo = r.GetType().GetProperties();
                foreach (PropertyInfo p in pinfo)
                {
                    iCol++;
                    excel.Cells[iRow + 1, iCol] = p.GetValue(r,null);
                }
            }
            
            
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = excelSheetName;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.Filter = "Fichero Excel (*.xlsx, *.xls)|*.xlsx;*.xls";
            saveFileDialog1.Title = "Exportar fichero a Excel";
            

            if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName != string.Empty)
            {
                // Global missing reference for objects we are not defining...
                object missing = System.Reflection.Missing.Value;
                // If wanting to Save the workbook...
                //workbook.SaveAs(excelSheetName,
                workbook.SaveAs(saveFileDialog1.FileName,
                Microsoft.Office.Interop.Excel.XlFileFormat.xlXMLSpreadsheet, missing, missing,
                false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                missing, missing, missing, missing, missing);
                // If wanting to make Excel visible and activate the worksheet...
                excel.Visible = true;
                Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)excel.ActiveSheet;
                ((Microsoft.Office.Interop.Excel._Worksheet)worksheet).Activate();
                // If wanting excel to shutdown...

                //((Microsoft.Office.Interop.Excel._Application)excel).Quit();
                //MessageBox.Show("Archivo exportado a " + saveFileDialog1.FileName + " !!", "Exportado");
            }

        }



        public static void GenerateExcel(BrightIdeasSoftware.ObjectListView olv, string excelSheetName)
        {
            excelSheetName = Regex.Replace(excelSheetName, @"[^\w\s@-]", "");


            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Application.Workbooks.Add(true);

            // Add column headings...
            int iCol = 0;

                foreach (BrightIdeasSoftware.OLVColumn c in olv.ColumnsInDisplayOrder)
                {
                    iCol++;
                    excel.Cells[1, iCol] = c.Text;
                }

            int iRow = 0;

            foreach (object r in olv.FilteredObjects)
            {
                iRow++;
                // add each row's cell data...
                iCol = 0;
                foreach (BrightIdeasSoftware.OLVColumn c in olv.ColumnsInDisplayOrder)
                {
                    iCol++;
                    if (r.GetType() == typeof(DataRowView))
                    {
                        excel.Cells[iRow + 1, iCol] = ((DataRowView)r).Row[c.AspectName];
                    }
                    else
                    {
                        PropertyInfo pinfo = r.GetType().GetProperty(c.AspectName);
                        excel.Cells[iRow + 1, iCol] = pinfo.GetValue(r, null);
                    }
                }
            }

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = excelSheetName;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.Filter = "Fichero Excel (*.xlsx, *.xls)|*.xlsx;*.xls";
            saveFileDialog1.Title = "Exportar fichero a Excel";
            

            if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName != string.Empty)
            {
                // Global missing reference for objects we are not defining...
                object missing = System.Reflection.Missing.Value;
                // If wanting to Save the workbook...
                //workbook.SaveAs(excelSheetName,
                workbook.SaveAs(saveFileDialog1.FileName,
                    //Microsoft.Office.Interop.Excel.XlFileFormat.xlXMLSpreadsheet, missing, missing,
                    Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook, missing, missing,
                    false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                    missing, missing, missing, missing, missing);
                // If wanting to make Excel visible and activate the worksheet...
                excel.Visible = true;
                Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)excel.ActiveSheet;
                ((Microsoft.Office.Interop.Excel._Worksheet)worksheet).Activate();
                // If wanting excel to shutdown...

                //((Microsoft.Office.Interop.Excel._Application)excel).Quit();
                //MessageBox.Show("Archivo exportado a " + saveFileDialog1.FileName + " !!", "Exportado");
            }
        }

        /// <summary>
        /// Generar excel con título y Pie de Página
        /// </summary>
        /// <param name="olv"></param>
        /// <param name="excelSheetName"></param>
        /// <param name="titulo"></param>
        /// <param name="pie"></param>
        public static void GenerateExcel(BrightIdeasSoftware.ObjectListView olv, string excelSheetName, string titulo, string pie)
        {
            excelSheetName = Regex.Replace(excelSheetName, @"[^\w\s@-]", "");

            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
            Microsoft.Office.Interop.Excel.Range rangeT;
            Microsoft.Office.Interop.Excel.Range rangeP;
            // Add column headings...
            int iCol = 0;

            foreach (BrightIdeasSoftware.OLVColumn c in olv.ColumnsInDisplayOrder)
            {
                iCol++;
                excel.Cells[2, iCol] = c.Text;
            }

            int iRow = 1;

            foreach (object r in olv.FilteredObjects)
            {
                iRow++;
                // add each row's cell data...
                iCol = 0;
                foreach (BrightIdeasSoftware.OLVColumn c in olv.ColumnsInDisplayOrder)
                {
                    iCol++;
                    if (r.GetType() == typeof(DataRowView))
                    {

                        excel.Cells[iRow + 1, iCol] = ((DataRowView)r).Row[c.AspectName];
                    }
                    else
                    {
                        PropertyInfo pinfo = r.GetType().GetProperty(c.AspectName);
                        excel.Cells[iRow + 1, iCol] = pinfo.GetValue(r, null);
                    }
                }
            }

            // Añadir titulo y pie
            excel.Cells[1, 1] = titulo;

            // Combinar celdas
            rangeT = excel.get_Range(excel.Cells[1, 1], excel.Cells[1, iCol]);
            rangeT.Merge(true);
            rangeT.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            rangeT.EntireRow.Font.Bold = true;
            rangeT.EntireRow.Font.Size = 20;
            // No combinar la última celda si el pie es cadena vacía
            if (!pie.Equals(string.Empty))
            {
                excel.Cells[iRow + 2, 1] = pie;
                rangeP = excel.get_Range(excel.Cells[iRow + 2, 1], excel.Cells[iRow + 2, iCol]);
                rangeP.Merge(true);
                rangeP.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                rangeP.EntireRow.Font.Bold = true;
                rangeP.EntireRow.Font.Size = 16;
            }

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = excelSheetName;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.Filter = "Fichero Excel (*.xlsx, *.xls)|*.xlsx;*.xls";
            saveFileDialog1.Title = "Exportar fichero a Excel";


            if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName != string.Empty)
            {
                // Global missing reference for objects we are not defining...
                object missing = System.Reflection.Missing.Value;
                // If wanting to Save the workbook...
                //workbook.SaveAs(excelSheetName,
                workbook.SaveAs(saveFileDialog1.FileName,
                    //Microsoft.Office.Interop.Excel.XlFileFormat.xlXMLSpreadsheet, missing, missing,
                    Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook, missing, missing,
                    false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                    missing, missing, missing, missing, missing);
                // If wanting to make Excel visible and activate the worksheet...
                excel.Visible = true;
                Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)excel.ActiveSheet;
                ((Microsoft.Office.Interop.Excel._Worksheet)worksheet).Activate();
                // If wanting excel to shutdown...

                //((Microsoft.Office.Interop.Excel._Application)excel).Quit();
                //MessageBox.Show("Archivo exportado a " + saveFileDialog1.FileName + " !!", "Exportado");
            }
        }


        public static string RemoveDiacriticos(string text)
        {
            if (text == null) return string.Empty;
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }


        public static string Short2DiaSemana(short dia)
        {
            if (dia >= 0 && dia < 7)
                return DiasSemana[dia];
            else
                return "Error";
        }
    }
}
