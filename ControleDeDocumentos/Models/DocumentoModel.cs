using System.ComponentModel.DataAnnotations;

namespace ControleDeDocumentos.Models
{
    public class DocumentoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o código do documento")]
        public int Codigo { get; set; }
        [Required(ErrorMessage = "Digite o título do documento")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Digite o processo do documento")]
        public string Processo { get; set; }
        [Required(ErrorMessage = "Digite a categoria do documento")]
        public string Categoria { get; set; }
        [Required(ErrorMessage = "Digite a extensão do arquivo do documento")]
        public string Arquivo { get; set; }
    }
}
