## Introducción
Eres parte del equipo que explora Marte enviando vehículos controlados a distancia a la superficie del planeta. Desarrolle una API que traduzca los comandos enviados desde la Tierra a instrucciones que comprenda el Rover.

## Requisitos
  - Se le da el punto de partida inicial (x, y) de un rover y la dirección (N, S, E, W) a la que se enfrenta.
  - El rover recibe una serie de comandos en caracteres.
  - Implementar comandos que muevan el rover hacia adelante / hacia atrás (F, B).
  - Implemente comandos que giren el móvil hacia la izquierda / derecha (L, R).
  - El tamaño del mapa es de 10 x 10 casilleros.
  - Los planetas son esferas. Conecte el borde x al otro borde x, por ejemplo si está en la posición (x=0, y=3) y quiere moverse a la izquierda automáticamente pasa a la posición (x=9, y=3).
  - Implemente la detección de obstáculos antes de cada movimiento a una nueva casilla. Si una determinada secuencia de comandos encuentra un obstáculo, el móvil se mueve hasta el último punto posible, aborta la secuencia e informa del obstáculo.
  - Aplicar TDD con hardcode.
  - Tenga cuidado con las excepciones. No podemos permitirnos perder un rover en
Marte, solo porque los desarrolladores pasaron por alto un puntero nulo.
