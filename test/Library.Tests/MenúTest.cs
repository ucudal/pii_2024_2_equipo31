using Library;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace Library.Tests;

[TestFixture]
public class MenuTests
{
    [Test]
    public void TestMostrarMenuPrincipal_IniciarBatalla()
    {
        // Simular la entrada de la opción "1" (Iniciar Batalla)
        StringReader input = new StringReader("1\n");
        Console.SetIn(input);

        // Crear la instancia del menú
        Menu menu = new Menu();

        // Act: Llamar al método que estamos probando
        menu.MostrarMenuPrincipal();

        // Aquí no podemos verificar directamente si se inició la batalla,
        // pero podemos observar la salida si fuera necesario.
    }

    [Test]
    public void TestMostrarMenuPrincipal_Salir()
    {
        // Simular la entrada de la opción "5" (Salir)
        StringReader input = new StringReader("5\n");
        Console.SetIn(input);

        // Crear la instancia del menú
        Menu menu = new Menu();

        // Act: Llamar al método que estamos probando
        menu.MostrarMenuPrincipal();

        // Si hubiera algún efecto o salida a verificar, se haría aquí.
        // Podrías usar Console.SetOut para capturar y verificar la salida si lo necesitas.
    }

    [Test]
    public void TestMostrarMenuPrincipal_UnirseALaEspera()
    {
        // Simular la entrada de la opción "2" (Unirse a la lista de espera)
        StringReader input = new StringReader("2\nJugador1\n5\n");
        Console.SetIn(input);

        // Crear la instancia del menú
        Menu menu = new Menu();

        // Act: Llamar al método que estamos probando
        menu.MostrarMenuPrincipal();

        // Verificar que el jugador se unió a la lista de espera correctamente.
        // Aquí se puede agregar lógica para verificar el estado del objeto Facade.
    }

    [Test]
    public void TestMostrarMenuPrincipal_MostrarJugadoresEnEspera()
    {
        // Simular la entrada de la opción "3" (Ver jugadores en la lista de espera)
        StringReader input = new StringReader("3\n5\n");
        Console.SetIn(input);

        // Crear la instancia del menú
        Menu menu = new Menu();

        // Act: Llamar al método que estamos probando
        menu.MostrarMenuPrincipal();

        // Aquí también se puede verificar la salida o el estado del objeto Facade.
    }
}
