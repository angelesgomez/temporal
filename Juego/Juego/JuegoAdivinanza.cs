using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego;

public interface IJuegoAdivinanza 
{
    void iniciarJuego();
    int generarNumeroAleatorio(int numIngresado);
}
public class JuegoAdivinanza : IJuegoAdivinanza
{
    enum TipoIntento { Ardiente, Caliente, Tibio, Frìo, Helado };
    public void iniciarJuego()
    {
        Console.WriteLine("¡Hola! Ingrese un numero máximo para comenzar:");
        int numMaximo = int.Parse(Console.ReadLine());

        int numGenerado = generarNumeroAleatorio(numMaximo);
        mostrarMensajeNumeroGenerado();
        verificarNumeroIngresado(numMaximo, numGenerado);
    }

    public void verificarNumeroIngresado(int numMaximo, int numGenerado)
    {
        int numIngresado;
        int cantIntentos = 0;

        do
        {

            Console.WriteLine("Ingrese un nuevo número:");
            numIngresado = int.Parse(Console.ReadLine());
            Console.Clear();

            double porcNroIngresado = calcularPorcentaje(numIngresado, numMaximo);
            double porcNroGenerado = calcularPorcentaje(numGenerado, numMaximo);

            double resDiferencia = calcularDiferencia(porcNroIngresado, porcNroGenerado);

            if (resDiferencia >= calcularPorcentajePredeterminado(numMaximo, 0.01)
              && resDiferencia <= calcularPorcentajePredeterminado(numMaximo, 0.1))
            {
                Console.WriteLine("Ardiente");
                ++cantIntentos;
            }

            if (resDiferencia >= calcularPorcentajePredeterminado(numMaximo, 0.1)
                && resDiferencia <= calcularPorcentajePredeterminado(numMaximo, 0.3))
            {
                Console.WriteLine("Caliente");
                ++cantIntentos;
            }
            
            if(resDiferencia >= calcularPorcentajePredeterminado(numMaximo, 0.3)
                && resDiferencia <= calcularPorcentajePredeterminado(numMaximo, 0.6))
            {
                Console.WriteLine("Tibio");
                ++cantIntentos;
            }
            
            if (resDiferencia >= calcularPorcentajePredeterminado(numMaximo, 0.6)
                && resDiferencia <= calcularPorcentajePredeterminado(numMaximo, 0.9))
            {
                Console.WriteLine("Frío");
                ++cantIntentos;
            }
            
            if (resDiferencia >= calcularPorcentajePredeterminado(numMaximo, 0.9)
                && resDiferencia <= calcularPorcentajePredeterminado(numMaximo, 0.99))
            {
                Console.WriteLine("Helado");
                ++cantIntentos;
            }

        } while (numIngresado != numGenerado);

        if (numIngresado == numGenerado)
        {
            ++cantIntentos;
            Console.WriteLine($"¡Muy bien ha adivinado! El número elegido era el {numIngresado}");
            Console.WriteLine($"Lo ha adivinado en {cantIntentos} intentos :)");
            Console.ReadKey();
        }
   
    }

    public int generarNumeroAleatorio(int numIngresado)
    {
        int min = 1;
        int max = numIngresado;

        Random rnd = new Random();
        int numGenerado = rnd.Next(min, max + 1);

        return numGenerado;
    }

    public void mostrarMensajeNumeroGenerado()
    {
        Console.WriteLine("Ya elegí un número. Adivinalo...");
    }

    public double calcularPorcentaje (int num, int numMaximo)
    {
        double resultado = (num*100)/numMaximo;
        return resultado;
    }

    public double calcularDiferencia (double porcNroIngresado, double porcNroGenerado )
    {
        double resDiferencia;

        if(porcNroGenerado < porcNroIngresado)
        {
            resDiferencia = porcNroIngresado - porcNroGenerado;
        } else
        {
            resDiferencia = porcNroGenerado - porcNroIngresado;
        }
        return resDiferencia;
    }

    public double calcularPorcentajePredeterminado (int numMaximo, double porcPredeterminado)
    {
        double resNivel;
        resNivel = numMaximo * porcPredeterminado;
        return resNivel;
    }

}
