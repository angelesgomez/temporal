using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego;

public interface IInputValues {
    string? leerEntrada();
    ConsoleKeyInfo leerTecla();
    void limpiarConsola();
}


public class InputValues 
 {
    public string? leerEntrada()
    {
        return Console.ReadLine();
    }

    public void limpiarConsola()
    {
        Console.Clear();
    }

    public ConsoleKeyInfo leerTecla()
    {
        return Console.ReadKey();
    }
}
