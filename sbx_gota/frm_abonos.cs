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
    public partial class frm_abonos : Form
    {
        cls_abonos cls_Abonos = new cls_abonos();
        DataTable v_dt;

        public frm_abonos()
        {
            InitializeComponent();
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            frm_agregar_abono frm_Agregar_Abono = new frm_agregar_abono();
            frm_Agregar_Abono.ShowDialog();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            cls_Abonos.v_buscar = txt_buscar.Text;
            v_dt = cls_Abonos.mtd_consultar_Abonos();
            dtg_abonos.DataSource = null;
            dtg_abonos.DataSource = v_dt;
        }

        private void txt_buscar_KeyUp(object sender, KeyEventArgs e)
        {
            cls_Abonos.v_buscar = txt_buscar.Text;
            v_dt = cls_Abonos.mtd_consultar_Abonos();
            dtg_abonos.DataSource = null;
            dtg_abonos.DataSource = v_dt;
        }

        private void frm_abonos_Load(object sender, EventArgs e)
        {
        }
    
        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            mtd_eliminar();
        }

        int Eliminados = 0;
        int Error = 0;
        int v_contador = 0;
        bool v_ok = false;
        private void mtd_eliminar()
        {      
            if (dtg_abonos.Rows.Count > 0)
            {
                if (dtg_abonos.SelectedRows.Count > 0)
                {
                    Eliminados = 0;
                    Error = 0;
                    v_contador = dtg_abonos.SelectedRows.Count;
                    DialogResult dialogResult = MessageBox.Show("¿Está seguro de que desea Eliminar " + v_contador + "  Abonos?", "", MessageBoxButtons.OKCancel);

                    if (dialogResult == DialogResult.OK)
                    {
                        foreach (DataGridViewRow rows in dtg_abonos.SelectedRows)
                        {
                            cls_Abonos.Id = Convert.ToInt32(rows.Cells["IdAbono"].Value);
                            cls_Abonos.Id_plan_pagos = Convert.ToInt32(rows.Cells["Id_plan_pagos"].Value);
                            v_ok = cls_Abonos.mtd_eliminar();
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

                        cls_Abonos.v_buscar = txt_buscar.Text;
                        v_dt = cls_Abonos.mtd_consultar_Abonos();
                        dtg_abonos.DataSource = null;
                        dtg_abonos.DataSource = v_dt;
                    }
                }
            }
        }

        private void dtg_abonos_DoubleClick(object sender, EventArgs e)
        {
            int v_filas = 0;
            string v_dato = "";
            DataTable v_dt2 = new DataTable();
            cls_cuenta_cobro cls_Cuenta_Cobro = new cls_cuenta_cobro();
            frm_agregar_abono frm_Agregar_Abono = new frm_agregar_abono();
            cls_plan_pagos cls_Plan_Pagos = new cls_plan_pagos();
            if (dtg_abonos.Rows.Count > 0)
            {
                v_filas = dtg_abonos.CurrentRow.Index;
                v_dato = dtg_abonos[4, v_filas].Value.ToString();
                cls_Cuenta_Cobro.v_buscar = v_dato;
                v_dt = cls_Cuenta_Cobro.mtd_consultar_cuenta_cobro_exacto();
                DataRow row = v_dt.Rows[0];
                frm_Agregar_Abono.txt_cuentaCobro.Text = row["IdCuentaCobro"].ToString();
                frm_Agregar_Abono.txt_id_cuenta_cobro.Text = row["IdCuentaCobro"].ToString();
                frm_Agregar_Abono.txt_identificacion.Text = row["NumeroIdentificacion"].ToString();
                frm_Agregar_Abono.txt_nombres.Text = row["Cliente"].ToString();
                frm_Agregar_Abono.txt_vlr_interes.Text = row["ValorInteres"].ToString();
                frm_Agregar_Abono.txt_vlr_prestamo.Text = row["MontoPrestamo"].ToString();
                frm_Agregar_Abono.txt_num_cuotas.Text = row["NumeroCuotas"].ToString();
                double valorTotal = Convert.ToDouble(frm_Agregar_Abono.txt_vlr_prestamo.Text) + Convert.ToDouble(frm_Agregar_Abono.txt_vlr_interes.Text);
                frm_Agregar_Abono.txt_valor_total.Text = valorTotal.ToString("N0");
                double valorCuota = Convert.ToDouble(frm_Agregar_Abono.txt_valor_total.Text) / Convert.ToInt32(frm_Agregar_Abono.txt_num_cuotas.Text);
                frm_Agregar_Abono.txt_valor_cuota.Text = valorCuota.ToString("N0");
                frm_Agregar_Abono.cbx_dia_pago.Text = row["DiaPago"].ToString();
                frm_Agregar_Abono.cbx_modo_pago.Text = row["ModoPago"].ToString();
                frm_Agregar_Abono.txt_dia_fecha_pago.Text = row["DiasFechaPago"].ToString();
                frm_Agregar_Abono.txt_nota.Text = row["Nota"].ToString();
                frm_Agregar_Abono.txt_porcentaje_interes.Text = row["PorcentajeInteres"].ToString();
                frm_Agregar_Abono.txt_fecha_registro.Text = row["FechaRegistros"].ToString();
                //carga plan de pagos
                frm_Agregar_Abono.dtg_plan_pagos.DataSource = null;
                //double VlrCuota = 0;
                //double VlrAbono = 0;
                //double vlrSaldo = 0;
                cls_Plan_Pagos.v_buscar = frm_Agregar_Abono.txt_id_cuenta_cobro.Text;
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
                frm_Agregar_Abono.dtg_plan_pagos.DataSource = v_dt2;
                double PagoTotal = 0;
                int pagoPendientes = 0;
                foreach (DataGridViewRow rows in frm_Agregar_Abono.dtg_plan_pagos.Rows)
                {
                    PagoTotal += Convert.ToDouble(rows.Cells["Saldo"].Value);
                    if (rows.Cells["Estado"].Value.ToString() == "Pendiente")
                    {
                        pagoPendientes++;
                    }
                }
                frm_Agregar_Abono.lbl_pago_total.Text = PagoTotal.ToString("N0");

                if (pagoPendientes > 0)
                {
                    frm_Agregar_Abono.btn_pago_total.Enabled = true;
                }
                frm_Agregar_Abono.ShowDialog();
            }
        }
    }
}
