using CalculadoraDeIsr.Application.Models;
using CalculadoraDeIsr.Application.Services;
using Moq;

namespace CalculadoraDeIsr.ApplicationTests.Services;

[TestFixture]
public class CalculadoraDeIsrTests
{
    private Mock<IProveedorDeTabuladores> _proveedorDeTabuladores;
    private Calculadora _sut;

    [SetUp]
    public void Setup()
    {
        _proveedorDeTabuladores = new Mock<IProveedorDeTabuladores>();
        _sut = new Calculadora(_proveedorDeTabuladores.Object);
    }

    [Test]
    public void CalcularIsr_ReturnsRetencion_WhenTabuladorExistsAndNoSubsidioApplies()
    {
        // Arrange
        _proveedorDeTabuladores
            .Setup(p => p.ObtenerTabulador(It.IsAny<Periodicidad>(), It.IsAny<decimal>()))
            .Returns(new Tabulador
            {
                LimiteInferior = 1_000,
                LimiteSuperior = 2_000,
                CuotaFija = 500,
                TasaExcedente = 0.2
            });

        // Act
        Retencion? retencion = _sut.CalcularIsr(1_200, Periodicidad.Mensual);

        // Assert
        Assert.That(retencion, Is.Not.Null);
        Assert.That(retencion.BaseGravable, Is.EqualTo(1_200));
        Assert.That(retencion.LimiteInferior, Is.EqualTo(1_000));
        Assert.That(retencion.TasaSobreExcedente, Is.EqualTo("20.00%"));
        Assert.That(retencion.CuotaFija, Is.EqualTo(500));
        Assert.That(retencion.Excedente, Is.EqualTo(200));
        Assert.That(retencion.ImpuestoMarginal, Is.EqualTo(40));
        Assert.That(retencion.ImpuestoSobreLaRenta, Is.EqualTo(540));
    }

    [Test]
    public void CalcularIsr_ReturnsRetencion_WhenTabuladorExistsAndSubsidioApplies()
    {
        // Arrange - Subsidio not implemented yet, so same as no subsidio
        _proveedorDeTabuladores
            .Setup(p => p.ObtenerTabulador(It.IsAny<Periodicidad>(), It.IsAny<decimal>()))
            .Returns(new Tabulador
            {
                LimiteInferior = 1_000,
                LimiteSuperior = 2_000,
                CuotaFija = 500,
                TasaExcedente = 0.2
            });

        // Act
        Retencion? retencion = _sut.CalcularIsr(1_200, Periodicidad.Mensual);

        // Assert - Same as no subsidio since not implemented
        Assert.That(retencion, Is.Not.Null);
        Assert.That(retencion.BaseGravable, Is.EqualTo(1_200));
        Assert.That(retencion.LimiteInferior, Is.EqualTo(1_000));
        Assert.That(retencion.TasaSobreExcedente, Is.EqualTo("20.00%"));
        Assert.That(retencion.CuotaFija, Is.EqualTo(500));
        Assert.That(retencion.Excedente, Is.EqualTo(200));
        Assert.That(retencion.ImpuestoMarginal, Is.EqualTo(40));
        Assert.That(retencion.ImpuestoSobreLaRenta, Is.EqualTo(540));
    }

    [Test]
    public void CalcularIsr_ReturnsNull_WhenTabuladorDoesNotExist()
    {
        // Arrange
        _proveedorDeTabuladores
            .Setup(p => p.ObtenerTabulador(It.IsAny<Periodicidad>(), It.IsAny<decimal>()))
            .Returns(null as Tabulador);

        // Act
        Retencion? retencion = _sut.CalcularIsr(100, Periodicidad.Mensual);

        // Assert
        Assert.That(retencion, Is.Null);
    }
}
