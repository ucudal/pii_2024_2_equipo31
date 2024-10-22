namespace Library;

public class Maquina : Jugador
{
    public Maquina(string nombre) : base(nombre)
    {
        Seleccionar_6_Pokemons_Automaticamente();
    }

    private void Seleccionar_6_Pokemons_Automaticamente()
    {
        ListPokemons = new List<Pokemon>
        {
            new Pokemon(1, "Crocalor", 81, 78, "Fuego", new List<IAtaque>
            {
                new AtaqueNormal("Explosion de Fuego", 110, "Fuego"),
                new AtaqueNormal("Colmillo de Fuego", 65, "Fuego"),
                new AtaqueNormal("Carga de Fuego", 50, "Fuego"),
                new AtaqueEspecial(" ⚠ Lanzallamas", 90, 2, "Fuego")
            }),

            new Pokemon(2, "Cacnea", 50, 40, "Hierba", new List<IAtaque>
            {
                new AtaqueNormal("Bola de Energia", 90, "Hierba"),
                new AtaqueNormal("Drenaje", 75, "Hierba"),
                new AtaqueNormal("Nudo de Hierba", 45, "Hierba"),
                new AtaqueEspecial(" ⚠ Tormenta de Hojas", 130, 2, "Hierba")
            }),

            new Pokemon(3, "Dewott", 75, 60, "Agua", new List<IAtaque>
            {
                new AtaqueNormal("Cuchilla de Agua", 70, "Agua"),
                new AtaqueNormal("Chorro de Agua", 40, "Agua"),
                new AtaqueNormal("Marea Alta", 90, "Agua"),
                new AtaqueEspecial(" ⚠ Agua Helada", 50, 2, "Agua")
            }),
            new Pokemon(4, "Gagnar", 60, 60, "Fantasma", new List<IAtaque>
            {
                new AtaqueNormal("Maldicion", 20, "Fantasma"),
                new AtaqueNormal("Vinculo de Destino", 65, "Fantasma"),
                new AtaqueNormal("Mal de Ojo", 65, "Fantasma"),
                new AtaqueEspecial(" ⚠ Sombra Nocturna", 40, 2, "Fantasma")
            }),
            new Pokemon(5, "Mareep", 55, 40, "Electrico", new List<IAtaque>
            {
                new AtaqueNormal("Descarga", 80, "Electrico"),
                new AtaqueNormal("Trueno", 75, "Electrico"),
                new AtaqueNormal("Rayo", 90, "Electrico"),
                new AtaqueEspecial(" ⚠ Choque Relampago", 110, 2, "Electrico")
            }),
            new Pokemon(6, "NosePass", 30, 135, "Roca", new List<IAtaque>
            {
                new AtaqueNormal("Cabezazo", 150, "Roca"),
                new AtaqueNormal("Rayo de Meteorito", 120, "Roca"),
                new AtaqueNormal("Gema de poder", 80, "Roca"),
                new AtaqueEspecial(" ⚠ Explosion de Roca", 25, 2, "Roca")
            })
        };
    }
}