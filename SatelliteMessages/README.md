## Ejercicio
El servicio de inteligencia ha detectado un llamado de auxilio de una nave enemiga a la deriva en un campo de asteroides. El manifiesto de la nave es ultra clasificado, pero se rumorea que transporta raciones y armamento para una legión entera.

Debes crear un programa que retorne la fuente y contenido del mensaje de auxilio. Para esto, cuentas con tres satélites que te permitirán triangular la posición, ¡pero cuidado! el mensaje puede no llegar completo a cada satélite debido al campo de asteroides frente a la nave.

Posición de los satélites actualmente en servicio
- Sat1: [-500, -200]
- Sat2: [100, -100]
- Sat3: [500, 100]

## Nivel 1
Crear un programa con las siguientes firmas:

  // input: distancia al emisor tal cual se recibe en cada satélite
  // output: las coordenadas 'x' e 'y' del emisor del mensaje
  func GetLocation(distances ...float32) (x, y float32)
  
  // input: el mensaje tal cual es recibido en cada satélite
  // output: el mensaje tal cual lo genera el emisor del mensaje
  func GetMessage(messages ...[]string(msg string)
  
Consideraciones:
- La unidad de distancia en los parámetros de GetLocation es la misma que la que se utiliza para indicar la posición de cada satélite.
- El mensaje recibido en cada satélite se recibe en forma de arreglo de strings.
- Cuando una palabra del mensaje no pueda ser determinada, se reemplaza por un string en blanco en el array.
  - Ejemplo: ["este", "es", "", "mensaje"]
- Considerar que existe un desfasaje (a determinar) en el mensaje que se recibe en cada satélite.
  - Ejemplo:
    - Sat1: ["", "este", "es", "un", "mensaje"]
    - Sat2: ["este", "", "un", "mensaje"]
    - Sat3: ["", "", "es", "", "mensaje"]

<hr>
Consideraciones propias:
- Las transmisiones de mensajes del satélite terminan inmediatamente luego de la última palabra, no existe desfasaje al final.
