# Pa-Note

Pa-Note is a simple task management web application built with ASP.NET Core Razor Pages. It helps you organize your to-do list and manage tasks with a clean, user-friendly interface.

## Features
- User registration with first name, last name, email, and password
- Login with feedback messages (success, wrong password, already registered, etc.)
- Personalized dashboard greeting after login
- Responsive and modern UI
- Uses SQL Server Management Studio for the Database 
- Server-side and client-side validation for forms

## Getting Started

### Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0) (or update the target framework in the project file to match your installed version)

### Running the Project
1. Open a terminal in the project root directory.
2. Run:
   ```
   dotnet run --project WebApplication5/WebApplication5.csproj
   ```
3. Open your browser and go to the URL shown in the terminal (usually `https://localhost:xxxx` or `http://localhost:xxxx`).

## Project Structure
- `Pages/Account/` - Contains registration and login pages
- `Pages/Dashboard.cshtml` - User dashboard after login
- `Pages/Shared/_Layout.cshtml` - Main layout and navigation
- `wwwroot/` - Static files (CSS, images, etc.)


## License
This project is for educational/demo purposes. 
