using Moq;
using NWE.DoacaoSangue.Domain.Entities;
using NWE.DoacaoSangue.Domain.Enums;
using NWE.DoacaoSangue.Domain.Exceptions;
using NWE.DoacaoSangue.Domain.Repositories;
using NWE.DoacaoSangue.Shared.Integrations;

namespace NWE.DoacaoSangue.Domain.Tests;

public class DoadorTests
{
    [Fact(DisplayName = "Sucesso Sem Endereco")]
    [Trait("Doador", "Novo Doador")]
    public void Doador_NovoDoadorSemEndereco_Sucesso()
    {
        //Arrange
        Mock<IDoadorRepository> repository = new();

        //Act
        Doador doador = new(
            repository.Object,
            "Thiago Majarão Longo",
            "majarao@outlook.com",
            new(1990, 4, 7),
            EGenero.MASCULINO,
            95,
            ETipoSanguineo.A,
            EFatorRH.POSITIVO,
            null);

        //Assert
        Assert.True(doador is not null);
    }

    [Fact(DisplayName = "Sucesso Com Endereco")]
    [Trait("Doador", "Novo Doador")]
    public void Doador_NovoDoadorComEndereco_Sucesso()
    {
        //Arrange
        Mock<IDoadorRepository> repository = new();
        Mock<ICEPService> cepService = new();

        cepService.Setup(s => s.RecuperarEnderecoPeloCEPAsync("14802-790").Result)
            .Returns(new CEPModel()
            {
                Logradouro = "Avenida Gumercindo Siqueira",
                Localidade = "Araraquara",
                Estado = "SP"
            });

        //Act
        Endereco endereco = new(cepService.Object, "14802-790");

        Doador doador = new(
            repository.Object,
            "Thiago Majarão Longo",
            "majarao@outlook.com",
            new(1990, 4, 7),
            EGenero.MASCULINO,
            95,
            ETipoSanguineo.A,
            EFatorRH.POSITIVO,
            endereco);

        //Assert
        Assert.True(doador is not null);
    }

    [Fact(DisplayName = "Falha Endereco Invalido")]
    [Trait("Doador", "Novo Doador")]
    public void Doador_NovoDoadorComEndereco_FalhaCEPInvalido()
    {
        //Arrange
        Mock<ICEPService> cepService = new();

        //Act Assert
        Assert.Throws<DoadorCEPException>(() =>
        {
            Endereco endereco = new(cepService.Object, "xxxxx");
        });
    }

    [Fact(DisplayName = "Falha Endereco Nao Encontrado")]
    [Trait("Doador", "Novo Doador")]
    public void Doador_NovoDoadorComEndereco_FalhaCEPNaoEncontrado()
    {
        //Arrange
        Mock<ICEPService> cepService = new();

        //Act Assert
        Assert.Throws<DoadorCEPException>(() =>
        {
            Endereco endereco = new(cepService.Object, "14810-790");
        });
    }

    [Fact(DisplayName = "Falha Email Utilizado")]
    [Trait("Doador", "Novo Doador")]
    public void Doador_NovoDoador_FalhaEmailUtilizado()
    {
        //Arrange
        Mock<IDoadorRepository> repository = new();

        Doador doadorEmail = new(
            repository.Object,
            "Thiago Majarão Longo",
            "majarao2@outlook.com",
            new(1990, 4, 7),
            EGenero.MASCULINO,
            95,
            ETipoSanguineo.A,
            EFatorRH.POSITIVO,
            null);

        repository.Setup(s => s.GetByEmailAsync("majarao2@outlook.com").Result).Returns(doadorEmail.Id);

        //Act Assert
        Assert.Throws<DoadorEmailUtilizadoException>(() =>
        {
            Doador doador = new(
                repository.Object,
                "Thiago Majarão Longo",
                "majarao2@outlook.com",
                new(1990, 4, 7),
                EGenero.MASCULINO,
                95,
                ETipoSanguineo.A,
                EFatorRH.POSITIVO,
                null);
        });
    }

    [Fact(DisplayName = "Falha Peso Minimo")]
    [Trait("Doador", "Novo Doador")]
    public void Doador_NovoDoador_FalhaPesoMinimo()
    {
        //Arrange
        Mock<IDoadorRepository> repository = new();

        //Act Assert
        Assert.Throws<DoadorPesoMinimoException>(() =>
        {
            Doador doador = new(
                repository.Object,
                "Thiago Majarão Longo",
                "majarao3@outlook.com",
                new(1990, 4, 7),
                EGenero.MASCULINO,
                45,
                ETipoSanguineo.A,
                EFatorRH.POSITIVO,
                null);
        });
    }

    [Fact(DisplayName = "Falha 16 Anos")]
    [Trait("Doador", "Novo Doador")]
    public void Doador_NovoDoador_Falha16Anos()
    {
        //Arrange
        Mock<IDoadorRepository> repository = new();

        //Act Assert
        Assert.Throws<DoadorPrecisaTer16AnosException>(() =>
        {
            Doador doador = new(
                repository.Object,
                "Thiago Majarão Longo",
                "majarao3@outlook.com",
                new(2020, 4, 7),
                EGenero.MASCULINO,
                70,
                ETipoSanguineo.A,
                EFatorRH.POSITIVO,
                null);
        });
    }
}
