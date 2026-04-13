using CalculadoraDeIsr.Application.Models;

namespace CalculadoraDeIsr.Application.Services;

public class ProveedorDeTabuladores : IProveedorDeTabuladores
{
    private readonly Dictionary<Periodicidad, Tabla> _tablas = [];

    public Tabulador? ObtenerTabulador(Periodicidad periodicidad, decimal baseGravable)
    {
        _tablas.TryGetValue(periodicidad, out Tabla? tabla);

        return tabla?.Tabuladores.LastOrDefault(t => t.LimiteInferior <= baseGravable);
    }

    public void CargarTablas(IEnumerable<Tabla> tablas)
    {
        foreach (Tabla tabla in tablas)
        {
            // Periodicidad duplicada
            if (_tablas.ContainsKey(tabla.Periodicidad))
                continue;

            // Sin tabuladores
            if (tabla.Tabuladores.Count == 0)
                continue;

            // Límites incorrectamente definidos
            if (tabla.Tabuladores.Any(t => t.LimiteInferior >= t.LimiteSuperior))
                continue;

            // Límites inferiores y superiores superpuestos
            var sortedTabuladores = tabla.Tabuladores.OrderBy(t => t.LimiteInferior).ToList();
            bool overlap = sortedTabuladores
                .Zip(sortedTabuladores.Skip(1), (a, b) => a.LimiteSuperior > b.LimiteInferior)
                .Any(x => x);

            if (overlap)
                continue;

            tabla.Tabuladores = sortedTabuladores;
            _tablas[tabla.Periodicidad] = tabla;
        }
    }
}
