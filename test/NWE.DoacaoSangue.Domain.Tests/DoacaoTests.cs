﻿using Moq;
using NWE.DoacaoSangue.Domain.Entities;
using NWE.DoacaoSangue.Domain.Enums;
using NWE.DoacaoSangue.Domain.Exceptions;
using NWE.DoacaoSangue.Domain.Repositories;

namespace NWE.DoacaoSangue.Domain.Tests;

public class DoacaoTests
{
    [Fact(DisplayName = "Sucesso")]
    public void Doacao_NovaDoacao_Sucesso()
    {
        //Arrange
        Mock<IDoadorRepository> repositoryDoador = new();
        Mock<IDoacaoRepository> repositoryDoacao = new();

        Doador doador = new(
            repositoryDoador.Object,
            "Thiago Majarão Longo",
            "majarao@outlook.com",
            new(1990, 4, 7),
            EGenero.MASCULINO,
            95,
            ETipoSanguineo.A,
            EFatorRH.POSITIVO,
            null);

        repositoryDoador.Setup(s => s.GetByIdAsync(doador.Id).Result).Returns(doador);

        //Act
        Doacao doacao = new(
            repositoryDoador.Object,
            repositoryDoacao.Object,
            doador.Id,
            DateTime.Now,
            450);

        //Assert
        Assert.True(doacao is not null);
    }

    [Fact(DisplayName = "Falha Doador Nao Encontrado")]
    public void Doacao_NovaDoacao_FalhaDoadorNaoEncontrado()
    {
        //Arrange
        Mock<IDoadorRepository> repositoryDoador = new();
        Mock<IDoacaoRepository> repositoryDoacao = new();

        //Act Assert
        Assert.Throws<DoacaoDoadorNaoEncontradoException>(() =>
        {
            Doacao doacao = new(
            repositoryDoador.Object,
            repositoryDoacao.Object,
            Guid.NewGuid(),
            DateTime.Now,
            450);
        });
    }

    [Fact(DisplayName = "Falha Doador Menor Idade")]
    public void Doacao_NovaDoacao_FalhaDoadorMenorIdade()
    {
        //Arrange
        Mock<IDoadorRepository> repositoryDoador = new();
        Mock<IDoacaoRepository> repositoryDoacao = new();

        Doador doador = new(
            repositoryDoador.Object,
            "Thiago Majarão Longo",
            "majarao@outlook.com",
            new(2007, 4, 7),
            EGenero.MASCULINO,
            95,
            ETipoSanguineo.A,
            EFatorRH.POSITIVO,
            null);

        repositoryDoador.Setup(s => s.GetByIdAsync(doador.Id).Result).Returns(doador);

        //Act Assert
        Assert.Throws<DoacaoDoadorMenorIdadeException>(() =>
        {
            Doacao doacao = new(
            repositoryDoador.Object,
            repositoryDoacao.Object,
            doador.Id,
            DateTime.Now,
            450);
        });
    }

    [Fact(DisplayName = "Falha Doador Intervalo Mulheres")]
    public void Doacao_NovaDoacao_FalhaIntervaloMulheres()
    {
        //Arrange
        Mock<IDoadorRepository> repositoryDoador = new();
        Mock<IDoacaoRepository> repositoryDoacao = new();

        Doador doador = new(
            repositoryDoador.Object,
            "Maria",
            "maria@outlook.com",
            new(1990, 4, 7),
            EGenero.FEMININO,
            95,
            ETipoSanguineo.A,
            EFatorRH.POSITIVO,
            null);

        repositoryDoador.Setup(s => s.GetByIdAsync(doador.Id).Result).Returns(doador);

        Doacao ultimaDoacao = new(repositoryDoador.Object, repositoryDoacao.Object, doador.Id, DateTime.Now.AddDays(-45), 450);

        repositoryDoacao.Setup(s => s.RecuperaUltimaDoacaoDoDoadorAsync(doador.Id).Result).Returns(ultimaDoacao);

        //Act Assert
        Assert.Throws<DoacaoIntervaloParaMulheresException>(() =>
        {
            Doacao doacao = new(
            repositoryDoador.Object,
            repositoryDoacao.Object,
            doador.Id,
            DateTime.Now,
            450);
        });
    }

    [Fact(DisplayName = "Falha Doador Intervalo Homens")]
    public void Doacao_NovaDoacao_FalhaIntervaloHomens()
    {
        //Arrange
        Mock<IDoadorRepository> repositoryDoador = new();
        Mock<IDoacaoRepository> repositoryDoacao = new();

        Doador doador = new(
            repositoryDoador.Object,
            "Maria",
            "maria@outlook.com",
            new(1990, 4, 7),
            EGenero.MASCULINO,
            95,
            ETipoSanguineo.A,
            EFatorRH.POSITIVO,
            null);

        repositoryDoador.Setup(s => s.GetByIdAsync(doador.Id).Result).Returns(doador);

        Doacao ultimaDoacao = new(repositoryDoador.Object, repositoryDoacao.Object, doador.Id, DateTime.Now.AddDays(-45), 450);

        repositoryDoacao.Setup(s => s.RecuperaUltimaDoacaoDoDoadorAsync(doador.Id).Result).Returns(ultimaDoacao);

        //Act Assert
        Assert.Throws<DoacaoIntervaloParaHomensException>(() =>
        {
            Doacao doacao = new(
            repositoryDoador.Object,
            repositoryDoacao.Object,
            doador.Id,
            DateTime.Now,
            450);
        });
    }

    [Fact(DisplayName = "Falha Quantidade Nao Esperada")]
    public void Doacao_NovaDoacao_FalhaQuantidadeNaoEsperada()
    {
        //Arrange
        Mock<IDoadorRepository> repositoryDoador = new();
        Mock<IDoacaoRepository> repositoryDoacao = new();

        Doador doador = new(
            repositoryDoador.Object,
            "Maria",
            "maria@outlook.com",
            new(1990, 4, 7),
            EGenero.MASCULINO,
            95,
            ETipoSanguineo.A,
            EFatorRH.POSITIVO,
            null);

        repositoryDoador.Setup(s => s.GetByIdAsync(doador.Id).Result).Returns(doador);

        //Act Assert
        Assert.Throws<DoacaoQuantidadeEsperadaException>(() =>
        {
            Doacao doacao = new(
            repositoryDoador.Object,
            repositoryDoacao.Object,
            doador.Id,
            DateTime.Now,
            100);
        });
    }
}
