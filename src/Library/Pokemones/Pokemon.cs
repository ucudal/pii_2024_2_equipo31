using System;
using System.Collections.Generic;

namespace Library;

public class Pokemon
{
    public string Name { get; private set; }
    public int Hp { get; private set; }
    public int Defensa { get; private set; }
    public string Tipo { get; private set; }
    public bool EnCombate { get; set; }
	public List<IAtaque> Ataques {get; private set; }

    public Pokemon(string nombre, int vida, int def, string tipo, List<IAtaque> ataques)
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
		return this.Hp <= 0;
	}
	
	public void RecibirDaño(int daño)
	{
		int dañoFinal = Math.Max(0, daño - this.Defensa);
		this.Hp -= dañoFinal;
		this.Hp = Math.Max(0, this.Hp);
	}
		
	public void Curar (int cantidad)
	{
		this.Hp = Math.Min(100, this.Hp + cantidad);
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

		IAtaque ataqueUsado = this.Ataques[eleccion - 1];
		
		int dañoFinal = ataqueUsado.Daño - oponente.Defensa;
		oponente.RecibirDaño(dañoFinal);

        Console.WriteLine($" 💥 {oponente.Name} recibe {dañoFinal} de daño. Le quedan {oponente.Hp} de vida.");

        if (oponente.EstaDerrotado())
        {
            Console.WriteLine($"{oponente.Name} fue derrotado");
        }
    }

    public void Mochila(string objeto)
    {
    
    var objetosDisponibles = new Dictionary<string, Action>
    {
        { "pocion", () => { Console.WriteLine($" 💝 {this.Name} usó poción y recuperó 20 puntos de vida"); this.Hp = Math.Min(100, this.Hp + 20); } },
        { "antidoto", () => Console.WriteLine($" 💉 {this.Name} usó antídoto") },
        { "revivir", () => {
            if (this.Hp <= 0)
            {
                Console.WriteLine($" 😇 {this.Name} fue revivido y tiene 50 puntos de vida");
                this.Hp = 50;
            }
            else
            {
                Console.WriteLine(" 😅 Solo puedes revivir a un Pokémon que no tiene puntos de vida");
            }
        }}
    };

    if (objetosDisponibles.ContainsKey(objeto.ToLower()))
    {
        objetosDisponibles[objeto.ToLower()].Invoke();
    }
    else
    {
        Console.WriteLine($" 🚫 El objeto '{objeto}' no está disponible en la mochila.");
    }
    if (this.Hp > 100)
    {
     	this.Hp = 100;
    }       
}
}