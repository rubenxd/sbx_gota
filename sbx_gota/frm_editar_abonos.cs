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
    public partial class frm_editar_abonos : Form
    {
        //Delegado
        public delegate void EnviarInfo(string dato);
        public event EnviarInfo Enviainfo;

        public frm_editar_abonos()
        {
            InitializeComponent();
        }

        private void txt_valor_abono_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_valor_abono.Text))
            {
                if (!double.TryParse(txt_valor_abono.Text, out double numero))
                {
                    MessageBox.Show("Por favor, ingrese un número válido.");
                    txt_valor_abono.Clear();
                }
            }
        }
        bool ok = false;
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            cls_abonos cls_Abonos = new cls_abonos();
            cls_Abonos.Id = Convert.ToInt32(txt_id_abono.Text);
            cls_Abonos.ValorAbono = txt_valor_abono.Text;
            cls_Abonos.Nota = txt_nota.Text;
            cls_Abonos.FechaRegistro = DateTime.Now.ToString();
            ok = cls_Abonos.mtd_Editar();
            if (ok)
            {
                MessageBox.Show("Abono editado correctamente");
                Enviainfo("correcto");
                this.Dispose();
            }
        }
    }
}
