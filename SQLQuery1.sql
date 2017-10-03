Create Database MyProject

use MyProject

Create Table Users
(
UserID varchar(30) primary key,
UserPassword varchar(max),
UserType varchar(max)
)

select * from users

Insert Users Values('admin','admin','Admin')

Create Table Customers
(CustomerID int identity(1000,1) primary key,
CustomerName varchar(max),
CustomerAddress varchar(max),
CustomerWebsite varchar(max),
CustomerEmailID varchar(max),
CustomerLandline varchar(max),
CustomerContactName1 varchar(max),
CustomerContactNumber1 varchar(max),
CustomerContactName2 varchar(max),
CustomerContactNumber2 varchar(max),
CustomerDue int,
CustomerStatus VARCHAR(10)
)

select * from Customers

Create Table Suppliers
(SupplierID int identity(1000,1) primary key,
SupplierName varchar(max),
MillName varchar(max),
SupplierAddress varchar(max),
SupplierWebsite varchar(max),
SupplierEmailID varchar(max),
SupplierLandline varchar(max),
SupplierContactName1 varchar(max),
SupplierContactNumber1 varchar(max),
SupplierContactName2 varchar(max),
SupplierContactNumber2 varchar(max),
SupplierTIN varchar(max),
SupplierGSTNo varchar(max),
SupplierPAN varchar(max),
SupplierBankName varchar(max),
SupplierBankAccountNo varchar(max),
SupplierIFSC varchar(max),
SupplierDue int,
SupplierStatus VARCHAR(10)
)

select * from Suppliers

Create Table Contractors
(ContractorID int identity(1000,1) primary key,
ContractorName varchar(max),
ContractorAddress varchar(max),
ContractorWebsite varchar(max),
ContractorEmailID varchar(max),
ContractorLandline varchar(max),
ContractorContactName1 varchar(max),
ContractorContactNumber1 varchar(max),
ContractorContactName2 varchar(max),
ContractorContactNumber2 varchar(max),
ContractorTIN varchar(max),
ContractorGSTNo varchar(max),
ContractorPAN varchar(max),
ContractorBankName varchar(max),
ContractorBankAccountNo varchar(max),
ContractorIFSC varchar(max),
ContractorDue int,
ContractorStatus VARCHAR(10)
)

select * from Contractors