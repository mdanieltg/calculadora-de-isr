using CalculadoraDeIsr.Application.Models;

namespace CalculadoraDeIsr.Application.Services;

public interface ICalculadoraDeIsr
{
    Retencion? CalcularIsr(decimal ingresoBruto, Periodicidad periodicidad);
}
