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
	
	public bool El_Pokemon_Esta_Derrotado()
	{
		EnCombate = false;
		return this.Hp <= 0;
	}
	
	public void El_Pokemon_Recibio_Daño(double daño)
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
	
}