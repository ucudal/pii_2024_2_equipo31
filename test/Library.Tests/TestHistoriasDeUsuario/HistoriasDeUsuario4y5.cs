using Xunit;
using System.Collections.Generic;
using Assert = NUnit.Framework.Assert;

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



public class HistoriaDeUsuario5
{
    
}