-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 18, 2023 at 02:47 PM
-- Server version: 10.4.27-MariaDB
-- PHP Version: 8.2.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `examination`
--

-- --------------------------------------------------------

--
-- Table structure for table `administrator`
--

CREATE TABLE `administrator` (
  `ID` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `lastname` varchar(255) NOT NULL,
  `firstname` varchar(255) NOT NULL,
  `middlename` varchar(255) DEFAULT NULL,
  `username` varchar(255) NOT NULL,
  `numberofsubject` int(3) NOT NULL,
  `password` varchar(255) NOT NULL,
  `key_code` varchar(8) NOT NULL,
  `permission` varchar(255) NOT NULL,
  `date` varchar(10) NOT NULL,
  `Subject1` varchar(999) NOT NULL,
  `Subject2` varchar(999) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `administrator`
--

INSERT INTO `administrator` (`ID`, `name`, `lastname`, `firstname`, `middlename`, `username`, `numberofsubject`, `password`, `key_code`, `permission`, `date`, `Subject1`, `Subject2`) VALUES
(1, 'asdas', 'dasdas', 'asdasd', '', 'administrator', 0, 'administrator', 'd2f8f6db', 'Administrator', '02/18/2023', '', ''),
(2, 'sadas, asd das', 'sadas', 'asd', 'das', 'professor', 1, 'professor', '5b54b86d', 'Professor', '02/18/2023', 'Calculus I', ''),
(3, 'asdasd, asdasdarer ', 'asdasd', 'asdasdarer', '', 'Proctor', 0, 'Proctor', 'fd9e09a2', 'Proctor', '02/18/2023', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `administrator_log`
--

CREATE TABLE `administrator_log` (
  `name` varchar(200) NOT NULL,
  `username` varchar(200) NOT NULL,
  `Time` varchar(200) NOT NULL,
  `Remarks` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `administrator_log`
--

INSERT INTO `administrator_log` (`name`, `username`, `Time`, `Remarks`) VALUES
('asdas', 'administrator', '2/18/2023 6:58:56 PM', 'Entered to Admin Account Form'),
('asdas', 'administrator', '2/18/2023 6:59:37 PM', 'Inserted an admin account: Proctor'),
('asdas', 'administrator', '2/18/2023 6:59:41 PM', 'Entered to Subject List Form'),
('asdas', 'administrator', '2/18/2023 6:59:52 PM', 'Entered to Admin Account Form'),
('asdas', 'administrator', '2/18/2023 6:59:55 PM', 'Modified an admin account: professor'),
('asdas', 'administrator', '2/18/2023 6:59:57 PM', 'Entered to Main Menu Form'),
('asdas', 'administrator', '2/18/2023 6:59:59 PM', 'Entered to Semester Subject Form'),
('asdas', 'administrator', '2/18/2023 7:00:06 PM', 'Creating list of subjects per semester: CPE, 3, 1st Semester'),
('asdas', 'administrator', '2/18/2023 7:00:10 PM', 'Finish creating CPE, 3, 1st Semester'),
('asdas', 'administrator', '2/18/2023 7:00:12 PM', 'Updating the list of subjects per semester.'),
('asdas', 'administrator', '2/18/2023 7:00:23 PM', 'Entered to Main Menu Form'),
('asdas', 'administrator', '2/18/2023 7:00:24 PM', 'Entered to Student Account Form'),
('asdas', 'administrator', '2/18/2023 7:01:24 PM', 'Log-In'),
('asdas', 'administrator', '2/18/2023 7:01:26 PM', 'Entered to Semester Subject Form'),
('asdas', 'administrator', '2/18/2023 7:01:29 PM', 'Entered to Main Menu Form'),
('asdas', 'administrator', '2/18/2023 7:01:29 PM', 'Entered to Student Account Form'),
('asdas', 'administrator', '2/18/2023 7:03:01 PM', 'Log-In'),
('asdas', 'administrator', '2/18/2023 7:03:02 PM', 'Entered to Semester Subject Form'),
('asdas', 'administrator', '2/18/2023 7:03:05 PM', 'Entered to Main Menu Form'),
('asdas', 'administrator', '2/18/2023 7:03:05 PM', 'Entered to Student Account Form'),
('asdas', 'administrator', '2/18/2023 7:05:47 PM', 'Log-In'),
('asdas', 'administrator', '2/18/2023 7:05:49 PM', 'Entered to Student Account Form'),
('asdas', 'administrator', '2/18/2023 7:13:30 PM', 'Log-In'),
('asdas', 'administrator', '2/18/2023 7:13:32 PM', 'Entered to Student Account Form'),
('asdas', 'administrator', '2/18/2023 7:14:02 PM', 'Inserted a student account: administrator'),
('asdas', 'administrator', '2/18/2023 7:15:29 PM', 'Inserted a student account: student'),
('asdas', 'administrator', '2/18/2023 7:15:32 PM', 'Entered to Main Menu Form'),
('asdas', 'administrator', '2/18/2023 7:15:35 PM', 'Log-Out'),
('sadas, asd das', 'professor', '2/18/2023 7:15:41 PM', 'Log-In'),
('sadas, asd das', 'professor', '2/18/2023 7:15:49 PM', 'Entered to Questions Form'),
('sadas, asd das', 'professor', '2/18/2023 7:15:59 PM', 'Creating an examination: Prelim Examination of Calculus I.'),
('sadas, asd das', 'professor', '2/18/2023 7:16:04 PM', 'Creating an examination: Prelim Examination of Calculus I.'),
('sadas, asd das', 'professor', '2/18/2023 7:17:04 PM', 'Creating an examination: Prelim Examination of Calculus I.'),
('sadas, asd das', 'professor', '2/18/2023 7:18:37 PM', 'Creating an examination: Prelim Examination of Calculus I.'),
('sadas, asd das', 'professor', '2/18/2023 7:22:02 PM', 'Log-In'),
('sadas, asd das', 'professor', '2/18/2023 7:22:05 PM', 'Entered to Questions Form'),
('sadas, asd das', 'professor', '2/18/2023 7:22:13 PM', 'Creating an examination: Prelim Examination of Calculus I.'),
('sadas, asd das', 'professor', '2/18/2023 7:29:32 PM', 'Creating an examination: Prelim Examination of Calculus I.'),
('sadas, asd das', 'professor', '2/18/2023 7:29:36 PM', 'Creating an examination: Prelim Examination of Calculus I.'),
('sadas, asd das', 'professor', '2/18/2023 7:29:56 PM', 'Log-In'),
('sadas, asd das', 'professor', '2/18/2023 7:29:58 PM', 'Entered to Questions Form'),
('sadas, asd das', 'professor', '2/18/2023 7:30:04 PM', 'Creating an examination: Prelim Examination of Calculus I.'),
('sadas, asd das', 'professor', '2/18/2023 7:30:46 PM', 'Log-In'),
('sadas, asd das', 'professor', '2/18/2023 7:30:48 PM', 'Entered to Questions Form'),
('sadas, asd das', 'professor', '2/18/2023 7:30:52 PM', 'Creating an examination: Prelim Examination of Calculus I.'),
('sadas, asd das', 'professor', '2/18/2023 7:33:17 PM', 'Log-In'),
('sadas, asd das', 'professor', '2/18/2023 7:37:30 PM', 'Entered to Questions Form'),
('sadas, asd das', 'professor', '2/18/2023 7:38:51 PM', 'Log-In'),
('sadas, asd das', 'professor', '2/18/2023 7:38:55 PM', 'Entered to Student Account Form'),
('sadas, asd das', 'professor', '2/18/2023 7:38:58 PM', 'Entered to Main Menu Form'),
('sadas, asd das', 'professor', '2/18/2023 7:39:00 PM', 'Entered to Check Form'),
('sadas, asd das', 'professor', '2/18/2023 7:39:10 PM', 'Entered to Main Menu Form'),
('sadas, asd das', 'professor', '2/18/2023 7:39:11 PM', 'Entered to Chart Form'),
('sadas, asd das', 'professor', '2/18/2023 7:39:15 PM', 'Entered to Main Menu Form'),
('sadas, asd das', 'professor', '2/18/2023 7:39:15 PM', 'Entered to Questions Form'),
('sadas, asd das', 'professor', '2/18/2023 7:39:35 PM', 'Deleting an examination: Prelim Examination of Calculus I.'),
('sadas, asd das', 'professor', '2/18/2023 7:39:37 PM', 'Creating an examination: Prelim Examination of Calculus I.'),
('sadas, asd das', 'professor', '2/18/2023 7:40:22 PM', 'Creating an examination: Prelim Examination of Calculus I.'),
('sadas, asd das', 'professor', '2/18/2023 7:40:25 PM', 'Creating an examination: Prelim Examination of Calculus I.'),
('sadas, asd das', 'professor', '2/18/2023 7:44:11 PM', 'Log-In'),
('sadas, asd das', 'professor', '2/18/2023 7:44:13 PM', 'Entered to Questions Form'),
('sadas, asd das', 'professor', '2/18/2023 7:44:17 PM', 'Deleting an examination: Prelim Examination of Calculus I.'),
('sadas, asd das', 'professor', '2/18/2023 7:44:18 PM', 'Creating an examination: Prelim Examination of Calculus I.'),
('sadas, asd das', 'professor', '2/18/2023 7:48:06 PM', 'Log-In'),
('sadas, asd das', 'professor', '2/18/2023 7:48:08 PM', 'Entered to Questions Form'),
('sadas, asd das', 'professor', '2/18/2023 7:48:13 PM', 'Deleting an examination: Prelim Examination of Calculus I.'),
('sadas, asd das', 'professor', '2/18/2023 7:48:14 PM', 'Creating an examination: Prelim Examination of Calculus I.'),
('sadas, asd das', 'professor', '2/18/2023 7:48:52 PM', 'Editing an examination: Prelim Examination of Calculus I.'),
('sadas, asd das', 'professor', '2/18/2023 7:49:19 PM', 'Log-In'),
('sadas, asd das', 'professor', '2/18/2023 7:49:21 PM', 'Entered to Questions Form'),
('sadas, asd das', 'professor', '2/18/2023 7:49:28 PM', 'Deleting an examination: Prelim Examination of Calculus I.'),
('sadas, asd das', 'professor', '2/18/2023 7:49:30 PM', 'Creating an examination: Prelim Examination of Calculus I.'),
('sadas, asd das', 'professor', '2/18/2023 7:53:18 PM', 'Log-In'),
('sadas, asd das', 'professor', '2/18/2023 7:53:20 PM', 'Entered to Questions Form'),
('sadas, asd das', 'professor', '2/18/2023 7:53:26 PM', 'Deleting an examination: Prelim Examination of Calculus I.'),
('sadas, asd das', 'professor', '2/18/2023 7:53:27 PM', 'Creating an examination: Prelim Examination of Calculus I.'),
('sadas, asd das', 'professor', '2/18/2023 7:53:56 PM', 'Creating an examination: Prelim Examination of Calculus I.'),
('sadas, asd das', 'professor', '2/18/2023 7:54:05 PM', 'Creating an examination: Prelim Examination of Calculus I.'),
('sadas, asd das', 'professor', '2/18/2023 7:54:19 PM', 'Creating an examination: Prelim Examination of Calculus I.'),
('sadas, asd das', 'professor', '2/18/2023 7:54:38 PM', 'Log-In'),
('sadas, asd das', 'professor', '2/18/2023 7:54:40 PM', 'Entered to Questions Form'),
('sadas, asd das', 'professor', '2/18/2023 7:57:01 PM', 'Creating an examination: Prelim Examination of Calculus I.'),
('sadas, asd das', 'professor', '2/18/2023 7:57:16 PM', 'Finish creating an examination: Prelim Examination of Calculus I.'),
('sadas, asd das', 'professor', '2/18/2023 7:57:28 PM', 'Editing an examination: Prelim Examination of Calculus I.'),
('sadas, asd das', 'professor', '2/18/2023 7:57:40 PM', 'Finish overwriting an examination: Prelim Examination of Calculus I.'),
('sadas, asd das', 'professor', '2/18/2023 7:57:47 PM', 'Exported a Word File: Prelim_CalculusI_2020-2021.docx'),
('sadas, asd das', 'professor', '2/18/2023 7:57:59 PM', 'Entered to Main Menu Form'),
('sadas, asd das', 'professor', '2/18/2023 7:58:02 PM', 'Entered to Chart Form'),
('sadas, asd das', 'professor', '2/18/2023 7:58:07 PM', 'Entered to Main Menu Form'),
('sadas, asd das', 'professor', '2/18/2023 7:58:13 PM', 'Exit Application'),
('asdasd, asdasdarer ', 'proctor', '2/18/2023 7:58:34 PM', 'Log-In'),
('asdasd, asdasdarer ', 'proctor', '2/18/2023 7:58:37 PM', 'Entered to Student Account Form'),
('asdasd, asdasdarer ', 'proctor', '2/18/2023 7:58:39 PM', 'Entered to Main Menu Form'),
('asdasd, asdasdarer ', 'proctor', '2/18/2023 7:58:40 PM', 'Entered to Student Account Form'),
('asdasd, asdasdarer ', 'proctor', '2/18/2023 7:58:42 PM', 'Entered to Main Menu Form'),
('asdasd, asdasdarer ', 'proctor', '2/18/2023 7:58:44 PM', 'Change keycode.'),
('asdasd, asdasdarer ', 'proctor', '2/18/2023 7:58:47 PM', 'Exit Application'),
('sadas, asd das', 'professor', '2/18/2023 8:56:27 PM', 'Log-In'),
('sadas, asd das', 'professor', '2/18/2023 8:56:30 PM', 'Entered to Check Form'),
('sadas, asd das', 'professor', '2/18/2023 8:57:25 PM', 'Entered to Main Menu Form'),
('sadas, asd das', 'professor', '2/18/2023 8:57:26 PM', 'Entered to Check Form'),
('sadas, asd das', 'professor', '2/18/2023 8:57:31 PM', 'Entered to Main Menu Form'),
('sadas, asd das', 'professor', '2/18/2023 8:57:32 PM', 'Entered to Questions Form'),
('sadas, asd das', 'professor', '2/18/2023 8:57:40 PM', 'Entered to Main Menu Form'),
('sadas, asd das', 'professor', '2/18/2023 8:57:41 PM', 'Entered to Chart Form'),
('sadas, asd das', 'professor', '2/18/2023 8:58:15 PM', 'Entered to Main Menu Form'),
('sadas, asd das', 'professor', '2/18/2023 8:58:19 PM', 'Log-Out'),
('asdas', 'administrator', '2/18/2023 8:58:23 PM', 'Log-In'),
('asdas', 'administrator', '2/18/2023 8:58:39 PM', 'Inserted an admin account: prof'),
('asdas', 'administrator', '2/18/2023 8:58:42 PM', 'Entered to Main Menu Form'),
('asdas', 'administrator', '2/18/2023 8:58:46 PM', 'Log-Out'),
('sadas, asd das', 'professor', '2/18/2023 9:01:38 PM', 'Log-In'),
('sadas, asd das', 'professor', '2/18/2023 9:01:40 PM', 'Entered to Check Form'),
('sadas, asd das', 'professor', '2/18/2023 9:01:56 PM', 'Exit Application'),
('sadas, asd das', 'professor', '2/18/2023 9:02:36 PM', 'Log-In'),
('sadas, asd das', 'professor', '2/18/2023 9:02:38 PM', 'Entered to Check Form'),
('sadas, asd das', 'professor', '2/18/2023 9:02:40 PM', 'Checking the answer of lastname, firstname middlename.\nPrelim Examination of Calculus I'),
('sadas, asd das', 'professor', '2/18/2023 9:10:41 PM', 'Entered to Main Menu Form'),
('sadas, asd das', 'professor', '2/18/2023 9:10:44 PM', 'Exit Application'),
('sadas, asd das', 'professor', '2/18/2023 9:14:26 PM', 'Log-In'),
('sadas, asd das', 'professor', '2/18/2023 9:14:27 PM', 'Entered to Check Form'),
('sadas, asd das', 'professor', '2/18/2023 9:14:30 PM', 'Checking the answer of lastname, firstname middlename.\nPrelim Examination of Calculus I'),
('sadas, asd das', 'professor', '2/18/2023 9:16:43 PM', 'Log-In'),
('sadas, asd das', 'professor', '2/18/2023 9:16:45 PM', 'Entered to Check Form'),
('sadas, asd das', 'professor', '2/18/2023 9:16:48 PM', 'Checking the answer of lastname, firstname middlename.\nPrelim Examination of Calculus I'),
('sadas, asd das', 'professor', '2/18/2023 9:16:50 PM', 'Exit Application'),
('sadas, asd das', 'professor', '2/18/2023 9:30:15 PM', 'Log-In'),
('sadas, asd das', 'professor', '2/18/2023 9:30:16 PM', 'Entered to Chart Form'),
('sadas, asd das', 'professor', '2/18/2023 9:30:34 PM', 'Entered to Main Menu Form'),
('sadas, asd das', 'professor', '2/18/2023 9:30:35 PM', 'Entered to Check Form'),
('sadas, asd das', 'professor', '2/18/2023 9:30:37 PM', 'Checking the answer of lastname, firstname middlename.\nPrelim Examination of Calculus I'),
('sadas, asd das', 'professor', '2/18/2023 9:30:40 PM', 'Entered to Main Menu Form'),
('sadas, asd das', 'professor', '2/18/2023 9:30:40 PM', 'Entered to Student Account Form'),
('sadas, asd das', 'professor', '2/18/2023 9:30:47 PM', 'Entered to Main Menu Form'),
('sadas, asd das', 'professor', '2/18/2023 9:30:50 PM', 'Exit Application');

-- --------------------------------------------------------

--
-- Table structure for table `prelim_calculusi_2020-2021`
--

CREATE TABLE `prelim_calculusi_2020-2021` (
  `ID` int(11) NOT NULL,
  `Number` int(11) DEFAULT NULL,
  `LastNumber` int(11) DEFAULT NULL,
  `Questions` text NOT NULL,
  `A` text NOT NULL,
  `B` text NOT NULL,
  `C` text NOT NULL,
  `D` text NOT NULL,
  `EnumerationA` text NOT NULL,
  `EnumerationB` text NOT NULL,
  `EnumerationC` text NOT NULL,
  `EnumerationD` text NOT NULL,
  `EnumerationE` text NOT NULL,
  `FixEnumeration` varchar(3) NOT NULL,
  `Answer` text DEFAULT NULL,
  `Points` int(11) NOT NULL,
  `TotalItems` int(11) NOT NULL,
  `PassingScore` int(11) NOT NULL,
  `QuestionType` varchar(255) NOT NULL,
  `ItemType` varchar(255) NOT NULL,
  `PreparedBy` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `prelim_calculusi_2020-2021`
--

INSERT INTO `prelim_calculusi_2020-2021` (`ID`, `Number`, `LastNumber`, `Questions`, `A`, `B`, `C`, `D`, `EnumerationA`, `EnumerationB`, `EnumerationC`, `EnumerationD`, `EnumerationE`, `FixEnumeration`, `Answer`, `Points`, `TotalItems`, `PassingScore`, `QuestionType`, `ItemType`, `PreparedBy`) VALUES
(1, 1, 1, 'sdsds', '', '', '', '', '', '', '', '', '', '', 'True', 1, 1, 1, 'True/Identify', 'Single Score', 'sadas, asd das');

-- --------------------------------------------------------

--
-- Table structure for table `result_prelim_calculusi_2020-2021`
--

CREATE TABLE `result_prelim_calculusi_2020-2021` (
  `name` varchar(255) NOT NULL,
  `gender` varchar(6) NOT NULL,
  `course` varchar(255) NOT NULL,
  `year` int(11) NOT NULL,
  `section` varchar(1) NOT NULL,
  `proctorby` varchar(255) NOT NULL,
  `score` int(11) NOT NULL,
  `professor` varchar(255) NOT NULL,
  `username` varchar(255) NOT NULL,
  `Q1` int(3) NOT NULL,
  `AnswerQ1` longtext NOT NULL,
  `Done` varchar(3) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `result_prelim_calculusi_2020-2021`
--

INSERT INTO `result_prelim_calculusi_2020-2021` (`name`, `gender`, `course`, `year`, `section`, `proctorby`, `score`, `professor`, `username`, `Q1`, `AnswerQ1`, `Done`) VALUES
('lastname, firstname middlename', 'Male', 'CPE', 3, 'A', 'sadas, asd das', 1, 'sadas, asd das', 'student', 1, 'True', 'Yes');

-- --------------------------------------------------------

--
-- Table structure for table `schedule_prelim_2020-2021`
--

CREATE TABLE `schedule_prelim_2020-2021` (
  `subject` varchar(99) NOT NULL,
  `date` varchar(99) NOT NULL,
  `time` varchar(99) NOT NULL,
  `endtime` varchar(99) NOT NULL,
  `completetime` varchar(99) NOT NULL,
  `completeendtime` varchar(99) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `schedule_prelim_2020-2021`
--

INSERT INTO `schedule_prelim_2020-2021` (`subject`, `date`, `time`, `endtime`, `completetime`, `completeendtime`) VALUES
('Calculus I', '02/18/2023', '07:57 PM', '11:57 PM', '07:57 PM 02/18/2023', '9:00 PM 02/18/2023');

-- --------------------------------------------------------

--
-- Table structure for table `semester_subjects`
--

CREATE TABLE `semester_subjects` (
  `Course` longtext NOT NULL,
  `Year` longtext NOT NULL,
  `Semester` longtext NOT NULL,
  `Subject` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `semester_subjects`
--

INSERT INTO `semester_subjects` (`Course`, `Year`, `Semester`, `Subject`) VALUES
('CPE', '3', '1st', 'Calculus I'),
('CPE', '3', '1st', 'Calculus II');

-- --------------------------------------------------------

--
-- Table structure for table `student_info`
--

CREATE TABLE `student_info` (
  `studentnumber` varchar(255) NOT NULL,
  `lastname` varchar(255) NOT NULL,
  `firstname` varchar(255) DEFAULT NULL,
  `middlename` varchar(255) NOT NULL,
  `name` varchar(255) NOT NULL,
  `Gender` varchar(6) NOT NULL,
  `Course` varchar(10) NOT NULL,
  `Year` int(1) NOT NULL,
  `Section` varchar(1) NOT NULL,
  `Semester` varchar(3) NOT NULL,
  `Username` varchar(255) NOT NULL,
  `Password` varchar(255) NOT NULL,
  `schoolyearstart` int(4) NOT NULL,
  `schoolyearend` int(4) NOT NULL,
  `status` varchar(9) NOT NULL,
  `numberofsubject` int(3) NOT NULL,
  `Subject1` varchar(99) NOT NULL,
  `Subject2` varchar(99) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `student_info`
--

INSERT INTO `student_info` (`studentnumber`, `lastname`, `firstname`, `middlename`, `name`, `Gender`, `Course`, `Year`, `Section`, `Semester`, `Username`, `Password`, `schoolyearstart`, `schoolyearend`, `status`, `numberofsubject`, `Subject1`, `Subject2`) VALUES
('878-86654-8654', 'lastname', 'firstname', 'middlename', 'lastname, firstname middlename', 'Male', 'CPE', 3, 'A', '1st', 'student', 'student', 2020, 2021, 'Regular', 2, 'Calculus I', 'Calculus II');

-- --------------------------------------------------------

--
-- Table structure for table `student_log`
--

CREATE TABLE `student_log` (
  `name` varchar(200) NOT NULL,
  `username` varchar(200) NOT NULL,
  `Time` varchar(200) NOT NULL,
  `Remarks` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `student_log`
--

INSERT INTO `student_log` (`name`, `username`, `Time`, `Remarks`) VALUES
('lastname, firstname middlename', 'student', '2/18/2023 8:12:41 PM', 'Log-In'),
('lastname, firstname middlename', 'student', '2/18/2023 8:12:44 PM', 'Entered Report Form'),
('lastname, firstname middlename', 'student', '2/18/2023 8:12:48 PM', 'Entered Main Menu Form'),
('lastname, firstname middlename', 'student', '2/18/2023 8:12:50 PM', 'Entered Report Form'),
('lastname, firstname middlename', 'student', '2/18/2023 8:12:55 PM', 'Entered Main Menu Form'),
('lastname, firstname middlename', 'student', '2/18/2023 8:12:55 PM', 'Entered Take Exam Form'),
('lastname, firstname middlename', 'student', '2/18/2023 8:13:00 PM', 'Taking Examination: Prelim Examination of Calculus I, 2020-2021'),
('lastname, firstname middlename', 'student', '2/18/2023 8:13:21 PM', 'Correct Code.'),
('lastname, firstname middlename', 'student', '2/18/2023 8:13:51 PM', 'Log-In'),
('lastname, firstname middlename', 'student', '2/18/2023 8:13:52 PM', 'Entered Take Exam Form'),
('lastname, firstname middlename', 'student', '2/18/2023 8:13:55 PM', 'Taking Examination: Prelim Examination of Calculus I, 2020-2021'),
('lastname, firstname middlename', 'student', '2/18/2023 8:13:58 PM', 'Correct Code.'),
('lastname, firstname middlename', 'student', '2/18/2023 8:14:28 PM', 'Trying to exit the application.'),
('lastname, firstname middlename', 'student', '2/18/2023 8:14:29 PM', 'Trying to exit the application.'),
('lastname, firstname middlename', 'student', '2/18/2023 8:15:58 PM', 'Log-In'),
('lastname, firstname middlename', 'student', '2/18/2023 8:15:59 PM', 'Entered Take Exam Form'),
('lastname, firstname middlename', 'student', '2/18/2023 8:16:03 PM', 'Taking Examination: Prelim Examination of Calculus I, 2020-2021'),
('lastname, firstname middlename', 'student', '2/18/2023 8:16:06 PM', 'Correct Code.'),
('lastname, firstname middlename', 'student', '2/18/2023 8:26:50 PM', 'Log-In'),
('lastname, firstname middlename', 'student', '2/18/2023 8:26:52 PM', 'Entered Take Exam Form'),
('lastname, firstname middlename', 'student', '2/18/2023 8:26:54 PM', 'Taking Examination: Prelim Examination of Calculus I, 2020-2021'),
('lastname, firstname middlename', 'student', '2/18/2023 8:26:57 PM', 'Correct Code.'),
('lastname, firstname middlename', 'student', '2/18/2023 8:28:02 PM', 'Log-In'),
('lastname, firstname middlename', 'student', '2/18/2023 8:28:04 PM', 'Entered Take Exam Form'),
('lastname, firstname middlename', 'student', '2/18/2023 8:28:08 PM', 'Taking Examination: Prelim Examination of Calculus I, 2020-2021'),
('lastname, firstname middlename', 'student', '2/18/2023 8:28:11 PM', 'Correct Code.'),
('lastname, firstname middlename', 'student', '2/18/2023 8:28:14 PM', 'Trying to exit the application.'),
('lastname, firstname middlename', 'student', '2/18/2023 8:36:30 PM', 'Log-In'),
('lastname, firstname middlename', 'student', '2/18/2023 8:36:31 PM', 'Entered Take Exam Form'),
('lastname, firstname middlename', 'student', '2/18/2023 8:36:34 PM', 'Taking Examination: Prelim Examination of Calculus I, 2020-2021'),
('lastname, firstname middlename', 'student', '2/18/2023 8:36:44 PM', 'Correct Code.'),
('lastname, firstname middlename', 'student', '2/18/2023 8:39:10 PM', 'Log-In'),
('lastname, firstname middlename', 'student', '2/18/2023 8:39:11 PM', 'Entered Take Exam Form'),
('lastname, firstname middlename', 'student', '2/18/2023 8:39:13 PM', 'Taking Examination: Prelim Examination of Calculus I, 2020-2021'),
('lastname, firstname middlename', 'student', '2/18/2023 8:39:21 PM', 'Correct Code.'),
('lastname, firstname middlename', 'student', '2/18/2023 8:40:05 PM', 'Log-In'),
('lastname, firstname middlename', 'student', '2/18/2023 8:40:06 PM', 'Entered Take Exam Form'),
('lastname, firstname middlename', 'student', '2/18/2023 8:40:08 PM', 'Taking Examination: Prelim Examination of Calculus I, 2020-2021'),
('lastname, firstname middlename', 'student', '2/18/2023 8:40:10 PM', 'Correct Code.'),
('lastname, firstname middlename', 'student', '2/18/2023 8:48:52 PM', 'Log-In'),
('lastname, firstname middlename', 'student', '2/18/2023 8:48:54 PM', 'Entered Take Exam Form'),
('lastname, firstname middlename', 'student', '2/18/2023 8:48:56 PM', 'Taking Examination: Prelim Examination of Calculus I, 2020-2021'),
('lastname, firstname middlename', 'student', '2/18/2023 8:49:10 PM', 'Correct Code.'),
('lastname, firstname middlename', 'student', '2/18/2023 8:50:23 PM', 'Log-In'),
('lastname, firstname middlename', 'student', '2/18/2023 8:50:25 PM', 'Entered Take Exam Form'),
('lastname, firstname middlename', 'student', '2/18/2023 8:50:27 PM', 'Taking Examination: Prelim Examination of Calculus I, 2020-2021'),
('lastname, firstname middlename', 'student', '2/18/2023 8:50:37 PM', 'Correct Code.'),
('lastname, firstname middlename', 'student', '2/18/2023 8:50:42 PM', 'Finish taking the Prelim Examination of Calculus I, 2020-2021.'),
('lastname, firstname middlename', 'student', '2/18/2023 8:50:45 PM', 'Entered Schedule Form'),
('lastname, firstname middlename', 'student', '2/18/2023 8:50:48 PM', 'Entered Main Menu Form'),
('lastname, firstname middlename', 'student', '2/18/2023 8:50:49 PM', 'Entered Student Info Form'),
('lastname, firstname middlename', 'student', '2/18/2023 8:50:54 PM', 'Modified Student Information'),
('lastname, firstname middlename', 'student', '2/18/2023 8:50:55 PM', 'Entered Main Menu Form'),
('lastname, firstname middlename', 'student', '2/18/2023 8:50:56 PM', 'Entered Report Form'),
('lastname, firstname middlename', 'student', '2/18/2023 8:50:58 PM', 'Entered Main Menu Form'),
('lastname, firstname middlename', 'student', '2/18/2023 8:55:16 PM', 'Entered Take Exam Form'),
('lastname, firstname middlename', 'student', '2/18/2023 8:55:19 PM', 'Entered Main Menu Form'),
('lastname, firstname middlename', 'student', '2/18/2023 8:55:20 PM', 'Entered Student Info Form'),
('lastname, firstname middlename', 'student', '2/18/2023 8:55:23 PM', 'Entered Main Menu Form'),
('lastname, firstname middlename', 'student', '2/18/2023 8:55:23 PM', 'Entered Report Form'),
('lastname, firstname middlename', 'student', '2/18/2023 8:55:27 PM', 'Entered Main Menu Form'),
('lastname, firstname middlename', 'student', '2/18/2023 8:55:35 PM', 'Log-Out'),
('lastname, firstname middlename', 'student', '2/18/2023 8:59:13 PM', 'Log-In'),
('lastname, firstname middlename', 'student', '2/18/2023 8:59:15 PM', 'Entered Take Exam Form'),
('lastname, firstname middlename', 'student', '2/18/2023 9:00:45 PM', 'Taking Examination: Prelim Examination of Calculus I, 2020-2021'),
('lastname, firstname middlename', 'student', '2/18/2023 9:00:54 PM', 'Correct Code.'),
('lastname, firstname middlename', 'student', '2/18/2023 9:01:09 PM', 'Finish taking the Prelim Examination of Calculus I, 2020-2021.'),
('lastname, firstname middlename', 'student', '2/18/2023 9:01:10 PM', 'Entered Schedule Form'),
('lastname, firstname middlename', 'student', '2/18/2023 9:01:12 PM', 'Entered Main Menu Form'),
('lastname, firstname middlename', 'student', '2/18/2023 9:01:14 PM', 'Exit Application'),
('lastname, firstname middlename', 'student', '2/18/2023 9:02:07 PM', 'Log-In'),
('lastname, firstname middlename', 'student', '2/18/2023 9:02:08 PM', 'Entered Take Exam Form'),
('lastname, firstname middlename', 'student', '2/18/2023 9:02:11 PM', 'Taking Examination: Prelim Examination of Calculus I, 2020-2021'),
('lastname, firstname middlename', 'student', '2/18/2023 9:02:13 PM', 'Correct Code.'),
('lastname, firstname middlename', 'student', '2/18/2023 9:02:21 PM', 'Finish taking the Prelim Examination of Calculus I, 2020-2021.'),
('lastname, firstname middlename', 'student', '2/18/2023 9:02:22 PM', 'Entered Schedule Form'),
('lastname, firstname middlename', 'student', '2/18/2023 9:02:24 PM', 'Exit Application'),
('lastname, firstname middlename', 'student', '2/18/2023 9:03:19 PM', 'Log-In'),
('lastname, firstname middlename', 'student', '2/18/2023 9:03:20 PM', 'Entered Take Exam Form'),
('lastname, firstname middlename', 'student', '2/18/2023 9:03:23 PM', 'Taking Examination: Prelim Examination of Calculus I, 2020-2021'),
('lastname, firstname middlename', 'student', '2/18/2023 9:03:25 PM', 'Correct Code.'),
('lastname, firstname middlename', 'student', '2/18/2023 9:03:28 PM', 'Finish taking the Prelim Examination of Calculus I, 2020-2021.'),
('lastname, firstname middlename', 'student', '2/18/2023 9:03:29 PM', 'Entered Schedule Form'),
('lastname, firstname middlename', 'student', '2/18/2023 9:10:57 PM', 'Log-In'),
('lastname, firstname middlename', 'student', '2/18/2023 9:10:58 PM', 'Entered Student Info Form'),
('lastname, firstname middlename', 'student', '2/18/2023 9:11:03 PM', 'Entered Main Menu Form'),
('lastname, firstname middlename', 'student', '2/18/2023 9:11:03 PM', 'Entered Take Exam Form'),
('lastname, firstname middlename', 'student', '2/18/2023 9:11:05 PM', 'Taking Examination: Prelim Examination of Calculus I, 2020-2021'),
('lastname, firstname middlename', 'student', '2/18/2023 9:11:45 PM', 'Correct Code.'),
('lastname, firstname middlename', 'student', '2/18/2023 9:11:56 PM', 'Finish taking the Prelim Examination of Calculus I, 2020-2021.'),
('lastname, firstname middlename', 'student', '2/18/2023 9:11:58 PM', 'Entered Schedule Form'),
('lastname, firstname middlename', 'student', '2/18/2023 9:17:16 PM', 'Log-In'),
('lastname, firstname middlename', 'student', '2/18/2023 9:17:18 PM', 'Entered Take Exam Form'),
('lastname, firstname middlename', 'student', '2/18/2023 9:17:20 PM', 'Taking Examination: Prelim Examination of Calculus I, 2020-2021'),
('lastname, firstname middlename', 'student', '2/18/2023 9:17:39 PM', 'Correct Code.'),
('lastname, firstname middlename', 'student', '2/18/2023 9:17:45 PM', 'Finish taking the Prelim Examination of Calculus I, 2020-2021.'),
('lastname, firstname middlename', 'student', '2/18/2023 9:17:46 PM', 'Entered Schedule Form'),
('lastname, firstname middlename', 'student', '2/18/2023 9:21:24 PM', 'Log-In'),
('lastname, firstname middlename', 'student', '2/18/2023 9:21:25 PM', 'Entered Take Exam Form'),
('lastname, firstname middlename', 'student', '2/18/2023 9:21:28 PM', 'Taking Examination: Prelim Examination of Calculus I, 2020-2021'),
('lastname, firstname middlename', 'student', '2/18/2023 9:21:35 PM', 'Correct Code.'),
('lastname, firstname middlename', 'student', '2/18/2023 9:21:39 PM', 'Finish taking the Prelim Examination of Calculus I, 2020-2021.'),
('lastname, firstname middlename', 'student', '2/18/2023 9:21:39 PM', 'Entered Schedule Form'),
('lastname, firstname middlename', 'student', '2/18/2023 9:22:02 PM', 'Taking Examination: Prelim Examination of Calculus I, 2020-2021'),
('lastname, firstname middlename', 'student', '2/18/2023 9:22:04 PM', 'Correct Code.'),
('lastname, firstname middlename', 'student', '2/18/2023 9:22:06 PM', 'Finish taking the Prelim Examination of Calculus I, 2020-2021.'),
('lastname, firstname middlename', 'student', '2/18/2023 9:22:07 PM', 'Reviewing the answers of the Prelim Examination of Calculus I, 2020-2021.'),
('lastname, firstname middlename', 'student', '2/18/2023 9:22:09 PM', 'Finish taking the Prelim Examination of Calculus I, 2020-2021.'),
('lastname, firstname middlename', 'student', '2/18/2023 9:22:16 PM', 'Entered Schedule Form'),
('lastname, firstname middlename', 'student', '2/18/2023 9:25:59 PM', 'Log-In'),
('lastname, firstname middlename', 'student', '2/18/2023 9:26:01 PM', 'Entered Take Exam Form'),
('lastname, firstname middlename', 'student', '2/18/2023 9:26:03 PM', 'Taking Examination: Prelim Examination of Calculus I, 2020-2021'),
('lastname, firstname middlename', 'student', '2/18/2023 9:26:15 PM', 'Correct Code.'),
('lastname, firstname middlename', 'student', '2/18/2023 9:26:17 PM', 'Finish taking the Prelim Examination of Calculus I, 2020-2021.'),
('lastname, firstname middlename', 'student', '2/18/2023 9:26:19 PM', 'Entered Schedule Form'),
('lastname, firstname middlename', 'student', '2/18/2023 9:27:06 PM', 'Log-In'),
('lastname, firstname middlename', 'student', '2/18/2023 9:27:07 PM', 'Entered Report Form'),
('lastname, firstname middlename', 'student', '2/18/2023 9:27:12 PM', 'Entered Main Menu Form'),
('lastname, firstname middlename', 'student', '2/18/2023 9:27:23 PM', 'Entered Take Exam Form'),
('lastname, firstname middlename', 'student', '2/18/2023 9:27:25 PM', 'Taking Examination: Prelim Examination of Calculus I, 2020-2021'),
('lastname, firstname middlename', 'student', '2/18/2023 9:27:27 PM', 'Correct Code.'),
('lastname, firstname middlename', 'student', '2/18/2023 9:27:30 PM', 'Finish taking the Prelim Examination of Calculus I, 2020-2021.'),
('lastname, firstname middlename', 'student', '2/18/2023 9:27:31 PM', 'Entered Schedule Form'),
('lastname, firstname middlename', 'student', '2/18/2023 9:29:47 PM', 'Entered Main Menu Form'),
('lastname, firstname middlename', 'student', '2/18/2023 9:29:47 PM', 'Entered Report Form'),
('lastname, firstname middlename', 'student', '2/18/2023 9:29:52 PM', 'Entered Main Menu Form'),
('lastname, firstname middlename', 'student', '2/18/2023 9:29:55 PM', 'Log-Out');

-- --------------------------------------------------------

--
-- Table structure for table `subject`
--

CREATE TABLE `subject` (
  `id` int(11) NOT NULL,
  `Subject` varchar(255) NOT NULL,
  `subject_code` varchar(255) NOT NULL,
  `units` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `subject`
--

INSERT INTO `subject` (`id`, `Subject`, `subject_code`, `units`) VALUES
(1, 'Calculus I', 'Code123', 3),
(2, 'Calculus II', 'Calc2', 3);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `administrator`
--
ALTER TABLE `administrator`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `prelim_calculusi_2020-2021`
--
ALTER TABLE `prelim_calculusi_2020-2021`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `result_prelim_calculusi_2020-2021`
--
ALTER TABLE `result_prelim_calculusi_2020-2021`
  ADD PRIMARY KEY (`username`);

--
-- Indexes for table `subject`
--
ALTER TABLE `subject`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `subject`
--
ALTER TABLE `subject`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
