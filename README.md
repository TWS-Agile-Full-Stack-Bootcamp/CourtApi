
# hint
* MySql Connection string: `server=localhost;user=root;database=db;password=*****;`
* Use below code to method of `Configure` in file `Startup.cs` to create database automaticlly
```

using (var scope = app.ApplicationServices.CreateScope())
{
    using (var context = scope.ServiceProvider.GetService<CompanyDBContext>())
    {
        context.Database.EnsureCreated();
    }
}
```
* create database context
* inject database context then call its save & findAll in resource

