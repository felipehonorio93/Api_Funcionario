using Dapper;
using FuncionariosApi.Data.Entities;
using FuncionariosApi.Data.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncionariosApi.Data.Repositories
{
    /// <summary>
    /// Classe para persistencia de funcionário em banco de dados
    /// </summary>
    public class FuncionarioRepository
    {
        /// <summary>
        /// Método para gravar um funcionário na base de dados
        /// </summary>
        public void Create(Funcionario funcionario)
        {
            using (var connection = new SqlConnection(ConnectionSettings.GetConnectionString))
            {
                connection.Execute(
                        "SP_INSERIR_FUNCIONARIO",
                        new
                        {
                            @NOME = funcionario.Nome,
                            @CPF = funcionario.Cpf,
                            @MATRICULA = funcionario.Matricula,
                            @DATAADMISSAO = funcionario.DataAdmissao
                        },
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

        /// <summary>
        /// Método para atualizar um funcionário na base de dados
        /// </summary>
        public void Update(Funcionario funcionario)
        {
            using (var connection = new SqlConnection(ConnectionSettings.GetConnectionString))
            {
                connection.Execute(
                        "SP_ALTERAR_FUNCIONARIO",
                        new
                        {
                            @IDFUNCIONARIO = funcionario.IdFuncionario,
                            @NOME = funcionario.Nome,
                            @CPF = funcionario.Cpf,
                            @MATRICULA = funcionario.Matricula,
                            @DATAADMISSAO = funcionario.DataAdmissao
                        },
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

        /// <summary>
        /// Método para excluir um funcionário na base de dados
        /// </summary>
        public void Delete(Funcionario funcionario)
        {
            using (var connection = new SqlConnection(ConnectionSettings.GetConnectionString))
            {
                connection.Execute(
                        "SP_EXCLUIR_FUNCIONARIO",
                        new
                        {
                            @IDFUNCIONARIO = funcionario.IdFuncionario
                        },
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

        /// <summary>
        /// Método para consultar os funcionários na base de dados
        /// </summary>
        public List<Funcionario> GetAll()
        {
            using (var connection = new SqlConnection(ConnectionSettings.GetConnectionString))
            {
                return connection.Query<Funcionario>(
                        "SP_CONSULTAR_FUNCIONARIOS",
                        commandType: CommandType.StoredProcedure
                    )
                    .ToList();
            }
        }

        /// <summary>
        /// Método para consultar 1 funcionário pelo ID na base de dados
        /// </summary>
        public Funcionario? GetById(Guid idFuncionario)
        {
            using (var connection = new SqlConnection(ConnectionSettings.GetConnectionString))
            {
                return connection.Query<Funcionario>(
                        "SP_OBTER_FUNCIONARIO",
                        new
                        {
                            @IDFUNCIONARIO = idFuncionario
                        },
                        commandType: CommandType.StoredProcedure
                    )
                    .FirstOrDefault();
            }
        }
    }
}



