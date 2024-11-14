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
        Pokemon oponente = new Pokemon(1, "Bulbasaur", 85, 70, "planta", new List<IAtaque>());

        AtaqueNormal ataque = new AtaqueNormal("Impactrueno", 30,"Hierba");

        // Act
        ataque.Ejecutar_Ataque(oponente);

        // Assert: Verificar que el oponente ha recibido el daño
        Assert.AreEqual(70 - 30, oponente.Hp, $"{oponente.Name} debería tener {oponente.Hp} HP después del ataque.");
    }

    [Test]
    public void TestEjecutarAtaqueEspecial_CuandoPuedeUsar()
    {
        // Arrange
        Pokemon oponente = new Pokemon(1, "Bulbasaur", 85, 70, "planta", new List<IAtaque>());

        AtaqueEspecial ataqueEspecial = new AtaqueEspecial("Rayo", 50, 2,"Hierba"); // Enfriamiento de 2 turnos

        // Act
        ataqueEspecial.Ejecutar_Ataque(oponente);

        // Assert: Verificar que el oponente ha recibido el daño
        Assert.AreEqual(70 - 50, oponente.Hp, $"{oponente.Name} debería tener {oponente.Hp} HP después del ataque especial.");
        Assert.AreEqual(2, ataqueEspecial.EnfriamientoMax, "El ataque especial debería estar en enfriamiento.");
    }

    [Test]
    public void TestEjecutarAtaqueEspecial_CuandoNoPuedeUsar()
    {
        // Arrange
        Pokemon oponente = new Pokemon(1, "Bulbasaur", 85, 70, "planta", new List<IAtaque>());
        AtaqueEspecial ataqueEspecial =  new AtaqueEspecial("Rayo", 50, 2, "Eléctrico");


        // Usar el ataque especial una vez para ponerlo en enfriamiento
        ataqueEspecial.Ejecutar_Ataque(oponente); // El oponente debería recibir daño y el ataque estará en enfriamiento

        // Act: Intentar usarlo nuevamente
        ataqueEspecial.Ejecutar_Ataque(oponente);

        // Assert: El ataque no debe ejecutarse, y se debe mostrar un mensaje de enfriamiento
        // Aquí podrías verificar que el HP no cambió, o que se llamó a Console.WriteLine() con el mensaje de enfriamiento.
        Assert.AreEqual(70 - 50, oponente.Hp, $"{oponente.Name} debería seguir teniendo {oponente.Hp} HP.");
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
