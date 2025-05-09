## Old Mutual Flag Explorer App Assessment
## Technologies Used
### Backend
- .NET 8 Web API
- Clean Controller-based architecture
- HttpClient integration with 3rd-party REST API
- Swagger (OpenAPI) documentation
- xUnit & Moq for unit testing
### Frontend
- React 18 & TypeScript
- Axios for HTTP requests
- React Router for client side routing
- CSS grid layout for responsive flag display
- Jest & React testing library
### CI/CD
- GitHub Actions
- Build & Test steps for both backend and frontend
- YAML based pipeline configuration
  
## Folder/Project Structure
Flag-Explorer-App
  - .github\workflows
  - backend\CountryApi
  - frontend\country-flags-app
  - README.md
  - .gitignore

## Getting Started
### Prerequisites/dependencies
Install the following:
- .Net SDK 8+
- Node.js v20+ and npm
### Backend Setup (.NET Core)
- cd backend/CountryApi
- dotnet run
- visit http://localhost:5093/countries
### Frontend Setup (React)
- cd frontend/country-flags-app
- npm install
- npm start
- visit http://localhost:3000/
### Running Test Backend
- cd backend
- dotnet test
### Running Test Frontend:
- cd frontend/country-flags-app
- npm test
### CI/CD Pipeline
- .github/workflows/ci-cd.yml


