using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ArraysWithPointers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Defina el tamaño de la matriz");
            Console.WriteLine("Filas: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Columnas: ");
            int m = int.Parse(Console.ReadLine());
            Matriz matriz = new Matriz(n, m);
            Console.WriteLine("Ingrese los valores de la matriz");
            bool flag = true;
            while (flag)
            {
                try
                {
                    Console.Clear();
                    matriz.print();
                    //Elija una accion
                    Console.WriteLine("1. Agregar un valor");
                    Console.WriteLine("2. Eliminar un valor");
                    Console.WriteLine("3. Multiplicar Elimentos x N");
                    Console.WriteLine("4. Salir");
                    int option = int.Parse(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            addValue(matriz);
                            break;
                        case 2:
                            deleteValue(matriz);
                            break;
                        case 3:
                            throw new NotImplementedException();
                        case 4:
                            flag = false;
                            break;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Presione una tecla para continuar");
                    Console.ReadKey();
                }
            }
        }
        static void addValue(Matriz matriz)
        {
            int n = matriz.n;
            int m = matriz.m;
            Console.Clear();
            Console.WriteLine($"Matriz actual {n}x{m}");
            matriz.print();
            Console.WriteLine($"Ingrese el valor de la fila de 1 a {n}");
            int i = int.Parse(Console.ReadLine());
            Console.WriteLine($"Ingrese el valor de la columna de 1 a {m}");
            int j = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el valor");
            int value = int.Parse(Console.ReadLine());
            matriz.Add(i, j, value);
        }
        static void deleteValue(Matriz matriz)
        {
            int n = matriz.n;
            int m = matriz.m;
            Console.Clear();
            Console.WriteLine($"Matriz actual {n}x{m}");
            matriz.print();
            Console.WriteLine($"Ingrese el valor de la fila de 1 a {n}");
            int i = int.Parse(Console.ReadLine());
            Console.WriteLine($"Ingrese el valor de la columna de 1 a {m}");
            int j = int.Parse(Console.ReadLine());
            matriz.Delete(i, j);
        }
    }



    //    unsafe estructura que simula un nodo de un diccionario

    unsafe public struct Nodo<T> : IComparable<T>

    {
        public int key;
        public T value;
        public Nodo<T>* next;
        public int CompareTo(T other)
        {
            return Comparer<T>.Default.Compare(this.value, other);
        }

    }

    //    unsafe estructura que simula un diccionario
    unsafe public class Diccionario<T> : IComparable<Diccionario<T>>
    {
        public Nodo<T>* head;
        public int CantElementos;
        public Diccionario()

        {
            head = null;
            CantElementos = 0;

        }
        public bool Exists(int key)
        {
            return Get(key) != null;
        }
        public Diccionario<T> Add(int key, T value)
        {
            Nodo<T>* node = Get(key);
            if (node == null)
            {

                Nodo<T>* nuevoNodo = (Nodo<T>*)Marshal.AllocHGlobal(sizeof(Nodo<T>));
                nuevoNodo->key = key;
                nuevoNodo->value = value;
                Nodo<T>* temp = head;
                Nodo<T>* prev = null;
                while (temp != null && Comparer<T>.Default.Compare(temp->value, nuevoNodo->value) < 0)
                {
                    prev = temp;
                    temp = temp->next;
                }
                if (prev == null)
                {
                    head = nuevoNodo;
                }
                else
                {
                    prev->next = nuevoNodo;
                }
                nuevoNodo->next = temp;
                CantElementos++;
            }
            else
            {
                node->value = value;
            }
            return this;
        }
        public Diccionario<T> Delete(int key)
        {
            if (Exists(key))
            {
                Nodo<T>* current = head;
                Nodo<T>* previous = null;
                while (current != null)
                {
                    if (current->key == key)
                    {
                        if (previous == null)
                        {
                            head = current->next;
                        }
                        else
                        {
                            previous->next = current->next;
                        }
                        break;
                    }
                    previous = current;
                    current = current->next;
                }
                CantElementos--;
            }
            return this;
        }

        public Diccionario<T> Set(int key, T value)
        {
            Nodo<T>* node = Get(key);
            if (node != null)
            {
                node->value = value;
            }
            return this;
        }
        public Nodo<T>* Get(int key)
        {
            Nodo<T>* current = head;
            while (current != null)
            {
                if (current->key == key)
                {
                    return current;
                }
                current = current->next;
            }
            return null;
        }
        public int CompareTo(Diccionario<T> other)
        {
            if (head == null && other.head == null)
                return 0;
            if (head == null)
                return -1;
            if (other.head == null)
                return 1;
            // Comparar según la clave del primer nodo
            return head->key.CompareTo(other.head->key);
        }
    }
    unsafe public class Matriz
    {
        public int n, m;
        private Diccionario<Diccionario<int>> matriz;
        public Matriz(int n, int m)
        {
            this.n = n;
            this.m = m;
            matriz = new Diccionario<Diccionario<int>>();
        }
        public Matriz Add(int i, int j, int value)
        {
            i--;
            j--;
            if (i >= 0 && i < n && j >= 0 && j < m)
            {
                if (!matriz.Exists(i))
                {
                    matriz.Add(i, new Diccionario<int>());
                }
                matriz.Get(i)->value.Add(j, value);
                return this;
            }
            else
            {
                throw new Exception("Index out of range");
            }
        }
        public int? Get(int i, int j)
        {
            if (i >= 0 && i < n && j >= 0 && j < m)
            {
                if (matriz.Exists(i))
                {
                    if (matriz.Get(i)->value.Exists(j))
                    {
                        return matriz.Get(i)->value.Get(j)->value;
                    }
                }
                return null;
            }
            else
            {
                throw new Exception("Index out of range");
            }
        }
        public void print()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    string value = Get(i, j)?.ToString();
                    if (value == null)
                    {
                        value = " ";
                    }
                    Console.Write(value + " - ");
                }
                Console.WriteLine();
            }
        }
        public Matriz Delete(int i, int j)
        {
            i--;
            j--;
            if (i >= 0 && i < n && j >= 0 && j < m)
            {
                if (matriz.Exists(i))
                {
                    if (matriz.Get(i)->value.Exists(j))
                    {
                        matriz.Get(i)->value.Delete(j);
                    }

                }
                return this;
            }
            else
            {
                throw new Exception("Index out of range");
            }
        }
    }
}