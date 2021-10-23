Pasos de preparación realizados

  1. Migración de codigo de NET Framework a NET 5 (uso Linux). Antes que nada es necesario poder correrlo, en mi caso al usar Linux no puedo compilar código en NET Framework sin tener que instalar mono.
  1. Separación de clases en archivos separados.
  1. Creación de base de datos en Microsoft Azure. Al estar en Linux no tengo acceso a una instancia de SQL Server local por lo que me es mucho más fácil crear una instancia en las nubes para conectarse.
  1. Ajuste de cadena de conexión. La cadena cambia un poco por lo que hardcodeo por el momento la cadena de conexión de la instancia en Azure.
  1. El query no funciona, "insert into Log_Values()" debería ser "insert into Log values()", también podría ser "insert into Log_Values values()".
  1. Una vez que se confirmó que la aplicación funciona se crea una librería separada para la lógica de negocios ya que no es conveniente colocar al exe como referencia de las pruebas unitarias.

Pasos de exploración realizados

  1. Con el proyecto en funcionamiento se empieza a explorar la aplicación creando pruebas sin modificar el código fuente actual buscando bugs, forzando las excepciones existentes, etc.
  1. Primero se explora el logging a archivo, combinando las distintas entradas en distintas pruebas para forzar la ejecucion de cada camino.
  1. Se descubre un bug donde todas las lineas salen una a continuacion de la otra, se soluciona para que cada log salga en una linea distinta.
  1. Una vez cubierta la totalidad de la funcionalidad del log, se la encapsula en un método para eventualmente convertirse en una clase.