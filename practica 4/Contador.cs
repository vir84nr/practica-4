namespace Practica4
{
    public static class Contador
    {
        private static long operaciones = 0;
        public static void sumar() { operaciones++; }
        public static long getOperaciones() { return operaciones; }
        public static void reiniciar() { operaciones = 0; }
    }
}
