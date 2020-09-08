using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace Uptook
{
    class Exportar
    {
        public void ExportarDatagridExcel(DataGridView dtg)
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                fichero.FileName = "ArchvioExportado";

                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application application;
                    Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                    Microsoft.Office.Interop.Excel._Worksheet hoja_trabajo;
                    application = new Microsoft.Office.Interop.Excel.Application();
                    libros_trabajo = application.Workbooks.Add();

                    hoja_trabajo = (Microsoft.Office.Interop.Excel._Worksheet)libros_trabajo.Worksheets.get_Item(1);

                    //Recorremos el datagridview rellenando la hoja de trabajo
                    for (int i = 0; i < dtg.Rows.Count; i++)
                    {
                        for (int j = 0; j < dtg.Columns.Count; j++)
                        {
                            if ((dtg.Rows[i].Cells[j].Value == null) == false)
                            {
                                hoja_trabajo.Cells[i + 1, j + 1] = dtg.Rows[i].Cells[j].Value.ToString();
                                hoja_trabajo.Columns.NumberFormat = "@";
                            }
                        }
                    }
                    libros_trabajo.SaveAs(fichero.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                    libros_trabajo.Close(true);
                    application.Quit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar la información debido a :" + ex.ToString());
            }


        }
    }
}
