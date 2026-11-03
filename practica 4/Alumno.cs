namespace Practica4
{
    public class Alumno
    {
        private int legajo;
        private string nombre;

        public Alumno(int legajo, string nombre)
        {
            this.legajo = legajo;
            this.nombre = nombre;
        }

        public int getLegajo() { return legajo; }
        public string getNombre() { return nombre; }
    }
}