# Calculadora de ISR

[Read in English](README.en.md)

Esta es una aplicación web desarrollada con Blazor para calcular el Impuesto Sobre la Renta (ISR) en México. Utiliza tablas oficiales de retención para proporcionar cálculos precisos basados en ingresos y periodicidad.

## Características

- Cálculo preciso del ISR basado en las tablas de retención oficiales mexicanas.
- Interfaz web moderna y responsiva construida con Blazor.
- Soporte para diferentes periodicidades (mensual, quincenal, etc.).
- Arquitectura modular con separación de capas (Application y WebApp).

## Instalación

### Prerrequisitos

- .NET 10.0 o superior
- Un navegador web moderno

### Pasos

1. Clona el repositorio:
   ```
   git clone <URL_DEL_REPOSITORIO>
   cd CalculadoraDeIsr
   ```

2. Restaura los paquetes NuGet:
   ```
   dotnet restore
   ```

3. Ejecuta la aplicación:
   ```
   cd src/CalculadoraDeIsr.BlazorWebApp
   dotnet run
   ```

4. Abre tu navegador y ve a `https://localhost:5001` (o el puerto especificado en la consola).

## Uso

1. Abre la aplicación en tu navegador.
2. Ingresa tu ingreso bruto y selecciona la periodicidad.
3. La aplicación calculará automáticamente el ISR a retener.
4. Revisa los resultados en la interfaz.

## Estructura del Proyecto

- `src/CalculadoraDeIsr.Application/`: Lógica de negocio y modelos.
- `src/CalculadoraDeIsr.BlazorWebApp/`: Interfaz web con Blazor.
- `tests/CalculadoraDeIsr.ApplicationTests/`: Pruebas unitarias.

## Contribución

Las contribuciones son bienvenidas. Por favor, sigue estos pasos:

1. Haz un fork del proyecto.
2. Crea una rama para tu feature (`git checkout -b feature/nueva-funcionalidad`).
3. Realiza tus cambios y escribe pruebas si es necesario.
4. Ejecuta las pruebas: `dotnet test`.
5. Envía un pull request.

## Licencia

Este proyecto está bajo la Licencia GNU GPLv3. Ver el archivo [LICENSE](LICENSE) para más detalles.

## Contacto

Si tienes preguntas o sugerencias, por favor abre un issue en el repositorio.
