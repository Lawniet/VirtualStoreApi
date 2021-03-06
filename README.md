# Virtual Store
[![Codacy Badge](https://app.codacy.com/project/badge/Grade/42c5b8448d3b4299a233c31d19be73e5)](https://www.codacy.com/gh/Lawniet/VirtualStoreApi/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=Lawniet/VirtualStoreApi&amp;utm_campaign=Badge_Grade)
[![GitHub license](https://img.shields.io/github/license/Lawniet/virtualstoreapi)](https://github.com/Lawniet/virtualstoreapi/blob/master/LICENSE)

## Description
Virtual Store Management for users (after authentication,) can register, change, delete or search for Stores, Products and stocks.

## :rocket: API project

### API architecture
<img src="images/apiSchema.png" alt="API architecture" width="700"/>

### SQL scheme
<img src="images/sqlSchema.png" alt="SQL Schema" width="700"/>

### Class diagram
<img src="images/classSchema.png" alt="Class diagram" width="700"/>

[See more in Figma](https://www.figma.com/file/K7eJzfgKeFc0UM85l2DO9C/System's-Design%3A-Virtual-store?node-id=2%3A2)

## :rocket: Technologies and Principles

- ✔️  .NET >= 5.0;
- ✔️  In-Memory DB;
- ✔️  MVC;
- ✔️  SOLID;
- ✔️  Clean Code;
- ✔️  Inheritance and Polymorphism;
- ✔️  Entity Framework;
- ✔️ TDD;
- ✔️  DTOs.

## :information_source: How to start

### Pre Requisites

Before starting the project, you will need the following tools: 

- [ ] [Install VsCode](https://code.visualstudio.com/download);
- [ ] [Install Git](https://git-scm.com/)
- [ ] [Install .NET 5.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/5.0)
- [ ] [Install Nuget](https://www.nuget.org/downloads)
- [ ] [Clone project in VSCode](https://github.com/Lawniet/VirtualStoreApi.git)

### Execution

How to run the project locally:

```
1. Open code's folder in VSCode;
2. Run the project in debug mode with IIS Express;
3. The application's Swagger will open;
4. API is protected by JWT token. The only endpoint released is the JWT. Run it and copy the generated token;
5. Click the authentication button (a padlock at the top of the swagger page);
6. In the required field, write Bearer + generated token. This will allow access to the endpoints.
```
<br>

## Projects

- VirtualStoreApi - API Project, where contains the controllers, mappers, JWT config and enum.
- Application - The application layer, where it contains the interfaces of services, validators and utils profiles.
- Domain - Domain layer, where it contains the models, interfaces and DTO's.
- Infrastructure - Data layer, where it contains the Context (the class where we configure the SQLlite), mappings, repositories.
- Tests - TDD layer, where it contains tests and mocks for API, repositories and Application layer.


## :seedling: About developer

Lauany Reis da Silva:
- LinkedIn: [https://www.linkedin.com/in/lauany-reis-da-silva/](https://www.linkedin.com/in/lauany-reis-da-silva/)
- Github: [https://github.com/Lawniet](https://github.com/Lawniet)

## More info

[Tutorial: criar uma API Web com o ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-6.0&tabs=visual-studio-code)

[C# de teste de unidade no .NET Core usando dotnet test e xUnit](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-dotnet-test)

[Tutorial: criar uma API Web com o ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-6.0&tabs=visual-studio-code)
