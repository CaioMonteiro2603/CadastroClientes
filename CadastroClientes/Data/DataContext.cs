using CadastroClientes.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroClientes.Data
{
    public class DataContext :DbContext
    {
        public DbSet<ClienteModel> Clientes { get; set;}
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected DataContext()
        {
        }



    }
}
