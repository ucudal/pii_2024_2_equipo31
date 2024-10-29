namespace Library;

public class Items_Jugador
{
    public string Nombre { get; set; }
    public int Cantidad { get; set; }
    public Items_Jugador(string nombre, int cantidad)
    {
        this.Nombre = nombre;
        this.Cantidad = cantidad;
    }
}