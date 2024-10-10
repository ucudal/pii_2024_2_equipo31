namespace Library;
using System;

class Juego
{
    public Jugador Jugador{ get; private set; }
    public Menu Menu { get; private set; }
    public string Pokemon { get; private set; }

    public void IniciarPartida()
    {
        Jugador = new Jugador();
        Menu = new Menu();
        Console.WriteLine("¡Partida iniciada!");
    }
    
    private string MostrarMenu()
    {
        string[] opciones = { "1. Jugar", "2. Salir" };
        Console.WriteLine("Menú:");
        foreach (var opcion in opciones)
        {
            Console.WriteLine(opcion);
        }
        Console.Write("Elige una opción: ");
        return Console.ReadLine();
    }
    }

