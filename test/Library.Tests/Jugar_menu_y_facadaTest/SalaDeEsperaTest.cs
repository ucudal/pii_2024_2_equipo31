using Library;
using NUnit.Framework;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;

namespace Library.Tests;

[TestFixture]
public class SalaDeEsperaTests
{
    private Sala_De_Espera salaDeEspera = new Sala_De_Espera();

    [Test]
    public void TestAgregarJugadorCreado()
    {
        // Crear un jugador
        Jugador jugador = new Jugador("Jugador1");

        // Agregar el jugador a la lista de jugadores creados
        salaDeEspera.AgregarJugadorCreado(jugador);

        // Verificar que el jugador fue agregado
        Assert.IsTrue(salaDeEspera.jugadoresCreados.Contains(jugador));
    }

    [Test]
    public void TestUnirseALaListaDeEspera_JugadorCreado()
    {
        // Crear un jugador y agregarlo
        Jugador jugador = new Jugador("Jugador1");
        salaDeEspera.AgregarJugadorCreado(jugador);

        // Simular la entrada de un jugador que se une a la lista de espera
        salaDeEspera.UnirseALaListaDeEspera(jugador, salaDeEspera.jugadoresCreados);

        // Verificar que el jugador está en la lista de espera
        Assert.IsTrue(salaDeEspera.listaEspera.Contains(jugador));
    }

    [Test]
    public void TestUnirseALaListaDeEspera_JugadorNoCreado()
    {
        // Crear un jugador que no se agrega a la lista
        Jugador jugador = new Jugador("Jugador1");

        // intento unir el jugador que no se encuentra en la lista de jugadores creados y guardo el mensaje que me devuelve
        string mensaje1 = salaDeEspera.UnirseALaListaDeEspera(jugador, salaDeEspera.jugadoresCreados);
        
        // Si el mensaje es el que salta cuando el jugador no puede unirse retorno true, de lo contrario retorno false
        bool algo(string mensaje)
        {
            if (mensaje.Contains("Solo los jugadores creados pueden unirse a la sala de espera."))
            {
                return false;
            }
            return true;
        }
        
        // instancio el metodo anterior
        algo(mensaje1);
        
        // SI EL METODO ES TRUE, SIGNIFICA QUE NO PUEDE I
        Assert.IsFalse(algo(mensaje1));
    }

    [Test]
    public void TestMostrarListaDeEspera()
    {
        // Crear una instancia de Sala_De_Espera
        Sala_De_Espera salaDeEspera = new Sala_De_Espera();
    
        // Crear un jugador y agregarlo a la lista
        Jugador jugador = new Jugador("Jugador1");
        salaDeEspera.AgregarJugadorCreado(jugador);
        salaDeEspera.UnirseALaListaDeEspera(jugador, salaDeEspera.jugadoresCreados);

        // Obtener la cadena de salida directamente del método
        string output = salaDeEspera.MostrarListaDeEspera();

        // Verificar que se muestra el jugador en la lista de espera
        string expectedOutput = "Jugadores en lista de espera: \n 👦 Jugador1";
        Assert.AreEqual(expectedOutput, output);
    }
}
