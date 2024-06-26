﻿using sbx_gota.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sbx_gota.MODEL
{
    public class cls_abonos
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
        public int Id_plan_pagos { get; set; }
        public string ValorAbono { get; set; }
        public string Nota { get; set; }
        public string FechaRegistro { get; set; }

        //Metodos
        public DataTable mtd_consultar_Abonos()
        {
            v_query = " EXECUTE sp_consultar_Abonos  '" + v_buscar + "' ";
            v_dt = cls_datos.mtd_consultar(v_query);
            return v_dt;
        }

        public DataTable mtd_consultar_abonos_exacto()
        {
            v_query = " SELECT * FROM tbl_abonos WHERE Id = '" + v_buscar + "' ";
            v_dt = cls_datos.mtd_consultar(v_query);
            return v_dt;
        }

        private void mtd_asignaParametros()
        {
            Parametros = new SqlParameter[4];

            Parametros[0] = new SqlParameter();
            Parametros[0].ParameterName = "@Id_plan_pagos";
            Parametros[0].SqlDbType = SqlDbType.Int;
            Parametros[0].SqlValue = Id_plan_pagos;

            Parametros[1] = new SqlParameter();
            Parametros[1].ParameterName = "@ValorAbono";
            Parametros[1].SqlDbType = SqlDbType.Money;
            Parametros[1].SqlValue = ValorAbono;

            Parametros[2] = new SqlParameter();
            Parametros[2].ParameterName = "@Nota";
            Parametros[2].SqlDbType = SqlDbType.VarChar;
            Parametros[2].SqlValue = Nota;

            Parametros[3] = new SqlParameter();
            Parametros[3].ParameterName = "@FechaRegistro";
            Parametros[3].SqlDbType = SqlDbType.DateTime;
            Parametros[3].SqlValue = FechaRegistro;
        }
        private void mtd_asignaParametros2()
        {
            Parametros = new SqlParameter[3];

            Parametros[0] = new SqlParameter();
            Parametros[0].ParameterName = "@ValorAbono";
            Parametros[0].SqlDbType = SqlDbType.Money;
            Parametros[0].SqlValue = ValorAbono;

            Parametros[1] = new SqlParameter();
            Parametros[1].ParameterName = "@Nota";
            Parametros[1].SqlDbType = SqlDbType.VarChar;
            Parametros[1].SqlValue = Nota;

            Parametros[2] = new SqlParameter();
            Parametros[2].ParameterName = "@FechaRegistro";
            Parametros[2].SqlDbType = SqlDbType.DateTime;
            Parametros[2].SqlValue = FechaRegistro;
        }

        public Boolean mtd_registrar()
        {
            v_query = " INSERT INTO tbl_abonos (Id_plan_pagos,ValorAbono,Nota,FechaRegistro)" +
                      " VALUES (@Id_plan_pagos,@ValorAbono,@Nota,@FechaRegistro)";

            mtd_asignaParametros();
            v_ok = cls_datos.mtd_registrar(Parametros, v_query);
            return v_ok;
        }
        public Boolean mtd_Editar()
        {
            v_query = " UPDATE tbl_abonos SET ValorAbono = @ValorAbono,Nota = @Nota,FechaRegistro = @FechaRegistro " +
                      " WHERE Id = " + Id;

            mtd_asignaParametros2();
            v_ok = cls_datos.mtd_editar(Parametros, v_query);
            return v_ok;
        }
        public Boolean mtd_eliminar_cuentaCobro()
        {
            v_query = "DELETE FROM tbl_abonos WHERE Id_plan_pagos = '" + Id_plan_pagos + "'";
            v_ok = cls_datos.mtd_eliminar(v_query);
            return v_ok;
        }
        public Boolean mtd_eliminar()
        {
            v_query = "DELETE FROM tbl_abonos WHERE Id = " + Id + "";
            v_ok = cls_datos.mtd_eliminar(v_query);
            //if (v_ok)
            //{
            //    v_query = " select count(*) CantidadAbonos,isnull(SUM(ValorAbono),0) totalAbonos,(select VlrCuota from tbl_plan_pagos where Id = "+ Id_plan_pagos + ") valorcuota  from tbl_abonos "+
            //              " where Id_plan_pagos = "+ Id_plan_pagos;
            //    v_dt = cls_datos.mtd_consultar(v_query);
            //    foreach (DataRow item in v_dt.Rows)
            //    {
            //        if (Convert.ToInt32(item["CantidadAbonos"]) == 0 && Convert.ToDouble(item["totalAbonos"]) == 0)
            //        {
            //            v_query = "update tbl_plan_pagos set Estado = 'Pendiente' where Id = " + Id_plan_pagos;
            //        }
            //        else
            //        {
            //            v_query = "update tbl_plan_pagos set Estado = 'Pago parcial' where Id = " + Id_plan_pagos;
            //        }
            //    }

            //    v_ok = cls_datos.mtd_ejecutar(v_query);
            //}
            return v_ok;
        }
        public Boolean mtd_eliminarDesdeCuentaCobro()
        {
            v_query = "DELETE FROM tbl_abonos WHERE Id_plan_pagos = '" + Id_plan_pagos + "'";
            v_ok = cls_datos.mtd_eliminar(v_query);
            return v_ok;
        }
    }
}
