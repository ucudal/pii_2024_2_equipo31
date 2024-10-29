namespace Library;


/// <summary>
/// Representa un ataque especial en el sistema, hereda de la clase Ataque.
/// </summary>
public class AtaqueEspecial : Ataque, IAtaque
{
    /// <summary>
    /// Obtiene el nombre del ataque especial.
    /// </summary>
    public string Name { get; private set; }


    /// <summary>
    /// Obtiene o establece el daño del ataque especial.
    /// </summary>
    public double Daño { get; internal set; }

    /// <summary>
    /// Obtiene el tipo de ataque especial.
    /// </summary>
    public string TipoAtaque { get; private set; }

    /// <summary>
    /// Obtiene el enfriamiento máximo del ataque especial.
    /// </summary>
    public int EnfriamientoMax { get; private set; }

    /// <summary>
    /// Obtiene el enfriamiento actual del ataque especial.
    /// </summary>
    private int enfriamientoActual;
    
    /// <summary>
    /// Propiedad que representa el enfriamiento actual.
    /// </summary>
    public int EnfriamientoActual => enfriamientoActual;

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="AtaqueEspecial"/>.
    /// </summary>
    /// <param name="nombre">El nombre del ataque especial.</param>
    /// <param name="daño">El daño que inflige el ataque especial.</param>
    /// <param name="enfriamiento">El enfriamiento máximo del ataque especial.</param>
    /// <param name="tipoAtaqueEsp">El tipo del ataque especial.</param>
    public AtaqueEspecial(string nombre, double daño, int enfriamiento, string tipoAtaqueEsp)
    {
        this.Name = nombre;
        this.Daño = daño;
        this.EnfriamientoMax = enfriamiento;
        this.enfriamientoActual = 0;
        this.TipoAtaque = tipoAtaqueEsp;
    }

    /// <summary>
    /// Verifica si se puede usar el ataque especial.
    /// </summary>
    /// <returns>Devuelve true si el ataque especial está listo para ser usado, de lo contrario false.</returns>
    public bool PuedeUsarAtaque() // SETEO EL ENFRIAMIENTO DEL ATAQUE ESPECIAL EN 0 TURNOS
    {
        return enfriamientoActual == 0;
    }

    /// <summary>
    /// Reduce el enfriamiento actual del ataque especial en 1.
    /// </summary>
    public void ReducirEnfriamiento() // SI TENGO UN ATAQUE CON TURNOS DE ENFRIAMIENTO LE REDUZCO LA CANTIDAD EN 1
    {
        if (enfriamientoActual > 0)
        {
            enfriamientoActual--;
        }
    }

    /// <summary>
    /// Asigna un estado aleatorio al oponente después de usar un ataque especial.
    /// </summary>
    /// <returns>El nuevo estado asignado al oponente.</returns>
    public string AsignarNuevoEstado() // ASIGNO UN ESTADO RANDOM LUEGO DE USAR UN ATAQUE ESPECIAL
    {
        string NuevoEstado;
        Random random = new Random();

        string[] estados = { "Dormido", "Paralizado", "Envenenado", "Quemado" };

        NuevoEstado = estados[random.Next(estados.Length)];
        return NuevoEstado;
    }
    
    /// <summary>
    /// Ejecuta el ataque especial sobre un Pokémon oponente.
    /// </summary>
    /// <param name="oponente">El Pokémon que será atacado.</param>
    public void Ejecutar_Ataque(Pokemon oponente) // ATACO AL OPONENTE
    {
        if (!PuedeUsarAtaque())
        {
            Console.WriteLine($"{this.Name} está en enfriamiento por {enfriamientoActual} turnos restantes ⌛ ");
            return;
        }
        else
        {
            double dañoFinal = this.EfectividadTipos(this.Daño, this.TipoAtaque, oponente);
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
