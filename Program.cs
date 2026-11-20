using System;
using System.Collections.Generic;

namespace PracticaABB
{
    public class NodoABB
    {
        public int Valor { get; set; }
        public NodoABB? Izquierdo { get; set; }
        public NodoABB? Derecho { get; set; }

        public NodoABB(int valor)
        {
            Valor = valor;
            Izquierdo = null;
            Derecho = null;
        }
    }

    public class ArbolBinarioBusqueda
    {
        public NodoABB? Raiz { get; private set; }

        public void Insertar(int valor)
        {
            Raiz = InsertarRec(Raiz, valor);
        }

        private NodoABB InsertarRec(NodoABB? actual, int valor)
        {
            if (actual == null)
                return new NodoABB(valor);

            if (valor < actual.Valor)
                actual.Izquierdo = InsertarRec(actual.Izquierdo, valor);
            else if (valor > actual.Valor)
                actual.Derecho = InsertarRec(actual.Derecho, valor);

            return actual;
        }

        public bool Buscar(int valor)
        {
            return BuscarRec(Raiz, valor);
        }

        private bool BuscarRec(NodoABB? actual, int valor)
        {
            if (actual == null)
                return false;

            if (valor == actual.Valor)
                return true;

            return valor < actual.Valor
                ? BuscarRec(actual.Izquierdo, valor)
                : BuscarRec(actual.Derecho, valor);
        }

        public void Eliminar(int valor)
        {
            Raiz = EliminarRec(Raiz, valor);
        }

        private NodoABB? EliminarRec(NodoABB? actual, int valor)
        {
            if (actual == null)
                return null;

            if (valor < actual.Valor)
            {
                actual.Izquierdo = EliminarRec(actual.Izquierdo, valor);
            }
            else if (valor > actual.Valor)
            {
                actual.Derecho = EliminarRec(actual.Derecho, valor);
            }
            else
            {
                if (actual.Izquierdo == null && actual.Derecho == null)
                    return null;

                if (actual.Izquierdo == null)
                    return actual.Derecho;
                if (actual.Derecho == null)
                    return actual.Izquierdo;

                NodoABB sucesor = ObtenerMinimo(actual.Derecho);
                actual.Valor = sucesor.Valor;
                actual.Derecho = EliminarRec(actual.Derecho, sucesor.Valor);
            }

            return actual;
        }

        private NodoABB ObtenerMinimo(NodoABB actual)
        {
            while (actual.Izquierdo != null)
                actual = actual.Izquierdo;

            return actual;
        }

        public List<int> Preorden()
        {
            var resultado = new List<int>();
            PreordenRec(Raiz, resultado);
            return resultado;
        }

        private void PreordenRec(NodoABB? actual, List<int> lista)
        {
            if (actual == null) return;
            lista.Add(actual.Valor);
            PreordenRec(actual.Izquierdo, lista);
            PreordenRec(actual.Derecho, lista);
        }

        public List<int> Inorden()
        {
            var resultado = new List<int>();
            InordenRec(Raiz, resultado);
            return resultado;
        }

        private void InordenRec(NodoABB? actual, List<int> lista)
        {
            if (actual == null) return;
            InordenRec(actual.Izquierdo, lista);
            lista.Add(actual.Valor);
            InordenRec(actual.Derecho, lista);
        }

        public List<int> Postorden()
        {
            var resultado = new List<int>();
            PostordenRec(Raiz, resultado);
            return resultado;
        }

        private void PostordenRec(NodoABB? actual, List<int> lista)
        {
            if (actual == null) return;
            PostordenRec(actual.Izquierdo, lista);
            PostordenRec(actual.Derecho, lista);
            lista.Add(actual.Valor);
        }

        public int Altura()
        {
            return AlturaRec(Raiz);
        }

        private int AlturaRec(NodoABB? actual)
        {
            if (actual == null) return -1;
            int izq = AlturaRec(actual.Izquierdo);
            int der = AlturaRec(actual.Derecho);
            return 1 + Math.Max(izq, der);
        }

        public int ContarNodos()
        {
            return ContarNodosRec(Raiz);
        }

        private int ContarNodosRec(NodoABB? actual)
        {
            if (actual == null) return 0;
            return 1 + ContarNodosRec(actual.Izquierdo) + ContarNodosRec(actual.Derecho);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var abb = new ArbolBinarioBusqueda();
            int[] valoresIniciales = { 50, 30, 70, 20, 40, 60, 80 };

            foreach (int v in valoresIniciales)
                abb.Insertar(v);

            int opcion;
            do
            {
                Console.WriteLine("\n=== ÁRBOL BINARIO DE BÚSQUEDA (C#) ===");
                Console.WriteLine("1. Insertar valor");
                Console.WriteLine("2. Buscar valor");
                Console.WriteLine("3. Eliminar valor");
                Console.WriteLine("4. Mostrar recorridos (Preorden, Inorden, Postorden)");
                Console.WriteLine("5. Mostrar altura y cantidad de nodos");
                Console.WriteLine("0. Salir");
                Console.Write("Elige una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    opcion = -1;
                    Console.WriteLine("Ingresa un número válido.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        Console.Write("Valor a insertar: ");
                        if (int.TryParse(Console.ReadLine(), out int ins))
                        {
                            abb.Insertar(ins);
                            Console.WriteLine($"Insertado {ins}. Inorden actual: {string.Join(" -> ", abb.Inorden())}");
                        }
                        break;

                    case 2:
                        Console.Write("Valor a buscar: ");
                        if (int.TryParse(Console.ReadLine(), out int bus))
                        {
                            bool encontrado = abb.Buscar(bus);
                            Console.WriteLine(encontrado
                                ? $"El valor {bus} SÍ existe en el árbol."
                                : $"El valor {bus} NO existe en el árbol.");
                        }
                        break;

                    case 3:
                        Console.Write("Valor a eliminar: ");
                        if (int.TryParse(Console.ReadLine(), out int eli))
                        {
                            abb.Eliminar(eli);
                            Console.WriteLine($"Operación realizada. Inorden actual: {string.Join(" -> ", abb.Inorden())}");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Preorden : " + string.Join(" -> ", abb.Preorden()));
                        Console.WriteLine("Inorden  : " + string.Join(" -> ", abb.Inorden()));
                        Console.WriteLine("Postorden: " + string.Join(" -> ", abb.Postorden()));
                        break;

                    case 5:
                        Console.WriteLine($"Altura del árbol (en aristas): {abb.Altura()}");
                        Console.WriteLine($"Total de nodos: {abb.ContarNodos()}");
                        break;

                    case 0:
                        Console.WriteLine("Saliendo...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            } while (opcion != 0);
        }
    }
}