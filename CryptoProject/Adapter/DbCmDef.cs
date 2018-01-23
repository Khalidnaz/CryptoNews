using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace CryptoProject.Adapter
{
    public class DbCmdDef : IDbCmdDef
    {
        public string DbCommandText { get; set; }

        public CommandType DbCommandType { get; set; }

        public IDbDataParameter[] DbParameters { get; set; }

    }
}