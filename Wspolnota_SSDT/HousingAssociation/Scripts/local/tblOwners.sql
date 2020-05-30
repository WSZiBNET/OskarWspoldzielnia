MERGE [dbo].[tblOwners] AS TARGET
		USING
		(
			VALUES
			(  
				'Marek',
				'Markowski',
				'markowski@wspoldzielnia.com',
				3,
				1
			),
			(  
				'Jan',
				'Kowalski',
				'kowalski@wspoldzielnia.com',
				4,
				1
			),
			(  
				'Piotr',
				'Nowak',
				'nowak@wspoldzielnia.com',
				5,
				1
			)
		)
		AS SOURCE
		(
			[FirstName], [LastName], [Email], [UserId], [Active]
		)
		ON
		(
			TARGET.[UserId] = SOURCE.[UserId]
		)
		/* KEEP DATA CHANGED BY ADMIN */
		/*
		WHEN MATCHED 
		AND (	TARGET.[FirstName] != SOURCE.[FirstName] 
			OR TARGET.[LastName] != SOURCE.[LastName]
			OR TARGET.[Email] != SOURCE.[Email]
			OR TARGET.[Active] != SOURCE.[Active])
		THEN
			UPDATE SET  [FirstName] = SOURCE.[FirstName], 
						[LastName]	= SOURCE.[LastName],
						[Email]		= SOURCE.[Email],
						[Active]	= SOURCE.[Active]
		*/
		WHEN NOT MATCHED BY TARGET
		THEN INSERT
		(
			[FirstName],
			[LastName],	
			[Email],
			[UserId],
			[Active]	
		)
		VALUES
		(
			SOURCE.[FirstName],
			SOURCE.[LastName],
			SOURCE.[Email],
			SOURCE.[UserId],
			SOURCE.[Active]
		)
		/* KEEP DATA ADDED BY ADMIN */
		/*
		WHEN NOT MATCHED BY SOURCE
		THEN DELETE
		*/
;