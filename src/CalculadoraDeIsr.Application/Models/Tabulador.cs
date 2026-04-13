namespace CalculadoraDeIsr.Application.Models;

public class Tabulador
{
    public decimal LimiteInferior { get; init; }
    public decimal LimiteSuperior { get; init; }
    public decimal CuotaFija { get; init; }
    public double TasaExcedente { get; init; }
}
