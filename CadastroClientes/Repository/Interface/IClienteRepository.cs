using CadastroClientes.Models;

namespace CadastroClientes.Repository.Interface
{
    public interface IClienteRepository
    {
        public IList<ClienteModel> FindAll();

        public ClienteModel FindById(int id);

        public int Insert(ClienteModel clienteModel);

        public void Update(ClienteModel clienteModel);

        public bool Delete(int id);
    }
}
