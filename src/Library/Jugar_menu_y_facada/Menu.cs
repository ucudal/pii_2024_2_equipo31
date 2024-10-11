namespace Library;

public class Menu
{
    public bool Turno { get; set; }
    public bool Batalla { get; set; }

    public void Estado_Batalla(Jugador jugador1)
    {
        if (jugador1.ListPokemons.Count > 0)
        {
            Console.WriteLine($"Al jugador le quedan {jugador1.ListPokemons.Count} pokemones.");
            Console.WriteLine("Cuando al jugador le queden cero pokemones la batalla finalizará");
        }
        else
        {
            Console.WriteLine("La batalla finalizó");
        }
    }

}
