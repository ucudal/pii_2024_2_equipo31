using System;
using System.Collections.Generic;

namespace Library;

public class Jugador
{
    public string Name { get; set; }
    public List<Pokemon> ListPokemons { get; set; }

    public Jugador(string nombre)
    {
        this.Name = nombre;
        ListPokemons = new List<Pokemon>
        {
            new Pokemon("Crocalor", 81, 78, "fuego", new List<Ataque>
            {
                new Ataque("Llamarada", 30),
                new Ataque("Ascuas", 15),
                new Ataque("Giro Fuego", 25),
                new Ataque("Latigo", 10)
            }),
            new Pokemon("juan", 20, 20, "fuego", new List<Ataque>
            {
                new Ataque("Llamarada", 30),
                new Ataque("Ascuas", 15),
                new Ataque("Giro Fuego", 25),
                new Ataque("Latigo", 10)
            }),
            new Pokemon("clara", 20, 20, "fuego", new List<Ataque>
            {
                new Ataque("Llamarada", 30),
                new Ataque("Ascuas", 15),
                new Ataque("Giro Fuego", 25),
                new Ataque("Latigo", 10)
            }),
            new Pokemon("armando", 20, 20, "fuego", new List<Ataque>
            {
                new Ataque("Llamarada", 30),
                new Ataque("Ascuas", 15),
                new Ataque("Giro Fuego", 25),
                new Ataque("Latigo", 10)
            }),
            new Pokemon("nati", 20, 20, "fuego", new List<Ataque>
            {
                new Ataque("Llamarada", 30),
                new Ataque("Ascuas", 15),
                new Ataque("Giro Fuego", 25),
                new Ataque("Latigo", 10)
            }),
        };
        Console.WriteLine($"\nSu jugador se llama {this.Name}\n");
    }

    public Pokemon Seleccionar_Pokemons()
    {
        List<string> actuales = new List<string>();
        
        Console.WriteLine($"Estos son sus Pokémons actuales:");
        
        foreach (Pokemon bicho in ListPokemons)
        {
            if (!bicho.EnCombate)
            {
                actuales.Add(bicho.Name);
                Console.WriteLine($"✪ {bicho.Name}");
            }
        }

        if (actuales.Count == 0)
        {
            Console.WriteLine("No tienes mas pokemons disponibles para luchar");
            return null;
        }
        
        Console.WriteLine($"\nEscriba a quien quiere usar: ");
        string seleccionado = Console.ReadLine();
        
        Pokemon encontrado = ListPokemons.Find(p => p.Name == seleccionado);
        
        if (encontrado != null)
        {
            Console.WriteLine($"\n{this.Name} saco a {seleccionado}\n");
            Console.WriteLine($"{encontrado.Name} tiene {encontrado.Hp} puntos de vida, {encontrado.Defensa} puntos de defensa y es de tipo {encontrado.Tipo}\n");
            Console.WriteLine("Ataques disponibles: ");
            foreach (Ataque ataq in encontrado.Ataques)
            {
                Console.WriteLine($"- {ataq.Name} = {ataq.Daño}");
            }
            Console.WriteLine("\n")
            return encontrado;
        }
        else
        {
            Console.WriteLine("Usted no tiene ese pokemon, seleccione otro.");
            return Seleccionar_Pokemons();
        }
    }

    public class Batalla
    {
        public static void IniciarBatalla(Jugador jugador1, Jugador jugador2)
        {
            Console.WriteLine("Se da inicio a la batalla pokemon\n");

            Pokemon pokemon1 = jugador1.Seleccionar_Pokemons();
            Pokemon pokemon2 = jugador2.Seleccionar_Pokemons();

            if (pokemon1 == null || pokemon2 == null)
            {
                Console.WriteLine("No hay suficientes pokemons para luchar");
                return;
            }
            
            while (pokemon1.Hp > 0 && pokemon2.Hp > 0)
            {
                pokemon1.Luchar(pokemon2);
                if (pokemon2.Hp <= 0)
                {
                    Console.WriteLine($"{pokemon2.Name} fue derrotado, {jugador1.Name} gana la batalla");
                    break;
                }

                pokemon2.Luchar(pokemon1);
                if (pokemon1.Hp <= 0)
                {
                    Console.WriteLine($"{pokemon1.Name} fue derrotado {pokemon2.Name} gana la batalla");
                    break;
                }
            }
            pokemon1.EnCombate = false;
            pokemon2.EnCombate = false;
        }
    }
}