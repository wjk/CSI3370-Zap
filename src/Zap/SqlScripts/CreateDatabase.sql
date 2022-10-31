-- Run this MySQL script at root to create the database structure.

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema Zap
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `Zap` DEFAULT CHARACTER SET utf8;
USE Zap;

-- -----------------------------------------------------
-- Table Zap.User
-- -----------------------------------------------------
DROP TABLE IF EXISTS Zap.USER;
CREATE TABLE `Zap`.`USER` (
    `USER_NAME` VARCHAR(45) NOT NULL PRIMARY KEY,
    `HASHED_PASSWORD` VARCHAR(240) NOT NULL
) ENGINE = InnoDB;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

-- -----------------------------------------------------
-- User Zap
-- -----------------------------------------------------
CREATE USER IF NOT EXISTS Zap IDENTIFIED BY 'Zap1234';
GRANT INSERT, SELECT, UPDATE, DELETE ON `Zap`.* TO 'Zap';
