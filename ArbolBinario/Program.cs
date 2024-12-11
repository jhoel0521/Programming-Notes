using System;
using System.Collections.Generic;

namespace ArbolBinario
{
    unsafe class Program
    {
        static void Main(string[] args)
        {
            // Crear una instancia del árbol binario
            var arbol = new ArbolBinario<int>();

            // Insertar valores
            Console.WriteLine("Insertando valores en el árbol...");
            arbol.Insertar(10);
            arbol.Insertar(5);
            arbol.Insertar(15);
            arbol.Insertar(3);
            arbol.Insertar(7);

            // Verificar si contiene ciertos valores
            Console.WriteLine("\nVerificando si ciertos valores están en el árbol:");
            Console.WriteLine($"¿Contiene 7? {arbol.Contiene(7)}"); // True
            Console.WriteLine($"¿Contiene 20? {arbol.Contiene(20)}"); // False

            // Recorridos
            Console.WriteLine("\nRecorridos del árbol:");
            Console.WriteLine("InOrden: " + string.Join(", ", arbol.RecorrerEnOrden())); // 3, 5, 7, 10, 15
            Console.WriteLine("PreOrden: " + string.Join(", ", arbol.RecorrerPreOrden())); // 10, 5, 3, 7, 15
            Console.WriteLine("PostOrden: " + string.Join(", ", arbol.RecorrerPostOrden())); // 3, 7, 5, 15, 10

            // Imprimir el árbol visualmente
            Console.WriteLine("\nÁrbol en formato visual:");
            arbol.PrintComoArbol();

            // Usar el método Print con diferentes tipos de recorrido
            Console.WriteLine("\nUsando el método Print para diferentes recorridos:");
            Console.WriteLine("InOrden:");
            arbol.Print(TipoRecorrido.InOrden);

            Console.WriteLine("PreOrden:");
            arbol.Print(TipoRecorrido.PreOrden);

            Console.WriteLine("PostOrden:");
            arbol.Print(TipoRecorrido.PostOrden);

            // Calcular profundidad
            Console.WriteLine($"\nLa profundidad del árbol es: {arbol.Profundidad()}"); // 3
            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey(true);
        }
    }
}
