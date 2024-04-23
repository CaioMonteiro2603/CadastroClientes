using CadastroClientes.Data;
using CadastroClientes.Models;
using CadastroClientes.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace CadastroClientes.Repository
{   
    public class ClienteRepository : IClienteRepository
    {

        private readonly DataContext _dataContext;

        public ClienteRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IList<ClienteModel> FindAll()
        {
            var cliente = _dataContext.Clientes.ToList();

            return cliente;
        }
        public ClienteModel FindById(int id)
        {
            var cliente = _dataContext.Clientes
                                  .AsNoTracking()
                                  .FirstOrDefault(cliente => cliente.Id == id);

            return cliente; 
        }
        public int Insert(ClienteModel clienteModel)
        {
           _dataContext.Clientes.Add(clienteModel);
           _dataContext.SaveChanges(); 

            return clienteModel.Id;
        }
        public void Update(ClienteModel clienteModel)
        {
            ClienteModel clienteNew = FindById(clienteModel.Id);

            if (clienteNew == null) throw new Exception("Erro no update de clientes. Não há clientes cadastrados!");

            clienteNew.NomeCompleto = clienteModel.NomeCompleto;
            clienteNew.CPF = clienteModel.CPF;
            clienteNew.Telefone = clienteModel.Telefone;
            clienteNew.Logradouro = clienteModel.Logradouro;
            clienteNew.Numero = clienteModel.Numero;
            clienteNew.Bairro = clienteModel.Bairro;
            clienteNew.CEP = clienteModel.CEP;
            clienteNew.Cidade = clienteModel.Cidade;

            _dataContext.Clientes.Update(clienteModel);
            _dataContext.SaveChanges();
        }
        public bool Delete(int id)
        {
            ClienteModel clienteModel = FindById(id);

            if (clienteModel == null) throw new Exception("Erro ao deletar cliente, não há o que deletar!");

            _dataContext.Remove(clienteModel);
            _dataContext.SaveChanges();

            return true;
        }
    }
}
