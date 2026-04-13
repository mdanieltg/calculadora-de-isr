using CalculadoraDeIsr.Application.Models;
using CalculadoraDeIsr.Application.Services;

namespace CalculadoraDeIsr.BlazorWebApp.Extensions;

public static class TabuladoresExtensions
{
    public static void AgregarTabuladores(this IServiceCollection services)
    {
        services.AddSingleton<IProveedorDeTabuladores>(_ =>
        {
            ProveedorDeTabuladores proveedor = new();

            // Tablas 2026
            Tabla[] tablas =
            [
                new()
                {
                    Periodicidad = Periodicidad.Mensual,
                    Tabuladores =
                    [
                        new Tabulador
                        {
                            LimiteInferior = 0.01m, LimiteSuperior = 844.59m,
                            CuotaFija = 0.00m, TasaExcedente = 0.0192d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 844.60m, LimiteSuperior = 7168.51m,
                            CuotaFija = 16.22m, TasaExcedente = 0.0640d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 7168.52m, LimiteSuperior = 12598.02m,
                            CuotaFija = 420.95m, TasaExcedente = 0.1088d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 12598.03m, LimiteSuperior = 14644.64m,
                            CuotaFija = 1011.68m, TasaExcedente = 0.1600d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 14644.65m, LimiteSuperior = 17533.64m,
                            CuotaFija = 1339.14m, TasaExcedente = 0.1792d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 17533.65m, LimiteSuperior = 35362.83m,
                            CuotaFija = 1856.84m, TasaExcedente = 0.2136d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 35362.84m, LimiteSuperior = 55736.68m,
                            CuotaFija = 5665.16m, TasaExcedente = 0.2352d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 55736.69m, LimiteSuperior = 106410.50m,
                            CuotaFija = 10457.09m, TasaExcedente = 0.3000d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 106410.51m, LimiteSuperior = 141880.66m,
                            CuotaFija = 25659.23m, TasaExcedente = 0.3200d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 141880.67m, LimiteSuperior = 425641.99m,
                            CuotaFija = 37009.69m, TasaExcedente = 0.3400d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 425642.00m, LimiteSuperior = decimal.MaxValue,
                            CuotaFija = 133488.54m, TasaExcedente = 0.3500d
                        }
                    ]
                },
                new()
                {
                    Periodicidad = Periodicidad.Quincenal,
                    Tabuladores =
                    [
                        new Tabulador
                        {
                            LimiteInferior = 0.01m, LimiteSuperior = 416.70m,
                            CuotaFija = 0.00m, TasaExcedente = 0.0192d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 416.71m, LimiteSuperior = 3537.15m,
                            CuotaFija = 7.95m, TasaExcedente = 0.0640d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 3537.16m, LimiteSuperior = 6216.15m,
                            CuotaFija = 207.75m, TasaExcedente = 0.1088d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 6216.16m, LimiteSuperior = 7225.95m,
                            CuotaFija = 499.20m, TasaExcedente = 0.1600d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 7225.96m, LimiteSuperior = 8651.40m,
                            CuotaFija = 660.75m, TasaExcedente = 0.1792d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 8651.41m, LimiteSuperior = 17448.75m,
                            CuotaFija = 916.20m, TasaExcedente = 0.2136d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 17448.76m, LimiteSuperior = 27501.60m,
                            CuotaFija = 2795.25m, TasaExcedente = 0.2352d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 27501.61m, LimiteSuperior = 52505.25m,
                            CuotaFija = 5159.70m, TasaExcedente = 0.3000d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 52505.26m, LimiteSuperior = 70006.95m,
                            CuotaFija = 12660.75m, TasaExcedente = 0.3200d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 70006.96m, LimiteSuperior = 210020.70m,
                            CuotaFija = 18261.30m, TasaExcedente = 0.3400d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 210020.71m, LimiteSuperior = decimal.MaxValue,
                            CuotaFija = 65866.05m, TasaExcedente = 0.3500d
                        }
                    ]
                },
                new()
                {
                    Periodicidad = Periodicidad.Decenal,
                    Tabuladores =
                    [
                        new Tabulador
                        {
                            LimiteInferior = 0.01m, LimiteSuperior = 277.80m,
                            CuotaFija = 0.00m, TasaExcedente = 0.0192d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 277.81m, LimiteSuperior = 2358.10m,
                            CuotaFija = 5.30m, TasaExcedente = 0.0640d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 2358.11m, LimiteSuperior = 4144.10m,
                            CuotaFija = 138.50m, TasaExcedente = 0.1088d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 4144.11m, LimiteSuperior = 4817.30m,
                            CuotaFija = 332.80m, TasaExcedente = 0.1600d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 4817.31m, LimiteSuperior = 5767.60m,
                            CuotaFija = 440.50m, TasaExcedente = 0.1792d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 5767.61m, LimiteSuperior = 11632.50m,
                            CuotaFija = 610.80m, TasaExcedente = 0.2136d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 11632.51m, LimiteSuperior = 18334.40m,
                            CuotaFija = 1863.50m, TasaExcedente = 0.2352d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 18334.41m, LimiteSuperior = 35003.50m,
                            CuotaFija = 3439.80m, TasaExcedente = 0.3000d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 35003.51m, LimiteSuperior = 46671.30m,
                            CuotaFija = 8440.50m, TasaExcedente = 0.3200d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 46671.31m, LimiteSuperior = 140013.80m,
                            CuotaFija = 12174.20m, TasaExcedente = 0.3400d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 140013.81m, LimiteSuperior = decimal.MaxValue,
                            CuotaFija = 43910.70m, TasaExcedente = 0.3500d
                        }
                    ]
                },
                new()
                {
                    Periodicidad = Periodicidad.Semanal,
                    Tabuladores =
                    [
                        new Tabulador
                        {
                            LimiteInferior = 0.01m, LimiteSuperior = 194.46m,
                            CuotaFija = 0.00m, TasaExcedente = 0.0192d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 194.47m, LimiteSuperior = 1650.67m,
                            CuotaFija = 3.71m, TasaExcedente = 0.0640d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 1650.68m, LimiteSuperior = 2900.87m,
                            CuotaFija = 96.95m, TasaExcedente = 0.1088d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 2900.88m, LimiteSuperior = 3372.11m,
                            CuotaFija = 232.96m, TasaExcedente = 0.1600d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 3372.12m, LimiteSuperior = 4037.32m,
                            CuotaFija = 308.35m, TasaExcedente = 0.1792d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 4037.33m, LimiteSuperior = 8142.75m,
                            CuotaFija = 427.56m, TasaExcedente = 0.2136d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 8142.76m, LimiteSuperior = 12834.08m,
                            CuotaFija = 1304.45m, TasaExcedente = 0.2352d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 12834.09m, LimiteSuperior = 24502.45m,
                            CuotaFija = 2407.86m, TasaExcedente = 0.3000d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 24502.46m, LimiteSuperior = 32669.91m,
                            CuotaFija = 5908.35m, TasaExcedente = 0.3200d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 32669.92m, LimiteSuperior = 98009.66m,
                            CuotaFija = 8521.94m, TasaExcedente = 0.3400d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 98009.67m, LimiteSuperior = decimal.MaxValue,
                            CuotaFija = 30737.49m, TasaExcedente = 0.3500d
                        }
                    ]
                },
                new()
                {
                    Periodicidad = Periodicidad.Diaria,
                    Tabuladores =
                    [
                        new Tabulador
                        {
                            LimiteInferior = 0.01m, LimiteSuperior = 27.78m,
                            CuotaFija = 0.00m, TasaExcedente = 0.0192d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 27.79m, LimiteSuperior = 235.81m,
                            CuotaFija = 0.53m, TasaExcedente = 0.0640d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 235.82m, LimiteSuperior = 414.41m,
                            CuotaFija = 13.85m, TasaExcedente = 0.1088d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 414.42m, LimiteSuperior = 481.73m,
                            CuotaFija = 33.28m, TasaExcedente = 0.1600d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 481.74m, LimiteSuperior = 576.76m,
                            CuotaFija = 44.05m, TasaExcedente = 0.1792d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 576.77m, LimiteSuperior = 1163.25m,
                            CuotaFija = 61.08m, TasaExcedente = 0.2136d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 1163.26m, LimiteSuperior = 1833.44m,
                            CuotaFija = 186.35m, TasaExcedente = 0.2352d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 1833.45m, LimiteSuperior = 3500.35m,
                            CuotaFija = 343.98m, TasaExcedente = 0.3000d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 3500.36m, LimiteSuperior = 4667.13m,
                            CuotaFija = 844.05m, TasaExcedente = 0.3200d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 4667.14m, LimiteSuperior = 14001.38m,
                            CuotaFija = 1217.42m, TasaExcedente = 0.3400d
                        },
                        new Tabulador
                        {
                            LimiteInferior = 14001.39m, LimiteSuperior = decimal.MaxValue,
                            CuotaFija = 4391.07m, TasaExcedente = 0.3500d
                        }
                    ]
                }
            ];

            proveedor.CargarTablas(tablas);
            return proveedor;
        });
    }
}
