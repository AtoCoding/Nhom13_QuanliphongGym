create table [dbo].[tblChitietHDBanSp]
(
[id_hdsp] NVARCHAR (20) NOT NULL,
[id_sp] NVARCHAR (20) NOT NULL,
[soluong] int NOT NULL,
[dongia] int NOT NULL,
[thanhtien] int NOT NULL,
primary key clustered ([id_hdsp] ASC,[id_sp] ASC)
);
