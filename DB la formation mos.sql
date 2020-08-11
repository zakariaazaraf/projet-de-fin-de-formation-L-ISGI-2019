use master 

create database DBFormationMos

--use DBFormationMos

/********** la creation de la base e donnée Fonction *********/

create table Fonction(
IdFonction smallint identity primary key,
NomFormation nvarchar(25) check (NomFormation in ('administrateur','adhérent'))
)

/********la creation de la base de donnée Utilisateur********/

create table Utilisateur(
PPR nvarchar(7) primary key,
NomUtilisateur nvarchar(25),
PrénomUtilisateur nvarchar(20),
TéléUtilisateur nvarchar(10),
Matière nvarchar(20),
Etablissement nvarchar(30),
LoginUtilisateur nvarchar(35),
PasswordUtilisateur nvarchar(25),
IdFonction smallint foreign key (IdFonction) references Fonction (IdFonction) on delete cascade on update cascade
)


/********* la création de la base de donnée Formation **********/

create table Formation(
IdFormation smallint identity primary key,
DébutFormation date,
FinFormation date
)


create table Centre(
IdCentreFormation smallint identity primary key,
NomCentreFormation nvarchar(30)
)

select * from Formation
select * from Module


/********** la création de la base de donnée **********/

create table [S'inscrire](
PPR nvarchar(7) foreign key (PPR) references Utilisateur (PPR) on delete cascade on update cascade,
IdFormation smallint foreign key (IdFormation) references Formation (IdFormation) on delete cascade on update cascade,
IdCentreFormation smallint foreign key (IdCentreFormation) references Centre (IdCentreFormation) on delete cascade on update cascade,
constraint LaCléPrimaireSinscrire primary key (PPR,IdFormation)
)

/********* la création de la base de donnée Module **********/

create table Module(
IdModule smallint identity primary key,
NomModule nvarchar(20)
)

/******** la création de la bsae de donnée Avoir *******/

create table Avoir (
Horaire nvarchar(10),
IdFormation smallint foreign key (IdFormation) references Formation (IdFormation) on delete cascade on update cascade,
IdModule smallint foreign key (IdModule) references Module (IdModule) on delete cascade on update cascade,
constraint CléPraimaireAvoir primary key (IdFormation,IdModule)
)

/****** la création de la base de donnée Formateur ******/

create table Formateur(
IdFormateur smallint identity primary key,
NomFormateur nvarchar(25),
PrénomFormateur nvarchar(20),
TéléFormateur nvarchar(10),
IdModule smallint foreign key (IdModule) references Module (IdModule) on delete cascade on update cascade
)

/******* la création de la base de donnée Effectuer *******/

create table Effectuer(
TypeFormation nvarchar(30),
Resultat nvarchar(20),
PPR nvarchar(7) foreign key (PPR) references Utilisateur (PPR) on delete cascade on update cascade,
IdModule smallint foreign key (IdModule) references Module(IdModule) on delete cascade on update cascade,
IdFormation smallint foreign key (IdFormation) references Formation (IdFormation) on delete cascade on update cascade,
constraint CléPrimaireEffectuer primary key (PPR,IdModule,IdFormation)
)







select * from Module
select * from Avoir



select M.NomModule from Module M join Avoir A on M.IdModule = A.IdModule where IdFormation = 1 and A.IdModule not in (select E.IdModule from Effectuer E where PPR ='4234567')

insert into Effectuer values ('aa','aa','4234567',1,1)

drop table Suivre
drop table Effectuer
select * from Formateur
/*** la saisaie des donnée  ***/

/***** Insertion des données de la table Fonction *******/

insert into Fonction values ('administrateur')
insert into Fonction values ('adhérent')


/****** Insertion des données de la table Utilisateur ******/

insert into Utilisateur values (1234567,'azaraf','zakaria','0629221997','français','Imam bokhari','azarafzakaria','az11111',1)
insert into Utilisateur values (2234567,'azaraf1','zakaria1','0629221997','anglais','Iben arabi','azarafzakaria','az22222',2)
insert into Utilisateur values (3234567,'azaraf2','zakaria2','0629221997','arabe','Imam bokhari','azarafzakaria','az33333',2)
insert into Utilisateur values (4234567,'azaraf3','zakaria3','0629221997','anglais','Imam bokhari','azarafzakaria','az44444',2)
insert into Utilisateur values (5234567,'azaraf4','zakaria4','0629221997','français','Iben arabi','azarafzakaria','az55555',2)
insert into Utilisateur values (6234567,'azaraf5','zakaria5','0629221997','physique','Imam bokhari','azarafzakaria','az66666',2)
insert into Utilisateur values (7234567,'azaraf6','zakaria6','0629221997','espagniol','Imam bokhari','azarafzakaria','az77777',2)
insert into Utilisateur values (8234567,'azaraf7','zakaria7','0629221997','français','iben arabi','azarafzakaria','az11111',2)

select * from Utilisateur U join Fonction F on F.IdFonction=U.IdFonction
update Utilisateur set NomUtilisateur='azaraf',PrénomUtilisateur='Zakaria' where PPR=3234567

delete Utilisateur where PPR='5234567'

delete Utilisateur where PPR =8234567
select PPR,IdFonction from Utilisateur where LoginUtilisateur='azarafzakaria' and PasswordUtilisateur='az11111 '

select PPR,IdFonction from Utilisateur where LoginUtilisateur='azarafzakaria' and PasswordUtilisateur='az22222'

/**** Insertion des données de la table Formation ****/

insert into Formation values ('2016/01/01','2016/12/22')
insert into Formation values ('2017/01/01','2017/12/22')
insert into Formation values ('2018/01/01','2018/12/22')
insert into Formation values ('2019/01/01','2019/12/22')

/****** Insertion des données de la table S'inscrire ******/ 

select * from Centre
insert into Centre values('Iben al arabi')

select * from Avoir A join Module M on A.IdModule=M.IdModule where IdFormation=4


insert into [S'inscrire] values (1234567,1,1)
insert into [S'inscrire] values (2234567,1,2)
insert into [S'inscrire] values (2234567,2,1)
insert into [S'inscrire] values (2234567,3,2)
insert into [S'inscrire] values (3234567,1,2)
insert into [S'inscrire] values (4234567,1,2)
insert into [S'inscrire] values (4234567,2,2)
insert into [S'inscrire] values (4234567,3,1)
insert into [S'inscrire] values (5234567,1,2)

/****** Insertion des données de la table Module ******/

insert into Module values('Word')
insert into Module values('Excel')

/****** Insertion des données de la table Avoir ******/

insert into Avoir values('30',1,1)
insert into Avoir values('26',1,2)
insert into Avoir values('25',4,2)
insert into Avoir values('25',3,1)
insert into Avoir values ('28',2,2)
insert into Avoir values ('28',2,1)
insert into Avoir values ('28',3,2)
insert into Avoir values ('28',4,1)

select IdFormation from Formation where IdFormation not in(select IdFormation from [S'inscrire] where PPR=4234567)





select distinct 

select NomCentreFormation from [S'inscrire] S join Centre C on S.IdCentreFormation = C.IdCentreFormation where S.IdCentreFormation =3 and PPR=

select * from Centre
select NomCentreFormation from Centre where IdCentreFormation =1
select C.NomCentreFormation from Centre C join [S'inscrire] S on S.IdCentreFormation=C.IdCentreFormation where  IdFormation =3 and PPR=2234567

select * from Utilisateur
select * from [S'inscrire]
select * from Formation
select * from Avoir
select * from Module

insert into Effectuer values ('Continu','validé',4234567,1,1)
insert into Effectuer values ('Continu','validé',4234567,1,2)
insert into Effectuer values ('Continu','validé',4234567,2,2)


select U.PPR,NomUtilisateur,PrénomUtilisateur,M.NomModule,C.NomCentreFormation,Resultat,TypeFormation 
from Utilisateur U join Effectuer E on U.PPR=E.PPR 
join Module M on E.IdModule = M.IdModule 
join Formation F on E.IdFormation = F.IdFormation 
join [S'inscrire] S on F.IdFormation = S.IdFormation 
join Centre C on C.IdCentreFormation = S.IdCentreFormation where Resultat='validé'

select U.PPR,U.NomUtilisateur,U.PrénomUtilisateur,E.Resultat,E.TypeFormation from Utilisateur U
where U.PPR in (select PPR,Resultat,TypeFormation from Effectuer E)

select  *
from Utilisateur U join Effectuer E on U.PPR = E.PPR 
join Module M on M.IdModule = E.IdModule 
join Formation F on E.IdFormation = F.IdFormation 
join [S'inscrire] S on F.IdFormation = S.IdFormation
join Centre C on C.IdCentreFormation = S.IdCentreFormation
where Resultat='validé' and NomModule='Excel'





select * from Avoir


insert into Centre values ('Iben Al Aaarbi')
insert into Centre values ('El Boukhari')
select * from Centre

select * from Effectuer

select * from Fonction

insert into Formateur values ('souny', 'mohammed', '0640404040',1)
insert into Formateur values ('el kadiri', 'mohammed', '0640404040',2)
select * from Formateur

select * from Formation

select * from Module

select * from [S'inscrire]

select * from Utilisateur