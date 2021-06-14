### SweetSavory.Solution

_By Jeremy Banka_

## Technologies Used

- 🎵 C# / .NET 5 Framework
- 🎛️ ASP.NET Core Server
- 👇 Entity Framework Core
- 🧮 MySQL Database
- 🪒 Razor Templating
- 💅 SCSS to CSS via Ritwick's Live Sass Compiler
- 🛠️ Tooling: Omnisharp
- 🅰️ Font: Palatino by Hermann Zapf (PBUH)

## Description

This is an exercise in implementing user authentication and a simple authorization protocol using Microsoft AspNetCore.

## Setup/Installation Requirements

- Get the source code: `$ git clone https://github.com/jeremybanka/SweetSavory.Solution`
- Set up necessary database schema
  - Install Entity Framework CLI: `$ dotnet tool install --global dotnet-ef`
  - Build your database: in `SweetSavory/`, run `dotnet ef database update`
- Add `appsettings.json` in `SweetSavory/` and paste in the following text:

  ```json
  {
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=sweet_savory;uid=root;pwd=************;"
    }
  }
  ```

  except, instead of `************` put your password for MySQL.

- Compile and run the app as you save changes: `$ dotnet watch run` in `SweetSavory/` (This command will also install necessary dependencies.)

## Known Bugs

- none identified

## License

Gnu Public License ^3.0

## Contact Information

hello at jeremybanka dot com
