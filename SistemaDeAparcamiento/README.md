## Sistema de Aparcamiento

Felipe vio la oportunidad para competir con el playón de estacionamiento de enfrente de su edificio porque lo veía siempre lleno. Lo único que conoce de el es que los autos entran y salen y hay un cartel que avisa si el playón está lleno, pero no sabe cómo se determina. Decidió llamar a Tadeo para que diseñe un sistema de Aparcamiento para lo que Felipe llama “El Playón 2.0”.

Va a tener que poder hacer lo mismo que el playón de la competencia (ingresar y egresar autos y avisar cuando está lleno) pero también va a tener más inteligencia y así poder ganarle negocio a la competencia.

Tadeo planteo lo siguiente: El playón que tiene Felipe es un espacio tan grande que podrían ingresar vehículos por distintos lados, pero eso puede generar que ingresen más vehículos de lo permitido.

Para solucionar esto, decidió que el playón tenga tres playas, otorgándole la posibilidad de manejar los ingresos de los vehículos a partir de sus particularidades:
- Por la playa izquierda, solo pueden ingresar vehículos hasta ocupar la totalidad del espacio “5 vehículos”.
- Por la playa derecha, pueden ingresar vehículos hasta ocupar la totalidad del espacio “7 vehículos” y también pueden egresar vehículos de la playa derecha o izquierda.
- Por la playa central, pueden ingresar vehículos hasta ocupar la totalidad del espacio “8 vehículos” y también pueden egresar vehículos de cualquier playa.

Tadeo para asegurarse de que se respete el orden que definió, llamo a Julio para que defina los criterios del programa.

Julio pensando en cómo plasmar esto en un sistema estableció lo siguiente:

Contar con un menú de opciones:
1. Estacionar en Playa Izquierda.
   - Si hay espacio, permite el ingreso.
   - Si no hay espacio, el sistema le informa la falta de espacio en esa playa y además le informa en que playas si hay espacio.
1. Estacionar en Playa Derecha.
   - Si hay espacio, permite el ingreso.
   - Si no hay espacio, el sistema le informa la falta de espacio en esa playa y además le informa en que playas si hay espacio.
1. Estacionar en Playa Central.
   - Si hay espacio, permite el ingreso.
   - Si no hay espacio, el sistema le informa la falta de espacio en esa playa y además
le informa en que playas si hay espacio.
1. Egreso de Auto.
   - Si no hay autos en el playón, el sistema le informa que no es posible ejecutar con esta opción.
   - Si hay autos en el playón, el sistema le solicita a Julio de que playa está egresando el vehículo. Si no es valido lo ingresado, le solicita nuevamente la información hasta que la misma sea válida.
1. Cantidad de Autos estacionados en el playón.
   Esta opción notifica cuantos autos se encuentran estacionados en el playón.
1. Cantidad de Autos egresados.
   Esta opción notifica cuantos autos egresaron del playón.
1. Salir del sistema.
   Esta opción finaliza con el programa dándole el siguiente mensaje “Muchísimas Gracias por usar el sistema de Aparcamiento. Los datos acumulados del día de hoy se borrarán. Nos vemos en la próxima jornada laboral”

Desarrollar el sistema de aparcamiento respetando la forma propuesta por Tadeo considerando el menú solicitado por Julio. La aprobación consta en la correcta utilización y aplicación de las herramientas vistas sobre POO. Ejemplo Polimorfismo, herencias, modificadores de accesos, etc.
