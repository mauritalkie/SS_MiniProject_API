CREATE DATABASE IF NOT EXISTS social_service_db;

USE social_service_db;

CREATE TABLE IF NOT EXISTS TipoUsuario (
	id INT AUTO_INCREMENT,
    nombre VARCHAR(100) NOT NULL,
    clave VARCHAR(100) NOT NULL,
    PRIMARY KEY(id)
);

CREATE TABLE IF NOT EXISTS Acceso (
	id INT AUTO_INCREMENT,
    clave VARCHAR(100) NOT NULL,
    nombre VARCHAR(100) NOT NULL,
    PRIMARY KEY(id)
);

CREATE TABLE IF NOT EXISTS Perfil (
	id INT AUTO_INCREMENT,
    nombre VARCHAR(100) NOT NULL,
    clave VARCHAR(100) UNIQUE NOT NULL,
    PRIMARY KEY(id)
);

CREATE TABLE IF NOT EXISTS TipoAhorro (
	id INT AUTO_INCREMENT,
    nombre VARCHAR(100) NOT NULL,
    clave VARCHAR(100) UNIQUE NOT NULL,
    PRIMARY KEY(id)
);

CREATE TABLE IF NOT EXISTS Usuario (
	id INT AUTO_INCREMENT,
    nombre VARCHAR(100) NOT NULL,
    apellido_paterno VARCHAR(100) NOT NULL,
    apellido_materno VARCHAR(100) NOT NULL,
    correo VARCHAR(100) NOT NULL,
    telefono VARCHAR(100) NOT NULL,
    id_tipo_usuario INT NOT NULL,
    usuario VARCHAR(100) NOT NULL,
    contrasenia VARCHAR(100) NOT NULL,
    PRIMARY KEY(id),
    FOREIGN KEY(id_tipo_usuario) REFERENCES TipoUsuario(id)
);

CREATE TABLE IF NOT EXISTS PerfilAcceso (
	id INT AUTO_INCREMENT,
    id_acceso INT NOT NULL,
    id_perfil INT NOT NULL,
    PRIMARY KEY(id),
    FOREIGN KEY(id_acceso) REFERENCES Acceso(id),
    FOREIGN KEY(id_perfil) REFERENCES Perfil(id)
);

CREATE TABLE IF NOT EXISTS PerfilUsuario (
	id INT AUTO_INCREMENT,
    id_usuario INT NOT NULL,
    id_perfil INT NOT NULL,
    PRIMARY KEY(id),
    FOREIGN KEY(id_usuario) REFERENCES Usuario(id),
    FOREIGN KEY(id_perfil) REFERENCES Perfil(id)
);

CREATE TABLE IF NOT EXISTS Cliente (
	id INT AUTO_INCREMENT,
    numero VARCHAR(100) UNIQUE NOT NULL,
    nombre VARCHAR(100) NOT NULL,
    rfc VARCHAR(20) UNIQUE NOT NULL,
    direccion VARCHAR(100) NOT NULL,
    correo VARCHAR(100) NOT NULL,
    PRIMARY KEY(id)
);

CREATE TABLE IF NOT EXISTS ClienteEstructura (
	id INT AUTO_INCREMENT,
    nombre VARCHAR(100) NOT NULL,
    id_cliente INT NOT NULL,
    PRIMARY KEY(id),
    FOREIGN KEY(id_cliente) REFERENCES Cliente(id)
);

CREATE TABLE IF NOT EXISTS TipoAhorroCliente (
	id INT AUTO_INCREMENT,
    alias VARCHAR(100) NOT NULL,
    id_cliente INT NOT NULL,
    PRIMARY KEY(id),
    FOREIGN KEY(id_cliente) REFERENCES Cliente(id)
);

CREATE TABLE IF NOT EXISTS EstructuraAhorro (
	id INT AUTO_INCREMENT,
    id_tipo_ahorro_cliente INT NOT NULL,
    id_cliente_estructura INT NOT NULL,
    PRIMARY KEY(id),
    FOREIGN KEY(id_tipo_ahorro_cliente) REFERENCES TipoAhorroCliente(id),
    FOREIGN KEY(id_cliente_estructura) REFERENCES ClienteEstructura(id)
);