using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace CryptoProject.Adapter
{
    public interface IDbCmdDef
    {
        string DbCommandText { get; set; }
        CommandType DbCommandType { get; set; }
        IDbDataParameter[] DbParameters { get; set; }
    }
}