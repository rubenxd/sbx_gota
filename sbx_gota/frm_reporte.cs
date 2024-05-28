using sbx_gota.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sbx_gota
{
    public partial class frm_reporte : Form
    {
        cls_reportes cls_Reportes = new cls_reportes();
        DataTable dt;
        public frm_reporte()
        {
            InitializeComponent();
        }

        private void frm_reporte_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_consultar_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            cls_Reportes.v_buscar = txt_buscar.Text;
            dt = cls_Reportes.mtd_consultar_reporte2();
            int idcc = 0;
            int idnumc = 0;
            int contador = 0;
            double abono = 0;
            foreach (DataRow rows in dt.Rows)
            {
                if (contador==0)
                {
                    idcc = Convert.ToInt32(rows["Id"]);
                    idnumc = Convert.ToInt32(rows["NumeroCuota"]);
                    abono = Convert.ToDouble(rows["ValorAbono"]);
                    contador++;
                }
                else
                {
                    if (idcc == Convert.ToInt32(rows["Id"]))
                    {
                        if (idnumc == Convert.ToInt32(rows["NumeroCuota"]))
                        {

                            rows["VlrCuota"] = Convert.ToDouble(rows["VlrCuota"]) - abono;
                            abono = Convert.ToDouble(rows["ValorAbono"]);
                            rows["Saldo"] = Convert.ToDouble(rows["VlrCuota"]) - abono;
                            idcc = Convert.ToInt32(rows["Id"]);
                            idnumc = Convert.ToInt32(rows["NumeroCuota"]);
                            abono = Convert.ToDouble(rows["ValorAbono"]);
                        }
                        else
                        {
                            idcc = Convert.ToInt32(rows["Id"]);
                            idnumc = Convert.ToInt32(rows["NumeroCuota"]);
                            abono = Convert.ToDouble(rows["ValorAbono"]);
                        }
                    }
                    else
                    {
                        idcc = Convert.ToInt32(rows["Id"]);
                        idnumc = Convert.ToInt32(rows["NumeroCuota"]);
                        abono = Convert.ToDouble(rows["ValorAbono"]);
                    }
                }
            }
            CambiarTipoDeColumna(dt, "VlrCuota", typeof(string));
            CambiarTipoDeColumna(dt, "ValorAbono", typeof(string));
            CambiarTipoDeColumna(dt, "Saldo", typeof(string));
            double VlrCuota = 0;
            double ValorAbono = 0;
            double Saldo = 0;
            foreach (DataRow item in dt.Rows)
            {
                VlrCuota = Convert.ToDouble(item["VlrCuota"]);
                item["VlrCuota"] = VlrCuota.ToString("N0");
                ValorAbono = Convert.ToDouble(item["ValorAbono"]);
                item["ValorAbono"] = ValorAbono.ToString("N0");
                Saldo = Convert.ToDouble(item["Saldo"]);
                item["Saldo"] = Saldo.ToString("N0");
            }
            int idCuentaCobro = 0;
            double TotalPrestamos = 0;
            double TotalAbonos = 0;
            double TotalGanancias = 0;
            double TotalGananciasxPersona = 0;
            double TotalIntereses = 0;
            double TotalSaldoPendiente = 0;
            foreach (DataRow rows in dt.Rows)
            {

                if (idCuentaCobro == 0)
                {
                    TotalPrestamos = Convert.ToDouble(rows["MontoPrestamo"]);
                    TotalIntereses = Convert.ToDouble(rows["ValorInteres"]);
                    idCuentaCobro = Convert.ToInt32(rows["Id"]);
                }
                else if (idCuentaCobro != Convert.ToInt32(rows["Id"]))
                {
                    TotalPrestamos += Convert.ToDouble(rows["MontoPrestamo"]);
                    TotalIntereses += Convert.ToDouble(rows["ValorInteres"]);
                    idCuentaCobro = Convert.ToInt32(rows["Id"]);
                }
              
                TotalAbonos += Convert.ToDouble(rows["ValorAbono"]);
                TotalGanancias += Convert.ToDouble(rows["Ganancia"]);
                TotalGananciasxPersona += Convert.ToDouble(rows["GananciaXPersona"]);
            }
            TotalSaldoPendiente = (TotalPrestamos + TotalIntereses) - TotalAbonos;
            lbl_t_p.Text = TotalPrestamos.ToString("N0");
            lbl_t_in.Text = TotalIntereses.ToString("N0");
            lbl_t_ab.Text = TotalAbonos.ToString("N0");
            lbl_tga.Text = TotalGanancias.ToString("N0");
            lbl_tgxp.Text = TotalGananciasxPersona.ToString("N0");
            lbl_t_s_p.Text = TotalSaldoPendiente.ToString("N0");

            dtg_reportes.DataSource = dt;
        }

        static void CambiarTipoDeColumna(DataTable table, string columnName, Type newType)
        {          
            // Crear una nueva columna con el tipo de datos deseado
            DataColumn newColumn = new DataColumn(columnName + "_new", newType);

            // Agregar la nueva columna al DataTable
            table.Columns.Add(newColumn);

            // Copiar los datos de la columna antigua a la nueva columna con la conversión necesaria
            foreach (DataRow row in table.Rows)
            {
                row[newColumn] = Convert.ChangeType(row[columnName], newType);
            }

            // Obtener el índice de la columna antigua
            int columnIndex = table.Columns[columnName].Ordinal;

            // Eliminar la columna antigua
            table.Columns.Remove(columnName);

            // Renombrar la nueva columna para que tenga el nombre de la columna original
            newColumn.ColumnName = columnName;

            // Opcional: Mover la nueva columna a la posición de la columna antigua
            newColumn.SetOrdinal(columnIndex);
        }

        private void txt_buscar_KeyUp(object sender, KeyEventArgs e)
        {
            dt = new DataTable();
            cls_Reportes.v_buscar = txt_buscar.Text;
            dt = cls_Reportes.mtd_consultar_reporte2();
            int idcc = 0;
            int idnumc = 0;
            int contador = 0;
            double abono = 0;
            foreach (DataRow rows in dt.Rows)
            {
                if (contador == 0)
                {
                    idcc = Convert.ToInt32(rows["Id"]);
                    idnumc = Convert.ToInt32(rows["NumeroCuota"]);
                    abono = Convert.ToDouble(rows["ValorAbono"]);
                    contador++;
                }
                else
                {
                    if (idcc == Convert.ToInt32(rows["Id"]))
                    {
                        if (idnumc == Convert.ToInt32(rows["NumeroCuota"]))
                        {

                            rows["VlrCuota"] = Convert.ToDouble(rows["VlrCuota"]) - abono;
                            abono = Convert.ToDouble(rows["ValorAbono"]);
                            rows["Saldo"] = Convert.ToDouble(rows["VlrCuota"]) - abono;
                            idcc = Convert.ToInt32(rows["Id"]);
                            idnumc = Convert.ToInt32(rows["NumeroCuota"]);
                            abono = Convert.ToDouble(rows["ValorAbono"]);
                        }
                        else
                        {
                            idcc = Convert.ToInt32(rows["Id"]);
                            idnumc = Convert.ToInt32(rows["NumeroCuota"]);
                            abono = Convert.ToDouble(rows["ValorAbono"]);
                        }
                    }
                    else
                    {
                        idcc = Convert.ToInt32(rows["Id"]);
                        idnumc = Convert.ToInt32(rows["NumeroCuota"]);
                        abono = Convert.ToDouble(rows["ValorAbono"]);
                    }
                }
            }
            CambiarTipoDeColumna(dt, "VlrCuota", typeof(string));
            CambiarTipoDeColumna(dt, "ValorAbono", typeof(string));
            CambiarTipoDeColumna(dt, "Saldo", typeof(string));
            double VlrCuota = 0;
            double ValorAbono = 0;
            double Saldo = 0;
            foreach (DataRow item in dt.Rows)
            {
                VlrCuota = Convert.ToDouble(item["VlrCuota"]);
                item["VlrCuota"] = VlrCuota.ToString("N0");
                ValorAbono = Convert.ToDouble(item["ValorAbono"]);
                item["ValorAbono"] = ValorAbono.ToString("N0");
                Saldo = Convert.ToDouble(item["Saldo"]);
                item["Saldo"] = Saldo.ToString("N0");
            }
            int idCuentaCobro = 0;
            double TotalPrestamos = 0;
            double TotalAbonos = 0;
            double TotalGanancias = 0;
            double TotalGananciasxPersona = 0;
            double TotalIntereses = 0;
            double TotalSaldoPendiente = 0;
            foreach (DataRow rows in dt.Rows)
            {

                if (idCuentaCobro == 0)
                {
                    TotalPrestamos = Convert.ToDouble(rows["MontoPrestamo"]);
                    TotalIntereses = Convert.ToDouble(rows["ValorInteres"]);
                    idCuentaCobro = Convert.ToInt32(rows["Id"]);
                }
                else if (idCuentaCobro != Convert.ToInt32(rows["Id"]))
                {
                    TotalPrestamos += Convert.ToDouble(rows["MontoPrestamo"]);
                    TotalIntereses += Convert.ToDouble(rows["ValorInteres"]);
                    idCuentaCobro = Convert.ToInt32(rows["Id"]);
                }

                TotalAbonos += Convert.ToDouble(rows["ValorAbono"]);
                TotalGanancias += Convert.ToDouble(rows["Ganancia"]);
                TotalGananciasxPersona += Convert.ToDouble(rows["GananciaXPersona"]);
            }
            TotalSaldoPendiente = (TotalPrestamos + TotalIntereses) - TotalAbonos;
            lbl_t_p.Text = TotalPrestamos.ToString("N0");
            lbl_t_in.Text = TotalIntereses.ToString("N0");
            lbl_t_ab.Text = TotalAbonos.ToString("N0");
            lbl_tga.Text = TotalGanancias.ToString("N0");
            lbl_tgxp.Text = TotalGananciasxPersona.ToString("N0");
            lbl_t_s_p.Text = TotalSaldoPendiente.ToString("N0");

            dtg_reportes.DataSource = dt;
        }
    }
}
