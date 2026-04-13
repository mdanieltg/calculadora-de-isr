namespace CalculadoraDeIsr.Application.Models;

public class Retencion
{
    public decimal BaseGravable { get; set; }
    public decimal LimiteInferior { get; set; }
    public decimal Excedente { get; set; }
    public string TasaSobreExcedente { get; set; } = "";
    public decimal CuotaFija { get; set; }
    public decimal ImpuestoMarginal { get; set; }
    public decimal ImpuestoSobreLaRenta { get; set; }
}
