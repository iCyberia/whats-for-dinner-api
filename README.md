# 🍽️ What's For Dinner API

This is the backend API for the *What's for Dinner* meal planning application. It allows users to manage dishes, ingredients, and an upcoming dinner menu. Built with **ASP.NET Core 8.0** and **Entity Framework Core**, it connects to a **SQL Server** database and serves as the primary data source for the React frontend.

---

## 🚀 Features

- ✅ CRUD operations for Dishes and Ingredients
- ✅ Manage upcoming dinner menu
- ✅ Generate a grocery list based on upcoming meals
- ✅ Swagger UI for interactive API testing
- ✅ Docker support for containerized deployment

---

## 📦 Technologies Used

- ASP.NET Core 8.0 Web API
- Entity Framework Core
- SQL Server
- Docker
- Swagger (Swashbuckle)
- LINQ

---

## 📁 Project Structure

```
WhatsForDinnerApi/
├── Controllers/
│   ├── DishesController.cs
│   └── UpcomingMenuController.cs
├── Models/
│   ├── Dinner.cs
│   ├── DinnerIngredient.cs
│   ├── Ingredient.cs
│   └── UpcomingMenu.cs
├── Data/
│   └── MenuContext.cs
├── Program.cs
├── appsettings.json
├── Dockerfile
└── WhatsForDinnerApi.csproj
```

---

## 🔧 API Endpoints

### 🥘 Dishes

- `GET /api/dishes` - Get all dishes
- `POST /api/dishes` - Add a new dish
- `DELETE /api/dishes/{id}` - Delete a dish

### 🍽️ Upcoming Menu

- `GET /api/upcomingmenu` - Get meals in the upcoming menu
- `POST /api/upcomingmenu/{dishId}` - Add dish to upcoming menu
- `DELETE /api/upcomingmenu/{id}` - Remove a dish from upcoming menu

### 🛒 Grocery List

- `GET /api/upcomingmenu/grocerylist` - Summarized ingredient list across all upcoming meals

---

## ⚙️ Running Locally

1. **Clone the repo**

```bash
git clone https://github.com/iCyberia/whats-for-dinner-api.git
cd whats-for-dinner-api
```

2. **Configure the database**

Update your connection string in `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=WhatsForDinner;User Id=sa;Password=YourStrong!Pass;"
}
```

3. **Run the API**

```bash
dotnet run
```

Navigate to `http://localhost:5296/swagger` to use the Swagger UI.

---

## 🐳 Docker

To build and run the API in Docker:

```bash
docker build -t whatsfordinnerapi .
docker run -d -p 5002:8080 --name whatsfordinnerapi-container whatsfordinnerapi
```

Access via: [http://localhost:5002/swagger](http://localhost:5002/swagger)

---

## 🔐 Environment Variables

| Name                    | Description                      |
|-------------------------|----------------------------------|
| `ConnectionStrings:DefaultConnection` | SQL Server connection string |

---

## ✍️ License

This project is open source and available under the [MIT License](LICENSE).

---

## 🙌 Author

**Hiroshi Thomas**  
GitHub: [@iCyberia](https://github.com/iCyberia)

---

Happy coding! 🎉
