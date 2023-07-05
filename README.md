# Prueba Tecnica - Full Stack


Informe Técnico: Aplicación Backend con C# .NET

Este informe técnico describe la implementación de una aplicación backend utilizando C# .NET y una base de datos SQL Server. Para desarrollar la aplicación, se utilizaron diversas tecnologías y herramientas populares, como el SDK de .NET 7, Entity Framework Core, Identity Framework, JWT, AutoMapper y Json.NET.

Arquitectura:
La aplicación se construyó siguiendo la arquitectura hexagonal, también conocida como arquitectura de puertos y adaptadores. Esta arquitectura se centra en la modularidad y la separación de responsabilidades. Se aplicaron buenas prácticas y principios SOLID para crear un código limpio y fácilmente mantenible.

Patrones utilizados:

Patrón Repositorio: Se implementó el patrón repositorio para separar la lógica de acceso a datos de la lógica de negocio. Esto permite cambiar la capa de acceso a datos sin afectar el resto de la aplicación.
Inyección de dependencias: Se utilizó la inyección de dependencias para lograr un acoplamiento flexible entre los componentes de la aplicación. Esto facilita la reutilización de código y la configuración de la aplicación.
Tecnologías y herramientas utilizadas:

SDK de .NET 7: Se utilizó la última versión del SDK de .NET para el desarrollo del backend.
Entity Framework Core: Se utilizó este ORM para facilitar el acceso a la base de datos SQL Server.
Identity Framework: Se utilizó Identity Framework para gestionar la autenticación y autorización de usuarios.
JWT (JSON Web Tokens): Se utilizó JWT para generar y validar tokens de autenticación, lo que mejora la seguridad de la aplicación.
AutoMapper: Se utilizó AutoMapper para mapear automáticamente objetos DTO a entidades y viceversa.
Json.NET: Se utilizó Json.NET (Newtonsoft.Json) para la serialización y deserialización de objetos JSON.
El desarrollo del backend se realizó siguiendo las mejores prácticas de programación y se tuvo en cuenta la seguridad y escalabilidad. Se implementaron pruebas unitarias y se gestionaron adecuadamente los errores y excepciones.




Informe Técnico: Aplicación Frontend con Angular

En este informe técnico, se describe la implementación de la aplicación frontend utilizando Angular. Aunque se utilizó Angular versión 15, se tiene en cuenta que la versión recomendada y más actualizada es Angular 12. Sin embargo, se aseguró de implementar código que también sería compatible con Angular 12.

Tecnologías y herramientas utilizadas:

Angular 15: Se utilizó Angular como el framework principal para el desarrollo del frontend.
Bootstrap 5: Se utilizó el framework de diseño Bootstrap 5 para crear una interfaz de usuario moderna y receptiva.
Angular Material: Se hizo uso de la biblioteca Angular Material para aprovechar sus componentes predefinidos y estilos de diseño.
Módulos: La aplicación se estructuró en módulos para aprovechar la carga diferida o lazy loading. Esto mejora el rendimiento al cargar los módulos de manera dinámica según sea necesario.
En cuanto a la implementación, se siguieron las mejores prácticas de desarrollo de Angular, como el uso de componentes, directivas, servicios y enrutamiento. Se aplicaron patrones de diseño recomendados y se siguió el principio de separación de responsabilidades para garantizar un código limpio y mantenible.

A pesar de utilizar Angular 15, se tuvo en cuenta la compatibilidad con Angular 12 y se aseguró de que el código implementado funcionara correctamente en ambas versiones.

quedaron pendiente algunas validaciones en el frontend y pruebas unitarias, siendo completamente transparente indicando que en angular apenas empecé aprender pruebas unitarias.




Funcionalidad de la aplicacion:

La aplicación desarrollada incluye las siguientes funcionalidades:

Gestión de entidades: Se crearon las entidades Empleado, Lideres, ReporteHoraExtra, Areas, Generos y Estados. Estas entidades están relacionadas entre sí utilizando el motor de SQL Server.

Tabla ReporteHoraExtra: Se intentó crear una tabla ReporteHoraExtra que utiliza la relación entre empleados y estados para parametrizar las horas del personal. Sin embargo, esta funcionalidad no se pudo completar al 100%.

Autorización de Horas: Se planeaba implementar la funcionalidad de permisos de autorización de horas, pero no se pudo finalizar en su totalidad.

Interceptores: Se utilizan interceptores para manejar las solicitudes HTTP y realizar tareas como agregar encabezados de autorización o manejar errores.

Guards: Se implementaron guards para proteger las rutas y asegurar que solo los usuarios autenticados puedan acceder a ciertas páginas.

Reactividad: Se utilizó la programación reactiva para manejar los cambios en los datos y actualizar la interfaz de usuario en consecuencia.

Almacenamiento de datos del usuario: Se utilizó el localStorage para guardar los datos del usuario, lo que permite mantener la sesión activa y recordar la información del usuario entre sesiones.

Aunque la aplicación no se completó al 100%, se lograron implementar algunas funcionalidades importantes, como la gestión de entidades, la utilización de interceptores y guards, y el almacenamiento de datos del usuario. Se reconoce que quedaron pendientes funcionalidades como la completa parametrización de las horas del personal y la finalización de los permisos de autorización de horas.



Usuario para ingreso: 

Usuario: john.rios@sisteCredito.com - Pwd: Siste2023* - Rol: Gerente
Usuario: vivian.ochoa@sisteCredito.com - Pwd: Siste2023*  - Rol: Tesoreria
Usuario: santiago.rios@sisteCredito.com - Pwd: Siste2023* - Rol: LiderTecnico
Usuario: paulina.david@sisteCredito.com - Pwd: Siste2023* - Rol: Empleado
