using System;

namespace ArbolBinarioLibros
{
    public class ArbolBinario
    {
        private Nodo raiz;

        public void Insertar(Libro libro)
        {
            raiz = Insertar(raiz, libro);
        }

        private Nodo Insertar(Nodo nodo, Libro libro)
        {
            if (nodo == null)
            {
                return new Nodo(libro);
            }

            if (string.Compare(libro.ISBN, nodo.Libro.ISBN) < 0)
            {
                nodo.Izquierdo = Insertar(nodo.Izquierdo, libro);
            }
            else if (string.Compare(libro.ISBN, nodo.Libro.ISBN) > 0)
            {
                nodo.Derecho = Insertar(nodo.Derecho, libro);
            }

            return nodo;
        }

        public Nodo Buscar(string isbn)
        {
            return Buscar(raiz, isbn);
        }

        private Nodo Buscar(Nodo nodo, string isbn)
        {
            if (nodo == null || nodo.Libro.ISBN == isbn)
            {
                return nodo;
            }

            if (string.Compare(isbn, nodo.Libro.ISBN) < 0)
            {
                return Buscar(nodo.Izquierdo, isbn);
            }
            else
            {
                return Buscar(nodo.Derecho, isbn);
            }
        }

        public bool Eliminar(string isbn)
        {
            if (Buscar(isbn) != null)
            {
                raiz = Eliminar(raiz, isbn);
                return true;
            }
            return false;
        }

        private Nodo Eliminar(Nodo nodo, string isbn)
        {
            if (nodo == null) return null;

            if (string.Compare(isbn, nodo.Libro.ISBN) < 0)
            {
                nodo.Izquierdo = Eliminar(nodo.Izquierdo, isbn);
            }
            else if (string.Compare(isbn, nodo.Libro.ISBN) > 0)
            {
                nodo.Derecho = Eliminar(nodo.Derecho, isbn);
            }
            else
            {
                // Nodo a eliminar encontrado
                if (nodo.Izquierdo == null) return nodo.Derecho;
                if (nodo.Derecho == null) return nodo.Izquierdo;

                // Nodo con dos hijos: obtener el menor de los mayores
                nodo.Libro = Minimo(nodo.Derecho);
                nodo.Derecho = Eliminar(nodo.Derecho, nodo.Libro.ISBN);
            }

            return nodo;
        }

        private string Minimo(Nodo nodo)
        {
            while (nodo.Izquierdo != null)
            {
                nodo = nodo.Izquierdo;
            }
            return nodo.Libro.ISBN;
        }

        public void MostrarArbol()
        {
            MostrarArbol(raiz);
        }

        private void MostrarArbol(Nodo nodo)
        {
            if (nodo != null)
            {
                MostrarArbol(nodo.Izquierdo);
                Console.WriteLine(nodo.Libro.ISBN);
                MostrarArbol(nodo.Derecho);
            }
        }
    }
}