-- CREACIÓN DE LA BASE DE DATOS Y TABLAS
CREATE DATABASE Empresa;
GO

USE Empresa;
GO

-- Tabla Usuarios
CREATE TABLE Usuarios (
    Id INT IDENTITY PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Correoelectronico NVARCHAR(200) NOT NULL,
    Telefono NVARCHAR(15) NOT NULL
);

-- Tabla Equipos
CREATE TABLE Equipos (
    EquipoId INT IDENTITY PRIMARY KEY,
    TipoEquipo NVARCHAR(150) NOT NULL,
    Modelo NVARCHAR(100) NOT NULL,
    IdUsuario INT NOT NULL FOREIGN KEY REFERENCES Usuarios(Id)
);

-- Tabla Tecnicos
CREATE TABLE Tecnicos (
    TecnicoId INT IDENTITY PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL,
    Especialidad NVARCHAR(50)
);

-- PROCEDIMIENTOS ALMACENADOS

-- Mantenimiento Usuarios
CREATE PROCEDURE AgregarUsuario
    @Nombre NVARCHAR(100),
    @Correoelectronico NVARCHAR(200),
    @Telefono NVARCHAR(15)
AS
BEGIN
    INSERT INTO Usuarios (Nombre, Correoelectronico, Telefono)
    VALUES (@Nombre, @Correoelectronico, @Telefono);
END;
GO

CREATE PROCEDURE ConsultarUsuarios
AS
BEGIN
    SELECT * FROM Usuarios;
END;
GO

CREATE PROCEDURE ModificarUsuario
    @Id INT,
    @Nombre NVARCHAR(100),
    @Correoelectronico NVARCHAR(200),
    @Telefono NVARCHAR(15)
AS
BEGIN
    UPDATE Usuarios
    SET Nombre = @Nombre,
        Correoelectronico = @Correoelectronico,
        Telefono = @Telefono
    WHERE Id = @Id;
END;
GO

CREATE PROCEDURE BorrarUsuario
    @Id INT
AS
BEGIN
    DELETE FROM Usuarios WHERE Id = @Id;
END;
GO

-- Mantenimiento Equipos
CREATE PROCEDURE AgregarEquipo
    @TipoEquipo NVARCHAR(150),
    @Modelo NVARCHAR(100),
    @IdUsuario INT
AS
BEGIN
    INSERT INTO Equipos (TipoEquipo, Modelo, IdUsuario)
    VALUES (@TipoEquipo, @Modelo, @IdUsuario);
END;
GO

CREATE PROCEDURE ConsultarEquipos
AS
BEGIN
    SELECT * FROM Equipos;
END;
GO

CREATE PROCEDURE ModificarEquipo
    @EquipoId INT,
    @TipoEquipo NVARCHAR(150),
    @Modelo NVARCHAR(100),
    @IdUsuario INT
AS
BEGIN
    UPDATE Equipos
    SET TipoEquipo = @TipoEquipo,
        Modelo = @Modelo,
        IdUsuario = @IdUsuario
    WHERE EquipoId = @EquipoId;
END;
GO

CREATE PROCEDURE BorrarEquipo
    @EquipoId INT
AS
BEGIN
    DELETE FROM Equipos WHERE EquipoId = @EquipoId;
END;
GO

-- Mantenimiento Tecnicos
CREATE PROCEDURE AgregarTecnico
    @Nombre NVARCHAR(50),
    @Especialidad NVARCHAR(50)
AS
BEGIN
    INSERT INTO Tecnicos (Nombre, Especialidad)
    VALUES (@Nombre, @Especialidad);
END;
GO

CREATE PROCEDURE ConsultarTecnicos
AS
BEGIN
    SELECT * FROM Tecnicos;
END;
GO

CREATE PROCEDURE ModificarTecnico
    @TecnicoId INT,
    @Nombre NVARCHAR(50),
    @Especialidad NVARCHAR(50)
AS
BEGIN
    UPDATE Tecnicos
    SET Nombre = @Nombre,
        Especialidad = @Especialidad
    WHERE TecnicoId = @TecnicoId;
END;
GO

CREATE PROCEDURE BorrarTecnico
    @TecnicoId INT
AS
BEGIN
    DELETE FROM Tecnicos WHERE TecnicoId = @TecnicoId;
END;
GO
