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
            dt = new DataTable();
            cls_Reportes.v_buscar = txt_buscar.Text;
            dt = cls_Reportes.mtd_consultar_reporte();

            double TotalPrestamos = 0;
            double TotalAbonos = 0;
            double TotalGanancias = 0;
            double TotalGananciasxPersona = 0;
            double TotalIntereses = 0;
            double TotalSaldoPendiente = 0;
            int contador = 0;
            foreach (DataRow rows in dt.Rows)
            {
                if (contador == 0)
                {
                    TotalPrestamos = Convert.ToDouble(rows["MontoPrestamoReal"]);
                    TotalIntereses = Convert.ToDouble(rows["ValorInteresesReal"]);
                    TotalSaldoPendiente = Convert.ToDouble(rows["Saldo"]);
                }
                TotalAbonos += Convert.ToDouble(rows["ValorAbono"]);
                TotalGanancias += Convert.ToDouble(rows["Ganancia"]);
                TotalGananciasxPersona += Convert.ToDouble(rows["GananciaXPersona"]);
                contador++;
            }
            lbl_t_p.Text = TotalPrestamos.ToString("N0");
            lbl_t_in.Text = TotalIntereses.ToString("N0");
            lbl_t_ab.Text = TotalAbonos.ToString("N0");
            lbl_tga.Text = TotalGanancias.ToString("N0");
            lbl_tgxp.Text = TotalGananciasxPersona.ToString("N0");
            lbl_t_s_p.Text = TotalSaldoPendiente.ToString("N0");
        }

        private void btn_consultar_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            cls_Reportes.v_buscar = txt_buscar.Text;
            dt = cls_Reportes.mtd_consultar_reporte();

            double TotalPrestamos = 0;
            double TotalAbonos = 0;
            double TotalGanancias = 0;
            double TotalGananciasxPersona = 0;
            double TotalIntereses = 0;
            double TotalSaldoPendiente = 0;
            int contador = 0;
            foreach (DataRow rows in dt.Rows)
            {
                if (contador == 0)
                {
                    TotalPrestamos = Convert.ToDouble(rows["MontoPrestamoReal"]);
                    TotalIntereses = Convert.ToDouble(rows["ValorInteresesReal"]);
                    TotalSaldoPendiente = Convert.ToDouble(rows["Saldo"]);
                }
                TotalAbonos += Convert.ToDouble(rows["ValorAbono"]);
                TotalGanancias += Convert.ToDouble(rows["Ganancia"]);
                TotalGananciasxPersona += Convert.ToDouble(rows["GananciaXPersona"]);
                contador++;
            }
            lbl_t_p.Text = TotalPrestamos.ToString("N0");
            lbl_t_in.Text = TotalIntereses.ToString("N0");
            lbl_t_ab.Text = TotalAbonos.ToString("N0");
            lbl_tga.Text = TotalGanancias.ToString("N0");
            lbl_tgxp.Text = TotalGananciasxPersona.ToString("N0");
            lbl_t_s_p.Text = TotalSaldoPendiente.ToString("N0");

            double MontoPrestamo = 0;
            double MontoPrestamoReal = 0;
            double ValorInteres = 0;
            double ValorInteresesReal = 0;
            double VlrCuota = 0;
            double ValorAbono = 0;
            double ValorRecuperado = 0;
            double Ganancia = 0;
            double GananciaXPersona = 0;
            double Saldo = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow fila = dt.Rows[i];
                MontoPrestamo = Convert.ToDouble(fila["MontoPrestamo"]);
                fila["MontoPrestamo"] = MontoPrestamo;
                MontoPrestamoReal = Convert.ToDouble(fila["MontoPrestamoReal"]);
                fila["MontoPrestamoReal"] = MontoPrestamoReal;
                ValorInteres = Convert.ToDouble(fila["ValorInteres"]);
                fila["ValorInteres"] = ValorInteres;
                ValorInteresesReal = Convert.ToDouble(fila["ValorInteresesReal"]);
                fila["ValorInteresesReal"] = ValorInteresesReal;
                VlrCuota = Convert.ToDouble(fila["VlrCuota"]);
                fila["VlrCuota"] = VlrCuota;
                ValorAbono = Convert.ToDouble(fila["ValorAbono"]);
                fila["ValorAbono"] = ValorAbono;
                ValorRecuperado = Convert.ToDouble(fila["ValorRecuperado"]);
                fila["ValorRecuperado"] = ValorRecuperado;
                Ganancia = Convert.ToDouble(fila["Ganancia"]);
                fila["Ganancia"] = Ganancia;
                GananciaXPersona = Convert.ToDouble(fila["GananciaXPersona"]);
                fila["GananciaXPersona"] = GananciaXPersona;
                Saldo = Convert.ToDouble(fila["Saldo"]);
                fila["Saldo"] = Saldo;
            }

            dtg_reportes.DataSource = dt;
        }

        private void txt_buscar_KeyUp(object sender, KeyEventArgs e)
        {
            dt = new DataTable();
            cls_Reportes.v_buscar = txt_buscar.Text;
            dt = cls_Reportes.mtd_consultar_reporte();

            double TotalPrestamos = 0;
            double TotalAbonos = 0;
            double TotalGanancias = 0;
            double TotalGananciasxPersona = 0;
            double TotalIntereses = 0;
            double TotalSaldoPendiente = 0;
            int contador = 0;
            foreach (DataRow rows in dt.Rows)
            {
                if (contador == 0)
                {
                    TotalPrestamos = Convert.ToDouble(rows["MontoPrestamoReal"]);
                    TotalIntereses = Convert.ToDouble(rows["ValorInteresesReal"]);
                    TotalSaldoPendiente = Convert.ToDouble(rows["Saldo"]);
                }
                TotalAbonos += Convert.ToDouble(rows["ValorAbono"]);
                TotalGanancias += Convert.ToDouble(rows["Ganancia"]);
                TotalGananciasxPersona += Convert.ToDouble(rows["GananciaXPersona"]);
                contador++;
            }
            lbl_t_p.Text = TotalPrestamos.ToString("N0");
            lbl_t_in.Text = TotalIntereses.ToString("N0");
            lbl_t_ab.Text = TotalAbonos.ToString("N0");
            lbl_tga.Text = TotalGanancias.ToString("N0");
            lbl_tgxp.Text = TotalGananciasxPersona.ToString("N0");
            lbl_t_s_p.Text = TotalSaldoPendiente.ToString("N0");

            double MontoPrestamo = 0;
            double MontoPrestamoReal = 0;
            double ValorInteres = 0;
            double ValorInteresesReal = 0;
            double VlrCuota = 0;
            double ValorAbono = 0;
            double ValorRecuperado = 0;
            double Ganancia = 0;
            double GananciaXPersona = 0;
            double Saldo = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow fila = dt.Rows[i];
                MontoPrestamo = Convert.ToDouble(fila["MontoPrestamo"]);
                fila["MontoPrestamo"] = MontoPrestamo;
                MontoPrestamoReal = Convert.ToDouble(fila["MontoPrestamoReal"]);
                fila["MontoPrestamoReal"] = MontoPrestamoReal;
                ValorInteres = Convert.ToDouble(fila["ValorInteres"]);
                fila["ValorInteres"] = ValorInteres;
                ValorInteresesReal = Convert.ToDouble(fila["ValorInteresesReal"]);
                fila["ValorInteresesReal"] = ValorInteresesReal;
                VlrCuota = Convert.ToDouble(fila["VlrCuota"]);
                fila["VlrCuota"] = VlrCuota;
                ValorAbono = Convert.ToDouble(fila["ValorAbono"]);
                fila["ValorAbono"] = ValorAbono;
                ValorRecuperado = Convert.ToDouble(fila["ValorRecuperado"]);
                fila["ValorRecuperado"] = ValorRecuperado;
                Ganancia = Convert.ToDouble(fila["Ganancia"]);
                fila["Ganancia"] = Ganancia;
                GananciaXPersona = Convert.ToDouble(fila["GananciaXPersona"]);
                fila["GananciaXPersona"] = GananciaXPersona;
                Saldo = Convert.ToDouble(fila["Saldo"]);
                fila["Saldo"] = Saldo;
            }

            dtg_reportes.DataSource = dt;
        }
    }
}
