-- phpMyAdmin SQL Dump
-- version 5.0.3
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1
-- Время создания: Ноя 11 2020 г., 14:04
-- Версия сервера: 10.4.14-MariaDB
-- Версия PHP: 7.4.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `goods`
--

-- --------------------------------------------------------

--
-- Структура таблицы `goods_main`
--

CREATE TABLE `goods_main` (
  `id` int(11) NOT NULL,
  `name` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `goods_main`
--

INSERT INTO `goods_main` (`id`, `name`) VALUES
(1, 'Фрутоняня'),
(2, 'Вискас для котят'),
(3, 'Агуша'),
(5, 'Хот-дог \"Горячая собака\"'),
(6, 'Шавуха'),
(7, 'Художественный фильм \"Стырили\"'),
(8, 'Игра \"Локалхост\"'),
(59, 'Мороженое \"ГУЛАГ\"'),
(60, 'Ржавый жигуль');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `goods_main`
--
ALTER TABLE `goods_main`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `goods_main`
--
ALTER TABLE `goods_main`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=64;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
