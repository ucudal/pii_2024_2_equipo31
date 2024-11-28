using NUnit.Framework;
namespace Library.Tests;


[TestFixture]
public class HistoriaDeUsuarioProyecto
{
    private double EsEfectivo(string tipo_Ataque, string tipo_Oponente, double dañoNormalmente)
    {
        double dañoModificado = 1.0;

        if (tipo_Ataque == "Agua")
        {
            if (tipo_Oponente == "Fuego" || tipo_Oponente == "Roca" || tipo_Oponente == "Tierra" || tipo_Oponente == "Hielo")
            {
                dañoModificado *= 2;
            }
            else if (tipo_Oponente == "Hierba" || tipo_Oponente == "Eléctrico")
            {
                dañoModificado *= 0.5;
            }
        }
        else if (tipo_Ataque == "Fuego")
        {
            if (tipo_Oponente == "Hierba" || tipo_Oponente == "Bicho" || tipo_Oponente == "Hielo" || tipo_Oponente == "Acero")
            {
                dañoModificado *= 2;
            }
            else if (tipo_Oponente == "Agua" || tipo_Oponente == "Roca" || tipo_Oponente == "Dragón")
            {
                dañoModificado *= 0.5;
            }
        }
        else if (tipo_Ataque == "Fantasma")
        {
            if (tipo_Oponente == "Fantasma" || tipo_Oponente == "Psíquico")
            {
                dañoModificado *= 2;
            }
            else if (tipo_Oponente == "Hielo")
            {
                dañoModificado = dañoModificado;
            }
            else if (tipo_Oponente == "Siniestro")
            {
                dañoModificado *= 0.5;
            }
        }
        else if (tipo_Ataque == "Hierba")
        {
            if (tipo_Oponente == "Agua" || tipo_Oponente == "Tierra" || tipo_Oponente == "Roca")
            {
                dañoModificado *= 2;
            }
            else if (tipo_Oponente == "Fuego" || tipo_Oponente == "Hielo" || tipo_Oponente == "Veneno" || tipo_Oponente == "Volador" || tipo_Oponente == "Bicho")
            {
                dañoModificado *= 0.5;
            }
        }
        else if (tipo_Ataque == "Hielo")
        {
            if (tipo_Oponente == "Hierba" || tipo_Oponente == "Tierra" || tipo_Oponente == "Dragón" || tipo_Oponente == "Volador")
            {
                dañoModificado *= 2;
            }
            else if (tipo_Oponente == "Fuego" || tipo_Oponente == "Lucha" || tipo_Oponente == "Roca" || tipo_Oponente == "Acero")
            {
                dañoModificado *= 0.5;
            }
        }

        return dañoNormalmente * dañoModificado;
    }

    //Suponiendo que tengo 2 tipo fuego, 1 tipo fantasma, 1 tipo hierba, 1 tipo hielo y 1 tipo agua y el
    //rival tiene activo un tipo hielo:
    
    [Test]
    public void TestFuego_Hielo()
    {
        Assert.AreEqual(200, EsEfectivo("Fuego", "Hielo", 100));
    }

    [Test]
    public void TestFantasmaHielo()
    {
        Assert.AreEqual(100, EsEfectivo("Fantasma", "Hielo", 100));
    }

    [Test]
    public void TestHieba_Hielo()
    {
        Assert.AreEqual(50, EsEfectivo("Hierba", "Hielo", 100));
    }

    [Test]
    public void TestHielo_Hielo()
    {
        Assert.AreEqual(100, EsEfectivo("Hielo", "Hielo", 100));
    }

    [Test]
    public void TestAgua_Hielo()
    {
        Assert.AreEqual(200, EsEfectivo("Agua", "Hielo", 100));
    }
}
