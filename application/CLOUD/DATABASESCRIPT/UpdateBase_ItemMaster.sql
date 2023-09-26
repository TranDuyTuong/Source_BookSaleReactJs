CREATE PROCEDURE UpdateBase_ItemMaster
@StoreCode				nvarchar(10),
@ItemCode				nvarchar(26),
@ApplyDate				datetime2(7),
@Description			nvarchar(50),
@DescriptionShort		nvarchar(25),
@DescriptionLong		nvarchar(100),
@Quantity				int,
@CategoryItemMasterID	nvarchar(MAX),
@AuthorID				nvarchar(MAX),
@size					nvarchar(100),
@PublishingCompanyID	nvarchar(MAX),
@Note					nvarchar(MAX),
@UserID					nvarchar(MAX)
AS
BEGIN
-- Update ItemMaster
Update TXTCloud.dbo.ItemMasters
SET 
	StoreCode = @StoreCode, 
	Description = @Description, 
	DescriptionShort = @DescriptionShort, 
	DescriptionLong = @DescriptionLong,
	Quantity = @Quantity, 
	CategoryItemMasterID = @CategoryItemMasterID, 
	AuthorID = @AuthorID, 
	size = @size,
	PublishingCompanyID = @PublishingCompanyID, 
	Note = @Note, 
	UserID = @UserID,
	LastUpdateDate = GETDATE()
WHERE 
		TXTCloud.dbo.ItemMasters.ItemCode = @ItemCode 
	AND TXTCloud.dbo.ItemMasters.ApplyDate = @ApplyDate

-- Insert Log Update
INSERT INTO TXTCloud.dbo.Logs(
	Id,
	UserID,
	Message, 
	DateCreate, 
	Status
)
VALUES(
	NEWID(),
	@UserID,
	N'Success: Update ' + @ItemCode + ' , success',
	GETDATE(),
	1
)
END
GO
