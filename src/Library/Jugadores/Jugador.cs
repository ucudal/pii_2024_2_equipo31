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
            new Pokemon("Crocalor", 81, 78, "Fuego", new List<Ataque>
            {
                new Ataque("Explosion de Fuego", 110),
                new Ataque("Colmillo de Fuego", 65),
                new Ataque("Carga de Fuego", 50),
                new Ataque("Lanzallamas", 90)
            }),
            new Pokemon("Cacnea", 50, 40, "Hierba", new List<Ataque>
            {
                new Ataque("Bola de Energia", 90),
                new Ataque("Drenaje", 75),
                new Ataque("Nudo de Hierba", 45),
                new Ataque("Tormenta de Hojas", 130)
            }),
            new Pokemon("Dewott", 75, 60, "Agua", new List<Ataque>
            {
                new Ataque("Cuchilla de Agua", 70),
                new Ataque("Chorro de Agua", 40),
                new Ataque("Marea Alta", 90),
                new Ataque("Agua Helada", 50)
            }),
            new Pokemon("Gagnar", 60, 60, "Fantasma", new List<Ataque>
            {
                new Ataque("Maldicion", 20),
                new Ataque("Vinculo de Destino", 65),
                new Ataque("Mal de Ojo", 65),
                new Ataque("Sombra Nocturna", 40)
            }),
            new Pokemon("Mareep", 55, 40, "Electrico", new List<Ataque>
            {
                new Ataque("Descarga", 80),
                new Ataque("Trueno", 75),
                new Ataque("Rayo", 90),
                new Ataque("Choque Relampago", 110)
            }),
        };
        Console.WriteLine($"\n 🗿 Su jugador se llama {this.Name}\n");
    }

    public Pokemon Seleccionar_Pokemons()
    {
        List<string> actuales = new List<string>();
        
        Console.WriteLine($" ◽ {this.Name}\n 🐗 Estos son sus Pokémons actuales:");
        
        foreach (Pokemon bicho in ListPokemons)
        {
            if (!bicho.EnCombate)
            {
                actuales.Add(bicho.Name);
                Console.WriteLine($" ✪ {bicho.Name}");
            }
        }

        if (actuales.Count == 0)
        {
            Console.WriteLine($" ❌ {this.Name}\nNo tienes mas pokemons disponibles para luchar");
            return null;
        }
        
        Console.WriteLine($"\n ⏳ {this.Name}\n Escriba a quien quiere usar: ");
        string seleccionado = Console.ReadLine();
        
        Pokemon encontrado = ListPokemons.Find(p => p.Name == seleccionado);
        
        if (encontrado != null)
        {
            Console.WriteLine($"\n 🐵 {this.Name} saco a {seleccionado}\n");
            Console.WriteLine($" 🐵 {encontrado.Name} tiene {encontrado.Hp} puntos de vida, {encontrado.Defensa} puntos de defensa y es de tipo {encontrado.Tipo}\n");
            Console.WriteLine(" 💣 Ataques disponibles: ");
            foreach (Ataque ataq in encontrado.Ataques)
            {
                Console.WriteLine($"- {ataq.Name} = {ataq.Daño}");
            }
            Console.WriteLine("\n");
            return encontrado;
        }
        else
        {
            Console.WriteLine($" 🚫 {this.Name}\n Usted no tiene ese pokemon, seleccione otro.");
            return Seleccionar_Pokemons();
        }
    }

    public class Batalla
    {
        public static void IniciarBatalla(Jugador jugador1, Jugador jugador2)
        {
            Pokemon pokemon1 = jugador1.Seleccionar_Pokemons();
            Pokemon pokemon2 = jugador2.Seleccionar_Pokemons();
            
            Console.WriteLine(" 🎮 Quiere iniciar la batalla pokemon (Si/No): ");
            string opcion = Console.ReadLine();

            if (opcion == "Si")
            {
                while (pokemon1.Hp > 0 && pokemon2.Hp > 0)
                {
                    pokemon1.Luchar(pokemon2);
                    if (pokemon2.Hp <= 0)
                    {
                        Console.WriteLine($"\n 🌟 {pokemon2.Name} fue derrotado, {jugador1.Name} gana la batalla 🌟 ");
                        break;
                    }

                    pokemon2.Luchar(pokemon1);
                    if (pokemon1.Hp <= 0)
                    {
                        Console.WriteLine($"\n 🌟 {pokemon1.Name} fue derrotado {pokemon2.Name} gana la batalla 🌟 ");
                        break;
                    }
                }
                pokemon1.EnCombate = false;
                pokemon2.EnCombate = false;
            }
            else if (opcion == "No")
            {
                if (pokemon1 == null || pokemon2 == null)
                {
                    Console.WriteLine(" 🔎 No hay suficientes pokemons para luchar");
                    return;
                }
            }
            else
            {
                Console.WriteLine(" 🚫 No selecciono una opcion valida.");
                return;
            }
        }
    }
}