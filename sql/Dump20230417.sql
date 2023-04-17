CREATE DATABASE  IF NOT EXISTS `journeysick_db` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `journeysick_db`;
-- MySQL dump 10.13  Distrib 8.0.27, for Win64 (x86_64)
--
-- Host: localhost    Database: journeysick_db
-- ------------------------------------------------------
-- Server version	8.0.27

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `tblitem`
--

DROP TABLE IF EXISTS `tblitem`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tblitem` (
  `fldItemId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `fldItemName` mediumtext,
  `fldItemDescription` mediumtext,
  `fldItemUsage` longtext,
  `fldItemCategory` varchar(50) DEFAULT NULL,
  `fldPriceMax` decimal(10,2) DEFAULT NULL,
  `fldPriceMin` decimal(10,2) DEFAULT NULL,
  `fldCreateDate` datetime DEFAULT NULL,
  `fldCreateBy` varchar(50) DEFAULT NULL,
  `fldUpdateDate` datetime DEFAULT NULL,
  `fldUpdateBy` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`fldItemId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblitem`
--

LOCK TABLES `tblitem` WRITE;
/*!40000 ALTER TABLE `tblitem` DISABLE KEYS */;
/*!40000 ALTER TABLE `tblitem` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblitemcategory`
--

DROP TABLE IF EXISTS `tblitemcategory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tblitemcategory` (
  `fldCategoryId` varchar(50) NOT NULL,
  `fldCategoryName` varchar(50) DEFAULT NULL,
  `fldCategoryDescription` tinytext,
  `fldCreateDate` datetime DEFAULT NULL,
  `fldCreateBy` varchar(50) DEFAULT NULL,
  `fldUpdateDate` datetime DEFAULT NULL,
  `fldUpdateBy` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`fldCategoryId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblitemcategory`
--

LOCK TABLES `tblitemcategory` WRITE;
/*!40000 ALTER TABLE `tblitemcategory` DISABLE KEYS */;
/*!40000 ALTER TABLE `tblitemcategory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblplanlocation`
--

DROP TABLE IF EXISTS `tblplanlocation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tblplanlocation` (
  `fldPlanId` int NOT NULL AUTO_INCREMENT,
  `fldOrdinal` int DEFAULT NULL,
  `fldPlanLocationId` varchar(50) DEFAULT NULL,
  `fldPlanLocationName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `fldPlanLocationDescription` text,
  `fldLocationArrivalTime` datetime DEFAULT NULL,
  `fldCreateDate` datetime DEFAULT NULL,
  `fldCreateBy` varchar(50) DEFAULT NULL,
  `fldUpdateDate` datetime DEFAULT NULL,
  `fldUpdateBy` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`fldPlanId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblplanlocation`
--

LOCK TABLES `tblplanlocation` WRITE;
/*!40000 ALTER TABLE `tblplanlocation` DISABLE KEYS */;
/*!40000 ALTER TABLE `tblplanlocation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbltrip`
--

DROP TABLE IF EXISTS `tbltrip`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbltrip` (
  `fldTripId` varchar(50) NOT NULL,
  `fldTripName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `fldTripBudget` decimal(15,2) DEFAULT NULL,
  `fldTripDescription` longtext,
  `fldEstimateStartTime` datetime DEFAULT NULL,
  `fldEstimateArrivalTime` datetime DEFAULT NULL,
  `fldTripStatus` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `fldTripMember` int DEFAULT NULL,
  `fldTripPresenter` varchar(50) NOT NULL,
  PRIMARY KEY (`fldTripId`),
  UNIQUE KEY `fldTripId_UNIQUE` (`fldTripId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbltrip`
--

LOCK TABLES `tbltrip` WRITE;
/*!40000 ALTER TABLE `tbltrip` DISABLE KEYS */;
INSERT INTO `tbltrip` VALUES ('TRIP_00000001','test123',120000000.00,'ád','2023-04-09 00:00:00','2023-04-10 00:00:00','ACTIVE',213,'USER_00000000');
/*!40000 ALTER TABLE `tbltrip` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbltripdetail`
--

DROP TABLE IF EXISTS `tbltripdetail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbltripdetail` (
  `fldTripId` varchar(50) NOT NULL,
  `fldTripStartLocationName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `fldTripStartLocationAddress` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `fldTripDestinationLocationName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `fldTripDestinationLocationAddress` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `fldCreateDate` datetime DEFAULT NULL,
  `fldCreateBy` varchar(50) DEFAULT NULL,
  `fldUpdateDate` datetime DEFAULT NULL,
  `fldUpdateBy` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`fldTripId`),
  UNIQUE KEY `fldTripId_UNIQUE` (`fldTripId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbltripdetail`
--

LOCK TABLES `tbltripdetail` WRITE;
/*!40000 ALTER TABLE `tbltripdetail` DISABLE KEYS */;
INSERT INTO `tbltripdetail` VALUES ('TRIP_00000001','123','k482 h11/18 Trưng Nữ Vương','123','address3','2023-04-09 01:05:53','Admin','2023-04-13 23:11:28','Admin');
/*!40000 ALTER TABLE `tbltripdetail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbltripitem`
--

DROP TABLE IF EXISTS `tbltripitem`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbltripitem` (
  `fldItemId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `fldTripId` varchar(50) NOT NULL,
  `fldItemName` varchar(150) DEFAULT NULL,
  `fldItemDescription` longtext,
  `fldPriceMin` decimal(10,2) DEFAULT NULL,
  `fldPriceMax` decimal(10,2) DEFAULT NULL,
  `fldItemCategory` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `fldCreateDate` datetime DEFAULT NULL,
  `fldCreateBy` varchar(50) DEFAULT NULL,
  `fldUpdateDate` datetime DEFAULT NULL,
  `fldUpdateBy` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`fldItemId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbltripitem`
--

LOCK TABLES `tbltripitem` WRITE;
/*!40000 ALTER TABLE `tbltripitem` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbltripitem` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbltripmember`
--

DROP TABLE IF EXISTS `tbltripmember`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbltripmember` (
  `fldMemberId` int NOT NULL AUTO_INCREMENT,
  `fldUserId` varchar(50) NOT NULL,
  `fldTripId` varchar(50) NOT NULL,
  `fldMemberRoleId` varchar(50) DEFAULT NULL,
  `fldNickName` varchar(50) DEFAULT NULL,
  `fldStatus` varchar(10) DEFAULT NULL,
  `fldCreateDate` datetime DEFAULT NULL,
  `fldCreateBy` varchar(50) DEFAULT NULL,
  `fldUpdateDate` datetime DEFAULT NULL,
  `fldUpdateBy` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`fldMemberId`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbltripmember`
--

LOCK TABLES `tbltripmember` WRITE;
/*!40000 ALTER TABLE `tbltripmember` DISABLE KEYS */;
INSERT INTO `tbltripmember` VALUES (1,'USER_00000000','TRIP_00000001','1','KhaiDO','ACTIVE','2023-04-13 22:43:54','Admin',NULL,NULL),(2,'USER_00000001','TRIP_00000001','1','KhaiDO123','Active','2023-04-15 20:14:30','USER_00000001',NULL,NULL);
/*!40000 ALTER TABLE `tbltripmember` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbltripplan`
--

DROP TABLE IF EXISTS `tbltripplan`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbltripplan` (
  `fldPlanId` int NOT NULL AUTO_INCREMENT,
  `fldTripId` varchar(50) DEFAULT NULL,
  `fldPlanDescription` longtext,
  `fldCreateDate` datetime DEFAULT NULL,
  `fldCreateBy` varchar(50) DEFAULT NULL,
  `fldUpdateDate` datetime DEFAULT NULL,
  `fldUpdateBy` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`fldPlanId`),
  UNIQUE KEY `fldPlanId_UNIQUE` (`fldPlanId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbltripplan`
--

LOCK TABLES `tbltripplan` WRITE;
/*!40000 ALTER TABLE `tbltripplan` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbltripplan` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbltriprole`
--

DROP TABLE IF EXISTS `tbltriprole`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbltriprole` (
  `fldRoleId` int NOT NULL AUTO_INCREMENT,
  `fldRoleName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `fldType` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `fldDescription` text,
  PRIMARY KEY (`fldRoleId`),
  UNIQUE KEY `fldRoleId_UNIQUE` (`fldRoleId`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbltriprole`
--

LOCK TABLES `tbltriprole` WRITE;
/*!40000 ALTER TABLE `tbltriprole` DISABLE KEYS */;
INSERT INTO `tbltriprole` VALUES (1,'test','HOST','qwe');
/*!40000 ALTER TABLE `tbltriprole` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbluser`
--

DROP TABLE IF EXISTS `tbluser`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbluser` (
  `fldUserId` varchar(50) NOT NULL,
  `fldUsername` varchar(45) NOT NULL,
  `fldPassword` varchar(45) NOT NULL,
  PRIMARY KEY (`fldUserId`),
  UNIQUE KEY `fldUserId_UNIQUE` (`fldUserId`),
  UNIQUE KEY `fldUsername_UNIQUE` (`fldUsername`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbluser`
--

LOCK TABLES `tbluser` WRITE;
/*!40000 ALTER TABLE `tbluser` DISABLE KEYS */;
INSERT INTO `tbluser` VALUES ('USER_00000000','test','s/1VFzoEbWVuh1qotbVbyw=='),('USER_00000001','test12','s/1VFzoEbWVuh1qotbVbyw==');
/*!40000 ALTER TABLE `tbluser` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbluserdetail`
--

DROP TABLE IF EXISTS `tbluserdetail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbluserdetail` (
  `fldUserId` varchar(50) NOT NULL,
  `fldRole` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `fldBirthday` datetime DEFAULT NULL,
  `fldActiveStatus` varchar(10) DEFAULT NULL,
  `fldEmail` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `fldFullname` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `fldPhone` varchar(20) DEFAULT NULL,
  `fldAddress` text CHARACTER SET utf8 COLLATE utf8_general_ci,
  `fldExperience` float DEFAULT NULL,
  `fldTripCreated` int DEFAULT NULL,
  `fldTripJoined` int DEFAULT NULL,
  `fldTripCompleted` int DEFAULT NULL,
  `fldTripCancelled` int DEFAULT NULL,
  `fldCreateDate` datetime DEFAULT NULL,
  `fldCreateBy` varchar(50) DEFAULT NULL,
  `fldUpdateDate` datetime DEFAULT NULL,
  `fldUpdateBy` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`fldUserId`),
  UNIQUE KEY `fldUserId_UNIQUE` (`fldUserId`),
  UNIQUE KEY `fldEmail_UNIQUE` (`fldEmail`),
  UNIQUE KEY `fldPhone_UNIQUE` (`fldPhone`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbluserdetail`
--

LOCK TABLES `tbluserdetail` WRITE;
/*!40000 ALTER TABLE `tbluserdetail` DISABLE KEYS */;
INSERT INTO `tbluserdetail` VALUES ('USER_00000000','ADMIN','2023-04-10 00:00:00','ACTIVE','dooanhkhai@gmail.com','test123121','+84935664271','k482 h11/18 Trưng Nữ Vương',NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2023-04-14 20:32:59','USER_00000000'),('USER_00000001','EMPL','2023-04-14 00:00:00','ACTIVE','dooanhkhai1@gmail.com','all','123','https://kwlqoj59zr.csb.app/',NULL,NULL,NULL,NULL,NULL,'2023-04-14 21:05:15','USER_00000000',NULL,NULL);
/*!40000 ALTER TABLE `tbluserdetail` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-04-17  1:38:42
