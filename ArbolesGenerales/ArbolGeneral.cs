using System;
using System.Collections.Generic;
using System.Text;

namespace ArbolesGenerales
{
    public class ArbolGeneral
    {
        private readonly Nodo raiz;
        public Nodo Raiz => raiz;

        public ArbolGeneral(string dato)
        {
            this.raiz = new Nodo(dato);
        }

        public Nodo InsertarNodo(string dato, Nodo nodoPadre)
        {
            if (nodoPadre == null) 
            {
                throw new Exception($"No se pudo insertar el valor " +
                    $"{dato}, se debe especificar el nodo padre");
            }

            if (nodoPadre.Hijo == null)
            {
                nodoPadre.Hijo = new Nodo(dato);
                return nodoPadre.Hijo;
            }
            else 
            {
                Nodo hijoNodoPadre = nodoPadre.Hijo;
                while(hijoNodoPadre.Hermano != null) 
                {
                    hijoNodoPadre = hijoNodoPadre.Hermano;
                }
                hijoNodoPadre.Hermano = new Nodo(dato);
                return hijoNodoPadre.Hermano;
            }
        }

        public string ObtenerArbol(Nodo nodo = null)
        {
            nodo ??= this.raiz;
            int posicion = 0;
            string datos = string.Empty;

            Recorrer(nodo, ref posicion, ref datos);
            return datos;
        }

        private void Recorrer(Nodo nodo, ref int posicion, ref string datos)
        {
            if (nodo != null)
            {
                datos += $"{nodo.Dato.PadLeft(nodo.Dato.Length + posicion,'-')}\n";

                if (nodo.Hijo != null)
                {
                    posicion++;
                    Recorrer(nodo.Hijo, ref posicion, ref datos);
                    posicion--;
                }

                if (nodo.Hermano != null)
                {
                    Recorrer(nodo.Hermano, ref posicion, ref datos);
                }
            }
        }

        public Nodo Buscar(string dato, Nodo nodoBusqueda = null) 
        {
            nodoBusqueda ??= this.raiz;

            if (nodoBusqueda.Dato.ToUpper() == dato.ToUpper()) 
            {
                return nodoBusqueda;
            }

            if (nodoBusqueda.Hijo != null) 
            {
                Nodo nodoEncontrado = Buscar(dato, nodoBusqueda.Hijo);
                if (nodoEncontrado != null) 
                {
                    return nodoEncontrado;
                }
            }

            if (nodoBusqueda.Hermano != null) 
            {
                Nodo nodoEncontrado = Buscar(dato, nodoBusqueda.Hermano);
                if (nodoEncontrado != null)
                {
                    return nodoEncontrado;
                }
            }

            return null;
        }
    }
}
