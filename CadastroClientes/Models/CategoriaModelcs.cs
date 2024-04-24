using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroClientes.Models
{
    [Table("Categoria")]
    public class CategoriaModelcs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoriaId { get; set; }

        [Required]
        [StringLength(100)]
        public string Descricao { get; set; }

        [NotMapped]
        public string? Token {  get; set; }

        public CategoriaModelcs()
        {
            
        }

        public CategoriaModelcs(int categoriaId, string descricao, string? token)
        {
            CategoriaId = categoriaId;
            Descricao = descricao;
            Token = token;
        }
    }
}
