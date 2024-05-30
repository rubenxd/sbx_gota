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
    public partial class frm_agregar_abono : Form
    {
        frm_ayuda frm_Ayuda;
        cls_cuenta_cobro cls_Cuenta_Cobro = new cls_cuenta_cobro();
        cls_plan_pagos cls_Plan_Pagos = new cls_plan_pagos();
        DataTable v_dt;
        DataTable v_dt2;

        public frm_agregar_abono()
        {
            InitializeComponent();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            if (frm_Ayuda == null || frm_Ayuda.IsDisposed)
            {
                frm_Ayuda = new frm_ayuda("agregaAbonos");
                frm_Ayuda.Enviainfo += new frm_ayuda.EnviarInfo(mtd_dato_venta);
                frm_Ayuda.Show();
            }
            else
            {
                frm_Ayuda.BringToFront();
                frm_Ayuda.WindowState = FormWindowState.Normal;
            }
        }

        private void mtd_dato_venta(string Item)
        {
            cls_Cuenta_Cobro.v_buscar = Item;
            v_dt = cls_Cuenta_Cobro.mtd_consultar_cuenta_cobro_exacto();
            DataRow row = v_dt.Rows[0];
            txt_cuentaCobro.Text = row["IdCuentaCobro"].ToString();
            txt_id_cuenta_cobro.Text = row["IdCuentaCobro"].ToString();
            txt_identificacion.Text = row["NumeroIdentificacion"].ToString();
            txt_nombres.Text = row["Cliente"].ToString();
            txt_vlr_interes.Text = row["ValorInteres"].ToString();
            txt_vlr_prestamo.Text = row["MontoPrestamo"].ToString();
            txt_num_cuotas.Text = row["NumeroCuotas"].ToString();
            double valorTotal = Convert.ToDouble(txt_vlr_prestamo.Text) + Convert.ToDouble(txt_vlr_interes.Text);
            txt_valor_total.Text = valorTotal.ToString("N0");
            double valorCuota = Convert.ToDouble(txt_valor_total.Text) / Convert.ToInt32(txt_num_cuotas.Text);
            txt_valor_cuota.Text = valorCuota.ToString("N0");
            cbx_dia_pago.Text = row["DiaPago"].ToString();
            cbx_modo_pago.Text = row["ModoPago"].ToString();
            txt_dia_fecha_pago.Text = row["DiasFechaPago"].ToString();
            txt_nota.Text = row["Nota"].ToString();
            txt_porcentaje_interes.Text = row["PorcentajeInteres"].ToString();

            //carga plan de pagos
            dtg_plan_pagos.DataSource = null;
            //double VlrCuota = 0;
            //double VlrAbono = 0;
            //double vlrSaldo = 0;
            cls_Plan_Pagos.v_buscar = txt_id_cuenta_cobro.Text;
            v_dt2 = cls_Plan_Pagos.mtd_consultar_planPagos();
            //for (int i = 0; i < v_dt2.Rows.Count; i++)
            //{
            //    DataRow fila = v_dt2.Rows[i];
            //    VlrCuota = Convert.ToDouble(fila["VlrCuota"]);
            //    fila["VlrCuota"] = VlrCuota.ToString();
            //    VlrAbono = Convert.ToDouble(fila["ValorAbono"]);
            //    fila["ValorAbono"] = VlrAbono.ToString();
            //    vlrSaldo = Convert.ToDouble(fila["Saldo"]);
            //    fila["Saldo"] = vlrSaldo.ToString();
            //}
            dtg_plan_pagos.DataSource = v_dt2;

            double TotalSaldo = 0;
            foreach (DataGridViewRow rows in dtg_plan_pagos.Rows)
            {
                TotalSaldo += Convert.ToDouble(rows.Cells["Saldo"].Value);
            }
            lbl_pago_total.Text = TotalSaldo.ToString("N0");
            if (TotalSaldo > 0)
            {
                btn_pago_total.Enabled = true;
            }
            else
            {
                btn_pago_total.Enabled = false;
            }

            //double PagoTotal = 0;
            //int pagoPendientes = 0;
            //foreach (DataGridViewRow rows in dtg_plan_pagos.Rows)
            //{
            //    PagoTotal += Convert.ToDouble(rows.Cells["Saldo"].Value);
            //    if (rows.Cells["Estado"].Value.ToString() == "Pendiente")
            //    {
            //        pagoPendientes++;
            //    }
            //}
            //lbl_pago_total.Text = PagoTotal.ToString("N0");

            //if (pagoPendientes > 0)
            //{
            //    btn_pago_total.Enabled = true;
            //}
        }

        string v_dato = "";
        frm_abono_cuota frm_Abono_Cuota;
        private void dtg_plan_pagos_DoubleClick(object sender, EventArgs e)
        {
            if (dtg_plan_pagos.Rows.Count > 0)
            {
                int v_filas = 0;
                List<int> cuotaApagar = new List<int>();
                v_filas = dtg_plan_pagos.CurrentRow.Index;
                foreach (DataGridViewRow item in dtg_plan_pagos.Rows)
                {
                    if (item.Cells["Estado"].Value.ToString() == "Pendiente")
                    {
                        cuotaApagar.Add(Convert.ToInt32(item.Cells["NumeroCuota"].Value));
                    }                    
                }

                v_dato = dtg_plan_pagos[5, v_filas].Value.ToString();
                if (v_dato != "Pago")
                {
                    int numCota = 0;
                    if (cuotaApagar.Count > 0)
                    {
                        numCota = cuotaApagar.Min();
                    }

                   if (numCota > 0)
                    {
                        if (Convert.ToInt32(dtg_plan_pagos[2, v_filas].Value) == numCota)
                        {
                            if (frm_Abono_Cuota == null || frm_Abono_Cuota.IsDisposed)
                            {
                                frm_Abono_Cuota = new frm_abono_cuota();
                                frm_Abono_Cuota.IdPlanPagos = Convert.ToInt32(dtg_plan_pagos[0, v_filas].Value);
                                frm_Abono_Cuota.ValorCuota = dtg_plan_pagos[7, v_filas].Value.ToString();
                                frm_Abono_Cuota.FechaCuota = dtg_plan_pagos[4, v_filas].Value.ToString();
                                frm_Abono_Cuota.NumCuota = Convert.ToInt32(dtg_plan_pagos[2, v_filas].Value);
                                frm_Abono_Cuota.Enviainfo += new frm_abono_cuota.EnviarInfo(mtd_confirmacion);
                                frm_Abono_Cuota.Show();
                            }
                            else
                            {
                                frm_Ayuda.BringToFront();
                                frm_Ayuda.WindowState = FormWindowState.Normal;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Cuota no se puede pagar");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Cuota ya esta paga");
                }
            }
        }

        private void mtd_confirmacion(string respuesta)
        {
            //carga plan de pagos
            dtg_plan_pagos.DataSource = null;
            cls_Plan_Pagos.v_buscar = txt_id_cuenta_cobro.Text;
            v_dt2 = cls_Plan_Pagos.mtd_consultar_planPagos();
            dtg_plan_pagos.DataSource = v_dt2;

            //verificar refinanciamiento
            bool v_ok2 = false;
            int contador = 1;
            DateTime FechaPago = new DateTime();
            int correcto = 0;
            int Error = 0;

            //suma todos los saldos
            var sumaSaldos = dtg_plan_pagos.Rows
            .Cast<DataGridViewRow>()
            .Where(row => !row.IsNewRow)
            .Sum(row => Convert.ToDouble(row.Cells["Saldo"].Value));
            foreach (DataGridViewRow rows in dtg_plan_pagos.Rows)
            {
                int year = 0;
                int mes = 0;
                int dias = 0;

                if (rows.Cells["Estado"].Value.ToString() == "Pago parcial" && Convert.ToDouble(rows.Cells["Saldo"].Value) > 0) 
                {
                    //eliminar los plan de pagos siguientes y recalcular fechas de pago
                    cls_Plan_Pagos.Id_cuentaCobro = Convert.ToInt32(rows.Cells["Id_cuentaCobro"].Value);
                    cls_Plan_Pagos.NumeroCuota = Convert.ToInt32(rows.Cells["NumeroCuota"].Value);
                    v_ok2 = cls_Plan_Pagos.mtd_eliminar_cuotas_plan_pago();
                    if (v_ok2)
                    {
                        //Cambiar el valor de la cuota para que el saldo del abono parcial quede en cero
                        cls_Plan_Pagos.Id = Convert.ToInt32(rows.Cells["id"].Value);
                        cls_Plan_Pagos.VlrCuota = rows.Cells["ValorAbono"].Value.ToString();
                        v_ok2 = cls_Plan_Pagos.mtd_Editar_valor_cuota();
                        if (v_ok2)
                        {
                            while (sumaSaldos > 0)
                            {
                                if (sumaSaldos >= Convert.ToDouble(rows.Cells["VlrCuota"].Value))
                                {
                                    sumaSaldos -= Convert.ToDouble(rows.Cells["VlrCuota"].Value);
                                    if (contador == 1)
                                    {
                                        FechaPago = Convert.ToDateTime(rows.Cells["FechaCuota"].Value);
                                    }
                                    double valorCuota = Convert.ToDouble(rows.Cells["VlrCuota"].Value);
                                    cls_Plan_Pagos.VlrCuota = valorCuota.ToString();
                                }
                                else
                                {
                                    if (contador == 1)
                                    {
                                        FechaPago = Convert.ToDateTime(rows.Cells["FechaCuota"].Value);
                                    }
                                    cls_Plan_Pagos.VlrCuota = sumaSaldos.ToString();
                                    sumaSaldos -= Convert.ToDouble(rows.Cells["VlrCuota"].Value);
                                }
                                switch (rows.Cells["ModoPago"].Value.ToString())
                                {
                                    case "Diario":
                                        FechaPago = FechaPago.AddDays(1);
                                        break;
                                    case "Semanal":
                                        FechaPago = FechaPago.AddDays(7);
                                        break;
                                    case "Quincenal":
                                        year = FechaPago.Year;
                                        mes = FechaPago.Month;
                                        dias = ContarDiasDelMes(year, FechaPago.Month);
                                        FechaPago = FechaPago.AddDays(15);

                                        if (dias == 31 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(1);
                                        }
                                        else if (dias == 29 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(-1);
                                        }
                                        else if (dias == 28 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(-2);
                                        }
                                        break;
                                    case "Mensual":
                                        year = FechaPago.Year;
                                        mes = FechaPago.Month;
                                        dias = ContarDiasDelMes(year, FechaPago.Month);
                                        FechaPago = FechaPago.AddDays(30);

                                        if (dias == 31 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(1);
                                        }
                                        else if (dias == 29 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(-1);
                                        }
                                        else if (dias == 28 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(-2);
                                        }
                                        break;
                                    case "Semestral":
                                        year = FechaPago.Year;
                                        mes = FechaPago.Month;
                                        dias = ContarDiasDelMes(year, FechaPago.Month);
                                        FechaPago = FechaPago.AddDays(180);

                                        if (dias == 31 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(1);
                                        }
                                        else if (dias == 29 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(-1);
                                        }
                                        else if (dias == 28 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(-2);
                                        }
                                        break;
                                    case "Anual":
                                        year = FechaPago.Year;
                                        mes = FechaPago.Month;
                                        dias = ContarDiasDelMes(year, FechaPago.Month);
                                        FechaPago = FechaPago.AddDays(360);

                                        if (dias == 31 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(1);
                                        }
                                        else if (dias == 29 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(-1);
                                        }
                                        else if (dias == 28 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(-2);
                                        }
                                        break;
                                    default:
                                        break;
                                }
                                cls_Plan_Pagos.Id_cuentaCobro = Convert.ToInt32(rows.Cells["Id_cuentaCobro"].Value);
                                cls_Plan_Pagos.NumeroCuota = Convert.ToInt32(rows.Cells["NumeroCuota"].Value) + contador;
                                cls_Plan_Pagos.FechaCuota = FechaPago.ToString();
                                cls_Plan_Pagos.FechaRegistro = DateTime.Now.ToString();
                                cls_Plan_Pagos.Estado = "Pendiente";
                                v_ok2 = cls_Plan_Pagos.mtd_registrar();
                                if (v_ok2)
                                {
                                    correcto++;
                                }
                                else
                                {
                                    Error++;
                                }
                                contador++;
                            }
                        }                     
                    }
                }
                else if (rows.Cells["Estado"].Value.ToString() == "Pago superior" && Convert.ToDouble(rows.Cells["Saldo"].Value) < 0)
                {
                    //eliminar los plan de pagos siguientes y recalcular fechas de pago
                    cls_Plan_Pagos.Id_cuentaCobro = Convert.ToInt32(rows.Cells["Id_cuentaCobro"].Value);
                    cls_Plan_Pagos.NumeroCuota = Convert.ToInt32(rows.Cells["NumeroCuota"].Value);
                    v_ok2 = cls_Plan_Pagos.mtd_eliminar_cuotas_plan_pago();
                    if (v_ok2)
                    {
                        //Cambiar el valor de la cuota para que el saldo del abono parcial quede en cero
                        cls_Plan_Pagos.Id = Convert.ToInt32(rows.Cells["id"].Value);
                        cls_Plan_Pagos.VlrCuota = rows.Cells["ValorAbono"].Value.ToString();
                        v_ok2 = cls_Plan_Pagos.mtd_Editar_valor_cuota();
                        if (v_ok2)
                        {
                            while (sumaSaldos > 0)
                            {
                                if (sumaSaldos >= Convert.ToDouble(rows.Cells["VlrCuota"].Value))
                                {
                                    sumaSaldos -= Convert.ToDouble(rows.Cells["VlrCuota"].Value);
                                    if (contador == 1)
                                    {
                                        FechaPago = Convert.ToDateTime(rows.Cells["FechaCuota"].Value);
                                    }
                                    double valorCuota = Convert.ToDouble(rows.Cells["VlrCuota"].Value);
                                    cls_Plan_Pagos.VlrCuota = valorCuota.ToString();
                                }
                                else
                                {
                                    if (contador == 1)
                                    {
                                        FechaPago = Convert.ToDateTime(rows.Cells["FechaCuota"].Value);
                                    }
                                    cls_Plan_Pagos.VlrCuota = sumaSaldos.ToString();
                                    sumaSaldos -= Convert.ToDouble(rows.Cells["VlrCuota"].Value);
                                }
                                switch (rows.Cells["ModoPago"].Value.ToString())
                                {
                                    case "Diario":
                                        FechaPago = FechaPago.AddDays(1);
                                        break;
                                    case "Semanal":
                                        FechaPago = FechaPago.AddDays(7);
                                        break;
                                    case "Quincenal":
                                        year = FechaPago.Year;
                                        mes = FechaPago.Month;
                                        dias = ContarDiasDelMes(year, FechaPago.Month);
                                        FechaPago = FechaPago.AddDays(15);

                                        if (dias == 31 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(1);
                                        }
                                        else if (dias == 29 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(-1);
                                        }
                                        else if (dias == 28 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(-2);
                                        }
                                        break;
                                    case "Mensual":
                                        year = FechaPago.Year;
                                        mes = FechaPago.Month;
                                        dias = ContarDiasDelMes(year, FechaPago.Month);
                                        FechaPago = FechaPago.AddDays(30);

                                        if (dias == 31 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(1);
                                        }
                                        else if (dias == 29 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(-1);
                                        }
                                        else if (dias == 28 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(-2);
                                        }
                                        break;
                                    case "Semestral":
                                        year = FechaPago.Year;
                                        mes = FechaPago.Month;
                                        dias = ContarDiasDelMes(year, FechaPago.Month);
                                        FechaPago = FechaPago.AddDays(180);

                                        if (dias == 31 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(1);
                                        }
                                        else if (dias == 29 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(-1);
                                        }
                                        else if (dias == 28 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(-2);
                                        }
                                        break;
                                    case "Anual":
                                        year = FechaPago.Year;
                                        mes = FechaPago.Month;
                                        dias = ContarDiasDelMes(year, FechaPago.Month);
                                        FechaPago = FechaPago.AddDays(360);

                                        if (dias == 31 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(1);
                                        }
                                        else if (dias == 29 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(-1);
                                        }
                                        else if (dias == 28 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(-2);
                                        }
                                        break;
                                    default:
                                        break;
                                }
                                cls_Plan_Pagos.Id_cuentaCobro = Convert.ToInt32(rows.Cells["Id_cuentaCobro"].Value);
                                cls_Plan_Pagos.NumeroCuota = Convert.ToInt32(rows.Cells["NumeroCuota"].Value) + contador;
                                cls_Plan_Pagos.FechaCuota = FechaPago.ToString();
                                cls_Plan_Pagos.FechaRegistro = DateTime.Now.ToString();
                                cls_Plan_Pagos.Estado = "Pendiente";
                                v_ok2 = cls_Plan_Pagos.mtd_registrar();
                                if (v_ok2)
                                {
                                    correcto++;
                                }
                                else
                                {
                                    Error++;
                                }
                                contador++;
                            }
                        }
                    }
                }
            }
            //fin refinanciamiento

            //cargar datos nuevamente
            //carga plan de pagos
            dtg_plan_pagos.DataSource = null;
            cls_Plan_Pagos.v_buscar = txt_id_cuenta_cobro.Text;
            v_dt2 = cls_Plan_Pagos.mtd_consultar_planPagos();
            dtg_plan_pagos.DataSource = v_dt2;

           // int numeroCuota = 0;
           // bool okok = false;
           // //maxima cuota
           // numeroCuota = dtg_plan_pagos.Rows
           //.Cast<DataGridViewRow>()
           //.Where(row => !row.IsNewRow)
           //.Max(row => Convert.ToInt32(row.Cells["NumeroCuota"].Value));
           // cls_Cuenta_Cobro.Id = Convert.ToInt32(txt_id_cuenta_cobro.Text);
           // cls_Cuenta_Cobro.NumeroCuotas = numeroCuota;
           // cls_Cuenta_Cobro.mtd_Editar_numero_cuotas();
           // if (okok)
           // {
           //     txt_num_cuotas.Text = numeroCuota.ToString();
           // }
            double TotalSaldo = 0;
            foreach (DataGridViewRow rows in dtg_plan_pagos.Rows)
            {
                TotalSaldo += Convert.ToDouble(rows.Cells["Saldo"].Value);
            }
            lbl_pago_total.Text = TotalSaldo.ToString("N0");
            if (TotalSaldo > 0)
            {
                btn_pago_total.Enabled = true;
            }
            else
            {
                btn_pago_total.Enabled = false;
            }

            //double PagoTotal = 0;
            //int pagoPendientes = 0;
            //foreach (DataGridViewRow rows in dtg_plan_pagos.Rows)
            //{
            //    PagoTotal += Convert.ToDouble(rows.Cells["Saldo"].Value);
            //    if (rows.Cells["Estado"].Value.ToString() == "Pendiente")
            //    {
            //        pagoPendientes++;
            //    }
            //}
            //lbl_pago_total.Text = PagoTotal.ToString("N0");
            //if (pagoPendientes > 0)
            //{
            //    btn_pago_total.Enabled = true;
            //}
        }
        private void mtd_refinanciacion()
        {
            //carga plan de pagos
            dtg_plan_pagos.DataSource = null;
            cls_Plan_Pagos.v_buscar = txt_id_cuenta_cobro.Text;
            v_dt2 = cls_Plan_Pagos.mtd_consultar_planPagos();
            dtg_plan_pagos.DataSource = v_dt2;

            //verificar refinanciamiento
            bool v_ok2 = false;
            int contador = 1;
            DateTime FechaPago = new DateTime();
            int correcto = 0;
            int Error = 0;
            //suma todos los saldos
            var sumaSaldos = dtg_plan_pagos.Rows
            .Cast<DataGridViewRow>()
            .Where(row => !row.IsNewRow)
            .Sum(row => Convert.ToDouble(row.Cells["Saldo"].Value));
            foreach (DataGridViewRow rows in dtg_plan_pagos.Rows)
            {
                int year = 0;
                int mes = 0;
                int dias = 0;

                if (rows.Cells["Estado"].Value.ToString() == "Pago parcial" && Convert.ToDouble(rows.Cells["Saldo"].Value) > 0)
                {
                    //eliminar los plan de pagos siguientes y recalcular fechas de pago
                    cls_Plan_Pagos.Id_cuentaCobro = Convert.ToInt32(rows.Cells["Id_cuentaCobro"].Value);
                    cls_Plan_Pagos.NumeroCuota = Convert.ToInt32(rows.Cells["NumeroCuota"].Value);
                    v_ok2 = cls_Plan_Pagos.mtd_eliminar_cuotas_plan_pago();
                    if (v_ok2)
                    {
                        //Cambiar el valor de la cuota para que el saldo del abono parcial quede en cero
                        cls_Plan_Pagos.Id = Convert.ToInt32(rows.Cells["id"].Value);
                        cls_Plan_Pagos.VlrCuota = rows.Cells["ValorAbono"].Value.ToString();
                        v_ok2 = cls_Plan_Pagos.mtd_Editar_valor_cuota();
                        if (v_ok2)
                        {
                            while (sumaSaldos > 0)
                            {
                                if (sumaSaldos >= Convert.ToDouble(rows.Cells["VlrCuota"].Value))
                                {
                                    sumaSaldos -= Convert.ToDouble(rows.Cells["VlrCuota"].Value);
                                    if (contador == 1)
                                    {
                                        FechaPago = Convert.ToDateTime(rows.Cells["FechaCuota"].Value);
                                    }
                                    double valorCuota = Convert.ToDouble(rows.Cells["VlrCuota"].Value);
                                    cls_Plan_Pagos.VlrCuota = valorCuota.ToString();
                                }
                                else
                                {
                                    if (contador == 1)
                                    {
                                        FechaPago = Convert.ToDateTime(rows.Cells["FechaCuota"].Value);
                                    }
                                    cls_Plan_Pagos.VlrCuota = sumaSaldos.ToString();
                                    sumaSaldos -= Convert.ToDouble(rows.Cells["VlrCuota"].Value);
                                }
                                switch (rows.Cells["ModoPago"].Value.ToString())
                                {
                                    case "Diario":
                                        FechaPago = FechaPago.AddDays(1);
                                        break;
                                    case "Semanal":
                                        FechaPago = FechaPago.AddDays(7);
                                        break;
                                    case "Quincenal":
                                        year = FechaPago.Year;
                                        mes = FechaPago.Month;
                                        dias = ContarDiasDelMes(year, FechaPago.Month);
                                        FechaPago = FechaPago.AddDays(15);

                                        if (dias == 31 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(1);
                                        }
                                        else if (dias == 29 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(-1);
                                        }
                                        else if (dias == 28 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(-2);
                                        }
                                        break;
                                    case "Mensual":
                                        year = FechaPago.Year;
                                        mes = FechaPago.Month;
                                        dias = ContarDiasDelMes(year, FechaPago.Month);
                                        FechaPago = FechaPago.AddDays(30);

                                        if (dias == 31 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(1);
                                        }
                                        else if (dias == 29 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(-1);
                                        }
                                        else if (dias == 28 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(-2);
                                        }
                                        break;
                                    case "Semestral":
                                        year = FechaPago.Year;
                                        mes = FechaPago.Month;
                                        dias = ContarDiasDelMes(year, FechaPago.Month);
                                        FechaPago = FechaPago.AddDays(180);

                                        if (dias == 31 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(1);
                                        }
                                        else if (dias == 29 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(-1);
                                        }
                                        else if (dias == 28 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(-2);
                                        }
                                        break;
                                    case "Anual":
                                        year = FechaPago.Year;
                                        mes = FechaPago.Month;
                                        dias = ContarDiasDelMes(year, FechaPago.Month);
                                        FechaPago = FechaPago.AddDays(360);

                                        if (dias == 31 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(1);
                                        }
                                        else if (dias == 29 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(-1);
                                        }
                                        else if (dias == 28 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(-2);
                                        }
                                        break;
                                    default:
                                        break;
                                }
                                cls_Plan_Pagos.Id_cuentaCobro = Convert.ToInt32(rows.Cells["Id_cuentaCobro"].Value);
                                cls_Plan_Pagos.NumeroCuota = Convert.ToInt32(rows.Cells["NumeroCuota"].Value) + contador;
                                cls_Plan_Pagos.FechaCuota = FechaPago.ToString();
                                cls_Plan_Pagos.FechaRegistro = DateTime.Now.ToString();
                                cls_Plan_Pagos.Estado = "Pendiente";
                                v_ok2 = cls_Plan_Pagos.mtd_registrar();
                                if (v_ok2)
                                {
                                    correcto++;
                                }
                                else
                                {
                                    Error++;
                                }
                                contador++;
                            }
                        }
                    }
                }else if (rows.Cells["Estado"].Value.ToString() == "Pago superior" && Convert.ToDouble(rows.Cells["Saldo"].Value) < 0)
                {
                    //eliminar los plan de pagos siguientes y recalcular fechas de pago
                    cls_Plan_Pagos.Id_cuentaCobro = Convert.ToInt32(rows.Cells["Id_cuentaCobro"].Value);
                    cls_Plan_Pagos.NumeroCuota = Convert.ToInt32(rows.Cells["NumeroCuota"].Value);
                    v_ok2 = cls_Plan_Pagos.mtd_eliminar_cuotas_plan_pago();
                    if (v_ok2)
                    {
                        //Cambiar el valor de la cuota para que el saldo del abono parcial quede en cero
                        cls_Plan_Pagos.Id = Convert.ToInt32(rows.Cells["id"].Value);
                        cls_Plan_Pagos.VlrCuota = rows.Cells["ValorAbono"].Value.ToString();
                        v_ok2 = cls_Plan_Pagos.mtd_Editar_valor_cuota();
                        if (v_ok2)
                        {
                            while (sumaSaldos > 0)
                            {
                                if (sumaSaldos >= Convert.ToDouble(rows.Cells["VlrCuota"].Value))
                                {
                                    sumaSaldos -= Convert.ToDouble(rows.Cells["VlrCuota"].Value);
                                    if (contador == 1)
                                    {
                                        FechaPago = Convert.ToDateTime(rows.Cells["FechaCuota"].Value);
                                    }
                                    double valorCuota = Convert.ToDouble(rows.Cells["VlrCuota"].Value);
                                    cls_Plan_Pagos.VlrCuota = valorCuota.ToString();
                                }
                                else
                                {
                                    if (contador == 1)
                                    {
                                        FechaPago = Convert.ToDateTime(rows.Cells["FechaCuota"].Value);
                                    }
                                    cls_Plan_Pagos.VlrCuota = sumaSaldos.ToString();
                                    sumaSaldos -= Convert.ToDouble(rows.Cells["VlrCuota"].Value);
                                }
                                switch (rows.Cells["ModoPago"].Value.ToString())
                                {
                                    case "Diario":
                                        FechaPago = FechaPago.AddDays(1);
                                        break;
                                    case "Semanal":
                                        FechaPago = FechaPago.AddDays(7);
                                        break;
                                    case "Quincenal":
                                        year = FechaPago.Year;
                                        mes = FechaPago.Month;
                                        dias = ContarDiasDelMes(year, FechaPago.Month);
                                        FechaPago = FechaPago.AddDays(15);

                                        if (dias == 31 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(1);
                                        }
                                        else if (dias == 29 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(-1);
                                        }
                                        else if (dias == 28 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(-2);
                                        }
                                        break;
                                    case "Mensual":
                                        year = FechaPago.Year;
                                        mes = FechaPago.Month;
                                        dias = ContarDiasDelMes(year, FechaPago.Month);
                                        FechaPago = FechaPago.AddDays(30);

                                        if (dias == 31 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(1);
                                        }
                                        else if (dias == 29 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(-1);
                                        }
                                        else if (dias == 28 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(-2);
                                        }
                                        break;
                                    case "Semestral":
                                        year = FechaPago.Year;
                                        mes = FechaPago.Month;
                                        dias = ContarDiasDelMes(year, FechaPago.Month);
                                        FechaPago = FechaPago.AddDays(180);

                                        if (dias == 31 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(1);
                                        }
                                        else if (dias == 29 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(-1);
                                        }
                                        else if (dias == 28 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(-2);
                                        }
                                        break;
                                    case "Anual":
                                        year = FechaPago.Year;
                                        mes = FechaPago.Month;
                                        dias = ContarDiasDelMes(year, FechaPago.Month);
                                        FechaPago = FechaPago.AddDays(360);

                                        if (dias == 31 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(1);
                                        }
                                        else if (dias == 29 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(-1);
                                        }
                                        else if (dias == 28 && mes != FechaPago.Month)
                                        {
                                            FechaPago = FechaPago.AddDays(-2);
                                        }
                                        break;
                                    default:
                                        break;
                                }
                                cls_Plan_Pagos.Id_cuentaCobro = Convert.ToInt32(rows.Cells["Id_cuentaCobro"].Value);
                                cls_Plan_Pagos.NumeroCuota = Convert.ToInt32(rows.Cells["NumeroCuota"].Value) + contador;
                                cls_Plan_Pagos.FechaCuota = FechaPago.ToString();
                                cls_Plan_Pagos.FechaRegistro = DateTime.Now.ToString();
                                cls_Plan_Pagos.Estado = "Pendiente";
                                v_ok2 = cls_Plan_Pagos.mtd_registrar();
                                if (v_ok2)
                                {
                                    correcto++;
                                }
                                else
                                {
                                    Error++;
                                }
                                contador++;
                            }
                        }
                    }
                }
            }
            //fin refinanciamiento

            //cargar datos nuevamente
            //carga plan de pagos
            dtg_plan_pagos.DataSource = null;
            cls_Plan_Pagos.v_buscar = txt_id_cuenta_cobro.Text;
            v_dt2 = cls_Plan_Pagos.mtd_consultar_planPagos();
            dtg_plan_pagos.DataSource = v_dt2;

            double TotalSaldo = 0;
            //int numeroCuota = 0;
            //bool okok = false;
            ////maxima cuota
            // numeroCuota = dtg_plan_pagos.Rows
            //.Cast<DataGridViewRow>()
            //.Where(row => !row.IsNewRow)
            //.Max(row => Convert.ToInt32(row.Cells["NumeroCuota"].Value));
            //cls_Cuenta_Cobro.Id = Convert.ToInt32(txt_id_cuenta_cobro.Text);
            //cls_Cuenta_Cobro.NumeroCuotas = numeroCuota;
            //okok = cls_Cuenta_Cobro.mtd_Editar_numero_cuotas();
            //if (okok)
            //{
            //    txt_num_cuotas.Text = numeroCuota.ToString();
            //}    

            foreach (DataGridViewRow rows in dtg_plan_pagos.Rows)
            {
                TotalSaldo += Convert.ToDouble(rows.Cells["Saldo"].Value);
            }
            lbl_pago_total.Text = TotalSaldo.ToString("N0");
            if (TotalSaldo > 0)
            {
                btn_pago_total.Enabled = true;
            }
            else
            {
                btn_pago_total.Enabled = false;
            }

            //double PagoTotal = 0;
            //int pagoPendientes = 0;
            //foreach (DataGridViewRow rows in dtg_plan_pagos.Rows)
            //{
            //    PagoTotal += Convert.ToDouble(rows.Cells["Saldo"].Value);
            //    if (rows.Cells["Estado"].Value.ToString() == "Pendiente")
            //    {
            //        pagoPendientes++;
            //    }
            //}
            //lbl_pago_total.Text = PagoTotal.ToString("N0");
            //if (pagoPendientes > 0)
            //{
            //    btn_pago_total.Enabled = true;
            //}
        }
        static int ContarDiasDelMes(int año, int mes)
        {
            return DateTime.DaysInMonth(año, mes);
        }
        private void btn_pago_total_Click(object sender, EventArgs e)
        {
            if (lbl_pago_total.Text != "0" && dtg_plan_pagos.Rows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("¿Está seguro de que desea realizar pago total ?", "", MessageBoxButtons.OKCancel);

                if (dialogResult == DialogResult.OK)
                {
                    bool v_ok = false;
                    int correcto = 0;
                    int Error = 0;
                    cls_abonos cls_Abonos = new cls_abonos();
                    if (dtg_plan_pagos.Rows.Count > 0)
                    {
                        if (dtg_plan_pagos.SelectedRows.Count > 0)
                        {
                            foreach (DataGridViewRow row in dtg_plan_pagos.Rows)
                            {
                                if (row.Cells["Estado"].Value.ToString() != "Pago")
                                {
                                    cls_Abonos.Id_plan_pagos = Convert.ToInt32(row.Cells["Id"].Value);
                                    cls_Abonos.ValorAbono = row.Cells["Saldo"].Value.ToString();
                                    cls_Abonos.Nota = "Pago total";
                                    cls_Abonos.FechaRegistro = DateTime.Now.ToString();
                                    v_ok = cls_Abonos.mtd_registrar();
                                    if (v_ok)
                                    {
                                        cls_Plan_Pagos.Id = Convert.ToInt32(row.Cells["Id"].Value);
                                        cls_Plan_Pagos.Estado = "Pago";
                                        v_ok = cls_Plan_Pagos.mtd_Editar_estado();
                                        if (v_ok)
                                        {
                                            correcto++;
                                        }
                                        else
                                        {
                                            Error++;
                                        }
                                    }
                                    else
                                    {
                                        Error++;
                                    }
                                }
                            }
                            MessageBox.Show("Pago Total registrado correctamente, Correcto:" + correcto + " , Error: " + Error + " ");
                        }
                    }
                    //carga plan de pagos
                    dtg_plan_pagos.DataSource = null;
                    //double VlrCuota = 0;
                    //double VlrAbono = 0;
                    //double vlrSaldo = 0;
                    cls_Plan_Pagos.v_buscar = txt_id_cuenta_cobro.Text;
                    v_dt2 = cls_Plan_Pagos.mtd_consultar_planPagos();
                    //for (int i = 0; i < v_dt2.Rows.Count; i++)
                    //{
                    //    DataRow fila = v_dt2.Rows[i];
                    //    VlrCuota = Convert.ToDouble(fila["VlrCuota"]);
                    //    fila["VlrCuota"] = VlrCuota.ToString();
                    //    VlrAbono = Convert.ToDouble(fila["ValorAbono"]);
                    //    fila["ValorAbono"] = VlrAbono.ToString();
                    //    vlrSaldo = Convert.ToDouble(fila["Saldo"]);
                    //    fila["Saldo"] = vlrSaldo.ToString();
                    //}

                    dtg_plan_pagos.DataSource = v_dt2;
                }
            }
        }

        private void frm_agregar_abono_Load(object sender, EventArgs e)
        {

        }

        private void btn_refinanciar_Click(object sender, EventArgs e)
        {
            mtd_refinanciacion();
        }
    }
}
