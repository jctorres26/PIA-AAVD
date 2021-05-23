
CREATE KEYSPACE PIA_AAVD WITH REPLICATION =  {'class' : 'SimpleStrategy', 'replication_factor' : 1};

CREATE TABLE Administrador(
Usuario VARCHAR,
Contrasenia VARCHAR,
Gestion_Empleados MAP<TIMESTAMP, VARCHAR>,
Administrador2 int,
PRIMARY KEY(Usuario)
);

INSERT INTO Administrador (Usuario, Contrasenia) VALUES ('Admin', '123');
--SELECT Nombre_Usuario, Contrasenia FROM Empleado_por_Id_Empleado WHERE Activo = true ALLOW FILTERING;

CREATE TABLE LOGIN_GUARDADO (
	BASE VARCHAR,
	Tipo VARCHAR,
	Recordar BOOLEAN,
	Usuario VARCHAR,
	Contrasenia VARCHAR,
	PRIMARY KEY (BASE)
	
);

SELECT * FROM LOGIN_GUARDADO;
--SELECT * FROM Administrador;
CREATE TABLE Empleado_por_Id_Empleado(
	Id_Empleado UUID,
	CURP VARCHAR,
	RFC VARCHAR,
	Nombre VARCHAR,
	Apellido_Paterno VARCHAR,
	Apellido_Materno VARCHAR,
	Fecha_Nacimiento DATE,
	Nombre_Usuario VARCHAR,
	Contrasenia VARCHAR,
	Activo BOOLEAN,
	Fecha_Alta DATE,
	Fecha_Modificacion timestamp,
	UsuarioACT BOOLEAN,
	Empleado INT,
	Clientes SET<VARCHAR>,
	PRIMARY KEY (Id_Empleado)
);

--drop table 
--drop table Empleado_por_Id_Empleado;
--truncate Empleado_por_Id_Empleado;
SELECT * FROM Empleado_por_Id_Empleado;




CREATE TABLE Cliente_por_Id_Cliente(
	Id_Cliente BIGINT,
	CURP VARCHAR,
	Nombre VARCHAR,
	Apellido_Paterno VARCHAR,
	Apellido_Materno VARCHAR,
	Fecha_Nacimiento DATE,
	Genero VARCHAR,
	Email VARCHAR,
	Nombre_Usuario VARCHAR,
	Contrasenia VARCHAR,
	Activo BOOLEAN,
	Fecha_Alta DATE,
	Fecha_Modificacion LIST<timestamp>,
	Empleado_Modificacion VARCHAR,
	ClienteACT BOOLEAN,
	Cliente INT,
	PRIMARY KEY (Id_Cliente)
);




CREATE TABLE Tarifa_por_Tipo_Anio_Mes(
	Anio VARCHAR,
	Mes VARCHAR,
	Tipo_Servicio VARCHAR,
	Basico FLOAT,
	Intermedio FLOAT,
	Excedente FLOAT,
	Empleado_Modificacion VARCHAR,
	PRIMARY KEY ((Anio,Mes,Tipo_Servicio))
);

SELECT *FROM Contrato_por_Numero_Servicio;

CREATE TABLE Contrato_por_Numero_Servicio(
	Numero_Servicio UUID,
	NumSer BIGINT,
	Numero_Medidor INT,
	Tipo_Servicio VARCHAR,
	Estado VARCHAR,
	Ciudad VARCHAR,
	Colonia VARCHAR,
	Calle VARCHAR,
	CP VARCHAR,
	Numero_Exterior INT,
	Id_Cliente BIGINT,
	Empleado_Modificacion VARCHAR,
	Usuario VARCHAR,
	PRIMARY KEY(Numero_Servicio, Id_Cliente)
); 

CREATE TABLE NumServ (
	idBASE VARCHAR,
	numero COUNTER,
	PRIMARY KEY (idBASE)
);

CREATE TABLE NumCliente (
	idBASE2 VARCHAR,
	numero2 COUNTER,
	PRIMARY KEY (idBASE2)
);

--SELECT * FROM Cliente_por_Id_Cliente;
SELECT * FROM Contrato_por_Numero_Servicio;
--SELECT * FROM NumServ;

--Select numero FROM NumServ;

--SELECT * FROM Administrador;


truncate  NumCliente ;
truncate NumServ;
truncate Empleado_por_Id_Empleado;
--SELECT * FROM  Cliente_por_Id_Cliente;
SELECT * FROM Contrato_por_Numero_Servicio;

CREATE TABLE Consumo_por_Numero_Medidor_Fecha(
	Numero_Medidor INT,
	Fecha DATE,
	Consumo INT,
	Basico INT,
	Intermedio INT,
	Excedente INT,
	Empleado_Modificacion VARCHAR,
	Basicot FLOAT,
	Intermediot FLOAT,
	Excedentet FLOAT,
	FechaAnio VARCHAR,
	FechaMes VARCHAR,
	tipo VARCHAR,
	FechaInicio VARCHAR,
	FechaFinal VARCHAR,
	FechaExcedente VARCHAR,
	PRIMARY KEY((Numero_Medidor, FechaAnio, FechaMes, FechaFinal))
);






SELECT *FROM  Consumo_por_Numero_Medidor_Fecha;
SELECT *FROM Reporte_Consumos;
SELECT * FROM Recibo_por_Numero_Servicio_Anio_Mes;
CREATE TABLE Recibo_por_Numero_Servicio_Anio_Mes(
	Numero_Servicio BIGINT,
	Fecha DATE,
	AnioF VARCHAR,
	MesF VARCHAR,
	FechaF VARCHAR,
	FechaI VARCHAR,
	Tipo_Servicio VARCHAR,
	Consumo INT,
	Consumo_Basico INT,
	Consumo_Intermedio INT,
	Consumo_Excedente INT,
	Tarifa_Basico FLOAT,
	Tarifa_Intermedio FLOAT,
	Tarifa_Excedente FLOAT,
	Subtotal_Basico FLOAT,
	Subtotal_Intermedio FLOAT,
	Subtotal_Excedente FLOAT,
	Is_Paid BOOLEAN,
	Importe FLOAT,
	Importe_IVA DOUBLE,
	Cantidad_Pagada FLOAT,
	Cantidad_Pendiente DOUBLE,
	Recibo_Generado BOOLEAN,
	Medidor INT,
	Dia VARCHAR,
	Usuario VARCHAR,
	PRIMARY KEY ((Numero_Servicio, AnioF, MesF,Dia ))
);

select * from  Recibo_por_Numero_Servicio_Anio_Mes;
CREATE TABLE ConsumoH(
	Numero_Servicio BIGINT,
	Medidor INT,
	AnioF VARCHAR,
	MesF VARCHAR,
	Dia VARCHAR,
	Consumo INT, 
	Importe_IVA DOUBLE,
	Cantidad_Pagada FLOAT,
	Cantidad_Pendiente DOUBLE,
	Generado BOOLEAN,
	Tipo VARCHAR,
	Fecha VARCHAR,
	PRIMARY KEY ((Numero_Servicio, AnioF, MesF,Dia ))
	
); 

--SELECT  Numero_Servicio, AnioF, MesF, Tipo, Dia   FROM ConsumoH WHERE  AnioF = '2021' AND MesF= '5' AND Tipo= 'Domiciliar' ALLOW FILTERING;

SELECT * FROM ConsumoH;
SELECT * FROM Recibo_por_Numero_Servicio_Anio_Mes;


CREATE TABLE Tarifa_por_Anio(
	Anio VARCHAR,
	Mes VARCHAR,
	Basico FLOAT,
	Intermedio FLOAT,
	Excedente FLOAT,
	Tipo_Servicio VARCHAR,
	PRIMARY KEY(Anio,Mes,Tipo_Servicio)
)WITH CLUSTERING ORDER BY(Mes ASC);



truncate Tarifa_por_Anio;
--Select * FROM Tarifa_por_Anio;

CREATE TABLE Reporte_General_por_Anio(
	Anio VARCHAR,
	Mes VARCHAR,
	Tipo_Servicio VARCHAR,
	Total_Pagado FLOAT,
	Pendiente_Pago FLOAT,
	PRIMARY KEY(Anio, Mes, Tipo_Servicio)
);

CREATE TABLE Reporte_General_por_Anio_Mes(
	Anio VARCHAR,
	Mes VARCHAR,
	Tipo_Servicio VARCHAR,
	Total_Pagado FLOAT,
	Pendiente_Pago FLOAT,
	PRIMARY KEY((Anio, Mes), Tipo_Servicio)
);

CREATE TABLE Reporte_General_por_Anio_Mes_Tipo_Servicio(
	Anio VARCHAR,
	Mes VARCHAR,
	Tipo_Servicio VARCHAR,
	Total_Pagado FLOAT,
	Pendiente_Pago FLOAT,
	PRIMARY KEY((Anio, Mes, Tipo_Servicio))
);

CREATE TABLE Consumo_Historico_por_Anio_Numero_Servicio(
	Anio VARCHAR,
	Numero_Servicio INT,
	Mes VARCHAR,
	Consumo INT,
	Importe FLOAT,
	Pagado FLOAT,
	Pendiente_Pago FLOAT,
	PRIMARY KEY((Anio, Numero_Servicio),Mes)
);

CREATE TABLE Consumo_Historico_por_Anio_Numero_Medidor(
	Anio VARCHAR,
	Numero_Medidor INT,
	Mes VARCHAR,
	Consumo INT,
	Importe FLOAT,
	Pagado FLOAT,
	Pendiente_Pago FLOAT,
	PRIMARY KEY((Anio, Numero_Medidor),Mes)
);


CREATE TABLE Reporte_Consumos(
	Anio VARCHAR,
	Mes VARCHAR,
	Numero_Medidor INT,
	Basico INT,
	Intermedio INT,
	Excedente INT,
	Fecha VARCHAR,
	PRIMARY KEY(Anio,Mes,Numero_Medidor,Fecha)
)WITH CLUSTERING ORDER BY(Mes ASC);



truncate   Reporte_Consumos;
truncate Recibo_por_Numero_Servicio_Anio_Mes;
truncate Consumo_por_Numero_Medidor_Fecha;
truncate ConsumoH;
truncate Reporte_Consumos;
truncate Tarifa_por_Tipo_Anio_Mes;
--truncate Tarifa_por_Anio;
SELECT * FROM Cliente_por_Id_Cliente;
SELECT * FROM Recibo_por_Numero_Servicio_Anio_Mes;
