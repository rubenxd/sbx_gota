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
    public partial class frm_ayuda : Form
    {
        //Delegado
        public delegate void EnviarInfo(string dato);
        public event EnviarInfo Enviainfo;

        string Origen = "";
        cls_cliente cls_Cliente = new cls_cliente();
        cls_cuenta_cobro cls_Cuenta_Cobro = new cls_cuenta_cobro();
        DataTable v_dt;
        string v_dato = "";
        int v_filas = 0;

        public frm_ayuda()
        {
            InitializeComponent();
        }
        public frm_ayuda(string frm)
        {
            InitializeComponent();
            Origen = frm;
        }

        private void frm_ayuda_Load(object sender, EventArgs e)
        {
            v_filas = 0;
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            switch (Origen)
            {
                case "cuentaCobro":
                    cls_Cliente.v_buscar = txt_buscar.Text;
                    v_dt = cls_Cliente.mtd_consultar_cliente();
                    dtg_ayuda.DataSource = null;
                    dtg_ayuda.DataSource = v_dt;
                    break;
                case "agregaAbonos":
                    cls_Cuenta_Cobro.v_buscar = txt_buscar.Text;
                    v_dt = cls_Cuenta_Cobro.mtd_consultar_cuenta_cobro();
                    dtg_ayuda.DataSource = null;
                    dtg_ayuda.DataSource = v_dt;
                    break;
            }
        }

        private void txt_buscar_KeyUp(object sender, KeyEventArgs e)
        {
            switch (Origen)
            {
                case "cuentaCobro":
                    cls_Cliente.v_buscar = txt_buscar.Text;
                    v_dt = cls_Cliente.mtd_consultar_cliente();
                    dtg_ayuda.DataSource = null;
                    dtg_ayuda.DataSource = v_dt;
                    break;
                case "agregaAbonos":
                    cls_Cuenta_Cobro.v_buscar = txt_buscar.Text;
                    v_dt = cls_Cuenta_Cobro.mtd_consultar_cuenta_cobro();
                    dtg_ayuda.DataSource = null;
                    dtg_ayuda.DataSource = v_dt;
                    break;
            }
        }

        private void dtg_ayuda_DoubleClick(object sender, EventArgs e)
        {
            if (dtg_ayuda.Rows.Count > 0)
            {
                v_filas = dtg_ayuda.CurrentRow.Index;
                switch (Origen)
                {
                    case "cuentaCobro":
                        //Enviar item de producto    
                        v_dato = dtg_ayuda[0, v_filas].Value.ToString();
                        break;
                    case "agregaAbonos":
                        //Enviar item de producto    
                        v_dato = dtg_ayuda[0, v_filas].Value.ToString();
                        break;
                }
                Enviainfo(v_dato);
                this.Dispose();
            }
        }
    }
}
