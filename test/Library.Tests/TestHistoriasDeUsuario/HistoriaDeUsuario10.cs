namespace Library.Tests;

using System.Collections.Generic;
using NUnit.Framework; // Marco de pruebas NUnit.

public class HistoriaDeUsuario10
{
    // Clase auxiliar para representar un jugador.
    public class Jugador
    {
        public string Name { get; set; } // Nombre del jugador.
    }

    // Clase que contiene la lista de espera y el método a probar.
    public class SalaDeEspera
    {
        public List<Jugador> listaEspera = new List<Jugador>(); // Lista de espera de jugadores.

        // Método que devuelve la lista de espera en formato string.
        public string MostrarListaDeEspera()
        {
            if (listaEspera.Count > 0) // Verifica si hay jugadores en la lista.
            {
                string lista = "Jugadores en lista de espera: \n";
                foreach (var jugador in listaEspera) // Recorre todos los jugadores.
                {
                    lista += $" 👦 {jugador.Name}"; // Agrega cada jugador al string.
                }
                return lista; // Devuelve la lista generada.
            }
            else
            {
                return "No hay jugadores en lista de espera."; // Mensaje si la lista está vacía.
            }
        }
    }

    // Test para verificar el comportamiento del método MostrarListaDeEspera.
    [Test]
    public void MostrarListaDeEspera_Debe_DevolverMensajeSiListaVacia()
    {
        // Arrange: Creamos una sala de espera vacía.
        var salaDeEspera = new SalaDeEspera();

        // Act: Llamamos al método MostrarListaDeEspera.
        string resultado = salaDeEspera.MostrarListaDeEspera();

        // Assert: Verificamos que el mensaje sea el esperado.
        Assert.AreEqual("No hay jugadores en lista de espera.", resultado);
    }

    [Test]
    public void MostrarListaDeEspera_Debe_DevolverListaDeJugadores()
    {
        // Arrange: Creamos una sala de espera con jugadores.
        var salaDeEspera = new SalaDeEspera();
        salaDeEspera.listaEspera.Add(new Jugador { Name = "Ash" });
        salaDeEspera.listaEspera.Add(new Jugador { Name = "Misty" });

        // Act: Llamamos al método MostrarListaDeEspera.
        string resultado = salaDeEspera.MostrarListaDeEspera();

        // Assert: Verificamos que el string devuelto sea correcto.
        string esperado = "Jugadores en lista de espera: \n 👦 Ash 👦 Misty";
        Assert.AreEqual(esperado, resultado);
    }
}
