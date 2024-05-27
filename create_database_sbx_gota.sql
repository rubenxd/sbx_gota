--CREATE DATABASE SBX_GOTA;

USE SBX_GOTA
GO
CREATE TABLE tbl_cliente(
Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
TipoIdentificacion varchar(20),
NumeroIdentificacion varchar(20),
Nombres varchar(100),
Apellidos varchar(100),
Celular varchar(100),
Direccion varchar(200),
FechaRegistro datetime
)
GO
CREATE TABLE tbl_contacto(
Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
TipoIdentificacion varchar(20),
NumeroIdentificacion varchar(20),
Nombres varchar(100),
Apellidos varchar(100),
Celular varchar(100),
Direccion varchar(200),
Id_cliente int,
FechaRegistro datetime,
foreign key(Id_cliente) references tbl_cliente(Id)
)
GO
CREATE TABLE tbl_cuenta_cobro(
Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
Id_cliente int,
MontoPrestamo money,
ValorInteres money,
PorcentajeInteres float,
NumeroCuotas int,
ModoPago varchar(30),
DiaPago varchar(50),
DiasFechaPago varchar(50),
FechaPrimerPago date,
Estado varchar(20),
Nota varchar(100),
FechaRegistros datetime,
foreign key(Id_cliente) references tbl_cliente(Id)
)
GO
CREATE TABLE tbl_plan_pagos(
Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
Id_cuentaCobro int,
NumeroCuota int,
VlrCuota money,
FechaCuota datetime,
Estado varchar(30),
FechaRegistro datetime,
foreign key(Id_cuentaCobro) references tbl_cuenta_cobro(Id)
)
GO
CREATE TABLE tbl_abonos(
Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
Id_plan_pagos int,
ValorAbono money,
Nota varchar(100),
FechaRegistro datetime,
foreign key(Id_plan_pagos) references tbl_plan_pagos(Id)
)
GO
CREATE TABLE tbl_rol(
Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
Nombre varchar(30),
Descripcion varchar(100) 
)
GO
CREATE TABLE tbl_usuario(
Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
Usuario varchar(100),
contraseña varchar(max),
IdRol int,
foreign key(IdRol) references tbl_rol(Id)
)
GO
CREATE TABLE tbl_colaborador(
Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
TipoIdentificacion varchar(20),
NumeroIdentificacion varchar(20),
Nombres varchar(100),
Apellidos varchar(100),
Celular varchar(100),
Direccion varchar(200),
FechaRegistro datetime
)
GO
CREATE TABLE tbl_pago_colaborador(
Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
Id_colaborador int,
ValorPago money,
Nota varchar(100),
FechaRegistro datetime,
foreign key(Id_colaborador) references tbl_colaborador(Id)
)
GO
CREATE TABLE tbl_parametro(
Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
Nombre varchar(30),
Valor varchar(max),
Descripcion varchar(100) 
)
GO
Insert into tbl_rol(Nombre, Descripcion) values('Administrador','Control Total')
GO
insert into tbl_usuario(Usuario,contraseña,IdRol) values('admin',ENCRYPTBYPASSPHRASE('password','admin'),1) 
GO
insert into tbl_parametro(Nombre,Valor,Descripcion) values('RutaBackup','','ruta en donde se guardara la copia de seguridad')
GO
insert into tbl_parametro(Nombre,Valor,Descripcion) values('RutaDestino','','ruta a donde se movera la copia de seguridad')
GO
CREATE PROC sp_consultar_cliente
	@v_buscar VARCHAR(300)
AS
BEGIN
	SELECT *
	FROM tbl_cliente c 
	WHERE (NumeroIdentificacion LIKE @v_buscar+'%' OR c.Nombres LIKE @v_buscar+'%' OR c.Apellidos LIKE @v_buscar+'%')		
END
GO
create PROC sp_consultar_cuenta_cobro
	@v_buscar VARCHAR(300)
AS
BEGIN
	SELECT c.Id IdCuentaCobro, cl.NumeroIdentificacion, cl.Nombres +' ' + cl.Apellidos Cliente, REPLACE(FORMAT(c.MontoPrestamo, '#,##0'), ',', '.') MontoPrestamo, 
	REPLACE(FORMAT(c.ValorInteres, '#,##0'), ',', '.') ValorInteres,c.PorcentajeInteres, c.NumeroCuotas,c.ModoPago, c.DiaPago,c.DiasFechaPago,c.Nota, c.Id_cliente
	FROM tbl_cuenta_cobro c 
	INNER JOIN tbl_cliente cl on c.Id_cliente = cl.Id
	WHERE (cl.NumeroIdentificacion LIKE @v_buscar+'%' OR cl.Nombres +' '+ cl.Apellidos LIKE @v_buscar+'%')
	order by c.Id desc;			
END
GO
create PROC sp_consultar_cuenta_cobro_exacto
	@v_buscar int
AS
BEGIN
	SELECT c.Id IdCuentaCobro, cl.NumeroIdentificacion, cl.Nombres +' ' + cl.Apellidos Cliente,REPLACE(FORMAT(c.MontoPrestamo, '#,##0'), ',', '.') MontoPrestamo, 
	REPLACE(FORMAT(c.ValorInteres, '#,##0'), ',', '.') ValorInteres,c.PorcentajeInteres, c.NumeroCuotas,c.ModoPago, c.DiaPago,c.DiasFechaPago,c.Nota, c.Id_cliente
	FROM tbl_cuenta_cobro c 
	INNER JOIN tbl_cliente cl on c.Id_cliente = cl.Id
	WHERE c.Id = @v_buscar		
END
GO
create PROC sp_consultar_plan_pagos
	@v_buscar int
AS
BEGIN
	SELECT pp.id,pp.Id_cuentaCobro,pp.NumeroCuota,REPLACE(FORMAT(pp.VlrCuota, '#,##0'), ',', '.') VlrCuota,pp.FechaCuota,pp.Estado,
	REPLACE(FORMAT(isnull((select SUM(ta.ValorAbono) ValorAbono from tbl_abonos ta where Id_plan_pagos = pp.Id),0), '#,##0'), ',', '.') ValorAbono,
	REPLACE(FORMAT(isnull(pp.VlrCuota - ((select isnull(SUM(ta.ValorAbono),0) ValorAbono from tbl_abonos ta where Id_plan_pagos = pp.Id)),0), '#,##0'), ',', '.') Saldo
	--,pp.FechaRegistro
	FROM tbl_plan_pagos pp 
	WHERE Id_cuentaCobro = @v_buscar
END
GO
create PROC sp_consultar_Abonos
	@v_buscar VARCHAR(300)
AS
BEGIN
	SELECT ta.Id IdAbono,REPLACE(FORMAT(ta.ValorAbono, '#,##0'), ',', '.') ValorAbono,ta.FechaRegistro,pp.Id_cuentaCobro,pp.Id IdPago, tc.NumeroIdentificacion, tc.Nombres, tc.Apellidos 
	FROM tbl_abonos ta 
	INNER JOIN tbl_plan_pagos pp ON ta.Id_plan_pagos = pp.Id
	INNER JOIN tbl_cuenta_cobro cc ON cc.Id = pp.Id_cuentaCobro
	INNER JOIN tbl_cliente tc ON tc.Id = cc.Id_cliente
	WHERE (tc.NumeroIdentificacion LIKE @v_buscar+'%' OR tc.Nombres +' '+ tc.Apellidos LIKE @v_buscar+'%')	 
	ORDER BY ta.Id desc
END
GO
create PROC sp_consultar_resultados
	@v_buscar VARCHAR(300)
AS
BEGIN
	select
	c.NumeroIdentificacion,
	c.Nombres + ' ' + c.Apellidos Cliente, 
	cc.id IdCuentaCobro,
	cc.MontoPrestamo,
	(select sum(tcc.MontoPrestamo) from tbl_cuenta_cobro tcc ) MontoPrestamoReal,
	cc.ValorInteres,
	(select sum(tcc2.ValorInteres) from tbl_cuenta_cobro tcc2 ) ValorInteresesReal,
	cc.NumeroCuotas,
	pp.VlrCuota,
	ab.ValorAbono,
	ab.ValorAbono - (ab.ValorAbono * (cc.ValorInteres/cc.NumeroCuotas) / pp.VlrCuota) ValorRecuperado,
	(ab.ValorAbono * (cc.ValorInteres/cc.NumeroCuotas) / pp.VlrCuota) Ganancia,
	(ab.ValorAbono * (cc.ValorInteres/cc.NumeroCuotas) / pp.VlrCuota)/ 2 GananciaXPersona,
	(Select sum(Saldo) Saldo from (
		SELECT 
			isnull(pp.VlrCuota - ((select isnull(SUM(ta.ValorAbono),0) ValorAbono from tbl_abonos ta where Id_plan_pagos = pp.Id)),0)  Saldo
		FROM tbl_plan_pagos pp 
	)t) Saldo
	from tbl_abonos ab
	inner join tbl_plan_pagos pp on pp.Id = ab.Id_plan_pagos
	inner join tbl_cuenta_cobro cc on cc.Id = pp.Id_cuentaCobro
	inner join tbl_cliente c on c.Id = cc.Id_cliente
	WHERE 
	(c.NumeroIdentificacion LIKE @v_buscar+'%' OR c.Nombres +' '+ c.Apellidos LIKE @v_buscar+'%')	 
	order by cc.id
END
GO
CREATE PROCEDURE  sp_verificar_login
	@Usuarios VARCHAR(50),
	@Contrasenas VARCHAR(50)
	AS
BEGIN
	DECLARE
	@PassEncritado VARCHAR(300),
	@PassDecifrado VARCHAR(300)

	SET @PassEncritado = (SELECT contraseña FROM tbl_usuario WHERE Usuario = @Usuarios)
	SET	@PassDecifrado = DECRYPTBYPASSPHRASE('password', @PassEncritado)
	IF(@PassDecifrado = @Contrasenas)
	SELECT Id,Usuario FROM tbl_usuario WHERE Usuario = @Usuarios
	ELSE
	SELECT Id,Usuario FROM tbl_usuario WHERE Id = 0
END
GO
create PROC sp_consultar_colaboradores
	@v_buscar VARCHAR(300)
AS
BEGIN
	SELECT *
	FROM tbl_colaborador c 
	WHERE (NumeroIdentificacion LIKE @v_buscar+'%' OR c.Nombres LIKE @v_buscar+'%' OR c.Apellidos LIKE @v_buscar+'%')		
END
GO
create PROC sp_consultar_pago_colaborador
AS
BEGIN
	SELECT Id, Id_colaborador, REPLACE(FORMAT(ValorPago, '#,##0'), ',', '.') ValorPago, Nota, FechaRegistro
	FROM tbl_pago_colaborador c 
	order by Id desc	
END
GO
create PROC sp_consultar_pagos_pendientes
	@v_buscar VARCHAR(300),
	@FechaIni AS DATE,
	@FechaFin AS DATE
AS
BEGIN
	select c.NumeroIdentificacion,c.Nombres + ' '+ c.Apellidos Cliente,c.Celular,cc.id IdCuentaCobro, pp.NumeroCuota,REPLACE(FORMAT(pp.VlrCuota, '#,##0'), ',', '.') VlrCuota,pp.FechaCuota,pp.Estado 
	from tbl_plan_pagos pp
	inner join tbl_cuenta_cobro cc on cc.Id = pp.Id_cuentaCobro
	inner join tbl_cliente c on c.Id = cc.Id_cliente
	where pp.Estado != 'Pago' and
	(NumeroIdentificacion LIKE @v_buscar+'%' OR c.Nombres + ' ' + c.Apellidos LIKE @v_buscar+'%') and
	CONVERT(date,pp.FechaCuota) between @FechaIni and @FechaFin
	order by FechaCuota asc;	
END
GO
create PROC sp_consultar_parametros
AS
BEGIN
	SELECT *
	FROM tbl_parametro
	order by Id asc	
END
GO
CREATE PROC sp_consultar_pagos_pendientes_2
	@v_buscar VARCHAR(300),
	@FechaFin AS DATE
	AS
BEGIN
select pp.Id idPlanPagos, pp.Id_cuentaCobro,c.NumeroIdentificacion,c.Nombres + ' ' + c.Apellidos Cliente, pp.NumeroCuota, 
REPLACE(FORMAT(pp.VlrCuota, '#,##0'), ',', '.') VlrCuota, 
CAST(pp.FechaCuota as date) FechaCuota, pp.Estado,
CASE WHEN DATEDIFF(day,CAST(pp.FechaCuota as datetime),CAST(GETDATE() as datetime)) < 0 THEN 0 ELSE DATEDIFF(day,CAST(pp.FechaCuota as datetime),CAST(GETDATE() as datetime)) END AS DiasMora,
cc.ModoPago,cc.DiaPago,cc.DiasFechaPago
from tbl_plan_pagos pp
inner join tbl_cuenta_cobro cc on cc.Id = pp.Id_cuentaCobro
inner join tbl_cliente c on c.Id = cc.Id_cliente
where pp.Estado = 'Pendiente' and (c.Nombres + ' ' + c.Apellidos LIKE @v_buscar+'%' or c.NumeroIdentificacion LIKE @v_buscar+'%') 
and
(CONVERT(date,pp.FechaCuota) = @FechaFin )
order by pp.Id_cuentaCobro, pp.NumeroCuota
END
GO
CREATE PROC sp_consultar_pagos_pendientes_3
	@v_buscar VARCHAR(300)
	AS
BEGIN
select pp.Id idPlanPagos, pp.Id_cuentaCobro,c.NumeroIdentificacion,c.Nombres + ' ' + c.Apellidos Cliente, pp.NumeroCuota, 
REPLACE(FORMAT(pp.VlrCuota, '#,##0'), ',', '.') VlrCuota, 
CAST(pp.FechaCuota as date) FechaCuota, pp.Estado,
CASE WHEN DATEDIFF(day,CAST(pp.FechaCuota as datetime),CAST(GETDATE() as datetime)) < 0 THEN 0 ELSE DATEDIFF(day,CAST(pp.FechaCuota as datetime),CAST(GETDATE() as datetime)) END AS DiasMora,
cc.ModoPago,cc.DiaPago,cc.DiasFechaPago
from tbl_plan_pagos pp
inner join tbl_cuenta_cobro cc on cc.Id = pp.Id_cuentaCobro
inner join tbl_cliente c on c.Id = cc.Id_cliente
where pp.Estado = 'Pendiente' and (c.Nombres + ' ' + c.Apellidos LIKE @v_buscar+'%' or c.NumeroIdentificacion LIKE @v_buscar+'%') 
order by pp.Id_cuentaCobro, pp.NumeroCuota
END
