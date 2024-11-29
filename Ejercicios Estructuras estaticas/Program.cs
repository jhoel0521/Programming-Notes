using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Ejercicios_Estructuras_estaticas.Ejercicio7Class;

namespace Ejercicios_Estructuras_estaticas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EjerciciosVarios ejercicios = new EjerciciosVarios();
            while (true)
            {
                Console.WriteLine("1. Ejercicio 1");
                Console.WriteLine("2. Ejercicio 2");
                Console.WriteLine("3. Ejercicio 3");
                Console.WriteLine("4. Ejercicio 4");
                Console.WriteLine("5. Ejercicio 5");
                Console.WriteLine("6. Ejercicio 6");
                Console.WriteLine("7. Ejercicio 7");
                Console.WriteLine("8. Ejercicio 8");
                Console.WriteLine("9. Salir");
                Console.WriteLine("Ingrese una opcion: ");
                int opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        hr();
                        ejercicios.ejercicio1();
                        hr();
                        break;
                    case 2:
                        hr();
                        // pregutnar si se quiere leer por consola
                        Console.WriteLine("Desea ingresar los numeros por consola? (s/n)");
                        string respuesta = Console.ReadLine();
                        if (respuesta == "s")
                        {
                            ejercicios.ejercicio2(true);
                        }
                        else
                        {
                            ejercicios.ejercicio2();
                        }
                        hr();
                        break;
                    case 3:
                        hr();
                        ejercicios.ejercicio3();
                        hr();
                        break;
                    case 4:
                        hr();
                        ejercicios.ejercicio4();
                        hr();
                        break;
                    case 5:
                        hr();
                        ejercicios.ejercicio5();
                        hr();
                        break;
                    case 6:
                        hr();
                        // preguntar si se quiere un laberinto random
                        Console.WriteLine("Desea un laberinto random? (s/n)");
                        string respuestaLaberinto = Console.ReadLine();
                        if (respuestaLaberinto == "s")
                        {
                            ejercicios.Ejercicio6(true);
                        }
                        else
                        {
                            ejercicios.Ejercicio6();
                        }
                        hr();
                        break;
                    case 7:
                        hr();
                        ejercicios.Ejercicio7();
                        hr();
                        break;
                    case 8:
                        hr();
                        ejercicios.Ejercicio8();
                        hr();
                        break;
                    case 9:
                        return;
                }
                Console.WriteLine("Presione enter para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        static void hr()
        {
            Console.WriteLine("-------------------------------------------------");
        }
    }
    public class EjerciciosVarios
    {
        public Random random;
        public static int[,] notasEstudiantes = new int[10, 5];
        public EjerciciosVarios()
        {
            random = new Random();
        }
        /*
         *  1. Elaborar un programa en C# para mostrar los primeros 20 elementos de la serie:
            “1,4,8,2,5,9,3, …”
        */
        public void ejercicio1()
        {
            int n = random.Next(20, 100);
            int a = 1, b = 4, c = 8;
            if (n < 0)
            {
                Console.WriteLine("No hay Elemlentos");
                return;
            }
            string result = "Viendo los primeros " + n + " elementos de la serie: \n";
            if (n >= 1)
            {
                result += a;
                a++;
            }
            if (n >= 2)
            {
                result += ("," + b);
                b++;
            }
            if (n >= 3)
            {
                result += ("," + c);
                c++;
            }
            int next = 1;
            for (int i = 2; i < n; i++)
            {
                if (next == 1)
                {
                    result += ("," + a);
                    a++;
                }
                if (next == 2)
                {
                    result += ("," + b);
                    b++;
                }
                if (next == 3)
                {
                    result += ("," + c);
                    c++;
                    next = 0;
                }
                next++;
            }
            Console.WriteLine(result);

        }
        /*
          2. Elaborar un programa en C#, para leer 50 números enteros y calcular:
            a. Suma,
            b. promedio,
            c. valor menor,
            d. valor mayor.
            
        */
        public void ejercicio2(bool readConsole = false)
        {
            int[] numeros = new int[50];
            for (int i = 0; i < 50; i++)
            {
                if (readConsole)
                {
                    Console.WriteLine("Ingrese el numero " + (i + 1) + ": ");
                    numeros[i] = int.Parse(Console.ReadLine());
                }
                else
                {
                    numeros[i] = random.Next(1, 100);
                    Console.WriteLine("Ingrese el numero " + (i + 1) + ": ");
                    Console.WriteLine(numeros[i]);
                }
            }
            int suma = 0;
            int menor = numeros[0];
            int mayor = numeros[0];
            for (int i = 0; i < 50; i++)
            {
                suma += numeros[i];
                if (numeros[i] < menor)
                {
                    menor = numeros[i];
                }
                if (numeros[i] > mayor)
                {
                    mayor = numeros[i];
                }
            }
            Console.WriteLine("La suma de los 50 numeros es: " + suma);
            Console.WriteLine("El promedio de los 50 numeros es: " + suma / 50);
            Console.WriteLine("El numero menor es: " + menor);
            Console.WriteLine("El numero mayor es: " + mayor);
        }
        /*
        3. Escribir un programa en C# para leer una oración y calcular:
        a. Cuantas vocales contiene
        b. Cuantas consonantes
        c. Cuantos caracteres especiales.
        */

        public void ejercicio3()
        {
            Console.WriteLine("Ingrese una oracion: ");
            string oracion = Console.ReadLine();
            int vocales = 0;
            int consonantes = 0;
            int especiales = 0;
            oracion = oracion.ToLower();
            char[] vocalesArray = { 'a', 'e', 'i', 'o', 'u', 'á', 'é', 'í', 'ó', 'ú' };
            char[] consonantesArray = { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'ñ', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z' };
            for (int i = 0; i < oracion.Length; i++)
            {
                char c = oracion[i];
                if (vocalesArray.Contains(c))
                {
                    vocales++;
                }
                else if (consonantesArray.Contains(c))
                {
                    consonantes++;
                }
                else
                {
                    especiales++;
                }
            }
            Console.WriteLine("La oracion tiene " + vocales + " vocales");
            Console.WriteLine("La oracion tiene " + consonantes + " consonantes");
            Console.WriteLine("La oracion tiene " + especiales + " caracteres especiales");
        }
        private void PrintMatrix<T>(T[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string row = "";
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    T value = matrix[i, j];
                    if (value is double)
                    {
                        // Alinea a la derecha con 8 espacios y muestra 2 decimales
                        row += ((double)(object)value).ToString("0.00").PadLeft(8);
                    }
                    else if (value is int)
                    {
                        // Alinea a la derecha con 3 espacios para enteros
                        row += ((int)(object)value).ToString().PadLeft(3);
                    }
                    else
                    {
                        // Otros tipos de datos
                        row += value.ToString().PadLeft(5);
                    }
                }
                Console.WriteLine(row);
            }
        }

        /*
         4. Realizar un programa en C# para que dada una matriz cuadrada con valores
            numéricos se obtenga:
            a. La Matriz transpuesta
            b. La Matriz inversa
            c. La triangular superior a otra matriz.
            d. La triangular inferior a otra matriz.
                  
        */
        public void ejercicio4()
        {
            int n = random.Next(2, 6);
            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = random.Next(1, 10);
                }
            }
            Console.WriteLine("Matriz Original");
            PrintMatrix(matrix);
            // calculamos la matriz transpuesta
            int[,] transpuesta = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    transpuesta[j, i] = matrix[i, j];
                }
            }
            Console.WriteLine("Matriz Transpuesta");
            PrintMatrix(transpuesta);
            // calculamos la matriz inversa
            double[,] copia = new double[n, n];
            double[,] inversa = new double[n, n];

            // Crear copia de la matriz original y matriz identidad
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    copia[i, j] = matrix[i, j];
                    inversa[i, j] = (i == j) ? 1 : 0; // Identidad
                }
            }

            // Aplicar método de Gauss-Jordan
            for (int i = 0; i < n; i++)
            {
                // Paso 1: Normalizar el pivote
                double pivote = copia[i, i];
                if (pivote == 0)
                {
                    Console.WriteLine("La matriz no es invertible.");
                    return;
                }

                for (int j = 0; j < n; j++)
                {
                    copia[i, j] /= pivote;
                    inversa[i, j] /= pivote;
                }

                // Paso 2: Crear ceros en la columna del pivote
                for (int k = 0; k < n; k++)
                {
                    if (k != i)
                    {
                        double factor = copia[k, i];
                        for (int j = 0; j < n; j++)
                        {
                            copia[k, j] -= factor * copia[i, j];
                            inversa[k, j] -= factor * inversa[i, j];
                        }
                    }
                }
            }

            Console.WriteLine("Matriz Inversa");
            PrintMatrix(inversa);
            // calculamos la matriz triangular superior
            int[,] triangularSuperior = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i <= j)
                    {
                        triangularSuperior[i, j] = matrix[i, j];
                    }
                    else
                    {
                        triangularSuperior[i, j] = 0;
                    }
                }
            }

            Console.WriteLine("Matriz Triangular Superior");
            PrintMatrix(triangularSuperior);
            // calculamos la matriz triangular inferior
            int[,] triangularInferior = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i >= j)
                    {
                        triangularInferior[i, j] = matrix[i, j];
                    }
                    else
                    {
                        triangularInferior[i, j] = 0;
                    }
                }
            }

        }
        /*
        5. Crea un programa que verifique si un tablero NxN que contiene números en cada una
            de sus filas del 1 al N y en sus columnas del 1 al N.tiene o no valores repetidos. Usa
            un arreglo estático para representar el tablero e implementa funciones para verificar
            filas, columnas y subcuadrículas.Ejm: { 1, 2, 3, 4}, {3, 4, 1, 2}, {2, 1, 4, 3}, {4, 3, 2, 1}
        */

        public void ejercicio5()
        {
            int n = random.Next(3, 6);
            int[,] tablero = new int[n, n];
            // Llenar tablero
            for (int i = 0; i < n; i++)
            {
                BitArray numberUsuados = new BitArray(n);
                numberUsuados.SetAll(false);
                for (int j = 0; j < n; j++)
                {
                    while (true)
                    {
                        int number = random.Next(1, n + 1);
                        if (!numberUsuados.Get(number - 1))
                        {
                            tablero[i, j] = number;
                            numberUsuados.Set(number - 1, true);
                            break;
                        }
                    }
                }
            }
            Console.WriteLine("Tablero Original");
            PrintMatrix(tablero);

            // Verificar filas y columnas
            bool isPerfect = true;
            for (int i = 0; isPerfect && i < n; i++)
            {
                BitArray numColumnas = new BitArray(n), numFilas = new BitArray(n);
                numColumnas.SetAll(false);
                numFilas.SetAll(false);
                for (int j = 0; j < n; j++)
                {
                    int numColumna = tablero[j, i];
                    int numFila = tablero[i, j];
                    if (numColumnas.Get(numColumna - 1) || numFilas.Get(numFila - 1))
                    {
                        isPerfect = false;
                        Console.Write("El tablero no esta perfectamete distribuido fallo en");
                        if (numColumnas.Get(numColumna - 1))
                        {
                            Console.Write(" Columna " + (i + 1));
                        }
                        if (numFilas.Get(numFila - 1))
                        {
                            Console.Write(" Fila " + (i + 1));
                        }
                        Console.WriteLine();
                        break;
                    }
                    numColumnas.Set(numColumna - 1, true);
                    numFilas.Set(numFila - 1, true);
                }
            }
        }
        /*
        6. Simula un laberinto usando un arreglo estático 10x10, donde 0 representa caminos y
            1 paredes.Crea una función para verificar si existe un camino desde una entrada a
            una salida.
        */
        public void Ejercicio6(bool isLaberintoRandon = false)
        {
            int n = 10;
            int[,] laberinto = new int[n, n];
            Random random = new Random();

            // Llenar laberinto
            if (isLaberintoRandon)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        laberinto[i, j] = random.Next(0, 2);
                    }
                }
            }
            else
            {
                laberinto = new int[,]
              {
                    { 1, 1, 0, 1, 1, 1, 1, 1, 1, 1 },
                    { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 1, 1, 1, 1, 1, 1, 1 },
                    { 1, 0, 1, 1, 1, 1, 1, 1, 1, 1 },
                    { 1, 0, 1, 1, 1, 1, 1, 1, 1, 1 },
                    { 1, 0, 1, 1, 1, 1, 1, 1, 1, 1 },
                    { 1, 0, 1, 1, 1, 1, 1, 1, 1, 1 },
                    { 1, 0, 1, 1, 1, 1, 1, 1, 1, 1 },
                    { 1, 0, 1, 1, 1, 1, 1, 1, 1, 1 },
                    { 1, 0, 1, 1, 1, 1, 1, 1, 1, 1 }
              };

            }

            Console.WriteLine("Laberinto Original");

            bool isVertical = random.Next(0, 2) == 1;
            Console.WriteLine("La posición de entrada es: " + (isVertical ? "Columna" : "Fila"));

            // Buscar la entrada (primer 0 en la fila o columna inicial)
            int entrada = -1;
            for (int i = 0; i < n; i++)
            {
                if ((isVertical && laberinto[i, 0] == 0) || (!isVertical && laberinto[0, i] == 0))
                {
                    entrada = i;
                    break;
                }
            }

            if (entrada == -1)
            {
                Console.WriteLine("No se encontró una entrada válida.\nFin.");
                return;
            }

            Console.WriteLine("Entrada encontrada en la posición: " + entrada);

            bool[,] visitados = new bool[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    visitados[i, j] = false;
                }
            }
            bool haySalida = false;

            if (isVertical)
            {
                laberinto[entrada, 0] = 2;
                PrintMatrix(laberinto);
                laberinto[entrada, 0] = 0;
                Console.WriteLine("Presione enter para continuar...");
                Console.ReadKey();
                haySalida = BuscarSalidaIterativo(laberinto, visitados, entrada, 0, n, isVertical);
            }
            else
            {
                laberinto[0, entrada] = 2;
                PrintMatrix(laberinto);
                laberinto[0, entrada] = 0;
                Console.WriteLine("Presione enter para continuar...");
                Console.ReadKey();
                Console.WriteLine();
                haySalida = BuscarSalidaIterativo(laberinto, visitados, 0, entrada, n, isVertical);
            }

            if (haySalida)
            {
                Console.WriteLine("Se encontró una salida:");
                PrintMatrix(laberinto);
            }
            else
            {
                Console.WriteLine("No se encontró ninguna salida.");
            }
        }

        private bool BuscarSalidaIterativo(int[,] laberinto, bool[,] visitados, int inicioI, int inicioJ, int n, bool isVertical)
        {
            Stack<(int i, int j)> stack = new Stack<(int, int)>();
            stack.Push((inicioI, inicioJ));

            while (stack.Count > 0)
            {
                var (i, j) = stack.Pop();

                if (i < 0 || j < 0 || i >= n || j >= n || laberinto[i, j] != 0 || visitados[i, j])
                {
                    continue;
                }

                visitados[i, j] = true;
                laberinto[i, j] = 2;

                if (isVertical && j == n - 1 || !isVertical && i == n - 1)
                {
                    Console.WriteLine("Salida encontrada en la posición: " + i + ", " + j);
                    return true;
                }


                stack.Push((i - 1, j));
                stack.Push((i + 1, j));
                stack.Push((i, j - 1));
                stack.Push((i, j + 1));
            }

            return false;
        }

        /*
        7. Crea un programa que gestione un inventario de productos utilizando un arreglo
            estático.Cada producto debe tener un código, nombre y precio.Implementa
            funciones para agregar, buscar y mostrar productos. Además de poder mostrar los
            productos ordenados por nombre, por precio, y dado el código de un producto
            devuelva su nombre y su precio.
        */
        
        public void Ejercicio7()
        {
            bool continuar = true;
            while (continuar)
            {
                try
                {
                    Ejercicio7Class.PrintProductos();
                    Console.WriteLine("1. Agregar Producto");
                    Console.WriteLine("2. Buscar por Codigo");
                    Console.WriteLine("3. Buscar por Nombre");
                    Console.WriteLine("4. Ordenar por Nombre");
                    Console.WriteLine("5. Ordenar por Precio");
                    Console.WriteLine("6. Buscar por Codigo Exacto");
                    Console.WriteLine("7. Salir");
                    Console.WriteLine("Ingrese una opcion: ");
                    int opcion = int.Parse(Console.ReadLine());
                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine("Ingrese el codigo del producto: ");
                            string codigo = Console.ReadLine();
                            Console.WriteLine("Ingrese el nombre del producto: ");
                            string nombre = Console.ReadLine();
                            Console.WriteLine("Ingrese el precio del producto: ");
                            double precio = double.Parse(Console.ReadLine());
                            if (Ejercicio7Class.AgregarProducto(codigo, nombre, precio))
                            {
                                Console.WriteLine("Producto agregado correctamente");
                            }
                            else
                            {
                                Console.WriteLine("No se pudo agregar el producto");
                            }
                            break;
                        case 2:
                            Console.WriteLine("Ingrese el codigo a buscar: ");
                            string codigoBuscar = Console.ReadLine();
                            Ejercicio7Class.PrintProductos(Ejercicio7Class.BuscarPorCodigo(codigoBuscar));
                            break;
                        case 3:
                            Console.WriteLine("Ingrese el nombre a buscar: ");
                            string nombreBuscar = Console.ReadLine();
                            Ejercicio7Class.PrintProductos(Ejercicio7Class.BuscarPorNombre(nombreBuscar));
                            break;
                        case 4:
                            Ejercicio7Class.OrdenarPorNombre();
                            Ejercicio7Class.PrintProductos();
                            break;
                        case 5:
                            Ejercicio7Class.OrdenarPorPrecio();
                            Ejercicio7Class.PrintProductos();
                            break;
                        case 6:
                            Console.WriteLine("Ingrese el codigo a buscar: ");
                            string codigoExacto = Console.ReadLine();
                            Ejercicio7Class.Product producto = Ejercicio7Class.BuscarPorCodigoExacto(codigoExacto);
                            if (producto.codigo != null)
                            {
                                Console.WriteLine("Nombre: " + producto.nombre);
                                Console.WriteLine("Precio: " + producto.precio);
                            }
                            else
                            {
                                Console.WriteLine("No se encontro el producto");
                            }
                            break;
                        case 7:
                            continuar = false;
                            break;

                    }
                    // clear console
                    Console.WriteLine("Presione enter para continuar...");
                    Console.ReadKey();
                    Console.Clear();

                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                    Console.WriteLine("Presione enter para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }

            }
        }
        /*
            8. Implementa un sistema que almacene calificaciones de 10 estudiantes en 5 materias
            usando un arreglo estático.El programa debe calcular el promedio de cada
            estudiante y de cada materia.Se debe generar los valores de las notas de forma
            aleatoria con valores entre 0 y 100. 
         */
        public void Ejercicio8()
        {
            int cantidadEstudiantes = 10;
            int cantidadMaterias = 5;
            for (int i = 0; i < cantidadEstudiantes; i++)
            {
                for (int j = 0; j < cantidadMaterias; j++)
                {
                    EjerciciosVarios.notasEstudiantes[i, j] = random.Next(0, 101);
                }
            }
            Console.WriteLine("Notas de los estudiantes");
            Console.WriteLine(" M1 M2 M3 M4 M5");
            Console.WriteLine(" |  |  |  |  |");
            Console.WriteLine(" V  V  V  V  V");
            PrintMatrix(notasEstudiantes);
            Console.WriteLine("----------------");
            double[] promediosEstudiantes = new double[cantidadEstudiantes];
            double[] promediosMaterias = new double[cantidadMaterias];
            for (int i = 0; i < cantidadEstudiantes; i++)
            {
                double suma = 0;
                for (int j = 0; j < cantidadMaterias; j++)
                {
                    suma += notasEstudiantes[i, j];
                }
                promediosEstudiantes[i] = suma / cantidadMaterias;
            }
            for (int i = 0; i < cantidadMaterias; i++)
            {
                double suma = 0;
                for (int j = 0; j < cantidadEstudiantes; j++)
                {
                    suma += notasEstudiantes[j, i];
                }
                promediosMaterias[i] = suma / cantidadEstudiantes;
            }
            Console.WriteLine("Promedios de los estudiantes");
            for (int i = 0; i < cantidadEstudiantes; i++)
            {
                Console.WriteLine("El promedio del estudiante " + (i + 1) + " es: " + promediosEstudiantes[i]);
            }
            Console.WriteLine("Promedios de las materias");
            for (int i = 0; i < cantidadMaterias; i++)
            {
                Console.WriteLine("El promedio de la materia " + (i + 1) + " es: " + promediosMaterias[i]);
            }
        }
    }
    public class Ejercicio7Class
    {
        public static Product[] productos = new Product[10];
        public static bool AgregarProducto(string codigo, string nombre, double precio)
        {
            bool insertado = false;
            for (int i = 0; i < productos.Length; i++)
            {
                if (productos[i].codigo == null)
                {
                    productos[i].codigo = codigo;
                    productos[i].nombre = nombre;
                    productos[i].precio = precio;
                    insertado = true;
                    break;
                }
            }
            return insertado;
        }
        public static Product[] BuscarPorCodigo(string codigo)
        {
            Product[] re = new Product[10];
            int j = 0;
            for (int i = 0; i < productos.Length; i++)
            {
                if (productos[i].codigo != null)
                {
                    if (productos[i].codigo.Contains(codigo))
                    {
                        re[j] = productos[i];
                        j++;
                    }
                }
            }
            return re;
        }
        public static Product[] BuscarPorNombre(string nombre)
        {
            Product[] re = new Product[10];
            int j = 0;
            for (int i = 0; i < productos.Length; i++)
            {
                if (productos[i].nombre != null)
                {
                    if (productos[i].nombre.Contains(nombre))
                    {
                        re[j] = productos[i];
                        j++;
                    }
                }
            }
            return re;
        }
        public static void OrdenarPorNombre()
        {
            Array.Sort(productos, (a, b) =>
            {
                if (a.nombre == null && b.nombre == null)
                {
                    return 0;
                }
                if (a.nombre == null)
                {
                    return -1;
                }
                if (b.nombre == null)
                {
                    return 1;
                }
                return a.nombre.CompareTo(b.nombre);
            });
        }
        public static void OrdenarPorPrecio()
        {
            Array.Sort(productos, (a, b) => a.precio.CompareTo(b.precio));
        }
        public static Product BuscarPorCodigoExacto(string codigo)
        {
            for (int i = 0; i < productos.Length; i++)
            {
                if (productos[i].codigo != null && productos[i].codigo == codigo)
                {
                    return productos[i];
                }
            }
            return new Product();
        }

        public static void PrintProductos(Product[] printProductos = null)
        {
            if (printProductos == null)
            {
                printProductos = productos;
            }
            bool isPrint = false;
            Console.WriteLine("Lista de Productos");
            for (int i = 0; i < printProductos.Length; i++)
            {
                if (printProductos[i].codigo != null)
                {
                    isPrint = true;
                    Console.Write("Codigo: " + printProductos[i].codigo);
                    Console.Write(" Nombre: " + printProductos[i].nombre);
                    Console.Write(" Precio: " + printProductos[i].precio);
                    Console.WriteLine("\n-------------------------------------------------");
                }
            }
            if (!isPrint)
            {
                Console.WriteLine("No hay productos");
            }
        }


        public struct Product
        {
            public string codigo;
            public string nombre;
            public double precio;
        }
    }

}
