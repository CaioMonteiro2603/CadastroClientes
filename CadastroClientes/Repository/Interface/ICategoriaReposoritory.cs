using CadastroClientes.Models;

namespace CadastroClientes.Repository.Interface
{
    public interface ICategoriaReposoritory
    {
        public IList<CategoriaModelcs> FindAll();

        public CategoriaModelcs FindById(int id);

        public int Insert(CategoriaModelcs Categoriamodel);

        public CategoriaModelcs Update(CategoriaModelcs categoriaModel);

        public bool Delete(int id);

    }
}
