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
    public partial class frm_agregar_pago_colaborador : Form
    {
        //Delegado
        public delegate void EnviarInfo(string dato);
        public event EnviarInfo Enviainfo;

        public int IdCliente { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string Nombre { get; set; }

        cls_reportes cls_Reportes = new cls_reportes();
        DataTable dt;
        cls_pagos_colaborador cls_Pagos_Colaborador = new cls_pagos_colaborador();
        bool v_registro = true;

        public frm_agregar_pago_colaborador()
        {
            InitializeComponent();
        }

        private void frm_agregar_pago_colaborador_Load(object sender, EventArgs e)
        {
            txt_id.Text = IdCliente.ToString();
            txt_identificacion.Text = NumeroIdentificacion;
            txt_nombres.Text = Nombre;

            dt = new DataTable();
            dt = cls_Reportes.mtd_consultar_reporte();
            double TotalGananciasxPersona = 0;
            foreach (DataRow rows in dt.Rows)
            {
                TotalGananciasxPersona += Convert.ToDouble(rows["GananciaXPersona"]);
            }
            txt_ganancias.Text = TotalGananciasxPersona.ToString("N0");

            DataTable dt2 = new DataTable();
            dt2 = cls_Pagos_Colaborador.mtd_consultar_Pagos_colaborador();
            double pagos = 0;
            double seledebe = 0;
            foreach (DataRow item in dt2.Rows)
            {
                pagos += Convert.ToDouble(item["ValorPago"]);
            }
            txt_pago.Text = pagos.ToString("N0");
            seledebe = TotalGananciasxPersona - pagos;
            txt_saldo.Text = seledebe.ToString("N0");
        }

        private void txt_vlr_pagar_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_vlr_pagar.Text))
            {
                if (!double.TryParse(txt_vlr_pagar.Text, out double numero))
                {
                    MessageBox.Show("Por favor, ingrese un número válido.");
                    txt_vlr_pagar.Clear();
                    v_validado++;
                }
            }
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            mtd_Cargar();
        }
        int v_validado = 0;
        bool v_ok = false;
        private void btn_pago_total_Click(object sender, EventArgs e)
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
                        lbl_id_pago.Text = row.Cells["Id"].Value.ToString();
                        txt_vlr_pagar.Text = row.Cells["ValorPago"].Value.ToString();
                        txt_nota.Text = row.Cells["Nota"].Value.ToString();
                    }
                }
            }
        }

        private void mtd_limpiar()
        {
            errorProvider.Clear();
            txt_vlr_pagar.Text = "";
            txt_nota.Text = "";
        }

        private void mtd_Cargar()
        {

            txt_id.Text = IdCliente.ToString();
            txt_identificacion.Text = NumeroIdentificacion;
            txt_nombres.Text = Nombre;

            dt = new DataTable();
            dt = cls_Reportes.mtd_consultar_reporte();
            double TotalGananciasxPersona = 0;
            foreach (DataRow rows in dt.Rows)
            {
                TotalGananciasxPersona += Convert.ToDouble(rows["GananciaXPersona"]);
            }
            txt_ganancias.Text = TotalGananciasxPersona.ToString("N0");

            DataTable dt2 = new DataTable();
            dt2 = cls_Pagos_Colaborador.mtd_consultar_Pagos_colaborador();
            double pagos = 0;
            double seledebe = 0;
            foreach (DataRow item in dt2.Rows)
            {
                pagos += Convert.ToDouble(item["ValorPago"]);
            }
            txt_pago.Text = pagos.ToString("N0");
            seledebe = TotalGananciasxPersona - pagos;
            txt_saldo.Text = seledebe.ToString("N0");


            DataTable dt3 = new DataTable();
            dt3 = cls_Pagos_Colaborador.mtd_consultar_Pagos_colaborador();
            dtg_clientes.DataSource = null;
            double ValorPago = 0;
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                DataRow fila = dt3.Rows[i];
                ValorPago = Convert.ToDouble(fila["ValorPago"]);
                fila["ValorPago"] = ValorPago.ToString();
            }
            dtg_clientes.DataSource = dt3;
        }

        private void mtd_guardar()
        {
            errorProvider.Clear();
            if (txt_vlr_pagar.Text.Trim() == "")
            {
                errorProvider.SetError(txt_vlr_pagar, "Ingrese valor a pagar");
                v_validado++;
            }

            if (v_validado == 0)
            {
                cls_Pagos_Colaborador.Id_colaborador = Convert.ToInt32(txt_id.Text);
                cls_Pagos_Colaborador.ValorPago = txt_vlr_pagar.Text;
                cls_Pagos_Colaborador.Nota = txt_nota.Text;
                cls_Pagos_Colaborador.FechaRegistro = DateTime.Now.ToString();
                v_ok = cls_Pagos_Colaborador.mtd_registrar();

                if (v_ok == true)
                {
                    MessageBox.Show("Pago registrado correctamente");
                    mtd_limpiar();
                    mtd_Cargar();
                    v_registro = true;
                    txt_vlr_pagar.Focus();
                }
            }
        }

        private void mtd_editar()
        {
            errorProvider.Clear();
            if (txt_vlr_pagar.Text.Trim() == "")
            {
                errorProvider.SetError(txt_vlr_pagar, "Ingrese valor a pagar");
                v_validado++;
            }

            if (v_validado == 0)
            {
                cls_Pagos_Colaborador.Id = Convert.ToInt32(lbl_id_pago.Text);
                cls_Pagos_Colaborador.ValorPago = txt_vlr_pagar.Text;
                cls_Pagos_Colaborador.Nota = txt_nota.Text;
                cls_Pagos_Colaborador.FechaRegistro = DateTime.Now.ToString();              
                v_ok = cls_Pagos_Colaborador.mtd_Editar();

                if (v_ok == true)
                {
                    MessageBox.Show("Pago editado correctamente");
                    mtd_limpiar();
                    mtd_Cargar();
                    v_registro = true;
                    txt_vlr_pagar.Focus();
                    lbl_id_pago.Text = "0";
                }
            }
        }

        private void mtd_eliminar()
        {
            int Eliminados = 0;
            int Error = 0;
            int v_contador = 0;

            if (dtg_clientes.Rows.Count > 0)
            {
                if (dtg_clientes.SelectedRows.Count > 0)
                {
                    Eliminados = 0;
                    Error = 0;
                    v_contador = dtg_clientes.SelectedRows.Count;
                    DialogResult dialogResult = MessageBox.Show("¿Está seguro de que desea Eliminar " + v_contador + "  pago?", "", MessageBoxButtons.OKCancel);

                    if (dialogResult == DialogResult.OK)
                    {
                        foreach (DataGridViewRow rows in dtg_clientes.SelectedRows)
                        {
                            cls_Pagos_Colaborador.Id = Convert.ToInt32(rows.Cells["Id"].Value);
                            v_ok = cls_Pagos_Colaborador.mtd_eliminar_pago_colaborador();
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
                        mtd_Cargar();
                    }
                }
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            mtd_eliminar();
        }
    }
}
