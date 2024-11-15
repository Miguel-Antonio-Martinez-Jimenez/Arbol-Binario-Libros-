using System;

namespace ArbolBinarioLibros
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArbolBinario arbol = new ArbolBinario();

            // Agregar 20 libros de ejemplo
            for (int i = 1; i <= 20; i++)
            {
                Libro libro = new Libro
                {
                    ISBN = "ISBN" + i.ToString(),
                    Titulo = "Titulo" + i.ToString(),
                    Autor = "Autor" + i.ToString(),
                    Genero = "Genero" + i.ToString()
                };
                arbol.Insertar(libro);
            }

            int opcion;
            do
            {
                Console.WriteLine("----- Menú de opciones -----");
                Console.WriteLine("1. Ingresar Libro");
                Console.WriteLine("2. Buscar Libro Por Su ISBN");
                Console.WriteLine("3. Eliminar Libro Por Su ISBN");
                Console.WriteLine("4. Mostrar todos los ISBN de libros existentes en forma de árbol binario de búsqueda");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese ISBN: ");
                        string isbn = Console.ReadLine();
                        Console.Write("Ingrese Titulo: ");
                        string titulo = Console.ReadLine();
                        Console.Write("Ingrese Autor: ");
                        string autor = Console.ReadLine();
                        Console.Write("Ingrese Genero: ");
                        string genero = Console.ReadLine();
                        
                        arbol.Insertar(new Libro { ISBN = isbn, Titulo = titulo, Autor = autor, Genero = genero });
                        Console.WriteLine("Libro ingresado exitosamente.");
                        break;

                    case 2:
                        Console.Write("Ingrese ISBN a buscar: ");
                        string isbnBuscar = Console.ReadLine();
                        var libroEncontrado = arbol.Buscar(isbnBuscar);
                        if (libroEncontrado != null)
                        {
                            Console.WriteLine($"Libro encontrado: {libroEncontrado.Libro.Titulo} por {libroEncontrado.Libro.Autor}");
                        }
                        else
                        {
                            Console.WriteLine("Libro no encontrado.");
                        }
                        break;

                    case 3:
                        Console.Write("Ingrese ISBN a eliminar: ");
                        string isbnEliminar = Console.ReadLine();
                        if (arbol.Eliminar(isbnEliminar))
                        {
                            Console.WriteLine("Libro eliminado exitosamente.");
                        }
                        else
                        {
                            Console.WriteLine("Libro no encontrado para eliminar.");
                        }
                        break;

                    case 4:
                        Console.WriteLine("----- Lista de ISBN en el árbol binario -----");
                        arbol.MostrarArbol();
                        Console.WriteLine("--------------------------------------------");
                        break;

                    case 5:
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    default:
                        Console.WriteLine("Opción inválida. Por favor, intente nuevamente.");
                        break;
                }

            } while (opcion != 5);
        }
    }
}
