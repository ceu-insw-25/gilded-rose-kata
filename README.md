# Introducción 

**Bienvenido a tu segunda tarea!**

La posada **"Gilded Rose"** está satisfecha con los cambios introducidos. Como preveen añadir una gran cantidad de objetos diferentes a su inventario, 
te preguntan si necesitas hacer algo en el programa para prepararte.

Tú sabes que la versión sobre la que has trabajado se hizo muy deprisa y no se pudieron aplicar las mejores prácticas.
Esta es una buena oportunidad para intentar limpiar el código y facilitarte el trabajo futuro.

No hay especificaciones de nueva funcionalidad o de cambios, ya que va a ser trabajo interno. La única restricción que se mantiene es que no 
puedes modificar la clase Item. Funcionalmente, por supuesto, la funcionalidad debe mantenerse.

## Tests

Los tests deberían ser suficientes para comprobar la funcionalidad actual, y como no hay que cambiar nada, te valdrán durante el proceso de refactor.
Aun así, si cambias suficiente la estructura del código o introduces nuevas funciones o métodos, quizá quieras extenderlos.

## Sugerencias 
A estas alturas del curso no hemos visto cómo desacoplar por completo la funcionalidad de cálculo de calidad de cada tipo de objeto del método UpdateQuality.
**Concéntrate en hacer el código existente lo más legible posible para facilitarte el trabajo futuro.**

Si aun así quieres intentar llevar esta limpieza a su máxima expresión, tu mejor opción es aplicar el patrón estrategia (https://refactoring.guru/design-patterns/strategy), o tus 
conocimientos del patrón de videojuegos Update Method (https://gameprogrammingpatterns.com/update-method.html). **En ningún caso deberías intentar
aplicar estos patrones antes de realizar unas primeras pasadas de refactor para legibilidad general.**
No dejes de consultar las transparencias del tema "Principios de Diseño", aunque no hayamos visto todavía en clase todo su contenido. 
Muchos de los consejos y buenas prácticas que detalla te pueden venir bien aquí.
 
## Entrega
Cuando tus cambios estén listos, o te quedes sin tiempo, abre una Pull Request desde la rama donde los has implementado. ***Si creas la rama pero no abres la Pull Request, no se considerará entregado***. 
La fecha límite de entrega podrás verla en Github Classroom

**Ánimo y suerte!**
