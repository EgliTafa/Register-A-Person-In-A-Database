# Register A Person In A Database Application

This application allows users to register and manage person data through a Windows Forms interface, utilizing a Web API backend built with .NET 6 and Microsoft SQL Server. The backend follows a repository pattern for data management and uses JWT (JSON Web Tokens) for secure user authentication.

## Technologies Used

- **.NET 6**: The application is built using the latest version of the .NET framework, providing modern features and performance improvements.

- **Microsoft SQL Server**: The database is managed using Microsoft SQL Server, ensuring secure and reliable data storage.

- **Windows Forms**: The frontend interface is developed using Windows Forms, providing a user-friendly and intuitive experience for managing person data.

- **JWT (JSON Web Tokens)**: User authentication and authorization are implemented using JWT, providing a secure and efficient method for user login.

## Backend (Web API)

The Web API backend provides the core functionality for registering and managing person data. It follows the repository pattern, separating data access logic from business logic.

Key features of the backend include:

- User registration and authentication using JWT
- CRUD operations for managing person data
- Repository pattern for organized and maintainable data access
- Token-based authentication and authorization using JWT (JSON Web Tokens)

## Frontend (Windows Forms)

The Windows Forms frontend provides an easy-to-use interface for interacting with the backend API. Users can:

- Register new persons
- View a list of registered persons
- Update existing person data
- Delete person records

## How to Build and Run the Application

Follow these steps to build and run the Register A Person In A Database application:

1. **Clone the Repository**: Clone this GitHub repository to your local machine using your preferred Git client or by running the following command in your terminal:
git clone https://github.com/yourusername/register-a-person-app.git

2. **Setup Database**: Make sure you have Microsoft SQL Server installed and create a new database named `PersonDatabase`. Update the database connection string in the `appsettings.json` file of the Web API project.

3. **Build the Backend**: Open the solution in Visual Studio or your preferred .NET IDE. Build the Web API project (`RegisterAPersonBackend`) to restore NuGet packages and generate the necessary binaries.

4. **Run the Backend**: Start the Web API project. It will launch the backend server, which will be accessible at `https://localhost:7295` by default.

5. **Build and Run the Frontend**: Open the `RegisterAPersonApp` folder in Visual Studio or your preferred .NET IDE. Build and run the Windows Forms application to start interacting with the backend API.

6. **Register and Manage Persons**: Use the Windows Forms interface to register new persons, view the list of registered persons, update existing person data, and delete person records.
