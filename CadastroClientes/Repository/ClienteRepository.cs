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
                                  .FirstOrDefault(cliente => cliente.ClienteId == id);

            return cliente; 
        }

        public IList<ClienteModel> FindByNome(string nome)
        {
            var cliente = _dataContext.Clientes
                                      .Include(c => c.CategoriaCliente)
                                      .Where(n => n.NomeCompleto.Contains(nome))
                                      .ToList();

            return cliente == null ? new List<ClienteModel>() : cliente;
        }

        public IList<ClienteModel> FindByCPF(string cpf)
        {
           var cliente = _dataContext.Clientes
                                      .Include(c => c.CategoriaCliente)
                                      .Where(c => c.CPF.Contains(cpf))
                                      .ToList();

            return cliente; 
        }

        public IList<ClienteModel> FindByTelefone(string telefone)
        {
            var cliente = _dataContext.Clientes
                                       .Include(c => c.CategoriaCliente)
                                       .Where(c => c.Telefone.Contains(telefone))
                                       .ToList();

            return cliente;
        }
        public int Insert(ClienteModel clienteModel)
        {
           _dataContext.Clientes.Add(clienteModel);
           _dataContext.SaveChanges(); 

            return clienteModel.ClienteId;
        }
        public ClienteModel Update(ClienteModel clienteModel)
        {
            ClienteModel clienteDB = FindById(clienteModel.ClienteId); 
            
            if (clienteDB == null) throw new Exception("Erro no update de clientes. Não há clientes cadastrados!");

            clienteDB.NomeCompleto = clienteModel.NomeCompleto; 
            clienteDB.CPF = clienteModel.CPF;
            clienteDB.Telefone = clienteModel.Telefone;
            clienteDB.CEP = clienteModel.CEP;
            clienteDB.Logradouro = clienteModel.Logradouro;
            clienteDB.Bairro = clienteModel.Bairro;
            clienteDB.Cidade = clienteModel.Cidade;
            clienteDB.Uf = clienteModel.Uf;
            clienteDB.Numero = clienteModel.Numero;

            _dataContext.Clientes.Update(clienteDB);
            _dataContext.SaveChanges(); 

            return clienteDB; 
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
