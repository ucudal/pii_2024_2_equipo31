namespace Library;

public class Pokemon
{
    public string Name { get; set; }
    public int Hp { get; set; }
    public int Defensa { get; set; }
    public string Tipo { get; set; }
    public bool EnCombate { get; set; }

    public Pokemon(string nombre, int vida, int def, string tipo)
    {
        this.Name = nombre;
        this.Hp = vida;
        this.Defensa = def;
        this.Tipo = tipo;
        this.EnCombate = false;
    }

    public void Luchar(Pokemon oponente)
    {
        if (this.Hp <= 0)
        {
            Console.WriteLine($"{this.Name} no puede luchar, ya que no tiene puntos de vida.");
            return;
        }
        
        this.EnCombate = true;

        Console.WriteLine($"{this.Name} ataco a {oponente.Name}");

        int daño = Math.Max(0, 10 - oponente.Defensa);
        oponente.Hp -= daño;

        Console.WriteLine($"{oponente.Name} recibe {daño} de daño. Le quedan {oponente.Hp} de vida.");

        if (oponente.Hp <= 0)
        {
            oponente.Hp = 0;
            Console.WriteLine($"{oponente.Name} fue derrotado");
            oponente.EnCombate = false;
        }

        if (this.Hp > 100)
        {
            this.Hp = 100;
        }
    }

    public void Mochila(string objeto)
    {
        switch (objeto.ToLower())
        {
            case "pocion":
                Console.WriteLine($"{this.Name} uso pocion y recupero 20 puntos de vida");
                this.Hp += 20;
                break;
            case "antidoto":
                Console.WriteLine($"{this.Name} uso antidoto");
                break;
            case "revivir":
                if (this.Hp <= 0)
                {
                    Console.WriteLine($"{this.Name} fue revivido y tiene 50 puntos de vida");
                    this.Hp = 50;
                }
                else
                {
                    Console.WriteLine("Solo puedes revivir a un pokemon que no tiene puntos de vida");
                }

                break;
            default:
                Console.WriteLine($"El objeto {objeto} no esta disponible en la mochila");
                break;
        }

        if (this.Hp > 100)
        {
            this.Hp = 100;
        }
    }       
}