namespace Library;

/// <summary>
/// Clase abstracta que representa un ataque en el sistema.
/// </summary>
public abstract class Ataque : IAtaque // CLASE ABSTRACTA CON LA EFECTIVIDAD DE TIPOS PARA HEREDAR
{
    /// <summary>
    /// Obtiene el nombre del ataque.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Obtiene o establece el daño del ataque.
    /// </summary>
    public double Daño { get; set; }

    /// <summary>
    /// Obtiene o establece el tipo de ataque.
    /// </summary>
    public string TipoAtaque { get; set; }

    /// <summary>
    /// Ejecuta el ataque sobre un Pokémon oponente.
    /// </summary>
    /// <param name="oponente">El Pokémon que será atacado.</param>
    public void Ejecutar_Ataque(Pokemon oponente) { }

    /// <summary>
    /// Calcula la efectividad del ataque basado en el tipo del ataque y el tipo del oponente.
    /// </summary>
    /// <param name="dañoEntrante">El daño base del ataque.</param>
    /// <param name="tipoDelAtaque">El tipo del ataque que se está realizando.</param>
    /// <param name="oponente">El Pokémon oponente que recibe el ataque.</param>
    /// <returns>El daño modificado después de aplicar la efectividad del tipo.</returns>
    public double EfectividadTipos(double dañoEntrante, string tipoDelAtaque, Pokemon oponente) // LISTA DE EFECTIVIDAD DE TIPOS SEGUN EL ATAQUE Y EL POKEMON
    {
        this.TipoAtaque = tipoDelAtaque;
        double dañoModificado = dañoEntrante;
        Console.WriteLine($"Tipo de ataque: {this.TipoAtaque}\nTipo del oponente: {oponente.Tipo}");

        // Cálculo de la efectividad del ataque según el tipo
        if (this.TipoAtaque == "Agua") 
        { 
            if (oponente.Tipo == "Electrico" || oponente.Tipo == "Hierba") 
            { 
                dañoModificado *= 0.5;
            }
            else if (oponente.Tipo == "Agua" || oponente.Tipo == "Fuego" || oponente.Tipo == "Hielo") 
            { 
                dañoModificado *= 2;
            }
        }
        else if (this.TipoAtaque == "Bicho") 
        { 
            if (oponente.Tipo == "Fuego" || oponente.Tipo == "Roca" || oponente.Tipo == "Volador" || oponente.Tipo == "Veneno")
            { 
                dañoModificado *= 0.5;
            }
            else if (oponente.Tipo == "Lucha" || oponente.Tipo == "Hierba" || oponente.Tipo == "Tierra") 
            { 
                dañoModificado *= 2;
            }
        }
        else if (this.TipoAtaque == "Dragón") 
        { 
            if (oponente.Tipo == "Dragón" || oponente.Tipo == "Hielo") 
            { 
                dañoModificado *= 0.5;
            }
            else if (oponente.Tipo == "Agua" || oponente.Tipo == "Electrico" || oponente.Tipo == "Fuego" || oponente.Tipo == "Hierba") 
            { 
                dañoModificado *= 2;
            }
        }
        else if (this.TipoAtaque == "Electrico") 
        { 
            if (oponente.Tipo == "Tierra") 
            { 
                dañoModificado *= 0.5;
            }
            else if (oponente.Tipo == "Volador") 
            { 
                dañoModificado *= 2;
            }
            else if (oponente.Tipo == "Electrico") 
            { 
                dañoModificado *= 0;
            }
        }
        else if (this.TipoAtaque == "Fantasma") 
        { 
            if (oponente.Tipo == "Fantasma") 
            { 
                dañoModificado *= 0.5;
            }
            else if (oponente.Tipo == "Veneno" || oponente.Tipo == "Lucha" || oponente.Tipo == "Normal") 
            { 
                dañoModificado *= 2;
            }
        }
        else if (this.TipoAtaque == "Fuego") 
        { 
            if (oponente.Tipo == "Agua" || oponente.Tipo == "Roca" || oponente.Tipo == "Tierra") 
            { 
                dañoModificado *= 0.5;
            }
            else if (oponente.Tipo == "Bicho" || oponente.Tipo == "Fuego" || oponente.Tipo == "Planta") 
            { 
                dañoModificado *= 2;
            }
        }
        else if (this.TipoAtaque == "Hielo") 
        { 
            if (oponente.Tipo == "Fuego" || oponente.Tipo == "Lucha" || oponente.Tipo == "Roca") 
            { 
                dañoModificado *= 0.5;
            }
            else if (oponente.Tipo == "Hielo") 
            { 
                dañoModificado *= 2;
            }
        }
        else if (this.TipoAtaque == "Lucha") 
        { 
            if (oponente.Tipo == "Psiquico" || oponente.Tipo == "Volador" || oponente.Tipo == "Bicho" || oponente.Tipo == "Roca") 
            { 
                dañoModificado *= 0.5;
            }
        }
        else if (this.TipoAtaque == "Normal") 
        { 
            if (oponente.Tipo == "Lucha") 
            { 
                dañoModificado *= 0.5;
            }
            else if (oponente.Tipo == "Fantasma") 
            { 
                dañoModificado *= 0;
            }
        }
        else if (this.TipoAtaque == "Hierba") 
        { 
            if (oponente.Tipo == "Bicho" || oponente.Tipo == "Fuego" || oponente.Tipo == "Hielo" || oponente.Tipo == "Veneno" || oponente.Tipo == "Volador") 
            { 
                dañoModificado *= 0.5;
            }
            else if (oponente.Tipo == "Agua" || oponente.Tipo == "Electrico" || oponente.Tipo == "Planta" || oponente.Tipo == "Tierra") 
            { 
                dañoModificado *= 2;
            }
        }
        else if (this.TipoAtaque == "Psiquico") 
        { 
            if (oponente.Tipo == "Bicho" || oponente.Tipo == "Lucha" || oponente.Tipo == "Fantasma") 
            { 
                dañoModificado *= 0.5;
            }
        }
        else if (this.TipoAtaque == "Roca") 
        { 
            if (oponente.Tipo == "Agua" || oponente.Tipo == "Lucha" || oponente.Tipo == "Planta" || oponente.Tipo == "Tierra") 
            { 
                dañoModificado *= 0.5;
            }
            else if (oponente.Tipo == "Fuego" || oponente.Tipo == "Normal" || oponente.Tipo == "Veneno" || oponente.Tipo == "Volador") 
            { 
                dañoModificado *= 2;
            }
        }
        else if (this.TipoAtaque == "Tierra") 
        { 
            if (oponente.Tipo == "Agua" || oponente.Tipo == "Hielo" || oponente.Tipo == "Planta" || oponente.Tipo == "Roca" || oponente.Tipo == "Veneno") 
            { 
                dañoModificado *= 0.5;
            }
            else if (oponente.Tipo == "Electrico") 
            { 
                dañoModificado *= 2;
            }
        }
        else if (this.TipoAtaque == "Veneno") 
        { 
            if (oponente.Tipo == "Bicho" || oponente.Tipo == "Psiquico" || oponente.Tipo == "Tierra" || oponente.Tipo == "Lucha" || oponente.Tipo == "Planta") 
            { 
                dañoModificado *= 0.5;
            }
            else if (oponente.Tipo == "Planta" || oponente.Tipo == "Veneno") 
            { 
                dañoModificado *= 2;
            }
        }
        else if (this.TipoAtaque == "Volador") 
        { 
            if (oponente.Tipo == "Electrico" || oponente.Tipo == "Hielo" || oponente.Tipo == "Roca") 
            { 
                dañoModificado *= 0.5;
            }
            else if (oponente.Tipo == "Bicho" || oponente.Tipo == "Lucha" || oponente.Tipo == "Planta" || oponente.Tipo == "Tierra") 
            { 
                dañoModificado *= 2;
            }
        } 
        Console.WriteLine($"Daño modificado final: {dañoModificado}");
        return dañoModificado;
    }
}
