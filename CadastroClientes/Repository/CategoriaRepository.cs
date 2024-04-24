using CadastroClientes.Data;
using CadastroClientes.Models;
using CadastroClientes.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace CadastroClientes.Repository
{
    public class CategoriaRepository : ICategoriaReposoritory
    {
        private readonly DataContext _dataContext; 
        public CategoriaRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IList<CategoriaModelcs> FindAll()
        {
            var categoria = _dataContext.Categorias.ToList();

            return categoria;
        }

        public CategoriaModelcs FindById(int id)
        {
            var categoria = _dataContext.Categorias
                                        .AsNoTracking()
                                        .FirstOrDefault(c => c.CategoriaId == id);

            return categoria; 
        }

        public int Insert(CategoriaModelcs Categoriamodel)
        {
            _dataContext.Categorias.Add(Categoriamodel);
            _dataContext.SaveChanges();

            return Categoriamodel.CategoriaId; 
        }

        public CategoriaModelcs Update(CategoriaModelcs categoriaModel)
        {
            CategoriaModelcs categoriaDB = FindById(categoriaModel.CategoriaId);

            if (categoriaDB == null) throw new Exception("Erro no update de categoria!");

            categoriaDB.Descricao = categoriaModel.Descricao;
            categoriaDB.Token  = categoriaModel.Token;

            _dataContext.Categorias.Update(categoriaDB);
            _dataContext.SaveChanges();

            return categoriaDB; 
        }

        public bool Delete(int id)
        {
            CategoriaModelcs categoria = FindById(id);

            if (categoria == null) throw new Exception("Erro ao apagar a categoria!"); 
            _dataContext.Categorias.Remove(categoria);
            _dataContext.SaveChanges();

            return true; 
        }
    }
}
