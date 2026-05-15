using System.ComponentModel.DataAnnotations;

namespace Tarefas.Models
{
    public record TarefaDto(
        [Required]
        [MinLength(3, ErrorMessage = "Deve conter pelo menos 3 caracteres")]
        [MaxLength(255, ErrorMessage = "Deve conter no máximo 255 caracteres")]
        string Desc,

        bool Terminado
    );
}