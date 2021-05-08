
CREATE KEYSPACE PIA_AAVD WITH REPLICATION =  {'class' : 'SimpleStrategy', 'replication_factor' : 1};

CREATE TABLE Administrador(
Usuario VARCHAR,
Contrasenia VARCHAR,
Gestion_Empleados MAP<TIMESTAMP, VARCHAR>,
PRIMARY KEY(Usuario)
);



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
	Fecha_Modificacion LIST<DATE>,
	PRIMARY KEY (Id_Empleado)
);
--drop table Empleado_por_Id_Empleado;
truncate Empleado_por_Id_Empleado;
SELECT * FROM Empleado_por_Id_Empleado;
CREATE TABLE Cliente_por_Id_Cliente(
	Id_Cliente INT,
	CURP VARCHAR,
	Nombre VARCHAR,
	Apellido_Paterno VARCHAR,
	Apellido_Materno VARCHAR,
	Fecha_Nacimiento VARCHAR,
	Genero VARCHAR,
	Email SET<VARCHAR>,
	Nombre_Usuario VARCHAR,
	Contrasenia VARCHAR,
	Activo BOOLEAN,
	Fecha_Alta DATE,
	Fecha_Modificacion DATE,
	Empleado_Modificacion VARCHAR,
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

CREATE TABLE Contrato_por_Numero_Servicio(
	Numero_Servicio INT,
	Numero_Medidor INT,
	Tipo_Servicio VARCHAR,
	Estado VARCHAR,
	Ciudad VARCHAR,
	Colonia VARCHAR,
	Calle VARCHAR,
	CP INT,
	Numero_Exterior INT,
	Id_Cliente INT,
	Empleado_Modificacion VARCHAR,
	PRIMARY KEY(Numero_Servicio, Id_Cliente)
);

CREATE TABLE Consumo_por_Numero_Medidor_Fecha(
	Numero_Medidor INT,
	Fecha DATE,
	Consumo INT,
	Basico INT,
	Intermedio INT,
	Excedente INT,
	Empleado_Modificacion VARCHAR,
	PRIMARY KEY((Numero_Medidor, Fecha))
);

CREATE TABLE Recibo_por_Numero_Servicio_Anio_Mes(
	Numero_Servicio INT,
	Anio VARCHAR,
	Mes VARCHAR,
	Fecha DATE,
	Tipo_Servicio VARCHAR,
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
	Importe_IVA FLOAT,
	Cantidad_Pagada FLOAT,
	Cantidad_Pendiente FLOAT,
	PRIMARY KEY ((Numero_Servicio, Anio, Mes))
);

CREATE TABLE Tarifa_por_Anio(
	Anio VARCHAR,
	Mes VARCHAR,
	Tipo_Servicio VARCHAR,
	Basico FLOAT,
	Intermedio FLOAT,
	Excedente FLOAT,
	PRIMARY KEY(Anio, Mes, Tipo_Servicio)
);

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
	PRIMARY KEY(Anio,Mes,Numero_Medidor)
);




