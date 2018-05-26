-- phpMyAdmin SQL Dump
-- version 3.2.4
-- http://www.phpmyadmin.net
--
-- Servidor: localhost
-- Tiempo de generación: 26-05-2018 a las 18:03:39
-- Versión del servidor: 5.1.41
-- Versión de PHP: 5.3.1

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Base de datos: `bcp_go`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `comentarios`
--

CREATE TABLE IF NOT EXISTS `comentarios` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_establecimiento` int(11) NOT NULL,
  `id_comentario` int(11) NOT NULL,
  `id_user` int(11) NOT NULL,
  `puntuacion` int(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=2 ;

--
-- Volcar la base de datos para la tabla `comentarios`
--

INSERT INTO `comentarios` (`id`, `id_establecimiento`, `id_comentario`, `id_user`, `puntuacion`) VALUES
(1, 100, 1, 1, 4);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `establecimientos`
--

CREATE TABLE IF NOT EXISTS `establecimientos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(30) NOT NULL,
  `latitud` float NOT NULL,
  `longitud` float NOT NULL,
  `puntuacion_prom` float NOT NULL,
  `horario` varchar(20) NOT NULL,
  `operaciones_validas` int(11) NOT NULL,
  `tiempo_estimado` int(11) NOT NULL,
  `estado` int(11) NOT NULL,
  `cantidad_disponibles` int(11) NOT NULL,
  `id_historial` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=102 ;

--
-- Volcar la base de datos para la tabla `establecimientos`
--

INSERT INTO `establecimientos` (`id`, `name`, `latitud`, `longitud`, `puntuacion_prom`, `horario`, `operaciones_validas`, `tiempo_estimado`, `estado`, `cantidad_disponibles`, `id_historial`) VALUES
(100, 'TiaVeneno', 0, 0, 3.4, 'j-v', 3, 5, 1, 2, 2),
(101, '', 0, 0, 3, 'm-v', 2, 3, 1, 3, 2);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `historial`
--

CREATE TABLE IF NOT EXISTS `historial` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `tiempo_promedio` float NOT NULL,
  `puntuacion_promedio` float NOT NULL,
  `time` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=3 ;

--
-- Volcar la base de datos para la tabla `historial`
--

INSERT INTO `historial` (`id`, `tiempo_promedio`, `puntuacion_promedio`, `time`) VALUES
(2, 3.4, 4.3, '2018-05-26 16:55:34');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `user`
--

CREATE TABLE IF NOT EXISTS `user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(20) NOT NULL,
  `password` varchar(20) NOT NULL,
  `puntos_bonus` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=2 ;

--
-- Volcar la base de datos para la tabla `user`
--

INSERT INTO `user` (`id`, `username`, `password`, `puntos_bonus`) VALUES
(1, 'holi_boli', '123', 5);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
