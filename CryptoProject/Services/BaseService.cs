using CryptoProject.Adapter;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CryptoProject.Services
{
    public class BaseService
    {
        public IDbAdapter Adapter
        {
            get
            {
                return new DbAdapter(new SqlCommand(), new SqlConnection("Server=DESKTOP-BT9ATT1\\SQLEXPRESS; Database=GameReview;Trusted_Connection=True"));
            }
        }
    }
}