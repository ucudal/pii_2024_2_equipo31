namespace Library;

public class AtaqueEspecial : Ataque
{
    public int EnfriamientoMax { get; set; }
    public int EnfriamientoActual { get; set; }

    public AtaqueEspecial(string name, int daño, int enfriamiento) : base(name, daño)
    {
        this.EnfriamientoMax = enfriamiento;
        this.EnfriamientoActual = 0;
    }

    public bool PuedeUsarAtaque()
    {
        return EnfriamientoActual == 0;
    }

    public void UsarAtaque()
    {
        if (PuedeUsarAtaque())
        {
            EnfriamientoActual = EnfriamientoMax;
        }
    }

    public void ReducirEnfriamiento()
    {
        if (EnfriamientoActual > 0)
        {
            EnfriamientoActual--;
        }
    }
}