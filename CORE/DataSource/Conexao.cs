using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Configuration;     

namespace CORE.DataSource
{
    class Conexao : DbContext 
    {
        public Conexao() : base(ConfigurationManager.ConnectionStrings["Banco"].ConnectionString)
        {

        }
    }
}
