using System.Collections.Generic;

namespace Practica4.Strategy
{
    public class BusquedaLineal : EstrategiaDeBusqueda
    {
        public Alumno Buscar(List<Alumno> alumnos, int legajo)
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