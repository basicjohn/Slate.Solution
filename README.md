### Slate.Solution

_By Jeremy Banka, Ahmed Ghouzlane, Tom Geraghty, and John Edmondson_

## Technologies Used

- 🎵 C# / .NET 5 Framework
- 🔥 Blazor Integrated WebAssembly Frontend + Server
- 📡 Real-time ASP.NET with SignalR
- 👇 Entity Framework Core
- 🧮 MySQL Database
- 🪒 Razor Templating
- 💅 SCSS to CSS via Ritwick's Live Sass Compiler
- 🛠️ Tooling: Omnisharp
- 🅰️ Font: JetBrains Mono

## Description

This is an exercise in implementing user authentication and a simple authorization protocol using Microsoft AspNetCore.

## Setup/Installation Requirements

- Get the source code: `$ git clone https://github.com/jeremybanka/Slate.Solution`
- Set up necessary database schema
  - Install Entity Framework CLI: `$ dotnet tool install --global dotnet-ef`
  - Build your database: in `Server/`, run `dotnet ef database update`
- Add `appsettings.json` in `Server/` and paste in the following text:

  ```json
  {
    "AppSettings": {
      "Secret": "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$"
    },
    "Logging": {
      "LogLevel": {
        "Default": "Information",
        "Microsoft": "Warning",
        "Microsoft.Hosting.Lifetime": "Information"
      }
    },
    "AllowedHosts": "*",
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=slate;uid=root;pwd=************;"
    }
  }
  ```

  except, instead of `************` put your password for MySQL.

  and instead of "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$" put a secret string of equivalent length or longer.

- Compile and run the app as you save changes: `$ dotnet watch run` in `Server/` (This command will also install necessary dependencies.)

## Known Bugs

- none identified

## License

Gnu Public License ^3.0

## Contact Information

```
JEREMY:   hello at jeremybanka dot com
USARNEME: jamestcoop at gmail dot com
JOHN:     edmondsonj at gmail dot com
AHMED:    ahmedghouzlane at gmail dot com
```
