
CREATE DATABASE IF NOT EXISTS dbcompras;
USE dbcompras ;


CREATE TABLE IF NOT EXISTS `dbcompras`.`bodegas` (
  `codigo_bodega` VARCHAR(5) NOT NULL,
  `nombre_bodega` VARCHAR(60) NULL DEFAULT NULL,
  `estatus_bodega` VARCHAR(1) NULL DEFAULT NULL,
  PRIMARY KEY (`codigo_bodega`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


CREATE TABLE IF NOT EXISTS `dbcompras`.`proveedores` (
  `codigo_proveedor` VARCHAR(5) NOT NULL,
  `nombre_proveedor` VARCHAR(60) NULL DEFAULT NULL,
  `direccion_proveedor` VARCHAR(60) NULL DEFAULT NULL,
  `telefono_proveedor` VARCHAR(50) NULL DEFAULT NULL,
  `nit_proveedor` VARCHAR(50) NULL DEFAULT NULL,
  `estatus_proveedor` VARCHAR(1) NULL DEFAULT NULL,
  PRIMARY KEY (`codigo_proveedor`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;



CREATE TABLE IF NOT EXISTS `dbcompras`.`compras_encabezado` (
  `documento_compraenca` VARCHAR(10) NOT NULL,
  `codigo_proveedor` VARCHAR(5) NULL DEFAULT NULL,
  `fecha_compraenca` DATE NULL DEFAULT NULL,
  `total_compraenca` FLOAT(10,2) NULL DEFAULT NULL,
  `estatus_compraenca` VARCHAR(1) NULL DEFAULT NULL,
  PRIMARY KEY (`documento_compraenca`),
  INDEX `codigo_proveedor` (`codigo_proveedor` ASC) VISIBLE,
  CONSTRAINT `compras_encabezado_ibfk_1`
    FOREIGN KEY (`codigo_proveedor`)
    REFERENCES `dbcompras`.`proveedores` (`codigo_proveedor`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


CREATE TABLE IF NOT EXISTS `dbcompras`.`lineas` (
  `codigo_linea` VARCHAR(5) NOT NULL,
  `nombre_linea` VARCHAR(60) NULL DEFAULT NULL,
  `estatus_linea` VARCHAR(1) NULL DEFAULT NULL,
  PRIMARY KEY (`codigo_linea`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;



CREATE TABLE IF NOT EXISTS `dbcompras`.`marcas` (
  `codigo_marca` VARCHAR(5) NOT NULL,
  `nombre_marca` VARCHAR(60) NULL DEFAULT NULL,
  `estatus_marca` VARCHAR(1) NULL DEFAULT NULL,
  PRIMARY KEY (`codigo_marca`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;



CREATE TABLE IF NOT EXISTS `dbcompras`.`productos` (
  `codigo_producto` VARCHAR(18) NOT NULL,
  `nombre_producto` VARCHAR(60) NULL DEFAULT NULL,
  `codigo_linea` VARCHAR(5) NULL DEFAULT NULL,
  `codigo_marca` VARCHAR(5) NULL DEFAULT NULL,
  `existencia_producto` FLOAT(10,2) NULL DEFAULT NULL,
  `estatus_producto` VARCHAR(1) NULL DEFAULT NULL,
  PRIMARY KEY (`codigo_producto`),
  INDEX `codigo_linea` (`codigo_linea` ASC) VISIBLE,
  INDEX `codigo_marca` (`codigo_marca` ASC) VISIBLE,
  CONSTRAINT `productos_ibfk_1`
    FOREIGN KEY (`codigo_linea`)
    REFERENCES `dbcompras`.`lineas` (`codigo_linea`),
  CONSTRAINT `productos_ibfk_2`
    FOREIGN KEY (`codigo_marca`)
    REFERENCES `dbcompras`.`marcas` (`codigo_marca`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;



CREATE TABLE IF NOT EXISTS `dbcompras`.`compras_detalle` (
  `documento_compraenca` VARCHAR(10) NOT NULL,
  `codigo_producto` VARCHAR(18) NOT NULL,
  `cantidad_compradet` FLOAT(10,2) NULL DEFAULT NULL,
  `costo_compradet` FLOAT(10,2) NULL DEFAULT NULL,
  `codigo_bodega` VARCHAR(5) NULL DEFAULT NULL,
  INDEX `codigo_producto` (`codigo_producto` ASC) VISIBLE,
  INDEX `codigo_bodega` (`codigo_bodega` ASC) VISIBLE,
  CONSTRAINT `compras_detalle_ibfk_1`
    FOREIGN KEY (`documento_compraenca`)
    REFERENCES `dbcompras`.`compras_encabezado` (`documento_compraenca`),
  CONSTRAINT `compras_detalle_ibfk_2`
    FOREIGN KEY (`codigo_producto`)
    REFERENCES `dbcompras`.`productos` (`codigo_producto`),
  CONSTRAINT `compras_detalle_ibfk_3`
    FOREIGN KEY (`codigo_bodega`)
    REFERENCES `dbcompras`.`bodegas` (`codigo_bodega`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;



CREATE TABLE IF NOT EXISTS `dbcompras`.`existencias` (
  `codigo_bodega` VARCHAR(5) NOT NULL,
  `codigo_producto` VARCHAR(18) NOT NULL,
  `saldo_existencia` FLOAT(10,2) NULL DEFAULT NULL,
  INDEX `codigo_producto` (`codigo_producto` ASC) VISIBLE,
  CONSTRAINT `existencias_ibfk_1`
    FOREIGN KEY (`codigo_bodega`)
    REFERENCES `dbcompras`.`bodegas` (`codigo_bodega`),
  CONSTRAINT `existencias_ibfk_2`
    FOREIGN KEY (`codigo_producto`)
    REFERENCES `dbcompras`.`productos` (`codigo_producto`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;



