MERGE [dbo].[tblFlats] AS TARGET
		USING
		(
			VALUES
			(  
				'M1',
				'POLYGON((0 0, 8 0, 8 11, 0 11, 0 0))',
				NULL,
				1,
				1
			),
			(  
				'M2',
				'POLYGON((0 0, 9 0, 9 10, 0 10, 0 0))',
				NULL,
				2,
				1
			),
			(  
				'M3',
				'POLYGON((0 0, 8 0, 8 11, 0 11, 0 0))',
				NULL,
				3,
				1
			),
			(  
				'M4',
				'POLYGON((0 0, 8 0, 8 11, 0 11, 0 0))',
				NULL,
				3,
				1
			),
			(  
				'M5',
				'POLYGON((0 0, 8 0, 8 11, 0 11, 0 0))',
				NULL,
				3,
				1
			),
			(  
				'M6',
				'POLYGON((0 0, 8 0, 8 11, 0 11, 0 0))',
				NULL,
				3,
				1
			),
			(  
				'M7',
				'POLYGON((0 0, 8 0, 8 11, 0 11, 0 0))',
				NULL,
				3,
				1
			),
			(  
				'M8',
				'POLYGON((0 0, 8 0, 8 11, 0 11, 0 0))',
				NULL,
				3,
				1
			),
			(  
				'M9',
				'POLYGON((0 0, 8 0, 8 11, 0 11, 0 0))',
				NULL,
				3,
				1
			),
			(  
				'M10',
				'POLYGON((0 0, 8 0, 8 11, 0 11, 0 0))',
				NULL,
				3,
				1
			),
			(  
				'M11',
				'POLYGON((0 0, 8 0, 8 11, 0 11, 0 0))',
				NULL,
				3,
				1
			),
			(  
				'M12',
				'POLYGON((0 0, 8 0, 8 11, 0 11, 0 0))',
				NULL,
				3,
				1
			),
			(  
				'M13',
				'POLYGON((0 0, 8 0, 8 11, 0 11, 0 0))',
				NULL,
				3,
				1
			),
			(  
				'M14',
				'POLYGON((0 0, 8 0, 8 11, 0 11, 0 0))',
				NULL,
				3,
				1
			),
			(  
				'M15',
				'POLYGON((0 0, 8 0, 8 11, 0 11, 0 0))',
				NULL,
				3,
				1
			),
			(  
				'M16',
				'POLYGON((0 0, 8 0, 8 11, 0 11, 0 0))',
				NULL,
				3,
				1
			),
			(  
				'M17',
				'POLYGON((0 0, 8 0, 8 11, 0 11, 0 0))',
				NULL,
				3,
				1
			)
		)
		AS SOURCE
		(	
			[Number], [Geometry], [Map], [OwnerId], [Active]
		)
		ON
		(
			TARGET.[Number] = SOURCE.[Number]
		)
		/* KEEP DATA CHANGED BY ADMIN */
		/*
		WHEN MATCHED 
		AND (	TARGET.[Geometry]	!= SOURCE.[Geometry] 
			OR TARGET.[Map]			!= SOURCE.[Map]
			OR TARGET.[OwnerId]		!= SOURCE.[OwnerId]
			OR TARGET.[Active]		!= SOURCE.[Active])
		THEN
			UPDATE SET  [Geometry]	= SOURCE.[Geometry],
						[Map]		= SOURCE.[Map],
						[OwnerId]	= SOURCE.[OwnerId],
						[Active]	= SOURCE.[Active]
		*/
		WHEN NOT MATCHED BY TARGET
		THEN INSERT
		(
			[Number],
			[Geometry],
			[Map],	
			[OwnerId],
			[Active]	
			
		)
		VALUES
		(
			SOURCE.[Number],
			SOURCE.[Geometry],
			SOURCE.[Map],	
			SOURCE.[OwnerId],
			SOURCE.[Active]	
		)
		/* KEEP DATA ADDED BY ADMIN */
		/*
		WHEN NOT MATCHED BY SOURCE
		THEN DELETE
		*/
;