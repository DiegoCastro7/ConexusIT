DROP DATABASE IF EXISTS ConexusIT;
CREATE DATABASE ConexusIT CHARACTER SET utf8mb4;
USE ConexusIT;

CREATE TABLE cliente (
  identificacion VARCHAR(10) NOT NULL,
  nombres VARCHAR(50) NOT NULL,
  apellidos VARCHAR(50) NOT NULL,
  telefono VARCHAR(20) NOT NULL,
  email VARCHAR(100) NOT NULL,
  direccion VARCHAR(50) NOT NULL,  
  complementos_direccion VARCHAR(50) DEFAULT NULL,
  PRIMARY KEY (identificacion)
);

CREATE TABLE emisor (
  identificacion VARCHAR(10) NOT NULL,
  razon_social VARCHAR(50) NOT NULL,
  telefono VARCHAR(20) NOT NULL,
  email VARCHAR(100) NOT NULL,
  direccion VARCHAR(50) NOT NULL,  
  complementos_direccion VARCHAR(50) DEFAULT NULL,
  PRIMARY KEY (identificacion)
);

CREATE TABLE producto (
  identificacion VARCHAR(10) NOT NULL,
  descripcion_texto TEXT NOT NULL,
  PRIMARY KEY (identificacion)
);

CREATE TABLE factura (
  id INTEGER NOT NULL,
  id_cliente VARCHAR(10) NOT NULL,
  id_emisor VARCHAR(10) NOT NULL,
  total_factura NUMERIC(15,2) NULL,
  PRIMARY KEY (id),
  FOREIGN KEY (id_cliente) REFERENCES cliente (identificacion),
  FOREIGN KEY (id_emisor) REFERENCES emisor (identificacion)
);

CREATE TABLE detalle_factura (
  id INT AUTO_INCREMENT,
  id_factura INTEGER NOT NULL,
  id_producto VARCHAR(10) NOT NULL,
  cantidad INTEGER NOT NULL,
  precio_unidad NUMERIC(15,2) NOT NULL,
  subtotal NUMERIC(15,2) NOT NULL,
  PRIMARY KEY (id),
  FOREIGN KEY (id_producto) REFERENCES producto (identificacion),
  FOREIGN KEY (id_factura) REFERENCES factura (id)
);


INSERT INTO cliente (identificacion, nombres, apellidos, telefono, email, direccion, complementos_direccion)
VALUES ('1020304050', 'Andrés', 'Gómez', '3201234567', 'andres@hotmail.com', 'Carrera 45 #67-89', 'Apartamento 301'),
       ('1030405060', 'María', 'Rodríguez', '3102345678', 'maria@hotmail.com', 'Calle 23 #12-34', NULL),
       ('1040506070', 'Carlos', 'Hernández', '3003456789', 'carlos@hotmail.com', 'Avenida 7 #8-90', NULL);

INSERT INTO emisor (identificacion, razon_social, telefono, email, direccion, complementos_direccion)
VALUES ('1234567890', 'Electrodomésticos S.A.', '3152345678', 'info@electrodomesticos.com', 'Carrera 12 #34-56', NULL),
       ('2345678901', 'Muebles y Decoración S.A.S.', '3112345678', 'info@mueblesdecoracion.com', 'Avenida 56 #78-90', 'Oficina 201');

INSERT INTO producto (codigo, descripcion_texto)
VALUES ('PROD001', 'Televisor LED 50"'),
       ('PROD002', 'Sofá de cuero de 3 plazas'),
       ('PROD003', 'Refrigeradora de acero inoxidable 400L');

INSERT INTO factura (id, id_cliente, id_emisor, total_factura)
VALUES (1, '1020304050', '1234567890', 0),
       (2, '1030405060', '2345678901', 0),
       (3, '1040506070', '1234567890', 0);

INSERT INTO detalle_factura (id_factura, id_producto, cantidad, precio_unidad, subtotal)
VALUES (1, 'PROD001', 1, 2000000.00, 2000000.00),
       (1, 'PROD003', 1, 500000.00, 500000.00),
       (2, 'PROD002', 1, 1000000.00, 1000000.00),
       (3, 'PROD001', 2, 600000.00, 1200000.00);