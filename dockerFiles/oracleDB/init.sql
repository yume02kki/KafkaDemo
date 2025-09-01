ALTER SESSION SET CONTAINER = XEPDB1;

CREATE USER PROJECT IDENTIFIED BY "1";
GRANT CONNECT, RESOURCE, UNLIMITED TABLESPACE TO PROJECT;

ALTER SESSION SET CURRENT_SCHEMA = PROJECT;

CREATE TABLE Address (
    id RAW(16) PRIMARY KEY,
    country     VARCHAR2(100),
    city        VARCHAR2(100),
    street      VARCHAR2(200),
    houseNumber VARCHAR2(20),
    postalCode  VARCHAR2(20)
);

CREATE TABLE Person (
    id           RAW(16) PRIMARY KEY,
    firstName    VARCHAR2(100),
    lastName     VARCHAR2(100),
    email        VARCHAR2(1000),
    phone        VARCHAR2(20),
    birthDateUtc DATE,
    gender       NUMBER(1),
    addressId    RAW(16),
    status       NUMBER(1),
    CONSTRAINT fk_person_address FOREIGN KEY (addressId) REFERENCES Address(id)
);

