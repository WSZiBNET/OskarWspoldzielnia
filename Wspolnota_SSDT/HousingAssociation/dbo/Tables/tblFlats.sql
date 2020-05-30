CREATE TABLE [dbo].[tblFlats] (
    [Id]           INT              IDENTITY (1, 1) NOT NULL,
    [Number]       NVARCHAR (100)   NOT NULL,
    [Geometry]     [sys].[geometry] CONSTRAINT [DF_tblFlats_Geometry] DEFAULT ('POLYGON((0 0, 8 0, 8 11, 0 11, 0 0))') NOT NULL,
    [SurfaceArea]  AS               (isnull([Geometry].[STArea](),(0))) PERSISTED NOT NULL,
    [GeometryDesc] AS               ([Geometry].[STAsText]()),
    [Map]          IMAGE            NULL,
    [OwnerId]      INT              NOT NULL,
    [AddDate]      DATETIME         CONSTRAINT [DF_tblFlats_AddDate] DEFAULT (getdate()) NOT NULL,
    [AddUser]      NVARCHAR (128)   CONSTRAINT [DF_tblFlats_AddUser] DEFAULT (suser_sname()) NOT NULL,
    [ModDate]      DATETIME         NULL,
    [ModUser]      NVARCHAR (128)   NULL,
    [Active]       BIT              CONSTRAINT [DF_tblFlats_Active] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_tblFlats] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_tblFlats_tblOwners] FOREIGN KEY ([OwnerId]) REFERENCES [dbo].[tblOwners] ([Id])
);


GO

--- <summary>
--- Log date and system user
--- </summary>
--- <param name="Id">ID filmu</param>
--- <event author="Oskar Wielanowski" date="30.05.2020" project="Zaliczenie">Trigger Created/event>
CREATE	TRIGGER [dbo].[trgflatsAfterUpdate]
ON	[dbo].[tblFlats]
AFTER	UPDATE

AS

BEGIN
	SET	NOCOUNT ON

    UPDATE	X
    SET	ModDate = GETDATE(),
		ModUser = SYSTEM_USER
	FROM [dbo].[tblFlats] X
	INNER JOIN inserted I
		ON	I.[Id] = X.[Id]

END
