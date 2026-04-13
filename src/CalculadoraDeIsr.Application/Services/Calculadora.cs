using CalculadoraDeIsr.Application.Models;

namespace CalculadoraDeIsr.Application.Services;

public class Calculadora(IProveedorDeTabuladores proveedorDeTabuladores) : ICalculadoraDeIsr
{
    public Retencion? CalcularIsr(decimal baseGravable, Periodicidad periodicidad)
    {
        Tabulador? tabulador = proveedorDeTabuladores.ObtenerTabulador(periodicidad, baseGravable);
        if (tabulador is null) return null;

        // Calcular excedente restando la cuota fija a la base gravable
        decimal excedente = baseGravable - tabulador.CuotaFija;

        // Calcular el impuesto marginal multiplicando el excedente por la tasa aplicable
        decimal impuestoMarginal = excedente * (decimal)tabulador.TasaExcedente;

        // Suma la cuota fija y el impuesto marginal para obtener la retención
        decimal retencion = tabulador.CuotaFija + impuestoMarginal;

        // TODO: Calcula el subsidio para el empleo (se necesita la UMA del mes)

        return new Retencion
        {
            BaseGravable = baseGravable,
            LimiteInferior = tabulador.LimiteInferior,
            Excedente = excedente,
            TasaSobreExcedente = tabulador.TasaExcedente.ToString("P2"),
            CuotaFija = tabulador.CuotaFija,
            ImpuestoMarginal = impuestoMarginal,
            ImpuestoSobreLaRenta = retencion
        };
    }
}
