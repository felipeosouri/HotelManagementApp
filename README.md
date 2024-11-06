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
