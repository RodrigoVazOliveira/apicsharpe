using System.ComponentModel.DataAnnotations;

namespace filmesApi;

public record Film([Required(ErrorMessage = "O campo Title é obrigatório")]
                    string Title,
                    
                    [Required(ErrorMessage = "O campo Gender é obrigatório")]
                    [MaxLength(50, ErrorMessage = "O campo Gender possuir no máximo 50 caracteres")]
                    [MinLength(3, ErrorMessage = "O campo Gender deve possuir no mínimo 3 caracteres")]
                    string Gender,
                    
                    [Required]
                    [Range(60, 600, ErrorMessage = "O campo Duration deve possuir um valor entre 60 e 600")]
                    int Duration);