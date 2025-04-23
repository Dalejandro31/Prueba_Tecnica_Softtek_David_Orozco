# Prueba Técnica - Autores y Libros

## Estructura del Proyecto

La solución está dividida en tres partes principales:

Prueba_tecnica/
├── CRUD.Backend     -> Aquí está la API (el servidor)
├── CRUD.Frontend    -> Aquí está la interfaz hecha con Blazor WebAssembly
└── CRUD.Shared      -> Aquí están los modelos que comparten el backend y el frontend


### ¿Por qué lo organicé así?

Decidí separar el proyecto en estas tres partes para tener todo más ordenado y poder reutilizar código:

- Los **modelos** como `Autor` y `Libro` están en el proyecto `CRUD.Shared`, así no tengo que copiarlos en el frontend y el backend.
- La **API (`CRUD.Backend`)** maneja toda la lógica de cómo se guarda un autor, cómo se conecta a la base de datos, etc.
- El **frontend (`CRUD.Frontend`)** se encarga de mostrar la información y permitir que el usuario interactúe con el sistema.

---

## ¿Cómo funciona?

- El usuario entra a la aplicación (el frontend hecho con Blazor).
- Desde ahí, se hacen llamadas HTTP a la API para consultar o modificar los datos.
- La API se conecta a una base de datos SQL Server usando Entity Framework Core.
---

## ¿Qué se puede hacer?

Desde el frontend se puede:

- Ver la lista de autores
- Ver los libros de cada autor
- Crear nuevos autores y libros
- Editarlos o eliminarlos
---

