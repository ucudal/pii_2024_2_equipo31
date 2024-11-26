using System;
using System.Collections.Generic;

namespace Library;

/// <summary>
/// Define la interfaz para un ataque en el sistema.
/// </summary>
public interface IAtaque
{
    /// <summary>
    /// Obtiene el nombre del ataque.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Obtiene o establece el daño del ataque.
    /// </summary>
    double Daño { get; set; }

    /// <summary>
    /// Obtiene el tipo del ataque.
    /// </summary>
    string TipoAtaque { get; }

    /// <summary>
    /// Ejecuta el ataque sobre un Pokémon oponente.
    /// </summary>
    /// <param name="oponente">El Pokémon que será atacado.</param>
    string Ejecutar_Ataque(Pokemon oponente);
}