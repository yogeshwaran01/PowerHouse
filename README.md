# PowerHouse

## Description
This is an ASP.NET Core API project. Just for learning purpose. Nothing special

## Setup

### Prerequisites
- .NET SDK (version 9.0 or later)
- PostgreSQL (for the database, if using the default connection string)

### Database Migrations
To apply database migrations, run the following commands:
```bash
dotnet ef database update
```

### User Secrets
To manage sensitive information like API keys, use the .NET Secret Manager:
```bash
dotnet user-secrets init
dotnet user-secrets set "Gemini:ApiKey" "YOUR_GEMINI_API_KEY"
dotnet user-secrets set "OpenAI:ApiKey" "YOUR_OPENAI_API_KEY"
# ... other secrets
```

## Running the Application

To run the application, navigate to the project root and execute:
```bash
dotnet run
```
The API will typically be available at `https://localhost:7000` or `http://localhost:5000`.

## API Endpoints
(Details about API endpoints can be added here, generated from Swagger/OpenAPI documentation.)
