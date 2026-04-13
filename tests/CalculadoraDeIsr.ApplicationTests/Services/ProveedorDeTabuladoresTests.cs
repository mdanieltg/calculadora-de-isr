using CalculadoraDeIsr.Application.Models;
using CalculadoraDeIsr.Application.Services;

namespace CalculadoraDeIsr.ApplicationTests.Services;

[TestFixture]
public class ProveedorDeTabuladoresTests
{
    private ProveedorDeTabuladores _sut;

    [SetUp]
    public void Setup()
    {
        _sut = new ProveedorDeTabuladores();
    }

    #region ObtenerTabulador

    [Test]
    public void ObtenerTabulador_ReturnsTabulador_HappyPath()
    {
        // Arrange
        _sut.CargarTablas([
            new Tabla
            {
                Periodicidad = Periodicidad.Diaria,
                Tabuladores =
                [
                    new Tabulador { LimiteInferior = 0, LimiteSuperior = 9 },
                    new Tabulador { LimiteInferior = 10, LimiteSuperior = 19 },
                    new Tabulador { LimiteInferior = 20, LimiteSuperior = decimal.MaxValue }
                ]
            }
        ]);

        // Act
        Tabulador? tabulador = _sut.ObtenerTabulador(Periodicidad.Diaria, 8);

        // Assert
        Assert.That(tabulador, Is.Not.Null);
        Assert.That(tabulador.LimiteInferior, Is.EqualTo(0));
    }

    [Test]
    public void ObtenerTabulador_ReturnsNull_WhenTablasIsEmpty()
    {
        // Act
        Tabulador? tabulador = _sut.ObtenerTabulador(Periodicidad.Mensual, 0);

        // Assert
        Assert.That(tabulador, Is.Null);
    }

    [Test]
    public void ObtenerTabulador_ReturnsNull_WhenNoMatchingPeriodicidad()
    {
        // Arrange
        _sut.CargarTablas([new Tabla { Periodicidad = Periodicidad.Diaria }]);

        // Act
        Tabulador? tabulador = _sut.ObtenerTabulador(Periodicidad.Quincenal, 0);

        // Assert
        Assert.That(tabulador, Is.Null);
    }

    [Test]
    public void ObtenerTabulador_ReturnsNull_WhenTabuladoresIsEmpty()
    {
        // Arrange
        _sut.CargarTablas([new Tabla { Periodicidad = Periodicidad.Mensual }]);

        // Act
        Tabulador? tabulador = _sut.ObtenerTabulador(Periodicidad.Mensual, 0);

        // Assert
        Assert.That(tabulador, Is.Null);
    }

    [Test]
    public void ObtenerTabulador_ReturnsLatestTabulador_WhenNoMatchingTabulador()
    {
        // Arrange
        _sut.CargarTablas([
            new Tabla
            {
                Periodicidad = Periodicidad.Mensual,
                Tabuladores =
                [
                    new Tabulador { LimiteInferior = 0, LimiteSuperior = 9 },
                    new Tabulador { LimiteInferior = 10, LimiteSuperior = 19 },
                    new Tabulador { LimiteInferior = 20, LimiteSuperior = decimal.MaxValue }
                ]
            }
        ]);

        // Act
        Tabulador? tabulador = _sut.ObtenerTabulador(Periodicidad.Mensual, 30);

        // Assert
        Assert.That(tabulador, Is.Not.Null);
        Assert.That(tabulador.LimiteInferior, Is.EqualTo(20));
    }

    #endregion

    #region CargarTablas

    [Test]
    public void CargarTablas_AddsAllTablas_HappyPath()
    {
        // Arrange
        Tabla[] tablas =
        [
            new()
            {
                Periodicidad = Periodicidad.Diaria,
                Tabuladores = [new Tabulador { LimiteInferior = 0, LimiteSuperior = 10 }]
            },
            new()
            {
                Periodicidad = Periodicidad.Mensual,
                Tabuladores = [new Tabulador { LimiteInferior = 0, LimiteSuperior = 100 }]
            }
        ];

        // Act
        _sut.CargarTablas(tablas);

        // Assert
        Assert.That(_sut.ObtenerTabulador(Periodicidad.Diaria, 5), Is.Not.Null);
        Assert.That(_sut.ObtenerTabulador(Periodicidad.Mensual, 50), Is.Not.Null);
        Assert.That(_sut.ObtenerTabulador(Periodicidad.Quincenal, 5), Is.Null);
    }

    [Test]
    public void CargarTablas_SkipsTablas_WhenDuplicatePeriodicidad()
    {
        // Arrange
        Tabla[] tablas =
        [
            new()
            {
                Periodicidad = Periodicidad.Diaria,
                Tabuladores = [new Tabulador { LimiteInferior = 0, LimiteSuperior = 10 }]
            },
            new()
            {
                Periodicidad = Periodicidad.Diaria, // Duplicate
                Tabuladores = [new Tabulador { LimiteInferior = 0, LimiteSuperior = 20 }]
            }
        ];

        // Act
        _sut.CargarTablas(tablas);

        // Assert
        Tabulador? tabulador = _sut.ObtenerTabulador(Periodicidad.Diaria, 5);
        Assert.That(tabulador, Is.Not.Null);
        Assert.That(tabulador.LimiteSuperior, Is.EqualTo(10)); // First one added
    }

    [Test]
    public void CargarTablas_SkipsTablas_WhenEmptyTabuladores()
    {
        // Arrange
        Tabla[] tablas =
        [
            new()
            {
                Periodicidad = Periodicidad.Diaria,
                Tabuladores = [] // Empty
            },
            new()
            {
                Periodicidad = Periodicidad.Mensual,
                Tabuladores = [new Tabulador { LimiteInferior = 0, LimiteSuperior = 10 }]
            }
        ];

        // Act
        _sut.CargarTablas(tablas);

        // Assert
        Assert.That(_sut.ObtenerTabulador(Periodicidad.Diaria, 5), Is.Null);
        Assert.That(_sut.ObtenerTabulador(Periodicidad.Mensual, 5), Is.Not.Null);
    }

    [Test]
    public void CargarTablas_SkipsTablas_WhenLimitesIncorrectos()
    {
        // Arrange
        Tabla[] tablas =
        [
            new()
            {
                Periodicidad = Periodicidad.Diaria,
                Tabuladores = [new Tabulador { LimiteInferior = 10, LimiteSuperior = 5 }] // Incorrecto
            },
            new()
            {
                Periodicidad = Periodicidad.Mensual,
                Tabuladores = [new Tabulador { LimiteInferior = 0, LimiteSuperior = 10 }]
            }
        ];

        // Act
        _sut.CargarTablas(tablas);

        // Assert
        Assert.That(_sut.ObtenerTabulador(Periodicidad.Diaria, 5), Is.Null);
        Assert.That(_sut.ObtenerTabulador(Periodicidad.Mensual, 5), Is.Not.Null);
    }

    [Test]
    public void CargarTablas_SkipsTablas_WhenOverlaps()
    {
        // Arrange
        Tabla[] tablas =
        [
            new()
            {
                Periodicidad = Periodicidad.Diaria,
                Tabuladores =
                [
                    new Tabulador { LimiteInferior = 0, LimiteSuperior = 15 },
                    new Tabulador { LimiteInferior = 10, LimiteSuperior = 20 } // Overlap
                ]
            },
            new()
            {
                Periodicidad = Periodicidad.Mensual,
                Tabuladores = [new Tabulador { LimiteInferior = 0, LimiteSuperior = 10 }]
            }
        ];

        // Act
        _sut.CargarTablas(tablas);

        // Assert
        Assert.That(_sut.ObtenerTabulador(Periodicidad.Diaria, 5), Is.Null);
        Assert.That(_sut.ObtenerTabulador(Periodicidad.Mensual, 5), Is.Not.Null);
    }

    #endregion
}
