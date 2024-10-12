using System;
using System.Collections.Generic;

namespace Library;

public class Jugador
{
    public string Name { get; set; }
    public List<Pokemon> ListPokemons { get; set; }
    private List<Pokemon> pokemonsDisponibles;

    public Jugador(string nombre)
    {
        this.Name = nombre;
        ListPokemons = new List<Pokemon>();
        InicializarPokemonsDisponibles();
    }
	
    private void InicializarPokemonsDisponibles()
    {
        pokemonsDisponibles = new List<Pokemon>
        {
            new Pokemon("Crocalor", 81, 78, "Fuego", new List<IAtaque>
            {
                new AtaqueNormal("Explosion de Fuego", 110),
                new AtaqueNormal("Colmillo de Fuego", 65),
                new AtaqueNormal("Carga de Fuego", 50),
                new AtaqueEspecial(" ⚠ Lanzallamas", 90, 2)
            }),

            new Pokemon("Cacnea", 50, 40, "Hierba", new List<IAtaque>
            {
                new AtaqueNormal("Bola de Energia", 90),
                new AtaqueNormal("Drenaje", 75),
                new AtaqueNormal("Nudo de Hierba", 45),
                new AtaqueEspecial(" ⚠ Tormenta de Hojas", 130, 2)
            }),

            new Pokemon("Dewott", 75, 60, "Agua", new List<IAtaque>
            {
                new AtaqueNormal("Cuchilla de Agua", 70),
                new AtaqueNormal("Chorro de Agua", 40),
                new AtaqueNormal("Marea Alta", 90),
                new AtaqueEspecial(" ⚠ Agua Helada", 50, 2)
            }),
            new Pokemon("Gagnar", 60, 60, "Fantasma", new List<IAtaque>
            {
                new AtaqueNormal("Maldicion", 20),
                new AtaqueNormal("Vinculo de Destino", 65),
                new AtaqueNormal("Mal de Ojo", 65),
                new AtaqueEspecial(" ⚠ Sombra Nocturna", 40, 2)
            }),
            new Pokemon("Mareep", 55, 40, "Electrico", new List<IAtaque>
            {
                new AtaqueNormal("Descarga", 80),
                new AtaqueNormal("Trueno", 75),
                new AtaqueNormal("Rayo", 90),
                new AtaqueEspecial(" ⚠ Choque Relampago", 110, 2)
            }),
            new Pokemon("NosePass", 30, 135, "Roca", new List<IAtaque>
            {
                new AtaqueNormal("Cabezazo", 150),
                new AtaqueNormal("Rayo de Meteorito", 120),
                new AtaqueNormal("Gema de poder", 80),
                new AtaqueEspecial(" ⚠ Explosion de Roca", 25, 2)
            }),
            new Pokemon("Crocalor 2", 81, 78, "Fuego", new List<IAtaque>
            {
                new AtaqueNormal("Explosion de Fuego", 110),
                new AtaqueNormal("Colmillo de Fuego", 65),
                new AtaqueNormal("Carga de Fuego", 50),
                new AtaqueEspecial(" ⚠ Lanzallamas", 90, 2)
            }),

            new Pokemon("Cacnea 2", 50, 40, "Hierba", new List<IAtaque>
            {
                new AtaqueNormal("Bola de Energia", 90),
                new AtaqueNormal("Drenaje", 75),
                new AtaqueNormal("Nudo de Hierba", 45),
                new AtaqueEspecial(" ⚠ Tormenta de Hojas", 130, 2)
            }),

            new Pokemon("Dewott 2", 75, 60, "Agua", new List<IAtaque>
            {
                new AtaqueNormal("Cuchilla de Agua", 70),
                new AtaqueNormal("Chorro de Agua", 40),
                new AtaqueNormal("Marea Alta", 90),
                new AtaqueEspecial(" ⚠ Agua Helada", 50, 2)
            }),
            new Pokemon("Gagnar 2", 60, 60, "Fantasma", new List<IAtaque>
            {
                new AtaqueNormal("Maldicion", 20),
                new AtaqueNormal("Vinculo de Destino", 65),
                new AtaqueNormal("Mal de Ojo", 65),
                new AtaqueEspecial(" ⚠ Sombra Nocturna", 40, 2)
            }),
            new Pokemon("Mareep 2", 55, 40, "Electrico", new List<IAtaque>
            {
                new AtaqueNormal("Descarga", 80),
                new AtaqueNormal("Trueno", 75),
                new AtaqueNormal("Rayo", 90),
                new AtaqueEspecial(" ⚠ Choque Relampago", 110, 2)
            }),
            new Pokemon("NosePass 2", 30, 135, "Roca", new List<IAtaque>
            {
                new AtaqueNormal("Cabezazo", 150),
                new AtaqueNormal("Rayo de Meteorito", 120),
                new AtaqueNormal("Gema de poder", 80),
                new AtaqueEspecial(" ⚠ Explosion de Roca", 25, 2)
            }),
        };

    }

    public void SeleccionarPokemons()
    {
        while (ListPokemons.Count < 6)
        {
            Console.WriteLine($" ◽ {this.Name}, añade un Pokémon (actualmente tienes {ListPokemons.Count}/6):");
            MostrarPokemonsDisponibles();

            string seleccionado = Console.ReadLine();
            Pokemon encontrado = pokemonsDisponibles.Find(p => p.Name == seleccionado);

            if (encontrado != null && !ListPokemons.Contains(encontrado))
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

    public Pokemon Seleccionar_Pokemons()
    {
        Console.WriteLine($" ◽ {this.Name}\n ⏳ selecciona el Pokemon para luchar: ");
		foreach (Pokemon bicho in ListPokemons)
        {
            if (!bicho.EnCombate && bicho.Hp > 0)
            {
                Console.WriteLine($" ✪ {bicho.Name}, (Vida: {bicho.Hp}, Defensa: {bicho.Defensa})");
            }
        }

        string seleccionado = Console.ReadLine();
        Pokemon encontrado = ListPokemons.Find(p => p.Name == seleccionado);

        if (encontrado != null && encontrado.Hp > 0)
        {
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
        else
        {
            Console.WriteLine($" 🚫 {this.Name}\n Usted no tiene ese pokemon, seleccione otro.");
            return Seleccionar_Pokemons();
        }
     
    }

    private void MostrarPokemonsDisponibles()
    {
        Console.WriteLine("\nPokemons disponibles: ");
        foreach (var pokemon in pokemonsDisponibles)
        {
            Console.WriteLine($" ✪ {pokemon.Name} (Vida: {pokemon.Hp}, Defensa: {pokemon.Defensa}, Tipo: {pokemon.Tipo})");
        }
    }


    public void TomarDecision(Pokemon propio, Pokemon oponente)
    {
        Console.WriteLine($"\n{this.Name}, elige una accion: \n1. Atacar\n2. Usar Mochila\n3. Cambiar Pokemon");
        string opcion = Console.ReadLine();

        switch (opcion)
        {
            case "1":
                Console.WriteLine($"{this.Name} decidio atacar");
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
            case "2":
                Console.WriteLine($"Estos son sus objetos:\n- 🍄 pocion-\n- 💉 antidoto-\n- 💗 revivir-\n");
                Console.WriteLine("Escribe el nombre del objeto que desea usar: ");
                string objeto = Console.ReadLine();
                propio.Mochila(objeto);
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
    }
    public bool TienePokemonsDisponibles()
    {
        return ListPokemons.Any(p => p.Hp > 0);
    }

}
