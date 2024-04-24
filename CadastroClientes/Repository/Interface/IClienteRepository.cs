using CadastroClientes.Models;

namespace CadastroClientes.Repository.Interface
{
    public interface IClienteRepository
    {
        public IList<ClienteModel> FindAll();

        public ClienteModel FindById(int id);

        public  IList<ClienteModel> FindByNome(string nome);

        public IList<ClienteModel> FindByTelefone(string telefone);

        public IList<ClienteModel> FindByCPF(string cpf);

        public int Insert(ClienteModel clienteModel);

        public ClienteModel Update(ClienteModel clienteModel);

        public bool Delete(int id);
    }
}
