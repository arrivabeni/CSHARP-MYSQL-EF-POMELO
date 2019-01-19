CREATE SCHEMA `sampledb` DEFAULT CHARACTER SET utf8mb4 ;

CREATE TABLE `sampledb`.`employees` (
  `idemployees` INT NOT NULL AUTO_INCREMENT,
  `firstname` VARCHAR(45) NULL,
  `lastname` VARCHAR(45) NULL,
  `birthdate` DATETIME NULL,
  PRIMARY KEY (`idemployees`));

CREATE TABLE `sampledb`.`addresses` (
  `idaddresses` INT NOT NULL AUTO_INCREMENT,
  `idemployee` INT NULL,
  `street` VARCHAR(45) NULL,
  `number` VARCHAR(45) NULL,
  `city` VARCHAR(45) NULL,
  `state` VARCHAR(45) NULL,
  `country` VARCHAR(45) NULL,
  PRIMARY KEY (`idaddresses`),
  INDEX `employee_address_idx` (`idemployee` ASC),
  CONSTRAINT `employee_address`
    FOREIGN KEY (`idemployee`)
    REFERENCES `sampledb`.`employees` (`idemployees`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

INSERT INTO `sampledb`.`employees` (`firstname`, `lastname`, `birthdate`) VALUES ('Johnny ', 'Appleseed', '1774-09-26');

INSERT INTO `sampledb`.`addresses` (`idemployee`, `street`, `number`, `city`, `state`, `country`) VALUES ('1', 'Street One', '500', 'My City', 'FL', 'US');
