create table users(
usersId int primary key auto_increment,
nom varchar(30) not null,
prenom varchar(30) not null,
dateNaissance datetime not null,
email varchar(100) not null,
password varchar(30) not null
);


create table compteEpargne(
compteEpargneId int primary key auto_increment,
numeroCompte varchar(100) not null,
nomPropri varchar(30) not null,
prenomPropri varchar(30) not null,
solde float not null,
typeCompte varchar(30),
tauxInteret float,
usersId int,
FOREIGN KEY (usersId) REFERENCES users(usersId)
);

create table compteCourant(
compteEpargneId int primary key auto_increment,
numeroCompte varchar(100) not null,
nomPropri varchar(30) not null,
prenomPropri varchar(30) not null,
solde float not null,
typeCompte varchar(30),
decouvertAut float,
usersId int,
FOREIGN KEY (usersId) REFERENCES users(usersId)
)
