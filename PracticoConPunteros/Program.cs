using System;

namespace PracticoConPunteros
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("Elija un ejercicio:");
                Console.WriteLine("1. Crear un array de tamaño aleatorio y mostrarlo");
                Console.WriteLine("2. Crear una lista de nodos con punteros y mostrarla");
                Console.WriteLine("3. Salir");
                int opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        EjerccioN1();
                        break;
                    case 2:
                        EjerccioN2();
                        break;
                    case 3:
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        // Función para ordenar un array con punteros
        unsafe static void OrdenarArrayWithPointers(int* arr, int length)
        {
            for (int i = 0; i < length; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    if (*(arr + i) > *(arr + j))
                    {
                        int temp = *(arr + i);
                        *(arr + i) = *(arr + j);
                        *(arr + j) = temp;
                    }
                }
            }
        }

        // Ejercicio 1: Crear un array de tamaño aleatorio y mostrarlo
        unsafe public static void EjerccioN1()
        {
            Random r = new Random();
            int n = r.Next(20, 100); // Tamaño aleatorio del array entre 20 y 100
            int[] arr = new int[n];
            Console.WriteLine($"El array tiene un tamaño de {n}");

            // Llenar el array con valores aleatorios
            Console.WriteLine("Array sin ordenar:");
            for (int i = 0; i < n; i++)
            {
                arr[i] = r.Next(1, 100); // Rellenamos el array con valores aleatorios entre 1 y 100
                Console.Write($"{arr[i]}, ");
            }
            Console.WriteLine();

            // Ordenar el array usando punteros
            fixed (int* primerElemento = &arr[0])
            {
                OrdenarArrayWithPointers(primerElemento, n);
            }

            // Imprimir el array ordenado
            Console.WriteLine("Array ordenado:");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{arr[i]}, ");
            }
            Console.WriteLine();
        }

        // Ejercicio 2: Crear una lista de nodos con punteros y mostrarla
        public static void EjerccioN2()
        {
            Console.WriteLine("Cargar ejemplo. (1)");
            Console.WriteLine("Cargar manualmente. (2)");
            int opcion = int.Parse(Console.ReadLine());
            Milist lista = new Milist();
            switch (opcion)
            {
                case 1:
                    lista.Add(215048717, "Jhoel Alvaro Cruz Zurita", "Estudiante", 77045885);
                    lista.Add(215048616, "Segundo item", "Estudiante", 77045885);
                    lista.Add(205048465, "Tercer Item", "Estudiante", 77045884);
                    lista.Add(465889788, "Cuarto Item", "Docente", 63507227);
                    lista.Imprimir();
                    break;
                case 2:
                    bool continuar = true;
                    do
                    {
                        
                        Console.WriteLine("Ingrese el código:");
                        int codigo = int.Parse(Console.ReadLine());
                        Console.WriteLine("Ingrese el nombre:");
                        string nombre = Console.ReadLine();
                        Console.WriteLine("Ingrese la profesión:");
                        string profesion = Console.ReadLine();
                        Console.WriteLine("Ingrese el teléfono:");
                        int telefono = int.Parse(Console.ReadLine());
                        lista.Add(codigo, nombre, profesion, telefono);
                        Console.Clear();
                        Console.WriteLine("Lista actual:");
                        lista.Imprimir();

                        Console.WriteLine("Desea continuar? (s/n)");
                        string respuesta = Console.ReadLine();
                        if (respuesta != "s")
                        {
                            continuar = false;
                        }
                    } while (continuar);
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }
    }

    // Estructura Nodo
    unsafe struct Nodo
    {
        public int Codigo;
        public string nombre;
        public string profesion;
        public int telefono;
        public Nodo* next;
    }

    // Clase Milist (Lista enlazada)
    unsafe class Milist
    {
        private Nodo* head;

        public Milist()
        {
            head = null;
        }

        public void Add(int Codigo, string nombre, string profesion, int telefono)
        {
            // Crear nuevo nodo
            Nodo* nuevoNodo = (Nodo*)System.Runtime.InteropServices.Marshal.AllocHGlobal(sizeof(Nodo));
            nuevoNodo->Codigo = Codigo;
            nuevoNodo->nombre = nombre;
            nuevoNodo->profesion = profesion;
            nuevoNodo->telefono = telefono;
            nuevoNodo->next = null;

            // Si la lista está vacía, el nuevo nodo será el head
            if (head == null)
            {
                head = nuevoNodo;
            }
            else
            {
                Nodo* temp = head;
                Nodo* prev = null;

                // Buscar la posición correcta para insertar
                while (temp != null && temp->Codigo < nuevoNodo->Codigo)
                {
                    prev = temp;
                    temp = temp->next;
                }

                // Si el nodo anterior es null, significa que insertamos en el principio
                if (prev == null)
                {
                    nuevoNodo->next = head;
                    head = nuevoNodo;
                }
                else
                {
                    prev->next = nuevoNodo;
                    nuevoNodo->next = temp;
                }
            }
        }

        public void Imprimir()
        {
            Nodo* temp = head;
            while (temp != null)
            {
                Console.WriteLine($"Codigo: {temp->Codigo}, Nombre: {temp->nombre}, Profesion: {temp->profesion}, Telefono: {temp->telefono}");
                temp = temp->next;
            }
        }
    }
}
