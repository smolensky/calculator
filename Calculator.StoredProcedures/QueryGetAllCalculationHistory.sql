IF EXISTS(SELECT * FROM sys.objects WHERE name = 'GetAllCalculationHistory')
BEGIN
	PRINT('Dropping GetAllCalculationHistory')
	DROP PROC GetAllCalculationHistory
END

GO

CREATE PROC GetAllCalculationHistory 
AS

SELECT [h].[FirstNumber]
		,[t].[ActionType]
		,[h].[SecondNumber]
		,[h].[Result]
FROM [dbo].[CalculationHistory] AS h
	INNER JOIN [dbo].[ActionType] AS t
		ON [h].[ActionTypeId] = [t].[Id]