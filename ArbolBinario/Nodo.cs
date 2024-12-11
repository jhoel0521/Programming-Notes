using System;

namespace ArbolBinario
{
    unsafe public struct Nodo<T> : IComparable<T> where T : IComparable<T>
    {
        public T Valor { get; set; }
        public Nodo<T>* Izquierdo { get; set; }
        public Nodo<T>* Derecho { get; set; }

        public Nodo(T valor)
        {
            Valor = valor;
            Izquierdo = null;
            Derecho = null;
        }

        public int CompareTo(T other)
        {
            return Valor.CompareTo(other);
        }
    }
}
