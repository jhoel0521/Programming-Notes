using System;
using System.Collections.Generic;

namespace ArbolBinario
{
    class Program
    {
        static void Main()
        {
            // Crear una instancia del árbol binario
            var arbol = new ArbolBinario<int>();
            arbol.Insertar(45);
            arbol.Insertar(20);
            arbol.Insertar(10);
            arbol.Insertar(30);
            arbol.Insertar(60);
            arbol.Insertar(50);
            arbol.Insertar(70);
            arbol.Insertar(48);
            arbol.Insertar(55);
            arbol.Insertar(52);
            int opcion;
            do
            {
                Console.Clear();

                // Mostrar los recorridos
                Console.WriteLine("\nRecorridos del árbol:");
                Console.WriteLine("InOrden: " + string.Join(", ", arbol.RecorrerEnOrden()));
                Console.WriteLine("PreOrden: " + string.Join(", ", arbol.RecorrerPreOrden()));
                Console.WriteLine("PostOrden: " + string.Join(", ", arbol.RecorrerPostOrden()));
                Console.WriteLine("Por Nivel: " + string.Join(", ", arbol.RecorrerPorNivel()));
                Console.WriteLine("Cantidad Nodo : " + arbol.CantidadNodo());
                Console.WriteLine("Cantidad Niveles : " + arbol.CantidadNiveles());



                // Imprimir el árbol visualmente
                Console.WriteLine("\nÁrbol en formato visual:");
                arbol.PrintComoArbol();

                // Mostrar el menú
                Console.WriteLine("\nMenú:");
                Console.WriteLine("1. Insertar Elemento");
                Console.WriteLine("2. Eliminar Elemento");
                Console.WriteLine("3. Eliminar todos los elementos");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");

                // Leer la opción del usuario
                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.Write("Ingrese el elemento a insertar: ");
                            if (int.TryParse(Console.ReadLine(), out int valorInsertar))
                            {
                                arbol.Insertar(valorInsertar);
                                Console.WriteLine("Elemento insertado correctamente.");
                            }
                            else
                            {
                                Console.WriteLine("Entrada inválida. Intente nuevamente.");
                            }
                            break;

                        case 2:
                            Console.Write("Ingrese el elemento a eliminar: ");
                            if (int.TryParse(Console.ReadLine(), out int valorEliminar))
                            {
                                arbol.Eliminar(valorEliminar);
                                Console.WriteLine("Elemento eliminado correctamente (si existía).");
                            }
                            else
                            {
                                Console.WriteLine("Entrada inválida. Intente nuevamente.");
                            }
                            break;

                        case 3:
                            arbol.EliminarTodos();
                            Console.WriteLine("Todos los elementos han sido eliminados.");
                            break;

                        case 4:
                            Console.WriteLine("Saliendo del programa...");
                            break;

                        default:
                            Console.WriteLine("Opción no válida. Intente nuevamente.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Por favor, ingrese un número.");
                }



            } while (opcion != 4);

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey(true);
        }
    }
}