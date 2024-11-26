using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Clase que representa el menú de opciones para gestionar jugadores, seleccionar Pokémon y realizar batallas.
    /// </summary>
    public class Menu
    {
        private Facada _facada;
        private Sala_De_Espera _salaDeEspera;

        /// <summary>
        /// Constructor de la clase <see cref="Menu"/> que inicializa la cantidad de jugadores y sus nombres.
        /// </summary>
        public Menu()
        {
            Console.WriteLine("\n 📝 ¿Cuántos jugadores desea crear? (1 o 2): ");
            string respuesta = Console.ReadLine();
            int cantidadJugadores;

            while (!int.TryParse(respuesta, out cantidadJugadores) || (cantidadJugadores < 1 || cantidadJugadores > 2))
            {
                Console.WriteLine("Intente ingresar un número de jugadores válido (1 o 2): ");
                respuesta = Console.ReadLine();
            }

            List<string> nombreJugadores = new List<string>();
            for (int i = 1; i <= cantidadJugadores; i++)
            {
                Console.WriteLine($"\n 📝 Escribe el nombre del Jugador {i}: ");
                nombreJugadores.Add(Console.ReadLine());
            }

            _salaDeEspera = new Sala_De_Espera();
            _facada = new Facada(_salaDeEspera);
            InicializarPokemons(nombreJugadores);
        }

        /// <summary>
        /// Permite que cada jugador seleccione sus Pokémon iniciales.
        /// </summary>
        private void InicializarPokemons(List<string> nombreJugadores)
        {
            Console.WriteLine("El primer jugador deberá seleccionar sus 6 Pokémon: ");
            _facada.UnirJugador(nombreJugadores[0]);
            // Aquí se debe agregar la lógica para que el jugador seleccione sus Pokémon

            if (nombreJugadores.Count > 1)
            {
                Console.WriteLine("El segundo jugador deberá seleccionar sus 6 Pokémon: ");
                _facada.UnirJugador(nombreJugadores[1]);
                // Aquí se debe agregar la lógica para que el segundo jugador seleccione sus Pokémon
            }
        }

        /// <summary>
        /// Muestra el menú principal para iniciar batallas, unirse a la lista de espera o salir.
        /// </summary>
        public void MostrarMenuPrincipal()
        {
            string opcion;

            do
            {
                Console.WriteLine("\nBienvenido al menú de batallas!");
                Console.WriteLine("1. Iniciar Batalla Local");
                Console.WriteLine("2. Unirse a la lista de espera");
                Console.WriteLine("3. Ver jugadores en la lista de espera");
                Console.WriteLine("4. Iniciar batalla con un jugador de la lista de espera");
                Console.WriteLine("5. Salir");
                Console.WriteLine("Escriba su opción: ");

                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        // Aquí se debe agregar la lógica para iniciar una batalla local
                        break;
                    case "2":
                        UnirJugadorALaEspera();
                        break;
                    case "3":
                        // Aquí se debe agregar la lógica para mostrar jugadores en espera
                        break;
                    case "4":
                        // Aquí se debe agregar la lógica para iniciar batalla con un jugador en espera
                        break;
                    case "5":
                        Console.WriteLine("Gracias por jugar\nHasta la próxima!\n");
                        break;
                    default:
                        Console.WriteLine("Opción incorrecta, ingrese una opción válida.");
                        break;
                }
            }
            while (opcion != "5");
        }

        /// <summary>
        /// Permite al usuario ingresar un jugador en la lista de espera.
        /// </summary>
        private void UnirJugadorALaEspera()
        {
            Console.WriteLine("Escribe el nombre del jugador que quiere unirse a la lista de espera: ");
            string nombreJugador = Console.ReadLine();

            // Aquí se debe agregar la lógica para unir al jugador a la lista de espera
        }
    }
}