CREATE TABLE Pessoa (
IDPessoa int identity (1,1) primary key,
Nome varchar (200),
Telefone char (14),
Celular char (14) NOT NULL,
Email varchar (200),
Logradouro varchar(300) NOT NULL,
Bairro varchar(20) NOT NULL,
Cidade varchar (20) NOT NULL,
UF varchar (2) NOT NULL,
CEP varchar (9) NOT NULL,
Numero varchar (10),
Complemento varchar (50),
Categoria varchar (2),
LoginPessoa varchar(50),
SenhaPessoa varchar(50),
);
select * from Pessoa
go

drop table Funcionario

CREATE TABLE ClientePF (
IDClientePF int identity (1,1),
IDPessoa int,
dataNascimento datetime NOT NULL,
Sexo varchar(1) NOT NULL,
RG char (12) NOT NULL,
CPF char (14) NOT NULL,
CNH char (11) NOT NULL,
constraint IDPessoa_fk foreign key (IDPessoa) references Pessoa (IDPessoa)
);

go

CREATE TABLE ClientePJ(
IDClientePJ int identity (1,1),
IDPessoa int,
CNPJ CHAR(18)NOT NULL,
RazaoSocial VARCHAR(200)NOT NULL,
constraint IDPessoa_fk2 foreign key (IDPessoa) references Pessoa (IDPessoa)
);


go

CREATE TABLE Funcionario (
IDFuncionario int identity (1,1) primary key,
IDPessoa int,
dataNascimento datetime NOT NULL,
Sexo varchar(1) NOT NULL,
RG varchar (12) NOT NULL,
CPF varchar (14) NOT NULL,
Cargo varchar (100),
constraint IDPessoa_fk4 foreign key (IDPessoa) references Pessoa (IDPessoa)
);
select * from Funcionario
go

drop table Locacao
go

CREATE TABLE Veiculo (
IDVeiculo int identity (1,1) primary key,
Placa varchar (8) NOT NULL,
Nome varchar (20) NOT NULL,
Ano int NOT NULL,
Marca varchar (30) NOT NULL,
Categoria varchar (7) NOT NULL,
CapacidadePortaMalas varchar NOT NULL,
AirBag varchar (3) NOT NULL,
QuantidadeAirBag int NOT NULL,
Direcao varchar (3) NOT NULL,
CapacidadePassageiros int NOT NULL,
ArCondicionado varchar NOT NULL,
Portas int NOT NULL,
Cambio varchar(15) NOT NULL,
VidroEletrico varchar(3) NOT NULL,
TravaEletrica varchar(3) NOT NULL,
FreioABS varchar(3) NOT NULL,
StatusVeiculo varchar (50)NOT NULL,
Km varchar(100),
Situacao varchar(100)

);

go

CREATE TABLE Locacao (
IDLocacao int identity (1,1),
IDFuncionario int NOT NULL,
IDCarro int NOT NULL,
IDReserva int NOT NULL,
ValorSinal decimal (10,2),
Situacao varchar (100),
ValorTotal decimal(10,2),
FormaPagamento varchar(100),
DataFinalizacao datetime,
PagamentoFinal varchar(100)
constraint pk_IDLocacao primary key (IDLocacao),
constraint fk_Funcionario_Locacao foreign key (IDFuncionario) references Funcionario (IDFuncionario),
constraint fk_Carro_Locacao foreign key (IDCarro) references Veiculo (IDVeiculo),
constraint fk_Reserva_Locacao foreign key (IDReserva) references Nova_Reserva (IDReserva)
);
go

insert into Funcionario values ('Victor', '29/11/2000', 'M', '560783589', '36652278871', '', '991143790', '', 'Rua Bento Antonio Dumont', '40', 'Casa 04', 'Vila Voturua', 'São Vicente', 'SP', '11380330', 'Administrador', 'victor.augustus', '29112000')
alter table Locacao add PagamentoFinal varchar(100)
go

create procedure ps_funcionario (
@LoginPessoa varchar(50),
@SenhaPessoa varchar(20)
)
as
select * from Pessoa where LoginPessoa = @LoginPessoa and SenhaPessoa = @SenhaPessoa and Categoria = 'FU'

go

drop procedure pi_Cliente

go

create procedure pi_Cliente (
@Nome varchar (200),
@Telefone char (14) = null,
@Celular char (14) = null,
@Email varchar (200),
@Logradouro varchar(300),
@Bairro varchar(20),
@Cidade varchar (20),
@UF varchar (2),
@CEP varchar (9),
@Numero varchar (10),
@Complemento varchar (50),
@Categoria varchar (2),
@LoginPessoa varchar(50),
@SenhaPessoa varchar(50),
@dataNascimento datetime = null,
@Sexo varchar(1) = null,
@RG char (12) = null,
@CPF char (14) = null,
@CNH char (11) = null,
@CNPJ CHAR(18) = null,
@RazaoSocial VARCHAR(200) = null
)

as

insert into Pessoa (Nome, Telefone, Celular, Email, Logradouro, Bairro, Cidade, UF, CEP, Numero, Complemento, Categoria, LoginPessoa, SenhaPessoa)
values (@Nome, @Telefone, @Celular, @Email, @Logradouro, @Bairro, @Cidade, @UF, @CEP, @Numero, @Complemento, @Categoria, @LoginPessoa, @SenhaPessoa)

declare @ID int
select @ID = max(IDPessoa) from Pessoa

if @Categoria = 'PF' 
insert into ClientePF (IDPessoa, dataNascimento, Sexo, RG, CPF, CNH)
values (@ID, @dataNascimento, @Sexo, @RG, @CPF, @CNH)

else if @Categoria = 'PJ' 
insert into ClientePJ (IDPessoa, CNPJ, RazaoSocial)
values (@ID, @CNPJ, @RazaoSocial)
 

go


select * from Pessoa
select * from ClientePF
select * from locacao

drop view vw_clientes_pf_pj

go

CREATE VIEW vw_clientes_pf_pj
AS
SELECT p.IDPessoa, p.Categoria, p.Nome, pf.Sexo, pf.dataNascimento, pf.CPF, pf.RG, pf.CNH, pj.CNPJ, pj.RazaoSocial, p.Logradouro, p.Numero, 
p.Complemento, p.Cidade, p.Bairro, p.UF, p.CEP, p.Celular, p.Telefone, p.Email, p.LoginPessoa, p.SenhaPessoa
FROM Pessoa p
left join ClientePF pf on pf.IDPessoa = p.IDPessoa
left join ClientePJ pj on pj.IDPessoa = p.IDPessoa

go
drop view vw_locacao
create view vw_locacao
as
select l.IDLocacao, l.IDFuncionario, l.IDReserva, r.DtHoraRetirada, r.DtHoraDevol, r.NomeCliente, r.CPFCliente, r.CNH, r.CNPJ,
r.RazaoSocial, r.Celular, r.Categoria, l.ValorSinal, l.IDCarro, v.Nome, v.Placa, v.Km, r.KmDesejado, r.KmExtra, r.BebeConforto, r.QuantidadeBebe,
r.CadeiraBebe, r.QuantidadeCadeira, r.AssentoElevado, r.QuantidadeAssento, l.ValorTotal, l.FormaPagamento from Locacao l
left join Funcionario f on f.IDFuncionario = l.IDFuncionario
left join Veiculo v on v.IDVeiculo = l.IDCarro
left join Nova_Reserva r on r.IDReserva = l.IDReserva

go

create proc ps_locacao
@IDLocacao int

as

select * from vw_locacao where IDLocacao = @IDLocacao

go
select * from Nova_Reserva

drop procedure ps_cliente_pf_pj

create procedure ps_cliente_pf_pj
@CPF VARCHAR(14) = null,
@CNPJ CHAR(18) = null


AS

if @CPF is null
SELECT * FROM vw_clientes_pf_pj WHERE  CNPJ= @CNPJ

else if @CNPJ is null
select * from vw_clientes_pf_pj where CPF = @CPF
SELECT * FROM sys.procedures

drop procedure pu_cliente

go 

create procedure pu_cliente
@IDPessoa int,
@Nome varchar (200),
@Telefone char (14),
@Celular char (14),
@Email varchar (200),
@Logradouro varchar(300),
@Bairro varchar(20),
@Cidade varchar (20),
@UF varchar (2),
@CEP varchar (9),
@Numero varchar (10),
@Complemento varchar (50),
@Categoria varchar (2),
@SenhaPessoa varchar(50),
@Sexo varchar(1) = null,
@RazaoSocial VARCHAR(200) = null,
@CPF varchar(14) = null,
@CNPJ CHAR(18) = null

as

if @Categoria = 'PF'
begin
update Pessoa
set Nome = @Nome, Telefone = @Telefone, Celular = @Celular, Email = @Email, Logradouro = @Logradouro, Bairro = @Bairro, Cidade = @Cidade, 
UF = @UF, CEP = @CEP, Numero = @Numero, Complemento = @Complemento, Categoria = @Categoria, SenhaPessoa = @SenhaPessoa
where IDPessoa = @IDPessoa
update ClientePF
set Sexo = @Sexo
where CPF = @CPF
end
else if @Categoria = 'PJ'
begin
update Pessoa
set Nome = @Nome, Telefone = @Telefone, Celular = @Celular, Email = @Email, Logradouro = @Logradouro, Bairro = @Bairro, Cidade = @Cidade, 
UF = @UF, CEP = @CEP, Numero = @Numero, Complemento = @Complemento, Categoria = @Categoria, SenhaPessoa = @SenhaPessoa
where IDPessoa =@IDPessoa
update ClientePJ
set RazaoSocial = @RazaoSocial
where CNPJ = @CNPJ
end


go



CREATE PROCEDURE ps_clientes_visualizar_pf_pj
@nome VARCHAR(200) = NULL,
@cpfcnpj VARCHAR (18) = NULL

AS

IF @nome IS NOT NULL (

SELECT * FROM vw_clientes WHERE Nome like @nome + '%'
)

ELSE IF @cpfcnpj IS NOT NULL(
SELECT * FROM vw_clientes WHERE CPF like @cpfcnpj + '%' or CNPJ like @cpfcnpj + '%'
)

ELSE(
SELECT * FROM vw_clientes
)

drop procedure ps_clientes_visualizar_pf_pj

go

create procedure pd_cliente
@IDPessoa int,
@CPF varchar(14) = null,
@CNPJ varchar(18) = null

as

if @CPF is null
delete ClientePJ where CNPJ = @CNPJ

else if @CNPJ is null
delete ClientePF where CPF = @CPF

delete Pessoa where IDPessoa = @IDPessoa

go

drop procedure pi_Funcionario

go

create procedure pi_Funcionario
@Nome varchar (50),
@dataNascimento datetime,
@Sexo varchar(1),
@RG varchar (12),
@CPF varchar (14),
@Telefone varchar (14),
@Celular varchar (14),
@Email varchar (50),
@Logradouro varchar(50),
@Numero varchar (10),
@Complemento varchar (50),
@Bairro varchar(20),
@Cidade varchar (20),
@UF varchar (2),
@CEP varchar (9),
@Cargo varchar (100),
@LoginPessoa varchar (50),
@SenhaPessoa varchar (20),
@Categoria varchar(2),
@Situacao varchar(100)

as

insert into Pessoa (Nome, Telefone, Celular, Email, Logradouro, Bairro, Cidade, UF, CEP, Numero, Complemento, Categoria, LoginPessoa, SenhaPessoa)
values (@Nome, @Telefone, @Celular, @Email, @Logradouro, @Bairro, @Cidade, @UF, @CEP, @Numero, @Complemento, @Categoria, @LoginPessoa, @SenhaPessoa)

declare @ID int
select @ID = max(IDPessoa) from Pessoa

insert into Funcionario (IDPessoa, dataNascimento, Sexo, RG, CPF, Cargo, Situacao)
 values (@ID, @dataNascimento, @Sexo, @RG, @CPF, @Cargo, @Situacao)
 go

create procedure pi_carro
@Placa varchar (8),
@Nome varchar (20),
@Ano int,
@Marca varchar (30),
@Categoria varchar (7),
@CapacidadePortaMalas varchar,
@AirBag varchar (3),
@QuantidadeAirBag int,
@Direcao varchar (3),
@CapacidadePassageiros int,
@ArCondicionado varchar,
@Portas int,
@Cambio varchar(15),
@VidroEletrico varchar(3),
@TravaEletrica varchar(3),
@FreioABS varchar(3),
@StatusVeiculo varchar(50) = null,
@Km varchar(100),
@Situacao varchar(100)

as

insert into Veiculo (Placa, Nome, Ano, Marca, Categoria, CapacidadePortaMalas, AirBag, QuantidadeAirBag,
Direcao, CapacidadePassageiros, ArCondicionado, Portas, Cambio, VidroEletrico, TravaEletrica, FreioABS,
StatusVeiculo, Km, Situacao)
values (@Placa, @Nome, @Ano, @Marca, @Categoria, @CapacidadePortaMalas, @AirBag, @QuantidadeAirBag,
@Direcao, @CapacidadePassageiros, @ArCondicionado, @Portas, @Cambio, @VidroEletrico, @TravaEletrica,
@FreioABS, @StatusVeiculo, @Km, @Situacao)

go
alter table Veiculo add Km varchar(100)
go
drop procedure pi_carro

select * from Veiculo

go

drop procedure ps_funcionario_atualizar

go

create procedure ps_funcionario_atualizar
@CPF varchar (14)

as

select * from vw_Login_Pessoa where [CPF Funcionário] = @CPF

go

create procedure pu_funcionario
@IDPessoa int,
@Nome varchar (50),
@CPF varchar (11),
@Telefone varchar (11),
@Celular varchar (12),
@Email varchar (50),
@Logradouro varchar(50),
@Numero varchar (10),
@Complemento varchar (50),
@Bairro varchar(20),
@Cidade varchar (20),
@UF varchar (2),
@CEP varchar (8),
@Cargo varchar (100),
@LoginPessoa varchar (50),
@SenhaPessoa varchar (20),
@Categoria varchar(2)

as

update Pessoa
set Nome = @Nome, Telefone = @Telefone, Celular = @Celular, Email = @Email, Logradouro = @Logradouro, Bairro = @Bairro, Cidade = @Cidade, 
UF = @UF, CEP = @CEP, Numero = @Numero, Complemento = @Complemento, Categoria = @Categoria, SenhaPessoa = @SenhaPessoa
where IDPessoa = @IDPessoa
update Funcionario
set Cargo = @Cargo

where CPF = @CPF

go

create procedure pd_funcionario
@IDPessoa int


as

delete Funcionario where IDPessoa = @IDPessoa
delete Pessoa where IDPessoa = @IDPessoa

go
drop proc pd_funcionario
go

select * from Funcionario

drop procedure ps_clientes_visualizar_pf_pj

--------------------------------


go
CREATE PROCEDURE ps_clientes_visualizar_pf_pj

@nome VARCHAR(200) = NULL



AS



IF @nome IS NOT NULL (



SELECT * FROM vw_clientes WHERE nome = @nome

)



ELSE (

SELECT * FROM vw_clientes

)


exec ps_clientes_visualizar_pf_pj 'Caio Vinicius'

go

CREATE VIEW vw_clientes_pf_pj_login
AS
SELECT IDClientePF [id] ,NomePF [nome], Sexo [sexo], RG [rg], CPF [cpfcnpj],  CAST(0 AS varchar(200)) [razaoSocial], CNH [cnh], Telefone [telefone], Celular [celular], Email [email], Logradouro [logradouro], Bairro [bairro], Cidade [cidade], UF [uf], Numero [numero], Complemento [complemento], CEP [cep], CAST('PF' AS CHAR(2)) [categoria], LoginCliente [loginCliente], SenhaCliente [senhaCliente]
FROM ClientePF

UNION 
SELECT IDClientePJ [id] ,NomePJ [nome], CAST(0 AS varchar(1)) [sexo], CAST(0 AS varchar(15)) [RG], CNPJ [cpfcnpj], RazaoSocial [razaoSocial], CAST(0 AS varchar(11)) [CNH], Telefone [telefone], Celular [celular], Email [email], Logradouro [logradouro], Bairro [bairro], Cidade [cidade], UF [uf], Numero [numero], Complemento [complemento], CEP [cep], CAST('PJ' AS CHAR(2)) [categoria], LoginCliente [loginCliente], SenhaCliente [senhaCliente]
FROM ClientePJ

go

create procedure ps_cliente_login
@LoginPessoa varchar(50) = null,
@SenhaPessoa varchar(50) = null,
@IDPessoa int = null

as 

if @LoginPessoa is null and @SenhaPessoa is null(
select * from vw_clientes_pf_pj where IDPessoa = @IDPessoa
)

else (
select * from vw_clientes_pf_pj where LoginPessoa = @LoginPessoa and SenhaPessoa = @SenhaPessoa
)
go

drop view vw_clientes_pf_pj_login

go

drop procedure pu_cliente_web

go

select * from ClientePF

go

create procedure pu_cliente_web
@IDPessoa int,
@Nome varchar (200),
@Telefone char (14),
@Celular char (14),
@Email varchar (200),
@Logradouro varchar(300),
@Bairro varchar(20),
@Cidade varchar (20),
@UF varchar (2),
@CEP varchar (9),
@Numero varchar (10),
@Complemento varchar (50),
@Categoria varchar (2),
@SenhaPessoa varchar(50),
@Sexo varchar(1) = null,
@RazaoSocial VARCHAR(200) = null,
@CPF varchar(14) = null,
@CNPJ CHAR(18) = null

as

if @Categoria = 'PF'
begin
update Pessoa
set Nome = @Nome, Telefone = @Telefone, Celular = @Celular, Email = @Email, Logradouro = @Logradouro, Bairro = @Bairro, Cidade = @Cidade, 
UF = @UF, CEP = @CEP, Numero = @Numero, Complemento = @Complemento, Categoria = @Categoria, SenhaPessoa = @SenhaPessoa
where IDPessoa = @IDPessoa
update ClientePF
set Sexo = @Sexo
where CPF = @CPF
end
else if @Categoria = 'PJ'
begin
update Pessoa
set Nome = @Nome, Telefone = @Telefone, Celular = @Celular, Email = @Email, Logradouro = @Logradouro, Bairro = @Bairro, Cidade = @Cidade, 
UF = @UF, CEP = @CEP, Numero = @Numero, Complemento = @Complemento, Categoria = @Categoria, SenhaPessoa = @SenhaPessoa
where IDPessoa =@IDPessoa
update ClientePJ
set RazaoSocial = @RazaoSocial
where CNPJ = @CNPJ
end


select * from ClientePF

go

create table Nova_Reserva (
IDReserva int identity (1,1) primary key,
IDPessoa int,
NomeCliente varchar (200),
RazaoSocial varchar (100),
CPFCliente char (14),
CNPJ char (18),
CNH char(11),
Celular char(14),
Categoria varchar(100),
DtHoraRetirada datetime,
DtHoraDevol datetime,
KmDesejado varchar(4),
KmExtra varchar(4),
BebeConforto varchar(3),
QuantidadeBebe varchar(1),
CadeiraBebe varchar(3),
QuantidadeCadeira varchar(1),
AssentoElevado varchar(3),
QuantidadeAssento varchar(1),
ValorTotal varchar(10),
TotalDias varchar(4),
Situacao varchar(100),

constraint IDPessoa_fk3 foreign key (IDPessoa) references Pessoa (IDPessoa)
);

go

go

drop table Nova_Reserva
drop procedure pi_nova_reserva

go

create procedure pi_nova_reserva
@IDPessoa int,
@NomeCliente varchar(200),
@RazaoSocial varchar(100) = '',
@CPFCliente char(14) = '',
@CNPJ char(18) = '',
@CNH char(11) = '',
@Celular char(14),
@Categoria varchar(100),
@DtHoraRetirada datetime,
@DtHoraDevol datetime,
@KmDesejado varchar(4) = '',
@KmExtra varchar(4) = '',
@BebeConforto varchar(3),
@QuantidadeBebe varchar(1) = '',
@CadeiraBebe varchar(3),
@QuantidadeCadeira varchar(1) = '',
@AssentoElevado varchar(3),
@QuantidadeAssento varchar(1) = '',
@ValorTotal varchar(10),
@TotalDias varchar(4),
@Situacao varchar(100)

as

insert into Nova_Reserva (IDPessoa, NomeCliente, RazaoSocial, CPFCliente, CNPJ, CNH, Celular, Categoria, DtHoraRetirada, DtHoraDevol, KmDesejado,
KmExtra, BebeConforto, QuantidadeBebe, CadeiraBebe, QuantidadeCadeira, AssentoElevado, QuantidadeAssento, ValorTotal, TotalDias, Situacao)
values (@IDPessoa, @NomeCliente, @RazaoSocial, @CPFCliente, @CNPJ, @CNH, @Celular, @Categoria, @DtHoraRetirada, @DtHoraDevol, @KmDesejado,
@KmExtra, @BebeConforto, @QuantidadeBebe, @CadeiraBebe, @QuantidadeCadeira, @AssentoElevado, @QuantidadeAssento, @ValorTotal, @TotalDias, @Situacao)

go

alter table Nova_Reserva add Situacao varchar (100)
select * from Nova_Reserva
go

drop proc pi_nova_reserva

create procedure ps_Reserva_Cliente
@IDPessoa int

as

select * from Nova_Reserva where IDPessoa = @IDPessoa

go

insert into Nova_Reserva values (4, 'caio vinicius', '156,023,516-30', '', '45133568863', '(11)02306-5189', 'SUV', '20/10/2018 15:00', 
'31/10/2018 15:00', '', '', 'Sim', 'Não', 'Não', '1000', '11')

go

create procedure ps_Reserva_Funcionario
as
select * from Nova_Reserva
go

select * from Nova_Reserva
select * from vw_clientes_pf_pj

go

CREATE VIEW vw_Login_Pessoa
AS
SELECT p.IDPessoa, p.Categoria, p.Nome, pf.Sexo, pf.dataNascimento, pf.CPF, pf.RG, pf.CNH, pj.CNPJ, pj.RazaoSocial, p.Logradouro, p.Numero, 
p.Complemento, p.Cidade, p.Bairro, p.UF, p.CEP, p.Celular, p.Telefone, p.Email, p.LoginPessoa, p.SenhaPessoa, fu.Cargo, fu.CPF [CPF Funcionário],
fu.dataNascimento [Data de Nascimento], fu.IDFuncionario, fu.RG [RG Funcionário], fu.Sexo [Sexo Funcionário], fu.Situacao
FROM Pessoa p
left join ClientePF pf on pf.IDPessoa = p.IDPessoa
left join ClientePJ pj on pj.IDPessoa = p.IDPessoa
left join Funcionario fu on fu.IDPessoa = p.IDPessoa

go
drop view vw_Login_Pessoa
go

create procedure ps_Login_Pessoa(
@IDPessoa int = null,
@LoginPessoa varchar(50) = null,
@SenhaPessoa varchar(50) = null
)
as

if @LoginPessoa is null and @SenhaPessoa is null(
select * from vw_Login_Pessoa where IDPessoa = @IDPessoa
)

else (
select * from vw_Login_Pessoa where LoginPessoa = @LoginPessoa and SenhaPessoa = @SenhaPessoa
)
go

CREATE VIEW vw_clientes
AS
SELECT p.IDPessoa, p.Categoria, p.Nome, pf.Sexo, pf.dataNascimento, pf.CPF, pf.RG, pf.CNH, pj.CNPJ, pj.RazaoSocial, p.Logradouro, p.Numero, 
p.Complemento, p.Cidade, p.Bairro, p.UF, p.CEP, p.Celular, p.Telefone, p.Email
FROM Pessoa p
left join ClientePF pf on pf.IDPessoa = p.IDPessoa
left join ClientePJ pj on pj.IDPessoa = p.IDPessoa
where Categoria <> 'FU'

go

drop view vw_clientes

go

drop proc ps_carro

go

create procedure pu_carro
@StatusVeiculo varchar(50),
@Km varchar(100),
@Placa varchar(8)

as

update Veiculo
set StatusVeiculo = @StatusVeiculo, Km = @Km
where Placa = @Placa


go
select * from Veiculo
go

create procedure ps_carro
@Placa varchar(8) = null

as

if @Placa is not null(
select * from Veiculo where Placa = @Placa
)

else (
select * from Veiculo
)

go

drop proc pd_carro

go

create proc pd_carro
@IDVeiculo varchar(8)

as

delete Veiculo where IDVeiculo = @IDVeiculo

go

create proc ps_reserva_locacao
@IDReserva int

as

select * from Nova_Reserva where IDReserva = @IDReserva

go

create proc ps_reserva
@NomeCliente varchar(200) = null

as

if @NomeCliente is null(
select * from Nova_Reserva
)

else (
select * from Nova_Reserva  where NomeCliente like @NomeCliente + '%'
)

go

drop proc pi_locacao

go

create procedure ps_carro_locacao
@Placa varchar(8),
@Categoria varchar (7)

as

select * from Veiculo where Placa = @Placa and Categoria = @Categoria

go

create proc pi_locacao
@IDFuncionario int,
@IDCarro int,
@IDReserva int,
@ValorSinal decimal (10,2),
@Situacao varchar(100),
@ValorTotal decimal (10,2),
@Placa varchar(8),
@StatusVeiculo varchar(50),
@SituacaoReserva varchar(100),
@FormaPagamento varchar(100),
@DataFinalizacao datetime = null,
@PagamentoFinal varchar(100) = null

as

insert into Locacao (IDFuncionario, IDCarro, IDReserva, ValorSinal, Situacao, ValorTotal, FormaPagamento, DataFinalizacao, PagamentoFinal)
values (@IDFuncionario, @IDCarro, @IDReserva, @ValorSinal, @Situacao, @ValorTotal, @FormaPagamento, @DataFinalizacao, @PagamentoFinal)

update Veiculo
set StatusVeiculo = @StatusVeiculo
where Placa = @Placa

update Nova_Reserva
set Situacao = @SituacaoReserva
where IDReserva = @IDReserva

go

drop proc pi_locacao

create proc pu_carro_locacao
@Placa varchar(8),
@StatusVeiculo varchar(50)

as

update Veiculo
set StatusVeiculo = @StatusVeiculo
where Placa = @Placa

go

create proc ps_visualizar_carro_disponivel
@Categoria varchar(7) = null

as

if @Categoria is null(
select Placa, Nome, Ano, Marca, Categoria, CapacidadePortaMalas, AirBag, QuantidadeAirBag, Direcao, CapacidadePassageiros, ArCondicionado,
Portas, Cambio, VidroEletrico, TravaEletrica, FreioABS from veiculo where StatusVeiculo = 'Disponível' and Situacao <>'Desativado'
)

else(
select Placa, Nome, Ano, Marca, Categoria, CapacidadePortaMalas, AirBag, QuantidadeAirBag, Direcao, CapacidadePassageiros, ArCondicionado,
Portas, Cambio, VidroEletrico, TravaEletrica, FreioABS from veiculo where StatusVeiculo = 'Disponível' and Categoria = @Categoria  and Situacao <>'Desativado'
)

go

create proc desativar_funcionario
@IDFuncionario int,
@Situacao varchar (100)

as

update Funcionario 
set Situacao = @Situacao
where IDFuncionario = @IDFuncionario

go

alter table Funcionario add Situacao varchar(100)

go

create proc ps_locacao_andamento
@NomeCliente varchar(200) = null

as 

if @NomeCliente is null(
select * from vw_locacao_andamento where Situacao = 'Em andamento'
)

else(
select * from vw_locacao_andamento where NomeCliente like @NomeCliente + '%' and Situacao = 'Em andamento'
)

go
drop view vw_locacao_andamento
create view vw_locacao_andamento
as
select l.IDLocacao, l.IDFuncionario, l.IDReserva, r.DtHoraRetirada, r.DtHoraDevol, r.NomeCliente, r.CPFCliente, r.CNH, r.CNPJ,
r.RazaoSocial, r.Celular, r.Categoria, l.ValorSinal, l.IDCarro, v.Nome, v.Placa, v.Km, r.KmDesejado, r.KmExtra, r.BebeConforto, r.QuantidadeBebe,
r.CadeiraBebe, r.QuantidadeCadeira, r.AssentoElevado, r.QuantidadeAssento, l.ValorTotal, l.Situacao, l.FormaPagamento from Locacao l
left join Funcionario f on f.IDFuncionario = l.IDFuncionario
left join Veiculo v on v.IDVeiculo = l.IDCarro
left join Nova_Reserva r on r.IDReserva = l.IDReserva

go

create proc destaivar_carro
@Placa varchar(8),
@Situacao varchar(100)

as

update Veiculo 
set Situacao = @Situacao
where Placa = @Placa

go

create proc finalizar_locacao
@IDLocacao int,
@Placa varchar(8),
@DtHoraDevol datetime,
@Km varchar(100),
@ValorTotal decimal (10,2),
@Situacao varchar(100),
@IDReserva int,
@DataFinalizacao datetime,
@PagamentoFinal varchar(100)

as

update Locacao
set ValorTotal = @ValorTotal, Situacao = @Situacao, 
DataFinalizacao = @DataFinalizacao, PagamentoFinal = @PagamentoFinal
where IDLocacao = @IDLocacao

update Veiculo
set Km = @Km, StatusVeiculo = 'Disponível'
where Placa = @Placa

update Nova_Reserva
set DtHoraDevol = @DtHoraDevol
where IDReserva = @IDReserva


go
drop proc finalizar_locacao

create procedure ps_carro_todos
@Categoria varchar(7) = null

as

if @Categoria is not null(
select * from Veiculo where Categoria = @Categoria and Situacao <> 'Desativado'
)

else (
select * from Veiculo where Situacao <> 'Desativado'
)

go

create proc ps_locacao_finalizada
@NomeCliente varchar(200) = null

as

if @NomeCliente is not null(
select * from vw_locacao_finalizada where NomeCliente = @NomeCliente and Situacao = 'Finalizada'
)

else(
select * from vw_locacao_finalizada where Situacao = 'Finalizada'
)
drop proc ps_locacao_finalizada
go

create view vw_locacao_finalizada
as
select l.IDLocacao, l.IDFuncionario, l.IDReserva, r.DtHoraRetirada, r.DtHoraDevol, r.NomeCliente, r.CPFCliente, r.CNH, r.CNPJ,
r.RazaoSocial, r.Celular, r.Categoria, l.ValorSinal, l.IDCarro, v.Nome, v.Placa, v.Km, r.KmDesejado, r.KmExtra, r.BebeConforto, r.QuantidadeBebe,
r.CadeiraBebe, r.QuantidadeCadeira, r.AssentoElevado, r.QuantidadeAssento, l.ValorTotal, l.Situacao, l.FormaPagamento, l.DataFinalizacao,
l.PagamentoFinal from Locacao l
left join Funcionario f on f.IDFuncionario = l.IDFuncionario
left join Veiculo v on v.IDVeiculo = l.IDCarro
left join Nova_Reserva r on r.IDReserva = l.IDReserva

go

create proc pu_reserva
@IDPessoa int,
@NomeCliente varchar(200),
@RazaoSocial varchar(100) = '',
@CPFCliente char(14) = '',
@CNPJ char(18) = '',
@CNH char(11) = '',
@Celular char(14),
@Categoria varchar(100),
@DtHoraRetirada datetime,
@DtHoraDevol datetime,
@KmDesejado varchar(4) = '',
@KmExtra varchar(4) = '',
@BebeConforto varchar(3),
@QuantidadeBebe varchar(1) = '',
@CadeiraBebe varchar(3),
@QuantidadeCadeira varchar(1) = '',
@AssentoElevado varchar(3),
@QuantidadeAssento varchar(1) = '',
@ValorTotal varchar(10),
@TotalDias varchar(4),
@Situacao varchar(100)

as

update NovaReserva
set NomeCliente = @NomeCliente, RazaoSocial = @RazaoSocial, CPFCliente = @CPFCliente,
CNPJ = @CNPJ, CNH = @CNH, Celular = @Celular, Categoria = @Categoria, DtHoraRetirada = @DtHoraDevol,
DtHoraRetirada = @DtHoraRetirada, KmDesejado = @KmDesejado, KmExtra = @KmExtra, BebeConforto = @BebeConforto,
QuantidadeBebe = @QuantidadeBebe, CadeiraBebe = @CadeiraBebe, QuantidadeCadeira = @QuantidadeCadeira,
AssentoElevado = @AssentoElevado, QuantidadeAssento = @QuantidadeAssento, ValorTotal = @ValorTotal,
TotalDias = @TotalDias, Situacao = @Situacao where IDPessoa = @IDPessoa