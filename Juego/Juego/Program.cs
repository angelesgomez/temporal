using System.Security.Cryptography.X509Certificates;

namespace Juego;

class Program
{
    static void Main(string[] args)
    {

        IJuegoAdivinanza juego = new JuegoAdivinanza();
        juego.iniciarJuego();

    }


}