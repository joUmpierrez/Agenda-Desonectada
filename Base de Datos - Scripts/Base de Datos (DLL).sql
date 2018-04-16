CREATE DATABASE [Programacion3-Agenda];
USE [Programacion3-Agenda];

CREATE TABLE Agendas (nombre varchar(50) NOT NULL, fechaCreacion date NOT NULL, activo bit NOT NULL, 
CONSTRAINT PK_Agendas PRIMARY KEY (nombre));

CREATE TABLE Contactos (nombre varchar(50) NOT NULL, fechaNacimiento date NOT NULL, pais varchar(50) NOT NULL, agenda varchar(50) NOT NULL, activo bit NOT NULL,
CONSTRAINT PK_Contactos PRIMARY KEY (nombre),
CONSTRAINT FK_Contactos_Agendas FOREIGN KEY (agenda) REFERENCES Agendas(nombre));

CREATE TABLE Telefonos (tipoTelefono varchar(50) NOT NULL, telefono varchar(50) NOT NULL, contacto varchar(50) NOT NULL, activo bit NOT NULL,
CONSTRAINT PK_Telefonos PRIMARY KEY (tipoTelefono, telefono, contacto),
CONSTRAINT FK_Telefonos_Contactos FOREIGN KEY (contacto) REFERENCES Contactos(nombre));

CREATE TABLE Emails (email varchar(50) NOT NULL, contacto varchar(50) NOT NULL, activo bit NOT NULL,
CONSTRAINT PK_Emails PRIMARY KEY (email, contacto),
CONSTRAINT FK_Emails_Contactos FOREIGN KEY (contacto) REFERENCES Contactos(nombre));

CREATE TABLE Citas (fecha date NOT NULL, horaInicio time NOT NULL, horaFinal time NOT NULL, contacto varchar(50) NOT NULL, activo bit NOT NULL,
CONSTRAINT PK_Citas PRIMARY KEY (fecha, horaInicio, horaFinal, contacto),
CONSTRAINT FK_Citas_Contactos FOREIGN KEY (contacto) REFERENCES Contactos(nombre));