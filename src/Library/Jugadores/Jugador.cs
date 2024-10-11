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
        ListPokemons = new List<Pokemon>();
        InicializarPokemons();
    }

    public void InicializarPokemons()
    {
        ListPokemons.Add(new Pokemon("Crocalor", 81, 78, "Fuego", new List<IAtaque>
        {
            new AtaqueNormal("Explosion de Fuego", 110),
            new AtaqueNormal("Colmillo de Fuego", 65),
            new AtaqueNormal("Carga de Fuego", 50),
            new AtaqueEspecial("Lanzallamas", 90,2)
        }));

        ListPokemons.Add(new Pokemon("Cacnea", 50, 40, "Hierba", new List<IAtaque>
        {
            new AtaqueNormal("Bola de Energia", 90),
            new AtaqueNormal("Drenaje", 75),
            new AtaqueNormal("Nudo de Hierba", 45),
            new AtaqueEspecial("Tormenta de Hojas", 130,2)
        }));

        ListPokemons.Add(new Pokemon("Dewott", 75, 60, "Agua", new List<IAtaque>
        {
            new AtaqueNormal("Cuchilla de Agua", 70),
            new AtaqueNormal("Chorro de Agua", 40),
            new AtaqueNormal("Marea Alta", 90),
            new AtaqueEspecial("Agua Helada", 50,2)
        }));
        ListPokemons.Add(new Pokemon("Gagnar", 60, 60, "Fantasma", new List<IAtaque>
        {
            new AtaqueNormal("Maldicion", 20),
            new AtaqueNormal("Vinculo de Destino", 65),
            new AtaqueNormal("Mal de Ojo", 65),
            new AtaqueEspecial("Sombra Nocturna", 40,2)
        }));
        ListPokemons.Add(new Pokemon("Mareep", 55, 40, "Electrico", new List<IAtaque>
        {
            new AtaqueNormal("Descarga", 80),
            new AtaqueNormal("Trueno", 75),
            new AtaqueNormal("Rayo", 90),
            new AtaqueEspecial("Choque Relampago", 110,2)
        }));
        ListPokemons.Add(new Pokemon("NosePass", 30, 135, "Roca", new List<IAtaque>
        { 
            new AtaqueNormal("Cabezazo", 150), 
            new AtaqueNormal("Rayo de Meteorito", 120), 
            new AtaqueNormal("Gema de poder", 80), 
            new AtaqueEspecial("Explosion de Roca", 25,2)
        }));
    }

    public List<Pokemon> SeleccionarPokemons()
    {
        List<Pokemon> seleccionados = new List<Pokemon>();

        while (seleccionados.Count < 6)
        {
            Console.WriteLine($" ◽ {this.Name}, añade un Pokémon (actualmente tienes {seleccionados.Count}/6 seleccionados):");
            MostrarPokemonsDisponibles();

            string seleccionado = Console.ReadLine();
            Pokemon encontrado = ListPokemons.Find(p => p.Name == seleccionado);

            if (encontrado != null && !seleccionados.Contains(encontrado))
            {
                seleccionados.Add(encontrado);
                Console.WriteLine($" 🐵 {this.Name} añadio a {encontrado.Name}");
            }
            else
            {
                Console.WriteLine(" 🚫 Seleccion invalida o Pokemon ya seleccionado.");
            }
        }

        return ListPokemons = seleccionados; 
    }
    

    public Pokemon Seleccionar_Pokemons()
    {
        List<string> actuales = new List<string>();
        Console.WriteLine($" ◽ {this.Name}\n 🐗 Estos son sus Pokémons actuales:");

        foreach (Pokemon bicho in ListPokemons)
        {
            if (!bicho.EnCombate && bicho.Hp > 0)
            {
                actuales.Add(bicho.Name);
                Console.WriteLine($" ✪ {bicho.Name}, (Vida: {bicho.Hp}, Defensa: {bicho.Defensa})");
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

    public void MostrarPokemonsDisponibles()
    {
        Console.WriteLine("Pokemons disponibles: ");
        foreach (var pokemon in ListPokemons)
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
