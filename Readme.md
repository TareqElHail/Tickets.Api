# .NET Core API

This is a .NET Core API project designed to perform CRUD operations. This guide will help you set up, configure the database connection, and apply migrations to launch the API successfully.

## Prerequisites

Before running this project, ensure you have the following installed:

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or another compatible database.
- An IDE (e.g., [Visual Studio](https://visualstudio.microsoft.com/), [Visual Studio Code](https://code.visualstudio.com/)).

## Steps to Launch

### 1. Clone the Repository

```bash
git clone https://github.com/your-repo-name/your-project.git
cd your-project

### 2. Update the Database Connection String

- Open the appsettings.json file located at the root of the project.
- Then update the connection string to macth your localDb

### 3. Apply Database Migrations

- Open a terminal or command prompt in the project directory.
- Run This Commands :
	dotnet ef database update
	