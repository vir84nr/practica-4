using System.Collections.Generic;

namespace Practica4.Proxy
{
    public class ServicioDeAlumnos : IServicioDeAlumnos
    {
        private List<Alumno> alumnos = new List<Alumno>();

        public ServicioDeAlumnos(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                alumnos.Add(new Alumno(i, "Alumno " + i));
            }
        }

        public Alumno buscarAlumno(int legajo)
        {
            foreach (var a in alumnos)
            {
                Contador.sumar();
                if (a.getLegajo() == legajo) return a;
            }
            return null;
        }
    }
}