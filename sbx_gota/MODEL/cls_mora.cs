using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sbx_gota.DB;

namespace sbx_gota.MODEL
{
    public class cls_mora
    {
        cls_datos cls_datos = new cls_datos();
        DataTable dt = new DataTable();

        public int Id { get; set; }
        public int Id_cuenta_cobro { get; set; }
        public string ValorPago { get; set; }
        public string Nota { get; set; }
        public string FechaRegistro { get; set; }

        SqlParameter[] Parametros;
        string v_query = "";
        bool v_ok;

        public DataTable mtd_consultar_pagos_mora()
        {
            v_query = " select Id, Id_cuenta_cobro, REPLACE(FORMAT(ValorPago, '#,##0'), ',', '.') ValorPago, Nota, FechaRegistro from tbl_pago_mora where Id_cuenta_cobro = " + Id_cuenta_cobro + " ";
            dt = cls_datos.mtd_consultar(v_query);
            return dt;
        }

        private void mtd_asignaParametros()
        {
            Parametros = new SqlParameter[4];

            Parametros[0] = new SqlParameter();
            Parametros[0].ParameterName = "@Id_cuenta_cobro";
            Parametros[0].SqlDbType = SqlDbType.Int;
            Parametros[0].SqlValue = Id_cuenta_cobro;

            Parametros[1] = new SqlParameter();
            Parametros[1].ParameterName = "@ValorPago";
            Parametros[1].SqlDbType = SqlDbType.Money;
            Parametros[1].SqlValue = ValorPago;

            Parametros[2] = new SqlParameter();
            Parametros[2].ParameterName = "@Nota";
            Parametros[2].SqlDbType = SqlDbType.VarChar;
            Parametros[2].SqlValue = Nota;

            Parametros[3] = new SqlParameter();
            Parametros[3].ParameterName = "@FechaRegistro";
            Parametros[3].SqlDbType = SqlDbType.DateTime;
            Parametros[3].SqlValue = FechaRegistro;
        }
        public Boolean mtd_registrar()
        {
            v_query = " INSERT INTO tbl_pago_mora (Id_cuenta_cobro,ValorPago,Nota,FechaRegistro)" +
                      " VALUES (@Id_cuenta_cobro,@ValorPago,@Nota,@FechaRegistro)";

            mtd_asignaParametros();
            v_ok = cls_datos.mtd_registrar(Parametros, v_query);
            return v_ok;
        }
        public Boolean mtd_eliminar()
        {
            v_query = "DELETE FROM tbl_pago_mora WHERE Id = '" + Id + "'";
            v_ok = cls_datos.mtd_eliminar(v_query);
            return v_ok;
        }
    }
}
