using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncionariosApi.Data.Entities
{
    /// <summary>
    /// Classe de entidade para o banco de dados
    /// </summary>

    public class Funcionario
    {
        #region Propriedades

        public Guid IdFuncionario { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Matricula { get; set; }
        public DateTime DataAdmissao { get; set; }

        #endregion

    }
}
