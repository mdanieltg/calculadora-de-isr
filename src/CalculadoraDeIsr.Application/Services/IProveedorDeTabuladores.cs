using CalculadoraDeIsr.Application.Models;

namespace CalculadoraDeIsr.Application.Services;

public interface IProveedorDeTabuladores
{
    Tabulador? ObtenerTabulador(Periodicidad periodicidad, decimal baseGravable);
    void CargarTablas(IEnumerable<Tabla> tabuladores);
}
