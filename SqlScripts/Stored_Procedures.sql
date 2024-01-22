DELIMITER //
CREATE PROCEDURE spGetUsuarios()
BEGIN
	SELECT * FROM Usuario;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE spCreateUsuario
(
	_nombre VARCHAR(100), 
    _apellido_paterno VARCHAR(100), 
    _apellido_materno VARCHAR(100), 
    _correo VARCHAR(100), 
    _telefono VARCHAR(100), 
    _id_tipo_usuario INT, 
    _usuario VARCHAR(100), 
    _contrasenia VARCHAR(100)
)
BEGIN
	INSERT INTO Usuario(nombre, apellido_paterno, apellido_materno, correo, telefono, id_tipo_usuario, usuario, contrasenia)
    VALUES(_nombre, _apellido_paterno, _apellido_materno, _correo, _telefono, _id_tipo_usuario, _usuario, _contrasenia);
END //
DELIMITER ;