

--- <summary>
--- View Owners with Login and Password
--- </summary>
--- <param name="Id">ID filmu</param>
--- <event author="Oskar Wielanowski" date="30.05.2020" project="Zaliczenie">View Created/event>
CREATE VIEW [dbo].[vwOwners]
	AS 
	SELECT	 O.[FirstName]
			,O.[LastName]
			,O.[Email] 
			,U.[Login]
			,U.[Password]
			,O.[Active] AS [OwnerActive]
			,U.[Active] AS [UserActive]
					
	FROM	[dbo].[tblOwners] O
	INNER JOIN
		[config].[tblUsers] U
	ON O.UserId = U.Id 
	WITH CHECK OPTION;
