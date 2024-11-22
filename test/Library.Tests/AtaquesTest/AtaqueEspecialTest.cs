using Library;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace Library.Tests;

[TestFixture]
public class AtaqueTests
{

    [Test]
    public void TestEjecutarAtaqueNormal()
    {
        // Arrange
        Pokemon oponente = new Pokemon(1, "Bulbasaur", 40, 70, "planta", new List<IAtaque>());
        AtaqueNormal ataque = new AtaqueNormal("Impactrueno", 30, "Eléctrico");

        // Act
        ataque.Ejecutar_Ataque(oponente);

        // Assert
        Assert.AreEqual(40, oponente.Hp, "El HP de Bulbasaur debería ser 40 después del ataque normal.");
    }


 
    [Test]
    public void TestEjecutarAtaqueEspecial_CuandoPuedeUsar()
    {
        // Arrange
        Pokemon oponente = new Pokemon(1, "Bulbasaur", 20, 70, "planta", new List<IAtaque>());
        AtaqueEspecial ataqueEspecial = new AtaqueEspecial("Rayo", 50, 2, "Eléctrico");

        // Act
        ataqueEspecial.Ejecutar_Ataque(oponente);

        // Assert
        Assert.AreEqual(20, oponente.Hp, "El HP de Bulbasaur debería ser 20 después del ataque especial.");
        Assert.AreEqual(2, ataqueEspecial.EnfriamientoActual, "El enfriamiento actual del ataque especial debería ser 2.");
    }

    [Test]
    public void TestEjecutarAtaqueEspecial_CuandoNoPuedeUsar()
    {
        // Arrange
        Pokemon oponente = new Pokemon(1, "Bulbasaur", 85, 70, "planta", new List<IAtaque>());
        AtaqueEspecial ataqueEspecial = new AtaqueEspecial("Rayo", 50, 2, "Eléctrico");

        // Usar el ataque especial una vez para ponerlo en enfriamiento
        ataqueEspecial.Ejecutar_Ataque(oponente); // El oponente debería recibir daño y el ataque estará en enfriamiento

        // Act: Intentar usarlo nuevamente
        ataqueEspecial.Ejecutar_Ataque(oponente);

        // Assert: El ataque no debe ejecutarse, y el HP no debe haber cambiado
        Assert.AreEqual(85, oponente.Hp, $"{oponente.Name} debería seguir teniendo 85 HP.");
    }


    [Test]
    public void TestPuedeUsarAtaque_CuandoEnfriamientoEsCero()
    {
        // Arrange
        AtaqueEspecial ataqueEspecial = new AtaqueEspecial("Rayo", 50, 2, "Eléctrico");


        // Act
        bool puedeUsar = ataqueEspecial.PuedeUsarAtaque();

        // Assert
        Assert.IsTrue(puedeUsar, "Se esperaba que el ataque especial pudiera ser utilizado.");
    }

    [Test]
    public void TestPuedeUsarAtaque_CuandoEnfriamientoNoEsCero()
    {
        // Arrange
        AtaqueEspecial ataqueEspecial = new AtaqueEspecial("Rayo", 50, 2, "Eléctrico");

        ataqueEspecial.Ejecutar_Ataque( new Pokemon(1, "Bulbasaur", 85, 70, "planta", new List<IAtaque>()));
        // Usamos el ataque para poner en enfriamiento

        // Act
        bool puedeUsar = ataqueEspecial.PuedeUsarAtaque();

        // Assert
        Assert.IsFalse(puedeUsar, "Se esperaba que el ataque especial no pudiera ser utilizado debido a enfriamiento.");
    }
}
