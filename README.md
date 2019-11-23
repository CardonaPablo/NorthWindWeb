# NorthWindWeb
## Versiones de NETCore
Debemos crear el proyecto NorthWind en NETCore 2.1 para que la sintaxis del PDF sea valida
Sin embargo al momento de crear los proyectos de NorthWindEntitiesLib y NorthWindContextLib se crean en mi caso automaticamente en NETCore 3.0
Asi que debemos entrar al explorador de soluciones, click derecho en el nombre del proyecto, propiedades, y cambiamos la plataforma de destino a NETCore 2.1

## ¿Qué cambió?
Primero que nada para que puedan probarlo deben cambiar el connection string que se ubica en Startup.cs
<pre>
            //Aqui deben reemplazarlo por el propio
            var connectionString = @"Integrated Security = SSPI; Persist Security Info = False; Initial Catalog = NorthWind; Data Source = PABLO";
            services
                .AddEntityFrameworkSqlServer()
                .AddDbContext<NorthwindContextLib.Northwind>((serviceProvider, options) =>
                 options.UseSqlServer(connectionString)
                           .UseInternalServiceProvider(serviceProvider));
</pre>

Después para resolver los errores generados por duplicación se utiliza este markup en los archivos de proyecto de los tres proyectos utilizados
            
```
    <PropertyGroup>
      <TargetFramework>netcoreapp2.1</TargetFramework>
      <EnableDefaultRazorTargetAssemblyInfoAttributes>false</EnableDefaultRazorTargetAssemblyInfoAttributes>
    </PropertyGroup>
```

## Paquetes NuGet a instalar
Ya  que estamos trabajando con una versión antigua de NETCore, debemos asegurarnos de que sea compatible con los paquetes que vamos a instalar.  

Aqui una lista de los paquetes por proyecto:

### NorthWindContextLib
* Microsoft.EntityFrameworkCore en su Versión 2.1.14
* Microsoft.EntityFrameworkCore.Relational en su Versión 2.1.14
* Microsoft.NetCore.App (Por defecto)
### NorthWindEntitiesLib
* Microsoft.NetCore.App (Por defecto)
### NorthwindWeb
* Microsoft.AspNetCore.Razor.Design (Por defecto de las RazorPages)
* Microsoft.EntityFrameworkCore en su Versión 2.1.14
* Microsoft.EntityFrameworkCore.Relational en su Versión 2.1.14
* Microsoft.NetCore.App (Por defecto)

# Documentaciones Útiles

https://docs.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/sql?view=aspnetcore-2.1&tabs=visual-studio
https://docs.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/page?view=aspnetcore-2.1&tabs=visual-studio
Asegurense de que en la seleccion de versión este en NETCore 2.1 

# Como descargar este repositorio para probarlo?
Deben instalar Git en su computadora, es bastante ligero pueden hacerlo desde [este link](https://git-scm.com/downloads).  
Después sigue los pasos de [este link](https://help.github.com/es/github/creating-cloning-and-archiving-repositories/cloning-a-repository) para copiar el repositorio con la terminal de Git .  
También se puede [clonar directamente a Visual Studio utilizando el Team Explorer](https://docs.microsoft.com/en-us/visualstudio/ide/connect-team-project?view=vs-2019).  
