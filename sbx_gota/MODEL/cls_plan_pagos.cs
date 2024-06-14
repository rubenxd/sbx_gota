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
    public class cls_plan_pagos
    {
        //instancias
        cls_datos cls_datos = new cls_datos();

        //Variables
        DataTable v_dt;
        string v_query = "";
        SqlParameter[] Parametros;
        bool v_ok;
        public string v_buscar { get; set; }
        public DateTime FechaFin { get; set; }

        //getter and setter
        public int Id { get; set; }
        public int Id_cuentaCobro { get; set; }
        public int NumeroCuota { get; set; }
        public string VlrCuota { get; set; }
        public string FechaCuota { get; set; }
        public string Estado { get; set; }
        public string FechaRegistro { get; set; }

        //Metodos
        public DataTable mtd_consultar_planPagos()
        {
            v_query = " EXECUTE sp_consultar_plan_pagos  '" + v_buscar + "' ";
            v_dt = cls_datos.mtd_consultar(v_query);
            return v_dt;
        }

        public DataTable mtd_consultar_planPagos_exacto()
        {
            v_query = " SELECT * FROM tbl_plan_pagos WHERE Id = '" + v_buscar + "' ";
            v_dt = cls_datos.mtd_consultar(v_query);
            return v_dt;
        }

        public DataTable mtd_consultar_planPagos_verif_cuotas()
        {
            v_query = " select pp.*, isnull((select sum(ValorAbono) from tbl_abonos where Id_plan_pagos = pp.Id),0) ValorAbono, "
                + "pp.VlrCuota - isnull((select sum(ValorAbono) from tbl_abonos where Id_plan_pagos = pp.Id),0) ValorFaltante "
                        + "from tbl_plan_pagos pp "
                        + "where pp.Id_cuentaCobro = "
                        +"(select cc.Id from tbl_cuenta_cobro cc "
                        +"where cc.Id = (select ppp.Id_cuentaCobro from tbl_plan_pagos ppp where ppp.Id = "+Id+")) "
                        +"and(pp.Estado = 'Pendiente' or pp.Estado = 'Pago parcial') ";
            v_dt = cls_datos.mtd_consultar(v_query);
            return v_dt;
        }

        public DataTable mtd_consultar_clientes_pendientes_a_excel()
        {
            v_query = " EXECUTE sp_consultar_pendientes_a_excel " + Id + " ";
            v_dt = cls_datos.mtd_consultar(v_query);
            return v_dt;
        }

        public DataTable mtd_consultar_clientes_pendientes_a_excel_fecha()
        {
            v_query = " EXECUTE sp_consultar_pendientes_a_excel_fecha  '" + v_buscar + "','"+ Estado + "', '" + FechaFin.ToString("yyyyMMdd") + "' ";
            v_dt = cls_datos.mtd_consultar(v_query);
            return v_dt;
        }

        private void mtd_asignaParametros()
        {
            Parametros = new SqlParameter[6];

            Parametros[0] = new SqlParameter();
            Parametros[0].ParameterName = "@Id_cuentaCobro";
            Parametros[0].SqlDbType = SqlDbType.Int;
            Parametros[0].SqlValue = Id_cuentaCobro;

            Parametros[1] = new SqlParameter();
            Parametros[1].ParameterName = "@NumeroCuota";
            Parametros[1].SqlDbType = SqlDbType.Int;
            Parametros[1].SqlValue = NumeroCuota;

            Parametros[2] = new SqlParameter();
            Parametros[2].ParameterName = "@VlrCuota";
            Parametros[2].SqlDbType = SqlDbType.Money;
            Parametros[2].SqlValue = VlrCuota;

            Parametros[3] = new SqlParameter();
            Parametros[3].ParameterName = "@FechaCuota";
            Parametros[3].SqlDbType = SqlDbType.DateTime;
            Parametros[3].SqlValue = FechaCuota;

            Parametros[4] = new SqlParameter();
            Parametros[4].ParameterName = "@FechaRegistro";
            Parametros[4].SqlDbType = SqlDbType.DateTime;
            Parametros[4].SqlValue = FechaRegistro;

            Parametros[5] = new SqlParameter();
            Parametros[5].ParameterName = "@Estado";
            Parametros[5].SqlDbType = SqlDbType.VarChar;
            Parametros[5].SqlValue = Estado;
        }

        private void mtd_asignaParametros2()
        {
            Parametros = new SqlParameter[1];

            Parametros[0] = new SqlParameter();
            Parametros[0].ParameterName = "@Estado";
            Parametros[0].SqlDbType = SqlDbType.VarChar;
            Parametros[0].SqlValue = Estado;
        }

        private void mtd_asignaParametros3()
        {
            Parametros = new SqlParameter[1];

            Parametros[0] = new SqlParameter();
            Parametros[0].ParameterName = "@VlrCuota";
            Parametros[0].SqlDbType = SqlDbType.Money;
            Parametros[0].SqlValue = VlrCuota;
        }

        public Boolean mtd_registrar()
        {
            v_query = " INSERT INTO tbl_plan_pagos (Id_cuentaCobro,NumeroCuota,VlrCuota,FechaCuota,FechaRegistro,Estado)" +
                      " VALUES (@Id_cuentaCobro,@NumeroCuota,@VlrCuota,@FechaCuota,@FechaRegistro,@Estado)";

            mtd_asignaParametros();
            v_ok = cls_datos.mtd_registrar(Parametros, v_query);
            return v_ok;
        }
        public Boolean mtd_Editar()
        {
            v_query = " UPDATE tbl_plan_pagos SET Id_cuentaCobro = @Id_cuentaCobro,NumeroCuota = @NumeroCuota,VlrCuota = @VlrCuota,FechaCuota = @FechaCuota,FechaRegistro=@FechaRegistro,Estado = @Estado  " +
                      " WHERE Id = " + Id;

            mtd_asignaParametros();
            v_ok = cls_datos.mtd_editar(Parametros, v_query);
            return v_ok;
        }
        public Boolean mtd_Editar_estado()
        {
            v_query = " UPDATE tbl_plan_pagos SET Estado = @Estado  " +
                      " WHERE Id = " + Id;

            mtd_asignaParametros2();
            v_ok = cls_datos.mtd_editar(Parametros, v_query);
            return v_ok;
        }
        public Boolean mtd_eliminar_cuentaCobro()
        {
            v_query = "DELETE FROM tbl_plan_pagos WHERE Id_cuentaCobro = '" + Id_cuentaCobro + "'";
            v_ok = cls_datos.mtd_eliminar(v_query);
            return v_ok;
        }
        public Boolean mtd_eliminar_cuotas_plan_pago()
        {
            v_query = "DELETE FROM tbl_plan_pagos WHERE Id_cuentaCobro = " + Id_cuentaCobro + " and NumeroCuota > "+ NumeroCuota;
            v_ok = cls_datos.mtd_eliminar(v_query);
            return v_ok;
        }
        public Boolean mtd_Editar_valor_cuota()
        {
            v_query = " UPDATE tbl_plan_pagos SET VlrCuota = @VlrCuota  " +
                      " WHERE Id = " + Id;

            mtd_asignaParametros3();
            v_ok = cls_datos.mtd_editar(Parametros, v_query);
            return v_ok;
        }
    }
}
