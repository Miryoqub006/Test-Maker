# ExamPdp3 - TestProject API

This project is the **Backend (API)** for a test/examination system designed to present random questions to users and verify their answers. The project is written in C# using **ASP.NET Core Web API** and follows an N-Tier architecture.

## 🎯 Features

The following operations can be performed via the API:
- **Get Random Question:** Retrieve a single random question and its options from the system.
- **Answer a Question:** Users submit their answers, and the system determines if they are correct or incorrect.
- **Add New Question (Admin):** Insert new questions and options into the system.
- **View All Questions (Admin):** Retrieve the complete list of all available questions in the system.

## 🏗 Architecture and Technologies

To ensure the code is readable and scalable, the project is divided into layers based on the **Repository Pattern**:
- **ASP.NET Core Web API:** The core framework.
- **Controllers:** The layer that exposes API endpoints and receives HTTP requests. (`QuestionController` is the main project controller)
- **Services (`QuestionService`):** The core business logic resides here (e.g., retrieving random questions, verifying the correctness of answers).
- **Repositories (`QuestionsRepositories`):** The Data Access layer. Data read/write operations are isolated here.
- **Entities & DTOs:** The primary data transfer models in the system (the `Question` object, the `GetQuestionDto` returned to the user, and the `SolveQuestionDto` that accepts the answer payload).

## 🚀 Installation and Setup

Follow these steps to run this project on your local machine:

### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet) (or higher)
- IDE: Visual Studio 2022, JetBrains Rider, or VS Code.

### Getting Started
1. Clone the repository to your local machine (if using git):
   ```bash
   git clone <repository_url>
   ```
2. Open your terminal (or CMD) and navigate to the main API folder:
   ```bash
   cd ExamPdp3/TestProject.Api
   ```
3. Restore required dependencies:
   ```bash
   dotnet restore
   ```
4. Run the project:
   ```bash
   dotnet run
   ```
5. Once the API starts successfully, you can test it via the **Swagger** interface in your browser:
   The URL typically is: `http://localhost:<port>/swagger` (or `https://localhost:<port>/swagger`).

## 📡 API Endpoints 

**The following API endpoints are designated in the project:**

| HTTP Method | Endpoint | Brief Description | Access Level |
|-------------|----------|-------------------|--------------|
| `GET`  | `/question api/get question` | Returns a single random question. | User |
| `POST` | `/question api/solve question` | Receives a user's answer and returns a boolean (true/false) result. | User |
| `POST` | `/question api/set question` | Adds a new question object to the system. | Admin |
| `GET`  | `/question api/get all questions data : admin` | Returns the entire list of questions stored in the system. | Admin |

*(Note: The current API Routes in the project contain whitespace characters. This is a non-standard approach and could cause URL encoding issues. It is recommended to update them to standard REST conventions like `api/questions/...` in the future).*

## 📌 Future Improvements

This project was developed to solidify fundamental C# backend skills within ASP.NET Core (APIs, Dependency Injection, Swagger, DTOs, Repository pattern, etc.).
The following enhancements may be considered for future feature releases:
- Replacing the in-memory storage with a real relational **Database (e.g., SQL Server or PostgreSQL)** using Entity Framework Core.
- **Authentication & Authorization (JWT):** Implementing role-based access control to secure the endpoints (differentiating Admin vs. User permissions).
- **Global Exception Handling:** Implementing a custom middleware to catch and handle unhandled exceptions gracefully.
