using CadastroClientes.Migrations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroClientes.Models
{
    [Table("Cliente")]
    public class ClienteModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClienteId { get; set; }

        [Required (ErrorMessage = "Campo para o nome é obrigatório!")]
        [StringLength(80)] 
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório!")]
        [StringLength(15)]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O campo telefone é obrigatório!")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo CEP é obrigatório!")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "O campo logradouro é obrigatório!")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O campo bairro é obrigatório!")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo cidade é obrigatório!")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O campo UF é obrigatório!")]
        public string Uf {  get; set; }

        [Required(ErrorMessage = "O campo número é obrigatório!")]
        public int Numero { get; set; }

        public string CategoriaCliente { get; set; }

        public ClienteModel()
        {
            
        }

        public ClienteModel(int clienteId, string nomeCompleto, string cPF, string telefone, string cEP,
            string logradouro, string bairro, string cidade, string uf, int numero, string categoriaCliente)
        {
            ClienteId = clienteId;
            NomeCompleto = nomeCompleto;
            CPF = cPF;
            Telefone = telefone;
            CEP = cEP;
            Logradouro = logradouro;
            Bairro = bairro;
            Cidade = cidade;
            Uf = uf;
            Numero = numero;
            CategoriaCliente = categoriaCliente;
        }
    }
}
