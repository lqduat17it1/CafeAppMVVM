
CREATE DATABASE Cafe_MVVM_DB
GO
USE Cafe_MVVM_DB
GO

CREATE TABLE tblArea
(
	AreaID INT IDENTITY(1,1),
	AreaName NVARCHAR(100),
)
GO
CREATE INDEX idx_area
ON tblArea(AreaID,AreaName)
GO
CREATE PROCEDURE sp_LoadArea
AS
BEGIN
SELECT AreaID,AreaName FROM tblArea
END
GO
CREATE TABLE tblTable
(
	TableID INT IDENTITY(1,1),
	TableName NVARCHAR(100),
	TableStatus NVARCHAR(100),
	AreaID INT
)
GO
CREATE INDEX idx_table
ON tblTable(TableID,TableName,TableStatus,AreaID);
GO
CREATE PROCEDURE sp_LoadTableByArea
@areaId INT
AS
BEGIN
SELECT TableID,TableName,TableStatus,AreaID FROM tblTable WHERE AreaID=@areaId ORDER BY TableID ASC
END
GO

CREATE PROCEDURE sp_TableList
@areaId INT
AS
BEGIN
SELECT TableID,TableName FROM tblTable WHERE AreaID=@areaId ORDER BY TableID ASC
END
GO

CREATE TABLE tblMenuCategories
(
	MCID INT IDENTITY(1,1),
	MCName NVARCHAR(100)
)
GO
CREATE INDEX idx_menucateGories
ON tblMenuCategories(MCID,MCName)
GO
CREATE PROCEDURE sp_LoadMenuCategories
AS
BEGIN
SELECT MCID,MCName FROM tblMenuCategories
END
GO
CREATE TABLE tblMenu
(
	MenuID INT IDENTITY (1,1),
	MenuName NVARCHAR(100),
	Price FLOAT,
	Discount INT DEFAULT(0),
	MCID INT
)
GO
CREATE INDEX idx_Menu
ON tblMenu(MenuID,MenuName,Price,Discount,MCID)
GO
CREATE PROCEDURE sp_LoadMenu
@mcId INT
AS
BEGIN
SELECT MenuID,MenuName,Price,Discount FROM tblMenu WHERE MCID=@mcId
END
GO

create table tblAccount
(
Username VARCHAR(100),
FullName NVARCHAR(100),
Password VARCHAR(100),
Role VARCHAR(100)
CONSTRAINT PK_Username PRIMARY KEY(Username)
)
GO
CREATE PROCEDURE sp_LoadAccount
AS
BEGIN
SELECT * FROM tblAccount
END
GO
CREATE PROCEDURE sp_AddNewAccount
@username varchar(100),@password varchar(100),@role varchar(100),@fullname nvarchar(100)
AS
BEGIN
INSERT INTO tblAccount(Username,Password,Role,FullName) VALUES(@username,@password,@role,@fullname)
END
GO
CREATE PROCEDURE sp_DeleteAccount
@username varchar(100)
AS
BEGIN
DELETE FROM tblAccount WHERE tblAccount.Username=@username
END
GO
CREATE PROCEDURE sp_ResetPassword
@username varchar(100)
AS
BEGIN
UPDATE tblAccount SET Password='202cb962ac59075b964b07152d234b70' WHERE Username=@username
END
GO


CREATE PROCEDURE sp_LoginCheck
@username varchar(100)
AS
BEGIN
SELECT * FROM tblAccount WHERE Username=@username
END
GO

CREATE TABLE tblReceipt
(
	ReceiptID INT IDENTITY(1,1),
	CreatedDate DATE,
	TotalPayment FLOAT,
	TableID INT,
	ReceiptStatus INT DEFAULT(0), -- 0 là chưa thanh toán 1 là thanh toán rồi 
	PrintReceipt INT DEFAULT(0), -- 0 là chưa in 1 là kích hoạt cho Server in, nếu là 2 thì do Server tính và ko cần làm gì, sau khi in xong sẽ cập nhật nó lên là 3
	CreatedTime VARCHAR(50),
	AccountID VARCHAR(100)
)
GO
CREATE PROCEDURE sp_AddReceipt
@createdDate DATE,@tableId INT
AS
BEGIN
INSERT INTO tblReceipt(CreatedDate,TableID,CreatedTime) VALUES(@createdDate,@tableId,(SELECT CONVERT(VARCHAR(10), GETDATE(), 108)))
UPDATE tblTable SET TableStatus=N'In-Use' WHERE TableID=@tableId
END
GO

CREATE TABLE tblReceiptDetail
(
	RDID INT IDENTITY(1,1),
	ReceiptID INT,
	MenuID INT,
	Quantity INT,
	Discount INT DEFAULT(0)
)
GO

CREATE PROCEDURE sp_AddReceiptDetail
@receiptId INT,@menuId INT,@quantity INT,@discount INT
AS
BEGIN
IF(@menuId IN (SELECT MenuID FROM tblReceiptDetail WHERE ReceiptID=@receiptId AND MenuID=@menuId AND Discount=@discount))
BEGIN
DECLARE @oldQuantity INT,@newQuantity INT,@totalQuantity INT
SET @oldQuantity=(SELECT Quantity FROM tblReceiptDetail WHERE ReceiptID=@receiptId AND MenuID=@menuId AND Discount=@discount)
SET @newQuantity=@quantity
SET @totalQuantity=@oldQuantity+@newQuantity
UPDATE tblReceiptDetail SET Quantity=@totalQuantity WHERE ReceiptID=@receiptId AND MenuID=@menuId AND Discount=@discount
END
ELSE
BEGIN
INSERT INTO tblReceiptDetail(ReceiptID,MenuID,Quantity,Discount) VALUES(@receiptId,@menuId,@quantity,@discount)
END
END
GO

CREATE PROCEDURE sp_DeleteReceiptDetail
@receiptId INT,@menuId INT,@discount INT
AS
BEGIN
DELETE FROM tblReceiptDetail WHERE ReceiptID=@receiptId AND MenuID=@menuId AND Discount=@discount
END
GO
CREATE PROCEDURE sp_LoadMenuListOfTable
@tableId INT,@receiptId INT
AS
BEGIN
SELECT tblMenu.MenuName,tblMenu.Price * ((100 - CAST(tblReceiptDetail.Discount AS FLOAT))/100) AS 'Discount',tblReceiptDetail.Quantity ,tblMenu.MenuID,tblReceiptDetail.Discount,tblMenu.Price AS 'Price',(tblMenu.Price * ((100 - CAST(tblReceiptDetail.Discount AS FLOAT))/100)) * tblReceiptDetail.Quantity AS 'TotalReceipt'
FROM tblReceipt
INNER JOIN tblReceiptDetail on tblReceipt.ReceiptID=tblReceiptDetail.ReceiptID
INNER JOIN tblMenu on tblMenu.MenuID=tblReceiptDetail.MenuID
WHERE tblReceipt.ReceiptID=@receiptId AND tblReceipt.TableID=@tableId
END
GO    

CREATE PROCEDURE sp_LoadMenuListOfTable_rpt
@tableId INT,@receiptId INT,@outTime varchar(50)
AS
BEGIN
SELECT tblMenu.MenuName,tblMenu.Price,tblReceiptDetail.Quantity ,tblMenu.MenuID,tblReceiptDetail.Discount,tblAccount.FullName,tblReceipt.CreatedDate,SUBSTRING(tblReceipt.CreatedTime,1,5) AS 'CreatedTime',tblTable.TableName,tblArea.AreaName,@outTime AS 'OutTime',(tblMenu.Price * ((100 - CAST(tblReceiptDetail.Discount AS FLOAT))/100))*tblReceiptDetail.Quantity AS 'TotalReceipt'
FROM tblReceipt
INNER JOIN tblAccount on tblAccount.Username=tblReceipt.AccountID
INNER JOIN tblTable on tblTable.TableID=tblReceipt.TableID
INNER JOIN tblArea on tblArea.AreaID=tblTable.AreaID
INNER JOIN tblReceiptDetail on tblReceipt.ReceiptID=tblReceiptDetail.ReceiptID
INNER JOIN tblMenu on tblMenu.MenuID=tblReceiptDetail.MenuID
WHERE tblReceipt.ReceiptID=@receiptId AND tblReceipt.TableID=@tableId
END
GO           

exec sp_LoadMenuListOfTable_rpt 51,74,'11:05 PM'
GO
CREATE PROCEDURE sp_LoadMenuListOfTable_Statistics
@receiptId INT
AS
BEGIN
SELECT tblMenu.MenuName,tblMenu.Price * ((100 - CAST(tblReceiptDetail.Discount AS FLOAT))/100) AS 'Price',tblReceiptDetail.Quantity ,tblMenu.MenuID,tblReceiptDetail.Discount
FROM tblReceipt
INNER JOIN tblReceiptDetail on tblReceipt.ReceiptID=tblReceiptDetail.ReceiptID
INNER JOIN tblMenu on tblMenu.MenuID=tblReceiptDetail.MenuID
WHERE tblReceipt.ReceiptID=@receiptId
END
GO        

CREATE PROCEDURE sp_GetReceiptIDByTableAndArea
@tableId INT,@areaId INT
AS
BEGIN
SELECT tblReceipt.ReceiptID
FROM tblReceipt
INNER JOIN tblTable on tblReceipt.TableID=tblTable.TableID
WHERE tblTable.TableID=@tableId AND tblTable.AreaID=@areaId AND tblReceipt.ReceiptStatus=0
END
GO



CREATE PROCEDURE sp_TablePayment
@tableId INT,@receiptId INT,@totalPayment FLOAT,@accountId varchar(50)
AS
BEGIN
UPDATE tblReceipt SET ReceiptStatus=1,TotalPayment=@totalPayment,AccountID=@accountId,PrintReceipt=2 WHERE ReceiptID=@receiptId AND TableID=@tableId
UPDATE tblTable SET TableStatus=N'Empty' WHERE TableID=@tableId
END
GO

CREATE PROCEDURE sp_TablePaymentClient
@tableId INT,@receiptId INT,@totalPayment FLOAT,@accountId varchar(50)
AS
BEGIN
UPDATE tblReceipt SET ReceiptStatus=1,TotalPayment=@totalPayment,AccountID=@accountId,PrintReceipt=1 WHERE ReceiptID=@receiptId AND TableID=@tableId
UPDATE tblTable SET TableStatus=N'Empty' WHERE TableID=@tableId
END
GO

CREATE PROCEDURE sp_AreaListHasEmptyTable
AS
BEGIN
SELECT tblTable.TableName,tblArea.AreaName,tblTable.TableStatus 
FROM tblTable
INNER JOIN tblArea on tblTable.AreaID=tblArea.AreaID
WHERE tblTable.TableStatus=N'Empty'
order by AreaName ASc 
END
GO

--Phần danh mục (WPF)
-- Khu vực

CREATE PROCEDURE sp_LoadAreaList
AS
BEGIN
SELECT tblArea.AreaID,tblArea.AreaName,COUNT(tblTable.TableID) AS 'NumberOfTables'
FROM tblArea
LEFT JOIN tblTable on tblArea.AreaID=tblTable.AreaID
group by tblArea.AreaID,tblArea.AreaName
order by tblArea.AreaID
END
GO
CREATE PROCEDURE sp_AddArea
@areaName nvarchar(200)
AS
BEGIN
INSERT INTO tblArea(AreaName) VALUES (@areaName)
END
GO
CREATE PROCEDURE sp_DeleteArea
@areaId INT
AS
BEGIN
DELETE FROM tblArea WHERE AreaID=@areaId
END
GO
-- Bàn
--CREATE PROCEDURE sp_bANDanhmuc
--@areaId INT
--AS
--BEGIN
--SELECT TableID,TableName FROM tblTable WHERE AreaID=@areaId
--END
--GO
CREATE PROCEDURE sp_AddTable
@tableName nvarchar(50),@areaId INT
AS
BEGIN
INSERT INTO tblTable(TableName,AreaID,TableStatus) VALUES(@tableName,@areaId,N'Empty')
END
GO
CREATE PROCEDURE sp_EditTable
@tableId INT,@tableName nvarchar(50)
AS
BEGIN
UPDATE tblTable SET TableName=@tableName WHERE TableID=@tableId
END
GO
CREATE PROCEDURE sp_DeleteTable
@tableId INT
AS
BEGIN
DELETE FROM tblTable WHERE TableID=@tableId
END
GO
-- Danh mục thực đơn + thực đơn
CREATE PROCEDURE sp_AddMenuCategories
@mcName nvarchar(100)
AS
BEGIN
INSERT INTO tblMenuCategories(MCName) VALUES(@mcName)
END
GO
CREATE PROCEDURE sp_DeleteMenuCategories
@mcId INT
AS
BEGIN
DELETE FROM tblMenuCategories WHERE MCID=@mcId
END
GO
CREATE PROCEDURE sp_AddMenu
@MenuName nvarchar(100),@price FLOAT,@mcId INT
AS
BEGIN
INSERT INTO tblMenu(MenuName,Price,MCID) VALUES(@MenuName,@price,@mcId)
END
GO
CREATE PROCEDURE sp_DeleteMenu
@menuId INT 
AS
BEGIN
DELETE FROM tblMenu WHERE MenuID=@menuId
END
GO

--CREATE PROCEDURE sp_xoachitiettblReceipt
--@receiptId INT,@menuId INT
--AS
--BEGIN
--DELETE FROM tblReceiptDetail WHERE ReceiptID=@receiptId AND MenuID=@menuId
--END
--GO


CREATE PROCEDURE sp_DeleteReceiptWhenOutOfMenu
@receiptId INT,@tableId INT
AS
BEGIN
DELETE FROM tblReceiptDetail WHERE ReceiptID=@receiptId
DELETE FROM tblReceipt WHERE ReceiptID=@receiptId
UPDATE tblTable SET TableStatus=N'Empty' WHERE TableID=@tableId
END
GO

CREATE PROCEDURE sp_LoadEmptyTable
@areaId INT
AS
BEGIN
SELECT * FROM tblTable WHERE TableStatus=N'Empty' AND AreaID=@areaId
END
GO

CREATE PROCEDURE sp_LoadInUseTable
@areaId INT
AS
BEGIN
SELECT * FROM tblTable WHERE TableStatus=N'In-Use'AND AreaID=@areaId
END
GO

CREATE PROCEDURE sp_ChangeTable
@newTableId INT,@oldTableId INT
AS
BEGIN
UPDATE tblReceipt SET TableID=@newTableId WHERE TableID=@oldTableId AND tblReceipt.ReceiptStatus=0
UPDATE tblTable SET TableStatus=N'Empty' WHERE TableID=@oldTableId
UPDATE tblTable SET TableStatus=N'In-Use' WHERE TableID=@newTableId
END
GO


CREATE PROCEDURE [dbo].[sp_LoadMergeTable]
@areaId INT,@tableId INT
AS
BEGIN
SELECT *,tblReceipt.ReceiptID 
FROM tblTable 
INNER JOIN tblReceipt on tblTable.TableID=tblReceipt.TableID
WHERE TableStatus=N'In-Use'AND AreaID=@areaId AND tblTable.TableID<> @tableId AND tblReceipt.ReceiptStatus=0
END
GO

CREATE PROCEDURE sp_LoadMergeTableReceiptDetail
@mergeTableId INT
AS
BEGIN
DECLARE @mergeTableReceipt INT
SET @mergeTableReceipt=(SELECT ReceiptID FROM tblReceipt WHERE TableID=@mergeTableId AND ReceiptStatus=0)
SELECT * FROM tblReceiptDetail WHERE ReceiptID=@mergeTableReceipt
END
GO

CREATE PROCEDURE sp_DeleteMergeTableReceipt
@tableId INT
AS
BEGIN
DECLARE @mergeTableReceipt INT
SET @mergeTableReceipt=(SELECT ReceiptID FROM tblReceipt WHERE TableID=@tableId AND ReceiptStatus=0)
DELETE FROM tblReceiptDetail WHERE ReceiptID=@mergeTableReceipt
DELETE FROM tblReceipt WHERE ReceiptID=@mergeTableReceipt
UPDATE tblTable SET TableStatus=N'Empty' WHERE TableID=@tableId
END
GO

CREATE PROCEDURE sp_AddDiscount
@menuId INT , @discount INT
AS
BEGIN
UPDATE tblMenu SET Discount=@discount WHERE MenuID=@menuId
END
GO

CREATE PROCEDURE sp_DeleteDiscount
@menuId INT
AS
BEGIN
UPDATE tblMenu SET Discount=0 WHERE MenuID=@menuId
END
GO

CREATE PROCEDURE sp_EditMenuPrice
@menuId INT,@price FLOAT
AS
BEGIN
UPDATE tblMenu SET Price=@price WHERE MenuID=@menuId
END
GO

--tài khoản


--Thống kê món theo ngày

CREATE PROCEDURE sp_MenuStatisticsByDay
@day INT
AS
BEGIN
SELECT tblMenu.MenuName,SUM(tblReceiptDetail.Quantity) AS 'Quantity',SUM((tblMenu.Price * ((100 - CAST(tblReceiptDetail.Discount AS FLOAT))/100)) * tblReceiptDetail.Quantity) AS 'Total'
FROM tblReceipt
INNER JOIN tblReceiptDetail on tblReceipt.ReceiptID=tblReceiptDetail.ReceiptID
INNER JOIN tblMenu on tblReceiptDetail.MenuID=tblMenu.MenuID
WHERE tblReceipt.ReceiptStatus=1 AND YEAR(tblReceipt.CreatedDate)=YEAR(GETDATE()) AND MONTH(tblReceipt.CreatedDate)=MONTH(GETDATE()) AND DAY(tblReceipt.CreatedDate)=@day
group by tblMenu.MenuName,tblMenu.Price
order by MenuName
END
GO

--Thống kê món theo tháng
CREATE PROCEDURE sp_MenuStatisticsByMonth
@month INT
AS
BEGIN
SELECT tblMenu.MenuName,SUM(tblReceiptDetail.Quantity) AS 'Quantity',SUM((tblMenu.Price * ((100 - CAST(tblReceiptDetail.Discount AS FLOAT))/100)) * tblReceiptDetail.Quantity) AS 'Total'
FROM tblReceipt
INNER JOIN tblReceiptDetail on tblReceipt.ReceiptID=tblReceiptDetail.ReceiptID
INNER JOIN tblMenu on tblReceiptDetail.MenuID=tblMenu.MenuID
WHERE tblReceipt.ReceiptStatus=1 AND YEAR(tblReceipt.CreatedDate)=YEAR(GETDATE()) AND MONTH(tblReceipt.CreatedDate)=@month
group by tblMenu.MenuName,tblMenu.Price
order by MenuName
END
GO

--Thống kê món theo năm
CREATE PROCEDURE sp_MenuStatisticsByYear
@year date
AS
BEGIN
SELECT tblMenu.MenuName,SUM(tblReceiptDetail.Quantity) AS 'Quantity',SUM((tblMenu.Price * ((100 - CAST(tblReceiptDetail.Discount AS FLOAT))/100)) * tblReceiptDetail.Quantity) AS 'Total'
FROM tblReceipt
INNER JOIN tblReceiptDetail on tblReceipt.ReceiptID=tblReceiptDetail.ReceiptID
INNER JOIN tblMenu on tblReceiptDetail.MenuID=tblMenu.MenuID
WHERE tblReceipt.ReceiptStatus=1 AND tblReceipt.CreatedDate=@year
group by tblMenu.MenuName,tblMenu.Price
order by MenuName
END
GO
--Doanh Thu Theo Ngay
CREATE PROCEDURE sp_RevenueByDay
@day INT
AS
BEGIN
SELECT tblArea.AreaName,tblTable.TableName,tblReceipt.TotalPayment,tblReceipt.CreatedDate,tblReceipt.CreatedTime,tblReceipt.ReceiptID
FROM tblReceipt
INNER JOIN tblTable on tblReceipt.TableID=tblTable.TableID
INNER JOIN tblArea on tblTable.AreaID=tblArea.AreaID
WHERE tblReceipt.ReceiptStatus=1 AND YEAR(tblReceipt.CreatedDate)=YEAR(GETDATE()) AND MONTH(tblReceipt.CreatedDate)=MONTH(GETDATE()) AND DAY(tblReceipt.CreatedDate)=@day
END
GO



--Doanh Thu Theo Tháng
CREATE PROCEDURE sp_RevenueByMonth
@month INT
AS
BEGIN
SELECT tblArea.AreaName,tblTable.TableName,tblReceipt.TotalPayment,tblReceipt.CreatedDate,tblReceipt.CreatedTime,tblReceipt.ReceiptID
FROM tblReceipt
INNER JOIN tblTable on tblReceipt.TableID=tblTable.TableID
INNER JOIN tblArea on tblTable.AreaID=tblArea.AreaID
WHERE tblReceipt.ReceiptStatus=1 AND YEAR(tblReceipt.CreatedDate)=YEAR(GETDATE()) AND MONTH(tblReceipt.CreatedDate)=@month
END
GO

--Doanh Thu Theo Năm 
CREATE PROCEDURE sp_RevenueByYear
@year date
AS
BEGIN
SELECT tblArea.AreaName,tblTable.TableName,tblReceipt.TotalPayment,tblReceipt.CreatedDate,tblReceipt.CreatedTime,tblReceipt.ReceiptID
FROM tblReceipt
INNER JOIN tblTable on tblReceipt.TableID=tblTable.TableID
INNER JOIN tblArea on tblTable.AreaID=tblArea.AreaID
WHERE tblReceipt.ReceiptStatus=1 AND tblReceipt.CreatedDate=@year
END
GO

CREATE PROCEDURE sp_UpdatePrintedReceipt
@receiptId INT
AS
BEGIN
UPDATE tblReceipt SET PrintReceipt=3 WHERE ReceiptID=@receiptId
END
GO

CREATE PROCEDURE sp_LoadReceiptToBePrinted
AS
BEGIN
SELECT ReceiptID,PrintReceipt,TableID 
FROM tblReceipt
WHERE tblReceipt.ReceiptStatus=1 AND tblReceipt.PrintReceipt=1 AND CreatedDate=CAST(GETDATE() AS date)
END
GO

DELETE FROM tblArea
DELETE FROM tblTable
DELETE FROM tblMenuCategories
DELETE FROM tblMenu
DELETE FROM tblReceiptDetail
DELETE FROM tblReceipt