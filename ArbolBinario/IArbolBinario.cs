using System;
using System.Collections.Generic;

namespace ArbolBinario
{
    public interface IArbolBinario<T> where T : IComparable<T>
    {
        /// <summary>
        /// Agrega un valor al árbol.
        /// </summary>
        /// <param name="valor">El valor a insertar.</param>
        void Insertar(T valor);
        
        /// <summary>
        /// Elimina un valor del árbol.
        /// </summary>
        /// <param name="valor">El valor a eliminar.</param>
        void Eliminar(T valor);

        /// <summary>
        /// Verifica si un valor existe en el árbol.
        /// </summary>
        /// <param name="valor">El valor a buscar.</param>
        /// <returns>True si el valor existe, de lo contrario false.</returns>
        bool Contiene(T valor);

        /// <summary>
        /// Obtiene los elementos del árbol en orden.
        /// </summary>
        /// <returns>Una lista de elementos en orden.</returns>
        List<T> RecorrerEnOrden();

        /// <summary>
        /// Obtiene los elementos del árbol en preorden.
        /// </summary>
        /// <returns>Una lista de elementos en preorden.</returns>
        List<T> RecorrerPreOrden();

        /// <summary>
        /// Obtiene los elementos del árbol en postorden.
        /// </summary>
        /// <returns>Una lista de elementos en postorden.</returns>
        List<T> RecorrerPostOrden();
        
        /// <summary>
        /// Obtiene los elementos del árbol por nivel.
        /// </summary>
        /// <returns>Una lista de elementos por nivel.</returns>
        List<T> RecorrerPorNivel();

        /// <summary>
        /// Calcula la profundidad máxima del árbol.
        /// </summary>
        /// <returns>La profundidad del árbol.</returns>
        int Profundidad();

        /// <summary>
        /// Obtiene los elementos del árbol según el tipo de recorrido especificado.
        /// </summary>
        /// <param name="tipoRecorrido">El tipo de recorrido a realizar (InOrden, PreOrden, PostOrden).</param>
        /// <returns>Una lista de elementos en el orden especificado.</returns>
        List<T> RecorrerPorTipo(TipoRecorrido tipoRecorrido);
        /// <summary>
        /// Imprime el árbol en formato de árbol visual (jerárquico).
        /// </summary>
        void PrintComoArbol();

        /// <summary>
        /// Imprime el árbol según el tipo de recorrido especificado.
        /// </summary>
        /// <param name="tipoRecorrido">El tipo de recorrido a realizar (InOrden, PreOrden, PostOrden).</param>
        void Print(TipoRecorrido tipoRecorrido);

        /// <summary>
        /// Devuelve la cantidad de niveles del árbol
        /// </summary>
        /// <returns>Devuelve la cantidad de niveles del árbol</returns>
        int CantidadNiveles();
        /// <summary>
        /// Devuelve la cantidad de nodos del árbol
        /// </summary>
        /// <returns>Devuelve la cantidad de nodos del árbol</returns>
        int CantidadNodo();

        /// <summary>
        /// Elimina todos los elementos del árbol.
        /// </summary>
        void EliminarTodos();

    }

    /// <summary>
    /// Enumeración para los tipos de recorrido del árbol binario.
    /// </summary>
    public enum TipoRecorrido
    {
        InOrden = 1,
        PreOrden = 2,
        PostOrden = 3,
        PorNivel = 4
    }
}
