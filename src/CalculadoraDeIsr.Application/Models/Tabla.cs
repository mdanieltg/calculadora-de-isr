using System.Collections.Generic;

namespace CalculadoraDeIsr.Application.Models;

public class Tabla
{
    public Periodicidad Periodicidad { get; init; }
    public List<Tabulador> Tabuladores { get; internal set; } = [];
}
