using System;

namespace ArbolesGenerales
{
    class Program
    {
        static void Main(string[] args)
        {
            ArbolGeneral arbol = new ArbolGeneral("A");
            Nodo nodoB = arbol.InsertarNodo("B", arbol.Raiz);
            Nodo nodoD = arbol.InsertarNodo("D", nodoB);
            Nodo nodoI = arbol.InsertarNodo("I", nodoD);
            Nodo nodoE = arbol.InsertarNodo("E", nodoB);
            Nodo nodoF = arbol.InsertarNodo("F", nodoB);
            arbol.InsertarNodo("J", nodoF);
            arbol.InsertarNodo("K", nodoF);

            Nodo nodoC = arbol.InsertarNodo("C", arbol.Raiz);
            Nodo nodoG = arbol.InsertarNodo("G", nodoC);
            Nodo nodoH = arbol.InsertarNodo("H", nodoC);
            arbol.InsertarNodo("L", nodoH);


            Console.WriteLine(arbol.ObtenerArbol());

            Nodo nodoEncontrado = arbol.Buscar("F");
            Console.WriteLine(arbol.ObtenerArbol(nodoEncontrado));
            Console.WriteLine(nodoEncontrado.Dato);
        }
    }
}


