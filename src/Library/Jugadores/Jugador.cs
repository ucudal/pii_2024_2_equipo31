using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.SlashCommands;

namespace Library;

/// <summary>
/// Representa un jugador en el juego de Pokémon.
/// </summary>
public class Jugador
{
    /// <summary>
    /// Nombre del jugador.
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Obtiene el Pokémon que está actualmente en batalla.
    /// </summary>
    public Pokemon pokemonEnBatalla { get; private set; }
    /// <summary>
    /// Lista de Pokémon del jugador.
    /// </summary>
    public List<Pokemon> ListPokemons { get; set; }

    /// <summary>
    /// Lista de Pokémon disponibles en el juego.
    /// </summary>
    private List<Pokemon> pokemonsDisponibles;

    /// <summary>
    /// Diccionario que almacena la cantidad de ítems del jugador.
    /// </summary>
    public List<Items_Jugador> Items { get; set; }

    /// <summary>
    /// Constructor que inicializa un nuevo jugador con un nombre y establece los Pokémon y los ítems.
    /// </summary>
    /// <param name="nombre">Nombre del jugador.</param>
    public Jugador(string nombre)
    {
        this.Name = nombre;
        ListPokemons = new List<Pokemon>();
        Items = new List<Items_Jugador>()
        {
             new ("Súper pociones", 4) ,
              new ("Cura total", 2 ),
             new ("Revivir", 1) 
        };
        Inicializar_Total_Pokemons_Disponibles_Juego();
    }

    /// <summary>
    /// Crea una lista con todos los Pokémon del juego a modo de base de datos.
    /// </summary>
    public List<Pokemon> Inicializar_Total_Pokemons_Disponibles_Juego() 
    {
        pokemonsDisponibles = new List<Pokemon>
        {
            new Pokemon(1,"Crocalor", 81, 78, "Fuego", new List<IAtaque>
            {
                new AtaqueNormal("Explosion de Fuego", 110, "Fuego"),
                new AtaqueNormal("Colmillo de Fuego", 65, "Fuego"),
                new AtaqueNormal("Carga de Fuego", 50, "Fuego"),
                new AtaqueEspecial(" ⚠ Lanzallamas", 90, 2, "Fuego")
            }),

            new Pokemon(2,"Cacnea", 50, 40, "Hierba", new List<IAtaque>
            {
                new AtaqueNormal("Bola de Energia", 90, "Hierba"),
                new AtaqueNormal("Drenaje", 75, "Hierba"),
                new AtaqueNormal("Nudo de Hierba", 45, "Hierba"),
                new AtaqueEspecial(" ⚠ Tormenta de Hojas", 130, 2, "Hierba")
            }),

            new Pokemon(3,"Dewott", 75, 60, "Agua", new List<IAtaque>
            {
                new AtaqueNormal("Cuchilla de Agua", 70, "Agua"),
                new AtaqueNormal("Chorro de Agua", 40, "Agua"),
                new AtaqueNormal("Marea Alta", 90, "Agua"),
                new AtaqueEspecial(" ⚠ Agua Helada", 50, 2, "Agua")
            }),
            new Pokemon(4,"Gagnar", 60, 60, "Fantasma", new List<IAtaque>
            {
                new AtaqueNormal("Maldicion", 20, "Fantasma"),
                new AtaqueNormal("Vinculo de Destino", 65, "Fantasma"),
                new AtaqueNormal("Mal de Ojo", 65, "Fantasma"),
                new AtaqueEspecial(" ⚠ Sombra Nocturna", 40, 2, "Fantasma")
            }),
            new Pokemon(5,"Mareep", 55, 40, "Electrico", new List<IAtaque>
            {
                new AtaqueNormal("Descarga", 80, "Electrico"),
                new AtaqueNormal("Trueno", 75, "Electrico"),
                new AtaqueNormal("Rayo", 90, "Electrico"),
                new AtaqueEspecial(" ⚠ Choque Relampago", 110, 2, "Electrico")
            }),
            new Pokemon(6,"NosePass", 30, 135, "Roca", new List<IAtaque>
            {
                new AtaqueNormal("Cabezazo", 150, "Roca"),
                new AtaqueNormal("Rayo de Meteorito", 120, "Roca"),
                new AtaqueNormal("Gema de poder", 80, "Roca"),
                new AtaqueEspecial(" ⚠ Explosion de Roca", 25, 2, "Roca")
            }),
            new Pokemon(7,"Arceus", 120, 120, "Veneno", new List<IAtaque>
            {
                new AtaqueNormal("Disparo de Basura", 40, "Veneno"),
                new AtaqueNormal("Colmillo de Veneno", 80, "Veneno"),
                new AtaqueNormal("Bomba de lodo", 90, "Veneno"),
                new AtaqueEspecial(" ⚠ Spray Ácido", 120, 2, "Veneno")
            }),

            new Pokemon(8,"Chansey", 250, 5, "Normal", new List<IAtaque>
            {
                new AtaqueNormal("Golpe de Cuerpo", 85, "Normal"),
                new AtaqueNormal("Doble filo", 70, "Normal"),
                new AtaqueNormal("Esfuerzo Brutal", 45, "Normal"),
                new AtaqueEspecial(" ⚠ Golpe Fuerte", 120, 2, "Normal")
            }),

            new Pokemon(9,"Corviknight", 98, 105, "Volador", new List<IAtaque>
            {
                new AtaqueNormal("Cuchilla de Viento", 75, "Volador"),
                new AtaqueNormal("Valentía Aviar", 80, "Volador"),
                new AtaqueNormal("Torbellino", 90, "Volador"),
                new AtaqueEspecial(" ⚠ Pico Taladro", 120, 2, "Volador")
            }),
            new Pokemon(10,"Donphan", 90, 120, "Tierra", new List<IAtaque>
            {
                new AtaqueNormal("Poder de la tierra", 65, "Tierra"),
                new AtaqueNormal("Terremoto", 100, "Tierra"),
                new AtaqueNormal("Alta Potencia", 95, "Tierra"),
                new AtaqueEspecial(" ⚠ Intimidación", 105, 2, "Tierra")
            }),
            new Pokemon(11,"Dragonite", 91, 95, "Dragón", new List<IAtaque>
            {
                new AtaqueNormal("Meteorito", 130, "Dragón"),
                new AtaqueNormal("Garra de Dragón", 80, "Dragón"),
                new AtaqueNormal("Danza del Dragón", 85, "Dragón"),
                new AtaqueEspecial(" ⚠ Embiste Furioso", 99, 2, "Dragón")
            }),
            new Pokemon(12,"Kyurem", 125, 90, "Hielo", new List<IAtaque>
            {
                new AtaqueNormal("Avalancha", 60, "Hielo"),
                new AtaqueNormal("Viento del Norte", 90, "Hielo"),
                new AtaqueNormal("Criogelación", 70, "Hielo"),
                new AtaqueEspecial(" ⚠ Laser Congelado", 110, 2, "Hielo")
            }),
            new Pokemon(13,"Mewtwo", 106, 90, "Psiquico", new List<IAtaque>
            {
                new AtaqueNormal("Golpe Agil", 60, "Psiquico"),
                new AtaqueNormal("Mente Calmada", 60, "Psiquico"),
                new AtaqueNormal("Expansión Forzada", 80, "Psiquico"),
                new AtaqueEspecial(" ⚠ Ataque Futuro", 120, 2, "Psiquico")
            }),
            new Pokemon(14,"Ribombee", 60, 60, "Bicho", new List<IAtaque>
            {
                new AtaqueNormal("Zumbido", 90, "Bicho"),
                new AtaqueNormal("Sanguijuela", 80, "Bicho"),
                new AtaqueNormal("Estocada", 80, "Bicho"),
                new AtaqueEspecial(" ⚠ Danza del Bicho", 95, 2, "Bicho")
            }),
        };
        return pokemonsDisponibles;
    }
    
    /// <summary>
    /// Verifica que el usuario escriba un ID válido.
    /// </summary>
    /// <param name="listapokemons">Lista de Pokémon de donde se seleccionará.</param>
    /// <param name="debeEstarDisponibleParaCombate">Indica si el Pokémon debe estar disponible para combate.</param>
    /// <returns>El Pokémon encontrado.</returns>
    private Pokemon Seleccionar_Pokemon_De_Una_Lista_Segun_Su_ID( double idPok, List<Pokemon> listapokemons, bool debeEstarDisponibleParaCombate = false) 
    {
        Pokemon encontrado = null;
        
        foreach (Pokemon bicho in listapokemons)
        {
            if (bicho.Id == idPok)
            {
                return bicho;
            }
        }
        return encontrado;
    }

    /// <summary>
    /// Hace que cada jugador seleccione a 6 Pokémon en su lista.
    /// </summary>
    public string Seleccionar_6_Pokemons_Iniciales(double idPok)
    {
        string mensaje = "";
        
        if (ListPokemons.Count < 6)
        {
            Pokemon encontrado = Seleccionar_Pokemon_De_Una_Lista_Segun_Su_ID( idPok, pokemonsDisponibles, true);

            if (encontrado == null)
            {
                mensaje += "\n 🚫 Seleccion invalida o Pokemon ya seleccionado.";
                return mensaje;
            }
            if (!ListPokemons.Contains(encontrado))
            {
                ListPokemons.Add(encontrado);
				pokemonsDisponibles.Remove(encontrado);
                mensaje += $"\n 🐵 {this.Name} añadio a {encontrado.Name}";
            }
            else
            {
                mensaje += "\n 🚫 Seleccion invalida o Pokemon ya seleccionado.";
                return mensaje;
            }
        }
        else
        {
            mensaje = "\nSelección completada: tienes 6 pokemom.";
        }
        return mensaje;
    }
    
    /// <summary>
    /// El jugador selecciona Pokémon que estén disponibles para luchar.
    /// </summary>
    /// <param name="mensaje"></param>
    /// <param name="pokemonActual">El Pokémon actual que se encuentra en combate.</param>
    /// <returns>El Pokémon seleccionado para luchar.</returns>
    public Pokemon Seleccionar_Pokemons_Para_Luchar(out string mensaje, double idPok, Pokemon pokemonActual = null)
    {
        if (!Jugador_Tiene_Pokemons_Disponibles_Para_Luchar()) 
        {
            mensaje = $"\n{this.Name} no tiene mas pokemons disponibles para luchar";
            return null;
        }
        
        mensaje = $"\n ◽ {this.Name}\n ⏳ selecciona un Pokemon para luchar: \n";
        
        Pokemon encontrado = Seleccionar_Pokemon_De_Una_Lista_Segun_Su_ID( idPok, ListPokemons, true);
        
        if (encontrado == null)
        {
            mensaje = "\nNo se pudo seleccionar ningun pokemon";
        }

        if (pokemonActual != null)
        {
            pokemonActual.EnCombate = false;
        }

        encontrado.EnCombate = true;
        
        mensaje +=  $"\n 🐵 {this.Name} saco a {encontrado.Name}\n" + 
                    $"\n 🐵 {encontrado.Name} tiene {encontrado.Hp} puntos de vida, {encontrado.Defensa} puntos de defensa y es de tipo {encontrado.Tipo}\n";
        
        pokemonActual = encontrado;
        pokemonEnBatalla = pokemonActual;
        return pokemonActual;   
    }

    /// <summary>
    /// Muestra todos los Pokémon disponibles del juego (no los del jugador).
    /// </summary>
    public string Mostrar_Todos_Los_Pokemons_Disponibles_Del_Juego() 
    {
        var mensaje = "\nPokemons disponibles: ";
        foreach (var pokemon in pokemonsDisponibles)
        {
            mensaje += $"\n ✪ {pokemon.Id} - {pokemon.Name} (Vida: {pokemon.Hp}, Defensa: {pokemon.Defensa}, Tipo: {pokemon.Tipo})";
        }
        return mensaje;
    }
    
    /// <summary>
    /// Muestra una lista de los Pokémon disponibles del jugador actual.
    /// </summary>
    /// <returns>Una cadena que contiene la lista de Pokémon con su ID, nombre, vida, defensa y tipo.</returns>
    public string Mostrar_Pokemons_Disponibles_Del_Jugador() 
    {
        var mensaje = "\nPokemons disponibles del jugador actual: ";
        foreach (var pokemon in ListPokemons)
        {
            mensaje += $"\n ✪ {pokemon.Id} - {pokemon.Name} (Vida: {pokemon.Hp}, Defensa: {pokemon.Defensa}, Tipo: {pokemon.Tipo})";
        }
        return mensaje;
    }
    
    /// <summary>
    /// Presenta las acciones disponibles para el jugador durante una batalla Pokémon.
    /// </summary>
    /// <param name="propio">El Pokémon del jugador.</param>
    /// <param name="oponente">El Pokémon oponente.</param>
    /// <param name="ctx">El contexto de la interacción del componente Discord.</param>
    /// <returns>Una tarea que representa la operación asíncrona.</returns>
    public async Task Acciones_Del_Jugador_En_Batalla(Pokemon propio, Pokemon oponente, ComponentInteractionCreateEventArgs ctx) 
    {
        string mensaje = $"\n ⚪ {this.Name}, elige una accion:\n";
        
        DiscordComponent[] components;
        
        if (!propio.El_Pokemon_Esta_Derrotado())
        {
            components = new DiscordComponent[]{
                new DiscordButtonComponent(ButtonStyle.Secondary, "bag", "Usar Mochila"),
                new DiscordButtonComponent(ButtonStyle.Success, "switch", "Cambiar Pokémon"),
                new DiscordButtonComponent(ButtonStyle.Primary, "attack", "Atacar"),
                new DiscordButtonComponent(ButtonStyle.Success, "estategia", "Posibilidades")
            };
        }
        else
        {
            components = new DiscordComponent[]
            {
                new DiscordButtonComponent(ButtonStyle.Secondary, "bag", "Usar Mochila"),
                new DiscordButtonComponent(ButtonStyle.Success, "switch", "Cambiar Pokémon"),
                new DiscordButtonComponent(ButtonStyle.Success, "estategia", "Posibilidades")
            };
        }

        var builder = new DiscordMessageBuilder()
            .WithContent(mensaje)
            .AddComponents(components);
        await ctx.Channel.SendMessageAsync(builder);
        string mensajesEstados = propio.AplicarEstados();
        await ctx.Channel.SendMessageAsync(mensajesEstados);
    }
    
    /// <summary>
    /// Verifica si el jugador tiene Pokémon con vida en su lista.
    /// </summary>
    /// <returns>
    /// Devuelve true si el jugador tiene Pokémon disponibles para luchar, de lo contrario, false.
    /// </returns>
    public bool Jugador_Tiene_Pokemons_Disponibles_Para_Luchar() 
    {
        foreach (Pokemon pokemon in ListPokemons)
        {
            if(pokemon.Hp > 0 && !pokemon.EnCombate)
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Gestiona el uso de objetos de la mochila del jugador durante una batalla.
    /// </summary>
    /// <param name="objeto">El nombre del objeto a usar.</param>
    /// <param name="pokemonMoch">El Pokémon al que se aplicará el objeto.</param>
    /// <returns>Un mensaje que describe el resultado de la acción.</returns>
    public string Mochila_Del_Jugador(string objeto, Pokemon pokemonMoch)
    {
        string mensaje = "";
        switch (objeto)
        {
            case "Súper pociones":
                if (!pokemonMoch.El_Pokemon_Esta_Derrotado())
                {
                    pokemonMoch.Hp += 70;
                    if (pokemonMoch.Hp > pokemonMoch.HpInicial)
                    {
                        pokemonMoch.Hp = pokemonMoch.HpInicial;
                    }
                    mensaje += $"\n 💝 {this.Name} usó una super poción en {pokemonMoch.Name} y ahora tiene {pokemonMoch.Hp} puntos de vida";
                    Items[0].Cantidad -= 1;
                    mensaje += $"\nA {this.Name} le quedan ***{Items[0].Cantidad} super pociones*** en su mochila.";
                }
                else
                {
                    mensaje = "\nSolo puedes curar a un pokemon que no este derrotado!";
                }
            
                break;

            case "Cura total":
                if (pokemonMoch.Hp > 0)
                {
                    if(pokemonMoch.EstadoNegativo != "Ninguno")
                    {
                        mensaje += $"\n 💉 {this.Name} usó una cura total en {pokemonMoch.Name} y se recupero de todos los efectos negativos";
                        Items[1].Cantidad -= 1;
                        pokemonMoch.EstadoNegativo = "Ninguno";
                        mensaje += $"\nA {this.Name} le quedan ***{Items[1].Cantidad} curas totales*** en su mochila.";
                    }
                    else if (pokemonMoch.EstadoNegativo == "Ninguno")
                    {
                        mensaje = $"\n{pokemonMoch.Name} no tiene ningun estado negativo por ser revertido." + 
                                  $"\nA {this.Name} aun le quedan ***{Items[1].Cantidad} curas totales***";
                    }
                    break;
                }

                mensaje = "\nNo puedes curar a un pokemon que no tiene vida";
                break;

            case "Revivir":
                if (pokemonMoch.El_Pokemon_Esta_Derrotado())
                {
                    pokemonMoch.Hp = pokemonMoch.HpInicial * 0.5;
                    mensaje += $"\n 😇 {pokemonMoch.Name} fue revivido y ahora tiene {pokemonMoch.Hp} puntos de vida";
                    Items[2].Cantidad -= 1;
                    mensaje += $"\nA {this.Name} le quedan ***{Items[2].Cantidad} revivir*** en su mochila.";
                }
                else
                {
                    mensaje = "\nSolo puedes revivir a un pokemon que este derrotado!";
                }

                break;

            default:
                mensaje = $"\n 🚫 El objeto '{objeto}' no está disponible en la mochila.";
                break;
        }
        return mensaje;
    }
    
    // Metodo de la defensa
    /// <summary>
    /// 
    /// </summary>
    /// <param name="propio"> Lista de pokemons que tiene el jugador en turno en su mochila</param>
    /// <param name="oponente"> Pokemon del rival</param>
    /// <returns></returns>
    public string PosibilidadDeGanarle(List<Pokemon> propio, Pokemon oponente)
    {
        string mensaje = null;
        for (int i = 0; i < propio.Count -1 ; i++)
        {
            mensaje = $"***{propio[i].Name} es de tipo {propio[i].Tipo}***";
            if (propio[i].Tipo.Equals("Agua"))
            {
                mensaje += "\nTiene ***mas posibilidades*** de ganarle a los de tipo: ***Agua, Fuego, Hielo***";
                mensaje += "\nY tiene ***menos posiblidades*** de ganarle a los de tipo: ***Electrico y Hierba***";
                mensaje += $"\nConsidere que el tipo de su rival es {oponente.Tipo}";
                return mensaje;
            }

            if (propio[i].Tipo.Equals("Bicho"))
            {
                mensaje += "\nTiene ***mas posibilidades*** de ganarle a los de tipo: ***Lucha, Hierba, Tierra***";
                mensaje += "\nY tiene ***menos posibilidad*** de ganarle a los de tipo: ***Agua, Roca, Tierra***";
                mensaje += $"\nConsidere que el tipo de su rival es {oponente.Tipo}";
                return mensaje;
            }
            else if (propio[i].Tipo.Equals("Dragón"))
            {
                mensaje += "\nTiene ***menos posibilidades*** de ganarle a los de tipo: ***Dragon, Hierba***";
                mensaje +=
                    "\nY tiene ***mas posibilidad*** de ganarle a los de tipo: ***Agua, Electrico, Fuego, Hierba***";
                mensaje += $"\nConsidere que el tipo de su rival es {oponente.Tipo}";
                return mensaje;
            }
            else if (propio[i].Tipo.Equals("Electrico"))
            {
                mensaje += "\nTiene ***mas posibilidades*** de ganarle a los de tipo: ***Volador***";
                mensaje += "\nTiene ***menos posibilidad*** de ganarle a los de tipo: ***Tierra***";
                mensaje += "\nSu pokemon tiene ***NULAS posibilidades*** de ganarle a otro de tipo: ***Electrico***";
                mensaje += $"\nConsidere que el tipo de su rival es {oponente.Tipo}";
                return mensaje;
            }
            else if (propio[i].Tipo.Equals("Fantasma"))
            {
                mensaje += "\nTiene ***menos posibilidades*** de ganarle a los de tipo: ***Fantasma***";
                mensaje += "\nY tiene ***mas posibilidad*** de ganarle a los de tipo: ***Veneno, Lucha, Normal***";
                mensaje += $"\nConsidere que el tipo de su rival es {oponente.Tipo}";
                return mensaje;
            }
            else if (propio[i].Tipo.Equals("Fuego"))
            {
                mensaje += "\nTiene ***mas posibilidades*** de ganarle a los de tipo: ***Bicho, Fuego, Hierba***";
                mensaje += "\nY tiene ***menos posibilidad*** de ganarle a los de tipo: ***Agua, Roca, Tierra***";
                mensaje += $"\nConsidere que el tipo de su rival es {oponente.Tipo}";
                return mensaje;
            }
            else if (propio[i].Tipo.Equals("Hielo"))
            {
                mensaje += "\nTiene ***mas posibilidades*** de ganarle a los de tipo: ***Hielo***";
                mensaje += "\nY tiene ***menos posibilidad*** de ganarle a los de tipo: ***Fuego, Lucha, Roca***";
                mensaje += $"\nConsidere que el tipo de su rival es {oponente.Tipo}";
                return mensaje;

            }
            else if (propio[i].Tipo.Equals("Lucha"))
            {
                mensaje +=
                    "\nY tiene ***menos posibilidad*** de ganarle a los de tipo: ***Psiquico, Volador, Bicho, Roca***";
                mensaje += $"\nConsidere que el tipo de su rival es {oponente.Tipo}";
                return mensaje;
            }
            else if (propio[i].Tipo.Equals("Normal"))
            {
                mensaje += "\nTiene ***NULAS posibilidades*** de ganarle a los de tipo: ***Fantasma***";
                mensaje += "\nY tiene ***menos posibilidad*** de ganarle a los de tipo: ***Lucha***";
                mensaje += $"\nConsidere que el tipo de su rival es {oponente.Tipo}";
                return mensaje;
            }
            else if (propio[i].Tipo.Equals("Hierba"))
            {
                mensaje +=
                    "\nTiene ***mas posibilidades*** de ganarle a los de tipo: ***Agua, Electrico, Hierba, Tierra***";
                mensaje +=
                    "\nY tiene ***menos posibilidad*** de ganarle a los de tipo: ***Bicho, Fuego, Hielo, Veneno, Volador***";
                mensaje += $"\nConsidere que el tipo de su rival es {oponente.Tipo}";
                return mensaje;

            }
            else if (propio[i].Tipo.Equals("Psiquico"))
            {
                mensaje += "\nY tiene ***menos posibilidad*** de ganarle a los de tipo: ***Bicho, Lucha, Fantasma***";
                mensaje += $"\nConsidere que el tipo de su rival es {oponente.Tipo}";
                return mensaje;
            }
            else if (propio[i].Tipo.Equals("Roca"))
            {
                mensaje +=
                    "\nTiene ***mas posibilidades*** de ganarle a los de tipo: ***Fuego, Normal, Veneno, Volador***";
                mensaje +=
                    "\nY tiene ***menos posibilidad*** de ganarle a los de tipo: ***Agua, Lucha, Hierba, Tierra***";
                mensaje += $"\nConsidere que el tipo de su rival es {oponente.Tipo}";
                return mensaje;
            }
            else if (propio[i].Tipo.Equals("Tierra"))
            {
                mensaje += "\nTiene ***mas posibilidades*** de ganarle a los de tipo: ***Electrico***";
                mensaje +=
                    "\nY tiene ***menos posibilidad*** de ganarle a los de tipo: ***Agua, Hielo, Hierba, Roca, Veneno***";
                mensaje += $"\nConsidere que el tipo de su rival es {oponente.Tipo}";
                return mensaje;
            }
            else if (propio[i].Tipo.Equals("Veneno"))
            {
                mensaje += "\nTiene ***mas posibilidades*** de ganarle a los de tipo: ***Hierba, Veneno***";
                mensaje +=
                    "\nY tiene ***menos posibilidad*** de ganarle a los de tipo: ***Bicho, Psiquico, Tierra, Lucha, Hierba***";
                mensaje += $"\nConsidere que el tipo de su rival es {oponente.Tipo}";
                return mensaje;
            }
            else if (propio[i].Tipo.Equals("Volador"))
            {
                mensaje +=
                    "\nTiene ***mas posibilidades*** de ganarle a los de tipo: ***Bicho, Lucha, Hierba, Tierra***";
                mensaje += "\nY tiene ***menos posibilidad*** de ganarle a los de tipo: ***Electrico, Hielo, Roca***";
                mensaje += $"\nConsidere que el tipo de su rival es {oponente.Tipo}";
                return mensaje;
            }
            return "Error en el tipo de su pokemon!";
        }
        return "Error en el tipo de su pokemon!";
    }
}