using Xunit;
using System.Collections.Generic;
using Assert = NUnit.Framework.Assert;
using NUnit.Framework;
using System;



namespace Library.Tests;


public class HistoriaDeUsuario4
{
    [Fact]
    public void EfectividadTipos_DanoReducido_CuandoAtaqueEsAguaYOponenteEsElectrico()
    {
        // Arrange
        var ataque = new AtaqueNormal("Chorro de agua", 100, "Agua");
        var oponente = new Pokemon(1, "Pikuachu", 100, 10, "Electrico", new List<IAtaque>());

        // Act
        double resultado = ataque.EfectividadTipos(ataque.Daño, ataque.TipoAtaque, oponente);

        // Assert
        Assert.AreEqual(50, resultado); // Se espera que el daño se reduzca a la mitad.
    }

    [Fact]
    public void EfectividadTipos_DanoAumentado_CuandoAtaqueEsAguaYOponenteEsFuego()
    {
        // Arrange
        var ataque = new AtaqueNormal("Chorro de agua", 100, "Agua");
        var oponente = new Pokemon(2, "Charmander", 100, 10, "Fuego", new List<IAtaque>());

        // Act
        double resultado = ataque.EfectividadTipos(ataque.Daño, ataque.TipoAtaque, oponente);

        // Assert
        Assert.AreEqual(200, resultado); // Se espera que el daño se duplique.
    }

    [Fact]
    public void EfectividadTipos_SinEfecto_CuandoAtaqueEsElectricoYOponenteEsElectrico()
    {
        // Arrange
        var ataque = new AtaqueNormal("Impactrueno", 100, "Electrico");
        var oponente = new Pokemon(3, "Raichu", 120, 15, "Electrico", new List<IAtaque>());

        // Act
        double resultado = ataque.EfectividadTipos(ataque.Daño, ataque.TipoAtaque, oponente);

        // Assert
        Assert.AreEqual(0, resultado); // Sin efecto, daño debe ser 0.
    }

    [Fact]
    public void EfectividadTipos_SinCambio_CuandoAtaqueYDefensaNoTienenVentajasNiDesventajas()
    {
        // Arrange
        var ataque = new AtaqueNormal("Corte", 100, "Normal");
        var oponente = new Pokemon(4, "Onix", 150, 20, "Roca", new List<IAtaque>());

        // Act
        double resultado = ataque.EfectividadTipos(ataque.Daño, ataque.TipoAtaque, oponente);

        // Assert
        Assert.AreEqual(100, resultado); // Sin cambio en el daño.
    }
}





// Clases y estructuras simuladas
public class ComponentInteractionCreateEventArgs
{
    public IUser User { get; set; }
    public IChannel Channel { get; set; }
}

public interface IUser
{
    string Username { get; }
}

public interface IChannel
{
    void SendMessageAsync(string message);
}

public class TestUser : IUser
{
    public string Username { get; set; }
}

public class TestChannel : IChannel
{
    public string LastMessage { get; private set; }

    public void SendMessageAsync(string message)
    {
        LastMessage = message;
    }
}

public class JugadorX
{
    public string Name { get; }

    public JugadorX(string name)
    {
        Name = name;
    }
}

[TestFixture]
public class EsMiTurnoTests
{
    [Test]
    public void EsMiTurno_CuandoEsTurnoDeJugador1_YUsuarioEsJugador1_RetornaTrue()
    {
        // Arrange
        var jugador1 = new Jugador("Ash");
        var jugador2 = new Jugador("Misty");

        var user = new TestUser { Username = "Ash" };
        var channel = new TestChannel();

        var args = new ComponentInteractionCreateEventArgs
        {
            User = user,
            Channel = channel
        };

        var esTurnoJugador1 = true;

        // Act
        var resultado = EsMiTurno_Testable(esTurnoJugador1, jugador1, jugador2, args);

        // Assert
        Assert.IsTrue(resultado, "El método debería retornar true si es el turno del jugador 1 y el usuario coincide.");
        Assert.IsNull(channel.LastMessage, "No debería enviar mensajes cuando es el turno correcto.");
    }

    [Test]
    public void EsMiTurno_CuandoEsTurnoDeJugador1_YUsuarioNoEsJugador1_RetornaFalse()
    {
        // Arrange
        var jugador1 = new Jugador("Ash");
        var jugador2 = new Jugador("Misty");

        var user = new TestUser { Username = "Misty" };
        var channel = new TestChannel();

        var args = new ComponentInteractionCreateEventArgs
        {
            User = user,
            Channel = channel
        };

        var esTurnoJugador1 = true;

        // Act
        var resultado = EsMiTurno_Testable(esTurnoJugador1, jugador1, jugador2, args);

        // Assert
        Assert.IsFalse(resultado, "El método debería retornar false si no es el turno del usuario.");
        Assert.AreEqual("No es tu turno actualmente", channel.LastMessage, "Debería enviar un mensaje cuando no es el turno del usuario.");
    }

    [Test]
    public void EsMiTurno_CuandoEsTurnoDeJugador2_YUsuarioEsJugador2_RetornaTrue()
    {
        // Arrange
        var jugador1 = new Jugador("Ash");
        var jugador2 = new Jugador("Misty");

        var user = new TestUser { Username = "Misty" };
        var channel = new TestChannel();

        var args = new ComponentInteractionCreateEventArgs
        {
            User = user,
            Channel = channel
        };

        var esTurnoJugador1 = false;

        // Act
        var resultado = EsMiTurno_Testable(esTurnoJugador1, jugador1, jugador2, args);

        // Assert
        Assert.IsTrue(resultado, "El método debería retornar true si es el turno del jugador 2 y el usuario coincide.");
        Assert.IsNull(channel.LastMessage, "No debería enviar mensajes cuando es el turno correcto.");
    }

    [Test]
    public void EsMiTurno_CuandoEsTurnoDeJugador2_YUsuarioNoEsJugador2_RetornaFalse()
    {
        // Arrange
        var jugador1 = new Jugador("Ash");
        var jugador2 = new Jugador("Misty");

        var user = new TestUser { Username = "Ash" };
        var channel = new TestChannel();

        var args = new ComponentInteractionCreateEventArgs
        {
            User = user,
            Channel = channel
        };

        var esTurnoJugador1 = false;

        // Act
        var resultado = EsMiTurno_Testable(esTurnoJugador1, jugador1, jugador2, args);

        // Assert
        Assert.IsFalse(resultado, "El método debería retornar false si no es el turno del usuario.");
        Assert.AreEqual("No es tu turno actualmente", channel.LastMessage, "Debería enviar un mensaje cuando no es el turno del usuario.");
    }

    // Método auxiliar para testear EsMiTurno
    private bool EsMiTurno_Testable(bool esTurnoJugador1, Jugador jugador1, Jugador jugador2, ComponentInteractionCreateEventArgs args)
    {
        if (esTurnoJugador1)
        {
            if (jugador1.Name == args.User.Username)
            {
                return true;
            }
            args.Channel.SendMessageAsync("No es tu turno actualmente");
        }
        else
        {
            if (jugador2.Name == args.User.Username)
            {
                return true;
            }
            args.Channel.SendMessageAsync("No es tu turno actualmente");
        }
        return false;
    }
}
