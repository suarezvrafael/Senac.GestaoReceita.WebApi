-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 23/08/2023 às 06:15
-- Versão do servidor: 10.4.28-MariaDB
-- Versão do PHP: 8.0.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `gestao_receita_api`
--

-- --------------------------------------------------------

--
-- Estrutura para tabela `cidades`
--

CREATE TABLE `cidades` (
  `Id` int(11) NOT NULL,
  `descricaoCidade` varchar(100) NOT NULL,
  `IdEstado` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `cidades`
--

INSERT INTO `cidades` (`Id`, `descricaoCidade`, `IdEstado`) VALUES
(1, 'Alegrete', 1),
(2, 'Santa Cruz do Sul', 1);

-- --------------------------------------------------------

--
-- Estrutura para tabela `empresas`
--

CREATE TABLE `empresas` (
  `Id` int(11) NOT NULL,
  `CNPJ` varchar(18) NOT NULL,
  `razaoSosial` varchar(150) NOT NULL,
  `rua` varchar(150) NOT NULL,
  `bairro` varchar(150) NOT NULL,
  `numeroEndereco` int(11) NOT NULL,
  `complemento` varchar(200) NOT NULL,
  `email` varchar(90) NOT NULL,
  `telefone` varchar(15) NOT NULL,
  `nomeFantasia` varchar(150) NOT NULL,
  `idcidade` int(11) NOT NULL,
  `createEmpresa` datetime(6) NOT NULL,
  `updateEmpresa` datetime(6) NOT NULL,
  `idUsername` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `empresas`
--

INSERT INTO `empresas` (`Id`, `CNPJ`, `razaoSosial`, `rua`, `bairro`, `numeroEndereco`, `complemento`, `email`, `telefone`, `nomeFantasia`, `idcidade`, `createEmpresa`, `updateEmpresa`, `idUsername`) VALUES
(2, '40.525.979/0001-36', 'RAZAO SOCIAL', 'RUA', 'BAIRRO', 1, 'COMPLE', 'email@email.com', '51999708050', 'NOME FANTASIA', 1, '2023-08-21 20:04:04.727151', '2023-08-22 23:56:00.998908', 0);

-- --------------------------------------------------------

--
-- Estrutura para tabela `estados`
--

CREATE TABLE `estados` (
  `Id` int(11) NOT NULL,
  `descricaoEstado` varchar(100) NOT NULL,
  `IdPais` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `estados`
--

INSERT INTO `estados` (`Id`, `descricaoEstado`, `IdPais`) VALUES
(1, 'Rio Grande de Sul', 1);

-- --------------------------------------------------------

--
-- Estrutura para tabela `ingredientes`
--

CREATE TABLE `ingredientes` (
  `Id` int(11) NOT NULL,
  `NomeIngrediente` varchar(200) NOT NULL,
  `PrecoIngrediente` decimal(65,30) NOT NULL,
  `QuantidadeUnidade` float NOT NULL,
  `EmpresaId` int(11) NOT NULL,
  `UnidadeMedidaId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `ingredientes`
--

INSERT INTO `ingredientes` (`Id`, `NomeIngrediente`, `PrecoIngrediente`, `QuantidadeUnidade`, `EmpresaId`, `UnidadeMedidaId`) VALUES
(1, 'Ovo', 0.200000000000000000000000000000, 10, 2, 1);

-- --------------------------------------------------------

--
-- Estrutura para tabela `paises`
--

CREATE TABLE `paises` (
  `Id` int(11) NOT NULL,
  `descricaoPais` varchar(140) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `paises`
--

INSERT INTO `paises` (`Id`, `descricaoPais`) VALUES
(1, 'Brasil');

-- --------------------------------------------------------

--
-- Estrutura para tabela `receitaingredientes`
--

CREATE TABLE `receitaingredientes` (
  `Id` int(11) NOT NULL,
  `IdReceita` int(11) NOT NULL,
  `Idingrediente` int(11) NOT NULL,
  `quantidadeIngrediente` int(11) NOT NULL,
  `IdGastoVariado` int(11) NOT NULL,
  `qntGastoVariado` decimal(65,30) NOT NULL,
  `ReceitaId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `receitaingredientes`
--

INSERT INTO `receitaingredientes` (`Id`, `IdReceita`, `Idingrediente`, `quantidadeIngrediente`, `IdGastoVariado`, `qntGastoVariado`, `ReceitaId`) VALUES
(3, 3, 1, 2, 0, 0.000000000000000000000000000000, 3);

-- --------------------------------------------------------

--
-- Estrutura para tabela `receitas`
--

CREATE TABLE `receitas` (
  `Id` int(11) NOT NULL,
  `nomeReceita` varchar(140) NOT NULL,
  `IdEmpresa` int(11) NOT NULL,
  `ValorTotalReceita` decimal(65,30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `receitas`
--

INSERT INTO `receitas` (`Id`, `nomeReceita`, `IdEmpresa`, `ValorTotalReceita`) VALUES
(3, 'Ovos fritos', 0, 10.000000000000000000000000000000);

-- --------------------------------------------------------

--
-- Estrutura para tabela `unidademedida`
--

CREATE TABLE `unidademedida` (
  `Id` int(11) NOT NULL,
  `descUnidMedIngrediente` varchar(200) NOT NULL,
  `sigla` varchar(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `unidademedida`
--

INSERT INTO `unidademedida` (`Id`, `descUnidMedIngrediente`, `sigla`) VALUES
(1, 'Unidade', 'UND'),
(2, 'Xícara Chá', 'XIC'),
(3, 'Quilograma', 'KG'),
(4, 'Gramas', 'gr'),
(5, 'Colheres', 'COLH'),
(6, 'Litros', 'LI'),
(7, 'Mililitros', 'ML');

-- --------------------------------------------------------

--
-- Estrutura para tabela `usuarios`
--

CREATE TABLE `usuarios` (
  `Id` int(11) NOT NULL,
  `Nome` varchar(200) NOT NULL,
  `Username` varchar(150) NOT NULL,
  `Senha` varchar(200) NOT NULL,
  `Acesso` int(11) NOT NULL,
  `ManterLogado` int(11) NOT NULL,
  `EmpresaId` int(11) NOT NULL,
  `Ativo` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `usuarios`
--

INSERT INTO `usuarios` (`Id`, `Nome`, `Username`, `Senha`, `Acesso`, `ManterLogado`, `EmpresaId`, `Ativo`) VALUES
(1, 'Rafael Vieira Suarez', 'rafael@hotmail.com', '123', 1, 0, 0, 1),
(2, 'natasha', 'natasha@hotmail.com', '123', 0, 0, 0, 1);

-- --------------------------------------------------------

--
-- Estrutura para tabela `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20230807230511_firstmigration', '7.0.5');

--
-- Índices para tabelas despejadas
--

--
-- Índices de tabela `cidades`
--
ALTER TABLE `cidades`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Cidades_IdEstado` (`IdEstado`);

--
-- Índices de tabela `empresas`
--
ALTER TABLE `empresas`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Empresas_idcidade` (`idcidade`);

--
-- Índices de tabela `estados`
--
ALTER TABLE `estados`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Estados_IdPais` (`IdPais`);

--
-- Índices de tabela `ingredientes`
--
ALTER TABLE `ingredientes`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Ingredientes_EmpresaId` (`EmpresaId`),
  ADD KEY `IX_Ingredientes_UnidadeMedidaId` (`UnidadeMedidaId`);

--
-- Índices de tabela `paises`
--
ALTER TABLE `paises`
  ADD PRIMARY KEY (`Id`);

--
-- Índices de tabela `receitaingredientes`
--
ALTER TABLE `receitaingredientes`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_ReceitaIngredientes_Idingrediente` (`Idingrediente`),
  ADD KEY `IX_ReceitaIngredientes_IdReceita` (`IdReceita`),
  ADD KEY `IX_ReceitaIngredientes_ReceitaId` (`ReceitaId`);

--
-- Índices de tabela `receitas`
--
ALTER TABLE `receitas`
  ADD PRIMARY KEY (`Id`);

--
-- Índices de tabela `unidademedida`
--
ALTER TABLE `unidademedida`
  ADD PRIMARY KEY (`Id`);

--
-- Índices de tabela `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`Id`);

--
-- Índices de tabela `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT para tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `cidades`
--
ALTER TABLE `cidades`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de tabela `empresas`
--
ALTER TABLE `empresas`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de tabela `estados`
--
ALTER TABLE `estados`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de tabela `ingredientes`
--
ALTER TABLE `ingredientes`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de tabela `paises`
--
ALTER TABLE `paises`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de tabela `receitaingredientes`
--
ALTER TABLE `receitaingredientes`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de tabela `receitas`
--
ALTER TABLE `receitas`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de tabela `unidademedida`
--
ALTER TABLE `unidademedida`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT de tabela `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Restrições para tabelas despejadas
--

--
-- Restrições para tabelas `cidades`
--
ALTER TABLE `cidades`
  ADD CONSTRAINT `FK_Cidades_Estados_IdEstado` FOREIGN KEY (`IdEstado`) REFERENCES `estados` (`Id`) ON DELETE CASCADE;

--
-- Restrições para tabelas `empresas`
--
ALTER TABLE `empresas`
  ADD CONSTRAINT `FK_Empresas_Cidades_idcidade` FOREIGN KEY (`idcidade`) REFERENCES `cidades` (`Id`) ON DELETE CASCADE;

--
-- Restrições para tabelas `estados`
--
ALTER TABLE `estados`
  ADD CONSTRAINT `FK_Estados_Paises_IdPais` FOREIGN KEY (`IdPais`) REFERENCES `paises` (`Id`) ON DELETE CASCADE;

--
-- Restrições para tabelas `ingredientes`
--
ALTER TABLE `ingredientes`
  ADD CONSTRAINT `FK_Ingredientes_Empresas_EmpresaId` FOREIGN KEY (`EmpresaId`) REFERENCES `empresas` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_Ingredientes_UnidadeMedida_UnidadeMedidaId` FOREIGN KEY (`UnidadeMedidaId`) REFERENCES `unidademedida` (`Id`) ON DELETE CASCADE;

--
-- Restrições para tabelas `receitaingredientes`
--
ALTER TABLE `receitaingredientes`
  ADD CONSTRAINT `FK_ReceitaIngredientes_Ingredientes_Idingrediente` FOREIGN KEY (`Idingrediente`) REFERENCES `ingredientes` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_ReceitaIngredientes_Receitas_IdReceita` FOREIGN KEY (`IdReceita`) REFERENCES `receitas` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_ReceitaIngredientes_Receitas_ReceitaId` FOREIGN KEY (`ReceitaId`) REFERENCES `receitas` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
