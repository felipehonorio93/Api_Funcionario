using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncionariosApi.Data.Settings
{ /// <summary>
  /// Classe para capturar a connectionstring do banco de dados
  /// </summary>
    public static class ConnectionSettings
    {
        //método estático para retornar a connectionstring
        public static string GetConnectionString
            => @"Data Source=(localdb)\MSSQLLocalDB;
                Initial Catalog=BDFuncionariosApi;
                Integrated Security=True;Connect Timeout=30;
                Encrypt=False;
                TrustServerCertificate=False;
                ApplicationIntent=ReadWrite;
                MultiSubnetFailover=False";
    }

}
