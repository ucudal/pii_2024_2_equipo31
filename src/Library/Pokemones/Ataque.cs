using System;
using System.Collections.Generic;

namespace Library;

	public interface IAtaque
	{
		string Name{get;}
		double Daño {get;}
		string TipoAtaque { get; }
		void Ejecutar (Pokemon oponente);
	}

	public class AtaqueNormal : IAtaque
	{
    	public string Name { get; private set; }
    	public double Daño { get; private set; }
	    public string TipoAtaque { get; private set; }

    	public AtaqueNormal(string nombre, double daño, string tipoAtaque)
    	{
        	this.Name = nombre;
        	this.Daño = daño;
	        this.TipoAtaque = tipoAtaque;
	    }
	
		public void Ejecutar(Pokemon oponente)
		{
			Console.WriteLine($"\n 👊 {this.Name} le hizo {this.EfectividadTipos(oponente)} puntos de daño a {oponente.Name}");
			oponente.RecibirDaño(this.EfectividadTipos(oponente));
			Console.WriteLine($" 📊 A {oponente.Name} le quedan {oponente.Hp} puntos de vida, {oponente.Defensa} puntos de defensa.");
		}
		public double EfectividadTipos(Pokemon oponente)
	    {
	        if (this.TipoAtaque == "Agua")
	        {
	            if (oponente.Tipo == "Electrico" || oponente.Tipo == "Hierba")
	            {
	                Daño *= 0.5;
	                return Daño;
	            }
	            else if (oponente.Tipo == "Agua" || oponente.Tipo == "Fuego" || oponente.Tipo == "Hielo")
	            {
	                Daño *= 2;
	                Console.WriteLine("Fue efectivo");
	                return Daño;
	            }
	        }
	        else if (this.TipoAtaque == "Bicho")
	        {
	            if (oponente.Tipo == "Fuego" || oponente.Tipo == "Roca" || oponente.Tipo == "Volador" ||
	                oponente.Tipo == "Veneno")
	            {
	                Daño *= 0.5;
	                return Daño;
	            }
	            else if (oponente.Tipo == "Lucha" || oponente.Tipo == "Hierba" || oponente.Tipo == "Tierra")
	            {
	                Daño *= 2;
	                return Daño;
	            }
	        }
	        else if (this.TipoAtaque == "Dragón")
	        {
	            if (oponente.Tipo == "Dragón" || oponente.Tipo == "Hielo")
	            {
	                Daño *= 0.5;
	                return Daño;
	            }
	            else if (oponente.Tipo == "Agua" || oponente.Tipo == "Electrico" || oponente.Tipo == "Fuego" || oponente.Tipo == "Hierba")
	            {
	                Daño *= 2;
	                return Daño;
	            }
	        }
	        else if (this.TipoAtaque == "Electrico")
	        {
	            if (oponente.Tipo == "Tierra")
	            {
	                Daño *= 0.5;
	                return Daño;
	            }
	            else if (oponente.Tipo == "Volador")
	            {
	                Daño *= 2;
	                return Daño;
	            }
	            else if (oponente.Tipo == "Electrico")
	            {
		            Daño = 0;
		            return Daño;
	            }
	        }
	        else if (this.TipoAtaque == "Fantasma")
	        {
	            if (oponente.Tipo == "Fantasma")
	            {
	                Daño *= 0.5;
	                return Daño;
	            }
	            else if (oponente.Tipo == "Veneno" || oponente.Tipo == "Lucha" || oponente.Tipo == "Normal")
	            {
	                Daño *= 2;
	                return Daño;
	            }
	        }
	        else if (this.TipoAtaque == "Fuego")
	        {
	            if (oponente.Tipo == "Agua" || oponente.Tipo == "Roca" || oponente.Tipo == "Tierra")
	            {
	                Daño *= 0.5;
	                return Daño;
	            }
	            else if (oponente.Tipo == "Bicho" || oponente.Tipo == "Fuego" || oponente.Tipo == "Planta")
	            {
	                Daño *= 2;
	                return Daño;
	            }
	        }
	        else if (this.TipoAtaque == "Hielo")
	        {
	            if (oponente.Tipo == "Fuego" || oponente.Tipo == "Lucha" || oponente.Tipo == "Roca")
	            {
	                Daño *= 0.5;
	                return Daño;
	            }
	            else if (oponente.Tipo == "Hielo")
	            {
	                Daño *= 2;
	                return Daño;
	            }
	        }
	        else if (this.TipoAtaque == "Lucha")
	        {
		        if (oponente.Tipo == "Psiquico" || oponente.Tipo == "Volador" || oponente.Tipo == "Bicho" || oponente.Tipo == "Roca")
		        {
			        Daño *= 0.5;
			        return Daño;
		        }
	        }
	        else if (this.TipoAtaque == "Normal")
	        {
		        if (oponente.Tipo == "Lucha")
		        {
			        Daño *= 0.5;
			        return Daño;
		        }
		        else if (oponente.Tipo == "Fantasma")
		        {
			        Daño = 0;
			        return Daño;
		        }
	        }
	        else if (this.TipoAtaque == "Hierba")
	        {
		        if (oponente.Tipo == "Bicho" || oponente.Tipo == "Fuego" || oponente.Tipo == "Hielo" || oponente.Tipo == "Veneno" || oponente.Tipo == "Volador")
		        {
			        Daño *= 0.5;
			        return Daño;
		        }
		        else if (oponente.Tipo == "Agua" || oponente.Tipo == "Electrico" || oponente.Tipo == "Planta" || oponente.Tipo == "Tierra")
		        {
			        Daño *= 2;
			        return Daño;
		        }
	        }
	        else if (this.TipoAtaque == "Psiquico")
	        {
		        if (oponente.Tipo == "Bicho" || oponente.Tipo == "Lucha" || oponente.Tipo == "Fantasma")
		        {
			        Daño *= 0.5;
			        return Daño;
		        }
	        }
	        else if (this.TipoAtaque == "Roca")
	        {
		        if (oponente.Tipo == "Agua" || oponente.Tipo == "Lucha" || oponente.Tipo == "Planta" || oponente.Tipo == "Tierra")
		        {
			        Daño *= 0.5;
			        return Daño;
		        }
		        else if (oponente.Tipo == "Fuego" || oponente.Tipo == "Normal" || oponente.Tipo == "Veneno" || oponente.Tipo == "Volador")
		        {
			        Daño *= 2;
			        return Daño;
		        }
	        }
	        else if (this.TipoAtaque == "Tierra")
	        {
		        if (oponente.Tipo == "Agua" || oponente.Tipo == "Hielo" || oponente.Tipo == "Planta" || oponente.Tipo == "Roca" || oponente.Tipo == "Veneno")
		        {
			        Daño *= 0.5;
			        return Daño;
		        }
		        else if (oponente.Tipo == "Electrico")
		        {
			        Daño *= 2;
			        return Daño;
		        }
	        }
	        else if (this.TipoAtaque == "Veneno")
	        {
		        if (oponente.Tipo == "Bicho" || oponente.Tipo == "Psiquico" || oponente.Tipo == "Tierra" || oponente.Tipo == "Lucha" || oponente.Tipo == "Planta")
		        {
			        Daño *= 0.5;
			        return Daño;
		        }
		        else if (oponente.Tipo == "Planta" || oponente.Tipo == "Veneno")
		        {
			        Daño *= 2;
			        return Daño;
		        }
	        }
	        else if (this.TipoAtaque == "Volador")
	        {
		        if (oponente.Tipo == "Electrico" || oponente.Tipo == "Hielo" || oponente.Tipo == "Roca")
		        {
			        Daño *= 0.5;
			        return Daño;
		        }
		        else if (oponente.Tipo == "Bicho" || oponente.Tipo == "Lucha" || oponente.Tipo == "Planta" || oponente.Tipo == "Tierra")
		        {
			        Daño *= 2;
			        return Daño;
		        }
	        }
	        return Daño;
	    }
	}

	public class AtaqueEspecial : IAtaque
	{
		public string Name {get; private set;}
		public double Daño {get; internal set;}
		public string TipoAtaque {get; private set;}
		public int EnfriamientoMax {get; private set;}
		private int enfriamientoActual;

		public AtaqueEspecial(string nombre, double daño, int enfriamiento, string tipoAtaqueEsp)
		{
			this.Name = nombre;
			this.Daño = daño;
			this.EnfriamientoMax = enfriamiento;
			this.enfriamientoActual = 0;
			this.TipoAtaque = tipoAtaqueEsp;
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

		public string AsignarNuevoEstado()
		{
			string NuevoEstado;
			Random random = new Random();

			string[] estados = { "Dormido", "Paralizado", "Envenenado", "Quemado" };

			NuevoEstado = estados[random.Next(estados.Length)];
			return NuevoEstado;
		}
		
		public void Ejecutar(Pokemon oponente)
		{
			if (!PuedeUsarAtaque())
			{
			Console.WriteLine($"{this.Name} esta en enfriamiento por {enfriamientoActual} turnos restantes");
			return;
			}
			Console.WriteLine($"\n 👊 {this.Name} le hizo {this.EfectividadTipos(oponente)} puntos de daño a {oponente.Name}");
			oponente.RecibirDaño(this.EfectividadTipos(oponente));
			oponente.EstadoNegativo = AsignarNuevoEstado();
			Console.WriteLine($" 📊 A {oponente.Name} le quedan {oponente.Hp} puntos de vida, {oponente.Defensa} puntos de defensa.");
			if (oponente.EstadoNegativo != "Ninguno")
			{
				Console.WriteLine($" 📊 Luego de ese ataque {oponente.Name} tiene el estado 💢 {oponente.EstadoNegativo} 💢 ");
			}
			enfriamientoActual = EnfriamientoMax;
		}
		
		public double EfectividadTipos(Pokemon oponente)
	    {
	        if (this.TipoAtaque == "Agua")
	        {
	            if (oponente.Tipo == "Electrico" && oponente.Tipo == "Hierba")
	            {
	                Daño *= 0.5;
	                return Daño;
	            }
	            else if (oponente.Tipo == "Agua" && oponente.Tipo == "Fuego" && oponente.Tipo == "Hielo")
	            {
	                Daño *= 2;
	                return Daño;
	            }
	        }
	        else if (this.TipoAtaque == "Bicho")
	        {
	            if (oponente.Tipo == "Fuego" && oponente.Tipo == "Roca" && oponente.Tipo == "Volador" &&
	                oponente.Tipo == "Veneno")
	            {
	                Daño *= 0.5;
	                return Daño;
	            }
	            else if (oponente.Tipo == "Lucha" && oponente.Tipo == "Hierba" && oponente.Tipo == "Tierra")
	            {
	                Daño *= 2;
	                return Daño;
	            }
	        }
	        else if (this.TipoAtaque == "Dragón")
	        {
	            if (oponente.Tipo == "Dragón" && oponente.Tipo == "Hielo")
	            {
	                Daño *= 0.5;
	                return Daño;
	            }
	            else if (oponente.Tipo == "Agua" && oponente.Tipo == "Electrico" && oponente.Tipo == "Fuego" && oponente.Tipo == "Hierba")
	            {
	                Daño *= 2;
	                return Daño;
	            }
	        }
	        else if (this.TipoAtaque == "Electrico")
	        {
	            if (oponente.Tipo == "Tierra")
	            {
	                Daño *= 0.5;
	                return Daño;
	            }
	            else if (oponente.Tipo == "Volador")
	            {
	                Daño *= 2;
	                return Daño;
	            }
	            else if (oponente.Tipo == "Electrico")
	            {
		            Daño = 0;
		            return Daño;
	            }
	        }
	        else if (this.TipoAtaque == "Fantasma")
	        {
	            if (oponente.Tipo == "Fantasma")
	            {
	                Daño *= 0.5;
	                return Daño;
	            }
	            else if (oponente.Tipo == "Veneno" && oponente.Tipo == "Lucha" && oponente.Tipo == "Normal")
	            {
	                Daño *= 2;
	                return Daño;
	            }
	        }
	        else if (this.TipoAtaque == "Fuego")
	        {
	            if (oponente.Tipo == "Agua" && oponente.Tipo == "Roca" && oponente.Tipo == "Tierra")
	            {
	                Daño *= 0.5;
	                return Daño;
	            }
	            else if (oponente.Tipo == "Bicho" && oponente.Tipo == "Fuego" && oponente.Tipo == "Planta")
	            {
	                Daño *= 2;
	                return Daño;
	            }
	        }
	        else if (this.TipoAtaque == "Hielo")
	        {
	            if (oponente.Tipo == "Fuego" && oponente.Tipo == "Lucha" && oponente.Tipo == "Roca")
	            {
	                Daño *= 0.5;
	                return Daño;
	            }
	            else if (oponente.Tipo == "Hielo")
	            {
	                Daño *= 2;
	                return Daño;
	            }
	        }
	        else if (this.TipoAtaque == "Lucha")
	        {
		        if (oponente.Tipo == "Psiquico" && oponente.Tipo == "Volador" && oponente.Tipo == "Bicho" && oponente.Tipo == "Roca")
		        {
			        Daño *= 0.5;
			        return Daño;
		        }
	        }
	        else if (this.TipoAtaque == "Normal")
	        {
		        if (oponente.Tipo == "Lucha")
		        {
			        Daño *= 0.5;
			        return Daño;
		        }
		        else if (oponente.Tipo == "Fantasma")
		        {
			        Daño = 0;
			        return Daño;
		        }
	        }
	        else if (this.TipoAtaque == "Hierba")
	        {
		        if (oponente.Tipo == "Bicho" && oponente.Tipo == "Fuego" && oponente.Tipo == "Hielo" && oponente.Tipo == "Veneno" && oponente.Tipo == "Volador")
		        {
			        Daño *= 0.5;
			        return Daño;
		        }
		        else if (oponente.Tipo == "Agua" && oponente.Tipo == "Electrico" && oponente.Tipo == "Planta" && oponente.Tipo == "Tierra")
		        {
			        Daño *= 2;
			        return Daño;
		        }
	        }
	        else if (this.TipoAtaque == "Psiquico")
	        {
		        if (oponente.Tipo == "Bicho" && oponente.Tipo == "Lucha" && oponente.Tipo == "Fantasma")
		        {
			        Daño *= 0.5;
			        return Daño;
		        }
	        }
	        else if (this.TipoAtaque == "Roca")
	        {
		        if (oponente.Tipo == "Agua" && oponente.Tipo == "Lucha" && oponente.Tipo == "Planta" && oponente.Tipo == "Tierra")
		        {
			        Daño *= 0.5;
			        return Daño;
		        }
		        else if (oponente.Tipo == "Fuego" && oponente.Tipo == "Normal" && oponente.Tipo == "Veneno" && oponente.Tipo == "Volador")
		        {
			        Daño *= 2;
			        return Daño;
		        }
	        }
	        else if (this.TipoAtaque == "Tierra")
	        {
		        if (oponente.Tipo == "Agua" && oponente.Tipo == "Hielo" && oponente.Tipo == "Planta" && oponente.Tipo == "Roca" && oponente.Tipo == "Veneno")
		        {
			        Daño *= 0.5;
			        return Daño;
		        }
		        else if (oponente.Tipo == "Electrico")
		        {
			        Daño *= 2;
			        return Daño;
		        }
	        }
	        else if (this.TipoAtaque == "Veneno")
	        {
		        if (oponente.Tipo == "Bicho" && oponente.Tipo == "Psiquico" && oponente.Tipo == "Tierra" && oponente.Tipo == "Lucha" && oponente.Tipo == "Planta")
		        {
			        Daño *= 0.5;
			        return Daño;
		        }
		        else if (oponente.Tipo == "Planta" && oponente.Tipo == "Veneno")
		        {
			        Daño *= 2;
			        return Daño;
		        }
	        }
	        else if (this.TipoAtaque == "Volador")
	        {
		        if (oponente.Tipo == "Electrico" && oponente.Tipo == "Hielo" && oponente.Tipo == "Roca")
		        {
			        Daño *= 0.5;
			        return Daño;
		        }
		        else if (oponente.Tipo == "Bicho" && oponente.Tipo == "Lucha" && oponente.Tipo == "Planta" && oponente.Tipo == "Tierra")
		        {
			        Daño *= 2;
			        return Daño;
		        }
	        }
	        return Daño;
	    }
	}


