using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Connections.Database;

namespace GestionServiceBatiment.DAL.Repositories.Implementations
{
    public abstract class BaseRepository
    {
        protected Connection _connection;

        public BaseRepository()
        {
            _connection = new Connection(
                SqlClientFactory.Instance,
                ConfigurationManager.ConnectionStrings["GestionServiceBatiment"].ConnectionString
            );
        }
    }
}
