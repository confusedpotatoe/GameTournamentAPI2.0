# 🏆 Game Tournament API

A Web API built with ASP.NET Core for managing tournaments and games.  
The API supports full CRUD operations, uses Entity Framework Core, DTOs, AutoMapper, and follows a clean service-based architecture.

---

## 🚀 Features

- 🏆 Manage Tournaments (CRUD)
- 🎮 Manage Games (CRUD)
- 🔗 One-to-many relationship (Tournament → Games)
- 🔍 Search tournaments by title
- 📅 Sorting by date and time
- 🧠 DTO-based architecture (no direct entity exposure)
- ⚡ Async/await throughout the API
- 🗄️ SQL Server database with Entity Framework Core
- 🧼 Clean separation of Controllers, Services, and Data layer
- 📘 Swagger API documentation

---

## 🧱 Tech Stack

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- AutoMapper
- Swagger / OpenAPI

---

## 📁 Project Structure


| Method | Endpoint | Description |
|------|----------|-------------|
| GET | `/api/tournaments` | Get all tournaments |
| GET | `/api/tournaments?search=` | Search tournaments by title |
| GET | `/api/tournaments/{id}` | Get tournament by id |
| GET | `/api/tournaments/{id}/with-games` | Get tournament with games |
| POST | `/api/tournaments` | Create tournament |
| PUT | `/api/tournaments/{id}` | Update tournament |
| DELETE | `/api/tournaments/{id}` | Delete tournament |

---

### 🎮 Games

| Method | Endpoint | Description |
|------|----------|-------------|
| GET | `/api/games` | Get all games |
| GET | `/api/tournaments/{id}/games` | Get games by tournament |
| POST | `/api/games` | Create game |
| PUT | `/api/games/{id}` | Update game |
| DELETE | `/api/games/{id}` | Delete game |

---

## 🧠 Business Rules

- Tournament title must be at least 3 characters
- Tournament date cannot be in the past
- Game time cannot be in the past
- Games must belong to an existing tournament
- All validation is handled in the service layer

---
