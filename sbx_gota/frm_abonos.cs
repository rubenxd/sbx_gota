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
            //double VlrAbono = 0;
            //for (int i = 0; i < v_dt.Rows.Count; i++)
            //{
            //    DataRow fila = v_dt.Rows[i];
            //    VlrAbono = Convert.ToDouble(fila["ValorAbono"]);
            //    fila["ValorAbono"] = VlrAbono.ToString();
            //}
            dtg_abonos.DataSource = v_dt;
        }

        private void txt_buscar_KeyUp(object sender, KeyEventArgs e)
        {
            cls_Abonos.v_buscar = txt_buscar.Text;
            v_dt = cls_Abonos.mtd_consultar_Abonos();
            dtg_abonos.DataSource = null;
            //double VlrAbono = 0;
            //for (int i = 0; i < v_dt.Rows.Count; i++)
            //{
            //    DataRow fila = v_dt.Rows[i];
            //    VlrAbono = Convert.ToDouble(fila["ValorAbono"]);
            //    fila["ValorAbono"] = VlrAbono.ToString();
            //}
            dtg_abonos.DataSource = v_dt;
        }

        private void frm_abonos_Load(object sender, EventArgs e)
        {
            //cls_Abonos.v_buscar = txt_buscar.Text;
            //v_dt = cls_Abonos.mtd_consultar_Abonos();
            //dtg_abonos.DataSource = null;
            //double VlrAbono = 0;
            //for (int i = 0; i < v_dt.Rows.Count; i++)
            //{
            //    DataRow fila = v_dt.Rows[i];
            //    VlrAbono = Convert.ToDouble(fila["ValorAbono"]);
            //    fila["ValorAbono"] = VlrAbono.ToString();
            //}
            //dtg_abonos.DataSource = v_dt;
        }
    }
}
