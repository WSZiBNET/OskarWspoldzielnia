MERGE [dbo].[tblInvoices] AS TARGET
		USING
		(
			VALUES
			(  
				'FA-1',
				'100',
				3,
				1,
				1
			),		
			(  
				'FA-2',
				'100',
				2,
				2,
				1
			),
			(  
				'FA-3',
				'100',
				3,
				3,
				1
			),
			(  
				'FA-4',
				'100',
				3,
				4,
				1
			),
			(  
				'FA-5',
				'100',
				3,
				5,
				1
			),
			(  
				'FA-6',
				'100',
				3,
				6,
				1
			),
			(  
				'FA-7',
				'100',
				3,
				7,
				1
			),
			(  
				'FA-8',
				'100',
				3,
				8,
				1
			),
			(  
				'FA-9',
				'100',
				3,
				9,
				1
			),
			(  
				'FA-10',
				'100',
				3,
				10,
				1
			),
			(  
				'FA-11',
				'100',
				3,
				11,
				1
			),
			(  
				'FA-12',
				'100',
				3,
				12,
				1
			),
			(  
				'FA-13',
				'100',
				3,
				13,
				1
			),
			(  
				'FA-14',
				'100',
				3,
				14,
				1
			),
			(  
				'FA-15',
				'100',
				3,
				15,
				1
			),
			(  
				'FA-16',
				'100',
				3,
				16,
				1
			),
			(  
				'FA-17',
				'100',
				3,
				17,
				1
			)
		)
		AS SOURCE
		(
			[Number], [Value], [OwnerId], [FlatId], [Active]
		)
		ON
		(
			TARGET.[Number] = SOURCE.[Number]
		)
		/* KEEP DATA CHANGED BY ADMIN */
		/*
		WHEN MATCHED 
		AND (	TARGET.[Value]	!= SOURCE.[Value] 
			OR TARGET.[OwnerId] != SOURCE.[OwnerId]
			OR TARGET.[FlatId]	!= SOURCE.[FlatId]
			OR TARGET.[Active]	!= SOURCE.[Active])
		THEN
			UPDATE SET  [Value]		= SOURCE.[Value], 
						[OwnerId]	= SOURCE.[OwnerId],
						[FlatId]	= SOURCE.[FlatId],
						[Active]	= SOURCE.[Active]
		*/
		WHEN NOT MATCHED BY TARGET
		THEN INSERT
		(
			[Number],
			[Value], 
			[OwnerId],
			[FlatId],
			[Active]
		)
		VALUES
		(
			SOURCE.[Number],
			SOURCE.[Value], 
			SOURCE.[OwnerId],
			SOURCE.[FlatId],
			SOURCE.[Active]
		)
		/* KEEP DATA ADDED BY ADMIN */
		/*
		WHEN NOT MATCHED BY SOURCE
		THEN DELETE
		*/
;