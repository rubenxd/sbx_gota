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
    public partial class frm_ajustes : Form
    {
        DataTable dt;
        cls_parametros cls_Parametros;
        bool ok = true;

        public frm_ajustes()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            cls_Parametros = new cls_parametros();
            dt = cls_Parametros.mtd_consultar_parametros();
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["Nombre"].ToString() == "RutaBackup")
                {
                    cls_Parametros.Nombre = "RutaBackup";
                    cls_Parametros.Valor = txt_ruta_backup.Text;
                    cls_Parametros.descripcion = "ruta en donde se guardara la copia de seguridad";
                    cls_Parametros.Id = Convert.ToInt32(lbl_id_ruta_backup.Text);
                    ok = cls_Parametros.mtd_Editar();
                    if (ok)
                    {
                        MessageBox.Show("Actualizado correctamente");
                    }
                }
                else if (dr["Nombre"].ToString() == "RutaDestino")
                {
                    cls_Parametros.Nombre = "RutaDestino";
                    cls_Parametros.Valor = txt_ruta_destino.Text;
                    cls_Parametros.descripcion = "ruta a donde se movera la copia de seguridad";
                    cls_Parametros.Id = Convert.ToInt32(lbl_ruta_destino.Text);
                    ok = cls_Parametros.mtd_Editar();
                    if (ok)
                    {
                        MessageBox.Show("Actualizado correctamente");
                    }
                }
            }          
            mtd_cargar();
        }

        private void frm_ajustes_Load(object sender, EventArgs e)
        {
            mtd_cargar();
        }

        private void mtd_cargar()
        {
            dt = new DataTable();
            cls_Parametros = new cls_parametros();
            dt = cls_Parametros.mtd_consultar_parametros();
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["Nombre"].ToString() == "RutaBackup")
                {
                    txt_ruta_backup.Text = dr["Valor"].ToString();
                    lbl_id_ruta_backup.Text = dr["Id"].ToString();
                }else if (dr["Nombre"].ToString() == "RutaDestino")
                {
                    txt_ruta_destino.Text = dr["Valor"].ToString();
                    lbl_ruta_destino.Text = dr["Id"].ToString();
                }
            }
        }
    }
}
