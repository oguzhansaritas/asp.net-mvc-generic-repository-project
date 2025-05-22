
# ASP.NET MVC Generic Repository Project

This project demonstrates a clean, layered architecture in an ASP.NET MVC 5 application using the **Generic Repository Pattern**, Entity Framework, and dependency injection. The goal is to promote reusability, testability, and separation of concerns in web application development.

## 🧰 Technologies Used

- ASP.NET MVC 5
- Entity Framework 6
- Generic Repository Pattern
- C#
- SQL Server
- Razor View Engine

## 📁 Project Structure

```
├── asp.netMVCwebApp.Constant      # Constants and configuration
├── asp.netMVCwebApp.Data          # Database context and migrations
├── asp.netMVCwebApp.Entities      # POCO entity classes
├── asp.netMVCwebApp.Repository    # Generic repository and interfaces
├── asp.netMVCwebApp.Service       # Business logic layer
├── asp.netMVCwebApp.Web           # MVC controllers and views
```

## 🏗️ Generic Repository Pattern

This project implements a generic repository pattern to abstract data access logic:

```csharp
public interface IGenericRepository<T> where T : class {
    IEnumerable<T> GetAll();
    T GetById(int id);
    void Insert(T entity);
    void Update(T entity);
    void Delete(T entity);
    void Save();
}
```

Benefits:
- Minimizes redundant code
- Improves maintainability
- Simplifies unit testing

## 🚀 Getting Started

### Prerequisites

- Visual Studio 2019 or later
- SQL Server (LocalDB or full)
- .NET Framework 4.7.2+

### Setup Instructions

1. Clone the repository:
   ```bash
   git clone https://github.com/oguzhansaritas/asp.net-mvc-generic-repository-project.git
   ```

2. Open the `.sln` file in Visual Studio.

3. Restore NuGet packages.

4. Update the `Web.config` file with your SQL connection string.

5. Run the project with `Ctrl + F5`.

## 💡 Usage

- Navigate to the controller routes (e.g., `/Product`, `/Category`)
- Perform basic CRUD operations through the UI
- Services handle business logic and communicate with repositories


## 🙌 Contribution

Feel free to fork this repo and submit pull requests. For major changes, please open an issue first to discuss what you would like to change.

## 📄 License

This project is licensed under the MIT License. See the `LICENSE` file for more details.

## 📬 Contact

Created by **OGUZHAN SARITAS** – reach me at info@oguzhansaritas.com for any questions.
