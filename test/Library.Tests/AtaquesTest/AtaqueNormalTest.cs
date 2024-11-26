using Library;
using NUnit.Framework;
using System;
using System.IO;

namespace Library.Tests;

[TestFixture]
public class AtaqueNormalTests
{
    private AtaqueNormal ataqueNormal;
    private Pokemon oponente;

    [SetUp]
    public void Setup()
    {
        // Inicializar un ataque normal
        ataqueNormal = new AtaqueNormal("Tackle", 10, "Normal");

        // Inicializar un Pokémon oponente
        oponente = new Pokemon(1, "Bulbasaur", 85, 70, "planta", new List<IAtaque>());

    }
    
    [Test]
    public void TestEjecutarAtaque_DañoCorrecto()
    {
        // Arrange
        StringWriter output = new StringWriter();
        Console.SetOut(output);

        // Crear un Pokémon de prueba
        Pokemon oponente = new Pokemon(1, "Bulbasaur", 50, 20, "Planta", new List<IAtaque>());

        // Crear un ataque normal
        AtaqueNormal ataqueNormal = new AtaqueNormal("Impactrueno", 10, "Eléctrico");

        // Calcular daño esperado
        double dañoEsperado = 10; // Cambiar según la lógica de tu sistema si es más complejo
        double hpEsperado = oponente.Hp - dañoEsperado;

        // Act
        ataqueNormal.Ejecutar_Ataque(oponente);

        // Assert: Verificar salida de consola
        string salida = output.ToString();
        Assert.IsTrue(salida.Contains($"👊 {ataqueNormal.Name} le hizo {dañoEsperado} puntos de daño a {oponente.Name}"), 
            "El mensaje de daño no coincide.");
        Assert.IsTrue(salida.Contains($"📊 A {oponente.Name} le quedan {hpEsperado} puntos de vida, {oponente.Defensa} puntos de defensa."), 
            "El mensaje de estado no coincide.");

        // Assert: Verificar que el daño fue aplicado correctamente
        Assert.AreEqual(hpEsperado, oponente.Hp, "El HP del oponente no fue actualizado correctamente.");
    }

    /*     ===================== COMENTE PARA PONER DARLE A RUN Y PROBAR QUE FUNCIONE EL BOT =======================
    [Test]
    public void TestEjecutarAtaque_DañoFinalConEfectividad()
    {
        // Ajustar el daño del ataque oponente según la lógica de efectividad
        // Aquí deberías implementar lógica para simular la efectividad del tipo, si es necesario.

        // Simular la salida de Console
        StringWriter output = new StringWriter();
        Console.SetOut(output);

        // Ejecutar el ataque
        ataqueNormal.Ejecutar_Ataque(oponente);

        // Verificar que el daño final se haya calculado correctamente
        // Puedes ajustar el cálculo del dañoFinal aquí si tienes lógica en EfectividadTipos
         // Cambiar según la efectividad real
        oponente.El_Pokemon_Recibio_Daño(dañoEsperado);

        Assert.IsTrue(output.ToString().Contains($"👊 {ataqueNormal.Name} le hizo {dañoEsperado} puntos de daño a {oponente.Name}"));
<<<<<<< HEAD
    }
}
=======
    }
    */
}
>>>>>>> origin/agustin
