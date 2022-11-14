using back_end.Entidades;
using System.Collections.Generic;

namespace back_end.Repositorios
{
    public interface IRepositorio
    {
        Genero ObtenerPorId(int Id);
        List<Genero> ObtenerTodosLosGeneros();
    }
}
