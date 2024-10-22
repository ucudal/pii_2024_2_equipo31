namespace Library;

	public class AtaqueEspecial : Ataque, IAtaque
	{
		public string Name {get; private set;}
		public double Daño {get; internal set;}
		public string TipoAtaque {get; private set;}
		public int EnfriamientoMax {get; private set;}
		private int enfriamientoActual;
		public int EnfriamientoActual => enfriamientoActual;

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
				Console.WriteLine($"{this.Name} esta en enfriamiento por {enfriamientoActual} turnos restantes ⌛ ");
				return;
			}
			else
			{
				double dañoFinal = this.EfectividadTipos(this.Daño,this.TipoAtaque, oponente);
				Console.WriteLine($"\n 👊 {this.Name} le hizo {dañoFinal} puntos de daño a {oponente.Name}");
				oponente.El_Pokemon_Recibio_Daño(dañoFinal);
				oponente.EstadoNegativo = AsignarNuevoEstado();
				Console.WriteLine($" 📊 A {oponente.Name} le quedan {oponente.Hp} puntos de vida, {oponente.Defensa} puntos de defensa.");
				if (oponente.EstadoNegativo != "Ninguno")
				{
					Console.WriteLine($" Luego de ese ataque {oponente.Name} tiene el estado 💢 {oponente.EstadoNegativo} 💢 ");
				}
				enfriamientoActual = EnfriamientoMax;
			}
		}
	}