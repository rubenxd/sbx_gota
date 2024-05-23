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
    public partial class frm_cliente : Form
    {
        cls_cliente cls_Cliente = new cls_cliente();

        int v_validado = 0;
        bool v_registro = true;
        DataTable v_dt;
        bool v_ok = true;
        int Eliminados;
        int Error;
        int v_contador = 0;

        public frm_cliente()
        {
            InitializeComponent();
        }

        private void frm_cliente_Load(object sender, EventArgs e)
        {
            cbx_tipo_identificacion.SelectedIndex = 0;
            //v_dt = new DataTable();
            //cls_Cliente.v_buscar = "";
            //v_dt = cls_Cliente.mtd_consultar_cliente();
            //dtg_clientes.DataSource = v_dt;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            v_validado = 0;

            if (v_validado == 0)
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
        }

        private void mtd_guardar()
        {
            errorProvider.Clear();
            if (txt_nombres.Text.Trim() == "")
            {
                errorProvider.SetError(txt_nombres, "Ingrese Nombres");
                v_validado++;
            }
            if (txt_apellidos.Text.Trim() == "")
            {
                errorProvider.SetError(txt_apellidos, "Ingrese Apellidos");
                v_validado++;
            }
            if (txt_celular.Text.Trim() == "")
            {
                errorProvider.SetError(txt_celular, "Ingrese Celular");
                v_validado++;
            }
            if (txt_direccion.Text.Trim() == "")
            {
                errorProvider.SetError(txt_direccion, "Ingrese Direccion");
                v_validado++;
            }
            if (txt_identificacion.Text.Trim() == "")
            {
                errorProvider.SetError(txt_identificacion, "Ingrese identificacion");
                v_validado++;
            }
            else
            {
                cls_Cliente.v_buscar = txt_identificacion.Text;
                v_dt = cls_Cliente.mtd_consultar_cliente();
                if (v_dt.Rows.Count > 0)
                {
                    errorProvider.SetError(txt_identificacion, "identificacion ya existe");
                    v_validado++;
                }
            }

            if (v_validado == 0)
            {
                cls_Cliente.TipoIdentificacion = cbx_tipo_identificacion.Text;
                cls_Cliente.NumeroIdentificacion = txt_identificacion.Text;
                cls_Cliente.Nombres = txt_nombres.Text;
                cls_Cliente.Apellidos = txt_apellidos.Text;
                cls_Cliente.Celular = txt_celular.Text;
                cls_Cliente.Direccion = txt_direccion.Text;
                cls_Cliente.FechaRegistro = DateTime.Now.ToString();
                v_ok = cls_Cliente.mtd_registrar();

                if (v_ok == true)
                {
                    MessageBox.Show("Cliente registrado correctamente");                  
                    mtd_limpiar();
                    mtd_Cargar_cliente();
                    v_registro = true;
                    txt_identificacion.Focus();
                }
            }
        }
        private void mtd_editar()
        {
            errorProvider.Clear();
            if (txt_nombres.Text.Trim() == "")
            {
                errorProvider.SetError(txt_nombres, "Ingrese Nombres");
                v_validado++;
            }
            if (txt_apellidos.Text.Trim() == "")
            {
                errorProvider.SetError(txt_apellidos, "Ingrese Apellidos");
                v_validado++;
            }
            if (txt_celular.Text.Trim() == "")
            {
                errorProvider.SetError(txt_celular, "Ingrese Celular");
                v_validado++;
            }
            if (txt_direccion.Text.Trim() == "")
            {
                errorProvider.SetError(txt_direccion, "Ingrese Direccion");
                v_validado++;
            }
            if (txt_identificacion.Text.Trim() == "")
            {
                errorProvider.SetError(txt_identificacion, "Ingrese identificacion");
                v_validado++;
            }

            if (v_validado == 0)
            {
                cls_Cliente.Id = Convert.ToInt32(lbl_id.Text);
                cls_Cliente.TipoIdentificacion = cbx_tipo_identificacion.Text;
                cls_Cliente.NumeroIdentificacion = txt_identificacion.Text;
                cls_Cliente.Nombres = txt_nombres.Text;
                cls_Cliente.Apellidos = txt_apellidos.Text;
                cls_Cliente.Celular = txt_celular.Text;
                cls_Cliente.Direccion = txt_direccion.Text;
                cls_Cliente.FechaRegistro = DateTime.Now.ToString();
                v_ok = cls_Cliente.mtd_Editar();

                if (v_ok == true)
                {
                    MessageBox.Show("Cliente Editado correctamente");
                    mtd_limpiar();
                    mtd_Cargar_cliente();
                    v_registro = true;
                    txt_identificacion.Focus();
                    lbl_id.Text = "0";
                }
            }
        }

        private void mtd_limpiar()
        {
            errorProvider.Clear();
            cbx_tipo_identificacion.SelectedIndex = 0;
            txt_identificacion.Text = "";
            txt_nombres.Text = "";
            txt_apellidos.Text = "";
            txt_celular.Text = "";
            txt_direccion.Text = "";
            v_registro = true;
            dtg_clientes.DataSource = null;
        }

        private void mtd_Cargar_cliente()
        {
            cls_Cliente.v_buscar = "";
            v_dt = cls_Cliente.mtd_consultar_cliente();
            dtg_clientes.DataSource = null;
            dtg_clientes.DataSource = v_dt;
        }

        private void mtd_eliminar()
        {
            if (dtg_clientes.Rows.Count > 0)
            {
                if (dtg_clientes.SelectedRows.Count > 0)
                {
                    Eliminados = 0;
                    Error = 0;
                    v_contador = dtg_clientes.SelectedRows.Count;
                    DialogResult dialogResult = MessageBox.Show("¿Está seguro de que desea Eliminar " + v_contador + "  Clientes?", "", MessageBoxButtons.OKCancel);
                   
                    if (dialogResult == DialogResult.OK)
                    {
                        foreach (DataGridViewRow rows in dtg_clientes.SelectedRows)
                        {
                            cls_Cliente.Id = Convert.ToInt32(rows.Cells["Id"].Value);
                            v_ok = cls_Cliente.mtd_eliminar();
                            if (v_ok)
                            {
                                Eliminados++;
                            }
                            else
                            {
                                Error++;
                            }
                        }                      
                        MessageBox.Show("Eliminados: "+ Eliminados + ", Errores: " + Error);
                        mtd_Cargar_cliente();
                    }
                }
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            mtd_eliminar();
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (dtg_clientes.Rows.Count > 0)
            {
                if (dtg_clientes.SelectedRows.Count > 0)
                {
                    errorProvider.Clear();
                    v_registro = false;
                    foreach (DataGridViewRow row in dtg_clientes.SelectedRows)
                    {
                        lbl_id.Text = row.Cells["Id"].Value.ToString();
                        cbx_tipo_identificacion.Text = row.Cells["TipoIdentificacion"].Value.ToString();
                        txt_identificacion.Text = row.Cells["NumeroIdentificacion"].Value.ToString();
                        txt_nombres.Text = row.Cells["Nombres"].Value.ToString();
                        txt_apellidos.Text = row.Cells["Apellidos"].Value.ToString();
                        txt_celular.Text = row.Cells["Celular"].Value.ToString();
                        txt_direccion.Text = row.Cells["Direccion"].Value.ToString();
                    }
                }
            }
        }

        private void txt_buscar_KeyUp(object sender, KeyEventArgs e)
        {
            cls_Cliente.v_buscar = txt_buscar.Text;
            v_dt = cls_Cliente.mtd_consultar_cliente();
            dtg_clientes.DataSource = null;
            dtg_clientes.DataSource = v_dt;
        }

        private void txt_identificacion_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_identificacion.Text))
            {
                if (!double.TryParse(txt_identificacion.Text, out double numero))
                {
                    MessageBox.Show("Por favor, ingrese un número válido.");
                    txt_identificacion.Clear();
                }
            }
        }

        private void txt_celular_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_celular.Text))
            {
                if (!double.TryParse(txt_celular.Text, out double numero))
                {
                    MessageBox.Show("Por favor, ingrese un número válido.");
                    txt_celular.Clear();
                }
            }
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            cls_Cliente.v_buscar = txt_buscar.Text;
            v_dt = cls_Cliente.mtd_consultar_cliente();
            dtg_clientes.DataSource = null;
            dtg_clientes.DataSource = v_dt;
        }
    }
}
