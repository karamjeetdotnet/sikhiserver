DROP DATABASE IF EXISTS `gurbanidb`;

CREATE DATABASE `gurbanidb` character set UTF8mb4 collate utf8mb4_bin;
USE `gurbanidb`;
-- MySQL dump 10.13  Distrib 5.6.23, for Win64 (x86_64)
--
-- Host: localhost    Database: gurbanidb
-- ------------------------------------------------------
-- Server version	5.6.23

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `bani_index`
--

DROP TABLE IF EXISTS `bani_index`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `bani_index` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `locale_id` bigint(20) NOT NULL,
  `file_source_id` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `bani_index_locale_locale_id_id_idx` (`locale_id`),
  KEY `bani_index_file_source_file_source_id_id_idx` (`file_source_id`),
  CONSTRAINT `bani_index_file_source_file_source_id_id` FOREIGN KEY (`file_source_id`) REFERENCES `file_source` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `bani_index_locale_locale_id_id` FOREIGN KEY (`locale_id`) REFERENCES `locale` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `bani_index_range`
--

DROP TABLE IF EXISTS `bani_index_range`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `bani_index_range` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `bani_index_id` bigint(20) NOT NULL,
  `start` varchar(45) NOT NULL,
  `end` varchar(45) NOT NULL,
  `file_source_id` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `bani_index_range_bani_index_index_id_id_idx` (`bani_index_id`),
  KEY `bani_index_range_file_source_file_source_id_id_idx` (`file_source_id`),
  CONSTRAINT `bani_index_range_bani_index_bani_index_id_id` FOREIGN KEY (`bani_index_id`) REFERENCES `bani_index` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `bani_index_range_file_source_file_source_id_id` FOREIGN KEY (`file_source_id`) REFERENCES `file_source` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `bani_text`
--

DROP TABLE IF EXISTS `bani_text`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `bani_text` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `gurbani_db_id` varchar(45) DEFAULT NULL,
  `sttm_id` bigint(20) DEFAULT NULL,
  `writer_id` bigint(20) NOT NULL,
  `section_source_id` bigint(20) DEFAULT NULL,
  `subsection_source_id` bigint(20) DEFAULT NULL,
  `file_source_id` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `writer_bani_text_id_writer_id_idx` (`writer_id`),
  KEY `source_index_range_bani_text_id_subsection_source_id_idx` (`subsection_source_id`),
  KEY `bani_text_file_source_file_source_id_id_idx` (`file_source_id`),
  KEY `bani_text_source_index_range_section_source_id_id_idx` (`section_source_id`),
  CONSTRAINT `bani_text_file_source_file_source_id_id` FOREIGN KEY (`file_source_id`) REFERENCES `file_source` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `bani_text_source_index_range_section_source_id_id` FOREIGN KEY (`section_source_id`) REFERENCES `source_index_range` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `bani_text_writer_writer_id_id` FOREIGN KEY (`writer_id`) REFERENCES `writer` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `source_index_range_bani_text_id_subsection_source_id` FOREIGN KEY (`subsection_source_id`) REFERENCES `source_index_range` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `bani_text_line`
--

DROP TABLE IF EXISTS `bani_text_line`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `bani_text_line` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `gurbani_db_id` varchar(45) DEFAULT NULL,
  `bani_text_id` bigint(20) DEFAULT NULL,
  `source_page` bigint(20) DEFAULT NULL,
  `source_line` bigint(20) DEFAULT NULL,
  `gurmukhi` longtext,
  `pronunciation` longtext,
  `pronunciation_information` longtext,
  `translation` longtext,
  `file_source_id` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `bani_text_line_bani_text_bani_text_id_id_idx` (`bani_text_id`),
  KEY `bani_text_line_file_source_file_source_id_id_idx` (`file_source_id`),
  CONSTRAINT `bani_text_line_bani_text_bani_text_id_id` FOREIGN KEY (`bani_text_id`) REFERENCES `bani_text` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `bani_text_line_file_source_file_source_id_id` FOREIGN KEY (`file_source_id`) REFERENCES `file_source` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `db_system_info`
--

DROP TABLE IF EXISTS `db_system_info`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `db_system_info` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `datetime` datetime NOT NULL,
  `information` longtext,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `file_source`
--

DROP TABLE IF EXISTS `file_source`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `file_source` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `file_name` varchar(45) DEFAULT NULL,
  `source` varchar(45) DEFAULT NULL,
  `content` longtext,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `languages`
--

DROP TABLE IF EXISTS `languages`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `languages` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `locale_id` bigint(20) NOT NULL,
  `file_source_id` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `languages_locale_locale_id_id_idx` (`locale_id`),
  KEY `languages_file_source_file_source_id_id_idx` (`file_source_id`),
  CONSTRAINT `languages_file_source_file_source_id_id` FOREIGN KEY (`file_source_id`) REFERENCES `file_source` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `languages_locale_locale_id_id` FOREIGN KEY (`locale_id`) REFERENCES `locale` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `locale`
--

DROP TABLE IF EXISTS `locale`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `locale` (
  `id` bigint(12) NOT NULL AUTO_INCREMENT,
  `gurmukhi` longtext NOT NULL,
  `english` longtext,
  `internatinal` longtext,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `source_index`
--

DROP TABLE IF EXISTS `source_index`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `source_index` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `locale_id` bigint(20) NOT NULL,
  `length` int(11) DEFAULT NULL,
  `english_page_name` varchar(255) DEFAULT NULL,
  `gurmukhi_page_name` varchar(255) DEFAULT NULL,
  `file_source_id` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `source_index_file_source_file_source_id_id_idx` (`file_source_id`),
  KEY `source_index_locale_locale_id_id_idx` (`locale_id`),
  CONSTRAINT `source_index_file_source_file_source_id_id` FOREIGN KEY (`file_source_id`) REFERENCES `file_source` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `source_index_locale_locale_id_id` FOREIGN KEY (`locale_id`) REFERENCES `locale` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `source_index_range`
--

DROP TABLE IF EXISTS `source_index_range`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `source_index_range` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `source_index_id` bigint(20) NOT NULL,
  `start_page` bigint(20) DEFAULT NULL,
  `end_page` bigint(20) DEFAULT NULL,
  `locale_id` bigint(20) NOT NULL,
  `description` longtext,
  `source_index_range_id` bigint(20) DEFAULT NULL,
  `file_source_id` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `source_index_id_source_index_id_idx` (`source_index_id`),
  KEY `source_index_locale_id_locale_id_idx` (`locale_id`),
  KEY `source_index_range_source_index_range_id_id_idx` (`source_index_range_id`),
  KEY `source_index_range_file_source_file_source_id_id_idx` (`file_source_id`),
  CONSTRAINT `source_index_id_source_index_id` FOREIGN KEY (`source_index_id`) REFERENCES `source_index` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `source_index_locale_id_locale_id` FOREIGN KEY (`locale_id`) REFERENCES `locale` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `source_index_range_file_source_file_source_id_id` FOREIGN KEY (`file_source_id`) REFERENCES `file_source` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `source_index_range_source_index_range_id_id` FOREIGN KEY (`source_index_range_id`) REFERENCES `source_index_range` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `translation_source`
--

DROP TABLE IF EXISTS `translation_source`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `translation_source` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `locale_id` bigint(20) NOT NULL,
  `source_index_id` bigint(20) DEFAULT NULL,
  `language` varchar(45) NOT NULL,
  `file_source_id` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `translation_source_source_index_source_id_id_idx` (`source_index_id`),
  KEY `translation_source_file_source_file_source_id_id_idx` (`file_source_id`),
  KEY `translation_source_locale_locale_id_id_idx` (`locale_id`),
  CONSTRAINT `translation_source_file_source_file_source_id_id` FOREIGN KEY (`file_source_id`) REFERENCES `file_source` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `translation_source_locale_locale_id_id` FOREIGN KEY (`locale_id`) REFERENCES `locale` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `translation_source_source_index_source_id_id` FOREIGN KEY (`source_index_id`) REFERENCES `source_index` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `writer`
--

DROP TABLE IF EXISTS `writer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `writer` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `locale_id` bigint(20) NOT NULL,
  `file_source_id` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `writer_locale_locale_id_id_idx` (`locale_id`),
  KEY `writer_file_source_file_source_id_id_idx` (`file_source_id`),
  CONSTRAINT `writer_file_source_file_source_id_id` FOREIGN KEY (`file_source_id`) REFERENCES `file_source` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `writer_locale_locale_id_id` FOREIGN KEY (`locale_id`) REFERENCES `locale` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping events for database 'gurbanidb'
--

--
-- Dumping routines for database 'gurbanidb'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-11-30 21:18:00
