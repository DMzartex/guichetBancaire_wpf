-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1
-- Généré le : mar. 16 mai 2023 à 15:58
-- Version du serveur : 10.4.25-MariaDB
-- Version de PHP : 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `guichetbancaire`
--

-- --------------------------------------------------------

--
-- Structure de la table `comptecourant`
--

CREATE TABLE `comptecourant` (
  `compteEpargneId` int(11) NOT NULL,
  `numeroCompte` varchar(100) NOT NULL,
  `nomPropri` varchar(30) NOT NULL,
  `prenomPropri` varchar(30) NOT NULL,
  `solde` float NOT NULL,
  `typeCompte` varchar(30) DEFAULT NULL,
  `decouvertAut` float DEFAULT NULL,
  `usersId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `comptecourant`
--

INSERT INTO `comptecourant` (`compteEpargneId`, `numeroCompte`, `nomPropri`, `prenomPropri`, `solde`, `typeCompte`, `decouvertAut`, `usersId`) VALUES
(6, 'BE96364589578', 'Michaux', 'dodo', 100600, 'Courant', -500, 5),
(7, 'BE96364589579', 'Michaux', 'dodo', 500, 'Courant', -500, 5),
(8, 'BE96364589580', 'Michaux', 'dodo', 103200, 'Courant', -500, 5);

-- --------------------------------------------------------

--
-- Structure de la table `compteepargne`
--

CREATE TABLE `compteepargne` (
  `compteEpargneId` int(11) NOT NULL,
  `numeroCompte` varchar(100) NOT NULL,
  `nomPropri` varchar(30) NOT NULL,
  `prenomPropri` varchar(30) NOT NULL,
  `solde` float NOT NULL,
  `typeCompte` varchar(30) DEFAULT NULL,
  `tauxInteret` float DEFAULT NULL,
  `usersId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `compteepargne`
--

INSERT INTO `compteepargne` (`compteEpargneId`, `numeroCompte`, `nomPropri`, `prenomPropri`, `solde`, `typeCompte`, `tauxInteret`, `usersId`) VALUES
(1, 'BE9878965698', 'test', 'test', 21700, 'Epargne', 2.5, 5),
(2, 'BE9878965699', 'test', 'test', 8351, 'Epargne', 2.5, 5);

-- --------------------------------------------------------

--
-- Structure de la table `users`
--

CREATE TABLE `users` (
  `usersId` int(11) NOT NULL,
  `nom` varchar(30) NOT NULL,
  `prenom` varchar(30) NOT NULL,
  `dateNaissance` datetime NOT NULL,
  `email` varchar(100) NOT NULL,
  `password` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `users`
--

INSERT INTO `users` (`usersId`, `nom`, `prenom`, `dateNaissance`, `email`, `password`) VALUES
(5, 'test3', 'test3', '2565-01-18 00:00:00', 'test3', 'test');

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `comptecourant`
--
ALTER TABLE `comptecourant`
  ADD PRIMARY KEY (`compteEpargneId`),
  ADD KEY `usersId` (`usersId`);

--
-- Index pour la table `compteepargne`
--
ALTER TABLE `compteepargne`
  ADD PRIMARY KEY (`compteEpargneId`),
  ADD KEY `usersId` (`usersId`);

--
-- Index pour la table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`usersId`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `comptecourant`
--
ALTER TABLE `comptecourant`
  MODIFY `compteEpargneId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT pour la table `compteepargne`
--
ALTER TABLE `compteepargne`
  MODIFY `compteEpargneId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT pour la table `users`
--
ALTER TABLE `users`
  MODIFY `usersId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `comptecourant`
--
ALTER TABLE `comptecourant`
  ADD CONSTRAINT `comptecourant_ibfk_1` FOREIGN KEY (`usersId`) REFERENCES `users` (`usersId`);

--
-- Contraintes pour la table `compteepargne`
--
ALTER TABLE `compteepargne`
  ADD CONSTRAINT `compteepargne_ibfk_1` FOREIGN KEY (`usersId`) REFERENCES `users` (`usersId`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
