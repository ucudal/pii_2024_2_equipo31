namespace Library;

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
	
		public void Ejecutar_Ataque(Pokemon oponente) // ATACO AL OPONENTE 
		{
			Console.WriteLine($"\n 👊 {this.Name} le hizo {this.EfectividadTipos(oponente)} puntos de daño a {oponente.Name}");
			oponente.El_Pokemon_Recibio_Daño(this.EfectividadTipos(oponente));
			Console.WriteLine($" 📊 A {oponente.Name} le quedan {oponente.Hp} puntos de vida, {oponente.Defensa} puntos de defensa.");
		}
		public double EfectividadTipos(Pokemon oponente) // LISTA DE EFECTIVIDAD DE TIPOS SEGUN EL ATAQUE Y EL POKEMON
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