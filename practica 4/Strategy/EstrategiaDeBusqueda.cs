using System.Collections.Generic;

namespace Practica4.Strategy
{
    public interface EstrategiaDeBusqueda
    {
        Alumno Buscar(List<Alumno> alumnos, int legajo);
    }
}
