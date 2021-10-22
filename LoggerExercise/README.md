Pasos realizados

  1. Migración de codigo de NET Framework a NET 5 (uso Linux). Antes que nada es necesario poder correrlo, en mi caso al usar Linux no puedo compilar código en NET Framework sin tener que instalar mono.
  1. Creación de base de datos en Microsoft Azure. Al estar en Linux no tengo acceso a una instancia de SQL Server local por lo que me es mucho más fácil crear una instancia en las nubes para conectarse.
  1. Ajuste de cadena de conexión. La cadena cambia un poco por lo que hardcodeo por el momento la cadena de conexión de la instancia en Azure.
  1. El query no funciona, "insert into Log_Values()" debería ser "insert into Log values()", también podría ser "insert into Log_Values values()".
