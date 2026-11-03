
using Practica4.Iterativos;
using Practica4.Proxy;
using Practica4.Recursivos;
using Practica4.Strategy;
using System;

namespace Practica4
{
    class MainClass
    {
        static void Main(string[] args)
        {
            ejercicio1();
            Console.WriteLine(new string('-', 50));
            ejercicio2();
            Console.WriteLine(new string('-', 50));
            ejercicio3();
            Console.WriteLine(new string('-', 50));
            ejercicio4();
        }

        static void ejercicio1()
        {
            Console.WriteLine("--- EJERCICIO 1 ---");
            int[] valoresN = { 10, 100, 1000 };

            foreach (int n in valoresN)
            {
                Console.WriteLine($"\nPara n = {n}:");

                Contador.reiniciar();
                AlgoritmosIterativos.contar(n);
                ImprimirResultadoEj1("contar", n, AlgoritmosIterativos.formulaContar(n), "O(n)");

                Contador.reiniciar();
                AlgoritmosIterativos.contar2(n);
                ImprimirResultadoEj1("contar2", n, AlgoritmosIterativos.formulaContar2(n), "O(n^2)");

                Contador.reiniciar();
                AlgoritmosIterativos.contarDependiente(n);
                ImprimirResultadoEj1("contarDependiente", n, AlgoritmosIterativos.formulaDependiente(n), "O(n^2)");

                Contador.reiniciar();
                AlgoritmosIterativos.tiempoWhile(n);
                ImprimirResultadoEj1("tiempoWhile", n, AlgoritmosIterativos.formulaWhile(n), "O(log n)");
            }
        }

        static void ImprimirResultadoEj1(string nombre, int n, long formula, string orden)
        {
            long operaciones = Contador.getOperaciones();
            bool coinciden = operaciones == formula;
            Console.WriteLine($"- {nombre}: Op. Contadas = {operaciones}, Fórmula = {formula}. Coinciden: {coinciden}. Orden: {orden}");
        }

        static void ejercicio2()
        {
            Console.WriteLine("--- EJERCICIO 2 ---");
            int[] valoresN = { 5, 10, 20, 25 };

            foreach (int n in valoresN)
            {
                Contador.reiniciar();
                int res1 = AlgoritmosRecursivos.rec1(n);
                long llamadasRec1 = Contador.getOperaciones();

                Contador.reiniciar();
                int res2 = AlgoritmosRecursivos.rec2(n);
                long llamadasRec2 = Contador.getOperaciones();

                long formRec1 = AlgoritmosRecursivos.formulaRec1(n);
                long formRec2 = AlgoritmosRecursivos.formulaRec2(n);
                long vecesMas = llamadasRec2 > 0 ? llamadasRec1 / llamadasRec2 : 0;

                Console.WriteLine($"\nPara n = {n}:");
                Console.WriteLine($"Mismo resultado: {res1 == res2} (Resultado = {res1})");
                Console.WriteLine($"Llamadas rec1: {llamadasRec1} (Fórmula: {formRec1})");
                Console.WriteLine($"Llamadas rec2: {llamadasRec2} (Fórmula: {formRec2})");
                Console.WriteLine($"rec1 hace {vecesMas} veces más llamadas que rec2.");
            }
        }

        static void ejercicio3()
        {
            Console.WriteLine("--- EJERCICIO 3 ---");
            int[] valoresN = { 1000, 10000, 100000, 1000000 };
            ListaDeInscriptos lista = new ListaDeInscriptos(new BusquedaLineal());

            foreach (int n in valoresN)
            {
                lista.cargar(n);
                int legajoBuscado = n + 1;

                lista.setEstrategia(new BusquedaLineal());
                Contador.reiniciar();
                lista.buscar(legajoBuscado);
                long compLineal = Contador.getOperaciones();

                lista.setEstrategia(new BusquedaBinaria());
                Contador.reiniciar();
                lista.buscar(legajoBuscado);
                long compBinaria = Contador.getOperaciones();

                long ganancia = compBinaria > 0 ? compLineal / compBinaria : 0;

                Console.WriteLine($"\nPara n = {n}:");
                Console.WriteLine($"Comparaciones Lineal: {compLineal}");
                Console.WriteLine($"Comparaciones Binaria: {compBinaria}");
                Console.WriteLine($"Ganancia (Lineal / Binaria): {ganancia}");
            }
        }

        static void ejercicio4()
        {
            Console.WriteLine("--- EJERCICIO 4 ---");
            int n = 10000;
            int consultas = 1000;
            int legajoBuscado = 10000;

            IServicioDeAlumnos servicioReal = new ServicioDeAlumnos(n);
            IServicioDeAlumnos servicioProxy = new ServicioDeAlumnosConCache(new ServicioDeAlumnos(n));

            Contador.reiniciar();
            for (int i = 0; i < consultas; i++)
            {
                servicioReal.buscarAlumno(legajoBuscado);
            }
            long compSinProxy = Contador.getOperaciones();

            Contador.reiniciar();
            for (int i = 0; i < consultas; i++)
            {
                servicioProxy.buscarAlumno(legajoBuscado);
            }
            long compConProxy = Contador.getOperaciones();

            long gananciaProxy = compConProxy > 0 ? compSinProxy / compConProxy : 0;

            Console.WriteLine($"Comparaciones sin proxy (1000 consultas): {compSinProxy}");
            Console.WriteLine($"Comparaciones con proxy (1000 consultas): {compConProxy}");
            Console.WriteLine($"Ganancia (Sin Proxy / Con Proxy): {gananciaProxy}");
        }
    }
}