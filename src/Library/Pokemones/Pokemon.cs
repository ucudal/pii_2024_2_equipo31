using System;
using System.Collections.Generic;

namespace Library;

public class Pokemon
{
    public string Name { get; private set; }
    public int Id { get; set; }
    public double HpInicial {get; private set; }
    public double Hp { get; set; }
    public double Defensa { get; private set; }
    public string Tipo { get; private set; }
    public bool EnCombate { get; set; }
    public string EstadoNegativo { get; set; }
	public List<IAtaque> Ataques {get; private set; }

    public Pokemon(int id, string nombre, int vida, double def, string tipo, List<IAtaque> ataques)
    {
        this.Name = nombre;
        this.Id = id;
        this.HpInicial = vida;
        this.Hp = this.HpInicial;
        this.Defensa = def;
        this.Tipo = tipo;
        this.EnCombate = false;
		this.Ataques = ataques;
		this.EstadoNegativo = "Ninguno";
    }
	
	public bool EstaDerrotado()
	{
		return this.Hp <= 0;
	}
	
	public void RecibirDaño(double daño)
	{
		double dañoFinal = Math.Max(0, daño - this.Defensa);
		this.Hp -= dañoFinal;
		if (dañoFinal > 0)
		{
			this.Defensa = 0;
		}
		else
		{
			this.Defensa -= daño;
		}
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
		
		double dañoFinal = ataqueUsado.Daño - oponente.Defensa;
		oponente.RecibirDaño(dañoFinal);

        Console.WriteLine($" 💥 {oponente.Name} recibe {dañoFinal} de daño. Le quedan {oponente.Hp} de vida.");

        if (oponente.EstaDerrotado())
        {
            Console.WriteLine($"{oponente.Name} fue derrotado");
        }
    }
    
}