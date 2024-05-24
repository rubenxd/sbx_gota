﻿using sbx_gota.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sbx_gota
{
    public partial class frm_cuenta_cobro : Form
    {
        frm_ayuda frm_Ayuda;
        cls_cliente cls_Cliente = new cls_cliente();
        cls_cuenta_cobro cls_Cuenta_Cobro = new cls_cuenta_cobro();
        cls_plan_pagos cls_Plan_Pagos = new cls_plan_pagos();
        DataTable v_dt;
        int v_validado = 0;
        bool v_registro = true;
        bool v_ok = true;
        int Eliminados;
        int Error;
        int v_contador = 0;
        double Margen = 0;

        public frm_cuenta_cobro()
        {
            InitializeComponent();
        }

        private void frm_cuenta_cobro_Load(object sender, EventArgs e)
        {
            cbx_dia_pago.SelectedIndex = 0;
            cbx_modo_pago.SelectedIndex = 0;
            //mtd_Cargar_cuenta_cobro();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            if (frm_Ayuda == null || frm_Ayuda.IsDisposed)
            {
                frm_Ayuda = new frm_ayuda("cuentaCobro");
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
            cls_Cliente.v_buscar = Item;
            v_dt = cls_Cliente.mtd_consultar_cliente_exacto();
            DataRow row = v_dt.Rows[0];
            txt_cliente.Text = row["NumeroIdentificacion"].ToString();
            lbl_id_cliente.Text = row["Id"].ToString();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (v_registro == true)
              {
                 mtd_guardar();
              }
             else
              {
                 mtd_editar();
              } 
        }
        private void mtd_guardar()
        {
            v_validado = 0;
            errorProvider.Clear();
            if (txt_cliente.Text.Trim() == "")
            {
                errorProvider.SetError(txt_cliente, "Ingrese cliente");
                v_validado++;
            }
            if (txt_vlr_prestamo.Text.Trim() == "")
            {
                errorProvider.SetError(txt_vlr_prestamo, "Ingrese valor prestamo");
                v_validado++;
            }
            if (txt_vlr_interes.Text.Trim() == "")
            {
                errorProvider.SetError(txt_vlr_interes, "Ingrese valor interes");
                v_validado++;
            }
            if (txt_porcentaje_interes.Text.Trim() == "")
            {
                errorProvider.SetError(txt_porcentaje_interes, "Ingrese porcentaje interes");
                v_validado++;
            }
            if (txt_num_cuotas.Text.Trim() == "")
            {
                errorProvider.SetError(txt_num_cuotas, "Ingrese numero de cuotas");
                v_validado++;
            }
            if (txt_valor_total.Text.Trim() == "")
            {
                errorProvider.SetError(txt_valor_total, "Ingrese valor total");
                v_validado++;
            }
            if (txt_num_cuotas.Text.Trim() == "0")
            {
                errorProvider.SetError(txt_num_cuotas, "Numero de cuotas debe ser mayor a cero");
                v_validado++;
            }
            if (txt_num_cuotas.Text.Trim() == "")
            {
                errorProvider.SetError(txt_num_cuotas, "Ingrese numero de cuotas");
                v_validado++;
            }


            if (v_validado == 0)
            {
                cls_Cuenta_Cobro.Id_cliente = Convert.ToInt32(lbl_id_cliente.Text);
                cls_Cuenta_Cobro.MontoPrestamo = Convert.ToDouble(txt_vlr_prestamo.Text);
                cls_Cuenta_Cobro.ValorInteres = Convert.ToDouble(txt_vlr_interes.Text);
                cls_Cuenta_Cobro.PorcentajeInteres = txt_porcentaje_interes.Text;
                cls_Cuenta_Cobro.NumeroCuotas = Convert.ToInt32(txt_num_cuotas.Text);
                cls_Cuenta_Cobro.ModoPago = cbx_modo_pago.Text;
                cls_Cuenta_Cobro.DiaPago = cbx_dia_pago.Text;
                cls_Cuenta_Cobro.DiasFechaPago = txt_dia_fecha_pago.Text;
                cls_Cuenta_Cobro.FechaPrimerPago = dtt_fecha_primer_pago.Text;
                cls_Cuenta_Cobro.Estado = "Activo";
                cls_Cuenta_Cobro.Nota = txt_nota.Text;
                cls_Cuenta_Cobro.FechaRegistros = DateTime.Now.ToString();

                v_ok = cls_Cuenta_Cobro.mtd_registrar();

                if (v_ok == true)
                {
                    MessageBox.Show("Cuenta cobro registrada correctamente");

                    DataTable dt = new DataTable();
                    dt = cls_Cuenta_Cobro.mtd_consultar_cuenta_cobro_maximo();
                    DataRow data = dt.Rows[0];
                    int exitosas = 0;
                    int errores = 0;
                    bool v_ok2 = false;
                    for (int i = 1; i <= Convert.ToInt32(txt_num_cuotas.Text); i++)
                    {
                        cls_Plan_Pagos.Id_cuentaCobro = Convert.ToInt32(data["Id"]);
                        cls_Plan_Pagos.NumeroCuota = i;
                        cls_Plan_Pagos.VlrCuota = txt_valor_cuota.Text;
                        DateTime FechaPago;
                        switch (cbx_modo_pago.Text)
                        {
                            case "Diario":
                                FechaPago = new DateTime();
                                FechaPago = dtt_fecha_primer_pago.Value;
                                if (i > 1)
                                {
                                    FechaPago = FechaPago.AddDays(i - 1);
                                }
                                cls_Plan_Pagos.FechaCuota = FechaPago.ToString();
                                break;
                            case "Semanal":
                                FechaPago = new DateTime();
                                FechaPago = dtt_fecha_primer_pago.Value;
                                if (i > 1)
                                {
                                    FechaPago = FechaPago.AddDays(7 * (i-1));
                                }                      
                                cls_Plan_Pagos.FechaCuota = FechaPago.ToString();
                                break;
                            case "Quincenal":
                                FechaPago = new DateTime();
                                FechaPago = dtt_fecha_primer_pago.Value;
                                if (i > 1)
                                {
                                    FechaPago = FechaPago.AddDays(15 * (i - 1));
                                }
                                cls_Plan_Pagos.FechaCuota = FechaPago.ToString();
                                break;
                            case "Mensual":
                                FechaPago = new DateTime();
                                FechaPago = dtt_fecha_primer_pago.Value;
                                if (i > 1)
                                {
                                    FechaPago = FechaPago.AddDays(30 * (i - 1));
                                }
                                cls_Plan_Pagos.FechaCuota = FechaPago.ToString();
                                break;
                            case "Semestral":
                                FechaPago = new DateTime();
                                FechaPago = dtt_fecha_primer_pago.Value;
                                if (i > 1)
                                {
                                    FechaPago = FechaPago.AddDays(180 * (i - 1));
                                }
                                cls_Plan_Pagos.FechaCuota = FechaPago.ToString();
                                break;
                            case "Anual":
                                FechaPago = new DateTime();
                                FechaPago = dtt_fecha_primer_pago.Value;
                                if (i > 1)
                                {
                                    FechaPago = FechaPago.AddDays(365 * (i - 1));
                                }
                                cls_Plan_Pagos.FechaCuota = FechaPago.ToString();
                                break;
                            default:
                                break;
                        }
                        cls_Plan_Pagos.Estado = "Pendiente";
                        cls_Plan_Pagos.FechaRegistro = DateTime.Now.ToString();
                        v_ok2 = cls_Plan_Pagos.mtd_registrar();
                        if (v_ok2)
                        {
                            exitosas++;
                        }
                        else
                        {
                            errores++;
                        }
                    }
                    MessageBox.Show("Plan de pagos registrado correctamente: Exitoso: "+exitosas+" , Errores: "+errores+"");
                    mtd_limpiar();
                    mtd_Cargar_cuenta_cobro();
                    v_registro = true;
                    txt_vlr_prestamo.Focus();
                    lbl_id_cliente.Text = "0";
                }
            }
        }
        private void mtd_editar()
        {
            v_validado = 0;
            errorProvider.Clear();
            if (txt_cliente.Text.Trim() == "")
            {
                errorProvider.SetError(txt_cliente, "Ingrese cliente");
                v_validado++;
            }
            if (txt_vlr_prestamo.Text.Trim() == "")
            {
                errorProvider.SetError(txt_vlr_prestamo, "Ingrese valor prestamo");
                v_validado++;
            }
            if (txt_vlr_interes.Text.Trim() == "")
            {
                errorProvider.SetError(txt_vlr_interes, "Ingrese valor interes");
                v_validado++;
            }
            if (txt_porcentaje_interes.Text.Trim() == "")
            {
                errorProvider.SetError(txt_porcentaje_interes, "Ingrese porcentaje interes");
                v_validado++;
            }
            if (txt_num_cuotas.Text.Trim() == "")
            {
                errorProvider.SetError(txt_num_cuotas, "Ingrese numero de cuotas");
                v_validado++;
            }
            if (txt_valor_total.Text.Trim() == "")
            {
                errorProvider.SetError(txt_valor_total, "Ingrese valor total");
                v_validado++;
            }
            if (txt_num_cuotas.Text.Trim() == "0")
            {
                errorProvider.SetError(txt_num_cuotas, "Numero de cuotas debe ser mayor a cero");
                v_validado++;
            }
            if (txt_num_cuotas.Text.Trim() == "")
            {
                errorProvider.SetError(txt_num_cuotas, "Ingrese numero de cuotas");
                v_validado++;
            }

            if (v_validado == 0)
            {
                cls_Cuenta_Cobro.Id = Convert.ToInt32(lbl_id_cuenta_cobro.Text);
                cls_Cuenta_Cobro.Id_cliente = Convert.ToInt32(lbl_id_cliente.Text);
                cls_Cuenta_Cobro.MontoPrestamo = Convert.ToDouble(txt_vlr_prestamo.Text);
                cls_Cuenta_Cobro.ValorInteres = Convert.ToDouble(txt_vlr_interes.Text);
                cls_Cuenta_Cobro.PorcentajeInteres = txt_porcentaje_interes.Text;
                cls_Cuenta_Cobro.NumeroCuotas = Convert.ToInt32(txt_num_cuotas.Text);
                cls_Cuenta_Cobro.ModoPago = cbx_modo_pago.Text;
                cls_Cuenta_Cobro.DiaPago = cbx_dia_pago.Text;
                cls_Cuenta_Cobro.DiasFechaPago = txt_dia_fecha_pago.Text;
                cls_Cuenta_Cobro.FechaPrimerPago = dtt_fecha_primer_pago.Text;
                cls_Cuenta_Cobro.Estado = "Activo";
                cls_Cuenta_Cobro.Nota = txt_nota.Text;
                cls_Cuenta_Cobro.FechaRegistros = DateTime.Now.ToString();

                v_ok = cls_Cuenta_Cobro.mtd_Editar();

                if (v_ok == true)
                {
                    MessageBox.Show("Cuenta cobro Editada correctamente");
                    bool v_ok2 = false;
                    cls_Plan_Pagos.Id_cuentaCobro = Convert.ToInt32(lbl_id_cuenta_cobro.Text);
                    v_ok2 = cls_Plan_Pagos.mtd_eliminar_cuentaCobro();
                    if (v_ok2 == true)
                    {
                        int exitosas = 0;
                        int errores = 0;

                        for (int i = 1; i <= Convert.ToInt32(txt_num_cuotas.Text); i++)
                        {
                            cls_Plan_Pagos.Id_cuentaCobro = Convert.ToInt32(lbl_id_cuenta_cobro.Text);
                            cls_Plan_Pagos.NumeroCuota = i;
                            cls_Plan_Pagos.VlrCuota = txt_valor_cuota.Text;
                            DateTime FechaPago;
                            switch (cbx_modo_pago.Text)
                            {
                                case "Diario":
                                    FechaPago = new DateTime();
                                    FechaPago = dtt_fecha_primer_pago.Value;
                                    if (i > 1)
                                    {
                                        FechaPago = FechaPago.AddDays(i - 1);
                                    }
                                    cls_Plan_Pagos.FechaCuota = FechaPago.ToString();
                                    break;
                                case "Semanal":
                                    FechaPago = new DateTime();
                                    FechaPago = dtt_fecha_primer_pago.Value;
                                    if (i > 1)
                                    {
                                        FechaPago = FechaPago.AddDays(7 * (i - 1));
                                    }
                                    cls_Plan_Pagos.FechaCuota = FechaPago.ToString();
                                    break;
                                case "Quincenal":
                                    FechaPago = new DateTime();
                                    FechaPago = dtt_fecha_primer_pago.Value;
                                    if (i > 1)
                                    {
                                        FechaPago = FechaPago.AddDays(15 * (i - 1));
                                    }
                                    cls_Plan_Pagos.FechaCuota = FechaPago.ToString();
                                    break;
                                case "Mensual":
                                    FechaPago = new DateTime();
                                    FechaPago = dtt_fecha_primer_pago.Value;
                                    if (i > 1)
                                    {
                                        FechaPago = FechaPago.AddDays(30 * (i - 1));
                                    }
                                    cls_Plan_Pagos.FechaCuota = FechaPago.ToString();
                                    break;
                                case "Semestral":
                                    FechaPago = new DateTime();
                                    FechaPago = dtt_fecha_primer_pago.Value;
                                    if (i > 1)
                                    {
                                        FechaPago = FechaPago.AddDays(180 * (i - 1));
                                    }
                                    cls_Plan_Pagos.FechaCuota = FechaPago.ToString();
                                    break;
                                case "Anual":
                                    FechaPago = new DateTime();
                                    FechaPago = dtt_fecha_primer_pago.Value;
                                    if (i > 1)
                                    {
                                        FechaPago = FechaPago.AddDays(365 * (i - 1));
                                    }
                                    cls_Plan_Pagos.FechaCuota = FechaPago.ToString();
                                    break;
                                default:
                                    break;
                            }
                            cls_Plan_Pagos.Estado = "Pendiente";
                            cls_Plan_Pagos.FechaRegistro = DateTime.Now.ToString();
                            v_ok2 = cls_Plan_Pagos.mtd_registrar();
                            if (v_ok2)
                            {
                                exitosas++;
                            }
                            else
                            {
                                errores++;
                            }
                        }
                        MessageBox.Show("Plan de pagos registrado correctamente: Exitoso: " + exitosas + " , Errores: " + errores + "");
                    }
                    mtd_limpiar();
                    mtd_Cargar_cuenta_cobro();
                    v_registro = true;
                    txt_vlr_prestamo.Focus();
                    lbl_id_cliente.Text = "0";
                }
            }
        }
        private void mtd_limpiar()
        {
            errorProvider.Clear();
            txt_cliente.Text = "";
            txt_vlr_prestamo.Text = "";
            txt_vlr_interes.Text = "";
            txt_porcentaje_interes.Text = "";
            txt_num_cuotas.Text = "";
            cbx_modo_pago.SelectedIndex = 0;
            cbx_dia_pago.SelectedIndex = 0;
            txt_dia_fecha_pago.Text = "";
            txt_nota.Text = "";
            v_registro = true;
            dtg_cuenta_cobro.DataSource = null;
            txt_valor_total.Text = "";
            txt_valor_cuota.Text = "";
            lbl_id_cliente.Text = "0";
            lbl_id_cuenta_cobro.Text = "0";
        }
        private void mtd_Cargar_cuenta_cobro()
        {
            cls_Cuenta_Cobro.v_buscar = "";
            v_dt = cls_Cuenta_Cobro.mtd_consultar_cuenta_cobro();
            dtg_cuenta_cobro.DataSource = null;
            double MontoPrestamo = 0;
            double vlr_interes = 0;
            for (int i = 0; i < v_dt.Rows.Count; i++)
            {
                DataRow fila = v_dt.Rows[i];
                MontoPrestamo = Convert.ToDouble(fila["MontoPrestamo"]);
                fila["MontoPrestamo"] = MontoPrestamo.ToString();
                vlr_interes = Convert.ToDouble(fila["ValorInteres"]);
                fila["ValorInteres"] = vlr_interes.ToString();
            }
            dtg_cuenta_cobro.DataSource = v_dt;
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            double MontoPrestamo = 0;
            double vlr_interes = 0;
            int validado = 0;
            DataTable dt_cuentas_cobro = new DataTable();

            if (dtg_cuenta_cobro.Rows.Count > 0)
            {
                if (dtg_cuenta_cobro.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow rows in dtg_cuenta_cobro.SelectedRows)
                    {
                        cls_Cuenta_Cobro.v_buscar = rows.Cells["IdCuentaCobro"].Value.ToString();
                        dt_cuentas_cobro = cls_Cuenta_Cobro.mtd_consultar_cuenta_cobro_en_plan_pagos();
                    }

                    foreach (DataRow item in dt_cuentas_cobro.Rows)
                    {
                        if (item["Estado"].ToString() == "Pago")
                        {
                            validado++;
                        }
                    }
                    if (validado == 0)
                    {
                        errorProvider.Clear();
                        v_registro = false;
                        foreach (DataGridViewRow row in dtg_cuenta_cobro.SelectedRows)
                        {
                            lbl_id_cuenta_cobro.Text = row.Cells["IdCuentaCobro"].Value.ToString();
                            lbl_id_cliente.Text = row.Cells["Id_cliente"].Value.ToString();
                            txt_cliente.Text = row.Cells["NumeroIdentificacion"].Value.ToString();
                            MontoPrestamo = Convert.ToDouble(row.Cells["MontoPrestamo"].Value);
                            txt_vlr_prestamo.Text = MontoPrestamo.ToString();
                            vlr_interes = Convert.ToDouble(row.Cells["ValorInteres"].Value);
                            txt_vlr_interes.Text = vlr_interes.ToString();
                            txt_porcentaje_interes.Text = row.Cells["PorcentajeInteres"].Value.ToString();
                            txt_num_cuotas.Text = row.Cells["NumeroCuotas"].Value.ToString();
                            cbx_modo_pago.Text = row.Cells["ModoPago"].Value.ToString();
                            cbx_dia_pago.Text = row.Cells["DiaPago"].Value.ToString();
                            txt_dia_fecha_pago.Text = row.Cells["DiasFechaPago"].Value.ToString();
                            txt_nota.Text = row.Cells["Nota"].Value.ToString();

                            double valorTotal = Convert.ToDouble(txt_vlr_prestamo.Text) + Convert.ToDouble(txt_vlr_interes.Text);
                            txt_valor_total.Text = valorTotal.ToString();

                            double valorCuota = Convert.ToDouble(txt_valor_total.Text) / Convert.ToInt32(txt_num_cuotas.Text);
                            txt_valor_cuota.Text = valorCuota.ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cuenta de cobro no se puede editar, por que ya tiene abonos");
                    } 
                }
            }
        }
        private void mtd_eliminar()
        {
            int validado = 0;
            DataTable dt_cuentas_cobro = new DataTable();
            if (dtg_cuenta_cobro.Rows.Count > 0)
            {
                if (dtg_cuenta_cobro.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow rows in dtg_cuenta_cobro.SelectedRows)
                    {
                        cls_Cuenta_Cobro.v_buscar = rows.Cells["IdCuentaCobro"].Value.ToString();
                        dt_cuentas_cobro = cls_Cuenta_Cobro.mtd_consultar_cuenta_cobro_en_plan_pagos();
                    }

                    foreach (DataRow item in dt_cuentas_cobro.Rows)
                    {
                        if (item["Estado"].ToString() == "Pago")
                        {
                            validado++;
                        }
                    }
                    if (validado == 0)
                    {
                        Eliminados = 0;
                        Error = 0;
                        v_contador = dtg_cuenta_cobro.SelectedRows.Count;
                        DialogResult dialogResult = MessageBox.Show("¿Está seguro de que desea Eliminar " + v_contador + "  cuentas de cobro?", "", MessageBoxButtons.OKCancel);

                        if (dialogResult == DialogResult.OK)
                        {
                            foreach (DataGridViewRow rows in dtg_cuenta_cobro.SelectedRows)
                            {
                                cls_Cuenta_Cobro.Id = Convert.ToInt32(rows.Cells["IdCuentaCobro"].Value);
                                v_ok = cls_Cuenta_Cobro.mtd_eliminar();
                                if (v_ok)
                                {
                                    Eliminados++;
                                }
                                else
                                {
                                    Error++;
                                }
                            }
                            MessageBox.Show("Eliminados: " + Eliminados + ", Errores: " + Error);
                            mtd_Cargar_cuenta_cobro();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cuenta de cobro no se puede eliminar, por que ya tiene abonos");
                    }
                }
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            mtd_eliminar();
        }

        private void txt_vlr_interes_KeyUp(object sender, KeyEventArgs e)
        {
            v_validado = 0;
            if (txt_vlr_prestamo.Text.Trim() == "")
            {
                errorProvider.SetError(txt_vlr_prestamo, "Ingrese valor prestamo");
                v_validado++;
            }
            if (txt_vlr_interes.Text.Trim() == "")
            {
                errorProvider.SetError(txt_vlr_interes, "Ingrese valor interes");
                v_validado++;
            }
            double valorTotal = 0;
            if (v_validado == 0)
            {
                Margen = (Convert.ToDouble(txt_vlr_interes.Text) / Convert.ToDouble(txt_vlr_prestamo.Text)) * 100;
                txt_porcentaje_interes.Text = Margen.ToString();
                valorTotal = Convert.ToDouble(txt_vlr_prestamo.Text) + Convert.ToDouble(txt_vlr_interes.Text);
                txt_valor_total.Text = valorTotal.ToString();
            }
            else
            {
                txt_porcentaje_interes.Text = "";
            }        
        }

        private void txt_porcentaje_interes_KeyUp(object sender, KeyEventArgs e)
        {
            double porcentaje = 0;
            double valorfinal = 0;
            v_validado = 0;

            if (txt_vlr_prestamo.Text.Trim() == "")
            {
                errorProvider.SetError(txt_vlr_prestamo, "Ingrese valor prestamo");
                v_validado++;
            }
            if (txt_porcentaje_interes.Text.Trim() == "")
            {
                errorProvider.SetError(txt_porcentaje_interes, "Ingrese porcentaje");
                v_validado++;
            }
            double valorTotal = 0;
            if (v_validado == 0)
            {
                porcentaje = (Convert.ToDouble(txt_porcentaje_interes.Text) / 100);
                valorfinal = porcentaje * Convert.ToDouble(txt_vlr_prestamo.Text);
                txt_vlr_interes.Text = valorfinal.ToString();
                valorTotal = Convert.ToDouble(txt_vlr_prestamo.Text) + Convert.ToDouble(txt_vlr_interes.Text);
                txt_valor_total.Text = valorTotal.ToString();
            }
            else
            {
                txt_vlr_interes.Text = "";
                txt_valor_total.Text = "";
            }
        }

        private void txt_num_cuotas_KeyUp(object sender, KeyEventArgs e)
        {
            v_validado = 0;
            errorProvider.Clear();
            if (txt_vlr_prestamo.Text.Trim() == "")
            {
                errorProvider.SetError(txt_vlr_prestamo, "Ingrese valor prestamo");
                v_validado++;
            }
            if (txt_vlr_interes.Text.Trim() == "")
            {
                errorProvider.SetError(txt_vlr_interes, "Ingrese valor interes");
                v_validado++;
            }
            if (txt_porcentaje_interes.Text.Trim() == "")
            {
                errorProvider.SetError(txt_porcentaje_interes, "Ingrese porcentaje");
                v_validado++;
            }
            if (txt_valor_total.Text.Trim() == "")
            {
                errorProvider.SetError(txt_valor_total, "Ingrese valor total");
                v_validado++;
            }
            if (txt_num_cuotas.Text.Trim() == "0")
            {
                errorProvider.SetError(txt_num_cuotas, "Numero de cuotas debe ser mayor a cero");
                v_validado++;
            }
            if (txt_num_cuotas.Text.Trim() == "")
            {
                errorProvider.SetError(txt_num_cuotas, "Ingrese numero de cuotas");
                v_validado++;
            }
            double valorCuota = 0;
            if (v_validado == 0)
            {
                valorCuota = Convert.ToDouble(txt_valor_total.Text) / Convert.ToInt32(txt_num_cuotas.Text);
                txt_valor_cuota.Text = valorCuota.ToString();
            }
            else
            {
                txt_valor_cuota.Text = "";
            }
        }

        private void txt_vlr_prestamo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_vlr_prestamo.Text))
            {
                if (!double.TryParse(txt_vlr_prestamo.Text, out double numero))
                {
                    MessageBox.Show("Por favor, ingrese un número válido.");
                    txt_vlr_prestamo.Clear();
                }
            }
        }

        private void txt_vlr_interes_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_vlr_interes.Text))
            {
                if (!double.TryParse(txt_vlr_interes.Text, out double numero))
                {
                    MessageBox.Show("Por favor, ingrese un número válido.");
                    txt_vlr_interes.Clear();
                }
            }
        }

        private void txt_porcentaje_interes_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_porcentaje_interes.Text))
            {
                if (!double.TryParse(txt_porcentaje_interes.Text, out double numero))
                {
                    MessageBox.Show("Por favor, ingrese un número válido.");
                    txt_porcentaje_interes.Clear();
                }
            }
        }

        private void txt_num_cuotas_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_num_cuotas.Text))
            {
                if (!int.TryParse(txt_num_cuotas.Text, out int numero))
                {
                    MessageBox.Show("Por favor, ingrese un número válido.");
                    txt_num_cuotas.Clear();
                }
            }
        }

        private void txt_buscar_KeyUp(object sender, KeyEventArgs e)
        {
            cls_Cuenta_Cobro.v_buscar = txt_buscar.Text;
            v_dt = cls_Cuenta_Cobro.mtd_consultar_cuenta_cobro();
            dtg_cuenta_cobro.DataSource = null;
            double MontoPrestamo = 0;
            double vlr_interes = 0;
            for (int i = 0; i < v_dt.Rows.Count; i++)
            {
                DataRow fila = v_dt.Rows[i];
                MontoPrestamo = Convert.ToDouble(fila["MontoPrestamo"]);
                fila["MontoPrestamo"] = MontoPrestamo.ToString();
                vlr_interes = Convert.ToDouble(fila["ValorInteres"]);
                fila["ValorInteres"] = vlr_interes.ToString();
            }
            dtg_cuenta_cobro.DataSource = v_dt;
        }

        private void btn_consultar_Click(object sender, EventArgs e)
        {
            cls_Cuenta_Cobro.v_buscar = txt_buscar.Text;
            v_dt = cls_Cuenta_Cobro.mtd_consultar_cuenta_cobro();
            dtg_cuenta_cobro.DataSource = null;
            double MontoPrestamo = 0;
            double vlr_interes = 0;
            for (int i = 0; i < v_dt.Rows.Count; i++)
            {
                DataRow fila = v_dt.Rows[i];
                MontoPrestamo = Convert.ToDouble(fila["MontoPrestamo"]);
                fila["MontoPrestamo"] = MontoPrestamo.ToString();
                vlr_interes = Convert.ToDouble(fila["ValorInteres"]);
                fila["ValorInteres"] = vlr_interes.ToString();
            }
            dtg_cuenta_cobro.DataSource = v_dt;
        }
    }
}