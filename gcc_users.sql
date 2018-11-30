-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 30, 2018 at 04:45 PM
-- Server version: 10.1.37-MariaDB
-- PHP Version: 7.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `gcc_users`
--

-- --------------------------------------------------------

--
-- Table structure for table `inventory`
--

CREATE TABLE `inventory` (
  `ID` int(11) NOT NULL,
  `Name` text NOT NULL,
  `Quantity` int(11) NOT NULL,
  `Description` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `inventory`
--

INSERT INTO `inventory` (`ID`, `Name`, `Quantity`, `Description`) VALUES
(1001, 'Football', 50, 'Footballs used for football matches and practice'),
(1002, 'Bat', 47, 'Bats used for cricket games and practice'),
(1003, 'Netball', 25, 'Netballs used for matches and training'),
(1004, 'Cricket Ball', 15, 'Cricket Balls Used for matches and practice '),
(1005, 'Helmet', 100, 'Helmets used for cricket matches and practice'),
(1006, 'Boots', 35, 'Football boots for athletes');

-- --------------------------------------------------------

--
-- Table structure for table `members`
--

CREATE TABLE `members` (
  `fname` text NOT NULL,
  `lname` text NOT NULL,
  `ID` int(11) NOT NULL,
  `Sport` text NOT NULL,
  `password` text NOT NULL,
  `email` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `members`
--

INSERT INTO `members` (`fname`, `lname`, `ID`, `Sport`, `password`, `email`) VALUES
('Shawn', 'Michael', 620112266, 'Football', 'test', 'smichael@gmail.com'),
('Shakeane', 'Hinds', 620112282, 'FootBall', 'test', 'test@gmail.com'),
('Yanick', 'Lynn-Fat', 620113322, 'Football', 'test', 'Ylf@gmail.com'),
('Al', 'Jordan', 620114158, 'Football', 'test', 'Aj@gmail.com'),
('Alex', 'Marshall', 620114455, 'FootBall', 'test12', 'alex@gmail.com'),
('Maria', 'Jones', 620114458, 'Netball', 'test', 'mjones@gmail.com'),
('Alkaline', 'Bartley', 620114477, 'Football', 'test', 'Alkadon@gmail.com'),
('Marcus', 'Cousins', 620116641, 'Football', 'test', 'MCous@gmail.com'),
('Mathew', 'Jones', 620118855, 'Cricket', 'test', 'matt@gmail.com'),
('James', 'Rashford', 620121325, 'Football', 'test', 'Jrashford@gmail.com'),
('Jason', 'Taylor', 620122362, 'Football', 'test', 'jtaylor@gmail.com'),
('Britanny ', 'Goslin', 620442221, 'Netball', 'test', 'britg@gmail.com'),
('Britanny ', 'Goslin', 620442225, 'Netball', 'test', 'britg@gmail.com'),
('Britanny ', 'Goslin', 620442227, 'Netball', 'test', 'britg@gmail.com'),
('Allison', 'Hines', 621554432, 'Netball', 'test', 'Ahines@gmail.com'),
('john', 'james', 630114425, 'Cricket', 'test', 'jjames@gmail.com');

-- --------------------------------------------------------

--
-- Table structure for table `schedule`
--

CREATE TABLE `schedule` (
  `ID` int(11) NOT NULL,
  `Sport` text NOT NULL,
  `monday` text NOT NULL,
  `tuesday` text NOT NULL,
  `wednesday` text NOT NULL,
  `thursday` text NOT NULL,
  `friday` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `schedule`
--

INSERT INTO `schedule` (`ID`, `Sport`, `monday`, `tuesday`, `wednesday`, `thursday`, `friday`) VALUES
(620114455, 'Football', 'Off', 'Train', 'Train', 'Train', 'Train'),
(620122362, 'Cricket', 'Train', 'Train', 'Off', 'Train', 'Off');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `inventory`
--
ALTER TABLE `inventory`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `members`
--
ALTER TABLE `members`
  ADD PRIMARY KEY (`ID`) USING BTREE;

--
-- Indexes for table `schedule`
--
ALTER TABLE `schedule`
  ADD PRIMARY KEY (`ID`) USING BTREE;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `schedule`
--
ALTER TABLE `schedule`
  ADD CONSTRAINT `schedule_ibfk_1` FOREIGN KEY (`ID`) REFERENCES `members` (`ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
