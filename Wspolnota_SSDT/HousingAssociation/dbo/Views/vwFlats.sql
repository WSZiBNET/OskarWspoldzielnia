

--- <summary>
--- Show Flats
--- </summary>
--- <param name="Id">ID filmu</param>
--- <event author="Oskar Wielanowski" date="30.05.2020" project="Zaliczenie">View Created/event>
CREATE VIEW [dbo].[vwFlats]
WITH SCHEMABINDING  
AS 
	SELECT	 [Id]
			,[Number]
			,[GeometryDesc] as [Geometry]
			,[SurfaceArea]
			,[Map]
			,[OwnerId]
		FROM [dbo].[tblFlats]		
		WITH CHECK OPTION;