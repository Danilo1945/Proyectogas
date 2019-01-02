-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 03-01-2019 a las 00:34:30
-- Versión del servidor: 10.1.37-MariaDB
-- Versión de PHP: 7.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `distrigas`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `calificacion_distribuidor`
--

CREATE TABLE `calificacion_distribuidor` (
  `id` int(20) NOT NULL,
  `valor` int(2) DEFAULT NULL,
  `fecha` date DEFAULT NULL,
  `hora` time DEFAULT NULL,
  `distribuidor_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `calificacion_usuario`
--

CREATE TABLE `calificacion_usuario` (
  `id` int(20) NOT NULL,
  `valor` int(2) DEFAULT NULL,
  `fecha` date DEFAULT NULL,
  `hora` time DEFAULT NULL,
  `usuario_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `casa`
--

CREATE TABLE `casa` (
  `id` int(11) NOT NULL,
  `direccion` varchar(200) DEFAULT NULL,
  `latitud` float DEFAULT NULL,
  `longitud` float DEFAULT NULL,
  `telefono` varchar(15) DEFAULT NULL,
  `usuario_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cilindro_gas`
--

CREATE TABLE `cilindro_gas` (
  `id` int(11) NOT NULL,
  `color` varchar(10) DEFAULT NULL,
  `detalle` varchar(50) DEFAULT NULL,
  `direccion_ip` varchar(20) DEFAULT NULL,
  `casa_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `distribuidor`
--

CREATE TABLE `distribuidor` (
  `id` int(11) NOT NULL,
  `cedula` varchar(11) DEFAULT NULL,
  `nombres` varchar(40) DEFAULT NULL,
  `apellidos` varchar(30) DEFAULT NULL,
  `celular` varchar(30) DEFAULT NULL,
  `direccion` varchar(200) DEFAULT NULL,
  `created` datetime DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `latitud` float DEFAULT NULL,
  `longitud` float DEFAULT NULL,
  `enable` varchar(6) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `password` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `distribuidor`
--

INSERT INTO `distribuidor` (`id`, `cedula`, `nombres`, `apellidos`, `celular`, `direccion`, `created`, `modified`, `latitud`, `longitud`, `enable`, `email`, `password`) VALUES
(1, '0503950131', 'Liliana', 'Tapia', '0998787675', 'Alaquez', '2018-12-25 00:11:31', '2018-12-25 00:11:31', 676474, 748748000, 'true', 'liliana.tapia1@utc.edu.ec', '0503950131');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `pedidos`
--

CREATE TABLE `pedidos` (
  `id` int(11) NOT NULL,
  `fecha` date DEFAULT NULL,
  `hora` time DEFAULT NULL,
  `estado` varchar(6) DEFAULT NULL,
  `calificacion_usuario` varchar(6) DEFAULT NULL,
  `calificacion_distribuidor` varchar(6) DEFAULT NULL,
  `usuario_id` int(11) DEFAULT NULL,
  `distribuidor_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `pedidos_generales`
--

CREATE TABLE `pedidos_generales` (
  `id` int(11) NOT NULL,
  `fecha` date DEFAULT NULL,
  `hora` time DEFAULT NULL,
  `estado` varchar(6) DEFAULT NULL,
  `usuario_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `phinxlog`
--

CREATE TABLE `phinxlog` (
  `version` bigint(20) NOT NULL,
  `migration_name` varchar(100) DEFAULT NULL,
  `start_time` timestamp NULL DEFAULT NULL,
  `end_time` timestamp NULL DEFAULT NULL,
  `breakpoint` tinyint(1) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `phinxlog`
--

INSERT INTO `phinxlog` (`version`, `migration_name`, `start_time`, `end_time`, `breakpoint`) VALUES
(20181225000235, 'Initial', '2018-12-25 05:02:35', '2018-12-25 05:02:35', 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuario`
--

CREATE TABLE `usuario` (
  `id` int(11) NOT NULL,
  `cedula` varchar(11) DEFAULT NULL,
  `nombres` varchar(40) DEFAULT NULL,
  `apellidos` varchar(30) DEFAULT NULL,
  `celular` varchar(30) DEFAULT NULL,
  `direccion` varchar(200) DEFAULT NULL,
  `created` datetime DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `latitud` float DEFAULT NULL,
  `longitud` float DEFAULT NULL,
  `enable` varchar(6) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `password` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `usuario`
--

INSERT INTO `usuario` (`id`, `cedula`, `nombres`, `apellidos`, `celular`, `direccion`, `created`, `modified`, `latitud`, `longitud`, `enable`, `email`, `password`) VALUES
(1, '0550114748', 'Danilo', 'Moya', '0997672064', 'San Felipe, calle 10 de agosto y el salvador', '2018-12-25 00:08:06', '2018-12-25 00:08:06', 704344, -7989380, 'true', 'danilomoya19@ymail.com', '0550114748'),
(2, '0503950131', 'Liliana', 'Tapia', '0998787678', 'alaquez', NULL, NULL, 799999, 799999, 'true', 'liliana.tapia1@hotmail.com', '12345');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `calificacion_distribuidor`
--
ALTER TABLE `calificacion_distribuidor`
  ADD PRIMARY KEY (`id`),
  ADD KEY `distribuidor_id` (`distribuidor_id`);

--
-- Indices de la tabla `calificacion_usuario`
--
ALTER TABLE `calificacion_usuario`
  ADD PRIMARY KEY (`id`),
  ADD KEY `usuario_id` (`usuario_id`);

--
-- Indices de la tabla `casa`
--
ALTER TABLE `casa`
  ADD PRIMARY KEY (`id`),
  ADD KEY `usuario_id` (`usuario_id`);

--
-- Indices de la tabla `cilindro_gas`
--
ALTER TABLE `cilindro_gas`
  ADD PRIMARY KEY (`id`),
  ADD KEY `casa_id` (`casa_id`);

--
-- Indices de la tabla `distribuidor`
--
ALTER TABLE `distribuidor`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `pedidos`
--
ALTER TABLE `pedidos`
  ADD PRIMARY KEY (`id`),
  ADD KEY `usuario_id` (`usuario_id`),
  ADD KEY `distribuidor_id` (`distribuidor_id`);

--
-- Indices de la tabla `pedidos_generales`
--
ALTER TABLE `pedidos_generales`
  ADD PRIMARY KEY (`id`),
  ADD KEY `usuario_id` (`usuario_id`);

--
-- Indices de la tabla `phinxlog`
--
ALTER TABLE `phinxlog`
  ADD PRIMARY KEY (`version`);

--
-- Indices de la tabla `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `calificacion_distribuidor`
--
ALTER TABLE `calificacion_distribuidor`
  MODIFY `id` int(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `calificacion_usuario`
--
ALTER TABLE `calificacion_usuario`
  MODIFY `id` int(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `casa`
--
ALTER TABLE `casa`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `cilindro_gas`
--
ALTER TABLE `cilindro_gas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `distribuidor`
--
ALTER TABLE `distribuidor`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `pedidos`
--
ALTER TABLE `pedidos`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `pedidos_generales`
--
ALTER TABLE `pedidos_generales`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `usuario`
--
ALTER TABLE `usuario`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `calificacion_distribuidor`
--
ALTER TABLE `calificacion_distribuidor`
  ADD CONSTRAINT `calificacion_distribuidor_ibfk_1` FOREIGN KEY (`distribuidor_id`) REFERENCES `distribuidor` (`id`) ON DELETE CASCADE;

--
-- Filtros para la tabla `calificacion_usuario`
--
ALTER TABLE `calificacion_usuario`
  ADD CONSTRAINT `calificacion_usuario_ibfk_1` FOREIGN KEY (`usuario_id`) REFERENCES `usuario` (`id`) ON DELETE CASCADE;

--
-- Filtros para la tabla `casa`
--
ALTER TABLE `casa`
  ADD CONSTRAINT `casa_ibfk_1` FOREIGN KEY (`usuario_id`) REFERENCES `usuario` (`id`) ON DELETE CASCADE;

--
-- Filtros para la tabla `cilindro_gas`
--
ALTER TABLE `cilindro_gas`
  ADD CONSTRAINT `cilindro_gas_ibfk_1` FOREIGN KEY (`casa_id`) REFERENCES `casa` (`id`) ON DELETE CASCADE;

--
-- Filtros para la tabla `pedidos`
--
ALTER TABLE `pedidos`
  ADD CONSTRAINT `pedidos_ibfk_1` FOREIGN KEY (`usuario_id`) REFERENCES `usuario` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `pedidos_ibfk_2` FOREIGN KEY (`distribuidor_id`) REFERENCES `distribuidor` (`id`) ON DELETE CASCADE;

--
-- Filtros para la tabla `pedidos_generales`
--
ALTER TABLE `pedidos_generales`
  ADD CONSTRAINT `pedidos_generales_ibfk_1` FOREIGN KEY (`usuario_id`) REFERENCES `usuario` (`id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
