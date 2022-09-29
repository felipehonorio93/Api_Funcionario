using System.ComponentModel.DataAnnotations;

namespace FuncionariosApi.Services.Requests
{
    /// <summary>
    /// Modelo de dados para a requisição de atualização de funcionários
    /// </summary>
    public class FuncionariosPutRequest
    {
        [Required(ErrorMessage = "Campo obrigatório.")]
        public Guid IdFuncionario { get; set; }

        [MinLength(6, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Nome { get; set; }

        [RegularExpression("^[0-9]{11}$", ErrorMessage = "Informe 11 dígitos numéricos.")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Cpf { get; set; }

        [RegularExpression("^[0-9]{6,10}$", ErrorMessage = "Informe de 6 a 10 dígitos numéricos.")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Matricula { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public DateTime DataAdmissao { get; set; }
    }
}



