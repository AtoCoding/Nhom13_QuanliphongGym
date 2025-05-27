CREATE TABLE [dbo].[SanPham] (
    [id_sp]     NVARCHAR (30)   NOT NULL,
    [ten]       NVARCHAR (30)   NOT NULL,
    [loai]      NVARCHAR (30)   NOT NULL,
	[ngaynhap] date not null,
    [soluong]   int   NOT NULL,
    [dongia]    int   NOT NULL,
    [trongluong] NVARCHAR (30)   NOT NULL,
    [hangsx] nvarchar (30)             NOT NULL,
    [tinhtrang]    NVARCHAR (50)   NOT NULL,
    [hinhanh]   VARBINARY (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([id_sp] ASC)
);
