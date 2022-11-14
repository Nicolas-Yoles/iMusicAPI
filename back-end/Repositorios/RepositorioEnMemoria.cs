using back_end.Entidades;
using System.Collections.Generic;

namespace back_end.Repositorios
{
    public class RepositorioEnMemoria: IRepositorio
    {
        private List<Genero> _generos;

        public RepositorioEnMemoria()
        {
            _generos = new List<Genero>()
            {
                new Genero(){ Id = 1, Nombre = "Comedia"},
                new Genero(){ Id = 2, Nombre = "Accion"}
            };
        }

        public List<Genero> ObtenerTodosLoSGeneros()
        {
            return _generos;
        }
    }
}
