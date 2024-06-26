﻿using sbx_gota.MODEL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sbx_gota
{
    public partial class frm_cobro_pendiente : Form
    {
        cls_pagos_pendientes cls_Pagos_Pendientes;
        DataTable v_dt;

        //Delegado
        public delegate void EnviarInfo(string dato);
        public event EnviarInfo Enviainfo;

        public frm_cobro_pendiente()
        {
            InitializeComponent();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            cls_Pagos_Pendientes = new cls_pagos_pendientes();
            v_dt = new DataTable();
            cls_Pagos_Pendientes.v_buscar = txt_buscar.Text;
            cls_Pagos_Pendientes.estado = cbx_estado.Text;
            if (cbx_tipo_filtro.Text == "Todos")
            {
                v_dt = cls_Pagos_Pendientes.mtd_consultar_pagos_pendientes3();
            }
            else
            {
                cls_Pagos_Pendientes.FechaFin = dtp_fecha_fin.Value;
                v_dt = cls_Pagos_Pendientes.mtd_consultar_pagos_pendientes2();
            }
            dtg_cobro_pendiente.DataSource = null;
            if (cbx_con_mora.Text == "En mora")
            {
                var query = from row in v_dt.AsEnumerable()
                            where row.Field<int>("DiasMora") > 0
                            select row;
                if (query.Count() > 0)
                {
                    DataTable filteredTable = query.CopyToDataTable();
                    dtg_cobro_pendiente.DataSource = filteredTable;
                }
            }
            else if (cbx_con_mora.Text == "Sin mora")
            {
                var query = from row in v_dt.AsEnumerable()
                            where row.Field<int>("DiasMora") == 0
                            select row;
                if (query.Count() > 0)
                {
                    DataTable filteredTable = query.CopyToDataTable();
                    dtg_cobro_pendiente.DataSource = filteredTable;
                }
            }
            else
            {
                dtg_cobro_pendiente.DataSource = v_dt;
            }
        }

        private void txt_buscar_KeyUp(object sender, KeyEventArgs e)
        {
            cls_Pagos_Pendientes = new cls_pagos_pendientes();
            v_dt = new DataTable();
            cls_Pagos_Pendientes.v_buscar = txt_buscar.Text;
            cls_Pagos_Pendientes.estado = cbx_estado.Text;
            if (cbx_tipo_filtro.Text == "Todos")
            {
                v_dt = cls_Pagos_Pendientes.mtd_consultar_pagos_pendientes3();
            }
            else
            {
                cls_Pagos_Pendientes.FechaFin = dtp_fecha_fin.Value;
                v_dt = cls_Pagos_Pendientes.mtd_consultar_pagos_pendientes2();
            }
            dtg_cobro_pendiente.DataSource = null;
            if (cbx_con_mora.Text == "En mora")
            {
                var query = from row in v_dt.AsEnumerable()
                            where row.Field<int>("DiasMora") > 0
                            select row;
                if (query.Count() > 0)
                {
                    DataTable filteredTable = query.CopyToDataTable();
                    dtg_cobro_pendiente.DataSource = filteredTable;
                }
            }
            else if (cbx_con_mora.Text == "Sin mora")
            {
                var query = from row in v_dt.AsEnumerable()
                            where row.Field<int>("DiasMora") == 0
                            select row;
                if (query.Count() > 0)
                {
                    DataTable filteredTable = query.CopyToDataTable();
                    dtg_cobro_pendiente.DataSource = filteredTable;
                }
            }
            else
            {
                dtg_cobro_pendiente.DataSource = v_dt;
            }
        }

        private void frm_cobro_pendiente_Load(object sender, EventArgs e)
        {
            cbx_dia_semana.SelectedIndex = 0;
            cbx_tipo_filtro.SelectedIndex = 0;
            cbx_con_mora.SelectedIndex = 0;
            cbx_estado.SelectedIndex = 0;
        }
        
        private void dtg_cobro_pendiente_DoubleClick(object sender, EventArgs e)
        {
            int v_filas = 0;
            string v_dato = "";
            DataTable v_dt2 = new DataTable();
            cls_cuenta_cobro cls_Cuenta_Cobro = new cls_cuenta_cobro();
            frm_agregar_abono frm_Agregar_Abono = new frm_agregar_abono();
            cls_plan_pagos cls_Plan_Pagos = new cls_plan_pagos();
            if (dtg_cobro_pendiente.Rows.Count > 0)
            {
                v_filas = dtg_cobro_pendiente.CurrentRow.Index;
                v_dato = dtg_cobro_pendiente[10, v_filas].Value.ToString();
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

                //carga plan de pagos
                frm_Agregar_Abono.dtg_plan_pagos.DataSource = null;

                cls_Plan_Pagos.v_buscar = frm_Agregar_Abono.txt_id_cuenta_cobro.Text;
                v_dt2 = cls_Plan_Pagos.mtd_consultar_planPagos();

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
        DataTable v_dt5;
        private void btn_exportar_excel_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            cls_plan_pagos cls_Plan_Pagos = new cls_plan_pagos();
            DataTable v_dt4 = new DataTable();
            v_dt5 = new DataTable();
            if (dtg_cobro_pendiente.Rows.Count > 0)
            {
                foreach (DataRow rowaa in v_dt.Rows)
                {
                    cls_Plan_Pagos.Id = Convert.ToInt32(rowaa["idPlanPagos"]);
                    v_dt4 = cls_Plan_Pagos.mtd_consultar_clientes_pendientes_a_excel();
                    v_dt5.Merge(v_dt4);
                }
                mtd_exporta_excel();
            }
            this.Cursor = Cursors.Default;
        }

        private void mtd_exporta_excel()
        {
            Microsoft.Office.Interop.Excel.Application Excel = new Microsoft.Office.Interop.Excel.Application();
            Excel.Application.Workbooks.Add(true);
            int IndiceColumna = 0;

            foreach (DataColumn columna in v_dt5.Columns)
            {
                    IndiceColumna++;
                    Excel.Cells[1, IndiceColumna] = columna.ColumnName;
            }
            int IndiceFila = 0;

            foreach (DataRow Row in v_dt5.Rows)
            {
                IndiceFila++;
                IndiceColumna = 0;

                foreach (DataColumn Columna in v_dt5.Columns)
                {
                        IndiceColumna++;
                        Excel.Cells[IndiceFila + 1, IndiceColumna] = Row[Columna.ColumnName];
                }
            }
            Excel.Visible = true;
        }
    }
}
