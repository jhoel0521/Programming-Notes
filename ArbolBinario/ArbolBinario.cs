using System;
using System.Collections.Generic;

namespace ArbolBinario
{
    unsafe internal class ArbolBinario<T> : IArbolBinario<T> where T : IComparable<T>
    {
        private Nodo<T>* Raiz;

        public ArbolBinario()
        {
            Raiz = null;
        }

        public void Insertar(T valor)
        {
            if (Raiz == null)
            {
                Raiz = CrearNodo(valor);
            }
            else
            {
                InsertarRecursivo(Raiz, valor);
            }
        }

        private Nodo<T>* CrearNodo(T valor)
        {
            Nodo<T>* nodo = (Nodo<T>*)System.Runtime.InteropServices.Marshal.AllocHGlobal(sizeof(Nodo<T>));
            *nodo = new Nodo<T>(valor);
            return nodo;
        }

        private void InsertarRecursivo(Nodo<T>* nodo, T valor)
        {
            if (valor.CompareTo(nodo->Valor) < 0)
            {
                if (nodo->Izquierdo == null)
                {
                    nodo->Izquierdo = CrearNodo(valor);
                }
                else
                {
                    InsertarRecursivo(nodo->Izquierdo, valor);
                }
            }
            else
            {
                if (nodo->Derecho == null)
                {
                    nodo->Derecho = CrearNodo(valor);
                }
                else
                {
                    InsertarRecursivo(nodo->Derecho, valor);
                }
            }
        }

        public bool Contiene(T valor)
        {
            return BuscarRecursivo(Raiz, valor);
        }

        private bool BuscarRecursivo(Nodo<T>* nodo, T valor)
        {
            if (nodo == null) return false;

            int comparacion = valor.CompareTo(nodo->Valor);

            if (comparacion == 0) return true;
            if (comparacion < 0) return BuscarRecursivo(nodo->Izquierdo, valor);
            return BuscarRecursivo(nodo->Derecho, valor);
        }

        public List<T> RecorrerEnOrden()
        {
            var resultado = new List<T>();
            RecorrerEnOrdenRecursivo(Raiz, resultado);
            return resultado;
        }

        private void RecorrerEnOrdenRecursivo(Nodo<T>* nodo, List<T> resultado)
        {
            if (nodo == null) return;

            RecorrerEnOrdenRecursivo(nodo->Izquierdo, resultado);
            resultado.Add(nodo->Valor);
            RecorrerEnOrdenRecursivo(nodo->Derecho, resultado);
        }

        public List<T> RecorrerPreOrden()
        {
            var resultado = new List<T>();
            RecorrerPreOrdenRecursivo(Raiz, resultado);
            return resultado;
        }

        private void RecorrerPreOrdenRecursivo(Nodo<T>* nodo, List<T> resultado)
        {
            if (nodo == null) return;

            resultado.Add(nodo->Valor);
            RecorrerPreOrdenRecursivo(nodo->Izquierdo, resultado);
            RecorrerPreOrdenRecursivo(nodo->Derecho, resultado);
        }

        public List<T> RecorrerPostOrden()
        {
            var resultado = new List<T>();
            RecorrerPostOrdenRecursivo(Raiz, resultado);
            return resultado;
        }

        private void RecorrerPostOrdenRecursivo(Nodo<T>* nodo, List<T> resultado)
        {
            if (nodo == null) return;

            RecorrerPostOrdenRecursivo(nodo->Izquierdo, resultado);
            RecorrerPostOrdenRecursivo(nodo->Derecho, resultado);
            resultado.Add(nodo->Valor);
        }

        public int Profundidad()
        {
            return CalcularProfundidad(Raiz);
        }

        private int CalcularProfundidad(Nodo<T>* nodo)
        {
            if (nodo == null) return 0;

            int profundidadIzquierda = CalcularProfundidad(nodo->Izquierdo);
            int profundidadDerecha = CalcularProfundidad(nodo->Derecho);

            return Math.Max(profundidadIzquierda, profundidadDerecha) + 1;
        }

        public void PrintComoArbol()
        {
            PrintComoArbolRecursivo(Raiz, "", true);
        }

        private void PrintComoArbolRecursivo(Nodo<T>* nodo, string indent, bool esUltimo)
        {
            if (nodo != null)
            {
                Console.WriteLine(indent + (esUltimo ? "└─ " : "├─ ") + nodo->Valor);

                string nuevoIndent = indent + (esUltimo ? "   " : "│  ");
                PrintComoArbolRecursivo(nodo->Izquierdo, nuevoIndent, nodo->Derecho == null);
                PrintComoArbolRecursivo(nodo->Derecho, nuevoIndent, true);
            }
        }

        public void Print(TipoRecorrido tipoRecorrido)
        {
            List<T> elementos;
            switch (tipoRecorrido)
            {
                case TipoRecorrido.InOrden:
                    elementos = RecorrerEnOrden();
                    break;
                case TipoRecorrido.PreOrden:
                    elementos = RecorrerPreOrden();
                    break;
                case TipoRecorrido.PostOrden:
                    elementos = RecorrerPostOrden();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(tipoRecorrido), tipoRecorrido, null);
            }
            Console.WriteLine(string.Join(", ", elementos));
        }

        public List<T> RecorrerPorTipo(TipoRecorrido tipoRecorrido)
        {
            List<T> elementos;
            switch (tipoRecorrido)
            {
                case TipoRecorrido.InOrden:
                    elementos = RecorrerEnOrden();
                    break;
                case TipoRecorrido.PreOrden:
                    elementos = RecorrerPreOrden();
                    break;
                case TipoRecorrido.PostOrden:
                    elementos = RecorrerPostOrden();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(tipoRecorrido), tipoRecorrido, null);
            }
            return elementos;
        }
    }
}
