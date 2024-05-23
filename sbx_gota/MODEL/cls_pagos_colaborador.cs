using sbx_gota.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sbx_gota.MODEL
{
    public class cls_pagos_colaborador
    {
        //instancias
        cls_datos cls_datos = new cls_datos();

        //Variables
        DataTable v_dt;
        string v_query = "";
        SqlParameter[] Parametros;
        bool v_ok;
        public string v_buscar { get; set; }

        //getter and setter
        public int Id { get; set; }
        public int Id_colaborador { get; set; }
        public string ValorPago { get; set; }
        public string Nota { get; set; }
        public string FechaRegistro { get; set; }

        //Metodos
        public DataTable mtd_consultar_Pagos_colaborador()
        {
            v_query = " EXECUTE sp_consultar_pago_colaborador ";
            v_dt = cls_datos.mtd_consultar(v_query);
            return v_dt;
        }

        public DataTable mtd_consultar_pagos_colaborador_exacto()
        {
            v_query = " SELECT * FROM tbl_pago_colaborador WHERE Id = '" + v_buscar + "' ";
            v_dt = cls_datos.mtd_consultar(v_query);
            return v_dt;
        }

        private void mtd_asignaParametros()
        {
            Parametros = new SqlParameter[4];

            Parametros[0] = new SqlParameter();
            Parametros[0].ParameterName = "@Id_colaborador";
            Parametros[0].SqlDbType = SqlDbType.Int;
            Parametros[0].SqlValue = Id_colaborador;

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
            v_query = " INSERT INTO tbl_pago_colaborador (Id_colaborador,ValorPago,Nota,FechaRegistro)" +
                      " VALUES (@Id_colaborador,@ValorPago,@Nota,@FechaRegistro)";

            mtd_asignaParametros();
            v_ok = cls_datos.mtd_registrar(Parametros, v_query);
            return v_ok;
        }
        public Boolean mtd_Editar()
        {
            v_query = " UPDATE tbl_pago_colaborador SET ValorPago = @ValorPago,Nota = @Nota,FechaRegistro = @FechaRegistro " +
                      " WHERE Id = " + Id;

            mtd_asignaParametros();
            v_ok = cls_datos.mtd_editar(Parametros, v_query);
            return v_ok;
        }
        public Boolean mtd_eliminar_pago_colaborador()
        {
            v_query = "DELETE FROM tbl_pago_colaborador WHERE Id = '" + Id + "'";
            v_ok = cls_datos.mtd_eliminar(v_query);
            return v_ok;
        }
    }
}
