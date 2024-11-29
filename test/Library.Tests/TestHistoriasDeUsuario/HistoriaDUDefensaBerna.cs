
namespace Library.Tests;
using Library;
using System.Collections.Generic;
using NUnit.Framework; 
    
public class HistoriaDUDefensaBerna
{

    [Test]

    public void Evualuar_Ataques_Disponibles_de_cada_Pokemon_y_su_tipo()
    {
        var jugador = new Jugador("Berna");
        var jugador2 = new Jugador("Pepe");

        jugador.Seleccionar_6_Pokemons_Iniciales(1);
        jugador.Seleccionar_6_Pokemons_Iniciales(2);
        jugador.Seleccionar_6_Pokemons_Iniciales(3);
        jugador.Seleccionar_6_Pokemons_Iniciales(4);
        jugador.Seleccionar_6_Pokemons_Iniciales(5);
        jugador.Seleccionar_6_Pokemons_Iniciales(6);

        jugador2.Seleccionar_6_Pokemons_Iniciales(1);
        jugador2.Seleccionar_6_Pokemons_Iniciales(2);
        jugador2.Seleccionar_6_Pokemons_Iniciales(3);
        jugador2.Seleccionar_6_Pokemons_Iniciales(4);
        jugador2.Seleccionar_6_Pokemons_Iniciales(5);
        jugador2.Seleccionar_6_Pokemons_Iniciales(6);

        List<Pokemon> ListaBerna = new List<Pokemon>();
        ListaBerna.Add(jugador.ListPokemons[0].Tipo.Ataques);
        ListaBerna.Add(jugador.ListPokemons[1].Tipo.Ataques);
        ListaBerna.Add(jugador.ListPokemons[2].Tipo.Ataques);
        ListaBerna.Add(jugador.ListPokemons[3].Tipo.Ataques);
        ListaBerna.Add(jugador.ListPokemons[4].Tipo.Ataques);
        ListaBerna.Add(jugador.ListPokemons[5].Tipo.Ataques);

        List<Pokemon> ListaPepe = new List<Pokemon>();
        ListaPepe.Add(jugador2.ListPokemons[0].Tipo.Ataques);
        ListaPepe.Add(jugador2.ListPokemons[1].Tipo.Ataques);
        ListaPepe.Add(jugador2.ListPokemons[2].Tipo.Ataques);
        ListaPepe.Add(jugador2.ListPokemons[3].Tipo.Ataques);
        ListaPepe.Add(jugador2.ListPokemons[4].Tipo.Ataques);
        ListaPepe.Add(jugador2.ListPokemons[5].Tipo.Ataques);

        foreach (var i in ListaBerna)
        {
            if (i.Tipo > ListaPepe[0].Tipo);
            {
                (Console.WriteLine($"{i} es efectivo contra {ListaPepe[0]}");
            }
            if (i.Tipo > ListaPepe[1].Tipo);
            {
                Console.WriteLine($"{i} es efectivo contra {ListaPepe[1]}");
            }
            if (i.Tipo > ListaPepe[2].Tipo);
            {
                Console.WriteLine($"{i} es efectivo contra {ListaPepe[2]}");
            }
            if (i.Tipo > ListaPepe[3].Tipo);
            {
                Console.WriteLine($"{i} es efectivo contra {ListaPepe[3]}");
            }
            if (i.Tipo > ListaPepe[4].Tipo);
            {
                Console.WriteLine($"{i} es efectivo contra {ListaPepe[4]}");
            }
            if (i.Tipo > ListaPepe[5].Tipo);
            {
                Console.WriteLine($"{i} es efectivo contra {ListaPepe[5]}");
            }
        }
        
        foreach (var i in ListaPepe)
        {
            if (i.Tipo > ListaBerna[0].Tipo);
            {
                Console.WriteLine($"{i} es efectivo contra {ListaBerna[0]}");
            }
            
            if (i.Tipo > ListaBerna[1].Tipo);
            {
                Console.WriteLine($"{i} es efectivo contra {ListaBerna[1]}");
            }
            if (i.Tipo > ListaBerna[2].Tipo);
            {
                Console.WriteLine($"{i} es efectivo contra {ListaBerna[2]}");
            }
            if (i.Tipo > ListaBerna[3].Tipo);
            {
                Console.WriteLine($"{i} es efectivo contra {ListaBerna[3]}");
            }
            if (i.Tipo > ListaBerna[4].Tipo);
            {
                Console.WriteLine($"{i} es efectivo contra {ListaBerna[4]}");
            }
            if (i.Tipo > ListaBerna[5].Tipo);
            {
                Console.WriteLine($"{i} es efectivo contra {ListaBerna[5]}");
            }
        }
    }

    [Test]
    public void Saber_tipo_rival_activo_y_que_ataques_de_mi_equipo_son_mas_efectivos();
    

    [Test]
    public void Cuantos_ataques_efectivo_tiene_cada_pokemon_activo_de_mi_equipo_frente_al_rival();

    [Test]
    public void Pokemon_de_mi_equipo_con_mas_chances_de_ganar();
}