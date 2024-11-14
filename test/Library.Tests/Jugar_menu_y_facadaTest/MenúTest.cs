using Library;
using NUnit.Framework;
using System;
using System.IO;

namespace Library.Tests
{
    [TestFixture]
    public class MenuTests
    {
        private StringWriter output;
        private Menu menu;

        [SetUp]
        public void SetUp()
        {
            output = new StringWriter();
            Console.SetOut(output);
            menu = new Menu();
        }

        [TearDown]
        public void TearDown()
        {
            Console.SetOut(Console.Out);
            output.Dispose();
            Console.SetIn(Console.In);
        }

        [Test]
        public void TestMostrarMenuPrincipal_IniciarBatalla()
        {
            using (var input = new StringReader("1\n5\n"))
            {
                Console.SetIn(input);
                menu.MostrarMenuPrincipal();
                Assert.IsTrue(output.ToString().Contains("Bienvenido al menú de batallas!"));
            }
        }

        [Test]
        public void TestMostrarMenuPrincipal_Salir()
        {
            using (var input = new StringReader("5\n"))
            {
                Console.SetIn(input);
                menu.MostrarMenuPrincipal();
                Assert.IsTrue(output.ToString().Contains("Gracias por jugar"));
            }
        }

        [Test]
        public void TestMostrarMenuPrincipal_UnirseALaEspera()
        {
            using (var input = new StringReader("2\nJugador1\n5\n"))
            {
                Console.SetIn(input);
                menu.MostrarMenuPrincipal();
                Assert.IsTrue(output.ToString().Contains("Escribe el nombre del jugador que quiere unirse a la lista de espera:"));
            }
        }

        [Test]
        public void TestMostrarMenuPrincipal_MostrarJugadoresEnEspera()
        {
            using (var input = new StringReader("3\n5\n"))
            {
                Console.SetIn(input);
                menu.MostrarMenuPrincipal();
                Assert.IsTrue(output.ToString().Contains("Bienvenido al menú de batallas!"));
            }
        }
    }
}
