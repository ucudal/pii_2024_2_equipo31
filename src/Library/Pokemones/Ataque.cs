namespace Library;

public class Ataque
{
    public string Name { get; set; }
    public int Daño { get; set; }

    public Ataque(string nombre, int daño)
    {
        this.Name = nombre;
        this.Daño = daño;
    }
}