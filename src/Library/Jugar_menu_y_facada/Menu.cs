namespace Library;

public class Menu
{
    public bool Turno { get; set; }
    public bool Batalla { get; set; }

    public void Estado_Batalla()
    {
        if (Jugador.ListPokemons.Count > 0)
        {
            Console.WriteLine($"Al jugador le quedan {Jugador.ListPokemons.Count} pokemones.");
            Console.WriteLine("Cuando al jugador le queden cero pokemones la batalla finalizará");
        }
        else
        {
            Console.WriteLine("La batalla finalizó");
        }
    }

}
