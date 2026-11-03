using System.Collections.Generic;

namespace Practica4.Strategy
{
    public class ListaDeInscriptos
    {
        private EstrategiaDeBusqueda estrategia;
        private List<Alumno> alumnos = new List<Alumno>();

        public ListaDeInscriptos(EstrategiaDeBusqueda estrategia)
        {
            this.estrategia = estrategia;
        }

        public void cargar(int n)
        {
            alumnos.Clear();
            for (int i = 1; i <= n; i++)
            {
                alumnos.Add(new Alumno(i, "Alumno " + i));
            }
        }

        public void setEstrategia(EstrategiaDeBusqueda estrategia)
        {
            this.estrategia = estrategia;
        }

        public Alumno buscar(int legajo)
        {
            return estrategia.Buscar(alumnos, legajo);
        }
    }
}
