using System;
using System.Collections.Generic;

namespace Library;

/// <summary>
/// Representa un Pokémon con atributos específicos como puntos de salud, defensa, tipo y una lista de ataques.
/// </summary>
public class Pokemon
{
    /// <summary>
    /// Obtiene el nombre del Pokémon.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Obtiene o establece el ID del Pokémon.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Obtiene los puntos de salud iniciales del Pokémon.
    /// </summary>
    public double HpInicial { get; private set; }

    /// <summary>
    /// Obtiene o establece los puntos de salud actuales del Pokémon.
    /// </summary>
    public double Hp { get; set; }

    /// <summary>
    /// Obtiene el valor de defensa del Pokémon.
    /// </summary>
    public double Defensa { get; private set; }

    /// <summary>
    /// Obtiene el tipo del Pokémon.
    /// </summary>
    public Pokemon Tipo { get; private set; }

    /// <summary>
    /// Obtiene o establece si el Pokémon está actualmente en combate.
    /// </summary>
    public bool EnCombate { get; set; }

    /// <summary>
    /// Obtiene o establece el efecto de estado negativo que afecta al Pokémon.
    /// </summary>
    public string EstadoNegativo { get; set; }

    /// <summary>
    /// Obtiene la lista de ataques disponibles para el Pokémon.
    /// </summary>
    public Pokemon Ataques { get; private set; }

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="Pokemon"/> con los atributos especificados.
    /// </summary>
    /// <param name="id">El identificador único del Pokémon.</param>
    /// <param name="nombre">El nombre del Pokémon.</param>
    /// <param name="vida">Los puntos de salud iniciales del Pokémon.</param>
    /// <param name="def">El valor de defensa del Pokémon.</param>
    /// <param name="tipo">El tipo del Pokémon (por ejemplo, fuego, agua).</param>
    /// <param name="ataques">La lista de ataques disponibles para el Pokémon.</param>
    public Pokemon(int id, string nombre, int vida, double def, string tipo, List<IAtaque> ataques)
    {
        this.Name = nombre;
        this.Id = id;
        this.HpInicial = vida;
        this.Hp = this.HpInicial;
        this.Defensa = def;
        this.Tipo = tipo;
        this.EnCombate = false;
        this.Ataques = ataques;
        this.EstadoNegativo = "Ninguno";
    }

    /// <summary>
    /// Verifica si el Pokémon ha sido derrotado (es decir, si los puntos de salud son cero o menos) y actualiza el estado de combate.
    /// </summary>
    /// <returns><c>true</c> si el Pokémon está derrotado; de lo contrario, <c>false</c>.</returns>
    public bool El_Pokemon_Esta_Derrotado()
    {
        if (this.Hp == 0)
        {
            this.EstadoNegativo = "Ninguno";
            EnCombate = false;
        }
        return this.Hp <= 0;
    }

    /// <summary>
    /// Reduce la salud y defensa del Pokémon en función del daño recibido.
    /// </summary>
    /// <param name="daño">La cantidad de daño recibida por el Pokémon.</param>
    public void El_Pokemon_Recibio_Daño(double daño)
    {
        if (this.Defensa > 0)
        {
            double dañoADefensa = (this.Defensa -= daño);
            this.Defensa -= dañoADefensa;
            daño -= dañoADefensa;
        }
        if (daño > 0)
        {
            this.Hp = Math.Max(0, this.Hp - daño);
        }
        if (this.Defensa <= 0)
        {
            this.Defensa = 0;
        }
    }
    
    /// <summary>
    /// Aplica los efectos de los estados negativos al Pokémon, si es que tiene alguno.
    /// </summary>
    /// <returns>
    /// Un mensaje que describe el estado actual del Pokémon, los efectos aplicados y las consecuencias.
    /// </returns>
    /// <remarks>
    /// Este método verifica si el Pokémon está derrotado antes de aplicar los estados. 
    /// Si el Pokémon está "Envenenado" o "Quemado", se calcula el daño correspondiente según el estado 
    /// y se reduce la cantidad de puntos de vida (`Hp`) del Pokémon. También genera un mensaje 
    /// con los detalles del estado y el daño recibido.
    /// </remarks>
    /// <example>
    /// Ejemplo de uso:
    /// <code>
    /// string resultado = pokemon.AplicarEstados();
    /// Console.WriteLine(resultado);
    /// </code>
    /// </example>
    /// <seealso cref="El_Pokemon_Esta_Derrotado"/>
    /// <seealso cref="EstadoNegativo"/>
    /// <seealso cref="Hp"/>
    public string AplicarEstados()
    {
        string mensaje = "";
        if (!El_Pokemon_Esta_Derrotado())
        {
            if (EstadoNegativo == "Envenenado")
            {
                double dañoVeneno = HpInicial * 0.05;
                Hp -= dañoVeneno;
                mensaje = $"{Name} se encuentra ***{EstadoNegativo}*** 💚 , en este turno perdio {dañoVeneno} puntos de vida\n Debes usar un ***Cura total***";
                mensaje += $"\n Ahora {Name} tiene {Hp} puntos de vida";
            }
            else if (EstadoNegativo == "Quemado")
            {
                double dañoQuemadura = HpInicial * 0.10;
                Hp -= dañoQuemadura;
                mensaje = $"{Name} se encuentra ***{EstadoNegativo}*** 🔥 , en este turno perdio {dañoQuemadura} puntos de vida\n Debes usar una ***Cura total***";
                mensaje += $"\n Ahora {Name} tiene {Hp} puntos de vida";
            }
        }
        else
        {
            mensaje = $"{Name} fue derrotado debes cambiar de pokemon o usar un item revivir.";
            EnCombate = false;
        }
        return mensaje;
    }
}
