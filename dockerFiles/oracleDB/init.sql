    CREATE USER PROJECT_SCHEMA IDENTIFIED BY pass123;
    GRANT ALL PRIVILEGES TO PROJECT_SCHEMA;

    CREATE TABLE Address (
                             id VARCHAR2(20) PRIMARY KEY,
                             country VARCHAR2(100),
                             city VARCHAR2(100),
                             street VARCHAR2(200),
                             houseNumber VARCHAR2(20),
                             postalCode VARCHAR2(20)
    );

    CREATE TABLE Person (
                            id VARCHAR2(20) PRIMARY KEY,
                            firstName VARCHAR2(100),
                            lastName VARCHAR2(100),
                            email VARCHAR2(1000),
                            phone VARCHAR2(20),
                            birthDateUtc DATE,
                            gender NUMBER(1),
                            addressId VARCHAR2(20) REFERENCES Address(id),
                            status NUMBER(1)
    );
