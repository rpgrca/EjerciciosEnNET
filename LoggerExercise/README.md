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
  1. Se continúa con un refactoreo del código separando en funciones, se convierten variables estáticas en atributos de instancia, se mueven chequeos al constructor para que no se pueda construir instancias inválidas.
  1. Luego del refactoreo se empieza a generar casos de prueba para el logging a base de datos.
  1. Se detecta un funcionamiento cuestionable: si un mensaje no está para ser procesado (por ejemplo, se va a loguear mensajes y llega un warning) se graba igual con nivel 0. Desde mi punto de vista es un bug, se por un lado se graba siempre en base de datos (contrario al logging por archivo donde no se graban los textos de los mensajes no queridos) sino también se pierde el tipo y no es posible recuperarlo. Los logs deben tener consistencia.
  1. Al solucionarlo se detecta otro funcionamiento cuestionable: en la base de datos se escribe un único registro mientras que en el archivo de texto y en la consola se escriben varios. Tiene sentido que un mensaje sea también una advertencia y un error? No deberían ser excluyentes como en el caso de la base de datos?
  1. Se implementa un parameter object para unir el texto del log con los flags.
  1. Se implementa el Builder pattern para construir al parameter object Entry.
  1. Se soluciona un bug, si el archivo de log ya existe en el disco nunca se abre siquiera y revienta.
  1. Si no hay nada que loguear ni siquiera se abre el archivo (antiguamente se creaba un archivo vacío).
  1. En el logueo de base de datos se le da mayor prioridad al warning que al error, eso debería cambiarse (además de correr una actualización a la base para cambiar todos los 2 por 3 y todos los 3 por 2 eventualmente).


        public const string DATABASE_SERVER = "tcp:logger-exercise-server.database.windows.net,1433";
        public const string DATABASE_NAME = "logger";
        public const string DATABASE_PASSWORD = "Extremely_Long_Password";
        public const string DATABASE_USERNAME = "Logger_server_admin_login";
     }
