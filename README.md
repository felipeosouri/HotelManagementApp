# Hotel Management API

Hotel Management API es un sistema de gestión de hoteles construido con **.NET 8** y **C#**. Este proyecto permite gestionar hoteles, habitaciones y reservas, proporcionando un conjunto de endpoints para crear, actualizar y consultar información sobre estos elementos. La arquitectura del proyecto sigue principios de **Domain-Driven Design (DDD)** y **Clean Architecture**.

## Características

- **Gestión de Hoteles**: Crear, actualizar, habilitar o deshabilitar hoteles.
- **Gestión de Habitaciones**: Crear, actualizar, asignar precios, impuestos y ubicación de habitaciones. Habilitar o deshabilitar habitaciones.
- **Gestión de Reservas**: Crear reservas de habitaciones, gestionar pasajeros y contactos de emergencia.

## Tecnologías Utilizadas

- **.NET 8** y **ASP.NET Core** para la API REST.
- **Entity Framework Core** para el acceso a la base de datos y migraciones (con **SQL Server**).
- **Domain-Driven Design (DDD)** y **Clean Architecture**.
- **Inyección de Dependencias** para gestionar servicios y repositorios.

## Configuración y Uso

### 1. Requisitos Previos

- **Visual Studio 2022** o **VS Code** con SDK de .NET 8.
- **SQL Server** para la base de datos.
- **Postman** o cualquier herramienta de cliente HTTP para probar los endpoints.

### 2. Clonar el Repositorio

Clona el repositorio desde GitHub:

```bash
git clone https://github.com/felipeosouri/HotelManagementApp.git
cd HotelManagementAPI
```


### 3. Configurar la Cadena de Conexión

Clona el repositorio desde GitHub:

```bash
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=HotelManagementDB;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  ...
}
```

Reemplaza YOUR_SERVER_NAME con el nombre de tu servidor SQL. Si usas autenticación de SQL Server en lugar de autenticación integrada, agrega User Id=YOUR_USER;Password=YOUR_PASSWORD;.

### 4. Aplicar Migraciones para Crear la Base de Datos

Ejecuta los siguientes comandos en la Consola del Administrador de Paquetes de Visual Studio o en la terminal para aplicar las migraciones y crear el esquema de la base de datos:

```bash
dotnet ef migrations add InitialCreate --project HotelManagement.Infrastructure --startup-project HotelManagement.API
dotnet ef database update --project HotelManagement.Infrastructure --startup-project HotelManagement.API
```
### 5. Ejecutar el Proyecto

Inicia la API, Puedes probar los endpoints de la API utilizando Postman o cualquier herramienta de cliente HTTP:

```bash
dotnet run --project HotelManagement.API
```

