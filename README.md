USE [MojaBp]

create table Proizvod(
idProizvod int primary key,
nazivProizvod varchar(255) not null,
cena int
);

Create table Dobavljac(
IdDob int primary key,
NazDob varchar(255),
Drzava varchar(255),
Grad varchar(255),
Adresa varchar(255));

Create table Porudzbina(
idProizvod int,
IdDob int,
datum date,
kol varchar(255),
constraint pk_por primary key(idProizvod,IdDob),
constraint fk_pro foreign key(idProizvod) references Proizvod(idProizvod),
constraint fk_dob foreign key(IdDob) references Dobavljac(IdDob)
);

Insert into Porudzbina values(2,1003,SYSDATETIME(),'500 ml');
Insert into Porudzbina values(4,1001,SYSDATETIME(),'900 gr');

Create table Kupac(
IdKup int identity(1,1) primary key,
Ime varchar(255),
Prz varchar(255),
Grad varchar(255),
Adresa varchar(255));
Insert into Kupac values ('Danilo', 'Bojovic', 'Novi Sad', 'Stojana Novakovica 4');
Insert into Kupac values ('Tom', 'Milankovic', 'Bugojno', 'Topolska 18');
Insert into Kupac values ('Jovana', 'Pajovic', 'Novi Sad', 'Bulevar Evrope 1');
Insert into Kupac values ('Zlatko', 'Agbaba', 'Beograd', 'Uspenska 90');

create table Registracija(
IdReg int identity(1,1),
UserName varchar(255),
Pass varchar(255),
datumReg date,
constraint pk_reg primary key(IdReg),
constraint un_user unique(UserName),
constraint un_pass unique(Pass)
);

create table registracijaKupac(
IdKup int,
IdReg int,
constraint pk_kup_reg primary key(IdKup,IdReg),
constraint fk_kup foreign key(IdKup) references Kupac(IdKup) ON DELETE CASCADE,
constraint fk_reg foreign key(IdReg) references Registracija(IdReg) ON DELETE CASCADE
);

Create table Admin(
UserName varchar(255) NOT NULL UNIQUE,
Password varchar(255) NOT NULL UNIQUE
)
INSERT INTO Admin VALUES ('admin','admin');
