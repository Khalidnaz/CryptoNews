using CryptoProject.Adapter;
using CryptoProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CryptoProject.Services
{
    public class BlogService : BaseService, IBlogService
    {
        public IEnumerable<BlogDomain> SelectAll()
        {
            DbCmdDef cmdDef = new DbCmdDef
            {
                DbCommandText = "dbo.Review_SelectAll",
                DbCommandType = System.Data.CommandType.StoredProcedure,

            };
            return Adapter.LoadObject<BlogDomain>(cmdDef);
        }

    }
}