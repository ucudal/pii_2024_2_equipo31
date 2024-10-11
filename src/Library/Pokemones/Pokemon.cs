using System;
using System.Collections.Generic;

namespace Library;

public class Pokemon
{
    public string Name { get; set; }
    public int Hp { get; set; }
    public int Defensa { get; set; }
    public string Tipo { get; set; }
    public bool EnCombate { get; set; }
	public List<Ataque> Ataques {get; set; }

    public Pokemon(string nombre, int vida, int def, string tipo, List<Ataque> ataques)
    {
        this.Name = nombre;
        this.Hp = vida;
        this.Defensa = def;
        this.Tipo = tipo;
        this.EnCombate = false;
		this.Ataques = ataques;
    }
	
	public bool EstaDerrotado()
	{
		if (this.Hp <= 0)
		{
			Console.WriteLine($" 😵 {this.Name} fue derrotado");
			this.EnCombate = false;
			return true;
		}
		return false;
	}
        private static void ActualizarEnfriamientos(Jugador jugador)
        {
            foreach(var pokemon in jugador.ListPokemons)
            {
                foreach(var ataque in pokemon.Ataques.OfType<AtaqueEspecial>())
                {
                    ataque.ReducirEnfriamiento();
                }
            }
        }


    public void Luchar(Pokemon oponente)
    {
		if (this.EstaDerrotado())
		{
			Console.WriteLine($" 💀 {this.Name} ya fue derrotado");
			return;
		}

        this.EnCombate = true;
		
		Console.WriteLine($" 💪 Seleccione un ataque: ");
		for (int i = 0; i < this.Ataques.Count; i++)
		{
			Console.WriteLine($"{i+1} {this.Ataques[i].Name} ({this.Ataques[i].Daño} daño)");
		}

		int eleccion;
		while (!int.TryParse(Console.ReadLine(), out eleccion) || eleccion < 1 || eleccion > this.Ataques.Count)
		{
			Console.WriteLine("Opcion no valida, seleccione un numero de ataque correcto");
		}

		Ataque ataqueUsado = this.Ataques[eleccion - 1];
		
		if (ataqueUsado is AtaqueEspecial ataqueEspecial)
		{
			if (ataqueEspecial.PuedeUsarAtaque())
			{
				ataqueEspecial.UsarAtaque();
				Console.WriteLine($"{this.Name} uso el ataque especial {ataqueUsado.Name}");
			}
			else
			{
				Console.WriteLine($"{ataqueUsado.Name} esta en enfriamiento por {ataqueEspecial.EnfriamientoActual} turnos restantes");
				return;
			}
		}
		else
		{
			Console.WriteLine($" 👊 {this.Name} uso el ataque {ataqueUsado.Name} contra {oponente.Name}");	
		}

		int dañoFinal = Math.Max(0, ataqueUsado.Daño - oponente.Defensa);
		oponente.Hp -= dañoFinal;
		oponente.Hp = Math.Max(0, oponente.Hp);

        Console.WriteLine($" 💥 {oponente.Name} recibe {dañoFinal} de daño. Le quedan {oponente.Hp} de vida.");

        if (oponente.EstaDerrotado())
        {
            return;
        }
    }

    public void Mochila(string objeto)
    {
        switch (objeto.ToLower())
        {
            case "pocion":
                Console.WriteLine($" 💝 {this.Name} uso pocion y recupero 20 puntos de vida");
                this.Hp += 20;
                break;
            case "antidoto":
                Console.WriteLine($" 💉 {this.Name} uso antidoto");
                break;
            case "revivir":
                if (this.Hp <= 0)
                {
                    Console.WriteLine($" 😇 {this.Name} fue revivido y tiene 50 puntos de vida");
                    this.Hp = 50;
                }
                else
                {
                    Console.WriteLine(" 😅 Solo puedes revivir a un pokemon que no tiene puntos de vida");
                }

                break;
            default:
                Console.WriteLine($" 🚫 El objeto {objeto} no esta disponible en la mochila");
                break;
        }

        if (this.Hp > 100)
        {
            this.Hp = 100;
        }
    }       
}