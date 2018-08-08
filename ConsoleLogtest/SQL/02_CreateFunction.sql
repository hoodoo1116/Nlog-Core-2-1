/****** Object:  UserDefinedFunction [dbo].[udf_DemotableSearch]    Script Date: 8/7/2018 4:59:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[udf_DemotableSearch]
(
	@Id INT,
	@DateOf DATE,
	@Value nvarchar(50)
)
RETURNS TABLE
AS
RETURN
(
	WITH VarVal AS (
		SELECT 
			Id, 
			DateOf, 
			Value 
		FROM 
			DemoTable
	)
	SELECT
		Id, 
		DateOf, 
		Value
	FROM 
		VarVal
	WHERE
		Id = @Id
		AND DateOf = @DateOf
		AND Value = @Value
)
GO