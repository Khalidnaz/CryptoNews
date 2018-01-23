using CryptoProject.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoProject.Adapter
{
    public class DbAdapter : IDbAdapter
    {
        public IDbCommand DbCommand { get; private set; }
        public IDbConnection DbConnection { get; private set; }
        //5 second timeout
        int _cmdTimeout = 5000;

        public int CommandTimeout
        {
            get { return _cmdTimeout; }
            set { _cmdTimeout = value; }
        }


        public DbAdapter(IDbCommand dbCommand, IDbConnection dbConnection)
        {

            DbCommand = dbCommand;
            DbConnection = dbConnection;
        }

        public IEnumerable<T> LoadObject<T>(IDbCmdDef cmDef) where T : class
        {


            try
            {
                if (cmDef == null)
                    throw new ArgumentException("Missing command definition");



                List<T> itms = new List<T>();
                using (IDbConnection conn = DbConnection)
                using (IDbCommand cmd = DbCommand)
                {

                    if (conn.State != ConnectionState.Open) { conn.Open(); }


                    cmd.CommandTimeout = CommandTimeout;
                    cmd.CommandType = cmDef.DbCommandType;
                    cmd.CommandText = cmDef.DbCommandText;

                    cmd.Connection = conn;


                    if (cmDef.DbParameters != null)
                        foreach (IDbDataParameter param in cmDef.DbParameters)
                            cmd.Parameters.Add(param);

                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        itms.Add(DataMapper<T>.Instance.MapToObject(reader));
                    }
                    return itms;


                }
            }
            catch { throw; }
        }

        public IEnumerable<T> LoadObject<T>(IDbCmdDef cmDef, Func<IDataReader, T> mapper) where T : class
        {
            try
            {
                if (cmDef == null)
                    throw new ArgumentException("Missing command definition");


                List<T> itms = new List<T>();
                using (IDbConnection conn = DbConnection)
                using (IDbCommand cmd = DbCommand)
                {

                    if (conn.State != ConnectionState.Open) { conn.Open(); }


                    cmd.CommandTimeout = CommandTimeout;
                    cmd.CommandType = cmDef.DbCommandType;
                    cmd.CommandText = cmDef.DbCommandText;

                    cmd.Connection = conn;

                    if (cmDef.DbParameters != null)
                        foreach (IDbDataParameter param in cmDef.DbParameters)
                            cmd.Parameters.Add(param);

                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        itms.Add(mapper(reader));
                    }
                    return itms;


                }
            }
            catch { throw; }
        }

        public int ExecuteQuery(IDbCmdDef cmDef, Action<IDataParameterCollection> returnParameters = null)
        {
            try
            {
                using (IDbConnection conn = DbConnection)
                using (IDbCommand cmd = DbCommand)
                {
                    if (conn.State != ConnectionState.Open) { conn.Open(); }
                    cmd.CommandTimeout = CommandTimeout;
                    cmd.CommandType = cmDef.DbCommandType;
                    cmd.CommandText = cmDef.DbCommandText;
                    cmd.Connection = conn;

                    if (cmDef.DbParameters != null)
                        foreach (IDbDataParameter param in cmDef.DbParameters)
                            cmd.Parameters.Add(param);


                    int returnVal = cmd.ExecuteNonQuery();
                    returnParameters?.Invoke(cmd.Parameters);

                    return returnVal;
                }
            }

            catch { throw; }
        }

        public object ExecuteScalar(IDbCmdDef cmDef)
        {
            try
            {
                using (IDbConnection conn = DbConnection)
                using (IDbCommand cmd = DbCommand)
                {
                    if (conn.State != ConnectionState.Open) { conn.Open(); }
                    cmd.CommandTimeout = CommandTimeout;
                    cmd.CommandType = cmDef.DbCommandType;
                    cmd.CommandText = cmDef.DbCommandText;
                    cmd.Connection = conn;

                    if (cmDef.DbParameters != null)
                        foreach (IDbDataParameter param in cmDef.DbParameters)
                            cmd.Parameters.Add(param);



                    return cmd.ExecuteScalar();
                }
            }
            catch { throw; }
        }

    }
}