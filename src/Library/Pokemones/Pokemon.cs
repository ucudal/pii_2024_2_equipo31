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
    public string Tipo { get; private set; }

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
    public List<IAtaque> Ataques { get; private set; }

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
        EnCombate = false;
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
            double dañoADefensa = Math.Max(this.Defensa, daño);
            this.Defensa -= dañoADefensa;
            daño -= dañoADefensa;
        }
        if (daño > 0)
        {
            this.Hp = Math.Max(0, this.Hp - daño);
        }
        if (this.Defensa < 0)
        {
            this.Defensa = 0;
        }
    }
}
