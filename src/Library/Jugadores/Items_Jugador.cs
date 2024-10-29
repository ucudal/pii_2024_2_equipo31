namespace Library;

/// <summary>
/// Clase que representa los ítems que un jugador puede poseer.
/// </summary>
public class Items_Jugador
{
    /// <summary>
    /// Nombre del ítem.
    /// </summary>
    public string Nombre { get; set; }

    /// <summary>
    /// Cantidad del ítem que posee el jugador.
    /// </summary>
    public int Cantidad { get; set; }

    /// <summary>
    /// Constructor de la clase <see cref="Items_Jugador"/>.
    /// </summary>
    /// <param name="nombre">Nombre del ítem.</param>
    /// <param name="cantidad">Cantidad inicial del ítem.</param>
    public Items_Jugador(string nombre, int cantidad)
    {
        this.Nombre = nombre;
        this.Cantidad = cantidad;
    }
}