using Library;
using NUnit.Framework;
using System;
using System.IO;

namespace Library.Tests;

[TestFixture]
public class SalaDeEsperaTests
{
    private Sala_De_Espera salaDeEspera;

    [SetUp]
    public void Setup()
    {
        salaDeEspera = new Sala_De_Espera();
    }

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

        // Simular que el jugador intenta unirse sin haber sido creado
        StringWriter output = new StringWriter();
        Console.SetOut(output);
        
        salaDeEspera.UnirseALaListaDeEspera(jugador, salaDeEspera.jugadoresCreados);

        // Verificar el mensaje de error
        string expectedOutput = "Solo los jugadores creados pueden unirse a la sala de espera.";
        Assert.IsTrue(output.ToString().Contains(expectedOutput));
    }

    [Test]
    public void TestMostrarListaDeEspera()
    {
        // Crear un jugador y agregarlo a la lista
        Jugador jugador = new Jugador("Jugador1");
        salaDeEspera.AgregarJugadorCreado(jugador);
        salaDeEspera.UnirseALaListaDeEspera(jugador, salaDeEspera.jugadoresCreados);

        // Simular la salida de mostrar la lista de espera
        StringWriter output = new StringWriter();
        Console.SetOut(output);

        salaDeEspera.MostrarListaDeEspera();

        // Verificar que se muestra el jugador en la lista de espera
        string expectedOutput = "Jugadores en lista de espera: \n 👦 Jugador1";
        Assert.IsTrue(output.ToString().Contains(expectedOutput));
    }

    [Test]
    public void TestIniciarBatallaSalaEspera_SuficientesJugadores()
    {
        // Crear dos jugadores y agregarlos a la sala de espera
        Jugador jugador1 = new Jugador("Jugador1");
        Jugador jugador2 = new Jugador("Jugador2");
        salaDeEspera.AgregarJugadorCreado(jugador1);
        salaDeEspera.AgregarJugadorCreado(jugador2);
        salaDeEspera.UnirseALaListaDeEspera(jugador1, salaDeEspera.jugadoresCreados);
        salaDeEspera.UnirseALaListaDeEspera(jugador2, salaDeEspera.jugadoresCreados);

        // Simular la salida de iniciar una batalla
        StringWriter output = new StringWriter();
        Console.SetOut(output);

        salaDeEspera.IniciarBatallaSalaEspera();

        // Verificar que se muestra que la batalla comenzó
        Assert.IsTrue(output.ToString().Contains("comenzaron una batalla"));
    }

    [Test]
    public void TestIniciarBatallaSalaEspera_NoSuficientesJugadores()
    {
        // Crear un jugador y agregarlo a la sala de espera
        Jugador jugador = new Jugador("Jugador1");
        salaDeEspera.AgregarJugadorCreado(jugador);
        salaDeEspera.UnirseALaListaDeEspera(jugador, salaDeEspera.jugadoresCreados);

        // Simular la salida de iniciar una batalla
        StringWriter output = new StringWriter();
        Console.SetOut(output);

        salaDeEspera.IniciarBatallaSalaEspera();

        // Verificar que se muestra que no hay suficientes jugadores
        string expectedOutput = "No hay jugadores suficientes en la lista de espera para batallar";
        Assert.IsTrue(output.ToString().Contains(expectedOutput));
    }
}
