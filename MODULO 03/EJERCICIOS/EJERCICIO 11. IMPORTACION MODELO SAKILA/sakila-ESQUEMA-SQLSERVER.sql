-- Sakila schema para Microsoft SQL Server (SSMS)
-- Propietario: Realizado por Manel Montero
-- Generada: 17-02-2026
-- Nota: Los corchetes están generados para evitar errores con Nombres de campos
-- que usen espacios en blanco. Se podrían eliminar si no es el caso

IF DB_ID(N'BDSAKILA') IS NOT NULL
BEGIN
  ALTER DATABASE [BDSAKILA] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
  DROP DATABASE [BDSAKILA];
END
GO

CREATE DATABASE [BDSAKILA];
GO
USE [BDSAKILA];
GO

SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO

CREATE TABLE [dbo].[actor] (
  [actor_id] SMALLINT IDENTITY(1,1) NOT NULL,
  [first_name] VARCHAR(45) NOT NULL,
  [last_name] VARCHAR(45) NOT NULL,
  [last_update] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
  CONSTRAINT [PK_actor] PRIMARY KEY ([actor_id])
);
GO

CREATE TABLE [dbo].[country] (
  [country_id] SMALLINT IDENTITY(1,1) NOT NULL,
  [country] VARCHAR(50) NOT NULL,
  [last_update] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
  CONSTRAINT [PK_country] PRIMARY KEY ([country_id])
);
GO

CREATE TABLE [dbo].[city] (
  [city_id] SMALLINT IDENTITY(1,1) NOT NULL,
  [city] VARCHAR(50) NOT NULL,
  [country_id] SMALLINT NOT NULL,
  [last_update] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
  CONSTRAINT [PK_city] PRIMARY KEY ([city_id]),
  CONSTRAINT [fk_city_country] FOREIGN KEY ([country_id]) REFERENCES [dbo].[country] ([country_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
GO

CREATE TABLE [dbo].[address] (
  [address_id] SMALLINT IDENTITY(1,1) NOT NULL,
  [address] VARCHAR(50) NOT NULL,
  [address2] VARCHAR(50),
  [district] VARCHAR(20) NOT NULL,
  [city_id] SMALLINT NOT NULL,
  [postal_code] VARCHAR(10),
  [phone] VARCHAR(20) NOT NULL,
  [last_update] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
  CONSTRAINT [PK_address] PRIMARY KEY ([address_id]),
  CONSTRAINT [fk_address_city] FOREIGN KEY ([city_id]) REFERENCES [dbo].[city] ([city_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
GO

CREATE TABLE [dbo].[store] (
  [store_id] TINYINT IDENTITY(1,1) NOT NULL,
  [manager_staff_id] TINYINT NOT NULL,
  [address_id] SMALLINT NOT NULL,
  [last_update] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
  CONSTRAINT [PK_store] PRIMARY KEY ([store_id]),
  CONSTRAINT [fk_store_address] FOREIGN KEY ([address_id]) REFERENCES [dbo].[address] ([address_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
GO

CREATE TABLE [dbo].[staff] (
  [staff_id] TINYINT IDENTITY(1,1) NOT NULL,
  [first_name] VARCHAR(45) NOT NULL,
  [last_name] VARCHAR(45) NOT NULL,
  [address_id] SMALLINT NOT NULL,
  [picture] VARBINARY(MAX),
  [email] VARCHAR(50),
  [store_id] TINYINT NOT NULL,
  [active] BIT NOT NULL DEFAULT 1,
  [username] VARCHAR(16) NOT NULL,
  [password] VARCHAR(40),
  [last_update] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
  CONSTRAINT [PK_staff] PRIMARY KEY ([staff_id]),
  CONSTRAINT [fk_staff_store] FOREIGN KEY ([store_id]) REFERENCES [dbo].[store] ([store_id]) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT [fk_staff_address] FOREIGN KEY ([address_id]) REFERENCES [dbo].[address] ([address_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
GO

CREATE TABLE [dbo].[customer] (
  [customer_id] SMALLINT IDENTITY(1,1) NOT NULL,
  [store_id] TINYINT NOT NULL,
  [first_name] VARCHAR(45) NOT NULL,
  [last_name] VARCHAR(45) NOT NULL,
  [email] VARCHAR(50),
  [address_id] SMALLINT NOT NULL,
  [active] BIT NOT NULL DEFAULT 1,
  [create_date] DATETIME2 NOT NULL,
  [last_update] DATETIME2 DEFAULT SYSDATETIME(),
  CONSTRAINT [PK_customer] PRIMARY KEY ([customer_id]),
  CONSTRAINT [fk_customer_address] FOREIGN KEY ([address_id]) REFERENCES [dbo].[address] ([address_id]) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT [fk_customer_store] FOREIGN KEY ([store_id]) REFERENCES [dbo].[store] ([store_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
GO

CREATE TABLE [dbo].[language] (
  [language_id] TINYINT IDENTITY(1,1) NOT NULL,
  [name] CHAR(20) NOT NULL,
  [last_update] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
  CONSTRAINT [PK_language] PRIMARY KEY ([language_id])
);
GO

CREATE TABLE [dbo].[category] (
  [category_id] TINYINT IDENTITY(1,1) NOT NULL,
  [name] VARCHAR(25) NOT NULL,
  [last_update] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
  CONSTRAINT [PK_category] PRIMARY KEY ([category_id])
);
GO

CREATE TABLE [dbo].[film] (
  [film_id] SMALLINT IDENTITY(1,1) NOT NULL,
  [title] VARCHAR(255) NOT NULL,
  [description] VARCHAR(MAX),
  [release_year] SMALLINT,
  [language_id] TINYINT NOT NULL,
  [original_language_id] TINYINT,
  [rental_duration] TINYINT NOT NULL DEFAULT 3,
  [rental_rate] DECIMAL(4,2) NOT NULL DEFAULT 4.99,
  [length] SMALLINT,
  [replacement_cost] DECIMAL(5,2) NOT NULL DEFAULT 19.99,
  [rating] VARCHAR(10) DEFAULT 'G' CHECK ([rating] IN ('G', 'PG', 'PG-13', 'R', 'NC-17')),
  [special_features] VARCHAR(255),
  [last_update] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
  CONSTRAINT [PK_film] PRIMARY KEY ([film_id]),
  CONSTRAINT [fk_film_language] FOREIGN KEY ([language_id]) REFERENCES [dbo].[language] ([language_id]) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT [fk_film_language_original] FOREIGN KEY ([original_language_id]) REFERENCES [dbo].[language] ([language_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
GO

CREATE TABLE [dbo].[film_text] (
  [film_id] SMALLINT NOT NULL,
  [title] VARCHAR(255) NOT NULL,
  [description] VARCHAR(MAX),
  CONSTRAINT [PK_film_text] PRIMARY KEY ([film_id])
);
GO

CREATE TABLE [dbo].[film_actor] (
  [actor_id] SMALLINT NOT NULL,
  [film_id] SMALLINT NOT NULL,
  [last_update] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
  CONSTRAINT [PK_film_actor] PRIMARY KEY ([actor_id], [film_id]),
  CONSTRAINT [fk_film_actor_actor] FOREIGN KEY ([actor_id]) REFERENCES [dbo].[actor] ([actor_id]) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT [fk_film_actor_film] FOREIGN KEY ([film_id]) REFERENCES [dbo].[film] ([film_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
GO

CREATE TABLE [dbo].[film_category] (
  [film_id] SMALLINT NOT NULL,
  [category_id] TINYINT NOT NULL,
  [last_update] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
  CONSTRAINT [PK_film_category] PRIMARY KEY ([film_id], [category_id]),
  CONSTRAINT [fk_film_category_film] FOREIGN KEY ([film_id]) REFERENCES [dbo].[film] ([film_id]) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT [fk_film_category_category] FOREIGN KEY ([category_id]) REFERENCES [dbo].[category] ([category_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
GO

CREATE TABLE [dbo].[inventory] (
  [inventory_id] INT IDENTITY(1,1) NOT NULL,
  [film_id] SMALLINT NOT NULL,
  [store_id] TINYINT NOT NULL,
  [last_update] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
  CONSTRAINT [PK_inventory] PRIMARY KEY ([inventory_id]),
  CONSTRAINT [fk_inventory_store] FOREIGN KEY ([store_id]) REFERENCES [dbo].[store] ([store_id]) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT [fk_inventory_film] FOREIGN KEY ([film_id]) REFERENCES [dbo].[film] ([film_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
GO

CREATE TABLE [dbo].[rental] (
  [rental_id] INT IDENTITY(1,1) NOT NULL,
  [rental_date] DATETIME2 NOT NULL,
  [inventory_id] INT NOT NULL,
  [customer_id] SMALLINT NOT NULL,
  [return_date] DATETIME2,
  [staff_id] TINYINT NOT NULL,
  [last_update] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
  CONSTRAINT [PK_rental] PRIMARY KEY ([rental_id]),
  CONSTRAINT [fk_rental_staff] FOREIGN KEY ([staff_id]) REFERENCES [dbo].[staff] ([staff_id]) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT [fk_rental_inventory] FOREIGN KEY ([inventory_id]) REFERENCES [dbo].[inventory] ([inventory_id]) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT [fk_rental_customer] FOREIGN KEY ([customer_id]) REFERENCES [dbo].[customer] ([customer_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
GO

CREATE TABLE [dbo].[payment] (
  [payment_id] SMALLINT IDENTITY(1,1) NOT NULL,
  [customer_id] SMALLINT NOT NULL,
  [staff_id] TINYINT NOT NULL,
  [rental_id] INT,
  [amount] DECIMAL(5,2) NOT NULL,
  [payment_date] DATETIME2 NOT NULL,
  [last_update] DATETIME2 DEFAULT SYSDATETIME(),
  CONSTRAINT [PK_payment] PRIMARY KEY ([payment_id]),
  CONSTRAINT [fk_payment_rental] FOREIGN KEY ([rental_id]) REFERENCES [dbo].[rental] ([rental_id]) ON DELETE SET NULL ON UPDATE NO ACTION,
  CONSTRAINT [fk_payment_customer] FOREIGN KEY ([customer_id]) REFERENCES [dbo].[customer] ([customer_id]) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT [fk_payment_staff] FOREIGN KEY ([staff_id]) REFERENCES [dbo].[staff] ([staff_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
GO

ALTER TABLE [dbo].[store]
  ADD CONSTRAINT [fk_store_staff] FOREIGN KEY ([manager_staff_id]) REFERENCES [dbo].[staff]([staff_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Indexes
GO
CREATE NONCLUSTERED INDEX [idx_actor_last_name] ON [dbo].[actor] ([last_name]);
GO
CREATE NONCLUSTERED INDEX [idx_fk_country_id] ON [dbo].[city] ([country_id]);
GO
CREATE NONCLUSTERED INDEX [idx_fk_city_id] ON [dbo].[address] ([city_id]);
GO
CREATE UNIQUE NONCLUSTERED INDEX [idx_unique_manager] ON [dbo].[store] ([manager_staff_id]);
GO
CREATE NONCLUSTERED INDEX [idx_fk_address_id] ON [dbo].[store] ([address_id]);
GO
CREATE NONCLUSTERED INDEX [idx_fk_store_id] ON [dbo].[staff] ([store_id]);
GO
CREATE NONCLUSTERED INDEX [idx_fk_address_id] ON [dbo].[staff] ([address_id]);
GO
CREATE NONCLUSTERED INDEX [idx_fk_store_id] ON [dbo].[customer] ([store_id]);
GO
CREATE NONCLUSTERED INDEX [idx_fk_address_id] ON [dbo].[customer] ([address_id]);
GO
CREATE NONCLUSTERED INDEX [idx_last_name] ON [dbo].[customer] ([last_name]);
GO
CREATE NONCLUSTERED INDEX [idx_title] ON [dbo].[film] ([title]);
GO
CREATE NONCLUSTERED INDEX [idx_fk_language_id] ON [dbo].[film] ([language_id]);
GO
CREATE NONCLUSTERED INDEX [idx_fk_original_language_id] ON [dbo].[film] ([original_language_id]);
GO
CREATE NONCLUSTERED INDEX [idx_fk_film_id] ON [dbo].[film_actor] ([film_id]);
GO
CREATE NONCLUSTERED INDEX [idx_fk_film_id] ON [dbo].[inventory] ([film_id]);
GO
CREATE NONCLUSTERED INDEX [idx_store_id_film_id] ON [dbo].[inventory] ([store_id], [film_id]);
GO
CREATE UNIQUE NONCLUSTERED INDEX [UQ_rental_rental_date_inventory_id_customer_id_1] ON [dbo].[rental] ([rental_date], [inventory_id], [customer_id]);
GO
CREATE NONCLUSTERED INDEX [idx_fk_inventory_id] ON [dbo].[rental] ([inventory_id]);
GO
CREATE NONCLUSTERED INDEX [idx_fk_customer_id] ON [dbo].[rental] ([customer_id]);
GO
CREATE NONCLUSTERED INDEX [idx_fk_staff_id] ON [dbo].[rental] ([staff_id]);
GO
CREATE NONCLUSTERED INDEX [idx_fk_staff_id] ON [dbo].[payment] ([staff_id]);
GO
CREATE NONCLUSTERED INDEX [idx_fk_customer_id] ON [dbo].[payment] ([customer_id]);
GO

-- Triggers to maintain last_update on UPDATE
GO
CREATE OR ALTER TRIGGER [dbo].[tr_actor_last_update]
ON [dbo].[actor]
AFTER UPDATE
AS
BEGIN
  SET NOCOUNT ON;
  UPDATE t
    SET [last_update] = SYSDATETIME()
  FROM [dbo].[actor] t
  INNER JOIN inserted i ON t.[actor_id]=i.[actor_id];
END
GO

CREATE OR ALTER TRIGGER [dbo].[tr_address_last_update]
ON [dbo].[address]
AFTER UPDATE
AS
BEGIN
  SET NOCOUNT ON;
  UPDATE t
    SET [last_update] = SYSDATETIME()
  FROM [dbo].[address] t
  INNER JOIN inserted i ON t.[address_id]=i.[address_id];
END
GO

CREATE OR ALTER TRIGGER [dbo].[tr_category_last_update]
ON [dbo].[category]
AFTER UPDATE
AS
BEGIN
  SET NOCOUNT ON;
  UPDATE t
    SET [last_update] = SYSDATETIME()
  FROM [dbo].[category] t
  INNER JOIN inserted i ON t.[category_id]=i.[category_id];
END
GO

CREATE OR ALTER TRIGGER [dbo].[tr_city_last_update]
ON [dbo].[city]
AFTER UPDATE
AS
BEGIN
  SET NOCOUNT ON;
  UPDATE t
    SET [last_update] = SYSDATETIME()
  FROM [dbo].[city] t
  INNER JOIN inserted i ON t.[city_id]=i.[city_id];
END
GO

CREATE OR ALTER TRIGGER [dbo].[tr_country_last_update]
ON [dbo].[country]
AFTER UPDATE
AS
BEGIN
  SET NOCOUNT ON;
  UPDATE t
    SET [last_update] = SYSDATETIME()
  FROM [dbo].[country] t
  INNER JOIN inserted i ON t.[country_id]=i.[country_id];
END
GO

CREATE OR ALTER TRIGGER [dbo].[tr_customer_last_update]
ON [dbo].[customer]
AFTER UPDATE
AS
BEGIN
  SET NOCOUNT ON;
  UPDATE t
    SET [last_update] = SYSDATETIME()
  FROM [dbo].[customer] t
  INNER JOIN inserted i ON t.[customer_id]=i.[customer_id];
END
GO

CREATE OR ALTER TRIGGER [dbo].[tr_film_last_update]
ON [dbo].[film]
AFTER UPDATE
AS
BEGIN
  SET NOCOUNT ON;
  UPDATE t
    SET [last_update] = SYSDATETIME()
  FROM [dbo].[film] t
  INNER JOIN inserted i ON t.[film_id]=i.[film_id];
END
GO

CREATE OR ALTER TRIGGER [dbo].[tr_film_actor_last_update]
ON [dbo].[film_actor]
AFTER UPDATE
AS
BEGIN
  SET NOCOUNT ON;
  UPDATE t
    SET [last_update] = SYSDATETIME()
  FROM [dbo].[film_actor] t
  INNER JOIN inserted i ON t.[actor_id]=i.[actor_id] AND t.[film_id]=i.[film_id];
END
GO

CREATE OR ALTER TRIGGER [dbo].[tr_film_category_last_update]
ON [dbo].[film_category]
AFTER UPDATE
AS
BEGIN
  SET NOCOUNT ON;
  UPDATE t
    SET [last_update] = SYSDATETIME()
  FROM [dbo].[film_category] t
  INNER JOIN inserted i ON t.[film_id]=i.[film_id] AND t.[category_id]=i.[category_id];
END
GO

CREATE OR ALTER TRIGGER [dbo].[tr_inventory_last_update]
ON [dbo].[inventory]
AFTER UPDATE
AS
BEGIN
  SET NOCOUNT ON;
  UPDATE t
    SET [last_update] = SYSDATETIME()
  FROM [dbo].[inventory] t
  INNER JOIN inserted i ON t.[inventory_id]=i.[inventory_id];
END
GO

CREATE OR ALTER TRIGGER [dbo].[tr_language_last_update]
ON [dbo].[language]
AFTER UPDATE
AS
BEGIN
  SET NOCOUNT ON;
  UPDATE t
    SET [last_update] = SYSDATETIME()
  FROM [dbo].[language] t
  INNER JOIN inserted i ON t.[language_id]=i.[language_id];
END
GO

CREATE OR ALTER TRIGGER [dbo].[tr_payment_last_update]
ON [dbo].[payment]
AFTER UPDATE
AS
BEGIN
  SET NOCOUNT ON;
  UPDATE t
    SET [last_update] = SYSDATETIME()
  FROM [dbo].[payment] t
  INNER JOIN inserted i ON t.[payment_id]=i.[payment_id];
END
GO

CREATE OR ALTER TRIGGER [dbo].[tr_rental_last_update]
ON [dbo].[rental]
AFTER UPDATE
AS
BEGIN
  SET NOCOUNT ON;
  UPDATE t
    SET [last_update] = SYSDATETIME()
  FROM [dbo].[rental] t
  INNER JOIN inserted i ON t.[rental_id]=i.[rental_id];
END
GO

CREATE OR ALTER TRIGGER [dbo].[tr_staff_last_update]
ON [dbo].[staff]
AFTER UPDATE
AS
BEGIN
  SET NOCOUNT ON;
  UPDATE t
    SET [last_update] = SYSDATETIME()
  FROM [dbo].[staff] t
  INNER JOIN inserted i ON t.[staff_id]=i.[staff_id];
END
GO

CREATE OR ALTER TRIGGER [dbo].[tr_store_last_update]
ON [dbo].[store]
AFTER UPDATE
AS
BEGIN
  SET NOCOUNT ON;
  UPDATE t
    SET [last_update] = SYSDATETIME()
  FROM [dbo].[store] t
  INNER JOIN inserted i ON t.[store_id]=i.[store_id];
END
GO

