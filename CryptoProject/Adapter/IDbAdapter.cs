using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CryptoProject.Adapter
{
    public interface IDbAdapter
    {
        int CommandTimeout { get; set; }
        IDbCommand DbCommand { get; }
        IDbConnection DbConnection { get; }


        int ExecuteQuery(IDbCmdDef cmDef, Action<IDataParameterCollection> returnParameters = null);
        object ExecuteScalar(IDbCmdDef cmDef);
        IEnumerable<T> LoadObject<T>(IDbCmdDef cmDef) where T : class;
        IEnumerable<T> LoadObject<T>(IDbCmdDef cmDef, Func<IDataReader, T> mapper) where T : class;
    }
}