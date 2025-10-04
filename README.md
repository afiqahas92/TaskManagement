📝 **Task Management App**

A simple Blazor Server application for managing tasks.
Users can view, add, complete, and delete tasks — built using .NET 8, Entity Framework Core, and SQLite, following Clean Architecture principles.


🚀 **Features**

✅ View all tasks with filtering: All, Completed, Pending

➕ Add new tasks (title and description)

✔️ Mark tasks as completed

🗑️ Delete tasks

💾 Persist data using SQLite

📱 Responsive, minimal UI



🏗️ **Project Structure**

The solution follows Clean Architecture, organized into separate layers:
<img width="1162" height="262" alt="image" src="https://github.com/user-attachments/assets/9362bb73-0fe4-4187-8751-29a728b267d1" />


**Key Concepts**

- Dependency Injection (services and repositories)
- Async/await for all data operations
- Optional CQRS pattern for scalability
- EF Core Migrations for database evolution

🧰 **Tech Stack**

| **Layer**          | **Technology**                 |
| ------------------ | ------------------------------ |
| **UI**             | Blazor Server (.NET 8)         |
| **Application**    | C# with CQRS (optional)        |
| **Infrastructure** | Entity Framework Core + SQLite |
| **Domain**         | POCO entities and domain logic |



⚙️ **Getting Started**

1️⃣ _Clone the repository_
git clone https://github.com/afiqahas92/TaskManagement.git

cd TaskManagement

2️⃣ _Apply database migrations_
cd TaskManagement.Infrastructure

dotnet ef database update

3️⃣ _Run the Blazor Server app_
cd ../TaskManagement

dotnet run

Then open your browser at https://localhost:5001
 
 (or the shown URL).


🗄️ **Database Schema**

| **Field**   | **Type** | **Description**           |
| ----------- | -------- | ------------------------- |
| Id          | int      | Primary key               |
| Title       | string   | Task title                |
| Description | string   | Task details              |
| IsCompleted | bool     | Completion status         |
| CreatedAt   | DateTime | Date the task was created |

👨‍💻 Author

Afiqah AS

Software Engineer • Building scalable apps with .NET and Blazor
