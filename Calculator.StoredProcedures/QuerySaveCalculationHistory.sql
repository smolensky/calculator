IF EXISTS(SELECT * FROM sys.objects WHERE name = 'SaveCalculationHistory')
BEGIN
	PRINT('Dropping SaveCalculationHistory')
	DROP PROC SaveCalculationHistory
END

GO

CREATE PROC SaveCalculationHistory 
	@FirstNumber DECIMAL(18,8),
	@SecondNumber DECIMAL(18,8),
	@ActionTypeId INT,
	@Result DECIMAL(18,8)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[CalculationHistory]
	VALUES (@FirstNumber
			,@SecondNumber
			,@ActionTypeId
			,@Result
			,GETUTCDATE()
			,1)
END