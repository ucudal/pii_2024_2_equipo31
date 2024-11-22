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
        // Simular la salida de Console
        StringWriter output = new StringWriter();
        Console.SetOut(output);

        // Ejecutar el ataque
        ataqueNormal.Ejecutar_Ataque(oponente);

        // Calcular el daño esperado (teniendo en cuenta que no se aplican efectos de tipo)
        double dañoEsperado = 10; // Cambiar si hay lógica adicional en EfectividadTipos
        oponente.El_Pokemon_Recibio_Daño(dañoEsperado);

        // Verificar la salida
        Assert.IsTrue(output.ToString().Contains($"👊 {ataqueNormal.Name} le hizo {dañoEsperado} puntos de daño a {oponente.Name}"));
        Assert.IsTrue(output.ToString().Contains($"📊 A {oponente.Name} le quedan {oponente.Hp} puntos de vida, {oponente.Defensa} puntos de defensa."));
    }

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
    }
}
