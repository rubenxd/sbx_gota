using sbx_gota.MODEL;
using System;
using System.Data;
using System.Windows.Forms;

namespace sbx_gota
{
    public partial class frm_mora : Form
    {
        cls_cuenta_cobro cls_Cuenta_Cobro;
        DataTable dt;
        cls_mora cls_Mora = new cls_mora();
        bool ok = false;
        int Eliminados;
        int Error;
        int v_contador = 0;
        //Delegado
        public delegate void EnviarInfo(string dato);
        public event EnviarInfo Enviainfo;

        public frm_mora()
        {
            InitializeComponent();
        }

        public frm_mora(string idCuentaCobro)
        {
            InitializeComponent();

            //obtener valor de mora total y cliente
            cls_Cuenta_Cobro = new cls_cuenta_cobro();
            dt = new DataTable();
            txt_id_cuenta_cobro.Text = idCuentaCobro;
            cls_Cuenta_Cobro.Id = Convert.ToInt32(idCuentaCobro);
            dt = cls_Cuenta_Cobro.mtd_consultar_cuenta_cobro_mora();
            double TotalMora = 0;
            string Cliente = "";
            foreach (DataRow rows in dt.Rows)
            {
                TotalMora = Convert.ToDouble(rows["mora"]);
                Cliente = rows["cliente"].ToString();
            }
            txt_mora.Text = TotalMora.ToString("N0");
            txt_nombres.Text = Cliente;
        }

        private void frm_mora_Load(object sender, EventArgs e)
        {
            cls_Mora.Id_cuenta_cobro = Convert.ToInt32(txt_id_cuenta_cobro.Text);
            dt = cls_Mora.mtd_consultar_pagos_mora();

            double TotalPagos = 0;
            foreach (DataRow rows in dt.Rows)
            {
                TotalPagos += Convert.ToDouble(rows["ValorPago"]);
            }
            txt_pagos_mora.Text = TotalPagos.ToString("N0");
            double debe = 0;
            debe = Convert.ToDouble(txt_mora.Text) - TotalPagos;
            txt_saldo.Text = debe.ToString("N0");
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            cls_Mora.Id_cuenta_cobro = Convert.ToInt32(txt_id_cuenta_cobro.Text);
            dt = cls_Mora.mtd_consultar_pagos_mora();
            dtg_pagos_mora.DataSource = dt;
        }

        private void btn_pago_total_Click(object sender, EventArgs e)
        {
            if (txt_vlr_pagar.Text != "")
            {
                if (Convert.ToDouble(txt_vlr_pagar.Text) > 0)
                {
                    if (Convert.ToDouble(txt_vlr_pagar.Text) <= Convert.ToDouble(txt_saldo.Text))
                    {
                        cls_Mora.Id_cuenta_cobro = Convert.ToInt32(txt_id_cuenta_cobro.Text);
                        cls_Mora.ValorPago = txt_vlr_pagar.Text;
                        cls_Mora.Nota = txt_nota.Text;
                        cls_Mora.FechaRegistro = DateTime.Now.ToString();
                        ok = cls_Mora.mtd_registrar();
                        if (ok)
                        {
                            MessageBox.Show("Pago registrado correctamente");

                            txt_vlr_pagar.Text = "";
                            txt_nota.Text = "";

                            cls_Mora.Id_cuenta_cobro = Convert.ToInt32(txt_id_cuenta_cobro.Text);
                            dt = cls_Mora.mtd_consultar_pagos_mora();
                            dtg_pagos_mora.DataSource = dt;

                            cls_Mora.Id_cuenta_cobro = Convert.ToInt32(txt_id_cuenta_cobro.Text);
                            dt = cls_Mora.mtd_consultar_pagos_mora();
                            double TotalPagos = 0;
                            foreach (DataRow rows in dt.Rows)
                            {
                                TotalPagos += Convert.ToDouble(rows["ValorPago"]);
                            }
                            txt_pagos_mora.Text = TotalPagos.ToString("N0");
                            double debe = 0;
                            debe = Convert.ToDouble(txt_mora.Text) - TotalPagos;
                            txt_saldo.Text = debe.ToString("N0");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El valor a pagar debe ser menor o igual al saldo");
                    }
                }
                else
                {
                    MessageBox.Show("Valor debe ser mayor a cero");
                }                           
            }
            else
            {
                MessageBox.Show("Debe ingresar un valor");
            }      
        }

        private void txt_vlr_pagar_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_vlr_pagar.Text))
            {
                if (!double.TryParse(txt_vlr_pagar.Text, out double numero))
                {
                    MessageBox.Show("Por favor, ingrese un número válido.");
                    txt_vlr_pagar.Clear();
                }
            }
        }

        private void txt_vlr_pagar_KeyUp(object sender, KeyEventArgs e)
        {
            double vlr = 0;
            string vF = "";
            if (txt_vlr_pagar.Text != "")
            {
                vlr = Convert.ToDouble(txt_vlr_pagar.Text);
                vF = vlr.ToString("N0");
                txt_vlr_pagar.Text = vF;
                txt_vlr_pagar.SelectionStart = txt_mora.Text.Length;
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (dtg_pagos_mora.Rows.Count > 0)
            {
                if (dtg_pagos_mora.SelectedRows.Count > 0)
                {
                    Eliminados = 0;
                    Error = 0;
                    v_contador = dtg_pagos_mora.SelectedRows.Count;
                    DialogResult dialogResult = MessageBox.Show("¿Está seguro de que desea Eliminar " + v_contador + "  pago?", "", MessageBoxButtons.OKCancel);

                    if (dialogResult == DialogResult.OK)
                    {
                        foreach (DataGridViewRow rows in dtg_pagos_mora.SelectedRows)
                        {
                            cls_Mora.Id = Convert.ToInt32(rows.Cells["Id"].Value);
                            ok = cls_Mora.mtd_eliminar();
                            if (ok)
                            {
                                Eliminados++;
                            }
                            else
                            {
                                Error++;
                            }
                        }
                        MessageBox.Show("Eliminados: " + Eliminados + ", Errores: " + Error);
                        //Actualizar
                        cls_Mora.Id_cuenta_cobro = Convert.ToInt32(txt_id_cuenta_cobro.Text);
                        dt = cls_Mora.mtd_consultar_pagos_mora();
                        dtg_pagos_mora.DataSource = dt;
                        //actualizar valores
                        cls_Mora.Id_cuenta_cobro = Convert.ToInt32(txt_id_cuenta_cobro.Text);
                        dt = cls_Mora.mtd_consultar_pagos_mora();

                        double TotalPagos = 0;
                        foreach (DataRow rows in dt.Rows)
                        {
                            TotalPagos += Convert.ToDouble(rows["ValorPago"]);
                        }
                        txt_pagos_mora.Text = TotalPagos.ToString("N0");
                        double debe = 0;
                        debe = Convert.ToDouble(txt_mora.Text) - TotalPagos;
                        txt_saldo.Text = debe.ToString("N0");
                    }
                }
            }
        }

        private void frm_mora_FormClosed(object sender, FormClosedEventArgs e)
        {
            Enviainfo(txt_id_cuenta_cobro.Text);
        }
    }
}
