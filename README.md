# API REST - Primera Division de Futbol de Costa Rica

## Sobre el Proyecto

Esta es una API RESTful construida en .NET 8 disenada para gestionar y exponer informacion sobre la liga de futbol de Costa Rica (equipos, jugadores, partidos y estadisticas). 

Mas alla de la gestion de datos deportivos, el proposito principal de este proyecto es demostrar la implementacion de patrones de diseno avanzados y estandares de ingenieria de software de nivel corporativo. Esta estructurado para ser altamente escalable, mantenible y testeable, simulando los requerimientos arquitectonicos de sistemas complejos (como plataformas transaccionales o ecosistemas empresariales).

## Arquitectura y Patrones

El proyecto se rige por los principios de Clean Architecture (Arquitectura Limpia), aislando completamente las reglas de negocio de los detalles de infraestructura (bases de datos, frameworks web, etc.).

Se divide en 4 proyectos (capas) con reglas de dependencia estrictas:

1. Domain (Capa de Dominio): El nucleo de la aplicacion. Contiene las entidades de negocio puras (Team, Player, Match) y las interfaces de los repositorios. No tiene ninguna dependencia externa, garantizando que la logica central sea agnostica a la tecnologia.

2. Application (Capa de Aplicacion):
   Implementa los casos de uso del sistema utilizando el patron CQRS (Command Query Responsibility Segregation) orquestado a traves de MediatR.
   * Commands: Operaciones que mutan el estado (ej. CreatePlayerCommand).
   * Queries: Operaciones optimizadas exclusivamente para la lectura de datos (ej. GetLeagueTableQuery).

3. Infrastructure (Capa de Infraestructura):
   Maneja la comunicacion con el mundo exterior. Aqui reside la implementacion de acceso a datos utilizando Entity Framework Core con el enfoque Code-First. 

4. WebApi (Capa de Presentacion):
   El punto de entrada HTTP. Contiene controladores ligeros que delegan toda la logica a la capa de Aplicacion. Incluye documentacion automatica y estandarizada.

## Tecnologias y Herramientas

* Plataforma: .NET 8 (C#)
* Arquitectura: Clean Architecture
* Patrones de Diseno: CQRS, Dependency Injection
* Acceso a Datos: Entity Framework Core
* Mediador de Mensajes: MediatR
* Documentacion de API: Swagger / OpenAPI

## Estructura del Repositorio

```text
📁 ApiFutbolCostaRica
├── 📁 ApiFutbolCostaRica.Domain         # Entidades de negocio sin dependencias
├── 📁 ApiFutbolCostaRica.Application    # Casos de uso (Commands y Queries con MediatR)
├── 📁 ApiFutbolCostaRica.Infrastructure # Entity Framework Core, DbContext y Migraciones
└── 📁 ApiFutbolCostaRica.WebApi         # Controladores HTTP y configuración de Swagger
```

## Como ejecutar el proyecto localmente

1. Clona este repositorio:
   git clone https://github.com/TuUsuario/ApiFutbolCostaRica.git

2. Navega a la carpeta raiz de la solucion:
   cd ApiFutbolCostaRica

3. Restaura las dependencias y compila el proyecto:
   dotnet build

4. Navega a la carpeta de la API y ejecutala:
   cd ApiFutbolCostaRica.WebApi
   dotnet run

5. Abre tu navegador y accede a la interfaz de Swagger para probar los endpoints:
   https://localhost:<puerto>/swagger