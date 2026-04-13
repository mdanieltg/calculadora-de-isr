# ISR Calculator

This is a web application developed with Blazor to calculate Mexican Income Tax (ISR). It uses official withholding tables to provide accurate calculations based on income and periodicity.

## Features

- Accurate ISR calculation based on official Mexican withholding tables.
- Modern and responsive web interface built with Blazor.
- Support for different periodicities (monthly, bi-weekly, etc.).
- Modular architecture with separation of layers (Application and WebApp).

## Installation

### Prerequisites

- .NET 10.0 or higher
- A modern web browser

### Steps

1. Clone the repository:
   ```
   git clone <REPOSITORY_URL>
   cd CalculadoraDeIsr
   ```

2. Restore NuGet packages:
   ```
   dotnet restore
   ```

3. Run the application:
   ```
   cd src/CalculadoraDeIsr.BlazorWebApp
   dotnet run
   ```

4. Open your browser and go to `https://localhost:5001` (or the port specified in the console).

## Usage

1. Open the application in your browser.
2. Enter your gross income and select the periodicity.
3. The application will automatically calculate the ISR to withhold.
4. Review the results in the interface.

## Project Structure

- `src/CalculadoraDeIsr.Application/`: Business logic and models.
- `src/CalculadoraDeIsr.BlazorWebApp/`: Web interface with Blazor.
- `tests/CalculadoraDeIsr.ApplicationTests/`: Unit tests.

## Contributing

Contributions are welcome. Please follow these steps:

1. Fork the project.
2. Create a branch for your feature (`git checkout -b feature/new-feature`).
3. Make your changes and write tests if necessary.
4. Run the tests: `dotnet test`.
5. Submit a pull request.

## License

This project is under the MIT License. See the [LICENSE](LICENSE) file for more details.

## Contact

If you have questions or suggestions, please open an issue in the repository.
