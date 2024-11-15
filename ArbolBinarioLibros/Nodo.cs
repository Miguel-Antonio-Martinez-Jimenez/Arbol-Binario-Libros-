namespace ArbolBinarioLibros
{
    public class Nodo
    {
        public Libro Libro { get; set; }
        public Nodo Izquierdo { get; set; }
        public Nodo Derecho { get; set; }

        public Nodo(Libro libro)
        {
            Libro = libro;
            Izquierdo = null;
            Derecho = null;
        }
    }
}