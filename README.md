# Proyecto Final Programación II.
## Equipo LRAC, Proyecto Pokémon.
#### Equipo integrado por Lautaro Arrigoni, Adolfo Bravo, Agustin Cigaran y Bernardino Ochoa.

![](https://i.pinimg.com/originals/f3/44/58/f344588bb0af858118a06d2004d2420d.gif) 
___

### Introducción

El mismo, se trata del desarrollo de un chatbot, cuyo proposito sera facilitar la introduccion de acciones dentro de un entorno de chat. Este bot permitira organizar y gestionar una batalla entre jugadores utilizando Pokémon como personajes principales.

Cada jugador contará con un equipo compuesto por seis Pokémon, los cuales participarán en combates estratégicos contra los oponentes. Cada Pokémon tendrá atributos específicos como vida, ataque y turno de participación. Asimismo, se dispondrá de una variedad de tipos de Pokémon, cada uno con una efectividad particular frente a otros tipos, lo que añadirá un componente táctico a las batallas.

La victoria será otorgada al jugador que logre reducir la vida de todos los Pokémon del adversario a cero (0). Además, durante el desarrollo de la batalla, los jugadores tendrán la opción de intercambiar los Pokémon de su equipo, proporcionando mayor dinamismo y flexibilidad en el transcurso del combate.
___

### Primera Entrega
Para comenzar al equipo se le panteó una **lista objetivos** que debía cumplir para la realización del proyecto pokémon, estos mismo eran:
- Realizar las tarjetas CRC, responsabilidades y colaboraciones identificadas para resolver el problema.
- Diagrama de Clases(UML) con las clases del modelo identificadas.
- Codigo C# de las clases de dominio.
- Facada

___

#### Facada.
![Facada](https://github.com/ucudal/pii_2024_2_equipo31/blob/agustin/docs/FACADA%20Final%20Segunda%20Entrega.png)

___

### Segunda Entrega.
En la segunda entrega del proyecto, se implementaron varias mejoras significativas y se ampliaron las funcionalidades originales del sistema. Entre los principales avances se encuentran la incorporación de ataques especiales para los Pokémon, que añaden un nivel de intensidad y estrategia adicional a las batallas. Estos ataques especiales permiten que cada Pokémon tenga habilidades únicas, ofreciendo así una mayor variedad de interacciones durante el combate.

Otro aspecto fundamental en esta segunda etapa fue la implementación de la efectividad de tipos. Los tipos de Pokémon, como agua, fuego, planta, entre otros, ahora tienen un impacto directo en la batalla, replicando las dinámicas de ventaja y desventaja presentes en el universo Pokémon. Esta nueva mecanica ayuda a que las decisiones de los jugadores durante la batalla sean más relevantes y cuidadosas.

En cuanto a la optimización del código, se llevaron a cabo diversas correcciones que permitieron mejorar la eficiencia del programa y corregir errores presentes en la primera entrega. Estas correcciones fueron esenciales para garantizar que el bot y el sistema de combate funcionen de manera fluida y sin fallos. Además, el código fue revisado para asegurar que cumpliera con lo planeado.

Continuando, como parte del proceso de actualización, se realizó una reestructuración del diagrama UML. Esta revisión del diseño fue necesaria para reflejar los cambios implementados en el sistema y asegurar que el modelo mantuviera una representación precisa y coherente de las nuevas características. El diagrama UML actualizado ahora incluye las relaciones entre los Pokémon, sus ataques, los tipos, y las interacciones dentro de las batallas, brindando una visión clara y estructurada del programa.

___

#### Diagrama de clases (UML ACTUAL).
![UML](https://github.com/ucudal/pii_2024_2_equipo31/blob/agustin/docs/UML%20Segunda%20Entrega%20Final.png)
___

#### Tarjetas CRC (ACTUAL)
![CRC](https://github.com/ucudal/pii_2024_2_equipo31/blob/agustin/docs/CRC%20Final%20Segunda%20Entrega.png)
___

### Desafíos Encontrados.
- Implementación de la sala de espera, fue desafiante tanto al intentar iniciar una batalla con los usuarios en la sala, como para ver la lista de jugadores en espera.
- Los items del jugador estaban implementados/vinculados en una lista de int, se mejoro creando una clase para dichos items para que cumpla de mejor manera la consigna e intentando que cumpla con el principio de delegación.
- El cambio de pokemon fue un problema, tanto el hecho de cambiar durante la batalla como intentar cambiarlo cuando ya no tenia vida. (la utilización del comando ref fue clave)
- Cuando el pokemon en batalla perdia toda su vida y no tenia mas items revivir, la batalla se perdia automaticamente, no se consideraba si habian mas pokemons disponibles para luchar o no.
- Uno de los desafios "finales" fue en cuanto a la implementación del bot, ya que el proyecto ya estaba enfocado en ir mostrando los mensajes por consola y cuando se ejecutaba el bot por discord no mostraba los pokemones, etc. Debido a ello se tuvo que cambiar casi todos los "console.writeline" por return en los metodos void o por el comando "out mensaje" para los metodos que ya devolvian algo como un tipo pokemon, de esa forma el metodo tiene una "doble devoluciom" o un "doble tipo" y se puede enviar dichos mensajes al bot.
___

### Bibliografía

[Interfaces](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/interfaces)

[Clases Abstractas](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/abstract-and-sealed-classes-and-class-members)

[Switch](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements#the-switch-statement)

[Null](https://learn.microsoft.com/en-us/dotnet/csharp/nullable-references)

[Ref](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/ref)

[Do while](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements)

[Refactorización y patrones de diseño](https://refactoring.guru/design-patterns)

[Conocimientos Pokémon](https://play.pokemonshowdown.com/teambuilder)

[Conocimientos Pokémon](https://www.pokemon.com/us/pokedex)

[Diseños](https://github.com/ucudal/PII_Guias)

[Discord Bot](https://discordjs.guide/#before-you-begin)

___

