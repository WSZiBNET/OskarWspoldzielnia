CREATE TABLE [dbo].[tblOwners] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (100) NOT NULL,
    [LastName]  NVARCHAR (100) NOT NULL,
    [Email]     NVARCHAR (100) NULL,
    [UserId]    INT            NOT NULL,
    [AddDate]   DATETIME       CONSTRAINT [DF_tblOwners_AddDate] DEFAULT (getdate()) NOT NULL,
    [AddUser]   NVARCHAR (128) CONSTRAINT [DF_tblOwners_AddUser] DEFAULT (suser_sname()) NOT NULL,
    [ModDate]   DATETIME       NULL,
    [ModUser]   NVARCHAR (128) NULL,
    [Active]    BIT            CONSTRAINT [DF_tblOwners_Active] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_tblOwners] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_tblOwners_tblUsers] FOREIGN KEY ([UserId]) REFERENCES [config].[tblUsers] ([Id]),
    CONSTRAINT [UX_tblOwners_Name] UNIQUE NONCLUSTERED ([FirstName] ASC, [LastName])
);


GO

--- <summary>
--- Log date and system user
--- </summary>
--- <param name="Id">ID filmu</param>
--- <event author="Oskar Wielanowski" date="30.05.2020" project="Zaliczenie">Trigger Created/event>
CREATE	TRIGGER [dbo].[trgOwnersAfterUpdate]
ON	[dbo].[tblOwners]
AFTER	UPDATE

AS

BEGIN
	SET	NOCOUNT ON

    UPDATE	X
    SET	ModDate = GETDATE(),
		ModUser = SYSTEM_USER
	FROM [dbo].[tblOwners] X
	INNER JOIN inserted I
		ON	I.[Id] = X.[Id]

END
