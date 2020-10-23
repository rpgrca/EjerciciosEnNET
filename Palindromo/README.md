# Palíndromo

## Descripción
Un palíndromo es una palabra que se lee igual de izquierda a derecha como de derecha a izquierda.

## Actividad
1. Crear una clase que detecte si una palabra es un palíndromo ("neuquen")
1. Extra: Ignorar mayúsculas y minúsculas en la comparación ("Neuquen")
1. Extra: Detectar números capicúas (43334)
1. Extra: Ignorar espacios al detectar ("sometamos o matemos", "    Dabale arroz a la zorra el abad")

## Resolución
- Ejercicio realizado en C# utilizando TDD.
- La clase Palindromo utiliza un ciclo repetitivo explícito para comparar cabeza con cola, moviendo los índices hacia el centro.
- La clase PalindromoSimple utiliza Linq para revertir un vector de caracteres y luego crea un string con la nueva cadena.
- Una vez obtenida la primer solución (Palindromo) se copiaron las pruebas para realizar el desarrollo de PalindromoSimple.
