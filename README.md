# NLayer App
----
That project created with the education of N-Tier Layer Arch and with best practices.
------
### Features 
- The Autofac integration with Web API and MVC provided the use of ability to resolve model binders using dependency injection and associate binders with types using a fluent interface.
- With the support of AutoMapper libray, maped business objects to data transfer objects without duplicate codes which is aimed to clean code and modularity.
- CRUD operations are accesible on the side of API or MVC and they communicate each other all time.
- FluentValidations are used for checking datas of Entity DTOs on side of API/MVC.
- Generic Repository Design Pattern, Unit Of Work Design pattern, MVC Design Patterns are used.
- Core / Repository / Service / Caching / API / MVC layers included.
- ASP.NET MVC(Model-View-Controller) which is web-application frameworked used as an architectural pattern.
----
### Project built with
- ASP.NET Backend(C#,.NET 7)
- MSSQL Database
- HTML-CSS
----
> Manual Guide

- Edit to connection string from Program.cs
```
builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});
```
### Database 
- I have defined an entity models in code, create a database from the model, and then add data to the database by Code-First approach and with the supportiong of EF Core.

  ---

Created Database diagram can be found below.

![](https://i.imgur.com/6MsI5wy.png)

---

### FrontEnd
- Fronted built with the HTML/CSS and help of Bootstrap.
