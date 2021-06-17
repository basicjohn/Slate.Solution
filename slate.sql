-- MySQL dump 10.13  Distrib 8.0.15, for macos10.14 (x86_64)
--
-- Host: localhost    Database: slate
-- ------------------------------------------------------
-- Server version	8.0.15

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__EFMigrationsHistory`
--

DROP TABLE IF EXISTS `__EFMigrationsHistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__EFMigrationsHistory`
--

LOCK TABLES `__EFMigrationsHistory` WRITE;
/*!40000 ALTER TABLE `__EFMigrationsHistory` DISABLE KEYS */;
INSERT INTO `__EFMigrationsHistory` VALUES ('20210616212223_Initial','5.0.0'),('20210616214609_UpdatesUserInvProps','5.0.0'),('20210616221251_FixUserConstructor','5.0.0');
/*!40000 ALTER TABLE `__EFMigrationsHistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Boards`
--

DROP TABLE IF EXISTS `Boards`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `Boards` (
  `Id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `URI` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Content` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `OwnerId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `EditorId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `EditorExpiration` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Boards_EditorId` (`EditorId`),
  KEY `IX_Boards_OwnerId` (`OwnerId`),
  CONSTRAINT `FK_Boards_Users_EditorId` FOREIGN KEY (`EditorId`) REFERENCES `users` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Boards_Users_OwnerId` FOREIGN KEY (`OwnerId`) REFERENCES `users` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Boards`
--

LOCK TABLES `Boards` WRITE;
/*!40000 ALTER TABLE `Boards` DISABLE KEYS */;
INSERT INTO `Boards` VALUES ('4e5dcd08-8ab6-43c9-8eef-29b1879684c8','4e5dcd08-8ab6-43c9-8eef-29b1879684c8',NULL,NULL,'ec00355c-8676-4bf0-a222-f60e8d746469','ec00355c-8676-4bf0-a222-f60e8d746469','0001-01-01 00:00:00.000000'),('6efa8f6c-87c1-43d1-931f-4c153728327f','6efa8f6c-87c1-43d1-931f-4c153728327f',NULL,NULL,'9fe75af6-ec6d-4582-9eb3-35793286182c','9fe75af6-ec6d-4582-9eb3-35793286182c','0001-01-01 00:00:00.000000'),('a4ac00a1-8084-49a0-9989-8596d4659be8','a4ac00a1-8084-49a0-9989-8596d4659be8',NULL,NULL,'9fe75af6-ec6d-4582-9eb3-35793286182c','9fe75af6-ec6d-4582-9eb3-35793286182c','0001-01-01 00:00:00.000000'),('e4659fa0-47b1-4f9d-b39b-f5b89b97f94a','e4659fa0-47b1-4f9d-b39b-f5b89b97f94a',NULL,NULL,'9fe75af6-ec6d-4582-9eb3-35793286182c','9fe75af6-ec6d-4582-9eb3-35793286182c','0001-01-01 00:00:00.000000'),('ef4b63d6-35c8-4a0b-bd94-6dd30f7789ed','ef4b63d6-35c8-4a0b-bd94-6dd30f7789ed',NULL,NULL,'9fe75af6-ec6d-4582-9eb3-35793286182c','9fe75af6-ec6d-4582-9eb3-35793286182c','0001-01-01 00:00:00.000000'),('f2f969e3-e4f1-45d6-8de6-bc63fbb16e72','f2f969e3-e4f1-45d6-8de6-bc63fbb16e72',NULL,NULL,'ec00355c-8676-4bf0-a222-f60e8d746469','ec00355c-8676-4bf0-a222-f60e8d746469','0001-01-01 00:00:00.000000');
/*!40000 ALTER TABLE `Boards` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Users`
--

DROP TABLE IF EXISTS `Users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `Users` (
  `Id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Email` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Salt` longblob,
  `Hash` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Users`
--

LOCK TABLES `Users` WRITE;
/*!40000 ALTER TABLE `Users` DISABLE KEYS */;
INSERT INTO `Users` VALUES ('455c3e27-4c2a-4354-96ab-486839b9383e','John','e@g.co',_binary 'xÒD9\“NÈñë\Ê\Á\”5','1bt82kH0RZ5/avCzYacEsCJ9N8vsW5HGEpgffrL3Cf4='),('77538b76-6a0e-478b-b26d-22632074fcea','ahmed','ahmed',_binary 'Û\∆\Èæ@ø=\·CınêT','FVl+QdpeF4KiMj4BRRRM2Tp4X5tVI5j5sUD47vr0Hqo='),('9fe75af6-ec6d-4582-9eb3-35793286182c','Jeremy','jeremy',_binary 'Ωsèp\Âï-tø¿ÏÑö\œ','mH7vHNTRtFx0g746p0vUKlNkST2XqyAv9i7m9btnQ2E='),('ec00355c-8676-4bf0-a222-f60e8d746469','Tom','a@b.c',_binary 'o/SM—æ\„0˜`d\ﬁ\ H','gInxWyFr7Kxz6GkJrZkTUWPqE7u29Jf5FmXtrlsRi8U=');
/*!40000 ALTER TABLE `Users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-06-17 10:51:01
