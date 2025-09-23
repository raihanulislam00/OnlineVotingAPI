# Polling-System
This project is a Simple Polling System built using SOLID principles and the three-tier architecture in ASP.NET Web API. 

## Features

- User authentication and management
- Create and manage polls
- Add options to polls
- Vote on poll options
- View poll results

## Prerequisites

- Visual Studio 2019 or later
- .NET Framework 4.7.2 or later
- SQL Server (LocalDB or higher)
- Entity Framework 6.5.1

## Getting Started

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/Polling-System.git
   ```

2. Open the solution file `Final.sln` in Visual Studio.

3. Restore NuGet packages:
   - Right-click on the solution in Solution Explorer
   - Select "Restore NuGet Packages"

4. Update the database connection string:
   - Open `Web.config` in the `Final` project
   - Update the connection string if needed

5. Initialize the database:
   - Open Package Manager Console in Visual Studio
   - Set the Default Project to "DAL"
   - Run the following commands:
     ```
     Enable-Migrations
     Update-Database
     ```

### Running the Application

1. Set `Final` as the startup project:
   - Right-click on the `Final` project in Solution Explorer
   - Select "Set as Startup Project"

2. Press F5 or click the "Start" button to run the application

## Project Structure

- **BLL (Business Logic Layer)**
  - Contains DTOs and Services
  - Handles business logic and data transformation

- **DAL (Data Access Layer)**
  - Manages database operations
  - Contains Entity Framework context and repositories
  - Handles data models and migrations

- **Final (Web API Layer)**
  - API Controllers
  - Route configurations
  - Web-specific settings

## API Endpoints

### User Management
- POST /api/User/register - Register a new user
- POST /api/User/login - User login

### Polls
- GET /api/Poll - Get all polls
- GET /api/Poll/{id} - Get specific poll
- POST /api/Poll - Create new poll
- PUT /api/Poll/{id} - Update poll
- DELETE /api/Poll/{id} - Delete poll

### Options
- GET /api/Option/{pollId} - Get options for a poll
- POST /api/Option - Add new option
- PUT /api/Option/{id} - Update option
- DELETE /api/Option/{id} - Delete option

### Votes
- POST /api/Vote - Cast a vote
- GET /api/Vote/{pollId} - Get vote results for a poll

## Technologies Used

- ASP.NET Web API
- Entity Framework 6
- AutoMapper
- SQL Server
- Newtonsoft.Json

## Testing with Postman

1. Download and install [Postman](https://www.postman.com/downloads/)

2. Import the API collection:
   - Open Postman
   - Click "Import" button
   - Create a new collection named "Polling System API"

3. Set up your environment:
   - Create a new environment in Postman
   - Add a variable `baseUrl` with value `http://localhost:PORT` (replace PORT with your application's port number)
   - Add a variable `token` (this will store the authentication token)

4. Test the API endpoints:

### Authentication
```
POST {{baseUrl}}/api/User/register
Content-Type: application/json

{
    "Name": "Your Name",
    "Email": "your.email@example.com",
    "Password": "your_password"
}
```

```
POST {{baseUrl}}/api/User/login
Content-Type: application/json

{
    "Email": "your.email@example.com",
    "Password": "your_password"
}
```
- After successful login, copy the token from the response and set it to the `token` environment variable

### Creating a Poll
```
POST {{baseUrl}}/api/Poll
Content-Type: application/json
Authorization: Bearer {{token}}

{
    "Title": "Your Poll Title",
    "Description": "Poll Description",
    "EndDate": "2025-12-31T23:59:59"
}
```

### Adding Options
```
POST {{baseUrl}}/api/Option
Content-Type: application/json
Authorization: Bearer {{token}}

{
    "PollId": 1,
    "Text": "Option Text"
}
```

### Casting a Vote
```
POST {{baseUrl}}/api/Vote
Content-Type: application/json
Authorization: Bearer {{token}}

{
    "OptionId": 1
}
```

### View Results
```
GET {{baseUrl}}/api/Vote/1
Authorization: Bearer {{token}}
```

5. Tips for testing:
   - Always include the Authorization header with Bearer token for protected endpoints
   - Check the response status codes (200 for success, 400 for bad requests, 401 for unauthorized)
   - Use the environment variables to easily switch between different environments (local, staging, production)

## Contributing

1. Fork the repository
2. Create your feature branch
3. Commit your changes
4. Push to the branch
5. Create a new Pull Request
