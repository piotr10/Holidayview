# Holidayview – Employee Leave Management

**Holidayview** is a web application for HR teams to manage employees' annual leave. It replaces the usual leave spreadsheet with an application backed by **Microsoft SQL Server**. Each employee's entitlement, leave taken and remaining days are stored together with their reporting line.

I built it from my own experience in HR & payroll, where keeping leave balances up to date for many employees and companies by hand was slow and error-prone.

---

## ✨ Features

- **Employee register:** name, e-mail, internal ID, employee type, company and active/inactive status (soft delete)
- **Reporting line:** every employee is linked to a team leader, manager and director
- **Leave entitlement:**
  - the yearly entitlement (e.g. 20 or 26 days) is assigned when the employee is created;
  - a disability flag is stored, since in Poland it can affect the entitlement
- **Leave balance:** per-employee entitlement, days taken and days remaining, created automatically with the employee record
- **Search and paging** on the employee list
- **User & role management:** ASP.NET Core Identity accounts, assigning roles to users and removing users
- **File logging** with Serilog

## 🗄️ Database

- **Microsoft SQL Server** with **Entity Framework Core** (code-first)
- Core tables:

  | Table | Purpose |
  |---|---|
  | `Customers` | employees |
  | `LeaveBalances` | entitlement, days taken, days remaining |
  | `Vacations` | entitlement levels |
  | `Companies` | companies |
  | `CustomerTypes` | employee types |
  | `Leaders`, `Managers`, `Directors` | reporting line |
  | `Disables` | disability flag |
  | `CustomerWithSupervisors` | employee ↔ supervisor assignment |

- One-to-many relationships from dictionary tables to employees, and one-to-many from employee to leave balances
- The schema evolved through EF Core migrations (Oct – Dec 2021)

## 🏗️ Architecture

The solution uses a layered (onion-style) architecture:

```
Holidayview.Domain          → entities and repository interfaces
Holidayview.Application     → services, view models, AutoMapper profiles
Holidayview.Infrastructure  → EF Core DbContext, repositories, migrations
Holidayview.Web             → ASP.NET Core MVC (controllers, Razor views, Identity)
Holidayview.Test            → xUnit test project
```

## 🧰 Tech stack

| Area | Technology |
|---|---|
| Framework | .NET Core 3.1, ASP.NET Core MVC, Razor |
| Data | SQL Server, Entity Framework Core, Migrations |
| Auth | ASP.NET Core Identity (users & roles) |
| Libraries | AutoMapper, Serilog |
| Tests | xUnit |

---

## 🚀 Running locally

**Prerequisites:** .NET Core 3.1 SDK, SQL Server Express (or any SQL Server instance), `dotnet-ef` tool.

1. Set your connection string in `Holidayview.Web/appsettings.json` → `ConnectionStrings:DefaultConnection`.
2. Create the database:
   ```bash
   dotnet ef database update --project Holidayview.Infrastructure --startup-project Holidayview.Web
   ```
3. Run:
   ```bash
   dotnet run --project Holidayview.Web
   ```
4. Fill in the dictionary tables (`Companies`, `Vacations`, `Leaders`, `Managers`, `Directors`, `CustomerTypes`, `Disables`), then add employees from the UI.

## 🗺️ Roadmap

- Leave requests with an approval flow (employee → leader → manager)
- Employees see only their own requests (match the logged-in user by e-mail)
- Automatic yearly carry-over of unused leave
- Leave reports per company and department as SQL views
- Unit tests for leave balance calculations
