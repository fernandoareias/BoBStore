-- Script de criação do BD e suas tabelas.

-- Cria o banco
CREATE DATABASE [BoBStore]

-- Seleciona o BD BoBStore
USE [BobStore]

-- Efetua as querys de criação de tabelas no BD BoBStore

-- Cria tabela Cliente
CREATE TABLE [Customer]
(
    [Id] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
    [FirstName] VARCHAR(40) NOT NULL,
    [LastName] VARCHAR(40) NOT NULL,
    [Document] CHAR(11) NOT NULL,
    [Email] VARCHAR(60) NOT NULL,
    [Phone] VARCHAR(13) NOT NULL
);
GO

-- Cria tabela dos Endereços
CREATE TABLE [Address]
(
    [Id] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
    [CustomerId] UNIQUEIDENTIFIER NOT NULL,
    [Number] VARCHAR(10) NOT NULL,
    [Complement] VARCHAR(40) NOT NULL,
    [District] VARCHAR(60) NOT NULL,
    [City] VARCHAR(60) NOT NULL,
    [State] CHAR(2) NOT NULL,
    [Country] CHAR (3) NOT NULL,
    [ZipCode] CHAR (8) NOT NULL,
    [Type] INT NOT NULL DEFAULT(1),
    CONSTRAINT [FK_Address_Customer_Id] FOREIGN KEY ([CustomerId]) REFERENCES [Customer]([Id])
);
GO

-- Cria tabela dos Produtos
CREATE TABLE [Product]
(
    [Id] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
    [Title] VARCHAR(225) NOT NULL,
    [Description] TEXT NOT NULL,
    [Image] VARCHAR(1024) NOT NULL,
    [Price] MONEY NOT NULL,
    [QuantityOnHand] DECIMAL(10, 2) NOT NULL
);
GO

-- Cria tabela dos Pedidos
CREATE TABLE [Order]
(
    [Id] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
    [CustomerId] UNIQUEIDENTIFIER NOT NULL,
    [CreateDate] DATETIME NOT NULL DEFAULT(GETDATE()),
    [Status] INT NOT NULL DEFAULT(1),
    CONSTRAINT [FK_Order_Customer_Id] FOREIGN KEY ([CustomerId]) REFERENCES [Customer]([Id])
);
GO

-- Cria a tabela dos Itens dos Pedidos
CREATE TABLE [OrderItem]
(
    [Id] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
    [OrderId] UNIQUEIDENTIFIER NOT NULL,
    [ProductId] UNIQUEIDENTIFIER NOT NULL,
    [Quantity] DECIMAL(10, 2) NOT NULL,
    [Price] MONEY NOT NULL,
    CONSTRAINT [FK_OrderItem_Order_Id] FOREIGN KEY ([OrderId]) REFERENCES [Order]([Id]),
    CONSTRAINT [FK_OrderItem_Product_Id] FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id])
);
GO

-- Cria a tabela Delivery 
CREATE TABLE [Delivery]
(
    [Id] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
    [OrderItem] UNIQUEIDENTIFIER NOT NULL,
    [CreateDate] DATETIME NOT NULL DEFAULT(GETDATE()),
    [EstimatedDeliveryDate] DATETIME NOT NULL,
    [Status] INT NOT NULL DEFAULT(1),
    CONSTRAINT [FK_Delivery_OrderItem_Id] FOREIGN KEY([OrderItem]) REFERENCES [OrderItem]([Id])

);
GO