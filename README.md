# 🧠 CompleteExamplePro

**CompleteExamplePro** is a **fully featured, production-ready ASP.NET Core MVC solution** built with **Entity Framework Core** and **PostgreSQL**, packaged for instant deployment via **Docker**.  
It demonstrates professional full-stack architecture, modular data design, and end-to-end automation — ideal for learning, prototyping, or extending into real-world enterprise systems.

---

## 🚀 Key Features

- **🔹 Full MVC Architecture**  
  Structured separation of Controllers, Models, and Razor Views for clean, maintainable development.

- **🔹 Entity Framework Core 8 (Code-First)**  
  Implements code-first migrations, seeding, and advanced relational mapping across entities (Users, Events, Locations, Organizers, Cities, Tags).

- **🔹 PostgreSQL Integration**  
  Pre-configured for automatic database creation and initialization with `DbContext` and migrations.

- **🔹 Dockerized Environment**  
  Ships with ready-to-run `Dockerfile` and `docker-compose.yml` — launches both the web application and PostgreSQL database in isolated containers.

- **🔹 Automated Windows Scripts**  
  Includes `.bat` utilities for simplified control:  
  - `run_app.bat` – start containers  
  - `stop_app.bat` – stop and clean up  
  - `rebuild_app.bat` – rebuild and redeploy

- **🔹 Built-in Logging & Middleware**  
  Developer diagnostics, data-protection keys, HTTPS redirection, and structured request logging enabled by default.

- **🔹 Cross-Platform Ready**  
  Runs identically on **Windows**, **Linux**, and **macOS** with Docker Desktop.

---

## 🧩 Technologies Used

| Layer        | Technology                              |
|:------------|:-----------------------------------------|
| Framework   | .NET 8 / ASP.NET Core MVC (Razor Views) |
| ORM         | Entity Framework Core 8                 |
| Database    | PostgreSQL 16                           |
| Containers  | Docker & Docker Compose                 |
| Languages   | C#, HTML, Razor, CSS                    |

---

## ⚙️ Getting Started

1. **Install** [Docker Desktop](https://www.docker.com/products/docker-desktop)  
2. **Clone** the repository:
   ```bash
   git clone https://github.com/yourusername/CompleteExamplePro.git
   cd CompleteExamplePro
Run the project:

docker_control.bat


Open your browser at http://localhost:8080

To rebuild everything from scratch:

rebuild_app.bat


🧱 Project Purpose

CompleteExamplePro serves as a reference-grade MVC template for developers and students.
It provides a complete, modular foundation — database schema, relationships, controllers, and views — ready for customization and scalable extensions such as APIs, authentication, or cloud deployment.

Built for clarity, maintainability, and real-world relevance, this project represents a modern example of professional .NET development workflow.

🏷️ License

This project is released under the MIT License.
You are free to use, modify, and distribute it for both educational and commercial purposes.

## License

[![License](https://img.shields.io/badge/License-Apache%202.0-blue.svg)](https://opensource.org/licenses/Apache-2.0)

Licensed under the Apache License 2.0 - see [LICENSE](./LICENSE) and [NOTICE](./NOTICE).  
Created by [Ioannis (wannabexaker)](https://github.com/wannabexaker) - Attribution required.