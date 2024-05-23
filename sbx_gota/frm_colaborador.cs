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
    public partial class frm_colaborador : Form
    {
        cls_colaborador cls_Colaborador = new cls_colaborador();

        int v_validado = 0;
        bool v_registro = true;
        DataTable v_dt;
        bool v_ok = true;
        int Eliminados;
        int Error;
        int v_contador = 0;

        public frm_colaborador()
        {
            InitializeComponent();
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
                cls_Colaborador.v_buscar = txt_identificacion.Text;
                v_dt = cls_Colaborador.mtd_consultar_colaborador();
                if (v_dt.Rows.Count > 0)
                {
                    errorProvider.SetError(txt_identificacion, "identificacion ya existe");
                    v_validado++;
                }
            }

            if (v_validado == 0)
            {
                cls_Colaborador.TipoIdentificacion = cbx_tipo_identificacion.Text;
                cls_Colaborador.NumeroIdentificacion = txt_identificacion.Text;
                cls_Colaborador.Nombres = txt_nombres.Text;
                cls_Colaborador.Apellidos = txt_apellidos.Text;
                cls_Colaborador.Celular = txt_celular.Text;
                cls_Colaborador.Direccion = txt_direccion.Text;
                cls_Colaborador.FechaRegistro = DateTime.Now.ToString();
                v_ok = cls_Colaborador.mtd_registrar();

                if (v_ok == true)
                {
                    MessageBox.Show("Colaborador registrado correctamente");
                    mtd_limpiar();
                    mtd_Cargar_colaboradores();
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
                cls_Colaborador.Id = Convert.ToInt32(lbl_id.Text);
                cls_Colaborador.TipoIdentificacion = cbx_tipo_identificacion.Text;
                cls_Colaborador.NumeroIdentificacion = txt_identificacion.Text;
                cls_Colaborador.Nombres = txt_nombres.Text;
                cls_Colaborador.Apellidos = txt_apellidos.Text;
                cls_Colaborador.Celular = txt_celular.Text;
                cls_Colaborador.Direccion = txt_direccion.Text;
                cls_Colaborador.FechaRegistro = DateTime.Now.ToString();
                v_ok = cls_Colaborador.mtd_Editar();

                if (v_ok == true)
                {
                    MessageBox.Show("Colaborador Editado correctamente");
                    mtd_limpiar();
                    mtd_Cargar_colaboradores();
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

        private void mtd_Cargar_colaboradores()
        {
            cls_Colaborador.v_buscar = "";
            v_dt = cls_Colaborador.mtd_consultar_colaborador();
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
                    DialogResult dialogResult = MessageBox.Show("¿Está seguro de que desea Eliminar " + v_contador + "  Colaboradores?", "", MessageBoxButtons.OKCancel);

                    if (dialogResult == DialogResult.OK)
                    {
                        foreach (DataGridViewRow rows in dtg_clientes.SelectedRows)
                        {
                            cls_Colaborador.Id = Convert.ToInt32(rows.Cells["Id"].Value);
                            v_ok = cls_Colaborador.mtd_eliminar();
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
                        mtd_Cargar_colaboradores();
                    }
                }
            }
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

        private void frm_colaborador_Load(object sender, EventArgs e)
        {
            cbx_tipo_identificacion.SelectedIndex = 0;
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            cls_Colaborador.v_buscar = txt_buscar.Text;
            v_dt = cls_Colaborador.mtd_consultar_colaborador();
            dtg_clientes.DataSource = null;
            dtg_clientes.DataSource = v_dt;
        }

        private void txt_buscar_KeyUp(object sender, KeyEventArgs e)
        {
            cls_Colaborador.v_buscar = txt_buscar.Text;
            v_dt = cls_Colaborador.mtd_consultar_colaborador();
            dtg_clientes.DataSource = null;
            dtg_clientes.DataSource = v_dt;
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            mtd_eliminar();
        }
        frm_agregar_pago_colaborador frm_Agregar_Pago_Colaborador;
        private void btn_agregar_pago_Click(object sender, EventArgs e)
        {
            string v_dato = "";
            string v_dato2 = "";
            if (dtg_clientes.Rows.Count > 0)
            {
                int v_filas = 0;
                v_filas = dtg_clientes.CurrentRow.Index;
               
                if (frm_Agregar_Pago_Colaborador == null || frm_Agregar_Pago_Colaborador.IsDisposed)
                {
                    frm_Agregar_Pago_Colaborador = new frm_agregar_pago_colaborador();
                    v_dato = dtg_clientes[0, v_filas].Value.ToString();
                    frm_Agregar_Pago_Colaborador.IdCliente = Convert.ToInt32(v_dato);
                    v_dato = dtg_clientes[2, v_filas].Value.ToString();
                    frm_Agregar_Pago_Colaborador.NumeroIdentificacion = v_dato;
                    v_dato = dtg_clientes[3, v_filas].Value.ToString();
                    v_dato2 = dtg_clientes[4, v_filas].Value.ToString();
                    frm_Agregar_Pago_Colaborador.Nombre = v_dato + " " + v_dato2;
                    frm_Agregar_Pago_Colaborador.Enviainfo += new frm_agregar_pago_colaborador.EnviarInfo(mtd_confirmacion);
                    frm_Agregar_Pago_Colaborador.Show();
                }
                else
                {
                    frm_Agregar_Pago_Colaborador.BringToFront();
                    frm_Agregar_Pago_Colaborador.WindowState = FormWindowState.Normal;
                }
            }
        }
        private void mtd_confirmacion(string respuesta)
        {
           
        }
    }
}
