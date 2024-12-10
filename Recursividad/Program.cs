using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursividad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int n;
            // preguntar al usuario si quiere ingresar el tamaño del vector
            Console.WriteLine("Desea ingresar el tamaño del vector? 1 = si, 2 = no");
            n = int.Parse(Console.ReadKey(true).KeyChar.ToString());
            if (n == 1)
            {
                Console.WriteLine("Ingrese el tamaño del vector");
                n = int.Parse(Console.ReadLine());
            }
            else
            {
                n = r.Next(10, 100);
            }
            int[] vector = new int[n];
            GenerarVector(vector, 0, r);
            PrintVector(vector);
            Console.WriteLine();
            Console.WriteLine("El minimo es : " + MinVector(vector));
            Console.WriteLine("El maximo es : " + MaxVector(vector));
            Console.WriteLine("La sumatoria es : " + SumatoriaVector(vector));
            Console.WriteLine("El promedio es : " + PromedioVector(vector));
            Console.ReadKey(false);
        }
        // hacer un programa para cargar elementos aleatorios a un vector 
        public static void GenerarVector(int[] vector, int indice = 0, Random r = null)
        {
            if (indice == vector.Length)
            {
                return;
            }


            vector[indice] = r.Next(0, 100);

            GenerarVector(vector, indice + 1, r);
        }
        public static void PrintVector(int[] vector, int indice = 0)
        {
            if (indice == vector.Length)
            {
                return;
            }
            if (indice == 0)
            {
                Console.Write($"Vector({vector.Length}) : ");
            }
            Console.Write(vector[indice] + " ");
            PrintVector(vector, indice + 1);

        }
        public static int MinVector(int[] vector, int indice = 0)
        {
            if (indice == vector.Length - 1)
            {
                return vector[indice];
            }
            int min = MinVector(vector, indice + 1);
            if (vector[indice] < min)
            {
                return vector[indice];
            }
            else
            {
                return min;
            }

        }
        public static int MaxVector(int[] vector, int indice = 0)
        {
            if (indice == vector.Length - 1)
            {
                return vector[indice];
            }
            int max = MaxVector(vector, indice + 1);
            if (vector[indice] > max)
            {
                return vector[indice];
            }
            else
            {
                return max;
            }
        }
        public static int SumatoriaVector(int[] vector, int indice = 0)
        {
            if (indice == vector.Length - 1)
            {
                return vector[indice];
            }
            return vector[indice] + SumatoriaVector(vector, indice + 1);
        }
        public static double PromedioVector(int[] vector, int indice = 0, int suma = 0)
        {
            if (indice == vector.Length)
            {
                return (double)suma / vector.Length;
            }

            suma += vector[indice];
            return PromedioVector(vector, indice + 1, suma);
        }

    }
}
