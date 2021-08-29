using System;
using System.Data;
using System.Data.SqlClient;
using BoBStore.Shared;

namespace BobStore.Infra.DataContexts
{
    public class BoBDataContext : IDisposable
    {
        public SqlConnection Connection { get; set; }

        // Cria e abre a conexão com o BD
        public BoBDataContext()
        {
            Connection = new SqlConnection(Settings.ConnectionString);
            Connection.Open();
        }

        // Fecha a conexão caso esteja aberta.
        public void Dispose()
        {

            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
    }
}