CREATE TABLE [dbo].[tblInvoices] (
    [Id]      INT             IDENTITY (1, 1) NOT NULL,
    [Number]  NVARCHAR (100)  NOT NULL,
    [Value]   DECIMAL (10, 2) NOT NULL,
    [OwnerId] INT             NOT NULL,
    [FlatId]  INT             NOT NULL,
    [AddDate] DATETIME        CONSTRAINT [DF_tblInvoices_AddDate] DEFAULT (getdate()) NOT NULL,
    [AddUser] NVARCHAR (128)  CONSTRAINT [DF_tblInvoices_AddUser] DEFAULT (suser_sname()) NOT NULL,
    [ModDate] DATETIME        NULL,
    [ModUser] NVARCHAR (128)  NULL,
    [Active]  BIT             CONSTRAINT [DF_tblInvoices_Active] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_tblInvoices] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_tblInvoices_tblFlats] FOREIGN KEY ([FlatId]) REFERENCES [dbo].[tblFlats] ([Id]),
    CONSTRAINT [FK_tblInvoices_tblOwners] FOREIGN KEY ([OwnerId]) REFERENCES [dbo].[tblOwners] ([Id]),
    CONSTRAINT [UX_tblInvoices_Number] UNIQUE NONCLUSTERED ([Number] ASC)
);


GO

--- <summary>
--- Log date and system user
--- </summary>
--- <param name="Id">ID filmu</param>
--- <event author="Oskar Wielanowski" date="30.05.2020" project="Zaliczenie">Trigger Created/event>
CREATE	TRIGGER [dbo].[trgInvoicesAfterUpdate]
ON	[dbo].[tblInvoices]
AFTER	UPDATE

AS

BEGIN
	SET	NOCOUNT ON

    UPDATE	X
    SET	ModDate = GETDATE(),
		ModUser = SYSTEM_USER
	FROM [dbo].[tblInvoices] X
	INNER JOIN inserted I
		ON	I.[Id] = X.[Id]

END
