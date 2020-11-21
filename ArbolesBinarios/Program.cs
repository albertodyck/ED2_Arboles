using System;

namespace ArbolesBinarios
{
    class Program
    {
        static void Main(string[] args)
        {
            ArbolBinarioBusqueda arbol = new ArbolBinarioBusqueda(80);
            //arbol.InsertarNodo(150);
            //arbol.InsertarNodo(300);
            arbol.InsertarNodo(5);
            //arbol.InsertarNodo(90);
            arbol.InsertarNodo(81);
            //arbol.InsertarNodo(82);
            arbol.InsertarNodo(30);
            arbol.InsertarNodo(50);
            //arbol.InsertarNodo(5);
            arbol.InsertarNodo(74);



            Console.Write(arbol.ObtenerArbol());

            Console.WriteLine("");
            Console.WriteLine("--------Recorridos-------");
            Console.WriteLine(arbol.Recorrido());
            Console.WriteLine(arbol.Recorrido(tipoRecorrido: ArbolBinarioBusqueda.TipoRecorrido.Inorden));
            Console.WriteLine(arbol.Recorrido(null, ArbolBinarioBusqueda.TipoRecorrido.Posorden));
        }
    }
}
