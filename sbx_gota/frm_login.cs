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
    public partial class frm_login : Form
    {
        frm_inicio frm_Inicio;
        int v_validado = 0;
        DataTable v_dt;
        cls_login cls_Login;


        public frm_login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            mtd_validar();
            if (v_validado == 0)
            {
                frm_Inicio = new frm_inicio();
                v_dt = new DataTable();
                cls_Login = new cls_login();
                cls_Login.Usuario = txtUsuario.Text;
                cls_Login.Contrasena = txtContrasena.Text;
                v_dt = cls_Login.mtd_consultar_estado();
                if (v_dt.Rows.Count > 0)
                {
                    DataRow rows = v_dt.Rows[0];
                    if (rows["Id"].ToString() == "")
                    {
                        errorProvider.SetError(txtUsuario, "Usuario incorrecto");
                        errorProvider.SetError(txtContrasena, "Contraseña incorrecta");
                    }
                    else
                    {
                        frm_Inicio.Show();
                        this.Hide();
                    }
                }
                else
                {
                    errorProvider.SetError(txtUsuario, "Usuario incorrecto");
                    errorProvider.SetError(txtContrasena, "Contraseña incorrecta");
                }
            }
        }

        private void mtd_validar()
        {
            v_validado = 0;

            if (txtUsuario.Text == "" || txtUsuario.Text == "USUARIO")
            {
                errorProvider.SetError(txtUsuario, "Ingrese usuario");
                v_validado++;
            }
            if (txtContrasena.Text == "" || txtContrasena.Text == "CONTRASEÑA")
            {
                errorProvider.SetError(txtContrasena, "Ingrese Contraseña");
                v_validado++;
            }
        }

        private void frm_login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
