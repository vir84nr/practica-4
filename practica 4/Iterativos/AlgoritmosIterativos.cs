using System;

namespace Practica4.Iterativos
{
    public class AlgoritmosIterativos
    {
        public static void contar(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                Contador.sumar();
            }
        }

        public static void contar2(int n)
        {
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    Contador.sumar();
                }
            }
        }

        public static void contarDependiente(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Contador.sumar();
                }
            }
        }

        public static void tiempoWhile(int n)
        {
            int i = 1;
            while (i < n)
            {
                Contador.sumar();
                i = i * 2;
            }
        }

        public static long formulaContar(long n) { return n; }

        public static long formulaContar2(long n) { return (long)Math.Pow(n + 1, 2); }

        public static long formulaDependiente(long n) { return (n * (n + 1)) / 2; }

        public static long formulaWhile(long n) { return (long)Math.Ceiling(Math.Log2(n)); }
    }
}
