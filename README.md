# Library Management System - Backend

This is the backend for the Library Management System, built with **C# .NET and SQLite**.

## 🚀 Features
- User authentication (JWT-based login & registration)
- CRUD operations for books
- SQLite database integration
- Protected API endpoints

## 📌 Tech Stack
- **Backend:** C# .NET Web API
- **Database:** SQLite
- **Authentication:** ASP.NET Identity, JWT
- **Tools:** Postman, Entity Framework Core

## 🛠️ Setup Instructions
### 1️⃣ Clone the repository
```sh
git clone https://github.com/MudusarithaGangamina/library-management-system-backend.git
cd LibraryManagementSystem
cd LibraryManagementSystem.API
```

### 2️⃣ Install dependencies
```sh
dotnet restore
```

### 3️⃣ Apply database migrations
```sh
dotnet ef database update --context AuthDbContext
dotnet ef database update --context LMSDbContext
```

### 4️⃣ Run the backend
```sh
dotnet run
```

### 5️⃣ Access API at:
```
https://localhost:7020/
```


## 📄 API Endpoints
| Method | Endpoint        | Description       |
|--------|----------------|-------------------|
| POST   | `/api/auth/register` | Register user  |
| POST   | `/api/auth/login`    | User login     |
| GET    | `/api/books`         | Get book list  |
| POST   | `/api/books`         | Add a book     |
| PUT    | `/api/books/{id}`    | Update a book  |
| DELETE | `/api/books/{id}`    | Delete a book  |



## 🛠️ Testing with Postman
- Use **Bearer Token Authentication** for protected routes.
- Register a user, then log in to get a **JWT Token**.
- Use this token in the **Authorization Header** when making API calls.


