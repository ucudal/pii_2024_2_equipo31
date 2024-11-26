namespace Library;

/// <summary>
/// Representa un ataque normal en el sistema, hereda de la clase Ataque.
/// </summary>
public class AtaqueNormal : Ataque, IAtaque
{
    /// <summary>
    /// Obtiene el nombre del ataque normal.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Obtiene el daño del ataque normal.
    /// </summary>
    public double Daño { get; private set; }

    /// <summary>
    /// Obtiene el tipo de ataque normal.
    /// </summary>
    public string TipoAtaque { get; private set; }

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="AtaqueNormal"/>.
    /// </summary>
    /// <param name="nombre">El nombre del ataque normal.</param>
    /// <param name="daño">El daño que inflige el ataque normal.</param>
    /// <param name="tipoAtaque">El tipo del ataque normal.</param>
    public AtaqueNormal(string nombre, double daño, string tipoAtaque)
    {
        this.Name = nombre;
        this.Daño = daño;
        this.TipoAtaque = tipoAtaque;
    }

    /// <summary>
    /// Ejecuta el ataque normal sobre un Pokémon oponente.
    /// </summary>
    /// <param name="oponente">El Pokémon que será atacado.</param>
    public string Ejecutar_Ataque(Pokemon oponente) // ATACO AL OPONENTE 
    {
        if (oponente != null)
        {
            string mensajeAtaqueNormal = "";
            double dañoFinal = this.EfectividadTipos(this.Daño, this.TipoAtaque, oponente);
            mensajeAtaqueNormal += $"\n 👊 {this.Name} le hizo {dañoFinal} puntos de daño a {oponente.Name}";
            oponente.El_Pokemon_Recibio_Daño(dañoFinal);
            mensajeAtaqueNormal += $" 📊 A {oponente.Name} le quedan {oponente.Hp} puntos de vida, {oponente.Defensa} puntos de defensa.";
            return mensajeAtaqueNormal;
        }
        return "\nEl pokemon oponente ya esta derrotado";
    }
}