using Library;
using System;

namespace Program;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Facada jugar = new Facada("Pedro","Juan");
		jugar.IniciarPartida();
    }
}
