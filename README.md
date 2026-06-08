# Cosmic Codex 🌌

Cosmic Codex is a full-stack web application built to catalog and manage discovered star systems and their respective planets. It serves as a digital cosmic journal, featuring a robust API backend and a responsive user interface.

## 🚀 Features

* **Star System Management:** Discover, register, update, and delete star systems.
* **Planet Cataloging:** Add planets and link them to their host star systems.
* **Habitability Tracking:** Keep track of which planets are capable of sustaining life.
* **Responsive UI:** A modern and user-friendly web interface.

## 🛠️ Technologies Used

* **Backend:** ASP.NET Core Web API (.NET 8)
* **Frontend:** Blazor Server (.NET 8)
* **Database:** SQL Server
* **ORM:** Entity Framework Core
* **Styling:** Bootstrap 5 & CSS
* **Architecture:** Repository Pattern, Dependency Injection (DI), and Data Transfer Objects (DTOs)

## 📁 Project Structure

The solution is divided into two main projects:

1. `CosmicCodex.Api` - The backend API responsible for data processing, business logic, and database communication.
2. `CosmicCodex.Frontend` - The Blazor-based frontend client that interacts with the API to display and manage data.

## ⚙️ Getting Started

Follow these steps to run the application locally on your machine.

### Prerequisites
* [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
* SQL Server (e.g., SQL Server Express or LocalDB)
* Visual Studio 2022, VS Code, or another preferred IDE

### 1. Set Up the Database

The project uses Entity Framework Core for database management. You need to apply the existing migrations to create the database schema.

Open your terminal or Package Manager Console in the `CosmicCodex.Api` directory and run:

``bash
dotnet ef database update

Note: Ensure your connection string in appsettings.json is correctly pointing to your local SQL Server instance before running the update.


## 2. Run the Backend API
Start the backend server first so the frontend has an API to communicate with.
Navigate to the CosmicCodex.Api folder and run:

Bash
dotnet run
The API should now be running (typically on https://localhost:7155). You can access the Swagger documentation at https://localhost:7155/swagger to test the endpoints directly.

## 3. Run the Frontend Client
Open a new terminal window, navigate to the CosmicCodex.Frontend folder, and run:

Bash
dotnet run
The Blazor application will launch. Open the provided localhost URL in your web browser to start exploring the Cosmic Codex!
