using sbx_gota.MODEL;
using System;
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

        public frm_cobro_pendiente()
        {
            InitializeComponent();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            cls_Pagos_Pendientes = new cls_pagos_pendientes();
            v_dt = new DataTable();
            cls_Pagos_Pendientes.v_buscar = txt_buscar.Text;
            cls_Pagos_Pendientes.FechaIni = dtp_fecha_ini.Value;
            cls_Pagos_Pendientes.FechaFin = dtp_fecha_fin.Value;
            v_dt = cls_Pagos_Pendientes.mtd_consultar_pagos_pendientes();
            dtg_cobro_pendiente.DataSource = null;
            if (cbx_dia_semana.Text == "Todos")
            {
                dtg_cobro_pendiente.DataSource = v_dt;
            }
            else
            {
                // Nombre del día de la semana a filtrar (en español)
                string diaSemanaFiltrar = cbx_dia_semana.Text;
                switch (diaSemanaFiltrar)
                {
                    case "Lunes":
                        var filasFiltradas = v_dt.AsEnumerable()
                        .Where(row => row.Field<DateTime>("FechaCuota").DayOfWeek == DayOfWeek.Monday);
                        if (filasFiltradas.Any())
                        {
                            dtg_cobro_pendiente.DataSource = filasFiltradas.CopyToDataTable();
                        }
                        else
                        {
                            MessageBox.Show("No hay eventos en el día especificado.");
                        }
                        break;
                    case "Martes":
                        filasFiltradas = v_dt.AsEnumerable()
                        .Where(row => row.Field<DateTime>("FechaCuota").DayOfWeek == DayOfWeek.Tuesday);
                        if (filasFiltradas.Any())
                        {
                            dtg_cobro_pendiente.DataSource = filasFiltradas.CopyToDataTable();
                        }
                        else
                        {
                            MessageBox.Show("No hay eventos en el día especificado.");
                        }
                        break;
                    case "Miercoles":
                        filasFiltradas = v_dt.AsEnumerable()
                        .Where(row => row.Field<DateTime>("FechaCuota").DayOfWeek == DayOfWeek.Wednesday);
                        if (filasFiltradas.Any())
                        {
                            dtg_cobro_pendiente.DataSource = filasFiltradas.CopyToDataTable();
                        }
                        else
                        {
                            MessageBox.Show("No hay eventos en el día especificado.");
                        }
                        break;
                    case "Jueves":
                        filasFiltradas = v_dt.AsEnumerable()
                        .Where(row => row.Field<DateTime>("FechaCuota").DayOfWeek == DayOfWeek.Thursday);
                        if (filasFiltradas.Any())
                        {
                            dtg_cobro_pendiente.DataSource = filasFiltradas.CopyToDataTable();
                        }
                        else
                        {
                            MessageBox.Show("No hay eventos en el día especificado.");
                        }
                        break;
                    case "Viernes":
                        filasFiltradas = v_dt.AsEnumerable()
                        .Where(row => row.Field<DateTime>("FechaCuota").DayOfWeek == DayOfWeek.Friday);
                        if (filasFiltradas.Any())
                        {
                            dtg_cobro_pendiente.DataSource = filasFiltradas.CopyToDataTable();
                        }
                        else
                        {
                            MessageBox.Show("No hay eventos en el día especificado.");
                        }
                        break;
                    case "Sabado":
                        filasFiltradas = v_dt.AsEnumerable()
                        .Where(row => row.Field<DateTime>("FechaCuota").DayOfWeek == DayOfWeek.Saturday);
                        if (filasFiltradas.Any())
                        {
                            dtg_cobro_pendiente.DataSource = filasFiltradas.CopyToDataTable();
                        }
                        else
                        {
                            MessageBox.Show("No hay eventos en el día especificado.");
                        }
                        break;
                    case "Domingo":
                        filasFiltradas = v_dt.AsEnumerable()
                        .Where(row => row.Field<DateTime>("FechaCuota").DayOfWeek == DayOfWeek.Sunday);
                        if (filasFiltradas.Any())
                        {
                            dtg_cobro_pendiente.DataSource = filasFiltradas.CopyToDataTable();
                        }
                        else
                        {
                            MessageBox.Show("No hay eventos en el día especificado.");
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void txt_buscar_KeyUp(object sender, KeyEventArgs e)
        {
            cls_Pagos_Pendientes = new cls_pagos_pendientes();
            v_dt = new DataTable();
            cls_Pagos_Pendientes.v_buscar = txt_buscar.Text;
            cls_Pagos_Pendientes.FechaIni = dtp_fecha_ini.Value;
            cls_Pagos_Pendientes.FechaFin = dtp_fecha_fin.Value;
            v_dt = cls_Pagos_Pendientes.mtd_consultar_pagos_pendientes();
            dtg_cobro_pendiente.DataSource = null;
            dtg_cobro_pendiente.DataSource = v_dt;
        }

        private void frm_cobro_pendiente_Load(object sender, EventArgs e)
        {
            cbx_dia_semana.SelectedIndex = 0;
        }
    }
}
