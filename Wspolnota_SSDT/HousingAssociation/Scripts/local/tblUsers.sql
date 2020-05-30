MERGE [config].[tblUsers]  AS TARGET
		USING
		(
			VALUES
			(
				'Admin',
				'SuperAdministratorAplikacji#0', /* ze wzgledu na wygodę haseł nie hashuje po stronie bazy */
				1, /* [IsAdmin] DEFAULT = 0 */
				1 /* [Active] DEFAULT = 1 */
			),
			(
				'Administrator',
				'AdministratorBudynku#1',
				1,
				1
			),
			(  
				'Wlasciciel1',
				'WlascicielPierszegoMieszkania@1',
				0,
				1
			),
			(  
				'Wlasciciel2',
				'WlascicielDrugiegoMieszkania@2',
				0,
				1
			),
			(  
				'Inwestor',
				'WlascicielPozostalych14MKieszkan@3_17',
				0,
				1
			)
		)
		AS SOURCE
		(
			[Login], [Password], [IsAdmin], [Active]
		)
		ON
		(
			TARGET.[Login] = SOURCE.[Login]
		)
		/* KEEP DATA CHANGED BY ADMIN */
		/*
		WHEN MATCHED 
		AND (	TARGET.[Password] != SOURCE.[Password] 
			OR TARGET.[IsAdmin] != SOURCE.[IsAdmin]
			OR TARGET.[Active] != SOURCE.[Active] )
		THEN
			UPDATE SET	[Password] = SOURCE.[Password],
						[IsAdmin] = SOURCE.[IsAdmin],
						[Active] = SOURCE.[Active]
		*/
		WHEN NOT MATCHED BY TARGET
		THEN INSERT
		(
			[Login],
			[Password],
			[IsAdmin],
			[Active]
		)
		VALUES
		(
			SOURCE.[Login],
			SOURCE.[Password],
			SOURCE.[IsAdmin],
			SOURCE.[Active]
		)
		/* KEEP DATA ADDED BY ADMIN */
		/*
		WHEN NOT MATCHED BY SOURCE
		THEN DELETE
		*/
;