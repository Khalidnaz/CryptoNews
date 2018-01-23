using CryptoProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CryptoProject.Services
{
    public interface IBlogService
    {
        IEnumerable<BlogDomain> SelectAll();
    }
}