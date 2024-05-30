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
    public partial class frm_abono_cuota : Form
    {
        //Delegado
        public delegate void EnviarInfo(string dato);
        public event EnviarInfo Enviainfo;

        public int IdPlanPagos { get; set; }
        public string ValorCuota { get; set; }
        public string FechaCuota { get; set; }
        public int NumCuota { get; set; }

        int v_validado = 0;
        cls_abonos cls_Abonos = new cls_abonos();
        cls_plan_pagos cls_Plan_Pagos = new cls_plan_pagos();   
        bool v_ok = false; 

        public frm_abono_cuota()
        {
            InitializeComponent();
        }

        private void frm_abono_cuota_Load(object sender, EventArgs e)
        {
            txt_id_cuota.Text = IdPlanPagos.ToString();
            txt_numero_cuota.Text = NumCuota.ToString();
            txt_fecha_cuota.Text = FechaCuota;
            txt_valor_cuota.Text = ValorCuota.ToString();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            v_validado = 0;
            int error = 0;
            int correcto = 0;
            errorProvider.Clear();
            if (txt_valor_abono.Text.Trim() == "")
            {
                errorProvider.SetError(txt_valor_abono, "Ingrese Abono");
                v_validado++;
            }
           
            if (v_validado == 0)
            {
                if (Convert.ToDouble(txt_valor_abono.Text) <= 0)
                {
                    MessageBox.Show("Abono NO puede ser menor o igual a cero");
                    v_validado++;
                }
                DataTable v_dt4 = new DataTable();
                double valorTotalEnCuotas = 0;
                if (v_validado == 0)
                {
                    cls_Plan_Pagos.Id = Convert.ToInt32(txt_id_cuota.Text);
                    v_dt4 = cls_Plan_Pagos.mtd_consultar_planPagos_verif_cuotas();
                    
                    foreach (DataRow item in v_dt4.Rows)
                    {
                        valorTotalEnCuotas += Convert.ToDouble(item["ValorFaltante"]);
                    }
                    if (valorTotalEnCuotas < Convert.ToDouble(txt_valor_abono.Text))
                    {
                        MessageBox.Show("Abono NO puede ser mayor al valor total en cuotas pendientes, Valor total en cuotas pendientes: " + valorTotalEnCuotas.ToString("N0"));
                        v_validado++;
                    }
                }
               
                if (v_validado == 0)
                {
                    //double vlrAbono = 0;
                    if (Convert.ToDouble(txt_valor_abono.Text) > Convert.ToDouble(txt_valor_cuota.Text))
                    {
                        cls_Abonos.Id_plan_pagos = Convert.ToInt32(txt_id_cuota.Text);
                        cls_Abonos.ValorAbono = txt_valor_abono.Text;
                        cls_Abonos.Nota = txt_nota.Text;
                        cls_Abonos.FechaRegistro = DateTime.Now.ToString();
                        v_ok = v_ok = cls_Abonos.mtd_registrar();
                        if (v_ok)
                        {
                            cls_Plan_Pagos.Id = Convert.ToInt32(txt_id_cuota.Text);
                            cls_Plan_Pagos.Estado = "Pago superior";
                            cls_Plan_Pagos.mtd_Editar_estado();
                            MessageBox.Show("Abono registrado correctamente");
                            Enviainfo("AbonoAplicado");
                            this.Dispose();
                        }

                        //vlrAbono = Convert.ToDouble(txt_valor_abono.Text);

                        //foreach (DataRow item in v_dt4.Rows)
                        //{
                        //    if (vlrAbono > 0)
                        //    {
                        //        cls_Abonos.Id_plan_pagos = Convert.ToInt32(item["Id"]);
                        //        if (vlrAbono >= Convert.ToDouble(item["ValorFaltante"]))
                        //        {
                        //            cls_Abonos.ValorAbono = item["ValorFaltante"].ToString();
                        //        }
                        //        else
                        //        {
                        //            cls_Abonos.ValorAbono = vlrAbono.ToString();
                        //        }
                                
                        //        cls_Abonos.Nota = "abono automatico";
                        //        cls_Abonos.FechaRegistro = DateTime.Now.ToString();
                        //        v_ok = v_ok = cls_Abonos.mtd_registrar();
                        //        if (v_ok)
                        //        {
                        //            cls_Plan_Pagos.Id = Convert.ToInt32(item["Id"]);
                        //            if (vlrAbono >= Convert.ToDouble(Convert.ToDouble(item["ValorFaltante"])))
                        //            {
                        //                cls_Plan_Pagos.Estado = "Pago";
                        //            }
                        //            else if (vlrAbono < Convert.ToDouble(Convert.ToDouble(item["ValorFaltante"])))
                        //            {
                        //                cls_Plan_Pagos.Estado = "Pago parcial";
                        //            }
                        //            correcto++;
                        //            vlrAbono = vlrAbono - Convert.ToDouble(item["ValorFaltante"]);
                        //            cls_Plan_Pagos.mtd_Editar_estado();
                        //        }
                        //        else
                        //        {
                        //            error++;
                        //        }
                        //    }
                        //}
                    }
                    else
                    {
                        cls_Abonos.Id_plan_pagos = Convert.ToInt32(txt_id_cuota.Text);
                        cls_Abonos.ValorAbono = txt_valor_abono.Text;
                        cls_Abonos.Nota = txt_nota.Text;
                        cls_Abonos.FechaRegistro = DateTime.Now.ToString();
                        v_ok = cls_Abonos.mtd_registrar();
                        if (v_ok)
                        {
                            cls_Plan_Pagos.Id = Convert.ToInt32(txt_id_cuota.Text);
                            if (Convert.ToDouble(txt_valor_abono.Text) == Convert.ToDouble(txt_valor_cuota.Text))
                            {
                                cls_Plan_Pagos.Estado = "Pago";
                            }
                            else if (Convert.ToDouble(txt_valor_abono.Text) < Convert.ToDouble(txt_valor_cuota.Text))
                            {
                                cls_Plan_Pagos.Estado = "Pago parcial";
                            }
                            cls_Plan_Pagos.mtd_Editar_estado();
                            MessageBox.Show("Abono registrado correctamente");
                            Enviainfo("AbonoAplicado");
                            this.Dispose();
                        }
                    }
                }
            }
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

        private void txt_valor_abono_KeyUp(object sender, KeyEventArgs e)
        {
            double vlr = 0;
            string vF = "";
            if (txt_valor_abono.Text != "")
            {
                vlr = Convert.ToDouble(txt_valor_abono.Text);
                vF = vlr.ToString("N0");
                txt_valor_abono.Text = vF;
                txt_valor_abono.SelectionStart = txt_valor_abono.Text.Length;
            }
        }
    }
}
