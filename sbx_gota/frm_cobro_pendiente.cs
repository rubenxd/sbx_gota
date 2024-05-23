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
            v_dt = cls_Pagos_Pendientes.mtd_consultar_pagos_pendientes();
            dtg_cobro_pendiente.DataSource = null;
            dtg_cobro_pendiente.DataSource = v_dt;
        }

        private void txt_buscar_KeyUp(object sender, KeyEventArgs e)
        {
            cls_Pagos_Pendientes = new cls_pagos_pendientes();
            v_dt = new DataTable();
            cls_Pagos_Pendientes.v_buscar = txt_buscar.Text;
            v_dt = cls_Pagos_Pendientes.mtd_consultar_pagos_pendientes();
            dtg_cobro_pendiente.DataSource = null;
            dtg_cobro_pendiente.DataSource = v_dt;
        }
    }
}
