using System;
using System.Collections.Generic;

namespace Library;

	public interface IAtaque
	{
		string Name{get;}
		int Daño {get;}
		void Ejecutar (Pokemon oponente);
	}

	public class AtaqueNormal : IAtaque
	{
    	public string Name { get; private set; }
    	public int Daño { get; private set; }

    	public AtaqueNormal(string nombre, int daño)
    	{
        	this.Name = nombre;
        	this.Daño = daño;
    	}
	
		public void Ejecutar(Pokemon oponente)
		{
			Console.WriteLine($" 👊 {this.Name} le hizo {this.Daño} a {oponente.Name}");
			oponente.RecibirDaño(this.Daño);
		}
	}

	public class AtaqueEspecial : IAtaque
	{
		public string Name {get; private set;}
		public int Daño {get; private set;}
		public int EnfriamientoMax {get; private set;}
		private int enfriamientoActual;

		public AtaqueEspecial(string nombre, int daño, int enfriamiento)
		{
			this.Name = nombre;
			this.Daño = daño;
			this.EnfriamientoMax = enfriamiento;
			this.enfriamientoActual = 0;
		}

		public bool PuedeUsarAtaque()
		{
			return enfriamientoActual == 0;
		}

		public void ReducirEnfriamiento()
		{
			if (enfriamientoActual > 0)
			{
			enfriamientoActual--;
			}
		}

		public void Ejecutar(Pokemon oponente)
		{
			if (!PuedeUsarAtaque())
			{
			Console.WriteLine($"{this.Name} esta en enfriamiento por {enfriamientoActual} turnos restantes");
			return;
			}
			Console.WriteLine($" 👊 {this.Name} le hizo {this.Daño} a {oponente.Name}");
			oponente.RecibirDaño(this.Daño);
			enfriamientoActual = EnfriamientoMax;
		}
	}

