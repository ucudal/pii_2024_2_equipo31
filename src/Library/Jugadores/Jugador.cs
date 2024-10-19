using System;
using System.Collections;
using System.Collections.Generic;

namespace Library;

public class Jugador
{
    public string Name { get; set; }
    public List<Pokemon> ListPokemons { get; set; }
    private List<Pokemon> pokemonsDisponibles;
    private List<int> CantidadItems;

    public Jugador(string nombre)
    {
        this.Name = nombre;
        ListPokemons = new List<Pokemon>();
        CantidadItems = new List<int> { 4, 1, 2 };
        InicializarPokemonsDisponibles();
    }
	
    private void InicializarPokemonsDisponibles() // CREA UNA LISTA CON TODOS LOS POKEMONS DEL JUEGO A MODO DE BASE DE DATOS
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
    }
    
    private Pokemon SeleccionarPokemonPorID(List<Pokemon> listapokemons, bool debeEstarDisponibleParaCombate = false) // VERIFICA QUE EL USUARIO ESCRIBA UN ID VALIDO
    {
        Pokemon encontrado = null;
        
        while (encontrado == null || encontrado.Hp <= 0 || encontrado.EnCombate)
        {
            Console.WriteLine($"Escriba el ID del pokemon que desea seleccionar: ");
            if (!int.TryParse(Console.ReadLine(), out int seleccionado))
            {
                Console.WriteLine($"Debe ingresar un ID de pokemon valido \n(núm entero frente al pokemon)");
                continue;
            }
            
            encontrado = listapokemons.Find(p => p.Id == seleccionado);
            
            if (encontrado == null)
            {
                Console.WriteLine($"Pokemon no encontrado.");
            }
            else if (debeEstarDisponibleParaCombate && (encontrado.Hp <= 0 || encontrado.EnCombate))
            {
                Console.WriteLine("El pokemon seleccionado no se encuentra disponible para el combate");
                encontrado = null; 
            }
        }
        return encontrado;
    }
    public void SeleccionarPokemons() // HACE QUE CADA JUGADOR SELECCIONE A 6 POKEMONS EN SU LISTA
    {
        while (ListPokemons.Count < 6) 
        {
            Console.WriteLine($" ◽ {this.Name}, añade un Pokémon (actualmente tienes {ListPokemons.Count}/6):");
            MostrarPokemonsDisponibles();

            Pokemon encontrado = SeleccionarPokemonPorID(pokemonsDisponibles);
            if (!ListPokemons.Contains(encontrado))
            {
                ListPokemons.Add(encontrado);
				pokemonsDisponibles.Remove(encontrado);
                Console.WriteLine($" 🐵 {this.Name} añadio a {encontrado.Name}");
            }
            else
            {
                Console.WriteLine(" 🚫 Seleccion invalida o Pokemon ya seleccionado.");
            }
        }
    }

    public Pokemon Seleccionar_Pokemons() // EL JUGADOR SELECCIONA POKEMONS QUE ESTEN DISPONIBLES PARA LUCHAR
    {
        Console.WriteLine($" ◽ {this.Name}\n ⏳ selecciona un Pokemon para luchar: ");
		foreach (Pokemon bicho in ListPokemons)
        {
            if (!bicho.EnCombate && bicho.Hp > 0)
            {
                Console.WriteLine($" ✪ {bicho.Id} - {bicho.Name}, (Vida: {bicho.Hp}, Defensa: {bicho.Defensa}, Tipo: {bicho.Tipo})");
            }
        }

        Pokemon encontrado = SeleccionarPokemonPorID(ListPokemons, true);

        Console.WriteLine($"\n 🐵 {this.Name} saco a {encontrado.Name}\n");
        Console.WriteLine($" 🐵 {encontrado.Name} tiene {encontrado.Hp} puntos de vida, {encontrado.Defensa} puntos de defensa y es de tipo {encontrado.Tipo}\n");
        Console.WriteLine(" 💣 Ataques disponibles: ");
        
        foreach (IAtaque ataq in encontrado.Ataques)
        { 
            Console.WriteLine($" 🔹 {ataq.Name} = {ataq.Daño}");
        }
        Console.WriteLine("\n");
        return encontrado;
    }

    private void MostrarPokemonsDisponibles() // MUESTRO TODOS LOS POKEMONS DISPONIBLES DEL JUEGO
    {
        Console.WriteLine("\nPokemons disponibles: ");
        foreach (var pokemon in pokemonsDisponibles)
        {
            Console.WriteLine($" ✪ {pokemon.Id} - {pokemon.Name} (Vida: {pokemon.Hp}, Defensa: {pokemon.Defensa}, Tipo: {pokemon.Tipo})");
        }
    }
    
    public void TomarDecision(Pokemon propio, Pokemon oponente) // MENU DE OPCIONES DENTRO DE LA BATALLA
    {
        Console.WriteLine($"\n{this.Name}, elige una accion: \n1. Atacar\n2. Usar Mochila\n3. Cambiar Pokemon");
        string opcion = Console.ReadLine();
        Random random = new Random();

        switch (opcion)
        {
            case "1":
                Console.WriteLine($"{this.Name} decidio atacar");

                    if (propio.EstaDerrotado())
                    {
                        Console.WriteLine($"{propio.Name} no puede seguir luchando, debe cambiar o revivir al pokemon: ");
                        propio.EstadoNegativo = "Ninguno";
                        this.TomarDecision(propio, oponente);
                    }
                    else
                    {
                        if (propio.EstadoNegativo == "Dormido")
                        {
                            Console.WriteLine($"{propio.Name} no puede atacar en este turno porque esta {propio.EstadoNegativo}");
                            int TurnosAleatorios = random.Next(1, 5);
                            if (TurnosAleatorios == 1)
                            {
                                Console.WriteLine($"{propio.Name} ya dejo de estar {propio.EstadoNegativo}.");
                                propio.EstadoNegativo = "Ninguno";
                            }
                            break;
                        }
                        else if (propio.EstadoNegativo == "Paralizado")
                        {
                            Console.WriteLine($"{propio.Name} perdio este turno porque estaba {propio.EstadoNegativo}");
                            int TurnosAleatorios = random.Next(1, 3);
                            if (TurnosAleatorios == 1)
                            {
                                Console.WriteLine($"{propio.Name} ya dejo de estar {propio.EstadoNegativo}.");
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"\nSelecciona un ataque: ");
                            for (int i = 0; i < propio.Ataques.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. 🔹 {propio.Ataques[i].Name} = {propio.Ataques[i].Daño}");
                            }

                            int seleccion;
                            if (int.TryParse(Console.ReadLine(), out seleccion) && seleccion >= 1 && seleccion <= propio.Ataques.Count)
                            {
                                propio.Ataques[seleccion -1].Ejecutar(oponente);
                            }
                            else
                            {
                                Console.WriteLine("No selecciono un ataque valido");
                            }
                            break;
                        }
                        break;
                    }
                break;
            case "2":
                Console.WriteLine($"Selecciona un item: \n1. Pocion\n2. Antidoto\n3. Revivir\n");
                string objeto = Console.ReadLine();
                this.Mochila(objeto, propio);
                break;
            case "3":
                propio.EnCombate = false;
                Pokemon nuevoPokemon = Seleccionar_Pokemons();
                if (nuevoPokemon != null)
                {
                    Console.WriteLine($"{this.Name} cambio a {nuevoPokemon.Name} y pierde un turno");
                }
                return;
            default:
                Console.WriteLine("Opcion incorrecta.");
                break;
        }

        if (!propio.EstaDerrotado())
        {
            if (propio.EstadoNegativo == "Envenenado")
            {
                propio.Hp -= propio.HpInicial * 0.05;
                Console.WriteLine($"{propio.Name} se encuentra {propio.EstadoNegativo} debe use un antidoto");
                Console.WriteLine($"Debido a que {propio.Name} esta {propio.EstadoNegativo} en este turno perdio un 5% de su vida total\n {propio.Name} tiene ahora {propio.Hp}");
            }
            else if (propio.EstadoNegativo == "Quemado")
            {
                propio.Hp -= propio.HpInicial * 0.10;
                Console.WriteLine($"{propio.Name} se encuentra {propio.EstadoNegativo} debe use un antidoto");
                Console.WriteLine($"Debido a que {propio.Name} esta {propio.EstadoNegativo} en este turno perdio un 10% de su vida total\n {propio.Name} tiene ahora {propio.Hp}");
            }
        }
    }

    public bool TienePokemonsDisponibles() // VERIFICA SI EL JUGADOR TIENE POKEMONS CON VIDA EN SU LISTA
    {
        return ListPokemons.Any(p => p.Hp > 0);
    }

    public void Mochila(string objeto, Pokemon pokemonMoch) // MENU DE LA MOCHILA, MUESTRA LOS ELEMENTOS QUE EL JUGADOR PUEDE USAR
    {
        switch (objeto.ToLower())
        {
            case "1":
                if (CantidadItems[0] >= 1)
                {
                    pokemonMoch.Hp = pokemonMoch.Hp + 70;
                    Console.WriteLine($" 💝 {this.Name} usó una super poción en {pokemonMoch.Name} y tiene {pokemonMoch.Hp} puntos de vida");
                    CantidadItems[0] -= 1;
                    Console.WriteLine($"A {this.Name} le quedan {CantidadItems[0]} super pociones en su mochila.");
                    break;
                }
                else if (CantidadItems[0] == 0)
                {
                    Console.WriteLine($"{this.Name} no tiene mas pociones en su mochila");
                    break;
                }
                break;

            case "2":
                if(CantidadItems[2] >= 1 && pokemonMoch.EstadoNegativo != "Ninguno")
                {
                    Console.WriteLine($" 💉 {this.Name} usó una cura total y se recupero de todos los efectos negativos");
                    CantidadItems[2] -= 1;
                    pokemonMoch.EstadoNegativo = "Ninguno";
                    Console.WriteLine($"A {this.Name} le quedan {CantidadItems[2]} curas totales en su mochila.");
                    break;
                }
                else
                {
                    Console.WriteLine($"{pokemonMoch.Name} no tiene ningun estado negativo que ser revertido.");
                    Console.WriteLine($"A {this.Name} aun le quedan {CantidadItems[2]} curas totales");
                    break;
                }
                break;

            case "3":
                if (pokemonMoch.Hp <= 0 && CantidadItems[1] >= 1)
                {
                    pokemonMoch.Hp = pokemonMoch.HpInicial * 0.5;
                    Console.WriteLine($" 😇 {pokemonMoch.Name} fue revivido y ahora tiene {pokemonMoch.Hp} puntos de vida");
                    CantidadItems[1] -= 1;
                    Console.WriteLine($"A {this.Name} le quedan {CantidadItems[1]} revivir en su mochila.");
                    break;
                }
                else
                {
                    Console.WriteLine($"Tienes {CantidadItems[1]} item revivir.");
                    Console.WriteLine(" 😅 Si tienes algun item revivir, asegurate que tu Pokémon no tenga puntos de vida!");
                    Mochila(objeto, pokemonMoch);
                }
                break;

            default:
                Console.WriteLine($" 🚫 El objeto '{objeto}' no está disponible en la mochila.");
                break;
        }

        if (pokemonMoch.Hp > pokemonMoch.HpInicial)
        {
            pokemonMoch.Hp = pokemonMoch.HpInicial;
        }
    }
}