CREATE TABLE [dbo].[TipoUsuario]
(
    [IdTipoUsuario] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    [DescricaoTipoUsuario] NVARCHAR(13) NOT NULL 

);


CREATE TABLE [dbo].[Usuario] (
    [IdUsuario] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    [NomeUsuario] NVARCHAR (50) NOT NULL,
    [CpfUsuario] NVARCHAR (14) UNIQUE NOT NULL,
    [SenhaUsuario] NVARCHAR (6) NOT NULL,
    [DataNascUsuario] NVARCHAR (10) NOT NULL,
    [TipoUsuario]INT NOT NULL,
	
   FOREIGN KEY (TipoUsuario) REFERENCES TipoUsuario(IdTipoUsuario)
);


CREATE TABLE [dbo].[Classificacao]
(
    [IdClassificacao] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    [DescricaoClassificacao] NVARCHAR(5) NOT NULL 

);


CREATE TABLE [dbo].[Filme] (
    [IdFilme] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    [TituloFilme] NVARCHAR (50) NOT NULL,
    [GeneroFilme] NVARCHAR (50) NOT NULL,
    [ProdutoraFilme] NVARCHAR (50) NOT NULL,
	[UrlImgFilme] NVARCHAR (MAX) NOT NULL,
    [ClassificacaoFilme]INT NOT NULL,
	
   FOREIGN KEY (ClassificacaoFilme) REFERENCES Classificacao(IdClassificacao)
);

SELECT IdUsuario, NomeUsuario, CpfUsuario, SenhaUsuario, DataNascUsuario, DescricaoTipoUsuario FROM Usuario JOIN TipoUsuario ON TipoUsuario = IdTipoUsuario;


--INSERT
INSERT INTO Usuario VALUES('Cerjio','111.111.111-01','111111','20/02/2001','~/Imagens/img1.jpg',1);
INSERT INTO Usuario VALUES('Marsia','111.111.111-02','222222','20/02/2002','~/Imagens/img2.jpg',2);
INSERT INTO Usuario VALUES('Jandiro','111.111.111-03','333333','20/02/2003','~/Imagens/img3.jpg',2);
INSERT INTO Usuario VALUES('Heleno','111.111.111-04','444444','20/02/2004','~/Imagens/img4.jpg',2);


--INSERT
INSERT INTO TipoUsuario VALUES('Administrador');
INSERT INTO TipoUsuario VALUES('Outros');

SELECT * FROM Usuario;
SELECT * FROM TipoUsuario;