-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 06-08-2021 a las 02:08:26
-- Versión del servidor: 10.4.19-MariaDB
-- Versión de PHP: 7.3.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `viveros_tamez`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cat_anio`
--

CREATE TABLE `cat_anio` (
  `id_anio` int(11) NOT NULL,
  `anio` char(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `cat_anio`
--

INSERT INTO `cat_anio` (`id_anio`, `anio`) VALUES
(1, '2021'),
(2, '2022');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cat_categorias`
--

CREATE TABLE `cat_categorias` (
  `id_categoria` int(11) NOT NULL,
  `categoria` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `cat_categorias`
--

INSERT INTO `cat_categorias` (`id_categoria`, `categoria`) VALUES
(1, 'CATEGORIA 1'),
(2, 'CATEGORIA 2'),
(3, 'CATEGORIA 3');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cat_clasificacion_descuento`
--

CREATE TABLE `cat_clasificacion_descuento` (
  `id_clasificacion_descuento` int(11) NOT NULL,
  `clasificacion_descuento` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `cat_clasificacion_descuento`
--

INSERT INTO `cat_clasificacion_descuento` (`id_clasificacion_descuento`, `clasificacion_descuento`) VALUES
(1, 'FALTA'),
(2, 'INCIDENTE');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cat_puestos`
--

CREATE TABLE `cat_puestos` (
  `id_puesto` int(11) NOT NULL,
  `puesto` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `cat_puestos`
--

INSERT INTO `cat_puestos` (`id_puesto`, `puesto`) VALUES
(1, 'PUESTO 1'),
(2, 'PUESTO 2'),
(3, 'PUESTO 3'),
(4, 'PUESTO 4'),
(5, 'PUESTO 5');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cat_quincena`
--

CREATE TABLE `cat_quincena` (
  `id_quincena` int(11) NOT NULL,
  `quincena` char(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `cat_quincena`
--

INSERT INTO `cat_quincena` (`id_quincena`, `quincena`) VALUES
(1, '1'),
(2, '2'),
(3, '3'),
(4, '4'),
(5, '5'),
(6, '6'),
(7, '7'),
(8, '8'),
(9, '9'),
(10, '10'),
(11, '11'),
(12, '12'),
(13, '13'),
(14, '14'),
(15, '15'),
(16, '16'),
(17, '17'),
(18, '18'),
(19, '19'),
(20, '20'),
(21, '21'),
(22, '22'),
(23, '23'),
(24, '24');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cat_status`
--

CREATE TABLE `cat_status` (
  `id_status` int(11) NOT NULL,
  `status` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `cat_status`
--

INSERT INTO `cat_status` (`id_status`, `status`) VALUES
(1, 'ACTIVO'),
(2, 'BAJA'),
(3, 'CANCELADO');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cat_status_nomina`
--

CREATE TABLE `cat_status_nomina` (
  `id_status_nomina` int(11) NOT NULL,
  `status_nomina` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `cat_status_nomina`
--

INSERT INTO `cat_status_nomina` (`id_status_nomina`, `status_nomina`) VALUES
(1, 'REGISTRADA'),
(2, 'CALCULADA'),
(3, 'APLICADA'),
(4, 'CANCELADA');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cat_tipo_usuario`
--

CREATE TABLE `cat_tipo_usuario` (
  `id_tipo_usuario` int(11) NOT NULL,
  `tipo_usuario` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `cat_tipo_usuario`
--

INSERT INTO `cat_tipo_usuario` (`id_tipo_usuario`, `tipo_usuario`) VALUES
(1, 'ADMINISTRADOR'),
(2, 'CLIENTE'),
(3, 'PERSONAL');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `clientes`
--

CREATE TABLE `clientes` (
  `id_cliente` int(11) NOT NULL,
  `nombre` varchar(200) NOT NULL,
  `app_paterno` varchar(200) NOT NULL,
  `app_materno` varchar(200) NOT NULL,
  `rfc` varchar(13) NOT NULL,
  `direccion` varchar(500) NOT NULL,
  `telefono` varchar(50) NOT NULL,
  `id_status` int(11) NOT NULL,
  `fec_registro` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `clientes`
--

INSERT INTO `clientes` (`id_cliente`, `nombre`, `app_paterno`, `app_materno`, `rfc`, `direccion`, `telefono`, `id_status`, `fec_registro`) VALUES
(1, 'Fulanito', 'Perez', 'Gonzalez', 'sadfadfas3242', 'sadfasfkjlkajlkf', '5461684684', 1, '2021-06-29');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `contactos`
--

CREATE TABLE `contactos` (
  `id_contacto` int(11) NOT NULL,
  `id_motivo_contacto` int(11) NOT NULL,
  `pregunta` varchar(500) NOT NULL,
  `nombre` varchar(250) NOT NULL,
  `direccion` varchar(250) NOT NULL,
  `telefono` varchar(20) NOT NULL,
  `correo` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `contactos`
--

INSERT INTO `contactos` (`id_contacto`, `id_motivo_contacto`, `pregunta`, `nombre`, `direccion`, `telefono`, `correo`) VALUES
(1, 0, '', '', '', '', ''),
(2, 0, '', '', '', '', '');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cotizacion`
--

CREATE TABLE `cotizacion` (
  `id_cotizacion` int(11) NOT NULL,
  `id_tipo_cotizacion` int(11) NOT NULL,
  `nombre` varchar(250) NOT NULL,
  `direccion` varchar(250) NOT NULL,
  `telefono` varchar(20) NOT NULL,
  `correo` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `cotizacion`
--

INSERT INTO `cotizacion` (`id_cotizacion`, `id_tipo_cotizacion`, `nombre`, `direccion`, `telefono`, `correo`) VALUES
(1, 1, '', '', '', ''),
(2, 1, '', '', '', '');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `descuentos`
--

CREATE TABLE `descuentos` (
  `id_descuento` int(11) NOT NULL,
  `id_personal` int(11) NOT NULL,
  `id_clasificacion_descuento` int(11) NOT NULL,
  `descripcion` varchar(500) NOT NULL,
  `cantidad` float NOT NULL,
  `id_anio` int(11) NOT NULL,
  `id_quincena` int(11) NOT NULL,
  `id_usuario` int(11) NOT NULL,
  `fec_registro` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `descuentos`
--

INSERT INTO `descuentos` (`id_descuento`, `id_personal`, `id_clasificacion_descuento`, `descripcion`, `cantidad`, `id_anio`, `id_quincena`, `id_usuario`, `fec_registro`) VALUES
(1, 1, 2, 'asdfasdfasd', 56.99, 1, 17, 2, '2021-06-13'),
(2, 1, 1, 'prueba', 88.9, 2, 1, 2, '2021-06-13'),
(3, 1, 1, 'fefrfrfdr', 1000, 1, 19, 2, '2021-06-13');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `inventario`
--

CREATE TABLE `inventario` (
  `id_inventario` int(11) NOT NULL,
  `num_carrito` int(11) NOT NULL,
  `id_producto` int(11) NOT NULL,
  `num_inventario` int(11) NOT NULL,
  `total` double NOT NULL,
  `id_usuario` int(11) NOT NULL,
  `id_status` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `inventario`
--

INSERT INTO `inventario` (`id_inventario`, `num_carrito`, `id_producto`, `num_inventario`, `total`, `id_usuario`, `id_status`) VALUES
(36, 1, 1, 1, 350, 9, 1),
(37, 2, 1, 1, 350, 9, 2),
(38, 1, 2, 1, 120, 13, 3),
(40, 1, 1, 4, 350, 13, 3),
(41, 2, 1, 4, 700, 13, 2),
(44, 2, 7, 3, 75, 13, 2),
(45, 2, 6, 1, 2500, 13, 2),
(46, 2, 10, 2, 30, 13, 2),
(47, 3, 4, 2, 1440, 13, 2),
(48, 3, 3, 2, 500, 13, 2);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `nomina`
--

CREATE TABLE `nomina` (
  `id_nomina` int(11) NOT NULL,
  `id_anio` int(11) NOT NULL,
  `id_quincena` int(11) NOT NULL,
  `descripcion` varchar(500) NOT NULL,
  `id_status_nomina` int(11) NOT NULL,
  `id_usuario` int(11) NOT NULL,
  `fec_registro` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `nomina`
--

INSERT INTO `nomina` (`id_nomina`, `id_anio`, `id_quincena`, `descripcion`, `id_status_nomina`, `id_usuario`, `fec_registro`) VALUES
(1, 1, 1, 'Primera quincena del año', 1, 2, '2021-06-16');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `personal`
--

CREATE TABLE `personal` (
  `id_personal` int(11) NOT NULL,
  `num_empleado` varchar(50) NOT NULL,
  `nombre` varchar(200) NOT NULL,
  `app_paterno` varchar(200) NOT NULL,
  `app_materno` varchar(200) DEFAULT NULL,
  `correo` varchar(200) DEFAULT NULL,
  `fec_nac` date NOT NULL,
  `direccion` varchar(300) DEFAULT NULL,
  `titulo` varchar(250) DEFAULT NULL,
  `id_puesto` int(11) NOT NULL,
  `id_categoria` int(11) NOT NULL,
  `sueldo` float NOT NULL,
  `fec_ingreso` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `personal`
--

INSERT INTO `personal` (`id_personal`, `num_empleado`, `nombre`, `app_paterno`, `app_materno`, `correo`, `fec_nac`, `direccion`, `titulo`, `id_puesto`, `id_categoria`, `sueldo`, `fec_ingreso`) VALUES
(1, 'W21', 'wilebaldo', 'bernal', 'flores', 'willee@gmail.com', '2021-02-11', 'pajaritos', 'ING. SISTEMAS', 3, 2, 15000, '2021-06-17'),
(2, 'K96', 'Karla', 'Martinez', 'Becerra', 'karla@gmail.com', '1988-01-11', 'benito juarez #24', 'Ing. Sistemas', 2, 3, 20000, '2021-01-15');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `productos`
--

CREATE TABLE `productos` (
  `id_producto` int(11) NOT NULL,
  `descripcion` varchar(250) NOT NULL,
  `actual_inventario` int(11) NOT NULL,
  `total_inventario` int(11) NOT NULL,
  `precio` float(10,0) NOT NULL,
  `url_imagen` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `productos`
--

INSERT INTO `productos` (`id_producto`, `descripcion`, `actual_inventario`, `total_inventario`, `precio`, `url_imagen`) VALUES
(1, 'Arreglos florales', 0, 0, 350, 'articulo-01.jpeg'),
(2, 'Macetas para jardín', 0, 0, 120, 'articulo-02.jpeg'),
(3, 'Noche buena', 0, 0, 250, 'articulo-06.jpeg'),
(4, 'Orquídeas', 0, 0, 720, 'articulo-05.jpeg'),
(5, 'Cempasúchil', 0, 0, 140, 'articulo-04.jpeg'),
(6, 'Palma Washingtonia', 0, 0, 2500, 'articulo-03.jpeg'),
(7, 'Gerbera', 0, 0, 25, 'articulo-07.jpg'),
(8, 'Hortensia', 0, 0, 45, 'articulo-08.jpg'),
(9, 'Peonia', 0, 0, 20, 'articulo-09.jpg'),
(10, 'Clavel', 0, 0, 15, 'articulo-10.jpg'),
(11, 'Ave del paraiso', 0, 0, 100, 'articulo-11.jpg'),
(12, 'Crisantemo', 0, 0, 20, 'articulo-12.jpg'),
(13, 'Campana irlandesa', 0, 0, 15, 'articulo-13.jpg'),
(14, 'Jacinto', 0, 0, 35, 'articulo-14.jpg'),
(15, 'Corona de cristo', 0, 0, 250, 'articulo-15.jpg');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `proveedores`
--

CREATE TABLE `proveedores` (
  `id_proveedor` int(11) NOT NULL,
  `nombre` varchar(250) NOT NULL,
  `rfc` varchar(13) NOT NULL,
  `direccion` varchar(500) NOT NULL,
  `telefono` varchar(50) NOT NULL,
  `id_status` int(11) NOT NULL,
  `fec_registro` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `proveedores`
--

INSERT INTO `proveedores` (`id_proveedor`, `nombre`, `rfc`, `direccion`, `telefono`, `id_status`, `fec_registro`) VALUES
(1, 'Rosas Perez', 'JHF34239HZTSE', 'Monterrey', '833154684648', 1, '2021-06-29');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE `usuarios` (
  `id_usuario` int(11) NOT NULL,
  `usuario` varchar(100) NOT NULL,
  `contrasena` varchar(100) NOT NULL,
  `nombre` varchar(250) NOT NULL,
  `correo` varchar(250) NOT NULL,
  `id_tipo_usuario` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `usuarios`
--

INSERT INTO `usuarios` (`id_usuario`, `usuario`, `contrasena`, `nombre`, `correo`, `id_tipo_usuario`) VALUES
(2, 'user', '6zKNpq/So90=', 'Juan', 'user@hotmail.com', 1),
(9, 'user2', '6zKNpq/So90=', 'Usuario prueba', 'user2@gmail.com', 2),
(10, 'karla', '6zKNpq/So90=', 'Karla Martinez', 'karla@gmail.com', 2),
(11, 'usr', '6zKNpq/So90=', 'hhgfgfg', 'hgjhgjh', 2),
(12, 'usr2', 'aFX6P8Mqz60=', 'asdfasd', 'asdfasd', 2),
(13, 'cliente', '6zKNpq/So90=', 'kasjdflska', 'sddlfkjasdlfk', 2),
(14, 'Admin2', '6zKNpq/So90=', 'Jose Reyes', 'josereyes001@gmail.com', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ventas`
--

CREATE TABLE `ventas` (
  `id_venta` int(11) NOT NULL,
  `id_inventario` int(11) NOT NULL,
  `fec_registro` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ventas`
--

INSERT INTO `ventas` (`id_venta`, `id_inventario`, `fec_registro`) VALUES
(1, 36, '2021-07-08'),
(2, 37, '2021-07-08'),
(3, 44, '2021-08-04'),
(4, 45, '2021-08-04'),
(5, 46, '2021-08-04'),
(6, 47, '2021-08-04'),
(7, 48, '2021-08-04');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `cat_anio`
--
ALTER TABLE `cat_anio`
  ADD PRIMARY KEY (`id_anio`);

--
-- Indices de la tabla `cat_categorias`
--
ALTER TABLE `cat_categorias`
  ADD PRIMARY KEY (`id_categoria`);

--
-- Indices de la tabla `cat_clasificacion_descuento`
--
ALTER TABLE `cat_clasificacion_descuento`
  ADD PRIMARY KEY (`id_clasificacion_descuento`);

--
-- Indices de la tabla `cat_puestos`
--
ALTER TABLE `cat_puestos`
  ADD PRIMARY KEY (`id_puesto`);

--
-- Indices de la tabla `cat_quincena`
--
ALTER TABLE `cat_quincena`
  ADD PRIMARY KEY (`id_quincena`);

--
-- Indices de la tabla `cat_status`
--
ALTER TABLE `cat_status`
  ADD PRIMARY KEY (`id_status`);

--
-- Indices de la tabla `cat_status_nomina`
--
ALTER TABLE `cat_status_nomina`
  ADD PRIMARY KEY (`id_status_nomina`);

--
-- Indices de la tabla `cat_tipo_usuario`
--
ALTER TABLE `cat_tipo_usuario`
  ADD PRIMARY KEY (`id_tipo_usuario`);

--
-- Indices de la tabla `clientes`
--
ALTER TABLE `clientes`
  ADD PRIMARY KEY (`id_cliente`),
  ADD KEY `id_status` (`id_status`);

--
-- Indices de la tabla `contactos`
--
ALTER TABLE `contactos`
  ADD PRIMARY KEY (`id_contacto`);

--
-- Indices de la tabla `cotizacion`
--
ALTER TABLE `cotizacion`
  ADD PRIMARY KEY (`id_cotizacion`);

--
-- Indices de la tabla `descuentos`
--
ALTER TABLE `descuentos`
  ADD PRIMARY KEY (`id_descuento`),
  ADD KEY `id_anio` (`id_anio`),
  ADD KEY `id_quincena` (`id_quincena`),
  ADD KEY `id_personal` (`id_personal`),
  ADD KEY `id_usuario` (`id_usuario`),
  ADD KEY `id_clasificacion_descuento` (`id_clasificacion_descuento`);

--
-- Indices de la tabla `inventario`
--
ALTER TABLE `inventario`
  ADD PRIMARY KEY (`id_inventario`),
  ADD KEY `id_usuario` (`id_usuario`),
  ADD KEY `id_status` (`id_status`);

--
-- Indices de la tabla `nomina`
--
ALTER TABLE `nomina`
  ADD PRIMARY KEY (`id_nomina`),
  ADD KEY `id_usuario` (`id_usuario`),
  ADD KEY `id_anio` (`id_anio`),
  ADD KEY `id_quincena` (`id_quincena`),
  ADD KEY `id_status_nomina` (`id_status_nomina`);

--
-- Indices de la tabla `personal`
--
ALTER TABLE `personal`
  ADD PRIMARY KEY (`id_personal`);

--
-- Indices de la tabla `productos`
--
ALTER TABLE `productos`
  ADD PRIMARY KEY (`id_producto`);

--
-- Indices de la tabla `proveedores`
--
ALTER TABLE `proveedores`
  ADD PRIMARY KEY (`id_proveedor`),
  ADD KEY `id_status` (`id_status`);

--
-- Indices de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`id_usuario`),
  ADD KEY `id_tipo_usuario` (`id_tipo_usuario`);

--
-- Indices de la tabla `ventas`
--
ALTER TABLE `ventas`
  ADD PRIMARY KEY (`id_venta`),
  ADD KEY `id_inventario` (`id_inventario`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `cat_anio`
--
ALTER TABLE `cat_anio`
  MODIFY `id_anio` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `cat_categorias`
--
ALTER TABLE `cat_categorias`
  MODIFY `id_categoria` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `cat_clasificacion_descuento`
--
ALTER TABLE `cat_clasificacion_descuento`
  MODIFY `id_clasificacion_descuento` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `cat_puestos`
--
ALTER TABLE `cat_puestos`
  MODIFY `id_puesto` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `cat_quincena`
--
ALTER TABLE `cat_quincena`
  MODIFY `id_quincena` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;

--
-- AUTO_INCREMENT de la tabla `cat_status`
--
ALTER TABLE `cat_status`
  MODIFY `id_status` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `cat_status_nomina`
--
ALTER TABLE `cat_status_nomina`
  MODIFY `id_status_nomina` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `cat_tipo_usuario`
--
ALTER TABLE `cat_tipo_usuario`
  MODIFY `id_tipo_usuario` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `clientes`
--
ALTER TABLE `clientes`
  MODIFY `id_cliente` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `contactos`
--
ALTER TABLE `contactos`
  MODIFY `id_contacto` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `cotizacion`
--
ALTER TABLE `cotizacion`
  MODIFY `id_cotizacion` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `descuentos`
--
ALTER TABLE `descuentos`
  MODIFY `id_descuento` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `inventario`
--
ALTER TABLE `inventario`
  MODIFY `id_inventario` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=49;

--
-- AUTO_INCREMENT de la tabla `nomina`
--
ALTER TABLE `nomina`
  MODIFY `id_nomina` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `personal`
--
ALTER TABLE `personal`
  MODIFY `id_personal` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `productos`
--
ALTER TABLE `productos`
  MODIFY `id_producto` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT de la tabla `proveedores`
--
ALTER TABLE `proveedores`
  MODIFY `id_proveedor` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `id_usuario` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT de la tabla `ventas`
--
ALTER TABLE `ventas`
  MODIFY `id_venta` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `clientes`
--
ALTER TABLE `clientes`
  ADD CONSTRAINT `clientes_ibfk_1` FOREIGN KEY (`id_status`) REFERENCES `cat_status` (`id_status`);

--
-- Filtros para la tabla `descuentos`
--
ALTER TABLE `descuentos`
  ADD CONSTRAINT `descuentos_ibfk_1` FOREIGN KEY (`id_anio`) REFERENCES `cat_anio` (`id_anio`),
  ADD CONSTRAINT `descuentos_ibfk_2` FOREIGN KEY (`id_quincena`) REFERENCES `cat_quincena` (`id_quincena`),
  ADD CONSTRAINT `descuentos_ibfk_3` FOREIGN KEY (`id_personal`) REFERENCES `personal` (`id_personal`),
  ADD CONSTRAINT `descuentos_ibfk_4` FOREIGN KEY (`id_usuario`) REFERENCES `usuarios` (`id_usuario`),
  ADD CONSTRAINT `descuentos_ibfk_5` FOREIGN KEY (`id_clasificacion_descuento`) REFERENCES `cat_clasificacion_descuento` (`id_clasificacion_descuento`);

--
-- Filtros para la tabla `inventario`
--
ALTER TABLE `inventario`
  ADD CONSTRAINT `inventario_ibfk_1` FOREIGN KEY (`id_usuario`) REFERENCES `usuarios` (`id_usuario`),
  ADD CONSTRAINT `inventario_ibfk_2` FOREIGN KEY (`id_usuario`) REFERENCES `usuarios` (`id_usuario`),
  ADD CONSTRAINT `inventario_ibfk_3` FOREIGN KEY (`id_status`) REFERENCES `cat_status` (`id_status`);

--
-- Filtros para la tabla `nomina`
--
ALTER TABLE `nomina`
  ADD CONSTRAINT `nomina_ibfk_1` FOREIGN KEY (`id_usuario`) REFERENCES `usuarios` (`id_usuario`),
  ADD CONSTRAINT `nomina_ibfk_2` FOREIGN KEY (`id_anio`) REFERENCES `cat_anio` (`id_anio`),
  ADD CONSTRAINT `nomina_ibfk_3` FOREIGN KEY (`id_quincena`) REFERENCES `cat_quincena` (`id_quincena`),
  ADD CONSTRAINT `nomina_ibfk_4` FOREIGN KEY (`id_status_nomina`) REFERENCES `cat_status_nomina` (`id_status_nomina`);

--
-- Filtros para la tabla `proveedores`
--
ALTER TABLE `proveedores`
  ADD CONSTRAINT `proveedores_ibfk_1` FOREIGN KEY (`id_status`) REFERENCES `cat_status` (`id_status`);

--
-- Filtros para la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD CONSTRAINT `usuarios_ibfk_1` FOREIGN KEY (`id_tipo_usuario`) REFERENCES `cat_tipo_usuario` (`id_tipo_usuario`);

--
-- Filtros para la tabla `ventas`
--
ALTER TABLE `ventas`
  ADD CONSTRAINT `ventas_ibfk_1` FOREIGN KEY (`id_inventario`) REFERENCES `inventario` (`id_inventario`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
