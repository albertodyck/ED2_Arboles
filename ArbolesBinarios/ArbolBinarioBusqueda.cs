using System;
using System.Collections.Generic;
using System.Text;

namespace ArbolesBinarios
{
    public class ArbolBinarioBusqueda
    {
        private readonly Nodo raiz;

        public Nodo Raiz => raiz;

        public ArbolBinarioBusqueda(int dato)
        {
            this.raiz = new Nodo(dato);
        }

        public enum TipoRecorrido
        {
            Preorden,
            Inorden,
            Posorden
        }

        public void InsertarNodo(int dato, Nodo nodo = null)
        {
            nodo ??= this.raiz;

            if (dato > nodo.Dato)
            {
                nodo.HijoDerecho ??= new Nodo(dato);
                InsertarNodo(dato, nodo.HijoDerecho);
            }
            else if (dato < nodo.Dato)
            {
                nodo.HijoIzquierdo ??= new Nodo(dato);
                InsertarNodo(dato, nodo.HijoIzquierdo);
            }
        }

        public string ObtenerArbol(Nodo nodo = null)
        {
            nodo ??= this.raiz;
            string datos = string.Empty;
            RecorrerArbol(nodo, ref datos);
            return datos;
        }

        private void RecorrerArbol(Nodo nodo, ref string datos)
        {
            if (nodo != null)
            {
                string raiz = (datos == string.Empty) ? "Raiz" : string.Empty;
                datos += $"{raiz}{nodo.Dato,5}\n";

                if (nodo.HijoIzquierdo != null)
                {
                    datos += $"{nodo.Dato,-5}< ";
                    RecorrerArbol(nodo.HijoIzquierdo, ref datos);
                }

                if (nodo.HijoDerecho != null)
                {
                    datos += $"{nodo.Dato,-5}> ";
                    RecorrerArbol(nodo.HijoDerecho, ref datos);
                }
            }
        }

        public string Recorrido(Nodo nodo = null, TipoRecorrido tipoRecorrido = TipoRecorrido.Preorden)
        {
            nodo ??= this.raiz;
            string datos = string.Empty;
            switch (tipoRecorrido)
            {
                case TipoRecorrido.Preorden:
                    RecorridoPreorden(nodo, ref datos);
                    break;
                case TipoRecorrido.Inorden:
                    RecorridoInorden(nodo, ref datos);
                    break;
                case TipoRecorrido.Posorden:
                    RecorridoPosorden(nodo, ref datos);
                    break;
            }
            return $"{tipoRecorrido}: {datos}";
        }

        private void RecorridoPreorden(Nodo nodo, ref string datos)
        {
            if (nodo != null)
            {
                AgregarDato(nodo, ref datos);

                if (nodo.HijoIzquierdo != null)
                {
                    RecorridoPreorden(nodo.HijoIzquierdo, ref datos);
                }

                if (nodo.HijoDerecho != null)
                {
                    RecorridoPreorden(nodo.HijoDerecho, ref datos);
                }
            }
        }

        private void RecorridoInorden(Nodo nodo, ref string datos)
        {
            if (nodo != null)
            {
                if (nodo.HijoIzquierdo != null)
                {
                    RecorridoInorden(nodo.HijoIzquierdo, ref datos);
                }

                AgregarDato(nodo, ref datos);

                if (nodo.HijoDerecho != null)
                {
                    RecorridoInorden(nodo.HijoDerecho, ref datos);
                }
            }
        }

        private void RecorridoPosorden(Nodo nodo, ref string datos)
        {
            if (nodo != null)
            {
                if (nodo.HijoIzquierdo != null)
                {
                    RecorridoPosorden(nodo.HijoIzquierdo, ref datos);
                }

                if (nodo.HijoDerecho != null)
                {
                    RecorridoPosorden(nodo.HijoDerecho, ref datos);
                }

                AgregarDato(nodo, ref datos);
            }
        }

        private void AgregarDato(Nodo nodo, ref string datos)
        {
            string coma = (datos == string.Empty) ? string.Empty : ",";
            datos += $"{coma}{nodo.Dato}";
        }

        public void EliminarDato(int dato, Nodo nodo = null, Nodo nodoPadre = null)
        {
            nodo ??= this.raiz;

            if (dato < nodo.Dato)
            {
                EliminarDato(dato, nodo.HijoIzquierdo, nodo);
            }
            else if (dato > nodo.Dato)
            {
                EliminarDato(dato, nodo.HijoDerecho, nodo);
            }
            else
            {
                if (nodo.HijoIzquierdo == null && nodo.HijoDerecho == null)
                {
                    if (nodoPadre == null)
                    {
                        nodo = null;
                    }
                    else
                    {
                        if (nodo.Dato > nodoPadre.Dato)
                        {
                            nodoPadre.HijoDerecho = null;
                        }
                        else
                        {
                            nodoPadre.HijoIzquierdo = null;
                        }
                    }
                }
                else if (nodo.HijoIzquierdo == null && nodo.HijoDerecho != null)
                {
                    //tenemos solo hijo derecho, se debe sustituir por el descendiente
                    if (nodo.Dato > nodoPadre.Dato)
                    {
                        nodoPadre.HijoDerecho = nodo.HijoDerecho;
                    }
                    else
                    {
                        nodoPadre.HijoIzquierdo = nodo.HijoDerecho;
                    }
                }
                else if (nodo.HijoIzquierdo != null && nodo.HijoDerecho == null)
                {
                    //tenemos hijo izquierdo
                    if (nodo.Dato < nodoPadre.Dato)
                    {
                        nodoPadre.HijoIzquierdo = nodo.HijoIzquierdo;
                    }
                    else
                    {
                        nodoPadre.HijoDerecho = nodo.HijoIzquierdo;
                    }
                }
                else
                {
                    //nodo izquiero != null nodo hijo derecho != null
                    
                    Nodo nodoDerecha = RecorrerDerecha(nodo.HijoIzquierdo);

                    //nodoDerecha.HijoIzquierdo = nodo.HijoIzquierdo;

                    nodoDerecha.HijoDerecho = nodo.HijoDerecho;

                    nodoPadre.HijoDerecho = nodoDerecha;

                    //nodo = nodoDerecha;

                    //nodoPadre.HijoDerecho = null;
                }
            }
        }

        private Nodo RecorrerDerecha(Nodo nodo)
        {

            if (nodo != null)
            {
                if (nodo.HijoDerecho != null)
                {
                    RecorrerDerecha(nodo.HijoDerecho);
                }
            }
            return nodo;
        }

    }

}