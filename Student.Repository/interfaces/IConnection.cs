using System.Collections.Generic;
using System.Data;

namespace Student.Repository.interfaces
{
    public interface IConnection
    {
        DataTable Execute(string sentence, Dictionary<string, object> parameters = null);
    }
}
