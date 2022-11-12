using Microsoft.Extensions.Configuration;
using Student.Repository.interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace Student.Repository.connection
{
    public class Connection : IConnection
    {
        private readonly IConfiguration configuration;
        public Connection(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        private SQLiteConnection Connect()
        {
            string datasource = configuration.GetConnectionString("db");
            return new SQLiteConnection($"Data Source={datasource}; Version = 3; New = True; Compress = True; ");
        }

        public DataTable Execute(string sentence, Dictionary<string, object> parameters = null)
        {
            SQLiteCommand command = new SQLiteCommand(sentence, Connect());
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = param.Key;
                    parameter.Value = param.Value;
                    command.Parameters.Add(parameter);
                }
            }
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            DataSet data = new DataSet();
            adapter.Fill(data);
            return data.Tables.Count > 0 ? data.Tables[0] : null;
        }
    }
}
