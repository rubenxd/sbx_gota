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
    public class cls_cuenta_cobro
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
        public int Id_cliente { get; set; }
        public double MontoPrestamo { get; set; }
        public double ValorInteres { get; set; }
        public string PorcentajeInteres { get; set; }
        public int NumeroCuotas { get; set; }
        public string ModoPago { get; set; }
        public string DiaPago { get; set; }
        public string DiasFechaPago { get; set; }
        public string FechaPrimerPago { get; set; }
        public string Estado { get; set; }
        public string Nota { get; set; }
        public string FechaRegistros { get; set; }

        //Metodos
        public DataTable mtd_consultar_cuenta_cobro()
        {
            v_query = " EXECUTE sp_consultar_cuenta_cobro  '" + v_buscar + "' ";
            v_dt = cls_datos.mtd_consultar(v_query);
            return v_dt;
        }

        public DataTable mtd_consultar_cuenta_cobro_exacto()
        {
            v_query = " sp_consultar_cuenta_cobro_exacto " + v_buscar + " ";
            v_dt = cls_datos.mtd_consultar(v_query);
            return v_dt;
        }

        public DataTable mtd_consultar_cuenta_cobro_maximo()
        {
            v_query = " SELECT * FROM tbl_cuenta_cobro where Id = (select MAX(id) from tbl_cuenta_cobro) ";
            v_dt = cls_datos.mtd_consultar(v_query);
            return v_dt;
        }

        public DataTable mtd_consultar_cuenta_cobro_en_plan_pagos()
        {
            v_query = " select * from tbl_plan_pagos where Id_cuentaCobro = " + v_buscar + " ";
            v_dt = cls_datos.mtd_consultar(v_query);
            return v_dt;
        }

        private void mtd_asignaParametros()
        {
            Parametros = new SqlParameter[13];

            Parametros[0] = new SqlParameter();
            Parametros[0].ParameterName = "@Id";
            Parametros[0].SqlDbType = SqlDbType.Int;
            Parametros[0].SqlValue = Id;

            Parametros[1] = new SqlParameter();
            Parametros[1].ParameterName = "@Id_cliente";
            Parametros[1].SqlDbType = SqlDbType.Int;
            Parametros[1].SqlValue = Id_cliente;

            Parametros[2] = new SqlParameter();
            Parametros[2].ParameterName = "@MontoPrestamo";
            Parametros[2].SqlDbType = SqlDbType.Money;
            Parametros[2].SqlValue = MontoPrestamo;

            Parametros[3] = new SqlParameter();
            Parametros[3].ParameterName = "@ValorInteres";
            Parametros[3].SqlDbType = SqlDbType.Money;
            Parametros[3].SqlValue = ValorInteres;

            Parametros[4] = new SqlParameter();
            Parametros[4].ParameterName = "@PorcentajeInteres";
            Parametros[4].SqlDbType = SqlDbType.Float;
            Parametros[4].SqlValue = PorcentajeInteres;

            Parametros[5] = new SqlParameter();
            Parametros[5].ParameterName = "@NumeroCuotas";
            Parametros[5].SqlDbType = SqlDbType.Int;
            Parametros[5].SqlValue = NumeroCuotas;

            Parametros[6] = new SqlParameter();
            Parametros[6].ParameterName = "@ModoPago";
            Parametros[6].SqlDbType = SqlDbType.VarChar;
            Parametros[6].SqlValue = ModoPago;

            Parametros[7] = new SqlParameter();
            Parametros[7].ParameterName = "@DiaPago";
            Parametros[7].SqlDbType = SqlDbType.VarChar;
            Parametros[7].SqlValue = DiaPago;

            Parametros[8] = new SqlParameter();
            Parametros[8].ParameterName = "@DiasFechaPago";
            Parametros[8].SqlDbType = SqlDbType.VarChar;
            Parametros[8].SqlValue = DiasFechaPago;

            Parametros[9] = new SqlParameter();
            Parametros[9].ParameterName = "@Estado";
            Parametros[9].SqlDbType = SqlDbType.VarChar;
            Parametros[9].SqlValue = Estado;

            Parametros[10] = new SqlParameter();
            Parametros[10].ParameterName = "@Nota";
            Parametros[10].SqlDbType = SqlDbType.VarChar;
            Parametros[10].SqlValue = Nota;

            Parametros[11] = new SqlParameter();
            Parametros[11].ParameterName = "@FechaRegistros";
            Parametros[11].SqlDbType = SqlDbType.DateTime;
            Parametros[11].SqlValue = FechaRegistros;

            Parametros[12] = new SqlParameter();
            Parametros[12].ParameterName = "@FechaPrimerPago";
            Parametros[12].SqlDbType = SqlDbType.DateTime;
            Parametros[12].SqlValue = FechaPrimerPago;

        }
        public Boolean mtd_registrar()
        {
            v_query = " INSERT INTO tbl_cuenta_cobro (Id_cliente,MontoPrestamo,ValorInteres,PorcentajeInteres,NumeroCuotas,ModoPago,DiaPago,DiasFechaPago,FechaPrimerPago,Estado,Nota, FechaRegistros)" +
                      " VALUES (@Id_cliente,@MontoPrestamo,@ValorInteres,@PorcentajeInteres,@NumeroCuotas,@ModoPago,@DiaPago,@DiasFechaPago,@FechaPrimerPago,@Estado,@Nota,@FechaRegistros)";

            mtd_asignaParametros();
            v_ok = cls_datos.mtd_registrar(Parametros, v_query);
            return v_ok;
        }
        public Boolean mtd_Editar()
        {
            v_query = " UPDATE tbl_cuenta_cobro SET Id_cliente = @Id_cliente,MontoPrestamo = @MontoPrestamo,ValorInteres = @ValorInteres,PorcentajeInteres = @PorcentajeInteres,NumeroCuotas = @NumeroCuotas,ModoPago = @ModoPago,DiaPago = @DiaPago,DiasFechaPago = @DiasFechaPago,FechaPrimerPago = @FechaPrimerPago,Estado = @Estado,Nota = @Nota, FechaRegistros = @FechaRegistros  " +
                      " WHERE Id = " + Id;

            mtd_asignaParametros();
            v_ok = cls_datos.mtd_editar(Parametros, v_query);
            return v_ok;
        }
        public Boolean mtd_eliminar()
        {
            v_query = "DELETE FROM tbl_plan_pagos WHERE Id_cuentaCobro =" + Id;
            v_ok = cls_datos.mtd_eliminar(v_query);
            if (v_ok)
            {
                v_query = "DELETE FROM tbl_cuenta_cobro WHERE Id = " + Id;
                v_ok = cls_datos.mtd_eliminar(v_query);
            }
            return v_ok;
        }
        public Boolean mtd_Editar_numero_cuotas()
        {
            v_query = " UPDATE tbl_cuenta_cobro SET numerocuotas = " + NumeroCuotas +
                      " WHERE Id = " + Id;

            v_ok = cls_datos.mtd_ejecutar(v_query);
            return v_ok;
        }
    }
}
