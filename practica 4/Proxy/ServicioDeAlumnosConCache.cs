using System.Collections.Generic;

namespace Practica4.Proxy
{
    public class ServicioDeAlumnosConCache : IServicioDeAlumnos
    {
        private IServicioDeAlumnos servicioReal;
        private Dictionary<int, Alumno> cache = new Dictionary<int, Alumno>();

        public ServicioDeAlumnosConCache(IServicioDeAlumnos servicioReal)
        {
            this.servicioReal = servicioReal;
        }

        public Alumno buscarAlumno(int legajo)
        {
            if (cache.ContainsKey(legajo))
            {
                return cache[legajo];
            }

            Alumno a = servicioReal.buscarAlumno(legajo);
            if (a != null)
            {
                cache.Add(legajo, a);
            }
            return a;
        }
    }
}