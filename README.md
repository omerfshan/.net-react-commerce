# URL Shortener

## Project Overview
A modern URL shortening application built with .NET Core Web API and React. This application allows users to convert long URLs into shorter, more manageable links while providing analytics on click-through rates.

## Key Features
- **URL Shortening**: Convert long URLs into short, easy-to-share links
- **Click Analytics**: Track the number of clicks for each shortened URL
- **Modern UI**: Clean and responsive user interface built with React and Material-UI
- **RESTful API**: Robust backend API built with .NET Core
- **Database Integration**: Persistent storage using SQLite database
- **Real-time Updates**: Instant feedback on URL creation and redirection

## Technical Stack
### Backend (.NET Core)
- **Framework**: .NET Core Web API
- **Database**: SQLite with Entity Framework Core
- **API Documentation**: Swagger/OpenAPI
- **Key Packages**:
  - Microsoft.EntityFrameworkCore.Sqlite
  - Microsoft.EntityFrameworkCore.Design
  - Swashbuckle.AspNetCore

### Frontend (React)
- **Framework**: React.js
- **UI Library**: Material-UI (MUI)
- **State Management**: React Hooks
- **HTTP Client**: Axios

## Project Structure
```
url-shortener/
├── UrlShortener.API/           # .NET Core Backend
│   ├── Controllers/           # API endpoints
│   ├── Models/               # Data models
│   ├── Services/            # Business logic
│   └── Data/               # Database context
├── src/                    # React Frontend
│   ├── components/        # React components
│   └── services/         # API integration
└── README.md
```

## Getting Started

### Prerequisites
- .NET Core SDK 6.0 or higher
- Node.js and npm
- SQLite

### Backend Setup
1. Navigate to the API project directory:
   ```bash
   cd UrlShortener.API
   ```
2. Install dependencies:
   ```bash
   dotnet restore
   ```
3. Run database migrations:
   ```bash
   dotnet ef database update
   ```
4. Start the API:
   ```bash
   dotnet run
   ```

### Frontend Setup
1. Navigate to the frontend directory:
   ```bash
   cd src
   ```
2. Install dependencies:
   ```bash
   npm install
   ```
3. Start the development server:
   ```bash
   npm start
   ```

## API Endpoints
- `POST /api/url` - Create a new shortened URL
- `GET /{shortCode}` - Redirect to original URL
- `GET /api/url/{shortCode}` - Get URL details

## Features in Detail
1. **URL Shortening**
   - Generates unique 6-character codes
   - Validates input URLs
   - Prevents duplicate entries

2. **Analytics**
   - Tracks click count
   - Records creation timestamp
   - Stores original URL

3. **User Interface**
   - Clean, modern design
   - Responsive layout
   - Real-time feedback
   - Copy-to-clipboard functionality

## Contributing
Contributions are welcome! Please feel free to submit a Pull Request.

## License
This project is licensed under the MIT License - see the LICENSE file for details.
