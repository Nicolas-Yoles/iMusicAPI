using back_end.Repositorios;

namespace back_end.Controllers
{
    public class GenerosController
    {
        private IRepositorio repositorio;

        public GenerosController(IRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }
    }
}
