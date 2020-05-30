CREATE TABLE [config].[tblUsers] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Login]    NVARCHAR (100) NOT NULL,
    [Password] NVARCHAR (100) NULL,
    [AddDate]  DATETIME       CONSTRAINT [DF_tblUsers_AddDate] DEFAULT (getdate()) NOT NULL,
    [AddUser]  NVARCHAR (128) CONSTRAINT [DF_tblUsers_AddUser] DEFAULT (suser_sname()) NOT NULL,
    [ModDate]  DATETIME       NULL,
    [ModUser]  NVARCHAR (128) NULL,
    [IsAdmin]  BIT            CONSTRAINT [DF_tblUsers_IsAdmin] DEFAULT ((0)) NOT NULL,
    [Active]   BIT            CONSTRAINT [DF_tblUsers_Active] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_tblUsers] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO


--- <summary>
--- Log date and system user
--- </summary>
--- <param name="Id">ID filmu</param>
--- <event author="Oskar Wielanowski" date="30.05.2020" project="Zaliczenie">Trigger Created/event>
CREATE	TRIGGER [config].[trgUsersAfterUpdate]
ON	[config].[tblUsers]
AFTER	UPDATE

AS

BEGIN
	SET	NOCOUNT ON

    UPDATE	X
    SET	ModDate = GETDATE(),
		ModUser = SYSTEM_USER
	FROM [config].[tblUsers] X
	INNER JOIN inserted I
		ON	I.[Id] = X.[Id]

END
