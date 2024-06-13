using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace WS.Models
{
    [Table("Pesquisa")]
    public class Pesquisa
    {
        [Key]
        public int Id { get; set; }
        [NotNull]
        [Display(Name = "Digite Seu Nome")]
        public string Nome { get; set; }
        [NotNull]
        public int Pergunta1 { get; set; }
        [NotNull]
        public int Pergunta2 { get; set; }
        [NotNull]
        public int Pergunta3 { get; set; }
        [NotNull]
        public double Resultado { get; set; }
    }
}
