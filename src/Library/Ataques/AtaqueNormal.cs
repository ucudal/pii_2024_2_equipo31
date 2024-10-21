namespace Library;

	public class AtaqueNormal : Ataque, IAtaque
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
			double dañoFinal = this.EfectividadTipos(this.Daño,this.TipoAtaque, oponente);
			Console.WriteLine($"\n 👊 {this.Name} le hizo {dañoFinal} puntos de daño a {oponente.Name}");
			oponente.El_Pokemon_Recibio_Daño(dañoFinal);
			Console.WriteLine($" 📊 A {oponente.Name} le quedan {oponente.Hp} puntos de vida, {oponente.Defensa} puntos de defensa.");
		}

	}