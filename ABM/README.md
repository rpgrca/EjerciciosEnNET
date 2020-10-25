Dada una base de datos en SQL Server X con el esquema:

                   +----------------+
                   | VENTAS_ITEMS   |  +-----------+
    +-----------+  +----------------+  | VENTAS    |  +----------+
    | PRODUCTOS |  | Id             |  +-----------+  | CLIENTES |
    +-----------+  | IdVenta        |->| Id        |  +----------+
    | Id        |->| IdProducto     |  | IdCliente |->| Id       |
    | Nombre    |  | PrecioUnitario |  | Fecha     |  | Nombre   |
    | Precio    |  | Cantidad       |  | Total     |  | Telefono |
    | Categoria |  | PrecioTotal    |  +-----------+  | Correo   |
    +-----------+  +----------------+                 +----------+

1. Alta, baja y modificación de clientes y productos
1. Consulta de clientes y productos con filtros y selección
1. Alta, baja y modificación de ventas
1. Consulta de ventas con filtros y visualización completa de los datos al cierre de la venta.

Condiciones:
1. Crear la base de datos con el script adjunto
1. No utilizar stored procedures
1. Utilizar Visual Studio 2019
1. Utilizar NET Framework 4.7.2
1. Utilizar Vb.NET
1. Utilizar System.Data.SqlClient.SqlConnection
1. Utilizar cadena de conexión:
   Server=localhost;Uid=sa;Pwd=sasa;MultipleActiveResultSets=True;Timeout=120;Database=demo
1. La cadena de conexión debe leerse desde el archivo App.config
1. Desarrollar la aplicación en tres capas orientada a objetos (POO). Por ejemplo cliente, producto, venta y sus items deben ser objetos que se comunicarán desde la interfaz gráfica hasta la base de datos y viceversa.
1. Las clases que representarán a los objetos mencionados deben tener características (propiedades) y comportamiento (métodos) que le corresponden.
