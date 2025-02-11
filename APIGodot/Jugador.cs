namespace APIGodot;

public class Jugador
{
    public string Nombre;
    public int Nivel;
    public int PuntosDeVida;
    public int PuntosDeAtaque;

    public Jugador(string nombre, int nivel = 1, int puntosDeVida = 100, int puntosDeAtaque = 10)
    {
        Nombre = nombre;
        Nivel = nivel;
        PuntosDeVida = puntosDeVida;
        PuntosDeAtaque = puntosDeAtaque;
    }

    public void Atacar(Enemigo enemigo)
    {
        enemigo.RecibirDaño(PuntosDeAtaque);
    }

    public void RecibirDaño(int cantidad)
    {
        PuntosDeVida -= cantidad;
    }

    public void SubirNivel()
    {
        Nivel++;
        PuntosDeVida += 20;
        PuntosDeAtaque += 5;
    }
}
