namespace ArbolesBinarios
{
    public class Nodo
    {
        private int dato;
        private Nodo hijoIzquierdo;
        private Nodo hijoDerecho;

        public int Dato { get => dato; set => dato = value; }
        public Nodo HijoIzquierdo { get => hijoIzquierdo; set => hijoIzquierdo = value; }
        public Nodo HijoDerecho { get => hijoDerecho; set => hijoDerecho = value; }

        public Nodo(int dato, Nodo hijoIzquierdo = null, Nodo hijoDerecho = null)
        {
            this.dato = dato;
            this.hijoIzquierdo = hijoIzquierdo;
            this.hijoDerecho = hijoDerecho;
        }
    }
}
