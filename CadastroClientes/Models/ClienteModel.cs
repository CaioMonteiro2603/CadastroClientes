using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroClientes.Models
{
    [Table("Cliente")]
    public class ClienteModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string NomeCompleto { get; set; }

        [Required]
        [StringLength(15)]
        public string CPF { get; set; }

        [Required]
        public string Telefone { get; set; }

        [Required]
        public string Logradouro { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required]
        public string Bairro { get; set; }

        [Required]
        public string CEP { get; set; }

        [Required]
        public string Cidade { get; set; }
    }
}
