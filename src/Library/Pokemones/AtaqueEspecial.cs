namespace Library;

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

		public bool PuedeUsarAtaque()	// SETEO EL ENFRIAMIENTO DEL ATAQUE ESPECIAL EN 0 TURNOS
		{
			return enfriamientoActual == 0;
		}

		public void ReducirEnfriamiento()	// SI TENGO UN ATAQUE CON TURNOS DE ENFRIAMIENTO LE REDUZCO LA CANTIDAD EN 1
		{
			if (enfriamientoActual > 0)
			{
			enfriamientoActual--;
			}
		}

		public string AsignarNuevoEstado()	// ASIGNO UN ESTADO RANDOM LUEGO DE USAR UN ATAQUE ESPECIAL
		{
			string NuevoEstado;
			Random random = new Random();

			string[] estados = { "Dormido", "Paralizado", "Envenenado", "Quemado" };

			NuevoEstado = estados[random.Next(estados.Length)];
			return NuevoEstado;
		}
		
		public void Ejecutar_Ataque(Pokemon oponente) // ATACO AL OPONENTE
		{
			if (!PuedeUsarAtaque())
			{
				Console.WriteLine($"{this.Name} esta en enfriamiento por {enfriamientoActual} turnos restantes");
				return;
			}
			else
			{
				Console.WriteLine($"\n 👊 {this.Name} le hizo {this.EfectividadTipos(oponente)} puntos de daño a {oponente.Name}");
				oponente.El_Pokemon_Recibio_Daño(this.EfectividadTipos(oponente));
				oponente.EstadoNegativo = AsignarNuevoEstado();
				Console.WriteLine($" 📊 A {oponente.Name} le quedan {oponente.Hp} puntos de vida, {oponente.Defensa} puntos de defensa.");
				if (oponente.EstadoNegativo != "Ninguno")
				{
					Console.WriteLine($" 📊 Luego de ese ataque {oponente.Name} tiene el estado 💢 {oponente.EstadoNegativo} 💢 ");
				}
				enfriamientoActual = EnfriamientoMax;
			}
		}
		
		public double EfectividadTipos(Pokemon oponente) // LISTA DE EFECTIVIDAD DE TIPOS, SEGUN EL ATAQUE Y EL POKEMON
	    {
	        if (this.TipoAtaque == "Agua")
	        {
	            if (oponente.Tipo == "Electrico" && oponente.Tipo == "Hierba")
	            {
	                return Daño *= 0.5;
	            }
	            else if (oponente.Tipo == "Agua" && oponente.Tipo == "Fuego" && oponente.Tipo == "Hielo")
	            {
	                return Daño *= 2;
	            }
	        }
	        else if (this.TipoAtaque == "Bicho")
	        {
	            if (oponente.Tipo == "Fuego" && oponente.Tipo == "Roca" && oponente.Tipo == "Volador" &&
	                oponente.Tipo == "Veneno")
	            {
	                return Daño *= 0.5;
	            }
	            else if (oponente.Tipo == "Lucha" && oponente.Tipo == "Hierba" && oponente.Tipo == "Tierra")
	            {
	                return Daño *= 2;
	            }
	        }
	        else if (this.TipoAtaque == "Dragón")
	        {
	            if (oponente.Tipo == "Dragón" && oponente.Tipo == "Hielo")
	            {
	                return Daño *= 0.5;
	            }
	            else if (oponente.Tipo == "Agua" && oponente.Tipo == "Electrico" && oponente.Tipo == "Fuego" && oponente.Tipo == "Hierba")
	            {
	                return Daño *= 2;
	            }
	        }
	        else if (this.TipoAtaque == "Electrico")
	        {
	            if (oponente.Tipo == "Tierra")
	            {
	                return Daño *= 0.5;
	            }
	            else if (oponente.Tipo == "Volador")
	            {
	                return Daño *= 2;
	            }
	            else if (oponente.Tipo == "Electrico")
	            {
		            return Daño = 0;
	            }
	        }
	        else if (this.TipoAtaque == "Fantasma")
	        {
	            if (oponente.Tipo == "Fantasma")
	            {
	                return Daño *= 0.5;
	            }
	            else if (oponente.Tipo == "Veneno" && oponente.Tipo == "Lucha" && oponente.Tipo == "Normal")
	            {
	                return Daño *= 2;
	            }
	        }
	        else if (this.TipoAtaque == "Fuego")
	        {
	            if (oponente.Tipo == "Agua" && oponente.Tipo == "Roca" && oponente.Tipo == "Tierra")
	            {
		            return Daño *= 0.5;
	            }
	            else if (oponente.Tipo == "Bicho" && oponente.Tipo == "Fuego" && oponente.Tipo == "Planta")
	            {
		            return Daño *= 2;
	            }
	        }
	        else if (this.TipoAtaque == "Hielo")
	        {
	            if (oponente.Tipo == "Fuego" && oponente.Tipo == "Lucha" && oponente.Tipo == "Roca")
	            {
		            return Daño *= 0.5;
	            }
	            else if (oponente.Tipo == "Hielo")
	            {
		            return Daño *= 2;
	            }
	        }
	        else if (this.TipoAtaque == "Lucha")
	        {
		        if (oponente.Tipo == "Psiquico" && oponente.Tipo == "Volador" && oponente.Tipo == "Bicho" && oponente.Tipo == "Roca")
		        {
			        return Daño *= 0.5;
		        }
	        }
	        else if (this.TipoAtaque == "Normal")
	        {
		        if (oponente.Tipo == "Lucha")
		        {
			        return Daño *= 0.5;
		        }
		        else if (oponente.Tipo == "Fantasma")
		        {
			        return 0;
		        }
	        }
	        else if (this.TipoAtaque == "Hierba")
	        {
		        if (oponente.Tipo == "Bicho" && oponente.Tipo == "Fuego" && oponente.Tipo == "Hielo" && oponente.Tipo == "Veneno" && oponente.Tipo == "Volador")
		        {
			        return Daño *= 0.5;
		        }
		        else if (oponente.Tipo == "Agua" && oponente.Tipo == "Electrico" && oponente.Tipo == "Planta" && oponente.Tipo == "Tierra")
		        {
			        return Daño *= 2;
		        }
	        }
	        else if (this.TipoAtaque == "Psiquico")
	        {
		        if (oponente.Tipo == "Bicho" && oponente.Tipo == "Lucha" && oponente.Tipo == "Fantasma")
		        {
			        return Daño *= 0.5;
		        }
	        }
	        else if (this.TipoAtaque == "Roca")
	        {
		        if (oponente.Tipo == "Agua" && oponente.Tipo == "Lucha" && oponente.Tipo == "Planta" && oponente.Tipo == "Tierra")
		        {
			        return Daño *= 0.5;
		        }
		        else if (oponente.Tipo == "Fuego" && oponente.Tipo == "Normal" && oponente.Tipo == "Veneno" && oponente.Tipo == "Volador")
		        {
			        return Daño *= 2;
		        }
	        }
	        else if (this.TipoAtaque == "Tierra")
	        {
		        if (oponente.Tipo == "Agua" && oponente.Tipo == "Hielo" && oponente.Tipo == "Planta" && oponente.Tipo == "Roca" && oponente.Tipo == "Veneno")
		        {
			        return Daño *= 0.5;
		        }
		        else if (oponente.Tipo == "Electrico")
		        {
			        return Daño *= 2;
		        }
	        }
	        else if (this.TipoAtaque == "Veneno")
	        {
		        if (oponente.Tipo == "Bicho" && oponente.Tipo == "Psiquico" && oponente.Tipo == "Tierra" && oponente.Tipo == "Lucha" && oponente.Tipo == "Planta")
		        {
			        return Daño *= 0.5;
		        }
		        else if (oponente.Tipo == "Planta" && oponente.Tipo == "Veneno")
		        {
			        return Daño *= 2;
		        }
	        }
	        else if (this.TipoAtaque == "Volador")
	        {
		        if (oponente.Tipo == "Electrico" && oponente.Tipo == "Hielo" && oponente.Tipo == "Roca")
		        {
			        return Daño *= 0.5;
		        }
		        else if (oponente.Tipo == "Bicho" && oponente.Tipo == "Lucha" && oponente.Tipo == "Planta" && oponente.Tipo == "Tierra")
		        {
			        return Daño *= 2;
		        }
	        }
	        return Daño;
	    }
	}